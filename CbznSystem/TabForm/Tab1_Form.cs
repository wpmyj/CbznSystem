using Dal;
using Model;
using Bll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CbznSystem
{
    public partial class Tab1_Form : Form
    {

        private Button SelectedTab;

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

        #region 窗体事件

        public Tab1_Form()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(240, 243, 245);

            this.Load += Form1_Load;
            this.Shown += Tab1_Form_Shown;
            this.FormClosed += Tab1_Form_FormClosed;
            this.KeyDown += Tab1_Form_KeyDown;

            l_DistanceTitle.Paint += TitlePaint;
            l_IcTitle.Paint += TitlePaint;

            btn_Tab1.MouseDown += Btn_Tab1_MouseDown;
            btn_Tab1.MouseUp += Btn_Tab1_MouseUp;
            btn_Tab1.MouseEnter += Btn_Tab1_MouseEnter;
            btn_Tab1.MouseLeave += Btn_Tab1_MouseLeave;
            btn_Tab1.Paint += Btn_Tab1_Paint;

            cb_TempDevice.CheckedChanged += Cb_TempDevice_CheckedChanged;
            cb_CameraDevice.CheckedChanged += Cb_CameraDevice_CheckedChanged;

            btn_Tab2.MouseDown += Btn_Tab2_MouseDown;
            btn_Tab2.MouseUp += Btn_Tab2_MouseUp;
            btn_Tab2.MouseEnter += Btn_Tab2_MouseEnter;
            btn_Tab2.MouseLeave += Btn_Tab2_MouseLeave;
            btn_Tab2.Paint += Btn_Tab2_Paint;

            btn_Tab3.MouseDown += Btn_Tab3_MouseDown;
            btn_Tab3.MouseUp += Btn_Tab3_MouseUp;
            btn_Tab3.MouseEnter += Btn_Tab3_MouseEnter;
            btn_Tab3.MouseLeave += Btn_Tab3_MouseLeave;
            btn_Tab3.Paint += Btn_Tab3_Paint;

            btn_Tab4.MouseDown += Btn_Tab4_MouseDown;
            btn_Tab4.MouseUp += Btn_Tab4_MouseUp;
            btn_Tab4.MouseEnter += Btn_Tab4_MouseEnter;
            btn_Tab4.MouseLeave += Btn_Tab4_MouseLeave;
            btn_Tab4.Paint += Btn_Tab4_Paint;

            btn_Tab5.MouseDown += Btn_Tab5_MouseDown;
            btn_Tab5.MouseUp += Btn_Tab5_MouseUp;
            btn_Tab5.MouseEnter += Btn_Tab5_MouseEnter;
            btn_Tab5.MouseLeave += Btn_Tab5_MouseLeave;
            btn_Tab5.Paint += Btn_Tab5_Paint;

        }

        private void Tab1_Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4 && e.Alt == true)
            {
                e.Handled = true;
            }
        }

        private void Cb_CameraDevice_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_CameraDevice.Checked != Dal_SysSettings.SystemSettings.IsSetLprDevice)
            {
                Dal_SysSettings.SystemSettings.IsSetLprDevice = cb_CameraDevice.Checked;
                XmlHelper.Update<CbSysSettings>(Dal_SysSettings.SystemSettings);
            }
        }

        private void Cb_TempDevice_CheckedChanged(object sender, EventArgs e)
        {
            p_Ic.Visible = cb_TempDevice.Checked;
            if (cb_TempDevice.Checked)
            {
                GetTempIcDevicePassword();
            }
            if (cb_TempDevice.Checked != Dal_SysSettings.SystemSettings.IsSetTempIcDevice)
            {
                Dal_SysSettings.SystemSettings.IsSetTempIcDevice = cb_TempDevice.Checked;
                XmlHelper.Update<CbSysSettings>(Dal_SysSettings.SystemSettings);
            }
        }

        private void Btn_Tab1_Paint(object sender, PaintEventArgs e)
        {
            TabPaint(sender, e, _isMouseDownTab1, _isMouseEnterTab1);
        }

        private void Btn_Tab2_Paint(object sender, PaintEventArgs e)
        {
            TabPaint(sender, e, _isMouseDownTab2, _isMouseEnterTab2);
        }

        private void Btn_Tab3_Paint(object sender, PaintEventArgs e)
        {
            TabPaint(sender, e, _isMouseDownTab3, _isMouseEnterTab3);
        }

        private void Btn_Tab4_Paint(object sender, PaintEventArgs e)
        {
            TabPaint(sender, e, _isMouseDownTab4, _isMouseEnterTab4);
        }

        private void Btn_Tab5_Paint(object sender, PaintEventArgs e)
        {
            TabPaint(sender, e, _isMouseDownTab5, _isMouseEnterTab5);
        }

        private void TabPaint(object sender, PaintEventArgs e, bool isdown, bool isenter)
        {
            Button btn = sender as Button;
            Graphics g = e.Graphics;
            Color backcolor = btn.BackColor;
            Color forecolor = btn.ForeColor;
            if (btn != SelectedTab)
            {
                if (!btn.Enabled)
                {
                    backcolor = Color.FromArgb(160, 160, 160);
                    forecolor = Color.FromArgb(231, 231, 231);
                }
                else
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
            }
            else
            {
                backcolor = btn.FlatAppearance.MouseDownBackColor;
            }
            Rectangle rect = new Rectangle(0, 0, btn.Width, btn.Height);
            StringFormat sf = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            g.FillRectangle(new SolidBrush(backcolor), rect);
            g.DrawString(btn.Text, btn.Font, new SolidBrush(forecolor), rect, sf);
            if (btn == SelectedTab)
            {
                Point[] p = new Point[] {
                        new Point(btn.Width,btn.Height/2-5),
                        new Point(btn.Width-5,btn.Height/2),
                        new Point(btn.Width,btn.Height/2+5)
                    };
                g.FillPolygon(new SolidBrush(Color.FromArgb(240, 243, 245)), p);
            }
        }

        private void Btn_Tab5_MouseLeave(object sender, EventArgs e)
        {
            _isMouseEnterTab5 = false;
            _isMouseDownTab5 = false;
        }

        private void Btn_Tab5_MouseEnter(object sender, EventArgs e)
        {
            _isMouseEnterTab5 = true;
        }

        private void Btn_Tab5_MouseUp(object sender, MouseEventArgs e)
        {
            _isMouseDownTab5 = false;
        }

        private void Btn_Tab5_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            GetSelectedTab(btn_Tab5);

            _isMouseDownTab5 = true;

            ShowPage(btn_Tab5);

            ShowTabForm(IcCard_Form.GetInstance);

        }

        private void Btn_Tab4_MouseLeave(object sender, EventArgs e)
        {
            _isMouseEnterTab4 = false;
            _isMouseDownTab4 = false;
        }

        private void Btn_Tab4_MouseEnter(object sender, EventArgs e)
        {
            _isMouseEnterTab4 = true;
        }

        private void Btn_Tab4_MouseUp(object sender, MouseEventArgs e)
        {
            _isMouseDownTab4 = false;
        }

        private void Btn_Tab4_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            GetSelectedTab(btn_Tab4);

            _isMouseDownTab4 = true;

            ShowPage(btn_Tab4);

            ShowTabForm(IcEquipment_Form.GetInstance);

        }

        private void Btn_Tab3_MouseLeave(object sender, EventArgs e)
        {
            _isMouseEnterTab3 = false;
            _isMouseDownTab3 = false;
        }

        private void Btn_Tab3_MouseEnter(object sender, EventArgs e)
        {
            _isMouseEnterTab3 = true;
        }

        private void Btn_Tab3_MouseUp(object sender, MouseEventArgs e)
        {
            _isMouseDownTab3 = false;
        }

        private void Btn_Tab3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            
            _isMouseDownTab3 = true;

            DistanceCardPwdSet();
        }

        public void DistanceCardPwdSet()
        {
            GetSelectedTab(btn_Tab3);

            ShowPage(btn_Tab3);

            ShowTabForm(DistanceCard_Form.GetInstance);

        }

        private void Btn_Tab2_MouseLeave(object sender, EventArgs e)
        {
            _isMouseEnterTab2 = false;
            _isMouseDownTab2 = false;
        }

        private void Btn_Tab2_MouseEnter(object sender, EventArgs e)
        {
            _isMouseEnterTab2 = true;
        }

        private void Btn_Tab2_MouseUp(object sender, MouseEventArgs e)
        {
            _isMouseDownTab2 = false;
        }

        private void Btn_Tab2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            _isMouseDownTab2 = true;

            DistancePwdSet();
        }

        public void DistancePwdSet()
        {
            GetSelectedTab(btn_Tab2);

            ShowPage(btn_Tab2);

            ShowTabForm(DistanceEquipment_Form.GetInstance);
        }

        private void Btn_Tab1_MouseLeave(object sender, EventArgs e)
        {
            _isMouseEnterTab1 = false;
            _isMouseDownTab1 = false;
        }

        private void Btn_Tab1_MouseEnter(object sender, EventArgs e)
        {
            _isMouseEnterTab1 = true;
        }

        private void Btn_Tab1_MouseUp(object sender, MouseEventArgs e)
        {
            _isMouseDownTab1 = false;
        }

        private void Btn_Tab1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            GetSelectedTab(btn_Tab1);

            _isMouseDownTab1 = true;

            ShowPage(btn_Tab1);


        }

        private void ShowTabForm(Form tab)
        {
            WinApi.SetParent(tab.Handle, p_Tab2.Handle);
            if (tab.WindowState != FormWindowState.Maximized)
            {
                tab.WindowState = FormWindowState.Maximized;
                tab.Show();
            }
        }

        private void ShowPage(Button btn)
        {
            if (btn == btn_Tab1)
            {
                p_Tab1.Visible = true;
                p_Tab2.Visible = false;
            }
            else
            {
                p_Tab1.Visible = false;
                p_Tab2.Visible = true;
            }
        }

        private void GetSelectedTab(Button btn)
        {
            Button oldtab = SelectedTab;
            SelectedTab = btn;
            if (oldtab != null)
                oldtab.Invalidate();
        }

        private void TitlePaint(object sender, PaintEventArgs e)
        {
            Label l = sender as Label;
            Graphics g = e.Graphics;
            g.DrawLine(new Pen(Brushes.Gray, 1), 0, l.Height - 1, l.Width, l.Height - 1);
        }

        private void Tab1_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            _uniqueInstance = null;
        }

        private static Tab1_Form _uniqueInstance;

        public static Tab1_Form GetInstance
        {
            get { return _uniqueInstance ?? (_uniqueInstance = new Tab1_Form()); }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SelectedTab = btn_Tab1;
            p_Tab2.Visible = false;

            if (Dal_DevicePwd.DistanceSystemPassword.ID == 0)
            {
                btn_Tab3.Enabled = false;
            }
            cb_TempDevice.Checked = Dal_SysSettings.SystemSettings.IsSetTempIcDevice;
            cb_CameraDevice.Checked = Dal_SysSettings.SystemSettings.IsSetLprDevice;
        }

        private void GetTempIcDevicePassword()
        {
            try
            {
                if (Dal_IcDevicePwd.TempIcDevicePassword != null) return;
                CbIcDeviePwd mTempIcPwd = Dbhelper.Db.FirstDefault<CbIcDeviePwd>();
                if (mTempIcPwd == null)
                {
                    mTempIcPwd = new CbIcDeviePwd() { Pwd = "FFFFFFFF" };
                    btn_Tab5.Enabled = false;
                }
                Dal_IcDevicePwd.TempIcDevicePassword = mTempIcPwd;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Tab1_Form_Shown(object sender, EventArgs e)
        {

        }

        #endregion 窗体事件

    }
}
