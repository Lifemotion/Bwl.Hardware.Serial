Public Interface ISerialDeviceSence
    Event DevicePresent(from As ISerialDevice)
    Event DeviceAbsent(from As ISerialDevice)
    ReadOnly Property IsPresent() As Boolean
End Interface
