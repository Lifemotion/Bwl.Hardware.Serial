Public Enum DisconnectReason
    request
    noPing
    system
End Enum

Public Interface ISerialDevice
    Event BytesArrived(from As SerialDevice, ByVal count As Integer)
    Event BytesRead(from As SerialDevice, ByVal bytes() As Byte, fromAutoRead As Boolean)
    Event DeviceDisconnected(from As SerialDevice, reason As DisconnectReason)
    Event DeviceConnected(from As SerialDevice)
    Event PropertiesChanged()
    Event BytesSent(from As SerialDevice, ByVal bytes() As Byte)

    'Property DeviceIdentifier As String
    Property BetweenBytesPause() As Integer
    Property DeviceParameters As String
    Property DeviceAddress As String
    Property DeviceSpeed As Integer
    Property AutoConnect() As Boolean
    Property AutoReadBytes() As Boolean

    ReadOnly Property ReceivedBufferCount() As Integer
    ReadOnly Property DeviceAddressFormat As String
    ReadOnly Property IsConnected() As Boolean

    Sub Connect()
    Sub Disconnect()
    Function TryConnect() As Boolean

    Sub Write(ByVal bytes() As Byte)
    Sub Write(ByVal oneByte As Byte)

    Function WriteWaitAnswer(ByVal command() As Byte, Optional ByVal endWithByte As Integer = -1, Optional ByVal messageLength As Integer = -1, Optional ByVal timeout As Integer = 1000) As Byte()

    Function Read(ByVal count As Integer) As Byte()
    Function Read() As Byte
End Interface
