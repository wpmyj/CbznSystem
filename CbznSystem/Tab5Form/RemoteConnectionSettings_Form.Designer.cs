namespace CbznSystem
{
    partial class RemoteConnectionSettings_Form
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
            this.l_IpAddressTitle = new System.Windows.Forms.Label();
            this.l_LoginNameTitle = new System.Windows.Forms.Label();
            this.l_PasswordTitle = new System.Windows.Forms.Label();
            this.cb_VisitState = new System.Windows.Forms.ComboBox();
            this.tb_LoginName = new System.Windows.Forms.TextBox();
            this.tb_Password = new System.Windows.Forms.TextBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Test = new System.Windows.Forms.Button();
            this.tb_IpAddress = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(42, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "访问方式";
            // 
            // l_IpAddressTitle
            // 
            this.l_IpAddressTitle.AutoSize = true;
            this.l_IpAddressTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_IpAddressTitle.Location = new System.Drawing.Point(28, 122);
            this.l_IpAddressTitle.Name = "l_IpAddressTitle";
            this.l_IpAddressTitle.Size = new System.Drawing.Size(79, 20);
            this.l_IpAddressTitle.TabIndex = 2;
            this.l_IpAddressTitle.Text = "服务器名称";
            // 
            // l_LoginNameTitle
            // 
            this.l_LoginNameTitle.AutoSize = true;
            this.l_LoginNameTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_LoginNameTitle.Location = new System.Drawing.Point(56, 175);
            this.l_LoginNameTitle.Name = "l_LoginNameTitle";
            this.l_LoginNameTitle.Size = new System.Drawing.Size(51, 20);
            this.l_LoginNameTitle.TabIndex = 3;
            this.l_LoginNameTitle.Text = "登录名";
            // 
            // l_PasswordTitle
            // 
            this.l_PasswordTitle.AutoSize = true;
            this.l_PasswordTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_PasswordTitle.Location = new System.Drawing.Point(66, 228);
            this.l_PasswordTitle.Name = "l_PasswordTitle";
            this.l_PasswordTitle.Size = new System.Drawing.Size(41, 20);
            this.l_PasswordTitle.TabIndex = 4;
            this.l_PasswordTitle.Text = " 密码";
            // 
            // cb_VisitState
            // 
            this.cb_VisitState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_VisitState.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_VisitState.FormattingEnabled = true;
            this.cb_VisitState.Items.AddRange(new object[] {
            "本地访问",
            "远程访问"});
            this.cb_VisitState.Location = new System.Drawing.Point(113, 65);
            this.cb_VisitState.Name = "cb_VisitState";
            this.cb_VisitState.Size = new System.Drawing.Size(200, 29);
            this.cb_VisitState.TabIndex = 0;
            // 
            // tb_LoginName
            // 
            this.tb_LoginName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_LoginName.Location = new System.Drawing.Point(113, 171);
            this.tb_LoginName.MaxLength = 100;
            this.tb_LoginName.Name = "tb_LoginName";
            this.tb_LoginName.Size = new System.Drawing.Size(200, 29);
            this.tb_LoginName.TabIndex = 2;
            // 
            // tb_Password
            // 
            this.tb_Password.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_Password.Location = new System.Drawing.Point(113, 224);
            this.tb_Password.MaxLength = 100;
            this.tb_Password.Name = "tb_Password";
            this.tb_Password.PasswordChar = '*';
            this.tb_Password.Size = new System.Drawing.Size(200, 29);
            this.tb_Password.TabIndex = 3;
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btn_Save.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btn_Save.FlatAppearance.BorderSize = 0;
            this.btn_Save.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btn_Save.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(214)))), ((int)(((byte)(141)))));
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Save.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Save.ForeColor = System.Drawing.Color.White;
            this.btn_Save.Location = new System.Drawing.Point(216, 280);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(100, 29);
            this.btn_Save.TabIndex = 5;
            this.btn_Save.TabStop = false;
            this.btn_Save.Text = "保 存";
            this.btn_Save.UseVisualStyleBackColor = false;
            // 
            // btn_Test
            // 
            this.btn_Test.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_Test.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_Test.FlatAppearance.BorderSize = 0;
            this.btn_Test.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(17)))), ((int)(((byte)(42)))));
            this.btn_Test.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(181)))), ((int)(((byte)(235)))));
            this.btn_Test.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Test.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Test.ForeColor = System.Drawing.Color.White;
            this.btn_Test.Location = new System.Drawing.Point(30, 280);
            this.btn_Test.Name = "btn_Test";
            this.btn_Test.Size = new System.Drawing.Size(100, 29);
            this.btn_Test.TabIndex = 4;
            this.btn_Test.TabStop = false;
            this.btn_Test.Text = "测 试";
            this.btn_Test.UseVisualStyleBackColor = false;
            // 
            // tb_IpAddress
            // 
            this.tb_IpAddress.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_IpAddress.Location = new System.Drawing.Point(113, 118);
            this.tb_IpAddress.Name = "tb_IpAddress";
            this.tb_IpAddress.Size = new System.Drawing.Size(200, 29);
            this.tb_IpAddress.TabIndex = 1;
            // 
            // RemoteConnectionSettings_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 330);
            this.Controls.Add(this.tb_IpAddress);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Test);
            this.Controls.Add(this.tb_Password);
            this.Controls.Add(this.tb_LoginName);
            this.Controls.Add(this.cb_VisitState);
            this.Controls.Add(this.l_PasswordTitle);
            this.Controls.Add(this.l_LoginNameTitle);
            this.Controls.Add(this.l_IpAddressTitle);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RemoteConnectionSettings_Form";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "远程连接设置";
            this.WindowMove = false;
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.l_IpAddressTitle, 0);
            this.Controls.SetChildIndex(this.l_LoginNameTitle, 0);
            this.Controls.SetChildIndex(this.l_PasswordTitle, 0);
            this.Controls.SetChildIndex(this.cb_VisitState, 0);
            this.Controls.SetChildIndex(this.tb_LoginName, 0);
            this.Controls.SetChildIndex(this.tb_Password, 0);
            this.Controls.SetChildIndex(this.btn_Test, 0);
            this.Controls.SetChildIndex(this.btn_Save, 0);
            this.Controls.SetChildIndex(this.tb_IpAddress, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label l_IpAddressTitle;
        private System.Windows.Forms.Label l_LoginNameTitle;
        private System.Windows.Forms.Label l_PasswordTitle;
        private System.Windows.Forms.ComboBox cb_VisitState;
        private System.Windows.Forms.TextBox tb_LoginName;
        private System.Windows.Forms.TextBox tb_Password;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Test;
        private System.Windows.Forms.TextBox tb_IpAddress;
    }
}