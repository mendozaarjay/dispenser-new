using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Media;

namespace CardDispenserSampleForSP
{
    public class IOB2000_GreenBoard
    {
        public delegate void myDelegate();

        System.Timers.Timer timerQueryIobInputs;

        System.IO.Ports.SerialPort _sPortIOB;

        public event Action CarLeavedTheLoop;
        public event Action LoopDetectedACar;



        public delegate void ButtonPushedDelegate();
        public event ButtonPushedDelegate ButtonPushed;


        List<string> _accumulatedMessage = new List<string>();


        string lastInputStatusFromLoop = "30";//30 means that at first no car is detected on the loop (supposed that input was off)
        string lastInputStatusFromButton = "30";//30 means that at first no car is detected on the loop (supposed that input was off)

        

        public IOB2000_GreenBoard(string portName, string caller)
        {
            try
            {
                Console.WriteLine("IOB2000_GreenBoard is called by: " + caller);


                _sPortIOB = new System.IO.Ports.SerialPort();

                _sPortIOB.PortName = portName;
                _sPortIOB.BaudRate = 115200;
                _sPortIOB.Parity = Parity.None;
                _sPortIOB.Handshake = Handshake.None;
                _sPortIOB.DataBits = 8;
                _sPortIOB.StopBits = StopBits.One;
                _sPortIOB.ReadTimeout = 500;
                _sPortIOB.WriteTimeout = 500;
                _sPortIOB.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(sPortIOB_DataReceivedHandler);
                _sPortIOB.Open();

                //EnableIobReport(); //this commands will force the IOB to report input/output statuses regularely

                timerQueryIobInputs = new System.Timers.Timer(500);
                timerQueryIobInputs.Elapsed += timerCheckLastAutoReport_OnTimedEvent;
                timerQueryIobInputs.AutoReset = true;
                timerQueryIobInputs.Enabled = true;

                Console.WriteLine("IOB2000_GreenBoard constructor executed with no error on: " + portName + "for " + caller);

            }
            catch (Exception e)
            {
                Console.WriteLine("Error when construcing IOB2000_GreenBoard", e);
            }
        }


        private void timerCheckLastAutoReport_OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            QueryIobInputs();
        }


        private void sPortIOB_DataReceivedHandler(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (_sPortIOB.IsOpen != true)//form is closing
            {
                Console.WriteLine("A data was received by sPortIOB_DataReceivedHandler, but _sPortIOB.IsOpen != true.");
                return;
            }


            System.IO.Ports.SerialPort sp = (System.IO.Ports.SerialPort)sender;
            int length = sp.BytesToRead;
            //Console.WriteLine(length);
            byte[] buf = new byte[length];

            for (int i = 0; i < length; i++)
            {
                buf[i] = (byte)_sPortIOB.ReadByte();
            }

            List<string> receivedMessage = new List<string>();

            foreach (byte item in buf)
            {
                receivedMessage.Add(item.ToString("X2"));
            }



            if (receivedMessage[0] == "02")
                _accumulatedMessage.Clear();


            _accumulatedMessage.AddRange(receivedMessage);




            if (_accumulatedMessage[0] == "02"/*STX*/ &&
                  _accumulatedMessage[_accumulatedMessage.Count - 1] == "03"/*ETX*/)//it is complete now
            {

                ProcessAcompleteMessage(_accumulatedMessage);
            }



        }


        void ProcessAcompleteMessage(List<string> completeMsg)
        {

            if (completeMsg.Count < 4) return;

            DecideAboutLoop(completeMsg[2]);
            DecideAboutButton(completeMsg[5]);

        }



        void DecideAboutLoop(string state)
        {
            try
            {

                if (lastInputStatusFromLoop == "30" && state == "31")//Input 3 triggered( on)
                {
                    LoopDetectedACar?.Invoke();
                    TurnOnButtonLED();

                }
                else if (lastInputStatusFromLoop == "31" && state == "30")//Input 3 trigger went off
                {
                    CarLeavedTheLoop?.Invoke();
                    TurnOffButtonLED();
                }

                lastInputStatusFromLoop = state;

            }
            catch (Exception e2)
            {
                Console.WriteLine(e2);
            }
        }


        void DecideAboutButton(string state)
        {
            try
            {

                if (lastInputStatusFromButton == "30" && state == "31")//Input 3 triggered( on)
                {
                    ButtonPushed?.Invoke();
                    TurnOffButtonLED();
                }


                lastInputStatusFromButton = state;

            }
            catch (Exception e2)
            {
                Console.WriteLine(e2);
            }
        }



        private void QueryIobInputs()
        {
            if (!_sPortIOB.IsOpen)
            {
                Console.WriteLine("QueryIobInputs is called but _sPortIOB.IsOpen==false");
                try
                {
                    _sPortIOB.Open();
                }
                catch (Exception e)
                {
                    Console.WriteLine("_sPortIOB.Open() was called again but an error occured: " + e.Message);
                    return;
                }
            }


            byte[] bytes = new byte[3];

            bytes[0] = 0x2;
            bytes[1] = 0x53;//'S'
            bytes[2] = 0x3;

            _sPortIOB.Write(bytes, 0, bytes.Length);
        }

        private void TurnOnButtonLED()
        {
            byte[] data = new byte[] { 0x2, 0x42, 0x3 };
            _sPortIOB.Write(data, 0, data.Length);
        }

        private void TurnOffButtonLED()
        {
            byte[] data = new byte[] { 0x2, 0x43, 0x3 };
            _sPortIOB.Write(data, 0, data.Length);
        }

        public void OpenEntranceBarrier()
        {
            byte[] data = new byte[] { 0x2, 0x55, 0x3 };
            _sPortIOB.Write(data, 0, data.Length);
        }

        public void CloseEntranceBarrier()
        {
            byte[] data = new byte[] { 0x2, 0x44, 0x3 };
            _sPortIOB.Write(data, 0, data.Length);


        }


        public void CloseComPort()
        {
            if (timerQueryIobInputs == null)
                return;

            Console.WriteLine("IOB2000 CloseComPort called. Current port status: " + _sPortIOB.IsOpen);
            timerQueryIobInputs.Enabled = false;
            if (_sPortIOB.IsOpen)
            {
                _sPortIOB.Close();
                Console.WriteLine("IOB2000 port closed");
            }

        }

    }
}
