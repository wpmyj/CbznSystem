namespace CbznSystem
{
    partial class ManageLog_Form
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
            this.ManageName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Explains = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LogTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_Top = new System.Windows.Forms.Panel();
            this.btn_Print = new System.Windows.Forms.Button();
            this.btn_ShowRecord = new System.Windows.Forms.Button();
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
            this.ManageName,
            this.Explains,
            this.LogTime});
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
            this.dgv_RecordList.Size = new System.Drawing.Size(614, 262);
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
            // ManageName
            // 
            this.ManageName.DataPropertyName = "ManageName";
            this.ManageName.HeaderText = "管理名称";
            this.ManageName.Name = "ManageName";
            this.ManageName.ReadOnly = true;
            // 
            // Explains
            // 
            this.Explains.DataPropertyName = "Explains";
            this.Explains.HeaderText = "操作说明";
            this.Explains.Name = "Explains";
            this.Explains.ReadOnly = true;
            // 
            // LogTime
            // 
            this.LogTime.DataPropertyName = "LogTime";
            dataGridViewCellStyle2.Format = "F";
            dataGridViewCellStyle2.NullValue = null;
            this.LogTime.DefaultCellStyle = dataGridViewCellStyle2;
            this.LogTime.HeaderText = "记录时间";
            this.LogTime.Name = "LogTime";
            this.LogTime.ReadOnly = true;
            this.LogTime.Width = 200;
            // 
            // p_Top
            // 
            this.p_Top.Controls.Add(this.btn_Print);
            this.p_Top.Controls.Add(this.btn_ShowRecord);
            this.p_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.p_Top.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.p_Top.Location = new System.Drawing.Point(0, 0);
            this.p_Top.Name = "p_Top";
            this.p_Top.Size = new System.Drawing.Size(614, 60);
            this.p_Top.TabIndex = 6;
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
            this.btn_Print.Location = new System.Drawing.Point(121, 16);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(100, 29);
            this.btn_Print.TabIndex = 18;
            this.btn_Print.TabStop = false;
            this.btn_Print.Text = "打 印";
            this.btn_Print.UseVisualStyleBackColor = false;
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
            this.btn_ShowRecord.TabIndex = 15;
            this.btn_ShowRecord.TabStop = false;
            this.btn_ShowRecord.Text = "显示记录";
            this.btn_ShowRecord.UseVisualStyleBackColor = false;
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
            this.p_Bottom.Location = new System.Drawing.Point(0, 322);
            this.p_Bottom.Name = "p_Bottom";
            this.p_Bottom.Size = new System.Drawing.Size(614, 50);
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
            this.tb_Page.Location = new System.Drawing.Point(465, 11);
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
            this.btn_PreviousPage.Location = new System.Drawing.Point(426, 11);
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
            this.btn_FirstPage.Location = new System.Drawing.Point(390, 11);
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
            this.btn_LastPage.Location = new System.Drawing.Point(557, 11);
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
            this.btn_NextPage.Location = new System.Drawing.Point(521, 11);
            this.btn_NextPage.Name = "btn_NextPage";
            this.btn_NextPage.Size = new System.Drawing.Size(33, 29);
            this.btn_NextPage.TabIndex = 19;
            this.btn_NextPage.TabStop = false;
            this.btn_NextPage.Text = ">";
            this.btn_NextPage.UseVisualStyleBackColor = false;
            // 
            // ManageLog_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 372);
            this.Controls.Add(this.dgv_RecordList);
            this.Controls.Add(this.p_Top);
            this.Controls.Add(this.p_Bottom);
            this.KeyPreview = true;
            this.Name = "ManageLog_Form";
            this.Text = "操作日志";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_RecordList)).EndInit();
            this.p_Top.ResumeLayout(false);
            this.p_Bottom.ResumeLayout(false);
            this.p_Bottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_RecordList;
        private System.Windows.Forms.Panel p_Top;
        private System.Windows.Forms.Button btn_Print;
        private System.Windows.Forms.Button btn_ShowRecord;
        private System.Windows.Forms.Panel p_Bottom;
        private System.Windows.Forms.Label l_PageTitle;
        private System.Windows.Forms.TextBox tb_Page;
        private System.Windows.Forms.Button btn_PreviousPage;
        private System.Windows.Forms.Button btn_FirstPage;
        private System.Windows.Forms.Button btn_LastPage;
        private System.Windows.Forms.Button btn_NextPage;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ManageName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Explains;
        private System.Windows.Forms.DataGridViewTextBoxColumn LogTime;
    }
}