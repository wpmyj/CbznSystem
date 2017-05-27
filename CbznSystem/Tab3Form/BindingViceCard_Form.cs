using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Model;
using Bll;
using Dal;
using NewControl;

namespace CbznSystem
{
    public partial class BindingViceCard_Form : NewForm
    {
        bool _isAddRow;
        /// <summary>
        /// 副卡集合
        /// </summary>
        List<CbAssociateCard> _mViceCard;

        /// <summary>
        /// 添加的副卡
        /// </summary>
        List<CbAssociateCard> _mAddViceCard;

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="mvicecard"></param>
        public BindingViceCard_Form(List<CbAssociateCard> mvicecard)
        {
            InitializeComponent();

            _mViceCard = mvicecard;

            this.Load += BindingViceCard_Form_Load;

            dgv_ViceCardList.RowsAdded += Dgv_ViceCardList_RowsAdded;
            dgv_ViceCardList.CellValueChanged += Dgv_ViceCardList_CellValueChanged;
            dgv_ViceCardList.CurrentCellDirtyStateChanged += Dgv_ViceCardList_CurrentCellDirtyStateChanged;
            dgv_ViceCardList.CellMouseDown += Dgv_ViceCardList_CellMouseDown;

            l_SearchTitle.MouseDown += L_SearchTitle_MouseDown;
            tb_SearchContent.TextChanged += Tb_SearchContent_TextChanged;
            tb_SearchContent.KeyPress += Tb_SearchContent_KeyPress;
            btn_Search.Click += Btn_Search_Click;
            btn_Enter.Click += Btn_Enter_Click;
            btn_Enter.Paint += FormComm.DrawBtnEnabled;

        }

        /// <summary>
        /// DGV 单元格鼠标按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dgv_ViceCardList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.Button != MouseButtons.Left) return;
            object vicecardnumber = dgv_ViceCardList["c_ViceCardNumber", e.RowIndex].Value;
            foreach (CbAssociateCard item in _mViceCard)
            {
                if (item.AssociateCardNumber.Equals(vicecardnumber))
                {
                    MessageBox.Show("定距卡:" + vicecardnumber + "已经绑定,不能修改不当前选项.", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        /// <summary>
        /// DGV 单元格状态因其内容更改而更改
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
        /// DGV 单元格的值发生变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dgv_ViceCardList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_isAddRow) return;
            try
            {
                bool check = Utils.StrToBool(dgv_ViceCardList[e.ColumnIndex, e.RowIndex].Value, false);
                string vicecardnumber = Utils.ObjectToStr(dgv_ViceCardList["c_ViceCardNumber", e.RowIndex].Value);
                if (check)
                {
                    //组合副卡
                    CbAssociateCard vicecard = new CbAssociateCard()
                    {
                        AssociateCardNumber = vicecardnumber,
                        AssociateCardTime = DateTime.Now,
                        UpdateTime = DateTime.Now,
                        SubCardDivision = 65535,
                        UseState = 0
                    };
                    _mAddViceCard.Add(vicecard);
                    //查询副卡的计数数据
                    CbCardCountingState cardcounting = Dbhelper.Db.FirstDefault<CbCardCountingState>(string.Format(" and UseNumber='{0}' ", vicecardnumber));
                    if (cardcounting != null) return;
                    //获取副卡参数
                    ViceCardParam mViceCardParam = Tab3_Form.SubList[vicecardnumber];
                    //组合副卡的计数数据
                    cardcounting = new CbCardCountingState()
                    {
                        UseCounting = mViceCardParam.Count,
                        UseFunction = 0,
                        UseNumber = mViceCardParam.ViceCardNumber
                    };
                    //添加副卡的计数数据
                    Dbhelper.Db.Insert<CbCardCountingState>(cardcounting);
                    //副卡获取是否须要解锁
                    if (mViceCardParam.LockState == 1)
                        //修改状态添加
                        vicecard.UseState = 2;
                }
                else
                {
                    foreach (CbAssociateCard item in _mAddViceCard)
                    {
                        if (item.AssociateCardNumber.Equals(vicecardnumber))
                        {
                            _mAddViceCard.Remove(item);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                btn_Enter.Enabled = _mAddViceCard.Count > 0;
            }
        }

        /// <summary>
        /// DGV 添加行事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dgv_ViceCardList_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                //获取副卡所关联的主卡
                string vicecardnumber = Utils.ObjectToStr(dgv_ViceCardList["c_ViceCardNumber", e.RowIndex].Value);
                DataTable dt = Dal_AssociateCard.GetUseUserName(vicecardnumber);
                if (dt.Rows.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        sb.AppendFormat("{0} ", dt.Rows[i]["CardNumber"]);
                    }
                    dgv_ViceCardList["c_UseUserName", e.RowIndex].Value = sb.ToString();
                }
            }
            catch (Exception ex)
            {
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Enter_Click(object sender, EventArgs e)
        {
            if (_mViceCard.Count + _mAddViceCard.Count > 4)
            {
                MessageBox.Show("副卡最多捆绑 4 张，请重新选择。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Tag = _mAddViceCard;
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Search_Click(object sender, EventArgs e)
        {
            string content = tb_SearchContent.Text.Trim();
            if (content.Length > 0)
            {
                try
                {
                    _isAddRow = true;
                    if (Tab3_Form.SubList != null && Tab3_Form.SubList.Count > 0)
                    {
                        //移除旧的搜索副卡内容
                        for (int i = dgv_ViceCardList.RowCount - 1; i >= Tab3_Form.SubList.Count; i--)
                        {
                            dgv_ViceCardList.Rows.RemoveAt(i);
                        }
                    }
                    else
                    {
                        dgv_ViceCardList.Rows.Clear();
                    }
                    //获取搜索的副卡
                    DataTable dt = Dal_AssociateCard.GetViceCard(content);
                    if (dt.Rows.Count > 0)
                    {
                        //将副卡显示在列表中
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            object vicecardnumber = dt.Rows[i]["ViceCardNumber"];
                            if (Tab3_Form.SubList != null && Tab3_Form.SubList.Count > 0)
                            {
                                if (Tab3_Form.SubList.ContainsKey(vicecardnumber.ToString()))
                                    continue;
                            }
                            //验证当前副卡是否已经存在捆绑列表中
                            bool check = GetViceCardExists(vicecardnumber.ToString());
                            dgv_ViceCardList.Rows.Add(new object[] { check, vicecardnumber, string.Empty });
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
                    _isAddRow = false;
                }
            }
        }

        /// <summary>
        /// 搜索文本在控件具有焦点并且用户按下并释放某个键后发生
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
        /// 搜索文本变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tb_SearchContent_TextChanged(object sender, EventArgs e)
        {
            l_SearchTitle.Visible = tb_SearchContent.TextLength == 0;
        }

        /// <summary>
        /// 搜索文本标题鼠标按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void L_SearchTitle_MouseDown(object sender, MouseEventArgs e)
        {
            tb_SearchContent.Focus();
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BindingViceCard_Form_Load(object sender, EventArgs e)
        {
            _mAddViceCard = new List<CbAssociateCard>();
            if (Tab3_Form.SubList == null) return;
            _isAddRow = true;
            foreach (KeyValuePair<string, ViceCardParam> item in Tab3_Form.SubList)
            {
                bool check = GetViceCardExists(item.Key);
                dgv_ViceCardList.Rows.Add(new object[] { check, item.Key });
            }
            _isAddRow = false;
        }

        /// <summary>
        /// 获取副卡是否已经添加致捆绑列表中
        /// </summary>
        /// <param name="cardnumber"></param>
        /// <returns></returns>
        private bool GetViceCardExists(string cardnumber)
        {
            foreach (CbAssociateCard item in _mViceCard)
            {
                if (item.AssociateCardNumber.Equals(cardnumber))
                    return true;
            }
            foreach (CbAssociateCard item in _mAddViceCard)
            {
                if (item.AssociateCardNumber.Equals(cardnumber))
                    return true;
            }
            return false;
        }

    }
}
