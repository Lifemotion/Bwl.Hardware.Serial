Public Class FirmwareUploaderGuiTools
    Public Shared Function SelectFirmwareFile() As String
        Dim fd As New OpenFileDialog()
        fd.Filter = "HEX|*.hex|BIN|*.bin"
        If fd.ShowDialog = System.Windows.Forms.DialogResult.OK Then Return fd.FileName
        Return ""
    End Function
End Class
