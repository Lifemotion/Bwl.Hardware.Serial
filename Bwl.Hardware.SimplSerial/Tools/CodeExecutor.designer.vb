<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CodeExecutor
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.sourceTextbox = New System.Windows.Forms.TextBox()
        Me.bRun = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'sourceTextbox
        '
        Me.sourceTextbox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sourceTextbox.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.sourceTextbox.Location = New System.Drawing.Point(3, 3)
        Me.sourceTextbox.Multiline = True
        Me.sourceTextbox.Name = "sourceTextbox"
        Me.sourceTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.sourceTextbox.Size = New System.Drawing.Size(533, 312)
        Me.sourceTextbox.TabIndex = 10
        '
        'bRun
        '
        Me.bRun.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bRun.Location = New System.Drawing.Point(461, 321)
        Me.bRun.Name = "bRun"
        Me.bRun.Size = New System.Drawing.Size(75, 23)
        Me.bRun.TabIndex = 9
        Me.bRun.Text = "Запуск"
        Me.bRun.UseVisualStyleBackColor = True
        '
        'CodeExecutor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.sourceTextbox)
        Me.Controls.Add(Me.bRun)
        Me.Name = "CodeExecutor"
        Me.Size = New System.Drawing.Size(540, 350)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents sourceTextbox As System.Windows.Forms.TextBox
    Friend WithEvents bRun As System.Windows.Forms.Button

End Class
