namespace CbznSystem
{
    partial class ControlBoardPassword_Form
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
            this.cb_ControlBoardType = new System.Windows.Forms.ComboBox();
            this.tb_NewPassword = new System.Windows.Forms.TextBox();
            this.tb_ConfirmPassword = new System.Windows.Forms.TextBox();
            this.l_NewTitle = new System.Windows.Forms.Label();
            this.l_ConfirmTitle = new System.Windows.Forms.Label();
            this.btn_Enter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cb_ControlBoardType
            // 
            this.cb_ControlBoardType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ControlBoardType.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_ControlBoardType.FormattingEnabled = true;
            this.cb_ControlBoardType.Items.AddRange(new object[] {
            "创建控制板密码",
            "清除控制板密码"});
            this.cb_ControlBoardType.Location = new System.Drawing.Point(50, 60);
            this.cb_ControlBoardType.Name = "cb_ControlBoardType";
            this.cb_ControlBoardType.Size = new System.Drawing.Size(200, 29);
            this.cb_ControlBoardType.TabIndex = 1;
            // 
            // tb_NewPassword
            // 
            this.tb_NewPassword.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_NewPassword.Location = new System.Drawing.Point(50, 110);
            this.tb_NewPassword.MaxLength = 6;
            this.tb_NewPassword.Name = "tb_NewPassword";
            this.tb_NewPassword.Size = new System.Drawing.Size(200, 29);
            this.tb_NewPassword.TabIndex = 2;
            this.tb_NewPassword.UseSystemPasswordChar = true;
            // 
            // tb_ConfirmPassword
            // 
            this.tb_ConfirmPassword.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_ConfirmPassword.Location = new System.Drawing.Point(50, 160);
            this.tb_ConfirmPassword.MaxLength = 6;
            this.tb_ConfirmPassword.Name = "tb_ConfirmPassword";
            this.tb_ConfirmPassword.Size = new System.Drawing.Size(200, 29);
            this.tb_ConfirmPassword.TabIndex = 3;
            this.tb_ConfirmPassword.UseSystemPasswordChar = true;
            // 
            // l_NewTitle
            // 
            this.l_NewTitle.AutoSize = true;
            this.l_NewTitle.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.l_NewTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_NewTitle.ForeColor = System.Drawing.Color.Gray;
            this.l_NewTitle.Location = new System.Drawing.Point(60, 114);
            this.l_NewTitle.Name = "l_NewTitle";
            this.l_NewTitle.Size = new System.Drawing.Size(109, 20);
            this.l_NewTitle.TabIndex = 4;
            this.l_NewTitle.Text = "新密码 6 位数字";
            // 
            // l_ConfirmTitle
            // 
            this.l_ConfirmTitle.AutoSize = true;
            this.l_ConfirmTitle.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.l_ConfirmTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_ConfirmTitle.ForeColor = System.Drawing.Color.Gray;
            this.l_ConfirmTitle.Location = new System.Drawing.Point(60, 164);
            this.l_ConfirmTitle.Name = "l_ConfirmTitle";
            this.l_ConfirmTitle.Size = new System.Drawing.Size(123, 20);
            this.l_ConfirmTitle.TabIndex = 5;
            this.l_ConfirmTitle.Text = "确认密码 6 位数字";
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
            this.btn_Enter.Location = new System.Drawing.Point(50, 200);
            this.btn_Enter.Name = "btn_Enter";
            this.btn_Enter.Size = new System.Drawing.Size(200, 42);
            this.btn_Enter.TabIndex = 6;
            this.btn_Enter.TabStop = false;
            this.btn_Enter.Text = "确 认";
            this.btn_Enter.UseVisualStyleBackColor = false;
            // 
            // ControlBoardPassword_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 260);
            this.Controls.Add(this.btn_Enter);
            this.Controls.Add(this.l_ConfirmTitle);
            this.Controls.Add(this.l_NewTitle);
            this.Controls.Add(this.tb_ConfirmPassword);
            this.Controls.Add(this.tb_NewPassword);
            this.Controls.Add(this.cb_ControlBoardType);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ControlBoardPassword_Form";
            this.ShowIcon = false;
            this.Text = "设置控制板密码";
            this.Controls.SetChildIndex(this.cb_ControlBoardType, 0);
            this.Controls.SetChildIndex(this.tb_NewPassword, 0);
            this.Controls.SetChildIndex(this.tb_ConfirmPassword, 0);
            this.Controls.SetChildIndex(this.l_NewTitle, 0);
            this.Controls.SetChildIndex(this.l_ConfirmTitle, 0);
            this.Controls.SetChildIndex(this.btn_Enter, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_ControlBoardType;
        private System.Windows.Forms.TextBox tb_NewPassword;
        private System.Windows.Forms.TextBox tb_ConfirmPassword;
        private System.Windows.Forms.Label l_NewTitle;
        private System.Windows.Forms.Label l_ConfirmTitle;
        private System.Windows.Forms.Button btn_Enter;
    }
}