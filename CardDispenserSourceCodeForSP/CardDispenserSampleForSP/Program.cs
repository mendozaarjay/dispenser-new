using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;


namespace CardDispenserSampleForSP.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
      {
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);


            AppDomain.CurrentDomain.UnhandledException+= new UnhandledExceptionEventHandler(MyHandler);

            Console.WriteLine("Dispenser is starting");


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            LocalSettings.LoadSettings();


            string tempDirectory = System.IO.Path.Combine(System.Environment.CurrentDirectory, "Temp");

            DirectoryInfo dirInfo = new DirectoryInfo(tempDirectory);
            if (!dirInfo.Exists)
            {
                try
                {
                    dirInfo.Create();
                }
                catch (System.IO.IOException ioEx)
                {
                    string strMessage = "Failed to create the Temp directory. Please contact the software vendor.";
                    strMessage = string.Format("{0}\n\n{1}", strMessage, ioEx.Message);
                    Console.WriteLine(strMessage);
                }
                catch (System.Exception sysEx)
                {
                    string strMessage = "Failed to create the Temp directory. Please contact the software vendor.";
                    strMessage = string.Format("{0}\n\n{1}", strMessage, sysEx.Message);
                    Console.WriteLine(strMessage);

                }
            }
            else
            {

                try
                {
                    dirInfo.Delete(true);
                    dirInfo.Create();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
    
            
                Application.Run(new frmMain());
            

        }


        static void MyHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            Console.WriteLine(e);
            //MessageBox.Show(e.Message);
        }


        static void Application_ThreadException(object sender, ThreadExceptionEventArgs args)
        {
            Exception e = (Exception)args.Exception;
            Console.WriteLine(e);
            //MessageBox.Show(e.Message);
        }

    }
}
