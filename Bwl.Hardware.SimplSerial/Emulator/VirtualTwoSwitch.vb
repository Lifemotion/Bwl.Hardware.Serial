Imports bwl.Hardware.Serial
Public Class VirtualTwoSwitch
    Inherits CatUartVirtualDevice
    Private _switch1 As Boolean
    Private _switch2 As Boolean
    Public ReadOnly Property Switch1 As Boolean
        Get
            Return _switch1
        End Get
    End Property
    Public ReadOnly Property Switch2 As Boolean
        Get
            Return _switch2
        End Get
    End Property
    Public Sub Push1()
        If DebugLinked1 Then
            _switch1 = Not _switch1
            DebugQuickState = 1
        End If
    End Sub
    Public Sub Push2()
        If DebugLinked2 Then
            _switch2 = Not _switch2
            DebugQuickState = 1
        End If
    End Sub
    Public Property DebugQuickState As Integer
    Public Property DebugLinked1 As Boolean = True
    Public Property DebugLinked2 As Boolean = True

    Sub New(serial As SerialEmulator, name As String, address As Integer)
        MyBase.New(serial, "TwoSwitch " + name, address)
    End Sub

    Private Sub VirtualTwoSwitch_ProcessPacketRequest(packet As SSRequest, response As SSResponse) Handles Me.ProcessPacketRequest
        If packet.Command = 10 Then
            response.Result = 0

        End If
    End Sub

    Private Sub VirtualTwoSwitch_ProcessQuickRequest(ByRef response As Integer) Handles Me.ProcessQuickRequest

    End Sub
End Class
