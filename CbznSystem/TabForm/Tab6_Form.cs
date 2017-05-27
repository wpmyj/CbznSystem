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
    public partial class Tab6_Form : Form
    {

        private Button SelectedTab;

        private bool _isMouseEnterTab1;
        private bool _isMouseDownTab1;

        private bool _isMouseEnterTab2;
        private bool _isMouseDownTab2;

        private bool _isMouseEnterTab3;
        private bool _isMouseDownTab3;

        public Tab6_Form()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(240, 243, 245);

            this.Load += Tab6_Form_Load;
            this.KeyDown += Tab6_Form_KeyDown;

            btn_Tab1.MouseDown += Btn_Tab1_MouseDown;
            btn_Tab1.MouseUp += Btn_Tab1_MouseUp;
            btn_Tab1.MouseEnter += Btn_Tab1_MouseEnter;
            btn_Tab1.MouseLeave += Btn_Tab1_MouseLeave;
            btn_Tab1.Paint += Btn_Tab1_Paint;

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

        }

        private void Tab6_Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4 && e.Alt)
            {
                e.Handled = true;
            }
        }

        private void Tab6_Form_Load(object sender, EventArgs e)
        {
            GetSelectedTab(btn_Tab1);
            ShowTabForm(EnterExitRecord_Form.GetInstance);
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

            GetSelectedTab(btn_Tab3);

            _isMouseDownTab3 = true;

            ShowTabForm(ManageLog_Form.GetInstance);
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

            GetSelectedTab(btn_Tab2);

            _isMouseDownTab2 = true;

            ShowTabForm(ChargeRecord_Form.GetInstance);
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

            ShowTabForm(EnterExitRecord_Form.GetInstance);
        }

        private void GetSelectedTab(Button btn)
        {
            Button oldtab = SelectedTab;
            SelectedTab = btn;
            if (oldtab != null)
                oldtab.Invalidate();
        }

        private void ShowTabForm(Form tab)
        {
            WinApi.SetParent(tab.Handle, p_Box.Handle);
            if (tab.WindowState != FormWindowState.Maximized)
            {
                tab.WindowState = FormWindowState.Maximized;
                tab.Show();
            }
        }

        private static Tab6_Form _uniqueInstance;

        public static Tab6_Form GetInstance
        {
            get { return _uniqueInstance ?? (_uniqueInstance = new Tab6_Form()); }
        }


    }
}
