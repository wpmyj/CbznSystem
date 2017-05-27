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
using System.Threading;
using Db_Rom;

namespace CbznSystem
{
    public partial class ChargeRecord_Form : Form
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
                    string where = GetSearchWhere();
                    DataTable dt = Dbhelper.Db.ToTable<CbTempChargeRecord>(_CurrentPage - 1, 30, where);
                    dgv_RecordList.DataSource = dt;
                    dgv_RecordList.Focus();
                }
                catch (Exception ex)
                {
                    CustomExceptionHandler.GetExceptionMessage(ex);
                    MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        public ChargeRecord_Form()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(240, 243, 245);

            this.Load += ChargeRecord_Form_Load;
            this.Resize += ChargeRecord_Form_Resize;
            this.KeyDown += ChargeRecord_Form_KeyDown;

            btn_ShowRecord.Click += Btn_ShowRecord_Click;
            btn_Export.Click += Btn_Export_Click;
            btn_Input.Click += Btn_Input_Click;
            btn_Print.Click += Btn_Print_Click;

            dt_StartTime.ValueChanged += Dt_StartTime_ValueChanged;
            dt_StopTime.ValueChanged += Dt_StopTime_ValueChanged;
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

            dgv_RecordList.RowsAdded += Dgv_RecordList_RowsAdded;
            dgv_RecordList.Paint += Dgv_RecordList_Paint;
        }

        private void ChargeRecord_Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4 && e.Alt)
            {
                e.Handled = true;
            }
        }

        private void P_Bottom_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                g.DrawLine(new Pen(dgv_RecordList.GridColor, 1), 0, 0, p_Bottom.Width, 0);
            }
        }

        private void Dgv_RecordList_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawLine(new Pen(dgv_RecordList.GridColor, 1), 0, 0, dgv_RecordList.Width, 0);
        }

        private void Tb_SearchContent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                GetRecordCount();
            }
        }

        private void Dt_StopTime_ValueChanged(object sender, EventArgs e)
        {
            GetRecordCount();
        }

        private void Dt_StartTime_ValueChanged(object sender, EventArgs e)
        {
            GetRecordCount();
        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {
            GetRecordCount();
        }

        private void Tb_SearchContent_TextChanged(object sender, EventArgs e)
        {
            l_SearchTitle.Visible = tb_SearchContent.TextLength == 0;
        }

        private void L_SearchTitle_MouseDown(object sender, MouseEventArgs e)
        {
            tb_SearchContent.Focus();
        }

        private void ChargeRecord_Form_Resize(object sender, EventArgs e)
        {
            l_StatisticsPage.Left = this.Width / 2;
        }

        private void Dgv_RecordList_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataTable dt = dgv_RecordList.DataSource as DataTable;
            if (dt == null) return;
            double charges = 0, paidinamount = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                charges += Convert.ToDouble(dt.Rows[i]["ChargeAmount"]);
                if (dt.Rows[i]["ActualAmount"] != DBNull.Value)
                    paidinamount += Convert.ToDouble(dt.Rows[i]["ActualAmount"]);
            }
            l_StatisticsPage.Text = string.Format("当前页金额    应收:{0}元      实收:{1}元", charges, paidinamount);
        }

        private void Btn_Input_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Filter = "电子表格|*.xls";
            openfile.Multiselect = true;
            if (openfile.ShowDialog() != DialogResult.OK) return;
            using (InputChargeRecord_Form input = new InputChargeRecord_Form(openfile.FileNames))
            {
                if (input.ShowDialog() != DialogResult.OK) return;
                GetRecordCount();
            }
        }

        private void Btn_Export_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() != DialogResult.OK) return;
            string where = GetSearchWhere();
            using (ExportChargeRecord_Form export = new ExportChargeRecord_Form(folder.SelectedPath, where))
            {
                export.ShowDialog();
            }
        }

        private void Btn_ShowRecord_Click(object sender, EventArgs e)
        {
            GetRecordCount();
        }

        private void Btn_Print_Click(object sender, EventArgs e)
        {
            new DGVPrinter
            {
                Title = "收费记录",
                PageNumbers = true,
                PageNumberInHeader = false,
                PorportionalColumns = true,
                HeaderCellAlignment = StringAlignment.Near,
                FooterSpacing = 15f
            }.PrintDataGridView(dgv_RecordList);
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

        private void GetRecordCount()
        {
            try
            {
                string where = GetSearchWhere();
                DataTable dt = Dbhelper.Db.GetAggregate<CbTempChargeRecord>(new AggregateFuncion[] {
                 new AggregateFuncion() { AggregateType=AggregateTypes.COUNT, Column="ID", ColumnAlias="RecordCount" },
                 new AggregateFuncion() { AggregateType=AggregateTypes.SUM, Column="ChargeAmount", ColumnAlias="Charges" },
                 new AggregateFuncion() { AggregateType=AggregateTypes.SUM, Column="ActualAmount",ColumnAlias="PaidInAmount" },
                }, where);
                int count = 0;
                double charges = 0, paidinamount = 0;
                object obj = dt.Rows[0]["RecordCount"];
                if (obj != DBNull.Value)
                    count = Convert.ToInt32(obj);
                obj = dt.Rows[0]["Charges"];
                if (obj != DBNull.Value)
                    charges = Convert.ToDouble(obj);
                obj = dt.Rows[0]["PaidInAmount"];
                if (obj != DBNull.Value)
                    paidinamount = Convert.ToDouble(obj);
                l_StatisticsAll.Text = string.Format("总计金额    应收:{0}元      实收:{1}元", charges, paidinamount);
                PageCount = FormComm.GetPage(count, 30, l_PageTitle);
                CurrentPage = 1;
            }
            catch (Exception ex)
            {
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetSearchWhere()
        {
            StringBuilder sb = new StringBuilder();
            DateTime now = DateTime.Now;
            DateTime start = dt_StartTime.Value;
            DateTime stop = dt_StopTime.Value;
            string content = tb_SearchContent.Text.Trim();
            if (start.Date != now.Date || stop.Date != now.Date)
            {
                sb.AppendFormat(" and EntranceTime >='{0:yyyy-MM-dd}' and ExportTime <'{1:yyyy-MM-dd}' ", start, stop);
            }
            if (content.Length != 0)
            {
                sb.AppendFormat(" and ( CardNumber like '%{0}%' or  PlateNumber like '%{0}%' ) ", content);
            }
            return sb.ToString();
        }

        private void ChargeRecord_Form_Load(object sender, EventArgs e)
        {
            Thread tDelayShowRecord = new Thread(DelayShowRecord);
            tDelayShowRecord.IsBackground = true;
            tDelayShowRecord.Start();
        }

        private void DelayShowRecord()
        {
            Thread.Sleep(150);
            this.Invoke(new EventHandler(delegate
            {
                GetRecordCount();
            }));
        }

        private static ChargeRecord_Form _uniqueInstance;

        public static ChargeRecord_Form GetInstance
        {
            get { return _uniqueInstance ?? (_uniqueInstance = new ChargeRecord_Form()); }
        }

    }
}
