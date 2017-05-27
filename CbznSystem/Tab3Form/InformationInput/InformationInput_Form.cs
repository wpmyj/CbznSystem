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
    public partial class InformationInput_Form : NewForm
    {
        private int PageCount;

        private int _CurrentPage;

        public int CurrentPage
        {
            get { return _CurrentPage; }
            set
            {
                _CurrentPage = value;

                tb_Page.Text = _CurrentPage.ToString();
                btn_FirstPage.Enabled = btn_PreviousPage.Enabled = _CurrentPage > 1;
                btn_NextPage.Enabled = btn_LastPage.Enabled = _CurrentPage < PageCount;

                try
                {
                    string strwhere = GetSearchWhere();
                    DataTable dt = Dbhelper.Db.ToTable<CbCardInfo>(_CurrentPage - 1, 30, strwhere);
                    dgv_InfoList.DataSource = dt;
                    dgv_InfoList.Focus();
                }
                catch (Exception ex)
                {
                    CustomExceptionHandler.GetExceptionMessage(ex);
                    MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public InformationInput_Form()
        {
            InitializeComponent();

            this.Load += InformationInput_Form_Load;

            btn_Add.Click += Btn_Add_Click;
            btn_Add.Paint += FormComm.DrawBtnEnabled;
            btn_Edit.Click += Btn_Edit_Click;
            btn_Edit.Paint += FormComm.DrawBtnEnabled;
            btn_Del.Click += Btn_Del_Click;
            btn_Del.Paint += FormComm.DrawBtnEnabled;
            btn_ShowRecord.Click += Btn_ShowRecord_Click;

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

            dgv_InfoList.Paint += dgv_InfoList_Paint;
            dgv_InfoList.CellFormatting += Dgv_InfoList_CellFormatting;
            dgv_InfoList.RowsAdded += Dgv_InfoList_RowsAdded;
            dgv_InfoList.RowsRemoved += Dgv_InfoList_RowsRemoved;
            dgv_InfoList.CellDoubleClick += Dgv_InfoList_CellDoubleClick;
        }

        private void Dgv_InfoList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btn_Edit.Enabled)
                Btn_Edit_Click(null, null);
        }

        private void Dgv_InfoList_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dgv_InfoList.RowCount == 0)
            {
                btn_Edit.Enabled = false;
                btn_Del.Enabled = false;
            }
        }

        private void Dgv_InfoList_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            btn_Edit.Enabled = Dal_ManageRights.ManageRights.InforMationEntryEditing;
            btn_Del.Enabled = Dal_ManageRights.ManageRights.InformationEntryAndDeletion;
        }

        private void Btn_ShowRecord_Click(object sender, EventArgs e)
        {
            GetRecordCount();
        }

        private void Btn_Del_Click(object sender, EventArgs e)
        {
            int index = 0;
            CbCardInfo mCardInfo = FormComm.GetDataSourceToClass<CbCardInfo>(dgv_InfoList, ref index);
            if (MessageBox.Show("确认删除用户：" + mCardInfo.UserName + " 的信息吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK) return;
            try
            {
                Dbhelper.Db.Del<CbCardInfo>(mCardInfo.ID);
                GetRecordCount();
                //DataTable dt = dgv_InfoList.DataSource as DataTable;
                //dt.Rows.RemoveAt(index);
            }
            catch (Exception ex)
            {
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Edit_Click(object sender, EventArgs e)
        {
            int index = 0;
            CbCardInfo mCardInfo = FormComm.GetDataSourceToClass<CbCardInfo>(dgv_InfoList, ref index);
            using (EditInfo_Form edit = new EditInfo_Form(mCardInfo))
            {
                if (edit.ShowDialog() != DialogResult.OK) return;
                mCardInfo = edit.Tag as CbCardInfo;
                FormComm.UpdateDgvDataSource<CbCardInfo>(mCardInfo, dgv_InfoList, index);
            }
        }

        private void Btn_Add_Click(object sender, EventArgs e)
        {
            using (AddInfo_Form add = new AddInfo_Form())
            {
                if (add.ShowDialog() != DialogResult.OK) return;
                GetRecordCount();
                //CbCardInfo mCardInfo = add.Tag as CbCardInfo;
                //FormComm.AddDgvSource<CbCardInfo>(mCardInfo, dgv_InfoList);
            }
        }

        private void Dgv_InfoList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            switch (dgv_InfoList.Columns[e.ColumnIndex].Name)
            {
                case "UserSex":
                    if (e.Value.Equals(0))
                    {
                        e.Value = "男";
                    }
                    else if (e.Value.Equals("1"))
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

        private void Btn_Search_Click(object sender, EventArgs e)
        {
            GetRecordCount();
        }

        private string GetSearchWhere()
        {
            string content = tb_SearchContent.Text.Trim();
            StringBuilder sb = new StringBuilder();
            sb.Append(" and CardNumber ='' ");
            if (content.Length > 0)
            {
                sb.AppendFormat(" and ( UserName like '%{0}%' or PlateNumber like '%{0}%' ) ", content);
            }
            return sb.ToString();
        }

        private void GetRecordCount()
        {
            try
            {
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

        private void Tb_SearchContent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Btn_Search_Click(null, null);
            }
        }

        private void Tb_SearchContent_TextChanged(object sender, EventArgs e)
        {
            l_SearchTitle.Visible = tb_SearchContent.TextLength == 0;
        }

        private void L_SearchTitle_MouseDown(object sender, MouseEventArgs e)
        {
            tb_SearchContent.Focus();
        }

        private void Btn_LastPage_Click(object sender, EventArgs e)
        {
            CurrentPage = PageCount;
        }

        private void Btn_NextPage_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
        }

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

        private void Btn_PreviousPage_Click(object sender, EventArgs e)
        {
            CurrentPage -= 1;
        }

        private void Btn_FirstPage_Click(object sender, EventArgs e)
        {
            CurrentPage = 1;
        }

        private void dgv_InfoList_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawLine(new Pen(dgv_InfoList.GridColor, 1), 0, 0, dgv_InfoList.Width, 0);
        }

        private void P_Bottom_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                g.DrawLine(new Pen(dgv_InfoList.GridColor, 1), 0, 0, p_Bottom.Width, 0);
            }
        }

        private void InformationInput_Form_Load(object sender, EventArgs e)
        {
            btn_Add.Enabled = Dal_ManageRights.ManageRights.InforMationEntryToAdd;

            Thread tDelayShowInfo = new Thread(DelayShowInfo);
            tDelayShowInfo.IsBackground = true;
            tDelayShowInfo.Start();
        }

        private void DelayShowInfo()
        {
            Thread.Sleep(150);

            this.Invoke(new EventHandler(delegate
            {
                GetRecordCount();
            }));
        }
    }
}
