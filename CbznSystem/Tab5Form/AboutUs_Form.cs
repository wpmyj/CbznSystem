using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CbznSystem
{
    /// <summary>
    /// 关于我们
    /// </summary>
    public partial class AboutUs_Form : Form
    {
        public AboutUs_Form()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(238, 238, 242);

            this.KeyDown += AboutUs_Form_KeyDown;
        }

        private void AboutUs_Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4 && e.Alt)
            {
                e.Handled = true;
            }
        }

        private static AboutUs_Form _uniqueInstance;

        public static AboutUs_Form GetInstance
        {
            get { return _uniqueInstance ?? (_uniqueInstance = new AboutUs_Form()); }
        }

    }
}
