using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Media;
using System.ServiceModel;

namespace CardDispenserSampleForSP
{
    public class BarrierController
    {
        static SerialPort _sPortBarrier;

        static List<string> _accumulatedReceivedMessageSgbType = new List<string>();

        static string _controllerType;
        static string _controllerIp;
        static bool _playEnglishBarrierOpenedMessage;
        //LpnDisplay _ld;
        static bool SuccessfullyInitialized = false;

        public BarrierController(bool playEnglishBarrierOpenedMessage, string SgbComPort, string controllerType, string controllerIp/*, IOB1000_GreenBoard IOB*/)
        {


            _controllerType = controllerType;
            Console.WriteLine("barrierController type is " + controllerType);
            _controllerIp = controllerIp;
            _playEnglishBarrierOpenedMessage = playEnglishBarrierOpenedMessage;


            if (SgbComPort == string.Empty)
                return;

            try
            {
                _sPortBarrier = new System.IO.Ports.SerialPort();

                _sPortBarrier.PortName = SgbComPort;
                _sPortBarrier.BaudRate = 9600;
                _sPortBarrier.Parity = Parity.None;
                _sPortBarrier.Handshake = Handshake.None;
                _sPortBarrier.DataBits = 8;
                _sPortBarrier.StopBits = StopBits.One;
                _sPortBarrier.ReadTimeout = 1000;
                _sPortBarrier.WriteTimeout = 1000;

                SuccessfullyInitialized = true;

                Console.WriteLine(SgbComPort + " opened for barrier controller");

            }
            catch (Exception e2)
            {
                Console.WriteLine(e2);
            }



        }


        public void OpenBarrier(string commandSource)
        {


            Console.WriteLine("OpenBarrier called by " + commandSource);


            if (IsSerialBarrierSgbType())
            {
                OpenSgbBarrierDirectly(commandSource);
            }
            else
            {
                Console.WriteLine("barrier type is " + _controllerType + " !!!");
            }

        }


        private void OpenSgbBarrierDirectly(string commandSource)
        {


            Console.WriteLine("OpenSgbBarrierDirectly called by " + commandSource);

            OpenSgbBarrier(_sPortBarrier);
            System.Threading.Thread.Sleep(150);

            OpenSgbBarrier(_sPortBarrier);
            System.Threading.Thread.Sleep(150);

            OpenSgbBarrier(_sPortBarrier);
            System.Threading.Thread.Sleep(150);

            OpenSgbBarrier(_sPortBarrier);


        }

        public void CloseBarrier(string commandSource)
        {


            Console.WriteLine("CloseBarrier called by " + commandSource);

            if (IsSerialBarrierSgbType())
            {
                CloseSgbBarrier(_sPortBarrier);
            }

        }


        private void OpenSgbBarrier(SerialPort sp)
        {
            try
            {
                Console.WriteLine("It is going to send Open command to SGB");

                //sp.Open();
                if (!SuccessfullyInitialized)
                    return;

                if (!_sPortBarrier.IsOpen)
                    _sPortBarrier.Open();

                byte[] bytes = new byte[9];

                bytes[0] = 0x2;
                bytes[1] = 0x47;
                bytes[2] = 0x41;
                bytes[3] = 0x54;
                bytes[4] = 0x45;
                bytes[5] = 0x20;
                bytes[6] = 0x55;
                bytes[7] = 0x50;
                bytes[8] = 0x3;


                SendBytesToSgbBarrier(sp, bytes);

                Console.WriteLine("Open command sent to SGB");
                //sp.Close();
                _sPortBarrier.Close();

            }
            catch (Exception e2)
            {

                Console.WriteLine(e2);
            }
        }

        private void CloseSgbBarrier(SerialPort sp)
        {
            try
            {
                //sp.Open();
                if (!SuccessfullyInitialized)
                    return;

                _sPortBarrier.Open();

                byte[] bytes = new byte[11];

                bytes[0] = 0x2;
                bytes[1] = 0x47;
                bytes[2] = 0x41;
                bytes[3] = 0x54;
                bytes[4] = 0x45;
                bytes[5] = 0x20;
                bytes[6] = 0x44;
                bytes[7] = 0x4f;
                bytes[8] = 0x57;
                bytes[9] = 0x4e;
                bytes[10] = 0x3;

                SendBytesToSgbBarrier(sp, bytes);
                //sp.Close();
                _sPortBarrier.Close();

            }
            catch (Exception e2)
            {
                Console.WriteLine(e2);
            }
        }

        private void SendBytesToSgbBarrier(SerialPort sp, byte[] bytes)
        {
            if (sp.IsOpen == false)
            {
                Console.WriteLine("SendBytesToSgbBarrier is callled but port is closed");
                return;
            }
            // According to the barrier manufacturer recommendation, we need to wait 5 milliseconds delay after sending each byte, unless it would be unstable and sometimes cannt receive the commands correctly
            for (int i = 0; i < bytes.Length; i++)
            {
                System.Threading.Thread.Sleep(5);
                sp.Write(new byte[] { bytes[i] }, 0, 1);
            }
        }


        private bool IsSerialBarrierIobType()
        {
            if (_controllerType == "IOB")
            {
                Console.WriteLine("Barrier is IOB type");
                return true;
            }                
            else
                return false;
        }

        private bool IsSerialBarrierSgbType()
        {
            if (_controllerType == "SGB")
            {
                Console.WriteLine("Barrier is SGB type");
                return true;
            }            
            else
                return false;
        }

        private bool IsBarrierNetworkType()
        {
            if (_controllerType == "Network")
            {
                Console.WriteLine("Barrier is network type");
                return true;
            }                
            else
                return false;
        }


    }
}
