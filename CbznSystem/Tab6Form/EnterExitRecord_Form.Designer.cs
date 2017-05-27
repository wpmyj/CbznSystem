namespace CbznSystem
{
    partial class EnterExitRecord_Form
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_RecordList = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MasterCardNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubCardNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeviceNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IOState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IOTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_Top = new System.Windows.Forms.Panel();
            this.l_SearchTitle = new System.Windows.Forms.Label();
            this.btn_Search = new System.Windows.Forms.Button();
            this.tb_SearchContent = new System.Windows.Forms.TextBox();
            this.dt_StopTime = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dt_StartTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_ShowRecord = new System.Windows.Forms.Button();
            this.btn_Print = new System.Windows.Forms.Button();
            this.btn_Input = new System.Windows.Forms.Button();
            this.p_Bottom = new System.Windows.Forms.Panel();
            this.l_PageTitle = new System.Windows.Forms.Label();
            this.tb_Page = new System.Windows.Forms.TextBox();
            this.btn_PreviousPage = new System.Windows.Forms.Button();
            this.btn_FirstPage = new System.Windows.Forms.Button();
            this.btn_LastPage = new System.Windows.Forms.Button();
            this.btn_NextPage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_RecordList)).BeginInit();
            this.p_Top.SuspendLayout();
            this.p_Bottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_RecordList
            // 
            this.dgv_RecordList.AllowUserToAddRows = false;
            this.dgv_RecordList.AllowUserToDeleteRows = false;
            this.dgv_RecordList.AllowUserToResizeColumns = false;
            this.dgv_RecordList.AllowUserToResizeRows = false;
            this.dgv_RecordList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(245)))));
            this.dgv_RecordList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_RecordList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_RecordList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgv_RecordList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_RecordList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_RecordList.ColumnHeadersHeight = 40;
            this.dgv_RecordList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_RecordList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.MasterCardNumber,
            this.SubCardNumber,
            this.DeviceNumber,
            this.IOState,
            this.IOTime});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_RecordList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_RecordList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_RecordList.EnableHeadersVisualStyles = false;
            this.dgv_RecordList.Location = new System.Drawing.Point(0, 60);
            this.dgv_RecordList.MultiSelect = false;
            this.dgv_RecordList.Name = "dgv_RecordList";
            this.dgv_RecordList.ReadOnly = true;
            this.dgv_RecordList.RowHeadersVisible = false;
            this.dgv_RecordList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_RecordList.RowTemplate.Height = 36;
            this.dgv_RecordList.RowTemplate.ReadOnly = true;
            this.dgv_RecordList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_RecordList.Size = new System.Drawing.Size(973, 301);
            this.dgv_RecordList.TabIndex = 7;
            this.dgv_RecordList.TabStop = false;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // MasterCardNumber
            // 
            this.MasterCardNumber.DataPropertyName = "MasterCardNumber";
            this.MasterCardNumber.HeaderText = "主卡卡号";
            this.MasterCardNumber.Name = "MasterCardNumber";
            this.MasterCardNumber.ReadOnly = true;
            this.MasterCardNumber.Width = 120;
            // 
            // SubCardNumber
            // 
            this.SubCardNumber.DataPropertyName = "SubCardNumber";
            this.SubCardNumber.HeaderText = "副卡卡号";
            this.SubCardNumber.Name = "SubCardNumber";
            this.SubCardNumber.ReadOnly = true;
            this.SubCardNumber.Width = 120;
            // 
            // DeviceNumber
            // 
            this.DeviceNumber.DataPropertyName = "DeviceNumber";
            this.DeviceNumber.HeaderText = "设备编号";
            this.DeviceNumber.Name = "DeviceNumber";
            this.DeviceNumber.ReadOnly = true;
            // 
            // IOState
            // 
            this.IOState.DataPropertyName = "IOState";
            this.IOState.HeaderText = "进出口";
            this.IOState.Name = "IOState";
            this.IOState.ReadOnly = true;
            // 
            // IOTime
            // 
            this.IOTime.DataPropertyName = "IOTime";
            dataGridViewCellStyle2.Format = "F";
            dataGridViewCellStyle2.NullValue = null;
            this.IOTime.DefaultCellStyle = dataGridViewCellStyle2;
            this.IOTime.HeaderText = "进出时间";
            this.IOTime.Name = "IOTime";
            this.IOTime.ReadOnly = true;
            this.IOTime.Width = 200;
            // 
            // p_Top
            // 
            this.p_Top.Controls.Add(this.l_SearchTitle);
            this.p_Top.Controls.Add(this.btn_Search);
            this.p_Top.Controls.Add(this.tb_SearchContent);
            this.p_Top.Controls.Add(this.dt_StopTime);
            this.p_Top.Controls.Add(this.label3);
            this.p_Top.Controls.Add(this.dt_StartTime);
            this.p_Top.Controls.Add(this.label2);
            this.p_Top.Controls.Add(this.btn_ShowRecord);
            this.p_Top.Controls.Add(this.btn_Print);
            this.p_Top.Controls.Add(this.btn_Input);
            this.p_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.p_Top.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.p_Top.Location = new System.Drawing.Point(0, 0);
            this.p_Top.Name = "p_Top";
            this.p_Top.Size = new System.Drawing.Size(973, 60);
            this.p_Top.TabIndex = 6;
            // 
            // l_SearchTitle
            // 
            this.l_SearchTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.l_SearchTitle.AutoSize = true;
            this.l_SearchTitle.BackColor = System.Drawing.Color.White;
            this.l_SearchTitle.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.l_SearchTitle.ForeColor = System.Drawing.Color.DarkGray;
            this.l_SearchTitle.Location = new System.Drawing.Point(680, 20);
            this.l_SearchTitle.Name = "l_SearchTitle";
            this.l_SearchTitle.Size = new System.Drawing.Size(177, 20);
            this.l_SearchTitle.TabIndex = 26;
            this.l_SearchTitle.Text = "搜索内容：主卡、副卡卡号";
            // 
            // btn_Search
            // 
            this.btn_Search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_Search.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_Search.FlatAppearance.BorderSize = 0;
            this.btn_Search.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(17)))), ((int)(((byte)(42)))));
            this.btn_Search.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(181)))), ((int)(((byte)(235)))));
            this.btn_Search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Search.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Search.ForeColor = System.Drawing.Color.White;
            this.btn_Search.Location = new System.Drawing.Point(870, 16);
            this.btn_Search.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(100, 29);
            this.btn_Search.TabIndex = 25;
            this.btn_Search.TabStop = false;
            this.btn_Search.Text = "搜 索";
            this.btn_Search.UseVisualStyleBackColor = false;
            // 
            // tb_SearchContent
            // 
            this.tb_SearchContent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_SearchContent.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_SearchContent.Location = new System.Drawing.Point(670, 16);
            this.tb_SearchContent.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.tb_SearchContent.Name = "tb_SearchContent";
            this.tb_SearchContent.Size = new System.Drawing.Size(200, 29);
            this.tb_SearchContent.TabIndex = 24;
            // 
            // dt_StopTime
            // 
            this.dt_StopTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dt_StopTime.Location = new System.Drawing.Point(500, 31);
            this.dt_StopTime.Name = "dt_StopTime";
            this.dt_StopTime.Size = new System.Drawing.Size(150, 26);
            this.dt_StopTime.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(429, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "结止时间";
            // 
            // dt_StartTime
            // 
            this.dt_StartTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dt_StartTime.Location = new System.Drawing.Point(500, 3);
            this.dt_StartTime.Name = "dt_StartTime";
            this.dt_StartTime.Size = new System.Drawing.Size(150, 26);
            this.dt_StartTime.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(433, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "开始时间";
            // 
            // btn_ShowRecord
            // 
            this.btn_ShowRecord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_ShowRecord.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_ShowRecord.FlatAppearance.BorderSize = 0;
            this.btn_ShowRecord.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(17)))), ((int)(((byte)(42)))));
            this.btn_ShowRecord.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(181)))), ((int)(((byte)(235)))));
            this.btn_ShowRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ShowRecord.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ShowRecord.ForeColor = System.Drawing.Color.White;
            this.btn_ShowRecord.Location = new System.Drawing.Point(15, 16);
            this.btn_ShowRecord.Name = "btn_ShowRecord";
            this.btn_ShowRecord.Size = new System.Drawing.Size(100, 29);
            this.btn_ShowRecord.TabIndex = 19;
            this.btn_ShowRecord.TabStop = false;
            this.btn_ShowRecord.Text = "显示记录";
            this.btn_ShowRecord.UseVisualStyleBackColor = false;
            // 
            // btn_Print
            // 
            this.btn_Print.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_Print.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_Print.FlatAppearance.BorderSize = 0;
            this.btn_Print.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(17)))), ((int)(((byte)(42)))));
            this.btn_Print.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(181)))), ((int)(((byte)(235)))));
            this.btn_Print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Print.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Print.ForeColor = System.Drawing.Color.White;
            this.btn_Print.Location = new System.Drawing.Point(227, 16);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(100, 29);
            this.btn_Print.TabIndex = 18;
            this.btn_Print.TabStop = false;
            this.btn_Print.Text = "打 印";
            this.btn_Print.UseVisualStyleBackColor = false;
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
            this.btn_Input.Location = new System.Drawing.Point(121, 16);
            this.btn_Input.Name = "btn_Input";
            this.btn_Input.Size = new System.Drawing.Size(100, 29);
            this.btn_Input.TabIndex = 13;
            this.btn_Input.TabStop = false;
            this.btn_Input.Text = "导入记录";
            this.btn_Input.UseVisualStyleBackColor = false;
            // 
            // p_Bottom
            // 
            this.p_Bottom.Controls.Add(this.l_PageTitle);
            this.p_Bottom.Controls.Add(this.tb_Page);
            this.p_Bottom.Controls.Add(this.btn_PreviousPage);
            this.p_Bottom.Controls.Add(this.btn_FirstPage);
            this.p_Bottom.Controls.Add(this.btn_LastPage);
            this.p_Bottom.Controls.Add(this.btn_NextPage);
            this.p_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.p_Bottom.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.p_Bottom.Location = new System.Drawing.Point(0, 361);
            this.p_Bottom.Name = "p_Bottom";
            this.p_Bottom.Size = new System.Drawing.Size(973, 50);
            this.p_Bottom.TabIndex = 8;
            // 
            // l_PageTitle
            // 
            this.l_PageTitle.AutoSize = true;
            this.l_PageTitle.Location = new System.Drawing.Point(20, 15);
            this.l_PageTitle.Name = "l_PageTitle";
            this.l_PageTitle.Size = new System.Drawing.Size(196, 21);
            this.l_PageTitle.TabIndex = 24;
            this.l_PageTitle.Text = "总计 {0} 条记录，共 {1} 页";
            // 
            // tb_Page
            // 
            this.tb_Page.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Page.Location = new System.Drawing.Point(824, 11);
            this.tb_Page.MaxLength = 3;
            this.tb_Page.Name = "tb_Page";
            this.tb_Page.Size = new System.Drawing.Size(50, 29);
            this.tb_Page.TabIndex = 23;
            this.tb_Page.Text = "1";
            this.tb_Page.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_PreviousPage
            // 
            this.btn_PreviousPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_PreviousPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_PreviousPage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_PreviousPage.FlatAppearance.BorderSize = 0;
            this.btn_PreviousPage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(17)))), ((int)(((byte)(42)))));
            this.btn_PreviousPage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(181)))), ((int)(((byte)(235)))));
            this.btn_PreviousPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_PreviousPage.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_PreviousPage.ForeColor = System.Drawing.Color.White;
            this.btn_PreviousPage.Location = new System.Drawing.Point(785, 11);
            this.btn_PreviousPage.Name = "btn_PreviousPage";
            this.btn_PreviousPage.Size = new System.Drawing.Size(33, 29);
            this.btn_PreviousPage.TabIndex = 22;
            this.btn_PreviousPage.TabStop = false;
            this.btn_PreviousPage.Text = "<";
            this.btn_PreviousPage.UseVisualStyleBackColor = false;
            // 
            // btn_FirstPage
            // 
            this.btn_FirstPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_FirstPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_FirstPage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_FirstPage.FlatAppearance.BorderSize = 0;
            this.btn_FirstPage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(17)))), ((int)(((byte)(42)))));
            this.btn_FirstPage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(181)))), ((int)(((byte)(235)))));
            this.btn_FirstPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_FirstPage.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_FirstPage.ForeColor = System.Drawing.Color.White;
            this.btn_FirstPage.Location = new System.Drawing.Point(749, 11);
            this.btn_FirstPage.Name = "btn_FirstPage";
            this.btn_FirstPage.Size = new System.Drawing.Size(33, 29);
            this.btn_FirstPage.TabIndex = 21;
            this.btn_FirstPage.TabStop = false;
            this.btn_FirstPage.Text = "|<";
            this.btn_FirstPage.UseVisualStyleBackColor = false;
            // 
            // btn_LastPage
            // 
            this.btn_LastPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_LastPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_LastPage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_LastPage.FlatAppearance.BorderSize = 0;
            this.btn_LastPage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(17)))), ((int)(((byte)(42)))));
            this.btn_LastPage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(181)))), ((int)(((byte)(235)))));
            this.btn_LastPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_LastPage.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_LastPage.ForeColor = System.Drawing.Color.White;
            this.btn_LastPage.Location = new System.Drawing.Point(916, 11);
            this.btn_LastPage.Name = "btn_LastPage";
            this.btn_LastPage.Size = new System.Drawing.Size(33, 29);
            this.btn_LastPage.TabIndex = 20;
            this.btn_LastPage.TabStop = false;
            this.btn_LastPage.Text = ">|";
            this.btn_LastPage.UseVisualStyleBackColor = false;
            // 
            // btn_NextPage
            // 
            this.btn_NextPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_NextPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_NextPage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_NextPage.FlatAppearance.BorderSize = 0;
            this.btn_NextPage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(17)))), ((int)(((byte)(42)))));
            this.btn_NextPage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(181)))), ((int)(((byte)(235)))));
            this.btn_NextPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_NextPage.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_NextPage.ForeColor = System.Drawing.Color.White;
            this.btn_NextPage.Location = new System.Drawing.Point(880, 11);
            this.btn_NextPage.Name = "btn_NextPage";
            this.btn_NextPage.Size = new System.Drawing.Size(33, 29);
            this.btn_NextPage.TabIndex = 19;
            this.btn_NextPage.TabStop = false;
            this.btn_NextPage.Text = ">";
            this.btn_NextPage.UseVisualStyleBackColor = false;
            // 
            // EnterExitRecord_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 411);
            this.Controls.Add(this.dgv_RecordList);
            this.Controls.Add(this.p_Top);
            this.Controls.Add(this.p_Bottom);
            this.KeyPreview = true;
            this.Name = "EnterExitRecord_Form";
            this.Text = "进出记录";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_RecordList)).EndInit();
            this.p_Top.ResumeLayout(false);
            this.p_Top.PerformLayout();
            this.p_Bottom.ResumeLayout(false);
            this.p_Bottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_RecordList;
        private System.Windows.Forms.Panel p_Top;
        private System.Windows.Forms.Button btn_Print;
        private System.Windows.Forms.Button btn_Input;
        private System.Windows.Forms.Panel p_Bottom;
        private System.Windows.Forms.Label l_PageTitle;
        private System.Windows.Forms.TextBox tb_Page;
        private System.Windows.Forms.Button btn_PreviousPage;
        private System.Windows.Forms.Button btn_FirstPage;
        private System.Windows.Forms.Button btn_LastPage;
        private System.Windows.Forms.Button btn_NextPage;
        private System.Windows.Forms.Button btn_ShowRecord;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dt_StopTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dt_StartTime;
        private System.Windows.Forms.TextBox tb_SearchContent;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Label l_SearchTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MasterCardNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubCardNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeviceNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn IOState;
        private System.Windows.Forms.DataGridViewTextBoxColumn IOTime;
    }
}