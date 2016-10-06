<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VirtualTwoSwitchVisualiser
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
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
        Me.components = New System.ComponentModel.Container()
        Me.Switch1 = New System.Windows.Forms.CheckBox()
        Me.Switch2 = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lDebug = New System.Windows.Forms.ListBox()
        Me.refreshTimer = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CheckBox1
        '
        Me.Switch1.AutoSize = True
        Me.Switch1.Location = New System.Drawing.Point(12, 12)
        Me.Switch1.Name = "CheckBox1"
        Me.Switch1.Size = New System.Drawing.Size(104, 17)
        Me.Switch1.TabIndex = 0
        Me.Switch1.Text = "Выключатель 1"
        Me.Switch1.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.Switch2.AutoSize = True
        Me.Switch2.Location = New System.Drawing.Point(168, 12)
        Me.Switch2.Name = "CheckBox2"
        Me.Switch2.Size = New System.Drawing.Size(104, 17)
        Me.Switch2.TabIndex = 1
        Me.Switch2.Text = "Выключатель 2"
        Me.Switch2.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lDebug)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 35)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(260, 163)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Отладка"
        '
        'lDebug
        '
        Me.lDebug.BackColor = System.Drawing.SystemColors.Control
        Me.lDebug.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lDebug.FormattingEnabled = True
        Me.lDebug.Location = New System.Drawing.Point(6, 19)
        Me.lDebug.Name = "lDebug"
        Me.lDebug.Size = New System.Drawing.Size(128, 130)
        Me.lDebug.TabIndex = 3
        '
        'refresh
        '
        '
        'VirtualTwoSwitchVisualiser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 210)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Switch2)
        Me.Controls.Add(Me.Switch1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "VirtualTwoSwitchVisualiser"
        Me.Text = "VirtualTwoSwitchVisualiser"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Switch1 As System.Windows.Forms.CheckBox
    Friend WithEvents Switch2 As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lDebug As System.Windows.Forms.ListBox
    Friend WithEvents refreshTimer As System.Windows.Forms.Timer
End Class
