using System.IO;
using Dal;
using Bll;
using Model;
using System.Threading;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CbznSystem
{
    public partial class Tab2_Form : Form
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
                btn_FirstPage.Enabled = btn_PreviousPage.Enabled = _CurrentPage > 1;

                DataTable dt = Dbhelper.Db.ToTable<CbDeviceInfo>(_CurrentPage - 1, 30);
                dgv_DeviceInfo.DataSource = dt;
                dgv_DeviceInfo.Focus();
            }
        }

        public Tab2_Form()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(240, 243, 245);

            this.Load += Tab2_Form_Load;
            this.FormClosed += Tab2_Form_FormClosed;
            this.KeyDown += Tab2_Form_KeyDown;

            btn_Add.Click += Btn_Add_Click;
            btn_Add.Paint += FormComm.DrawBtnEnabled;
            btn_Edit.Paint += FormComm.DrawBtnEnabled;
            btn_Edit.Click += Btn_Edit_Click;
            btn_Del.Paint += FormComm.DrawBtnEnabled;
            btn_Del.Click += Btn_Del_Click;
            btn_Export.Paint += FormComm.DrawBtnEnabled;
            btn_Export.Click += Btn_Export_Click;
            btn_Input.Click += Btn_Input_Click;
            btn_Input.Paint += FormComm.DrawBtnEnabled;

            p_Bottom.Paint += P_Bottom_Paint;
            btn_FirstPage.Paint += FormComm.DrawBtnEnabled;
            btn_FirstPage.Click += Btn_FirstPage_Click;
            btn_PreviousPage.Paint += FormComm.DrawBtnEnabled;
            btn_PreviousPage.Click += Btn_PreviousPage_Click;
            btn_NextPage.Paint += FormComm.DrawBtnEnabled;
            btn_NextPage.Click += Btn_NextPage_Click;
            btn_LastPage.Paint += FormComm.DrawBtnEnabled;
            btn_LastPage.Click += Btn_LastPage_Click;
            tb_Page.KeyPress += Tb_Page_KeyPress;

            cb_AllSelected.CheckedChanged += Cb_AllSelected_CheckedChanged;
            cb_AllSelected.MouseDown += Cb_AllSelected_MouseDown;

            dgv_DeviceInfo.Paint += Dgv_DeviceInfo_Paint;
            dgv_DeviceInfo.RowsRemoved += Dgv_DeviceInfo_RowsRemoved;
            dgv_DeviceInfo.RowsAdded += Dgv_DeviceInfo_RowsAdded;
            dgv_DeviceInfo.Scroll += Dgv_DeviceInfo_Scroll;
            dgv_DeviceInfo.CellFormatting += Dgv_DeviceInfo_CellFormatting;
            dgv_DeviceInfo.CellValueChanged += Dgv_DeviceInfo_CellValueChanged;
            dgv_DeviceInfo.CurrentCellDirtyStateChanged += Dgv_DeviceInfo_CurrentCellDirtyStateChanged;
            dgv_DeviceInfo.CellMouseDoubleClick += Dgv_DeviceInfo_CellMouseDoubleClick;
        }

        private void Tab2_Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4 && e.Alt)
            {
                e.Handled = true;
            }
        }

        private void Cb_AllSelected_MouseDown(object sender, MouseEventArgs e)
        {
            cb_AllSelected.ThreeState = false;
        }

        private void Dgv_DeviceInfo_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (btn_Edit.Enabled)
                    Btn_Edit_Click(null, null);
            }
        }

        private void Dgv_DeviceInfo_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawLine(new Pen(dgv_DeviceInfo.GridColor, 1), 0, 0, dgv_DeviceInfo.Width, 0);
        }

        private void P_Bottom_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                g.DrawLine(new Pen(dgv_DeviceInfo.GridColor, 1), 0, 0, p_Bottom.Width, 0);
            }
        }

        private void Cb_AllSelected_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_AllSelected.CheckState == CheckState.Indeterminate) return;
            cb_AllSelected.Tag = cb_AllSelected.Checked;
            SetSelectedRows(cb_AllSelected.Checked);
            if (dgv_DeviceInfo.RowCount > 0)
                btn_Export.Enabled = cb_AllSelected.Checked ? Dal_ManageRights.ManageRights.ExportEquipmentCatalog : false;
            cb_AllSelected.Tag = null;
        }

        private void SetSelectedRows(bool flag)
        {
            for (int i = 0; i < dgv_DeviceInfo.RowCount; i++)
            {
                dgv_DeviceInfo["c_Selected", i].Value = flag;
            }
        }

        private void Dgv_DeviceInfo_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgv_DeviceInfo.IsCurrentCellDirty)
                dgv_DeviceInfo.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void Dgv_DeviceInfo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_DeviceInfo.Columns[e.ColumnIndex].Name == "c_Selected")
            {
                if (cb_AllSelected.Tag != null) return;
                cb_AllSelected.ThreeState = true;
                btn_Export.Enabled = GetDataSelected() ? Dal_ManageRights.ManageRights.ExportEquipmentCatalog : false;
            }
        }

        private bool GetDataSelected()
        {
            int count = 0;
            for (int i = 0; i < dgv_DeviceInfo.RowCount; i++)
            {
                bool flag = Utils.StrToBool(dgv_DeviceInfo["c_Selected", i].Value, false);
                if (flag)
                    count++;
            }
            if (count == 0)
                cb_AllSelected.CheckState = CheckState.Unchecked;
            else if (count == dgv_DeviceInfo.RowCount)
                cb_AllSelected.CheckState = CheckState.Checked;
            else
                cb_AllSelected.CheckState = CheckState.Indeterminate;
            return count > 0;
        }

        private void Dgv_DeviceInfo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int index = 0;
            switch (dgv_DeviceInfo.Columns[e.ColumnIndex].Name)
            {
                case "IOSate"://入口出口
                    e.Value = (object.Equals(e.Value, 0) ? "入口" : "出口");
                    break;
                case "DeviceMode"://开闸模式
                    index = Convert.ToInt32(e.Value);
                    switch (index)
                    {
                        case 0:
                            e.Value = "畅泊：串口开闸";
                            break;
                        case 1:
                            e.Value = "畅泊：无线开闸";
                            break;
                        case 2:
                            e.Value = "学习遥控器开闸";
                            break;
                        case 3:
                            e.Value = "继电器开闸";
                            break;
                    }
                    break;
                case "IsLikeMachine":
                    e.Value = (object.Equals(e.Value, 0) ? "无" : "有");
                    break;
                case "FieldPartition":
                    if (object.Equals(e.Value, 0))
                    {
                        e.Value = "关闭";
                    }
                    else
                    {
                        e.Value += " 分区";
                    }
                    break;
                case "AntiSubmarineBack":
                case "VehicleDetection":
                    e.Value = (object.Equals(e.Value, 0) ? "关闭" : "开启");
                    break;
                case "Language":
                    index = Convert.ToInt32(e.Value);
                    switch (index)
                    {
                        case 1:
                            e.Value = "东北话";
                            break;
                        case 2:
                            e.Value = "四川话";
                            break;
                        case 3:
                            e.Value = "河南话";
                            break;
                        case 4:
                            e.Value = "陕西话";
                            break;
                        default:
                            e.Value = "普通话";
                            break;
                    }
                    break;
                case "EquipmentDelay":
                    index = Convert.ToInt32(e.Value);
                    switch (index)
                    {
                        case 0:
                            e.Value = "1 秒";
                            break;
                        case 1:
                            e.Value = "5 秒";
                            break;
                        case 2:
                            e.Value = "10 秒";
                            break;
                        case 3:
                            e.Value = "20 秒";
                            break;
                        case 4:
                            e.Value = "40 秒";
                            break;
                        case 5:
                            e.Value = "80 秒";
                            break;
                        case 6:
                            e.Value = "160 秒";
                            break;
                        case 7:
                            e.Value = "320 秒";
                            break;
                    }
                    break;
                case "Distance":
                    index = Convert.ToInt32(e.Value);
                    switch (index)
                    {
                        case 0:
                            e.Value = "1.2 米";
                            break;
                        case 1:
                            e.Value = "2.3 米";
                            break;
                        case 2:
                            e.Value = "3.8 米";
                            break;
                        case 3:
                            e.Value = "5 米";
                            break;
                    }
                    break;
                case "VagueQueryNumber":
                    if (e.Value.Equals(0))
                    {
                        e.Value = "关闭";
                    }
                    break;
            }
        }

        private void Dgv_DeviceInfo_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                cb_AllSelected.Left = 8 - e.NewValue;
            }
        }

        private void Tb_Page_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string content = tb_Page.Text.Trim();
                int page = 1;
                if (content.Length == 0)
                    page = 1;
                else
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

        private void Btn_LastPage_Click(object sender, EventArgs e)
        {
            CurrentPage = PageCount;
        }

        private void Btn_NextPage_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
        }

        private void Btn_PreviousPage_Click(object sender, EventArgs e)
        {
            CurrentPage -= 1;
        }

        private void Btn_FirstPage_Click(object sender, EventArgs e)
        {
            CurrentPage = 1;
        }

        private void Dgv_DeviceInfo_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            btn_Edit.Enabled = Dal_ManageRights.ManageRights.CatalogEditingEquipment;
            btn_Del.Enabled = Dal_ManageRights.ManageRights.DeleteLoggingEquipment;
        }

        private void Dgv_DeviceInfo_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dgv_DeviceInfo.RowCount == 0)
            {
                btn_Edit.Enabled = false;
                btn_Del.Enabled = false;
            }
        }

        private void Tab2_Form_Load(object sender, EventArgs e)
        {
            btn_Add.Enabled = Dal_ManageRights.ManageRights.AddEquipmentCatalog;
            btn_Input.Enabled = Dal_ManageRights.ManageRights.ImportEquipmentCatalog;

            Thread tDelayShowDeviceInfo = new Thread(DelayShowDeviceInfo);
            tDelayShowDeviceInfo.IsBackground = true;
            tDelayShowDeviceInfo.Start();
        }

        private void DelayShowDeviceInfo()
        {
            Thread.Sleep(150);
            this.Invoke(new EventHandler(delegate
            {
                GetDeviceInfoCount();
            }));
        }

        private void GetDeviceInfoCount()
        {
            int count = Dbhelper.Db.GetCount<CbDeviceInfo>();
            PageCount = FormComm.GetPage(count, 30, l_Description);
            CurrentPage = 1;
        }

        private void Btn_Input_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Multiselect = true;
            openfile.Filter = "文本文件|*.txt";
            openfile.InitialDirectory = GetInitialDirectory();
            if (openfile.ShowDialog() != DialogResult.OK) return;
            InputDeviceInfo_Form inputdeviceinfo = new InputDeviceInfo_Form(openfile.FileNames);
            if (inputdeviceinfo.ShowDialog() == DialogResult.OK)
            {
                GetDeviceInfoCount();
                if (cb_AllSelected.CheckState != CheckState.Unchecked)
                {
                    cb_AllSelected.CheckState = CheckState.Unchecked;
                }
            }
        }

        private string GetInitialDirectory()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo item in drives)
            {
                if (item.DriveType == DriveType.Removable)
                {
                    return item.Name;
                }
            }
            return Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
        }

        private void Btn_Export_Click(object sender, EventArgs e)
        {
            List<CbDeviceInfo> mDeviceInfos = GetSelectRow();
            using (ExportDeviceInfo_Form exportdeviceinfo = new ExportDeviceInfo_Form(mDeviceInfos))
            {
                if (exportdeviceinfo.ShowDialog() != DialogResult.OK) return;
                GetContainerControl();
            }
        }

        private List<CbDeviceInfo> GetSelectRow()
        {
            List<CbDeviceInfo> mDeviceInfos = new List<CbDeviceInfo>();
            for (int i = 0; i < dgv_DeviceInfo.RowCount; i++)
            {
                bool flag = Utils.StrToBool(dgv_DeviceInfo["c_Selected", i].Value, false);
                if (!flag) continue;
                CbDeviceInfo mDeviceInfo = FormComm.GetDataSourceToClass<CbDeviceInfo>(dgv_DeviceInfo, i);
                mDeviceInfos.Add(mDeviceInfo);
            }
            return mDeviceInfos;
        }

        private void Btn_Del_Click(object sender, EventArgs e)
        {
            int index = 0;
            CbDeviceInfo deviceinfo = FormComm.GetDataSourceToClass<CbDeviceInfo>(dgv_DeviceInfo, ref index);
            if (MessageBox.Show("确认是否删除设备信息。", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                try
                {
                    Dbhelper.Db.Del<CbDeviceInfo>(deviceinfo.ID);
                    DataTable dt = dgv_DeviceInfo.DataSource as DataTable;
                    dt.Rows.RemoveAt(index);
                    GetDeviceInfoCount();
                    if (cb_AllSelected.CheckState != CheckState.Unchecked)
                    {
                        cb_AllSelected.CheckState = CheckState.Unchecked;
                        btn_Export.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    CustomExceptionHandler.GetExceptionMessage(ex);
                    MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Btn_Edit_Click(object sender, EventArgs e)
        {
            int index = 0;
            CbDeviceInfo mDeviceInfo = FormComm.GetDataSourceToClass<CbDeviceInfo>(dgv_DeviceInfo, ref index);
            using (EditDeviceInfo_Form editdeviceinfo = new CbznSystem.EditDeviceInfo_Form(mDeviceInfo))
            {
                if (editdeviceinfo.ShowDialog() != DialogResult.OK) return;
                mDeviceInfo = editdeviceinfo.Tag as CbDeviceInfo;
                FormComm.UpdateDgvDataSource<CbDeviceInfo>(mDeviceInfo, dgv_DeviceInfo, index);
            }
        }

        private void Btn_Add_Click(object sender, EventArgs e)
        {
            using (AddDeviceInfo_Form adddeviceinfo = new AddDeviceInfo_Form())
            {
                if (adddeviceinfo.ShowDialog() != DialogResult.OK) return;
                CbDeviceInfo mDeviceInfo = adddeviceinfo.Tag as CbDeviceInfo;
                FormComm.AddDgvSource<CbDeviceInfo>(mDeviceInfo, dgv_DeviceInfo);
                GetDeviceInfoCount();
            }
        }

        private void Tab2_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            _uniqueInstance = null;
        }

        private static Tab2_Form _uniqueInstance;

        public static Tab2_Form GetInstance
        {
            get { return _uniqueInstance ?? (_uniqueInstance = new Tab2_Form()); }
        }

    }
}
