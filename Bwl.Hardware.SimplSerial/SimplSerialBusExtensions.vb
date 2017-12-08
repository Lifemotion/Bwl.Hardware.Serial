Imports System.Runtime.CompilerServices

Public Module SimplSerialBusExtensions
    ''' <summary>
    ''' Запросить базовую информацию устройства (команда 120).
    ''' </summary>
    ''' <param name="address">Адрес устройства.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension()>
    Public Function RequestDeviceInfo(ss As ISimplSerialBus, address As Integer) As DeviceInfo
        Dim result = ss.Request(New SSRequest(address, 254, {}), ss.RequestRetriesDefault)
        Dim ascii = Text.ASCIIEncoding.ASCII
        Dim info As New DeviceInfo With {.Response = result}
        If result.ResponseState = ResponseState.ok Then
            If (result.Result = 0 And result.Data.Length >= 54) Then
                Dim arr(15) As Byte
                For i = 0 To 15
                    arr(i) = result.Data(i)
                Next
                For i = 16 To 54
                    If result.Data(i) < &H20 Or result.Data(i) > &H7E Then result.Data(i) = &H20
                Next
                info.DeviceGuid = New Guid(arr)
                info.DeviceName = ascii.GetString(result.Data, 16, 32).Replace(vbNullChar, "").Trim
                info.DeviceDate = ascii.GetString(result.Data, 48, 6).Replace(vbNullChar, "").Trim
                If result.Data.Length >= 86 Then
                    info.BootName = ascii.GetString(result.Data, 54, 16).Replace(vbNullChar, "").Trim
                    info.ProtocolVersion = ascii.GetString(result.Data, 70, 6).Replace(vbNullChar, "").Trim
                End If
                If info.DeviceName.StartsWith("BwlBoot") Then
                    info.BootloaderMode = True
                    info.BootName = info.DeviceName.Substring(0, 16).Replace(vbNullChar, "").Trim.Replace(":", "")
                End If
                Return info
            End If
        End If
        Return info
    End Function

    <Extension()>
    Public Sub RequestSetAddress(ss As ISimplSerialBus, guid As Guid, address As Integer)
        Dim bytes = New List(Of Byte)
        bytes.AddRange(guid.ToByteArray)
        bytes.AddRange(SimplSerialBus.UInt16ToBytes(address))
        Dim result = ss.Request(New SSRequest(0, 253, bytes.ToArray), ss.RequestRetriesDefault)
        If result.ResponseState = ResponseState.ok AndAlso result.Result = 0 Then Return
        Throw New Exception("RequestSetAddress: bad response: " + result.ResponseState.ToString + " " + result.Result.ToString)
    End Sub

    <Extension()>
    Public Sub RequestRestart(ss As ISimplSerialBus, address As Integer)
        Dim result = ss.Request(New SSRequest(address, 251, {255}), ss.RequestRetriesDefault)
        If result.ResponseState = ResponseState.ok AndAlso result.Result = 0 Then Return
        Throw New Exception("RequestRestart: bad response: " + result.ResponseState.ToString + " " + result.Result.ToString)
    End Sub

    <Extension()>
    Public Sub RequestGoToBootloader(ss As ISimplSerialBus, address As Integer)
        Dim result = ss.Request(New SSRequest(address, 251, {2}), ss.RequestRetriesDefault)
        If result.ResponseState = ResponseState.ok AndAlso result.Result = 0 Then Return
        Throw New Exception("RequestGoToBootloader: bad response: " + result.ResponseState.ToString + " " + result.Result.ToString)
    End Sub

    <Extension()>
    Public Sub RequestGoToMain(ss As ISimplSerialBus, address As Integer)
        Dim result = ss.Request(New SSRequest(address, 251, {1}), ss.RequestRetriesDefault)
        If result.ResponseState = ResponseState.ok AndAlso result.Result = 0 Then Return
        Throw New Exception("RequestGoToMain: bad response: " + result.ResponseState.ToString + " " + result.Result.ToString)
    End Sub

    ''' <summary>
    ''' Самотестирование устройства на произвольных данных (не менее 1 байта и не более буфера устройства).
    ''' </summary>
    ''' <remarks></remarks>
    <Extension()>
    Public Sub RequestTestDevice(ss As ISimplSerialBus, address As Integer, testData As Byte())
        If testData Is Nothing OrElse testData.Length < 1 Then Throw New Exception("Data must be 1 byte at least")
        Dim request As New SSRequest(address, 252, testData)
        Dim response = ss.Request(request, ss.RequestRetriesDefault)
        If response.ResponseState = ResponseState.ok Then
            If response.Result <> request.Data(0) Then Throw New Exception("RequestTestDevice: error response")
            If response.Data.Length + 1 <> request.Data.Length Then Throw New Exception("RequestTestDevice: error data length")
            For i = 0 To response.Data.Length - 1
                Dim data = request.Data(i + 1) - 1
                If data = -1 Then data = 255
                If response.Data(i) <> data Then Throw New Exception("RequestTestDevice: error data byte")
            Next
        Else
            Throw New Exception("RequestTestDevice: bad response: " + response.ResponseState.ToString)
        End If
    End Sub

    <Extension()>
    Public Sub RequestPinSet(ss As ISimplSerialBus, address As Integer, portIndex As Integer, pinIndex As Integer, direction As Boolean, output As Boolean)
        ss.RequestPinSet(address, portIndex, pinIndex, New SimplSerialBus.Pin(direction, output))
    End Sub

    <Extension()>
    Public Sub RequestPinSet(ss As ISimplSerialBus, address As Integer, portIndex As Integer, pinIndex As Integer, pin As SimplSerialBus.Pin)
        Dim ports As New SimplSerialBus.Ports
        ports.GetPort(portIndex).SetPin(pinIndex, pin)
        ss.RequestPortsChange(address, ports)
    End Sub

    <Extension()>
    Public Function RequestPortsRead(ss As ISimplSerialBus, address As Integer) As SimplSerialBus.Ports
        Dim pins As New SimplSerialBus.Ports
        Dim bytes(2) As Byte
        bytes(0) = 2
        Dim req As New SSRequest(address, 250, bytes)
        Dim resp = ss.Request(req, ss.RequestRetriesDefault)
        If resp.ResponseState <> ResponseState.ok Then Throw New Exception(resp.ResponseState.ToString)

        pins.PortA.PinDirection = (resp.Data(1))
        pins.PortA.PinOutput = (resp.Data(2))
        pins.PortA.PinInput = (resp.Data(3))
        pins.PortA.PinSetMask = 0

        pins.PortB.PinDirection = (resp.Data(4))
        pins.PortB.PinOutput = (resp.Data(5))
        pins.PortB.PinInput = (resp.Data(6))
        pins.PortB.PinSetMask = 0

        pins.PortC.PinDirection = (resp.Data(7))
        pins.PortC.PinOutput = (resp.Data(8))
        pins.PortC.PinInput = (resp.Data(9))
        pins.PortC.PinSetMask = 0

        pins.PortD.PinDirection = (resp.Data(10))
        pins.PortD.PinOutput = (resp.Data(11))
        pins.PortD.PinInput = (resp.Data(12))
        pins.PortD.PinSetMask = 0

        Return pins
    End Function

    <Extension()>
    Public Sub RequestPortsChange(ss As ISimplSerialBus, address As Integer, pins As SimplSerialBus.Ports)
        Dim bytes(13) As Byte
        bytes(0) = 1

        bytes(1) = pins.PortA.PinDirection
        bytes(2) = pins.PortA.PinOutput
        bytes(3) = pins.PortA.PinSetMask

        bytes(4) = pins.PortB.PinDirection
        bytes(5) = pins.PortB.PinOutput
        bytes(6) = pins.PortB.PinSetMask

        bytes(7) = pins.PortC.PinDirection
        bytes(8) = pins.PortC.PinOutput
        bytes(9) = pins.PortC.PinSetMask

        bytes(10) = pins.PortD.PinDirection
        bytes(11) = pins.PortD.PinOutput
        bytes(12) = pins.PortD.PinSetMask

        Dim req As New SSRequest(address, 250, bytes)
        Dim resp = ss.Request(req, ss.RequestRetriesDefault)
        If resp.ResponseState <> ResponseState.ok Then Throw New Exception(resp.ResponseState.ToString)
    End Sub

    Private _rnd As New Random
    <Extension()>
    Public Sub RequestTestDevice(ss As ISimplSerialBus, address As Integer, maxLength As Integer)
        Dim length = _rnd.Next(1, maxLength)
        Dim testdata As New List(Of Byte)
        For i = 1 To length
            testdata.Add(_rnd.Next(0, 255))
        Next
        ss.RequestTestDevice(address, testdata.ToArray)
    End Sub
End Module
