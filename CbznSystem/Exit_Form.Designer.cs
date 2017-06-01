namespace CbznSystem
{
    partial class Exit_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Exit_Form));
            this.tb_Pwd = new System.Windows.Forms.TextBox();
            this.l_Title = new System.Windows.Forms.Label();
            this.btn_Enter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_Pwd
            // 
            this.tb_Pwd.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_Pwd.Location = new System.Drawing.Point(67, 75);
            this.tb_Pwd.MaxLength = 18;
            this.tb_Pwd.Name = "tb_Pwd";
            this.tb_Pwd.Size = new System.Drawing.Size(200, 33);
            this.tb_Pwd.TabIndex = 0;
            this.tb_Pwd.UseSystemPasswordChar = true;
            // 
            // l_Title
            // 
            this.l_Title.AutoSize = true;
            this.l_Title.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.l_Title.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_Title.ForeColor = System.Drawing.Color.Gray;
            this.l_Title.Location = new System.Drawing.Point(75, 81);
            this.l_Title.Name = "l_Title";
            this.l_Title.Size = new System.Drawing.Size(93, 20);
            this.l_Title.TabIndex = 2;
            this.l_Title.Text = "输入登录密码";
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
            this.btn_Enter.Location = new System.Drawing.Point(67, 130);
            this.btn_Enter.Name = "btn_Enter";
            this.btn_Enter.Size = new System.Drawing.Size(200, 42);
            this.btn_Enter.TabIndex = 1;
            this.btn_Enter.TabStop = false;
            this.btn_Enter.Text = "登 录";
            this.btn_Enter.UseVisualStyleBackColor = false;
            // 
            // Exit_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 201);
            this.Controls.Add(this.btn_Enter);
            this.Controls.Add(this.l_Title);
            this.Controls.Add(this.tb_Pwd);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "Exit_Form";
            this.ShowIcon = false;
            this.Text = "退出验证";
            this.Controls.SetChildIndex(this.tb_Pwd, 0);
            this.Controls.SetChildIndex(this.l_Title, 0);
            this.Controls.SetChildIndex(this.btn_Enter, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_Pwd;
        private System.Windows.Forms.Label l_Title;
        private System.Windows.Forms.Button btn_Enter;
    }
}