using System.Threading;
using Dal;
using Model;
using Bll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CbznSystem
{
    /// <summary>
    /// 管理员设置
    /// </summary>
    public partial class ManagerSettings_Form : Form
    {

        public ManagerSettings_Form()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(240, 243, 245);

            this.Load += ManagerSettings_Form_Load;
            this.KeyDown += ManagerSettings_Form_KeyDown;

            btn_Add.Click += Btn_Add_Click;
            btn_Add.Paint += FormComm.DrawBtnEnabled;
            btn_Edit.Click += Btn_Edit_Click;
            btn_Edit.Paint += FormComm.DrawBtnEnabled;
            btn_Del.Click += Btn_Del_Click;
            btn_Del.Paint += FormComm.DrawBtnEnabled;
            btn_Jurisdiction.Click += Btn_Jurisdiction_Click;
            btn_Jurisdiction.Paint += FormComm.DrawBtnEnabled;
            btn_ChangePassword.Click += Btn_ChangePassword_Click;
            btn_ChangePassword.Paint += FormComm.DrawBtnEnabled;

            dgv_ManageList.RowsAdded += Dgv_ManageList_RowsAdded;
            dgv_ManageList.RowsRemoved += Dgv_ManageList_RowsRemoved;
            dgv_ManageList.SelectionChanged += Dgv_ManageList_SelectionChanged;
            dgv_ManageList.CellFormatting += Dgv_ManageList_CellFormatting;
        }

        private void ManagerSettings_Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4 && e.Alt)
            {
                e.Handled = true;
            }
        }

        private void Dgv_ManageList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv_ManageList.Columns[e.ColumnIndex].Name == "ManageType")
            {
                e.Value = e.Value.Equals(0) ? "超级管理员" : "管理员";
            }
        }

        private void Btn_ChangePassword_Click(object sender, EventArgs e)
        {
            int index = 0;
            CbManageInfo mManageInfo = FormComm.GetDataSourceToClass<CbManageInfo>(dgv_ManageList, ref index);
            using (ChangePassword_Form changepassword = new ChangePassword_Form(mManageInfo))
            {
                if (changepassword.ShowDialog() != DialogResult.OK) return;
                mManageInfo = changepassword.Tag as CbManageInfo;
                FormComm.UpdateDgvDataSource<CbManageInfo>(mManageInfo, dgv_ManageList, index);
            }
        }

        private void Dgv_ManageList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_ManageList.SelectedRows.Count == 0) return;
            int index = 0;
            CbManageInfo mManageInfo = FormComm.GetDataSourceToClass<CbManageInfo>(dgv_ManageList, ref index);
            if (mManageInfo.ManageType == 0)
            {
                btn_Del.Enabled = false;
                btn_Edit.Enabled = false;
                btn_ChangePassword.Enabled = Dal_ManageInfo.ManageInfo.ManageType == 0;
                btn_Jurisdiction.Enabled = false;
            }
            else if (mManageInfo.ID == Dal_ManageInfo.ManageInfo.ID)
            {
                btn_Del.Enabled = false;
                btn_ChangePassword.Enabled = true;
                btn_Edit.Enabled = true;
                btn_Jurisdiction.Enabled = false;
            }
            else
            {
                btn_Del.Enabled = Dal_ManageRights.ManageRights.SetUserManagementToDelete;
                btn_Edit.Enabled = Dal_ManageRights.ManageRights.SetUserManagemenetEditor;
                btn_ChangePassword.Enabled = Dal_ManageInfo.ManageInfo.ManageType == 0;
                btn_Jurisdiction.Enabled = Dal_ManageRights.ManageRights.SetUserAdministrationRights;
            }
        }

        private void Btn_Jurisdiction_Click(object sender, EventArgs e)
        {
            int index = 0;
            CbManageInfo mManageInfo = FormComm.GetDataSourceToClass<CbManageInfo>(dgv_ManageList, ref index);
            using (JurisdictionSettings_Form jurisdiction = new JurisdictionSettings_Form(mManageInfo))
            {
                if (jurisdiction.ShowDialog() != DialogResult.OK) return;
                GetManageInfo();
                dgv_ManageList.Rows[index].Selected = true;
            }
        }

        private void Btn_Del_Click(object sender, EventArgs e)
        {
            int index = 0;
            CbManageInfo mManageInfo = FormComm.GetDataSourceToClass<CbManageInfo>(dgv_ManageList, ref index);
            if (MessageBox.Show("确认删除管理员：" + mManageInfo.UserName + "", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK) return;
            try
            {
                Dbhelper.Db.Del<CbManageInfo>(mManageInfo.ID);
                Dbhelper.Db.Del<CbManageRights>(" and UserID=" + mManageInfo.ID);
                DataTable dt = dgv_ManageList.DataSource as DataTable;
                dt.Rows.RemoveAt(index);
                dgv_ManageList.Rows[0].Selected = true;
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
            CbManageInfo mManageInfo = FormComm.GetDataSourceToClass<CbManageInfo>(dgv_ManageList, ref index);
            using (EditManager_Form editmanage = new EditManager_Form(mManageInfo))
            {
                if (editmanage.ShowDialog() != DialogResult.OK) return;
                mManageInfo = editmanage.Tag as CbManageInfo;
                FormComm.UpdateDgvDataSource<CbManageInfo>(mManageInfo, dgv_ManageList, index);
            }
        }

        private void Btn_Add_Click(object sender, EventArgs e)
        {
            using (AddManager_Form addmanage = new AddManager_Form())
            {
                if (addmanage.ShowDialog() != DialogResult.OK) return;
                GetManageInfo();
            }
        }

        private void Dgv_ManageList_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dgv_ManageList.RowCount == 0)
            {
                btn_Edit.Enabled = false;
                btn_Del.Enabled = false;
                btn_Jurisdiction.Enabled = false;
                btn_ChangePassword.Enabled = false;
            }
        }

        private void Dgv_ManageList_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //btn_Edit.Enabled = true;
            //btn_Del.Enabled = true;
            //btn_Jurisdiction.Enabled = true;
        }

        private void GetManageInfo()
        {
            try
            {
                DataTable dt = Dal_ManageInfo.GetManageAndRights();
                dt.Columns.Remove("ID1");
                dt.Columns.Remove("UserID");
                dgv_ManageList.DataSource = dt;
                dgv_ManageList.Focus();
            }
            catch (Exception ex)
            {
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ManagerSettings_Form_Load(object sender, EventArgs e)
        {
            btn_Add.Enabled = Dal_ManageRights.ManageRights.SetUserManagementToAdd;

            Thread tDelayShowData = new Thread(DelayShowData);
            tDelayShowData.IsBackground = true;
            tDelayShowData.Start();
        }

        private void DelayShowData()
        {
            Thread.Sleep(150);
            this.Invoke(new EventHandler(delegate
            {
                GetManageInfo();
            }));
        }

        private static ManagerSettings_Form _uniqueInstance;

        public static ManagerSettings_Form GetInstance
        {
            get { return _uniqueInstance ?? (_uniqueInstance = new ManagerSettings_Form()); }
        }

    }
}
