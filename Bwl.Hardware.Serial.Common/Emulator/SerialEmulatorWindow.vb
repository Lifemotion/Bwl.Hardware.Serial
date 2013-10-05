Public Class SerialEmulatorWindow
    Private WithEvents _emulator As SerialEmulator
    Sub New(emulator As SerialEmulator)
        _emulator = emulator
        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()
        ' Добавьте все инициализирующие действия после вызова InitializeComponent().
    End Sub
    Private Sub Window_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Friend Sub RefreshState()
        lbState.Items.Clear()
        lbState.Items.Add("DeviceAddress: " + _emulator.DeviceAddress)
        lbState.Items.Add("DeviceAddressFormat: " + _emulator.DeviceAddressFormat)
        lbState.Items.Add("DeviceParameters: " + _emulator.DeviceParameters)
        ' lbState.Items.Add("DeviceIdentifier: " + _emulator.DeviceIdentifier)
        lbState.Items.Add("DeviceSpeed: " + _emulator.DeviceSpeed.ToString)
        lbState.Items.Add("AutoConnect: " + _emulator.AutoConnect.ToString)
        lbState.Items.Add("AutoReadBytes: " + _emulator.AutoReadBytes.ToString)
        ' lbState.Items.Add("IsPresent: " + _emulator.IsPresent.ToString)
        lbState.Items.Add("IsConnected: " + _emulator.IsConnected.ToString)
        lbState.Items.Add("DeviceAddress: " + _emulator.DeviceAddress)
    End Sub

    Private Sub lbState_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lbState.SelectedIndexChanged

    End Sub
End Class