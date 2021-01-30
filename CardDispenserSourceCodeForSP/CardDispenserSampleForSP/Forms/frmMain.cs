using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.ServiceModel;
using System.Net;
using System.Net.Sockets;

namespace CardDispenserSampleForSP
{


    public partial class frmMain : Form
    {
        bool _waitingForDriverToPushTheButton = false;

        int _numberOfErrorsOccuredOnDispenser1 = 0;
        int _numberOfErrorsOccuredOnDispenser2 = 0;

        int _lastSentToDispenserNumber = 1;//default

        static BarrierController _barrierController;

        Vlc.DotNet.Forms.VlcControl myVlcControl = new Vlc.DotNet.Forms.VlcControl();

        static IOB2000_GreenBoard _ioBoard2000;

        SRD2000 _dispenser1;
        SRD2000 _dispenser2;
        int _secondsWaitedBeforeCapture = 0;

        USBcamera _USBcam;

        bool _waitingForDriverTotakeTheTicket = false;


        Timer timerDateTime = new Timer();
        Timer timerUSBcam = new Timer();

        System.Timers.Timer timerCapture = new System.Timers.Timer();

        Image _latestUSBcamImage;
        SoundPlayer _sndPlayer;


        Image _currentImage1;
        Image _currentImage2;

        System.Timers.Timer _timerClearMessages;
        DateTime _lastTimeThatAmessageIsDisplayed;
        bool _messagesShouldBeCleared;

        private DataAccessLayer services = new DataAccessLayer();
        public frmMain()
        {
            InitializeComponent();

        }

        private void pictureBoxCloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBoxMaximizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void pictureBoxMinimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {

                ShowVersionNumber();
                InitCaptureTimer();
                InitDataTimeDisplay();
                InitBarrierController();
                InitIOB();
                initDispenserDevices();
                InitIPcamera();
                InitUSBcamera();
                InitMessages();
                InitClearMessageTimer();

                Console.WriteLine("Version: " + GetVersion());

            }
            catch (Exception e2)
            {
                Console.WriteLine(e2);
                //MessageBox.Show(e2.Message);
            }

        }


        private void InitClearMessageTimer()
        {
            try
            {

                _timerClearMessages = new System.Timers.Timer(1000);
                _timerClearMessages.Elapsed += timerClearMessages_OnTimedEvent;
                _timerClearMessages.AutoReset = true;
                _timerClearMessages.Enabled = true;

            }
            catch (Exception e2)
            {
                Console.WriteLine(e2);
            }
        }


        private void timerClearMessages_OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            if ((DateTime.Now - _lastTimeThatAmessageIsDisplayed).TotalSeconds >= 5 && _messagesShouldBeCleared)
                ShowTextMessage(string.Empty, string.Empty);

        }


        private void PlanClearMessage()
        {
            _lastTimeThatAmessageIsDisplayed = DateTime.Now;
            _messagesShouldBeCleared = true;
        }

        private void InitBarrierController()
        {
            try
            {

                bool playEnglishBarrierOpenedMessage = true;

                _barrierController = new BarrierController(playEnglishBarrierOpenedMessage, LocalSettings.SgbBarrierComPort, LocalSettings.BarrierControllerType, LocalSettings.BarrierControllerIp);

            }
            catch (Exception e2)
            {
                Console.WriteLine(e2);
            }
        }

        private string GetVersion()
        {
            try
            {
                System.Diagnostics.FileVersionInfo fv = System.Diagnostics.FileVersionInfo.GetVersionInfo
                   (System.Reflection.Assembly.GetExecutingAssembly().Location);

                return fv.FileVersion.ToString();
            }
            catch (Exception e2)
            {

                Console.WriteLine(e2);
                return string.Empty;
            }
        }

        private void InitMessages()
        {
            lblMessage1stLine.Text = string.Empty;
            lblMessage2ndLine.Text = string.Empty;
        }
        private void ShowVersionNumber()
        {
            try
            {

                lblVersion.Text = GetVersion();
            }
            catch (Exception e2)
            {
                Console.WriteLine(e2);
            }

        }



        private void InitCaptureTimer()
        {
            try
            {
                timerCapture.Elapsed += new System.Timers.ElapsedEventHandler(timerCapture_Tick);
                timerCapture.Interval = 1000;
                timerCapture.Enabled = false;
                timerCapture.AutoReset = true;
            }
            catch (Exception e2)
            {
                Console.WriteLine(e2);
            }
        }


        private void InitDataTimeDisplay()
        {
            try
            {
                timerDateTime.Tick += new EventHandler(timerDateTime_Tick);
                timerDateTime.Interval = 1000;
                timerDateTime.Enabled = true;
                SetDateTimeValues();
            }
            catch (Exception e2)
            {
                Console.WriteLine(e2);
            }
        }

        private void InitUSBcamera()
        {
            try
            {
                _USBcam = new USBcamera(this.Handle);
                _USBcam.Start();

                timerUSBcam.Tick += new EventHandler(timerUSBcam_Tick);
                timerUSBcam.Interval = 250;
                timerUSBcam.Enabled = true;
            }
            catch (Exception e2)
            {
                Console.WriteLine(e2);
            }
        }



        private void InitIPcamera()
        {

            try
            {
                myVlcControl.BeginInit();
                myVlcControl.VlcLibDirectory = new System.IO.DirectoryInfo(Application.StartupPath + @"\VLC"); //Make sure your dir is correct
                myVlcControl.VlcMediaplayerOptions = new[] { "-vv" }; //not sure what this does
                myVlcControl.EndInit();

                myVlcControl.SetMedia(LocalSettings.CamRtspUrl);

                myVlcControl.Play();

                Console.WriteLine("VLC control media set to: " + LocalSettings.CamRtspUrl);


            }
            catch (Exception e2)
            {
                Console.WriteLine(e2);
                //MessageBox.Show(e2.Message);
            }

        }

        private void InitIOB()
        {
            try
            {

                    _ioBoard2000 = new IOB2000_GreenBoard(LocalSettings.IOBcomPort, "Card dispenser");

                    _ioBoard2000.LoopDetectedACar += new Action(LoopDetectedAvehicle);
                    _ioBoard2000.ButtonPushed += new IOB2000_GreenBoard.ButtonPushedDelegate(ButtonPushed);
                    _ioBoard2000.CarLeavedTheLoop += new Action(NoCarDetectedOnTheLoop);
                

            }
            catch (Exception e2)
            {
                Console.WriteLine(e2);
                //MessageBox.Show(e2.Message);
            }
        }


        private void initDispenserDevices()
        {
            try
            {
                _dispenser1 = new SRD2000(LocalSettings.SRD1comPort, 9600,
                    System.IO.Ports.Parity.None, System.IO.Ports.Handshake.None, 8, System.IO.Ports.StopBits.One, "dispenser1");

                _dispenser1.NewCardIsGrabbed += new Action<string, DateTime, int>(NewCardIsGrabbed);
                _dispenser1.CardEmpty += new Action(CardEmpty_Dispenser1);

                _dispenser1.CardEjected += new Action(CardEjected);
                _dispenser1.ErrorOccured += new Action(ErrorOccured_Dispenser1);

            }
            catch (Exception e2)
            {
                Console.WriteLine(e2);
            }

            try
            {
                _dispenser2 = new SRD2000(LocalSettings.SRD2comPort, 9600,
                    System.IO.Ports.Parity.None, System.IO.Ports.Handshake.None, 8, System.IO.Ports.StopBits.One, "dispenser2");

                _dispenser2.NewCardIsGrabbed += new Action<string, DateTime, int>(NewCardIsGrabbed);
                _dispenser2.CardEmpty += new Action(CardEmpty_Dispenser2);
                _dispenser2.CardEjected += new Action(CardEjected);
                _dispenser2.ErrorOccured += new Action(ErrorOccured_Dispenser2);

            }
            catch (Exception e2)
            {
                Console.WriteLine(e2);
            }

        }



        private void NewCardIsGrabbed(string issueString, DateTime issueDateTime, int issueTransitID)
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("Card grabbed: " + issueTransitID);

                _waitingForDriverTotakeTheTicket = false;

                _barrierController.OpenBarrier("NewCardIsGrabbed");

                ShowTextMessage("Gate Barrier", "Opened");

                //You can use this point to finalize the entry becasue you are now sure that the parker took the card
                //SaveEntry_ByDispenser(issueTransitID, issueString, issueDateTime, _currentGate.GateID, _currentUser.UserID, _currentImage1, _currentImage2, null, false, true);

                var sqlConnectionString = $"Server={LocalSettings.SqlDataSource};Database={LocalSettings.SqlInitialCatalog};User Id={LocalSettings.SqlUserId};Password={LocalSettings.SqlUserId}";
                var result = services.GenerateNewHistory(LocalSettings.ParkingID, LocalSettings.GateID, LocalSettings.Location, LocalSettings.Terminal, LocalSettings.SerialNumber, LocalSettings.LocalIPAddress, LocalSettings.AutoLoginUser, sqlConnectionString);

            }
            catch (Exception e2)
            {
                Console.WriteLine(e2);
            }
        }


        private void CardEmpty_Dispenser1()
        {
            ShowTextMessage("Card Empty", "Dispenser 1");

            pictureBoxLedEmpty.Image = new Bitmap(CardDispenserSampleForSP.Properties.Resources.GreenLEDsmallMirrored);
        }

        private void CardEmpty_Dispenser2()
        {
            ShowTextMessage("Card Empty", "Dispenser 2");

            pictureBoxLedEmpty.Image = new Bitmap(CardDispenserSampleForSP.Properties.Resources.GreenLEDsmallMirrored);
        }


        private void CardEjected()
        {
            Console.WriteLine("CardEjected");

            _waitingForDriverTotakeTheTicket = true;
            pictureBoxLedEmpty.Image = new Bitmap(CardDispenserSampleForSP.Properties.Resources.GrayLEDsmallMirrored);

            ShowTextMessage("Thank you", "Please get the card");

        }

        private void ErrorOccured_Dispenser1()
        {
            Console.WriteLine("ErrorOccured_Dispenser1");

            IssueCard(true, "ErrorOccured_Dispenser1");

            _numberOfErrorsOccuredOnDispenser1++;

        }

        private void ErrorOccured_Dispenser2()
        {
            Console.WriteLine("ErrorOccured_Dispenser2");

            IssueCard(true, "ErrorOccured_Dispenser2");
            _numberOfErrorsOccuredOnDispenser2++;

        }


        private void SaveEntry_ByDispenser(int transitID, string issueString, DateTime issueDateTime, int gateID, int userID, Image image1, Image image2, string LPN, bool ticketCaptured, bool ticketIsEjected)
        {

        }


        private void PlayErrorMessage()
        {
            ShowTextMessage("Temporarily unavailable", "Please Press Help Button");
            //_sndPlayer = new SoundPlayer(Properties.Resources.please_press_help_button);
            _sndPlayer.Play();
        }

        private void LoopDetectedAvehicle()
        {
            //if (consequtiveDispenserFailures > 2) return;

            Console.WriteLine("LoopDetectedAvehicle");


            ShowTextMessage("Welcome", "Please Press the Button");

            //WelcomeAudioMessage.wav
            string welcomeFileAddress = Application.StartupPath + "\\WelcomeAudioMessage.wav";
            if (System.IO.File.Exists(welcomeFileAddress))
            {
                _sndPlayer = new SoundPlayer(welcomeFileAddress);
                _sndPlayer.Play();
            }
            else
            {
                //_sndPlayer = new SoundPlayer(Common.Properties.Resources.welcome_please_press_the_button);
                _sndPlayer.Play();
            }


            _waitingForDriverToPushTheButton = true;

        }


        private void ButtonPushed()
        {

            Console.WriteLine("ButtonPushed method called");


            if (!_waitingForDriverToPushTheButton && LocalSettings.LoopDetectionRequired)
            {
                Console.WriteLine("No car is detected on the loop, ticket will not be dispensed");

                return;
            }


            _numberOfErrorsOccuredOnDispenser1 = 0;
            _numberOfErrorsOccuredOnDispenser2 = 0;

            _currentImage1 = null;
            _currentImage2 = null;



            if (this.InvokeRequired)
            {

                this.Invoke(new IOB2000_GreenBoard.ButtonPushedDelegate(ButtonPushed));
            }
            else
            {

                bool res = IssueCard(false, "ButtonPushed");
                if (res)
                    ShowTextMessage("Please wait for the card", string.Empty);


            }

            //_sndPlayer = new SoundPlayer(Common.Properties.Resources.please_take_a_card);
            _sndPlayer.Play();
            UpdateCurrentImages();
        }

        private void UpdateCurrentImages()
        {
            if (myVlcControl.IsPlaying)
                _currentImage1 = GetNewVlcSnapShot(myVlcControl);


            _currentImage2 = _latestUSBcamImage;
        }

        private void timerUSBcam_Tick(object sender, EventArgs e)
        {
            _latestUSBcamImage = _USBcam.getCurrentFrame();
        }

        private Bitmap GetNewVlcSnapShot(Vlc.DotNet.Forms.VlcControl vlcControl)
        {
            try
            {
                Random R = new Random();

                var next = R.NextDouble();

                string tempDirectory = System.IO.Path.Combine(System.Environment.CurrentDirectory, "Temp");

                string fileAddress = tempDirectory + "\\" + next + ".jpg";
                vlcControl.TakeSnapshot(fileAddress);
                return new Bitmap(fileAddress);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }


        }

        private void ShowTextMessage(string firstLine, string secondLine)
        {

            if (lblMessage1stLine.InvokeRequired)
            {
                lblMessage1stLine.BeginInvoke(new Action(() => lblMessage1stLine.Text = firstLine));
            }
            else
            {
                lblMessage1stLine.Text = firstLine;
            }

            if (lblMessage2ndLine.InvokeRequired)
            {
                lblMessage2ndLine.BeginInvoke(new Action(() => lblMessage2ndLine.Text = secondLine));
            }
            else
            {
                lblMessage2ndLine.Text = secondLine;
            }


            PlanClearMessage();

            if (firstLine.Length > 0 || secondLine.Length > 0)
                Console.WriteLine("Message displayed: " + firstLine + ", " + secondLine);
        }

        private bool IssueCard(bool retryWithOtherDevice, string src)
        {

            try
            {
                Console.WriteLine("IssueCard is called by " + src);

                bool issueStartStatus = false;


                if (_numberOfErrorsOccuredOnDispenser1 >= 2 && _numberOfErrorsOccuredOnDispenser2 >= 2)
                {
                    PlayErrorMessage();
                    _numberOfErrorsOccuredOnDispenser1 = 0;
                    _numberOfErrorsOccuredOnDispenser2 = 0;

                    return false;
                }



                DateTime issueDateTime = DateTime.Now;
                if (issueDateTime == DateTime.MinValue)
                    return false;


                //int newTransitID = 123456789;

                //Console.WriteLine("newTransitID is acquired: " + newTransitID);
                ////string issueString = Common.getCardIssueString_RawNumbers(Convert.ToByte(LocalSettings.ParkingID), Convert.ToByte(LocalSettings.GateID), issueDateTime, newTransitID);
                //string issueString ="1234567891234567891234";//22 chars
                //Console.WriteLine("issueString generated: " + issueString);

                var sqlConnectionString = $"Server={LocalSettings.SqlDataSource};Database={LocalSettings.SqlInitialCatalog};User Id={LocalSettings.SqlUserId};Password={LocalSettings.SqlUserId}";



                if (retryWithOtherDevice)
                {
                    if (_lastSentToDispenserNumber == 1)
                    {
                        _lastSentToDispenserNumber = 2;

                        if (_dispenser2 == null)
                        {
                            ErrorOccured_Dispenser2();
                            return false;
                        }
                        Console.WriteLine("Going to send issue command to _dispenser2");
                        var result = services.GenerateNewHistory(LocalSettings.ParkingID, LocalSettings.GateID, LocalSettings.Location, LocalSettings.Terminal, LocalSettings.SerialNumber, LocalSettings.LocalIPAddress, LocalSettings.AutoLoginUser, sqlConnectionString);
                        issueStartStatus = result.ToLower().Contains("success");
                    }
                    else if (_lastSentToDispenserNumber == 2)
                    {
                        _lastSentToDispenserNumber = 1;

                        if (_dispenser1 == null)
                        {
                            ErrorOccured_Dispenser1();
                            return false;
                        }
                        Console.WriteLine("Going to send issue command to _dispenser1");

                        var result = services.GenerateNewHistory(LocalSettings.ParkingID, LocalSettings.GateID, LocalSettings.Location, LocalSettings.Terminal, LocalSettings.SerialNumber, LocalSettings.LocalIPAddress, LocalSettings.AutoLoginUser, sqlConnectionString);
                        issueStartStatus = result.ToLower().Contains("success");
                    }

                }
                else
                {
                    if (_lastSentToDispenserNumber == 1)
                    {
                        var result = services.GenerateNewHistory(LocalSettings.ParkingID, LocalSettings.GateID, LocalSettings.Location, LocalSettings.Terminal, LocalSettings.SerialNumber, LocalSettings.LocalIPAddress, LocalSettings.AutoLoginUser, sqlConnectionString);
                        issueStartStatus = result.ToLower().Contains("success");
                    }
                    else if (_lastSentToDispenserNumber == 2)
                    {
                        var result = services.GenerateNewHistory(LocalSettings.ParkingID, LocalSettings.GateID, LocalSettings.Location, LocalSettings.Terminal, LocalSettings.SerialNumber, LocalSettings.LocalIPAddress, LocalSettings.AutoLoginUser, sqlConnectionString);
                        issueStartStatus = result.ToLower().Contains("success");
                    }

                }


                return issueStartStatus;
            }
            catch (Exception e2)
            {
                Console.WriteLine(e2);
                return false;
            }
        }



        private void NoCarDetectedOnTheLoop()
        {
            Console.WriteLine("NoCarDetectedOnTheLoop");

            _waitingForDriverToPushTheButton = false;

            ShowTextMessage(string.Empty, string.Empty);
        }


        private void CloseBarrier()
        {
            _barrierController.CloseBarrier("Network");
        }



        private void timerDateTime_Tick(object sender, EventArgs e)
        {
            SetDateTimeValues();
        }

        private void timerCapture_Tick(object sender, System.Timers.ElapsedEventArgs e)
        {
            _secondsWaitedBeforeCapture++;
            if (_secondsWaitedBeforeCapture > 5)
            {
                Console.WriteLine("A card was ejected but it should be captured becasue the driver leaved the loop");
                _dispenser1.CaptureCard();
                _dispenser2.CaptureCard();
                _waitingForDriverTotakeTheTicket = false;
                _secondsWaitedBeforeCapture = 0;
                timerCapture.Enabled = false;
            }

        }



        private void SetDateTimeValues()
        {
            lblDate.Text = DateTime.Now.Date.ToShortDateString();
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void SetDateTimepositions()
        {
            lblTime.Left = (this.Width - lblTime.Width) / 2;
            lblDate.Left = (this.Width - lblDate.Width) / 2;
            lblMessage1stLine.Left = (this.Width - lblMessage1stLine.Width) / 2;
            lblMessage2ndLine.Left = (this.Width - lblMessage2ndLine.Width) / 2;

        }



        private void frmMain_Paint(object sender, PaintEventArgs e)
        {
            SetDateTimepositions();
        }




        private void pictureBoxCloseButton_Click_1(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void pictureBoxMaximizeButton_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void pictureBoxMinimizeButton_Click_1(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Minimized;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Console.WriteLine("Dispenser is closing");

                if (_ioBoard2000 != null)
                    _ioBoard2000.CloseComPort();

                if (_dispenser1 != null)
                    _dispenser1.CloseComPort();

                if (_dispenser2 != null)
                    _dispenser2.CloseComPort();

                if (myVlcControl.IsPlaying)
                {
                    myVlcControl.Stop();
                }
                myVlcControl.Dispose();

            }
            catch (Exception e2)
            {
                Console.WriteLine(e2);
                //MessageBox.Show(e2.Message);
            }
        }

        private void pictureBoxLoginLogoutButton_Click(object sender, EventArgs e)
        {

            frmSettings settingsForm = new frmSettings();
            settingsForm.ShowDialog();


        }


    }
}
