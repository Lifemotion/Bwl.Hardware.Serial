Module StandardTests
    Public Sub DeviceSelfTest(sserial As SimplSerialBus, maxSize As Integer, Optional count As Integer = Integer.MaxValue)
        Dim n = 0, errs = 0
        Do While n < count
            Try
                sserial.RequestTestDevice(0, maxSize)
            Catch ex As Exception
                Console.WriteLine(ex.Message) : errs += 1
            End Try
                n += 1
            If n Mod 10 = 0 Then Console.WriteLine("Exps: " + n.ToString + ", errs: " + errs.ToString)
        Loop
    End Sub

    Public Sub AddressSetupTest(sserial As SimplSerialBus, Optional count As Integer = Integer.MaxValue)
        Dim n = 0, errs = 0
        Do While n < count
            Try
                SimplSerialBus.Tests.AddressSetupTest(sserial)
            Catch ex As Exception
                Console.WriteLine(ex.Message) : errs += 1
            End Try
            n += 1
            If n Mod 2 = 0 Then Console.WriteLine("Exps: " + n.ToString + ", errs: " + errs.ToString)
        Loop
    End Sub
End Module
