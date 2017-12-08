Imports System.Diagnostics
#Disable Warning BC40056 ' Пространство имен или тип, указанный в операторе Imports, не содержит открытый член, или невозможно найти пространство имен или тип
Imports Bwl.Hardware.Serial
#Enable Warning BC40056 ' Пространство имен или тип, указанный в операторе Imports, не содержит открытый член, или невозможно найти пространство имен или тип
''' <summary>
''' Реализация базового интерфейса шины SimplSerial.
''' </summary>
''' <remarks></remarks>
Public Class SimplSerialBus
    Implements ISimplSerialBus
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
    Public Event Logger(type As String, msg As String)

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

    Public Sub Connect() Implements ISimplSerialBus.Connect
        _serial.Connect()
    End Sub

    Public Sub Disconnect() Implements ISimplSerialBus.Disconnect
        _serial.Disconnect()
    End Sub

    Public ReadOnly Property IsConnected() As Boolean Implements ISimplSerialBus.IsConnected
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

    Public Sub Send(request As SSRequest) Implements ISimplSerialBus.Send
        Dim bytes = MakeRequestBytes(request)
        _serial.Write(bytes.ToArray)
        RaiseEvent Logger("DBG", "SS <- " + request.ToString)
    End Sub

    Public Function Read() As SSResponse Implements ISimplSerialBus.Read
        SyncLock _syncRoot
            Static readLastByte As Byte
            Dim result As New SSResponse
            result.ResponseState = ResponseState.errorNotRequested
            SyncLock _serial
                Dim readSuccess As Boolean = True
                Do While result.ResponseState <> ResponseState.ok And readSuccess
                    readSuccess = False
                    Dim currbyte As Byte
                    Try
                        If _serial.ReceivedBufferCount > 0 Then
                            currbyte = _serial.Read()
                            readSuccess = True
                        End If
                    Catch ex As Exception
                        result.ResponseState = ResponseState.errorPortError
                        RaiseEvent Logger("DBG", "SS -> " + result.ToString)
                        Return result
                    End Try

                    If readSuccess Then
                        If _readBufferPos > _readBuffer.Length - 1 Then
                            _readBufferPos = 0
                        End If

                        If readLastByte = &H98 Then
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
                                            RaiseEvent Logger("DBG", "SS -> " + result.ToString)
                                            Return result
                                        Else
                                            result.ResponseState = ResponseState.errorCrc
                                            RaiseEvent Logger("DBG", "SS -> " + result.ToString)
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
                        readLastByte = currbyte
                    Else
                        Threading.Thread.Sleep(1)
                    End If
                Loop

            End SyncLock
            If result.ResponseState = ResponseState.ok Then
                RaiseEvent Logger("DBG", "SS -> " + result.ToString)
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

    Public Property RequestRetriesDefault = 1 As Integer Implements ISimplSerialBus.RequestRetriesDefault

    Function Request(requestPacket As SSRequest, retries As Integer) As SSResponse Implements ISimplSerialBus.Request
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
    Public Function Request(address As UShort, command As Byte, ParamArray data As Byte()) As SSResponse Implements ISimplSerialBus.Request
        Return Request(New SSRequest(address, command, data))
    End Function

    Public Property DebugIgnoreCrcErrors As Boolean = False

    ''' <summary>
    ''' Выполнить запрос и получить ответ. 
    ''' </summary>
    ''' <param name="requestPacket">Пакет данных запроса</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Request(requestPacket As SSRequest) As SSResponse Implements ISimplSerialBus.Request
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
                        RaiseEvent Logger("DBG", "SS -> " + result.ToString)
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
                                            RaiseEvent Logger("DBG", "SS -> " + result.ToString)
                                            Return result
                                        Else
                                            If Not DebugIgnoreCrcErrors Then
                                                result.ResponseState = ResponseState.errorCrc
                                                RaiseEvent Logger("DBG", "SS -> " + result.ToString)
                                                Return result
                                            Else
                                                result.FromAddress = receivedBuffer(0) * 256 + receivedBuffer(1)
                                                result.Result = receivedBuffer(2)
                                                Dim length = receivedLength - 5
                                                result.Data = Array.CreateInstance(GetType(Byte), length)
                                                Array.ConstrainedCopy(receivedBuffer, 3, result.Data, 0, length)
                                                result.ResponseState = ResponseState.ok
                                                RaiseEvent Logger("WRN", "SS Crc Error ignored: " + recvCrc.ToString + " vs" + realCrc.ToString)
                                                RaiseEvent Logger("DBG", "SS -> " + result.ToString)
                                                Return result
                                            End If
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
                RaiseEvent Logger("DBG", "SS -> " + result.ToString)
                Return result
            End SyncLock
        End SyncLock
    End Function

    Public Shared Function UInt16ToBytes(uint As UInt16) As Byte()
        Dim result(1) As Byte
        result(0) = (uint >> 8) And 255
        result(1) = uint And 255
        Return result
    End Function

    Public Function FindDevices(seed As Integer, timeout As Double) As Guid()
        Dim bytes = BitConverter.GetBytes(seed)
        SyncLock _syncRoot
            Send(New SSRequest(0, 255, {0, bytes(0), bytes(1), bytes(2), bytes(3)}))
        End SyncLock
        Dim start = Now
        Dim list As New List(Of Guid)
        Do While (Now - start).TotalSeconds < timeout
            Dim result = Read()
            Try
                If result IsNot Nothing AndAlso result.ResponseState = ResponseState.ok AndAlso result.Data IsNot Nothing AndAlso result.Data.Length = 16 Then
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
        Return FindDevices(randi, 2)
    End Function

End Class


