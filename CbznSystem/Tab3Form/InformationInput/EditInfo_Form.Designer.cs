namespace CbznSystem
{
    partial class EditInfo_Form
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_UserName = new System.Windows.Forms.TextBox();
            this.tb_PlateNumber = new System.Windows.Forms.TextBox();
            this.cb_Sex = new System.Windows.Forms.ComboBox();
            this.tb_Phone = new System.Windows.Forms.TextBox();
            this.tb_Address = new System.Windows.Forms.TextBox();
            this.btn_Enter = new System.Windows.Forms.Button();
            this.l_UserNameTitle = new System.Windows.Forms.Label();
            this.l_PlateNumberTitle = new System.Windows.Forms.Label();
            this.l_PhoneTitle = new System.Windows.Forms.Label();
            this.ud_Age = new System.Windows.Forms.NumericUpDown();
            this.btn_SetPlate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ud_Age)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(45, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "用户姓名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(45, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "车牌号码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(53, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "性     别";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(53, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "年     龄";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(45, 244);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "电话号码";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(53, 289);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "地     址";
            // 
            // tb_UserName
            // 
            this.tb_UserName.BackColor = System.Drawing.Color.White;
            this.tb_UserName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_UserName.Location = new System.Drawing.Point(116, 60);
            this.tb_UserName.MaxLength = 4;
            this.tb_UserName.Name = "tb_UserName";
            this.tb_UserName.Size = new System.Drawing.Size(200, 29);
            this.tb_UserName.TabIndex = 0;
            // 
            // tb_PlateNumber
            // 
            this.tb_PlateNumber.BackColor = System.Drawing.Color.White;
            this.tb_PlateNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_PlateNumber.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_PlateNumber.Location = new System.Drawing.Point(116, 105);
            this.tb_PlateNumber.MaxLength = 8;
            this.tb_PlateNumber.Name = "tb_PlateNumber";
            this.tb_PlateNumber.Size = new System.Drawing.Size(200, 29);
            this.tb_PlateNumber.TabIndex = 1;
            // 
            // cb_Sex
            // 
            this.cb_Sex.BackColor = System.Drawing.Color.White;
            this.cb_Sex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Sex.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_Sex.FormattingEnabled = true;
            this.cb_Sex.Items.AddRange(new object[] {
            "男",
            "女"});
            this.cb_Sex.Location = new System.Drawing.Point(116, 150);
            this.cb_Sex.Name = "cb_Sex";
            this.cb_Sex.Size = new System.Drawing.Size(200, 29);
            this.cb_Sex.TabIndex = 2;
            // 
            // tb_Phone
            // 
            this.tb_Phone.BackColor = System.Drawing.Color.White;
            this.tb_Phone.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_Phone.Location = new System.Drawing.Point(116, 240);
            this.tb_Phone.MaxLength = 11;
            this.tb_Phone.Name = "tb_Phone";
            this.tb_Phone.Size = new System.Drawing.Size(200, 29);
            this.tb_Phone.TabIndex = 4;
            // 
            // tb_Address
            // 
            this.tb_Address.BackColor = System.Drawing.Color.White;
            this.tb_Address.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_Address.Location = new System.Drawing.Point(116, 285);
            this.tb_Address.MaxLength = 100;
            this.tb_Address.Multiline = true;
            this.tb_Address.Name = "tb_Address";
            this.tb_Address.Size = new System.Drawing.Size(200, 58);
            this.tb_Address.TabIndex = 5;
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
            this.btn_Enter.Location = new System.Drawing.Point(90, 360);
            this.btn_Enter.Name = "btn_Enter";
            this.btn_Enter.Size = new System.Drawing.Size(200, 42);
            this.btn_Enter.TabIndex = 6;
            this.btn_Enter.TabStop = false;
            this.btn_Enter.Text = "确 认";
            this.btn_Enter.UseVisualStyleBackColor = false;
            // 
            // l_UserNameTitle
            // 
            this.l_UserNameTitle.AutoSize = true;
            this.l_UserNameTitle.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.l_UserNameTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_UserNameTitle.ForeColor = System.Drawing.Color.Red;
            this.l_UserNameTitle.Location = new System.Drawing.Point(125, 64);
            this.l_UserNameTitle.Name = "l_UserNameTitle";
            this.l_UserNameTitle.Size = new System.Drawing.Size(129, 20);
            this.l_UserNameTitle.TabIndex = 14;
            this.l_UserNameTitle.Text = "如：王某某 ( 必填 )";
            // 
            // l_PlateNumberTitle
            // 
            this.l_PlateNumberTitle.AutoSize = true;
            this.l_PlateNumberTitle.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.l_PlateNumberTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_PlateNumberTitle.ForeColor = System.Drawing.Color.DarkGray;
            this.l_PlateNumberTitle.Location = new System.Drawing.Point(125, 109);
            this.l_PlateNumberTitle.Name = "l_PlateNumberTitle";
            this.l_PlateNumberTitle.Size = new System.Drawing.Size(100, 20);
            this.l_PlateNumberTitle.TabIndex = 15;
            this.l_PlateNumberTitle.Text = "如：粤B12345";
            // 
            // l_PhoneTitle
            // 
            this.l_PhoneTitle.AutoSize = true;
            this.l_PhoneTitle.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.l_PhoneTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_PhoneTitle.ForeColor = System.Drawing.Color.DarkGray;
            this.l_PhoneTitle.Location = new System.Drawing.Point(125, 244);
            this.l_PhoneTitle.Name = "l_PhoneTitle";
            this.l_PhoneTitle.Size = new System.Drawing.Size(125, 20);
            this.l_PhoneTitle.TabIndex = 19;
            this.l_PhoneTitle.Text = "如：15112345678";
            // 
            // ud_Age
            // 
            this.ud_Age.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ud_Age.Location = new System.Drawing.Point(116, 195);
            this.ud_Age.Minimum = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.ud_Age.Name = "ud_Age";
            this.ud_Age.Size = new System.Drawing.Size(200, 29);
            this.ud_Age.TabIndex = 3;
            this.ud_Age.Value = new decimal(new int[] {
            18,
            0,
            0,
            0});
            // 
            // btn_SetPlate
            // 
            this.btn_SetPlate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_SetPlate.FlatAppearance.BorderSize = 0;
            this.btn_SetPlate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btn_SetPlate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btn_SetPlate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SetPlate.Image = global::CbznSystem.Properties.Resources.Keyboard;
            this.btn_SetPlate.Location = new System.Drawing.Point(290, 111);
            this.btn_SetPlate.Name = "btn_SetPlate";
            this.btn_SetPlate.Size = new System.Drawing.Size(16, 16);
            this.btn_SetPlate.TabIndex = 21;
            this.btn_SetPlate.TabStop = false;
            this.btn_SetPlate.UseVisualStyleBackColor = true;
            // 
            // EditInfo_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 420);
            this.Controls.Add(this.btn_SetPlate);
            this.Controls.Add(this.ud_Age);
            this.Controls.Add(this.l_PhoneTitle);
            this.Controls.Add(this.l_PlateNumberTitle);
            this.Controls.Add(this.l_UserNameTitle);
            this.Controls.Add(this.btn_Enter);
            this.Controls.Add(this.tb_Address);
            this.Controls.Add(this.tb_Phone);
            this.Controls.Add(this.cb_Sex);
            this.Controls.Add(this.tb_PlateNumber);
            this.Controls.Add(this.tb_UserName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditInfo_Form";
            this.ShowIcon = false;
            this.Text = "编辑信息";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.tb_UserName, 0);
            this.Controls.SetChildIndex(this.tb_PlateNumber, 0);
            this.Controls.SetChildIndex(this.cb_Sex, 0);
            this.Controls.SetChildIndex(this.tb_Phone, 0);
            this.Controls.SetChildIndex(this.tb_Address, 0);
            this.Controls.SetChildIndex(this.btn_Enter, 0);
            this.Controls.SetChildIndex(this.l_UserNameTitle, 0);
            this.Controls.SetChildIndex(this.l_PlateNumberTitle, 0);
            this.Controls.SetChildIndex(this.l_PhoneTitle, 0);
            this.Controls.SetChildIndex(this.ud_Age, 0);
            this.Controls.SetChildIndex(this.btn_SetPlate, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ud_Age)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_UserName;
        private System.Windows.Forms.TextBox tb_PlateNumber;
        private System.Windows.Forms.ComboBox cb_Sex;
        private System.Windows.Forms.TextBox tb_Phone;
        private System.Windows.Forms.TextBox tb_Address;
        private System.Windows.Forms.Button btn_Enter;
        private System.Windows.Forms.Label l_UserNameTitle;
        private System.Windows.Forms.Label l_PlateNumberTitle;
        private System.Windows.Forms.Label l_PhoneTitle;
        private System.Windows.Forms.NumericUpDown ud_Age;
        private System.Windows.Forms.Button btn_SetPlate;
    }
}