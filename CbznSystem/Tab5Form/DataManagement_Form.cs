using Dal;
using Model;
using Bll;
using System.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Threading;

namespace CbznSystem
{
    /// <summary>
    /// 数据管理
    /// </summary>
    public partial class DataManagement_Form : Form
    {

        private delegate void DefaultEventHandler(string recoveryaddress);

        public DataManagement_Form()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(240, 243, 245);

            this.Load += DataManagement_Form_Load;
            this.KeyDown += DataManagement_Form_KeyDown;

            cb_EnterExitRecord.CheckedChanged += Cb_EnterExitRecord_CheckedChanged;
            cb_ChargeReocrd.CheckedChanged += Cb_ChargeReocrd_CheckedChanged;

            btn_SelectAddress.Click += Btn_SelectAddress_Click;
            btn_SelectAddress.Paint += FormComm.DrawBtnEnabled;
            btn_SelectFile.Click += Btn_SelectFile_Click;
            btn_SelectFile.Paint += FormComm.DrawBtnEnabled;
            btn_Backups.Click += Btn_Backups_Click;
            btn_Backups.Paint += FormComm.DrawBtnEnabled;
            btn_Recovery.Click += Btn_Recovery_Click;
            btn_Recovery.Paint += FormComm.DrawBtnEnabled;
            btn_Delete.Click += Btn_Delete_Click;
            btn_Delete.Paint += FormComm.DrawBtnEnabled;
        }

        private void GetDelRecord()
        {
            if (cb_ChargeReocrd.Checked)
            {
                btn_Delete.Enabled = Dal_ManageRights.ManageRights.SetDataManagementClear;
            }
            else if (cb_EnterExitRecord.Checked)
            {
                btn_Delete.Enabled = Dal_ManageRights.ManageRights.SetDataManagementClear;
            }
            else
            {
                btn_Delete.Enabled = false;
            }
        }

        private void Cb_ChargeReocrd_CheckedChanged(object sender, EventArgs e)
        {
            GetDelRecord();
        }

        private void Cb_EnterExitRecord_CheckedChanged(object sender, EventArgs e)
        {
            GetDelRecord();
        }

        private void DataManagement_Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4 && e.Alt)
            {
                e.Handled = true;
            }
        }

        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            switch (cb_TimeSlot.SelectedIndex)
            {
                case 1:
                    now = now.AddMonths(-1);
                    break;
                case 2:
                    now = now.AddMonths(-3);
                    break;
                case 3:
                    now = now.AddMonths(-6);
                    break;
                case 4:
                    now = now.AddMonths(-12);
                    break;
            }
            try
            {
                btn_Delete.Enabled = false;

                StringBuilder sb = new StringBuilder();
                if (cb_EnterExitRecord.Checked)
                {
                    Dbhelper.Db.Del<CbIoRecord>(string.Format(" and IOTime < '{0:yyyy-MM-dd}' ", now));
                    sb.Append("  Vacuum CbIoRecord ; ");
                }
                if (cb_ChargeReocrd.Checked)
                {
                    Dbhelper.Db.Del<CbTempChargeRecord>(string.Format(" and ExportTime < '{0:yyyy-MM-dd}' ", now));
                    sb.Append("  Vacuum CbTempChargeRecord ; ");
                }
                if (cb_DelayRecord.Checked)
                {
                    Dbhelper.Db.Del<CbLprDelayRecord>(string.Format(" and RecordTime < '{0:yyyy-MM-dd}' ", now));
                    sb.Append("  Vacuum CbLprDelayRecord ; ");
                }
                //Dbhelper.Db.Del<CbManageLog>(string.Format(" and LogTime < '{0:yyyy-MM-dd}' ", now));

                if (Dal_SysSettings.SystemSettings.RemoteConnection == 0)
                {
                    //sb.Append(" Vacuum CbManageLog ");
                    Dbhelper.Db.ExecuteNonQuery(sb.ToString());
                }
                btn_Delete.Enabled = true;
            }
            catch (Exception ex)
            {
                CustomExceptionHandler.GetExceptionMessage(ex);
                btn_Delete.Enabled = true;
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Recovery_Click(object sender, EventArgs e)
        {
            string fileaddress = tb_RecoveryAddress.Text.Trim();

            btn_Recovery.Enabled = false;

            DefaultEventHandler deh = Recovery;
            deh.BeginInvoke(fileaddress, null, null);
        }

        private void Recovery(string recoveryaddress)
        {
            string dbaddress = string.Format(@"{0}\Data\Mtc.db", Application.StartupPath);

            do
            {
                Thread.Sleep(1000);
            } while (IsFileInUse(dbaddress));
            FileHelper.CopyFile(recoveryaddress, dbaddress);
            MessageBox.Show("数据库恢复成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.None);

            Thread.Sleep(5000);

            btn_Recovery.Enabled = true;
        }

        public bool IsFileInUse(string fileName)
        {
            bool inUse = true;
            if (File.Exists(fileName))
            {
                FileStream fs = null;
                try
                {
                    fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None);
                    inUse = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message.ToString());
                }
                finally
                {
                    if (fs != null)
                    {
                        fs.Close();
                    }
                }
                return inUse;           //true表示正在使用,false没有使用
            }
            else
            {
                return false;           //文件不存在则一定没有被使用
            }
        }

        private void Btn_Backups_Click(object sender, EventArgs e)
        {
            string backupsdirectory = tb_BackupsAddress.Text.Trim();
            if (backupsdirectory.Length == 0)
            {
                FolderBrowserDialog folder = new FolderBrowserDialog();
                if (folder.ShowDialog() != DialogResult.OK) return;
                backupsdirectory = folder.SelectedPath;
            }
            if (!Directory.Exists(backupsdirectory))
            {
                MessageBox.Show("目录不存在，请重新选择目录。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string backupsaddress = string.Format(@"{0}\{1}.db", backupsdirectory, DateTime.Now.ToString("yyyyMMddHHmmssff"));
            try
            {
                btn_Backups.Enabled = false;

                //FileHelper.CopyFile(fileaddress, newfileaddress);
                Dbhelper.Backups(backupsaddress);

                Thread tDelayShowBtn = new Thread(DelayShowBackupsBtn);
                tDelayShowBtn.IsBackground = true;
                tDelayShowBtn.Start();

                if (backupsdirectory != Dal_SysSettings.SystemSettings.BackupsAddress)
                {
                    Dal_SysSettings.SystemSettings.BackupsAddress = backupsdirectory;
                    XmlHelper.Update<CbSysSettings>(Dal_SysSettings.SystemSettings);
                }
                MessageBox.Show("数据库备份完成。", "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            catch (Exception ex)
            {
                CustomExceptionHandler.GetExceptionMessage(ex);
                btn_Backups.Enabled = true;
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DelayShowBackupsBtn()
        {
            Thread.Sleep(5000);

            btn_Backups.Enabled = true;
        }

        private void Btn_SelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Multiselect = false;
            openfile.Filter = "数据库文件|*.db";
            if (openfile.ShowDialog() != DialogResult.OK) return;
            tb_RecoveryAddress.Text = openfile.FileName;
        }

        private void Btn_SelectAddress_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() != DialogResult.OK) return;
            tb_BackupsAddress.Text = folder.SelectedPath;
        }

        private void DataManagement_Form_Load(object sender, EventArgs e)
        {
            cb_TimeSlot.SelectedIndex = 2;

            if (Dal_SysSettings.SystemSettings.RemoteConnection == 0)
            {
                tb_BackupsAddress.Text = Dal_SysSettings.SystemSettings.BackupsAddress;
                btn_Backups.Enabled = Dal_ManageRights.ManageRights.SetDataManagementBackup;
                btn_Recovery.Enabled = Dal_ManageRights.ManageRights.SetDataManagementRecovery;
            }
            else
            {
                tb_BackupsAddress.Enabled = false;
                btn_SelectAddress.Enabled = false;
                btn_Backups.Enabled = false;

                tb_RecoveryAddress.Enabled = false;
                btn_SelectFile.Enabled = false;
                btn_Recovery.Enabled = false;
            }
            //btn_Delete.Enabled = Dal_ManageRights.ManageRights.SetDataManagementClear;
        }

        private static DataManagement_Form _uniqueInstance;

        public static DataManagement_Form GetInstance
        {
            get { return _uniqueInstance ?? (_uniqueInstance = new DataManagement_Form()); }
        }

    }
}
