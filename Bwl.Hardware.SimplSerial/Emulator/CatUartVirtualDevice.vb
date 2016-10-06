Imports bwl.Hardware.Serial
Imports System.Threading

Public Class CatUartVirtualDevice
    Private _serial As New SerialEmulator
    Public Event ProcessPacketRequest(packet As SSRequest, response As SSResponse)
    Public Event ProcessQuickRequest(ByRef response As Integer)
    Public Property Address As Integer = 10

    Public Sub New(serial As SerialEmulator, name As String, address As Integer)
        _serial = serial
        _Address = address
        Dim deviceThread As New Thread(AddressOf CheckUart)
        deviceThread.Name = "CatUartDevice " + name
        deviceThread.IsBackground = True
        deviceThread.Start()
    End Sub

    Private Property DeviceType As Integer = 22

    Private Property DeviceModel As Integer = 352


    Private Sub CheckUart()
        _serial.EmuCanConnect = True
        Do
            If _serial.EmuToRead() > 0 Then
                Dim data = _serial.EmuRead
                _serial.EmuWrite(data)
                ByteReceived(data)
            End If
            Thread.Sleep(1)
        Loop
    End Sub

    Private Sub ByteReceived(data As Byte)
        Static receivedLength As Integer
        Static receivedBuffer(31) As Byte

        Select Case data
            Case &HFD
                receivedLength = 0
            Case &HFB

            Case Else
                If receivedLength < 32 Then
                    receivedBuffer(receivedLength) = data
                    receivedLength += 1
                End If
        End Select

        If data > 127 Then
            If data = &HFD Then
                receivedLength = 0
            Else
                Dim packet As New SSRequest
                packet.Address = receivedBuffer(0)
                packet.Command = receivedBuffer(2)
                packet.Data(0) = receivedBuffer(3)
                packet.Data(1) = receivedBuffer(4)
                packet.Data(2) = receivedBuffer(5)
                packet.Data(3) = receivedBuffer(6)
                ProcessPacket(packet)
            End If
        Else
        End If
    End Sub

    Protected Sub SendResponse(address As Integer, command As Integer, Optional data1 As Integer = 0, Optional data2 As Integer = 0, Optional data3 As Integer = 0, Optional data4 As Integer = 0)
        Dim type As Byte = 1 + 16
        Dim bytes(9) As Byte
        bytes(0) = 253
        bytes(1) = address + 128
        bytes(2) = type
        bytes(3) = command
        bytes(4) = data1
        bytes(5) = data2
        bytes(6) = data3
        bytes(7) = data4
        bytes(8) = Crc8.ComputeCrc(170, bytes, 1, 7)
        bytes(9) = Crc8.ComputeCrc(0, bytes, 1, 7)
        _serial.EmuWrite(bytes)
    End Sub

    Private Sub ProcessPacket(packet As SSRequest)
        Select Case packet.Command
            Case 120
                SendResponse(Address, 0, Me.DeviceType, Me.DeviceModel / 256, Me.DeviceModel Mod 256, 0)
            Case 122
                If packet.Address > 0 Then

                End If
            Case 124

            Case Else
                Dim response As New SSResponse
                response.Result = 255
                RaiseEvent ProcessPacketRequest(packet, response)
                If response.Result < 250 Then

                End If
        End Select
    End Sub

End Class


