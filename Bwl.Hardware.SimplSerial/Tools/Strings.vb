Public Class Strings
    Public Shared Function String2Byte(str As String) As Byte
        str = str.PadLeft(8)
        Dim val As Byte
        For i = 0 To 7
            Dim bit = 0
            If str(7 - i) = "1" Then bit = 1
            val += (2 ^ i) * bit
        Next
        Return val
    End Function

    Public Shared Function Byte2String(val As Byte) As String
        Dim str As String = ""
        For i = 0 To 7
            If val And 128 Then str += "1" Else str += "0"
            val = val << 1
        Next
        Return str
    End Function
End Class
