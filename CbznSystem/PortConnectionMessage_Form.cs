using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
namespace CbznSystem
{
    public partial class PortConnectionMessage_Form : Form
    {
        private Thread _tEffectThread;

        public PortConnectionMessage_Form()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;

            this.FormClosed += PortConnectionMessage_Form_FormClosed;
            this.Load += PortConnectionMessage_Form_Load;
        }

        private void PortConnectionMessage_Form_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
        }

        private void PortConnectionMessage_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            _uniqueInstance = null;
        }

        public void ShowMessage(bool flag)
        {
            if (flag)
            {
                l_Title.Text = "端口已连接";
                l_Title.ForeColor = Color.White;
            }
            else
            {
                l_Title.Text = "端口已断开";
                l_Title.ForeColor = Color.Red;
            }

            if (_tEffectThread == null)
            {
                _tEffectThread = new Thread(ShowEffect);
                _tEffectThread.IsBackground = true;
                _tEffectThread.Start();
            }
        }

        private void ShowEffect()
        {
            try
            {
                do
                {
                    this.Invoke(new EventHandler(delegate
                    {
                        this.Opacity += 0.1;
                    }));
                    Thread.Sleep(50);
                } while (this.Opacity < 0.9);
                Thread.Sleep(2000);
                do
                {
                    this.Invoke(new EventHandler(delegate
                    {
                        this.Opacity -= 0.1;
                    }));
                    Thread.Sleep(50);
                } while (this.Opacity > 0.1);
            }
            catch (Exception ex) { Bll.CustomExceptionHandler.GetExceptionMessage(ex); }
            finally
            {
                _tEffectThread = null;
                this.Invoke(new EventHandler(delegate
                {
                    this.Hide();
                }));
                //Close();
            }
        }

        private static PortConnectionMessage_Form _uniqueInstance;

        public static PortConnectionMessage_Form GetInstance
        {
            get { return _uniqueInstance ?? (_uniqueInstance = new PortConnectionMessage_Form()); }
        }


    }
}
