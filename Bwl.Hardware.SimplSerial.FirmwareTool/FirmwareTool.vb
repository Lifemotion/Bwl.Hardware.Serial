Imports System.Windows.Forms

Public Class FirmwareTool
    Inherits Form
    Private Shared _form As FirmwareTool
    Private _logger As Logger
    Private _sserial As SimplSerialBus
    Private _rnd As New Random
    Private _flasher As FirmwareUploader

    Public Sub New()
        Me.New(New SimplSerialBus)
    End Sub

    Public Sub New(sserial As SimplSerialBus)
        InitializeComponent()
        _sserial = sserial
        _logger = New Logger
        _flasher = New FirmwareUploader(_sserial, _logger)
        SerialSelector1.AssociatedISerialDevice = _sserial.SerialDevice
        SerialSelector1.LoadFromDevice()
        SerialSelector1.Enabled = True
        SerialSelector1.AllowPortChange = True
        SerialSelector1.SaveToDevice()

        _form = Me
    End Sub

    Public Sub CheckConnected()
        If _sserial.IsConnected = False Then
            _logger.AddMessage("Устройство не подключено. Попытка подключения (" + _sserial.SerialDevice.DeviceAddress + ", " + _sserial.SerialDevice.DeviceSpeed.ToString + ")...")
            Try
                _sserial.Connect()
            Catch ex As Exception
                _logger.AddError(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Tool_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Text += " " + Application.ProductVersion + " (" + IO.File.GetLastWriteTime(Application.ExecutablePath) + ")"
        Catch ex As Exception

        End Try
        _logger.ConnectWriter(DatagridLogWriter1)
        If IO.File.Exists("config.txt") Then
            Dim thread As New Threading.Thread(AddressOf ScriptModeThread)
            thread.Name = "Script"
            thread.IsBackground = True
            thread.Start()
        End If
    End Sub

    Private Sub ScriptModeThread()
        Me.Invoke(Sub()
                      gbFirmware.Enabled = False
                      gbPortSelect.Enabled = False
                      gbRestarts.Enabled = False
                      gbSelectDevice.Enabled = False
                      gbTechInfo.Enabled = False
                      bStartScript.Enabled = False
                      bStartScript.BackColor = Color.LightBlue
                  End Sub)
        Try
            Dim result = ScriptMode()
            Me.Invoke(Sub()
                          If result Then
                              bStartScript.BackColor = Color.LightGreen
                          Else
                              bStartScript.BackColor = Color.Pink
                          End If
                      End Sub)
        Catch ex As Exception
            _logger.AddError(ex.Message)
        End Try
        Me.Invoke(Sub()
                      bStartScript.Enabled = True
                      gbFirmware.Enabled = True
                      gbPortSelect.Enabled = True
                      gbRestarts.Enabled = True
                      gbSelectDevice.Enabled = True
                      gbTechInfo.Enabled = True
                  End Sub)
    End Sub

    Private Function ScriptMode() As Boolean
        Threading.Thread.Sleep(1000)

        Dim params As New Dictionary(Of String, String)
        Dim lines = IO.File.ReadAllLines("config.txt")
        For Each line In lines
            Dim pparts = line.Split("=")
            If pparts.Length = 2 Then
                Dim name = pparts(0).ToLower
                Dim value = pparts(1)
                params.Add(name, value)
            End If
        Next

        Dim flashfile = params("fw_file")
        If flashfile Is Nothing Then Throw New Exception("fw_file is missing")
        If IO.File.Exists(flashfile) = False Then
            _logger.AddWarning("Файл прошивки не найден, невозможно продолжить.")
            Return False
        End If

        Dim baudrate = params("baudrate")
        If baudrate Is Nothing Then Throw New Exception("baudrate is missing")

        Dim check_devname = params("check_devname")
        If check_devname Is Nothing Then Throw New Exception("check_devname is missing")

        Dim check_after = params("check_after")
        If check_after Is Nothing Then Throw New Exception("check_after is missing")

        Dim foundCounter As Integer = 0
        Dim info As DeviceInfo = Nothing
        For Each port In IO.Ports.SerialPort.GetPortNames
            Try
                _logger.AddInformation("Проверка порта " + port)
                _sserial.SerialDevice.DeviceAddress = port
                _sserial.SerialDevice.DeviceSpeed = CInt(Val(baudrate))
                Me.Invoke(Sub() SerialSelector1.LoadFromDevice())
                _sserial.Connect()
                For i = 1 To 3
                    Try
                        _logger.AddMessage("Проверка...")
                        info = _sserial.RequestDeviceInfo(0)
                        If info.Response.ResponseState = ResponseState.ok Then
                            _logger.AddMessage("Обнаружено " + info.DeviceName)
                            foundCounter += 1
                            ShowDevInfo(info)
                            Exit For
                        End If
                    Catch ex As Exception
                    End Try
                Next
            Catch ex As Exception
                _logger.AddWarning(ex.Message)
            End Try
        Next

        If foundCounter = 0 Then
            _logger.AddError("Устройств SimplSerial не обнаружено. Невозможно продолжить.")
            Return False
        End If

        If foundCounter > 1 Then
            _logger.AddError("Устройств SimplSerial обнаружено более одного. Отключите лишние. Невозможно продолжить.")
            Return False
        End If

        If check_devname > "" Then
            Dim noBoot As Boolean = True

            If info.DeviceName.Contains("BwlBoot") Then
                noBoot = False
                _logger.AddMessage("Устройство найдено, но оно в режиме загрузчика, попытка перевести его в обычный режим")
                For i = 1 To 5
                    Try
                        _logger.AddInformation("Попытка...")
                        _sserial.RequestGoToMain(0)
                        Dim inf = _sserial.RequestDeviceInfo(0)
                        ShowDevInfo(inf)
                        If inf.Response.ResponseState = ResponseState.ok And inf.DeviceName.Contains("BwlBoot") = False Then
                            noBoot = True
                            Exit For
                        End If
                    Catch ex As Exception
                    End Try
                Next
                If noBoot = False Then
                    _logger.AddMessage("Устройство не переходит в обычный режим по команде, ожидаем ")
                    Dim wait = params("wait_for_exit_boot")
                    If wait Is Nothing Then Threading.Thread.Sleep(15000) Else Threading.Thread.Sleep(CInt(Val(wait)) * 1000)
                    For i = 1 To 3
                        _logger.AddInformation("Проверка...")
                        Try
                            Dim inf = _sserial.RequestDeviceInfo(0)
                            If inf.Response.ResponseState = ResponseState.ok And inf.DeviceName.Contains("BwlBoot") = False Then
                                noBoot = True
                                Exit For
                            End If
                        Catch ex As Exception
                        End Try
                    Next
                End If
                If noBoot = False Then
                    _logger.AddError("Не удалось перейти в обычный режим и проверить имя устройства.")
                    _logger.AddMessage("Возможно, программа не загружена. Пропустить проверку?")
                    If MsgBox("Не удалось перейти в обычный режим и проверить имя устройства. Возможно, программа не загружена. Пропустить проверку?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        _logger.AddError("Невозможно продолжить.")
                        Return False
                    End If
                End If
            End If

            If noBoot = True Then
                Dim devnames = check_devname.Split({","}, StringSplitOptions.RemoveEmptyEntries)
                Dim found = 0
                For Each devname In devnames
                    If info.DeviceName.ToLower.Contains(devname.ToLower) Then
                        _logger.AddMessage("Устройство найдено, его имя (" + info.DeviceName + ")  соответствует заданному (" + check_devname + ")")
                        found = 1
                    End If
                Next
                If found = 0 Then
                    _logger.AddError("Устройство найдено, но его имя (" + info.DeviceName + ") не соответствует заданному (" + check_devname + ")")
                    _logger.AddError("Невозможно продолжить.")
                    Return False
                End If
            End If
        End If

        Dim info3 = _sserial.RequestDeviceInfo(0)
        ShowDevInfo(info3)
        Dim boot As Boolean = False

        If info3.DeviceName.Contains("BwlBoot") = False Then
            _logger.AddMessage("Попытка перевести устройство в режим загрузчика")

            For i = 1 To 5
                Try
                    _logger.AddInformation("Попытка...")
                    _sserial.RequestGoToBootloader(0)

                    Dim inf = _sserial.RequestDeviceInfo(0)
                    ShowDevInfo(inf)
                    If inf.Response.ResponseState = ResponseState.ok And inf.DeviceName.Contains("BwlBoot") Then

                        boot = True
                        Exit For
                    End If
                Catch ex As Exception
                End Try
            Next
            If boot = False Then
                _logger.AddMessage("Устройство не переходит в режим загрузчика по команде, пробуем перезагрузку ")
                For i = 1 To 3
                    Try
                        _logger.AddInformation("Попытка...")
                        _sserial.RequestRestart(0)
                        Dim inf = _sserial.RequestDeviceInfo(0)
                        ShowDevInfo(inf)
                        If inf.Response.ResponseState = ResponseState.ok And inf.DeviceName.Contains("BwlBoot") Then
                            boot = True
                            Exit For
                        End If
                    Catch ex As Exception
                    End Try
                Next
            End If
            If boot = False Then
                _logger.AddWarning("Не удалось перевести устройство в режим загрузчика")
                _logger.AddWarning("Возможно, загрузчика нет или нужен перезапуск по питанию")
                If MsgBox("Не удалось перевести устройство в режим загрузчика. Возможно, загрузчика нет или нужен перезапуск по питанию. Хотите попробовать перезапустить устройство по питанию? (нажмите Да, как только это будет сделано)", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    _logger.AddError("Невозможно продолжить.")
                    Return False
                End If

                For i = 1 To 10
                    Try
                        _logger.AddInformation("Проверка...")
                        _sserial.RequestGoToBootloader(0)
                        Dim inf = _sserial.RequestDeviceInfo(0)
                        ShowDevInfo(inf)
                        If inf.Response.ResponseState = ResponseState.ok And inf.DeviceName.Contains("BwlBoot") Then
                            boot = True
                            Exit For
                        End If
                    Catch ex As Exception
                    End Try
                Next

                If boot = False Then
                    _logger.AddError("Не удалось перевести устройство в режим загрузчика. Невозможно продолжить.")
                    Return False
                End If
            End If
        End If

        Try
            ShowDevInfo(_sserial.RequestDeviceInfo(0))
        Catch ex As Exception
        End Try

        _logger.AddInformation("Все готово к прошивке")
        Try
            _flasher.RequestBootInfo(0)
            _flasher.EraseAndFlashAll(0, FirmwareUploader.LoadFirmwareFromFile(flashfile))
        Catch ex As Exception
            _logger.AddWarning(ex.ToString)
            _logger.AddInformation("Первая попытка не удалась, пробуем еще раз")
            Try
                _flasher.RequestBootInfo(0)
                _flasher.EraseAndFlashAll(0, FirmwareUploader.LoadFirmwareFromFile(flashfile))
            Catch ex2 As Exception
                _logger.AddWarning(ex2.ToString)
                _logger.AddError("Вторая попытка не удалась. Невозможно продолжить.")
                Try
                    _flasher.EraseAll(0)
                Catch ex3 As Exception
                End Try
                Return False
            End Try
        End Try

        _logger.AddMessage("Прошивка завершена. Переходим в основную программу")
        Dim noBoot1 As Boolean = False

        For i = 1 To 5
            Try
                _logger.AddInformation("Попытка...")
                _sserial.RequestGoToMain(0)

                Dim inf = _sserial.RequestDeviceInfo(0)
                ShowDevInfo(inf)
                If inf.Response.ResponseState = ResponseState.ok And inf.DeviceName.Contains("BwlBoot") = False Then
                    noBoot1 = True
                    Exit For
                End If
            Catch ex As Exception
            End Try
        Next

        If noBoot1 = False Then
            _logger.AddMessage("Устройство не переходит в обычный режим по команде, ожидаем ")
            Dim wait = params("wait_for_exit_boot")
            If wait Is Nothing Then Threading.Thread.Sleep(15000) Else Threading.Thread.Sleep(CInt(Val(wait)) * 1000)
            For i = 1 To 3
                _logger.AddInformation("Проверка...")
                Try
                    Dim inf = _sserial.RequestDeviceInfo(0)
                    ShowDevInfo(inf)
                    If inf.Response.ResponseState = ResponseState.ok And inf.DeviceName.Contains("BwlBoot") = False Then

                        noBoot1 = True
                        Exit For
                    End If
                Catch ex As Exception
                End Try
            Next
        End If

        If noBoot1 = False Then
            _logger.AddError("Не удалось перейти в обычный режим и проверить имя устройства после прошивки.")
            If MsgBox("Не удалось перейти в обычный режим и проверить имя устройства после прошивки. Возможно, нужен перезапуск по питанию. Хотите попробовать перезапустить устройство по питанию? (нажмите Да, как только это будет сделано)", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                _logger.AddError("Невозможно продолжить.")
                Return False
            End If

            For i = 1 To 20
                Try
                    _logger.AddInformation("Проверка...")
                    _sserial.RequestGoToBootloader(0)
                    Dim inf = _sserial.RequestDeviceInfo(0)
                    ShowDevInfo(inf)
                    If inf.Response.ResponseState = ResponseState.ok And inf.DeviceName.Contains("BwlBoot") = False Then

                        boot = True
                        Exit For
                    End If
                Catch ex As Exception
                End Try
            Next
        End If
        If noBoot1 = False Then
            _logger.AddError("Не удалось перейти в обычный режим и проверить имя устройства после прошивки.")
            _logger.AddError("Невозможно продолжить.")
            Return False
        End If

        Dim info5 As DeviceInfo = Nothing
        For i = 1 To 3
            Try
                _logger.AddInformation("Проверка...")
                info5 = _sserial.RequestDeviceInfo(0)
                If info5.Response.ResponseState = ResponseState.ok Then
                    _logger.AddMessage("Обнаружено " + info5.DeviceName)
                    Exit For
                End If
            Catch ex As Exception
            End Try
        Next

        If info5 Is Nothing OrElse info5.Response.ResponseState <> ResponseState.ok Then
            _logger.AddError("Устройство не отвечает. Невозможно продолжить.")
            Return False
        End If

        ShowDevInfo(info5)
        Dim devnames2 = check_after.Split({","}, StringSplitOptions.RemoveEmptyEntries)
        Dim found2 = 0
        For Each devname In devnames2
            If info5.DeviceName.ToLower.Contains(devname.ToLower) Then
                _logger.AddMessage("Устройство найдено, его имя после прошивки (" + info5.DeviceName + ")  соответствует заданному (" + check_after + ")")
                found2 = 1
            End If
        Next

        If found2 = 0 Then
            _logger.AddError("Устройство найдено, но его имя (" + info5.DeviceName + ") не соответствует заданному (" + check_after + ")")
            _logger.AddError("Невозможно продолжить.")
            Return False
        End If

        _logger.AddMessage("!!! ОБНОВЛЕНИЕ УСПЕШНО ЗАВЕРШЕНО !!!")
        Return True
    End Function

    Private Sub ShowDevInfo(info As DeviceInfo)
        If Me.InvokeRequired Then
            Me.Invoke(Sub() ShowDevInfo(info))
        Else
            If info.Response.ResponseState = ResponseState.ok Then
                devAddressTextbox.Text = info.Response.FromAddress.ToString
                devDateTextbox.Text = info.DeviceDate
                devguidTextbox.Text = info.DeviceGuid.ToString
                devnameTextbox.Text = info.DeviceName
                If info.BootloaderMode Then
                    bootstateTextbox.Text = "режим загрузчика, " + info.BootName
                Else
                    bootstateTextbox.Text = "основной код, "
                    If info.BootName > "" Then
                        bootstateTextbox.Text += "загрузчик найден: " + info.BootName
                    Else
                        bootstateTextbox.Text += "нет информации о загрузчике"
                    End If
                End If
                addInfoTextbox.Text = "SimplSerial: " + info.ProtocolVersion
            End If
        End If
    End Sub

    Private Sub getDevInfoButton_Click(sender As Object, e As EventArgs) Handles getDevInfoButton.Click, bTestDevice.Click
        TryThis(Sub()
                    Dim info = _sserial.RequestDeviceInfo(GetAddress())
                    If info.Response.ResponseState = ResponseState.ok Then
                        ShowDevInfo(info)
                    Else
                        Throw New Exception(info.Response.ResponseState.ToString)
                    End If
                End Sub)
    End Sub

    Public Delegate Sub TryThisDelegate()
    Public Sub TryThis(dlg As TryThisDelegate)
        CheckConnected()
        Try
            dlg.Invoke()
            _logger.AddMessage("OK")
        Catch ex As Exception
            _logger.AddWarning(ex.Message)
        End Try
    End Sub

    Public Function GetAddress() As Integer
        Dim address = 0
        If selectAddress.Checked Then address = CInt(Val(reqAddressTextbox.Text))
        If selectGuid.Checked Then
            address = _rnd.Next(1, 30000)
            _sserial.RequestSetAddress(Guid.Parse(reqGuidTextbox.Text), address)
        End If
        Return address
    End Function

    Private Sub goToBootloader_Click() Handles goToBootloader.Click
        TryThis(Sub()
                    _sserial.RequestGoToBootloader(GetAddress())
                End Sub)
    End Sub

    Private Sub reqBootInfoButton_Click() Handles reqBootInfoButton.Click
        Try
            goToBootloader_Click()
        Catch ex As Exception
        End Try
        TryThis(Sub()
                    _flasher = New FirmwareUploader(_sserial, _logger)
                    _flasher.RequestBootInfo(GetAddress())
                    spmSizeTextbox.Text = _flasher.SpmSize.ToString
                    progmemSizeTextbox.Text = _flasher.ProgmemSize.ToString
                    signature.Text = _flasher.Signature
                End Sub)
    End Sub

    Private Sub programMemButton_Click(sender As Object, e As EventArgs) Handles programMemButton.Click
        reqBootInfoButton_Click()
        TryThis(Sub()
                    _flasher.EraseAndFlashAll(GetAddress(), FirmwareUploader.LoadFirmwareFromFile(firmwarePathTextbox.Text))
                End Sub)
    End Sub

    Private Sub gotoMain_Click(sender As Object, e As EventArgs) Handles gotoMain.Click
        TryThis(Sub()
                    _sserial.RequestGoToMain(GetAddress())
                End Sub)
    End Sub

    Private Sub eraseProgramButton_Click(sender As Object, e As EventArgs) Handles eraseProgramButton.Click
        reqBootInfoButton_Click()
        TryThis(Sub()
                    _flasher.EraseAll(GetAddress())
                End Sub)
    End Sub

    Private Sub selectFirmwarePathButton_Click(sender As Object, e As EventArgs) Handles selectFirmwarePathButton.Click
        firmwarePathTextbox.Text = FirmwareUploader.SelectFirmwareFile
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles restartByDefault.Click
        TryThis(Sub()
                    _sserial.RequestRestart(GetAddress())
                End Sub)
    End Sub

    Private Sub bStartScript_Click(sender As Object, e As EventArgs) Handles bStartScript.Click
        If IO.File.Exists("config.txt") Then
            Dim thread As New Threading.Thread(AddressOf ScriptModeThread)
            thread.Name = "Script"
            thread.IsBackground = True
            thread.Start()
        End If
    End Sub
End Class
