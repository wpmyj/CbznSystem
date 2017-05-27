using System.Data;
using Bll;
using Dal;
using Model;
using NewControl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CbznSystem
{
    public partial class DistanceCardIssue_Form : NewForm
    {
        /// <summary>
        /// 显示动画效果
        /// </summary>
        private System.Timers.Timer _tEffect;
        /// <summary>
        /// 主卡信息
        /// </summary>
        private CbCardInfo _mCardInfo;
        /// <summary>
        /// 主卡计数信息
        /// </summary>
        private CbCardCountingState _mCardCounting;
        /// <summary>
        /// 已捆绑的副卡集合
        /// </summary>
        private List<CbAssociateCard> _mViceCard;
        /// <summary>
        /// 已捆绑的副卡计数集合
        /// </summary>
        private List<CbCardCountingState> _mViceCardCount;
        /// <summary>
        /// 添加的副卡集合
        /// </summary>
        private List<CbAssociateCard> _mAddViceCard;
        /// <summary>
        /// 删除的副卡集合
        /// </summary>
        private List<CbAssociateCard> _mDelViceCard;
        /// <summary>
        /// 解锁的副卡
        /// </summary>
        private CbAssociateCard _mUnlockViceCard;
        private Label _lMessage;

        private bool _isShow;

        public DistanceCardIssue_Form(CbCardInfo mcardinfo)
        {
            InitializeComponent();

            _mCardInfo = mcardinfo;

            this.Load += DistanceCardIssue_Form_Load;
            this.Shown += DistanceCardIssue_Form_Shown;
            this.FormClosing += DistanceCardIssue_Form_FormClosing;
            this.FormClosed += DistanceCardIssue_Form_FormClosed;

            cb_InformationInput.SelectedIndexChanged += Cb_InformationInput_SelectedIndexChanged;
            l_UserNameTitle.MouseDown += L_UserNameTitle_MouseDown;
            tb_UserName.TextChanged += Tb_UserName_TextChanged;
            tb_UserName.KeyPress += Tb_UserName_KeyPress;
            l_PlateNumberTitle.MouseDown += L_PlateNumberTitle_MouseDown;
            tb_PlateNumber.TextChanged += Tb_PlateNumber_TextChanged;
            tb_PlateNumber.KeyPress += Tb_PlateNumber_KeyPress;
            cb_Sex.KeyPress += Cb_Sex_KeyPress;
            ud_Age.KeyPress += Ud_Age_KeyPress;
            l_PhoneTitle.MouseDown += L_PhoneTitle_MouseDown;
            tb_Phone.TextChanged += Tb_Phone_TextChanged;
            tb_Phone.KeyPress += Tb_Phone_KeyPress;

            cb_CardType.SelectedIndexChanged += Cb_CardType_SelectedIndexChanged;
            cb_CardPartition.SelectedIndexChanged += Cb_CardPartition_SelectedIndexChanged;

            //车场分区全选
            cb_AllSelected.CheckedChanged += Cb_AllSelected_CheckedChanged;
            cb_AllSelected.MouseDown += Cb_AllSelected_MouseDown;
            //车场分区容器重绘事件
            p_CardPartition.Paint += P_CardPartition_Paint;
            p_CardPartition.VisibleChanged += P_CardPartition_VisibleChanged;
            //捆绑副卡全选
            cb_AllSelected2.MouseDown += Cb_AllSelected2_MouseDown;
            cb_AllSelected2.CheckedChanged += Cb_AllSelected2_CheckedChanged;
            //捆绑副卡容器重绘事件
            p_Bundled.Paint += P_Bundled_Paint;

            dgv_ViceCardList.CellValueChanged += Dgv_ViceCardList_CellValueChanged;
            dgv_ViceCardList.CurrentCellDirtyStateChanged += Dgv_ViceCardList_CurrentCellDirtyStateChanged;
            dgv_ViceCardList.RowsAdded += Dgv_ViceCardList_RowsAdded;
            dgv_ViceCardList.RowsRemoved += Dgv_ViceCardList_RowsRemoved;
            dgv_ViceCardList.CellFormatting += Dgv_ViceCardList_CellFormatting;

            btn_Remove.Click += Btn_Remove_Click;
            btn_Remove.Paint += FormComm.DrawBtnEnabled;
            btn_Add.Click += Btn_Add_Click;
            btn_Add.Paint += FormComm.DrawBtnEnabled;
            btn_SetPlate.Click += Btn_SetPlate_Click;
            btn_Enter.Paint += FormComm.DrawBtnEnabled;
            btn_Enter.Click += Btn_Enter_Click;

        }

        /// <summary>
        /// 信息录入变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cb_InformationInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_InformationInput.SelectedIndex > 0)
            {
                try
                {
                    CbCardInfo mUserInfo = Dbhelper.Db.FirstDefault<CbCardInfo>();
                    _mCardInfo.ID = mUserInfo.ID;
                    tb_UserName.Text = mUserInfo.UserName;
                    tb_PlateNumber.Text = mUserInfo.PlateNumber;
                    ud_Age.Value = mUserInfo.UserAge;
                    cb_Sex.SelectedIndex = mUserInfo.UserSex;
                    tb_Address.Text = mUserInfo.UserAddress;
                    tb_Phone.Text = mUserInfo.UserPhone;
                }
                catch (Exception ex)
                {
                    CustomExceptionHandler.GetExceptionMessage(ex);
                    MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (!_isShow) return;
                _mCardInfo.ID = 0;
                tb_UserName.Text = string.Empty;
                tb_PlateNumber.Text = string.Empty;
                ud_Age.Value = 18;
                cb_Sex.SelectedIndex = 0;
                tb_Address.Text = string.Empty;
                tb_Phone.Text = string.Empty;
            }
        }

        /// <summary>
        /// 窗体关闭前事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DistanceCardIssue_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (PortHelper.IsConnection && !btn_Enter.Enabled)
            {
                MessageBox.Show("当前定距卡操作未结果，无法退出，请稍后。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }
            if (_mAddViceCard.Count + _mDelViceCard.Count > 0)
            {
                if (MessageBox.Show("当前定距卡操作未完成，是否放弃当前操作。", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// DGV 单元格格式发生变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dgv_ViceCardList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv_ViceCardList.Columns[e.ColumnIndex].Name == "c_ViceCardPartition")
            {
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
            }
        }

        /// <summary>
        /// 获取车场分的值
        /// </summary>
        /// <returns></returns>
        private int GetFieldPartition()
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
        /// 将车场分区分配
        /// </summary>
        /// <param name="partition"></param>
        private void SetFieldPartition(int partition)
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
            SetCheckState(p_CardPartition);
        }

        /// <summary>
        /// 车牌分区容器显示或隐藏事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void P_CardPartition_VisibleChanged(object sender, EventArgs e)
        {
            if (!p_CardPartition.Visible) return;
            if (_mCardInfo != null & _mCardInfo.FieldPartition > 0)
            {
                SetFieldPartition(_mCardInfo.FieldPartition);
            }
        }

        /// <summary>
        /// 车场分区全选鼠标按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cb_AllSelected_MouseDown(object sender, MouseEventArgs e)
        {
            cb_AllSelected.ThreeState = false;
        }

        /// <summary>
        /// 车场分区全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cb_AllSelected_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_AllSelected.CheckState == CheckState.Indeterminate) return;
            cb_AllSelected.Tag = cb_AllSelected.Checked;
            foreach (Control item in cb_AllSelected.Parent.Controls)
            {
                if (!(item is CheckBox)) continue;
                if (item == cb_AllSelected) continue;
                ((CheckBox)item).Checked = cb_AllSelected.Checked;
            }
            cb_AllSelected.Tag = null;
        }

        /// <summary>
        /// 车场分区选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PartitionCheckedChanged(object sender, EventArgs e)
        {
            if (!_isShow) return;
            if (cb_AllSelected.Tag != null) return;
            Control c = sender as Control;
            SetCheckState(c.Parent as Panel);
        }

        /// <summary>
        /// 设置车场分区全选的状态
        /// </summary>
        /// <param name="p"></param>
        private void SetCheckState(Panel p)
        {
            int count = 0;
            foreach (Control item in p.Controls)
            {
                if (!(item is CheckBox)) continue;
                if (item == cb_AllSelected) continue;
                CheckBox cb = item as CheckBox;
                if (cb.Checked)
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
        /// 车场分区变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cb_CardPartition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_CardPartition.SelectedIndex == 0)//车场分区关闭
            {
                p_CardPartition.Visible = false;//隐藏车场分区容器
            }

            //显示动画效果
            StopEffect();
            StartEffect();
        }

        /// <summary>
        /// 停止动画显示
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
        /// 开始动画显示
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
                if (cb_CardType.SelectedIndex == 0)//显示单卡的动画效果
                {
                    if (cb_CardPartition.SelectedIndex == 0)//车场分区关闭
                    {
                        if (Height <= 360)
                        {
                            StopEffect();
                            Height = 360;
                            return;
                        }
                        Height -= 20;
                    }
                    else//车场分区开启
                    {
                        if (Height >= 520)
                        {
                            StopEffect();
                            Height = 520;
                            p_CardPartition.Visible = true;//显示车场分区容器
                            return;
                        }
                        Height += 20;
                    }
                }
                else //显示组合卡或车牌识别卡的动画效果
                {
                    if (Height >= 595)
                    {
                        StopEffect();
                        Height = 595;
                        p_Bundled.Visible = true;//显示副卡捆绑容器
                        return;
                    }
                    Height += 20;
                }
            }));
        }

        /// <summary>
        /// 车场分区容器重绘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void P_CardPartition_Paint(object sender, PaintEventArgs e)
        {
            DrawBorder(e.Graphics, cb_CardPartition, p_CardPartition);
        }

        /// <summary>
        /// 副卡容器重绘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void P_Bundled_Paint(object sender, PaintEventArgs e)
        {
            DrawBorder(e.Graphics, cb_CardType, p_Bundled);
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
        /// 窗体显示事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DistanceCardIssue_Form_Shown(object sender, EventArgs e)
        {
            _isShow = true;
        }

        /// <summary>
        /// 副卡全选鼠标按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cb_AllSelected2_MouseDown(object sender, MouseEventArgs e)
        {
            cb_AllSelected2.ThreeState = false;
        }

        /// <summary>
        /// 副卡全选变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cb_AllSelected2_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_AllSelected2.CheckState == CheckState.Indeterminate) return;
            cb_AllSelected2.Tag = cb_AllSelected2.Checked;
            for (int i = 0; i < dgv_ViceCardList.RowCount; i++)
            {
                dgv_ViceCardList["c_Selected", i].Value = cb_AllSelected2.Checked;
            }
            if (dgv_ViceCardList.RowCount > 0)
                btn_Remove.Enabled = cb_AllSelected2.Checked;
            cb_AllSelected2.Tag = null;
        }

        /// <summary>
        /// DGV 单元格状因其内容更改而发生的变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dgv_ViceCardList_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgv_ViceCardList.IsCurrentCellDirty)
            {
                dgv_ViceCardList.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        /// <summary>
        /// DGV 单元格内容发生变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dgv_ViceCardList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_ViceCardList.Columns[e.ColumnIndex].Name == "c_Selected")
            {
                if (cb_AllSelected2.Tag != null) return;
                int count = 0;
                for (int i = 0; i < dgv_ViceCardList.RowCount; i++)
                {
                    bool flag = Utils.StrToBool(dgv_ViceCardList["c_Selected", i].Value, false);
                    if (flag)
                        count++;
                }
                cb_AllSelected2.ThreeState = true;
                if (count == 0)
                    cb_AllSelected2.CheckState = CheckState.Unchecked;
                else if (count == dgv_ViceCardList.RowCount)
                    cb_AllSelected2.CheckState = CheckState.Checked;
                else
                    cb_AllSelected2.CheckState = CheckState.Indeterminate;
                btn_Remove.Enabled = count > 0;
            }
        }

        /// <summary>
        /// DGV 移除行事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dgv_ViceCardList_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            btn_Add.Enabled = dgv_ViceCardList.RowCount < 4;
        }

        /// <summary>
        /// DGV 添加行事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dgv_ViceCardList_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            btn_Add.Enabled = dgv_ViceCardList.RowCount < 4;
        }

        /// <summary>
        /// 确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Enter_Click(object sender, EventArgs e)
        {
            if (tb_UserName.TextLength == 0)
            {
                tb_UserName.Focus();
                return;
            }

            //用户名称
            _mCardInfo.UserName = tb_UserName.Text.Trim();
            //车牌号码
            _mCardInfo.PlateNumber = tb_PlateNumber.Text.Trim();
            //性别
            _mCardInfo.UserSex = cb_Sex.SelectedIndex;
            //年龄
            _mCardInfo.UserAge = (int)ud_Age.Value;
            //电话号码
            _mCardInfo.UserPhone = tb_Phone.Text.Trim();
            //地址
            _mCardInfo.UserAddress = tb_Address.Text.Trim();
            //主卡类型
            _mCardInfo.CardType = cb_CardType.SelectedIndex;
            //主卡距离
            _mCardInfo.Distance = cb_Distance.SelectedIndex;
            //主卡车位限制
            _mCardInfo.ParkingRestrictions = cb_ParkingRestrictions.SelectedIndex;
            //_mCardInfo.LoseState = 0;
            //主卡锁的状态
            _mCardInfo.Unlocked = 0;
            //主卡使用状态
            _mCardInfo.UseState = 1;
            //主卡车场分区
            _mCardInfo.FieldPartition = cb_CardPartition.SelectedIndex == 0 ? 0 : GetFieldPartition();
            //主卡时间
            _mCardInfo.StopTime = cb_CardType.SelectedIndex == 0 ? dt_Time.Value : GetViceCardMaxTime();
            //开始时间
            _mCardInfo.StartTime = _mCardInfo.StopTime;

            if (_mCardInfo.ID == 0)
            {
                _mCardInfo.RegistrationTime = DateTime.Now;
            }
            btn_Enter.Enabled = false;
            _mUnlockViceCard = null;
            try
            {
                //获取主卡计数信息
                _mCardCounting = Dbhelper.Db.FirstDefault<CbCardCountingState>(" and UseNumber='" + _mCardInfo.CardNumber + "' ");
                if (_mCardCounting == null)
                {
                    _mCardCounting = new CbCardCountingState()
                    {
                        UseNumber = _mCardInfo.CardNumber
                    };
                }
                //组合卡获取副卡的计数信息
                if (_mCardInfo.CardType == 1)
                {
                    StringBuilder sb = new StringBuilder();
                    //获取已捆绑的副卡
                    foreach (CbAssociateCard item in _mViceCard)
                    {
                        sb.AppendFormat(" UseNumber='{0}' or", item.AssociateCardNumber);
                    }
                    //获取等待捆绑的副卡
                    foreach (CbAssociateCard item in _mAddViceCard)
                    {
                        sb.AppendFormat(" UseNumber='{0}' or", item.AssociateCardNumber);
                    }
                    sb = sb.Remove(sb.Length - 2, 2);
                    //获取副卡的计数信息
                    _mViceCardCount = Dbhelper.Db.ToList<CbCardCountingState>(" and (" + sb.ToString() + ") ");
                }
                //发送读取定距卡
                byte[] by = PortAgreement.GetReadSomeCard(_mCardInfo.CardNumber);
                PortHelper.SerialPortWrite(by);
            }
            catch (Exception ex)
            {
                btn_Enter.Enabled = true;
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 获取副卡最大的时间
        /// </summary>
        /// <returns></returns>
        private DateTime GetViceCardMaxTime()
        {
            DateTime time = DateTime.MinValue;
            foreach (CbAssociateCard item in _mViceCard)
            {
                if (item.AssociateCardTime > time)
                {
                    time = item.AssociateCardTime;
                }
                else if (item.UpdateTime > time)
                {
                    time = item.UpdateTime;
                }
            }
            foreach (CbAssociateCard item in _mAddViceCard)
            {
                if (item.AssociateCardTime > time)
                    time = item.AssociateCardTime;
            }
            return time;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Add_Click(object sender, EventArgs e)
        {
            DateTime nowday = DateTime.Now.Date;
            try
            {
                if (cb_CardType.SelectedIndex == 2)//车牌识别卡
                {
                    AddLicensePlateViceCard(string.Empty);
                }
                else //组合卡
                {
                    List<CbAssociateCard> combinationViceCard = new List<CbAssociateCard>();
                    combinationViceCard.AddRange(_mViceCard);
                    combinationViceCard.AddRange(_mAddViceCard);
                    using (BindingViceCard_Form binding = new BindingViceCard_Form(combinationViceCard)
                    {
                        Height = this.Height,
                        Location = new Point(Left + Width, Top)
                    })
                    {
                        if (binding.ShowDialog() != DialogResult.OK) return;
                        List<CbAssociateCard> mAddViceCard = binding.Tag as List<CbAssociateCard>;
                        //将副卡添加到集合中
                        _mAddViceCard.AddRange(mAddViceCard);
                        //显示添加的副卡
                        foreach (CbAssociateCard item in mAddViceCard)
                        {
                            Image img = Properties.Resources.check;
                            if (item.UseState == 2)
                                img = Properties.Resources.block;
                            dgv_ViceCardList.Rows.Add(new object[] { false, img, item.AssociateCardNumber, item.AssociateCardTime, item.SubCardDivision });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 添加车牌识别副卡
        /// </summary>
        /// <param name="licenseplate"></param>
        private void AddLicensePlateViceCard(string licenseplate)
        {
            using (InputPlate_Form inputplate = new InputPlate_Form(licenseplate))
            {
                inputplate.Location = new Point(Left + Width, Top);
                if (inputplate.ShowDialog() != DialogResult.OK) return;
                licenseplate = inputplate.Tag as string;
                //验证车牌号码是存在
                if (GetLicensePlateViceCardExists(licenseplate))
                {
                    if (MessageBox.Show("车牌号码：" + licenseplate + "已经存在列表中，不能重复添加，是否进行修改。", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        AddLicensePlateViceCard(licenseplate);
                    }
                    return;
                }
                CbAssociateCard mViceCard = new CbAssociateCard()
                {
                    AssociateCardNumber = licenseplate,
                    AssociateCardTime = DateTime.Now.Date,
                    UpdateTime = DateTime.Now.Date,
                    SubCardDivision = 65535,
                    UseState = 0
                };
                _mAddViceCard.Add(mViceCard);
                dgv_ViceCardList.Rows.Add(new object[] { false, Properties.Resources.check, mViceCard.AssociateCardNumber, mViceCard.AssociateCardTime, mViceCard.SubCardDivision });
            }
        }

        /// <summary>
        /// 判断车牌号码副卡是否存在
        /// </summary>
        /// <param name="platenumber"></param>
        /// <returns></returns>
        private bool GetLicensePlateViceCardExists(string platenumber)
        {
            foreach (CbAssociateCard item in _mViceCard)
            {
                if (item.AssociateCardNumber == platenumber)
                    return true;
            }
            foreach (CbAssociateCard item in _mAddViceCard)
            {
                if (item.AssociateCardNumber == platenumber)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Remove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认移除捆绑的副卡", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK) return;

            for (int i = dgv_ViceCardList.RowCount - 1; i >= 0; i--)
            {
                bool flag = Utils.StrToBool(dgv_ViceCardList["c_Selected", i].Value, false);
                if (!flag) continue;
                string vicecardnumber = Utils.ObjectToStr(dgv_ViceCardList["c_ViceCardNumber", i].Value);
                RemoveBundledViceCard(vicecardnumber);
                dgv_ViceCardList.Rows.RemoveAt(i);
            }
            btn_Remove.Enabled = false;
            cb_AllSelected2.CheckState = CheckState.Unchecked;
        }

        /// <summary>
        /// 移除捆绑的副卡
        /// </summary>
        /// <param name="cardnumber"></param>
        private void RemoveBundledViceCard(string cardnumber)
        {
            //移除已绑定的副卡
            foreach (CbAssociateCard item in _mViceCard)
            {
                if (item.AssociateCardNumber.Equals(cardnumber))
                {
                    _mDelViceCard.Add(item);
                    _mViceCard.Remove(item);
                    return;
                }
            }
            //移除等待添加的副卡
            foreach (CbAssociateCard item in _mAddViceCard)
            {
                if (item.AssociateCardNumber.Equals(cardnumber))
                {
                    _mAddViceCard.Remove(item);
                    return;
                }
            }
        }

        /// <summary>
        /// 车牌号码边上的小键盘按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_SetPlate_Click(object sender, EventArgs e)
        {
            using (InputPlate_Form inputplate = new InputPlate_Form(tb_PlateNumber.Text.Trim()))
            {
                if (inputplate.ShowDialog() != DialogResult.OK) return;
                string platenumber = inputplate.Tag as string;
                tb_PlateNumber.Text = platenumber;
                tb_PlateNumber.Focus();
                tb_PlateNumber.SelectionStart = tb_PlateNumber.TextLength;
            }
        }

        /// <summary>
        /// 电话号码在控件具有焦点并且用户按下并释放某个键后发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tb_Phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                tb_Address.Focus();//地址获取焦点
            }
            e.Handled = LimitInput.InputNumber(e.KeyChar);
        }

        /// <summary>
        /// 电话号码文本变化变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tb_Phone_TextChanged(object sender, EventArgs e)
        {
            l_PhoneTitle.Visible = tb_Phone.TextLength == 0;
        }

        /// <summary>
        /// 电话号码文本鼠标按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void L_PhoneTitle_MouseDown(object sender, MouseEventArgs e)
        {
            tb_Phone.Focus();
        }

        /// <summary>
        /// 年龄在控件具有焦点并且用户按下并释放某个键后发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ud_Age_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                tb_Phone.Focus();
            }
        }

        /// <summary>
        /// 性别在控件具有焦点并且用户按下并释放某个键后发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cb_Sex_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ud_Age.Focus();
            }
        }

        /// <summary>
        /// 车牌号码在控件具有焦点并且用户按下并释放某个键后发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tb_PlateNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cb_Sex.Focus();
            }
        }

        /// <summary>
        /// 车牌号码文本变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tb_PlateNumber_TextChanged(object sender, EventArgs e)
        {
            l_PlateNumberTitle.Visible = tb_PlateNumber.TextLength == 0;
        }

        /// <summary>
        /// 按下车牌号码标题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void L_PlateNumberTitle_MouseDown(object sender, MouseEventArgs e)
        {
            tb_PlateNumber.Focus();
        }

        /// <summary>
        /// 用户名称在控件具有焦点并且用户按下并释放某个键后发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tb_UserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                tb_PlateNumber.Focus();
            }
        }

        /// <summary>
        /// 用户名称文本变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tb_UserName_TextChanged(object sender, EventArgs e)
        {
            l_UserNameTitle.Visible = tb_UserName.TextLength == 0;
        }

        /// <summary>
        /// 按下用户名称标题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void L_UserNameTitle_MouseDown(object sender, MouseEventArgs e)
        {
            tb_UserName.Focus();
        }

        /// <summary>
        /// 定距卡类型变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cb_CardType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_CardType.SelectedIndex != _mCardInfo.CardType)
            {
                if (_mViceCard.Count > 0)
                {
                    //将副卡集合中的数据添加到删除副卡集合中
                    _mDelViceCard.AddRange(_mViceCard);
                    //清空副卡集合
                    _mViceCard.Clear();
                }
                //清空添加集合
                _mAddViceCard.Clear();
                //清空列表
                dgv_ViceCardList.Rows.Clear();
            }
            else if (_mCardInfo.CardType > 0)
            {
                //清空删除集合
                _mDelViceCard.Clear();
                //清空添加集合
                _mAddViceCard.Clear();
                //获取副卡集合
                GetViceCardInfo();
            }

            if (cb_CardType.SelectedIndex == 0)//单卡模式
            {
                //启用时间
                dt_Time.Enabled = true;
                //不启用车牌限制
                cb_ParkingRestrictions.Enabled = false;
                //启用车场分区
                cb_CardPartition.Enabled = true;
                //隐藏副卡容器
                p_Bundled.Visible = false;
            }
            else //组合卡或车牌识别卡模式
            {
                //不启用时间
                dt_Time.Enabled = false;
                //启用车牌限制
                cb_ParkingRestrictions.Enabled = true;
                //关闭车场分区
                cb_CardPartition.SelectedIndex = 0;
                //不启用车场分区
                cb_CardPartition.Enabled = false;
                //隐藏车场分区容器
                p_CardPartition.Visible = false;
            }

            //显示动画效果
            StopEffect();
            StartEffect();
        }

        /// <summary>
        /// 获取副卡信息
        /// </summary>
        private void GetViceCardInfo()
        {
            try
            {
                if (_mCardInfo.ID > 0)
                {
                    _mViceCard = Dbhelper.Db.ToList<CbAssociateCard>(" and CardId=" + _mCardInfo.ID + " ");
                    foreach (CbAssociateCard item in _mViceCard)
                    {
                        dgv_ViceCardList.Rows.Add(new object[] { false, Properties.Resources.check, item.AssociateCardNumber, item.AssociateCardTime, item.SubCardDivision });
                    }
                }
            }
            catch (Exception ex)
            {
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DistanceCardIssue_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            //释放端口数据接收事件
            PortHelper.DataReceived -= SerialPortDataReceived;
            //释放端口数量变化事件
            PortHelper.ConnectionChange -= DeviceConnectionChange;
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DistanceCardIssue_Form_Load(object sender, EventArgs e)
        {
            //添加端口数据接收事件
            PortHelper.DataReceived += SerialPortDataReceived;
            //添加端口变化事件
            PortHelper.ConnectionChange += DeviceConnectionChange;
            PortHelper.CurrentForm = this;
            btn_Enter.Enabled = PortHelper.IsConnection;

            //初始化删除副卡集合
            _mDelViceCard = new List<CbAssociateCard>();
            //初始化添加副卡集合
            _mAddViceCard = new List<CbAssociateCard>();
            //初始化副卡集合
            _mViceCard = new List<CbAssociateCard>();

            if (_mCardInfo.ID > 0)
            {
                //不启用信息录入
                cb_InformationInput.Enabled = false;
                //姓名
                tb_UserName.Text = _mCardInfo.UserName;
                //电话
                tb_Phone.Text = _mCardInfo.UserPhone;
                //车牌号码
                tb_PlateNumber.Text = _mCardInfo.PlateNumber;
                //性别
                cb_Sex.SelectedIndex = _mCardInfo.UserSex;
                //年龄
                ud_Age.Value = _mCardInfo.UserAge;
                //地址
                tb_Address.Text = _mCardInfo.UserAddress;
                //主卡类型
                cb_CardType.SelectedIndex = _mCardInfo.CardType;
                //时间
                dt_Time.Value = _mCardInfo.StopTime;
                //距离
                cb_Distance.SelectedIndex = _mCardInfo.Distance;
                //停车限制
                cb_ParkingRestrictions.SelectedIndex = _mCardInfo.ParkingRestrictions;
                //车场分区
                cb_CardPartition.SelectedIndex = _mCardInfo.FieldPartition > 0 ? 1 : 0;
            }
            else
            {
                //获取信息录入的用户信息
                DataTable dt = Dbhelper.Db.ToTable<CbCardInfo>(" and CardNumber ='' ");
                DataRow dr = dt.NewRow();
                dr["UserName"] = "无";
                dr["ID"] = 0;
                dt.Rows.InsertAt(dr, 0);
                cb_InformationInput.DisplayMember = "UserName";
                cb_InformationInput.ValueMember = "ID";
                cb_InformationInput.DataSource = dt;
                //性别
                cb_Sex.SelectedIndex = 0;
                //主卡类型
                cb_CardType.SelectedIndex = 0;
                //距离
                cb_Distance.SelectedIndex = 4;
                //车牌限制
                cb_ParkingRestrictions.SelectedIndex = 0;
                //车场分区
                cb_CardPartition.SelectedIndex = 0;
            }
            //主卡编号
            tb_CardNumber.Text = _mCardInfo.CardNumber;
            //不启用主卡编号
            tb_CardNumber.Enabled = false;
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
        /// 端口数据接收
        /// </summary>
        /// <param name="param"></param>
        private void SerialPortDataReceived(ParsingParameter param)
        {
            if (!PortHelper.IsConnection) return;
            if (PortHelper.CurrentForm != this) return;
            this.Invoke(new EventHandler(delegate
            {
                DistanceDataContent(param);
            }));
        }

        /// <summary>
        /// 显示端口数据
        /// </summary>
        /// <param name="param"></param>
        private void DistanceDataContent(ParsingParameter param)
        {
            try
            {
                if (param.FunctionAddress == 65)//定距卡操作
                {
                    //解析端口获取的数据
                    DistanceParameter distanceparam = DataParsing.DistanceParsingContent(param.DataContent);
                    switch (distanceparam.Command)
                    {
                        case 26://读取定距卡
                            if (distanceparam.AuxiliaryCommand == 0)//成功
                            {
                                HostCardIssue(param.DataContent);
                            }
                            else//失败
                            {
                                btn_Enter.Enabled = true;
                                MessageBox.Show("定距卡发行失败，请将定距卡放置在发行器可读写区域内。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            break;
                        case 27: //写入定距卡
                            if (_mUnlockViceCard == null)
                            {
                                if (distanceparam.AuxiliaryCommand == 0)//成功
                                {
                                    HostCardDataSave();
                                }
                                else
                                {
                                    btn_Enter.Enabled = true;
                                    MessageBox.Show("定距卡发行失败，请将定距卡放置在发行器可读写区域内。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }

                            if (_mCardInfo.CardType == 1)//组合卡
                            {
                                int index = -1;
                                foreach (CbAssociateCard item in _mViceCard)
                                {
                                    index++;
                                    if (_mUnlockViceCard != null && item == _mUnlockViceCard)
                                    {
                                        if (distanceparam.AuxiliaryCommand == 0)//解锁成功
                                        {
                                            item.UseState = 0;
                                            Dbhelper.Db.Update<CbAssociateCard>(item);
                                            dgv_ViceCardList["c_State", index].Value = Properties.Resources.check;
                                        }
                                        _mUnlockViceCard = null;
                                        continue;
                                    }
                                    if (_mUnlockViceCard != null) continue;
                                    if (item.UseState != 2) continue;
                                    _mUnlockViceCard = item;
                                    //创建提示容器
                                    CreateMessageLabel();
                                    //解锁副卡类型
                                    int typebyte = DistanceCardHelper.SetCardTypeByte(new DistanceTypeParameter() { Lock = 0, Distance = 4 }, 1);
                                    byte[] by = PortAgreement.GetDistanceContent(item.AssociateCardNumber, typebyte);
                                    PortHelper.SerialPortWrite(by);
                                    return;
                                }
                                foreach (CbAssociateCard item in _mViceCard)
                                {
                                    if (item.UseState == 2)
                                    {
                                        //释放提示label
                                        if (_lMessage != null)
                                        {
                                            Controls.Remove(_lMessage);
                                            _lMessage.Dispose();
                                            _lMessage = null;
                                        }
                                        btn_Enter.Enabled = true;
                                        MessageBox.Show("解锁副卡失败，将新添加的副卡放置在发行器可读写区域内", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                            }
                            btn_Enter.Enabled = true;
                            this.DialogResult = DialogResult.OK;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                btn_Enter.Enabled = true;
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 创建提示解锁副卡容器
        /// </summary>
        private void CreateMessageLabel()
        {
            if (_lMessage != null) return;
            _lMessage = new Label()
            {
                Size = new Size(Width, 100),
                Location = new Point(0, (Height - 100) / 2),
                BackColor = Color.Gray,
                ForeColor = Color.White,
                Text = "解锁副卡中，将副卡放置在发行器可读写区域内",
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)))
            };
            this.Controls.Add(_lMessage);
            _lMessage.BringToFront();
        }

        /// <summary>
        /// 主卡数据保存
        /// </summary>
        private void HostCardDataSave()
        {
            //修改挂失类型
            _mCardInfo.LoseState = 0;
            if (_mCardInfo.ID > 0)
            {
                //更新主卡数据
                Dbhelper.Db.Update<CbCardInfo>(_mCardInfo);
            }
            else
            {
                //插入主卡数据
                _mCardInfo.ID = Dbhelper.Db.Insert<CbCardInfo>(_mCardInfo);
            }
            if (_mCardCounting.ID > 0)
            {
                //更新主卡计数数据
                Dbhelper.Db.Update<CbCardCountingState>(_mCardCounting);
            }
            else
            {
                //插入主卡计数数据
                Dbhelper.Db.Insert<CbCardCountingState>(_mCardCounting);
            }

            //删除移除的副卡
            if (_mDelViceCard.Count > 0)
            {
                Dbhelper.Db.Del<CbAssociateCard>(_mDelViceCard.ToArray());
                _mDelViceCard.Clear();
            }

            if (_mAddViceCard.Count > 0)
            {
                foreach (CbAssociateCard item in _mAddViceCard)
                {
                    item.CardID = _mCardInfo.ID;
                }
                //插入添加的副卡
                Dbhelper.Db.Insert<CbAssociateCard>(_mAddViceCard.ToArray());
                //将等待添加的副卡集合添加到已绑定的副卡集合中
                _mViceCard.AddRange(_mAddViceCard);
                //清空等待添加的副卡集合
                _mAddViceCard.Clear();
            }

            if (_mViceCardCount != null && _mViceCardCount.Count > 0)
            {
                //更新副卡计数数据
                Dbhelper.Db.Update<CbCardCountingState>(_mViceCardCount.ToArray());
            }

            this.Tag = _mCardInfo;
        }

        /// <summary>
        /// 发行定距卡
        /// </summary>
        /// <param name="by"></param>
        private void HostCardIssue(byte[] by)
        {
            //解析定距卡数据内容
            DistanceDataParameter dataparam = DataParsing.DistanceData(by);
            //功能字节
            int functionbyte = 0;
            DistanceCardBaseParam baseparam;
            if (_mCardInfo.CardType == 0) //单卡
            {
                //实例化单卡基本数据内容
                baseparam = new SingleCardDataParam();
                //获取单卡基本数据内容
                baseparam = GetDistanceCardBaseParam(baseparam, dataparam);
                SingleCardDataParam single = (SingleCardDataParam)baseparam;
                //时间
                single.NewTime = _mCardInfo.StopTime;
                //车场分区
                single.Partition = _mCardInfo.FieldPartition;
                by = DistanceCardHelper.SetDistanceData(single, ref functionbyte);
            }
            else if (_mCardInfo.CardType == 1) //组合卡
            {
                //实例化组合卡基本数据内容
                baseparam = new CombinationCardDataParam();
                //获取组合卡基本数据内容
                baseparam = GetDistanceCardBaseParam(baseparam, dataparam);
                CombinationCardDataParam combination = (CombinationCardDataParam)baseparam;
                //获取已绑定副卡数据内容
                foreach (CbAssociateCard item in _mViceCard)
                {
                    //获取副卡计数信息
                    CbCardCountingState vicecardcount = GetViceCardCounting(item.AssociateCardNumber);
                    combination.ViceCards.Add(new CombinationCardViceCardDataParam()
                    {
                        //副卡时间
                        ViceCardTime = item.UpdateTime,
                        //副卡编号
                        ViceCardNumber = item.AssociateCardNumber,
                        //副卡分区
                        ViceCardPartition = item.SubCardDivision,
                        //副卡计数
                        ViceCardCount = vicecardcount.UseCounting
                    });
                }
                //获取等待绑定的副卡数据内容
                foreach (CbAssociateCard item in _mAddViceCard)
                {
                    //获取副卡计数信息
                    CbCardCountingState vicecardcount = GetViceCardCounting(item.AssociateCardNumber);
                    combination.ViceCards.Add(new CombinationCardViceCardDataParam()
                    {
                        //副卡时间
                        ViceCardTime = item.UpdateTime,
                        //副卡编号
                        ViceCardNumber = item.AssociateCardNumber,
                        //副卡分区
                        ViceCardPartition = item.SubCardDivision,
                        //副卡计数
                        ViceCardCount = vicecardcount.UseCounting
                    });
                }
                by = DistanceCardHelper.SetDistanceData(combination, ref functionbyte);
            }
            else //车牌识别卡
            {
                //初始化车牌识别卡基本参数
                baseparam = new LprCardDataParam();
                //获取车牌识别卡基本参数
                baseparam = GetDistanceCardBaseParam(baseparam, dataparam);
                LprCardDataParam lpr = (LprCardDataParam)baseparam;
                //获取已绑定副卡数据内容
                foreach (CbAssociateCard item in _mViceCard)
                {
                    lpr.ViceCards.Add(new LprCardViceCardParam()
                    {
                        //车牌号码
                        PlateNumber = item.AssociateCardNumber,
                        //时间
                        ViceCardTime = item.UpdateTime,
                        //分区
                        ViceCardPartition = item.SubCardDivision
                    });
                }
                //获取等待绑定的副卡数据内容
                foreach (CbAssociateCard item in _mAddViceCard)
                {
                    lpr.ViceCards.Add(new LprCardViceCardParam()
                    {
                        //车牌号码
                        PlateNumber = item.AssociateCardNumber,
                        //时间
                        ViceCardTime = item.UpdateTime,
                        //分区
                        ViceCardPartition = item.SubCardDivision
                    });
                }
                by = DistanceCardHelper.SetDistanceData(lpr, ref functionbyte);
            }
            //获取主卡计数
            _mCardCounting.UseCounting = baseparam.Count;
            //获取主卡的功能字节
            _mCardCounting.UseFunction = functionbyte;
            PortHelper.SerialPortWrite(by);
        }

        /// <summary>
        /// 获取定距卡基本参数
        /// </summary>
        /// <param name="baseparam"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        private DistanceCardBaseParam GetDistanceCardBaseParam(DistanceCardBaseParam baseparam, DistanceDataParameter param)
        {
            //卡号
            baseparam.CardNumber = _mCardInfo.CardNumber;
            //类型参数
            baseparam.CardTypeParam = new DistanceTypeParameter()
            {
                Distance = _mCardInfo.Distance,
                Lock = _mCardInfo.Unlocked
            };
            //功能参数
            baseparam.CardFunctioinParam = new FunctionByteParameter()
            {
                Loss = 0, //挂失
                ParkingRestrictions = _mCardInfo.ParkingRestrictions,//车牌限制
                RegistrationType = (CardTypes)_mCardInfo.CardType, //注册类型
                ViceCardCount = _mAddViceCard.Count + _mViceCard.Count, //副卡数量
                InOutState = param.FunctionByteParameter.InOutState, //进出状
                                                                     //同步位：同步位相同，挂失位看内存。 不同则看卡内的挂失位
                Synchronous = _mCardInfo.LoseState == 1 ? (param.FunctionByteParameter.Synchronous == 1 ? 0 : 1) : param.FunctionByteParameter.Synchronous
            };
            baseparam.Count = DistanceCardHelper.LimitCount(param.Count);
            return baseparam;
        }

        /// <summary>
        /// 获取副卡的计算信息
        /// </summary>
        /// <param name="cardnumber"></param>
        /// <returns></returns>
        private CbCardCountingState GetViceCardCounting(string cardnumber)
        {
            if (_mViceCardCount != null)
            {
                foreach (CbCardCountingState item in _mViceCardCount)
                {
                    if (item.UseNumber == cardnumber)
                    {
                        //当前计数+1
                        item.UseCounting = DistanceCardHelper.LimitCount(item.UseCounting);
                        return item;
                    }
                }
            }
            return null;
        }
    }
}
