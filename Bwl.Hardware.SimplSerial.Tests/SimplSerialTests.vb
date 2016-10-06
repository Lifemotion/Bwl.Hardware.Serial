Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class SimplSerialTests
    Private Shared _sserial As SimplSerialBus
    Private Shared _sync As New Object

    Public Function GetSimplSerial() As SimplSerialBus
        SyncLock _sync
            If _sserial Is Nothing Then
                _sserial = New SimplSerialBus
                _sserial.Connect()
                Threading.Thread.Sleep(500)

            End If
            Return _sserial
        End SyncLock
    End Function

    <TestMethod()> Public Sub Crc16Test()
        Crc16.Test()
    End Sub

    <TestMethod()> Public Sub SSRandomSendTest()
        SyncLock _sync
            For i = 1 To 20
                GetSimplSerial.RequestTestDevice(0, 128)
            Next
        End SyncLock
    End Sub

    <TestMethod()> Public Sub SSDeviceInfo()
        SyncLock _sync
            Dim info = GetSimplSerial.RequestDeviceInfo(0)
            Assert.IsNotNull(info.BootName)
            Assert.IsNotNull(info.DeviceDate)
            Assert.IsNotNull(info.DeviceGuid)
            Assert.IsNotNull(info.DeviceName)
            Assert.AreEqual(info.DeviceGuid.ToString("D").Length, 36)
            Assert.IsTrue(info.DeviceGuid.ToString("D").Replace("0", "").Replace(".", "").Replace("-", "").Length > 16)
            Assert.IsTrue(info.DeviceName.Length > 6)
            Assert.IsTrue(info.DeviceDate.Length = 6)
        End SyncLock
    End Sub

    <TestMethod()> Public Sub SSGoToBootloaderAndToMain()
        SyncLock _sync
            Dim info = GetSimplSerial.RequestDeviceInfo(0)
            If info.BootloaderMode = True Then Throw New Exception("In bootloader mode, expected program mode")
            If info.BootName.Contains("BwlBoot") = False Then Throw New Exception("Bootloader was not found")
            GetSimplSerial.RequestGoToBootloader(0)
            info = GetSimplSerial.RequestDeviceInfo(0)
            If info.BootloaderMode = False Then Throw New Exception("In program mode, expected bootloader mode")
            If info.BootName.Contains("BwlBoot") = False Then Throw New Exception("Bootloader was not found")
            If info.DeviceName.Contains("BwlBoot") = False Then Throw New Exception("DeviceName wrong")
            GetSimplSerial.RequestGoToMain(0)
            info = GetSimplSerial.RequestDeviceInfo(0)
            If info.BootloaderMode = True Then Throw New Exception("In bootloader mode, expected program mode")
            If info.BootName.Contains("BwlBoot") = False Then Throw New Exception("Bootloader was not found")
        End SyncLock
      
    End Sub

    <TestMethod()> Public Sub SSRestart()
        SyncLock _sync
            Dim info = GetSimplSerial.RequestDeviceInfo(0)
            Dim addr = 8678
            GetSimplSerial.RequestSetAddress(info.DeviceGuid, addr)
            info = GetSimplSerial.RequestDeviceInfo(0)
            If info.Response.FromAddress <> addr Then Throw New Exception("RequestSetAddress failed")
            GetSimplSerial.RequestRestart(0)
            info = GetSimplSerial.RequestDeviceInfo(0)
            If info.Response.FromAddress <> 0 Then Throw New Exception("RequestRestart failed? see test code")
        End SyncLock
    End Sub

    <TestMethod()> Public Sub SSAddressTest()
        SyncLock _sync
            For i = 1 To 2
                SimplSerialBus.Tests.AddressSetupTest(GetSimplSerial)
            Next
        End SyncLock
    End Sub

    <TestMethod()> Public Sub SSPinsBitOps()
        Dim port As New SimplSerialBus.Port
        Assert.AreEqual(port.PinDirection, CByte(0))
        Assert.AreEqual(port.PinInput, CByte(0))
        Assert.AreEqual(port.PinOutput, CByte(0))
        Assert.AreEqual(port.PinSetMask, CByte(0))
  
        port.SetPin(1, New SimplSerialBus.Pin(True, False))
        Assert.AreEqual(port.PinDirection, CByte(2))
        Assert.AreEqual(port.PinInput, CByte(0))
        Assert.AreEqual(port.PinOutput, CByte(0))
        Assert.AreEqual(port.PinSetMask, CByte(2))

        port.SetPin(1, New SimplSerialBus.Pin(False, False))
        Assert.AreEqual(port.PinDirection, CByte(0))
        Assert.AreEqual(port.PinInput, CByte(0))
        Assert.AreEqual(port.PinOutput, CByte(0))
        Assert.AreEqual(port.PinSetMask, CByte(2))

        port.SetPin(1, New SimplSerialBus.Pin(True, True))
        port.SetPin(5, New SimplSerialBus.Pin(True, False))

        Assert.AreEqual(port.PinDirection, CByte(2 + 32))
        Assert.AreEqual(port.PinInput, CByte(0))
        Assert.AreEqual(port.PinOutput, CByte(2))
        Assert.AreEqual(port.PinSetMask, CByte(2 + 32))

    End Sub

    <TestMethod()> Public Sub SSPinsTest()
        SyncLock _sync
            Dim pins = GetSimplSerial.RequestPortsRead(0)
            pins.PortA.SetPort(255, 0, 255)
            pins.PortB.SetPort(255, 0, 255)
            pins.PortB.SetPort(255, 0, 255)
            pins.PortB.SetPort(255, 0, 255)
            GetSimplSerial.RequestPortsChange(0, pins)
            pins = GetSimplSerial.RequestPortsRead(0)
            Dim pin = pins.GetPort(1).GetPin(5)
            Assert.AreEqual(pin.Direction, True)
            Assert.AreEqual(pin.Input, False)
            Assert.AreEqual(pin.Output, False)

            GetSimplSerial.RequestPinSet(0, 1, 5, True, True)
            Dim pins2 = GetSimplSerial.RequestPortsRead(0)
            Dim pin2 = pins2.GetPort(1).GetPin(5)
            Assert.AreEqual(pin2.Direction, True)
            Assert.AreEqual(pin2.Input, True)
            Assert.AreEqual(pin2.Output, True)

            GetSimplSerial.RequestPinSet(0, 1, 5, False, False)
            pins2 = GetSimplSerial.RequestPortsRead(0)
            pin2 = pins2.GetPort(1).GetPin(5)
            Assert.AreEqual(pin2.Direction, False)
            Assert.AreEqual(pin2.Input, False)
            Assert.AreEqual(pin2.Output, False)
        End SyncLock
    End Sub

    <TestMethod()> Public Sub SSBootInfo()
        SyncLock _sync
            GetSimplSerial.RequestGoToBootloader(0)
            Dim fw As New FirmwareUploader(GetSimplSerial)
            fw.RequestBootInfo(0)
            If fw.ProgmemSize < 2048 And fw.ProgmemSize > 128 * 1024 Then Throw New Exception("ProgmemSize")
            If fw.SpmSize < 32 And fw.ProgmemSize > 2048 Then Throw New Exception("SpmSize")
        End SyncLock
    End Sub

    <TestMethod()> Public Sub SSFindDevices()
        SyncLock _sync
            Dim devs = GetSimplSerial.FindDevices()
            If devs.Length = 0 Then Throw New Exception("FindDevices may fail sometime, try again")
        End SyncLock
    End Sub

    <TestMethod()> Public Sub SSConnectDisconnect()
        SyncLock _sync
            GetSimplSerial.Disconnect()
            Assert.AreEqual(False, GetSimplSerial.IsConnected)
            GetSimplSerial.Connect()
            Assert.AreEqual(True, GetSimplSerial.IsConnected)
        End SyncLock
    End Sub
    Private _testRequest = New SSRequest(0, 252, {1, 2, 3})

    <TestMethod()> Public Sub SSRequest()
        Dim result = GetSimplSerial.Request(_testRequest)
        If result.ResponseState <> ResponseState.ok Then Throw New Exception(result.ResponseState)
        If result.Data.Length <> 2 Then Throw New Exception("result.Data.Length ")
    End Sub


    <TestMethod()> Public Sub SSSendRead()
        SyncLock _sync
            Dim b = GetSimplSerial()
            GetSimplSerial.Send(_testRequest)
            Dim time = Now
            Do While (Now - time).TotalSeconds < 1.0
                Dim result = GetSimplSerial.Read
                If result IsNot Nothing AndAlso result.ResponseState = ResponseState.ok Then
                    If result.Data.Length <> 2 Then Throw New Exception("result.Data.Length ")
                    Return
                End If
                Threading.Thread.Sleep(1)
            Loop
            Throw New Exception("SSSendRead")
        End SyncLock
    End Sub

    <TestMethod()> Public Sub SSMakeRequestBytes()
        SyncLock _sync
            Dim bytes = GetSimplSerial.MakeRequestBytes(_testRequest)
            Assert.AreEqual(bytes.Length, 13)
        End SyncLock
    End Sub
End Class