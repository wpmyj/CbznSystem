using System.Drawing.Drawing2D;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NewControl;
using Bll;
using System.Diagnostics;

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


        public Main_Form()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(1);
            this.BackColor = Color.FromArgb(240, 243, 245);
            Screen currentscreen = Screen.FromControl(this);
            this.Location = new Point(currentscreen.Bounds.Left, currentscreen.Bounds.Top);
            this.Size = new Size(currentscreen.WorkingArea.Width, currentscreen.WorkingArea.Height);
            this.Paint += Main_Form_Paint;
            this.Load += Main_Form_Load;

            btn_Close.Click += Btn_Close_Click;
            btn_Min.Click += Btn_Min_Click;
            p_Top.Paint += P_Top_Paint;
            pb_Logo.Click += Pb_Logo_Click;

            Tab1.Paint += Tab1_Paint;
            Tab1.MouseDown += Tab1_MouseDown;
            Tab1.MouseUp += Tab1_MouseUp;
            Tab1.MouseEnter += Tab1_MouseEnter;
            Tab1.MouseLeave += Tab1_MouseLeave;
            Tab1.Click += Tab1_Click;

            Tab2.Paint += Tab2_Paint;
            Tab2.MouseDown += Tab2_MouseDown;
            Tab2.MouseUp += Tab2_MouseUp;
            Tab2.MouseEnter += Tab2_MouseEnter;
            Tab2.MouseLeave += Tab2_MouseLeave;
            Tab2.Click += Tab2_Click;

            Tab3.Paint += Tab3_Paint;
            Tab3.MouseDown += Tab3_MouseDown;
            Tab3.MouseUp += Tab3_MouseUp;
            Tab3.MouseEnter += Tab3_MouseEnter;
            Tab3.MouseLeave += Tab3_MouseLeave;
            Tab3.Click += Tab3_Click;

            Tab4.Paint += Tab4_Paint;
            Tab4.MouseDown += Tab4_MouseDown;
            Tab4.MouseUp += Tab4_MouseUp;
            Tab4.MouseEnter += Tab4_MouseEnter;
            Tab4.MouseLeave += Tab4_MouseLeave;
            Tab4.Click += Tab4_Click;

            Tab5.Paint += Tab5_Paint;
            Tab5.MouseDown += Tab5_MouseDown;
            Tab5.MouseUp += Tab5_MouseUp;
            Tab5.MouseEnter += Tab5_MouseEnter;
            Tab5.MouseLeave += Tab5_MouseLeave;
            Tab5.Click += Tab5_Click;
        }

        private void Pb_Logo_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.c-b-z-n.com");
        }

        private void Tab5_Click(object sender, EventArgs e)
        {
            TabBtnEnalbed(Tab5);
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
            _isMouseDownTab5 = true;
        }

        private void Tab5_Paint(object sender, PaintEventArgs e)
        {
            TabBtnPaint(sender, e, _isMouseEnterTab5, _isMouseDownTab5);
        }

        private void Tab4_Click(object sender, EventArgs e)
        {
            TabBtnEnalbed(Tab4);
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
            _isMouseDownTab4 = true;
        }

        private void Tab4_Paint(object sender, PaintEventArgs e)
        {
            TabBtnPaint(sender, e, _isMouseEnterTab4, _isMouseDownTab4);
        }

        private void Tab3_Click(object sender, EventArgs e)
        {
            TabBtnEnalbed(Tab3);
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
            _isMouseDownTab3 = true;
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
            _isMouseDownTab2 = true;
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

        private void Tab2_Click(object sender, EventArgs e)
        {
            TabBtnEnalbed(Tab2);
        }

        private void Tab1_Click(object sender, EventArgs e)
        {
            TabBtnEnalbed(Tab1);

        }

        private void TabBtnEnalbed(Button btn)
        {
            Tab1.Enabled = btn != Tab1;
            Tab2.Enabled = btn != Tab2;
            Tab3.Enabled = btn != Tab3;
            Tab4.Enabled = btn != Tab4;
            Tab5.Enabled = btn != Tab5;
            p_Top.Invalidate(false);
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {



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
            _isMouseDownTab1 = true;
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

    }
}
