Imports System.Diagnostics
#Disable Warning BC40056 ' Пространство имен или тип, указанный в операторе Imports, не содержит открытый член, или невозможно найти пространство имен или тип
Imports Bwl.Hardware.Serial
#Enable Warning BC40056 ' Пространство имен или тип, указанный в операторе Imports, не содержит открытый член, или невозможно найти пространство имен или тип
''' <summary>
''' Реализация базового интерфейса шины SimplSerial.
''' </summary>
''' <remarks></remarks>
Public Class SimplSerialBus
    Public Class Tests
        Public Shared Sub AddressSetupTest(sserial As SimplSerialBus)
            Dim rnd As New Random
            Dim startinfo = sserial.RequestDeviceInfo(0)
            If startinfo.Response.ResponseState <> ResponseState.ok Then Throw New Exception("Device Not Respond")
            If startinfo.DeviceDate.Length < 6 Then Throw New Exception("Bad DeviceDate")
            If startinfo.DeviceName.Length < 6 Then Throw New Exception("Bad DeviceName")
            '   If startinfo.DeviceGuid. Then Throw New Exception("Bad DeviceDate")

            Dim addr1 = rnd.Next(2, UInt16.MaxValue - 2)
            sserial.RequestSetAddress(startinfo.DeviceGuid, addr1)
            Dim info1 = sserial.RequestDeviceInfo(0)
            Dim addr1real = info1.Response.FromAddress
            If addr1 <> addr1real Then Throw New Exception("Bad RequestSetAddress 1")

            Dim resp1a = sserial.RequestDeviceInfo(addr1)
            If resp1a.Response.ResponseState <> ResponseState.ok Then Throw New Exception("Not respond to set addr 1")

            Dim resp1b = sserial.RequestDeviceInfo(addr1 - 1)
            If resp1b.Response.ResponseState <> ResponseState.errorTimeout Then Throw New Exception("Respond to wronad addr addr 1 - 1")

            Dim resp1c = sserial.RequestDeviceInfo(addr1 + 1)
            If resp1c.Response.ResponseState <> ResponseState.errorTimeout Then Throw New Exception("Respond to wronad addr addr 1 + 1")

            Dim addr2 = rnd.Next(2, UInt16.MaxValue - 2)
            sserial.RequestSetAddress(startinfo.DeviceGuid, addr2)
            Dim info2 = sserial.RequestDeviceInfo(0)
            Dim addr2real = info2.Response.FromAddress
            If addr2 <> addr2real Then Throw New Exception("Bad RequestSetAddress 2")

            Dim resp2a = sserial.RequestDeviceInfo(addr2)
            If resp2a.Response.ResponseState <> ResponseState.ok Then Throw New Exception("Not respond to set addr 2")

            Dim resp2b = sserial.RequestDeviceInfo(addr1)
            If resp2b.Response.ResponseState <> ResponseState.errorTimeout Then Throw New Exception("Respond to previous addr 1")

        End Sub
    End Class

    Private _serial As ISerialDevice
    Private _lastPacket As SSRequest
    Private _syncRoot As New Object
    Private _readBufferPos As Integer
    Private _readBuffer(1024) As Byte
    Public Property RequestTimeout As Integer = 1000
    Public Property ReadBytes As Long

    ' 9600 - стандарт, 1200 - low, 115200 - fast
    Public Sub New(serial As ISerialDevice)
        _serial = serial
        _serial.AutoReadBytes = False
    End Sub

    Public Sub New()
        _serial = New FastSerialPort
        _serial.AutoReadBytes = False
    End Sub

    Public Sub New(Optional serialPortIndex As Integer = 0)
        Me.New(System.IO.Ports.SerialPort.GetPortNames(serialPortIndex))
    End Sub

    Public Sub New(serialPortName As String)
        _serial = New FastSerialPort
        _serial.DeviceAddress = serialPortName
        _serial.DeviceSpeed = 9600
        _serial.AutoReadBytes = False
    End Sub

    Public Sub Connect()
        _serial.Connect()
    End Sub

    Public Sub Disconnect()
        _serial.Disconnect()
    End Sub

    Public ReadOnly Property IsConnected()
        Get
            Return _serial.IsConnected
        End Get
    End Property
    ''' <summary>
    ''' Устройство последовательной связи.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SerialDevice As ISerialDevice
        Get
            Return _serial
        End Get
    End Property
    Private Sub AddBytes(list As List(Of Byte), val As Byte, crc As Crc16)
        list.Add(val)
        crc.Update(val)
        If val = &H98 Then list.Add(0)
    End Sub

    Public Function MakeRequestBytes(request As SSRequest) As Byte()
        Dim datalength = request.Data.Length
        Dim address = request.Address
        Dim command = request.Command

        If datalength > 127 Then datalength = 127
        Dim bytes As New List(Of Byte)
        Dim crc16 As New Crc16
        bytes.Add(0)
        bytes.AddRange({&H98, 1})
        Dim crcstart = bytes.Count
        AddBytes(bytes, (address >> 8) And 255, crc16)
        AddBytes(bytes, (address) And 255, crc16)
        AddBytes(bytes, (command), crc16)
        For Each b In request.Data
            AddBytes(bytes, (b), crc16)
        Next
        Dim crcsend = bytes.Count - 1
        Dim crc As UInt16 = crc16.GetCrc
        AddBytes(bytes, (crc >> 8) And 255, crc16)
        AddBytes(bytes, (crc) And 255, crc16)
        bytes.AddRange({&H98, 2})
        '  bytes.Add(0)
        Return bytes.ToArray
    End Function

    Public Sub Send(request As SSRequest)
        Dim bytes = MakeRequestBytes(request)
        _serial.Write(bytes.ToArray)
    End Sub

    Public Function Read() As SSResponse
        SyncLock _syncRoot
            Dim result As New SSResponse
            result.ResponseState = ResponseState.errorNotRequested
            SyncLock _serial
                Dim time = Now
                Dim readSuccess As Boolean = True
                Do While result.ResponseState <> ResponseState.ok And readSuccess
                    Dim currbyte As Byte
                    Dim lastData As Byte
                    readSuccess = False
                    Try
                        If _serial.ReceivedBufferCount > 0 Then
                            currbyte = _serial.Read()
                            readSuccess = True
                        End If
                    Catch ex As Exception
                        result.ResponseState = ResponseState.errorPortError
                        Return result
                    End Try

                    If readSuccess Then
                        If _readBufferPos > _readBuffer.Length - 1 Then
                            _readBufferPos = 0
                        End If

                        If lastData = &H98 Then
                            Select Case currbyte
                                Case 0
                                    _readBuffer(_readBufferPos) = &H98 : _readBufferPos += 1
                                Case &H3
                                    _readBufferPos = 0
                                Case &H4
                                    If _readBufferPos > 4 Then
                                        Dim recvCrc As UShort = _readBuffer(_readBufferPos - 2) * 256 + _readBuffer(_readBufferPos - 1)
                                        Dim realCrc = Crc16.ComputeCrc(_readBuffer, 0, _readBufferPos - 3)
                                        If recvCrc = realCrc Then
                                            result.FromAddress = _readBuffer(0) * 256 + _readBuffer(1)
                                            result.Result = _readBuffer(2)
                                            Dim length = _readBufferPos - 5
                                            result.Data = Array.CreateInstance(GetType(Byte), length)
                                            Array.ConstrainedCopy(_readBuffer, 3, result.Data, 0, length)
                                            result.ResponseState = ResponseState.ok
                                            Return result
                                        Else
                                            result.ResponseState = ResponseState.errorCrc
                                            Return result
                                        End If
                                    End If
                                Case &H98
                                    _readBuffer(_readBufferPos) = currbyte : _readBufferPos += 1
                                Case Else
                            End Select
                        Else
                            If currbyte <> &H98 Then _readBuffer(_readBufferPos) = currbyte : _readBufferPos += 1
                        End If
                        lastData = currbyte
                    Else
                        Threading.Thread.Sleep(TimeSpan.FromTicks(1))
                    End If
                Loop

            End SyncLock
            If result.ResponseState = ResponseState.ok Then
                Return result
            Else
                Return Nothing
            End If
        End SyncLock
    End Function

    Public Class Port
        Public Property PinDirection As Byte
        Public Property PinInput As Byte
        Public Property PinOutput As Byte
        Public Property PinSetMask As Byte
        Public Sub SetPort(direction As Byte, output As Byte, mask As Byte)
            PinDirection = direction
            PinOutput = output
            PinSetMask = mask
            PinInput = 0
        End Sub

        Public Function GetPin(bit As Integer) As Pin
            If bit < 0 Or bit > 7 Then Throw New ArgumentException("Bit must be 0..7", "bit")
            Dim pin As New Pin
            pin.Direction = PinDirection And (1 << bit)
            pin.Input = PinInput And (1 << bit)
            pin.Output = PinOutput And (1 << bit)
            Return pin
        End Function

        Public Sub SetPin(bit As Integer, direction As Boolean, output As Boolean)
            SetPin(bit, New Pin(direction, output))
        End Sub

        Public Sub SetPin(bit As Integer, pin As Pin)
            PinDirection = (PinDirection And Not (1 << bit))
            If pin.Direction Then PinDirection = (PinDirection Or (1 << bit))

            PinOutput = (PinOutput And Not (1 << bit))
            If pin.Output Then PinOutput = (PinOutput Or (1 << bit))

            PinSetMask = (PinSetMask Or (1 << bit))
        End Sub
    End Class

    Public Class Ports
        Public Property PortA As New Port
        Public Property PortB As New Port
        Public Property PortC As New Port
        Public Property PortD As New Port
        Public Function GetPort(portIndex As Integer) As Port
            If portIndex = 0 Then Return PortA
            If portIndex = 1 Then Return PortB
            If portIndex = 2 Then Return PortC
            If portIndex = 3 Then Return PortD
            Throw New ArgumentException("PortIndex must be 0..3", "portIndex")
        End Function
    End Class

    Public Class Pin
        Public Property Output As Boolean
        Public Property Input As Boolean
        Public Property Direction As Boolean
        Public Sub New()

        End Sub
        Public Sub New(direction As Boolean, output As Boolean)
            Me.Direction = direction
            Me.Output = output
        End Sub
    End Class

    Public Sub RequestPinSet(address As Integer, portIndex As Integer, pinIndex As Integer, direction As Boolean, output As Boolean)
        RequestPinSet(address, portIndex, pinIndex, New Pin(direction, output))
    End Sub

    Public Sub RequestPinSet(address As Integer, portIndex As Integer, pinIndex As Integer, pin As Pin)
        Dim ports As New Ports
        ports.GetPort(portIndex).SetPin(pinIndex, pin)
        RequestPortsChange(address, ports)
    End Sub

    Public Function RequestPortsRead(address As Integer) As Ports
        Dim pins As New Ports
        Dim bytes(2) As Byte
        bytes(0) = 2
        Dim req As New SSRequest(address, 250, bytes)
        Dim resp = Request(req, RequestRetriesDefault)
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

    Public Sub RequestPortsChange(address As Integer, pins As Ports)
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
        Dim resp = Request(req, RequestRetriesDefault)
        If resp.ResponseState <> ResponseState.ok Then Throw New Exception(resp.ResponseState.ToString)
    End Sub

    Public Property RequestRetriesDefault = 1

    Function Request(requestPacket As SSRequest, retries As Integer) As SSResponse
        For i = 1 To retries - 1
            Dim result = Request(requestPacket)
            If result.ResponseState = ResponseState.ok Then Return result
            Debug.WriteLine("Retry " + Command.ToString)
            Threading.Thread.Sleep(200)
        Next
        Return Request(requestPacket)
    End Function

    ''' <summary>
    ''' Выполнить запрос и получить ответ. 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Request(address As UShort, command As Byte, ParamArray data As Byte()) As SSResponse
        Return Request(New SSRequest(address, command, data))
    End Function

    ''' <summary>
    ''' Выполнить запрос и получить ответ. 
    ''' </summary>
    ''' <param name="requestPacket">Пакет данных запроса</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Request(requestPacket As SSRequest) As SSResponse
        SyncLock _syncRoot
            Dim result As New SSResponse
            SyncLock _serial
                Try
                    Do While _serial.ReceivedBufferCount > 0
                        _serial.Read()
                    Loop
                Catch ex As Exception
                End Try
                Send(requestPacket)
                result.ResponseState = ResponseState.errorTimeout
                Dim time = Now
                Dim receivedLength As Integer
                Dim receivedBuffer(1024) As Byte

                Do While (Now - time).TotalMilliseconds < RequestTimeout And result.ResponseState = ResponseState.errorTimeout

                    Dim readSuccess As Boolean = False
                    Dim currbyte As Byte
                    Dim lastData As Byte
                    Try
                        If _serial.ReceivedBufferCount > 0 Then
                            currbyte = _serial.Read()
                            readSuccess = True
                        End If
                    Catch ex As Exception
                        result.ResponseState = ResponseState.errorPortError
                        Return result
                    End Try

                    If readSuccess Then
                        If receivedLength > receivedBuffer.Length - 1 Then
                            receivedLength = 0
                        End If

                        If lastData = &H98 Then
                            Select Case currbyte
                                Case 0
                                    receivedBuffer(receivedLength) = &H98 : receivedLength += 1
                                Case &H3
                                    receivedLength = 0
                                Case &H4
                                    If receivedLength > 4 Then
                                        Dim recvCrc As UShort = receivedBuffer(receivedLength - 2) * 256 + receivedBuffer(receivedLength - 1)
                                        Dim realCrc = Crc16.ComputeCrc(receivedBuffer, 0, receivedLength - 3)
                                        If recvCrc = realCrc Then
                                            result.FromAddress = receivedBuffer(0) * 256 + receivedBuffer(1)
                                            result.Result = receivedBuffer(2)
                                            Dim length = receivedLength - 5
                                            result.Data = Array.CreateInstance(GetType(Byte), length)
                                            Array.ConstrainedCopy(receivedBuffer, 3, result.Data, 0, length)
                                            result.ResponseState = ResponseState.ok
                                            Return result
                                        Else
                                            result.ResponseState = ResponseState.errorCrc
                                            Return result
                                        End If
                                    End If
                                Case &H98
                                    receivedBuffer(receivedLength) = currbyte : receivedLength += 1
                                Case Else
                            End Select
                        Else
                            If currbyte <> &H98 Then receivedBuffer(receivedLength) = currbyte : receivedLength += 1
                        End If
                        lastData = currbyte
                    Else
                        Threading.Thread.Sleep(10)
                    End If
                Loop
                ' If result.ResponseState = ResponseState.errorTimeout Then Stop
                Return result
            End SyncLock
        End SyncLock
    End Function

    ''' <summary>
    ''' Самотестирование устройства на произвольных данных (не менее 1 байта и не более буфера устройства).
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RequestTestDevice(address As Integer, testData As Byte())
        If testData Is Nothing OrElse testData.Length < 1 Then Throw New Exception("Data must be 1 byte at least")
        Dim request As New SSRequest(address, 252, testData)
        Dim response = Me.Request(request, RequestRetriesDefault)
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

    Public Sub RequestTestDevice(address As Integer, maxLength As Integer)
        Dim length = _rnd.Next(1, maxLength)
        Dim testdata As New List(Of Byte)
        For i = 1 To length
            testdata.Add(_rnd.Next(0, 255))
        Next
        RequestTestDevice(address, testdata.ToArray)
    End Sub

    Public Function UInt16ToBytes(uint As UInt16) As Byte()
        Dim result(1) As Byte
        result(0) = (uint >> 8) And 255
        result(1) = uint And 255
        Return result
    End Function

    Public Sub RequestSetAddress(guid As Guid, address As Integer)
        Dim bytes = New List(Of Byte)
        bytes.AddRange(guid.ToByteArray)
        bytes.AddRange(UInt16ToBytes(address))
        Dim result = Request(New SSRequest(0, 253, bytes.ToArray), RequestRetriesDefault)
        If result.ResponseState = ResponseState.ok AndAlso result.Result = 0 Then Return
        Throw New Exception("RequestSetAddress: bad response: " + result.ResponseState.ToString + " " + result.Result.ToString)
    End Sub

    Public Sub RequestRestart(address As Integer)
        Dim result = Request(New SSRequest(address, 251, {255}), RequestRetriesDefault)
        If result.ResponseState = ResponseState.ok AndAlso result.Result = 0 Then Return
        Throw New Exception("RequestRestart: bad response: " + result.ResponseState.ToString + " " + result.Result.ToString)
    End Sub

    Public Sub RequestGoToBootloader(address As Integer)
        Dim result = Request(New SSRequest(address, 251, {2}), RequestRetriesDefault)
        If result.ResponseState = ResponseState.ok AndAlso result.Result = 0 Then Return
        Throw New Exception("RequestGoToBootloader: bad response: " + result.ResponseState.ToString + " " + result.Result.ToString)
    End Sub
    Public Sub RequestGoToMain(address As Integer)
        Dim result = Request(New SSRequest(address, 251, {1}), RequestRetriesDefault)
        If result.ResponseState = ResponseState.ok AndAlso result.Result = 0 Then Return
        Throw New Exception("RequestGoToMain: bad response: " + result.ResponseState.ToString + " " + result.Result.ToString)
    End Sub
    ''' <summary>
    ''' Запросить базовую информацию устройства (команда 120).
    ''' </summary>
    ''' <param name="address">Адрес устройства.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RequestDeviceInfo(address As Integer) As DeviceInfo
        Dim result = Request(New SSRequest(address, 254, {}), RequestRetriesDefault)
        Dim ascii = Text.ASCIIEncoding.ASCII
        Dim info As New DeviceInfo With {.Response = result}
        If result.ResponseState = ResponseState.ok Then
            If result.Result = 0 And result.Data.Length >= 54 Then
                Dim arr(15) As Byte
                For i = 0 To 15
                    arr(i) = result.Data(i)
                Next
                For i = 16 To 54
                    If result.Data(i) < &H20 Or result.Data(i) > &H7E Then result.Data(i) = &H20
                Next
                info.DeviceGuid = New Guid(arr)
                info.DeviceName = ascii.GetString(result.Data, 16, 32).Trim
                info.DeviceDate = ascii.GetString(result.Data, 48, 6).Trim
                If result.Data.Length >= 86 Then
                    info.BootName = ascii.GetString(result.Data, 54, 16).Trim
                    info.ProtocolVersion = ascii.GetString(result.Data, 70, 6).Trim
                End If
                If info.DeviceName.StartsWith("BwlBoot") Then
                    info.BootloaderMode = True
                    info.BootName = info.DeviceName.Substring(0, 16).Trim.Replace(":", "")
                End If
                Return info
            End If
        End If
        Return info
    End Function

    Public Function FindDevices(seed As Integer) As Guid()
        Dim bytes = BitConverter.GetBytes(seed)
        Send(New SSRequest(0, 255, {0, bytes(0), bytes(1), bytes(2), bytes(3)}))
        Debug.WriteLine(seed.ToString)
        Dim timeout = 1
        Dim start = Now
        Dim list As New List(Of Guid)
        Do While (Now - start).TotalSeconds < timeout
            Dim result = Read()
            Try
                If result IsNot Nothing AndAlso result.ResponseState = ResponseState.ok Then
                    Dim arr(15) As Byte
                    For i = 0 To 15
                        arr(i) = result.Data(i)
                    Next
                    Dim sg = New Guid(arr)
                    If list.Contains(sg) = False Then list.Add(sg)
                End If
            Catch ex As Exception

            End Try
        Loop
        Return list.ToArray
    End Function

    Private _rnd As New Random
    Public Function FindDevices() As Guid()
        Dim randi = _rnd.Next
        Return FindDevices(randi)
    End Function

End Class


