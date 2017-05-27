namespace CbznSystem
{
    partial class DistanceCard_Form
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
            this.dgv_DataContent = new System.Windows.Forms.DataGridView();
            this.c_Content = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_CardType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_Description = new System.Windows.Forms.Panel();
            this.l_Description = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.p_Top = new System.Windows.Forms.Panel();
            this.btn_Enter = new System.Windows.Forms.Button();
            this.l_OldTitle = new System.Windows.Forms.Label();
            this.btn_OldDefault = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_OldPwd = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DataContent)).BeginInit();
            this.p_Description.SuspendLayout();
            this.p_Top.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_DataContent
            // 
            this.dgv_DataContent.AllowUserToAddRows = false;
            this.dgv_DataContent.AllowUserToDeleteRows = false;
            this.dgv_DataContent.AllowUserToResizeColumns = false;
            this.dgv_DataContent.AllowUserToResizeRows = false;
            this.dgv_DataContent.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(245)))));
            this.dgv_DataContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_DataContent.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_DataContent.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgv_DataContent.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_DataContent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_DataContent.ColumnHeadersVisible = false;
            this.dgv_DataContent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_Content,
            this.c_CardType,
            this.c_Time});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_DataContent.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_DataContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_DataContent.EnableHeadersVisualStyles = false;
            this.dgv_DataContent.Location = new System.Drawing.Point(0, 210);
            this.dgv_DataContent.MultiSelect = false;
            this.dgv_DataContent.Name = "dgv_DataContent";
            this.dgv_DataContent.ReadOnly = true;
            this.dgv_DataContent.RowHeadersVisible = false;
            this.dgv_DataContent.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_DataContent.RowTemplate.Height = 36;
            this.dgv_DataContent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_DataContent.Size = new System.Drawing.Size(558, 204);
            this.dgv_DataContent.TabIndex = 8;
            this.dgv_DataContent.TabStop = false;
            // 
            // c_Content
            // 
            this.c_Content.HeaderText = "内 容";
            this.c_Content.Name = "c_Content";
            this.c_Content.ReadOnly = true;
            // 
            // c_CardType
            // 
            this.c_CardType.HeaderText = "定距卡类型";
            this.c_CardType.Name = "c_CardType";
            this.c_CardType.ReadOnly = true;
            // 
            // c_Time
            // 
            this.c_Time.HeaderText = "时 间";
            this.c_Time.Name = "c_Time";
            this.c_Time.ReadOnly = true;
            this.c_Time.Width = 150;
            // 
            // p_Description
            // 
            this.p_Description.Controls.Add(this.l_Description);
            this.p_Description.Controls.Add(this.label1);
            this.p_Description.Dock = System.Windows.Forms.DockStyle.Top;
            this.p_Description.Location = new System.Drawing.Point(0, 60);
            this.p_Description.Name = "p_Description";
            this.p_Description.Size = new System.Drawing.Size(558, 150);
            this.p_Description.TabIndex = 7;
            // 
            // l_Description
            // 
            this.l_Description.AutoSize = true;
            this.l_Description.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_Description.Location = new System.Drawing.Point(56, 38);
            this.l_Description.Name = "l_Description";
            this.l_Description.Size = new System.Drawing.Size(0, 20);
            this.l_Description.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(31, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "注意";
            // 
            // p_Top
            // 
            this.p_Top.Controls.Add(this.btn_Enter);
            this.p_Top.Controls.Add(this.l_OldTitle);
            this.p_Top.Controls.Add(this.btn_OldDefault);
            this.p_Top.Controls.Add(this.label2);
            this.p_Top.Controls.Add(this.tb_OldPwd);
            this.p_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.p_Top.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.p_Top.Location = new System.Drawing.Point(0, 0);
            this.p_Top.Name = "p_Top";
            this.p_Top.Size = new System.Drawing.Size(558, 60);
            this.p_Top.TabIndex = 6;
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
            this.btn_Enter.Location = new System.Drawing.Point(306, 16);
            this.btn_Enter.Name = "btn_Enter";
            this.btn_Enter.Size = new System.Drawing.Size(100, 29);
            this.btn_Enter.TabIndex = 12;
            this.btn_Enter.TabStop = false;
            this.btn_Enter.Text = "确 认";
            this.btn_Enter.UseVisualStyleBackColor = false;
            // 
            // l_OldTitle
            // 
            this.l_OldTitle.AutoSize = true;
            this.l_OldTitle.BackColor = System.Drawing.Color.White;
            this.l_OldTitle.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.l_OldTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_OldTitle.ForeColor = System.Drawing.Color.Gray;
            this.l_OldTitle.Location = new System.Drawing.Point(113, 20);
            this.l_OldTitle.Name = "l_OldTitle";
            this.l_OldTitle.Size = new System.Drawing.Size(63, 20);
            this.l_OldTitle.TabIndex = 9;
            this.l_OldTitle.Text = "6 位数字";
            // 
            // btn_OldDefault
            // 
            this.btn_OldDefault.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_OldDefault.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_OldDefault.FlatAppearance.BorderSize = 0;
            this.btn_OldDefault.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(17)))), ((int)(((byte)(42)))));
            this.btn_OldDefault.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(181)))), ((int)(((byte)(235)))));
            this.btn_OldDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_OldDefault.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_OldDefault.ForeColor = System.Drawing.Color.White;
            this.btn_OldDefault.Location = new System.Drawing.Point(200, 16);
            this.btn_OldDefault.Name = "btn_OldDefault";
            this.btn_OldDefault.Size = new System.Drawing.Size(100, 29);
            this.btn_OldDefault.TabIndex = 11;
            this.btn_OldDefault.TabStop = false;
            this.btn_OldDefault.Text = "出厂默认";
            this.btn_OldDefault.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 21);
            this.label2.TabIndex = 10;
            this.label2.Text = "旧口令";
            // 
            // tb_OldPwd
            // 
            this.tb_OldPwd.BackColor = System.Drawing.Color.White;
            this.tb_OldPwd.Location = new System.Drawing.Point(94, 16);
            this.tb_OldPwd.MaxLength = 6;
            this.tb_OldPwd.Name = "tb_OldPwd";
            this.tb_OldPwd.Size = new System.Drawing.Size(100, 29);
            this.tb_OldPwd.TabIndex = 0;
            this.tb_OldPwd.UseSystemPasswordChar = true;
            // 
            // DistanceCard_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 414);
            this.Controls.Add(this.dgv_DataContent);
            this.Controls.Add(this.p_Description);
            this.Controls.Add(this.p_Top);
            this.KeyPreview = true;
            this.Name = "DistanceCard_Form";
            this.Text = "DistanceCardForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DataContent)).EndInit();
            this.p_Description.ResumeLayout(false);
            this.p_Description.PerformLayout();
            this.p_Top.ResumeLayout(false);
            this.p_Top.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_DataContent;
        private System.Windows.Forms.Panel p_Description;
        private System.Windows.Forms.Label l_Description;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel p_Top;
        private System.Windows.Forms.Label l_OldTitle;
        private System.Windows.Forms.Button btn_OldDefault;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_OldPwd;
        private System.Windows.Forms.Button btn_Enter;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_Content;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_CardType;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_Time;
    }
}