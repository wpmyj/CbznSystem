using Model;
using Dal;
using System.Threading;
using Bll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace CbznSystem
{
    /*
     * 此窗体用于加密多功能操作平台
     */
    public partial class DistanceEquipment_Form : Form
    {

        private int ShowRowCount = 0;

        /// <summary>
        /// 构造函数
        /// </summary>
        public DistanceEquipment_Form()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(240, 243, 245);

            this.Activated += DistanceEquipment_Form_Activated;
            this.Load += DistanceEquipment_Form_Load;
            this.KeyDown += DistanceEquipment_Form_KeyDown;

            dgv_DataContent.Resize += Dgv_DataContent_Resize;

            l_OldTitle.MouseDown += L_OldTitle_MouseDown;
            l_NewTitle.MouseDown += L_NewTitle_MouseDown;
            l_ConfirmTitle.MouseDown += L_ConfirmTitle_MouseDown;

            tb_OldPwd.TextChanged += Tb_OldPwd_TextChanged;
            tb_OldPwd.KeyPress += Tb_OldPwd_KeyPress;
            tb_NewPwd.TextChanged += Tb_NewPwd_TextChanged;
            tb_NewPwd.KeyPress += Tb_NewPwd_KeyPress;
            tb_ConfirmPwd.TextChanged += Tb_ConfirmPwd_TextChanged;
            tb_ConfirmPwd.KeyPress += Tb_ConfirmPwd_KeyPress;

            btn_OldDefault.Click += Btn_OldDefault_Click;
            btn_OldDefault.Paint += FormComm.DrawBtnEnabled;
            btn_NewDefault.Click += Btn_NewDefault_Click;
            btn_NewDefault.Paint += FormComm.DrawBtnEnabled;
            btn_Enter.Click += Btn_Enter_Click;
            btn_Enter.Paint += FormComm.DrawBtnEnabled;
        }

        private void DistanceEquipment_Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4 && e.Alt == true)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 窗体获取焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DistanceEquipment_Form_Activated(object sender, EventArgs e)
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
        /// DGV大小变化
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
        /// 默认新密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_NewDefault_Click(object sender, EventArgs e)
        {
            tb_NewPwd.Text = "766554";
            tb_ConfirmPwd.Text = "766554";
            tb_ConfirmPwd.Focus();
            tb_ConfirmPwd.SelectionStart = tb_ConfirmPwd.TextLength;
        }

        /// <summary>
        /// 默认旧密码
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
            string newpwd = tb_NewPwd.Text.Trim();
            string confirmpwd = tb_ConfirmPwd.Text.Trim();
            if (Dal_DevicePwd.DistanceSystemPassword.ID != 0)
            {
                if (oldpwd.Length != tb_OldPwd.MaxLength)
                {
                    DisplayContent("旧口令长度为 6 位数字，请重新输入旧口令。");
                    tb_OldPwd.Focus();
                    return;
                }
                if (oldpwd != Dal_DevicePwd.DistanceSystemPassword.Pwd)
                {
                    DisplayContent("验证旧口令错误，请重新输入旧口令。");
                    tb_OldPwd.Focus();
                    return;
                }
            }
            if (newpwd.Length != tb_NewPwd.MaxLength)
            {
                DisplayContent("新口令长度为 6 位数字，请重新输入新口令。");
                tb_NewPwd.Focus();
                return;
            }
            if (confirmpwd.Length != tb_ConfirmPwd.MaxLength)
            {
                DisplayContent("确认口令长度为 6 位数字，请重新输入确认口令。");
                tb_ConfirmPwd.Focus();
                return;
            }
            if (newpwd != confirmpwd)
            {
                DisplayContent("新口令与确认口令不一致。");
                tb_ConfirmPwd.Focus();
                return;
            }
            try
            {
                if (Dal_DevicePwd.DistanceSystemPassword.ID == 0)
                {
                    //插入新密码
                    CbDevicePwd mDistanceSystemPwd = new CbDevicePwd() { Pwd = newpwd };
                    mDistanceSystemPwd.ID = Dbhelper.Db.Insert<CbDevicePwd>(mDistanceSystemPwd);
                    Dal_DevicePwd.DistanceSystemPassword = mDistanceSystemPwd;
                    Tab1_Form.GetInstance.btn_Tab3.Enabled = true;
                }
                else
                {
                    //更新新密码
                    Dal_DevicePwd.DistanceSystemPassword.Pwd = newpwd;
                    Dbhelper.Db.Update<CbDevicePwd>(Dal_DevicePwd.DistanceSystemPassword);
                }
                if (PortHelper.IsConnection)
                {
                    byte[] by = PortAgreement.GetDistanceEncryption(newpwd);
                    PortHelper.SerialPortWrite(by);
                }
                else
                {
                    DisplayContent("多功能操作平台口令设置成功，请保管好口令。", Color.Black);
                    ClearTxt();
                }
            }
            catch (Exception ex)
            {
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 验证密码用户按下并释放事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tb_ConfirmPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (btn_Enter.Enabled)
                    Btn_Enter_Click(null, null);
            }
            e.Handled = LimitInput.InputNumber(e.KeyChar);
        }

        /// <summary>
        /// 新密码用户按下并释放事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tb_NewPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                tb_ConfirmPwd.Focus();
            }
            e.Handled = LimitInput.InputNumber(e.KeyChar);
        }

        /// <summary>
        /// 旧密码用户按下并释放事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tb_OldPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                tb_NewPwd.Focus();
            }
            e.Handled = LimitInput.InputNumber(e.KeyChar);
        }

        /// <summary>
        /// 验证密码文本变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tb_ConfirmPwd_TextChanged(object sender, EventArgs e)
        {
            l_ConfirmTitle.Visible = tb_ConfirmPwd.TextLength == 0;
            SetDefaultEnabled();
        }

        /// <summary>
        /// 新密码文本变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tb_NewPwd_TextChanged(object sender, EventArgs e)
        {
            l_NewTitle.Visible = tb_NewPwd.TextLength == 0;
            SetDefaultEnabled();
        }

        /// <summary>
        /// 设置默认密码控件是否启用
        /// </summary>
        private void SetDefaultEnabled()
        {
            if (tb_ConfirmPwd.TextLength > 0 || tb_NewPwd.TextLength > 0)
            {
                btn_NewDefault.Enabled = false;
            }
            else
            {
                btn_NewDefault.Enabled = true;
            }
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
        /// 验证密码标题鼠标按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void L_ConfirmTitle_MouseDown(object sender, MouseEventArgs e)
        {
            tb_ConfirmPwd.Focus();
        }

        /// <summary>
        /// 新密码标题鼠标按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void L_NewTitle_MouseDown(object sender, MouseEventArgs e)
        {
            tb_NewPwd.Focus();
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

        private static DistanceEquipment_Form _uniqueInstance;

        public static DistanceEquipment_Form GetInstance
        {
            get { return _uniqueInstance ?? (_uniqueInstance = new DistanceEquipment_Form()); }
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DistanceEquipment_Form_Load(object sender, EventArgs e)
        {
            btn_Enter.Enabled = Dal_ManageRights.ManageRights.DeviceEncryption;

            l_Description.Text = " 口令即密码，是为了把“5 米定距”的相关设备之间的空间通讯设置密码，以保证使用安全和防患卡，定距卡与读写器口令一致方可进行相关的读写操作。\n\n 此密码在使用过程中非常重要，所有初次使用一定要设置好密码，并且保存好。";

            //初始化端口接收事件
            PortHelper.DataReceived += SerialPortDataReceived;

            if (Dal_DevicePwd.DistanceSystemPassword.ID == 0)
            {
                l_Title.Visible = false;
                tb_OldPwd.Visible = false;
                l_OldTitle.Visible = false;
                btn_OldDefault.Visible = false;
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
                if (tb_NewPwd.TextLength == 0) return;
                try
                {
                    if (param.FunctionAddress == 65)
                    {
                        DistanceParameter distanceparam = DataParsing.DistanceParsingContent(param.DataContent);
                        if (distanceparam.Command == 160)
                        {
                            if (distanceparam.AuxiliaryCommand == 0)//成功
                            {
                                DisplayContent("多功能操作平台口令设置成功，请保管好口令。", Color.Black);
                                ClearTxt();
                            }
                            else//失败
                            {
                                DisplayContent("多功能操作平台口令设置失败，请重新操作。");
                            }
                        }
                        else
                        {
                            DisplayContent("未知数据内容。");
                        }
                    }
                    else
                    {
                        DisplayContent("未知数据内容。");
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
        /// 清空文本内容
        /// </summary>
        private void ClearTxt()
        {
            l_Title.Visible = true;
            tb_OldPwd.Visible = true;
            l_OldTitle.Visible = true;
            btn_OldDefault.Visible = true;

            tb_OldPwd.Text = string.Empty;
            tb_NewPwd.Text = string.Empty;
            tb_ConfirmPwd.Text = string.Empty;
        }

        /// <summary>
        /// 列表中显示内容
        /// </summary>
        /// <param name="content"></param>
        private void DisplayContent(string content)
        {
            DisplayContent(content, Color.Red);
        }

        /// <summary>
        /// 列表中显示内容
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

    }
}
