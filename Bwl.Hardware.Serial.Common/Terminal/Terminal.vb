Public Class Terminal

    Public Sub AddText(text As String, color As Drawing.Color)
        If InvokeRequired Then
            Invoke(Sub() AddText(text, color))
        Else
            rtb.SuspendLayout()
            Dim l1 = rtb.TextLength
            rtb.Select(l1, 0)
            rtb.SelectedText = text
            Dim l2 = rtb.TextLength
            rtb.Select(l1, l2 - l1)
            rtb.SelectionColor = color
            rtb.Select(l2, 0)
            rtb.ResumeLayout()
            rtb.ScrollToCaret()
        End If
    End Sub

    Public Sub ClearText()
        If InvokeRequired Then
            Invoke(Sub() ClearText())
        Else
            rtb.Text = ""
        End If
    End Sub

    Sub AddReceived(bytes As Byte())
        If InvokeRequired Then
            Invoke(Sub() AddReceived(bytes))
        Else
            AddBytes(bytes, Drawing.Color.FromArgb(0, 160, 0), Drawing.Color.FromArgb(0, 60, 0))
        End If
    End Sub

    Sub AddSend(bytes As Byte())
        If InvokeRequired Then
            Invoke(Sub() AddSend(bytes))
        Else
            AddBytes(bytes, Drawing.Color.FromArgb(160, 0, 0), Drawing.Color.FromArgb(60, 0, 0))
        End If
    End Sub

    Private Sub AddBytes(bytes() As Byte, colorHex As Drawing.Color, colorText As Drawing.Color)
        Dim text = ""

        For i = 0 To bytes.Length - 1 Step 20
            Dim hexString = ""
            Dim decString = ""
            Dim textString = ""
            For j = 0 To 19
                If i + j < bytes.Length Then
                    hexString += HexFormat(bytes(i + j)) + "  "
                    decString += (bytes(i + j)).ToString("000") + " "
                    textString += TextFormat(bytes(i + j))
                Else
                    hexString += "   "
                End If
            Next
            AddText(hexString + "   ", colorHex)
            AddText(textString + vbCrLf, colorText)
            If cbDecimal.Checked Then
                AddText(decString + vbCrLf, Drawing.Color.DarkGray)
            End If
        Next
    End Sub

    Private Function HexFormat(data As Integer) As String
        Dim result = Hex(data)
        If result.Length = 1 Then result = "0" + result
        Return result
    End Function

    Dim enc As System.Text.Encoding = System.Text.Encoding.GetEncoding(1251)

    Private Function TextFormat(data As Byte) As String
        Dim bytes(0) As Byte
        bytes(0) = data
        Dim temp = enc.GetString(bytes, 0, 1)
        If Char.IsControl(temp(0)) Then Return "."
        Return temp
    End Function

    Private Sub Terminal_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
