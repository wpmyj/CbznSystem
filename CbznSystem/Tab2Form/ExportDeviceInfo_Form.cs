using System.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NewControl;
using Dal;
using Bll;
using Model;

namespace CbznSystem
{
    public partial class ExportDeviceInfo_Form : NewForm
    {
        private List<CbDeviceInfo> _mDeviceInfo;

        private string _strControlBoardPassword = string.Empty;

        private string _strDistancePassword = string.Empty;

        private string _strTempIcPassword = string.Empty;

        public ExportDeviceInfo_Form(List<CbDeviceInfo> deviceinfo)
        {
            InitializeComponent();

            this._mDeviceInfo = deviceinfo;

            this.Load += ExportDeviceInfo_Form_Load;
            this.KeyDown += ExportDeviceInfo_Form_KeyDown;

            cb_LoadControlBoard.CheckedChanged += Cb_LoadControlBoard_CheckedChanged;
            cb_LoadDistance.CheckedChanged += Cb_LoadDistance_CheckedChanged;
            cb_LoadTempIc.CheckedChanged += Cb_LoadTempIc_CheckedChanged;
            cb_Directory.DropDown += Cb_Directory_DropDown;
            btn_Enter.Click += Btn_Enter_Click;
        }

        private void ExportDeviceInfo_Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void Cb_LoadTempIc_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cb_LoadTempIc.Checked)
                {
                    if (Dal_IcDevicePwd.TempIcDevicePassword == null)
                    {
                        CbIcDeviePwd mTempIcPwd = Dbhelper.Db.FirstDefault<CbIcDeviePwd>();
                        if (mTempIcPwd == null)
                        {
                            return;
                        }
                        Dal_IcDevicePwd.TempIcDevicePassword = mTempIcPwd;
                    }
                    _strTempIcPassword = Dal_IcDevicePwd.TempIcDevicePassword.Pwd;
                }
                else
                {
                    _strTempIcPassword = string.Empty;
                }
            }
            catch (Exception ex)
            {
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cb_LoadDistance_CheckedChanged(object sender, EventArgs e)
        {
            if (!cb_LoadDistance.Checked) return;
            ConfirmDistanceOldPassword_Form cdopassowrd = new ConfirmDistanceOldPassword_Form();
            if (cdopassowrd.ShowDialog() != DialogResult.OK)
            {
                cb_LoadDistance.Checked = false;
                return;
            }
            string strDistanceOldPassword = cdopassowrd.Tag as string;
            //主机旧密码在加上主机的新密码
            _strDistancePassword = strDistanceOldPassword + Dal_DevicePwd.DistanceSystemPassword.Pwd;
        }

        private void Cb_LoadControlBoard_CheckedChanged(object sender, EventArgs e)
        {
            if (!cb_LoadControlBoard.Checked) return;
            ControlBoardPassword_Form cbpassword = new ControlBoardPassword_Form();
            if (cbpassword.ShowDialog() != DialogResult.OK)
            {
                cb_LoadControlBoard.Checked = false;
                return;
            }
            _strControlBoardPassword = cbpassword.Tag as string;
        }

        private void Btn_Enter_Click(object sender, EventArgs e)
        {
            StreamWriter sw = null;
            int index = cb_Directory.SelectedIndex;
            DriveInfo dinfo = DriveInfo.GetDrives()[index];
            if (!dinfo.IsReady)
            {
                MessageBox.Show("当前驱动设备未就绪，请重新选择输出目录。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string path = string.Format("{0}\\SZCBKJ", dinfo.Name);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path += "\\OS";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            try
            {
                StringBuilder sb = new StringBuilder();
                foreach (CbDeviceInfo item in _mDeviceInfo)
                {
                    sb.AppendFormat(" 设备信息ID:{0} 门口编号:{1} 出入口:{2} ", item.ID, item.HostNumber, item.IOSate == 0 ? "入口" : "出口");
                    Dictionary<int, string> dic = new Dictionary<int, string>();
                    dic.Add(0, string.Format("{0:X2}{1:X2}{2}{3:X2}", item.HostNumber, item.Frequency, (item.IsLikeMachine == 0 ? string.Format("{0:X8}", item.HostNumber) : item.WirelessID.ToString().PadLeft(8, '0')), item.IsLikeMachine));//编号
                    dic.Add(1, string.Format("{0:X2}", item.Distance));//距离
                    dic.Add(2, string.Format("{0:X2}", item.EquipmentDelay));//设备延时
                    dic.Add(3, "");//客户编号 9887
                    dic.Add(4, _strDistancePassword);//主机密码
                    dic.Add(5, "");//保留
                    dic.Add(6, "0101");//IC开关
                    dic.Add(7, DateTime.Now.ToString("yyMMddHHmmss"));//时间
                    dic.Add(8, string.Format("{0:X2}", item.FieldPartition));//场分区
                    dic.Add(9, string.Format("{0:X2}", item.IOSate));//进出口标志
                    dic.Add(10, string.Format("{0:X2}", item.AntiSubmarineBack));//返潜回
                    dic.Add(11, _strControlBoardPassword);//控制板密码
                    string value = string.Empty;
                    switch (item.DeviceMode)
                    {
                        case 0:
                            value = string.Format("{0:X6}FF", item.DeviceNumber);//串口开闸  
                            break;
                        case 1:
                            value = string.Format("{0:X6}55", item.DeviceNumber);//无线开闸
                            break;
                        case 2:
                            value = "FFFFFFAA";//学习开闸
                            break;
                        case 3:
                            value = "FFFFFFF0";//继电器开闸
                            break;
                    }
                    dic.Add(12, value);//开闸方式
                    dic.Add(13, string.Format("{0:X2}", item.Language));//语言种类
                    dic.Add(14, "1E");
                    dic.Add(15, string.Format("{0:X2}", item.VehicleDetection));//车辆检测
                    dic.Add(16, _strTempIcPassword);//出卡机密码
                    dic.Add(17, string.Format("{0:X2}", item.VagueQueryNumber));//车牌识别模糊查询位数

                    foreach (KeyValuePair<int, string> key in dic)
                    {
                        if (key.Key == 0)
                        {
                            sw = File.CreateText(string.Format("{0}\\FORM{1:X2}.txt", path, item.HostNumber));
                        }
                        sw.WriteLine("00{0:X2}<{1:X2},{2},{3:X2}>", key.Key, key.Value.Length, key.Value, GetVerification(key.Value));
                    }
                    sw.Close();
                }
                Close();
            }
            catch (Exception ex)
            {
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetVerification(string content)
        {
            byte[] by = Encoding.ASCII.GetBytes(content);
            int result = 0;
            for (int i = 0; i < by.Length; i++)
            {
                result = result ^ by[i];
            }
            return result;
        }

        private void Cb_Directory_DropDown(object sender, EventArgs e)
        {
            if (cb_Directory.Items.Count != DriveInfo.GetDrives().Length)
            {
                LoadDrive();
            }
        }

        private void ExportDeviceInfo_Form_Load(object sender, EventArgs e)
        {

            cb_LoadTempIc.Enabled = Dal_SysSettings.SystemSettings.IsSetTempIcDevice;
            cb_LoadDistance.Enabled = Dal_DevicePwd.DistanceSystemPassword.ID > 0;

            LoadDrive();
        }

        private void LoadDrive()
        {
            cb_Directory.Items.Clear();
            int index = 0;
            DriveInfo[] dinfos = DriveInfo.GetDrives();
            for (int i = 0; i < dinfos.Length; i++)
            {
                if (dinfos[i].DriveType == DriveType.Removable)
                    index = i;
                cb_Directory.Items.Add(dinfos[i].Name + GetDriveType(dinfos[i].DriveType));
            }
            cb_Directory.SelectedIndex = index;
        }

        private string GetDriveType(DriveType dtype)
        {
            string content = string.Empty;
            switch (dtype)
            {
                case DriveType.Unknown:
                    content = "未知驱动器s";
                    break;
                case DriveType.NoRootDirectory:
                    content = "此驱动器没有根目录";
                    break;
                case DriveType.Removable:
                    content = "可移动磁盘 如 U盘 SD卡";
                    break;
                case DriveType.Fixed:
                    content = "固定磁盘";
                    break;
                case DriveType.Network:
                    content = "网络磁盘";
                    break;
                case DriveType.CDRom:
                    content = "CD或CD-ROM";
                    break;
                case DriveType.Ram:
                    content = "RAM磁盘";
                    break;
            }
            return content;
        }
    }
}
