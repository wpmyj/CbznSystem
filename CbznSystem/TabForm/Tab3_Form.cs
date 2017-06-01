using Bll;
using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CbznSystem
{
    enum OperatingType
    {
        None = 0,
        Loss = 1,//挂失
        WriteOff = 2//注销
    }

    public partial class Tab3_Form : Form
    {
        /// <summary>
        /// 超时线程
        /// </summary>
        private Thread _tTimeOutThread;
        /// <summary>
        /// 当前页的数量
        /// </summary>
        private int PageCount;
        /// <summary>
        /// 当前页数
        /// </summary>
        private int _CurrentPage;
        /// <summary>
        /// 挂失集合
        /// </summary>
        private Dictionary<CbCardInfo, int> _LossList;
        /// <summary>
        /// 挂失定距卡的计数信息
        /// </summary>
        private Dictionary<string, CbCardCountingState> _LossCountings;
        /// <summary>
        /// 副卡列表
        /// </summary>
        public static Dictionary<string, ViceCardParam> SubList;
        /// <summary>
        /// 主卡列表
        /// </summary>
        private List<string> _HostsList;
        /// <summary>
        /// 延期更新列表
        /// </summary>
        private Dictionary<string, int> _UpdateDelayList;
        /// <summary>
        /// 当前操作
        /// </summary>
        private OperatingType _eOperating = OperatingType.None;

        /// <summary>
        /// 获取当前页数据
        /// </summary>
        public int CurrentPage
        {
            get { return _CurrentPage; }
            set
            {
                _CurrentPage = value;

                tb_Page.Text = _CurrentPage.ToString();
                btn_FirstPage.Enabled = btn_PreviousPage.Enabled = _CurrentPage > 1;
                btn_NextPage.Enabled = btn_LastPage.Enabled = _CurrentPage < PageCount;
                tb_Page.Enabled = true;
                try
                {
                    string strwhere = GetSearchWhere();
                    DataTable dt = Dbhelper.Db.ToTable<CbCardInfo>(_CurrentPage - 1, 30, strwhere);
                    dgv_CardList.DataSource = dt;
                    dgv_CardList.Focus();

                    SetControlEnalbed(PortHelper.IsConnection);
                }
                catch (Exception ex)
                {
                    CustomExceptionHandler.GetExceptionMessage(ex);
                    MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public Tab3_Form()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(240, 243, 245);

            this.Load += Tab3_Form_Load;
            this.Activated += Tab3_Form_Activated;
            this.FormClosed += Tab3_Form_FormClosed;
            this.KeyDown += Tab3_Form_KeyDown;

            btn_Refresh.Click += Btn_Refresh_Click;
            btn_Refresh.Paint += FormComm.DrawBtnEnabled;
            btn_Issue.Click += Btn_Issue_Click;
            btn_Issue.Paint += FormComm.DrawBtnEnabled;
            btn_Delay.Click += Btn_Delay_Click;
            btn_Delay.Paint += FormComm.DrawBtnEnabled;
            btn_AddLose.Click += Btn_AddLose_Click;
            btn_AddLose.Paint += FormComm.DrawBtnEnabled;
            p_Loss.Paint += p_Loss_Paint;
            cb_AllSelected.MouseDown += Cb_AllSelected_MouseDown;
            cb_AllSelected.CheckedChanged += Cb_AllSelected_CheckedChanged;
            dgv_LossList.CurrentCellDirtyStateChanged += Dgv_LossList_CurrentCellDirtyStateChanged;
            dgv_LossList.CellValueChanged += Dgv_LossList_CellValueChanged;
            dgv_LossList.RowsRemoved += Dgv_LossList_RowsRemoved;
            dgv_LossList.RowsAdded += Dgv_LossList_RowsAdded;
            btn_LossClose.Click += Btn_LossClose_Click;
            btn_Enter.Click += Btn_Enter_Click;
            btn_Enter.Paint += FormComm.DrawBtnEnabled;
            btn_Remove.Click += Btn_Remove_Click;
            btn_Remove.Paint += FormComm.DrawBtnEnabled;

            btn_Other.Click += btn_Other_Click;
            tsmt_Cancellation.Click += Tsmt_Cancellation_Click;
            tsmt_DeferredUpdate.Click += Tsmt_DeferredUpdate_Click;
            tsmt_Unlock.Click += Tsmt_Unlock_Click;
            tsmt_Lockup.Click += Tsmt_Lockup_Click;
            btn_InformationInput.Click += Btn_InformationInput_Click;
            btn_ShowRecord.Click += Btn_ShowRecord_Click;
            btn_Print.Click += Btn_Print_Click;

            l_SearchTitle.MouseDown += L_SearchTitle_MouseDown;
            tb_SearchContent.TextChanged += Tb_SearchContent_TextChanged;
            tb_SearchContent.KeyPress += Tb_SearchContent_KeyPress;
            btn_Search.Click += Btn_Search_Click;

            p_Bottom.Paint += P_Bottom_Paint;
            btn_FirstPage.Click += Btn_FirstPage_Click;
            btn_FirstPage.Paint += FormComm.DrawBtnEnabled;
            btn_PreviousPage.Click += Btn_PreviousPage_Click;
            btn_PreviousPage.Paint += FormComm.DrawBtnEnabled;
            tb_Page.KeyPress += Tb_Page_KeyPress;
            btn_NextPage.Click += Btn_NextPage_Click;
            btn_NextPage.Paint += FormComm.DrawBtnEnabled;
            btn_LastPage.Click += Btn_LastPage_Click;
            btn_LastPage.Paint += FormComm.DrawBtnEnabled;

            dgv_CardList.CellFormatting += Dgv_CardList_CellFormatting;
            dgv_CardList.RowsRemoved += Dgv_CardList_RowsRemoved;
            dgv_CardList.CellMouseClick += Dgv_CardList_CellMouseClick;
            dgv_CardList.CellPainting += Dgv_CardList_CellPainting;
            dgv_CardList.CellMouseEnter += Dgv_CardList_CellMouseEnter;
        }

        /// <summary>
        /// 窗体按键按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tab3_Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4 && e.Alt)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 挂失DGV添加行事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dgv_LossList_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            btn_Enter.Enabled = PortHelper.IsConnection;
            cb_AllSelected.Enabled = true;
        }

        /// <summary>
        /// 挂失DGV移除行事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dgv_LossList_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dgv_LossList.RowCount == 0)
            {
                btn_Enter.Enabled = false;
                cb_AllSelected.Enabled = false;
                cb_AllSelected.CheckState = CheckState.Unchecked;
            }
        }

        /// <summary>
        /// 挂失DGV单元格内容发生变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dgv_LossList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (cb_AllSelected.Tag != null) return;
            int count = 0;
            for (int i = 0; i < dgv_LossList.RowCount; i++)
            {
                bool check = Utils.StrToBool(dgv_LossList["c_LossSelected", i].Value, false);
                if (check)
                    count++;
            }
            cb_AllSelected.ThreeState = true;
            if (count == 0)
                cb_AllSelected.CheckState = CheckState.Unchecked;
            else if (count == dgv_LossList.RowCount)
                cb_AllSelected.CheckState = CheckState.Checked;
            else
                cb_AllSelected.CheckState = CheckState.Indeterminate;
            btn_Remove.Enabled = count > 0;
        }

        /// <summary>
        /// 挂失DGV内容因其更改而更改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dgv_LossList_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgv_LossList.IsCurrentCellDirty)
            {
                dgv_LossList.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        /// <summary>
        /// 挂失全选变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cb_AllSelected_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_AllSelected.CheckState == CheckState.Indeterminate) return;
            cb_AllSelected.Tag = cb_AllSelected.CheckState;
            for (int i = 0; i < dgv_LossList.RowCount; i++)
            {
                dgv_LossList["c_LossSelected", i].Value = cb_AllSelected.Checked;
            }
            if (dgv_LossList.RowCount > 0)
                btn_Remove.Enabled = cb_AllSelected.Checked;
            cb_AllSelected.Tag = null;
        }

        /// <summary>
        /// 挂失全选鼠标按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cb_AllSelected_MouseDown(object sender, MouseEventArgs e)
        {
            cb_AllSelected.ThreeState = false;
        }

        /// <summary>
        /// 移除挂失
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Remove_Click(object sender, EventArgs e)
        {
            for (int i = dgv_LossList.RowCount - 1; i >= 0; i--)
            {
                bool check = Utils.StrToBool(dgv_LossList["c_LossSelected", i].Value, false);
                if (check)
                {
                    RemoveLoss(i);
                    dgv_LossList.Rows.RemoveAt(i);
                }
            }
            cb_AllSelected.CheckState = CheckState.Unchecked;
            btn_Remove.Enabled = false;
        }

        /// <summary>
        /// 移除挂失集合
        /// </summary>
        /// <param name="index"></param>
        private void RemoveLoss(int index)
        {
            int count = 0;
            foreach (KeyValuePair<CbCardInfo, int> item in _LossList)
            {
                if (count == index)
                {
                    _LossCountings.Remove(item.Key.CardNumber);
                    _LossList.Remove(item.Key);
                    break;
                }
                count++;
            }
        }

        /// <summary>
        /// 确认挂失
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Enter_Click(object sender, EventArgs e)
        {
            SetControlEnalbed(false);
            cb_AllSelected.Enabled = false;
            btn_Remove.Enabled = false;
            try
            {
                //初始化挂失参数
                List<LossCardDataParam> param = new List<LossCardDataParam>();
                foreach (KeyValuePair<CbCardInfo, int> item in _LossList)
                {
                    //将定卡修改为挂失
                    item.Key.LoseState = 1;
                    //定距卡的计数加1
                    _LossCountings[item.Key.CardNumber].UseCounting = DistanceCardHelper.LimitCount(_LossCountings[item.Key.CardNumber].UseCounting);
                    param.Add(new LossCardDataParam()
                    {
                        CardNumber = item.Key.CardNumber,
                        CardType = (CardTypes)item.Key.CardType,
                        CardTime = item.Key.StopTime,
                        Functionbyte = _LossCountings[item.Key.CardNumber].UseFunction
                    });
                }
                byte[] by = DistanceCardHelper.SetLossCard(param.ToArray());
                PortHelper.SerialPortWrite(by);
                _eOperating = OperatingType.Loss;
                StartTimeOutThread();
            }
            catch (Exception ex)
            {
                SetControlEnalbed(true);
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 关闭挂失操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_LossClose_Click(object sender, EventArgs e)
        {
            if (dgv_LossList.RowCount > 0)
            {
                if (MessageBox.Show("挂失操作未完成，是否放弃挂失。", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes)
                {
                    return;
                }
            }
            dgv_LossList.Rows.Clear();
            p_Loss.Visible = false;
            _LossList = null;
            _LossCountings = null;
        }

        /// <summary>
        /// 挂失列表容器重绘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void p_Loss_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                g.DrawLines(new Pen(dgv_CardList.GridColor, 1), new Point[] {
                    new Point(p_Loss.Width, 0),
                    new Point(0, 0),
                    new Point(0, p_Loss.Height)
                });
            }
        }

        /// <summary>
        /// 挂失
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_AddLose_Click(object sender, EventArgs e)
        {
            //初始化挂失集合
            if (_LossList == null)
            {
                _LossList = new Dictionary<CbCardInfo, int>();
                _LossCountings = new Dictionary<string, CbCardCountingState>();
            }
            if (!p_Loss.Visible)
            {
                p_Loss.Visible = true;
            }
            try
            {
                int index = 0;
                //获取当前行的卡片信息
                CbCardInfo mCardInfo = FormComm.GetDataSourceToClass<CbCardInfo>(dgv_CardList, ref index);
                if (_LossList.Count >= 10)
                {
                    MessageBox.Show("挂失定距卡最多10张，请稍后添加。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (_LossCountings.ContainsKey(mCardInfo.CardNumber))
                {
                    MessageBox.Show($"定距卡:{mCardInfo.CardNumber} 已经添加到挂失列表中，不能重复添加，请重新选择。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                CbCardCountingState mCardCounting = Dbhelper.Db.FirstDefault<CbCardCountingState>(" and UseNumber='" + mCardInfo.CardNumber + "' ");
                _LossList.Add(mCardInfo, index);
                _LossCountings.Add(mCardInfo.CardNumber, mCardCounting);
                dgv_LossList.Rows.Add(new object[] { false, mCardInfo.CardNumber, mCardInfo.UserName });
            }
            catch (Exception ex)
            {
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 更新挂失定距卡在列表中的显示
        /// </summary>
        private void UpdateLossContent()
        {
            try
            {
                foreach (KeyValuePair<CbCardInfo, int> item in _LossList)
                {
                    RemoveDelayUpdate(item.Key.CardNumber);
                    if (dgv_CardList.RowCount > item.Value && dgv_CardList["CardNumber", item.Value].Value.Equals(item.Key.CardNumber))
                    {
                        UpdateLossContent(item.Key, item.Value);
                    }
                    else
                    {
                        for (int i = 0; i < dgv_CardList.RowCount; i++)
                        {
                            if (dgv_CardList["CardNumber", i].Value.Equals(item.Key.CardNumber))
                            {
                                UpdateLossContent(item.Key, item.Value);
                            }
                        }
                    }
                }
            }
            finally
            {
                _LossList = null;
                _LossCountings = null;
            }
        }

        /// <summary>
        /// 更新列表中的显示
        /// </summary>
        /// <param name="minfo"></param>
        /// <param name="index"></param>
        private void UpdateLossContent(CbCardInfo minfo, int index)
        {
            this.Invoke(new EventHandler(delegate
            {
                FormComm.UpdateDgvDataSource<CbCardInfo>(minfo, dgv_CardList, index);
                if (index == dgv_CardList.SelectedRows[0].Index)
                {
                    btn_AddLose.Enabled = false;
                    btn_Delay.Enabled = false;
                }
            }));
        }

        /// <summary>
        /// 锁住
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tsmt_Lockup_Click(object sender, EventArgs e)
        {
            Dictionary<CbCardInfo, int> dicCardInfos = new Dictionary<CbCardInfo, int>();
            for (int i = 0; i < dgv_CardList.RowCount; i++)
            {
                CbCardInfo mInfo = FormComm.GetDataSourceToClass<CbCardInfo>(dgv_CardList, i);
                if (mInfo.ID == 0 || mInfo.CardType > 3 || mInfo.LoseState == 1 || mInfo.Unlocked == 1) continue;
                dicCardInfos.Add(mInfo, i);
            }
            using (DistanceLock_Form lockcard = new DistanceLock_Form(dicCardInfos))
            {
                lockcard.LockChange += CardLockChange;
                lockcard.ShowDialog();
            }
        }

        /// <summary>
        /// 解锁
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tsmt_Unlock_Click(object sender, EventArgs e)
        {
            Dictionary<CbCardInfo, int> mCardInfos = new Dictionary<CbCardInfo, int>();
            for (int i = 0; i < dgv_CardList.RowCount; i++)
            {
                CbCardInfo mInfo = FormComm.GetDataSourceToClass<CbCardInfo>(dgv_CardList, i);
                if (mInfo.ID == 0 || mInfo.CardType > 3 || mInfo.LoseState == 1 || mInfo.Unlocked == 0) continue;
                mCardInfos.Add(mInfo, i);
            }
            using (DistanceUnlock_Form unlock = new DistanceUnlock_Form(mCardInfos))
            {
                unlock.LockChange += CardLockChange;
                unlock.ShowDialog();
            }
        }

        /// <summary>
        /// 锁变化事件
        /// </summary>
        /// <param name="minfo"></param>
        private void CardLockChange(KeyValuePair<CbCardInfo, int> dic)
        {
            //更新列表内容 
            FormComm.UpdateDgvDataSource<CbCardInfo>(dic.Key, dgv_CardList, dic.Value);
        }

        /// <summary>
        /// 延期更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tsmt_DeferredUpdate_Click(object sender, EventArgs e)
        {
            Dictionary<CbCardInfo, int> mCardInfos = new Dictionary<CbCardInfo, int>();
            if (_UpdateDelayList != null && _UpdateDelayList.Count > 0)
            {
                foreach (KeyValuePair<string, int> item in _UpdateDelayList)
                {
                    CbCardInfo mInfo = FormComm.GetDataSourceToClass<CbCardInfo>(dgv_CardList, item.Value);
                    mCardInfos.Add(mInfo, item.Value);
                }
            }
            using (DistanceCardDeferredUpdate_Form update = new DistanceCardDeferredUpdate_Form(mCardInfos))
            {
                update.UpdateChange += Update_UpdateChange;
                update.ShowDialog();
            }
        }

        /// <summary>
        /// 延期更新完成更新列表内容
        /// </summary>
        /// <param name="dic"></param>
        private void Update_UpdateChange(KeyValuePair<CbCardInfo, int> dic)
        {
            RemoveDelayUpdate(dic.Key.CardNumber);
            FormComm.UpdateDgvDataSource<CbCardInfo>(dic.Key, dgv_CardList, dic.Value);
        }

        /// <summary>
        /// 移除延期更新
        /// </summary>
        /// <param name="cardnumber"></param>
        private void RemoveDelayUpdate(string cardnumber)
        {
            if (_UpdateDelayList != null && _UpdateDelayList.Count > 0)
            {
                _UpdateDelayList.Remove(cardnumber);
            }
        }

        /// <summary>
        /// 定距卡注销
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tsmt_Cancellation_Click(object sender, EventArgs e)
        {
            int index = 0;
            try
            {
                //获取注销定距卡
                CbCardInfo mCardInfo = FormComm.GetDataSourceToClass<CbCardInfo>(dgv_CardList, ref index);
                //提示是否挂失
                if (MessageBox.Show("确认是否注销定距卡：" + mCardInfo.CardNumber, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK) return;
                SetControlEnalbed(false);
                dgv_CardList.Enabled = false;
                //获取注销定距卡的计数信息
                CbCardCountingState mCardCounting = Dbhelper.Db.FirstDefault<CbCardCountingState>(" and UseNumber='" + mCardInfo.CardNumber + "' ");
                mCardCounting.UseCounting = DistanceCardHelper.LimitCount(mCardCounting.UseCounting);
                //清空定距卡内的数据
                //string content = string.Format("{0:X4}FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF", mCardCounting.UseCounting);
                //byte[] by = PortAgreement.GetDistanceContent(mCardInfo.CardNumber, 1, content);
                int distancetype = DistanceCardHelper.SetCardTypeByte(new DistanceTypeParameter() { Lock = 1, Distance = mCardInfo.Distance });
                byte[] by = PortAgreement.GetDistanceContent(mCardInfo.CardNumber, distancetype);
                PortHelper.SerialPortWrite(by);
                _eOperating = OperatingType.WriteOff;
                StartTimeOutThread();
            }
            catch (Exception ex)
            {
                SetControlEnalbed(true);
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 打印预览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Print_Click(object sender, EventArgs e)
        {
            new DGVPrinter
            {
                Title = "定距卡信息",
                PageNumbers = true,
                PageNumberInHeader = false,
                PorportionalColumns = true,
                HeaderCellAlignment = StringAlignment.Near,
                FooterSpacing = 15f
            }.PrintDataGridView(dgv_CardList);
        }

        /// <summary>
        /// 显示记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_ShowRecord_Click(object sender, EventArgs e)
        {
            GetRecordCount();
        }

        /// <summary>
        /// 获取搜索条件
        /// </summary>
        /// <returns></returns>
        private string GetSearchWhere()
        {
            string content = tb_SearchContent.Text.Trim();
            StringBuilder sb = new StringBuilder();
            sb.Append(" and CardNumber != '' ");
            if (content.Length > 0)
            {
                sb.AppendFormat(" and ( CardNumber like '%{0}%' or UserName like '%{0}%' or PlateNumber like '%{0}%' or UserPhone like '%{0}%' ) ", content);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 获取记录行
        /// </summary>
        private void GetRecordCount()
        {
            try
            {
                _UpdateDelayList = null;
                string strwhere = GetSearchWhere();
                int count = Dbhelper.Db.GetCount<CbCardInfo>("ID", strwhere);
                PageCount = FormComm.GetPage(count, 30, l_PageTile);
                CurrentPage = 1;
            }
            catch (Exception ex)
            {
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 信息录入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_InformationInput_Click(object sender, EventArgs e)
        {
            using (InformationInput_Form informationinput = new InformationInput_Form())
            {
                informationinput.ShowDialog();
            }
        }

        /// <summary>
        /// 其它操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Other_Click(object sender, EventArgs e)
        {
            cms_Other.Show(btn_Other, new Point(0, btn_Other.Height));
        }

        /// <summary>
        /// 延期
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Delay_Click(object sender, EventArgs e)
        {
            int index = 0;
            CbCardInfo mCardInfo = FormComm.GetDataSourceToClass<CbCardInfo>(dgv_CardList, ref index);
            if (mCardInfo.CardType == 0)
            {
                using (DelayParam_Form delay = new DelayParam_Form(mCardInfo))
                {
                    if (delay.ShowDialog() != DialogResult.OK) return;
                    mCardInfo = delay.Tag as CbCardInfo;
                }
            }
            else
            {
                using (DistanceDelay_Form delay = new DistanceDelay_Form(mCardInfo))
                {
                    if (delay.ShowDialog() != DialogResult.OK) return;
                    mCardInfo = delay.Tag as CbCardInfo;
                }
            }
            FormComm.UpdateDgvDataSource<CbCardInfo>(mCardInfo, dgv_CardList, index);
        }

        /// <summary>
        /// 定距卡发行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Issue_Click(object sender, EventArgs e)
        {
            int index = 0;
            bool isloss;
            CbCardInfo mCardInfo = FormComm.GetDataSourceToClass<CbCardInfo>(dgv_CardList, ref index);
            isloss = mCardInfo.LoseState == 1 || mCardInfo.UseState == 0;
            using (DistanceCardIssue_Form issue = new DistanceCardIssue_Form(mCardInfo))
            {
                issue.ShowDialog();
                if (issue.Tag == null) return;
                mCardInfo = issue.Tag as CbCardInfo;
                RemoveDelayUpdate(mCardInfo.CardNumber);
                FormComm.UpdateDgvDataSource<CbCardInfo>(mCardInfo, dgv_CardList, index);
                if (isloss)
                {
                    dgv_CardList.Rows[index].DefaultCellStyle.ForeColor = Color.Black;
                    btn_Delay.Enabled = true;
                    btn_AddLose.Enabled = true;
                    tsmt_Cancellation.Enabled = true;
                }
            }
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Refresh_Click(object sender, EventArgs e)
        {
            //清空列表
            DataTable dt = dgv_CardList.DataSource as DataTable;
            if (dt != null)
                dt.Rows.Clear();

            SetControlEnalbed(false);

            //不启用分布操作
            btn_FirstPage.Enabled = false;
            btn_PreviousPage.Enabled = false;
            tb_Page.Enabled = false;
            btn_NextPage.Enabled = false;
            btn_LastPage.Enabled = false;

            SubList = new Dictionary<string, ViceCardParam>();
            _HostsList = new List<string>();
            _UpdateDelayList = new Dictionary<string, int>();
            _eOperating = OperatingType.None;

            try
            {
                byte[] by = PortAgreement.GetReadAllCard();
                PortHelper.SerialPortWrite(by);
                StartTimeOutThread();
            }
            catch (Exception ex)
            {
                btn_Refresh.Enabled = true;
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 设置控件启用或不启用
        /// </summary>
        /// <param name="connectionstate"></param>
        private void SetControlEnalbed(bool connectionstate)
        {
            btn_Refresh.Enabled = connectionstate;
            if (!dgv_CardList.Enabled) dgv_CardList.Enabled = true;
            if (connectionstate)
            {
                if (dgv_CardList.RowCount > 0)
                {
                    int index = 0;
                    //获取当前行的数据
                    CbCardInfo mCardInfo = FormComm.GetDataSourceToClass<CbCardInfo>(dgv_CardList, ref index);
                    if (mCardInfo.ID > 0)
                    {
                        bool flag = mCardInfo.CardType < 3 ? mCardInfo.LoseState == 0 : false;
                        //挂失
                        btn_AddLose.Enabled = Dal_ManageRights.ManageRights.CardOperationLoss ? flag : false;
                        //延期
                        btn_Delay.Enabled = Dal_ManageRights.ManageRights.CardOperationDelay ? flag : false;
                        //注销
                        tsmt_Cancellation.Enabled = Dal_ManageRights.ManageRights.CardOperationLog ? flag : false;
                    }
                    else
                    {
                        btn_Delay.Enabled = false;
                        btn_AddLose.Enabled = false;
                        tsmt_Cancellation.Enabled = false;
                    }
                    //发行
                    btn_Issue.Enabled = Dal_ManageRights.ManageRights.CardOperationIssue ? mCardInfo.CardType < 3 : false;
                }

                //延期更新
                tsmt_DeferredUpdate.Enabled = Dal_ManageRights.ManageRights.CardOperationDeferredUpdate;
                //解锁
                tsmt_Unlock.Enabled = Dal_ManageRights.ManageRights.CardOperationUnlock;
                //锁住
                tsmt_Lockup.Enabled = Dal_ManageRights.ManageRights.CardOperationLock;

                if (p_Loss.Visible)
                {
                    if (dgv_LossList.RowCount > 0)
                    {
                        btn_Enter.Enabled = true;//确认挂失
                        cb_AllSelected.Enabled = true;//挂失全选
                    }
                    btn_Remove.Enabled = cb_AllSelected.CheckState != CheckState.Unchecked;//移除挂失
                }
            }
            else
            {
                btn_Issue.Enabled = false;//发行
                btn_Delay.Enabled = false;//延期
                btn_AddLose.Enabled = false;//添加挂失
                tsmt_Cancellation.Enabled = false;//注册
                tsmt_DeferredUpdate.Enabled = false;//延期更新
                tsmt_Unlock.Enabled = false;//锁住
                tsmt_Lockup.Enabled = false;//解锁
                if (p_Loss.Visible)
                {
                    btn_Enter.Enabled = false; //确认挂失
                }
            }
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
        /// 创建超时线程
        /// </summary>
        private void StartTimeOutThread()
        {
            StopTimeOutThread();
            _tTimeOutThread = new Thread(TimeOutWait);
            _tTimeOutThread.IsBackground = true;
            _tTimeOutThread.Start();
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
                    SetControlEnalbed(PortHelper.IsConnection);
                }));
            }
            finally
            {
                _tTimeOutThread = null;
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
                 if (param.FunctionAddress == 65)
                 {
                     DistanceParameter distanceparam = DataParsing.DistanceParsingContent(param.DataContent);
                     switch (distanceparam.Command)
                     {
                         case 10://读取定距内容
                             try
                             {
                                 StopTimeOutThread();
                                 if (distanceparam.AuxiliaryCommand != 8)
                                 {
                                     if (distanceparam.TypeParameter.CardType == CardTypes.ViceCard) //定距卡类型为副卡
                                     {
                                         if (!SubList.ContainsKey(distanceparam.CardNumber))//判断是否已经读取到副卡
                                         {
                                             //解析数据内容
                                             DistanceDataParameter distancedata = DataParsing.DistanceData(param.DataContent);
                                             //组合副卡参数
                                             ViceCardParam vicecardparam = new ViceCardParam()
                                             {
                                                 ViceCardNumber = distanceparam.CardNumber,//副卡卡号
                                                 LockState = distanceparam.TypeParameter.Lock,//解锁状态
                                                 Count = distancedata.Count //计数字节
                                             };
                                             //添加到副卡集合中
                                             SubList.Add(distanceparam.CardNumber, vicecardparam);
                                         }
                                     }
                                     else //主卡
                                     {
                                         if (!_HostsList.Contains(distanceparam.CardNumber))//判断是否已经读取到
                                         {
                                             //获取副卡信息
                                             CbCardInfo mCardInfo = Dbhelper.Db.FirstDefault<CbCardInfo>(string.Format(" and CardNumber ='{0}' ", distanceparam.CardNumber));
                                             if (mCardInfo != null)
                                             {
                                                 if (distanceparam.TypeParameter.CardType < CardTypes.ViceCard)
                                                 {
                                                     DistanceDataParameter distancedata = DataParsing.DistanceData(param.DataContent);
                                                     if (mCardInfo.LoseState == 0)
                                                         mCardInfo.LoseState = distancedata.FunctionByteParameter.Loss;//挂失
                                                                                                                       //停车限制
                                                     mCardInfo.ParkingRestrictions = distancedata.FunctionByteParameter.ParkingRestrictions;
                                                     //注册类型
                                                     distanceparam.TypeParameter.CardType = distancedata.FunctionByteParameter.RegistrationType;
                                                     if (mCardInfo.CardType > 0 && mCardInfo.LoseState == 0)
                                                     {
                                                         int count = Dbhelper.Db.GetCount<CbAssociateCard>("ID", " and CardID=" + mCardInfo.ID + " and UseState = 1 ");
                                                         if (count > 0)
                                                         {
                                                             _UpdateDelayList.Add(distanceparam.CardNumber, dgv_CardList.RowCount);
                                                         }
                                                     }
                                                 }
                                             }
                                             else
                                             {
                                                 mCardInfo = new CbCardInfo();
                                                 mCardInfo.UserSex = -1;
                                             }
                                             mCardInfo.CardNumber = distanceparam.CardNumber;
                                             mCardInfo.Electricity = distanceparam.TypeParameter.Battry;//电量
                                             mCardInfo.Distance = distanceparam.TypeParameter.Distance;//距离
                                             mCardInfo.CardType = (int)distanceparam.TypeParameter.CardType;//类型
                                             mCardInfo.Unlocked = distanceparam.TypeParameter.Lock;//解锁状态
                                             _HostsList.Add(mCardInfo.CardNumber);
                                             FormComm.AddDgvSource<CbCardInfo>(mCardInfo, dgv_CardList);

                                             StartTimeOutThread();
                                         }
                                     }
                                 }
                                 else //结束
                                 {
                                     SetControlEnalbed(true);
                                     l_PageTile.Text = $"总共 {dgv_CardList.RowCount} 条记录";
                                 }
                             }
                             catch (Exception ex)
                             {
                                 SetControlEnalbed(true);
                                 CustomExceptionHandler.GetExceptionMessage(ex);
                                 MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                             }
                             break;
                         case 27:
                             if (_eOperating == OperatingType.WriteOff)
                             {
                                 try
                                 {
                                     StopTimeOutThread();

                                     //注销
                                     if (distanceparam.AuxiliaryCommand == 0)
                                     {
                                         int index = 0;
                                         CbCardInfo mCardInfo = FormComm.GetDataSourceToClass<CbCardInfo>(dgv_CardList, ref index);
                                         if (mCardInfo.CardType != 0)
                                         {
                                             //组合卡或车牌识别卡删除副卡的数据
                                             Dbhelper.Db.Del<CbAssociateCard>(" and CardID=" + mCardInfo.ID + " ");
                                         }
                                         //删除注销的定距卡计数数据
                                         Dbhelper.Db.Del<CbCardCountingState>(" and UseNumber='" + mCardInfo.CardNumber + "' ");
                                         //删除注销的定距卡数据
                                         Dbhelper.Db.Del<CbCardInfo>(mCardInfo.ID);
                                         //移除延期更新
                                         RemoveDelayUpdate(mCardInfo.CardNumber);
                                         //移除注销的定距卡
                                         DataTable dt = dgv_CardList.DataSource as DataTable;
                                         if (dt == null) return;
                                         dt.Rows.RemoveAt(index);
                                     }
                                     else
                                     {
                                         throw new Exception("定距卡注销失败，请将定距卡放置在发行器可读写区域内。");
                                     }
                                 }
                                 catch (Exception ex)
                                 {
                                     CustomExceptionHandler.GetExceptionMessage(ex);
                                     MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                 }
                                 finally
                                 {
                                     _eOperating = OperatingType.None;
                                     SetControlEnalbed(true);
                                 }
                             }
                             else if (_eOperating == OperatingType.Loss) //挂失操作
                             {
                                 try
                                 {
                                     StopTimeOutThread();
                                     if (distanceparam.AuxiliaryCommand == 0)
                                     {
                                         CbCardInfo[] mCardInfos = new CbCardInfo[_LossList.Count];
                                         _LossList.Keys.CopyTo(mCardInfos, 0);
                                         CbCardCountingState[] mCardCounting = new CbCardCountingState[_LossList.Count];
                                         _LossCountings.Values.CopyTo(mCardCounting, 0);
                                         //更新挂失的定距卡数据库内容
                                         Dbhelper.Db.Update<CbCardInfo>(mCardInfos);
                                         //更新挂失的定距卡计数
                                         Dbhelper.Db.Update<CbCardCountingState>(mCardCounting);
                                         //清空挂失DGV列表
                                         dgv_LossList.Rows.Clear();
                                         p_Loss.Visible = false;
                                         //更新挂失的定距卡在列表中的显示
                                         Thread tUpdateLossContent = new Thread(UpdateLossContent);
                                         tUpdateLossContent.IsBackground = true;
                                         tUpdateLossContent.Start();
                                         MessageBox.Show("定距卡挂失成功，确保每一个读卡器都提示“挂失成功”，解挂定距卡重新发行即可。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                     }
                                     else
                                     {
                                         throw new Exception("定距卡挂失失败，请将挂失卡放置在发行器可读写区域内。");
                                     }
                                 }
                                 catch (Exception ex)
                                 {
                                     CustomExceptionHandler.GetExceptionMessage(ex);
                                     MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                 }
                                 finally
                                 {
                                     _eOperating = OperatingType.None;
                                     SetControlEnalbed(true);
                                 }
                             }
                             break;
                     }
                 }
             }));
        }

        /// <summary>
        /// 端口变化事件
        /// </summary>
        /// <param name="flag"></param>
        private void DeviceConnectionChange(bool flag)
        {
            this.BeginInvoke(new EventHandler(delegate
            {
                SetControlEnalbed(flag);
            }));
        }

        /// <summary>
        /// 定距卡列表鼠标单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dgv_CardList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (btn_Refresh.Enabled)
                    SetControlEnalbed(PortHelper.IsConnection);
            }
        }

        /// <summary>
        /// 定距卡列表移除行事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dgv_CardList_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dgv_CardList.RowCount == 0)
            {
                btn_Issue.Enabled = false;//发行
                btn_Delay.Enabled = false;//延期
                btn_AddLose.Enabled = false;//添加挂失
                tsmt_Cancellation.Enabled = false;//注销
            }
        }

        /// <summary>
        /// 定距卡列表单元格格式发生变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dgv_CardList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            switch (dgv_CardList.Columns[e.ColumnIndex].Name)
            {
                case "CardType":
                    int cardtype = Utils.ObjToInt(e.Value, 0);
                    switch (cardtype)
                    {
                        case 0:
                            e.Value = "单卡";
                            break;
                        case 1:
                            e.Value = "组合卡";
                            break;
                        case 2:
                            e.Value = "车牌识别卡";
                            break;
                        case 3:
                            e.Value = "副卡";
                            break;
                        case 8:
                            e.Value = "挂失卡";
                            dgv_CardList.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Red;
                            dgv_CardList.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Gray;
                            break;
                        case 15:
                            e.Value = "密码错误";
                            dgv_CardList.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                            break;
                    }
                    break;
                case "Distance":
                    int distance = Utils.ObjToInt(e.Value, 0);
                    switch (distance)
                    {
                        case 0:
                            e.Value = "1.2 米";
                            break;
                        case 1:
                            e.Value = "2.5 米";
                            break;
                        case 2:
                            e.Value = "3.8 米";
                            break;
                        case 3:
                            e.Value = "5 米";
                            break;
                        case 4:
                            e.Value = "距离由主机设定";
                            break;
                    }
                    break;
                case "Unlocked":
                    e.Value = e.Value.Equals(0) ? "已解锁" : "未解锁";
                    break;
                case "LoseState":
                    if (e.Value.Equals(0))
                    {
                        e.Value = "未挂失";
                    }
                    else
                    {
                        e.Value = "已挂失";
                        if (dgv_CardList.Rows[e.RowIndex].DefaultCellStyle.ForeColor != Color.Red)
                            dgv_CardList.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Gray;
                    }
                    break;
                case "UseState":
                    e.Value = e.Value.Equals(0) ? "未使用" : "已使用";
                    break;
                case "FieldPartition":
                    int partition = Utils.ObjToInt(e.Value, 0);
                    if (partition > 0)
                    {
                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < 16; i++)
                        {
                            int result = BinaryHelper.GetIntegerSomeBit(partition, i);
                            if (result == 1)
                            {
                                sb.AppendFormat("分区 {0} ", i + 1);
                            }
                        }
                        e.Value = sb.ToString();
                    }
                    else
                    {
                        e.Value = "关闭";
                    }
                    break;
                case "ParkingRestrictions":
                    e.Value = e.Value.Equals(0) ? "关闭" : "开启";
                    break;
                case "Electricity":
                    e.Value = e.Value.Equals(0) ? "电量正常" : "电量低";
                    break;
                case "UserSex":
                    if (e.Value.Equals(0))
                    {
                        e.Value = "男";
                    }
                    else if (e.Value.Equals(1))
                    {
                        e.Value = "女";
                    }
                    else
                    {
                        e.Value = "未选择";
                    }
                    break;
            }
        }

        /// <summary>
        /// 定距卡列表绘制单元格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dgv_CardList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (dgv_CardList.Columns["StopTime"].Index == e.ColumnIndex && e.RowIndex >= 0)
            {
                if (_UpdateDelayList == null) return;
                if (_UpdateDelayList.Count == 0) return;
                if (_UpdateDelayList.ContainsValue(e.RowIndex))
                {
                    e.Paint(e.ClipBounds, e.PaintParts);
                    e.Graphics.DrawImage(Properties.Resources.Update, new Point(e.CellBounds.X + (e.CellBounds.Width - 25), e.CellBounds.Y + (e.CellBounds.Height - 16) / 2));
                    e.Handled = true;
                }
            }
        }

        /// <summary>
        /// 定距卡列表鼠标进行时的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dgv_CardList_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_CardList.Columns["StopTime"].Index == e.ColumnIndex && e.RowIndex >= 0)
            {
                if (_UpdateDelayList == null) return;
                if (_UpdateDelayList.Count == 0) return;
                if (_UpdateDelayList.ContainsValue(e.RowIndex))
                {
                    dgv_CardList.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "副卡时间需进行更新";
                }
            }
        }

        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Search_Click(object sender, EventArgs e)
        {
            GetRecordCount();
        }

        /// <summary>
        /// 搜索内容键盘按下释放事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tb_SearchContent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Btn_Search_Click(null, null);
            }
        }

        /// <summary>
        /// 搜索内容文本变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tb_SearchContent_TextChanged(object sender, EventArgs e)
        {
            l_SearchTitle.Visible = tb_SearchContent.TextLength == 0;
        }

        /// <summary>
        /// 搜索内容标题鼠标按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void L_SearchTitle_MouseDown(object sender, MouseEventArgs e)
        {
            tb_SearchContent.Focus();
        }

        /// <summary>
        /// 底容器重事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void P_Bottom_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                g.DrawLine(new Pen(dgv_CardList.GridColor, 1), 0, 0, p_Bottom.Width, 0);
            }
        }

        /// <summary>
        /// 最后一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_LastPage_Click(object sender, EventArgs e)
        {
            CurrentPage = PageCount;
        }

        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_NextPage_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
        }

        /// <summary>
        /// 页数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tb_Page_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                int page = 1;
                string content = tb_Page.Text.Trim();
                if (content.Length > 0)
                {
                    page = Convert.ToInt32(content);
                    if (page < 1)
                        page = 1;
                    else if (page > PageCount)
                        page = PageCount;
                }
                CurrentPage = page;
            }
            e.Handled = LimitInput.InputNumber(e.KeyChar);
        }

        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_PreviousPage_Click(object sender, EventArgs e)
        {
            CurrentPage -= 1;
        }

        /// <summary>
        /// 第一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_FirstPage_Click(object sender, EventArgs e)
        {
            CurrentPage = 1;
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tab3_Form_Load(object sender, EventArgs e)
        {
            //初始化端口接收
            PortHelper.ConnectionChange += DeviceConnectionChange;
            //初始化端口变化事件
            PortHelper.DataReceived += SerialPortDataReceived;

            SetControlEnalbed(PortHelper.IsConnection);
        }

        /// <summary>
        /// 窗体获取焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tab3_Form_Activated(object sender, EventArgs e)
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
        /// 窗体关闭后事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tab3_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            _uniqueInstance = null;
        }

        private static Tab3_Form _uniqueInstance;

        /// <summary>
        /// 窗体单例模式
        /// </summary>
        public static Tab3_Form GetInstance
        {
            get { return _uniqueInstance ?? (_uniqueInstance = new Tab3_Form()); }
        }

    }

    public class ViceCardParam
    {
        public string ViceCardNumber { get; set; }

        public int LockState { get; set; }

        public int Count { get; set; }
    }
}
