using Bll;
using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CbznSystem
{
    /// <summary>
    /// 多功能操作台设置
    /// </summary>
    public partial class PlatformSetting_Form : Form
    {

        private delegate void SerialPortCountChangeEvnetHandler(List<string> portnames);

        public PlatformSetting_Form()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(240, 243, 245);

            this.Load += PlatformSetting_Form_Load;
            this.Activated += PlatformSetting_Form_Activated;
            this.KeyDown += PlatformSetting_Form_KeyDown;

            cb_WirelessIdList.DropDown += Cb_WirelessIdList_DropDown;
            cb_WirelessIdList.SelectedIndexChanged += Cb_WirelessIdList_SelectedIndexChanged;
            cb_ManualSetting.CheckedChanged += Cb_ManualSetting_CheckedChanged;
            rbtn_AutoConnection.CheckedChanged += Rbtn_AutoConnection_CheckedChanged;
            rbtn_ManualConnection.CheckedChanged += Rbtn_ManualConnection_CheckedChanged;
            btn_SerialPortConnection.Click += Btn_SerialPortConnection_Click;
            btn_SerialPortConnection.Paint += FormComm.DrawBtnEnabled;
            btn_ModuleConnection.Paint += FormComm.DrawBtnEnabled;
            btn_ModuleConnection.EnabledChanged += Btn_ModuleConnection_EnabledChanged;
            btn_ModuleConnection.Click += Btn_ModuleConnection_Click;
            btn_ManualConnection.Paint += FormComm.DrawBtnEnabled;
            btn_ManualConnection.Click += Btn_ManualConnection_Click;
        }

        private void PlatformSetting_Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4 && e.Alt)
            {
                e.Handled = true;
            }
        }

        private void Btn_ModuleConnection_EnabledChanged(object sender, EventArgs e)
        {
            btn_ManualConnection.Enabled = btn_ModuleConnection.Enabled;
            cb_WirelessIdList.Enabled = btn_ModuleConnection.Enabled;
            ud_WirelessId.Enabled = btn_ModuleConnection.Enabled;
            ud_WirelessFrequency.Enabled = btn_ModuleConnection.Enabled;
        }

        private void PlatformSetting_Form_Activated(object sender, EventArgs e)
        {
            if (Tab4_Form.GetInstance.IsConnectionModule)
            {
                l_ModuleConnectionState.Text = "已连接";
                l_ModuleConnectionState.ForeColor = Color.Green;
            }
            else
            {
                l_ModuleConnectionState.Text = "未连接";
                l_ModuleConnectionState.ForeColor = Color.Red;
            }
        }

        private void Cb_WirelessIdList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_WirelessIdList.SelectedIndex > 0)
            {
                try
                {
                    CbDeviceInfo mDeviceInfo = Dbhelper.Db.FirstDefault<CbDeviceInfo>((long)cb_WirelessIdList.SelectedValue);
                    ud_WirelessId.Value = mDeviceInfo.IsLikeMachine == 0 ? mDeviceInfo.HostNumber : mDeviceInfo.WirelessID;
                    ud_WirelessFrequency.Value = mDeviceInfo.HostNumber > 64 ? mDeviceInfo.HostNumber - 64 : mDeviceInfo.HostNumber;
                }
                catch (Exception ex)
                {
                    CustomExceptionHandler.GetExceptionMessage(ex);
                    MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                ud_WirelessFrequency.Value = 1;
                ud_WirelessId.Value = 0;
            }
        }

        private void Cb_WirelessIdList_DropDown(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = Dbhelper.Db.ToTable<CbDeviceInfo>(" and Iosate=1 ");
                if (dt.Rows.Count == cb_WirelessIdList.Items.Count - 1)
                {
                    return;
                }
                DataTable newtable = new DataTable();
                newtable.Columns.AddRange(new DataColumn[] {
                    new DataColumn("ID",typeof(long)),
                    new DataColumn ("Description")
                });
                DataRow dr = newtable.NewRow();
                dr["ID"] = 0;
                dr["Description"] = "请选择(关闭)";
                newtable.Rows.Add(dr);
                foreach (DataRow item in dt.Rows)
                {
                    newtable.Rows.Add(new object[] { item["ID"], "编号" + item["HostNumber"] + " 序列号" + item["WirelessID"] });
                }
                cb_WirelessIdList.DisplayMember = "Description";
                cb_WirelessIdList.ValueMember = "ID";
                cb_WirelessIdList.DataSource = newtable;
            }
            catch (Exception ex)
            {
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 手动连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_ManualConnection_Click(object sender, EventArgs e)
        {
            Btn_ModuleConnection_Click(null, null);
        }

        private void Cb_ManualSetting_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_ManualSetting.Checked)
            {
                gb_WirelessSettings.Height = 270;
            }
            else
            {
                gb_WirelessSettings.Height = 165;
            }
        }

        /// <summary>
        /// 连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_ModuleConnection_Click(object sender, EventArgs e)
        {
            btn_ModuleConnection.Enabled = false;

            try
            {
                if (ud_WirelessId.Value == 0)
                {
                    //保存频道和ID
                    SaveWirelessParameter();
                    MessageBox.Show("搜索主机关闭成功。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (SearchWirelessFrequency_Form search = new SearchWirelessFrequency_Form((int)ud_WirelessId.Value, (int)ud_WirelessFrequency.Value))
                {
                    if (search.ShowDialog() == DialogResult.OK)
                    {
                        int frequency = Utils.ObjToInt(search.Tag, 1);
                        ud_WirelessFrequency.Value = frequency;
                        //保存频道和ID
                        SaveWirelessParameter();
                        l_ModuleConnectionState.Text = "已连接";
                        l_ModuleConnectionState.ForeColor = Color.Green;
                        Tab4_Form.GetInstance.IsConnectionModule = true;
                    }
                    else
                    {
                        l_ModuleConnectionState.Text = "未连接";
                        l_ModuleConnectionState.ForeColor = Color.Red;
                        Tab4_Form.GetInstance.IsConnectionModule = false;
                    }
                }
            }
            catch (Exception ex)
            {
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btn_ModuleConnection.Enabled = true;
            }
        }

        private void SaveWirelessParameter()
        {
            int wirelessid = (int)ud_WirelessId.Value;
            int wirelessfrequency = (int)ud_WirelessFrequency.Value;
            if (wirelessid != Dal_SysSettings.SystemSettings.SaveCommunicationID || wirelessfrequency != Dal_SysSettings.SystemSettings.SaveFrequency)
            {
                Dal_SysSettings.SystemSettings.SaveCommunicationID = wirelessid;
                Dal_SysSettings.SystemSettings.SaveFrequency = wirelessfrequency;
                XmlHelper.Update<CbSysSettings>(Dal_SysSettings.SystemSettings);
            }
        }

        private void Btn_SerialPortConnection_Click(object sender, EventArgs e)
        {
            if (PortHelper.sp.IsOpen)
            {
                try
                {
                    PortHelper.sp.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                SerialPortChange(PortHelper.IsConnection);
            }
            else
            {
                PortHelper.sp.PortName = cb_SerialPortName.SelectedItem.ToString();
                try
                {
                    PortHelper.sp.Open();

                    PortHelper.SerialPortWrite(PortAgreement.GetDistanceEncryption(Dal_DevicePwd.DistanceSystemPassword.Pwd));

                    Thread.Sleep(600);

                    if (!PortHelper.IsConnection)
                    {
                        PortHelper.sp.Close();
                        MessageBox.Show("当前端口连接失败，请选择正确的端口进行连接。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        SerialPortChange(PortHelper.IsConnection);
                    }
                }
                catch (Exception ex)
                {
                    CustomExceptionHandler.GetExceptionMessage(ex);
                    MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// 手动连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rbtn_ManualConnection_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_ManualConnection.Checked)
            {
                cb_SerialPortName.Enabled = !PortHelper.IsConnection;
                btn_SerialPortConnection.Enabled = true;

                PortHelper.SetAutoDevice(false);
            }
        }

        /// <summary>
        /// 自动连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rbtn_AutoConnection_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_AutoConnection.Checked)
            {
                cb_SerialPortName.Enabled = false;
                btn_SerialPortConnection.Enabled = false;

                PortHelper.SetAutoDevice(true);
            }
        }

        private void PlatformSetting_Form_Load(object sender, EventArgs e)
        {
            PortHelper.ConnectionChange += DeviceConnectionChange;
            PortHelper.sp.SerialPortCountChange += SerialPortCountChange;

            gb_WirelessSettings.Height = 165;
            cb_WirelessIdList.SelectedIndex = 0;
            ud_WirelessFrequency.Value = Dal_SysSettings.SystemSettings.SaveFrequency;
            ud_WirelessId.Value = Dal_SysSettings.SystemSettings.SaveCommunicationID;

            SerialPortCountChange(PortHelper.sp.SerialPortNames);
            DeviceConnectionChange(PortHelper.IsConnection);
        }

        private void SerialPortChange(bool flag)
        {
            this.Invoke(new EventHandler(delegate
            {
                btn_SerialPortConnection.Text = flag ? "关 闭" : "打 开";
                btn_ModuleConnection.Enabled = flag ? Dal_ManageRights.ManageRights.ModuleSettings : false;
                if (!rbtn_AutoConnection.Checked)
                    cb_SerialPortName.Enabled = !flag;
            }));
        }

        private void SerialPortCountChange(List<string> portnames)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new SerialPortCountChangeEvnetHandler(SerialPortCountChange), portnames);
                return;
            }

            cb_SerialPortName.Items.Clear();
            if (portnames == null) return;
            if (portnames.Count > 0)
            {
                cb_SerialPortName.Items.AddRange(portnames.ToArray());
                int index = 0;
                if (PortHelper.IsConnection)
                {
                    index = portnames.IndexOf(PortHelper.sp.PortName);
                }
                cb_SerialPortName.SelectedIndex = index;
            }
        }

        private void DeviceConnectionChange(bool flag)
        {
            this.BeginInvoke(new EventHandler(delegate
            {
                l_ConnectionState.Text = flag ? "已连接" : "已断开";
                l_ConnectionState.ForeColor = flag ? Color.Green : Color.Red;
                if (flag)
                {
                    cb_SerialPortName.SelectedIndex = cb_SerialPortName.Items.IndexOf(PortHelper.sp.PortName);
                }
                SerialPortChange(flag);
            }));
        }

        private static PlatformSetting_Form _uniqueInstance;

        public static PlatformSetting_Form GetInstance
        {
            get { return _uniqueInstance ?? (_uniqueInstance = new PlatformSetting_Form()); }
        }

    }
}
