using Bll;
using Dal;
using Model;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CbznSystem
{
    public partial class Main_Form : Form
    {
        private bool _isMouseEnterTab1;
        private bool _isMouseDownTab1;

        private bool _isMouseEnterTab2;
        private bool _isMouseDownTab2;

        private bool _isMouseEnterTab3;
        private bool _isMouseDownTab3;

        private bool _isMouseEnterTab4;
        private bool _isMouseDownTab4;

        private bool _isMouseEnterTab5;
        private bool _isMouseDownTab5;

        private bool _isMouseEnterTab6;
        private bool _isMouseDownTab6;

        public Main_Form()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(1);
            this.BackColor = Color.FromArgb(240, 243, 245);
            Screen currentscreen = Screen.FromControl(this);
            this.Location = new Point(currentscreen.Bounds.Left, currentscreen.Bounds.Top);
            this.Size = new Size(currentscreen.WorkingArea.Width, currentscreen.WorkingArea.Height);
            //this.Size = new Size(1280, 768);
            //this.StartPosition = FormStartPosition.CenterScreen;

            this.Paint += Main_Form_Paint;
            this.Load += Main_Form_Load;
            this.Shown += Main_Form_Shown;
            this.FormClosing += Main_Form_FormClosing;
            this.KeyDown += Main_Form_KeyDown;

            btn_Close.Click += Btn_Close_Click;
            btn_Min.Click += Btn_Min_Click;
            p_Top.Paint += P_Top_Paint;
            pb_Logo.Click += Pb_Logo_Click;

            Tab1.Paint += Tab1_Paint;
            Tab1.MouseDown += Tab1_MouseDown;
            Tab1.MouseUp += Tab1_MouseUp;
            Tab1.MouseEnter += Tab1_MouseEnter;
            Tab1.MouseLeave += Tab1_MouseLeave;

            Tab2.Paint += Tab2_Paint;
            Tab2.MouseDown += Tab2_MouseDown;
            Tab2.MouseUp += Tab2_MouseUp;
            Tab2.MouseEnter += Tab2_MouseEnter;
            Tab2.MouseLeave += Tab2_MouseLeave;

            Tab3.Paint += Tab3_Paint;
            Tab3.MouseDown += Tab3_MouseDown;
            Tab3.MouseUp += Tab3_MouseUp;
            Tab3.MouseEnter += Tab3_MouseEnter;
            Tab3.MouseLeave += Tab3_MouseLeave;

            Tab4.Paint += Tab4_Paint;
            Tab4.MouseDown += Tab4_MouseDown;
            Tab4.MouseUp += Tab4_MouseUp;
            Tab4.MouseEnter += Tab4_MouseEnter;
            Tab4.MouseLeave += Tab4_MouseLeave;

            Tab5.Paint += Tab5_Paint;
            Tab5.MouseDown += Tab5_MouseDown;
            Tab5.MouseUp += Tab5_MouseUp;
            Tab5.MouseEnter += Tab5_MouseEnter;
            Tab5.MouseLeave += Tab5_MouseLeave;

            Tab6.Paint += Tab6_Paint;
            Tab6.MouseDown += Tab6_MouseDown;
            Tab6.MouseUp += Tab6_MouseUp;
            Tab6.MouseEnter += Tab6_MouseEnter;
            Tab6.MouseLeave += Tab6_MouseLeave;

            pb_Process1.Click += Pb_Process1_Click;
            pb_Process2.Click += Pb_Process2_Click;
            pb_Process4.Click += Pb_Process4_Click;
            pb_Process5.Click += Pb_Process5_Click;

        }

        /// <summary>
        /// 定距卡发行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pb_Process5_Click(object sender, EventArgs e)
        {
            Tab3_MouseDown(null, new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0));
            _isMouseDownTab3 = false;
        }

        /// <summary>
        /// 定距卡同步(加密)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pb_Process4_Click(object sender, EventArgs e)
        {
            Tab1_MouseDown(null, new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0));
            _isMouseDownTab1 = false;
            Tab1_Form.GetInstance.DistanceCardPwdSet();
        }

        /// <summary>
        /// 配置主机参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pb_Process2_Click(object sender, EventArgs e)
        {
            Tab2_MouseDown(null, new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0));
            _isMouseDownTab2 = false;
        }

        /// <summary>
        /// 发行器设置(加密)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pb_Process1_Click(object sender, EventArgs e)
        {
            Tab1_MouseDown(null, new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0));
            _isMouseDownTab1 = false;
            Tab1_Form.GetInstance.DistancePwdSet();
        }

        private void Main_Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
            {
                if (!Tab4.Enabled)
                {
                    Tab4_Form.GetInstance.AcceptButton.PerformClick();
                }
            }
        }

        private void Main_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (Exit_Form exit = new Exit_Form())
            {
                if (exit.ShowDialog() != DialogResult.OK)
                {
                    e.Cancel = true;
                    return;
                }
            }
            if (!Tab4.Enabled)
            {
                Tab4_Form.GetInstance.Close();
            }
        }

        private void Main_Form_Shown(object sender, EventArgs e)
        {
            PortHelper.LoadPort();
            PortHelper.DataReceived += SerialPortDataReceived;
            PortHelper.SerialPortConnection += PortHelper_SerialPortConnection;
            PortHelper.ConnectionChange += PortHelper_ConnectionChange;
        }

        private void PortHelper_ConnectionChange(bool flag)
        {
            this.BeginInvoke(new EventHandler(delegate
            {
                //显示端口断开或连接提示
                PortConnectionMessage_Form portConnectionMessage = PortConnectionMessage_Form.GetInstance;
                portConnectionMessage.Location = new Point((this.Width - portConnectionMessage.Width) / 2, this.Height - portConnectionMessage.Height);
                portConnectionMessage.Show();
                portConnectionMessage.ShowMessage(flag);
            }));
        }

        private void PortHelper_SerialPortConnection(string portname)
        {
            if (PortHelper.IsConnection) return;
            PortHelper.sp.PortName = portname;
            try
            {
                PortHelper.sp.Open();
                byte[] by = PortAgreement.GetDistanceEncryption(Dal_DevicePwd.DistanceSystemPassword.Pwd);
                PortHelper.sp.Write(by);
                by = null;
                Thread.Sleep(550);
                if (PortHelper.IsConnection)
                {
                    return;
                }
                PortHelper.sp.Close();
                Thread.Sleep(10);
            }
            catch
            {

            }
        }

        private void SerialPortDataReceived(ParsingParameter param)
        {
            if (PortHelper.IsConnection) return;
            if (param.FunctionAddress == 65)
            {
                DistanceParameter distanceparam = DataParsing.DistanceParsingContent(param.DataContent);
                if (distanceparam.Command == 160)
                {
                    PortHelper.IsConnection = true;
                }
            }
        }

        private void Tab6_MouseLeave(object sender, EventArgs e)
        {
            _isMouseEnterTab6 = false;
            _isMouseDownTab6 = false;
        }

        private void Tab6_MouseEnter(object sender, EventArgs e)
        {
            _isMouseEnterTab6 = true;
        }

        private void Tab6_MouseUp(object sender, MouseEventArgs e)
        {
            _isMouseDownTab6 = false;
        }

        private void Tab6_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            _isMouseDownTab6 = true;

            TabBtnEnalbed(Tab6);

            ShowTabForm(Tab6_Form.GetInstance);
        }

        private void Tab6_Paint(object sender, PaintEventArgs e)
        {
            TabBtnPaint(sender, e, _isMouseEnterTab6, _isMouseDownTab6);
        }

        private void Pb_Logo_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.c-b-z-n.com");
        }

        private void Tab5_MouseLeave(object sender, EventArgs e)
        {
            _isMouseEnterTab5 = false;
            _isMouseDownTab5 = false;
        }

        private void Tab5_MouseEnter(object sender, EventArgs e)
        {
            _isMouseEnterTab5 = true;
        }

        private void Tab5_MouseUp(object sender, MouseEventArgs e)
        {
            _isMouseDownTab5 = false;
        }

        private void Tab5_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            _isMouseDownTab5 = true;

            TabBtnEnalbed(Tab5);
            ShowTabForm(Tab5_Form.GetInstance);
        }

        private void Tab5_Paint(object sender, PaintEventArgs e)
        {
            TabBtnPaint(sender, e, _isMouseEnterTab5, _isMouseDownTab5);
        }

        private void Tab4_MouseLeave(object sender, EventArgs e)
        {
            _isMouseDownTab4 = false;
            _isMouseEnterTab4 = false;
        }

        private void Tab4_MouseEnter(object sender, EventArgs e)
        {
            _isMouseEnterTab4 = true;
        }

        private void Tab4_MouseUp(object sender, MouseEventArgs e)
        {
            _isMouseDownTab4 = false;
        }

        private void Tab4_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            if (!Dal_ManageRights.ManageRights.SetChargeManagement)
            {
                MessageBox.Show("当前用户无权限使用此功能。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            _isMouseDownTab4 = true;

            TabBtnEnalbed(Tab4);

            if (Tab4_Form.GetInstance.p_SetBox != null)
            {
                Tab4_Form.GetInstance.DisplaySet();
            }

            ShowTabForm(Tab4_Form.GetInstance);
        }

        private void Tab4_Paint(object sender, PaintEventArgs e)
        {
            TabBtnPaint(sender, e, _isMouseEnterTab4, _isMouseDownTab4);
        }

        private void Tab3_MouseLeave(object sender, EventArgs e)
        {
            _isMouseDownTab3 = false;
            _isMouseEnterTab3 = false;
        }

        private void Tab3_MouseEnter(object sender, EventArgs e)
        {
            _isMouseEnterTab3 = true;
        }

        private void Tab3_MouseUp(object sender, MouseEventArgs e)
        {
            _isMouseDownTab3 = false;
        }

        private void Tab3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            _isMouseDownTab3 = true;

            TabBtnEnalbed(Tab3);
            ShowTabForm(Tab3_Form.GetInstance);
        }

        private void Tab3_Paint(object sender, PaintEventArgs e)
        {
            TabBtnPaint(sender, e, _isMouseEnterTab3, _isMouseDownTab3);
        }

        private void Tab2_MouseLeave(object sender, EventArgs e)
        {
            _isMouseDownTab2 = false;
            _isMouseEnterTab2 = false;
        }

        private void Tab2_MouseEnter(object sender, EventArgs e)
        {
            _isMouseEnterTab2 = true;
        }

        private void Tab2_MouseUp(object sender, MouseEventArgs e)
        {
            _isMouseDownTab2 = false;
        }

        private void Tab2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            _isMouseDownTab2 = true;

            TabBtnEnalbed(Tab2);
            ShowTabForm(Tab2_Form.GetInstance);
        }

        private void Tab2_Paint(object sender, PaintEventArgs e)
        {
            TabBtnPaint(sender, e, _isMouseEnterTab2, _isMouseDownTab2);
        }

        private void Tab1_Paint(object sender, PaintEventArgs e)
        {
            TabBtnPaint(sender, e, _isMouseEnterTab1, _isMouseDownTab1);
        }

        private void P_Top_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                Button btn = null;
                foreach (Control item in p_Top.Controls)
                {
                    if (item is Button && !item.Enabled)
                    {
                        btn = item as Button;
                        break;
                    }
                }
                if (btn != null)
                {
                    g.DrawLine(new Pen(btn.FlatAppearance.BorderColor, 3), 0, p_Top.Height - 2, p_Top.Width, p_Top.Height - 2);
                }
            }
        }

        private void ShowTabForm(Form tab)
        {
            WinApi.SetParent(tab.Handle, p_Box.Handle);
            if (tab.WindowState != FormWindowState.Maximized)
            {
                //tab.WindowState = FormWindowState.Maximized;
                tab.Location = new Point(0, 0);
                tab.Size = new Size(p_Box.Width, p_Box.Height);
                tab.Show();
            }
        }

        private void TabBtnEnalbed(Button btn)
        {
            Tab1.Enabled = btn != Tab1;
            Tab2.Enabled = btn != Tab2;
            Tab3.Enabled = btn != Tab3;
            Tab4.Enabled = btn != Tab4;
            Tab5.Enabled = btn != Tab5;
            Tab6.Enabled = btn != Tab6;
            p_Top.Invalidate(false);
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {
            CbDevicePwd mDistanceSystemPwd = null;
            try
            {
                mDistanceSystemPwd = Dbhelper.Db.FirstDefault<CbDevicePwd>();
            }
            finally
            {
                if (mDistanceSystemPwd == null)
                {
                    mDistanceSystemPwd = new CbDevicePwd()
                    {
                        Pwd = "766554"
                    };
                }
            }
            Dal_DevicePwd.DistanceSystemPassword = mDistanceSystemPwd;
        }

        private void Tab1_MouseEnter(object sender, EventArgs e)
        {
            _isMouseEnterTab1 = true;
        }

        private void Tab1_MouseLeave(object sender, EventArgs e)
        {
            _isMouseEnterTab1 = false;
            _isMouseDownTab1 = false;
        }

        private void Tab1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            _isMouseDownTab1 = true;

            TabBtnEnalbed(Tab1);
            ShowTabForm(Tab1_Form.GetInstance);
        }

        private void Tab1_MouseUp(object sender, MouseEventArgs e)
        {
            _isMouseDownTab1 = false;
        }

        private void TabBtnPaint(object sender, PaintEventArgs e, bool isenter, bool isdown)
        {
            Button btn = sender as Button;
            Graphics g = e.Graphics;
            StringFormat sf = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            Rectangle rect = new Rectangle(0, 0, btn.Width, btn.Height);
            Color backcolor = btn.BackColor;
            if (btn.Enabled)
            {
                if (isdown)
                {
                    backcolor = btn.FlatAppearance.MouseDownBackColor;
                }
                else if (isenter)
                {
                    backcolor = btn.FlatAppearance.MouseOverBackColor;
                }
            }
            else
            {
                backcolor = btn.FlatAppearance.MouseDownBackColor;
            }
            g.FillRectangle(new SolidBrush(backcolor), rect);
            g.DrawString(btn.Text, btn.Font, Brushes.White, rect, sf);
            if (!btn.Enabled)
            {
                int width = btn.Width / 2;
                Point[] p = new Point[] {
                    new Point(width-6,btn.Height),
                    new Point(width,btn.Height-6),
                    new Point(width+6,btn.Height),
                };
                g.FillPolygon(new SolidBrush(btn.FlatAppearance.BorderColor), p);
            }
        }

        private void Main_Form_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                g.DrawRectangle(new Pen(Brushes.Gray, 1), new Rectangle(0, 0, Width - 1, Height - 1));
            }
        }

        private void Btn_Min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 解决窗体切换而产生的控件闪烁问题
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

    }
}
