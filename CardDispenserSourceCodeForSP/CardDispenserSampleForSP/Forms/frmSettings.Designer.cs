namespace CardDispenserSampleForSP
{
    partial class frmSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControlSettings = new System.Windows.Forms.TabControl();
            this.tabPageMiscellaneous = new System.Windows.Forms.TabPage();
            this.cmbSgbBarrierComPort = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtNetworkBarrierIP = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.chkEnableNetworkListener = new System.Windows.Forms.CheckBox();
            this.txtListenOnPort = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.chkLoopDetectionRequired = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbIob2000 = new System.Windows.Forms.RadioButton();
            this.rdbIob1000 = new System.Windows.Forms.RadioButton();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbIobInputFromLoop = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbIobInputFromButton = new System.Windows.Forms.ComboBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.rdbNetworkBarrierType = new System.Windows.Forms.RadioButton();
            this.rdbIobBarrierType = new System.Windows.Forms.RadioButton();
            this.rdbSgbBarrierType = new System.Windows.Forms.RadioButton();
            this.cmbDispenser2ComPort = new System.Windows.Forms.ComboBox();
            this.cmbDispenser1ComPort = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAutoLoginUsername = new System.Windows.Forms.TextBox();
            this.txtAutoLoginPassword = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbGateName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkAnnounceControlCenter = new System.Windows.Forms.CheckBox();
            this.txtControlCenterIpAddress = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbIobComPort = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.tabPageCameras = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkDontSaveFullSizeImagesOnTheServer = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowseSaveImageFolder = new System.Windows.Forms.Button();
            this.txtImagesSaveFolder = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtRtspUrl = new System.Windows.Forms.TextBox();
            this.tabPageDatabase = new System.Windows.Forms.TabPage();
            this.txtSqlDatabaseName = new System.Windows.Forms.TextBox();
            this.txtSqlUserName = new System.Windows.Forms.TextBox();
            this.txtSqlPassword = new System.Windows.Forms.TextBox();
            this.btnTestDatabaseConnection = new System.Windows.Forms.Button();
            this.txtSqlServerName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtLocalIPAddress = new System.Windows.Forms.TextBox();
            this.txtSerialNumber = new System.Windows.Forms.TextBox();
            this.txtTerminal = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.tabControlSettings.SuspendLayout();
            this.tabPageMiscellaneous.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabPageCameras.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPageDatabase.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlSettings
            // 
            this.tabControlSettings.Controls.Add(this.tabPageMiscellaneous);
            this.tabControlSettings.Controls.Add(this.tabPageCameras);
            this.tabControlSettings.Controls.Add(this.tabPageDatabase);
            this.tabControlSettings.Location = new System.Drawing.Point(3, 4);
            this.tabControlSettings.Margin = new System.Windows.Forms.Padding(4);
            this.tabControlSettings.Name = "tabControlSettings";
            this.tabControlSettings.SelectedIndex = 0;
            this.tabControlSettings.Size = new System.Drawing.Size(797, 574);
            this.tabControlSettings.TabIndex = 0;
            // 
            // tabPageMiscellaneous
            // 
            this.tabPageMiscellaneous.Controls.Add(this.txtLocation);
            this.tabPageMiscellaneous.Controls.Add(this.label21);
            this.tabPageMiscellaneous.Controls.Add(this.txtTerminal);
            this.tabPageMiscellaneous.Controls.Add(this.label19);
            this.tabPageMiscellaneous.Controls.Add(this.txtSerialNumber);
            this.tabPageMiscellaneous.Controls.Add(this.txtLocalIPAddress);
            this.tabPageMiscellaneous.Controls.Add(this.label18);
            this.tabPageMiscellaneous.Controls.Add(this.label17);
            this.tabPageMiscellaneous.Controls.Add(this.cmbSgbBarrierComPort);
            this.tabPageMiscellaneous.Controls.Add(this.label12);
            this.tabPageMiscellaneous.Controls.Add(this.txtNetworkBarrierIP);
            this.tabPageMiscellaneous.Controls.Add(this.label20);
            this.tabPageMiscellaneous.Controls.Add(this.chkEnableNetworkListener);
            this.tabPageMiscellaneous.Controls.Add(this.txtListenOnPort);
            this.tabPageMiscellaneous.Controls.Add(this.label13);
            this.tabPageMiscellaneous.Controls.Add(this.chkLoopDetectionRequired);
            this.tabPageMiscellaneous.Controls.Add(this.groupBox2);
            this.tabPageMiscellaneous.Controls.Add(this.label14);
            this.tabPageMiscellaneous.Controls.Add(this.cmbIobInputFromLoop);
            this.tabPageMiscellaneous.Controls.Add(this.label11);
            this.tabPageMiscellaneous.Controls.Add(this.cmbIobInputFromButton);
            this.tabPageMiscellaneous.Controls.Add(this.groupBox6);
            this.tabPageMiscellaneous.Controls.Add(this.cmbDispenser2ComPort);
            this.tabPageMiscellaneous.Controls.Add(this.cmbDispenser1ComPort);
            this.tabPageMiscellaneous.Controls.Add(this.label7);
            this.tabPageMiscellaneous.Controls.Add(this.label8);
            this.tabPageMiscellaneous.Controls.Add(this.txtAutoLoginUsername);
            this.tabPageMiscellaneous.Controls.Add(this.txtAutoLoginPassword);
            this.tabPageMiscellaneous.Controls.Add(this.label9);
            this.tabPageMiscellaneous.Controls.Add(this.label10);
            this.tabPageMiscellaneous.Controls.Add(this.cmbGateName);
            this.tabPageMiscellaneous.Controls.Add(this.label1);
            this.tabPageMiscellaneous.Controls.Add(this.chkAnnounceControlCenter);
            this.tabPageMiscellaneous.Controls.Add(this.txtControlCenterIpAddress);
            this.tabPageMiscellaneous.Controls.Add(this.label16);
            this.tabPageMiscellaneous.Controls.Add(this.cmbIobComPort);
            this.tabPageMiscellaneous.Controls.Add(this.label27);
            this.tabPageMiscellaneous.Location = new System.Drawing.Point(4, 29);
            this.tabPageMiscellaneous.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageMiscellaneous.Name = "tabPageMiscellaneous";
            this.tabPageMiscellaneous.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageMiscellaneous.Size = new System.Drawing.Size(789, 541);
            this.tabPageMiscellaneous.TabIndex = 3;
            this.tabPageMiscellaneous.Text = "Miscellaneous";
            this.tabPageMiscellaneous.UseVisualStyleBackColor = true;
            // 
            // cmbSgbBarrierComPort
            // 
            this.cmbSgbBarrierComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSgbBarrierComPort.FormattingEnabled = true;
            this.cmbSgbBarrierComPort.Location = new System.Drawing.Point(221, 217);
            this.cmbSgbBarrierComPort.Name = "cmbSgbBarrierComPort";
            this.cmbSgbBarrierComPort.Size = new System.Drawing.Size(113, 28);
            this.cmbSgbBarrierComPort.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(44, 220);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(185, 20);
            this.label12.TabIndex = 71;
            this.label12.Text = "SGB Barrier COM port:";
            // 
            // txtNetworkBarrierIP
            // 
            this.txtNetworkBarrierIP.Location = new System.Drawing.Point(221, 183);
            this.txtNetworkBarrierIP.Name = "txtNetworkBarrierIP";
            this.txtNetworkBarrierIP.Size = new System.Drawing.Size(113, 26);
            this.txtNetworkBarrierIP.TabIndex = 2;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(43, 186);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(152, 20);
            this.label20.TabIndex = 69;
            this.label20.Text = "Network Barrier IP:";
            // 
            // chkEnableNetworkListener
            // 
            this.chkEnableNetworkListener.AutoSize = true;
            this.chkEnableNetworkListener.Location = new System.Drawing.Point(442, 246);
            this.chkEnableNetworkListener.Name = "chkEnableNetworkListener";
            this.chkEnableNetworkListener.Size = new System.Drawing.Size(205, 24);
            this.chkEnableNetworkListener.TabIndex = 68;
            this.chkEnableNetworkListener.Text = "Enable network listener";
            this.chkEnableNetworkListener.UseVisualStyleBackColor = true;
            // 
            // txtListenOnPort
            // 
            this.txtListenOnPort.Location = new System.Drawing.Point(611, 266);
            this.txtListenOnPort.Name = "txtListenOnPort";
            this.txtListenOnPort.Size = new System.Drawing.Size(113, 26);
            this.txtListenOnPort.TabIndex = 12;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(439, 269);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(117, 20);
            this.label13.TabIndex = 66;
            this.label13.Text = "Listen on port:";
            // 
            // chkLoopDetectionRequired
            // 
            this.chkLoopDetectionRequired.AutoSize = true;
            this.chkLoopDetectionRequired.Location = new System.Drawing.Point(442, 418);
            this.chkLoopDetectionRequired.Name = "chkLoopDetectionRequired";
            this.chkLoopDetectionRequired.Size = new System.Drawing.Size(207, 24);
            this.chkLoopDetectionRequired.TabIndex = 61;
            this.chkLoopDetectionRequired.Text = "Loop detection required";
            this.chkLoopDetectionRequired.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbIob2000);
            this.groupBox2.Controls.Add(this.rdbIob1000);
            this.groupBox2.Location = new System.Drawing.Point(47, 306);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(287, 58);
            this.groupBox2.TabIndex = 60;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "IOB type";
            // 
            // rdbIob2000
            // 
            this.rdbIob2000.AutoSize = true;
            this.rdbIob2000.Location = new System.Drawing.Point(119, 28);
            this.rdbIob2000.Name = "rdbIob2000";
            this.rdbIob2000.Size = new System.Drawing.Size(66, 24);
            this.rdbIob2000.TabIndex = 23;
            this.rdbIob2000.TabStop = true;
            this.rdbIob2000.Text = "2000";
            this.rdbIob2000.UseVisualStyleBackColor = true;
            // 
            // rdbIob1000
            // 
            this.rdbIob1000.AutoSize = true;
            this.rdbIob1000.Location = new System.Drawing.Point(17, 28);
            this.rdbIob1000.Name = "rdbIob1000";
            this.rdbIob1000.Size = new System.Drawing.Size(66, 24);
            this.rdbIob1000.TabIndex = 22;
            this.rdbIob1000.TabStop = true;
            this.rdbIob1000.Text = "1000";
            this.rdbIob1000.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(44, 420);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(200, 20);
            this.label14.TabIndex = 59;
            this.label14.Text = "IOB 1000 input from loop:";
            // 
            // cmbIobInputFromLoop
            // 
            this.cmbIobInputFromLoop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIobInputFromLoop.FormattingEnabled = true;
            this.cmbIobInputFromLoop.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cmbIobInputFromLoop.Location = new System.Drawing.Point(221, 416);
            this.cmbIobInputFromLoop.Name = "cmbIobInputFromLoop";
            this.cmbIobInputFromLoop.Size = new System.Drawing.Size(113, 28);
            this.cmbIobInputFromLoop.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(44, 386);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(215, 20);
            this.label11.TabIndex = 59;
            this.label11.Text = "IOB 1000 input from button:";
            // 
            // cmbIobInputFromButton
            // 
            this.cmbIobInputFromButton.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIobInputFromButton.FormattingEnabled = true;
            this.cmbIobInputFromButton.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cmbIobInputFromButton.Location = new System.Drawing.Point(221, 382);
            this.cmbIobInputFromButton.Name = "cmbIobInputFromButton";
            this.cmbIobInputFromButton.Size = new System.Drawing.Size(113, 28);
            this.cmbIobInputFromButton.TabIndex = 5;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rdbNetworkBarrierType);
            this.groupBox6.Controls.Add(this.rdbIobBarrierType);
            this.groupBox6.Controls.Add(this.rdbSgbBarrierType);
            this.groupBox6.Location = new System.Drawing.Point(47, 109);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(287, 58);
            this.groupBox6.TabIndex = 57;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Barrier controller type";
            // 
            // rdbNetworkBarrierType
            // 
            this.rdbNetworkBarrierType.AutoSize = true;
            this.rdbNetworkBarrierType.Location = new System.Drawing.Point(147, 26);
            this.rdbNetworkBarrierType.Name = "rdbNetworkBarrierType";
            this.rdbNetworkBarrierType.Size = new System.Drawing.Size(91, 24);
            this.rdbNetworkBarrierType.TabIndex = 23;
            this.rdbNetworkBarrierType.TabStop = true;
            this.rdbNetworkBarrierType.Text = "Network";
            this.rdbNetworkBarrierType.UseVisualStyleBackColor = true;
            // 
            // rdbIobBarrierType
            // 
            this.rdbIobBarrierType.AutoSize = true;
            this.rdbIobBarrierType.Location = new System.Drawing.Point(85, 26);
            this.rdbIobBarrierType.Name = "rdbIobBarrierType";
            this.rdbIobBarrierType.Size = new System.Drawing.Size(59, 24);
            this.rdbIobBarrierType.TabIndex = 23;
            this.rdbIobBarrierType.TabStop = true;
            this.rdbIobBarrierType.Text = "IOB";
            this.rdbIobBarrierType.UseVisualStyleBackColor = true;
            // 
            // rdbSgbBarrierType
            // 
            this.rdbSgbBarrierType.AutoSize = true;
            this.rdbSgbBarrierType.Location = new System.Drawing.Point(17, 26);
            this.rdbSgbBarrierType.Name = "rdbSgbBarrierType";
            this.rdbSgbBarrierType.Size = new System.Drawing.Size(66, 24);
            this.rdbSgbBarrierType.TabIndex = 22;
            this.rdbSgbBarrierType.TabStop = true;
            this.rdbSgbBarrierType.Text = "SGB";
            this.rdbSgbBarrierType.UseVisualStyleBackColor = true;
            // 
            // cmbDispenser2ComPort
            // 
            this.cmbDispenser2ComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDispenser2ComPort.FormattingEnabled = true;
            this.cmbDispenser2ComPort.Location = new System.Drawing.Point(221, 56);
            this.cmbDispenser2ComPort.Name = "cmbDispenser2ComPort";
            this.cmbDispenser2ComPort.Size = new System.Drawing.Size(113, 28);
            this.cmbDispenser2ComPort.TabIndex = 1;
            // 
            // cmbDispenser1ComPort
            // 
            this.cmbDispenser1ComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDispenser1ComPort.FormattingEnabled = true;
            this.cmbDispenser1ComPort.Location = new System.Drawing.Point(221, 22);
            this.cmbDispenser1ComPort.Name = "cmbDispenser1ComPort";
            this.cmbDispenser1ComPort.Size = new System.Drawing.Size(113, 28);
            this.cmbDispenser1ComPort.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(43, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(183, 20);
            this.label7.TabIndex = 53;
            this.label7.Text = "Dispenser 2 COM port:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(43, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(183, 20);
            this.label8.TabIndex = 53;
            this.label8.Text = "Dispenser 1 COM port:";
            // 
            // txtAutoLoginUsername
            // 
            this.txtAutoLoginUsername.Location = new System.Drawing.Point(611, 47);
            this.txtAutoLoginUsername.Name = "txtAutoLoginUsername";
            this.txtAutoLoginUsername.Size = new System.Drawing.Size(113, 26);
            this.txtAutoLoginUsername.TabIndex = 9;
            // 
            // txtAutoLoginPassword
            // 
            this.txtAutoLoginPassword.Location = new System.Drawing.Point(611, 75);
            this.txtAutoLoginPassword.Name = "txtAutoLoginPassword";
            this.txtAutoLoginPassword.Size = new System.Drawing.Size(113, 26);
            this.txtAutoLoginPassword.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(439, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(165, 20);
            this.label9.TabIndex = 50;
            this.label9.Text = "Auto login password:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(439, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(167, 20);
            this.label10.TabIndex = 49;
            this.label10.Text = "Auto login username:";
            // 
            // cmbGateName
            // 
            this.cmbGateName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGateName.FormattingEnabled = true;
            this.cmbGateName.Location = new System.Drawing.Point(611, 147);
            this.cmbGateName.Name = "cmbGateName";
            this.cmbGateName.Size = new System.Drawing.Size(113, 28);
            this.cmbGateName.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(439, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.TabIndex = 45;
            this.label1.Text = "Gate name:";
            // 
            // chkAnnounceControlCenter
            // 
            this.chkAnnounceControlCenter.AutoSize = true;
            this.chkAnnounceControlCenter.Location = new System.Drawing.Point(442, 335);
            this.chkAnnounceControlCenter.Name = "chkAnnounceControlCenter";
            this.chkAnnounceControlCenter.Size = new System.Drawing.Size(213, 24);
            this.chkAnnounceControlCenter.TabIndex = 44;
            this.chkAnnounceControlCenter.Text = "Announce control center";
            this.chkAnnounceControlCenter.UseVisualStyleBackColor = true;
            // 
            // txtControlCenterIpAddress
            // 
            this.txtControlCenterIpAddress.Location = new System.Drawing.Point(611, 361);
            this.txtControlCenterIpAddress.Name = "txtControlCenterIpAddress";
            this.txtControlCenterIpAddress.Size = new System.Drawing.Size(113, 26);
            this.txtControlCenterIpAddress.TabIndex = 13;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(442, 364);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(123, 20);
            this.label16.TabIndex = 42;
            this.label16.Text = "CC IP address:";
            // 
            // cmbIobComPort
            // 
            this.cmbIobComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIobComPort.FormattingEnabled = true;
            this.cmbIobComPort.Location = new System.Drawing.Point(221, 276);
            this.cmbIobComPort.Name = "cmbIobComPort";
            this.cmbIobComPort.Size = new System.Drawing.Size(113, 28);
            this.cmbIobComPort.TabIndex = 4;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(44, 279);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(121, 20);
            this.label27.TabIndex = 21;
            this.label27.Text = "IOB COM port:";
            // 
            // tabPageCameras
            // 
            this.tabPageCameras.Controls.Add(this.groupBox3);
            this.tabPageCameras.Controls.Add(this.label15);
            this.tabPageCameras.Controls.Add(this.txtRtspUrl);
            this.tabPageCameras.Location = new System.Drawing.Point(4, 29);
            this.tabPageCameras.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageCameras.Name = "tabPageCameras";
            this.tabPageCameras.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageCameras.Size = new System.Drawing.Size(789, 541);
            this.tabPageCameras.TabIndex = 1;
            this.tabPageCameras.Text = "Camera";
            this.tabPageCameras.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkDontSaveFullSizeImagesOnTheServer);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.btnBrowseSaveImageFolder);
            this.groupBox3.Controls.Add(this.txtImagesSaveFolder);
            this.groupBox3.Location = new System.Drawing.Point(75, 136);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(602, 102);
            this.groupBox3.TabIndex = 56;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Image saving";
            // 
            // chkDontSaveFullSizeImagesOnTheServer
            // 
            this.chkDontSaveFullSizeImagesOnTheServer.AutoSize = true;
            this.chkDontSaveFullSizeImagesOnTheServer.Location = new System.Drawing.Point(39, 32);
            this.chkDontSaveFullSizeImagesOnTheServer.Name = "chkDontSaveFullSizeImagesOnTheServer";
            this.chkDontSaveFullSizeImagesOnTheServer.Size = new System.Drawing.Size(346, 24);
            this.chkDontSaveFullSizeImagesOnTheServer.TabIndex = 58;
            this.chkDontSaveFullSizeImagesOnTheServer.Text = "Do not save full size images on the server";
            this.chkDontSaveFullSizeImagesOnTheServer.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 20);
            this.label2.TabIndex = 57;
            this.label2.Text = "Images folder:";
            // 
            // btnBrowseSaveImageFolder
            // 
            this.btnBrowseSaveImageFolder.Location = new System.Drawing.Point(500, 62);
            this.btnBrowseSaveImageFolder.Name = "btnBrowseSaveImageFolder";
            this.btnBrowseSaveImageFolder.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseSaveImageFolder.TabIndex = 7;
            this.btnBrowseSaveImageFolder.Text = "Browse";
            this.btnBrowseSaveImageFolder.UseVisualStyleBackColor = true;
            this.btnBrowseSaveImageFolder.Click += new System.EventHandler(this.btnBrowseSaveImageFolder_Click);
            // 
            // txtImagesSaveFolder
            // 
            this.txtImagesSaveFolder.Location = new System.Drawing.Point(132, 63);
            this.txtImagesSaveFolder.Margin = new System.Windows.Forms.Padding(2);
            this.txtImagesSaveFolder.Name = "txtImagesSaveFolder";
            this.txtImagesSaveFolder.Size = new System.Drawing.Size(345, 26);
            this.txtImagesSaveFolder.TabIndex = 6;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(72, 76);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(97, 20);
            this.label15.TabIndex = 7;
            this.label15.Text = "RTSP URL:";
            // 
            // txtRtspUrl
            // 
            this.txtRtspUrl.Location = new System.Drawing.Point(154, 73);
            this.txtRtspUrl.Margin = new System.Windows.Forms.Padding(2);
            this.txtRtspUrl.Name = "txtRtspUrl";
            this.txtRtspUrl.Size = new System.Drawing.Size(496, 26);
            this.txtRtspUrl.TabIndex = 6;
            // 
            // tabPageDatabase
            // 
            this.tabPageDatabase.Controls.Add(this.txtSqlDatabaseName);
            this.tabPageDatabase.Controls.Add(this.txtSqlUserName);
            this.tabPageDatabase.Controls.Add(this.txtSqlPassword);
            this.tabPageDatabase.Controls.Add(this.btnTestDatabaseConnection);
            this.tabPageDatabase.Controls.Add(this.txtSqlServerName);
            this.tabPageDatabase.Controls.Add(this.label6);
            this.tabPageDatabase.Controls.Add(this.label5);
            this.tabPageDatabase.Controls.Add(this.label4);
            this.tabPageDatabase.Controls.Add(this.label3);
            this.tabPageDatabase.Location = new System.Drawing.Point(4, 29);
            this.tabPageDatabase.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageDatabase.Name = "tabPageDatabase";
            this.tabPageDatabase.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageDatabase.Size = new System.Drawing.Size(789, 541);
            this.tabPageDatabase.TabIndex = 2;
            this.tabPageDatabase.Text = "Database";
            this.tabPageDatabase.UseVisualStyleBackColor = true;
            // 
            // txtSqlDatabaseName
            // 
            this.txtSqlDatabaseName.Location = new System.Drawing.Point(182, 76);
            this.txtSqlDatabaseName.Name = "txtSqlDatabaseName";
            this.txtSqlDatabaseName.Size = new System.Drawing.Size(173, 26);
            this.txtSqlDatabaseName.TabIndex = 8;
            // 
            // txtSqlUserName
            // 
            this.txtSqlUserName.Location = new System.Drawing.Point(182, 104);
            this.txtSqlUserName.Name = "txtSqlUserName";
            this.txtSqlUserName.Size = new System.Drawing.Size(173, 26);
            this.txtSqlUserName.TabIndex = 7;
            // 
            // txtSqlPassword
            // 
            this.txtSqlPassword.Location = new System.Drawing.Point(182, 132);
            this.txtSqlPassword.Name = "txtSqlPassword";
            this.txtSqlPassword.Size = new System.Drawing.Size(173, 26);
            this.txtSqlPassword.TabIndex = 6;
            // 
            // btnTestDatabaseConnection
            // 
            this.btnTestDatabaseConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestDatabaseConnection.Location = new System.Drawing.Point(635, 391);
            this.btnTestDatabaseConnection.Name = "btnTestDatabaseConnection";
            this.btnTestDatabaseConnection.Size = new System.Drawing.Size(114, 39);
            this.btnTestDatabaseConnection.TabIndex = 5;
            this.btnTestDatabaseConnection.Text = "Test";
            this.btnTestDatabaseConnection.UseVisualStyleBackColor = true;
            this.btnTestDatabaseConnection.Click += new System.EventHandler(this.btnTestDatabaseConnection_Click);
            // 
            // txtSqlServerName
            // 
            this.txtSqlServerName.Location = new System.Drawing.Point(182, 46);
            this.txtSqlServerName.Name = "txtSqlServerName";
            this.txtSqlServerName.Size = new System.Drawing.Size(173, 26);
            this.txtSqlServerName.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(55, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "Password:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Username:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Database name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Server name:";
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveSettings.Location = new System.Drawing.Point(677, 585);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(114, 39);
            this.btnSaveSettings.TabIndex = 1;
            this.btnSaveSettings.Text = "Save";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(543, 585);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(114, 39);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(44, 462);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(147, 20);
            this.label17.TabIndex = 73;
            this.label17.Text = "Local IP Address :";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(44, 500);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(126, 20);
            this.label18.TabIndex = 74;
            this.label18.Text = "Serial Number :";
            // 
            // txtLocalIPAddress
            // 
            this.txtLocalIPAddress.Location = new System.Drawing.Point(221, 459);
            this.txtLocalIPAddress.Name = "txtLocalIPAddress";
            this.txtLocalIPAddress.Size = new System.Drawing.Size(113, 26);
            this.txtLocalIPAddress.TabIndex = 7;
            // 
            // txtSerialNumber
            // 
            this.txtSerialNumber.Location = new System.Drawing.Point(221, 497);
            this.txtSerialNumber.Name = "txtSerialNumber";
            this.txtSerialNumber.Size = new System.Drawing.Size(113, 26);
            this.txtSerialNumber.TabIndex = 8;
            // 
            // txtTerminal
            // 
            this.txtTerminal.Location = new System.Drawing.Point(611, 462);
            this.txtTerminal.Name = "txtTerminal";
            this.txtTerminal.Size = new System.Drawing.Size(113, 26);
            this.txtTerminal.TabIndex = 75;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(434, 465);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(84, 20);
            this.label19.TabIndex = 76;
            this.label19.Text = "Terminal :";
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(611, 500);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(113, 26);
            this.txtLocation.TabIndex = 77;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(434, 503);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(83, 20);
            this.label21.TabIndex = 78;
            this.label21.Text = "Location :";
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 626);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveSettings);
            this.Controls.Add(this.tabControlSettings);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.tabControlSettings.ResumeLayout(false);
            this.tabPageMiscellaneous.ResumeLayout(false);
            this.tabPageMiscellaneous.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tabPageCameras.ResumeLayout(false);
            this.tabPageCameras.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPageDatabase.ResumeLayout(false);
            this.tabPageDatabase.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlSettings;
        private System.Windows.Forms.TabPage tabPageCameras;
        private System.Windows.Forms.TabPage tabPageDatabase;
        private System.Windows.Forms.TabPage tabPageMiscellaneous;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtSqlServerName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSqlDatabaseName;
        private System.Windows.Forms.TextBox txtSqlUserName;
        private System.Windows.Forms.TextBox txtSqlPassword;
        private System.Windows.Forms.Button btnTestDatabaseConnection;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.ComboBox cmbIobComPort;
        private System.Windows.Forms.ComboBox cmbDispenser1ComPort;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAutoLoginUsername;
        private System.Windows.Forms.TextBox txtAutoLoginPassword;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbGateName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkAnnounceControlCenter;
        private System.Windows.Forms.TextBox txtControlCenterIpAddress;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton rdbIobBarrierType;
        private System.Windows.Forms.RadioButton rdbSgbBarrierType;
        private System.Windows.Forms.ComboBox cmbDispenser2ComPort;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbIobInputFromButton;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbIobInputFromLoop;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbIob2000;
        private System.Windows.Forms.RadioButton rdbIob1000;
        private System.Windows.Forms.CheckBox chkLoopDetectionRequired;
        private System.Windows.Forms.CheckBox chkEnableNetworkListener;
        private System.Windows.Forms.TextBox txtListenOnPort;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RadioButton rdbNetworkBarrierType;
        private System.Windows.Forms.TextBox txtNetworkBarrierIP;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtRtspUrl;
        private System.Windows.Forms.ComboBox cmbSgbBarrierComPort;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkDontSaveFullSizeImagesOnTheServer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowseSaveImageFolder;
        private System.Windows.Forms.TextBox txtImagesSaveFolder;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtSerialNumber;
        private System.Windows.Forms.TextBox txtLocalIPAddress;
        private System.Windows.Forms.TextBox txtTerminal;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label label21;
    }
}