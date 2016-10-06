Module App

    Sub Main()

        Dim parameters = My.Application.CommandLineArgs

        Dim ports = IO.Ports.SerialPort.GetPortNames
        Dim port = ""
        If ports.Length > 0 Then port = ports(0)
        If ports.Length = 0 Then
            Console.WriteLine("Serial Ports not found. Exiting...") : Return
        End If

        Dim baud = 9600
        Dim fport = New Serial.FastSerialPort()
        fport.DeviceAddress = port
        fport.DeviceSpeed = baud
        Try
            fport.Connect()
            Console.WriteLine("Connected: " + port + ", " + baud.ToString)

        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Console.WriteLine("Cannot open port: " + port + ", " + baud.ToString)
            Return
        End Try
        Console.WriteLine()
        Dim ss As New SimplSerialBus(fport)
        Dim addr = 0
        Try
            ss.RequestDeviceInfo(addr)
            ss.RequestDeviceInfo(addr)
            Dim info = ss.RequestDeviceInfo(addr)
            Console.WriteLine("DeviceAddr:  " + info.Response.FromAddress.ToString)
            Console.WriteLine("DeviceName:  " + info.DeviceName)
            Console.WriteLine("DeviceGuid:  " + info.DeviceGuid.ToString)
            Console.WriteLine("DeviceDate:  " + info.DeviceDate.ToString)
        Catch ex As Exception
            Console.WriteLine("Device request error: " + ex.Message)
        End Try
        If parameters.Contains("gotobootloader") Then
            Try
                ss.RequestGoToBootloader(addr)
                Console.WriteLine("RequestGoToBootloader ok")
            Catch ex As Exception
                Console.WriteLine("RequestGoToBootloader: " + ex.Message)
            End Try
        End If

        If parameters.Contains("erase") Then
            Try
                Dim flasher As New FirmwareUploader(ss)
                flasher.RequestBootInfo(addr)
                flasher.EraseAll(addr)
                Console.WriteLine("EraseAll ok")
            Catch ex As Exception
                Console.WriteLine("EraseAll: " + ex.Message)
            End Try
        End If

        For i = 0 To parameters.Count - 1
            If parameters(i).ToLower = "flash" Then
                Try
                    Dim file = parameters(i + 1)
                    If IO.File.Exists(file) = False Then Throw New Exception("File not found: " + file)
                    Dim flasher As New FirmwareUploader(ss)
                    flasher.RequestBootInfo(addr)
                    flasher.EraseAndFlashAll(addr, FirmwareUploader.LoadFirmwareFromFile(file))
                    Console.WriteLine("EraseAndFlashAll ok")
                Catch ex As Exception
                    Console.WriteLine("EraseAndFlashAll: " + ex.Message)
                End Try
            End If
        Next
        Console.ReadLine()
    End Sub

End Module
