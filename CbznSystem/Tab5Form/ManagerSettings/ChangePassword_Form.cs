using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bll;
using Dal;
using Model;
using NewControl;

namespace CbznSystem
{
    public partial class ChangePassword_Form : NewForm
    {
        private CbManageInfo _mManageInfo;

        public ChangePassword_Form(CbManageInfo mManageInfo)
        {
            InitializeComponent();

            this.Load += ChangePassword_Form_Load;
            this.KeyDown += ChangePassword_Form_KeyDown;

            _mManageInfo = mManageInfo;

            l_OldTitle.MouseDown += L_OldTitle_MouseDown;
            tb_OldPassword.TextChanged += Tb_OldPassword_TextChanged;
            tb_OldPassword.KeyPress += Tb_OldPassword_KeyPress;
            l_NewTitle.MouseDown += L_NewTitle_MouseDown;
            tb_NewPassword.TextChanged += Tb_NewPassword_TextChanged;
            tb_NewPassword.KeyPress += Tb_NewPassword_KeyPress;
            l_ConfirmTitle.MouseDown += L_ConfirmTitle_MouseDown;
            tb_ConfirmPassword.TextChanged += Tb_ConfirmPassword_TextChanged;
            tb_ConfirmPassword.KeyPress += Tb_ConfirmPassword_KeyPress;

            btn_Enter.Click += Btn_Enter_Click;
        }

        private void ChangePassword_Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void Btn_Enter_Click(object sender, EventArgs e)
        {
            string oldpwd = tb_OldPassword.Text.Trim();
            string newpwd = tb_NewPassword.Text.Trim();
            string confirmpwd = tb_ConfirmPassword.Text.Trim();
            if (_mManageInfo.ManageType != 0 && oldpwd.Length == 0)
            {
                l_OldTitle.ForeColor = Color.Red;
                tb_OldPassword.Focus();
                tb_OldPassword.SelectionStart = tb_OldPassword.TextLength;
                return;
            }
            if (oldpwd != _mManageInfo.ManagePwd)
            {
                MessageBox.Show("旧密码错误，请重新输入旧密码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb_OldPassword.Focus();
                tb_OldPassword.SelectionStart = tb_OldPassword.TextLength;
                return;
            }
            if (newpwd.Length == 0)
            {
                //l_NewTitle.Text = "新密码不能为空";
                l_NewTitle.ForeColor = Color.Red;
                tb_NewPassword.Focus();
                return;
            }
            if (newpwd.Length < 6)
            {
                MessageBox.Show("密码长度为 6-18 位数字、字母", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb_NewPassword.Focus();
                tb_NewPassword.SelectionStart = tb_NewPassword.TextLength;
                return;
            }
            if (confirmpwd.Length == 0)
            {
                //l_ConfirmTitle.Text = "确认密码不能为空";
                l_ConfirmTitle.ForeColor = Color.Red;
                tb_ConfirmPassword.Focus();
                return;
            }
            if (confirmpwd.Length < 6)
            {
                MessageBox.Show("密码长度为 6-18 位数字、字母", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb_ConfirmPassword.Focus();
                tb_ConfirmPassword.SelectionStart = tb_ConfirmPassword.TextLength;
                return;
            }
            if (newpwd != confirmpwd)
            {
                MessageBox.Show("密码与确认密码不一致，请重新输入。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb_ConfirmPassword.Focus();
                tb_ConfirmPassword.SelectionStart = tb_ConfirmPassword.TextLength;
                return;
            }
            try
            {
                _mManageInfo.ManagePwd = newpwd;
                Dbhelper.Db.Update<CbManageInfo>(_mManageInfo);
                if (_mManageInfo.ID == Dal_ManageInfo.ManageInfo.ID)
                    Dal_ManageInfo.ManageInfo = _mManageInfo;
                this.Tag = _mManageInfo;
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Tb_ConfirmPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Btn_Enter_Click(null, null);
            }
            e.Handled = LimitInput.InputNumberAndLetter(e.KeyChar);
        }

        private void Tb_ConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            l_ConfirmTitle.Visible = tb_ConfirmPassword.TextLength == 0;
        }

        private void L_ConfirmTitle_MouseDown(object sender, MouseEventArgs e)
        {
            tb_ConfirmPassword.Focus();
        }

        private void Tb_NewPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                tb_ConfirmPassword.Focus();
            }
            e.Handled = LimitInput.InputNumberAndLetter(e.KeyChar);
        }

        private void Tb_NewPassword_TextChanged(object sender, EventArgs e)
        {
            l_NewTitle.Visible = tb_NewPassword.TextLength == 0;
        }

        private void L_NewTitle_MouseDown(object sender, MouseEventArgs e)
        {
            tb_NewPassword.Focus();
        }

        private void Tb_OldPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                tb_NewPassword.Focus();
            }
            e.Handled = LimitInput.InputNumberAndLetter(e.KeyChar);
        }

        private void Tb_OldPassword_TextChanged(object sender, EventArgs e)
        {
            l_OldTitle.Visible = tb_OldPassword.TextLength == 0;
        }

        private void L_OldTitle_MouseDown(object sender, MouseEventArgs e)
        {
            tb_OldPassword.Focus();
        }

        private void ChangePassword_Form_Load(object sender, EventArgs e)
        {

        }
    }
}
