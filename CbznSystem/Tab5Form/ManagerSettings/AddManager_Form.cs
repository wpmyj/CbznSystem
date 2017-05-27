using System.Reflection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Model;
using NewControl;
using Bll;
using Dal;

namespace CbznSystem
{
    public partial class AddManager_Form : NewForm
    {
        public AddManager_Form()
        {
            InitializeComponent();

            this.Load += AddManager_Form_Load;
            this.KeyDown += AddManager_Form_KeyDown;

            l_AccountsTitle.MouseDown += L_AccountsTitle_MouseDown;
            tb_Accounts.TextChanged += Tb_Accounts_TextChanged;
            tb_Accounts.KeyPress += Tb_Accounts_KeyPress;
            l_NameTitle.MouseDown += L_NameTitle_MouseDown;
            tb_Name.TextChanged += Tb_Name_TextChanged;
            tb_Name.KeyPress += Tb_Name_KeyPress;
            l_PasswordTitle.MouseDown += L_PasswordTitle_MouseDown;
            tb_Password.TextChanged += Tb_Password_TextChanged;
            tb_Password.KeyPress += Tb_Password_KeyPress;
            l_ConfrimTitle.MouseDown += L_ConfrimTitle_MouseDown;
            tb_ConfirmPassword.TextChanged += Tb_ConfirmPassword_TextChanged;
            tb_ConfirmPassword.KeyPress += Tb_ConfirmPassword_KeyPress;
            btn_Enter.Click += Btn_Enter_Click;
        }

        private void AddManager_Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
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

        private void Tb_Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                tb_ConfirmPassword.Focus();
            }
            e.Handled = LimitInput.InputNumberAndLetter(e.KeyChar);

        }

        private void Tb_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                tb_Password.Focus();
            }
        }

        private void Tb_Accounts_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                tb_Name.Focus();
            }
            e.Handled = LimitInput.InputNumberAndLetter(e.KeyChar);
        }

        private void Tb_ConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            l_ConfrimTitle.Visible = tb_ConfirmPassword.TextLength == 0;
        }

        private void Tb_Password_TextChanged(object sender, EventArgs e)
        {
            l_PasswordTitle.Visible = tb_Password.TextLength == 0;
        }

        private void Tb_Name_TextChanged(object sender, EventArgs e)
        {
            l_NameTitle.Visible = tb_Name.TextLength == 0;
        }

        private void Tb_Accounts_TextChanged(object sender, EventArgs e)
        {
            l_AccountsTitle.Visible = tb_Accounts.TextLength == 0;
        }

        private void L_ConfrimTitle_MouseDown(object sender, MouseEventArgs e)
        {
            tb_ConfirmPassword.Focus();
        }

        private void L_PasswordTitle_MouseDown(object sender, MouseEventArgs e)
        {
            tb_Password.Focus();
        }

        private void L_NameTitle_MouseDown(object sender, MouseEventArgs e)
        {
            tb_Name.Focus();
        }

        private void L_AccountsTitle_MouseDown(object sender, MouseEventArgs e)
        {
            tb_Accounts.Focus();
        }

        private void Btn_Enter_Click(object sender, EventArgs e)
        {
            string account = tb_Accounts.Text.Trim();
            string name = tb_Name.Text.Trim();
            string password = tb_Password.Text.Trim();
            string confirmpassword = tb_ConfirmPassword.Text.Trim();
            int index = cb_ManageType.SelectedIndex;
            if (account.Length == 0)
            {
                //l_AccountsTitle.Text = "帐号不能为空";
                l_AccountsTitle.ForeColor = Color.Red;
                tb_Accounts.Focus();
                return;
            }
            if (account.Length < 6)
            {
                MessageBox.Show("帐号长度不能小于 6 位，请重新输入。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb_Accounts.Focus();
                tb_Accounts.SelectionStart = tb_Accounts.TextLength;
                return;
            }
            if (name.Length == 0)
            {
                //l_NameTitle.Text = "用户名称不能为空";
                l_NameTitle.ForeColor = Color.Red;
                tb_Name.Focus();
                return;
            }
            if (password.Length == 0)
            {
                //l_PasswordTitle.Text = "密码不能为空";
                l_PasswordTitle.ForeColor = Color.Red;
                tb_Password.Focus();
                return;
            }
            if (password.Length < 6)
            {
                MessageBox.Show("密码长度不能小于 6 位，请重新输入。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb_Password.Focus();
                tb_Password.SelectionStart = tb_Password.TextLength;
                return;
            }
            if (confirmpassword.Length == 0)
            {
                //l_ConfrimTitle.Text = "确认密码不能为空";
                l_ConfrimTitle.ForeColor = Color.Red;
                tb_ConfirmPassword.Focus();
                return;
            }
            if (confirmpassword.Length < 6)
            {
                MessageBox.Show("确认密码长度不能小于 6 位，请重新输入。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb_ConfirmPassword.Focus();
                tb_ConfirmPassword.SelectionStart = tb_ConfirmPassword.TextLength;
                return;
            }
            if (password != confirmpassword)
            {
                MessageBox.Show("密码与确认密码不一致，请重新输入。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb_ConfirmPassword.Focus();
                tb_ConfirmPassword.SelectionStart = tb_ConfirmPassword.TextLength;
                return;
            }
            try
            {
                int count = Dbhelper.Db.GetCount<CbManageInfo>("ManageName", string.Format(" and ManageName='{0}' ", account));
                if (count > 0)
                {
                    MessageBox.Show(string.Format("{0} 已经存在", account), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tb_Accounts.Focus();
                    tb_Accounts.SelectionStart = tb_Accounts.TextLength;
                    return;
                }
                CbManageInfo mManageInfo = new CbManageInfo()
                {
                    ManageName = account,
                    ManagePwd = password,
                    ManageType = index + 1,
                    UserName = name
                };
                mManageInfo.ID = Dbhelper.Db.Insert<CbManageInfo>(mManageInfo);
                //添加权限
                CbManageRights mManageRights = new CbManageRights() { UserID = mManageInfo.ID };
                PropertyInfo[] pinfos = typeof(CbManageRights).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                foreach (PropertyInfo item in pinfos)
                {
                    if (item.PropertyType == typeof(Boolean))
                    {
                        item.SetValue(mManageRights, true, null);
                    }
                }
                Dbhelper.Db.Insert<CbManageRights>(mManageRights);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AddManager_Form_Load(object sender, EventArgs e)
        {
            cb_ManageType.SelectedIndex = 0;
        }
    }
}
