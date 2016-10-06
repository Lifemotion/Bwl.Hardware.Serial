Public Class SSResponse
    Sub New()

    End Sub
    Public Property Result As Byte
    Public Property ResponseState As ResponseState
    Public Property FromAddress As UInt16
    Public Property Data As Byte() = {}

    Public Overrides Function ToString() As String
        Dim text = ResponseState.ToString + " " + Result.ToString + ": "
        For Each d In Data
            text += d.ToString + " "
        Next
        Return text
    End Function
End Class


Public Enum ResponseState
    ok
    errorTimeout
    errorFormat
    errorCrc
    errorPacketType
    errorNotRequested
    errorPortError
End Enum
