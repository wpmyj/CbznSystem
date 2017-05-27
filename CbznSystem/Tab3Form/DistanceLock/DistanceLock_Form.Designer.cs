namespace CbznSystem
{
    partial class DistanceLock_Form
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
            this.cb_AllSelected = new System.Windows.Forms.CheckBox();
            this.btn_Remove = new System.Windows.Forms.Button();
            this.btn_Enter = new System.Windows.Forms.Button();
            this.dgv_LockList = new System.Windows.Forms.DataGridView();
            this.c_Selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.c_State = new System.Windows.Forms.DataGridViewImageColumn();
            this.CardNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_LockList)).BeginInit();
            this.SuspendLayout();
            // 
            // cb_AllSelected
            // 
            this.cb_AllSelected.AutoSize = true;
            this.cb_AllSelected.Location = new System.Drawing.Point(19, 55);
            this.cb_AllSelected.Name = "cb_AllSelected";
            this.cb_AllSelected.Size = new System.Drawing.Size(15, 14);
            this.cb_AllSelected.TabIndex = 21;
            this.cb_AllSelected.UseVisualStyleBackColor = true;
            // 
            // btn_Remove
            // 
            this.btn_Remove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_Remove.Enabled = false;
            this.btn_Remove.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_Remove.FlatAppearance.BorderSize = 0;
            this.btn_Remove.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(17)))), ((int)(((byte)(42)))));
            this.btn_Remove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(181)))), ((int)(((byte)(235)))));
            this.btn_Remove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Remove.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Remove.ForeColor = System.Drawing.Color.White;
            this.btn_Remove.Location = new System.Drawing.Point(20, 455);
            this.btn_Remove.Name = "btn_Remove";
            this.btn_Remove.Size = new System.Drawing.Size(100, 29);
            this.btn_Remove.TabIndex = 20;
            this.btn_Remove.TabStop = false;
            this.btn_Remove.Text = "移 除";
            this.btn_Remove.UseVisualStyleBackColor = false;
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
            this.btn_Enter.Location = new System.Drawing.Point(260, 455);
            this.btn_Enter.Name = "btn_Enter";
            this.btn_Enter.Size = new System.Drawing.Size(100, 29);
            this.btn_Enter.TabIndex = 19;
            this.btn_Enter.TabStop = false;
            this.btn_Enter.Text = "确 认";
            this.btn_Enter.UseVisualStyleBackColor = false;
            // 
            // dgv_LockList
            // 
            this.dgv_LockList.AllowUserToAddRows = false;
            this.dgv_LockList.AllowUserToDeleteRows = false;
            this.dgv_LockList.AllowUserToResizeColumns = false;
            this.dgv_LockList.AllowUserToResizeRows = false;
            this.dgv_LockList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(245)))));
            this.dgv_LockList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_LockList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_LockList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgv_LockList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_LockList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_LockList.ColumnHeadersHeight = 40;
            this.dgv_LockList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_LockList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_Selected,
            this.c_State,
            this.CardNumber,
            this.UserName});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_LockList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_LockList.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgv_LockList.EnableHeadersVisualStyles = false;
            this.dgv_LockList.Location = new System.Drawing.Point(1, 41);
            this.dgv_LockList.MultiSelect = false;
            this.dgv_LockList.Name = "dgv_LockList";
            this.dgv_LockList.RowHeadersVisible = false;
            this.dgv_LockList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_LockList.RowTemplate.Height = 36;
            this.dgv_LockList.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_LockList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_LockList.Size = new System.Drawing.Size(378, 400);
            this.dgv_LockList.TabIndex = 18;
            // 
            // c_Selected
            // 
            this.c_Selected.HeaderText = "";
            this.c_Selected.Name = "c_Selected";
            this.c_Selected.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.c_Selected.Width = 50;
            // 
            // c_State
            // 
            this.c_State.HeaderText = "状态";
            this.c_State.Name = "c_State";
            this.c_State.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.c_State.Width = 50;
            // 
            // CardNumber
            // 
            this.CardNumber.HeaderText = "卡片编号";
            this.CardNumber.Name = "CardNumber";
            this.CardNumber.ReadOnly = true;
            this.CardNumber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CardNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CardNumber.Width = 130;
            // 
            // UserName
            // 
            this.UserName.HeaderText = "用户姓名";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            this.UserName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.UserName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UserName.Width = 130;
            // 
            // DistanceLock_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 500);
            this.Controls.Add(this.cb_AllSelected);
            this.Controls.Add(this.btn_Remove);
            this.Controls.Add(this.btn_Enter);
            this.Controls.Add(this.dgv_LockList);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DistanceLock_Form";
            this.ShowIcon = false;
            this.Text = "锁住定距卡";
            this.Controls.SetChildIndex(this.dgv_LockList, 0);
            this.Controls.SetChildIndex(this.btn_Enter, 0);
            this.Controls.SetChildIndex(this.btn_Remove, 0);
            this.Controls.SetChildIndex(this.cb_AllSelected, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_LockList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cb_AllSelected;
        private System.Windows.Forms.Button btn_Remove;
        private System.Windows.Forms.Button btn_Enter;
        private System.Windows.Forms.DataGridView dgv_LockList;
        private System.Windows.Forms.DataGridViewCheckBoxColumn c_Selected;
        private System.Windows.Forms.DataGridViewImageColumn c_State;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
    }
}