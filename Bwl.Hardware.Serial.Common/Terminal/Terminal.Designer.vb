<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Terminal
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
        Me.rtb = New System.Windows.Forms.RichTextBox()
        Me.cbReturns = New System.Windows.Forms.CheckBox()
        Me.cbHex = New System.Windows.Forms.CheckBox()
        Me.cbDecimal = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'rtb
        '
        Me.rtb.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtb.BackColor = System.Drawing.Color.White
        Me.rtb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rtb.DetectUrls = False
        Me.rtb.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtb.Location = New System.Drawing.Point(3, 3)
        Me.rtb.Name = "rtb"
        Me.rtb.ReadOnly = True
        Me.rtb.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.rtb.ShortcutsEnabled = False
        Me.rtb.Size = New System.Drawing.Size(609, 161)
        Me.rtb.TabIndex = 27
        Me.rtb.Text = ""
        '
        'cbReturns
        '
        Me.cbReturns.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbReturns.AutoSize = True
        Me.cbReturns.Enabled = False
        Me.cbReturns.Location = New System.Drawing.Point(165, 164)
        Me.cbReturns.Name = "cbReturns"
        Me.cbReturns.Size = New System.Drawing.Size(102, 17)
        Me.cbReturns.TabIndex = 28
        Me.cbReturns.Text = "Перенос строк"
        Me.cbReturns.UseVisualStyleBackColor = True
        '
        'cbHex
        '
        Me.cbHex.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbHex.AutoSize = True
        Me.cbHex.Checked = True
        Me.cbHex.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbHex.Enabled = False
        Me.cbHex.Location = New System.Drawing.Point(3, 164)
        Me.cbHex.Name = "cbHex"
        Me.cbHex.Size = New System.Drawing.Size(151, 17)
        Me.cbHex.TabIndex = 29
        Me.cbHex.Text = "Шестнадцатеричный вид"
        Me.cbHex.UseVisualStyleBackColor = True
        '
        'cbDecimal
        '
        Me.cbDecimal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbDecimal.AutoSize = True
        Me.cbDecimal.Location = New System.Drawing.Point(273, 164)
        Me.cbDecimal.Name = "cbDecimal"
        Me.cbDecimal.Size = New System.Drawing.Size(139, 17)
        Me.cbDecimal.TabIndex = 30
        Me.cbDecimal.Text = "Десятичные значения"
        Me.cbDecimal.UseVisualStyleBackColor = True
        '
        'Terminal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cbDecimal)
        Me.Controls.Add(Me.cbHex)
        Me.Controls.Add(Me.cbReturns)
        Me.Controls.Add(Me.rtb)
        Me.Name = "Terminal"
        Me.Size = New System.Drawing.Size(615, 184)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rtb As System.Windows.Forms.RichTextBox
    Friend WithEvents cbReturns As System.Windows.Forms.CheckBox
    Friend WithEvents cbHex As System.Windows.Forms.CheckBox
    Friend WithEvents cbDecimal As System.Windows.Forms.CheckBox

End Class
