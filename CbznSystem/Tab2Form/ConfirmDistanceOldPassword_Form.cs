using Bll;
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
    public partial class ConfirmDistanceOldPassword_Form : NewForm
    {
        public ConfirmDistanceOldPassword_Form()
        {
            InitializeComponent();

            this.KeyDown += ConfirmDistanceOldPassword_Form_KeyDown;

            l_OldTitle.MouseDown += L_OldTitle_MouseDown;
            tb_OldPassword.TextChanged += Tb_OldPassword_TextChanged;
            tb_OldPassword.KeyPress += Tb_OldPassword_KeyPress;
            btn_DefaultPassword.Click += Btn_DefaultPassword_Click;
            btn_DefaultPassword.Paint += FormComm.DrawBtnEnabled;
            btn_Enter.Click += Btn_Enter_Click;
        }

        private void ConfirmDistanceOldPassword_Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void Tb_OldPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Btn_Enter_Click(null, null);
            }
            e.Handled = LimitInput.InputNumber(e.KeyChar);
        }

        private void Btn_Enter_Click(object sender, EventArgs e)
        {
            string oldpassowrd = tb_OldPassword.Text.Trim();
            if (oldpassowrd.Length == 0)
            {
                l_OldTitle.Text = "旧口令不能为空";
                l_OldTitle.ForeColor = Color.Red;
                tb_OldPassword.Focus();
                return;
            }
            if (oldpassowrd.Length != tb_OldPassword.MaxLength)
            {
                MessageBox.Show("旧口令长度为 6 位数字，请重新输入。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb_OldPassword.Focus();
                return;
            }
            Tag = oldpassowrd;
            this.DialogResult = DialogResult.OK;
        }

        private void Btn_DefaultPassword_Click(object sender, EventArgs e)
        {
            tb_OldPassword.Text = "766554";
            tb_OldPassword.Focus();
            tb_OldPassword.SelectionStart = tb_OldPassword.TextLength;
        }

        private void Tb_OldPassword_TextChanged(object sender, EventArgs e)
        {
            l_OldTitle.Visible = tb_OldPassword.TextLength == 0;
            btn_DefaultPassword.Enabled = tb_OldPassword.TextLength == 0;
        }

        private void L_OldTitle_MouseDown(object sender, MouseEventArgs e)
        {
            tb_OldPassword.Focus();
        }
    }
}
