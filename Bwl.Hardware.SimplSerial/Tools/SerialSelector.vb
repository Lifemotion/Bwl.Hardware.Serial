Public Class SerialSelector

    Public Sub New()
        InitializeComponent()
        ComboBox1.Items.AddRange(IO.Ports.SerialPort.GetPortNames)
        If ComboBox1.Items.Count > 0 Then ComboBox1.SelectedIndex = 0
    End Sub

    Private Sub SerialSelector_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        
    End Sub

    Public Property AssociatedISerialDevice As ISerialDevice

    Public Property AllowPortChange As Boolean
        Set(value As Boolean)
            ComboBox1.Enabled = value
        End Set
        Get
            Return ComboBox1.Enabled
        End Get
    End Property

    Public Property AllowSpeedChange As Boolean
        Set(value As Boolean)
            ComboBox2.Enabled = value
        End Set
        Get
            Return ComboBox2.Enabled
        End Get
    End Property

    Private _suppressUpdate As Boolean
    Public Sub LoadFromDevice()
        If AssociatedISerialDevice IsNot Nothing Then
            _suppressUpdate = True
            If AssociatedISerialDevice.DeviceAddress > "" Then ComboBox1.Text = AssociatedISerialDevice.DeviceAddress
            ComboBox2.Text = AssociatedISerialDevice.DeviceSpeed.ToString
            _suppressUpdate = False
        End If
    End Sub

    Public Sub SaveToDevice()
        If AssociatedISerialDevice IsNot Nothing Then
            _suppressUpdate = True
            AssociatedISerialDevice.DeviceAddress = ComboBox1.Text
            AssociatedISerialDevice.DeviceSpeed = CInt(Val(ComboBox2.Text))
            _suppressUpdate = False
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged() Handles ComboBox1.TextChanged, ComboBox2.TextChanged
        If AssociatedISerialDevice IsNot Nothing And Not _suppressUpdate Then
            With AssociatedISerialDevice
                Try
                    Dim wasConnected = .IsConnected
                    .Disconnect()
                    .DeviceAddress = ComboBox1.Text
                    .DeviceSpeed = Val(ComboBox2.Text)
                    '  If wasConnected Then .Connect()
                Catch ex As Exception
                End Try
            End With
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim text = ComboBox1.Text
        ComboBox1.Items.Clear()
        ComboBox1.Items.AddRange(IO.Ports.SerialPort.GetPortNames)
        ComboBox1.Text = text
    End Sub

End Class
