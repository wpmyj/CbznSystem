using System.Reflection;
using NewControl;
using Bll;
using Model;
using Dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CbznSystem
{
    public partial class JurisdictionSettings_Form : NewForm
    {
        private CbManageInfo _mManageInfo;

        private CbManageRights _mManageRights;

        private bool _isActivate;

        public JurisdictionSettings_Form(CbManageInfo mManageInfo)
        {
            InitializeComponent();

            _mManageInfo = mManageInfo;

            this.Load += JurisdictionSettings_Load;
            this.Shown += JurisdictionSettings_Form_Shown;
            this.KeyDown += JurisdictionSettings_Form_KeyDown;

            cb_AllSelected.CheckedChanged += Cb_AllSelected_CheckedChanged;
            cb_AllSelected.MouseDown += Cb_AllSelected_MouseDown;
            tv_DataList.AfterCheck += Tv_DataList_AfterCheck;
            tv_DataList.NodeMouseClick += Tv_DataList_NodeMouseClick; btn_Enter.Click += Btn_Enter_Click;
        }

        private void JurisdictionSettings_Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void Tv_DataList_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                e.Node.Checked = !e.Node.Checked;
                //tv_DataList.SelectedNode.Checked = !tv_DataList.SelectedNode.Checked;
            }
        }

        private void JurisdictionSettings_Form_Shown(object sender, EventArgs e)
        {
            _isActivate = true;
        }

        private void Tv_DataList_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (cb_AllSelected.Tag != null) return;
            if (!_isActivate) return;
            GetSelectedState();
        }

        private void GetSelectedState()
        {
            int count = 0;
            foreach (TreeNode item in tv_DataList.Nodes)
            {
                if (item.Checked)
                    count++;
            }
            cb_AllSelected.ThreeState = true;
            if (count == 0)
                cb_AllSelected.CheckState = CheckState.Unchecked;
            else if (count == tv_DataList.Nodes.Count)
                cb_AllSelected.CheckState = CheckState.Checked;
            else
                cb_AllSelected.CheckState = CheckState.Indeterminate;
        }

        private void Cb_AllSelected_MouseDown(object sender, MouseEventArgs e)
        {
            cb_AllSelected.ThreeState = false;
        }

        private void Cb_AllSelected_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_AllSelected.CheckState == CheckState.Indeterminate) return;
            cb_AllSelected.Tag = cb_AllSelected.Checked;
            foreach (TreeNode item in tv_DataList.Nodes)
            {
                item.Checked = cb_AllSelected.Checked;
            }
            cb_AllSelected.Tag = null;
        }

        private void Btn_Enter_Click(object sender, EventArgs e)
        {
            try
            {
                PropertyInfo[] pinfo = typeof(CbManageRights).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                foreach (PropertyInfo item in pinfo)
                {
                    if (!tv_DataList.Nodes.ContainsKey(item.Name)) continue;
                    item.SetValue(_mManageRights, tv_DataList.Nodes[item.Name].Checked, null);
                }
                Dbhelper.Db.Update<CbManageRights>(_mManageRights);
                this.Tag = _mManageRights;
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void JurisdictionSettings_Load(object sender, EventArgs e)
        {
            try
            {
                _mManageRights = Dbhelper.Db.FirstDefault<CbManageRights>(" And UserId=" + _mManageInfo.ID);

                PropertyInfo[] pinfo = typeof(CbManageRights).GetProperties(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance);
                foreach (PropertyInfo item in pinfo)
                {
                    if (!tv_DataList.Nodes.ContainsKey(item.Name)) continue;
                    TreeNode node = tv_DataList.Nodes[item.Name];
                    node.Checked = Utils.StrToBool(item.GetValue(_mManageRights, null), false);
                }
                GetSelectedState();
            }
            catch (Exception ex)
            {
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
