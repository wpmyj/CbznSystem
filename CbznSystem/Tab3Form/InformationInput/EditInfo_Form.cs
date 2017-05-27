using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bll;
using NewControl;
using Model;
using Dal;

namespace CbznSystem
{
    public partial class EditInfo_Form : NewForm
    {
        private CbCardInfo mCardInfo;

        public EditInfo_Form(CbCardInfo mcardinfo)
        {
            InitializeComponent();

            this.mCardInfo = mcardinfo;

            this.Load += AddInfo_Load;
            this.KeyDown += EditInfo_Form_KeyDown;

            l_UserNameTitle.MouseDown += L_UserNameTitle_MouseDown;
            tb_UserName.TextChanged += Tb_UserName_TextChanged;
            tb_UserName.KeyPress += Tb_UserName_KeyPress;
            l_PlateNumberTitle.MouseDown += L_PlateNumberTitle_MouseDown;
            tb_PlateNumber.TextChanged += Tb_PlateNumber_TextChanged;
            tb_PlateNumber.KeyPress += Tb_PlateNumber_KeyPress;
            cb_Sex.KeyPress += Cb_Sex_KeyPress;
            ud_Age.KeyPress += ud_Age_KeyPress;
            l_PhoneTitle.MouseDown += L_PhoneTitle_MouseDown;
            tb_Phone.TextChanged += Tb_Phone_TextChanged;
            tb_Phone.KeyPress += Tb_Phone_KeyPress;
            tb_Address.KeyPress += Tb_Address_KeyPress;
            btn_Enter.Click += Btn_Enter_Click;
            btn_SetPlate.Click += Btn_SetPlate_Click;
        }

        private void EditInfo_Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void Btn_SetPlate_Click(object sender, EventArgs e)
        {
            using (InputPlate_Form inputplate = new InputPlate_Form(tb_PlateNumber.Text.Trim()))
            {
                if (inputplate.ShowDialog() != DialogResult.OK) return;
                string platenumber = inputplate.Tag as string;
                tb_PlateNumber.Text = platenumber;
                tb_PlateNumber.Focus();
                tb_PlateNumber.SelectionStart = tb_PlateNumber.TextLength;
            }
        }

        private void Cb_Sex_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ud_Age.Focus();
            }
        }

        private void Btn_Enter_Click(object sender, EventArgs e)
        {
            string username = tb_UserName.Text.Trim();
            string platenumber = tb_PlateNumber.Text.Trim();
            int sex = cb_Sex.SelectedIndex;
            int age = (int)ud_Age.Value;
            string phone = tb_Phone.Text.Trim();
            string address = tb_Address.Text.Trim();
            if (username.Length == 0)
            {
                //l_UserNameTitle.Text = "用户名称不能为空";
                //l_UserNameTitle.ForeColor = Color.Red;
                tb_UserName.Focus();
                return;
            }
            //if (platenumber.Length == 0)
            //{
            //    l_PlateNumberTitle.Text = "车牌号码不能为空";
            //    l_PlateNumberTitle.ForeColor = Color.Red;
            //    tb_PlateNumber.Focus();
            //    return;
            //}
            //if (phone.Length == 0)
            //{
            //    l_PhoneTitle.Text = "电话号码不能为空";
            //    l_PhoneTitle.ForeColor = Color.Red;
            //    tb_Phone.Focus();
            //    return;
            //}
            mCardInfo.UserName = username;
            mCardInfo.PlateNumber = platenumber;
            mCardInfo.UserSex = sex;
            mCardInfo.UserAge = age;
            mCardInfo.UserPhone = phone;
            mCardInfo.UserAddress = address;
            try
            {
                Dbhelper.Db.Update<CbCardInfo>(mCardInfo);
                this.Tag = mCardInfo;
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Tb_Address_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Btn_Enter_Click(null, null);
            }
        }

        private void Tb_Phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                tb_Address.Focus();
            }
        }

        private void Tb_Phone_TextChanged(object sender, EventArgs e)
        {
            l_PhoneTitle.Visible = tb_Phone.TextLength == 0;
        }

        private void L_PhoneTitle_MouseDown(object sender, MouseEventArgs e)
        {
            tb_Phone.Focus();
        }

        private void ud_Age_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                tb_Phone.Focus();
            }
        }

        private void Tb_PlateNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cb_Sex.Focus();
            }
        }

        private void Tb_PlateNumber_TextChanged(object sender, EventArgs e)
        {
            l_PlateNumberTitle.Visible = tb_PlateNumber.TextLength == 0;
        }

        private void L_PlateNumberTitle_MouseDown(object sender, MouseEventArgs e)
        {
            tb_PlateNumber.Focus();
        }

        private void Tb_UserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                tb_PlateNumber.Focus();
            }
        }

        private void Tb_UserName_TextChanged(object sender, EventArgs e)
        {
            l_UserNameTitle.Visible = tb_UserName.TextLength == 0;
        }

        private void L_UserNameTitle_MouseDown(object sender, MouseEventArgs e)
        {
            tb_UserName.Focus();
        }

        private void AddInfo_Load(object sender, EventArgs e)
        {
            tb_UserName.Text = mCardInfo.UserName;
            tb_PlateNumber.Text = mCardInfo.PlateNumber;
            cb_Sex.SelectedIndex = mCardInfo.UserSex;
            ud_Age.Value = mCardInfo.UserAge;
            tb_Phone.Text = mCardInfo.UserPhone;
            tb_Address.Text = mCardInfo.UserAddress;
        }
    }
}
