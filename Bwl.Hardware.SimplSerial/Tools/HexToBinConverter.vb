Public Class HexToBinConverter
	Private _segmAddr As Integer
	Private _advAdr As Integer
	Private _bytes(0) As Byte

	Public Function Hex2Bin(hexStrings As String()) As Byte()
		For i = 0 To hexStrings.Length
			If hexStrings(i) = ":00000001FF" Then
				Return _bytes
			End If
			Dim hexData = HexStringToData(hexStrings(i))
			If hexData.Type = 4 Then
				_advAdr = hexData.Data(0)
				_advAdr = _advAdr << 8
				_advAdr += hexData.Data(1)
			ElseIf hexData.Type = 2 Then
				_segmAddr = hexData.Data(0)
				_segmAddr = _advAdr << 8
				_segmAddr += hexData.Data(1)
			ElseIf hexData.Type = 0 Then
				Dim addr As Long = _segmAddr << 16
				addr += hexData.AddrByte1
				addr = addr << 8
				addr += hexData.AddrByte2

				If _bytes.Length < (addr + hexData.DataLen) Then
					ReDim Preserve _bytes(addr + hexData.DataLen - 1)
				End If

				Array.Copy(hexData.Data, 0, _bytes, addr, hexData.DataLen)
			End If
		Next
		Throw New Exception("Плохой конец файла")
	End Function

	Public Shared Sub CheckCrcAndLengthGood(bytes As Byte())
		'Dim sum As Byte = 0
		'For i = 0 To bytes.Length - 2
		'	sum = sum Xor bytes(i)
		'Next
		'Dim crc1 As Byte = 255 - (Not sum)
		'Dim crc2 = bytes.Last
		'Dim res = False
		'If crc1 = crc2 Then
		'	Dim dataLen1 = bytes(0)
		'	Dim dataLen2 = bytes.Length - 5
		'	If dataLen1 = dataLen2 Then
		'		'Return True
		'	Else
		'		Throw New Exception("Bad data length")
		'	End If
		'Else
		'	Throw New Exception("Bad crc")
		'End If
	End Sub

	Private Function HexStringToBytes(hexString As String) As Byte()
		If hexString(0) = ":" Then
			Dim bytes As New List(Of Byte)
			Dim correct As Boolean = True
			For i = 1 To hexString.Length - 1 Step 2
				Dim part = Mid(hexString, i + 1, 2)
				Try
					Dim b = CByte(Val("&H" + part))
					bytes.Add(b)
				Catch ex As Exception
					Throw New Exception("Bad String Format, not sequense of hex")
				End Try
			Next
			Return bytes.ToArray
		Else
			Throw New Exception("Bad String Format, нет символа ':'")
		End If
	End Function

	Private Function HexStringToData(hexString As String) As HexData
		Dim bytes = HexStringToBytes(hexString)
		CheckCrcAndLengthGood(bytes)
		Dim data = New HexData
		data.DataLen = bytes(0)
		data.AddrByte1 = bytes(1)
		data.AddrByte2 = bytes(2)
		data.Type = bytes(3)
		Dim mas(data.DataLen - 1) As Byte
		Array.Copy(bytes, 4, mas, 0, data.DataLen)
		data.Data = mas
		data.Crc = bytes.Last
		Return data
	End Function

	Class HexData
		Public Property DataLen As Byte
		Public Property AddrByte1 As Byte
		Public Property AddrByte2 As Byte
		Public Property Type As Byte
		Public Property Data As Byte()
		Public Property Crc As Byte
	End Class
End Class

