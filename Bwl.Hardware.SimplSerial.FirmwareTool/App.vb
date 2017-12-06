Module App
    Public Sub Main()
        Application.EnableVisualStyles()
        Dim hexNames = IO.Directory.GetFiles(Application.StartupPath, "*.hex")
        If hexNames.Length = 1 Then StartWithHexFile(hexNames(0))
        StartWithEmbeddedFile()
    End Sub

    Public Sub StartWithEmbeddedFile()
        Dim exe = Application.ExecutablePath
        'Dim exe = "C:\Users\heart\Cleverflow Projects\Cf.Orlan\Cf.Orlan.Hardware.Boards.Fw\powerboard.v3.fw.update.02.12.2017_19.05.exe"
        Dim myBytes = IO.File.ReadAllBytes(exe)
        Dim ascii = System.Text.Encoding.ASCII.GetString(myBytes)
        Dim i1 = ascii.IndexOf("###!!!***")
        Dim i2 = ascii.IndexOf("###!!!***", i1 + 9)
        Dim i3 = ascii.IndexOf("###!!!***", i2 + 9)
        If i1 > 0 And i2 > 0 And i3 < 0 Then
            Dim cfg = ascii.Substring(i1 + 9, i2 - i1 - 9)
            Dim hex = ascii.Substring(i2 + 10)

            Dim parameters As New FirmwareUpdaterParameters(cfg)
            Dim bin = FirmwareUploader.LoadFirmwareFromHexString(hex)
            Dim ss As SimplSerialBus = Nothing
            Dim tool As New FirmwareUpdaterTool(bin, "(" + IO.Path.GetFileName(exe) + ")", ss, parameters)
            Application.Run(tool)
        End If
    End Sub

    Public Sub StartWithHexFile(hexName As String)
        Dim parameters As New FirmwareUpdaterParameters(IO.Path.GetFileNameWithoutExtension(hexName))
        Dim bin = FirmwareUploader.LoadFirmwareFromFile(hexName)
        Dim ss As SimplSerialBus = Nothing
        Dim tool As New FirmwareUpdaterTool(bin, IO.Path.GetFileNameWithoutExtension(hexName), ss, parameters)
        Application.Run(tool)
    End Sub
End Module
