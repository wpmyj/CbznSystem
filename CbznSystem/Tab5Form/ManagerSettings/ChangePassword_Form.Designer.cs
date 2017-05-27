namespace CbznSystem
{
    partial class ChangePassword_Form
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
            this.label1 = new System.Windows.Forms.Label();
            this.tb_OldPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_NewPassword = new System.Windows.Forms.TextBox();
            this.tb_ConfirmPassword = new System.Windows.Forms.TextBox();
            this.btn_Enter = new System.Windows.Forms.Button();
            this.l_OldTitle = new System.Windows.Forms.Label();
            this.l_NewTitle = new System.Windows.Forms.Label();
            this.l_ConfirmTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(46, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "旧 密 码";
            // 
            // tb_OldPassword
            // 
            this.tb_OldPassword.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_OldPassword.Location = new System.Drawing.Point(111, 60);
            this.tb_OldPassword.MaxLength = 18;
            this.tb_OldPassword.Name = "tb_OldPassword";
            this.tb_OldPassword.Size = new System.Drawing.Size(200, 29);
            this.tb_OldPassword.TabIndex = 0;
            this.tb_OldPassword.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(46, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "新 密 码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(40, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "确认密码";
            // 
            // tb_NewPassword
            // 
            this.tb_NewPassword.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_NewPassword.Location = new System.Drawing.Point(111, 115);
            this.tb_NewPassword.MaxLength = 18;
            this.tb_NewPassword.Name = "tb_NewPassword";
            this.tb_NewPassword.Size = new System.Drawing.Size(200, 29);
            this.tb_NewPassword.TabIndex = 1;
            this.tb_NewPassword.UseSystemPasswordChar = true;
            // 
            // tb_ConfirmPassword
            // 
            this.tb_ConfirmPassword.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_ConfirmPassword.Location = new System.Drawing.Point(111, 170);
            this.tb_ConfirmPassword.MaxLength = 18;
            this.tb_ConfirmPassword.Name = "tb_ConfirmPassword";
            this.tb_ConfirmPassword.Size = new System.Drawing.Size(200, 29);
            this.tb_ConfirmPassword.TabIndex = 2;
            this.tb_ConfirmPassword.UseSystemPasswordChar = true;
            // 
            // btn_Enter
            // 
            this.btn_Enter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btn_Enter.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btn_Enter.FlatAppearance.BorderSize = 0;
            this.btn_Enter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btn_Enter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(214)))), ((int)(((byte)(141)))));
            this.btn_Enter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Enter.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Enter.ForeColor = System.Drawing.Color.White;
            this.btn_Enter.Location = new System.Drawing.Point(75, 216);
            this.btn_Enter.Name = "btn_Enter";
            this.btn_Enter.Size = new System.Drawing.Size(200, 42);
            this.btn_Enter.TabIndex = 3;
            this.btn_Enter.TabStop = false;
            this.btn_Enter.Text = "确 认";
            this.btn_Enter.UseVisualStyleBackColor = false;
            // 
            // l_OldTitle
            // 
            this.l_OldTitle.AutoSize = true;
            this.l_OldTitle.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.l_OldTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_OldTitle.ForeColor = System.Drawing.Color.DarkGray;
            this.l_OldTitle.Location = new System.Drawing.Point(120, 64);
            this.l_OldTitle.Name = "l_OldTitle";
            this.l_OldTitle.Size = new System.Drawing.Size(149, 20);
            this.l_OldTitle.TabIndex = 8;
            this.l_OldTitle.Text = "6-18 位旧密码 ( 必填 )";
            // 
            // l_NewTitle
            // 
            this.l_NewTitle.AutoSize = true;
            this.l_NewTitle.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.l_NewTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_NewTitle.ForeColor = System.Drawing.Color.DarkGray;
            this.l_NewTitle.Location = new System.Drawing.Point(120, 119);
            this.l_NewTitle.Name = "l_NewTitle";
            this.l_NewTitle.Size = new System.Drawing.Size(177, 20);
            this.l_NewTitle.TabIndex = 9;
            this.l_NewTitle.Text = "6-18 位数字、字母 ( 必填 )";
            // 
            // l_ConfirmTitle
            // 
            this.l_ConfirmTitle.AutoSize = true;
            this.l_ConfirmTitle.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.l_ConfirmTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_ConfirmTitle.ForeColor = System.Drawing.Color.DarkGray;
            this.l_ConfirmTitle.Location = new System.Drawing.Point(120, 174);
            this.l_ConfirmTitle.Name = "l_ConfirmTitle";
            this.l_ConfirmTitle.Size = new System.Drawing.Size(177, 20);
            this.l_ConfirmTitle.TabIndex = 10;
            this.l_ConfirmTitle.Text = "6-18 位数字、字母 ( 必填 )";
            // 
            // ChangePassword_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 280);
            this.Controls.Add(this.l_ConfirmTitle);
            this.Controls.Add(this.l_NewTitle);
            this.Controls.Add(this.l_OldTitle);
            this.Controls.Add(this.btn_Enter);
            this.Controls.Add(this.tb_ConfirmPassword);
            this.Controls.Add(this.tb_NewPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_OldPassword);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangePassword_Form";
            this.ShowIcon = false;
            this.Text = "修改密码";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.tb_OldPassword, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.tb_NewPassword, 0);
            this.Controls.SetChildIndex(this.tb_ConfirmPassword, 0);
            this.Controls.SetChildIndex(this.btn_Enter, 0);
            this.Controls.SetChildIndex(this.l_OldTitle, 0);
            this.Controls.SetChildIndex(this.l_NewTitle, 0);
            this.Controls.SetChildIndex(this.l_ConfirmTitle, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_OldPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_NewPassword;
        private System.Windows.Forms.TextBox tb_ConfirmPassword;
        private System.Windows.Forms.Button btn_Enter;
        private System.Windows.Forms.Label l_OldTitle;
        private System.Windows.Forms.Label l_NewTitle;
        private System.Windows.Forms.Label l_ConfirmTitle;
    }
}