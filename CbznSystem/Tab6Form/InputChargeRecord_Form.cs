using System.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NewControl;
using Bll;
using Model;
using Dal;
using System.Threading;

namespace CbznSystem
{
    public partial class InputChargeRecord_Form : NewForm
    {
        private string[] fileNames;
        private Thread tInputRecord;

        public InputChargeRecord_Form(string[] fileNames)
        {
            InitializeComponent();

            this.fileNames = fileNames;

            this.Load += InputChargeRecord_Form_Load;
            this.FormClosing += InputChargeRecord_Form_FormClosing;

            btn_Cenal.Click += btn_Cenal_Click;
        }

        private void InputChargeRecord_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tInputRecord != null)
            {
                if (MessageBox.Show("确认退出当前操作", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
                {
                    e.Cancel = true;
                    return;
                }
            }
            tInputRecord = null;
        }

        private void btn_Cenal_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void InputChargeRecord_Form_Load(object sender, EventArgs e)
        {
            pBar.Maximum = fileNames.Length;

            tInputRecord = new Thread(InputChargeReord);
            tInputRecord.IsBackground = true;
            tInputRecord.Start();
        }

        private void InputChargeReord()
        {
            try
            {
                ExcelHandler excel = new ExcelHandler();
                byte[] by;
                foreach (string item in fileNames)
                {
                    if (!File.Exists(item)) return;
                    using (FileStream fs = new FileStream(item, FileMode.Open, FileAccess.Read))
                    {
                        by = new byte[fs.Length];
                        fs.Read(by, 0, by.Length);
                        fs.Close();
                    }
                    DataTable dt = excel.RenderDataTableFromExcel(new MemoryStream(by), "Sheet0", 1, true);
                    if (dt.Rows.Count > 0)
                    {
                        Dbhelper.Db.Insert<CbTempChargeRecord>(dt);
                    }
                    pBar.PerformStep();
                }
                tInputRecord = null;
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tInputRecord = null;
                Close();
            }
        }
    }
}
