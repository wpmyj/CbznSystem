using System.Threading;
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
using System.Drawing.Drawing2D;

namespace CbznSystem
{
    public partial class DistanceDelay_Form : NewForm
    {
        private int _mouseEnterIndex = -1;
        private bool _isDown;

        /// <summary>
        /// 定距卡
        /// </summary>
        private CbCardInfo _mCardInfo;
        /// <summary>
        /// 定距卡计数信息
        /// </summary>
        private CbCardCountingState _mCardCounting;
        /// <summary>
        /// 副卡计数信息
        /// </summary>
        private List<CbCardCountingState> _mViceCardCounting;
        /// <summary>
        /// 副卡信息
        /// </summary>
        private List<CbAssociateCard> _mViceCard;
        /// <summary>
        /// 超时线程
        /// </summary>
        private Thread _tTimeOutThread;

        public DistanceDelay_Form(CbCardInfo mcardinfo)
        {
            InitializeComponent();

            _mCardInfo = mcardinfo;

            this.Load += DistanceDelay_Form_Load;
            this.FormClosing += DistanceDelay_Form_FormClosing;

            cb_AllSelected.CheckedChanged += Cb_AllSelected_CheckedChanged;
            cb_AllSelected.MouseDown += Cb_AllSelected_MouseDown;

            dgv_DataList.CellPainting += Dgv_DataList_CellPainting;
            dgv_DataList.CellMouseEnter += Dgv_DataList_CellMouseEnter;
            dgv_DataList.CellMouseLeave += Dgv_DataList_CellMouseLeave;
            dgv_DataList.CellMouseDown += Dgv_DataList_CellMouseDown;
            dgv_DataList.CellMouseUp += Dgv_DataList_CellMouseUp;
            dgv_DataList.CellContentClick += Dgv_DataList_CellContentClick;
            dgv_DataList.Paint += Dgv_DataList_Paint;
            dgv_DataList.CellValueChanged += Dgv_DataList_CellValueChanged;
            dgv_DataList.CurrentCellDirtyStateChanged += Dgv_DataList_CurrentCellDirtyStateChanged;
            dgv_DataList.RowsAdded += Dgv_DataList_RowsAdded;
            dgv_DataList.CellFormatting += Dgv_DataList_CellFormatting;
            dgv_DataList.AutoGenerateColumns = false;

            btn_Delays.Click += Btn_Delays_Click;
            btn_Delays.Paint += FormComm.DrawBtnEnabled;
            btn_Enter.Click += Btn_Enter_Click;
            btn_Enter.Paint += FormComm.DrawBtnEnabled;

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
        /// DGV 单元格格式发生变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dgv_DataList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            switch (dgv_DataList.Columns[e.ColumnIndex].Name)
            {
                case "UseState":
                    int index = Utils.ObjToInt(e.Value, 0);
                    switch (index)
                    {
                        case 1:
                            e.Value = "更新";
                            break;
                        case 3:
                            e.Value = "延期";
                            break;
                        default:
                            e.Value = string.Empty;
                            break;
                    }
                    break;
                case "SubCardDivision":
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
            }
        }

        /// <summary>
        /// DGV 添加行事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dgv_DataList_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            btn_Enter.Enabled = PortHelper.IsConnection;
        }

        /// <summary>
        /// 窗体关闭前事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DistanceDelay_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            //释放端口接收事件
            PortHelper.DataReceived -= SerialPortDataReceived;
            //释放端口连接发生变化事件
            PortHelper.ConnectionChange -= DeviceConnectionChange;
        }

        /// <summary>
        /// 确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Enter_Click(object sender, EventArgs e)
        {
            btn_Enter.Enabled = false;
            byte[] by = null;
            try
            {
                if (_mCardCounting == null)
                {
                    //获取主卡计数数据
                    _mCardCounting = Dbhelper.Db.FirstDefault<CbCardCountingState>(string.Format(" and UseNumber='{0}' ", _mCardInfo.CardNumber));
                    //当前计数+1
                    _mCardCounting.UseCounting = DistanceCardHelper.LimitCount(_mCardCounting.UseCounting);
                }
                //获取副卡集合
                _mViceCard = new List<CbAssociateCard>();
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < dgv_DataList.RowCount; i++)
                {
                    CbAssociateCard mvicecard = FormComm.GetDataSourceToClass<CbAssociateCard>(dgv_DataList, i);
                    _mViceCard.Add(mvicecard);
                    sb.AppendFormat(" UseNumber='{0}' or", mvicecard.AssociateCardNumber);
                }
                if (sb.Length > 0)
                {
                    sb = sb.Remove(sb.Length - 2, 2);
                }

                if (_mViceCardCounting == null && _mCardInfo.CardType == (int)CardTypes.CombinationCard)
                {
                    //获取副卡的计数数据
                    _mViceCardCounting = Dbhelper.Db.ToList<CbCardCountingState>(string.Format(" and ({0}) ", sb.ToString()));
                    List<CombinationCardViceCardDataParam> ViceCardParams = new List<CombinationCardViceCardDataParam>();
                    foreach (CbCardCountingState item in _mViceCardCounting)
                    {
                        //副卡计数+1
                        item.UseCounting = DistanceCardHelper.LimitCount(item.UseCounting);
                        //获取副卡
                        CbAssociateCard vicecard = GetViceCard(item.UseNumber);
                        ViceCardParams.Add(new CombinationCardViceCardDataParam()
                        {
                            ViceCardCount = item.UseCounting,
                            ViceCardNumber = item.UseNumber,
                            ViceCardPartition = vicecard.SubCardDivision,
                            ViceCardTime = vicecard.UpdateTime
                        });
                    }
                    by = DistanceCardHelper.SetDistanceData(_mCardInfo.CardNumber, _mCardCounting.UseCounting, ViceCardParams);
                }
                else //车牌识别卡
                {
                    List<LprCardViceCardParam> ViceCardParams = new List<LprCardViceCardParam>();
                    foreach (CbAssociateCard item in _mViceCard)
                    {
                        ViceCardParams.Add(new LprCardViceCardParam()
                        {
                            PlateNumber = item.AssociateCardNumber,
                            ViceCardPartition = item.SubCardDivision,
                            ViceCardTime = item.UpdateTime
                        });
                    }
                    by = DistanceCardHelper.SetDistanceData(_mCardInfo.CardNumber, _mCardCounting.UseCounting, ViceCardParams);
                }
                PortHelper.SerialPortWrite(by);
                StartTimeOutThread();
            }
            catch (Exception ex)
            {
                btn_Enter.Enabled = true;
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 开始超时线程
        /// </summary>
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
        /// 批量延期
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Delays_Click(object sender, EventArgs e)
        {
            //获取选择批量延期的副卡
            List<CbAssociateCard> mAssociateCards = new List<CbAssociateCard>();
            for (int i = 0; i < dgv_DataList.RowCount; i++)
            {
                bool flag = Utils.StrToBool(dgv_DataList["c_Selected", i].Value, false);
                if (!flag) continue;
                CbAssociateCard mAssociateCard = FormComm.GetDataSourceToClass<CbAssociateCard>(dgv_DataList, i);
                mAssociateCards.Add(mAssociateCard);
            }
            using (DelayParam_Form delayparam = new DelayParam_Form(mAssociateCards))
            {
                if (delayparam.ShowDialog() != DialogResult.OK) return;
                mAssociateCards = delayparam.Tag as List<CbAssociateCard>;
                //延期后的时间和车牌分区显示在列表中
                foreach (CbAssociateCard item in mAssociateCards)
                {
                    for (int i = 0; i < dgv_DataList.RowCount; i++)
                    {
                        if (dgv_DataList["AssociateCardNumber", i].Value.Equals(item.AssociateCardNumber))
                        {
                            if (item.AssociateCardTime.Date != item.UpdateTime.Date)
                            {
                                item.UseState = 3;
                            }
                            //更新列表中的显示
                            FormComm.UpdateDgvDataSource<CbAssociateCard>(item, dgv_DataList, i);
                            break;
                        }
                    }
                }
            }
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
            for (int i = 0; i < dgv_DataList.RowCount; i++)
            {
                dgv_DataList["c_Selected", i].Value = cb_AllSelected.Checked;
            }
            if (dgv_DataList.RowCount > 0)
                btn_Delays.Enabled = cb_AllSelected.Checked;
            cb_AllSelected.Tag = null;
        }

        /// <summary>
        /// DGV 单元格状态因其内容更改而更改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dgv_DataList_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgv_DataList.IsCurrentCellDirty)
            {
                dgv_DataList.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        /// <summary>
        /// DGV 单元格内容变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dgv_DataList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (cb_AllSelected.Tag != null) return;
            if (dgv_DataList.Columns[e.ColumnIndex].Name == "c_Selected")
            {
                int count = 0;
                for (int i = 0; i < dgv_DataList.RowCount; i++)
                {
                    bool flag = Utils.StrToBool(dgv_DataList["c_Selected", i].Value, false);
                    if (flag)
                        count++;
                }
                cb_AllSelected.ThreeState = true;
                if (count == 0)
                    cb_AllSelected.CheckState = CheckState.Unchecked;
                else if (count == dgv_DataList.RowCount)
                    cb_AllSelected.CheckState = CheckState.Checked;
                else
                    cb_AllSelected.CheckState = CheckState.Indeterminate;
                btn_Delays.Enabled = count > 0;
            }
        }

        /// <summary>
        /// DGV 重绘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dgv_DataList_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                g.DrawLine(new Pen(Brushes.Gray), 0, dgv_DataList.Height - 1, dgv_DataList.Width - 1, dgv_DataList.Height - 1);
            }
        }

        /// <summary>
        /// DGV 单击单元格内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dgv_DataList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (!(dgv_DataList.Columns[e.ColumnIndex] is DataGridViewButtonColumn)) return;
            int index = 0;
            CbAssociateCard mAssociateCard = FormComm.GetDataSourceToClass<CbAssociateCard>(dgv_DataList, ref index);
            //单个延期
            using (DelayParam_Form delayparam = new DelayParam_Form(mAssociateCard))
            {
                if (delayparam.ShowDialog() != DialogResult.OK) return;
                mAssociateCard = delayparam.Tag as CbAssociateCard;
                if (mAssociateCard.AssociateCardTime.Date != mAssociateCard.UpdateTime.Date)
                {
                    mAssociateCard.UseState = 3;
                }
                //更新列表中的显示
                FormComm.UpdateDgvDataSource<CbAssociateCard>(mAssociateCard, dgv_DataList, index);
            }
        }

        /// <summary>
        /// DGV 单元格鼠标弹起
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dgv_DataList_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_isDown)
                _isDown = false;
        }

        /// <summary>
        /// DGV 单元格鼠标按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dgv_DataList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || dgv_DataList.Columns[e.ColumnIndex].Name != "c_Btn") return;
            if (_mouseEnterIndex == e.RowIndex)
                _isDown = true;
        }

        /// <summary>
        /// DGV 单元格鼠标移出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dgv_DataList_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgv_DataList.Columns[e.ColumnIndex].Name != "c_Btn") return;
            _mouseEnterIndex = -1;
            Rectangle rect = GetCellRectangle(e.RowIndex, e.ColumnIndex);
            dgv_DataList.Invalidate(rect);
        }

        /// <summary>
        /// DGV 单元格鼠标移入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dgv_DataList_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgv_DataList.Columns[e.ColumnIndex].Name != "c_Btn") return;
            _mouseEnterIndex = e.RowIndex;
            Rectangle rect = GetCellRectangle(e.RowIndex, e.ColumnIndex);
            dgv_DataList.Invalidate(rect);
        }

        /// <summary>
        /// DGV 需要绘制单元格时发生的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dgv_DataList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (!(dgv_DataList.Columns[e.ColumnIndex] is DataGridViewButtonColumn)) return;
            Graphics g = e.Graphics;
            e.PaintBackground(e.CellBounds, true);
            Color background = Color.White;
            Color forecolor = dgv_DataList.DefaultCellStyle.ForeColor;
            Color bordercolor = Color.Gray;
            if (dgv_DataList.Enabled)
            {
                if (e.RowIndex == _mouseEnterIndex && _isDown)
                {
                    background = Color.FromArgb(240, 88, 35);
                    forecolor = Color.White;
                    bordercolor = background;
                }
                else if (e.RowIndex == _mouseEnterIndex)
                {
                    background = Color.FromArgb(255, 106, 49);
                    bordercolor = background;
                    forecolor = Color.White;
                }
            }
            else
            {
                background = Color.Gray;
                forecolor = Color.White;
                bordercolor = Color.Gray;
            }
            DrawButton(g, e.CellBounds, background, forecolor, bordercolor);
            e.Handled = true;
        }

        /// <summary>
        /// 在DGV中绘制Button按钮
        /// </summary>
        /// <param name="g"></param>
        /// <param name="rect"></param>
        /// <param name="background"></param>
        /// <param name="forecolor"></param>
        /// <param name="linecolor"></param>
        private void DrawButton(Graphics g, Rectangle rect, Color background, Color forecolor, Color linecolor)
        {
            DataGridViewButtonColumn buttoncolumn = dgv_DataList.Columns["c_Btn"] as DataGridViewButtonColumn;
            StringFormat sf = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rect.X + 5, rect.Y + 3, 10, 10, 180, 90);
            path.AddArc(rect.Right - 15, rect.Y + 3, 10, 10, 270, 90);
            path.AddArc(rect.Right - 15, rect.Bottom - 15, 10, 10, 360, 90);
            path.AddArc(rect.X + 5, rect.Bottom - 15, 10, 10, 90, 90);
            path.AddLine(rect.X + 5, rect.Y + 8, rect.X + 5, rect.Bottom - 15);
            g.FillPath(new SolidBrush(background), path);
            g.DrawPath(new Pen(new SolidBrush(linecolor), 1), path);
            g.DrawString(buttoncolumn.Text, dgv_DataList.DefaultCellStyle.Font, new SolidBrush(forecolor), rect, sf);
        }

        /// <summary>
        /// 获取单元的边框
        /// </summary>
        /// <param name="rowindex"></param>
        /// <param name="columnindex"></param>
        /// <returns></returns>
        private Rectangle GetCellRectangle(int rowindex, int columnindex)
        {
            Rectangle rect = dgv_DataList.GetCellDisplayRectangle(columnindex, rowindex, true);
            return rect;
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DistanceDelay_Form_Load(object sender, EventArgs e)
        {
            //初始化端口接收事件
            PortHelper.DataReceived += SerialPortDataReceived;
            //初始化端口变化事件
            PortHelper.ConnectionChange += DeviceConnectionChange;
            PortHelper.CurrentForm = this;
            try
            {
                //获取副卡集合
                DataTable dt = Dbhelper.Db.ToTable<CbAssociateCard>(" and  CardID=" + _mCardInfo.ID + " ");
                dgv_DataList.DataSource = dt;
                dgv_DataList.Focus();

                if (_mCardInfo.ParkingRestrictions == 1)
                {
                    cb_AllSelected.Checked = true;
                    cb_AllSelected.Enabled = false;
                    dgv_DataList.Enabled = false;
                    l_Message.Visible = true;
                }

            }
            catch (Exception ex)
            {
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 端口连接发生变化事件
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
                    StopTimeOutThread();

                    //解析数据内容
                    DistanceParameter distanceparam = DataParsing.DistanceParsingContent(param.DataContent);
                    if (distanceparam.Command == 27)//写入定距卡
                    {
                        if (distanceparam.AuxiliaryCommand == 0)//成功
                        {
                            StringBuilder sb = new StringBuilder();
                            StringBuilder sbRecordContent = new StringBuilder();
                            DateTime maxtime = DateTime.MinValue;
                            foreach (CbAssociateCard vicecarditem in _mViceCard)
                            {
                                if (vicecarditem.UseState == 3 && vicecarditem.AssociateCardTime.Date != vicecarditem.UpdateTime.Date)
                                {
                                    sb.AppendFormat(" update CBAssociateCard set UpdateTime='{0:yyyy-MM-dd}',UseState={1} where id!={2} and AssociateCardNumber='{3}' ; ", vicecarditem.UpdateTime, 1, vicecarditem.ID, vicecarditem.AssociateCardNumber);
                                    sbRecordContent.AppendFormat(" 副卡编号:{0} 时间:{1} 延期时间:{2} ", vicecarditem.AssociateCardNumber, vicecarditem.AssociateCardTime, vicecarditem.UpdateTime);
                                }
                                vicecarditem.AssociateCardTime = vicecarditem.UpdateTime;
                                vicecarditem.UseState = 0;
                                if (vicecarditem.AssociateCardTime > maxtime)
                                    maxtime = vicecarditem.AssociateCardTime;
                            }

                            if (sb.Length > 0)
                            {
                                //更新当前副卡的所有时间
                                Dbhelper.Db.ExecuteNonQuery(sb.ToString());
                            }

                            //更新副卡数据
                            Dbhelper.Db.Update<CbAssociateCard>(_mViceCard.ToArray());
                            if (_mViceCardCounting != null)
                            {
                                _mViceCardCounting.Add(_mCardCounting);
                                //更新计数数据
                                Dbhelper.Db.Update<CbCardCountingState>(_mViceCardCounting.ToArray());
                            }
                            else
                            {
                                //更新主卡计数数据
                                Dbhelper.Db.Update<CbCardCountingState>(_mCardCounting);
                            }
                            if (_mCardInfo.StopTime.Date != maxtime.Date)
                            {
                                _mCardInfo.StopTime = maxtime;
                                //更新主卡数据
                                Dbhelper.Db.Update<CbCardInfo>(_mCardInfo);
                            }
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
        /// 获取副卡
        /// </summary>
        /// <param name="cardnumber"></param>
        /// <returns></returns>
        private CbAssociateCard GetViceCard(string cardnumber)
        {
            CbAssociateCard vicecard = null;
            foreach (CbAssociateCard item in _mViceCard)
            {
                if (item.AssociateCardNumber != cardnumber) continue;
                vicecard = item;
            }
            return vicecard;
        }
    }
}
