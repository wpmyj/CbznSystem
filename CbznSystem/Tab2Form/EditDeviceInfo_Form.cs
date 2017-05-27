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
    public partial class EditDeviceInfo_Form : NewForm
    {
        private CbDeviceInfo _mDeviceInfo;

        public EditDeviceInfo_Form(CbDeviceInfo mdeviceinfo)
        {
            InitializeComponent();

            _mDeviceInfo = mdeviceinfo;

            this.Load += AddDeviceInfo_Form_Load;
            this.KeyDown += EditDeviceInfo_Form_KeyDown;

            cb_DeviceMode.SelectedIndexChanged += Cb_DeviceMode_SelectedIndexChanged;
            cb_IsLikeMachine.SelectedIndexChanged += Cb_IsLikeMachine_SelectedIndexChanged;
            tb_DeviceNumber.KeyPress += TxtKeyPress;
            tb_WirelessID.KeyPress += TxtKeyPress;
            btn_Enter.Click += Btn_Enter_Click;
        }

        private void EditDeviceInfo_Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
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

            _mDeviceInfo.HostNumber = (int)ud_HostNumber.Value;
            _mDeviceInfo.IOSate = cb_IOSate.SelectedIndex;
            _mDeviceInfo.DeviceNumber = devicenumber;
            _mDeviceInfo.DeviceMode = cb_DeviceMode.SelectedIndex;
            _mDeviceInfo.FieldPartition = cb_FieldPartition.SelectedIndex;
            _mDeviceInfo.AntiSubmarineBack = cb_AntiSubmarineBack.SelectedIndex;
            _mDeviceInfo.VehicleDetection = cb_VehicleDetection.SelectedIndex;
            _mDeviceInfo.Distance = cb_Distance.SelectedIndex;
            _mDeviceInfo.EquipmentDelay = cb_EquipmentDelay.SelectedIndex;
            _mDeviceInfo.Language = cb_Language.SelectedIndex;
            _mDeviceInfo.IsLikeMachine = cb_IsLikeMachine.SelectedIndex;
            _mDeviceInfo.Frequency = (int)ud_Frequency.Value;
            _mDeviceInfo.WirelessID = wirelessid;
            _mDeviceInfo.VagueQueryNumber = cb_VagueQueryNumber.SelectedIndex;

            try
            {
                Dbhelper.Db.Update<CbDeviceInfo>(_mDeviceInfo);
                Tag = _mDeviceInfo;
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
            ud_HostNumber.Value = _mDeviceInfo.HostNumber;//门口编号
            cb_IOSate.SelectedIndex = _mDeviceInfo.IOSate;//出入口
            cb_DeviceMode.SelectedIndex = _mDeviceInfo.DeviceMode;//开闸模式
            tb_DeviceNumber.Text = _mDeviceInfo.DeviceNumber.ToString();//道闸ID
            cb_Distance.SelectedIndex = _mDeviceInfo.Distance;//读卡距离
            cb_EquipmentDelay.SelectedIndex = _mDeviceInfo.EquipmentDelay;//读卡延迟
            cb_FieldPartition.SelectedIndex = _mDeviceInfo.FieldPartition;//车场分区
            cb_AntiSubmarineBack.SelectedIndex = _mDeviceInfo.AntiSubmarineBack;//返潜回
            cb_VehicleDetection.SelectedIndex = _mDeviceInfo.VehicleDetection;//离开检测
            cb_VagueQueryNumber.SelectedIndex = _mDeviceInfo.VagueQueryNumber;//模糊查询
            cb_Language.SelectedIndex = _mDeviceInfo.Language;//语言
            cb_IsLikeMachine.SelectedIndex = _mDeviceInfo.IsLikeMachine;
            tb_WirelessID.Text = _mDeviceInfo.WirelessID.ToString();//像机ID
            ud_Frequency.Value = _mDeviceInfo.Frequency;//频道偏移
            cb_IsLikeMachine.Enabled = false;
            ud_HostNumber.Enabled = false;
        }
    }
}
