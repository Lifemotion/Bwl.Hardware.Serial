Imports System.Windows.Forms

Public Class ByteMonitor

    Public Event BitChanged(bitIdx As Integer, bitValue As Integer)
    Public Event ByteChanged(byteValue As Integer)

    Private _byte As Byte

    Public Sub New()
        InitializeComponent()
        AddHandler BitChanged, AddressOf BitChanged_Handler
        AddHandler ByteChanged, AddressOf ByteChanged_Handler
        ByteTextBox.Text = "0"
        Me.Refresh()
    End Sub

    Public Property Value As Byte
        Get
            Return _byte
        End Get
        Set(value As Byte)
            _byte = value
            RaiseEvent ByteChanged(_byte)
        End Set
    End Property

    Public Property Bit(bitIdx As Integer) As Integer
        Get
            Return If((_byte And (1 << bitIdx)) = 0, 0, 1)
        End Get
        Set(value As Integer)
            value = If(value <> 0, 1, 0)
            Dim bitmask = 1 << bitIdx
            _byte = (_byte And Not bitmask) Or If(value <> 0, bitmask, 0)
            RaiseEvent BitChanged(bitIdx, value)
            RaiseEvent ByteChanged(_byte)
        End Set
    End Property

    Private Sub BitChanged_Handler(bitIdx As Integer, bitValue As Integer)
        Select Case bitIdx
            Case 0
                bit0.Checked = (bitValue = 1)
            Case 1
                bit1.Checked = (bitValue = 1)
            Case 2
                bit2.Checked = (bitValue = 1)
            Case 3
                bit3.Checked = (bitValue = 1)
            Case 4
                bit4.Checked = (bitValue = 1)
            Case 5
                bit5.Checked = (bitValue = 1)
            Case 6
                bit6.Checked = (bitValue = 1)
            Case 7
                bit7.Checked = (bitValue = 1)
        End Select
    End Sub

    Private Sub ByteChanged_Handler(byteValue As Integer)
        For i = 0 To 7
            BitChanged_Handler(i, Bit(i))
        Next
        ByteTextBox.Text = _byte.ToString()
    End Sub

    Private Sub bit0_Click(sender As Object, e As EventArgs) Handles bit0.Click
        Dim bitValue = Not bit0.Checked
        Bit(0) = bitValue
        bit0.Checked = bitValue
    End Sub

    Private Sub bit1_Click(sender As Object, e As EventArgs) Handles bit1.Click
        Dim bitValue = Not bit1.Checked
        Bit(1) = bitValue
        bit1.Checked = bitValue
    End Sub

    Private Sub bit2_Click(sender As Object, e As EventArgs) Handles bit2.Click
        Dim bitValue = Not bit2.Checked
        Bit(2) = bitValue
        bit2.Checked = bitValue
    End Sub

    Private Sub bit3_Click(sender As Object, e As EventArgs) Handles bit3.Click
        Dim bitValue = Not bit3.Checked
        Bit(3) = bitValue
        bit3.Checked = bitValue
    End Sub

    Private Sub bit4_Click(sender As Object, e As EventArgs) Handles bit4.Click
        Dim bitValue = Not bit4.Checked
        Bit(4) = bitValue
        bit4.Checked = bitValue
    End Sub

    Private Sub bit5_Click(sender As Object, e As EventArgs) Handles bit5.Click
        Dim bitValue = Not bit5.Checked
        Bit(5) = bitValue
        bit5.Checked = bitValue
    End Sub

    Private Sub bit6_Click(sender As Object, e As EventArgs) Handles bit6.Click
        Dim bitValue = Not bit6.Checked
        Bit(6) = bitValue
        bit6.Checked = bitValue
    End Sub

    Private Sub bit7_Click(sender As Object, e As EventArgs) Handles bit7.Click
        Dim bitValue = Not bit7.Checked
        Bit(7) = bitValue
        bit7.Checked = bitValue
    End Sub

    Private Sub ByteTextBox_TextChanged(sender As Object, e As EventArgs) Handles ByteTextBox.TextChanged
        Dim savedValue = Value
        Try
            Value = Convert.ToByte(ByteTextBox.Text)
        Catch
            If ByteTextBox.TextLength <> 0 Then
                Value = savedValue
            Else
                Value = 0
            End If
        End Try
    End Sub

    Private Sub ByteTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ByteTextBox.KeyPress
        If e.KeyChar <> CType(ChrW(Keys.Back), Char) AndAlso Not Char.IsDigit(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub ByteMonitor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
