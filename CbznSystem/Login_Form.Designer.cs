namespace CbznSystem
{
    partial class Login_Form
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
            this.tb_Accounts = new System.Windows.Forms.TextBox();
            this.l_AccountsTitle = new System.Windows.Forms.Label();
            this.l_PasswordTitle = new System.Windows.Forms.Label();
            this.tb_Password = new System.Windows.Forms.TextBox();
            this.btn_Enter = new System.Windows.Forms.Button();
            this.cb_RecordPassword = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_Accounts
            // 
            this.tb_Accounts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tb_Accounts.BackColor = System.Drawing.Color.White;
            this.tb_Accounts.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_Accounts.Location = new System.Drawing.Point(70, 177);
            this.tb_Accounts.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.tb_Accounts.MaxLength = 18;
            this.tb_Accounts.Name = "tb_Accounts";
            this.tb_Accounts.Size = new System.Drawing.Size(200, 29);
            this.tb_Accounts.TabIndex = 0;
            // 
            // l_AccountsTitle
            // 
            this.l_AccountsTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.l_AccountsTitle.AutoSize = true;
            this.l_AccountsTitle.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.l_AccountsTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_AccountsTitle.ForeColor = System.Drawing.Color.Gray;
            this.l_AccountsTitle.Location = new System.Drawing.Point(80, 181);
            this.l_AccountsTitle.Name = "l_AccountsTitle";
            this.l_AccountsTitle.Size = new System.Drawing.Size(37, 20);
            this.l_AccountsTitle.TabIndex = 3;
            this.l_AccountsTitle.Text = "帐号\r\n";
            // 
            // l_PasswordTitle
            // 
            this.l_PasswordTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.l_PasswordTitle.AutoSize = true;
            this.l_PasswordTitle.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.l_PasswordTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_PasswordTitle.ForeColor = System.Drawing.Color.Gray;
            this.l_PasswordTitle.Location = new System.Drawing.Point(80, 210);
            this.l_PasswordTitle.Name = "l_PasswordTitle";
            this.l_PasswordTitle.Size = new System.Drawing.Size(37, 20);
            this.l_PasswordTitle.TabIndex = 5;
            this.l_PasswordTitle.Text = "密码";
            // 
            // tb_Password
            // 
            this.tb_Password.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tb_Password.BackColor = System.Drawing.Color.White;
            this.tb_Password.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_Password.Location = new System.Drawing.Point(70, 206);
            this.tb_Password.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tb_Password.MaxLength = 18;
            this.tb_Password.Name = "tb_Password";
            this.tb_Password.Size = new System.Drawing.Size(200, 29);
            this.tb_Password.TabIndex = 1;
            this.tb_Password.UseSystemPasswordChar = true;
            // 
            // btn_Enter
            // 
            this.btn_Enter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Enter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btn_Enter.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btn_Enter.FlatAppearance.BorderSize = 0;
            this.btn_Enter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btn_Enter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(214)))), ((int)(((byte)(141)))));
            this.btn_Enter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Enter.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Enter.ForeColor = System.Drawing.Color.White;
            this.btn_Enter.Location = new System.Drawing.Point(70, 269);
            this.btn_Enter.Name = "btn_Enter";
            this.btn_Enter.Size = new System.Drawing.Size(200, 42);
            this.btn_Enter.TabIndex = 3;
            this.btn_Enter.TabStop = false;
            this.btn_Enter.Text = "登 录";
            this.btn_Enter.UseVisualStyleBackColor = false;
            // 
            // cb_RecordPassword
            // 
            this.cb_RecordPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_RecordPassword.AutoSize = true;
            this.cb_RecordPassword.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_RecordPassword.ForeColor = System.Drawing.Color.DimGray;
            this.cb_RecordPassword.Location = new System.Drawing.Point(70, 242);
            this.cb_RecordPassword.Name = "cb_RecordPassword";
            this.cb_RecordPassword.Size = new System.Drawing.Size(75, 21);
            this.cb_RecordPassword.TabIndex = 2;
            this.cb_RecordPassword.Text = "记住密码";
            this.cb_RecordPassword.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(134)))), ((int)(((byte)(254)))));
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::CbznSystem.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(1, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(338, 120);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // Login_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 330);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cb_RecordPassword);
            this.Controls.Add(this.btn_Enter);
            this.Controls.Add(this.l_PasswordTitle);
            this.Controls.Add(this.tb_Password);
            this.Controls.Add(this.l_AccountsTitle);
            this.Controls.Add(this.tb_Accounts);
            this.Name = "Login_Form";
            this.SettingsBox = true;
            this.ShowIcon = false;
            this.Text = "";
            this.Controls.SetChildIndex(this.tb_Accounts, 0);
            this.Controls.SetChildIndex(this.l_AccountsTitle, 0);
            this.Controls.SetChildIndex(this.tb_Password, 0);
            this.Controls.SetChildIndex(this.l_PasswordTitle, 0);
            this.Controls.SetChildIndex(this.btn_Enter, 0);
            this.Controls.SetChildIndex(this.cb_RecordPassword, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_Accounts;
        private System.Windows.Forms.Label l_AccountsTitle;
        private System.Windows.Forms.Label l_PasswordTitle;
        private System.Windows.Forms.TextBox tb_Password;
        private System.Windows.Forms.Button btn_Enter;
        private System.Windows.Forms.CheckBox cb_RecordPassword;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}