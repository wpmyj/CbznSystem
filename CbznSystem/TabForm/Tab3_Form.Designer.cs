namespace CbznSystem
{
    partial class Tab3_Form
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_CardList = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CardNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CardType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlateNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StopTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Distance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unlocked = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoseState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UseState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FieldPartition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParkingRestrictions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Electricity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserSex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegistrationTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_Top = new System.Windows.Forms.Panel();
            this.l_SearchTitle = new System.Windows.Forms.Label();
            this.tb_SearchContent = new System.Windows.Forms.TextBox();
            this.btn_Other = new System.Windows.Forms.Button();
            this.btn_Search = new System.Windows.Forms.Button();
            this.btn_ShowRecord = new System.Windows.Forms.Button();
            this.btn_InformationInput = new System.Windows.Forms.Button();
            this.btn_AddLose = new System.Windows.Forms.Button();
            this.btn_Delay = new System.Windows.Forms.Button();
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.btn_Issue = new System.Windows.Forms.Button();
            this.btn_Print = new System.Windows.Forms.Button();
            this.p_Bottom = new System.Windows.Forms.Panel();
            this.l_PageTile = new System.Windows.Forms.Label();
            this.tb_Page = new System.Windows.Forms.TextBox();
            this.btn_PreviousPage = new System.Windows.Forms.Button();
            this.btn_FirstPage = new System.Windows.Forms.Button();
            this.btn_LastPage = new System.Windows.Forms.Button();
            this.btn_NextPage = new System.Windows.Forms.Button();
            this.cms_Other = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmt_Cancellation = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmt_DeferredUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmt_Unlock = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmt_Lockup = new System.Windows.Forms.ToolStripMenuItem();
            this.p_Loss = new System.Windows.Forms.Panel();
            this.cb_AllSelected = new System.Windows.Forms.CheckBox();
            this.btn_Remove = new System.Windows.Forms.Button();
            this.btn_Enter = new System.Windows.Forms.Button();
            this.dgv_LossList = new System.Windows.Forms.DataGridView();
            this.c_LossSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.c_LossCardNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_LossUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_LossClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_CardList)).BeginInit();
            this.p_Top.SuspendLayout();
            this.p_Bottom.SuspendLayout();
            this.cms_Other.SuspendLayout();
            this.p_Loss.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_LossList)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_CardList
            // 
            this.dgv_CardList.AllowUserToAddRows = false;
            this.dgv_CardList.AllowUserToDeleteRows = false;
            this.dgv_CardList.AllowUserToResizeColumns = false;
            this.dgv_CardList.AllowUserToResizeRows = false;
            this.dgv_CardList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(245)))));
            this.dgv_CardList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_CardList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_CardList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgv_CardList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_CardList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_CardList.ColumnHeadersHeight = 40;
            this.dgv_CardList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_CardList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.CardNumber,
            this.CardType,
            this.UserName,
            this.PlateNumber,
            this.StartTime,
            this.StopTime,
            this.Distance,
            this.Unlocked,
            this.LoseState,
            this.UseState,
            this.FieldPartition,
            this.ParkingRestrictions,
            this.Electricity,
            this.UserSex,
            this.UserAge,
            this.UserPhone,
            this.UserAddress,
            this.RegistrationTime});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_CardList.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_CardList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_CardList.EnableHeadersVisualStyles = false;
            this.dgv_CardList.Location = new System.Drawing.Point(0, 60);
            this.dgv_CardList.MultiSelect = false;
            this.dgv_CardList.Name = "dgv_CardList";
            this.dgv_CardList.ReadOnly = true;
            this.dgv_CardList.RowHeadersVisible = false;
            this.dgv_CardList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_CardList.RowTemplate.Height = 36;
            this.dgv_CardList.RowTemplate.ReadOnly = true;
            this.dgv_CardList.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_CardList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_CardList.Size = new System.Drawing.Size(666, 387);
            this.dgv_CardList.TabIndex = 7;
            this.dgv_CardList.TabStop = false;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ID.Visible = false;
            // 
            // CardNumber
            // 
            this.CardNumber.DataPropertyName = "CardNumber";
            this.CardNumber.HeaderText = "定距卡编号";
            this.CardNumber.Name = "CardNumber";
            this.CardNumber.ReadOnly = true;
            this.CardNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CardType
            // 
            this.CardType.DataPropertyName = "CardType";
            this.CardType.HeaderText = "定距卡类型";
            this.CardType.Name = "CardType";
            this.CardType.ReadOnly = true;
            this.CardType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "UserName";
            this.UserName.HeaderText = "用户姓名";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            this.UserName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PlateNumber
            // 
            this.PlateNumber.DataPropertyName = "PlateNumber";
            this.PlateNumber.HeaderText = "车牌号码";
            this.PlateNumber.Name = "PlateNumber";
            this.PlateNumber.ReadOnly = true;
            this.PlateNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PlateNumber.Width = 120;
            // 
            // StartTime
            // 
            this.StartTime.DataPropertyName = "StartTime";
            this.StartTime.HeaderText = "StartTime";
            this.StartTime.Name = "StartTime";
            this.StartTime.ReadOnly = true;
            this.StartTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.StartTime.Visible = false;
            // 
            // StopTime
            // 
            this.StopTime.DataPropertyName = "StopTime";
            dataGridViewCellStyle2.Format = "D";
            dataGridViewCellStyle2.NullValue = null;
            this.StopTime.DefaultCellStyle = dataGridViewCellStyle2;
            this.StopTime.HeaderText = "有效时间";
            this.StopTime.Name = "StopTime";
            this.StopTime.ReadOnly = true;
            this.StopTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.StopTime.Width = 150;
            // 
            // Distance
            // 
            this.Distance.DataPropertyName = "Distance";
            this.Distance.HeaderText = "距离 ";
            this.Distance.Name = "Distance";
            this.Distance.ReadOnly = true;
            this.Distance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Distance.Width = 120;
            // 
            // Unlocked
            // 
            this.Unlocked.DataPropertyName = "Unlocked";
            this.Unlocked.HeaderText = "解锁状态";
            this.Unlocked.Name = "Unlocked";
            this.Unlocked.ReadOnly = true;
            this.Unlocked.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // LoseState
            // 
            this.LoseState.DataPropertyName = "LoseState";
            this.LoseState.HeaderText = "挂失状态";
            this.LoseState.Name = "LoseState";
            this.LoseState.ReadOnly = true;
            this.LoseState.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // UseState
            // 
            this.UseState.DataPropertyName = "UseState";
            this.UseState.HeaderText = "使用状态";
            this.UseState.Name = "UseState";
            this.UseState.ReadOnly = true;
            this.UseState.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FieldPartition
            // 
            this.FieldPartition.DataPropertyName = "FieldPartition";
            this.FieldPartition.HeaderText = "场分区";
            this.FieldPartition.Name = "FieldPartition";
            this.FieldPartition.ReadOnly = true;
            this.FieldPartition.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FieldPartition.Width = 200;
            // 
            // ParkingRestrictions
            // 
            this.ParkingRestrictions.DataPropertyName = "ParkingRestrictions";
            this.ParkingRestrictions.HeaderText = "停车限制";
            this.ParkingRestrictions.Name = "ParkingRestrictions";
            this.ParkingRestrictions.ReadOnly = true;
            this.ParkingRestrictions.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Electricity
            // 
            this.Electricity.DataPropertyName = "Electricity";
            this.Electricity.HeaderText = "电量";
            this.Electricity.Name = "Electricity";
            this.Electricity.ReadOnly = true;
            this.Electricity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // UserSex
            // 
            this.UserSex.DataPropertyName = "UserSex";
            this.UserSex.HeaderText = "性别";
            this.UserSex.Name = "UserSex";
            this.UserSex.ReadOnly = true;
            this.UserSex.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // UserAge
            // 
            this.UserAge.DataPropertyName = "UserAge";
            this.UserAge.HeaderText = "年龄";
            this.UserAge.Name = "UserAge";
            this.UserAge.ReadOnly = true;
            this.UserAge.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // UserPhone
            // 
            this.UserPhone.DataPropertyName = "UserPhone";
            this.UserPhone.HeaderText = "电话呺码";
            this.UserPhone.Name = "UserPhone";
            this.UserPhone.ReadOnly = true;
            this.UserPhone.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UserPhone.Width = 150;
            // 
            // UserAddress
            // 
            this.UserAddress.DataPropertyName = "UserAddress";
            this.UserAddress.HeaderText = "地址";
            this.UserAddress.Name = "UserAddress";
            this.UserAddress.ReadOnly = true;
            this.UserAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UserAddress.Width = 200;
            // 
            // RegistrationTime
            // 
            this.RegistrationTime.DataPropertyName = "RegistrationTime";
            dataGridViewCellStyle3.Format = "f";
            dataGridViewCellStyle3.NullValue = null;
            this.RegistrationTime.DefaultCellStyle = dataGridViewCellStyle3;
            this.RegistrationTime.HeaderText = "注册时间";
            this.RegistrationTime.Name = "RegistrationTime";
            this.RegistrationTime.ReadOnly = true;
            this.RegistrationTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.RegistrationTime.Width = 180;
            // 
            // p_Top
            // 
            this.p_Top.Controls.Add(this.l_SearchTitle);
            this.p_Top.Controls.Add(this.tb_SearchContent);
            this.p_Top.Controls.Add(this.btn_Other);
            this.p_Top.Controls.Add(this.btn_Search);
            this.p_Top.Controls.Add(this.btn_ShowRecord);
            this.p_Top.Controls.Add(this.btn_InformationInput);
            this.p_Top.Controls.Add(this.btn_AddLose);
            this.p_Top.Controls.Add(this.btn_Delay);
            this.p_Top.Controls.Add(this.btn_Refresh);
            this.p_Top.Controls.Add(this.btn_Issue);
            this.p_Top.Controls.Add(this.btn_Print);
            this.p_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.p_Top.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.p_Top.Location = new System.Drawing.Point(0, 0);
            this.p_Top.Name = "p_Top";
            this.p_Top.Size = new System.Drawing.Size(1046, 60);
            this.p_Top.TabIndex = 6;
            // 
            // l_SearchTitle
            // 
            this.l_SearchTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.l_SearchTitle.AutoSize = true;
            this.l_SearchTitle.BackColor = System.Drawing.Color.White;
            this.l_SearchTitle.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.l_SearchTitle.ForeColor = System.Drawing.Color.Gray;
            this.l_SearchTitle.Location = new System.Drawing.Point(755, 20);
            this.l_SearchTitle.Name = "l_SearchTitle";
            this.l_SearchTitle.Size = new System.Drawing.Size(149, 20);
            this.l_SearchTitle.TabIndex = 21;
            this.l_SearchTitle.Text = "卡片编号、车牌号码等";
            // 
            // tb_SearchContent
            // 
            this.tb_SearchContent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_SearchContent.BackColor = System.Drawing.Color.White;
            this.tb_SearchContent.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_SearchContent.Location = new System.Drawing.Point(743, 16);
            this.tb_SearchContent.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.tb_SearchContent.MaxLength = 50;
            this.tb_SearchContent.Name = "tb_SearchContent";
            this.tb_SearchContent.Size = new System.Drawing.Size(200, 29);
            this.tb_SearchContent.TabIndex = 20;
            // 
            // btn_Other
            // 
            this.btn_Other.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_Other.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_Other.FlatAppearance.BorderSize = 0;
            this.btn_Other.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(17)))), ((int)(((byte)(42)))));
            this.btn_Other.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(181)))), ((int)(((byte)(235)))));
            this.btn_Other.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Other.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Other.ForeColor = System.Drawing.Color.White;
            this.btn_Other.Location = new System.Drawing.Point(439, 16);
            this.btn_Other.Name = "btn_Other";
            this.btn_Other.Size = new System.Drawing.Size(100, 29);
            this.btn_Other.TabIndex = 24;
            this.btn_Other.TabStop = false;
            this.btn_Other.Text = "其它功能";
            this.btn_Other.UseVisualStyleBackColor = false;
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
            this.btn_Search.Location = new System.Drawing.Point(943, 16);
            this.btn_Search.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(100, 29);
            this.btn_Search.TabIndex = 22;
            this.btn_Search.TabStop = false;
            this.btn_Search.Text = "搜 索";
            this.btn_Search.UseVisualStyleBackColor = false;
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
            this.btn_ShowRecord.Location = new System.Drawing.Point(651, 16);
            this.btn_ShowRecord.Name = "btn_ShowRecord";
            this.btn_ShowRecord.Size = new System.Drawing.Size(100, 29);
            this.btn_ShowRecord.TabIndex = 19;
            this.btn_ShowRecord.TabStop = false;
            this.btn_ShowRecord.Text = "显示数据";
            this.btn_ShowRecord.UseVisualStyleBackColor = false;
            // 
            // btn_InformationInput
            // 
            this.btn_InformationInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_InformationInput.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_InformationInput.FlatAppearance.BorderSize = 0;
            this.btn_InformationInput.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(17)))), ((int)(((byte)(42)))));
            this.btn_InformationInput.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(181)))), ((int)(((byte)(235)))));
            this.btn_InformationInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_InformationInput.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_InformationInput.ForeColor = System.Drawing.Color.White;
            this.btn_InformationInput.Location = new System.Drawing.Point(545, 16);
            this.btn_InformationInput.Name = "btn_InformationInput";
            this.btn_InformationInput.Size = new System.Drawing.Size(100, 29);
            this.btn_InformationInput.TabIndex = 17;
            this.btn_InformationInput.TabStop = false;
            this.btn_InformationInput.Text = "信息录入";
            this.btn_InformationInput.UseVisualStyleBackColor = false;
            // 
            // btn_AddLose
            // 
            this.btn_AddLose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_AddLose.Enabled = false;
            this.btn_AddLose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_AddLose.FlatAppearance.BorderSize = 0;
            this.btn_AddLose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(17)))), ((int)(((byte)(42)))));
            this.btn_AddLose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(181)))), ((int)(((byte)(235)))));
            this.btn_AddLose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddLose.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_AddLose.ForeColor = System.Drawing.Color.White;
            this.btn_AddLose.Location = new System.Drawing.Point(333, 16);
            this.btn_AddLose.Name = "btn_AddLose";
            this.btn_AddLose.Size = new System.Drawing.Size(100, 29);
            this.btn_AddLose.TabIndex = 16;
            this.btn_AddLose.TabStop = false;
            this.btn_AddLose.Text = "挂 失";
            this.btn_AddLose.UseVisualStyleBackColor = false;
            // 
            // btn_Delay
            // 
            this.btn_Delay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_Delay.Enabled = false;
            this.btn_Delay.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_Delay.FlatAppearance.BorderSize = 0;
            this.btn_Delay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(17)))), ((int)(((byte)(42)))));
            this.btn_Delay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(181)))), ((int)(((byte)(235)))));
            this.btn_Delay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Delay.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Delay.ForeColor = System.Drawing.Color.White;
            this.btn_Delay.Location = new System.Drawing.Point(227, 16);
            this.btn_Delay.Name = "btn_Delay";
            this.btn_Delay.Size = new System.Drawing.Size(100, 29);
            this.btn_Delay.TabIndex = 15;
            this.btn_Delay.TabStop = false;
            this.btn_Delay.Text = "延 期";
            this.btn_Delay.UseVisualStyleBackColor = false;
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btn_Refresh.Enabled = false;
            this.btn_Refresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btn_Refresh.FlatAppearance.BorderSize = 0;
            this.btn_Refresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btn_Refresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(214)))), ((int)(((byte)(141)))));
            this.btn_Refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Refresh.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Refresh.ForeColor = System.Drawing.Color.White;
            this.btn_Refresh.Location = new System.Drawing.Point(15, 16);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(100, 29);
            this.btn_Refresh.TabIndex = 14;
            this.btn_Refresh.TabStop = false;
            this.btn_Refresh.Text = "刷新平台";
            this.btn_Refresh.UseVisualStyleBackColor = false;
            // 
            // btn_Issue
            // 
            this.btn_Issue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_Issue.Enabled = false;
            this.btn_Issue.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_Issue.FlatAppearance.BorderSize = 0;
            this.btn_Issue.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(17)))), ((int)(((byte)(42)))));
            this.btn_Issue.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(181)))), ((int)(((byte)(235)))));
            this.btn_Issue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Issue.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Issue.ForeColor = System.Drawing.Color.White;
            this.btn_Issue.Location = new System.Drawing.Point(121, 16);
            this.btn_Issue.Name = "btn_Issue";
            this.btn_Issue.Size = new System.Drawing.Size(100, 29);
            this.btn_Issue.TabIndex = 13;
            this.btn_Issue.TabStop = false;
            this.btn_Issue.Text = "发 行";
            this.btn_Issue.UseVisualStyleBackColor = false;
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
            this.btn_Print.Location = new System.Drawing.Point(757, 16);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(100, 29);
            this.btn_Print.TabIndex = 18;
            this.btn_Print.TabStop = false;
            this.btn_Print.Text = "打 印";
            this.btn_Print.UseVisualStyleBackColor = false;
            this.btn_Print.Visible = false;
            // 
            // p_Bottom
            // 
            this.p_Bottom.Controls.Add(this.l_PageTile);
            this.p_Bottom.Controls.Add(this.tb_Page);
            this.p_Bottom.Controls.Add(this.btn_PreviousPage);
            this.p_Bottom.Controls.Add(this.btn_FirstPage);
            this.p_Bottom.Controls.Add(this.btn_LastPage);
            this.p_Bottom.Controls.Add(this.btn_NextPage);
            this.p_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.p_Bottom.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.p_Bottom.Location = new System.Drawing.Point(0, 447);
            this.p_Bottom.Name = "p_Bottom";
            this.p_Bottom.Size = new System.Drawing.Size(1046, 50);
            this.p_Bottom.TabIndex = 8;
            // 
            // l_PageTile
            // 
            this.l_PageTile.AutoSize = true;
            this.l_PageTile.Location = new System.Drawing.Point(20, 15);
            this.l_PageTile.Name = "l_PageTile";
            this.l_PageTile.Size = new System.Drawing.Size(176, 21);
            this.l_PageTile.TabIndex = 24;
            this.l_PageTile.Text = "总计 0 条记录，共 1 页";
            // 
            // tb_Page
            // 
            this.tb_Page.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Page.Location = new System.Drawing.Point(898, 11);
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
            this.btn_PreviousPage.Enabled = false;
            this.btn_PreviousPage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_PreviousPage.FlatAppearance.BorderSize = 0;
            this.btn_PreviousPage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(17)))), ((int)(((byte)(42)))));
            this.btn_PreviousPage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(181)))), ((int)(((byte)(235)))));
            this.btn_PreviousPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_PreviousPage.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_PreviousPage.ForeColor = System.Drawing.Color.White;
            this.btn_PreviousPage.Location = new System.Drawing.Point(859, 11);
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
            this.btn_FirstPage.Enabled = false;
            this.btn_FirstPage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_FirstPage.FlatAppearance.BorderSize = 0;
            this.btn_FirstPage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(17)))), ((int)(((byte)(42)))));
            this.btn_FirstPage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(181)))), ((int)(((byte)(235)))));
            this.btn_FirstPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_FirstPage.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_FirstPage.ForeColor = System.Drawing.Color.White;
            this.btn_FirstPage.Location = new System.Drawing.Point(823, 11);
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
            this.btn_LastPage.Enabled = false;
            this.btn_LastPage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_LastPage.FlatAppearance.BorderSize = 0;
            this.btn_LastPage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(17)))), ((int)(((byte)(42)))));
            this.btn_LastPage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(181)))), ((int)(((byte)(235)))));
            this.btn_LastPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_LastPage.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_LastPage.ForeColor = System.Drawing.Color.White;
            this.btn_LastPage.Location = new System.Drawing.Point(990, 11);
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
            this.btn_NextPage.Enabled = false;
            this.btn_NextPage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_NextPage.FlatAppearance.BorderSize = 0;
            this.btn_NextPage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(17)))), ((int)(((byte)(42)))));
            this.btn_NextPage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(181)))), ((int)(((byte)(235)))));
            this.btn_NextPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_NextPage.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_NextPage.ForeColor = System.Drawing.Color.White;
            this.btn_NextPage.Location = new System.Drawing.Point(954, 11);
            this.btn_NextPage.Name = "btn_NextPage";
            this.btn_NextPage.Size = new System.Drawing.Size(33, 29);
            this.btn_NextPage.TabIndex = 19;
            this.btn_NextPage.TabStop = false;
            this.btn_NextPage.Text = ">";
            this.btn_NextPage.UseVisualStyleBackColor = false;
            // 
            // cms_Other
            // 
            this.cms_Other.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cms_Other.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmt_Cancellation,
            this.tsmt_DeferredUpdate,
            this.tsmt_Unlock,
            this.tsmt_Lockup});
            this.cms_Other.Name = "contextMenuStrip1";
            this.cms_Other.ShowImageMargin = false;
            this.cms_Other.Size = new System.Drawing.Size(120, 108);
            // 
            // tsmt_Cancellation
            // 
            this.tsmt_Cancellation.Enabled = false;
            this.tsmt_Cancellation.Name = "tsmt_Cancellation";
            this.tsmt_Cancellation.Size = new System.Drawing.Size(119, 26);
            this.tsmt_Cancellation.Text = "注 销";
            // 
            // tsmt_DeferredUpdate
            // 
            this.tsmt_DeferredUpdate.Name = "tsmt_DeferredUpdate";
            this.tsmt_DeferredUpdate.Size = new System.Drawing.Size(119, 26);
            this.tsmt_DeferredUpdate.Text = "延期更新";
            // 
            // tsmt_Unlock
            // 
            this.tsmt_Unlock.Name = "tsmt_Unlock";
            this.tsmt_Unlock.Size = new System.Drawing.Size(119, 26);
            this.tsmt_Unlock.Text = "解 锁";
            // 
            // tsmt_Lockup
            // 
            this.tsmt_Lockup.Name = "tsmt_Lockup";
            this.tsmt_Lockup.Size = new System.Drawing.Size(119, 26);
            this.tsmt_Lockup.Text = "锁 住";
            // 
            // p_Loss
            // 
            this.p_Loss.Controls.Add(this.cb_AllSelected);
            this.p_Loss.Controls.Add(this.btn_Remove);
            this.p_Loss.Controls.Add(this.btn_Enter);
            this.p_Loss.Controls.Add(this.dgv_LossList);
            this.p_Loss.Controls.Add(this.panel2);
            this.p_Loss.Dock = System.Windows.Forms.DockStyle.Right;
            this.p_Loss.Location = new System.Drawing.Point(666, 60);
            this.p_Loss.Name = "p_Loss";
            this.p_Loss.Padding = new System.Windows.Forms.Padding(1);
            this.p_Loss.Size = new System.Drawing.Size(380, 387);
            this.p_Loss.TabIndex = 9;
            this.p_Loss.Visible = false;
            // 
            // cb_AllSelected
            // 
            this.cb_AllSelected.AutoSize = true;
            this.cb_AllSelected.Enabled = false;
            this.cb_AllSelected.Location = new System.Drawing.Point(17, 55);
            this.cb_AllSelected.Name = "cb_AllSelected";
            this.cb_AllSelected.Size = new System.Drawing.Size(15, 14);
            this.cb_AllSelected.TabIndex = 20;
            this.cb_AllSelected.UseVisualStyleBackColor = true;
            // 
            // btn_Remove
            // 
            this.btn_Remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Remove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_Remove.Enabled = false;
            this.btn_Remove.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_Remove.FlatAppearance.BorderSize = 0;
            this.btn_Remove.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(17)))), ((int)(((byte)(42)))));
            this.btn_Remove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(181)))), ((int)(((byte)(235)))));
            this.btn_Remove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Remove.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Remove.ForeColor = System.Drawing.Color.White;
            this.btn_Remove.Location = new System.Drawing.Point(19, 352);
            this.btn_Remove.Name = "btn_Remove";
            this.btn_Remove.Size = new System.Drawing.Size(100, 29);
            this.btn_Remove.TabIndex = 19;
            this.btn_Remove.TabStop = false;
            this.btn_Remove.Text = "移 除";
            this.btn_Remove.UseVisualStyleBackColor = false;
            // 
            // btn_Enter
            // 
            this.btn_Enter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Enter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btn_Enter.Enabled = false;
            this.btn_Enter.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btn_Enter.FlatAppearance.BorderSize = 0;
            this.btn_Enter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btn_Enter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(214)))), ((int)(((byte)(141)))));
            this.btn_Enter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Enter.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Enter.ForeColor = System.Drawing.Color.White;
            this.btn_Enter.Location = new System.Drawing.Point(259, 352);
            this.btn_Enter.Name = "btn_Enter";
            this.btn_Enter.Size = new System.Drawing.Size(100, 29);
            this.btn_Enter.TabIndex = 18;
            this.btn_Enter.TabStop = false;
            this.btn_Enter.Text = "确 认";
            this.btn_Enter.UseVisualStyleBackColor = false;
            // 
            // dgv_LossList
            // 
            this.dgv_LossList.AllowUserToAddRows = false;
            this.dgv_LossList.AllowUserToDeleteRows = false;
            this.dgv_LossList.AllowUserToResizeColumns = false;
            this.dgv_LossList.AllowUserToResizeRows = false;
            this.dgv_LossList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_LossList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(245)))));
            this.dgv_LossList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_LossList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_LossList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgv_LossList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_LossList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_LossList.ColumnHeadersHeight = 40;
            this.dgv_LossList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_LossList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_LossSelected,
            this.c_LossCardNumber,
            this.c_LossUserName});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_LossList.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_LossList.EnableHeadersVisualStyles = false;
            this.dgv_LossList.Location = new System.Drawing.Point(1, 41);
            this.dgv_LossList.MultiSelect = false;
            this.dgv_LossList.Name = "dgv_LossList";
            this.dgv_LossList.RowHeadersVisible = false;
            this.dgv_LossList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_LossList.RowTemplate.Height = 36;
            this.dgv_LossList.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_LossList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_LossList.Size = new System.Drawing.Size(378, 305);
            this.dgv_LossList.TabIndex = 17;
            // 
            // c_LossSelected
            // 
            this.c_LossSelected.HeaderText = "";
            this.c_LossSelected.Name = "c_LossSelected";
            this.c_LossSelected.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.c_LossSelected.Width = 50;
            // 
            // c_LossCardNumber
            // 
            this.c_LossCardNumber.HeaderText = "卡片编号";
            this.c_LossCardNumber.Name = "c_LossCardNumber";
            this.c_LossCardNumber.ReadOnly = true;
            this.c_LossCardNumber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.c_LossCardNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.c_LossCardNumber.Width = 164;
            // 
            // c_LossUserName
            // 
            this.c_LossUserName.HeaderText = "用户姓名";
            this.c_LossUserName.Name = "c_LossUserName";
            this.c_LossUserName.ReadOnly = true;
            this.c_LossUserName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.c_LossUserName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.c_LossUserName.Width = 164;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(134)))), ((int)(((byte)(254)))));
            this.panel2.Controls.Add(this.btn_LossClose);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(1, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(378, 40);
            this.panel2.TabIndex = 21;
            // 
            // btn_LossClose
            // 
            this.btn_LossClose.FlatAppearance.BorderSize = 0;
            this.btn_LossClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(27)))), ((int)(((byte)(0)))));
            this.btn_LossClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(54)))), ((int)(((byte)(16)))));
            this.btn_LossClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_LossClose.Image = global::CbznSystem.Properties.Resources.NoneClose;
            this.btn_LossClose.Location = new System.Drawing.Point(332, 0);
            this.btn_LossClose.Name = "btn_LossClose";
            this.btn_LossClose.Size = new System.Drawing.Size(46, 31);
            this.btn_LossClose.TabIndex = 1;
            this.btn_LossClose.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(128, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "定距卡挂失列表";
            // 
            // Tab3_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 497);
            this.Controls.Add(this.dgv_CardList);
            this.Controls.Add(this.p_Loss);
            this.Controls.Add(this.p_Top);
            this.Controls.Add(this.p_Bottom);
            this.KeyPreview = true;
            this.Name = "Tab3_Form";
            this.Text = "注册注销管理";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_CardList)).EndInit();
            this.p_Top.ResumeLayout(false);
            this.p_Top.PerformLayout();
            this.p_Bottom.ResumeLayout(false);
            this.p_Bottom.PerformLayout();
            this.cms_Other.ResumeLayout(false);
            this.p_Loss.ResumeLayout(false);
            this.p_Loss.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_LossList)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_CardList;
        private System.Windows.Forms.Panel p_Top;
        private System.Windows.Forms.Button btn_Print;
        private System.Windows.Forms.Button btn_InformationInput;
        private System.Windows.Forms.Button btn_AddLose;
        private System.Windows.Forms.Button btn_Delay;
        private System.Windows.Forms.Button btn_Refresh;
        private System.Windows.Forms.Button btn_Issue;
        private System.Windows.Forms.Panel p_Bottom;
        private System.Windows.Forms.Label l_PageTile;
        private System.Windows.Forms.TextBox tb_Page;
        private System.Windows.Forms.Button btn_PreviousPage;
        private System.Windows.Forms.Button btn_FirstPage;
        private System.Windows.Forms.Button btn_LastPage;
        private System.Windows.Forms.Button btn_NextPage;
        private System.Windows.Forms.Button btn_ShowRecord;
        private System.Windows.Forms.Label l_SearchTitle;
        private System.Windows.Forms.TextBox tb_SearchContent;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Button btn_Other;
        private System.Windows.Forms.ContextMenuStrip cms_Other;
        private System.Windows.Forms.ToolStripMenuItem tsmt_Cancellation;
        private System.Windows.Forms.ToolStripMenuItem tsmt_DeferredUpdate;
        private System.Windows.Forms.ToolStripMenuItem tsmt_Unlock;
        private System.Windows.Forms.ToolStripMenuItem tsmt_Lockup;
        private System.Windows.Forms.Panel p_Loss;
        private System.Windows.Forms.Button btn_Remove;
        private System.Windows.Forms.Button btn_Enter;
        private System.Windows.Forms.DataGridView dgv_LossList;
        private System.Windows.Forms.CheckBox cb_AllSelected;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_LossClose;
        private System.Windows.Forms.DataGridViewCheckBoxColumn c_LossSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_LossCardNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_LossUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardType;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlateNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn StopTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Distance;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unlocked;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoseState;
        private System.Windows.Forms.DataGridViewTextBoxColumn UseState;
        private System.Windows.Forms.DataGridViewTextBoxColumn FieldPartition;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParkingRestrictions;
        private System.Windows.Forms.DataGridViewTextBoxColumn Electricity;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserSex;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserAge;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegistrationTime;
    }
}