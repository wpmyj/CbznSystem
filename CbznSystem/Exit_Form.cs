using Dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NewControl;

namespace CbznSystem
{
    public partial class Exit_Form : NewForm
    {
        public Exit_Form()
        {
            InitializeComponent();

            this.KeyDown += Exit_Form_KeyDown;

            l_Title.MouseDown += L_Title_MouseDown;
            tb_Pwd.TextChanged += Tb_Pwd_TextChanged;
            tb_Pwd.KeyPress += Tb_Pwd_KeyPress;
            btn_Enter.Click += Btn_Enter_Click;
        }

        private void Exit_Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void Btn_Enter_Click(object sender, EventArgs e)
        {
            string pwd = tb_Pwd.Text.Trim();
            if (Dal_ManageInfo.ManageInfo.ManagePwd != pwd)
            {
                MessageBox.Show("密码错误，请重新输入。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb_Pwd.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void Tb_Pwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Btn_Enter_Click(null, null);
            }
        }

        private void Tb_Pwd_TextChanged(object sender, EventArgs e)
        {
            l_Title.Visible = tb_Pwd.TextLength == 0;
        }

        private void L_Title_MouseDown(object sender, MouseEventArgs e)
        {
            tb_Pwd.Focus();
        }
    }
}
