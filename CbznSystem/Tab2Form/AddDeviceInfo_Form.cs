using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NewControl;
using Model;
using Dal;
using Bll;

namespace CbznSystem
{
    public partial class AddDeviceInfo_Form : NewForm
    {
        public AddDeviceInfo_Form()
        {
            InitializeComponent();

            this.Load += AddDeviceInfo_Form_Load;
            this.KeyDown += AddDeviceInfo_Form_KeyDown;

            cb_DeviceMode.SelectedIndexChanged += Cb_DeviceMode_SelectedIndexChanged;
            cb_IsLikeMachine.SelectedIndexChanged += Cb_IsLikeMachine_SelectedIndexChanged;
            tb_DeviceNumber.KeyPress += TxtKeyPress;
            tb_WirelessID.KeyPress += TxtKeyPress;
            btn_Enter.Click += Btn_Enter_Click;
        }

        private void AddDeviceInfo_Form_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Escape)
            {
                Close();
            }
        }

        private void TxtKeyPress(object sendr, KeyPressEventArgs e)
        {
            e.Handled = LimitInput.InputNumber(e.KeyChar);
        }

        private void Cb_DeviceMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cb_DeviceMode.SelectedIndex;
            if (index > 1)
            {
                tb_DeviceNumber.Enabled = false;
                l_GateSign.Text = string.Empty;
            }
            else
            {
                tb_DeviceNumber.Focus();
                tb_DeviceNumber.SelectionStart = tb_DeviceNumber.TextLength;
                tb_DeviceNumber.Enabled = true;
                l_GateSign.Text = "*";
            }
        }

        private void Btn_Enter_Click(object sender, EventArgs e)
        {
            int devicenumber = Utils.StrToInt(tb_DeviceNumber.Text, 0);
            int wirelessid = Utils.StrToInt(tb_WirelessID.Text, 0);
            CbDeviceInfo mDeviceInfo = new CbDeviceInfo()
            {
                HostNumber = (int)ud_HostNumber.Value,
                IOSate = cb_IOSate.SelectedIndex,
                DeviceNumber = devicenumber,
                DeviceMode = cb_DeviceMode.SelectedIndex,
                FieldPartition = cb_FieldPartition.SelectedIndex,
                AntiSubmarineBack = cb_AntiSubmarineBack.SelectedIndex,
                VehicleDetection = cb_VehicleDetection.SelectedIndex,
                Distance = cb_Distance.SelectedIndex,
                EquipmentDelay = cb_EquipmentDelay.SelectedIndex,
                Language = cb_Language.SelectedIndex,
                IsLikeMachine = cb_IsLikeMachine.SelectedIndex,
                Frequency = (int)ud_Frequency.Value,
                WirelessID = wirelessid,
                VagueQueryNumber = cb_VagueQueryNumber.SelectedIndex
            };
            try
            {
                mDeviceInfo.ID = Dbhelper.Db.Insert<CbDeviceInfo>(mDeviceInfo);
                Tag = mDeviceInfo;
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
        }

        private void Cb_IsLikeMachine_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cb_IsLikeMachine.SelectedIndex;
            if (index == 0)
            {
                tb_WirelessID.Enabled = false;
                ud_Frequency.Enabled = false;
                cb_VagueQueryNumber.Enabled = false;
                l_CameraIdSign.Text = string.Empty;
            }
            else
            {
                tb_WirelessID.Enabled = true;
                ud_Frequency.Enabled = true;
                cb_VagueQueryNumber.Enabled = true;
                l_CameraIdSign.Text = "*";
            }
        }

        private void AddDeviceInfo_Form_Load(object sender, EventArgs e)
        {
            cb_DeviceMode.SelectedIndex = 3;//开闸模式
            cb_Distance.SelectedIndex = 3;//读卡距离
            cb_EquipmentDelay.SelectedIndex = 1;//读卡延迟
            cb_FieldPartition.SelectedIndex = 0;//车场分区
            cb_AntiSubmarineBack.SelectedIndex = 0;//返潜回
            cb_VehicleDetection.SelectedIndex = 0;//离开检测
            cb_VagueQueryNumber.SelectedIndex = 0;//模糊查询
            cb_Language.SelectedIndex = 0;//语言
            cb_IsLikeMachine.SelectedIndex = Dal_SysSettings.SystemSettings.IsSetLprDevice ? 1 : 0;
            cb_IsLikeMachine.Enabled = false;
            int hostnumber = GetHostNumber();
            ud_HostNumber.Value = hostnumber;
            cb_IOSate.SelectedIndex = hostnumber % 2;//出入口
            ud_HostNumber.Enabled = false;
        }

        private int GetHostNumber()
        {

            DataTable dt = Dal_DeviceInfo.GetHostNumber();
            int index = 1;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (!dt.Rows[i]["HostNumber"].Equals(index)) break;
                index++;
            }
            if (index > 128 || index < 0)
                index = 1;
            return index;
        }
    }
}
