Module TestRun
    Private _device2 As New SerialEmulator
    Private _test As New SerialTerminal(_device2)
    Private _vis As New SerialVisualiser
    Sub Main()

        _vis.SerialDevice = _device2
        _vis.Show()
        _device2.MakeLoop = True
        _test.Show()
        Application.EnableVisualStyles()
        Application.Run()

    End Sub
End Module
