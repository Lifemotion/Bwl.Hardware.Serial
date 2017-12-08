Public Interface ISimplSerialBus
    ReadOnly Property IsConnected As Boolean
    Property RequestRetriesDefault As Integer
    Sub Connect()
    Sub Disconnect()
    Sub Send(request As SSRequest)
    Function Read() As SSResponse
    Function Request(requestPacket As SSRequest) As SSResponse
    Function Request(requestPacket As SSRequest, retries As Integer) As SSResponse
    Function Request(address As UShort, command As Byte, ParamArray data() As Byte) As SSResponse
End Interface
