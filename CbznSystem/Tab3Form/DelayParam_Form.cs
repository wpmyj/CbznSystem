using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Dal;
using Bll;
using Model;
using NewControl;
using System.Threading;

namespace CbznSystem
{
    public partial class DelayParam_Form : NewForm
    {
        /// <summary>
        /// 单张副卡延期
        /// </summary>
        private CbAssociateCard _mAssociateCard;
        /// <summary>
        /// 定距卡延期
        /// </summary>
        private CbCardInfo _mCardInfo;
        /// <summary>
        /// 定距卡计数
        /// </summary>
        private CbCardCountingState _mCardCounting;
        /// <summary>
        /// 批量延期集合
        /// </summary>
        private List<CbAssociateCard> _mAssociateCards;
        private bool _isActivate;

        /// <summary>
        /// 显示动画效果
        /// </summary>
        private System.Timers.Timer _tEffect;
        /// <summary>
        /// 超时线程
        /// </summary>
        private Thread _tTimeOutThread;

        /// <summary>
        /// 构造函数 批量延期
        /// </summary>
        /// <param name="massociatecards"></param>
        public DelayParam_Form(List<CbAssociateCard> massociatecards)
        {
            InitializeComponent();

            _mAssociateCards = massociatecards;
        }

        /// <summary>
        /// 构造函数 单张副卡延期
        /// </summary>
        /// <param name="massociatecard"></param>
        public DelayParam_Form(CbAssociateCard massociatecard)
        {
            InitializeComponent();

            _mAssociateCard = massociatecard;
        }

        /// <summary>
        /// 构造函数 单卡延期
        /// </summary>
        /// <param name="mcardinfo"></param>
        public DelayParam_Form(CbCardInfo mcardinfo)
        {
            InitializeComponent();

            _mCardInfo = mcardinfo;
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelayParam_Form_Load(object sender, EventArgs e)
        {
            //全选变化事件
            cb_AllSelected.CheckedChanged += Cb_AllSelected_CheckedChanged;
            //全选鼠标按下事件
            cb_AllSelected.MouseDown += Cb_AllSelected_MouseDown;
            //延期选择
            cb_DelaySelected.SelectedIndexChanged += Cb_DelaySelected_SelectedIndexChanged;
            //延期次数
            ud_DelayValue.ValueChanged += Ud_DelayValue_ValueChanged;
            btn_Enter.Click += Btn_Enter_Click;
            btn_Enter.Paint += FormComm.DrawBtnEnabled;

            if (_mCardInfo != null)
            {
                //初始化端口数据接收事件
                PortHelper.DataReceived += SerialPortDataReceived;
                //初始化端口变化事件
                PortHelper.ConnectionChange += DeviceConnectionChange;
                PortHelper.CurrentForm = this;
                btn_Enter.Enabled = PortHelper.IsConnection;
                //显示卡片编号
                tb_CardNumber.Text = _mCardInfo.CardNumber;
                //显示旧时间
                t_OldTime.Value = _mCardInfo.StopTime;
                //车场分区
                cb_CardPartition.SelectedIndex = _mCardInfo.FieldPartition == 0 ? 0 : 1;
                //获取定距卡的车场分区
                SetPartiion(_mCardInfo.FieldPartition);
            }
            else if (_mAssociateCard != null)
            {
                //显示副卡编号
                tb_CardNumber.Text = _mAssociateCard.AssociateCardNumber;
                //显示旧时间
                t_OldTime.Value = _mAssociateCard.AssociateCardTime;
                //车场分区
                cb_CardPartition.SelectedIndex = _mAssociateCard.SubCardDivision == 0 ? 0 : 1;
                //获取定距卡的车场分区
                SetPartiion(_mAssociateCard.SubCardDivision);
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                foreach (CbAssociateCard item in _mAssociateCards)
                {
                    sb.AppendFormat("{0},", item.AssociateCardNumber);
                }
                sb = sb.Remove(sb.Length - 1, 1);
                //显示副卡编号
                tb_CardNumber.Text = sb.ToString();
                //车场分区
                cb_CardPartition.SelectedIndex = 1;
            }

            cb_DelaySelected.SelectedIndex = 1;
        }

        /// <summary>
        /// 全选鼠标按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cb_AllSelected_MouseDown(object sender, MouseEventArgs e)
        {
            cb_AllSelected.ThreeState = false;
        }

        /// <summary>
        /// 车场分区容器重绘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void p_CardPartition_Paint(object sender, PaintEventArgs e)
        {
            DrawBorder(e.Graphics, cb_CardPartition, p_CardPartition);
        }

        /// <summary>
        /// 绘制车场分区和副卡容器的边框
        /// </summary>
        /// <param name="host"></param>
        /// <param name="p"></param>
        private void DrawBorder(Graphics g, Control host, Panel p)
        {
            int height = 5;
            int left = host.Left - p.Left;
            Point[] points = {
                             new Point(0 , height),
                             new Point(left + (host.Width / 2 - height) , height),
                             new Point(left + (host.Width / 2) , 0),
                             new Point(left + (host.Width / 2 + height), height),
                             new Point(p.Width - 1, height),
                             new Point(p.Width - 1, p.Height - 1),
                             new Point(0 , p.Height - 1),
                             new Point(0 , height)
                             };
            g.DrawLines(new Pen(Brushes.Gray, 1), points);
            g.Dispose();
        }

        /// <summary>
        /// 端口变化事件
        /// </summary>
        /// <param name="flag"></param>
        private void DeviceConnectionChange(bool flag)
        {
            this.BeginInvoke(new EventHandler(delegate { btn_Enter.Enabled = flag; }));
        }

        /// <summary>
        /// 端口数据接收事件
        /// </summary>
        /// <param name="param"></param>
        private void SerialPortDataReceived(ParsingParameter param)
        {
            if (!PortHelper.IsConnection) return;
            if (PortHelper.CurrentForm != this) return;
            try
            {
                if (param.FunctionAddress == 65)
                {
                    StopTimeOut();
                    //解析数据内容
                    DistanceParameter distanceparam = DataParsing.DistanceParsingContent(param.DataContent);
                    if (distanceparam.Command == 27)//定距卡写入
                    {
                        if (distanceparam.AuxiliaryCommand == 0) //成功
                        {
                            Dbhelper.Db.Update<CbCardInfo>(_mCardInfo);
                            Dbhelper.Db.Update<CbCardCountingState>(_mCardCounting);
                            this.Tag = _mCardInfo;
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show("定距卡写入失败，请将定距卡放置在发行器可读写区域内，重新操作。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
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
                btn_Enter.Enabled = true;
            }
        }

        /// <summary>
        /// 确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Enter_Click(object sender, EventArgs e)
        {
            //获取延期时间
            DateTime newtime = t_NewTime.Value;
            //获取车场分区的值
            int partition = cb_CardPartition.SelectedIndex == 0 ? 0 : GetPartition();
            if (_mCardInfo != null)//定距卡
            {
                btn_Enter.Enabled = false;
                _mCardInfo.StopTime = newtime;
                _mCardInfo.FieldPartition = partition;

                try
                {
                    if (_mCardCounting == null)
                    {
                        //获取定距卡计数信息
                        _mCardCounting = Dbhelper.Db.FirstDefault<CbCardCountingState>(" and UseNumber = '" + _mCardInfo.CardNumber + "' ");
                        //计数加1
                        _mCardCounting.UseCounting = DistanceCardHelper.LimitCount(_mCardCounting.UseCounting);
                    }
                    //将数据写入定距卡
                    byte[] by = DistanceCardHelper.SetDistanceData(_mCardInfo.CardNumber, _mCardCounting.UseCounting, _mCardInfo.StopTime, _mCardInfo.FieldPartition);
                    PortHelper.SerialPortWrite(by);
                    StartTimeOut();
                }
                catch (Exception ex)
                {
                    btn_Enter.Enabled = true;
                    CustomExceptionHandler.GetExceptionMessage(ex);
                    MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (_mAssociateCard != null)//单张副卡
            {
                _mAssociateCard.UpdateTime = newtime;
                _mAssociateCard.SubCardDivision = partition;
                this.Tag = _mAssociateCard;
                this.DialogResult = DialogResult.OK;
            }
            else //批量延期
            {
                foreach (CbAssociateCard item in _mAssociateCards)
                {
                    item.UpdateTime = newtime;
                    item.SubCardDivision = partition;
                }
                this.Tag = _mAssociateCards;
                this.DialogResult = DialogResult.OK;
            }
        }

        /// <summary>
        /// 开始超时线程
        /// </summary>
        private void StartTimeOut()
        {
            StopTimeOut();
            _tTimeOutThread = new Thread(TimeOutWait);
            _tTimeOutThread.IsBackground = true;
            _tTimeOutThread.Start();
        }

        /// <summary>
        /// 停止超时线程
        /// </summary>
        private void StopTimeOut()
        {
            if (_tTimeOutThread != null)
            {
                _tTimeOutThread.Abort();
            }
        }

        /// <summary>
        /// 超时线程等待
        /// </summary>
        private void TimeOutWait()
        {
            try
            {
                Thread.Sleep(5000);

                this.Invoke(new EventHandler(delegate
                {
                    btn_Enter.Enabled = PortHelper.IsConnection;
                }));
            }
            finally
            {
                _tTimeOutThread = null;
            }
        }

        /// <summary>
        /// 延期次数发生变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ud_DelayValue_ValueChanged(object sender, EventArgs e)
        {
            Cb_DelaySelected_SelectedIndexChanged(null, null);
        }

        /// <summary>
        /// 延期方式发生变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cb_DelaySelected_SelectedIndexChanged(object sender, EventArgs e)
        {
            int value = (int)ud_DelayValue.Value;
            switch (cb_DelaySelected.SelectedIndex)
            {
                case 0:
                    t_NewTime.Value = t_OldTime.Value.AddDays(value);
                    break;
                case 1:
                    t_NewTime.Value = t_OldTime.Value.AddDays(value * 30);
                    break;
                case 2:
                    t_NewTime.Value = t_OldTime.Value.AddMonths(value * 3);
                    break;
                case 3:
                    t_NewTime.Value = t_OldTime.Value.AddYears(value);
                    break;
            }
        }

        /// <summary>
        /// 设置车场分区
        /// </summary>
        /// <param name="partition"></param>
        private void SetPartiion(int partition)
        {
            for (int i = 0; i < 16; i++)
            {
                int check = BinaryHelper.GetIntegerSomeBit(partition, i);
                Control[] findcontrol = p_CardPartition.Controls.Find("cb_Partition" + (i + 1), false);
                foreach (Control item in findcontrol)
                {
                    if (check != 1) continue;
                    CheckBox cb = item as CheckBox;
                    if (cb != null)
                        cb.Checked = true;
                }
            }
            SetCheckState();
        }

        /// <summary>
        /// 获取车场分区选择的值
        /// </summary>
        /// <returns></returns>
        private int GetPartition()
        {
            int partition = 0;
            for (int i = 0; i < 16; i++)
            {
                Control[] findcontrol = p_CardPartition.Controls.Find("cb_Partition" + (i + 1), true);
                foreach (Control item in findcontrol)
                {
                    CheckBox cb = item as CheckBox;
                    partition = BinaryHelper.SetIntegeSomeBit(partition, i, cb != null && cb.Checked);
                }
            }
            return partition;
        }

        /// <summary>
        /// 车场分区全选事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cb_AllSelected_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_AllSelected.CheckState == CheckState.Indeterminate) return;
            cb_AllSelected.Tag = cb_AllSelected.Checked;
            foreach (Control item in p_CardPartition.Controls)
            {
                if (item == cb_AllSelected) continue;
                if (item is CheckBox)
                {
                    ((CheckBox)item).Checked = cb_AllSelected.Checked;
                }
            }
            cb_AllSelected.Tag = null;
        }

        /// <summary>
        /// 车场分区选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Partition_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_AllSelected.Tag != null) return;
            if (!_isActivate) return;
            SetCheckState();
        }

        /// <summary>
        /// 设置车场分区全选状态
        /// </summary>
        private void SetCheckState()
        {
            int count = 0;
            foreach (Control item in p_CardPartition.Controls)
            {
                if (item is Label) continue;
                if (item == cb_AllSelected) continue;
                if (((CheckBox)item).Checked)
                    count++;
            }
            cb_AllSelected.ThreeState = true;
            if (count == 0)
                cb_AllSelected.CheckState = CheckState.Unchecked;
            else if (count == 16)
                cb_AllSelected.CheckState = CheckState.Checked;
            else
                cb_AllSelected.CheckState = CheckState.Indeterminate;
        }

        /// <summary>
        /// 窗体关闭前
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelayParam_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_mCardInfo != null)
            {
                if (!btn_Enter.Enabled)
                {
                    MessageBox.Show("当前操作未完成无法退出，请稍后。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
                //释放端口数据接收
                PortHelper.DataReceived -= SerialPortDataReceived;
                //释放连接状态
                PortHelper.ConnectionChange -= DeviceConnectionChange;
            }
        }

        /// <summary>
        /// 窗体显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelayParam_Form_Shown(object sender, EventArgs e)
        {
            _isActivate = true;
        }

        /// <summary>
        /// 车场分区选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_CardPartition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_CardPartition.SelectedIndex == 0)
            {
                p_CardPartition.Visible = false;
            }

            //开启动画效果
            StopEffect();
            StartEffect();
        }

        /// <summary>
        /// 停止显示动画效果
        /// </summary>
        private void StopEffect()
        {
            if (_tEffect != null)
            {
                _tEffect.Stop();
                _tEffect = null;
            }
        }

        /// <summary>
        /// 开始显示动画效果
        /// </summary>
        private void StartEffect()
        {
            _tEffect = new System.Timers.Timer(5) { AutoReset = true };
            _tEffect.Elapsed += ShowEffect;
            _tEffect.Start();
        }

        /// <summary>
        /// 显示动画效果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowEffect(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.Invoke(new EventHandler(delegate
            {
                if (cb_CardPartition.SelectedIndex == 0)
                {
                    if (Height <= 222)
                    {
                        StopEffect();
                        Height = 222;
                        return;
                    }
                    Height -= 20;
                }
                else
                {
                    if (Height >= 430)
                    {
                        StopEffect();
                        Height = 430;
                        p_CardPartition.Visible = true;
                        return;
                    }
                    Height += 20;
                }
            }));
        }
    }
}
