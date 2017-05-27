namespace CbznSystem
{
    partial class Tab2_Form
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_DeviceInfo = new System.Windows.Forms.DataGridView();
            this.p_Top = new System.Windows.Forms.Panel();
            this.btn_Input = new System.Windows.Forms.Button();
            this.btn_Export = new System.Windows.Forms.Button();
            this.btn_Del = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Edit = new System.Windows.Forms.Button();
            this.p_Bottom = new System.Windows.Forms.Panel();
            this.l_Description = new System.Windows.Forms.Label();
            this.tb_Page = new System.Windows.Forms.TextBox();
            this.btn_PreviousPage = new System.Windows.Forms.Button();
            this.btn_FirstPage = new System.Windows.Forms.Button();
            this.btn_LastPage = new System.Windows.Forms.Button();
            this.btn_NextPage = new System.Windows.Forms.Button();
            this.cb_AllSelected = new System.Windows.Forms.CheckBox();
            this.c_Selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HostNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IOSate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeviceMode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeviceNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FieldPartition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AntiSubmarineBack = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VehicleDetection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Distance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EquipmentDelay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Language = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsLikeMachine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Frequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WirelessID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VagueQueryNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DeviceInfo)).BeginInit();
            this.p_Top.SuspendLayout();
            this.p_Bottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_DeviceInfo
            // 
            this.dgv_DeviceInfo.AllowUserToAddRows = false;
            this.dgv_DeviceInfo.AllowUserToDeleteRows = false;
            this.dgv_DeviceInfo.AllowUserToResizeColumns = false;
            this.dgv_DeviceInfo.AllowUserToResizeRows = false;
            this.dgv_DeviceInfo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(245)))));
            this.dgv_DeviceInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_DeviceInfo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_DeviceInfo.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgv_DeviceInfo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_DeviceInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_DeviceInfo.ColumnHeadersHeight = 40;
            this.dgv_DeviceInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_DeviceInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_Selected,
            this.ID,
            this.HostNumber,
            this.IOSate,
            this.DeviceMode,
            this.DeviceNumber,
            this.FieldPartition,
            this.AntiSubmarineBack,
            this.VehicleDetection,
            this.Distance,
            this.EquipmentDelay,
            this.Language,
            this.IsLikeMachine,
            this.Frequency,
            this.WirelessID,
            this.VagueQueryNumber});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_DeviceInfo.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_DeviceInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_DeviceInfo.EnableHeadersVisualStyles = false;
            this.dgv_DeviceInfo.Location = new System.Drawing.Point(0, 60);
            this.dgv_DeviceInfo.MultiSelect = false;
            this.dgv_DeviceInfo.Name = "dgv_DeviceInfo";
            this.dgv_DeviceInfo.RowHeadersVisible = false;
            this.dgv_DeviceInfo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_DeviceInfo.RowTemplate.Height = 36;
            this.dgv_DeviceInfo.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_DeviceInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_DeviceInfo.Size = new System.Drawing.Size(677, 321);
            this.dgv_DeviceInfo.TabIndex = 6;
            this.dgv_DeviceInfo.TabStop = false;
            // 
            // p_Top
            // 
            this.p_Top.Controls.Add(this.btn_Input);
            this.p_Top.Controls.Add(this.btn_Export);
            this.p_Top.Controls.Add(this.btn_Del);
            this.p_Top.Controls.Add(this.btn_Add);
            this.p_Top.Controls.Add(this.btn_Edit);
            this.p_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.p_Top.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.p_Top.Location = new System.Drawing.Point(0, 0);
            this.p_Top.Name = "p_Top";
            this.p_Top.Size = new System.Drawing.Size(677, 60);
            this.p_Top.TabIndex = 3;
            // 
            // btn_Input
            // 
            this.btn_Input.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_Input.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_Input.FlatAppearance.BorderSize = 0;
            this.btn_Input.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(17)))), ((int)(((byte)(42)))));
            this.btn_Input.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(181)))), ((int)(((byte)(235)))));
            this.btn_Input.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Input.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Input.ForeColor = System.Drawing.Color.White;
            this.btn_Input.Location = new System.Drawing.Point(439, 16);
            this.btn_Input.Name = "btn_Input";
            this.btn_Input.Size = new System.Drawing.Size(100, 29);
            this.btn_Input.TabIndex = 4;
            this.btn_Input.TabStop = false;
            this.btn_Input.Text = "导 入";
            this.btn_Input.UseVisualStyleBackColor = false;
            // 
            // btn_Export
            // 
            this.btn_Export.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_Export.Enabled = false;
            this.btn_Export.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_Export.FlatAppearance.BorderSize = 0;
            this.btn_Export.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(17)))), ((int)(((byte)(42)))));
            this.btn_Export.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(181)))), ((int)(((byte)(235)))));
            this.btn_Export.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Export.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Export.ForeColor = System.Drawing.Color.White;
            this.btn_Export.Location = new System.Drawing.Point(333, 16);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(100, 29);
            this.btn_Export.TabIndex = 3;
            this.btn_Export.TabStop = false;
            this.btn_Export.Text = "导 出";
            this.btn_Export.UseVisualStyleBackColor = false;
            // 
            // btn_Del
            // 
            this.btn_Del.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_Del.Enabled = false;
            this.btn_Del.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_Del.FlatAppearance.BorderSize = 0;
            this.btn_Del.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(17)))), ((int)(((byte)(42)))));
            this.btn_Del.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(181)))), ((int)(((byte)(235)))));
            this.btn_Del.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Del.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Del.ForeColor = System.Drawing.Color.White;
            this.btn_Del.Location = new System.Drawing.Point(227, 16);
            this.btn_Del.Name = "btn_Del";
            this.btn_Del.Size = new System.Drawing.Size(100, 29);
            this.btn_Del.TabIndex = 2;
            this.btn_Del.TabStop = false;
            this.btn_Del.Text = "删 除";
            this.btn_Del.UseVisualStyleBackColor = false;
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btn_Add.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btn_Add.FlatAppearance.BorderSize = 0;
            this.btn_Add.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btn_Add.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(214)))), ((int)(((byte)(141)))));
            this.btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Add.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Add.ForeColor = System.Drawing.Color.White;
            this.btn_Add.Location = new System.Drawing.Point(15, 16);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(100, 29);
            this.btn_Add.TabIndex = 0;
            this.btn_Add.TabStop = false;
            this.btn_Add.Text = "添 加";
            this.btn_Add.UseVisualStyleBackColor = false;
            // 
            // btn_Edit
            // 
            this.btn_Edit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_Edit.Enabled = false;
            this.btn_Edit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_Edit.FlatAppearance.BorderSize = 0;
            this.btn_Edit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(17)))), ((int)(((byte)(42)))));
            this.btn_Edit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(181)))), ((int)(((byte)(235)))));
            this.btn_Edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Edit.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Edit.ForeColor = System.Drawing.Color.White;
            this.btn_Edit.Location = new System.Drawing.Point(121, 16);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(100, 29);
            this.btn_Edit.TabIndex = 1;
            this.btn_Edit.TabStop = false;
            this.btn_Edit.Text = "编 辑";
            this.btn_Edit.UseVisualStyleBackColor = false;
            // 
            // p_Bottom
            // 
            this.p_Bottom.Controls.Add(this.l_Description);
            this.p_Bottom.Controls.Add(this.tb_Page);
            this.p_Bottom.Controls.Add(this.btn_PreviousPage);
            this.p_Bottom.Controls.Add(this.btn_FirstPage);
            this.p_Bottom.Controls.Add(this.btn_LastPage);
            this.p_Bottom.Controls.Add(this.btn_NextPage);
            this.p_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.p_Bottom.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.p_Bottom.Location = new System.Drawing.Point(0, 381);
            this.p_Bottom.Name = "p_Bottom";
            this.p_Bottom.Size = new System.Drawing.Size(677, 50);
            this.p_Bottom.TabIndex = 5;
            // 
            // l_Description
            // 
            this.l_Description.AutoSize = true;
            this.l_Description.Location = new System.Drawing.Point(20, 15);
            this.l_Description.Name = "l_Description";
            this.l_Description.Size = new System.Drawing.Size(196, 21);
            this.l_Description.TabIndex = 24;
            this.l_Description.Text = "总计 {0} 条记录，共 {1} 页";
            // 
            // tb_Page
            // 
            this.tb_Page.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Page.Location = new System.Drawing.Point(528, 11);
            this.tb_Page.MaxLength = 3;
            this.tb_Page.Name = "tb_Page";
            this.tb_Page.Size = new System.Drawing.Size(50, 29);
            this.tb_Page.TabIndex = 9;
            this.tb_Page.Text = "1";
            this.tb_Page.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_PreviousPage
            // 
            this.btn_PreviousPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_PreviousPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_PreviousPage.Enabled = false;
            this.btn_PreviousPage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_PreviousPage.FlatAppearance.BorderSize = 0;
            this.btn_PreviousPage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(17)))), ((int)(((byte)(42)))));
            this.btn_PreviousPage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(181)))), ((int)(((byte)(235)))));
            this.btn_PreviousPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_PreviousPage.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_PreviousPage.ForeColor = System.Drawing.Color.White;
            this.btn_PreviousPage.Location = new System.Drawing.Point(489, 11);
            this.btn_PreviousPage.Name = "btn_PreviousPage";
            this.btn_PreviousPage.Size = new System.Drawing.Size(33, 29);
            this.btn_PreviousPage.TabIndex = 8;
            this.btn_PreviousPage.TabStop = false;
            this.btn_PreviousPage.Text = "<";
            this.btn_PreviousPage.UseVisualStyleBackColor = false;
            // 
            // btn_FirstPage
            // 
            this.btn_FirstPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_FirstPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_FirstPage.Enabled = false;
            this.btn_FirstPage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_FirstPage.FlatAppearance.BorderSize = 0;
            this.btn_FirstPage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(17)))), ((int)(((byte)(42)))));
            this.btn_FirstPage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(181)))), ((int)(((byte)(235)))));
            this.btn_FirstPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_FirstPage.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_FirstPage.ForeColor = System.Drawing.Color.White;
            this.btn_FirstPage.Location = new System.Drawing.Point(453, 11);
            this.btn_FirstPage.Name = "btn_FirstPage";
            this.btn_FirstPage.Size = new System.Drawing.Size(33, 29);
            this.btn_FirstPage.TabIndex = 7;
            this.btn_FirstPage.TabStop = false;
            this.btn_FirstPage.Text = "|<";
            this.btn_FirstPage.UseVisualStyleBackColor = false;
            // 
            // btn_LastPage
            // 
            this.btn_LastPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_LastPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_LastPage.Enabled = false;
            this.btn_LastPage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_LastPage.FlatAppearance.BorderSize = 0;
            this.btn_LastPage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(17)))), ((int)(((byte)(42)))));
            this.btn_LastPage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(181)))), ((int)(((byte)(235)))));
            this.btn_LastPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_LastPage.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_LastPage.ForeColor = System.Drawing.Color.White;
            this.btn_LastPage.Location = new System.Drawing.Point(620, 11);
            this.btn_LastPage.Name = "btn_LastPage";
            this.btn_LastPage.Size = new System.Drawing.Size(33, 29);
            this.btn_LastPage.TabIndex = 11;
            this.btn_LastPage.TabStop = false;
            this.btn_LastPage.Text = ">|";
            this.btn_LastPage.UseVisualStyleBackColor = false;
            // 
            // btn_NextPage
            // 
            this.btn_NextPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_NextPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_NextPage.Enabled = false;
            this.btn_NextPage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_NextPage.FlatAppearance.BorderSize = 0;
            this.btn_NextPage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(17)))), ((int)(((byte)(42)))));
            this.btn_NextPage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(181)))), ((int)(((byte)(235)))));
            this.btn_NextPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_NextPage.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_NextPage.ForeColor = System.Drawing.Color.White;
            this.btn_NextPage.Location = new System.Drawing.Point(584, 11);
            this.btn_NextPage.Name = "btn_NextPage";
            this.btn_NextPage.Size = new System.Drawing.Size(33, 29);
            this.btn_NextPage.TabIndex = 10;
            this.btn_NextPage.TabStop = false;
            this.btn_NextPage.Text = ">";
            this.btn_NextPage.UseVisualStyleBackColor = false;
            // 
            // cb_AllSelected
            // 
            this.cb_AllSelected.AutoSize = true;
            this.cb_AllSelected.Location = new System.Drawing.Point(7, 75);
            this.cb_AllSelected.Name = "cb_AllSelected";
            this.cb_AllSelected.Size = new System.Drawing.Size(15, 14);
            this.cb_AllSelected.TabIndex = 6;
            this.cb_AllSelected.ThreeState = true;
            this.cb_AllSelected.UseVisualStyleBackColor = true;
            // 
            // c_Selected
            // 
            this.c_Selected.HeaderText = "";
            this.c_Selected.Name = "c_Selected";
            this.c_Selected.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.c_Selected.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.c_Selected.Width = 30;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ID.Visible = false;
            // 
            // HostNumber
            // 
            this.HostNumber.DataPropertyName = "HostNumber";
            this.HostNumber.HeaderText = "门口编号";
            this.HostNumber.Name = "HostNumber";
            this.HostNumber.ReadOnly = true;
            this.HostNumber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.HostNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // IOSate
            // 
            this.IOSate.DataPropertyName = "IOSate";
            this.IOSate.HeaderText = "出入口";
            this.IOSate.Name = "IOSate";
            this.IOSate.ReadOnly = true;
            this.IOSate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.IOSate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DeviceMode
            // 
            this.DeviceMode.DataPropertyName = "DeviceMode";
            this.DeviceMode.HeaderText = "开闸模式";
            this.DeviceMode.Name = "DeviceMode";
            this.DeviceMode.ReadOnly = true;
            this.DeviceMode.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DeviceMode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DeviceMode.Width = 120;
            // 
            // DeviceNumber
            // 
            this.DeviceNumber.DataPropertyName = "DeviceNumber";
            this.DeviceNumber.HeaderText = "道闸编号";
            this.DeviceNumber.Name = "DeviceNumber";
            this.DeviceNumber.ReadOnly = true;
            this.DeviceNumber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DeviceNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FieldPartition
            // 
            this.FieldPartition.DataPropertyName = "FieldPartition";
            this.FieldPartition.HeaderText = "场分区";
            this.FieldPartition.Name = "FieldPartition";
            this.FieldPartition.ReadOnly = true;
            this.FieldPartition.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.FieldPartition.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // AntiSubmarineBack
            // 
            this.AntiSubmarineBack.DataPropertyName = "AntiSubmarineBack";
            this.AntiSubmarineBack.HeaderText = "返潜回";
            this.AntiSubmarineBack.Name = "AntiSubmarineBack";
            this.AntiSubmarineBack.ReadOnly = true;
            this.AntiSubmarineBack.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.AntiSubmarineBack.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // VehicleDetection
            // 
            this.VehicleDetection.DataPropertyName = "VehicleDetection";
            this.VehicleDetection.HeaderText = "车辆检测";
            this.VehicleDetection.Name = "VehicleDetection";
            this.VehicleDetection.ReadOnly = true;
            this.VehicleDetection.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.VehicleDetection.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Distance
            // 
            this.Distance.DataPropertyName = "Distance";
            this.Distance.HeaderText = "读卡距离";
            this.Distance.Name = "Distance";
            this.Distance.ReadOnly = true;
            this.Distance.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Distance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // EquipmentDelay
            // 
            this.EquipmentDelay.DataPropertyName = "EquipmentDelay";
            this.EquipmentDelay.HeaderText = "读卡延迟";
            this.EquipmentDelay.Name = "EquipmentDelay";
            this.EquipmentDelay.ReadOnly = true;
            this.EquipmentDelay.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.EquipmentDelay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Language
            // 
            this.Language.DataPropertyName = "Language";
            this.Language.HeaderText = "语言各类";
            this.Language.Name = "Language";
            this.Language.ReadOnly = true;
            this.Language.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Language.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // IsLikeMachine
            // 
            this.IsLikeMachine.DataPropertyName = "IsLikeMachine";
            this.IsLikeMachine.HeaderText = "车牌识别";
            this.IsLikeMachine.Name = "IsLikeMachine";
            this.IsLikeMachine.ReadOnly = true;
            this.IsLikeMachine.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.IsLikeMachine.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Frequency
            // 
            this.Frequency.DataPropertyName = "Frequency";
            this.Frequency.HeaderText = "频率偏移";
            this.Frequency.Name = "Frequency";
            this.Frequency.ReadOnly = true;
            this.Frequency.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Frequency.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // WirelessID
            // 
            this.WirelessID.DataPropertyName = "WirelessID";
            this.WirelessID.HeaderText = "像机 ID";
            this.WirelessID.Name = "WirelessID";
            this.WirelessID.ReadOnly = true;
            this.WirelessID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.WirelessID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // VagueQueryNumber
            // 
            this.VagueQueryNumber.DataPropertyName = "VagueQueryNumber";
            this.VagueQueryNumber.HeaderText = "模糊查询位数";
            this.VagueQueryNumber.Name = "VagueQueryNumber";
            this.VagueQueryNumber.ReadOnly = true;
            this.VagueQueryNumber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.VagueQueryNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Tab2_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 431);
            this.Controls.Add(this.cb_AllSelected);
            this.Controls.Add(this.dgv_DeviceInfo);
            this.Controls.Add(this.p_Top);
            this.Controls.Add(this.p_Bottom);
            this.KeyPreview = true;
            this.Name = "Tab2_Form";
            this.Text = "设备信息";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DeviceInfo)).EndInit();
            this.p_Top.ResumeLayout(false);
            this.p_Bottom.ResumeLayout(false);
            this.p_Bottom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgv_DeviceInfo;
        private System.Windows.Forms.Panel p_Top;
        private System.Windows.Forms.Panel p_Bottom;
        private System.Windows.Forms.Button btn_Input;
        private System.Windows.Forms.Button btn_Export;
        private System.Windows.Forms.Button btn_Del;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Edit;
        private System.Windows.Forms.Button btn_PreviousPage;
        private System.Windows.Forms.Button btn_FirstPage;
        private System.Windows.Forms.Button btn_LastPage;
        private System.Windows.Forms.Button btn_NextPage;
        private System.Windows.Forms.TextBox tb_Page;
        private System.Windows.Forms.Label l_Description;
        private System.Windows.Forms.CheckBox cb_AllSelected;
        private System.Windows.Forms.DataGridViewCheckBoxColumn c_Selected;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn HostNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn IOSate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeviceMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeviceNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn FieldPartition;
        private System.Windows.Forms.DataGridViewTextBoxColumn AntiSubmarineBack;
        private System.Windows.Forms.DataGridViewTextBoxColumn VehicleDetection;
        private System.Windows.Forms.DataGridViewTextBoxColumn Distance;
        private System.Windows.Forms.DataGridViewTextBoxColumn EquipmentDelay;
        private System.Windows.Forms.DataGridViewTextBoxColumn Language;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsLikeMachine;
        private System.Windows.Forms.DataGridViewTextBoxColumn Frequency;
        private System.Windows.Forms.DataGridViewTextBoxColumn WirelessID;
        private System.Windows.Forms.DataGridViewTextBoxColumn VagueQueryNumber;
    }
}