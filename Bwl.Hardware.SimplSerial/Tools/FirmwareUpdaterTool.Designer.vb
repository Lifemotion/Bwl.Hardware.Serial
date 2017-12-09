<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FirmwareUpdaterTool
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FirmwareUpdaterTool))
        Me.tbFindBootName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbFindMainName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbFindWorkAddress = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.tbUpdateFile = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tbUpdateName = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tbConnectedDate = New System.Windows.Forms.TextBox()
        Me.bRequestInfo = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tbConnectedName = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tbConnectedAddress = New System.Windows.Forms.TextBox()
        Me.tbConnectedGuid = New System.Windows.Forms.TextBox()
        Me.bUpdate = New System.Windows.Forms.Button()
        Me.DatagridLogWriter1 = New Bwl.Hardware.SimplSerial.DatagridLogWriter()
        Me.bFindDevice = New System.Windows.Forms.Button()
        Me.SerialSelector1 = New Bwl.Hardware.SimplSerial.SerialSelector()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.bSimplSerialTool = New System.Windows.Forms.Button()
        Me.tbClientAddress = New System.Windows.Forms.TextBox()
        Me.bConnectToClient = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbFindBootName
        '
        Me.tbFindBootName.Location = New System.Drawing.Point(119, 19)
        Me.tbFindBootName.Name = "tbFindBootName"
        Me.tbFindBootName.ReadOnly = True
        Me.tbFindBootName.Size = New System.Drawing.Size(148, 20)
        Me.tbFindBootName.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Имя загрузчика:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Имя основного ПО:"
        '
        'tbFindMainName
        '
        Me.tbFindMainName.Location = New System.Drawing.Point(119, 45)
        Me.tbFindMainName.Name = "tbFindMainName"
        Me.tbFindMainName.ReadOnly = True
        Me.tbFindMainName.Size = New System.Drawing.Size(148, 20)
        Me.tbFindMainName.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Рабочий адрес:"
        '
        'tbFindWorkAddress
        '
        Me.tbFindWorkAddress.Location = New System.Drawing.Point(119, 72)
        Me.tbFindWorkAddress.Name = "tbFindWorkAddress"
        Me.tbFindWorkAddress.ReadOnly = True
        Me.tbFindWorkAddress.Size = New System.Drawing.Size(148, 20)
        Me.tbFindWorkAddress.TabIndex = 4
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.tbFindBootName)
        Me.GroupBox1.Controls.Add(Me.tbFindWorkAddress)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.tbFindMainName)
        Me.GroupBox1.Location = New System.Drawing.Point(121, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(280, 103)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Параметры поиска устройства"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.tbUpdateFile)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.tbUpdateName)
        Me.GroupBox2.Location = New System.Drawing.Point(407, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(325, 103)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Файл обновления"
        '
        'tbUpdateFile
        '
        Me.tbUpdateFile.Location = New System.Drawing.Point(119, 19)
        Me.tbUpdateFile.Name = "tbUpdateFile"
        Me.tbUpdateFile.ReadOnly = True
        Me.tbUpdateFile.Size = New System.Drawing.Size(200, 20)
        Me.tbUpdateFile.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Файл:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(107, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Имя основного ПО:"
        '
        'tbUpdateName
        '
        Me.tbUpdateName.Location = New System.Drawing.Point(119, 45)
        Me.tbUpdateName.Name = "tbUpdateName"
        Me.tbUpdateName.ReadOnly = True
        Me.tbUpdateName.Size = New System.Drawing.Size(200, 20)
        Me.tbUpdateName.TabIndex = 2
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.tbConnectedDate)
        Me.GroupBox3.Controls.Add(Me.bRequestInfo)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.tbConnectedName)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.tbConnectedAddress)
        Me.GroupBox3.Controls.Add(Me.tbConnectedGuid)
        Me.GroupBox3.Location = New System.Drawing.Point(120, 121)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(400, 130)
        Me.GroupBox3.TabIndex = 8
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Обновляемое устройство"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(205, 77)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(36, 13)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "Дата:"
        '
        'tbConnectedDate
        '
        Me.tbConnectedDate.Location = New System.Drawing.Point(247, 71)
        Me.tbConnectedDate.Name = "tbConnectedDate"
        Me.tbConnectedDate.ReadOnly = True
        Me.tbConnectedDate.Size = New System.Drawing.Size(147, 20)
        Me.tbConnectedDate.TabIndex = 11
        '
        'bRequestInfo
        '
        Me.bRequestInfo.Location = New System.Drawing.Point(119, 98)
        Me.bRequestInfo.Name = "bRequestInfo"
        Me.bRequestInfo.Size = New System.Drawing.Size(275, 23)
        Me.bRequestInfo.TabIndex = 10
        Me.bRequestInfo.Text = "Запросить информацию"
        Me.bRequestInfo.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Идентификатор:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 75)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 13)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Рабочий адрес:"
        '
        'tbConnectedName
        '
        Me.tbConnectedName.Location = New System.Drawing.Point(119, 45)
        Me.tbConnectedName.Name = "tbConnectedName"
        Me.tbConnectedName.ReadOnly = True
        Me.tbConnectedName.Size = New System.Drawing.Size(275, 20)
        Me.tbConnectedName.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 52)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 13)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Имя:"
        '
        'tbConnectedAddress
        '
        Me.tbConnectedAddress.Location = New System.Drawing.Point(119, 71)
        Me.tbConnectedAddress.Name = "tbConnectedAddress"
        Me.tbConnectedAddress.ReadOnly = True
        Me.tbConnectedAddress.Size = New System.Drawing.Size(76, 20)
        Me.tbConnectedAddress.TabIndex = 2
        '
        'tbConnectedGuid
        '
        Me.tbConnectedGuid.Location = New System.Drawing.Point(119, 19)
        Me.tbConnectedGuid.Name = "tbConnectedGuid"
        Me.tbConnectedGuid.ReadOnly = True
        Me.tbConnectedGuid.Size = New System.Drawing.Size(275, 20)
        Me.tbConnectedGuid.TabIndex = 4
        '
        'bUpdate
        '
        Me.bUpdate.Location = New System.Drawing.Point(526, 170)
        Me.bUpdate.Name = "bUpdate"
        Me.bUpdate.Size = New System.Drawing.Size(206, 39)
        Me.bUpdate.TabIndex = 9
        Me.bUpdate.Text = "Найти и обновить"
        Me.bUpdate.UseVisualStyleBackColor = True
        '
        'DatagridLogWriter1
        '
        Me.DatagridLogWriter1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DatagridLogWriter1.ExtendedView = True
        Me.DatagridLogWriter1.FilterText = ""
        Me.DatagridLogWriter1.Location = New System.Drawing.Point(0, 254)
        Me.DatagridLogWriter1.LogEnabled = True
        Me.DatagridLogWriter1.Margin = New System.Windows.Forms.Padding(0)
        Me.DatagridLogWriter1.Name = "DatagridLogWriter1"
        Me.DatagridLogWriter1.ShowDebug = False
        Me.DatagridLogWriter1.ShowErrors = True
        Me.DatagridLogWriter1.ShowInformation = True
        Me.DatagridLogWriter1.ShowMessages = True
        Me.DatagridLogWriter1.ShowWarnings = True
        Me.DatagridLogWriter1.Size = New System.Drawing.Size(742, 150)
        Me.DatagridLogWriter1.TabIndex = 12
        '
        'bFindDevice
        '
        Me.bFindDevice.Location = New System.Drawing.Point(526, 127)
        Me.bFindDevice.Name = "bFindDevice"
        Me.bFindDevice.Size = New System.Drawing.Size(206, 39)
        Me.bFindDevice.TabIndex = 13
        Me.bFindDevice.Text = "Найти устройство"
        Me.bFindDevice.UseVisualStyleBackColor = True
        '
        'SerialSelector1
        '
        Me.SerialSelector1.AllowPortChange = True
        Me.SerialSelector1.AllowSpeedChange = True
        Me.SerialSelector1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SerialSelector1.AssociatedISerialDevice = Nothing
        Me.SerialSelector1.Location = New System.Drawing.Point(6, 19)
        Me.SerialSelector1.Name = "SerialSelector1"
        Me.SerialSelector1.Size = New System.Drawing.Size(98, 84)
        Me.SerialSelector1.TabIndex = 23
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.tbClientAddress)
        Me.GroupBox4.Controls.Add(Me.SerialSelector1)
        Me.GroupBox4.Controls.Add(Me.bConnectToClient)
        Me.GroupBox4.Location = New System.Drawing.Point(5, 12)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(110, 239)
        Me.GroupBox4.TabIndex = 11
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Подключение"
        '
        'bSimplSerialTool
        '
        Me.bSimplSerialTool.Location = New System.Drawing.Point(526, 219)
        Me.bSimplSerialTool.Name = "bSimplSerialTool"
        Me.bSimplSerialTool.Size = New System.Drawing.Size(206, 23)
        Me.bSimplSerialTool.TabIndex = 14
        Me.bSimplSerialTool.Text = "SimplSerial Tool"
        Me.bSimplSerialTool.UseVisualStyleBackColor = True
        '
        'tbClientAddress
        '
        Me.tbClientAddress.Location = New System.Drawing.Point(7, 168)
        Me.tbClientAddress.Name = "tbClientAddress"
        Me.tbClientAddress.Size = New System.Drawing.Size(97, 20)
        Me.tbClientAddress.TabIndex = 25
        Me.tbClientAddress.Text = "localhost:4960"
        '
        'bConnectToClient
        '
        Me.bConnectToClient.Location = New System.Drawing.Point(6, 194)
        Me.bConnectToClient.Name = "bConnectToClient"
        Me.bConnectToClient.Size = New System.Drawing.Size(98, 36)
        Me.bConnectToClient.TabIndex = 24
        Me.bConnectToClient.Text = "Подключиться по сети"
        Me.bConnectToClient.UseVisualStyleBackColor = True
        '
        'FirmwareUpdaterTool
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(744, 401)
        Me.Controls.Add(Me.bSimplSerialTool)
        Me.Controls.Add(Me.bFindDevice)
        Me.Controls.Add(Me.DatagridLogWriter1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.bUpdate)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FirmwareUpdaterTool"
        Me.Text = "SS: Утилита обновления прошивки"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tbFindBootName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents tbFindMainName As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents tbFindWorkAddress As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents tbUpdateFile As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents tbUpdateName As TextBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents tbConnectedName As TextBox
    Friend WithEvents tbConnectedGuid As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents tbConnectedAddress As TextBox
    Friend WithEvents bUpdate As Button
    Friend WithEvents bRequestInfo As Button
    Friend WithEvents DatagridLogWriter1 As DatagridLogWriter
    Friend WithEvents Label10 As Label
    Friend WithEvents tbConnectedDate As TextBox
    Friend WithEvents bFindDevice As Button
    Friend WithEvents SerialSelector1 As SerialSelector
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents bSimplSerialTool As Button
    Friend WithEvents tbClientAddress As TextBox
    Friend WithEvents bConnectToClient As Button
End Class
