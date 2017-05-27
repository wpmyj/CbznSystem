namespace CbznSystem
{
    partial class InformationInput_Form
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
            this.dgv_InfoList = new System.Windows.Forms.DataGridView();
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
            this.btn_Search = new System.Windows.Forms.Button();
            this.l_SearchTitle = new System.Windows.Forms.Label();
            this.tb_SearchContent = new System.Windows.Forms.TextBox();
            this.btn_ShowRecord = new System.Windows.Forms.Button();
            this.btn_Del = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Edit = new System.Windows.Forms.Button();
            this.p_Bottom = new System.Windows.Forms.Panel();
            this.l_PageTile = new System.Windows.Forms.Label();
            this.tb_Page = new System.Windows.Forms.TextBox();
            this.btn_PreviousPage = new System.Windows.Forms.Button();
            this.btn_FirstPage = new System.Windows.Forms.Button();
            this.btn_LastPage = new System.Windows.Forms.Button();
            this.btn_NextPage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_InfoList)).BeginInit();
            this.p_Top.SuspendLayout();
            this.p_Bottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_InfoList
            // 
            this.dgv_InfoList.AllowUserToAddRows = false;
            this.dgv_InfoList.AllowUserToDeleteRows = false;
            this.dgv_InfoList.AllowUserToResizeColumns = false;
            this.dgv_InfoList.AllowUserToResizeRows = false;
            this.dgv_InfoList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(245)))));
            this.dgv_InfoList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_InfoList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_InfoList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgv_InfoList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_InfoList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_InfoList.ColumnHeadersHeight = 40;
            this.dgv_InfoList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_InfoList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_InfoList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_InfoList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_InfoList.EnableHeadersVisualStyles = false;
            this.dgv_InfoList.Location = new System.Drawing.Point(1, 101);
            this.dgv_InfoList.MultiSelect = false;
            this.dgv_InfoList.Name = "dgv_InfoList";
            this.dgv_InfoList.ReadOnly = true;
            this.dgv_InfoList.RowHeadersVisible = false;
            this.dgv_InfoList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_InfoList.RowTemplate.Height = 36;
            this.dgv_InfoList.RowTemplate.ReadOnly = true;
            this.dgv_InfoList.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_InfoList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_InfoList.Size = new System.Drawing.Size(768, 448);
            this.dgv_InfoList.TabIndex = 10;
            this.dgv_InfoList.TabStop = false;
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
            this.CardNumber.Visible = false;
            // 
            // CardType
            // 
            this.CardType.DataPropertyName = "CardType";
            this.CardType.HeaderText = "定距卡类型";
            this.CardType.Name = "CardType";
            this.CardType.ReadOnly = true;
            this.CardType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CardType.Visible = false;
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
            this.StopTime.Visible = false;
            this.StopTime.Width = 120;
            // 
            // Distance
            // 
            this.Distance.DataPropertyName = "Distance";
            this.Distance.HeaderText = "距离 ";
            this.Distance.Name = "Distance";
            this.Distance.ReadOnly = true;
            this.Distance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Distance.Visible = false;
            // 
            // Unlocked
            // 
            this.Unlocked.DataPropertyName = "Unlocked";
            this.Unlocked.HeaderText = "解锁状态";
            this.Unlocked.Name = "Unlocked";
            this.Unlocked.ReadOnly = true;
            this.Unlocked.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Unlocked.Visible = false;
            // 
            // LoseState
            // 
            this.LoseState.DataPropertyName = "LoseState";
            this.LoseState.HeaderText = "挂失状态";
            this.LoseState.Name = "LoseState";
            this.LoseState.ReadOnly = true;
            this.LoseState.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LoseState.Visible = false;
            // 
            // UseState
            // 
            this.UseState.DataPropertyName = "UseState";
            this.UseState.HeaderText = "使用状态";
            this.UseState.Name = "UseState";
            this.UseState.ReadOnly = true;
            this.UseState.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UseState.Visible = false;
            // 
            // FieldPartition
            // 
            this.FieldPartition.DataPropertyName = "FieldPartition";
            this.FieldPartition.HeaderText = "场分区";
            this.FieldPartition.Name = "FieldPartition";
            this.FieldPartition.ReadOnly = true;
            this.FieldPartition.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FieldPartition.Visible = false;
            this.FieldPartition.Width = 200;
            // 
            // ParkingRestrictions
            // 
            this.ParkingRestrictions.DataPropertyName = "ParkingRestrictions";
            this.ParkingRestrictions.HeaderText = "停车限制";
            this.ParkingRestrictions.Name = "ParkingRestrictions";
            this.ParkingRestrictions.ReadOnly = true;
            this.ParkingRestrictions.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ParkingRestrictions.Visible = false;
            // 
            // Electricity
            // 
            this.Electricity.DataPropertyName = "Electricity";
            this.Electricity.HeaderText = "电量";
            this.Electricity.Name = "Electricity";
            this.Electricity.ReadOnly = true;
            this.Electricity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Electricity.Visible = false;
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
            this.RegistrationTime.HeaderText = "注册时间";
            this.RegistrationTime.Name = "RegistrationTime";
            this.RegistrationTime.ReadOnly = true;
            this.RegistrationTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.RegistrationTime.Visible = false;
            // 
            // p_Top
            // 
            this.p_Top.Controls.Add(this.btn_Search);
            this.p_Top.Controls.Add(this.l_SearchTitle);
            this.p_Top.Controls.Add(this.tb_SearchContent);
            this.p_Top.Controls.Add(this.btn_ShowRecord);
            this.p_Top.Controls.Add(this.btn_Del);
            this.p_Top.Controls.Add(this.btn_Add);
            this.p_Top.Controls.Add(this.btn_Edit);
            this.p_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.p_Top.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.p_Top.Location = new System.Drawing.Point(1, 41);
            this.p_Top.Name = "p_Top";
            this.p_Top.Size = new System.Drawing.Size(768, 60);
            this.p_Top.TabIndex = 9;
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
            this.btn_Search.Location = new System.Drawing.Point(665, 16);
            this.btn_Search.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(100, 29);
            this.btn_Search.TabIndex = 22;
            this.btn_Search.TabStop = false;
            this.btn_Search.Text = "搜 索";
            this.btn_Search.UseVisualStyleBackColor = false;
            // 
            // l_SearchTitle
            // 
            this.l_SearchTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.l_SearchTitle.AutoSize = true;
            this.l_SearchTitle.BackColor = System.Drawing.Color.White;
            this.l_SearchTitle.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.l_SearchTitle.ForeColor = System.Drawing.Color.Gray;
            this.l_SearchTitle.Location = new System.Drawing.Point(476, 20);
            this.l_SearchTitle.Name = "l_SearchTitle";
            this.l_SearchTitle.Size = new System.Drawing.Size(149, 20);
            this.l_SearchTitle.TabIndex = 21;
            this.l_SearchTitle.Text = "用户姓名、车牌号码等";
            // 
            // tb_SearchContent
            // 
            this.tb_SearchContent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_SearchContent.BackColor = System.Drawing.Color.White;
            this.tb_SearchContent.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_SearchContent.Location = new System.Drawing.Point(465, 16);
            this.tb_SearchContent.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.tb_SearchContent.MaxLength = 50;
            this.tb_SearchContent.Name = "tb_SearchContent";
            this.tb_SearchContent.Size = new System.Drawing.Size(200, 29);
            this.tb_SearchContent.TabIndex = 20;
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
            this.btn_ShowRecord.Location = new System.Drawing.Point(333, 16);
            this.btn_ShowRecord.Name = "btn_ShowRecord";
            this.btn_ShowRecord.Size = new System.Drawing.Size(100, 29);
            this.btn_ShowRecord.TabIndex = 19;
            this.btn_ShowRecord.TabStop = false;
            this.btn_ShowRecord.Text = "显示数据";
            this.btn_ShowRecord.UseVisualStyleBackColor = false;
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
            this.btn_Del.TabIndex = 15;
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
            this.btn_Add.TabIndex = 14;
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
            this.btn_Edit.TabIndex = 13;
            this.btn_Edit.TabStop = false;
            this.btn_Edit.Text = "编 辑";
            this.btn_Edit.UseVisualStyleBackColor = false;
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
            this.p_Bottom.Location = new System.Drawing.Point(1, 549);
            this.p_Bottom.Name = "p_Bottom";
            this.p_Bottom.Size = new System.Drawing.Size(768, 50);
            this.p_Bottom.TabIndex = 11;
            // 
            // l_PageTile
            // 
            this.l_PageTile.AutoSize = true;
            this.l_PageTile.Location = new System.Drawing.Point(20, 15);
            this.l_PageTile.Name = "l_PageTile";
            this.l_PageTile.Size = new System.Drawing.Size(196, 21);
            this.l_PageTile.TabIndex = 24;
            this.l_PageTile.Text = "总计 {0} 条记录，共 {1} 页";
            // 
            // tb_Page
            // 
            this.tb_Page.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Page.Location = new System.Drawing.Point(620, 11);
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
            this.btn_PreviousPage.Location = new System.Drawing.Point(581, 11);
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
            this.btn_FirstPage.Location = new System.Drawing.Point(545, 11);
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
            this.btn_LastPage.Location = new System.Drawing.Point(712, 11);
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
            this.btn_NextPage.Location = new System.Drawing.Point(676, 11);
            this.btn_NextPage.Name = "btn_NextPage";
            this.btn_NextPage.Size = new System.Drawing.Size(33, 29);
            this.btn_NextPage.TabIndex = 19;
            this.btn_NextPage.TabStop = false;
            this.btn_NextPage.Text = ">";
            this.btn_NextPage.UseVisualStyleBackColor = false;
            // 
            // InformationInput_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 600);
            this.Controls.Add(this.dgv_InfoList);
            this.Controls.Add(this.p_Top);
            this.Controls.Add(this.p_Bottom);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InformationInput_Form";
            this.ShowIcon = false;
            this.Text = "信息录入";
            this.Controls.SetChildIndex(this.p_Bottom, 0);
            this.Controls.SetChildIndex(this.p_Top, 0);
            this.Controls.SetChildIndex(this.dgv_InfoList, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_InfoList)).EndInit();
            this.p_Top.ResumeLayout(false);
            this.p_Top.PerformLayout();
            this.p_Bottom.ResumeLayout(false);
            this.p_Bottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_InfoList;
        private System.Windows.Forms.Panel p_Top;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Label l_SearchTitle;
        private System.Windows.Forms.TextBox tb_SearchContent;
        private System.Windows.Forms.Button btn_ShowRecord;
        private System.Windows.Forms.Button btn_Del;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Edit;
        private System.Windows.Forms.Panel p_Bottom;
        private System.Windows.Forms.Label l_PageTile;
        private System.Windows.Forms.TextBox tb_Page;
        private System.Windows.Forms.Button btn_PreviousPage;
        private System.Windows.Forms.Button btn_FirstPage;
        private System.Windows.Forms.Button btn_LastPage;
        private System.Windows.Forms.Button btn_NextPage;
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