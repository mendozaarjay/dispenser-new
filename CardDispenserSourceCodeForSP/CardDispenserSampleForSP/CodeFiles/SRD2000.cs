using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace CardDispenserSampleForSP
{


    public class SRD2000
    {
        DateTime _lastDtOfIssueRequest;


        int _numberOfgetSensorsSent = 0;
        bool _sensorStatusReceived = false;

        System.Timers.Timer timerCheckSensors;
        int _numberOfClearStatusOnSensors = 0;

        bool _issueCardRequested = false;

        bool _cardOnLastSensor = false;

        bool _cardReadyRequested = false;

        bool _cardEjected = false;


        DateTime _lastDtOfReadyRequest;



        System.IO.Ports.SerialPort _sPortTD;
        string _issueString = string.Empty;
        DateTime _issueDateTime = DateTime.MinValue;
        int _issueTransitID = -1;
        string _issueGateName = string.Empty;

        List<string> _accumulatedMessage = new List<string>();


        public event Action<string, DateTime, int> NewCardIsGrabbed;
        public event Action ErrorOccured;
        public event Action CardEjected;
        public event Action CardEmpty;
        //public event Action<string, DateTime, int, string> NewCardCaptured;


        string _dispenserName;

        bool successfullyInitialized = false;



        public SRD2000(string portName, int baudRate, Parity parity, Handshake handshake, int dataBits, StopBits stopBits, string dispenserName)
        {
            try
            {
                if (portName == string.Empty)
                    return;


                _dispenserName = dispenserName;

                _sPortTD = new System.IO.Ports.SerialPort();

                _sPortTD.PortName = portName;
                _sPortTD.BaudRate = baudRate;
                _sPortTD.Parity = parity;
                _sPortTD.Handshake = handshake;
                _sPortTD.DataBits = dataBits;
                _sPortTD.StopBits = stopBits;
                _sPortTD.ReadTimeout = 500;
                _sPortTD.WriteTimeout = 500;
                _sPortTD.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(sPortTD_DataReceivedHandler);
                _sPortTD.Open();

                Console.WriteLine(portName + " opened successfuly for " + dispenserName);

                CaptureCard();

                timerCheckSensors = new System.Timers.Timer(500);
                timerCheckSensors.Elapsed += timerCheckSensors_OnTimedEvent;
                timerCheckSensors.AutoReset = true;
                timerCheckSensors.Enabled = false;



            }
            catch (Exception e2)
            {
                Console.WriteLine(e2);
            }

        }


        private void ResetVariables()
        {
            _sensorStatusReceived = false;
            _numberOfgetSensorsSent = 0;
            _numberOfClearStatusOnSensors = 0;

            timerCheckSensors.Enabled = false;

            _issueString = string.Empty;
            _issueDateTime = DateTime.MinValue;
            _issueTransitID = -1;


            _issueCardRequested = false;
            //_cardOnOneRemainedToLastSensor = false;
            _cardOnLastSensor = false;
            _cardReadyRequested = false;
            _cardEjected = false;
        }


        private void RequestAreadyCard()
        {
            _cardReadyRequested = true;
            _lastDtOfReadyRequest = DateTime.Now;
            byte[] bBuf = new byte[5];

            bBuf[0] = 0x02;
            bBuf[1] = 0x21;
            bBuf[2] = 0x35;
            bBuf[3] = 0x03;
            bBuf[4] = Common.CalculateXorForSRD2000(bBuf);
            //bBuf[4] = 0xFF;

            SendToSRD2000(bBuf);

        }


        public void CaptureCard()
        {

            byte[] bBuf = new byte[5];

            bBuf[0] = 0x02;
            bBuf[1] = 0x21;
            bBuf[2] = 0x38;
            bBuf[3] = 0x03;
            bBuf[4] = Common.CalculateXorForSRD2000(bBuf);
            //bBuf[4] = 0xFF;

            SendToSRD2000(bBuf);

        }


        public void WriteOnTheCardToSimulateTheUid(string issueString)
        {
            try
            {


                byte[] bytes = new byte[29];


                bytes[0] = 0x02;//STX

                bytes[1] = 0x39;
                bytes[2] = 0x36;


                //A 0x30 is added to all of the date bytes to prevent conflicting wiht stx and etx
                for (int i = 0; i < 22; i++)
                {
                    bytes[i + 3] = (byte)(0x30 + Convert.ToByte(issueString.Substring(i, 1)));
                }


                bytes[25] = (byte)(0x30 + Convert.ToByte(0));//unused byte
                bytes[26] = (byte)(0x30 + Convert.ToByte(0));//unused byte


                bytes[27] = 0x03;//ETX
                bytes[28] = Common.CalculateXorForSRD2000(bytes);

                SendToSRD2000(bytes);




            }
            catch (Exception e2)
            {
                //Console.WriteLine(e2);
            }
        }


        private void EjectCard()
        {

            byte[] bBuf = new byte[5];

            bBuf[0] = 0x02;
            bBuf[1] = 0x21;
            bBuf[2] = 0x40;
            bBuf[3] = 0x03;
            bBuf[4] = Common.CalculateXorForSRD2000(bBuf);
            //bBuf[4] = 0xFF;

            SendToSRD2000(bBuf);

        }


        public void QuerySensors()
        {
            //Console.WriteLine("QueryDispenserSensors is called");

            //_sensorResultReceived = false;

            byte[] bytes = new byte[5];

            bytes[0] = 0x02;
            bytes[1] = 0x21;
            bytes[2] = 0x32;
            bytes[3] = 0x03;
            bytes[4] = Common.CalculateXorForSRD2000(bytes);

            SendToSRD2000(bytes);

        }


        //public void QueryFirmware()
        //{
        //    Console.WriteLine("SRD-2000 QueryFirmware is called");

        //    //_sensorResultReceived = false;

        //    byte[] bytes = new byte[5];

        //    bytes[0] = 0x02;
        //    bytes[1] = 0x20;
        //    bytes[2] = 0x31;
        //    bytes[3] = 0x03;
        //    bytes[4] = Common.CalculateXorForSRD2000(bytes);

        //    SendToSRD2000(bytes);

        //}



        private void timerCheckSensors_OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            if (_numberOfgetSensorsSent > 5 && _sensorStatusReceived == false)
            {
                ResetVariables();
                ErrorOccured?.Invoke();
                return;
            }

            QuerySensors();
            _numberOfgetSensorsSent++;
        }



        public void CloseComPort()
        {
            if (_sPortTD == null)
                return;


            if (_sPortTD.IsOpen)
                _sPortTD.Close();


            Console.WriteLine("Dispenser CloseComPort called. Current port status: " + _sPortTD.IsOpen);

            if (_sPortTD.IsOpen)
            {
                _sPortTD.Close();
                Console.WriteLine("Dispenser port closed");
            }


        }

        private void sPortTD_DataReceivedHandler(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

            System.IO.Ports.SerialPort sp = (System.IO.Ports.SerialPort)sender;
            int length = sp.BytesToRead;
            //Console.WriteLine(length);
            byte[] buf = new byte[length];

            for (int i = 0; i < length; i++)
            {
                buf[i] = (byte)_sPortTD.ReadByte();
            }


            List<string> receivedMessage = new List<string>();

            foreach (byte item in buf)
            {
                receivedMessage.Add(item.ToString("X2"));
            }

            //Console.WriteLine("A message received from SRD2000: " + Common.ConvertStringArrayToString(receivedMessage.ToArray(), true));


            if (receivedMessage.Count == 0)
                return;


            if (receivedMessage.Contains("02"/*STX*/))
                _accumulatedMessage.Clear();


            _accumulatedMessage.AddRange(receivedMessage);



            if (_accumulatedMessage.Contains("02"/*STX*/) &&
                  _accumulatedMessage.Contains("03"/*ETX*/))//it is complete now
            {
                int indexOfSTX = GetFirstIndexOfString(_accumulatedMessage, "02");
                if (indexOfSTX != 0)
                    _accumulatedMessage.RemoveRange(0, indexOfSTX);//remove garbages before EA

                int indexOfETX = GetFirstIndexOfString(_accumulatedMessage, "03");
                if (indexOfETX != _accumulatedMessage.Count - 1)
                    _accumulatedMessage.RemoveRange(indexOfETX + 1, _accumulatedMessage.Count - indexOfETX - 1);//remove garbages after EB

                ProcessAcompleteMessage(_accumulatedMessage);
                receivedMessage.Clear();
                _accumulatedMessage.Clear();
            }


        }

        int GetFirstIndexOfString(List<string> lst, string str)
        {
            for (int i = 0; i < lst.Count; i++)
            {
                if (lst[i].Equals(str)) // (you use the word "contains". either equals or indexof might be appropriate)
                {
                    return i;
                }
            }
            return -1;//not found
        }

        private void ProcessAcompleteMessage(List<string> msg)//old name: gf_Device_Get_SRD2000
        {

            //Console.WriteLine("SRD2000: (" + _dispenserName + "):" + Common.ConvertStringArrayToString(msg.ToArray(), true));
            //#if DEBUG
            //            Console.WriteLine("SRD2000: (" + _dispenserName + "):" + Common.ConvertStringArrayToString(msg.ToArray(), true));
            //#endif

            if (msg.Count < 4)
            {
                //QueryDispenserSensors();
                return;
            }

            successfullyInitialized = true;



            if (msg[2] == "32")//a response to get sensor
            {
                if (timerCheckSensors.Enabled == false)
                    return;

                if (msg.Count < 6)
                    return;

                _sensorStatusReceived = true;

                if (msg[5] == "31") _cardOnLastSensor = true; else _cardOnLastSensor = false;

                Console.WriteLine("sensor values: " + "(s1): " + msg[4].Substring(1, 1) +
                    ", (s2): " + msg[5].Substring(1, 1) + ", (s3): " +
                    msg[6].Substring(1, 1) + ", (s4): " + msg[7].Substring(1, 1))
                    ;

                if (msg[4] == "30" && msg[5] == "30" && msg[6] == "30" && msg[7] == "31" && _issueCardRequested)
                    _numberOfClearStatusOnSensors++;

                DoNextStepBasedOnSensorValues(msg);
            }
            else if (msg[2] == "35")//a response to card issue ready
            {
                //_sensorResultReceived = true;

                if (msg[3] == "30")//issue ready successful
                {
                    Console.WriteLine("Card issue ready successful");
                    Console.WriteLine("Card issue ready successful");

                }

                if (msg[3] == "31")//error on write
                {
                    Console.WriteLine("Error on card issue ready");
                    Console.WriteLine("Error on card issue ready");
                }

                if (msg[3] == "32")//error on write
                {
                    Console.WriteLine("No card status returned after sending card issue ready");
                    Console.WriteLine("No card status returned after sending card issue ready");

                    CardEmpty?.Invoke();
                }

            }
            else if (msg[2] == "36")//a response to card write
            {
                //_sensorResultReceived = true;

                if (msg[3] == "30")//write successful
                {
                    Console.WriteLine("Card write successful");
                    Console.WriteLine("Card write successful");

                }

                if (msg[3] == "31")//error on write
                {
                    Console.WriteLine("Error on card write");
                    Console.WriteLine("Error on card write");

                }

            }
            else
            {
                Console.WriteLine("Not interpreted message from " + _dispenserName + ": " + msg.ToArray().ToString());
            }

        }

        private void DoNextStepBasedOnSensorValues(List<string> msg)
        {
            if (_issueCardRequested)
            {
                Console.WriteLine("A response to get sensor status command is received and Issue Card is Requested");

                if (_cardOnLastSensor /*&& _cardOnOneRemainedToLastSensor*/ && !_cardReadyRequested)
                {
                    Console.WriteLine("Going to CaptureCard");
                    System.Threading.Thread.Sleep(200);
                    CaptureCard();
                    System.Threading.Thread.Sleep(2000);
                }
                else if (!_cardEjected && !_cardOnLastSensor && !_cardReadyRequested)
                {
                    Console.WriteLine("RequestAreadyCard");
                    System.Threading.Thread.Sleep(100);
                    RequestAreadyCard();
                    System.Threading.Thread.Sleep(1200);
                }
                else if (_cardOnLastSensor /*&& _cardOnOneRemainedToLastSensor*/ && _cardReadyRequested && !_cardEjected)
                {
                    Console.WriteLine("Going to write on the card and eject");

                    WriteOnTheCardToSimulateTheUid(_issueString);
                    System.Threading.Thread.Sleep(100);
                    EjectCard();
                    //System.Threading.Thread.Sleep(500);
                    _cardEjected = true;
                    CardEjected?.Invoke();

                }
                else if (!_cardEjected && !_cardOnLastSensor && _cardReadyRequested && (DateTime.Now - _lastDtOfReadyRequest).TotalMilliseconds >= 3000)
                {

                    Console.WriteLine("3000 milliseconds passed and the card still not ready");

                    CaptureCard();//ususaly in this situation there is no card to capture but this is just a recheck
                    System.Threading.Thread.Sleep(2000);
                    ResetVariables();
                    ErrorOccured?.Invoke();

                }
                else if (_cardEjected && !_cardOnLastSensor && _numberOfClearStatusOnSensors > 2)//then card is taken by the driver
                {
                    Console.WriteLine("card is taken by the parker");

                    NewCardIsGrabbed?.Invoke(_issueString, _issueDateTime, _issueTransitID);
                    ResetVariables();
                }
                else if (_cardEjected && _cardOnLastSensor && (DateTime.Now - _lastDtOfReadyRequest).TotalMilliseconds >= 10000)
                {

                    Console.WriteLine("10 seconds passed and the parker did not take the card yet, going to capture the card");

                    CaptureCard();
                    System.Threading.Thread.Sleep(2000);
                    ResetVariables();

                }
                else
                {
                    Console.WriteLine("None of conditions in DoNextStepBasedOnSensorValues");
                }

            }
        }


        public bool IssueCardEntranceGate(string issueString, DateTime issueDateTime, int newTransitID, string gateName)
        {
            if ((DateTime.Now - _lastDtOfIssueRequest).TotalSeconds < 4)
            {
                Console.WriteLine("Issue requested in less then 4 seconds then it will be ignored");
                return false;
            }

            if (!successfullyInitialized)
            {
                ErrorOccured?.Invoke();
                return false;
            }

            Console.WriteLine("IssueCard is called for transitID: " + newTransitID + ", issue string: " + issueString);
            ResetVariables();


            _issueDateTime = issueDateTime;
            _issueString = issueString;
            _issueTransitID = newTransitID;
            _issueGateName = gateName;

            _issueCardRequested = true;
            _lastDtOfIssueRequest = DateTime.Now;
            EnableTimerSensorStates();

            return true;
        }


        public void EnableTimerSensorStates()
        {
            timerCheckSensors.Enabled = true;
        }




        private void SendToSRD2000(byte[] bytes)
        {
            try
            {
                if (_sPortTD.IsOpen == false)
                {
                    Console.WriteLine("SendToSRD2000 is called but port is closed");
                    return;
                }
                _sPortTD.Write(bytes, 0, bytes.Length);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }







    }
}
