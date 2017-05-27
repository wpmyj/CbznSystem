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
    public partial class ManageLog_Form : Form
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
                    DataTable dt = Dbhelper.Db.ToTable<CbManageLog>(_CurrentPage - 1, 30);
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


        public ManageLog_Form()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(240, 243, 245);

            this.Resize += ManageLog_Form_Resize;
            this.Load += ManageLog_Form_Load;
            this.KeyDown += ManageLog_Form_KeyDown;

            btn_ShowRecord.Click += Btn_ShowRecord_Click;
            btn_Print.Click += Btn_Print_Click;

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
        }

        private void ManageLog_Form_KeyDown(object sender, KeyEventArgs e)
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

        private void Btn_Print_Click(object sender, EventArgs e)
        {
            new DGVPrinter
            {
                Title = "操作日志",
                PageNumbers = true,
                PageNumberInHeader = false,
                PorportionalColumns = true,
                HeaderCellAlignment = StringAlignment.Near,
                FooterSpacing = 15f
            }.PrintDataGridView(dgv_RecordList);
        }

        private void Btn_ShowRecord_Click(object sender, EventArgs e)
        {
            GetRecordCount();
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

        private void DelayShowRecord()
        {
            Thread.Sleep(150);
            this.Invoke(new EventHandler(delegate
            {
                GetRecordCount();
            }));
        }

        private void ManageLog_Form_Load(object sender, EventArgs e)
        {
            Thread tDelayShowRecord = new Thread(DelayShowRecord);
            tDelayShowRecord.IsBackground = true;
            tDelayShowRecord.Start();
        }

        private void GetRecordCount()
        {
            int count = Dbhelper.Db.GetCount<CbManageLog>("ID");
            PageCount = FormComm.GetPage(count, 30, l_PageTitle);
            CurrentPage = 1;
        }

        private void ManageLog_Form_Resize(object sender, EventArgs e)
        {
            dgv_RecordList.Columns["Explains"].Width = this.Width - 320;
        }

        private static ManageLog_Form _uniqueInstance;

        public static ManageLog_Form GetInstance
        {
            get { return _uniqueInstance ?? (_uniqueInstance = new ManageLog_Form()); }
        }

    }
}
