using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace NewControl
{
    public partial class NewForm : Form
    {
        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_MOVE = 0xF010;
        private const int HTCAPTION = 0x0002;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        public NewForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(1);
            this.BackColor = Color.White;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw, true);
            StyleChanged += NewForm_StyleChanged;
            this.Paint += NewForm_Paint;
            this.TextChanged += NewForm_TextChanged;

            btn_Min.Click += Btn_Min_Click;
            btn_Close.Click += Btn_Close_Click;

            p_Title.Paint += P_Title_Paint;
            p_Title.Resize += P_Title_Resize;
            p_Title.MouseDown += P_Title_MouseDown;
        }

        private void NewForm_TextChanged(object sender, EventArgs e)
        {
            p_Title.Invalidate(false);
        }

        private void P_Title_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        private void P_Title_Resize(object sender, EventArgs e)
        {
            p_Title.Invalidate(false);
        }

        private void P_Title_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                if (this.ShowIcon)
                {
                    g.DrawIcon(this.Icon, new Rectangle(new Point(10, (p_Title.Height - this.Icon.Height) / 2), this.Icon.Size));
                }
                Rectangle rect = new Rectangle(0, 0, p_Title.Width, p_Title.Height);
                StringFormat sf = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                g.DrawString(Text, p_Title.Font, Brushes.White, rect, sf);
            }
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Btn_Min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void NewForm_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                g.DrawRectangle(new Pen(Brushes.Gray, 1), 0, 0, Width - 1, Height - 1);
            }
        }

        private void NewForm_StyleChanged(object sender, EventArgs e)
        {
            if (this.ControlBox)
            {
                btn_Min.Visible = this.MinimizeBox;
            }
            else
            {
                btn_Close.Visible = false;
                btn_Min.Visible = false;
            }
        }
    }
}
