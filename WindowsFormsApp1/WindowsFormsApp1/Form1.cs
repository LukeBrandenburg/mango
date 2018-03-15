using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private const int APPCOMMAND_VOLUME_UP = 0xA0000;
        private const int WM_APPCOMMAND = 0x319;

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg,
            IntPtr wParam, IntPtr lParam);

        private void VolUp()
        {
            SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle,
                (IntPtr)APPCOMMAND_VOLUME_UP);
        }

        public Form1()
        {
            InitializeComponent();
            //testing
            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x80;  // Turn on WS_EX_TOOLWINDOW
                return cp;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Opacity = 0.0f;
            this.ShowInTaskbar = false;
            System.IO.Stream str = Properties.Resources.sound;
            System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
            snd.PlayLooping(); // play the great soviet union anthem. 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                VolUp();
            }
            catch { }
        }
    }
}
