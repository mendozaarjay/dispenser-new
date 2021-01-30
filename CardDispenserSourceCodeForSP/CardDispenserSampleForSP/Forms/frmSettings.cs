using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.EntityClient;
using System.Data.SqlClient;


namespace CardDispenserSampleForSP
{
    public partial class frmSettings : Form
    {


        public frmSettings()
        {
            InitializeComponent();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {

            PrepareTabMiscellaneous();
            PrepareTabDatabase();
            PrepareTabCameras();

        }

        private void PrepareTabMiscellaneous()
        {

            cmbGateName.DisplayMember = "GateName";
            cmbGateName.ValueMember = "GateID";
            //cmbGateName.DataSource = _dataProvider.GetAllGates(false);


            cmbGateName.SelectedValue = Convert.ToInt32(LocalSettings.GateID);


            Common.SerialPortListReNEW(cmbIobComPort);
            cmbIobComPort.SelectedIndex = cmbIobComPort.Items.IndexOf(LocalSettings.IOBcomPort);

            Common.SerialPortListReNEW(cmbDispenser1ComPort);
            cmbDispenser1ComPort.SelectedIndex = cmbDispenser1ComPort.Items.IndexOf(LocalSettings.SRD1comPort);

            Common.SerialPortListReNEW(cmbDispenser2ComPort);
            cmbDispenser2ComPort.SelectedIndex = cmbDispenser2ComPort.Items.IndexOf(LocalSettings.SRD2comPort);


            Common.SerialPortListReNEW(cmbSgbBarrierComPort);
            cmbSgbBarrierComPort.SelectedIndex = cmbSgbBarrierComPort.Items.IndexOf(LocalSettings.SgbBarrierComPort);


            cmbIobInputFromButton.SelectedIndex = cmbIobInputFromButton.Items.IndexOf(LocalSettings.IobInputFromButton);
            cmbIobInputFromLoop.SelectedIndex = cmbIobInputFromLoop.Items.IndexOf(LocalSettings.IobInputFromLoop);
            

            txtControlCenterIpAddress.Text = LocalSettings.ControlCenterIP;
            chkAnnounceControlCenter.Checked = LocalSettings.AnnounceControlCenter;

            txtListenOnPort.Text = LocalSettings.ListenOnPort.ToString();
            chkEnableNetworkListener.Checked = LocalSettings.EnableNetworkListener;


            if (LocalSettings.BarrierControllerType == "SGB")
                rdbSgbBarrierType.Checked = true;
            else if (LocalSettings.BarrierControllerType == "IOB")
                rdbIobBarrierType.Checked = true;
            else if (LocalSettings.BarrierControllerType == "Network")
                rdbNetworkBarrierType.Checked = true;

            txtNetworkBarrierIP.Text = LocalSettings.BarrierControllerIp;

            if (LocalSettings.IobType == "1000")
                rdbIob1000.Checked = true;
            else if (LocalSettings.IobType == "2000")
                rdbIob2000.Checked = true;


            //cmbIobBaudRate.SelectedIndex = cmbIobBaudRate.Items.IndexOf(LocalSettings.IOBbaudRate);


            txtAutoLoginUsername.Text = LocalSettings.AutoLoginUser;
            txtAutoLoginPassword.Text = LocalSettings.AutoLoginPassword;

            txtLocalIPAddress.Text = LocalSettings.LocalIPAddress;
            txtSerialNumber.Text = LocalSettings.SerialNumber;
            txtTerminal.Text = LocalSettings.Terminal;
            txtLocation.Text = LocalSettings.Location;

            chkLoopDetectionRequired.Checked = LocalSettings.LoopDetectionRequired;

        }

        private void PrepareTabDatabase()
        {

            txtSqlServerName.Text = LocalSettings.SqlDataSource;

            txtSqlDatabaseName.Text = LocalSettings.SqlInitialCatalog;

            txtSqlUserName.Text = LocalSettings.SqlUserId;

            txtSqlPassword.Text = LocalSettings.SqlPassword;


        }

        private void PrepareTabCameras()
        {
            txtRtspUrl.Text = LocalSettings.CamRtspUrl;
            chkDontSaveFullSizeImagesOnTheServer.Checked = LocalSettings.DontSaveFullSizeImagesOnTheServer;
            txtImagesSaveFolder.Text = LocalSettings.ImagesSaveFolder;
            chkDontSaveFullSizeImagesOnTheServer.Checked = Convert.ToBoolean(LocalSettings.DontSaveFullSizeImagesOnTheServer);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnTestDatabaseConnection_Click(object sender, EventArgs e)
        {


        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            LocalSettings.GateID = cmbGateName.SelectedValue.ToString();

            LocalSettings.SqlDataSource = txtSqlServerName.Text;
            LocalSettings.SqlInitialCatalog = txtSqlDatabaseName.Text;
            LocalSettings.SqlUserId = txtSqlUserName.Text;
            LocalSettings.SqlPassword = txtSqlPassword.Text;

            LocalSettings.AutoLoginUser = txtAutoLoginUsername.Text;
            LocalSettings.AutoLoginPassword = txtAutoLoginPassword.Text;

            if (cmbDispenser1ComPort.SelectedItem != null)
                LocalSettings.SRD1comPort = cmbDispenser1ComPort.SelectedItem.ToString();

            if (cmbDispenser2ComPort.SelectedItem != null)
                LocalSettings.SRD2comPort = cmbDispenser2ComPort.SelectedItem.ToString();

            if (cmbSgbBarrierComPort.SelectedItem != null)
                LocalSettings.SgbBarrierComPort = cmbSgbBarrierComPort.SelectedItem.ToString();

            if (cmbIobComPort.SelectedItem != null)
                LocalSettings.IOBcomPort = cmbIobComPort.SelectedItem.ToString();

            if (cmbIobInputFromButton.SelectedItem != null)
                LocalSettings.IobInputFromButton = cmbIobInputFromButton.SelectedItem.ToString();

            if (cmbIobInputFromLoop.SelectedItem != null)
                LocalSettings.IobInputFromLoop = cmbIobInputFromLoop.SelectedItem.ToString();


            LocalSettings.CamRtspUrl = txtRtspUrl.Text;
            LocalSettings.ImagesSaveFolder = txtImagesSaveFolder.Text;
            LocalSettings.DontSaveFullSizeImagesOnTheServer = chkDontSaveFullSizeImagesOnTheServer.Checked;


            LocalSettings.AnnounceControlCenter = chkAnnounceControlCenter.Checked;
            LocalSettings.ControlCenterIP = txtControlCenterIpAddress.Text;

            LocalSettings.EnableNetworkListener = chkEnableNetworkListener.Checked;
            LocalSettings.ListenOnPort =Convert.ToInt32(txtListenOnPort.Text);


            if (rdbSgbBarrierType.Checked)
                LocalSettings.BarrierControllerType = "SGB";
            else if (rdbIobBarrierType.Checked)
                LocalSettings.BarrierControllerType = "IOB";
            else if (rdbNetworkBarrierType.Checked)
                LocalSettings.BarrierControllerType = "Network";

            LocalSettings.BarrierControllerIp = txtNetworkBarrierIP.Text;
            if (rdbIob1000.Checked)
                LocalSettings.IobType = "1000";
            else if (rdbIob2000.Checked)
                LocalSettings.IobType = "2000";


            LocalSettings.LoopDetectionRequired = chkLoopDetectionRequired.Checked;
            LocalSettings.LocalIPAddress = txtLocalIPAddress.Text;
            LocalSettings.SerialNumber = txtSerialNumber.Text;
            LocalSettings.Terminal = txtTerminal.Text;
            LocalSettings.Location = txtLocation.Text;

            LocalSettings.SaveSettings();

            MessageBox.Show("Please restart the software to apply the settings.", "Software Restrat", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
        }

        private void btnBrowseSaveImageFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            if (System.IO.Directory.Exists(fbd.SelectedPath))
                txtImagesSaveFolder.Text = fbd.SelectedPath;
        }
    }
}
