namespace CbznSystem
{
    partial class PlatformSetting_Form
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
            this.rbtn_AutoConnection = new System.Windows.Forms.RadioButton();
            this.rbtn_ManualConnection = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_SerialPortName = new System.Windows.Forms.ComboBox();
            this.btn_SerialPortConnection = new System.Windows.Forms.Button();
            this.l_ConnectionState = new System.Windows.Forms.Label();
            this.gb_WirelessSettings = new System.Windows.Forms.GroupBox();
            this.btn_ManualConnection = new System.Windows.Forms.Button();
            this.ud_WirelessFrequency = new System.Windows.Forms.NumericUpDown();
            this.ud_WirelessId = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_ManualSetting = new System.Windows.Forms.CheckBox();
            this.l_ModuleConnectionState = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_ModuleConnection = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_WirelessIdList = new System.Windows.Forms.ComboBox();
            this.gb_SerialPortSettings = new System.Windows.Forms.GroupBox();
            this.gb_WirelessSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ud_WirelessFrequency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ud_WirelessId)).BeginInit();
            this.gb_SerialPortSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbtn_AutoConnection
            // 
            this.rbtn_AutoConnection.AutoSize = true;
            this.rbtn_AutoConnection.Checked = true;
            this.rbtn_AutoConnection.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbtn_AutoConnection.Location = new System.Drawing.Point(38, 42);
            this.rbtn_AutoConnection.Name = "rbtn_AutoConnection";
            this.rbtn_AutoConnection.Size = new System.Drawing.Size(92, 25);
            this.rbtn_AutoConnection.TabIndex = 0;
            this.rbtn_AutoConnection.TabStop = true;
            this.rbtn_AutoConnection.Text = "自动连接";
            this.rbtn_AutoConnection.UseVisualStyleBackColor = true;
            // 
            // rbtn_ManualConnection
            // 
            this.rbtn_ManualConnection.AutoSize = true;
            this.rbtn_ManualConnection.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbtn_ManualConnection.Location = new System.Drawing.Point(38, 83);
            this.rbtn_ManualConnection.Name = "rbtn_ManualConnection";
            this.rbtn_ManualConnection.Size = new System.Drawing.Size(92, 25);
            this.rbtn_ManualConnection.TabIndex = 1;
            this.rbtn_ManualConnection.Text = "手动连接";
            this.rbtn_ManualConnection.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(290, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "串口连接状态：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(165, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "串口号：";
            // 
            // cb_SerialPortName
            // 
            this.cb_SerialPortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_SerialPortName.Enabled = false;
            this.cb_SerialPortName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_SerialPortName.FormattingEnabled = true;
            this.cb_SerialPortName.Location = new System.Drawing.Point(245, 81);
            this.cb_SerialPortName.Name = "cb_SerialPortName";
            this.cb_SerialPortName.Size = new System.Drawing.Size(167, 29);
            this.cb_SerialPortName.TabIndex = 2;
            // 
            // btn_SerialPortConnection
            // 
            this.btn_SerialPortConnection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btn_SerialPortConnection.Enabled = false;
            this.btn_SerialPortConnection.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btn_SerialPortConnection.FlatAppearance.BorderSize = 0;
            this.btn_SerialPortConnection.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btn_SerialPortConnection.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(214)))), ((int)(((byte)(141)))));
            this.btn_SerialPortConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SerialPortConnection.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_SerialPortConnection.ForeColor = System.Drawing.Color.White;
            this.btn_SerialPortConnection.Location = new System.Drawing.Point(418, 81);
            this.btn_SerialPortConnection.Name = "btn_SerialPortConnection";
            this.btn_SerialPortConnection.Size = new System.Drawing.Size(100, 29);
            this.btn_SerialPortConnection.TabIndex = 3;
            this.btn_SerialPortConnection.TabStop = false;
            this.btn_SerialPortConnection.Text = "打 开";
            this.btn_SerialPortConnection.UseVisualStyleBackColor = false;
            // 
            // l_ConnectionState
            // 
            this.l_ConnectionState.AutoSize = true;
            this.l_ConnectionState.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_ConnectionState.ForeColor = System.Drawing.Color.Red;
            this.l_ConnectionState.Location = new System.Drawing.Point(439, 44);
            this.l_ConnectionState.Name = "l_ConnectionState";
            this.l_ConnectionState.Size = new System.Drawing.Size(58, 21);
            this.l_ConnectionState.TabIndex = 14;
            this.l_ConnectionState.Text = "已断开";
            // 
            // gb_WirelessSettings
            // 
            this.gb_WirelessSettings.Controls.Add(this.btn_ManualConnection);
            this.gb_WirelessSettings.Controls.Add(this.ud_WirelessFrequency);
            this.gb_WirelessSettings.Controls.Add(this.ud_WirelessId);
            this.gb_WirelessSettings.Controls.Add(this.label7);
            this.gb_WirelessSettings.Controls.Add(this.label3);
            this.gb_WirelessSettings.Controls.Add(this.cb_ManualSetting);
            this.gb_WirelessSettings.Controls.Add(this.l_ModuleConnectionState);
            this.gb_WirelessSettings.Controls.Add(this.label6);
            this.gb_WirelessSettings.Controls.Add(this.btn_ModuleConnection);
            this.gb_WirelessSettings.Controls.Add(this.label4);
            this.gb_WirelessSettings.Controls.Add(this.cb_WirelessIdList);
            this.gb_WirelessSettings.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gb_WirelessSettings.Location = new System.Drawing.Point(30, 184);
            this.gb_WirelessSettings.Name = "gb_WirelessSettings";
            this.gb_WirelessSettings.Size = new System.Drawing.Size(557, 270);
            this.gb_WirelessSettings.TabIndex = 15;
            this.gb_WirelessSettings.TabStop = false;
            this.gb_WirelessSettings.Text = "无线通信设置";
            // 
            // btn_ManualConnection
            // 
            this.btn_ManualConnection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btn_ManualConnection.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btn_ManualConnection.FlatAppearance.BorderSize = 0;
            this.btn_ManualConnection.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btn_ManualConnection.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(214)))), ((int)(((byte)(141)))));
            this.btn_ManualConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ManualConnection.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ManualConnection.ForeColor = System.Drawing.Color.White;
            this.btn_ManualConnection.Location = new System.Drawing.Point(418, 220);
            this.btn_ManualConnection.Name = "btn_ManualConnection";
            this.btn_ManualConnection.Size = new System.Drawing.Size(100, 29);
            this.btn_ManualConnection.TabIndex = 21;
            this.btn_ManualConnection.TabStop = false;
            this.btn_ManualConnection.Text = "手动连接";
            this.btn_ManualConnection.UseVisualStyleBackColor = false;
            // 
            // ud_WirelessFrequency
            // 
            this.ud_WirelessFrequency.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ud_WirelessFrequency.Location = new System.Drawing.Point(245, 220);
            this.ud_WirelessFrequency.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.ud_WirelessFrequency.Name = "ud_WirelessFrequency";
            this.ud_WirelessFrequency.Size = new System.Drawing.Size(167, 29);
            this.ud_WirelessFrequency.TabIndex = 20;
            // 
            // ud_WirelessId
            // 
            this.ud_WirelessId.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ud_WirelessId.Location = new System.Drawing.Point(245, 170);
            this.ud_WirelessId.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.ud_WirelessId.Name = "ud_WirelessId";
            this.ud_WirelessId.Size = new System.Drawing.Size(167, 29);
            this.ud_WirelessId.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(117, 224);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 21);
            this.label7.TabIndex = 18;
            this.label7.Text = "像机通信频道：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(133, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 21);
            this.label3.TabIndex = 17;
            this.label3.Text = "像机序列号：";
            // 
            // cb_ManualSetting
            // 
            this.cb_ManualSetting.AutoSize = true;
            this.cb_ManualSetting.Location = new System.Drawing.Point(38, 126);
            this.cb_ManualSetting.Name = "cb_ManualSetting";
            this.cb_ManualSetting.Size = new System.Drawing.Size(322, 24);
            this.cb_ManualSetting.TabIndex = 2;
            this.cb_ManualSetting.Text = "附加功能 (只有在自动搜索不正常的情况下使用)";
            this.cb_ManualSetting.UseVisualStyleBackColor = true;
            // 
            // l_ModuleConnectionState
            // 
            this.l_ModuleConnectionState.AutoSize = true;
            this.l_ModuleConnectionState.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_ModuleConnectionState.ForeColor = System.Drawing.Color.Red;
            this.l_ModuleConnectionState.Location = new System.Drawing.Point(439, 36);
            this.l_ModuleConnectionState.Name = "l_ModuleConnectionState";
            this.l_ModuleConnectionState.Size = new System.Drawing.Size(58, 21);
            this.l_ModuleConnectionState.TabIndex = 16;
            this.l_ModuleConnectionState.Text = "末连接";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(258, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(154, 21);
            this.label6.TabIndex = 15;
            this.label6.Text = "无线通信连接状态：";
            // 
            // btn_ModuleConnection
            // 
            this.btn_ModuleConnection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btn_ModuleConnection.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btn_ModuleConnection.FlatAppearance.BorderSize = 0;
            this.btn_ModuleConnection.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btn_ModuleConnection.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(214)))), ((int)(((byte)(141)))));
            this.btn_ModuleConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ModuleConnection.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ModuleConnection.ForeColor = System.Drawing.Color.White;
            this.btn_ModuleConnection.Location = new System.Drawing.Point(418, 76);
            this.btn_ModuleConnection.Name = "btn_ModuleConnection";
            this.btn_ModuleConnection.Size = new System.Drawing.Size(100, 29);
            this.btn_ModuleConnection.TabIndex = 1;
            this.btn_ModuleConnection.TabStop = false;
            this.btn_ModuleConnection.Text = "连 接";
            this.btn_ModuleConnection.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(85, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 21);
            this.label4.TabIndex = 14;
            this.label4.Text = "出口编号(主机 ID)：";
            // 
            // cb_WirelessIdList
            // 
            this.cb_WirelessIdList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_WirelessIdList.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_WirelessIdList.Items.AddRange(new object[] {
            "请选择(关闭)"});
            this.cb_WirelessIdList.Location = new System.Drawing.Point(245, 76);
            this.cb_WirelessIdList.Name = "cb_WirelessIdList";
            this.cb_WirelessIdList.Size = new System.Drawing.Size(167, 29);
            this.cb_WirelessIdList.TabIndex = 0;
            // 
            // gb_SerialPortSettings
            // 
            this.gb_SerialPortSettings.Controls.Add(this.rbtn_AutoConnection);
            this.gb_SerialPortSettings.Controls.Add(this.rbtn_ManualConnection);
            this.gb_SerialPortSettings.Controls.Add(this.l_ConnectionState);
            this.gb_SerialPortSettings.Controls.Add(this.label1);
            this.gb_SerialPortSettings.Controls.Add(this.btn_SerialPortConnection);
            this.gb_SerialPortSettings.Controls.Add(this.label2);
            this.gb_SerialPortSettings.Controls.Add(this.cb_SerialPortName);
            this.gb_SerialPortSettings.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gb_SerialPortSettings.Location = new System.Drawing.Point(30, 25);
            this.gb_SerialPortSettings.Name = "gb_SerialPortSettings";
            this.gb_SerialPortSettings.Size = new System.Drawing.Size(557, 130);
            this.gb_SerialPortSettings.TabIndex = 16;
            this.gb_SerialPortSettings.TabStop = false;
            this.gb_SerialPortSettings.Text = "通信端口设置";
            // 
            // PlatformSetting_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 492);
            this.Controls.Add(this.gb_SerialPortSettings);
            this.Controls.Add(this.gb_WirelessSettings);
            this.KeyPreview = true;
            this.Name = "PlatformSetting_Form";
            this.Text = "多功能操作台设置";
            this.gb_WirelessSettings.ResumeLayout(false);
            this.gb_WirelessSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ud_WirelessFrequency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ud_WirelessId)).EndInit();
            this.gb_SerialPortSettings.ResumeLayout(false);
            this.gb_SerialPortSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtn_AutoConnection;
        private System.Windows.Forms.RadioButton rbtn_ManualConnection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_SerialPortName;
        private System.Windows.Forms.Button btn_SerialPortConnection;
        private System.Windows.Forms.Label l_ConnectionState;
        private System.Windows.Forms.GroupBox gb_WirelessSettings;
        private System.Windows.Forms.GroupBox gb_SerialPortSettings;
        private System.Windows.Forms.Button btn_ModuleConnection;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_WirelessIdList;
        private System.Windows.Forms.Label l_ModuleConnectionState;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cb_ManualSetting;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown ud_WirelessFrequency;
        private System.Windows.Forms.NumericUpDown ud_WirelessId;
        private System.Windows.Forms.Button btn_ManualConnection;
    }
}