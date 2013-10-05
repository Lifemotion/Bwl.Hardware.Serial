Imports System.Windows.Forms

Public Class SerialVisualiser
    Private _serial As ISerialDevice

    Public Property SerialDevice As ISerialDevice
        Set(value As ISerialDevice)
            RemoveHandlers()
            _serial = value
            AddHandlers()
        End Set
        Get
            Return _serial
        End Get
    End Property

    Public Shared Sub CreateAndRunInThread(serialDevice As ISerialDevice)
        Dim thread As New Threading.Thread(AddressOf VisualiserThread)
        thread.Priority = Threading.ThreadPriority.BelowNormal
        thread.Name = "SerialVisualiserUI"
        thread.Start(serialDevice)
    End Sub

    Private Shared Sub VisualiserThread(serialDevice As ISerialDevice)
        Dim visualiser As New SerialVisualiser
        visualiser.SerialDevice = serialDevice
        visualiser.Show()
        Application.Run()
    End Sub

    Private Sub SerialVisualiser_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub RemoveHandlers()

    End Sub

    Private Sub AddHandlers()
        If _serial IsNot Nothing Then
            AddHandler _serial.PropertiesChanged, AddressOf PropertiesChanged
            AddHandler _serial.BytesSent, AddressOf BytesSent
            AddHandler _serial.BytesRead, AddressOf BytesRead
            If _serial.Logger IsNot Nothing Then _serial.Logger.ConnectWriter(Me.LogWriterList1)
        End If
    End Sub

    Private Sub PropertiesChanged()

    End Sub

    Private Sub RefreshStateHandler() Handles refreshState.Tick
        If _serial IsNot Nothing Then
            ' SyncLock _serial
            Do While lbState.Items.Count < 10
                lbState.Items.Add("")
            Loop
            lbState.Items(0) = "AutoConnect:         " + _serial.AutoConnect.ToString
            lbState.Items(1) = "AutoReadBytes:       " + _serial.AutoReadBytes.ToString
            lbState.Items(2) = "BetweenBytesPause:   " + _serial.BetweenBytesPause.ToString
            lbState.Items(3) = "DeviceAddress:       " + _serial.DeviceAddress.ToString
            lbState.Items(4) = "DeviceAddressFormat: " + _serial.DeviceAddressFormat.ToString
            lbState.Items(5) = "DeviceParameters:    " + _serial.DeviceParameters.ToString
            lbState.Items(6) = "DeviceParameters:    " + _serial.DeviceParameters.ToString
            lbState.Items(7) = "DeviceSpeed:         " + _serial.DeviceSpeed.ToString
            lbState.Items(8) = "IsConnected:         " + _serial.IsConnected.ToString
            lbState.Items(9) = "BytesToRead:         " + _serial.ReceivedBufferCount.ToString
            ' End SyncLock
        End If
    End Sub

    Private Sub BytesSent(from As SerialDevice, bytes As Byte())
        view.AddSend(bytes)
    End Sub

    Private Sub BytesRead(from As SerialDevice, bytes As Byte(), fromAutoRead As Boolean)
        view.AddReceived(bytes)
    End Sub

End Class