Imports System.Windows.Forms

Public Class SimplSerialTool
    Inherits Form
    Private Shared _form As SimplSerialTool
    Private _logger As Logger
    Private _sserial As SimplSerialBus

    Public Shared ReadOnly Property SelAddress As Integer
        Get
            Return _form.GetAddress
        End Get
    End Property

    Public Shared ReadOnly Property SSB As SimplSerialBus
        Get
            Return _form._sserial
        End Get
    End Property

    Public Sub New()
        Me.New(Nothing)
    End Sub

    Public Sub New(sserial As SimplSerialBus)
        Me.New(sserial, New Logger)
    End Sub

    Public Sub New(sserial As SimplSerialBus, logger As Logger)
        InitializeComponent()
        _sserial = sserial
        _logger = logger
        Dim allowChangePort As Boolean = False
        If _sserial Is Nothing Then
            _sserial = New SimplSerialBus(New SerialPort)
            allowChangePort = True
        End If
        SerialSelector1.AssociatedISerialDevice = _sserial.SerialDevice
        SerialSelector1.LoadFromDevice()
        SerialSelector1.Enabled = True
        SerialSelector1.AllowPortChange = allowChangePort
        If allowChangePort Then SerialSelector1.SaveToDevice()

        Dim thread As New Threading.Thread(AddressOf SearchingThread)
        thread.IsBackground = True
        thread.Name = "SearchingThread"
        thread.Start()

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
        _logger.ConnectWriter(DatagridLogWriter1)
        ShowGuidInfo()
        CodeExecutor1.ImportsList.Add(Me.GetType.FullName)
        CodeExecutor.Logger = _logger
        CodeExecutor1.SourceText += "Sub Main()" + vbCrLf
        CodeExecutor1.SourceText += "Dim result = SSB.Request(SelAddress, 254)" + vbCrLf
        CodeExecutor1.SourceText += "Output(result.ToString)" + vbCrLf
        CodeExecutor1.SourceText += "End Sub" + vbCrLf
    End Sub

    Private Sub getDevInfoButton_Click(sender As Object, e As EventArgs) Handles getDevInfoButton.Click, Button3.Click
        TryThis(Sub()
                    Dim info = _sserial.RequestDeviceInfo(GetAddress())
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
    Dim _rnd As New Random
    Public Function GetAddress() As Integer
        Dim address = 0
        If selectAddress.Checked Then address = CInt(Val(reqAddressTextbox.Text))
        If selectGuid.Checked Then
            address = _rnd.Next(1, 30000)
            _sserial.RequestSetAddress(Guid.Parse(reqGuidTextbox.Text), address)
        End If
        Return address
    End Function

    Private Sub setAddressButton_Click(sender As Object, e As EventArgs) Handles setAddressButton.Click
        TryThis(Sub()
                    _sserial.RequestSetAddress(Guid.Parse(reqGuidTextbox.Text), Val(_setAddressValueTextbox.Text))
                End Sub)
    End Sub

    Private Sub selfTestBustton_Click(sender As Object, e As EventArgs) Handles selfTestBustton.Click
        Const maxsize = 128
        TryThis(Sub()
                    For n = 1 To 50
                        Dim rnd As New Random
                        Dim length = rnd.Next(1, maxsize)
                        Dim list As New List(Of Byte)
                        For i = 1 To length
                            list.Add(rnd.Next(0, 255))
                        Next
                        _sserial.RequestTestDevice(Val(_setAddressValueTextbox.Text), list.ToArray)
                        If n Mod 10 = 0 Then _logger.AddMessage("Проведено тестов: " + n.ToString)
                        Application.DoEvents()
                    Next
                End Sub)
    End Sub

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

    Private _flasher As FirmwareUploader

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

    Private Sub portWriteButton_Click() Handles portWriteButton.Click
        TryThis(Sub()
                    Dim bytes(15) As Byte
                    Dim pins As New SimplSerialBus.Ports
                    PortMonitor1.ToPort() : pins.PortA = PortMonitor1.Port
                    PortMonitor2.ToPort() : pins.PortB = PortMonitor2.Port
                    PortMonitor3.ToPort() : pins.PortC = PortMonitor3.Port
                    PortMonitor4.ToPort() : pins.PortD = PortMonitor4.Port
                    _sserial.RequestPortsChange(GetAddress(), pins)
                End Sub)
        portReadButton_Click()
    End Sub

    Private Sub PortMonitorHandler()
        If My.Computer.Keyboard.ShiftKeyDown Then portWriteButton_Click()
    End Sub

    Private Sub portReadButton_Click() Handles portReadButton.Click
        TryThis(Sub()
                    Dim pins = _sserial.RequestPortsRead(GetAddress())
                    PortMonitor1.Port = pins.PortA : PortMonitor1.Refresh()
                    PortMonitor2.Port = pins.PortB : PortMonitor2.Refresh()
                    PortMonitor3.Port = pins.PortC : PortMonitor3.Refresh()
                    PortMonitor4.Port = pins.PortD : PortMonitor4.Refresh()
                End Sub)
    End Sub

    Private Sub getCurrentGuidButton_Click(sender As Object, e As EventArgs) Handles getCurrentGuidButton.Click
        guidToAddTextbox.Text = devguidTextbox.Text
        guidCommentTextbox.Text = devnameTextbox.Text
    End Sub

    Private Function GetGuidInfo(guid As String) As String
        If IO.File.Exists(guid.ToLower + ".guid.txt") Then
            Return IO.File.ReadAllText(guid.ToLower + ".guid.txt", System.Text.UTF8Encoding.UTF8)
        Else
            Return ""
        End If
    End Function

    Private Sub SaveGuidInfo(guid As String, info As String)
        If guid.Length <> 36 Then Return
        IO.File.WriteAllText(guid.ToLower + ".guid.txt", info, System.Text.UTF8Encoding.UTF8)
        ShowGuidInfo()
    End Sub

    Private Sub addGuidButton_Click(sender As Object, e As EventArgs) Handles addGuidButton.Click
        If GetGuidInfo(guidToAddTextbox.Text) = "" Then SaveGuidInfo(guidToAddTextbox.Text, guidCommentTextbox.Text)
    End Sub

    Private Sub ShowGuidInfo()
        Dim files = IO.Directory.GetFiles(".", "*.guid.txt")
        identifiersList.Items.Clear()
        For Each f In files
            Dim guid = f.Split(IO.Path.DirectorySeparatorChar).Last().ToLower.Replace(".guid.txt", "")
            If guid.Length = 36 Then
                identifiersList.Items.Add(guid + " " + GetGuidInfo(guid))
            End If
        Next
    End Sub

    Private Sub guidCommentTextbox_KeyDown(sender As Object, e As KeyEventArgs) Handles guidCommentTextbox.KeyDown
        If e.KeyCode = Keys.Enter Then
            SaveGuidInfo(guidToAddTextbox.Text, guidCommentTextbox.Text)
            ShowGuidInfo()
        End If
    End Sub

    Private Sub identifiersList_Click(sender As Object, e As EventArgs) Handles identifiersList.Click
        Dim guid = identifiersList.Text.Split(" ")(0)
        If guid.Length = 36 Then
            guidToAddTextbox.Text = guid
            guidCommentTextbox.Text = GetGuidInfo(guid)
        End If
    End Sub

    Private Sub CodeExecutor1_Load(sender As Object, e As EventArgs) Handles CodeExecutor1.Load

    End Sub

    Private Sub identifiersList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles identifiersList.SelectedIndexChanged
        If identifiersList.SelectedItem IsNot Nothing Then
            Dim g = identifiersList.SelectedItem.ToString.Split(" ")(0)
            Try
                _sserial.RequestSetAddress(Guid.Parse(g), 255)
                _logger.AddInformation(g + " _ good")
            Catch ex As Exception
                _logger.AddError(g + " _ " + ex.ToString)
            End Try
        End If
    End Sub

    Private Sub queryAllGuidsButton_Click(sender As Object, e As EventArgs) Handles queryAllGuidsButton.Click
        Try
            For Each it In identifiersList.Items
                Dim g = it.ToString.Split(" ")(0)
                Try
                    _sserial.RequestSetAddress(Guid.Parse(g), 255)
                    _logger.AddInformation(g + " _ good")
                Catch ex As Exception
                End Try
            Next
        Catch ex As Exception
            _logger.AddError(ex.ToString)
        End Try
    End Sub

    Private Sub SearchingThread()
        Dim rnd As New Random
        Do
            Try

                If Me.Created AndAlso Me.Invoke(Function() _searchingEnabled.Checked) = True Then
                    CheckConnected()
                    For i = 1 To 10

                        Dim results = _sserial.FindDevices()
                        For Each result In results
                            Dim str = result.ToString
                            Dim lines As String() = Me.Invoke(Function() searchDevicesResult.Lines)

                            If lines.Contains(str) = False Then Me.Invoke(Sub() searchDevicesResult.Text = searchDevicesResult.Text + vbCrLf + str)
                        Next
                    Next
                End If
            Catch ex As Exception
            End Try
            Threading.Thread.Sleep(100)
        Loop
    End Sub

    Private Sub selectFirmwarePathButton_Click(sender As Object, e As EventArgs) Handles selectFirmwarePathButton.Click
        firmwarePathTextbox.Text = FirmwareUploader.SelectFirmwareFile
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If _searchingEnabled.Checked = True Then MsgBox("Для запроса информации у найденных устройств остановите поиск")
        searchDevicesResult.Enabled = False
        Dim lines As String() = searchDevicesResult.Lines
        Dim text As String = ""
        For Each line In lines
            Dim split = (line + "   ").Split(" ")
            For i = 1 To 3
                Try
                    Dim id = Guid.Parse(split(0))
                    Dim addr = _rnd.Next(1, 30000)
                    _sserial.RequestSetAddress(id, addr)
                    Dim info = _sserial.RequestDeviceInfo(addr)
                    If info.DeviceGuid = id Then
                        split(1) = info.DeviceName.Trim
                        split(2) = info.DeviceDate.Trim
                    End If
                Catch ex As Exception
                End Try

            Next
            Dim line1 = (String.Join(" "c, split)).Trim
            text = text + line1 + vbCrLf
            searchDevicesResult.Text = text
            Application.DoEvents()
        Next
        searchDevicesResult.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TryThis(Sub()
                    _sserial.RequestRestart(GetAddress())
                End Sub)
    End Sub

    Private Sub searchDevicesResult_DoubleClick(sender As Object, e As EventArgs) Handles searchDevicesResult.DoubleClick
        Try
            Dim line = searchDevicesResult.Lines(searchDevicesResult.GetLineFromCharIndex(searchDevicesResult.GetFirstCharIndexOfCurrentLine))
            Dim parts = line.Split(" ")
            reqGuidTextbox.Text = parts(0)
            selectGuid.Checked = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ЛогToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ЛогToolStripMenuItem.Click
        ' Dim loggerForm = New LoggerForm(_logger)
        ' loggerForm.Show()
    End Sub
End Class
