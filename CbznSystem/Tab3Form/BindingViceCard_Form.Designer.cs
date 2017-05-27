namespace CbznSystem
{
    partial class BindingViceCard_Form
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
            this.dgv_ViceCardList = new System.Windows.Forms.DataGridView();
            this.c_Selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.c_ViceCardNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_UseUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tb_SearchContent = new System.Windows.Forms.TextBox();
            this.btn_Search = new System.Windows.Forms.Button();
            this.btn_Enter = new System.Windows.Forms.Button();
            this.l_SearchTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ViceCardList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_ViceCardList
            // 
            this.dgv_ViceCardList.AllowUserToAddRows = false;
            this.dgv_ViceCardList.AllowUserToDeleteRows = false;
            this.dgv_ViceCardList.AllowUserToResizeColumns = false;
            this.dgv_ViceCardList.AllowUserToResizeRows = false;
            this.dgv_ViceCardList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgv_ViceCardList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(245)))));
            this.dgv_ViceCardList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_ViceCardList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgv_ViceCardList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_ViceCardList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_ViceCardList.ColumnHeadersHeight = 40;
            this.dgv_ViceCardList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_ViceCardList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_Selected,
            this.c_ViceCardNumber,
            this.c_UseUserName});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_ViceCardList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_ViceCardList.EnableHeadersVisualStyles = false;
            this.dgv_ViceCardList.Location = new System.Drawing.Point(15, 90);
            this.dgv_ViceCardList.MultiSelect = false;
            this.dgv_ViceCardList.Name = "dgv_ViceCardList";
            this.dgv_ViceCardList.RowHeadersVisible = false;
            this.dgv_ViceCardList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_ViceCardList.RowTemplate.Height = 36;
            this.dgv_ViceCardList.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_ViceCardList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ViceCardList.Size = new System.Drawing.Size(420, 323);
            this.dgv_ViceCardList.TabIndex = 2;
            // 
            // c_Selected
            // 
            this.c_Selected.HeaderText = "";
            this.c_Selected.Name = "c_Selected";
            this.c_Selected.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.c_Selected.Width = 30;
            // 
            // c_ViceCardNumber
            // 
            this.c_ViceCardNumber.HeaderText = "副卡编号";
            this.c_ViceCardNumber.Name = "c_ViceCardNumber";
            this.c_ViceCardNumber.ReadOnly = true;
            this.c_ViceCardNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.c_ViceCardNumber.Width = 120;
            // 
            // c_UseUserName
            // 
            this.c_UseUserName.HeaderText = "已绑定的主卡编号";
            this.c_UseUserName.Name = "c_UseUserName";
            this.c_UseUserName.ReadOnly = true;
            this.c_UseUserName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.c_UseUserName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.c_UseUserName.Width = 250;
            // 
            // tb_SearchContent
            // 
            this.tb_SearchContent.BackColor = System.Drawing.Color.White;
            this.tb_SearchContent.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_SearchContent.Location = new System.Drawing.Point(15, 55);
            this.tb_SearchContent.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.tb_SearchContent.Name = "tb_SearchContent";
            this.tb_SearchContent.Size = new System.Drawing.Size(319, 29);
            this.tb_SearchContent.TabIndex = 0;
            // 
            // btn_Search
            // 
            this.btn_Search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_Search.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_Search.FlatAppearance.BorderSize = 0;
            this.btn_Search.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(17)))), ((int)(((byte)(42)))));
            this.btn_Search.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(181)))), ((int)(((byte)(235)))));
            this.btn_Search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Search.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Search.ForeColor = System.Drawing.Color.White;
            this.btn_Search.Location = new System.Drawing.Point(334, 55);
            this.btn_Search.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(100, 29);
            this.btn_Search.TabIndex = 1;
            this.btn_Search.TabStop = false;
            this.btn_Search.Text = "搜 索";
            this.btn_Search.UseVisualStyleBackColor = false;
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
            this.btn_Enter.Location = new System.Drawing.Point(334, 425);
            this.btn_Enter.Name = "btn_Enter";
            this.btn_Enter.Size = new System.Drawing.Size(100, 29);
            this.btn_Enter.TabIndex = 3;
            this.btn_Enter.TabStop = false;
            this.btn_Enter.Text = "确 认";
            this.btn_Enter.UseVisualStyleBackColor = false;
            // 
            // l_SearchTitle
            // 
            this.l_SearchTitle.AutoSize = true;
            this.l_SearchTitle.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.l_SearchTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_SearchTitle.ForeColor = System.Drawing.Color.Gray;
            this.l_SearchTitle.Location = new System.Drawing.Point(25, 59);
            this.l_SearchTitle.Name = "l_SearchTitle";
            this.l_SearchTitle.Size = new System.Drawing.Size(205, 20);
            this.l_SearchTitle.TabIndex = 82;
            this.l_SearchTitle.Text = "搜索使用人员的姓名或卡片编号";
            // 
            // BindingViceCard_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 470);
            this.Controls.Add(this.l_SearchTitle);
            this.Controls.Add(this.btn_Enter);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.tb_SearchContent);
            this.Controls.Add(this.dgv_ViceCardList);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BindingViceCard_Form";
            this.ShowIcon = false;
            this.Text = "副卡";
            this.Controls.SetChildIndex(this.dgv_ViceCardList, 0);
            this.Controls.SetChildIndex(this.tb_SearchContent, 0);
            this.Controls.SetChildIndex(this.btn_Search, 0);
            this.Controls.SetChildIndex(this.btn_Enter, 0);
            this.Controls.SetChildIndex(this.l_SearchTitle, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ViceCardList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgv_ViceCardList;
        private System.Windows.Forms.TextBox tb_SearchContent;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Button btn_Enter;
        private System.Windows.Forms.Label l_SearchTitle;
        private System.Windows.Forms.DataGridViewCheckBoxColumn c_Selected;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_ViceCardNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_UseUserName;
    }
}