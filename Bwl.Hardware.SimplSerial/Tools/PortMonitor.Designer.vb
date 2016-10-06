<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PortMonitor
    Inherits System.Windows.Forms.UserControl

    'Пользовательский элемент управления (UserControl) переопределяет метод Dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.output = New Bwl.Hardware.SimplSerial.ByteMonitor()
        Me.direction = New Bwl.Hardware.SimplSerial.ByteMonitor()
        Me.input = New Bwl.Hardware.SimplSerial.ByteMonitor()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'output
        '
        Me.output.Location = New System.Drawing.Point(28, 126)
        Me.output.MaximumSize = New System.Drawing.Size(138, 59)
        Me.output.MinimumSize = New System.Drawing.Size(138, 59)
        Me.output.Name = "output"
        Me.output.Size = New System.Drawing.Size(138, 59)
        Me.output.TabIndex = 40
        Me.output.Value = CType(0, Byte)
        '
        'direction
        '
        Me.direction.Location = New System.Drawing.Point(28, 64)
        Me.direction.MaximumSize = New System.Drawing.Size(138, 59)
        Me.direction.MinimumSize = New System.Drawing.Size(138, 59)
        Me.direction.Name = "direction"
        Me.direction.Size = New System.Drawing.Size(138, 59)
        Me.direction.TabIndex = 39
        Me.direction.Value = CType(0, Byte)
        '
        'input
        '
        Me.input.Enabled = False
        Me.input.Location = New System.Drawing.Point(28, 2)
        Me.input.MaximumSize = New System.Drawing.Size(138, 59)
        Me.input.MinimumSize = New System.Drawing.Size(138, 59)
        Me.input.Name = "input"
        Me.input.Size = New System.Drawing.Size(138, 59)
        Me.input.TabIndex = 38
        Me.input.Value = CType(0, Byte)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(19, 13)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "In:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 103)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 13)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "Dir:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(2, 164)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 13)
        Me.Label3.TabIndex = 43
        Me.Label3.Text = "Out:"
        '
        'PortMonitor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.output)
        Me.Controls.Add(Me.direction)
        Me.Controls.Add(Me.input)
        Me.Name = "PortMonitor"
        Me.Size = New System.Drawing.Size(166, 187)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents output As Bwl.Hardware.SimplSerial.ByteMonitor
    Friend WithEvents direction As Bwl.Hardware.SimplSerial.ByteMonitor
    Friend WithEvents input As Bwl.Hardware.SimplSerial.ByteMonitor
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label

End Class
