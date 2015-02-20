Public Interface ISerialDeviceSence
    Event DevicePresent(from As SerialDevice)
    Event DeviceAbsent(from As SerialDevice)
    ReadOnly Property IsPresent() As Boolean
End Interface
