Imports FTD2XX_NET
Imports FTD2XX_NET.FTDI
Imports System.Threading
Imports Bwl.Framework

Public Class FTDIUsbDevice
    Inherits SerialDevice
    ''' <summary>
    ''' Исключение, возникшее в классе устройства USB.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class UsbDeviceException
        Inherits Exception
        Sub New(ByVal message As String)
            MyBase.New(message)
        End Sub
        Sub New()

        End Sub
    End Class

    Private Const bufferSize = 256
    Private device As New FTDI
    Public Sub New()
        Dim funcs As New WorkFunctions
        funcs.connectFunction = AddressOf ConnectRealization
        funcs.disconnectFunction = AddressOf DisconnectRealization
        funcs.pingFunction = AddressOf PingerRealization
        funcs.readFunction = AddressOf ReadRealization
        funcs.readOneFunction = AddressOf ReadByteFunction
        funcs.writeFunction = AddressOf WriteRealization
        funcs.writeOneFunction = AddressOf WriteByteFunction
        funcs.getRxBufferLengthFunction = AddressOf GetRxBytesAvailableRealization
        Init("[VID][PID]", "", funcs, New Logger)
    End Sub
    ''' <summary>
    ''' Проверяет состояние USB-модуля. Вызывается таймером pingTimer
    ''' </summary>
    ''' <remarks></remarks>
    Private Function PingerRealization() As Boolean
        Dim result = True
        Dim status As FT_STATUS
        If Not device.GetLineStatus(status) = FT_STATUS.FT_OK Then result = False
        Return result
    End Function

    Public Sub GoToAsyncBitBang()
        device.SetBitMode(255, 1)
    End Sub

    Private Function ConnectRealization() As Boolean
        Dim result = False
        SyncLock device
            'определяем число устройств FTDI
            Dim deviceCount As UInteger = 0
            device.GetNumberOfDevices(deviceCount)
            'получаем их список
            Dim deviceList(deviceCount - 1) As FT_DEVICE_INFO_NODE
            device.GetDeviceList(deviceList)
            'ищем среди них синхронизатор
            For Each dev In deviceList
                'идентификатор синхронизатора №3, полученный из Vid и Pid
                If dev.ID = CUInt(Val(DeviceAddress)) Then
                    If device.OpenByLocation(dev.LocId) = FT_STATUS.FT_OK Then
                        'нашли, устанавливаем параметры обмена
                        device.SetBaudRate(DeviceSpeed)
                        device.SetFlowControl(FT_FLOW_CONTROL.FT_FLOW_NONE, 0, 0)
                        device.SetDataCharacteristics(FT_DATA_BITS.FT_BITS_8, FT_STOP_BITS.FT_STOP_BITS_1, FT_PARITY.FT_PARITY_NONE)
                        device.SetTimeouts(1000, 1000)
                        result = True
                    End If
                End If
            Next
            'раз мы здесь, значит, не нашли устройства
            If Not result Then Throw New UsbDeviceException("Не удалось найти и подключить устройство USB!")
        End SyncLock
        Return result
    End Function

    ''' <summary>
    ''' Отключить синхронизатор.
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    Public Sub DisconnectRealization()
        Try
            device.Close()
        Catch ex As Exception
        End Try
    End Sub

    Public Sub WriteRealization(ByVal bytes() As Byte)
        SyncLock device
            Dim bytesWritten As Integer
            Dim tmp(0) As Byte
            For i As Integer = 0 To bytes.Length - 1
                tmp(0) = bytes(i)
                device.SetBitMode(255, 1)
                device.Write(tmp, 1, bytesWritten)
                Thread.Sleep(15)
                If bytesWritten <> 1 Then Throw New UsbDeviceException("Не удалось записать все байты!")
            Next
        End SyncLock
    End Sub

    Public Function ReadRealization(ByVal count As Integer) As Byte()
        Dim result(count) As Byte
        Dim reallyRead As Integer
        SyncLock device
            device.Read(result, CUInt(count), reallyRead)
        End SyncLock
        Return result
    End Function

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Protected Function GetRxBytesAvailableRealization() As Integer
        Dim count = 0
        If IsConnected And device.IsOpen Then
            Dim tmp As Integer
            If device.GetRxBytesAvailable(tmp) = FT_STATUS.FT_OK Then
                count = tmp
            Else
                count = 0
            End If
        End If
        Return count
    End Function

    Private Function ReadByteFunction() As Byte
        Throw New NotImplementedException
    End Function

    Private Sub WriteByteFunction(onebyte As Byte)
        Throw New NotImplementedException
    End Sub

End Class
