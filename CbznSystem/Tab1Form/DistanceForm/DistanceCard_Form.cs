using Dal;
using Model;
using Bll;
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
    /*
     * 此窗体用于加密5米定距卡
     */
    public partial class DistanceCard_Form : Form
    {

        private int ShowRowCount = 0;

        private bool IsEnd;

        public DistanceCard_Form()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(240, 243, 245);

            this.Activated += DistanceCard_Form_Activated;
            this.Load += DistanceCardForm_Load;
            this.KeyDown += DistanceCard_Form_KeyDown;

            dgv_DataContent.Resize += Dgv_DataContent_Resize;
            dgv_DataContent.CellFormatting += Dgv_DataContent_CellFormatting;

            l_OldTitle.MouseDown += L_OldTitle_MouseDown;
            tb_OldPwd.TextChanged += Tb_OldPwd_TextChanged;
            tb_OldPwd.KeyPress += Tb_OldPwd_KeyPress;
            tb_OldPwd.EnabledChanged += Tb_OldPwd_EnabledChanged;

            btn_OldDefault.Click += Btn_OldDefault_Click;
            btn_OldDefault.Paint += FormComm.DrawBtnEnabled;
            btn_Enter.Click += Btn_Enter_Click;
            btn_Enter.Paint += FormComm.DrawBtnEnabled;
        }

        private void DistanceCard_Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4 && e.Alt)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 文本启用或不启用事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tb_OldPwd_EnabledChanged(object sender, EventArgs e)
        {
            if (tb_OldPwd.Enabled)
            {
                tb_OldPwd.Focus();
                tb_OldPwd.SelectionStart = tb_OldPwd.TextLength;
            }
        }

        /// <summary>
        /// 窗体获取焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DistanceCard_Form_Activated(object sender, EventArgs e)
        {
            if (PortHelper.CurrentForm != this)
            {
                PortHelper.CurrentForm = this;

                if (Tab4_Form.GetInstance.IsReadIcCard)
                {
                    Tab4_Form.GetInstance.CloseReadIcCard();
                }
            }
        }

        /// <summary>
        /// DGV大小发生变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dgv_DataContent_Resize(object sender, EventArgs e)
        {
            int cellwidth = dgv_DataContent.Columns["c_Time"].Width + dgv_DataContent.Columns["c_CardType"].Width;
            dgv_DataContent.Columns["c_Content"].Width = dgv_DataContent.Width - cellwidth;

            ShowRowCount = dgv_DataContent.Height / dgv_DataContent.RowTemplate.Height;
        }

        /// <summary>
        /// DGV 单元格格式发生变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dgv_DataContent_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv_DataContent.Columns["c_CardType"].Index == e.ColumnIndex)
            {
                if (e.Value.Equals(0))
                {
                    e.Value = "单卡";
                }
                else if (e.Value.Equals(1))
                {
                    e.Value = "组合卡";
                }
                else if (e.Value.Equals(2))
                {
                    e.Value = "车牌识别卡";
                }
                else if (e.Value.Equals(3))
                {
                    e.Value = "副卡";
                }
                else if (e.Value.Equals(8))
                {
                    e.Value = "挂失卡";
                }
                else if (e.Value.Equals(15))
                {
                    e.Value = "密码错误";
                }
                else
                {
                    e.Value = string.Empty;
                }

            }
        }

        /// <summary>
        /// 旧默认密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_OldDefault_Click(object sender, EventArgs e)
        {
            tb_OldPwd.Text = "766554";
            tb_OldPwd.Focus();
            tb_OldPwd.SelectionStart = tb_OldPwd.TextLength;
        }

        /// <summary>
        /// 确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Enter_Click(object sender, EventArgs e)
        {
            string oldpwd = tb_OldPwd.Text.Trim();
            if (oldpwd.Length != tb_OldPwd.MaxLength)
            {
                DisplayContent("旧口令长度为 6 位数字，请重新输入旧口令。");
                tb_OldPwd.Focus();
                return;
            }
            try
            {
                IsEnd = false;
                byte[] by = PortAgreement.GetDistanceEncryption(oldpwd);
                PortHelper.SerialPortWrite(by);
                p_Top.Enabled = false;
            }
            catch (Exception ex)
            {
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 旧密码文本按下并释放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tb_OldPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (btn_Enter.Enabled)
                    Btn_Enter_Click(null, null);
            }
            e.Handled = LimitInput.InputNumber(e.KeyChar);
        }

        /// <summary>
        /// 旧密码文本变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tb_OldPwd_TextChanged(object sender, EventArgs e)
        {
            l_OldTitle.Visible = tb_OldPwd.TextLength == 0;
            btn_OldDefault.Enabled = tb_OldPwd.TextLength == 0;
        }

        /// <summary>
        ///旧密码标题鼠标按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void L_OldTitle_MouseDown(object sender, MouseEventArgs e)
        {
            tb_OldPwd.Focus();
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DistanceCardForm_Load(object sender, EventArgs e)
        {
            l_Description.Text = " 只有将“5 米定距卡”的口令设置成与系统口令一致才能与系统的定距读写器进行通讯和正常使用。\n\n 将“5 米定距卡”放到多功能操作平台上，再单击“系统口令加载到定距卡”按钮。 ";

            btn_Enter.Enabled = Dal_ManageRights.ManageRights.DevicEncryptionCardEncryption ? PortHelper.IsConnection : false;
            //初始化端口接收事件
            PortHelper.DataReceived += SerialPortDataReceived;
            //初始化端口变化事件
            PortHelper.ConnectionChange += DeviceConnectionChange;
        }

        /// <summary>
        /// 端口变化事件
        /// </summary>
        /// <param name="flag"></param>
        private void DeviceConnectionChange(bool flag)
        {
            this.Invoke(new EventHandler(delegate
            {
                if (flag)
                {
                    btn_Enter.Enabled = Dal_ManageRights.ManageRights.DevicEncryptionCardEncryption;
                }
                else
                {
                    btn_Enter.Enabled = false;
                }
            }));
        }

        /// <summary>
        /// 端口数据接收
        /// </summary>
        /// <param name="param"></param>
        private void SerialPortDataReceived(ParsingParameter param)
        {
            if (!PortHelper.IsConnection) return;
            if (PortHelper.CurrentForm != this) return;
            this.Invoke(new EventHandler(delegate
            {
                if (tb_OldPwd.TextLength == 0) return;
                try
                {
                    if (param.FunctionAddress == 65)
                    {
                        DistanceParameter distanceparam = DataParsing.DistanceParsingContent(param.DataContent);
                        switch (distanceparam.Command)
                        {
                            case 13://卡密码
                                switch (distanceparam.AuxiliaryCommand)
                                {
                                    case 0:
                                        if (distanceparam.TypeParameter.CardType == CardTypes.PasswordMistake)
                                        {
                                            DisplayContent("5 米定距卡：" + distanceparam.CardNumber + " 加载失败。", (int)distanceparam.TypeParameter.CardType, Color.Red);
                                        }
                                        else
                                        {
                                            DisplayContent("5 米定距卡：" + distanceparam.CardNumber + " 加载成功。", (int)distanceparam.TypeParameter.CardType, Color.Black);
                                        }
                                        break;
                                    case 8:
                                        DisplayContent("5 米定距卡加载结束。", Color.Black);
                                        p_Top.Enabled = true;
                                        IsEnd = true;
                                        SetDevicedNewPwd();
                                        break;
                                    default:
                                        DisplayContent("5 米定距卡加载失败，请将 5 米定距卡放置在读写区域内，请重新操作。");
                                        p_Top.Enabled = true;
                                        break;
                                }
                                break;
                            case 160://设备密码
                                if (!IsEnd)
                                {
                                    if (distanceparam.AuxiliaryCommand == 0)//成功
                                    {
                                        DisplayContent("多功能操作平台初始化设置成功，进行 5 米定距卡口令加载。", Color.Black);

                                        PortHelper.SerialPortWrite(PortAgreement.GetDistanceCardEncryption(Dal_DevicePwd.DistanceSystemPassword.Pwd));
                                    }
                                    else//失败
                                    {
                                        DisplayContent("多功能操作平台初始化设置失败，请重新操作。");
                                        p_Top.Enabled = true;
                                    }
                                }
                                else
                                {
                                    if (distanceparam.AuxiliaryCommand != 0)
                                    {
                                        SetDevicedNewPwd();
                                    }
                                }
                                break;
                            default:
                                DisplayContent("未知数据内容。");
                                p_Top.Enabled = true;
                                break;
                        }
                    }
                    else
                    {
                        DisplayContent("未知数据内容。");
                        p_Top.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    DisplayContent(ex.Message);
                    p_Top.Enabled = true;
                    CustomExceptionHandler.GetExceptionMessage(ex);
                }
            }));
        }

        /// <summary>
        /// 设置设备新密码
        /// </summary>
        private void SetDevicedNewPwd()
        {
            PortHelper.SerialPortWrite(PortAgreement.GetDistanceEncryption(Dal_DevicePwd.DistanceSystemPassword.Pwd));
        }

        /// <summary>
        /// 列表显示内容
        /// </summary>
        /// <param name="content"></param>
        private void DisplayContent(string content)
        {
            DisplayContent(content, -1, Color.Red);
        }

        /// <summary>
        /// 列表显示内容
        /// </summary>
        /// <param name="content"></param>
        /// <param name="forecolor"></param>
        private void DisplayContent(string content, Color forecolor)
        {
            DisplayContent(content, -1, forecolor);
        }

        /// <summary>
        /// 列表显示内容
        /// </summary>
        /// <param name="content"></param>
        /// <param name="cardtype"></param>
        /// <param name="forecolor"></param>
        private void DisplayContent(string content, int cardtype, Color forecolor)
        {
            dgv_DataContent.Rows.Insert(0, new object[] { content, cardtype, DateTime.Now });
            dgv_DataContent.Rows[0].DefaultCellStyle.ForeColor = forecolor;
            dgv_DataContent.Rows[0].DefaultCellStyle.SelectionForeColor = forecolor;
            dgv_DataContent.FirstDisplayedScrollingRowIndex = 0;
            if (dgv_DataContent.RowCount > ShowRowCount)
            {
                dgv_DataContent.Rows.RemoveAt(dgv_DataContent.RowCount - 1);
            }
        }

        private static DistanceCard_Form _uniqueInstance;

        public static DistanceCard_Form GetInstance
        {
            get { return _uniqueInstance ?? (_uniqueInstance = new DistanceCard_Form()); }
        }

    }
}
