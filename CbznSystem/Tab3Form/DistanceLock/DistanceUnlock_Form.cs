using System.Threading;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NewControl;
using Bll;
using Dal;
using Model;

namespace CbznSystem
{
    public partial class DistanceUnlock_Form : NewForm
    {

        public delegate void LockChangeEventHandler(KeyValuePair<CbCardInfo, int> dic);

        public event LockChangeEventHandler LockChange;

        private void OnLockChange(KeyValuePair<CbCardInfo, int> dic)
        {
            LockChange?.Invoke(dic);
        }

        /// <summary>
        /// 解锁定距卡集合
        /// </summary>
        private Dictionary<CbCardInfo, int> _mUnLockList;

        /// <summary>
        /// 解锁的定距卡
        /// </summary>
        private CbCardInfo _mUnLockCardInfo;

        /// <summary>
        /// 超时线程
        /// </summary>
        private Thread _tTimeOutThread;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="mcardinfos"></param>
        public DistanceUnlock_Form(Dictionary<CbCardInfo, int> mcardinfos)
        {
            InitializeComponent();

            _mUnLockList = mcardinfos;

            this.Load += DistanceUnlock_Form_Load;
            this.FormClosed += DistanceUnlock_Form_FormClosed;
            this.FormClosing += DistanceUnlock_Form_FormClosing;

            cb_AllSelected.MouseDown += Cb_AllSelected_MouseDown;
            cb_AllSelected.CheckedChanged += Cb_AllSelected_CheckedChanged;

            dgv_UnlockList.CellValueChanged += Dgv_UnlockList_CellValueChanged;
            dgv_UnlockList.CurrentCellDirtyStateChanged += Dgv_UnlockList_CurrentCellDirtyStateChanged;
            dgv_UnlockList.RowsAdded += Dgv_UnlockList_RowsAdded;
            dgv_UnlockList.RowsRemoved += Dgv_UnlockList_RowsRemoved;

            btn_Remove.Click += Btn_Remove_Click;
            btn_Remove.Paint += FormComm.DrawBtnEnabled;
            btn_Enter.Click += Btn_Enter_Click;
            btn_Enter.Paint += FormComm.DrawBtnEnabled;
        }

        /// <summary>
        /// 窗体关闭前
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DistanceUnlock_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (PortHelper.IsConnection && !btn_Enter.Enabled && dgv_UnlockList.RowCount > 0)
            {
                MessageBox.Show("解锁定距卡操作未完成无法退出，请稍后。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                e.Cancel = true;
            }
        }

        /// <summary>
        /// DGV 移除行事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dgv_UnlockList_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dgv_UnlockList.RowCount == 0)
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
        private void Dgv_UnlockList_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            btn_Enter.Enabled = PortHelper.IsConnection;
            cb_AllSelected.Enabled = true;
        }

        /// <summary>
        /// DGV 单元格状态因其内容更改而更改时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dgv_UnlockList_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgv_UnlockList.IsCurrentCellDirty)
                dgv_UnlockList.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        /// <summary>
        /// DGV 单元格发生变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dgv_UnlockList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_UnlockList.Columns[e.ColumnIndex].Name == "c_Selected")
            {
                if (cb_AllSelected.Tag != null) return;
                int count = 0;
                for (int i = 0; i < dgv_UnlockList.RowCount; i++)
                {
                    bool flag = Utils.StrToBool(dgv_UnlockList["c_Selected", i].Value, false);
                    if (flag)
                        count++;
                }
                cb_AllSelected.ThreeState = true;
                if (count == 0)
                    cb_AllSelected.CheckState = CheckState.Unchecked;
                else if (count == dgv_UnlockList.RowCount)
                    cb_AllSelected.CheckState = CheckState.Checked;
                else
                    cb_AllSelected.CheckState = CheckState.Indeterminate;
                btn_Remove.Enabled = count > 0;
            }
        }

        /// <summary>
        /// 窗体关闭后事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DistanceUnlock_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            //释放端口接收事件
            PortHelper.DataReceived -= SerialPortDataReceived;
            //释放端口变化事件
            PortHelper.ConnectionChange -= DeviceConnectionChange;
        }

        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Remove_Click(object sender, EventArgs e)
        {
            for (int i = dgv_UnlockList.RowCount - 1; i >= 0; i--)
            {
                bool flag = Utils.StrToBool(dgv_UnlockList["c_Selected", i].Value, false);
                if (!flag) continue;
                RemoveUnlock(i);
                dgv_UnlockList.Rows.RemoveAt(i);
            }
            cb_AllSelected.CheckState = CheckState.Unchecked;
            btn_Remove.Enabled = false;
        }

        /// <summary>
        /// 移除解锁
        /// </summary>
        /// <param name="index"></param>
        private void RemoveUnlock(int index)
        {
            int count = 0;
            foreach (KeyValuePair<CbCardInfo, int> item in _mUnLockList)
            {
                if (count == index)
                {
                    _mUnLockList.Remove(item.Key);
                    break;
                }
                count++;
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

            _mUnLockCardInfo = null;

            UnlockDistanceCard(0);
        }

        /// <summary>
        /// 启用控件
        /// </summary>
        private void UseControlEnabled()
        {
            btn_Enter.Enabled = PortHelper.IsConnection;
            cb_AllSelected.Enabled = true;
            if (cb_AllSelected.CheckState != CheckState.Unchecked)
                btn_Remove.Enabled = true;
        }

        /// <summary>
        /// 解锁
        /// </summary>
        /// <param name="cardnumber"></param>
        /// <param name="flag"></param>
        private void UnlockDistanceCard(int flag)
        {
            try
            {
                StopTimeOutThread();
                int index = -1;
                foreach (KeyValuePair<CbCardInfo, int> item in _mUnLockList)
                {
                    index++;
                    if (_mUnLockCardInfo != null && item.Key == _mUnLockCardInfo)
                    {
                        if (flag == 0)
                        {
                            item.Key.Unlocked = 0;
                            Dbhelper.Db.Update<CbCardInfo>(item.Key);
                            dgv_UnlockList["c_State", index].Value = Properties.Resources.check;
                            OnLockChange(item);
                        }
                        _mUnLockCardInfo = null;
                        continue;
                    }
                    if (_mUnLockCardInfo != null) continue;
                    if (item.Key.Unlocked == 0) continue;
                    _mUnLockCardInfo = item.Key;
                    DistanceTypeParameter typeparam = new DistanceTypeParameter() { Lock = 0, Distance = item.Key.Distance };
                    int typebyte = DistanceCardHelper.SetCardTypeByte(typeparam, 1);
                    byte[] by = PortAgreement.GetDistanceContent(item.Key.CardNumber, typebyte);
                    PortHelper.SerialPortWrite(by);

                    StartTimeOutThread();
                    return;
                }
                foreach (KeyValuePair<CbCardInfo, int> item in _mUnLockList)
                {
                    if (item.Key.Unlocked != 0)
                    {
                        UseControlEnabled();
                        return;
                    }
                }
                dgv_UnlockList.Rows.Clear();
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                UseControlEnabled();
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 超时处理
        /// </summary>
        private void TimeOutWait()
        {
            try
            {
                Thread.Sleep(5000);

                this.Invoke(new EventHandler(delegate
                {
                    UseControlEnabled();
                }));
            }
            finally
            {
                _tTimeOutThread = null;
            }
        }

        /// <summary>
        /// 开始超时线程
        /// </summary>
        /// <param name=""></param>
        private void StartTimeOutThread()
        {
            StopTimeOutThread();
            _tTimeOutThread = new Thread(TimeOutWait);
            _tTimeOutThread.IsBackground = true;
            _tTimeOutThread.Start();
        }

        /// <summary>
        /// 停止超时线程
        /// </summary>
        private void StopTimeOutThread()
        {
            if (_tTimeOutThread != null)
            {
                _tTimeOutThread.Abort();
            }
        }

        /// <summary>
        /// 全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cb_AllSelected_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_AllSelected.CheckState == CheckState.Indeterminate) return;
            cb_AllSelected.Tag = cb_AllSelected.Checked;
            for (int i = 0; i < dgv_UnlockList.RowCount; i++)
            {
                dgv_UnlockList["c_Selected", i].Value = cb_AllSelected.Checked;
            }
            if (dgv_UnlockList.RowCount > 0)
                btn_Remove.Enabled = cb_AllSelected.Checked;
            cb_AllSelected.Tag = null;
        }

        /// <summary>
        /// 全选鼠标按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cb_AllSelected_MouseDown(object sender, MouseEventArgs e)
        {
            cb_AllSelected.ThreeState = false;
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DistanceUnlock_Form_Load(object sender, EventArgs e)
        {
            //初始化端口接收事件
            PortHelper.DataReceived += SerialPortDataReceived;
            //初始化端口变化事件
            PortHelper.ConnectionChange += DeviceConnectionChange;
            PortHelper.CurrentForm = this;

            //显示需挂失的集合
            foreach (KeyValuePair<CbCardInfo, int> item in _mUnLockList)
            {
                dgv_UnlockList.Rows.Add(new object[] { false, Properties.Resources.block, item.Key.CardNumber, item.Key.UserName });
            }
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
        /// 端口接收事件
        /// </summary>
        /// <param name="param"></param>
        private void SerialPortDataReceived(ParsingParameter param)
        {
            if (!PortHelper.IsConnection) return;
            if (PortHelper.CurrentForm != this) return;
            this.Invoke(new EventHandler(delegate
            {
                if (param.FunctionAddress == 65)
                {
                    DistanceParameter distanceparam = DataParsing.DistanceParsingContent(param.DataContent);
                    if (distanceparam.Command == 27)
                    {
                        UnlockDistanceCard(distanceparam.AuxiliaryCommand);
                    }
                }
            }));
        }
    }
}
