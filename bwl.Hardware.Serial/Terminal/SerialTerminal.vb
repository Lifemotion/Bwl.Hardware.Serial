Public Class SerialTerminal
    Private WithEvents _device As bwl.Hardware.Serial.SerialDevice
    Sub New(ByVal device As SerialDevice)
        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()
        _device = device
        '  _logger.AddMessage("Создан: " + TypeName(device))
        ' Добавьте все инициализирующие действия после вызова InitializeComponent().
        RefreshState()
        tabsSend.Enabled = False
    End Sub

    Private Sub frmSerialDeviceTest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub RefreshState()
        tDeviceAddress.Text = _device.DeviceAddress
        tDeviceAddressFormat.Text = _device.DeviceAddressFormat
        tDeviceSpeed.Text = _device.DeviceSpeed
        tDeviceParametersFormat.Text = _device.DeviceParameters
        cbAutoConnect.Checked = _device.AutoConnect
        cbAutoReadBytes.Checked = _device.AutoReadBytes
        cbIsConnected.Checked = _device.IsConnected
    End Sub

    Private Sub bApply_Click(sender As System.Object, e As System.EventArgs) Handles bApply.Click
        _device.DeviceAddress = tDeviceAddress.Text
        _device.DeviceSpeed = tDeviceSpeed.Text
        _device.DeviceParameters = tDeviceParametersFormat.Text
        _device.AutoConnect = cbAutoConnect.Checked
        _device.AutoReadBytes = cbAutoReadBytes.Checked
    End Sub

    Private Sub bConnect_Click(sender As System.Object, e As System.EventArgs) Handles bConnect.Click
        If Not _device.IsConnected Then
            Try
                _device.Connect()
            Catch ex As Exception
                '    _logger.AddError(ex.Message)
            End Try
        Else
            _device.Disconnect()
        End If
    End Sub

    Private Sub _device_BytesArrived(from As SerialDevice, count As Integer) Handles _device.BytesArrived
        '  _logger.AddDebug("Пришло байт: " + count.ToString)
    End Sub

    Private Sub _device_BytesRead(from As SerialDevice, bytes() As Byte, fromAutoRead As Boolean) Handles _device.BytesRead
        '   _logger.AddDebug("Прочитано байт: " + bytes.Length.ToString + ", авточтение: " + fromAutoRead.ToString)
        view.AddReceived(bytes)
    End Sub

    Private Sub _device_DeviceConnected(from As SerialDevice) Handles _device.DeviceConnected
        '   _logger.AddMessage("Устройство подключено.")
    End Sub

    Private Sub _device_DeviceDisconnected(from As SerialDevice, reason As DisconnectReason) Handles _device.DeviceDisconnected
        '     _logger.AddMessage("Устройство отключено: " + reason.ToString)
    End Sub

    Private Sub input_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles input.KeyDown
        If e.KeyCode = System.Windows.Forms.Keys.Enter Then
            e.SuppressKeyPress = True
            Dim text = input.Text
            Dim bytes As Byte() = System.Text.Encoding.GetEncoding(1251).GetBytes(text)
            view.AddSend(bytes)
            If _device.IsConnected Then
                _device.Write(bytes)
            End If
        End If
    End Sub

    Private Sub input_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub input_TextChanged_1(sender As System.Object, e As System.EventArgs) Handles input.TextChanged

    End Sub

    Private Sub refresh_Tick(sender As System.Object, e As System.EventArgs) Handles refreshTimer.Tick
        If _device.IsConnected Then
            tabsSend.Enabled = True
        Else
            tabsSend.Enabled = False
        End If
    End Sub
End Class
