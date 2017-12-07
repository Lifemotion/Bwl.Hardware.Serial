Imports Bwl.Hardware.SimplSerial



Public Class FirmwareUpdaterTool
    Private _ss As SimplSerialBus
    Private _fwUpdater As FirmwareUploader
    Private _parameters As FirmwareUpdaterParameters
    Private _logger As New Logger
    Private _fwBin As Byte()

    Public Sub New(fwBin As Byte(), updateFileName As String, ss As SimplSerialBus, parameters As FirmwareUpdaterParameters)
        _parameters = parameters
        _ss = ss

        InitializeComponent()
        tbFindBootName.Text = _parameters.bootName
        tbFindMainName.Text = _parameters.mainName
        tbFindWorkAddress.Text = _parameters.workAddress

        If ss Is Nothing Then
            Me._ss = New SimplSerialBus
            Me._ss.SerialDevice.DeviceSpeed = _parameters.baud
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
        tbUpdateFile.Text = updateFileName
        _fwBin = fwBin
        Try
            Dim text = System.Text.Encoding.ASCII.GetString(_fwBin)
            Dim pos = InStr(text, _parameters.mainName)
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
        Text = _parameters.mainName + ", " + _parameters.bootName + " - " + Text + " " + Application.ProductVersion.ToString
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
                      tbConnectedGuid.Text = info.DeviceGuid.ToString + " (" + (info.DeviceGuid.ToByteArray(15) + +info.DeviceGuid.ToByteArray(14) * 256).ToString + ")"
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
        _logger.AddMessage("Простой поиск устройства (Address=" + _parameters.workAddress.ToString + ")")
        Dim guid As Guid = FindDeviceSimple(_parameters.workAddress)
        If guid.ToString = Guid.Empty.ToString And _parameters.workAddress > 0 Then
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
            If _parameters.bootName > "" And info.DeviceName.Contains(_parameters.bootName) Then
                _logger.AddMessage("Найдено устройство " + info.DeviceName +
                                   " в режиме загрузчика, с совпадающим именем (" + _parameters.bootName + ").")
                Return info.DeviceGuid
            End If
        Else
            If _parameters.mainName > "" And info.DeviceName.Contains(_parameters.mainName) Then
                _logger.AddMessage("Найдено устройство " + info.DeviceName +
                                   " в основном режиме, с совпадающим именем (" + _parameters.mainName + ").")
                Return info.DeviceGuid
            End If
        End If
        Return Guid.Empty
    End Function

    Private Sub FirmwareUpdate(guid As Guid)
        _logger.AddMessage("Начало обновления для " + guid.ToString)
        Dim address = _parameters.workAddress
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
        If _parameters.additionalRestart Then
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
                    If info.DeviceName.Contains(_parameters.mainName) Or _parameters.mainName = "" Then
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
            Dim address = _parameters.workAddress
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

    Private Sub bSimplSerialTool_Click(sender As Object, e As EventArgs) Handles bSimplSerialTool.Click
        Dim tool As New SimplSerialTool(_ss)
        tool.Show()
    End Sub
End Class

Public Class FirmwareUpdaterParameters
    Public bootName As String = ""
    Public mainName As String = ""
    Public workAddress As Integer
    Public baud As Integer
    Public additionalRestart As Boolean

    Public Sub New()

    End Sub

    Public Sub New(parametersString As String)
        Dim parametersStrings = parametersString.Split(",")
        For Each keyValueString In parametersStrings
            Dim keyValue = keyValueString.Split("=")
            If keyValue.Length = 2 Then
                Select Case keyValue(0)
                    Case "BN" : bootName = keyValue(1)
                    Case "MN" : mainName = keyValue(1)
                    Case "WA" : workAddress = keyValue(1)
                    Case "BAUD" : baud = keyValue(1)
                    Case "AR" : additionalRestart = keyValue(1).Trim.ToLower = "true"
                End Select
            End If
        Next
    End Sub
End Class