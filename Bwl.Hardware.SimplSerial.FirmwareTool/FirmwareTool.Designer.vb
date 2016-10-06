<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FirmwareTool
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FirmwareTool))
        Me.gbTechInfo = New System.Windows.Forms.GroupBox()
        Me.signature = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.progmemSizeTextbox = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.reqBootInfoButton = New System.Windows.Forms.Button()
        Me.spmSizeTextbox = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.gbFirmware = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.selectFirmwarePathButton = New System.Windows.Forms.Button()
        Me.firmwarePathTextbox = New System.Windows.Forms.TextBox()
        Me.eraseProgramButton = New System.Windows.Forms.Button()
        Me.programMemButton = New System.Windows.Forms.Button()
        Me.gotoMain = New System.Windows.Forms.Button()
        Me.goToBootloader = New System.Windows.Forms.Button()
        Me.restartByDefault = New System.Windows.Forms.Button()
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
        Me.DatagridLogWriter1 = New Bwl.Hardware.SimplSerial.DatagridLogWriter()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.НастройкиToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.reqGuidTextbox = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.bootstateTextbox = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.addInfoTextbox = New System.Windows.Forms.TextBox()
        Me.gbPortSelect = New System.Windows.Forms.GroupBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.SerialSelector1 = New Bwl.Hardware.SimplSerial.SerialSelector()
        Me.gbSelectDevice = New System.Windows.Forms.GroupBox()
        Me.bTestDevice = New System.Windows.Forms.Button()
        Me.selectGuid = New System.Windows.Forms.RadioButton()
        Me.selectAddress = New System.Windows.Forms.RadioButton()
        Me.selectBroadcast = New System.Windows.Forms.RadioButton()
        Me.gbDevInfo = New System.Windows.Forms.GroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.gbRestarts = New System.Windows.Forms.GroupBox()
        Me.bStartScript = New System.Windows.Forms.Button()
        Me.gbTechInfo.SuspendLayout()
        Me.gbFirmware.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.gbPortSelect.SuspendLayout()
        Me.gbSelectDevice.SuspendLayout()
        Me.gbDevInfo.SuspendLayout()
        Me.gbRestarts.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbTechInfo
        '
        Me.gbTechInfo.Controls.Add(Me.signature)
        Me.gbTechInfo.Controls.Add(Me.Label7)
        Me.gbTechInfo.Controls.Add(Me.progmemSizeTextbox)
        Me.gbTechInfo.Controls.Add(Me.Label6)
        Me.gbTechInfo.Controls.Add(Me.reqBootInfoButton)
        Me.gbTechInfo.Controls.Add(Me.spmSizeTextbox)
        Me.gbTechInfo.Controls.Add(Me.Label5)
        Me.gbTechInfo.Location = New System.Drawing.Point(228, 216)
        Me.gbTechInfo.Name = "gbTechInfo"
        Me.gbTechInfo.Size = New System.Drawing.Size(679, 50)
        Me.gbTechInfo.TabIndex = 43
        Me.gbTechInfo.TabStop = False
        Me.gbTechInfo.Text = "Техническая информация загрузчика"
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
        'gbFirmware
        '
        Me.gbFirmware.Controls.Add(Me.Label8)
        Me.gbFirmware.Controls.Add(Me.selectFirmwarePathButton)
        Me.gbFirmware.Controls.Add(Me.firmwarePathTextbox)
        Me.gbFirmware.Controls.Add(Me.eraseProgramButton)
        Me.gbFirmware.Controls.Add(Me.programMemButton)
        Me.gbFirmware.Location = New System.Drawing.Point(228, 272)
        Me.gbFirmware.Name = "gbFirmware"
        Me.gbFirmware.Size = New System.Drawing.Size(679, 63)
        Me.gbFirmware.TabIndex = 42
        Me.gbFirmware.TabStop = False
        Me.gbFirmware.Text = "Прошивка"
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
        'gotoMain
        '
        Me.gotoMain.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gotoMain.Location = New System.Drawing.Point(6, 75)
        Me.gotoMain.Name = "gotoMain"
        Me.gotoMain.Size = New System.Drawing.Size(191, 22)
        Me.gotoMain.TabIndex = 25
        Me.gotoMain.Text = "Рестарт в основную программу"
        Me.gotoMain.UseVisualStyleBackColor = True
        '
        'goToBootloader
        '
        Me.goToBootloader.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.goToBootloader.Location = New System.Drawing.Point(6, 47)
        Me.goToBootloader.Name = "goToBootloader"
        Me.goToBootloader.Size = New System.Drawing.Size(191, 22)
        Me.goToBootloader.TabIndex = 24
        Me.goToBootloader.Text = "Рестарт в загрузчик"
        Me.goToBootloader.UseVisualStyleBackColor = True
        '
        'restartByDefault
        '
        Me.restartByDefault.Location = New System.Drawing.Point(6, 19)
        Me.restartByDefault.Name = "restartByDefault"
        Me.restartByDefault.Size = New System.Drawing.Size(191, 22)
        Me.restartByDefault.TabIndex = 25
        Me.restartByDefault.Text = "Рестарт по-умолчанию"
        Me.restartByDefault.UseVisualStyleBackColor = True
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
        'DatagridLogWriter1
        '
        Me.DatagridLogWriter1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DatagridLogWriter1.ExtendedView = False
        Me.DatagridLogWriter1.FilterText = ""
        Me.DatagridLogWriter1.Location = New System.Drawing.Point(1, 338)
        Me.DatagridLogWriter1.LogEnabled = True
        Me.DatagridLogWriter1.Margin = New System.Windows.Forms.Padding(0)
        Me.DatagridLogWriter1.Name = "DatagridLogWriter1"
        Me.DatagridLogWriter1.ShowDebug = False
        Me.DatagridLogWriter1.ShowErrors = True
        Me.DatagridLogWriter1.ShowInformation = True
        Me.DatagridLogWriter1.ShowMessages = True
        Me.DatagridLogWriter1.ShowWarnings = True
        Me.DatagridLogWriter1.Size = New System.Drawing.Size(915, 307)
        Me.DatagridLogWriter1.TabIndex = 10
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
        'gbPortSelect
        '
        Me.gbPortSelect.Controls.Add(Me.Label19)
        Me.gbPortSelect.Controls.Add(Me.SerialSelector1)
        Me.gbPortSelect.Controls.Add(Me.Label9)
        Me.gbPortSelect.Location = New System.Drawing.Point(10, 130)
        Me.gbPortSelect.Name = "gbPortSelect"
        Me.gbPortSelect.Size = New System.Drawing.Size(208, 86)
        Me.gbPortSelect.TabIndex = 29
        Me.gbPortSelect.TabStop = False
        Me.gbPortSelect.Text = "Параметры шины"
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
        'gbSelectDevice
        '
        Me.gbSelectDevice.Controls.Add(Me.bTestDevice)
        Me.gbSelectDevice.Controls.Add(Me.selectGuid)
        Me.gbSelectDevice.Controls.Add(Me.selectAddress)
        Me.gbSelectDevice.Controls.Add(Me.selectBroadcast)
        Me.gbSelectDevice.Controls.Add(Me.reqAddressTextbox)
        Me.gbSelectDevice.Controls.Add(Me.reqGuidTextbox)
        Me.gbSelectDevice.Location = New System.Drawing.Point(228, 27)
        Me.gbSelectDevice.Name = "gbSelectDevice"
        Me.gbSelectDevice.Size = New System.Drawing.Size(250, 183)
        Me.gbSelectDevice.TabIndex = 30
        Me.gbSelectDevice.TabStop = False
        Me.gbSelectDevice.Text = "Выбор устройства"
        '
        'bTestDevice
        '
        Me.bTestDevice.Location = New System.Drawing.Point(8, 147)
        Me.bTestDevice.Name = "bTestDevice"
        Me.bTestDevice.Size = New System.Drawing.Size(232, 22)
        Me.bTestDevice.TabIndex = 13
        Me.bTestDevice.Text = "Проверка"
        Me.bTestDevice.UseVisualStyleBackColor = True
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
        'gbDevInfo
        '
        Me.gbDevInfo.Controls.Add(Me.Label12)
        Me.gbDevInfo.Controls.Add(Me.bootstateTextbox)
        Me.gbDevInfo.Controls.Add(Me.devDateTextbox)
        Me.gbDevInfo.Controls.Add(Me.Label2)
        Me.gbDevInfo.Controls.Add(Me.addInfoTextbox)
        Me.gbDevInfo.Controls.Add(Me.Label3)
        Me.gbDevInfo.Controls.Add(Me.Label1)
        Me.gbDevInfo.Controls.Add(Me.Label18)
        Me.gbDevInfo.Controls.Add(Me.devAddressTextbox)
        Me.gbDevInfo.Controls.Add(Me.getDevInfoButton)
        Me.gbDevInfo.Controls.Add(Me.devnameTextbox)
        Me.gbDevInfo.Controls.Add(Me.Label4)
        Me.gbDevInfo.Controls.Add(Me.devguidTextbox)
        Me.gbDevInfo.Location = New System.Drawing.Point(488, 27)
        Me.gbDevInfo.Name = "gbDevInfo"
        Me.gbDevInfo.Size = New System.Drawing.Size(419, 183)
        Me.gbDevInfo.TabIndex = 31
        Me.gbDevInfo.TabStop = False
        Me.gbDevInfo.Text = "Информация об устройстве"
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
        'gbRestarts
        '
        Me.gbRestarts.Controls.Add(Me.restartByDefault)
        Me.gbRestarts.Controls.Add(Me.goToBootloader)
        Me.gbRestarts.Controls.Add(Me.gotoMain)
        Me.gbRestarts.Location = New System.Drawing.Point(10, 225)
        Me.gbRestarts.Name = "gbRestarts"
        Me.gbRestarts.Size = New System.Drawing.Size(208, 106)
        Me.gbRestarts.TabIndex = 44
        Me.gbRestarts.TabStop = False
        Me.gbRestarts.Text = "Перезагрузка устройства"
        '
        'bStartScript
        '
        Me.bStartScript.Location = New System.Drawing.Point(56, 44)
        Me.bStartScript.Name = "bStartScript"
        Me.bStartScript.Size = New System.Drawing.Size(133, 67)
        Me.bStartScript.TabIndex = 45
        Me.bStartScript.Text = "Автопрошивка"
        Me.bStartScript.UseVisualStyleBackColor = True
        '
        'FirmwareTool
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(917, 645)
        Me.Controls.Add(Me.bStartScript)
        Me.Controls.Add(Me.gbRestarts)
        Me.Controls.Add(Me.gbFirmware)
        Me.Controls.Add(Me.gbTechInfo)
        Me.Controls.Add(Me.gbDevInfo)
        Me.Controls.Add(Me.gbSelectDevice)
        Me.Controls.Add(Me.gbPortSelect)
        Me.Controls.Add(Me.DatagridLogWriter1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimumSize = New System.Drawing.Size(840, 560)
        Me.Name = "FirmwareTool"
        Me.Text = "SimplSerial Flasher"
        Me.gbTechInfo.ResumeLayout(False)
        Me.gbTechInfo.PerformLayout()
        Me.gbFirmware.ResumeLayout(False)
        Me.gbFirmware.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gbPortSelect.ResumeLayout(False)
        Me.gbPortSelect.PerformLayout()
        Me.gbSelectDevice.ResumeLayout(False)
        Me.gbSelectDevice.PerformLayout()
        Me.gbDevInfo.ResumeLayout(False)
        Me.gbDevInfo.PerformLayout()
        Me.gbRestarts.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents devDateTextbox As System.Windows.Forms.TextBox
    Friend WithEvents reqAddressTextbox As System.Windows.Forms.TextBox
    Friend WithEvents getDevInfoButton As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents devguidTextbox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents devnameTextbox As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents devAddressTextbox As System.Windows.Forms.TextBox
    Friend WithEvents DatagridLogWriter1 As DatagridLogWriter
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents НастройкиToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents reqGuidTextbox As System.Windows.Forms.TextBox
    Friend WithEvents SerialSelector1 As Bwl.Hardware.SimplSerial.SerialSelector
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents restartByDefault As System.Windows.Forms.Button
    Friend WithEvents bootstateTextbox As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents addInfoTextbox As System.Windows.Forms.TextBox
    Friend WithEvents gbPortSelect As System.Windows.Forms.GroupBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents gbSelectDevice As System.Windows.Forms.GroupBox
    Friend WithEvents selectGuid As System.Windows.Forms.RadioButton
    Friend WithEvents selectAddress As System.Windows.Forms.RadioButton
    Friend WithEvents selectBroadcast As System.Windows.Forms.RadioButton
    Friend WithEvents gbDevInfo As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents bTestDevice As System.Windows.Forms.Button
    Friend WithEvents gbTechInfo As System.Windows.Forms.GroupBox
    Friend WithEvents signature As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents progmemSizeTextbox As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents reqBootInfoButton As System.Windows.Forms.Button
    Friend WithEvents spmSizeTextbox As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents gbFirmware As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents selectFirmwarePathButton As System.Windows.Forms.Button
    Friend WithEvents firmwarePathTextbox As System.Windows.Forms.TextBox
    Friend WithEvents eraseProgramButton As System.Windows.Forms.Button
    Friend WithEvents programMemButton As System.Windows.Forms.Button
    Friend WithEvents gotoMain As System.Windows.Forms.Button
    Friend WithEvents goToBootloader As System.Windows.Forms.Button
    Friend WithEvents gbRestarts As GroupBox
    Friend WithEvents bStartScript As Button
End Class
