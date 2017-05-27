using System.IO;
using Bll;
using Dal;
using Model;
using NewControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CbznSystem
{
    public partial class RemoteConnectionSettings_Form : NewForm
    {
        public RemoteConnectionSettings_Form()
        {
            InitializeComponent();

            this.Load += RemoteConnectionSettings_Form_Load;
            this.KeyDown += RemoteConnectionSettings_Form_KeyDown;

            cb_VisitState.SelectedIndexChanged += Cb_VisitState_SelectedIndexChanged;
            tb_IpAddress.KeyPress += Tb_IpAddress_KeyPress;
            tb_IpAddress.KeyDown += tb_IpAddress_KeyDown;
            tb_LoginName.KeyPress += Tb_LoginName_KeyPress;
            tb_Password.KeyPress += Tb_Password_KeyPress;

            btn_Test.Click += Btn_Test_Click;
            btn_Test.Paint += FormComm.DrawBtnEnabled;
            btn_Save.Click += Btn_Save_Click;
        }

        private void RemoteConnectionSettings_Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4 && e.Alt)
            {
                e.Handled = true;
            }
        }

        private void Tb_IpAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == 46)
            {
                return;
            }
            e.Handled = LimitInput.InputNumber(e.KeyChar);
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            if (cb_VisitState.SelectedIndex == 0)
            {
                string filepath = string.Format(@"{0}\Data\Mtc.db", Application.StartupPath);
                if (!File.Exists(filepath))
                {
                    MessageBox.Show("数据库文件不存，请重新安装应用程序。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Dbhelper.InitSqlitePort(filepath);
            }
            else
            {
                if (!ValidationContent()) return;
                if (!TestSqlConnection()) return;

                string ip = tb_IpAddress.Text.Replace(" ", "");
                string loginname = tb_LoginName.Text.Trim();
                string password = tb_Password.Text.Trim();

                Dal_SysSettings.SystemSettings.RemoteConnectionIP = ip;
                Dal_SysSettings.SystemSettings.RemoteConnectionUserID = loginname;
                Dal_SysSettings.SystemSettings.RemoteConnectionPwd = password;

                try
                {
                    string sqlConnectionStr = string.Format("Data Source = {0},1433;Network Library = DBMSSOCN;Initial Catalog = master;User ID = {1};Password = {2}", ip, loginname, password);
                    using (SqlConnection conn = new SqlConnection(sqlConnectionStr))
                    {
                        SqlCommand comm = new SqlCommand("select COUNT(name) from sys.databases where name = 'Mtc' ", conn);
                        conn.Open();
                        try
                        {
                            object obj = comm.ExecuteScalar();
                            int count = Convert.ToInt32(obj);
                            if (count == 0)
                            {
                                comm.CommandText = " Create DataBase Mtc ";
                                comm.ExecuteNonQuery();
                            }

                            Dbhelper.InitSqlPort(ip, loginname, password);

                            if (count == 0)
                            {
                                Dbhelper.Db.ExecuteNonQuery(Dbhelper.CreateSqlDb());
                            }
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    CustomExceptionHandler.GetExceptionMessage(ex);
                    MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            Dal_SysSettings.SystemSettings.RemoteConnection = cb_VisitState.SelectedIndex;
            XmlHelper.Update<CbSysSettings>(Dal_SysSettings.SystemSettings);
            Close();
        }

        private void RemoteConnectionSettings_Form_Load(object sender, EventArgs e)
        {
            cb_VisitState.SelectedIndex = Dal_SysSettings.SystemSettings.RemoteConnection;
            tb_LoginName.Text = Dal_SysSettings.SystemSettings.RemoteConnectionUserID;
            tb_IpAddress.Text = Dal_SysSettings.SystemSettings.RemoteConnectionIP;
        }

        private void Cb_VisitState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_VisitState.SelectedIndex == 0)
            {
                tb_IpAddress.Enabled = false;
                l_IpAddressTitle.ForeColor = Color.Gray;
                tb_LoginName.Enabled = false;
                l_LoginNameTitle.ForeColor = Color.Gray;
                tb_Password.Enabled = false;
                l_PasswordTitle.ForeColor = Color.Gray;
                btn_Test.Enabled = false;
            }
            else
            {
                tb_IpAddress.Enabled = true;
                l_IpAddressTitle.ForeColor = Color.Black;
                tb_Password.Enabled = true;
                l_PasswordTitle.ForeColor = Color.Black;
                tb_LoginName.Enabled = true;
                l_LoginNameTitle.ForeColor = Color.Black;
                btn_Test.Enabled = true;
            }
        }

        private bool ValidationContent()
        {
            string ip = tb_IpAddress.Text.Trim();
            string loginname = tb_LoginName.Text.Trim();
            string password = tb_Password.Text.Trim();
            if (!CRegex.IsIpAddress(ip))
            {
                MessageBox.Show(ip + " IP地址有误(例:192.168.0.100)，请重新输入。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb_IpAddress.Focus();
                return false;
            }
            if (loginname.Length == 0)
            {
                MessageBox.Show("登录名不能为空，请重新输入。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb_LoginName.Focus();
                return false;
            }
            if (password.Length == 0)
            {
                MessageBox.Show("密码不能为空，请重新输入。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb_Password.Focus();
                return false;
            }
            return true;
        }

        private bool TestSqlConnection()
        {
            bool IsCanConnectioned = false;
            string ip = tb_IpAddress.Text.Trim();
            string loginname = tb_LoginName.Text.Trim();
            string password = tb_Password.Text.Trim();

            string strTestConnection = string.Format("Data Source = {0},1433;Network Library = DBMSSOCN;Initial Catalog = master;User ID = {1};Password = {2}", ip, loginname, password);
            //string strTestConnection = string.Format("Data Source = .;Initial Catalog = master;User Id = {0};Password = {1};", loginname, password);
            SqlConnection conn = new SqlConnection(strTestConnection);
            try
            {
                conn.Open();
                IsCanConnectioned = true;
            }
            catch (Exception ex)
            {
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
            return IsCanConnectioned;
        }

        private void Btn_Test_Click(object sender, EventArgs e)
        {
            if (!ValidationContent()) return;
            if (TestSqlConnection())
            {
                MessageBox.Show("数据库连接成功", "提示", MessageBoxButtons.OK);
            }
        }

        private void Tb_Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Btn_Test_Click(null, null);
            }
        }

        private void Tb_LoginName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                tb_Password.Focus();
            }
        }

        private void tb_IpAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Decimal)
            {
                int pos = tb_IpAddress.SelectionStart;
                int index = tb_IpAddress.Text.IndexOf('.', pos);
                if (index == -1) return;
                tb_IpAddress.SelectionStart = index + 1;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                tb_LoginName.Focus();
            }
        }
    }
}
