namespace CbznSystem
{
    partial class AddManager_Form
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
            this.tb_Accounts = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_Name = new System.Windows.Forms.TextBox();
            this.tb_Password = new System.Windows.Forms.TextBox();
            this.tb_ConfirmPassword = new System.Windows.Forms.TextBox();
            this.btn_Enter = new System.Windows.Forms.Button();
            this.l_AccountsTitle = new System.Windows.Forms.Label();
            this.l_NameTitle = new System.Windows.Forms.Label();
            this.l_PasswordTitle = new System.Windows.Forms.Label();
            this.l_ConfrimTitle = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_ManageType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(42, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = " 帐    号 ";
            // 
            // tb_Accounts
            // 
            this.tb_Accounts.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_Accounts.Location = new System.Drawing.Point(113, 65);
            this.tb_Accounts.MaxLength = 18;
            this.tb_Accounts.Name = "tb_Accounts";
            this.tb_Accounts.Size = new System.Drawing.Size(200, 29);
            this.tb_Accounts.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(38, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "用户名称";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(46, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "密    码 ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(38, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "确认密码";
            // 
            // tb_Name
            // 
            this.tb_Name.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_Name.Location = new System.Drawing.Point(113, 115);
            this.tb_Name.MaxLength = 10;
            this.tb_Name.Name = "tb_Name";
            this.tb_Name.Size = new System.Drawing.Size(200, 29);
            this.tb_Name.TabIndex = 1;
            // 
            // tb_Password
            // 
            this.tb_Password.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_Password.Location = new System.Drawing.Point(113, 165);
            this.tb_Password.MaxLength = 18;
            this.tb_Password.Name = "tb_Password";
            this.tb_Password.Size = new System.Drawing.Size(200, 29);
            this.tb_Password.TabIndex = 2;
            this.tb_Password.UseSystemPasswordChar = true;
            // 
            // tb_ConfirmPassword
            // 
            this.tb_ConfirmPassword.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_ConfirmPassword.Location = new System.Drawing.Point(113, 215);
            this.tb_ConfirmPassword.MaxLength = 18;
            this.tb_ConfirmPassword.Name = "tb_ConfirmPassword";
            this.tb_ConfirmPassword.Size = new System.Drawing.Size(200, 29);
            this.tb_ConfirmPassword.TabIndex = 3;
            this.tb_ConfirmPassword.UseSystemPasswordChar = true;
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
            this.btn_Enter.Location = new System.Drawing.Point(75, 315);
            this.btn_Enter.Name = "btn_Enter";
            this.btn_Enter.Size = new System.Drawing.Size(200, 42);
            this.btn_Enter.TabIndex = 5;
            this.btn_Enter.TabStop = false;
            this.btn_Enter.Text = "添 加";
            this.btn_Enter.UseVisualStyleBackColor = false;
            // 
            // l_AccountsTitle
            // 
            this.l_AccountsTitle.AutoSize = true;
            this.l_AccountsTitle.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.l_AccountsTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_AccountsTitle.ForeColor = System.Drawing.Color.DarkGray;
            this.l_AccountsTitle.Location = new System.Drawing.Point(120, 69);
            this.l_AccountsTitle.Name = "l_AccountsTitle";
            this.l_AccountsTitle.Size = new System.Drawing.Size(177, 20);
            this.l_AccountsTitle.TabIndex = 10;
            this.l_AccountsTitle.Text = "6-18 位数字、字母 ( 必填 )";
            // 
            // l_NameTitle
            // 
            this.l_NameTitle.AutoSize = true;
            this.l_NameTitle.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.l_NameTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_NameTitle.ForeColor = System.Drawing.Color.DarkGray;
            this.l_NameTitle.Location = new System.Drawing.Point(120, 119);
            this.l_NameTitle.Name = "l_NameTitle";
            this.l_NameTitle.Size = new System.Drawing.Size(129, 20);
            this.l_NameTitle.TabIndex = 11;
            this.l_NameTitle.Text = "管理员名称 ( 必填 )";
            // 
            // l_PasswordTitle
            // 
            this.l_PasswordTitle.AutoSize = true;
            this.l_PasswordTitle.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.l_PasswordTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_PasswordTitle.ForeColor = System.Drawing.Color.DarkGray;
            this.l_PasswordTitle.Location = new System.Drawing.Point(120, 169);
            this.l_PasswordTitle.Name = "l_PasswordTitle";
            this.l_PasswordTitle.Size = new System.Drawing.Size(177, 20);
            this.l_PasswordTitle.TabIndex = 12;
            this.l_PasswordTitle.Text = "6-18 位数字、字母 ( 必填 )";
            // 
            // l_ConfrimTitle
            // 
            this.l_ConfrimTitle.AutoSize = true;
            this.l_ConfrimTitle.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.l_ConfrimTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_ConfrimTitle.ForeColor = System.Drawing.Color.DarkGray;
            this.l_ConfrimTitle.Location = new System.Drawing.Point(120, 219);
            this.l_ConfrimTitle.Name = "l_ConfrimTitle";
            this.l_ConfrimTitle.Size = new System.Drawing.Size(177, 20);
            this.l_ConfrimTitle.TabIndex = 13;
            this.l_ConfrimTitle.Text = "6-18 位数字、字母 ( 必填 )";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(38, 269);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "用户类型";
            // 
            // cb_ManageType
            // 
            this.cb_ManageType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ManageType.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_ManageType.FormattingEnabled = true;
            this.cb_ManageType.Items.AddRange(new object[] {
            "管理员"});
            this.cb_ManageType.Location = new System.Drawing.Point(113, 265);
            this.cb_ManageType.Name = "cb_ManageType";
            this.cb_ManageType.Size = new System.Drawing.Size(200, 29);
            this.cb_ManageType.TabIndex = 4;
            // 
            // AddManager_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 380);
            this.Controls.Add(this.cb_ManageType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.l_ConfrimTitle);
            this.Controls.Add(this.l_PasswordTitle);
            this.Controls.Add(this.l_NameTitle);
            this.Controls.Add(this.l_AccountsTitle);
            this.Controls.Add(this.btn_Enter);
            this.Controls.Add(this.tb_ConfirmPassword);
            this.Controls.Add(this.tb_Password);
            this.Controls.Add(this.tb_Name);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_Accounts);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddManager_Form";
            this.ShowIcon = false;
            this.Text = "添加管理员";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.tb_Accounts, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.tb_Name, 0);
            this.Controls.SetChildIndex(this.tb_Password, 0);
            this.Controls.SetChildIndex(this.tb_ConfirmPassword, 0);
            this.Controls.SetChildIndex(this.btn_Enter, 0);
            this.Controls.SetChildIndex(this.l_AccountsTitle, 0);
            this.Controls.SetChildIndex(this.l_NameTitle, 0);
            this.Controls.SetChildIndex(this.l_PasswordTitle, 0);
            this.Controls.SetChildIndex(this.l_ConfrimTitle, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.cb_ManageType, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_Accounts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_Name;
        private System.Windows.Forms.TextBox tb_Password;
        private System.Windows.Forms.TextBox tb_ConfirmPassword;
        private System.Windows.Forms.Button btn_Enter;
        private System.Windows.Forms.Label l_AccountsTitle;
        private System.Windows.Forms.Label l_NameTitle;
        private System.Windows.Forms.Label l_PasswordTitle;
        private System.Windows.Forms.Label l_ConfrimTitle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_ManageType;
    }
}