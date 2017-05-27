using System.Threading;
using Bll;
using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CbznSystem
{
    public partial class EnterExitRecord_Form : Form
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
                btn_NextPage.Enabled = btn_LastPage.Enabled = _CurrentPage < PageCount;
                btn_PreviousPage.Enabled = btn_FirstPage.Enabled = _CurrentPage > 1;

                try
                {
                    string where = GetSearchCountent();
                    DataTable dt = Dbhelper.Db.ToTable<CbIoRecord>(_CurrentPage - 1, 30, where);
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


        public EnterExitRecord_Form()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(240, 243, 245);

            this.Load += EnterExitRecord_Form_Load;
            this.KeyDown += EnterExitRecord_Form_KeyDown;

            dt_StartTime.ValueChanged += Dt_StartTime_ValueChanged;
            dt_StopTime.ValueChanged += Dt_StopTime_ValueChanged;
            l_SearchTitle.MouseDown += L_SearchTitle_MouseDown;
            tb_SearchContent.TextChanged += Tb_SearchContent_TextChanged;
            tb_SearchContent.KeyPress += Tb_SearchContent_KeyPress;
            btn_Search.Click += Btn_Search_Click;


            p_Bottom.Paint += p_Bottom_Paint;
            btn_FirstPage.Click += Btn_FirstPage_Click;
            btn_FirstPage.Paint += FormComm.DrawBtnEnabled;
            btn_PreviousPage.Click += Btn_PreviousPage_Click;
            btn_PreviousPage.Paint += FormComm.DrawBtnEnabled;
            tb_Page.KeyPress += Tb_Page_KeyPress;
            btn_NextPage.Click += Btn_NextPage_Click;
            btn_NextPage.Paint += FormComm.DrawBtnEnabled;
            btn_LastPage.Click += Btn_LastPage_Click;
            btn_LastPage.Paint += FormComm.DrawBtnEnabled;

            btn_ShowRecord.Click += Btn_ShowRecord_Click;
            btn_Input.Click += Btn_Input_Click;
            btn_Print.Click += Btn_Print_Click;

            dgv_RecordList.CellFormatting += Dgv_RecordList_CellFormatting;
            dgv_RecordList.Paint += Dgv_RecordList_Paint;
        }

        private void EnterExitRecord_Form_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.F4 && e.Alt)
            {
                e.Handled = true;
            }
        }

        private void p_Bottom_Paint(object sender, PaintEventArgs e)
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

        private void Dgv_RecordList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv_RecordList.Columns["IOState"].Index == e.ColumnIndex)
            {
                bool flag = Utils.StrToBool(dgv_RecordList["IOState", e.RowIndex].Value, false);
                e.Value = flag ? "出口" : "入口";
            }
        }

        private void Btn_Print_Click(object sender, EventArgs e)
        {
            new DGVPrinter
            {
                Title = "进出记录",
                PageNumbers = true,
                PageNumberInHeader = false,
                PorportionalColumns = true,
                HeaderCellAlignment = StringAlignment.Near,
                FooterSpacing = 15f
            }.PrintDataGridView(dgv_RecordList);
        }

        private void Btn_Input_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Multiselect = true;
            openfile.Filter = "文本文件|*.txt";
            if (openfile.ShowDialog() != DialogResult.OK) return;
            using (InputEnterExitRecord_Form input = new InputEnterExitRecord_Form(openfile.FileNames))
            {
                if (input.ShowDialog() != DialogResult.OK) return;
                GetRecordCount();
            }
        }

        private void Btn_ShowRecord_Click(object sender, EventArgs e)
        {
            GetRecordCount();
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

        private string GetSearchCountent()
        {
            StringBuilder sb = new StringBuilder();
            DateTime now = DateTime.Now;
            DateTime start = dt_StartTime.Value;
            DateTime stop = dt_StopTime.Value;
            string content = tb_SearchContent.Text.Trim();
            if (start.Date != now.Date || stop.Date != now.Date)
            {
                stop.AddDays(1);
                sb.AppendFormat(" and IOTime >= '{0:yyyy-MM-dd}' and IOTime < '{1:yyyy-MM-dd}' ", start, stop);
            }
            if (content.Length != 0)
            {
                sb.AppendFormat(" and ( MasterCardNumber like '%{0}%' or SubCardNumber like '%{0}%' ) ", content);
            }
            return sb.ToString();
        }

        private void GetRecordCount()
        {
            string where = GetSearchCountent();
            int count = Dbhelper.Db.GetCount<CbIoRecord>("ID", where);
            PageCount = FormComm.GetPage(count, 30, l_PageTitle);
            CurrentPage = 1;
        }

        private void EnterExitRecord_Form_Load(object sender, EventArgs e)
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

        private static EnterExitRecord_Form _uniqueInstance;

        public static EnterExitRecord_Form GetInstance
        {
            get { return _uniqueInstance ?? (_uniqueInstance = new EnterExitRecord_Form()); }
        }

    }
}
