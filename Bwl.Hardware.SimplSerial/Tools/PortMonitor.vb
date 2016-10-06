Public Class PortMonitor
    Public Property Port As SimplSerialBus.Port
    Private _suppressEvent As Boolean
    Public Sub FromPort()
        _suppressEvent = True
        input.Value = Port.PinInput
        direction.Value = Port.PinDirection
        output.Value = Port.PinOutput
        _suppressEvent = False
    End Sub

    Public Sub ToPort()
        If Port IsNot Nothing Then
            Port.PinSetMask = 255
            Port.PinDirection = direction.Value
            Port.PinOutput = output.Value
        End If
    End Sub

    Public Event PortChanged()
    Private Sub PortMonitor_Load() Handles output.ByteChanged, direction.ByteChanged
        If Not _suppressEvent Then
            ToPort()
            RaiseEvent PortChanged()
        End If
    End Sub

    Private Sub PortMonitor_Load(sender As Object, e As EventArgs)

    End Sub

    Public Overrides Sub Refresh()
        FromPort()
        MyBase.Refresh()
    End Sub

    Private Sub PortMonitor_Load(byteValue As Integer) Handles output.ByteChanged, direction.ByteChanged

    End Sub
End Class
