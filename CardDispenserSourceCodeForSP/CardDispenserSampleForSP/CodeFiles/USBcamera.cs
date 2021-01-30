using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;

namespace CardDispenserSampleForSP
{


    public partial class USBcamera
    {

        private int m_CapHwnd;

        //private bool bStopped = true;

        IntPtr _parentFormHandle;

        #region API Declarations

        [DllImport("user32", EntryPoint = "SendMessage")]
        public static extern int SendMessage(int hWnd, uint Msg, int wParam, int lParam);

        //Esta API cria a instância da webcam para que possamos acessa-la.
        [DllImport("avicap32.dll", EntryPoint = "capCreateCaptureWindowA")]
        public static extern int capCreateCaptureWindowA(string lpszWindowName, int dwStyle, int x, int y, int nWidth, int nHeight, int hwndParent, int nID);

        //Esta API abre a área de tranferência para que possamos buscar os dados da webcam.
        [DllImport("user32", EntryPoint = "OpenClipboard")]
        public static extern int OpenClipboard(int hWnd);

        //Esta API limpa a área de transferência.
        [DllImport("user32", EntryPoint = "EmptyClipboard")]
        public static extern int EmptyClipboard();

        //Esta API fecha a área de tranferência após utilização.
        [DllImport("user32", EntryPoint = "CloseClipboard")]
        public static extern int CloseClipboard();

        //Esta API recupera os dados da área de tranferência para a utilização.
        [DllImport("user32.dll")]
        extern static IntPtr GetClipboardData(uint uFormat);

        #endregion

        #region API Constants

        //Esas constantes são predefinidas pelo SO

        public const int WM_USER = 1024;

        public const int WM_CAP_CONNECT = 1034;
        public const int WM_CAP_DISCONNECT = 1035;
        public const int WM_CAP_GT_FRAME = 1084;
        public const int WM_CAP_COPY = 1054;

        public const int WM_CAP_START = WM_USER;

        public const int WM_CAP_DLG_VIDEOFORMAT = WM_CAP_START + 41;
        public const int WM_CAP_DLG_VIDEOSOURCE = WM_CAP_START + 42;
        public const int WM_CAP_DLG_VIDEODISPLAY = WM_CAP_START + 43;
        public const int WM_CAP_GET_VIDEOFORMAT = WM_CAP_START + 44;
        public const int WM_CAP_SET_VIDEOFORMAT = WM_CAP_START + 45;
        public const int WM_CAP_DLG_VIDEOCOMPRESSION = WM_CAP_START + 46;
        public const int WM_CAP_SET_PREVIEW = WM_CAP_START + 50;

        #endregion

        public USBcamera(IntPtr parentFormHandle)
        {
            _parentFormHandle = parentFormHandle;
            //InitializeComponent();
        }

        public void Stop()
        {
            try
            {
                //bStopped = true;
                //this.tmrRefrashFrame.Stop();

                //Application.DoEvents();

                SendMessage(m_CapHwnd, WM_CAP_DISCONNECT, 0, 0);

                CloseClipboard();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Start()
        {
            try
            {
                this.Stop();

                m_CapHwnd = capCreateCaptureWindowA("WebCap", 0, 0, 0, 1280, 960, this._parentFormHandle.ToInt32(), 0);

                SendMessage(m_CapHwnd, WM_CAP_CONNECT, 0, 0);

                //bStopped = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Stop();
            }
        }

        public Image getCurrentFrame()
        {
            try
            {


                SendMessage(m_CapHwnd, WM_CAP_GT_FRAME, 0, 0);

                SendMessage(m_CapHwnd, WM_CAP_COPY, 0, 0);

                OpenClipboard(m_CapHwnd);

                IntPtr img = GetClipboardData(2);

                CloseClipboard();


                IDataObject tempObj = Clipboard.GetDataObject();
                Image tempImg = (System.Drawing.Bitmap)tempObj.GetData(DataFormats.Bitmap);

                return tempImg;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);                
                return null;
            }
        }

    }



}
