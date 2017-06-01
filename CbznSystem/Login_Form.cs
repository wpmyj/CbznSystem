using Bll;
using Dal;
using Db_Rom;
using Model;
using NewControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CbznSystem
{
    public partial class Login_Form : NewForm
    {
        public Login_Form()
        {
            InitializeComponent();

            this.Load += Login_Form_Load;
            this.SettingsClick += Login_Form_SettingsClick;

            cb_RecordPassword.KeyPress += Cb_RecordPassword_KeyPress;
            l_AccountsTitle.MouseDown += L_AccountsTitle_MouseDown;
            l_PasswordTitle.MouseDown += L_PasswordTitle_MouseDown;
            tb_Accounts.TextChanged += Tb_Accounts_TextChanged;
            tb_Accounts.KeyPress += Tb_Accounts_KeyPress;
            tb_Password.TextChanged += Tb_Password_TextChanged;
            tb_Password.KeyPress += Tb_Password_KeyPress;
            btn_Enter.Click += Btn_Enter_Click;
        }

        private void Login_Form_SettingsClick(object sender, EventArgs e)
        {
            using (RemoteConnectionSettings_Form remoteconnection = new RemoteConnectionSettings_Form())
            {
                remoteconnection.Location = this.Location;
                remoteconnection.ShowDialog();
            }
        }

        private void Cb_RecordPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Btn_Enter_Click(null, null);
            }
        }

        private void Login_Form_Load(object sender, EventArgs e)
        {
            //加载配置文件
            XmlHelper.FilePath = string.Format(@"{0}\\SystemSettings.xml", Application.StartupPath);
            if (!File.Exists(XmlHelper.FilePath))
            {
                XmlHelper.Create();
                Dal_SysSettings.SystemSettings = new CbSysSettings();
                XmlHelper.Add<CbSysSettings>(Dal_SysSettings.SystemSettings);
            }
            else
            {
                Dal_SysSettings.SystemSettings = XmlHelper.Load<CbSysSettings>();
            }

            //初始化数据库
            if (Dal_SysSettings.SystemSettings.RemoteConnection == 0)
            {
                //连接sqlite数据库
                string filepath = string.Format(@"{0}\Data\Mtc.db", Application.StartupPath);
                Dbhelper.InitSqlitePort(filepath);

                UpdateSqliteContent();
            }
            else
            {
                //连接sql数据库
                Dbhelper.InitSqlPort(Dal_SysSettings.SystemSettings.RemoteConnectionIP, Dal_SysSettings.SystemSettings.RemoteConnectionUserID, Dal_SysSettings.SystemSettings.RemoteConnectionPwd);

                UpdateSqlContent();
            }

            tb_Accounts.Text = Dal_SysSettings.SystemSettings.ManageAccount;
            if (Dal_SysSettings.SystemSettings.IsSavePassword)
            {
                cb_RecordPassword.Checked = true;
                tb_Password.Text = Dal_SysSettings.SystemSettings.ManagePassword;
            }
        }

        private void UpdateSqliteContent()
        {
            try
            {
                if (Dal_SysSettings.SystemSettings.Version != Application.ProductVersion)
                {
                    StringBuilder sb = new StringBuilder();

                    string cmdtext = " select sql from sqlite_master where name='CBDeviceInfo' ";
                    DataTable dt = Dbhelper.Db.ToTable(cmdtext);
                    if (dt.Rows.Count > 0)
                    {
                        string sql = dt.Rows[0]["sql"].ToString();
                        if (!sql.Contains("VagueQueryNumber"))
                        {
                            sb.Append(" alter table CBDeviceInfo add column VagueQueryNumber INT default(0) ; ");
                        }
                    }

                    cmdtext = " select sql from sqlite_master where name='CBTempChargeRecord' ";
                    dt = Dbhelper.Db.ToTable(cmdtext);
                    if (dt.Rows.Count > 0)
                    {
                        string sql = dt.Rows[0]["sql"].ToString();
                        if (!sql.Contains("ExitNumber"))
                        {
                            sb.Append(" alter table CBTempChargeRecord add column ExitNumber Int Default(0) ; ");
                        }
                    }

                    if (sb.Length > 0)
                    {
                        Dbhelper.Db.ExecuteNonQuery(sb.ToString());
                    }

                    Dal_SysSettings.SystemSettings.Version = Application.ProductVersion;
                    XmlHelper.Update<CbSysSettings>(Dal_SysSettings.SystemSettings);
                }
            }
            catch (Exception ex)
            {
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateSqlContent()
        {
            try
            {
                if (Dal_SysSettings.SystemSettings.Version != Application.ProductVersion)
                {
                    StringBuilder sb = new StringBuilder();

                    sb.Append(@" if not exists( select name from sys.columns where name='VagueQueryNumber' and object_id = ( select object_id from sys.tables where name = 'CBDeviceInfo') )
	alter table CbDeviceInfo add VagueQueryNumber int not null default 0 ");

                    sb.Append(@" if not exists( select name from sys.columns where name='ExitNumber' and object_id = ( select object_id from sys.tables where name = 'CBTempChargeRecord') )
	alter table CBTempChargeRecord add ExitNumber int not null default 0 ");

                    Dbhelper.Db.ExecuteNonQuery(sb.ToString());

                    Dal_SysSettings.SystemSettings.Version = Application.ProductVersion;
                    XmlHelper.Update<CbSysSettings>(Dal_SysSettings.SystemSettings);
                }
            }
            catch (Exception ex)
            {
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Tb_Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Btn_Enter_Click(null, null);
            }
            e.Handled = LimitInput.InputNumberAndLetter(e.KeyChar);
        }

        private void Tb_Accounts_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                tb_Password.Focus();
            }
            e.Handled = LimitInput.InputNumberAndLetter(e.KeyChar);
        }

        private void Tb_Password_TextChanged(object sender, EventArgs e)
        {
            l_PasswordTitle.Visible = tb_Password.TextLength == 0;
        }

        private void Tb_Accounts_TextChanged(object sender, EventArgs e)
        {
            l_AccountsTitle.Visible = tb_Accounts.TextLength == 0;
        }

        private void L_PasswordTitle_MouseDown(object sender, MouseEventArgs e)
        {
            tb_Password.Focus();
        }

        private void L_AccountsTitle_MouseDown(object sender, MouseEventArgs e)
        {
            tb_Accounts.Focus();
        }

        private void Btn_Enter_Click(object sender, EventArgs e)
        {
            string account = tb_Accounts.Text.Trim();
            string password = tb_Password.Text.Trim();
            if (account.Length == 0)
            {
                l_AccountsTitle.Text = "帐号不能为空";
                l_AccountsTitle.ForeColor = Color.Red;
                tb_Accounts.Focus();
                return;
            }
            //if (password.Length == 0)
            //{
            //    l_PasswordTitle.Text = "密码不能为空";
            //    l_PasswordTitle.ForeColor = Color.Red;
            //    tb_Password.Focus();
            //    return;
            //}
            try
            {
                CbManageInfo Manage = Dal_ManageInfo.GetManage(account, password);
                if (Manage == null)
                {
                    MessageBox.Show("帐号或密码错误", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (account != Dal_SysSettings.SystemSettings.ManageAccount || cb_RecordPassword.Checked != Dal_SysSettings.SystemSettings.IsSavePassword || password != Dal_SysSettings.SystemSettings.ManagePassword)
                {
                    Dal_SysSettings.SystemSettings.ManageAccount = account;
                    Dal_SysSettings.SystemSettings.IsSavePassword = cb_RecordPassword.Checked;
                    Dal_SysSettings.SystemSettings.ManagePassword = password;
                    XmlHelper.Update<CbSysSettings>(Dal_SysSettings.SystemSettings);
                }
                Dal_ManageInfo.ManageInfo = Manage;
                Dal_ManageRights.ManageRights = Dbhelper.Db.FirstDefault<CbManageRights>(" and UserId=" + Manage.ID);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 解决窗体切换而产生的控件闪烁问题
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

    }
}
