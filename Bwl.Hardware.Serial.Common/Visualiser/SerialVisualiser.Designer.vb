<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SerialVisualiser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SerialVisualiser))
        Me.lbState = New System.Windows.Forms.ListBox()
        Me.LogWriterList1 = New LogWriterList()
        Me.refreshState = New System.Windows.Forms.Timer(Me.components)
        Me.view = New bwl.Hardware.Serial.Terminal()
        Me.SuspendLayout()
        '
        'lbState
        '
        Me.lbState.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbState.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbState.FormattingEnabled = True
        Me.lbState.ItemHeight = 11
        Me.lbState.Location = New System.Drawing.Point(0, 4)
        Me.lbState.Name = "lbState"
        Me.lbState.Size = New System.Drawing.Size(201, 246)
        Me.lbState.TabIndex = 0
        '
        'LogWriterList1
        '
        Me.LogWriterList1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LogWriterList1.FilterText = ""
        Me.LogWriterList1.Location = New System.Drawing.Point(0, 257)
        Me.LogWriterList1.LogEnabled = True
        Me.LogWriterList1.Margin = New System.Windows.Forms.Padding(0)
        Me.LogWriterList1.Name = "LogWriterList1"
        Me.LogWriterList1.ShowDebug = False
        Me.LogWriterList1.ShowErrors = True
        Me.LogWriterList1.ShowInformation = True
        Me.LogWriterList1.ShowMessages = True
        Me.LogWriterList1.ShowWarnings = True
        Me.LogWriterList1.Size = New System.Drawing.Size(903, 216)
        Me.LogWriterList1.TabIndex = 2
        '
        'refreshState
        '
        Me.refreshState.Enabled = True
        Me.refreshState.Interval = 300
        '
        'view
        '
        Me.view.Location = New System.Drawing.Point(207, 4)
        Me.view.Name = "view"
        Me.view.Size = New System.Drawing.Size(696, 250)
        Me.view.TabIndex = 27
        '
        'SerialVisualiser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(905, 476)
        Me.Controls.Add(Me.view)
        Me.Controls.Add(Me.LogWriterList1)
        Me.Controls.Add(Me.lbState)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SerialVisualiser"
        Me.Text = "Визуализатор ISerialDevice"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbState As System.Windows.Forms.ListBox
    Friend WithEvents LogWriterList1 As LogWriterList
    Friend WithEvents refreshState As System.Windows.Forms.Timer
    Friend WithEvents view As bwl.Hardware.Serial.Terminal
End Class
