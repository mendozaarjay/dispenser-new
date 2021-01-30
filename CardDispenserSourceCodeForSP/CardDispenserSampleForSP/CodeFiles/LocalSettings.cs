using System.Configuration;
using System;


namespace CardDispenserSampleForSP
{
    public sealed class LocalSettings
    {

        public static string ParkingID { get; set; }
        public static string GateID { get; set; }
        public static string CarType { get; set; }


        public static string CamRtspUrl { get; set; }
        public static string CamUsername { get; set; }
        public static string CamPassword { get; set; }
        public static string IOBcomPort { get; set; }
        public static string IOBbaudRate { get; set; }
        public static string SRD1comPort { get; set; }
        public static string SRD2comPort { get; set; }
        public static string SBPbaudRate { get; set; }

        public static string ControlCenterIP { get; set; }

        public static string AutoLoginUser { get; set; }
        public static string AutoLoginPassword { get; set; }
        public static bool AnnounceControlCenter { get; set; }

        public static string SqlDataSource { get; set; }
        public static string SqlInitialCatalog { get; set; }
        public static string SqlUserId { get; set; }
        public static string SqlPassword { get; set; }

        public static string SgbBarrierComPort { get; set; }
        public static string SgbBarrierBaudRate { get; set; }
        public static string BarrierControllerType { get; set; }
        public static string Gp90ComPort { get; set; }


        public static string IobInputFromButton { get; set; }
        public static string IobInputFromLoop { get; set; }
        public static string IpCameraStream { get; set; }

        public static string IobType { get; set; }

        public static bool LoopDetectionRequired { get; set; }
        public static bool EnableNetworkListener { get; set; }
        public static int ListenOnPort { get; set; }

        public static string BarrierControllerIp { get; set; }

        public static bool DontSaveFullSizeImagesOnTheServer { get; set; }

        public static string ImagesSaveFolder { get; set; }
        public static string LocalIPAddress { get; set; }
        public static string SerialNumber { get; set; }
        public static string Terminal { get; set; }
        public static string Location { get; set; }
        public static void LoadSettings()
        {
            Configuration cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            AppSettingsSection appS = (System.Configuration.AppSettingsSection)cfg.GetSection("appSettings");
            ParkingID = appS.Settings["ParkingID"].Value;
            GateID = appS.Settings["GateID"].Value;
            CarType = appS.Settings["CarType"].Value;
            CamRtspUrl = appS.Settings["CamIPaddress"].Value;
            CamUsername = appS.Settings["CamUsername"].Value;
            CamPassword = appS.Settings["CamPassword"].Value;
            IOBcomPort = appS.Settings["IOBcomPort"].Value;
            IOBbaudRate = appS.Settings["IOBbaudRate"].Value;
            SRD1comPort = appS.Settings["SRD1comPort"].Value;
            SRD2comPort = appS.Settings["SRD2comPort"].Value;
            SBPbaudRate = appS.Settings["SBPbaudRate"].Value;
            AutoLoginUser = appS.Settings["AutoLoginUser"].Value;
            AutoLoginPassword = appS.Settings["AutoLoginPassword"].Value;
            AnnounceControlCenter = System.Convert.ToBoolean(appS.Settings["AnnounceControlCenter"].Value);
            SqlDataSource = appS.Settings["SqlDataSource"].Value;
            SqlInitialCatalog = appS.Settings["SqlInitialCatalog"].Value;
            SqlUserId = appS.Settings["SqlUserId"].Value;
            SqlPassword = appS.Settings["SqlPassword"].Value;
            ControlCenterIP = appS.Settings["ControlCenterIP"].Value;
            SgbBarrierComPort = appS.Settings["SgbBarrierComPort"].Value;
            SgbBarrierBaudRate = appS.Settings["SgbBarrierBaudRate"].Value;
            BarrierControllerType = appS.Settings["BarrierControllerType"].Value;
            Gp90ComPort = appS.Settings["Gp90ComPort"].Value;
            IobInputFromButton = appS.Settings["IobInputFromButton"].Value;
            IobInputFromLoop = appS.Settings["IobInputFromLoop"].Value;
            IpCameraStream = appS.Settings["IpCameraStream"].Value;
            LoopDetectionRequired = System.Convert.ToBoolean(appS.Settings["LoopDetectionRequired"].Value);
            EnableNetworkListener = System.Convert.ToBoolean(appS.Settings["EnableNetworkListener"].Value);
            ListenOnPort = System.Convert.ToInt32(appS.Settings["ListenOnPort"].Value);

            IobType = appS.Settings["IobType"].Value;
            BarrierControllerIp = appS.Settings["BarrierControllerIp"].Value;

            DontSaveFullSizeImagesOnTheServer = System.Convert.ToBoolean(appS.Settings["DontSaveFullSizeImagesOnTheServer"].Value);
            ImagesSaveFolder = appS.Settings["ImagesSaveFolder"].Value;
            LocalIPAddress = appS.Settings["LocalIPAddress"].Value;
            SerialNumber = appS.Settings["SerialNumber"].Value;
            Terminal = appS.Settings["Terminal"].Value;
            Location = appS.Settings["Location"].Value;
        }

        public static void SaveSettings()
        {
            Configuration cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            AppSettingsSection appS = (System.Configuration.AppSettingsSection)cfg.GetSection("appSettings");
            appS.Settings["ParkingID"].Value = ParkingID;
            appS.Settings["GateID"].Value = GateID;
            appS.Settings["CarType"].Value = CarType;
            appS.Settings["CamIPaddress"].Value = CamRtspUrl;
            appS.Settings["CamUsername"].Value = CamUsername;
            appS.Settings["CamPassword"].Value = CamPassword;
            appS.Settings["IOBcomPort"].Value = IOBcomPort;
            appS.Settings["IOBbaudRate"].Value = IOBbaudRate;
            appS.Settings["SRD1comPort"].Value = SRD1comPort;
            appS.Settings["SRD2comPort"].Value = SRD2comPort;
            appS.Settings["SBPbaudRate"].Value = SBPbaudRate;
            appS.Settings["AutoLoginUser"].Value = AutoLoginUser;
            appS.Settings["AutoLoginPassword"].Value = AutoLoginPassword;
            appS.Settings["AnnounceControlCenter"].Value = AnnounceControlCenter.ToString();
            appS.Settings["SqlDataSource"].Value = SqlDataSource;
            appS.Settings["SqlInitialCatalog"].Value = SqlInitialCatalog;
            appS.Settings["SqlUserId"].Value = SqlUserId;
            appS.Settings["SqlPassword"].Value = SqlPassword;
            appS.Settings["ControlCenterIP"].Value = ControlCenterIP;
            appS.Settings["SgbBarrierComPort"].Value = SgbBarrierComPort;
            appS.Settings["SgbBarrierBaudRate"].Value = SgbBarrierBaudRate;
            appS.Settings["BarrierControllerType"].Value = BarrierControllerType;
            appS.Settings["Gp90ComPort"].Value = Gp90ComPort;
            appS.Settings["IobInputFromButton"].Value = IobInputFromButton.ToString();
            appS.Settings["IobInputFromLoop"].Value = IobInputFromLoop.ToString();
            appS.Settings["IpCameraStream"].Value = IpCameraStream.ToString();
            appS.Settings["IobType"].Value = IobType.ToString();
            appS.Settings["LoopDetectionRequired"].Value = LoopDetectionRequired.ToString();
            appS.Settings["EnableNetworkListener"].Value = EnableNetworkListener.ToString();
            appS.Settings["ListenOnPort"].Value = ListenOnPort.ToString();
            appS.Settings["BarrierControllerIp"].Value = BarrierControllerIp;
            appS.Settings["DontSaveFullSizeImagesOnTheServer"].Value = DontSaveFullSizeImagesOnTheServer.ToString();
            appS.Settings["ImagesSaveFolder"].Value = ImagesSaveFolder;
            appS.Settings["LocalIPAddress"].Value = LocalIPAddress;
            appS.Settings["SerialNumber"].Value = SerialNumber;
            appS.Settings["Terminal"].Value = Terminal;
            appS.Settings["Location"].Value = Location;
            cfg.Save();
        }
    }
}
