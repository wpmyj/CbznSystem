using System.IO;
using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NewControl;
using Microsoft.VisualBasic.FileIO;
using Model;
using Dal;
using Bll;

namespace CbznSystem
{
    public partial class InputDeviceInfo_Form : NewForm
    {
        private string[] _FileNames;

        public InputDeviceInfo_Form(string[] filenames)
        {
            InitializeComponent();

            this._FileNames = filenames;

            this.Load += InputDeviceInfo_Form_Load;

            btn_Enter.Paint += FormComm.DrawBtnEnabled;
        }

        private void InputDeviceInfo_Form_Load(object sender, EventArgs e)
        {
            pBar.Maximum = _FileNames.Length;

            Thread tInputDeviceInfo = new Thread(InputInfo);
            tInputDeviceInfo.IsBackground = true;
            tInputDeviceInfo.Start();
        }

        private void InputInfo()
        {
            CbDeviceInfo mode;
            List<CbDeviceInfo> deviceinfos = new List<CbDeviceInfo>();
            try
            {
                StringBuilder sb = new StringBuilder();
                TextFieldParser tfp;
                foreach (string item in _FileNames)
                {
                    if (!File.Exists(item)) continue;
                    string filename = Path.GetFileNameWithoutExtension(item);
                    if (!CRegex.IsDeviceInfoFileName(filename)) continue;
                    l_Title.Text = "正在导入：" + filename;
                    pBar.PerformStep();
                    sb.AppendFormat("文件:{0}", filename);
                    using (tfp = new TextFieldParser(item))
                    {
                        tfp.Delimiters = new string[] { ",", "<", ">" };
                        tfp.TextFieldType = FieldType.Delimited;
                        mode = new CbDeviceInfo();
                        while (!tfp.EndOfData)
                        {
                            string[] content = tfp.ReadFields();
                            int number = Convert.ToInt32(content[0], 16);
                            string value = content[2];
                            switch (number)
                            {
                                case 0:
                                    mode.HostNumber = Utils.StrToInt(value.Substring(0, 2), 1);
                                    mode.Frequency = Utils.StrToInt(value.Substring(2, 2), 1);
                                    mode.WirelessID = Utils.StrToInt(value.Substring(4, 8), 0);
                                    mode.IsLikeMachine = Utils.StrToInt(value.Substring(12, 2), 0);
                                    break;
                                case 1:
                                    mode.Distance = Utils.StrToInt(value, 1);
                                    break;
                                case 2:
                                    mode.EquipmentDelay = Utils.StrToInt(value, 1);
                                    break;
                                case 3:
                                    //mode.CustomerNumber = Utils.StrToInt(value, 9887);
                                    break;
                                case 8:
                                    mode.FieldPartition = Convert.ToInt32(value, 16);
                                    break;
                                case 9:
                                    if (!string.IsNullOrEmpty(value))
                                        mode.IOSate = Utils.StrToInt(value, 0);
                                    break;
                                case 10:
                                    mode.AntiSubmarineBack = Utils.StrToInt(value, 0);
                                    break;
                                case 12:
                                    switch (value.Substring(value.Length - 2, 2))
                                    {
                                        case "F0"://继电器开闸
                                            mode.DeviceMode = 3;
                                            break;
                                        case "AA"://学习遥控器开闸
                                            mode.DeviceMode = 2;
                                            break;
                                        case "FF"://串口开闸
                                            mode.DeviceMode = 0;
                                            mode.DeviceNumber = Convert.ToInt32(value.Substring(0, 6), 16);
                                            break;
                                        case "55"://无线电开闸
                                            mode.DeviceMode = 1;
                                            mode.DeviceNumber = Convert.ToInt32(value.Substring(0, 6), 16);
                                            break;
                                    }
                                    break;
                                case 13:
                                    mode.Language = Utils.StrToInt(value, 0);
                                    break;
                                case 15:
                                    mode.VehicleDetection = Utils.StrToInt(value, 0);
                                    break;
                                case 17:
                                    mode.VagueQueryNumber = Utils.StrToInt(value, 0);
                                    break;
                            }
                        }
                        deviceinfos.Add(mode);
                    }
                }
                this.Invoke(new EventHandler(delegate
                {
                    l_Title.Text = "正在保存数据，请勿操作。";
                    btn_Enter.Enabled = false;
                    Dbhelper.Db.Insert<CbDeviceInfo>(deviceinfos.ToArray());
                    this.DialogResult = DialogResult.OK;
                }));
            }
            catch (Exception ex)
            {
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show("导入失败错误数据：" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }
    }
}
