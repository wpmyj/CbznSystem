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
    public partial class ControlBoardPassword_Form : NewForm
    {
        public ControlBoardPassword_Form()
        {
            InitializeComponent();

            this.Load += ControlBoardPassword_Form_Load;
            this.KeyDown += ControlBoardPassword_Form_KeyDown;

            cb_ControlBoardType.SelectedIndexChanged += Cb_ControlBoardType_SelectedIndexChanged;
            l_NewTitle.MouseDown += L_NewTitle_MouseDown;
            l_ConfirmTitle.MouseDown += L_ConfirmTitle_MouseDown;
            tb_NewPassword.TextChanged += Tb_NewPassword_TextChanged;
            tb_NewPassword.KeyPress += Tb_NewPassword_KeyPress;
            tb_ConfirmPassword.TextChanged += Tb_ConfirmPassword_TextChanged;
            tb_ConfirmPassword.KeyPress += Tb_ConfirmPassword_KeyPress;

            btn_Enter.Click += Btn_Enter_Click;
        }

        private void ControlBoardPassword_Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void Cb_ControlBoardType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_ControlBoardType.SelectedIndex == 0)
            {
                tb_NewPassword.Enabled = true;
                tb_ConfirmPassword.Enabled = true;
                l_NewTitle.Visible = true;
                l_ConfirmTitle.Visible = true;
            }
            else
            {
                tb_ConfirmPassword.Text = string.Empty;
                tb_NewPassword.Text = string.Empty;
                tb_ConfirmPassword.Enabled = false;
                tb_NewPassword.Enabled = false;
                l_NewTitle.Visible = false;
                l_ConfirmTitle.Visible = false;
            }
        }

        private void Btn_Enter_Click(object sender, EventArgs e)
        {
            string newpassword = tb_NewPassword.Text.Trim();
            string confirmpassword = tb_ConfirmPassword.Text.Trim();
            if (cb_ControlBoardType.SelectedIndex == 0)
            {
                if (newpassword.Length == 0)
                {
                    l_NewTitle.Text = "新密码不能为空";
                    l_NewTitle.ForeColor = Color.Red;
                    tb_NewPassword.Focus();
                    return;
                }
                if (newpassword.Length != tb_NewPassword.MaxLength)
                {
                    MessageBox.Show("密码长度为 6 位数字", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tb_NewPassword.Focus();
                    return;
                }

                if (confirmpassword.Length == 0)
                {
                    l_ConfirmTitle.Text = "确认密码不能为空";
                    l_ConfirmTitle.ForeColor = Color.Red;
                    tb_ConfirmPassword.Focus();
                    return;
                }
                if (confirmpassword.Length != tb_ConfirmPassword.MaxLength)
                {
                    MessageBox.Show("确认密码长度为 6 位数字", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tb_ConfirmPassword.Focus();
                    return;
                }
                Tag = "3355AAEE" + newpassword;
            }
            else
            {
                Tag = "00000000000000";
            }
            this.DialogResult = DialogResult.OK;
        }

        private void Tb_ConfirmPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Btn_Enter_Click(null, null);
            }
            e.Handled = LimitInput.InputNumber(e.KeyChar);
        }

        private void Tb_NewPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                tb_ConfirmPassword.Focus();
            }
            e.Handled = LimitInput.InputNumber(e.KeyChar);
        }

        private void Tb_ConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            l_ConfirmTitle.Visible = tb_ConfirmPassword.TextLength == 0;
        }

        private void Tb_NewPassword_TextChanged(object sender, EventArgs e)
        {
            l_NewTitle.Visible = tb_NewPassword.TextLength == 0;
        }

        private void L_ConfirmTitle_MouseDown(object sender, MouseEventArgs e)
        {
            tb_ConfirmPassword.Focus();
        }

        private void L_NewTitle_MouseDown(object sender, MouseEventArgs e)
        {
            tb_NewPassword.Focus();
        }

        private void ControlBoardPassword_Form_Load(object sender, EventArgs e)
        {
            cb_ControlBoardType.SelectedIndex = 0;
        }
    }
}
