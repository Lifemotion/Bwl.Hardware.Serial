Imports System.Diagnostics
Public Class SerialPort
    Inherits SerialDevice
    Private _rs232 As New IO.Ports.SerialPort

    Private Sub ConnectFunction()
        _rs232.Close()
        _rs232.PortName = DeviceAddress
        _rs232.BaudRate = DeviceSpeed
        _rs232.Open()
    End Sub

    Private Sub DisconnectFunction(reason As DisconnectReason)
        _rs232.Close()
    End Sub

    Private Function PingFunction() As Boolean
        Return True
    End Function

    Private Function GetRxCount() As Integer
        Return _rs232.BytesToRead
    End Function

    Private Function ReadByteFunction() As Byte
        Dim v = _rs232.ReadByte()
        Debug.WriteLine(v)
        Return v
    End Function

    Private Function ReadFunction(count As Integer) As Byte()
        Dim buffer(count - 1) As Byte
        Dim read = _rs232.Read(buffer, 0, count)
        ReDim Preserve buffer(read - 1)
        Return buffer
    End Function

    Private Sub WriteByteFunction(oneByte As Byte)
        Dim buffer(0) As Byte
        buffer(0) = oneByte
        _rs232.Write(buffer, 0, 1)
    End Sub

    Private Sub WriteFunction(bytes() As Byte)
        _rs232.Write(bytes, 0, bytes.Length)
    End Sub

    Public Sub New()
        Dim funcs As New WorkFunctions
        funcs.connectFunction = AddressOf ConnectFunction
        funcs.disconnectFunction = AddressOf DisconnectFunction
        funcs.pingFunction = AddressOf PingFunction
        funcs.readFunction = AddressOf ReadFunction
        funcs.readOneFunction = AddressOf ReadByteFunction
        funcs.writeFunction = AddressOf WriteFunction
        funcs.writeOneFunction = AddressOf WriteByteFunction
        funcs.getRxBufferLengthFunction = AddressOf GetRxCount
        Init("DEV[#]", "", funcs)
    End Sub
End Class
