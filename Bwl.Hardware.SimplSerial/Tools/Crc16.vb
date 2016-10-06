Public Class Crc16

    Private _value As UInt16 = &HFFFF

    Public Sub Init()
        _value = &HFFFF
    End Sub

    Public Sub Update(val As Byte)
        _value = _value Xor val
            For i = 1 To 8
            If (_value And 1) = 1 Then
                _value = (_value >> 1) Xor &HA001
            Else
                _value = (_value >> 1)
            End If
            Next
    End Sub

    Public Function GetCrc() As UInt16
        Return _value
    End Function

    Public Shared Function ComputeCrc(array As Byte()) As UInt16
        Return ComputeCrc(array, 0, array.Length - 1)
    End Function

    Public Shared Function ComputeCrc(array As Byte(), first As Integer, last As Integer) As UInt16
        Dim crc As UInt16 = &HFFFF
        For j = first To last
            Dim a = array(j)
            crc = crc Xor a
            For i = 1 To 8
                If (crc And 1) = 1 Then
                    crc = (crc >> 1) Xor &HA001
                Else
                    crc = (crc >> 1)
                End If
            Next
        Next
        Return crc
    End Function

    Public Shared Sub Test()
        If ComputeCrc({&H31, &H32, &H33, &H34}) <> &H30BA Then Throw New Exception("CrcCalcError")
        If ComputeCrc({&H88, &HA4}) <> &HB66 Then Throw New Exception("CrcCalcError")
        If ComputeCrc({}) <> &HFFFF Then Throw New Exception("CrcCalcError")
    End Sub
End Class
