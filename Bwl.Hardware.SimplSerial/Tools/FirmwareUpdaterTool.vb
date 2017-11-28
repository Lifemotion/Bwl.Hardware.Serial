Imports Bwl.Hardware.SimplSerial

Public Class FirmwareUpdaterTool
    Private _hexName As String
    Private _ss As SimplSerialBus
    Private _fwUpdater As FirmwareUploader
    Private _bootName As String
    Private _mainName As String
    Private _workAddress As Integer
    Private _logger As New Logger
    Private _fwBin As Byte()
    Private _additionalRestart As Boolean

    Public Sub New(hexName As String, ss As SimplSerialBus, bootName As String, mainName As String, workAddress As Integer, baud As Integer, additionalRestart As Boolean)
        _hexName = hexName
        _ss = ss
        _bootName = bootName
        _mainName = mainName
        _workAddress = workAddress
        _additionalRestart = additionalRestart
        InitializeComponent()
        tbFindBootName.Text = bootName
        tbFindMainName.Text = mainName
        tbFindWorkAddress.Text = workAddress

        If ss Is Nothing Then
            Me._ss = New SimplSerialBus
            Me._ss.SerialDevice.DeviceSpeed = baud
            SerialSelector1.Enabled = True
        Else
            SerialSelector1.Enabled = False
        End If
        SerialSelector1.AssociatedISerialDevice = _ss.SerialDevice
        SerialSelector1.LoadFromDevice()
        SerialSelector1.SaveToDevice()
        _fwUpdater = New FirmwareUploader(_ss)
        AddHandler _fwUpdater.Logger, Sub(type As String, msg As String)
                                          Select Case type
                                              Case "INF" : _logger.AddInformation(msg)
                                              Case "MSG" : _logger.AddMessage(msg)
                                              Case "WRN" : _logger.AddWarning(msg)
                                              Case "ERR" : _logger.AddError(msg)
                                              Case Else : _logger.AddDebug(msg)
                                          End Select
                                      End Sub
        _logger.ConnectWriter(DatagridLogWriter1)
        tbUpdateFile.Text = IO.Path.GetFileName(hexName).Split(",")("0")
        _fwBin = FirmwareUploader.LoadFirmwareFromFile(hexName)
        Try
            Dim text = System.Text.Encoding.ASCII.GetString(_fwBin)
            Dim pos = InStr(text, mainName)
            If pos > 0 Then
                For i = pos To text.Length - 1
                    If _fwBin(i) = 0 Then
                        Dim fwDevname = text.Substring(pos - 1, i - pos)
                        tbUpdateName.Text = fwDevname
                        Exit For
                    End If
                Next
            End If
        Catch ex As Exception
            tbUpdateName.Text = "не удалось извлечь"
        End Try
        Text = mainName + ", " + bootName + " - " + Text + " " + Application.ProductVersion.ToString
    End Sub

    Public Sub CheckConnected()
        If _ss.IsConnected = False Then
            _logger.AddMessage("Устройство не подключено. Попытка подключения (" + _ss.SerialDevice.DeviceAddress + ", " + _ss.SerialDevice.DeviceSpeed.ToString + ")...")
            Try
                _ss.Connect()
            Catch ex As Exception
                _logger.AddError(ex.Message)
            End Try
        End If
    End Sub

    Private Sub ShowInfo(info As DeviceInfo)
        Me.Invoke(Sub()
                      tbConnectedAddress.Text = info.Response.FromAddress
                      tbConnectedGuid.Text = info.DeviceGuid.ToString
                      tbConnectedName.Text = info.DeviceName
                      tbConnectedDate.Text = info.DeviceDate
                  End Sub)
    End Sub

    Private Sub bUpdate_Click(sender As Object, e As EventArgs) Handles bUpdate.Click
        Dim thr As New Threading.Thread(Sub()
                                            EnableButtons(False)
                                            Try
                                                Dim guid = FindDevice()
                                                _logger.AddMessage("Устройство найдено.")
                                                FirmwareUpdate(guid)
                                            Catch ex As Exception
                                                _logger.AddError(ex.Message + " Невозможно продолжить.")
                                            End Try
                                            EnableButtons(True)
                                        End Sub)
        thr.Start()
    End Sub

    Private Sub bFindDevice_Click(sender As Object, e As EventArgs) Handles bFindDevice.Click
        Dim thr As New Threading.Thread(Sub()
                                            EnableButtons(False)
                                            Try
                                                Dim guid = FindDevice()
                                                _logger.AddMessage("Устройство найдено.")
                                            Catch ex As Exception
                                                _logger.AddError(ex.Message + " Невозможно продолжить.")
                                            End Try
                                            EnableButtons(True)
                                        End Sub)
        thr.Start()
    End Sub

    Private Sub EnableButtons(enabled As Boolean)
        Me.Invoke(Sub()
                      bUpdate.Enabled = enabled
                      bFindDevice.Enabled = enabled
                  End Sub)
    End Sub

    Private Function FindDevice() As Guid
        CheckConnected()
        _logger.AddMessage("Простой поиск устройства (Address=" + _workAddress.ToString + ")")
        Dim guid As Guid = FindDeviceSimple(_workAddress)
        If guid.ToString = Guid.Empty.ToString And _workAddress > 0 Then
            _logger.AddMessage("Простой поиск устройства (Address=" + 0.ToString + ")")
            guid = FindDeviceSimple(0)
        End If
        If guid.ToString = Guid.Empty.ToString Then Throw New Exception("Подходящее устройство не найдено. Проверьте подключение и настройки порта.")
        Return guid
    End Function

    Private Function FindDeviceSimple(address As Integer) As Guid
        Dim info = _ss.RequestDeviceInfo(address)
        ShowInfo(info)
        If info.BootloaderMode Then
            If _bootName > "" And info.DeviceName.Contains(_bootName) Then
                _logger.AddMessage("Найдено устройство " + info.DeviceName +
                                   " в режиме загрузчика, с совпадающим именем (" + _bootName + ").")
                Return info.DeviceGuid
            End If
        Else
            If _mainName > "" And info.DeviceName.Contains(_mainName) Then
                _logger.AddMessage("Найдено устройство " + info.DeviceName +
                                   " в основном режиме, с совпадающим именем (" + _mainName + ").")
                Return info.DeviceGuid
            End If
        End If
        Return Guid.Empty
    End Function

    Private Sub FirmwareUpdate(guid As Guid)
        _logger.AddMessage("Начало обновления для " + guid.ToString)
        Dim address = _workAddress
        If address = 0 Then
            Dim rnd As New Random
            address = rnd.Next(1, 30000)
        End If
        'переход в загрузчик
        _ss.RequestSetAddress(guid, address)
        Try
            _ss.RequestGoToBootloader(address)
        Catch ex As Exception
        End Try
        'стираем прошивку
        _ss.RequestSetAddress(guid, address)
        _fwUpdater.EraseAllFast(address)
        'перезагружаемся, чтобы контроллер перешел в дефолтный режим
        If _additionalRestart Then
            _logger.AddMessage("Дополнительный рестарт")
            _ss.RequestRestart(address)
            Threading.Thread.Sleep(1000)
        End If
        'выполняем прошивку
        _ss.RequestSetAddress(guid, address)
        _fwUpdater.RequestBootInfo(address)
        _fwUpdater.EraseAndFlashAllFast(address, _fwBin, 32)
        _logger.AddMessage("Прошивка завершена!")
        Try
            _ss.RequestGoToMain(address)
        Catch ex As Exception
        End Try
        Try
            _ss.RequestRestart(address)
        Catch ex As Exception
        End Try
        'ожидаем возвращения из загрузчика и запуска
        For i = 1 To 30
            Try
                _logger.AddInformation("Ожидание выхода из загрузчика " + i.ToString + "...")
                _ss.RequestSetAddress(guid, address)
                Dim info = _ss.RequestDeviceInfo(address)
                ShowInfo(info)
                If info.BootloaderMode = False And info.DeviceName > "" Then
                    If info.DeviceName.Contains(_mainName) Or _mainName = "" Then
                        _logger.AddMessage("Устройство вышло из загрузчика и имеет правильное имя " + info.DeviceName)
                        _logger.AddMessage("Процедура обновления полностью завершена.")
                        Exit Sub
                    Else
                        Throw New Exception("Устройство вышло из загрузчика, но имеет неправильное имя: " + info.DeviceName)
                        Exit Sub
                    End If
                End If
            Catch ex As Exception
            End Try
            Threading.Thread.Sleep(1000)
        Next
        Throw New Exception("Устройство не вышло из загрузчика.")
    End Sub

    Private Sub bRequestInfo_Click(sender As Object, e As EventArgs) Handles bRequestInfo.Click
        Try
            If tbConnectedGuid.Text = "" Then Throw New Exception("Устройство еще не было найдено.")
            CheckConnected()
            Dim address = _workAddress
            If address = 0 Then
                Dim rnd As New Random
                address = rnd.Next(1, 3000)
            End If
            _ss.RequestSetAddress(New Guid(tbConnectedGuid.Text), address)
            Dim info = _ss.RequestDeviceInfo(address)
            If info.Response.ResponseState <> ResponseState.ok Then Throw New Exception("Нет ответа.")
            ShowInfo(info)
        Catch ex As Exception
            _logger.AddError(ex.Message + " Невозможно продолжить.")
        End Try
    End Sub
End Class