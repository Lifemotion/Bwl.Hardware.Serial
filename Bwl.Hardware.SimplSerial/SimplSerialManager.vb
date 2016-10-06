Imports Bwl.Hardware.SimplSerial.SimplSerialBus

Public Class SimplSerialManager
    Private _logger As Logger
    Private ReadOnly _bus As SimplSerialBus
    Private ReadOnly _busLocker As New Object
    Private ReadOnly _rand As New Random(CInt(DateTime.Now.Ticks >> 32))
    Private ReadOnly _adresses As New Dictionary(Of String, UShort)

    Public Sub New(logger As Logger)
        _logger = logger
        _bus = New SimplSerialBus()
        Try
            _bus.Connect()
        Catch ex As Exception

        End Try

        CheckConnection()
    End Sub

    Public ReadOnly Property SSBus As SimplSerialBus
        Get
            Return _bus
        End Get
    End Property

    Public Function CheckConnection() As Boolean
        Dim res = False
        SyncLock (_busLocker)
            If Not _bus.IsConnected Then
                Threading.Thread.Sleep(1)
                Try
                    _bus.Connect()
                Catch ex As Exception
                    _logger.AddWarning("SimplSerailManager - " + ex.Message)
                End Try
            End If
            res = _bus.IsConnected
        End SyncLock
        Return res
    End Function

    Public Function PrepareAndGetShortAddr(addressGuid As Guid, checkAddr As Boolean) As UShort
        Dim shortAddr As UShort = 0
        SyncLock (_busLocker)
            If CheckConnection() Then
                Try
                    shortAddr = GetShortAddr(addressGuid, checkAddr)
                    If shortAddr > 0 Then
                        _bus.RequestSetAddress(addressGuid, shortAddr)
                    End If
                Catch ex As Exception
                    _logger.AddError("SimplSerialManager.GetResponse - " + ex.ToString)
                End Try
            End If
        End SyncLock
        Return shortAddr
    End Function

    Public Function GetShortAddr(AddressGuid As Guid, checkAddr As Boolean) As UShort
        SyncLock (_busLocker)
            SyncLock (_adresses)
                Dim guidStr = AddressGuid.ToString()
                Dim shortAddr = _rand.Next(UShort.MaxValue)
                If checkAddr Then
                    If _adresses.ContainsKey(guidStr) Then
                        shortAddr = _adresses(guidStr)
                    End If

                    If _bus IsNot Nothing Then
                        While (True)
                            Dim res = _bus.RequestDeviceInfo(shortAddr)
                            If (res.Response.ResponseState <> ResponseState.ok) OrElse (res.DeviceGuid = AddressGuid) Then
                                Exit While
                            End If
                            shortAddr = _rand.Next(UShort.MaxValue)
                        End While
                    End If

                    _adresses(guidStr) = shortAddr
                End If
                Return shortAddr
            End SyncLock
        End SyncLock
    End Function
End Class
