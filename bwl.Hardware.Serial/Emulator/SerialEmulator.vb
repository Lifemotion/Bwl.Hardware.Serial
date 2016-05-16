Public Class SerialEmulator
    Inherits SerialDevice
    Private _emuRxBuffer As New List(Of Byte)
    Private _emuTxBuffer As New List(Of Byte)
    Private _loop As Threading.Thread

    Sub New()
        Dim funcs As New WorkFunctions
        funcs.connectFunction = AddressOf ConnectFunction
        funcs.disconnectFunction = AddressOf DisconnectFunction
        funcs.pingFunction = AddressOf PingFunction
        funcs.readFunction = AddressOf ReadFunction
        funcs.readOneFunction = AddressOf ReadByteFunction
        funcs.writeFunction = AddressOf WriteFunction
        funcs.writeOneFunction = AddressOf WriteByteFunction
        funcs.getRxBufferLengthFunction = AddressOf GetRxCount
        Init("DEV[#]", "", funcs)
        '   Logger.AddMessage("Класс SerialEmulator создан.")
        DeviceAddress = "DEV1"
    End Sub

    Public Property EmuCanConnect As Boolean = True

    Private Sub ConnectFunction()
        If EmuCanConnect Then
            '      Logger.AddMessage("Connected by request")
        Else
            Throw New Exception("Emualtor CanConnect=false")
        End If
    End Sub

    Private Sub DisconnectFunction(reason As DisconnectReason)
        '       Logger.AddMessage("Disconnected by " + reason.ToString)
    End Sub

    Private Function PingFunction() As Boolean
        '      Logger.AddDebug("Ping requested: true")
        Return True
    End Function

    Private Function GetRxCount() As Integer
        SyncLock _emuRxBuffer
            Return _emuRxBuffer.Count
        End SyncLock
    End Function

    Private Function ReadByteFunction() As Byte
        Dim ready As Boolean = False
        Do
            SyncLock _emuRxBuffer
                ready = _emuRxBuffer.Count > 0
            End SyncLock
            If Not ready Then Threading.Thread.Sleep(10)
        Loop While Not ready
        SyncLock _emuRxBuffer
            Dim result = _emuRxBuffer(0)
            _emuRxBuffer.RemoveAt(0)
            Return result
        End SyncLock
    End Function

    Private Function ReadFunction(count As Integer) As Byte()
        Dim ready As Boolean = False
        Dim result As New List(Of Byte)
        Do
            SyncLock _emuRxBuffer
                If _emuRxBuffer.Count > 0 Then
                    result.Add(_emuRxBuffer(0))
                    _emuRxBuffer.RemoveAt(0)
                End If
                If result.Count = count Then ready = True
            End SyncLock
        Loop While Not ready
        Return result.ToArray
    End Function

    Private Sub WriteByteFunction(oneByte As Byte)
        SyncLock _emuTxBuffer
            _emuTxBuffer.Add(oneByte)
        End SyncLock
    End Sub

    Private Sub WriteFunction(bytes() As Byte)
        SyncLock _emuTxBuffer
            _emuTxBuffer.AddRange(bytes)
        End SyncLock
    End Sub

    Public Function EmuToRead() As Integer
        SyncLock _emuTxBuffer
            Return _emuTxBuffer.Count
        End SyncLock
    End Function

    Public Function EmuToWrite() As Integer
        SyncLock _emuRxBuffer
            Return _emuRxBuffer.Count
        End SyncLock
    End Function

    Public Sub EmuWrite(one As Byte)
        SyncLock _emuRxBuffer
            _emuRxBuffer.Add(one)
        End SyncLock
    End Sub

    Public Sub EmuWrite(arr As Byte())
        SyncLock _emuRxBuffer
            _emuRxBuffer.AddRange(arr)
        End SyncLock
    End Sub

    Public Function EmuRead() As Byte
        SyncLock _emuTxBuffer
            Dim result = _emuTxBuffer(0)
            _emuTxBuffer.RemoveAt(0)
            Return result
        End SyncLock
    End Function

    Public Property MakeLoop As Boolean
        Set(value As Boolean)
            If value <> MakeLoop Then
                If value Then
                    _loop = New Threading.Thread(AddressOf LoopThread)
                    _loop.Name = "SerialDeviceLoop"
                    _loop.IsBackground = True
                    _loop.Start()
                Else

                End If
            End If
        End Set
        Get
            If _loop IsNot Nothing Then
                If _loop.IsAlive Then
                    Return True
                End If
            End If
            Return False
        End Get
    End Property

    Private Sub LoopThread()
        Do
            If EmuToRead() > 0 Then
                Dim one = EmuRead()
                EmuWrite(one)
            Else
                Threading.Thread.Sleep(10)
            End If
        Loop
    End Sub

End Class
