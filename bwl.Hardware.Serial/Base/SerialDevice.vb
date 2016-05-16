Imports System.Threading
Public MustInherit Class SerialDevice
    Implements ISerialDevice

    Public Class WorkFunctions
        Public Delegate Function GetRxBufferLengthDelegate() As Integer
        Public Delegate Sub ConnectDelegate()
        Public Delegate Sub DisconnectDelegate(reason As DisconnectReason)
        Public Delegate Function PingDelegate() As Boolean
        Public Delegate Sub WriteDelegate(ByVal bytes() As Byte)
        Public Delegate Sub WriteOneDelegate(ByVal byteOne As Byte)
        Public Delegate Function ReadDelegate(ByVal count As Integer) As Byte()
        Public Delegate Function ReadOneDelegate() As Byte
        Public getRxBufferLengthFunction As GetRxBufferLengthDelegate
        Public connectFunction As ConnectDelegate
        Public disconnectFunction As DisconnectDelegate
        Public pingFunction As PingDelegate
        Public writeFunction As WriteDelegate
        Public writeOneFunction As WriteOneDelegate
        Public readFunction As ReadDelegate
        Public readOneFunction As ReadOneDelegate
    End Class

    Private _deviceAddressFormat As String = "COM[номер порта]"
    Private _deviceParametersFormat As String = "Нет параметров"
    Private _workFunctions As WorkFunctions
    Private _deviceAddress As String = ""
    Private _deviceParameters As String = ""
    Private _isConnected As Boolean
    Private _autoRead As Boolean
    Private _autoReadBlock As Boolean
    Private _deviceSync As New Object
    Private _betweenBytesPause As Integer
    Private _readThread As New Thread(AddressOf AutoReaderThread)
    Private _pingThread As New Thread(AddressOf AutoReaderThread)
    Private _autoConnectThread As New Thread(AddressOf AutoReaderThread)
    Dim _autoConnect As Boolean

    Public Event BytesArrived(from As SerialDevice, ByVal count As Integer) Implements ISerialDevice.BytesArrived
    Public Event BytesRead(from As SerialDevice, ByVal bytes() As Byte, fromAutoRead As Boolean) Implements ISerialDevice.BytesRead
    Public Event DeviceDisconnected(from As SerialDevice, reason As DisconnectReason) Implements ISerialDevice.DeviceDisconnected
    Public Event DeviceConnected(from As SerialDevice) Implements ISerialDevice.DeviceConnected
    Public Event PropertiesChanged() Implements ISerialDevice.PropertiesChanged
    Public Event BytesSent(from As SerialDevice, bytes() As Byte) Implements ISerialDevice.BytesSent

    Public Property BetweenBytesPause() As Integer Implements ISerialDevice.BetweenBytesPause
        Get
            Return _betweenBytesPause
        End Get
        Set(value As Integer)
            _betweenBytesPause = value
            RaiseEvent PropertiesChanged()
        End Set
    End Property

    Protected Sub New()
        _pingThread = New Thread(AddressOf PingThread)
        _pingThread.Name = "Serial Ping"
        _pingThread.Priority = ThreadPriority.Lowest
        _pingThread.IsBackground = True
        _pingThread.Start()

        _autoConnectThread = New Thread(AddressOf AutoConnectThread)
        _autoConnectThread.Name = "Serial Auto Connect"
        _autoConnectThread.Priority = ThreadPriority.Lowest
        _autoConnectThread.IsBackground = True
        _autoConnectThread.Start()

        _readThread = New Thread(AddressOf AutoReaderThread)
        _readThread.Name = "Serial Auto Read"
        _readThread.Priority = ThreadPriority.BelowNormal
        _readThread.IsBackground = True
        _readThread.Start()
    End Sub

    Protected Sub Init(deviceAddressFormat As String, deviceParametersFormat As String, workingFunctions As WorkFunctions)
        _workFunctions = workingFunctions
        _deviceAddressFormat = deviceAddressFormat
        _deviceParametersFormat = deviceParametersFormat
    End Sub

    Public Property DeviceParameters As String Implements ISerialDevice.DeviceParameters
        Get
            Return _deviceParameters
        End Get
        Set(ByVal value As String)
            _deviceParameters = value
            RaiseEvent PropertiesChanged()
        End Set
    End Property

    Public Property DeviceAddress As String Implements ISerialDevice.DeviceAddress
        Get
            Return _deviceAddress
        End Get
        Set(ByVal value As String)
            _deviceAddress = value
            RaiseEvent PropertiesChanged()
        End Set
    End Property

    Public ReadOnly Property DeviceAddressFormat As String Implements ISerialDevice.DeviceAddressFormat
        Get
            Return _deviceAddressFormat
        End Get
    End Property

    ''' <summary>
    ''' Подключено ли сейчас устройство.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property IsConnected() As Boolean Implements ISerialDevice.IsConnected
        Get
            Return _isConnected
        End Get
    End Property

    Public Sub Connect() Implements ISerialDevice.Connect
        _isConnected = False
        SyncLock _deviceSync
            _workFunctions.connectFunction.Invoke()
        End SyncLock
        _isConnected = True
        RaiseEvent DeviceConnected(Me)
    End Sub

    Private _deviceSpeed As Integer = 9600
    Public Property DeviceSpeed As Integer Implements ISerialDevice.DeviceSpeed
        Set(value As Integer)
            _deviceSpeed = value
            RaiseEvent PropertiesChanged()
        End Set
        Get
            Return _deviceSpeed
        End Get
    End Property

    'Private _deviceIdentifier As String
    'Public Property DeviceIdentifier As String Implements ISerialDevice.DeviceIdentifier
    '    Set(value As String)
    '        _deviceIdentifier = value
    '        RaiseEvent PropertiesChanged()
    '    End Set
    '    Get
    '        Return _deviceIdentifier
    '    End Get
    'End Property

    Public Sub Disconnect() Implements ISerialDevice.Disconnect
        DisconnectWithReason(DisconnectReason.request)
    End Sub

    ''' <summary>
    ''' Закрыть порт.
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DisconnectWithReason(reason As DisconnectReason)
        SyncLock _deviceSync
            _workFunctions.disconnectFunction.Invoke(reason)
            _isConnected = False
        End SyncLock
        RaiseEvent DeviceDisconnected(Me, reason)
    End Sub


    ''' <summary>
    ''' Пытаться автоматически установить соединение с синхронизатором.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AutoConnect() As Boolean Implements ISerialDevice.AutoConnect
        Get
            Return _autoConnect
        End Get
        Set(ByVal value As Boolean)
            _autoConnect = value
            RaiseEvent PropertiesChanged()
        End Set
    End Property


    Private Sub AutoConnectThread()
        Do
            If _autoConnect Then
                If Not IsConnected Then TryConnect()
            End If
            Thread.Sleep(1000)
        Loop
    End Sub

    Private Sub PingThread()
        Dim result As Boolean
        Do
            If _isConnected Then
                SyncLock _deviceSync
                    result = _workFunctions.pingFunction.Invoke
                End SyncLock
                If result = False Then DisconnectWithReason(DisconnectReason.noPing)
            End If
            Thread.Sleep(1000)
        Loop
    End Sub

    Public Property AutoReadBytes() As Boolean Implements ISerialDevice.AutoReadBytes
        Get
            Return _autoRead
        End Get
        Set(ByVal value As Boolean)
            _autoRead = value
            RaiseEvent PropertiesChanged()
        End Set
    End Property

    Protected Overrides Sub Finalize()
        DisconnectWithReason(DisconnectReason.system)
    End Sub

    Public Sub Write(ByVal bytes() As Byte) Implements ISerialDevice.Write
        If Not IsConnected Then Throw New Exception("Устройство не подключено!")
        SyncLock _deviceSync
            If _betweenBytesPause = 0 Then
                _workFunctions.writeFunction.Invoke(bytes)
            Else
                For Each bt In bytes
                    Thread.Sleep(_betweenBytesPause)
                    _workFunctions.writeOneFunction(bt)
                Next
            End If
        End SyncLock
        RaiseEvent BytesSent(Me, bytes)
    End Sub

    Public Sub WriteByte(ByVal oneByte As Byte) Implements ISerialDevice.Write
        Static oneByteArr(0) As Byte
        If Not IsConnected Then Throw New Exception("Устройство не подключено!")
        SyncLock _deviceSync
            _workFunctions.writeOneFunction.Invoke(oneByte)
            oneByteArr(0) = oneByte
        End SyncLock
        RaiseEvent BytesSent(Me, oneByteArr)
    End Sub

    ''' <summary>
    ''' Отправить байты устройству и ждать ответ, который и возвращается. 
    ''' Если ответ не получен за указанное время, возвращается пустой массив.
    ''' </summary>
    ''' <param name="command">Байты отправляемой команды.</param>
    ''' <param name="endMessageSymbol">Символ конца сообщения, -1, если не используется.</param>
    ''' <param name="messageLength">Длина сообщения, -1, если не используется.</param>
    ''' <returns>Массив байт ответа устройства.</returns>
    ''' <remarks></remarks>
    Public Function WriteWaitAnswer(ByVal command() As Byte, Optional ByVal endMessageSymbol As Integer = -1, Optional ByVal messageLength As Integer = -1, Optional ByVal timeout As Integer = 1000) As Byte() Implements ISerialDevice.WriteWaitAnswer
        If timeout <= 0 Then timeout = Integer.MaxValue
        If messageLength = -1 Then messageLength = Integer.MaxValue
        If Not IsConnected Then Throw New Exception("Устройство не подключено!")
        Dim result(512 - 1) As Byte '!!Костыль
        SyncLock _deviceSync
            _autoReadBlock = True

            'очищаем буфер от уже принятых ненужных нам значений
            Dim size As UInteger = _workFunctions.getRxBufferLengthFunction.Invoke
            _workFunctions.readFunction.Invoke(size)

            'буфер-приемник и позиция в нем
            Dim position As Integer
            Dim received(0) As Byte
            'отправляем байты запроса
            _workFunctions.writeFunction.Invoke(command)
            RaiseEvent BytesSent(Me, command)

            'получаем ответ по одному байту до тех пор, пока не выполнится граничное условие или таймаут
            Dim length As Integer
            Dim time = Now
            Do
                length = _workFunctions.getRxBufferLengthFunction.Invoke()
                If length > 0 Then
                    Dim receivedByte = _workFunctions.readOneFunction.Invoke
                    result(position) = receivedByte
                    position += 1
                End If

            Loop While received(0) <> endMessageSymbol And position < messageLength And (Now - time).TotalMilliseconds < timeout

            ReDim Preserve result(position - 1)

            _autoReadBlock = False
        End SyncLock
        Return result
    End Function

    Public ReadOnly Property ReceivedBufferCount() As Integer Implements ISerialDevice.ReceivedBufferCount
        Get
            Return _workFunctions.getRxBufferLengthFunction.Invoke
        End Get
    End Property

    Private Sub AutoReaderThread()
        Dim lastBytesCount As UInteger
        Do
            Try
                Dim raiseArrived = False
            Dim raiseRead = False
            Dim bytesCount As Integer
            Dim bytes() As Byte = Nothing
            Thread.Sleep(1)
            SyncLock _deviceSync
                If IsConnected And Not _autoReadBlock Then
                    bytesCount = _workFunctions.getRxBufferLengthFunction.Invoke
                    If lastBytesCount <> bytesCount Then
                        If _autoRead Then
                            bytes = _workFunctions.readFunction.Invoke(bytesCount)
                            bytesCount = 0
                            If bytes.Length > 0 Then raiseRead = True
                        Else
                            raiseArrived = True
                        End If
                    End If
                    lastBytesCount = bytesCount
                    Thread.Sleep(1)
                End If
            End SyncLock
            If raiseRead Then RaiseEvent BytesRead(Me, bytes, True)
                If raiseArrived Then RaiseEvent BytesArrived(Me, bytesCount)

            Catch ex As Exception

            End Try
        Loop
    End Sub

    Public Function Read(ByVal count As Integer) As Byte() Implements ISerialDevice.Read
        Dim result As Byte()
        SyncLock _deviceSync
            result = _workFunctions.readFunction.Invoke(count)
        End SyncLock
        RaiseEvent BytesRead(Me, result, False)
        Return result
    End Function

    Public Function ReadByte() As Byte Implements ISerialDevice.Read
        Static arr(0) As Byte
        SyncLock _deviceSync
            arr(0) = _workFunctions.readOneFunction.Invoke()
        End SyncLock
        RaiseEvent BytesRead(Me, arr, False)
        Return arr(0)
    End Function

    Public Function TryConnect() As Boolean Implements ISerialDevice.TryConnect
        Try
            Connect()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class
