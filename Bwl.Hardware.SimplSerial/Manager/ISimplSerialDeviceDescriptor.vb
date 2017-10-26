Imports Bwl.Hardware.SimplSerial

Public Interface ISimplSerialDeviceDescriptor
    ReadOnly Property Name As String
    ReadOnly Property SSNameToFind As String
    ReadOnly Property SSWorkAddress As Integer
End Interface
