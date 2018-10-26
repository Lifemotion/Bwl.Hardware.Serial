
Public Class DeviceInfo
    Public Property Response As SSResponse
    Property DeviceName As String = ""
    Property DeviceDate As String = ""
    Property BootName As String = ""
    Property ProtocolVersion As String = ""
    Property DeviceGuid As Guid
    Property BootloaderMode As Boolean = False

    Property Signature As String = ""
    Property Fuses As String = ""
    Property Lock As String = ""
    Property ChipSerialNumber As UInt64
End Class
