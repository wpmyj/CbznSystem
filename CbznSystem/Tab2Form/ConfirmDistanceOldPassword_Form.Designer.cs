namespace CbznSystem
{
    partial class ConfirmDistanceOldPassword_Form
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
            this.tb_OldPassword = new System.Windows.Forms.TextBox();
            this.l_OldTitle = new System.Windows.Forms.Label();
            this.btn_DefaultPassword = new System.Windows.Forms.Button();
            this.btn_Enter = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_OldPassword
            // 
            this.tb_OldPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tb_OldPassword.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_OldPassword.Location = new System.Drawing.Point(47, 95);
            this.tb_OldPassword.MaxLength = 6;
            this.tb_OldPassword.Name = "tb_OldPassword";
            this.tb_OldPassword.Size = new System.Drawing.Size(150, 29);
            this.tb_OldPassword.TabIndex = 0;
            this.tb_OldPassword.UseSystemPasswordChar = true;
            // 
            // l_OldTitle
            // 
            this.l_OldTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.l_OldTitle.AutoSize = true;
            this.l_OldTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_OldTitle.ForeColor = System.Drawing.Color.Gray;
            this.l_OldTitle.Location = new System.Drawing.Point(56, 99);
            this.l_OldTitle.Name = "l_OldTitle";
            this.l_OldTitle.Size = new System.Drawing.Size(137, 20);
            this.l_OldTitle.TabIndex = 1;
            this.l_OldTitle.Text = "系统旧口令 6 位数字";
            // 
            // btn_DefaultPassword
            // 
            this.btn_DefaultPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_DefaultPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_DefaultPassword.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_DefaultPassword.FlatAppearance.BorderSize = 0;
            this.btn_DefaultPassword.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(17)))), ((int)(((byte)(42)))));
            this.btn_DefaultPassword.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(181)))), ((int)(((byte)(235)))));
            this.btn_DefaultPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DefaultPassword.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_DefaultPassword.ForeColor = System.Drawing.Color.White;
            this.btn_DefaultPassword.Location = new System.Drawing.Point(203, 95);
            this.btn_DefaultPassword.Name = "btn_DefaultPassword";
            this.btn_DefaultPassword.Size = new System.Drawing.Size(100, 29);
            this.btn_DefaultPassword.TabIndex = 2;
            this.btn_DefaultPassword.TabStop = false;
            this.btn_DefaultPassword.Text = "出厂默认";
            this.btn_DefaultPassword.UseVisualStyleBackColor = false;
            // 
            // btn_Enter
            // 
            this.btn_Enter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Enter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btn_Enter.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Enter.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btn_Enter.FlatAppearance.BorderSize = 0;
            this.btn_Enter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btn_Enter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(214)))), ((int)(((byte)(141)))));
            this.btn_Enter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Enter.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Enter.ForeColor = System.Drawing.Color.White;
            this.btn_Enter.Location = new System.Drawing.Point(47, 140);
            this.btn_Enter.Name = "btn_Enter";
            this.btn_Enter.Size = new System.Drawing.Size(256, 42);
            this.btn_Enter.TabIndex = 7;
            this.btn_Enter.TabStop = false;
            this.btn_Enter.Text = "确 认";
            this.btn_Enter.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(61, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "此旧口令为当前主机(读头)系统口令";
            // 
            // ConfirmDistanceOldPassword_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 200);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Enter);
            this.Controls.Add(this.btn_DefaultPassword);
            this.Controls.Add(this.l_OldTitle);
            this.Controls.Add(this.tb_OldPassword);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfirmDistanceOldPassword_Form";
            this.ShowIcon = false;
            this.Text = "验证旧口令";
            this.Controls.SetChildIndex(this.tb_OldPassword, 0);
            this.Controls.SetChildIndex(this.l_OldTitle, 0);
            this.Controls.SetChildIndex(this.btn_DefaultPassword, 0);
            this.Controls.SetChildIndex(this.btn_Enter, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_OldPassword;
        private System.Windows.Forms.Label l_OldTitle;
        private System.Windows.Forms.Button btn_DefaultPassword;
        private System.Windows.Forms.Button btn_Enter;
        private System.Windows.Forms.Label label1;
    }
}