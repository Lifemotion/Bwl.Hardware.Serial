Public Class FastSerialPort
    Implements ISerialDevice, ISerialDeviceSence, ISerialDeviceSignals


    Private _rs232 As New IO.Ports.SerialPort
    Public Property DeviceAddress As String = "" Implements ISerialDevice.DeviceAddress
    Public Property AutoConnect As Boolean Implements ISerialDevice.AutoConnect
    Public Property AutoReadBytes As Boolean Implements ISerialDevice.AutoReadBytes
    Public Property BetweenBytesPause As Integer Implements ISerialDevice.BetweenBytesPause
    Public Property DeviceParameters As String = "" Implements ISerialDevice.DeviceParameters
    Public Property DeviceSpeed As Integer Implements ISerialDevice.DeviceSpeed

    Public Event BytesArrived(from As SerialDevice, count As Integer) Implements ISerialDevice.BytesArrived
    Public Event BytesRead(from As SerialDevice, bytes() As Byte, fromAutoRead As Boolean) Implements ISerialDevice.BytesRead
    Public Event BytesSent(from As SerialDevice, bytes() As Byte) Implements ISerialDevice.BytesSent
    Public Event DeviceConnected(from As SerialDevice) Implements ISerialDevice.DeviceConnected
    Public Event DeviceDisconnected(from As SerialDevice, reason As DisconnectReason) Implements ISerialDevice.DeviceDisconnected
    Public Event DeviceAbsent(from As SerialDevice) Implements ISerialDeviceSence.DeviceAbsent
    Public Event DevicePresent(from As SerialDevice) Implements ISerialDeviceSence.DevicePresent

    Public Sub Connect() Implements ISerialDevice.Connect
        SyncLock _rs232
            _rs232.Close()
            _rs232.PortName = DeviceAddress
            _rs232.BaudRate = DeviceSpeed
            _rs232.Open()
        End SyncLock
    End Sub

    Public ReadOnly Property DeviceAddressFormat As String Implements ISerialDevice.DeviceAddressFormat
        Get
            Return "COM#"
        End Get
    End Property

    Public Sub Disconnect() Implements ISerialDevice.Disconnect
        SyncLock _rs232
            _rs232.Close()
        End SyncLock
    End Sub

    Public ReadOnly Property IsConnected As Boolean Implements ISerialDevice.IsConnected
        Get
            SyncLock _rs232
                Return _rs232.IsOpen
            End SyncLock
        End Get
    End Property

    Public Event PropertiesChanged() Implements ISerialDevice.PropertiesChanged

    Public Function Read() As Byte Implements ISerialDevice.Read
        SyncLock _rs232
            Return _rs232.ReadByte
        End SyncLock
    End Function

    Public Function Read(count As Integer) As Byte() Implements ISerialDevice.Read
        SyncLock _rs232

            Dim buff(count) As Byte
            _rs232.Read(buff, 0, count)
            Return buff
        End SyncLock
    End Function

    Public ReadOnly Property ReceivedBufferCount As Integer Implements ISerialDevice.ReceivedBufferCount
        Get
            SyncLock _rs232
                Try
                    Return _rs232.BytesToRead
                Catch ex As Exception
                    _rs232.Close()
                    Throw ex
                End Try
            End SyncLock
        End Get
    End Property

    Public Function TryConnect() As Boolean Implements ISerialDevice.TryConnect
        Try
            Connect()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Sub Write(oneByte As Byte) Implements ISerialDevice.Write
        SyncLock _rs232
            _rs232.Write({oneByte}, 0, 1)
        End SyncLock
    End Sub

    Public Sub Write(bytes() As Byte) Implements ISerialDevice.Write
        SyncLock _rs232
            _rs232.Write(bytes, 0, bytes.Length)
        End SyncLock
    End Sub

    Public Function WriteWaitAnswer(command() As Byte, Optional endWithByte As Integer = -1, Optional messageLength As Integer = -1, Optional timeout As Integer = 1000) As Byte() Implements ISerialDevice.WriteWaitAnswer
        Throw New Exception("not implemented")
    End Function


    Public ReadOnly Property IsPresent As Boolean Implements ISerialDeviceSence.IsPresent
        Get
            Return True
        End Get
    End Property

    Public Property SignalDTR As Boolean Implements ISerialDeviceSignals.SignalDTR
        Set(value As Boolean)
            SyncLock _rs232
                _rs232.DtrEnable = value
            End SyncLock
        End Set
        Get
            SyncLock _rs232
                Return _rs232.DtrEnable
            End SyncLock
        End Get
    End Property

    Public Property SignalRTS As Boolean Implements ISerialDeviceSignals.SignalRTS
        Set(value As Boolean)
            SyncLock _rs232
                _rs232.RtsEnable = value
            End SyncLock
        End Set
        Get
            SyncLock _rs232
                Return _rs232.RtsEnable
            End SyncLock
        End Get
    End Property
End Class
