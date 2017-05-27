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
    public partial class EditManager_Form : NewForm
    {
        private CbManageInfo _mManageInfo;

        public EditManager_Form(CbManageInfo mManageInfo)
        {
            InitializeComponent();

            this._mManageInfo = mManageInfo;

            this.Load += AddManager_Form_Load;
            this.KeyDown += EditManager_Form_KeyDown;

            l_AccountsTitle.MouseDown += L_AccountsTitle_MouseDown;
            tb_Accounts.TextChanged += Tb_Accounts_TextChanged;
            l_NameTitle.MouseDown += L_NameTitle_MouseDown;
            tb_Name.TextChanged += Tb_Name_TextChanged;
            tb_Name.KeyPress += Tb_Name_KeyPress;
            btn_Enter.Click += Btn_Enter_Click;
        }

        private void EditManager_Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void Tb_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Btn_Enter_Click(null, null);
            }
            //e.Handled = LimitInput.InputNumberAndLetter(e.KeyChar);
        }

        private void Tb_Name_TextChanged(object sender, EventArgs e)
        {
            l_NameTitle.Visible = tb_Name.TextLength == 0;
        }

        private void Tb_Accounts_TextChanged(object sender, EventArgs e)
        {
            l_AccountsTitle.Visible = tb_Accounts.TextLength == 0;
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
            int index = cb_ManageType.SelectedIndex + 1;
            if (account.Length == 0)
            {
                //l_AccountsTitle.Text = "帐号不能为空";
                l_AccountsTitle.ForeColor = Color.Red;
                tb_Accounts.Focus();
                return;
            }
            //if (account.Length < 6)
            //{
            //    MessageBox.Show("帐号长度不能小于 6 位，请重新输入。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    tb_Accounts.Focus();
            //    tb_Accounts.SelectionStart = tb_Accounts.TextLength;
            //    return;
            //}
            if (name.Length == 0)
            {
                //l_NameTitle.Text = "用户名称不能为空";
                l_NameTitle.ForeColor = Color.Red;
                tb_Name.Focus();
                return;
            }

            try
            {
                _mManageInfo.UserName = name;
                _mManageInfo.ManageType = index;
                Dbhelper.Db.Update<CbManageInfo>(_mManageInfo);
                if (_mManageInfo.ID == Dal_ManageInfo.ManageInfo.ID)
                    Dal_ManageInfo.ManageInfo = _mManageInfo;
                this.Tag = _mManageInfo;
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
            tb_Accounts.Text = _mManageInfo.ManageName;
            tb_Accounts.Enabled = false;
            tb_Name.Text = _mManageInfo.UserName;
        }
    }
}
