<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SerialEmulatorWindow
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
        Me.LogWriterList1 = New bwl.Logs.Basic.LogWriterList()
        Me.lbState = New System.Windows.Forms.ListBox()
        Me.Present = New System.Windows.Forms.CheckBox()
        Me.CanConnect = New System.Windows.Forms.CheckBox()
        Me.Connected = New System.Windows.Forms.CheckBox()
        Me.tbReceived = New System.Windows.Forms.TextBox()
        Me.tbSent = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'LogWriterList1
        '
        Me.LogWriterList1.FilterText = ""
        Me.LogWriterList1.Location = New System.Drawing.Point(0, 178)
        Me.LogWriterList1.LogEnabled = True
        Me.LogWriterList1.Margin = New System.Windows.Forms.Padding(0)
        Me.LogWriterList1.Name = "LogWriterList1"
        Me.LogWriterList1.ShowDebug = False
        Me.LogWriterList1.ShowErrors = True
        Me.LogWriterList1.ShowInformation = True
        Me.LogWriterList1.ShowMessages = True
        Me.LogWriterList1.ShowWarnings = True
        Me.LogWriterList1.Size = New System.Drawing.Size(642, 231)
        Me.LogWriterList1.TabIndex = 0
        '
        'lbState
        '
        Me.lbState.FormattingEnabled = True
        Me.lbState.Location = New System.Drawing.Point(645, 2)
        Me.lbState.Name = "lbState"
        Me.lbState.Size = New System.Drawing.Size(248, 342)
        Me.lbState.TabIndex = 1
        '
        'Present
        '
        Me.Present.AutoSize = True
        Me.Present.Checked = True
        Me.Present.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Present.Location = New System.Drawing.Point(645, 349)
        Me.Present.Name = "Present"
        Me.Present.Size = New System.Drawing.Size(77, 17)
        Me.Present.TabIndex = 2
        Me.Present.Text = "В наличии"
        Me.Present.UseVisualStyleBackColor = True
        '
        'CanConnect
        '
        Me.CanConnect.AutoSize = True
        Me.CanConnect.Checked = True
        Me.CanConnect.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CanConnect.Location = New System.Drawing.Point(645, 370)
        Me.CanConnect.Name = "CanConnect"
        Me.CanConnect.Size = New System.Drawing.Size(124, 17)
        Me.CanConnect.TabIndex = 3
        Me.CanConnect.Text = "Можно подключить"
        Me.CanConnect.UseVisualStyleBackColor = True
        '
        'Connected
        '
        Me.Connected.AutoSize = True
        Me.Connected.Enabled = False
        Me.Connected.Location = New System.Drawing.Point(645, 392)
        Me.Connected.Name = "Connected"
        Me.Connected.Size = New System.Drawing.Size(89, 17)
        Me.Connected.TabIndex = 4
        Me.Connected.Text = "Подключено"
        Me.Connected.UseVisualStyleBackColor = True
        '
        'tbReceived
        '
        Me.tbReceived.Enabled = False
        Me.tbReceived.Location = New System.Drawing.Point(0, 2)
        Me.tbReceived.Multiline = True
        Me.tbReceived.Name = "tbReceived"
        Me.tbReceived.Size = New System.Drawing.Size(640, 84)
        Me.tbReceived.TabIndex = 5
        '
        'tbSent
        '
        Me.tbSent.Location = New System.Drawing.Point(0, 91)
        Me.tbSent.Multiline = True
        Me.tbSent.Name = "tbSent"
        Me.tbSent.Size = New System.Drawing.Size(640, 84)
        Me.tbSent.TabIndex = 6
        '
        'Window
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(898, 412)
        Me.Controls.Add(Me.tbSent)
        Me.Controls.Add(Me.tbReceived)
        Me.Controls.Add(Me.Connected)
        Me.Controls.Add(Me.CanConnect)
        Me.Controls.Add(Me.Present)
        Me.Controls.Add(Me.lbState)
        Me.Controls.Add(Me.LogWriterList1)
        Me.Name = "Window"
        Me.Text = "Тестовое последовательное устройство"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LogWriterList1 As LogWriterList
    Friend WithEvents lbState As System.Windows.Forms.ListBox
    Friend WithEvents Present As System.Windows.Forms.CheckBox
    Friend WithEvents CanConnect As System.Windows.Forms.CheckBox
    Friend WithEvents Connected As System.Windows.Forms.CheckBox
    Friend WithEvents tbReceived As System.Windows.Forms.TextBox
    Friend WithEvents tbSent As System.Windows.Forms.TextBox
End Class
