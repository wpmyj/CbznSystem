namespace CbznSystem
{
    partial class DistanceDelay_Form
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_DataList = new System.Windows.Forms.DataGridView();
            this.cb_AllSelected = new System.Windows.Forms.CheckBox();
            this.btn_Enter = new System.Windows.Forms.Button();
            this.btn_Delays = new System.Windows.Forms.Button();
            this.l_Message = new System.Windows.Forms.Label();
            this.c_Selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CardID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssociateCardNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssociateCardTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubCardDivision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UseState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_Btn = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DataList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_DataList
            // 
            this.dgv_DataList.AllowUserToAddRows = false;
            this.dgv_DataList.AllowUserToDeleteRows = false;
            this.dgv_DataList.AllowUserToResizeColumns = false;
            this.dgv_DataList.AllowUserToResizeRows = false;
            this.dgv_DataList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(245)))));
            this.dgv_DataList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_DataList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_DataList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgv_DataList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_DataList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_DataList.ColumnHeadersHeight = 40;
            this.dgv_DataList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_DataList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_Selected,
            this.ID,
            this.CardID,
            this.AssociateCardNumber,
            this.AssociateCardTime,
            this.UpdateTime,
            this.SubCardDivision,
            this.UseState,
            this.c_Btn});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_DataList.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_DataList.EnableHeadersVisualStyles = false;
            this.dgv_DataList.Location = new System.Drawing.Point(1, 41);
            this.dgv_DataList.Name = "dgv_DataList";
            this.dgv_DataList.RowHeadersVisible = false;
            this.dgv_DataList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_DataList.RowTemplate.Height = 36;
            this.dgv_DataList.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_DataList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_DataList.Size = new System.Drawing.Size(678, 184);
            this.dgv_DataList.TabIndex = 1;
            this.dgv_DataList.TabStop = false;
            // 
            // cb_AllSelected
            // 
            this.cb_AllSelected.AutoSize = true;
            this.cb_AllSelected.Location = new System.Drawing.Point(8, 56);
            this.cb_AllSelected.Name = "cb_AllSelected";
            this.cb_AllSelected.Size = new System.Drawing.Size(15, 14);
            this.cb_AllSelected.TabIndex = 2;
            this.cb_AllSelected.ThreeState = true;
            this.cb_AllSelected.UseVisualStyleBackColor = true;
            // 
            // btn_Enter
            // 
            this.btn_Enter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btn_Enter.Enabled = false;
            this.btn_Enter.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btn_Enter.FlatAppearance.BorderSize = 0;
            this.btn_Enter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btn_Enter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(214)))), ((int)(((byte)(141)))));
            this.btn_Enter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Enter.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Enter.ForeColor = System.Drawing.Color.White;
            this.btn_Enter.Location = new System.Drawing.Point(560, 245);
            this.btn_Enter.Name = "btn_Enter";
            this.btn_Enter.Size = new System.Drawing.Size(100, 29);
            this.btn_Enter.TabIndex = 15;
            this.btn_Enter.TabStop = false;
            this.btn_Enter.Text = "确 认";
            this.btn_Enter.UseVisualStyleBackColor = false;
            // 
            // btn_Delays
            // 
            this.btn_Delays.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_Delays.Enabled = false;
            this.btn_Delays.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_Delays.FlatAppearance.BorderSize = 0;
            this.btn_Delays.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(17)))), ((int)(((byte)(42)))));
            this.btn_Delays.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(181)))), ((int)(((byte)(235)))));
            this.btn_Delays.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Delays.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Delays.ForeColor = System.Drawing.Color.White;
            this.btn_Delays.Location = new System.Drawing.Point(20, 245);
            this.btn_Delays.Name = "btn_Delays";
            this.btn_Delays.Size = new System.Drawing.Size(100, 29);
            this.btn_Delays.TabIndex = 16;
            this.btn_Delays.TabStop = false;
            this.btn_Delays.Text = "批量延期";
            this.btn_Delays.UseVisualStyleBackColor = false;
            // 
            // l_Message
            // 
            this.l_Message.AutoSize = true;
            this.l_Message.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_Message.ForeColor = System.Drawing.Color.Red;
            this.l_Message.Location = new System.Drawing.Point(126, 249);
            this.l_Message.Name = "l_Message";
            this.l_Message.Size = new System.Drawing.Size(317, 20);
            this.l_Message.TabIndex = 17;
            this.l_Message.Text = "提示：定距卡开启车位限制无法修改单张副卡期限";
            this.l_Message.Visible = false;
            // 
            // c_Selected
            // 
            this.c_Selected.HeaderText = "";
            this.c_Selected.Name = "c_Selected";
            this.c_Selected.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.c_Selected.Width = 30;
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
            // CardID
            // 
            this.CardID.DataPropertyName = "CardID";
            this.CardID.HeaderText = "CardID";
            this.CardID.Name = "CardID";
            this.CardID.ReadOnly = true;
            this.CardID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CardID.Visible = false;
            // 
            // AssociateCardNumber
            // 
            this.AssociateCardNumber.DataPropertyName = "AssociateCardNumber";
            this.AssociateCardNumber.HeaderText = "副卡编号";
            this.AssociateCardNumber.Name = "AssociateCardNumber";
            this.AssociateCardNumber.ReadOnly = true;
            this.AssociateCardNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // AssociateCardTime
            // 
            this.AssociateCardTime.DataPropertyName = "AssociateCardTime";
            dataGridViewCellStyle2.Format = "D";
            dataGridViewCellStyle2.NullValue = null;
            this.AssociateCardTime.DefaultCellStyle = dataGridViewCellStyle2;
            this.AssociateCardTime.HeaderText = "副卡时间";
            this.AssociateCardTime.Name = "AssociateCardTime";
            this.AssociateCardTime.ReadOnly = true;
            this.AssociateCardTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.AssociateCardTime.Width = 120;
            // 
            // UpdateTime
            // 
            this.UpdateTime.DataPropertyName = "UpdateTime";
            dataGridViewCellStyle3.Format = "D";
            dataGridViewCellStyle3.NullValue = null;
            this.UpdateTime.DefaultCellStyle = dataGridViewCellStyle3;
            this.UpdateTime.HeaderText = "延期时间";
            this.UpdateTime.Name = "UpdateTime";
            this.UpdateTime.ReadOnly = true;
            this.UpdateTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UpdateTime.Width = 120;
            // 
            // SubCardDivision
            // 
            this.SubCardDivision.DataPropertyName = "SubCardDivision";
            this.SubCardDivision.HeaderText = "副卡分区";
            this.SubCardDivision.Name = "SubCardDivision";
            this.SubCardDivision.ReadOnly = true;
            this.SubCardDivision.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SubCardDivision.Width = 108;
            // 
            // UseState
            // 
            this.UseState.DataPropertyName = "UseState";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.UseState.DefaultCellStyle = dataGridViewCellStyle4;
            this.UseState.HeaderText = "状态";
            this.UseState.Name = "UseState";
            this.UseState.ReadOnly = true;
            this.UseState.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // c_Btn
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.c_Btn.DefaultCellStyle = dataGridViewCellStyle5;
            this.c_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.c_Btn.HeaderText = "操 作";
            this.c_Btn.Name = "c_Btn";
            this.c_Btn.ReadOnly = true;
            this.c_Btn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.c_Btn.Text = "延 期";
            // 
            // DistanceDelay_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 290);
            this.Controls.Add(this.l_Message);
            this.Controls.Add(this.btn_Delays);
            this.Controls.Add(this.btn_Enter);
            this.Controls.Add(this.cb_AllSelected);
            this.Controls.Add(this.dgv_DataList);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DistanceDelay_Form";
            this.ShowIcon = false;
            this.Text = "定距卡延期";
            this.Controls.SetChildIndex(this.dgv_DataList, 0);
            this.Controls.SetChildIndex(this.cb_AllSelected, 0);
            this.Controls.SetChildIndex(this.btn_Enter, 0);
            this.Controls.SetChildIndex(this.btn_Delays, 0);
            this.Controls.SetChildIndex(this.l_Message, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DataList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_DataList;
        private System.Windows.Forms.CheckBox cb_AllSelected;
        private System.Windows.Forms.Button btn_Enter;
        private System.Windows.Forms.Button btn_Delays;
        private System.Windows.Forms.Label l_Message;
        private System.Windows.Forms.DataGridViewCheckBoxColumn c_Selected;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssociateCardNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssociateCardTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubCardDivision;
        private System.Windows.Forms.DataGridViewTextBoxColumn UseState;
        private System.Windows.Forms.DataGridViewButtonColumn c_Btn;
    }
}