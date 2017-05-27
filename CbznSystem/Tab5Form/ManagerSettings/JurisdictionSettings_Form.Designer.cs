namespace CbznSystem
{
    partial class JurisdictionSettings_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode(" 发行");
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode(" 延期");
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode(" 挂失");
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode(" 注销");
            System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode(" 延期更新");
            System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode(" 解锁");
            System.Windows.Forms.TreeNode treeNode36 = new System.Windows.Forms.TreeNode(" 锁住");
            System.Windows.Forms.TreeNode treeNode37 = new System.Windows.Forms.TreeNode(" 信息录入-添加");
            System.Windows.Forms.TreeNode treeNode38 = new System.Windows.Forms.TreeNode(" 信息录入-编辑");
            System.Windows.Forms.TreeNode treeNode39 = new System.Windows.Forms.TreeNode(" 信息录入-删除");
            System.Windows.Forms.TreeNode treeNode40 = new System.Windows.Forms.TreeNode(" 设备信息-添加");
            System.Windows.Forms.TreeNode treeNode41 = new System.Windows.Forms.TreeNode(" 设备信息-编辑");
            System.Windows.Forms.TreeNode treeNode42 = new System.Windows.Forms.TreeNode(" 设备信息-删除");
            System.Windows.Forms.TreeNode treeNode43 = new System.Windows.Forms.TreeNode(" 设备信息-导出");
            System.Windows.Forms.TreeNode treeNode44 = new System.Windows.Forms.TreeNode(" 设备信息-导入");
            System.Windows.Forms.TreeNode treeNode45 = new System.Windows.Forms.TreeNode(" 定距设备加载");
            System.Windows.Forms.TreeNode treeNode46 = new System.Windows.Forms.TreeNode(" 定距卡加载");
            System.Windows.Forms.TreeNode treeNode47 = new System.Windows.Forms.TreeNode(" 临时IC设备加载");
            System.Windows.Forms.TreeNode treeNode48 = new System.Windows.Forms.TreeNode(" 临时IC卡加载");
            System.Windows.Forms.TreeNode treeNode49 = new System.Windows.Forms.TreeNode(" 用户管理-添加");
            System.Windows.Forms.TreeNode treeNode50 = new System.Windows.Forms.TreeNode(" 用户管理-编辑");
            System.Windows.Forms.TreeNode treeNode51 = new System.Windows.Forms.TreeNode(" 用户管理-删除");
            System.Windows.Forms.TreeNode treeNode52 = new System.Windows.Forms.TreeNode(" 用户管理-权限");
            System.Windows.Forms.TreeNode treeNode53 = new System.Windows.Forms.TreeNode(" 数据管理-备份");
            System.Windows.Forms.TreeNode treeNode54 = new System.Windows.Forms.TreeNode(" 数据管理-恢复");
            System.Windows.Forms.TreeNode treeNode55 = new System.Windows.Forms.TreeNode(" 数据管理-清除");
            System.Windows.Forms.TreeNode treeNode56 = new System.Windows.Forms.TreeNode(" 无线通信设置");
            System.Windows.Forms.TreeNode treeNode57 = new System.Windows.Forms.TreeNode(" 像机管理");
            System.Windows.Forms.TreeNode treeNode58 = new System.Windows.Forms.TreeNode(" 在线收费");
            this.tv_DataList = new System.Windows.Forms.TreeView();
            this.btn_Enter = new System.Windows.Forms.Button();
            this.cb_AllSelected = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tv_DataList
            // 
            this.tv_DataList.CheckBoxes = true;
            this.tv_DataList.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tv_DataList.FullRowSelect = true;
            this.tv_DataList.ItemHeight = 25;
            this.tv_DataList.Location = new System.Drawing.Point(20, 47);
            this.tv_DataList.Name = "tv_DataList";
            treeNode30.Name = "CardOperationIssue";
            treeNode30.Text = " 发行";
            treeNode31.Name = "CardOperationDelay";
            treeNode31.Text = " 延期";
            treeNode32.Name = "CardOperationLoss";
            treeNode32.Text = " 挂失";
            treeNode33.Name = "CardOperationLog";
            treeNode33.Text = " 注销";
            treeNode34.Name = "CardOperationDeferredUpdate";
            treeNode34.Text = " 延期更新";
            treeNode35.Name = "CardOperationUnlock";
            treeNode35.Text = " 解锁";
            treeNode36.Name = "CardOperationLock";
            treeNode36.Text = " 锁住";
            treeNode37.Name = "InforMationEntryToAdd";
            treeNode37.Text = " 信息录入-添加";
            treeNode38.Name = "InforMationEntryEditing";
            treeNode38.Text = " 信息录入-编辑";
            treeNode39.Name = "InformationEntryAndDeletion";
            treeNode39.Text = " 信息录入-删除";
            treeNode40.Name = "AddEquipmentCatalog";
            treeNode40.Text = " 设备信息-添加";
            treeNode41.Name = "CatalogEditingEquipment";
            treeNode41.Text = " 设备信息-编辑";
            treeNode42.Name = "DeleteLoggingEquipment";
            treeNode42.Text = " 设备信息-删除";
            treeNode43.Name = "ExportEquipmentCatalog";
            treeNode43.Text = " 设备信息-导出";
            treeNode44.Name = "ImportEquipmentCatalog";
            treeNode44.Text = " 设备信息-导入";
            treeNode45.Name = "DeviceEncryption";
            treeNode45.Text = " 定距设备加载";
            treeNode46.Name = "DevicEncryptionCardEncryption";
            treeNode46.Text = " 定距卡加载";
            treeNode47.Name = "ICEncryptionICDeviceEncryption";
            treeNode47.Text = " 临时IC设备加载";
            treeNode48.Name = "ICEncryptionICCardEncryption";
            treeNode48.Text = " 临时IC卡加载";
            treeNode49.Name = "SetUserManagementToAdd";
            treeNode49.Text = " 用户管理-添加";
            treeNode50.Name = "SetUserManagemenetEditor";
            treeNode50.Text = " 用户管理-编辑";
            treeNode51.Name = "SetUserManagementToDelete";
            treeNode51.Text = " 用户管理-删除";
            treeNode52.Name = "SetUserAdministrationRights";
            treeNode52.Text = " 用户管理-权限";
            treeNode53.Name = "SetDataManagementBackup";
            treeNode53.Text = " 数据管理-备份";
            treeNode54.Name = "SetDataManagementRecovery";
            treeNode54.Text = " 数据管理-恢复";
            treeNode55.Name = "SetDataManagementClear";
            treeNode55.Text = " 数据管理-清除";
            treeNode56.Name = "ModuleSettings";
            treeNode56.Text = " 无线通信设置";
            treeNode57.Name = "CameraManagement";
            treeNode57.Text = " 像机管理";
            treeNode58.Name = "SetChargeManagement";
            treeNode58.Text = " 在线收费";
            this.tv_DataList.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode30,
            treeNode31,
            treeNode32,
            treeNode33,
            treeNode34,
            treeNode35,
            treeNode36,
            treeNode37,
            treeNode38,
            treeNode39,
            treeNode40,
            treeNode41,
            treeNode42,
            treeNode43,
            treeNode44,
            treeNode45,
            treeNode46,
            treeNode47,
            treeNode48,
            treeNode49,
            treeNode50,
            treeNode51,
            treeNode52,
            treeNode53,
            treeNode54,
            treeNode55,
            treeNode56,
            treeNode57,
            treeNode58});
            this.tv_DataList.ShowLines = false;
            this.tv_DataList.ShowPlusMinus = false;
            this.tv_DataList.ShowRootLines = false;
            this.tv_DataList.Size = new System.Drawing.Size(300, 350);
            this.tv_DataList.TabIndex = 1;
            // 
            // btn_Enter
            // 
            this.btn_Enter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btn_Enter.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btn_Enter.FlatAppearance.BorderSize = 0;
            this.btn_Enter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btn_Enter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(214)))), ((int)(((byte)(141)))));
            this.btn_Enter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Enter.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Enter.ForeColor = System.Drawing.Color.White;
            this.btn_Enter.Location = new System.Drawing.Point(220, 410);
            this.btn_Enter.Name = "btn_Enter";
            this.btn_Enter.Size = new System.Drawing.Size(100, 29);
            this.btn_Enter.TabIndex = 15;
            this.btn_Enter.TabStop = false;
            this.btn_Enter.Text = "确 认";
            this.btn_Enter.UseVisualStyleBackColor = false;
            // 
            // cb_AllSelected
            // 
            this.cb_AllSelected.AutoSize = true;
            this.cb_AllSelected.Location = new System.Drawing.Point(20, 416);
            this.cb_AllSelected.Name = "cb_AllSelected";
            this.cb_AllSelected.Size = new System.Drawing.Size(78, 16);
            this.cb_AllSelected.TabIndex = 16;
            this.cb_AllSelected.Text = "全选/反选";
            this.cb_AllSelected.UseVisualStyleBackColor = true;
            // 
            // JurisdictionSettings_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 450);
            this.Controls.Add(this.cb_AllSelected);
            this.Controls.Add(this.btn_Enter);
            this.Controls.Add(this.tv_DataList);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "JurisdictionSettings_Form";
            this.ShowIcon = false;
            this.Text = "权限设置";
            this.Controls.SetChildIndex(this.tv_DataList, 0);
            this.Controls.SetChildIndex(this.btn_Enter, 0);
            this.Controls.SetChildIndex(this.cb_AllSelected, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tv_DataList;
        private System.Windows.Forms.Button btn_Enter;
        private System.Windows.Forms.CheckBox cb_AllSelected;
    }
}