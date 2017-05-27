namespace CbznSystem
{
    partial class IcEquipment_Form
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
            this.c_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_Description = new System.Windows.Forms.Panel();
            this.l_Description = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.l_ConfirmTitle = new System.Windows.Forms.Label();
            this.l_NewTitle = new System.Windows.Forms.Label();
            this.l_OldTitle = new System.Windows.Forms.Label();
            this.btn_NewDefault = new System.Windows.Forms.Button();
            this.btn_OldDefault = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.l_Title = new System.Windows.Forms.Label();
            this.tb_ConfirmPwd = new System.Windows.Forms.TextBox();
            this.tb_NewPwd = new System.Windows.Forms.TextBox();
            this.tb_OldPwd = new System.Windows.Forms.TextBox();
            this.btn_Enter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DataContent)).BeginInit();
            this.p_Description.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.dgv_DataContent.Size = new System.Drawing.Size(939, 149);
            this.dgv_DataContent.TabIndex = 11;
            this.dgv_DataContent.TabStop = false;
            // 
            // c_Content
            // 
            this.c_Content.HeaderText = "内 容";
            this.c_Content.Name = "c_Content";
            this.c_Content.ReadOnly = true;
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
            this.p_Description.Size = new System.Drawing.Size(939, 150);
            this.p_Description.TabIndex = 10;
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
            // panel2
            // 
            this.panel2.Controls.Add(this.l_ConfirmTitle);
            this.panel2.Controls.Add(this.l_NewTitle);
            this.panel2.Controls.Add(this.l_OldTitle);
            this.panel2.Controls.Add(this.btn_NewDefault);
            this.panel2.Controls.Add(this.btn_OldDefault);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.l_Title);
            this.panel2.Controls.Add(this.tb_ConfirmPwd);
            this.panel2.Controls.Add(this.tb_NewPwd);
            this.panel2.Controls.Add(this.tb_OldPwd);
            this.panel2.Controls.Add(this.btn_Enter);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(939, 60);
            this.panel2.TabIndex = 9;
            // 
            // l_ConfirmTitle
            // 
            this.l_ConfirmTitle.AutoSize = true;
            this.l_ConfirmTitle.BackColor = System.Drawing.Color.White;
            this.l_ConfirmTitle.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.l_ConfirmTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_ConfirmTitle.ForeColor = System.Drawing.Color.Gray;
            this.l_ConfirmTitle.Location = new System.Drawing.Point(599, 20);
            this.l_ConfirmTitle.Name = "l_ConfirmTitle";
            this.l_ConfirmTitle.Size = new System.Drawing.Size(63, 20);
            this.l_ConfirmTitle.TabIndex = 22;
            this.l_ConfirmTitle.Text = "8 位数字";
            // 
            // l_NewTitle
            // 
            this.l_NewTitle.AutoSize = true;
            this.l_NewTitle.BackColor = System.Drawing.Color.White;
            this.l_NewTitle.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.l_NewTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_NewTitle.ForeColor = System.Drawing.Color.Gray;
            this.l_NewTitle.Location = new System.Drawing.Point(408, 20);
            this.l_NewTitle.Name = "l_NewTitle";
            this.l_NewTitle.Size = new System.Drawing.Size(63, 20);
            this.l_NewTitle.TabIndex = 21;
            this.l_NewTitle.Text = "8 位数字";
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
            this.l_OldTitle.TabIndex = 13;
            this.l_OldTitle.Text = "8 位数字";
            // 
            // btn_NewDefault
            // 
            this.btn_NewDefault.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_NewDefault.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_NewDefault.FlatAppearance.BorderSize = 0;
            this.btn_NewDefault.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(17)))), ((int)(((byte)(42)))));
            this.btn_NewDefault.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(181)))), ((int)(((byte)(235)))));
            this.btn_NewDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_NewDefault.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_NewDefault.ForeColor = System.Drawing.Color.White;
            this.btn_NewDefault.Location = new System.Drawing.Point(686, 16);
            this.btn_NewDefault.Name = "btn_NewDefault";
            this.btn_NewDefault.Size = new System.Drawing.Size(100, 29);
            this.btn_NewDefault.TabIndex = 20;
            this.btn_NewDefault.TabStop = false;
            this.btn_NewDefault.Text = "出厂默认";
            this.btn_NewDefault.UseVisualStyleBackColor = false;
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
            this.btn_OldDefault.TabIndex = 1;
            this.btn_OldDefault.TabStop = false;
            this.btn_OldDefault.Text = "出厂默认";
            this.btn_OldDefault.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(500, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 21);
            this.label4.TabIndex = 18;
            this.label4.Text = "确认口令";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(325, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 21);
            this.label3.TabIndex = 17;
            this.label3.Text = "新口令";
            // 
            // l_Title
            // 
            this.l_Title.AutoSize = true;
            this.l_Title.Location = new System.Drawing.Point(30, 20);
            this.l_Title.Name = "l_Title";
            this.l_Title.Size = new System.Drawing.Size(58, 21);
            this.l_Title.TabIndex = 16;
            this.l_Title.Text = "旧口令";
            // 
            // tb_ConfirmPwd
            // 
            this.tb_ConfirmPwd.BackColor = System.Drawing.Color.White;
            this.tb_ConfirmPwd.Location = new System.Drawing.Point(580, 16);
            this.tb_ConfirmPwd.MaxLength = 8;
            this.tb_ConfirmPwd.Name = "tb_ConfirmPwd";
            this.tb_ConfirmPwd.Size = new System.Drawing.Size(100, 29);
            this.tb_ConfirmPwd.TabIndex = 15;
            this.tb_ConfirmPwd.UseSystemPasswordChar = true;
            // 
            // tb_NewPwd
            // 
            this.tb_NewPwd.BackColor = System.Drawing.Color.White;
            this.tb_NewPwd.Location = new System.Drawing.Point(389, 16);
            this.tb_NewPwd.MaxLength = 8;
            this.tb_NewPwd.Name = "tb_NewPwd";
            this.tb_NewPwd.Size = new System.Drawing.Size(100, 29);
            this.tb_NewPwd.TabIndex = 14;
            this.tb_NewPwd.UseSystemPasswordChar = true;
            // 
            // tb_OldPwd
            // 
            this.tb_OldPwd.BackColor = System.Drawing.Color.White;
            this.tb_OldPwd.Location = new System.Drawing.Point(94, 16);
            this.tb_OldPwd.MaxLength = 8;
            this.tb_OldPwd.Name = "tb_OldPwd";
            this.tb_OldPwd.Size = new System.Drawing.Size(100, 29);
            this.tb_OldPwd.TabIndex = 0;
            this.tb_OldPwd.UseSystemPasswordChar = true;
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
            this.btn_Enter.Location = new System.Drawing.Point(792, 16);
            this.btn_Enter.Name = "btn_Enter";
            this.btn_Enter.Size = new System.Drawing.Size(100, 29);
            this.btn_Enter.TabIndex = 11;
            this.btn_Enter.TabStop = false;
            this.btn_Enter.Text = "确 认";
            this.btn_Enter.UseVisualStyleBackColor = false;
            // 
            // IcEquipment_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 359);
            this.Controls.Add(this.dgv_DataContent);
            this.Controls.Add(this.p_Description);
            this.Controls.Add(this.panel2);
            this.KeyPreview = true;
            this.Name = "IcEquipment_Form";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DataContent)).EndInit();
            this.p_Description.ResumeLayout(false);
            this.p_Description.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_DataContent;
        private System.Windows.Forms.Panel p_Description;
        private System.Windows.Forms.Label l_Description;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label l_ConfirmTitle;
        private System.Windows.Forms.Label l_NewTitle;
        private System.Windows.Forms.Label l_OldTitle;
        private System.Windows.Forms.Button btn_NewDefault;
        private System.Windows.Forms.Button btn_OldDefault;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label l_Title;
        private System.Windows.Forms.TextBox tb_ConfirmPwd;
        private System.Windows.Forms.TextBox tb_NewPwd;
        private System.Windows.Forms.TextBox tb_OldPwd;
        private System.Windows.Forms.Button btn_Enter;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_Content;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_Time;
    }
}