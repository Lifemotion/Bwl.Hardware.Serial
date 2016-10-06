Imports System.Windows.Forms

Public Class VirtualTwoSwitchVisualiser
    Private _device As VirtualTwoSwitch
    Public Sub New(device As VirtualTwoSwitch)
        _device = device
        InitializeComponent()
    End Sub
    Private Sub VirtualTwoSwitchVisualiser_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        lDebug.Items.Add("")
        lDebug.Items.Add("")
        lDebug.Items.Add("")
        lDebug.Items.Add("")
        refreshTimer.Enabled = True
    End Sub

    Private Sub refresh_Tick(sender As System.Object, e As System.EventArgs) Handles refreshTimer.Tick
        lDebug.Items(0) = "Адрес: " + _device.Address.ToString
        lDebug.Items(1) = "Быстр. отв.: " + _device.DebugQuickState.ToString
        lDebug.Items(2) = "Связь 1:" + _device.DebugLinked1.ToString
        lDebug.Items(3) = "Связь 2:" + _device.DebugLinked2.ToString
        Switch1.Checked = _device.Switch1
        Switch2.Checked = _device.Switch2
    End Sub

    Public Shared Sub CreateAndRunInThread(virtualDevice As VirtualTwoSwitch)
        Dim thread As New Threading.Thread(AddressOf VisualiserThread)
        thread.Priority = Threading.ThreadPriority.BelowNormal
        thread.Name = "SerialVisualiserUI"
        thread.Start(virtualDevice)
    End Sub

    Private Shared Sub VisualiserThread(virtualDevice As VirtualTwoSwitch)
        Dim visualiser As New VirtualTwoSwitchVisualiser(virtualDevice)
        visualiser.Show()
        Application.Run()
    End Sub

    Private Sub CheckBox1_Click(sender As Object, e As System.EventArgs) Handles Switch1.Click
        _device.Push1()
    End Sub

    Private Sub CheckBox2_Click(sender As Object, e As System.EventArgs) Handles Switch2.Click
        _device.Push2()
    End Sub
End Class