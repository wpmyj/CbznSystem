using Bll;
using Dal;
using Model;
using NewControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CbznSystem
{
    public partial class SearchWirelessFrequency_Form : NewForm
    {
        private Thread _tSearchHostFrequency;

        private bool _isModuleSet;

        private int _wirelessID;

        private int _wirelessFrequency;

        public SearchWirelessFrequency_Form(int wirelessid, int wirelessfressid)
        {
            InitializeComponent();

            _wirelessID = wirelessid;
            _wirelessFrequency = wirelessfressid;

            this.Load += SearchWirelessFrequency_Form_Load;
            this.FormClosing += SearchWirelessFrequency_Form_FormClosing;
            this.FormClosed += SearchWirelessFrequency_Form_FormClosed;
            this.KeyDown += SearchWirelessFrequency_Form_KeyDown;

            btn_Cancel.Click += Btn_Cancel_Click;
            btn_Cancel.Paint += FormComm.DrawBtnEnabled;
        }

        private void SearchWirelessFrequency_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Thread.Sleep(50);//防止数据相撞
        }

        private void SearchWirelessFrequency_Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4 && e.Alt)
            {
                e.Handled = true;
            }
        }

        private void SearchWirelessFrequency_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            PortHelper.DataReceived -= SerialPortDataReceived;
            PortHelper.ConnectionChange -= PortHelper_ConnectionChange;
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            if (_tSearchHostFrequency != null)
            {
                if (MessageBox.Show("确认是否退出当前搜索操作。", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
                {
                    return;
                }
                _tSearchHostFrequency?.Abort();
                Close();
            }
        }

        private void SearchWirelessFrequency_Form_Load(object sender, EventArgs e)
        {
            PortHelper.DataReceived += SerialPortDataReceived;
            PortHelper.ConnectionChange += PortHelper_ConnectionChange;
            PortHelper.CurrentForm = this;

            pBar.Visible = false;
            btn_Cancel.Enabled = false;
            pBar.Maximum = 64;
            pBar.Value = 0;

            //是否读取Ic卡
            Tab4_Form.GetInstance.IsReadIcCard = false;

            _tSearchHostFrequency = new Thread(SearchFrequency);
            _tSearchHostFrequency.IsBackground = true;
            _tSearchHostFrequency.Start();
        }

        private void SearchFrequency()
        {
            try
            {
                OpenModule();
                SetModuleFrequency(_wirelessFrequency);
                if (!_isModuleSet)
                {
                    SetModuleFrequency(_wirelessFrequency);
                    if (!_isModuleSet)
                    {
                        SetModuleFrequency(_wirelessFrequency);
                    }
                }
                if (_isModuleSet)
                {
                    SetModuleRid(_wirelessID);
                    if (!_isModuleSet)
                    {
                        SetModuleRid(_wirelessID);
                        if (!_isModuleSet)
                        {
                            SetModuleRid(_wirelessID);
                        }
                    }
                }
                if (_isModuleSet)
                {
                    SetModuleTid(_wirelessID);
                    if (!_isModuleSet)
                    {
                        SetModuleTid(_wirelessID);
                        if (!_isModuleSet)
                        {
                            SetModuleTid(_wirelessID);
                        }
                    }
                }
                if (_isModuleSet)
                {
                    SetModuleComesBack(1);
                    if (!_isModuleSet)
                    {
                        SetModuleComesBack(1);
                        if (!_isModuleSet)
                        {
                            SetModuleComesBack(1);
                        }
                    }
                }
                CloseModule();
                if (_isModuleSet)
                {
                    ModuleTest();
                    if (!_isModuleSet)
                    {
                        ModuleTest();
                        if (!_isModuleSet)
                        {
                            ModuleTest();
                        }
                    }
                }

                if (!_isModuleSet)
                {
                    this.Invoke(new EventHandler(delegate
                    {
                        l_Title.Visible = false;
                        pBar.Visible = true;
                        btn_Cancel.Enabled = true;
                    }));
                    for (int i = 1; i <= 64; i++)
                    {
                        OpenModule();
                        SetModuleFrequency(i);
                        if (!_isModuleSet)
                        {
                            SetModuleFrequency(i);
                            if (!_isModuleSet)
                            {
                                SetModuleFrequency(i);
                            }
                        }
                        CloseModule();
                        if (_isModuleSet)
                        {
                            ModuleTest();

                            if (_isModuleSet)
                            {
                                this.Tag = i;
                                this.DialogResult = DialogResult.OK;
                                return;
                            }
                        }
                        this.Invoke(new EventHandler(delegate
                        {
                            pBar.PerformStep();
                        }));
                    }
                    this.Invoke(new EventHandler(delegate
                    {
                        MessageBox.Show("搜索主机通信频道失败，请重检测设备连接是否正常或无线通信距离过远。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }));
                }
                else
                {
                    this.Tag = _wirelessFrequency;
                    this.DialogResult = DialogResult.OK;
                    return;
                }
            }
            catch
            {
                CloseModule();
            }
            finally
            {
                _tSearchHostFrequency = null;
            }
        }

        private void OpenModule()
        {
            byte[] by = PortAgreement.GetOpenModule();
            if (PortHelper.IsConnection)
            {
                PortHelper.SerialPortWrite(by);
                Thread.Sleep(10);
            }
        }

        private void CloseModule()
        {
            byte[] by = PortAgreement.GetCloseModule();
            if (PortHelper.IsConnection)
            {
                PortHelper.SerialPortWrite(by);
                Thread.Sleep(10);
            }
        }

        private void SetModuleFrequency(int frequency)
        {
            _isModuleSet = false;
            frequency = 127 - (frequency * 2 - 1);
            byte[] by = PortAgreement.GetSetModule(string.Format("AT+FREQ={0:X2}", frequency));
            if (PortHelper.IsConnection)
            {
                PortHelper.SerialPortWrite(by);
                Thread.Sleep(150);
            }
        }

        private void SetModuleRid(int id)
        {
            _isModuleSet = false;
            byte[] by = PortAgreement.GetSetModule(string.Format("AT+RID=01{0}", id.ToString().PadLeft(8, '0')));
            if (PortHelper.IsConnection)
            {
                PortHelper.SerialPortWrite(by);
                Thread.Sleep(150);
            }
        }

        private void SetModuleTid(int id)
        {
            _isModuleSet = false;
            byte[] by = PortAgreement.GetSetModule(string.Format("AT+TID=01{0}", id.ToString().PadLeft(8, '0')));
            if (PortHelper.IsConnection)
            {
                PortHelper.SerialPortWrite(by);
                Thread.Sleep(150);
            }
        }

        private void SetModuleComesBack(int value)
        {
            _isModuleSet = false;
            byte[] by = PortAgreement.GetSetModule(string.Format("AT+BACK={0}", value));
            if (PortHelper.IsConnection)
            {
                PortHelper.SerialPortWrite(by);
                Thread.Sleep(150);
            }
        }

        private void ModuleTest()
        {
            _isModuleSet = false;
            byte[] by = PortAgreement.GetSetModule("ABCDEF");
            if (PortHelper.IsConnection)
            {
                PortHelper.SerialPortWrite(by);
                Thread.Sleep(150);
            }
        }

        private void PortHelper_ConnectionChange(bool flag)
        {
            if (!flag)
            {
                this.BeginInvoke(new EventHandler(delegate
                {
                    if (_tSearchHostFrequency != null)
                    {
                        _tSearchHostFrequency.Abort();
                    }
                    Close();
                    MessageBox.Show("连接端口已断开，退出搜索操作。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }));
            }
        }

        private void SerialPortDataReceived(ParsingParameter param)
        {
            if (!PortHelper.IsConnection) return;
            if (PortHelper.CurrentForm != this) return;
            if (param.FunctionAddress == 67)
            {
                switch (param.Command)
                {
                    case 9:
                        //0x46 F 失败  0x53 S 成功
                        _isModuleSet = DataParsing.TemporaryContent(param.DataContent) == 83;
                        break;
                    case 208:
                        //0x59 Y 设置成功  0x4E N 设置失败
                        _isModuleSet = DataParsing.TemporaryContent(param.DataContent) == 89;
                        break;
                }
            }
        }
    }
}
