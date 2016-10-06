<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SimplSerialTool
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SimplSerialTool))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.signature = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.progmemSizeTextbox = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.reqBootInfoButton = New System.Windows.Forms.Button()
        Me.spmSizeTextbox = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.selectFirmwarePathButton = New System.Windows.Forms.Button()
        Me.firmwarePathTextbox = New System.Windows.Forms.TextBox()
        Me.eraseProgramButton = New System.Windows.Forms.Button()
        Me.programMemButton = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.selfTestBustton = New System.Windows.Forms.Button()
        Me.gotoMain = New System.Windows.Forms.Button()
        Me.goToBootloader = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me._setAddressValueTextbox = New System.Windows.Forms.TextBox()
        Me._setAddressGuidTextbox = New System.Windows.Forms.TextBox()
        Me.setAddressButton = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.portReadButton = New System.Windows.Forms.Button()
        Me.portWriteButton = New System.Windows.Forms.Button()
        Me.PortMonitor4 = New Bwl.Hardware.SimplSerial.PortMonitor()
        Me.PortMonitor3 = New Bwl.Hardware.SimplSerial.PortMonitor()
        Me.PortMonitor2 = New Bwl.Hardware.SimplSerial.PortMonitor()
        Me.PortMonitor1 = New Bwl.Hardware.SimplSerial.PortMonitor()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me._searchingEnabled = New System.Windows.Forms.CheckBox()
        Me.searchDevicesResult = New System.Windows.Forms.TextBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.queryAllGuidsButton = New System.Windows.Forms.Button()
        Me.guidCommentTextbox = New System.Windows.Forms.TextBox()
        Me.addGuidButton = New System.Windows.Forms.Button()
        Me.getCurrentGuidButton = New System.Windows.Forms.Button()
        Me.guidToAddTextbox = New System.Windows.Forms.TextBox()
        Me.identifiersList = New System.Windows.Forms.ListBox()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.CodeExecutor1 = New Bwl.Hardware.SimplSerial.CodeExecutor()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.devAddressTextbox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.devDateTextbox = New System.Windows.Forms.TextBox()
        Me.reqAddressTextbox = New System.Windows.Forms.TextBox()
        Me.getDevInfoButton = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.devguidTextbox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.devnameTextbox = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.НастройкиToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.reqGuidTextbox = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.bootstateTextbox = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.addInfoTextbox = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.SerialSelector1 = New Bwl.Hardware.SimplSerial.SerialSelector()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.selectGuid = New System.Windows.Forms.RadioButton()
        Me.selectAddress = New System.Windows.Forms.RadioButton()
        Me.selectBroadcast = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.DatagridLogWriter1 = New Bwl.Hardware.SimplSerial.DatagridLogWriter()
        Me.ЛогToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Location = New System.Drawing.Point(2, 216)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(915, 259)
        Me.TabControl1.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox7)
        Me.TabPage1.Controls.Add(Me.GroupBox6)
        Me.TabPage1.Controls.Add(Me.GroupBox5)
        Me.TabPage1.Controls.Add(Me.GroupBox4)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(907, 233)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Основное"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.signature)
        Me.GroupBox7.Controls.Add(Me.Label7)
        Me.GroupBox7.Controls.Add(Me.progmemSizeTextbox)
        Me.GroupBox7.Controls.Add(Me.Label6)
        Me.GroupBox7.Controls.Add(Me.reqBootInfoButton)
        Me.GroupBox7.Controls.Add(Me.spmSizeTextbox)
        Me.GroupBox7.Controls.Add(Me.Label5)
        Me.GroupBox7.Location = New System.Drawing.Point(256, 113)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(643, 50)
        Me.GroupBox7.TabIndex = 43
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Техническая информация загрузчика"
        '
        'signature
        '
        Me.signature.Location = New System.Drawing.Point(387, 19)
        Me.signature.Name = "signature"
        Me.signature.ReadOnly = True
        Me.signature.Size = New System.Drawing.Size(87, 20)
        Me.signature.TabIndex = 20
        Me.signature.Text = "0"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(331, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 13)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "Signature"
        '
        'progmemSizeTextbox
        '
        Me.progmemSizeTextbox.Location = New System.Drawing.Point(235, 19)
        Me.progmemSizeTextbox.Name = "progmemSizeTextbox"
        Me.progmemSizeTextbox.ReadOnly = True
        Me.progmemSizeTextbox.Size = New System.Drawing.Size(87, 20)
        Me.progmemSizeTextbox.TabIndex = 21
        Me.progmemSizeTextbox.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(147, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 13)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "PROGMEM size"
        '
        'reqBootInfoButton
        '
        Me.reqBootInfoButton.Location = New System.Drawing.Point(478, 18)
        Me.reqBootInfoButton.Name = "reqBootInfoButton"
        Me.reqBootInfoButton.Size = New System.Drawing.Size(159, 21)
        Me.reqBootInfoButton.TabIndex = 17
        Me.reqBootInfoButton.Text = "Запрос информации"
        Me.reqBootInfoButton.UseVisualStyleBackColor = True
        '
        'spmSizeTextbox
        '
        Me.spmSizeTextbox.Location = New System.Drawing.Point(59, 19)
        Me.spmSizeTextbox.Name = "spmSizeTextbox"
        Me.spmSizeTextbox.ReadOnly = True
        Me.spmSizeTextbox.Size = New System.Drawing.Size(87, 20)
        Me.spmSizeTextbox.TabIndex = 18
        Me.spmSizeTextbox.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(5, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 13)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "SPM size"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label11)
        Me.GroupBox6.Controls.Add(Me.Label8)
        Me.GroupBox6.Controls.Add(Me.selectFirmwarePathButton)
        Me.GroupBox6.Controls.Add(Me.firmwarePathTextbox)
        Me.GroupBox6.Controls.Add(Me.eraseProgramButton)
        Me.GroupBox6.Controls.Add(Me.programMemButton)
        Me.GroupBox6.Location = New System.Drawing.Point(256, 6)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(643, 103)
        Me.GroupBox6.TabIndex = 42
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Прошивка"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(6, 58)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(630, 42)
        Me.Label11.TabIndex = 27
        Me.Label11.Text = resources.GetString("Label11.Text")
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(187, 13)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Путь к файлу прошивки (*.hex; *.bin)"
        '
        'selectFirmwarePathButton
        '
        Me.selectFirmwarePathButton.Location = New System.Drawing.Point(446, 32)
        Me.selectFirmwarePathButton.Name = "selectFirmwarePathButton"
        Me.selectFirmwarePathButton.Size = New System.Drawing.Size(28, 22)
        Me.selectFirmwarePathButton.TabIndex = 24
        Me.selectFirmwarePathButton.Text = "..."
        Me.selectFirmwarePathButton.UseVisualStyleBackColor = True
        '
        'firmwarePathTextbox
        '
        Me.firmwarePathTextbox.Location = New System.Drawing.Point(8, 33)
        Me.firmwarePathTextbox.Name = "firmwarePathTextbox"
        Me.firmwarePathTextbox.Size = New System.Drawing.Size(434, 20)
        Me.firmwarePathTextbox.TabIndex = 23
        '
        'eraseProgramButton
        '
        Me.eraseProgramButton.Location = New System.Drawing.Point(478, 32)
        Me.eraseProgramButton.Name = "eraseProgramButton"
        Me.eraseProgramButton.Size = New System.Drawing.Size(77, 22)
        Me.eraseProgramButton.TabIndex = 22
        Me.eraseProgramButton.Text = "Очистка"
        Me.eraseProgramButton.UseVisualStyleBackColor = True
        '
        'programMemButton
        '
        Me.programMemButton.Location = New System.Drawing.Point(559, 32)
        Me.programMemButton.Name = "programMemButton"
        Me.programMemButton.Size = New System.Drawing.Size(77, 22)
        Me.programMemButton.TabIndex = 21
        Me.programMemButton.Text = "Прошивка"
        Me.programMemButton.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Controls.Add(Me.selfTestBustton)
        Me.GroupBox5.Controls.Add(Me.gotoMain)
        Me.GroupBox5.Controls.Add(Me.goToBootloader)
        Me.GroupBox5.Controls.Add(Me.Button2)
        Me.GroupBox5.Location = New System.Drawing.Point(7, 6)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(242, 219)
        Me.GroupBox5.TabIndex = 41
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Сервисные функции"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(5, 101)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(236, 71)
        Me.Label10.TabIndex = 26
        Me.Label10.Text = "В зависимости от версий программы, протокола, загрузчика один или несколько спосо" &
    "бов рестарта могут не работать. В этом случае используйте перезагрузку по питани" &
    "ю."
        '
        'selfTestBustton
        '
        Me.selfTestBustton.Location = New System.Drawing.Point(5, 173)
        Me.selfTestBustton.Name = "selfTestBustton"
        Me.selfTestBustton.Size = New System.Drawing.Size(228, 22)
        Me.selfTestBustton.TabIndex = 4
        Me.selfTestBustton.Text = "Тест стабильности передачи данных"
        Me.selfTestBustton.UseVisualStyleBackColor = True
        '
        'gotoMain
        '
        Me.gotoMain.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gotoMain.Location = New System.Drawing.Point(5, 75)
        Me.gotoMain.Name = "gotoMain"
        Me.gotoMain.Size = New System.Drawing.Size(228, 22)
        Me.gotoMain.TabIndex = 25
        Me.gotoMain.Text = "Рестарт в основную программу"
        Me.gotoMain.UseVisualStyleBackColor = True
        '
        'goToBootloader
        '
        Me.goToBootloader.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.goToBootloader.Location = New System.Drawing.Point(5, 47)
        Me.goToBootloader.Name = "goToBootloader"
        Me.goToBootloader.Size = New System.Drawing.Size(228, 22)
        Me.goToBootloader.TabIndex = 24
        Me.goToBootloader.Text = "Рестарт в загрузчик"
        Me.goToBootloader.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(5, 19)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(228, 22)
        Me.Button2.TabIndex = 25
        Me.Button2.Text = "Рестарт по-умолчанию"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label25)
        Me.GroupBox4.Controls.Add(Me.Label24)
        Me.GroupBox4.Controls.Add(Me.Label20)
        Me.GroupBox4.Controls.Add(Me.Label21)
        Me.GroupBox4.Controls.Add(Me._setAddressValueTextbox)
        Me.GroupBox4.Controls.Add(Me._setAddressGuidTextbox)
        Me.GroupBox4.Controls.Add(Me.setAddressButton)
        Me.GroupBox4.Location = New System.Drawing.Point(256, 167)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(643, 58)
        Me.GroupBox4.TabIndex = 40
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Установка рабочего адреса"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(6, 41)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(423, 13)
        Me.Label25.TabIndex = 41
        Me.Label25.Text = "Только для отладки. Для работы по GUID используйте выбор устройства вверху."
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(6, 41)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(0, 13)
        Me.Label24.TabIndex = 40
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(6, 21)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(90, 13)
        Me.Label20.TabIndex = 39
        Me.Label20.Text = "Идентификатор:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(335, 21)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(41, 13)
        Me.Label21.TabIndex = 38
        Me.Label21.Text = "Адрес:"
        '
        '_setAddressValueTextbox
        '
        Me._setAddressValueTextbox.Location = New System.Drawing.Point(378, 17)
        Me._setAddressValueTextbox.Name = "_setAddressValueTextbox"
        Me._setAddressValueTextbox.Size = New System.Drawing.Size(61, 20)
        Me._setAddressValueTextbox.TabIndex = 37
        Me._setAddressValueTextbox.Text = "0"
        '
        '_setAddressGuidTextbox
        '
        Me._setAddressGuidTextbox.Location = New System.Drawing.Point(100, 17)
        Me._setAddressGuidTextbox.Name = "_setAddressGuidTextbox"
        Me._setAddressGuidTextbox.Size = New System.Drawing.Size(224, 20)
        Me._setAddressGuidTextbox.TabIndex = 36
        Me._setAddressGuidTextbox.Text = "0"
        '
        'setAddressButton
        '
        Me.setAddressButton.Location = New System.Drawing.Point(446, 16)
        Me.setAddressButton.Name = "setAddressButton"
        Me.setAddressButton.Size = New System.Drawing.Size(190, 22)
        Me.setAddressButton.TabIndex = 35
        Me.setAddressButton.Text = "Установить рабочий адрес"
        Me.setAddressButton.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label17)
        Me.TabPage2.Controls.Add(Me.Label16)
        Me.TabPage2.Controls.Add(Me.Label15)
        Me.TabPage2.Controls.Add(Me.Label14)
        Me.TabPage2.Controls.Add(Me.Label13)
        Me.TabPage2.Controls.Add(Me.portReadButton)
        Me.TabPage2.Controls.Add(Me.portWriteButton)
        Me.TabPage2.Controls.Add(Me.PortMonitor4)
        Me.TabPage2.Controls.Add(Me.PortMonitor3)
        Me.TabPage2.Controls.Add(Me.PortMonitor2)
        Me.TabPage2.Controls.Add(Me.PortMonitor1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(907, 233)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Входы-выходы"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(686, 185)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(129, 31)
        Me.Label17.TabIndex = 61
        Me.Label17.Text = "Удерживайте Shift для немедленной записи "
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(544, 12)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(34, 13)
        Me.Label16.TabIndex = 56
        Me.Label16.Text = "PortD"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(373, 12)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(33, 13)
        Me.Label15.TabIndex = 55
        Me.Label15.Text = "PortC"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(205, 12)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(33, 13)
        Me.Label14.TabIndex = 54
        Me.Label14.Text = "PortB"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(35, 12)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(33, 13)
        Me.Label13.TabIndex = 53
        Me.Label13.Text = "PortA"
        '
        'portReadButton
        '
        Me.portReadButton.Location = New System.Drawing.Point(686, 122)
        Me.portReadButton.Name = "portReadButton"
        Me.portReadButton.Size = New System.Drawing.Size(134, 27)
        Me.portReadButton.TabIndex = 51
        Me.portReadButton.Text = "Считать все"
        Me.portReadButton.UseVisualStyleBackColor = True
        '
        'portWriteButton
        '
        Me.portWriteButton.Location = New System.Drawing.Point(686, 155)
        Me.portWriteButton.Name = "portWriteButton"
        Me.portWriteButton.Size = New System.Drawing.Size(134, 27)
        Me.portWriteButton.TabIndex = 52
        Me.portWriteButton.Text = "Записать все"
        Me.portWriteButton.UseVisualStyleBackColor = True
        '
        'PortMonitor4
        '
        Me.PortMonitor4.Location = New System.Drawing.Point(514, 29)
        Me.PortMonitor4.Name = "PortMonitor4"
        Me.PortMonitor4.Port = Nothing
        Me.PortMonitor4.Size = New System.Drawing.Size(166, 187)
        Me.PortMonitor4.TabIndex = 60
        '
        'PortMonitor3
        '
        Me.PortMonitor3.Location = New System.Drawing.Point(343, 29)
        Me.PortMonitor3.Name = "PortMonitor3"
        Me.PortMonitor3.Port = Nothing
        Me.PortMonitor3.Size = New System.Drawing.Size(166, 187)
        Me.PortMonitor3.TabIndex = 59
        '
        'PortMonitor2
        '
        Me.PortMonitor2.Location = New System.Drawing.Point(173, 29)
        Me.PortMonitor2.Name = "PortMonitor2"
        Me.PortMonitor2.Port = Nothing
        Me.PortMonitor2.Size = New System.Drawing.Size(166, 187)
        Me.PortMonitor2.TabIndex = 58
        '
        'PortMonitor1
        '
        Me.PortMonitor1.Location = New System.Drawing.Point(6, 29)
        Me.PortMonitor1.Name = "PortMonitor1"
        Me.PortMonitor1.Port = Nothing
        Me.PortMonitor1.Size = New System.Drawing.Size(166, 187)
        Me.PortMonitor1.TabIndex = 57
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.Label22)
        Me.TabPage5.Controls.Add(Me.Button1)
        Me.TabPage5.Controls.Add(Me._searchingEnabled)
        Me.TabPage5.Controls.Add(Me.searchDevicesResult)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(907, 233)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Поиск устройств на шине"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label22.Location = New System.Drawing.Point(599, 63)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(298, 165)
        Me.Label22.TabIndex = 6
        Me.Label22.Text = resources.GetString("Label22.Text")
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(600, 36)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(298, 22)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Запрос информации у найденных"
        Me.Button1.UseVisualStyleBackColor = True
        '
        '_searchingEnabled
        '
        Me._searchingEnabled.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._searchingEnabled.AutoSize = True
        Me._searchingEnabled.Location = New System.Drawing.Point(600, 13)
        Me._searchingEnabled.Name = "_searchingEnabled"
        Me._searchingEnabled.Size = New System.Drawing.Size(89, 17)
        Me._searchingEnabled.TabIndex = 1
        Me._searchingEnabled.Text = "Вести поиск"
        Me._searchingEnabled.UseVisualStyleBackColor = True
        '
        'searchDevicesResult
        '
        Me.searchDevicesResult.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.searchDevicesResult.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.searchDevicesResult.Location = New System.Drawing.Point(7, 12)
        Me.searchDevicesResult.Multiline = True
        Me.searchDevicesResult.Name = "searchDevicesResult"
        Me.searchDevicesResult.Size = New System.Drawing.Size(571, 216)
        Me.searchDevicesResult.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.queryAllGuidsButton)
        Me.TabPage3.Controls.Add(Me.guidCommentTextbox)
        Me.TabPage3.Controls.Add(Me.addGuidButton)
        Me.TabPage3.Controls.Add(Me.getCurrentGuidButton)
        Me.TabPage3.Controls.Add(Me.guidToAddTextbox)
        Me.TabPage3.Controls.Add(Me.identifiersList)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(907, 233)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Библиотека идентификаторов"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'queryAllGuidsButton
        '
        Me.queryAllGuidsButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.queryAllGuidsButton.Location = New System.Drawing.Point(622, 91)
        Me.queryAllGuidsButton.Name = "queryAllGuidsButton"
        Me.queryAllGuidsButton.Size = New System.Drawing.Size(263, 22)
        Me.queryAllGuidsButton.TabIndex = 8
        Me.queryAllGuidsButton.Text = "Опросить все"
        Me.queryAllGuidsButton.UseVisualStyleBackColor = True
        '
        'guidCommentTextbox
        '
        Me.guidCommentTextbox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.guidCommentTextbox.Location = New System.Drawing.Point(622, 37)
        Me.guidCommentTextbox.Name = "guidCommentTextbox"
        Me.guidCommentTextbox.Size = New System.Drawing.Size(263, 20)
        Me.guidCommentTextbox.TabIndex = 7
        '
        'addGuidButton
        '
        Me.addGuidButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.addGuidButton.Location = New System.Drawing.Point(785, 63)
        Me.addGuidButton.Name = "addGuidButton"
        Me.addGuidButton.Size = New System.Drawing.Size(100, 22)
        Me.addGuidButton.TabIndex = 6
        Me.addGuidButton.Text = "Добавить"
        Me.addGuidButton.UseVisualStyleBackColor = True
        '
        'getCurrentGuidButton
        '
        Me.getCurrentGuidButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.getCurrentGuidButton.Location = New System.Drawing.Point(622, 64)
        Me.getCurrentGuidButton.Name = "getCurrentGuidButton"
        Me.getCurrentGuidButton.Size = New System.Drawing.Size(157, 22)
        Me.getCurrentGuidButton.TabIndex = 5
        Me.getCurrentGuidButton.Text = "Взять текущий"
        Me.getCurrentGuidButton.UseVisualStyleBackColor = True
        '
        'guidToAddTextbox
        '
        Me.guidToAddTextbox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.guidToAddTextbox.Location = New System.Drawing.Point(622, 11)
        Me.guidToAddTextbox.Name = "guidToAddTextbox"
        Me.guidToAddTextbox.Size = New System.Drawing.Size(263, 20)
        Me.guidToAddTextbox.TabIndex = 1
        '
        'identifiersList
        '
        Me.identifiersList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.identifiersList.FormattingEnabled = True
        Me.identifiersList.Location = New System.Drawing.Point(7, 12)
        Me.identifiersList.Name = "identifiersList"
        Me.identifiersList.Size = New System.Drawing.Size(606, 212)
        Me.identifiersList.TabIndex = 0
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.Label23)
        Me.TabPage4.Controls.Add(Me.CodeExecutor1)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(907, 233)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Скрипт"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'Label23
        '
        Me.Label23.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label23.Location = New System.Drawing.Point(614, 10)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(290, 220)
        Me.Label23.TabIndex = 28
        Me.Label23.Text = resources.GetString("Label23.Text")
        '
        'CodeExecutor1
        '
        Me.CodeExecutor1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CodeExecutor1.ImportsList = CType(resources.GetObject("CodeExecutor1.ImportsList"), System.Collections.Generic.List(Of String))
        Me.CodeExecutor1.Location = New System.Drawing.Point(4, 9)
        Me.CodeExecutor1.Name = "CodeExecutor1"
        Me.CodeExecutor1.ReferencesList = CType(resources.GetObject("CodeExecutor1.ReferencesList"), System.Collections.Generic.List(Of String))
        Me.CodeExecutor1.Size = New System.Drawing.Size(585, 224)
        Me.CodeExecutor1.SourceText = ""
        Me.CodeExecutor1.TabIndex = 0
        Me.CodeExecutor1.Template = "Imports Bwl.Hardware.SimplSerial.SimplSerialBus'importsPublic Class TestProgram'c" &
    "odeEnd Class"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(208, 73)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Адрес:"
        '
        'devAddressTextbox
        '
        Me.devAddressTextbox.Location = New System.Drawing.Point(253, 69)
        Me.devAddressTextbox.Name = "devAddressTextbox"
        Me.devAddressTextbox.ReadOnly = True
        Me.devAddressTextbox.Size = New System.Drawing.Size(155, 20)
        Me.devAddressTextbox.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Дата прошивки:"
        '
        'devDateTextbox
        '
        Me.devDateTextbox.Location = New System.Drawing.Point(101, 69)
        Me.devDateTextbox.Name = "devDateTextbox"
        Me.devDateTextbox.ReadOnly = True
        Me.devDateTextbox.Size = New System.Drawing.Size(101, 20)
        Me.devDateTextbox.TabIndex = 6
        '
        'reqAddressTextbox
        '
        Me.reqAddressTextbox.Location = New System.Drawing.Point(10, 67)
        Me.reqAddressTextbox.Multiline = True
        Me.reqAddressTextbox.Name = "reqAddressTextbox"
        Me.reqAddressTextbox.Size = New System.Drawing.Size(230, 21)
        Me.reqAddressTextbox.TabIndex = 5
        Me.reqAddressTextbox.Text = "0"
        '
        'getDevInfoButton
        '
        Me.getDevInfoButton.Location = New System.Drawing.Point(100, 147)
        Me.getDevInfoButton.Name = "getDevInfoButton"
        Me.getDevInfoButton.Size = New System.Drawing.Size(308, 22)
        Me.getDevInfoButton.TabIndex = 4
        Me.getDevInfoButton.Text = "Запрос информации"
        Me.getDevInfoButton.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Идентификатор:"
        '
        'devguidTextbox
        '
        Me.devguidTextbox.Location = New System.Drawing.Point(101, 43)
        Me.devguidTextbox.Name = "devguidTextbox"
        Me.devguidTextbox.ReadOnly = True
        Me.devguidTextbox.Size = New System.Drawing.Size(307, 20)
        Me.devguidTextbox.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Имя устройства:"
        '
        'devnameTextbox
        '
        Me.devnameTextbox.Location = New System.Drawing.Point(101, 17)
        Me.devnameTextbox.Name = "devnameTextbox"
        Me.devnameTextbox.ReadOnly = True
        Me.devnameTextbox.Size = New System.Drawing.Size(307, 20)
        Me.devnameTextbox.TabIndex = 0
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.НастройкиToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(917, 24)
        Me.MenuStrip1.TabIndex = 11
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'НастройкиToolStripMenuItem
        '
        Me.НастройкиToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ЛогToolStripMenuItem})
        Me.НастройкиToolStripMenuItem.Name = "НастройкиToolStripMenuItem"
        Me.НастройкиToolStripMenuItem.Size = New System.Drawing.Size(88, 20)
        Me.НастройкиToolStripMenuItem.Text = "Настройки..."
        '
        'reqGuidTextbox
        '
        Me.reqGuidTextbox.Location = New System.Drawing.Point(10, 119)
        Me.reqGuidTextbox.Multiline = True
        Me.reqGuidTextbox.Name = "reqGuidTextbox"
        Me.reqGuidTextbox.Size = New System.Drawing.Size(229, 21)
        Me.reqGuidTextbox.TabIndex = 12
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(35, 13)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Порт:"
        '
        'bootstateTextbox
        '
        Me.bootstateTextbox.Location = New System.Drawing.Point(101, 121)
        Me.bootstateTextbox.Name = "bootstateTextbox"
        Me.bootstateTextbox.ReadOnly = True
        Me.bootstateTextbox.Size = New System.Drawing.Size(307, 20)
        Me.bootstateTextbox.TabIndex = 26
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(7, 125)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(62, 13)
        Me.Label18.TabIndex = 27
        Me.Label18.Text = "Загрузчик:"
        '
        'addInfoTextbox
        '
        Me.addInfoTextbox.Location = New System.Drawing.Point(101, 95)
        Me.addInfoTextbox.Name = "addInfoTextbox"
        Me.addInfoTextbox.ReadOnly = True
        Me.addInfoTextbox.Size = New System.Drawing.Size(307, 20)
        Me.addInfoTextbox.TabIndex = 28
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.SerialSelector1)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 27)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(208, 86)
        Me.GroupBox1.TabIndex = 29
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Параметры шины"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(6, 54)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(58, 13)
        Me.Label19.TabIndex = 22
        Me.Label19.Text = "Скорость:"
        '
        'SerialSelector1
        '
        Me.SerialSelector1.AllowPortChange = True
        Me.SerialSelector1.AllowSpeedChange = True
        Me.SerialSelector1.AssociatedISerialDevice = Nothing
        Me.SerialSelector1.Location = New System.Drawing.Point(65, 24)
        Me.SerialSelector1.Name = "SerialSelector1"
        Me.SerialSelector1.Size = New System.Drawing.Size(132, 52)
        Me.SerialSelector1.TabIndex = 13
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button3)
        Me.GroupBox2.Controls.Add(Me.selectGuid)
        Me.GroupBox2.Controls.Add(Me.selectAddress)
        Me.GroupBox2.Controls.Add(Me.selectBroadcast)
        Me.GroupBox2.Controls.Add(Me.reqAddressTextbox)
        Me.GroupBox2.Controls.Add(Me.reqGuidTextbox)
        Me.GroupBox2.Location = New System.Drawing.Point(228, 27)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(250, 183)
        Me.GroupBox2.TabIndex = 30
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Выбор устройства"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(8, 147)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(232, 22)
        Me.Button3.TabIndex = 13
        Me.Button3.Text = "Проверка"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'selectGuid
        '
        Me.selectGuid.AutoSize = True
        Me.selectGuid.Location = New System.Drawing.Point(9, 95)
        Me.selectGuid.Name = "selectGuid"
        Me.selectGuid.Size = New System.Drawing.Size(233, 17)
        Me.selectGuid.TabIndex = 2
        Me.selectGuid.Text = "По глобальному идентификатору (GUID):"
        Me.selectGuid.UseVisualStyleBackColor = True
        '
        'selectAddress
        '
        Me.selectAddress.AutoSize = True
        Me.selectAddress.Location = New System.Drawing.Point(9, 43)
        Me.selectAddress.Name = "selectAddress"
        Me.selectAddress.Size = New System.Drawing.Size(179, 17)
        Me.selectAddress.TabIndex = 1
        Me.selectAddress.Text = "По рабочему адресу (1-65536):"
        Me.selectAddress.UseVisualStyleBackColor = True
        '
        'selectBroadcast
        '
        Me.selectBroadcast.AutoSize = True
        Me.selectBroadcast.Checked = True
        Me.selectBroadcast.Location = New System.Drawing.Point(9, 19)
        Me.selectBroadcast.Name = "selectBroadcast"
        Me.selectBroadcast.Size = New System.Drawing.Size(141, 17)
        Me.selectBroadcast.TabIndex = 0
        Me.selectBroadcast.TabStop = True
        Me.selectBroadcast.Text = "Широковещательно (0)"
        Me.selectBroadcast.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.bootstateTextbox)
        Me.GroupBox3.Controls.Add(Me.devDateTextbox)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.addInfoTextbox)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.devAddressTextbox)
        Me.GroupBox3.Controls.Add(Me.getDevInfoButton)
        Me.GroupBox3.Controls.Add(Me.devnameTextbox)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.devguidTextbox)
        Me.GroupBox3.Location = New System.Drawing.Point(488, 27)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(419, 183)
        Me.GroupBox3.TabIndex = 31
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Информация об устройстве"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(7, 99)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(90, 13)
        Me.Label12.TabIndex = 29
        Me.Label12.Text = "Дополнительно:"
        '
        'DatagridLogWriter1
        '
        Me.DatagridLogWriter1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DatagridLogWriter1.ExtendedView = True
        Me.DatagridLogWriter1.FilterText = ""
        Me.DatagridLogWriter1.Location = New System.Drawing.Point(1, 478)
        Me.DatagridLogWriter1.LogEnabled = True
        Me.DatagridLogWriter1.Margin = New System.Windows.Forms.Padding(0)
        Me.DatagridLogWriter1.Name = "DatagridLogWriter1"
        Me.DatagridLogWriter1.ShowDebug = False
        Me.DatagridLogWriter1.ShowErrors = True
        Me.DatagridLogWriter1.ShowInformation = True
        Me.DatagridLogWriter1.ShowMessages = True
        Me.DatagridLogWriter1.ShowWarnings = True
        Me.DatagridLogWriter1.Size = New System.Drawing.Size(915, 254)
        Me.DatagridLogWriter1.TabIndex = 10
        '
        'ЛогToolStripMenuItem
        '
        Me.ЛогToolStripMenuItem.Name = "ЛогToolStripMenuItem"
        Me.ЛогToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ЛогToolStripMenuItem.Text = "Лог"
        '
        'SimplSerialTool
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(917, 733)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DatagridLogWriter1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimumSize = New System.Drawing.Size(300, 200)
        Me.Name = "SimplSerialTool"
        Me.Text = "SimplSerialTool"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents devDateTextbox As System.Windows.Forms.TextBox
    Friend WithEvents reqAddressTextbox As System.Windows.Forms.TextBox
    Friend WithEvents getDevInfoButton As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents devguidTextbox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents devnameTextbox As System.Windows.Forms.TextBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents devAddressTextbox As System.Windows.Forms.TextBox
    Friend WithEvents selfTestBustton As System.Windows.Forms.Button
    Friend WithEvents DatagridLogWriter1 As DatagridLogWriter
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents НастройкиToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents identifiersList As System.Windows.Forms.ListBox
    Friend WithEvents queryAllGuidsButton As System.Windows.Forms.Button
    Friend WithEvents guidCommentTextbox As System.Windows.Forms.TextBox
    Friend WithEvents addGuidButton As System.Windows.Forms.Button
    Friend WithEvents getCurrentGuidButton As System.Windows.Forms.Button
    Friend WithEvents guidToAddTextbox As System.Windows.Forms.TextBox
    Friend WithEvents reqGuidTextbox As System.Windows.Forms.TextBox
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents CodeExecutor1 As Bwl.Hardware.SimplSerial.CodeExecutor
    Friend WithEvents SerialSelector1 As Bwl.Hardware.SimplSerial.SerialSelector
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents searchDevicesResult As System.Windows.Forms.TextBox
    Friend WithEvents _searchingEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents bootstateTextbox As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents addInfoTextbox As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents selectGuid As System.Windows.Forms.RadioButton
    Friend WithEvents selectAddress As System.Windows.Forms.RadioButton
    Friend WithEvents selectBroadcast As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents signature As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents progmemSizeTextbox As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents reqBootInfoButton As System.Windows.Forms.Button
    Friend WithEvents spmSizeTextbox As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents selectFirmwarePathButton As System.Windows.Forms.Button
    Friend WithEvents firmwarePathTextbox As System.Windows.Forms.TextBox
    Friend WithEvents eraseProgramButton As System.Windows.Forms.Button
    Friend WithEvents programMemButton As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents gotoMain As System.Windows.Forms.Button
    Friend WithEvents goToBootloader As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents _setAddressValueTextbox As System.Windows.Forms.TextBox
    Friend WithEvents _setAddressGuidTextbox As System.Windows.Forms.TextBox
    Friend WithEvents setAddressButton As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents PortMonitor4 As Bwl.Hardware.SimplSerial.PortMonitor
    Friend WithEvents PortMonitor3 As Bwl.Hardware.SimplSerial.PortMonitor
    Friend WithEvents PortMonitor2 As Bwl.Hardware.SimplSerial.PortMonitor
    Friend WithEvents PortMonitor1 As Bwl.Hardware.SimplSerial.PortMonitor
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents portReadButton As System.Windows.Forms.Button
    Friend WithEvents portWriteButton As System.Windows.Forms.Button
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents ЛогToolStripMenuItem As ToolStripMenuItem
End Class
