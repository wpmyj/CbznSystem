using Dal;
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
    public partial class IcCard_Form : Form
    {

        private int ShowRowCount = 0;

        private bool IsEnd;

        /// <summary>
        /// 构造函数
        /// </summary>
        public IcCard_Form()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(240, 243, 245);

            this.Activated += IcCard_Form_Activated;
            this.Load += IcCardForm_Load;
            this.KeyDown += IcCard_Form_KeyDown;

            dgv_DataContent.Resize += Dgv_DataContent_Resize;

            l_OldTitle.MouseDown += L_OldTitle_MouseDown;
            tb_OldPwd.TextChanged += Tb_OldPwd_TextChanged;
            tb_OldPwd.KeyPress += Tb_OldPwd_KeyPress;
            tb_OldPwd.EnabledChanged += Tb_OldPwd_EnabledChanged;

            btn_OldDefault.Click += Btn_OldDefault_Click;
            btn_OldDefault.Paint += FormComm.DrawBtnEnabled;
            btn_Enter.Click += Btn_Enter_Click;
            btn_Enter.Paint += FormComm.DrawBtnEnabled;
        }

        private void IcCard_Form_KeyDown(object sender, KeyEventArgs e)
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
        private void IcCard_Form_Activated(object sender, EventArgs e)
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
        /// 窗体大小变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dgv_DataContent_Resize(object sender, EventArgs e)
        {
            int timewidth = dgv_DataContent.Columns["c_Time"].Width;
            dgv_DataContent.Columns["c_Content"].Width = dgv_DataContent.Width - timewidth;

            ShowRowCount = dgv_DataContent.Height / dgv_DataContent.RowTemplate.Height;
        }

        /// <summary>
        /// 默认旧密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_OldDefault_Click(object sender, EventArgs e)
        {
            tb_OldPwd.Text = "FFFFFFFF";
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
                byte[] by = PortAgreement.GetTemporaryEncryption(oldpwd);
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
        /// 旧密码用户按下并且释放
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
        /// 旧密码标题鼠标按下事件
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
        private void IcCardForm_Load(object sender, EventArgs e)
        {
            l_Description.Text = " “IC 设备”与“IC 卡”密码相同时方可修改 “IC 卡”密码为新密码。\n\n 将“IC 卡”放到多功能操作平台上，输入 IC 卡的旧密码，再单击“确认”按钮。 ";

            btn_Enter.Enabled = Dal_ManageRights.ManageRights.ICEncryptionICCardEncryption ? PortHelper.IsConnection : false;
            //初始化端口接收
            PortHelper.DataReceived += SerialPortDataReceived;
            //初始化端口变化
            PortHelper.ConnectionChange += DeviceConnectionChange;
        }

        /// <summary>
        /// 端口变化事件
        /// </summary>
        /// <param name="flag"></param>
        private void DeviceConnectionChange(bool flag)
        {
            this.BeginInvoke(new EventHandler(delegate
            {
                if (flag)
                {
                    btn_Enter.Enabled = Dal_ManageRights.ManageRights.ICEncryptionICCardEncryption;
                }
                else
                {
                    btn_Enter.Enabled = false;
                }
            }));
        }

        /// <summary>
        /// 列表显示内容
        /// </summary>
        /// <param name="content"></param>
        private void DisplayContent(string content)
        {
            DisplayContent(content, Color.Red);
        }

        /// <summary>
        /// 列表显示内容
        /// </summary>
        /// <param name="content"></param>
        /// <param name="forecolor"></param>
        private void DisplayContent(string content, Color forecolor)
        {
            dgv_DataContent.Rows.Insert(0, new object[] { content, DateTime.Now });
            dgv_DataContent.Rows[0].DefaultCellStyle.ForeColor = forecolor;
            dgv_DataContent.Rows[0].DefaultCellStyle.SelectionForeColor = forecolor;
            dgv_DataContent.FirstDisplayedScrollingRowIndex = 0;
            if (dgv_DataContent.RowCount > ShowRowCount)
            {
                dgv_DataContent.Rows.RemoveAt(dgv_DataContent.RowCount - 1);
            }
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
                try
                {
                    if (param.FunctionAddress == 66)
                    {
                        long result = DataParsing.TemporaryContent(param.DataContent);
                        switch (param.Command)
                        {
                            case 204:
                                if (result == 0)
                                {
                                    DisplayContent("临时 IC 卡加载成功。", Color.Black);
                                }
                                else
                                {
                                    DisplayContent("临时 IC 卡加载失败，请确认旧密码是否正确或IC 卡是否放置在读写区域内。");
                                }
                                SetDeviceNewPassword();
                                IsEnd = true;
                                break;
                            case 221:
                                if (!IsEnd)
                                {
                                    if (result == 0)
                                    {
                                        DisplayContent("临时 IC 设备初始化成功。", Color.Black);
                                        PortHelper.SerialPortWrite(PortAgreement.GetTemporaryICEncryption(Dal_IcDevicePwd.TempIcDevicePassword.Pwd));
                                    }
                                    else
                                    {
                                        DisplayContent("临时 IC 设备初始化失败。");
                                        p_Top.Enabled = true;
                                    }
                                }
                                else
                                {
                                    if (result != 0)
                                    {
                                        SetDeviceNewPassword();
                                    }
                                    else
                                    {
                                        p_Top.Enabled = true;
                                    }
                                }
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    CustomExceptionHandler.GetExceptionMessage(ex);
                    MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }));
        }

        /// <summary>
        /// 设置设备新密码
        /// </summary>
        private void SetDeviceNewPassword()
        {
            PortHelper.SerialPortWrite(PortAgreement.GetTemporaryEncryption(Dal_IcDevicePwd.TempIcDevicePassword.Pwd));
        }

        private static IcCard_Form _uniqueInstance;

        public static IcCard_Form GetInstance
        {
            get { return _uniqueInstance ?? (_uniqueInstance = new IcCard_Form()); }
        }

    }
}
