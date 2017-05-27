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

namespace CbznSystem
{
    public partial class ExportChargeRecord_Form : NewForm
    {
        private string _ExportFileAddress;
        private string _strWhere;
        private Thread tExportRecord;
        private List<CbDeviceInfo> _mDeviceInfos;
        private CbDeviceInfo _mDeviceInfo;

        public ExportChargeRecord_Form(string fileaddress, string where)
        {
            InitializeComponent();

            _ExportFileAddress = fileaddress;
            _strWhere = where;

            this.Load += ExportChargeRecord_Form_Load;
            this.FormClosing += ExportChargeRecord_Form_FormClosing;
            cb_ExitNumber.SelectedIndexChanged += Cb_ExitNumber_SelectedIndexChanged;
            btn_Next.Paint += FormComm.DrawBtnEnabled;
            btn_Next.Click += Btn_Next_Click;
        }

        private void Btn_Next_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateExitNumber(cb_ExitNumber.SelectedIndex - 1);
                cb_ExitNumber.Visible = false;
                btn_Next.Visible = false;
                pBar.Visible = true;
                StartExport();
            }
            catch (Exception ex)
            {
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cb_ExitNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_ExitNumber.SelectedIndex > 0)
            {
                btn_Next.Enabled = true;
            }
            else
            {
                btn_Next.Enabled = false;
            }
        }

        private void ExportChargeRecord_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tExportRecord != null)
            {
                if (MessageBox.Show("确认是否退出当前操作。", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
                {
                    return;
                }
                tExportRecord?.Abort();
                tExportRecord = null;
            }
        }

        private void ExportChargeRecord_Form_Load(object sender, EventArgs e)
        {

            try
            {
                _mDeviceInfos = Dbhelper.Db.ToList<CbDeviceInfo>(" and IOSate = 1 ");
                if (_mDeviceInfos.Count > 1)
                {
                    cb_ExitNumber.Visible = true;
                    btn_Next.Visible = true;
                    pBar.Visible = false;
                    cb_ExitNumber.Items.Add("请选择");
                    foreach (CbDeviceInfo item in _mDeviceInfos)
                    {
                        cb_ExitNumber.Items.Add(item.HostNumber);
                    }
                    cb_ExitNumber.SelectedIndex = 0;
                }
                else
                {
                    UpdateExitNumber(0);
                    StartExport();
                }
            }
            catch (Exception ex)
            {
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StartExport()
        {
            l_Title.Text = "正在导出记录，请稍后···";
            tExportRecord = new Thread(ExportRecord);
            tExportRecord.IsBackground = true;
            tExportRecord.Start();
        }

        private void UpdateExitNumber(int index)
        {
            _mDeviceInfo = _mDeviceInfos[index];
            string cmdtext = string.Format(" Update CBTempChargeRecord set ExitNumber={0} where ExitNumber=0 ", _mDeviceInfo.HostNumber);
            Dbhelper.Db.ExecuteNonQuery(cmdtext);
            _mDeviceInfos = null;
        }

        private void ExportRecord()
        {
            try
            {
                string savepath = string.Format("{0}\\出口{1}收费记录.xls", _ExportFileAddress, _mDeviceInfo.HostNumber);
                DataTable dt = Dbhelper.Db.ToTable<CbTempChargeRecord>(_strWhere);
                ExcelHandler excel = new ExcelHandler();
                excel.RenderDataTableToExcel(dt, "收费记录", savepath);
            }
            catch (Exception ex)
            {
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                tExportRecord = null;
                Close();
            }
        }
    }
}
