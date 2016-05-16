<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SerialTerminal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SerialTerminal))
        Me.gbConnect = New System.Windows.Forms.GroupBox()
        Me.cbAutoConnect = New System.Windows.Forms.CheckBox()
        Me.cbAutoReadBytes = New System.Windows.Forms.CheckBox()
        Me.bApply = New System.Windows.Forms.Button()
        Me.bConnect = New System.Windows.Forms.Button()
        Me.cbIsConnected = New System.Windows.Forms.CheckBox()
        Me.cbIsPresent = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tDeviceSpeed = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbDeviceParameters = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tDeviceParametersFormat = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tDeviceAddressFormat = New System.Windows.Forms.TextBox()
        Me.tDeviceAddress = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.tabsSend = New System.Windows.Forms.TabControl()
        Me.tpSendStrings = New System.Windows.Forms.TabPage()
        Me.input = New System.Windows.Forms.TextBox()
        Me.tpHexSend = New System.Windows.Forms.TabPage()
        Me.refreshTimer = New System.Windows.Forms.Timer(Me.components)
        Me.view = New Bwl.Hardware.Serial.Terminal()
        Me.gbConnect.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.tabsSend.SuspendLayout()
        Me.tpSendStrings.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbConnect
        '
        Me.gbConnect.Controls.Add(Me.cbAutoConnect)
        Me.gbConnect.Controls.Add(Me.cbAutoReadBytes)
        Me.gbConnect.Controls.Add(Me.bApply)
        Me.gbConnect.Controls.Add(Me.bConnect)
        Me.gbConnect.Controls.Add(Me.cbIsConnected)
        Me.gbConnect.Controls.Add(Me.cbIsPresent)
        Me.gbConnect.Controls.Add(Me.Label6)
        Me.gbConnect.Controls.Add(Me.tDeviceSpeed)
        Me.gbConnect.Controls.Add(Me.Label4)
        Me.gbConnect.Controls.Add(Me.tbDeviceParameters)
        Me.gbConnect.Controls.Add(Me.Label5)
        Me.gbConnect.Controls.Add(Me.tDeviceParametersFormat)
        Me.gbConnect.Controls.Add(Me.Label3)
        Me.gbConnect.Controls.Add(Me.Label2)
        Me.gbConnect.Controls.Add(Me.tDeviceAddressFormat)
        Me.gbConnect.Controls.Add(Me.tDeviceAddress)
        Me.gbConnect.Location = New System.Drawing.Point(6, 6)
        Me.gbConnect.Name = "gbConnect"
        Me.gbConnect.Size = New System.Drawing.Size(162, 362)
        Me.gbConnect.TabIndex = 24
        Me.gbConnect.TabStop = False
        Me.gbConnect.Text = "Подключение"
        '
        'cbAutoConnect
        '
        Me.cbAutoConnect.AutoSize = True
        Me.cbAutoConnect.Location = New System.Drawing.Point(6, 226)
        Me.cbAutoConnect.Name = "cbAutoConnect"
        Me.cbAutoConnect.Size = New System.Drawing.Size(88, 17)
        Me.cbAutoConnect.TabIndex = 34
        Me.cbAutoConnect.Text = "AutoConnect"
        Me.cbAutoConnect.UseVisualStyleBackColor = True
        '
        'cbAutoReadBytes
        '
        Me.cbAutoReadBytes.AutoSize = True
        Me.cbAutoReadBytes.Location = New System.Drawing.Point(6, 245)
        Me.cbAutoReadBytes.Name = "cbAutoReadBytes"
        Me.cbAutoReadBytes.Size = New System.Drawing.Size(100, 17)
        Me.cbAutoReadBytes.TabIndex = 35
        Me.cbAutoReadBytes.Text = "AutoReadBytes"
        Me.cbAutoReadBytes.UseVisualStyleBackColor = True
        '
        'bApply
        '
        Me.bApply.Location = New System.Drawing.Point(6, 300)
        Me.bApply.Name = "bApply"
        Me.bApply.Size = New System.Drawing.Size(149, 23)
        Me.bApply.TabIndex = 40
        Me.bApply.Text = "Применить"
        Me.bApply.UseVisualStyleBackColor = True
        '
        'bConnect
        '
        Me.bConnect.Location = New System.Drawing.Point(6, 328)
        Me.bConnect.Name = "bConnect"
        Me.bConnect.Size = New System.Drawing.Size(147, 23)
        Me.bConnect.TabIndex = 38
        Me.bConnect.Text = "Подключить\отключить"
        Me.bConnect.UseVisualStyleBackColor = True
        '
        'cbIsConnected
        '
        Me.cbIsConnected.AutoSize = True
        Me.cbIsConnected.Enabled = False
        Me.cbIsConnected.Location = New System.Drawing.Point(6, 264)
        Me.cbIsConnected.Name = "cbIsConnected"
        Me.cbIsConnected.Size = New System.Drawing.Size(86, 17)
        Me.cbIsConnected.TabIndex = 37
        Me.cbIsConnected.Text = "IsConnected"
        Me.cbIsConnected.UseVisualStyleBackColor = True
        '
        'cbIsPresent
        '
        Me.cbIsPresent.AutoSize = True
        Me.cbIsPresent.Enabled = False
        Me.cbIsPresent.Location = New System.Drawing.Point(6, 283)
        Me.cbIsPresent.Name = "cbIsPresent"
        Me.cbIsPresent.Size = New System.Drawing.Size(70, 17)
        Me.cbIsPresent.TabIndex = 36
        Me.cbIsPresent.Text = "IsPresent"
        Me.cbIsPresent.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 181)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 13)
        Me.Label6.TabIndex = 33
        Me.Label6.Text = "DeviceSpeed"
        '
        'tDeviceSpeed
        '
        Me.tDeviceSpeed.Location = New System.Drawing.Point(6, 198)
        Me.tDeviceSpeed.Name = "tDeviceSpeed"
        Me.tDeviceSpeed.Size = New System.Drawing.Size(147, 20)
        Me.tDeviceSpeed.TabIndex = 32
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 99)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 13)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "DeviceParameters"
        '
        'tbDeviceParameters
        '
        Me.tbDeviceParameters.Location = New System.Drawing.Point(6, 116)
        Me.tbDeviceParameters.Name = "tbDeviceParameters"
        Me.tbDeviceParameters.Size = New System.Drawing.Size(149, 20)
        Me.tbDeviceParameters.TabIndex = 28
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 58)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(126, 13)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "DeviceParametersFormat"
        '
        'tDeviceParametersFormat
        '
        Me.tDeviceParametersFormat.Enabled = False
        Me.tDeviceParametersFormat.Location = New System.Drawing.Point(6, 75)
        Me.tDeviceParametersFormat.Name = "tDeviceParametersFormat"
        Me.tDeviceParametersFormat.Size = New System.Drawing.Size(149, 20)
        Me.tDeviceParametersFormat.TabIndex = 29
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(111, 13)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "DeviceAddressFormat"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 140)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 13)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "DeviceAddress"
        '
        'tDeviceAddressFormat
        '
        Me.tDeviceAddressFormat.Enabled = False
        Me.tDeviceAddressFormat.Location = New System.Drawing.Point(6, 34)
        Me.tDeviceAddressFormat.Name = "tDeviceAddressFormat"
        Me.tDeviceAddressFormat.Size = New System.Drawing.Size(149, 20)
        Me.tDeviceAddressFormat.TabIndex = 25
        '
        'tDeviceAddress
        '
        Me.tDeviceAddress.Location = New System.Drawing.Point(6, 157)
        Me.tDeviceAddress.Name = "tDeviceAddress"
        Me.tDeviceAddress.Size = New System.Drawing.Size(147, 20)
        Me.tDeviceAddress.TabIndex = 24
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(644, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(185, 402)
        Me.TabControl1.TabIndex = 25
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.gbConnect)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(177, 376)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Подключение"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(177, 376)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Другое"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'tabsSend
        '
        Me.tabsSend.Controls.Add(Me.tpSendStrings)
        Me.tabsSend.Controls.Add(Me.tpHexSend)
        Me.tabsSend.Location = New System.Drawing.Point(6, 318)
        Me.tabsSend.Name = "tabsSend"
        Me.tabsSend.SelectedIndex = 0
        Me.tabsSend.Size = New System.Drawing.Size(626, 87)
        Me.tabsSend.TabIndex = 27
        '
        'tpSendStrings
        '
        Me.tpSendStrings.Controls.Add(Me.input)
        Me.tpSendStrings.Location = New System.Drawing.Point(4, 22)
        Me.tpSendStrings.Name = "tpSendStrings"
        Me.tpSendStrings.Padding = New System.Windows.Forms.Padding(3)
        Me.tpSendStrings.Size = New System.Drawing.Size(618, 61)
        Me.tpSendStrings.TabIndex = 0
        Me.tpSendStrings.Text = "Отправка строка"
        Me.tpSendStrings.UseVisualStyleBackColor = True
        '
        'input
        '
        Me.input.Location = New System.Drawing.Point(6, 6)
        Me.input.Name = "input"
        Me.input.Size = New System.Drawing.Size(606, 20)
        Me.input.TabIndex = 0
        '
        'tpHexSend
        '
        Me.tpHexSend.Location = New System.Drawing.Point(4, 22)
        Me.tpHexSend.Name = "tpHexSend"
        Me.tpHexSend.Padding = New System.Windows.Forms.Padding(3)
        Me.tpHexSend.Size = New System.Drawing.Size(618, 61)
        Me.tpHexSend.TabIndex = 1
        Me.tpHexSend.Text = "Отправка HEX"
        Me.tpHexSend.UseVisualStyleBackColor = True
        '
        'refreshTimer
        '
        Me.refreshTimer.Enabled = True
        Me.refreshTimer.Interval = 500
        '
        'view
        '
        Me.view.Location = New System.Drawing.Point(6, 6)
        Me.view.Name = "view"
        Me.view.Size = New System.Drawing.Size(626, 310)
        Me.view.TabIndex = 26
        '
        'SerialTerminal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(817, 407)
        Me.Controls.Add(Me.tabsSend)
        Me.Controls.Add(Me.view)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "SerialTerminal"
        Me.Text = "Терминал"
        Me.gbConnect.ResumeLayout(False)
        Me.gbConnect.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.tabsSend.ResumeLayout(False)
        Me.tpSendStrings.ResumeLayout(False)
        Me.tpSendStrings.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbConnect As System.Windows.Forms.GroupBox
    Friend WithEvents cbAutoConnect As System.Windows.Forms.CheckBox
    Friend WithEvents cbAutoReadBytes As System.Windows.Forms.CheckBox
    Friend WithEvents bApply As System.Windows.Forms.Button
    Friend WithEvents bConnect As System.Windows.Forms.Button
    Friend WithEvents cbIsConnected As System.Windows.Forms.CheckBox
    Friend WithEvents cbIsPresent As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tDeviceSpeed As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbDeviceParameters As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tDeviceParametersFormat As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tDeviceAddressFormat As System.Windows.Forms.TextBox
    Friend WithEvents tDeviceAddress As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents view As bwl.Hardware.Serial.Terminal
    Friend WithEvents tabsSend As System.Windows.Forms.TabControl
    Friend WithEvents tpSendStrings As System.Windows.Forms.TabPage
    Friend WithEvents tpHexSend As System.Windows.Forms.TabPage
    Friend WithEvents input As System.Windows.Forms.TextBox
    Friend WithEvents refreshTimer As System.Windows.Forms.Timer

End Class
