
Public Class DeviceInfo
    Public Property Response As SSResponse
    Property DeviceName As String = ""
    Property DeviceDate As String = ""
    Property BootName As String = ""
    Property ProtocolVersion As String = ""
    Property DeviceGuid As Guid
    Property BootloaderMode As Boolean = False
End Class
