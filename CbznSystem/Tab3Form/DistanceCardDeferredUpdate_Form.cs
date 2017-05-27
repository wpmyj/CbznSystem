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
    public partial class DistanceCardDeferredUpdate_Form : NewForm
    {
        public delegate void UpdateChangehandler(KeyValuePair<CbCardInfo, int> dic);

        public event UpdateChangehandler UpdateChange;

        private void OnUpdateChanage(KeyValuePair<CbCardInfo, int> dic)
        {
            UpdateChange?.Invoke(dic);
        }

        /// <summary>
        /// 延期更新的定距卡集合
        /// </summary>
        private Dictionary<CbCardInfo, int> _mUpdateList;

        /// <summary>
        /// 副卡的集合
        /// </summary>
        private List<CbAssociateCard> _mViceCard;

        /// <summary>
        /// 延期更新的定距卡
        /// </summary>
        private CbCardInfo _mCardInfo;

        /// <summary>
        /// 定距卡计数信息
        /// </summary>
        private CbCardCountingState _mCardCounting;

        /// <summary>
        /// 副卡的计数信息
        /// </summary>
        private List<CbCardCountingState> _mViceCardCounting;

        /// <summary>
        /// 超时线程
        /// </summary>
        private Thread _tTimeOutThread;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="mcardinfo"></param>
        public DistanceCardDeferredUpdate_Form(Dictionary<CbCardInfo, int> mcardinfo)
        {
            InitializeComponent();

            _mUpdateList = mcardinfo;

            this.Load += DistanceCardDeferredUpdate_Form_Load;
            this.FormClosing += DistanceCardDeferredUpdate_Form_FormClosing;
            this.FormClosed += DistanceCardDeferredUpdate_Form_FormClosed;

            cb_AllSelected.MouseDown += Cb_AllSelected_MouseDown;
            cb_AllSelected.CheckedChanged += Cb_AllSelected_CheckedChanged;

            dgv_DelayList.RowsAdded += dgv_DelayList_RowsAdded;
            dgv_DelayList.RowsRemoved += Dgv_DelayList_RowsRemoved;
            dgv_DelayList.CurrentCellDirtyStateChanged += Dgv_DelayList_CurrentCellDirtyStateChanged;
            dgv_DelayList.CellValueChanged += Dgv_DelayList_CellValueChanged;

            btn_Remove.Click += Btn_Remove_Click;
            btn_Remove.Paint += FormComm.DrawBtnEnabled;
            btn_Enter.Click += Btn_Enter_Click;
            btn_Enter.Paint += FormComm.DrawBtnEnabled;
        }

        /// <summary>
        /// 全选变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cb_AllSelected_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_AllSelected.CheckState == CheckState.Indeterminate) return;
            cb_AllSelected.Tag = cb_AllSelected.Checked;
            for (int i = 0; i < dgv_DelayList.RowCount; i++)
            {
                dgv_DelayList["c_Selected", i].Value = cb_AllSelected.Checked;
            }
            if (dgv_DelayList.RowCount > 0)
                btn_Remove.Enabled = cb_AllSelected.Checked;
            cb_AllSelected.Tag = null;
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
        /// 移除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Remove_Click(object sender, EventArgs e)
        {
            for (int i = dgv_DelayList.RowCount - 1; i >= 0; i--)
            {
                bool check = Utils.StrToBool(dgv_DelayList["c_Selected", i].Value, false);
                if (check)
                {
                    RemoveUpdate(i);
                    dgv_DelayList.Rows.RemoveAt(i);
                }
            }
            cb_AllSelected.CheckState = CheckState.Unchecked;
            btn_Remove.Enabled = false;
        }

        /// <summary>
        /// 移除更新集合
        /// </summary>
        /// <param name="index"></param>
        private void RemoveUpdate(int index)
        {
            int count = 0;
            foreach (KeyValuePair<CbCardInfo, int> item in _mUpdateList)
            {
                if (count == index)
                {
                    _mUpdateList.Remove(item.Key);
                    break;
                }
                count++;
            }
        }

        /// <summary>
        /// DGV  单元格内容发生变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dgv_DelayList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (cb_AllSelected.Tag != null) return;
            int count = 0;
            for (int i = 0; i < dgv_DelayList.RowCount; i++)
            {
                bool check = Utils.StrToBool(dgv_DelayList["c_Selected", i].Value, false);
                if (check)
                    count++;
            }
            cb_AllSelected.ThreeState = true;
            if (count == 0)
                cb_AllSelected.CheckState = CheckState.Unchecked;
            else if (count == dgv_DelayList.RowCount)
                cb_AllSelected.CheckState = CheckState.Checked;
            else
                cb_AllSelected.CheckState = CheckState.Indeterminate;
            btn_Remove.Enabled = count > 0;
        }

        /// <summary>
        /// DGV 单元格状态因其内容更改而更改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dgv_DelayList_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgv_DelayList.IsCurrentCellDirty)
            {
                dgv_DelayList.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        /// <summary>
        /// DGV 移除行事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dgv_DelayList_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dgv_DelayList.RowCount == 0)
            {
                btn_Enter.Enabled = false;
                cb_AllSelected.Enabled = false;
            }
        }

        /// <summary>
        /// DGV 添加行事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_DelayList_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            btn_Enter.Enabled = PortHelper.IsConnection;
            cb_AllSelected.Enabled = true;
        }

        /// <summary>
        /// 窗体关闭后事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DistanceCardDeferredUpdate_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            //释放端口接收事件
            PortHelper.DataReceived -= SerialPortDataReceived;
            //释放端口变化事件
            PortHelper.ConnectionChange -= DeviceConnectionChange;
        }

        /// <summary>
        /// 窗体关闭前事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DistanceCardDeferredUpdate_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (PortHelper.IsConnection && !btn_Enter.Enabled && dgv_DelayList.RowCount > 0)
            {
                MessageBox.Show("延期更新操作未完成无法退出，请稍后。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }
        }

        /// <summary>
        /// 确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Enter_Click(object sender, EventArgs e)
        {
            btn_Enter.Enabled = false;
            cb_AllSelected.Enabled = false;
            btn_Remove.Enabled = false;

            _mCardInfo = null;

            SetUpdateCardData(0);

        }

        /// <summary>
        /// 设置控件启用
        /// </summary>
        private void SetControlEnabled()
        {
            btn_Enter.Enabled = PortHelper.IsConnection;
            cb_AllSelected.Enabled = true;
            if (cb_AllSelected.CheckState != CheckState.Unchecked)
                btn_Remove.Enabled = true;
        }

        /// <summary>
        /// 开始线程超时
        /// </summary>
        private void StartTimeOutThread()
        {
            StopTimeOutThread();
            _tTimeOutThread = new Thread(TimeOutWait);
            _tTimeOutThread.IsBackground = true;
            _tTimeOutThread.Start();
        }

        /// <summary>
        /// 停止线程超时
        /// </summary>
        private void StopTimeOutThread()
        {
            if (_tTimeOutThread != null)
            {
                _tTimeOutThread.Abort();
            }
        }

        /// <summary>
        /// 超时等待
        /// </summary>
        private void TimeOutWait()
        {
            try
            {
                Thread.Sleep(5000);

                this.Invoke(new EventHandler(delegate
                {
                    SetControlEnabled();
                }));
            }
            finally
            {
                _tTimeOutThread = null;
            }
        }

        /// <summary>
        /// 延期更新
        /// </summary>
        /// <param name="cardnumber"></param>
        /// <param name="flag"></param>
        private void SetUpdateCardData(int flag)
        {
            try
            {
                StopTimeOutThread();
                int index = -1;
                //遍历更新的集合
                foreach (KeyValuePair<CbCardInfo, int> item in _mUpdateList)
                {
                    index++;
                    if (_mCardInfo != null && item.Key == _mCardInfo)
                    {
                        if (flag != 0) //失败
                        {
                            dgv_DelayList["c_State", index].Value = Properties.Resources.block;
                        }
                        else
                        {
                            DateTime maxtime = DateTime.MinValue;
                            foreach (CbAssociateCard vicecarditem in _mViceCard)
                            {
                                if (vicecarditem.UseState == 1)
                                {
                                    vicecarditem.UseState = 0;
                                    vicecarditem.AssociateCardTime = vicecarditem.UpdateTime;
                                }
                                if (vicecarditem.UpdateTime.Date > maxtime.Date)
                                {
                                    maxtime = vicecarditem.UpdateTime;
                                }
                            }
                            if (item.Key.StopTime.Date != maxtime.Date)
                            {
                                item.Key.StopTime = maxtime;
                                //更新主卡数据
                                Dbhelper.Db.Update<CbCardInfo>(item.Key);
                            }
                            //更新副卡数据
                            Dbhelper.Db.Update<CbAssociateCard>(_mViceCard.ToArray());
                            //更新计数数据
                            if (_mViceCardCounting != null)
                            {
                                _mViceCardCounting.Add(_mCardCounting);
                                Dbhelper.Db.Update<CbCardCountingState>(_mViceCardCounting.ToArray());
                            }
                            else
                            {
                                Dbhelper.Db.Update<CbCardCountingState>(_mCardCounting);
                            }
                            dgv_DelayList["c_State", index].Value = Properties.Resources.check;
                            OnUpdateChanage(item);
                        }
                        _mCardInfo = null;
                        continue;
                    }
                    if (_mCardInfo != null) continue;
                    if (dgv_DelayList["c_State", index].Value == Properties.Resources.check) continue;
                    _mCardInfo = item.Key;
                    //获取主卡计数字节数据
                    _mCardCounting = Dbhelper.Db.FirstDefault<CbCardCountingState>(" and UseNumber='" + item.Key.CardNumber + "' ");
                    //计数字节+1
                    _mCardCounting.UseCounting = DistanceCardHelper.LimitCount(_mCardCounting.UseCounting);
                    //获取副卡数据集
                    _mViceCard = Dbhelper.Db.ToList<CbAssociateCard>(" and CardID =" + item.Key.ID + " ");
                    byte[] by = null;
                    if (item.Key.CardType == (int)CardTypes.CombinationCard) //组合卡
                    {
                        StringBuilder sb = new StringBuilder();
                        foreach (CbAssociateCard vicecarditem in _mViceCard)
                        {
                            sb.AppendFormat(" UseNumber='{0}' or", vicecarditem.AssociateCardNumber);
                        }
                        if (sb.Length > 0)
                        {
                            sb.Remove(sb.Length - 2, 2);
                        }
                        //获取副卡集合的计数字节数据集
                        _mViceCardCounting = Dbhelper.Db.ToList<CbCardCountingState>(string.Format(" and ({0}) ", sb.ToString()));

                        List<CombinationCardViceCardDataParam> ViceCardParam = new List<CombinationCardViceCardDataParam>();
                        foreach (CbAssociateCard vicecarditem in _mViceCard)
                        {
                            CbCardCountingState vicecardcounting = GetViceCardCounting(vicecarditem.AssociateCardNumber);
                            ViceCardParam.Add(new CombinationCardViceCardDataParam()
                            {
                                ViceCardCount = vicecardcounting.UseCounting,
                                ViceCardNumber = vicecarditem.AssociateCardNumber,
                                ViceCardPartition = vicecarditem.SubCardDivision,
                                ViceCardTime = vicecarditem.UpdateTime
                            });
                        }
                        by = DistanceCardHelper.SetDistanceData(item.Key.CardNumber, _mCardCounting.UseCounting, ViceCardParam);
                    }
                    else//车牌识别卡
                    {
                        List<LprCardViceCardParam> ViceCardParam = new List<LprCardViceCardParam>();
                        foreach (CbAssociateCard vicecarditem in _mViceCard)
                        {
                            ViceCardParam.Add(new LprCardViceCardParam()
                            {
                                PlateNumber = vicecarditem.AssociateCardNumber,
                                ViceCardPartition = vicecarditem.SubCardDivision,
                                ViceCardTime = vicecarditem.UpdateTime
                            });
                        }
                        by = DistanceCardHelper.SetDistanceData(item.Key.CardNumber, _mCardCounting.UseCounting, ViceCardParam);
                    }
                    //发送数据
                    PortHelper.SerialPortWrite(by);
                    //开始超时线程
                    StartTimeOutThread();
                    return;
                }
                btn_Enter.Enabled = PortHelper.IsConnection;
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                SetControlEnabled();
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 获取副卡的计数信息
        /// </summary>
        /// <param name="cardnumber"></param>
        /// <returns></returns>
        private CbCardCountingState GetViceCardCounting(string cardnumber)
        {
            CbCardCountingState cardcounting = null;
            foreach (CbCardCountingState item in _mViceCardCounting)
            {
                if (item.UseNumber.Equals(cardnumber))
                {
                    item.UseCounting = DistanceCardHelper.LimitCount(item.UseCounting);
                    cardcounting = item;
                    break;
                }
            }
            return cardcounting;
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DistanceCardDeferredUpdate_Form_Load(object sender, EventArgs e)
        {
            //初始化端口数据接收
            PortHelper.DataReceived += SerialPortDataReceived;
            //初始化端口变化事件
            PortHelper.ConnectionChange += DeviceConnectionChange;
            PortHelper.CurrentForm = this;
            //显示延期的定距卡
            foreach (KeyValuePair<CbCardInfo, int> item in _mUpdateList)
            {
                dgv_DelayList.Rows.Add(new object[] { false, Properties.Resources.block, item.Key.CardNumber, item.Key.UserName });
            }
        }

        /// <summary>
        /// 端口变化事件
        /// </summary>
        /// <param name="flag"></param>
        private void DeviceConnectionChange(bool flag)
        {
            this.BeginInvoke(new EventHandler(delegate
            {
                btn_Enter.Enabled = flag;
            }));
        }

        /// <summary>
        /// 端口数据接收事件
        /// </summary>
        /// <param name="param"></param>
        private void SerialPortDataReceived(ParsingParameter param)
        {
            if (!PortHelper.IsConnection) return;
            if (PortHelper.CurrentForm != this) return;
            if (param.FunctionAddress == 65)
            {
                DistanceParameter distanceparam = DataParsing.DistanceParsingContent(param.DataContent);
                if (distanceparam.Command == 27)
                {
                    SetUpdateCardData(distanceparam.AuxiliaryCommand);
                }
            }
        }

    }
}
