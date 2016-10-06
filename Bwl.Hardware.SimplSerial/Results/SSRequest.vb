Public Class SSRequest
    Sub New()

    End Sub
    Sub New(address As UInt16, command As Integer)
        _Command = command
        _Address = address
    End Sub
    Sub New(address As UInt16, command As Integer, data() As Byte)
        _Command = command
        _Address = address
        _Data = data
    End Sub

    Public Property Address As UInt16
    Public Property Command As Byte
    Public Property Data As Byte() = Array.CreateInstance(GetType(Byte), 0)
End Class
