Imports System.Windows.Forms

Public Class FirmwareUploader
    Private _sserial As SimplSerialBus
    Private _logger As Logger

    Public ReadOnly Property SSerial As SimplSerialBus
        Get
            Return _sserial
        End Get
    End Property

    Public Sub New(sserial As SimplSerialBus, logger As Logger)
        _sserial = sserial
        _logger = logger
    End Sub

    Public Sub New(sserial As SimplSerialBus)
        _sserial = sserial
        _logger = New Logger
    End Sub

    Public Property SpmSize As Integer
    Public Property ProgmemSize As Integer
    Public Property Signature As String = ""

    Public Shared Function SelectFirmwareFile() As String
        Dim fd As New OpenFileDialog()
        fd.Filter = "HEX|*.hex|BIN|*.bin"
        If fd.ShowDialog = Windows.Forms.DialogResult.OK Then Return fd.FileName
        Return ""
    End Function

    Public Sub EraseAll(address As Integer)
        Dim spm = SpmSize
        Dim size = ProgmemSize - 1024 * 4
        For i = 0 To size - 1 Step spm
            Dim page As Integer = Math.Floor(i \ spm)
            _logger.AddInformation("Erase: " + i.ToString + "\" + size.ToString)
            Application.DoEvents()
            ErasePage(address, page)
        Next
    End Sub

    Public Shared Function LoadFirmwareFromFile(file As String) As Byte()
        Dim bin As Byte()
        Dim ext = IO.Path.GetExtension(file).ToLower
        Select Case ext
            Case ".hex"
                Dim str = IO.File.ReadAllLines(file)
                Dim converter = New HexToBinConverter()
                bin = converter.Hex2Bin(str)
            Case ".bin"
                bin = IO.File.ReadAllBytes(file)
            Case Else
                Throw New Exception("Extension not supported. Use HEX or BIN.")
        End Select
        Return bin
    End Function

    Public Sub EraseAndFlashAll(address As Integer, bin As Byte())
        EraseAll(address)
        FlashAll(address, bin)
    End Sub

    Public Sub FlashAll(address As Integer, bin As Byte())
        Dim binLength As Integer
        binLength = bin.Length
        Dim spm = SpmSize
        Dim size = ProgmemSize - 1024 * 4
        If spm < 64 Then Throw New Exception("SPM = 0")

        Dim binsize As Integer = Math.Ceiling(bin.Length / spm) * spm
        ReDim Preserve bin(binsize - 1) '

        For i = 0 To bin.Length - 1 Step spm
            Dim page As Integer = Math.Floor(i \ spm)
            _logger.AddInformation("Program: " + i.ToString + "\" + binLength.ToString)
            Application.DoEvents()
            EraseFillWritePage(address, page, bin, i, spm)
        Next
    End Sub

    Public Sub RequestBootInfo(address As Integer)
        Dim info = _sserial.Request(New SSRequest(address, 100, {}))
        If info.ResponseState = ResponseState.ok Then
            Dim spm = info.Data(16) * 256 + info.Data(17)
            Dim pgmsize = info.Data(18) * 256 * 256 + info.Data(19) * 256 + info.Data(10)
            Dim sign = info.Data(11) * 256 * 256 + info.Data(13) * 256 + info.Data(5)
            SpmSize = spm
            ProgmemSize = Math.Floor(pgmsize / SpmSize) * SpmSize
            Signature = Hex(sign)
        Else
            Throw New Exception(info.ResponseState.ToString)
        End If
    End Sub

    Public Sub ErasePage(address As Integer, page As Integer)
        Dim page0 = (page >> 8) And 255
        Dim page1 = page Mod 256
        Dim test = _sserial.Request(New SSRequest(address, 102, {page0, page1, 0}), 50)
        If test.ResponseState <> ResponseState.ok Then Throw New Exception(test.ResponseState.ToString)
        If test.Result <> 103 Then Throw New Exception(test.ResponseState.ToString)
        _logger.AddDebug("ErasePage")
    End Sub

    Public Sub FillPageBuffer(address As Integer, page As Integer, offset As Integer, bytes As Byte())
        If bytes.Length <> 8 Then Throw New Exception("FillPageBuffer <> 8")
        Dim page0 = (page >> 8) And 255
        Dim page1 = page Mod 256
        Dim offset0 = (offset >> 8) And 255
        Dim offset1 = offset Mod 256
        Dim test = _sserial.Request(New SSRequest(address, 104, {page0, page1, offset0, offset1, bytes(0), bytes(1), bytes(2), bytes(3), bytes(4), bytes(5), bytes(6), bytes(7)}), 50)
        If test.ResponseState <> ResponseState.ok Then Throw New Exception(test.ResponseState.ToString)
        If test.Result <> 105 Then Throw New Exception(test.ResponseState.ToString)

        _logger.AddDebug("FillPage")
    End Sub

    Public Sub WritePage(address As Integer, page As Integer)
        Dim page0 = (page >> 8) And 255
        Dim page1 = page Mod 256
        Dim test = _sserial.Request(New SSRequest(address, 106, {page0, page1}), 50)
        If test.ResponseState <> ResponseState.ok Then Throw New Exception(test.ResponseState.ToString)
        If test.Result <> 107 Then Throw New Exception(test.ResponseState.ToString)
    End Sub

    Public Sub EraseFillWritePage(address As Integer, page As Integer, data As Byte(), offset As Integer, size As Integer)
        If size <> 128 And size <> 64 And size <> 256 Then Throw New Exception("EraseFillWritePage:  size <> 128, size <> 64")
        If data.Length < offset + size Then Throw New Exception("EraseFillWritePage: Data not enough")

        Dim buffer(size - 1) As Integer
        For i = 0 To buffer.Length - 1
            buffer(i) = data(offset + i)
        Next

        ErasePage(address, page)
        For i = 0 To size - 1 Step 8
            FillPageBuffer(address, page, i, {buffer(i), buffer(i + 1), buffer(i + 2), buffer(i + 3), buffer(i + 4), buffer(i + 5), buffer(i + 6), buffer(i + 7)})
        Next
        WritePage(address, page)
    End Sub

End Class
