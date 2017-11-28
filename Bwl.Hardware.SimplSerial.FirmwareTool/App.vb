Module App
    Public Sub Main()
        Dim hexNames = IO.Directory.GetFiles(Application.StartupPath, "*.hex")
        If hexNames.Length = 0 Then MsgBox("No hex file!") : End
        If hexNames.Length > 1 Then MsgBox("Only 1 hex file allowed!") : End
        Dim hexName = hexNames(0)
        Dim nameParts = IO.Path.GetFileNameWithoutExtension(hexName).Split(",")
        Dim bootName = ""
        Dim mainName = ""
        Dim workAddress = 0
        Dim baud = 9600
        Dim additionalRestart = True
        For Each namePart In nameParts
            Dim keyValue = namePart.Split("=")
            If keyValue.Length = 2 Then
                Select Case keyValue(0)
                    Case "BN" : bootName = keyValue(1)
                    Case "MN" : mainName = keyValue(1)
                    Case "WA" : workAddress = keyValue(1)
                    Case "BAUD" : baud = keyValue(1)
                    Case "AR" : additionalRestart = keyValue(1).Trim.ToLower = "true"
                End Select
            End If
        Next
        Dim ss As SimplSerialBus = Nothing
        Dim tool As New FirmwareUpdaterTool(hexName, ss, bootName, mainName, workAddress, baud, additionalRestart)
        Application.EnableVisualStyles()
        Application.Run(tool)
    End Sub
End Module
