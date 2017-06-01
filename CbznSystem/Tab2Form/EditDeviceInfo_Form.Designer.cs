namespace CbznSystem
{
    partial class EditDeviceInfo_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditDeviceInfo_Form));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ud_HostNumber = new System.Windows.Forms.NumericUpDown();
            this.cb_DeviceMode = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_IOSate = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_DeviceNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.l_GateSign = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.l_CameraIdSign = new System.Windows.Forms.Label();
            this.cb_Distance = new System.Windows.Forms.ComboBox();
            this.cb_EquipmentDelay = new System.Windows.Forms.ComboBox();
            this.cb_FieldPartition = new System.Windows.Forms.ComboBox();
            this.cb_AntiSubmarineBack = new System.Windows.Forms.ComboBox();
            this.cb_VehicleDetection = new System.Windows.Forms.ComboBox();
            this.cb_IsLikeMachine = new System.Windows.Forms.ComboBox();
            this.tb_WirelessID = new System.Windows.Forms.TextBox();
            this.ud_Frequency = new System.Windows.Forms.NumericUpDown();
            this.cb_VagueQueryNumber = new System.Windows.Forms.ComboBox();
            this.cb_Language = new System.Windows.Forms.ComboBox();
            this.btn_Enter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ud_HostNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ud_Frequency)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(27, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "门口编号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(284, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "开闸模式";
            // 
            // ud_HostNumber
            // 
            this.ud_HostNumber.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ud_HostNumber.Location = new System.Drawing.Point(98, 59);
            this.ud_HostNumber.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.ud_HostNumber.Name = "ud_HostNumber";
            this.ud_HostNumber.Size = new System.Drawing.Size(120, 29);
            this.ud_HostNumber.TabIndex = 0;
            // 
            // cb_DeviceMode
            // 
            this.cb_DeviceMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_DeviceMode.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_DeviceMode.FormattingEnabled = true;
            this.cb_DeviceMode.Items.AddRange(new object[] {
            "畅泊：串口开闸",
            "畅泊：无线开闸",
            "学习遥控器开闸",
            "继电器开闸"});
            this.cb_DeviceMode.Location = new System.Drawing.Point(355, 59);
            this.cb_DeviceMode.Name = "cb_DeviceMode";
            this.cb_DeviceMode.Size = new System.Drawing.Size(121, 29);
            this.cb_DeviceMode.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(33, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "出 入 口";
            // 
            // cb_IOSate
            // 
            this.cb_IOSate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_IOSate.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_IOSate.FormattingEnabled = true;
            this.cb_IOSate.Items.AddRange(new object[] {
            "入口",
            "出口"});
            this.cb_IOSate.Location = new System.Drawing.Point(98, 111);
            this.cb_IOSate.Name = "cb_IOSate";
            this.cb_IOSate.Size = new System.Drawing.Size(121, 29);
            this.cb_IOSate.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(293, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "道闸 ID";
            // 
            // tb_DeviceNumber
            // 
            this.tb_DeviceNumber.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_DeviceNumber.Location = new System.Drawing.Point(355, 109);
            this.tb_DeviceNumber.MaxLength = 10;
            this.tb_DeviceNumber.Name = "tb_DeviceNumber";
            this.tb_DeviceNumber.Size = new System.Drawing.Size(121, 29);
            this.tb_DeviceNumber.TabIndex = 8;
            this.tb_DeviceNumber.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(225, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "*";
            // 
            // l_GateSign
            // 
            this.l_GateSign.AutoSize = true;
            this.l_GateSign.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_GateSign.ForeColor = System.Drawing.Color.Red;
            this.l_GateSign.Location = new System.Drawing.Point(482, 113);
            this.l_GateSign.Name = "l_GateSign";
            this.l_GateSign.Size = new System.Drawing.Size(15, 20);
            this.l_GateSign.TabIndex = 10;
            this.l_GateSign.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(482, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(27, 167);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 20);
            this.label8.TabIndex = 12;
            this.label8.Text = "读卡距离";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(27, 219);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 20);
            this.label9.TabIndex = 13;
            this.label9.Text = "读卡延迟";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(27, 271);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 20);
            this.label10.TabIndex = 14;
            this.label10.Text = "车场分区";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(33, 323);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 20);
            this.label11.TabIndex = 15;
            this.label11.Text = "返 潜 回";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(27, 375);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 20);
            this.label12.TabIndex = 16;
            this.label12.Text = "离开检测";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(284, 375);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 20);
            this.label13.TabIndex = 17;
            this.label13.Text = "语言种类";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(256, 323);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(93, 20);
            this.label14.TabIndex = 18;
            this.label14.Text = "模糊查询位数";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(284, 167);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 20);
            this.label15.TabIndex = 19;
            this.label15.Text = "辅助像机";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(293, 219);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 20);
            this.label16.TabIndex = 20;
            this.label16.Text = "像机 ID";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(284, 271);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(65, 20);
            this.label17.TabIndex = 21;
            this.label17.Text = "频道偏移";
            // 
            // l_CameraIdSign
            // 
            this.l_CameraIdSign.AutoSize = true;
            this.l_CameraIdSign.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_CameraIdSign.ForeColor = System.Drawing.Color.Red;
            this.l_CameraIdSign.Location = new System.Drawing.Point(482, 220);
            this.l_CameraIdSign.Name = "l_CameraIdSign";
            this.l_CameraIdSign.Size = new System.Drawing.Size(15, 20);
            this.l_CameraIdSign.TabIndex = 22;
            this.l_CameraIdSign.Text = "*";
            // 
            // cb_Distance
            // 
            this.cb_Distance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Distance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_Distance.FormattingEnabled = true;
            this.cb_Distance.Items.AddRange(new object[] {
            "1.2 米",
            "2.5 米",
            "3.8 米",
            "5 米"});
            this.cb_Distance.Location = new System.Drawing.Point(97, 163);
            this.cb_Distance.Name = "cb_Distance";
            this.cb_Distance.Size = new System.Drawing.Size(121, 29);
            this.cb_Distance.TabIndex = 2;
            // 
            // cb_EquipmentDelay
            // 
            this.cb_EquipmentDelay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_EquipmentDelay.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_EquipmentDelay.FormattingEnabled = true;
            this.cb_EquipmentDelay.Items.AddRange(new object[] {
            "1 秒",
            "5 秒",
            "10 秒",
            "20 秒",
            "40 秒",
            "80 秒",
            "160 秒",
            "320 秒"});
            this.cb_EquipmentDelay.Location = new System.Drawing.Point(97, 215);
            this.cb_EquipmentDelay.Name = "cb_EquipmentDelay";
            this.cb_EquipmentDelay.Size = new System.Drawing.Size(121, 29);
            this.cb_EquipmentDelay.TabIndex = 3;
            // 
            // cb_FieldPartition
            // 
            this.cb_FieldPartition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_FieldPartition.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_FieldPartition.FormattingEnabled = true;
            this.cb_FieldPartition.Items.AddRange(new object[] {
            "关闭",
            "1 分区",
            "2 分区",
            "3 分区",
            "4 分区",
            "5 分区",
            "6 分区",
            "7 分区",
            "8 分区",
            "9 分区",
            "10 分区",
            "11 分区",
            "12 分区",
            "13 分区",
            "14 分区",
            "15 分区",
            "16 分区"});
            this.cb_FieldPartition.Location = new System.Drawing.Point(97, 267);
            this.cb_FieldPartition.Name = "cb_FieldPartition";
            this.cb_FieldPartition.Size = new System.Drawing.Size(121, 29);
            this.cb_FieldPartition.TabIndex = 4;
            // 
            // cb_AntiSubmarineBack
            // 
            this.cb_AntiSubmarineBack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_AntiSubmarineBack.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_AntiSubmarineBack.FormattingEnabled = true;
            this.cb_AntiSubmarineBack.Items.AddRange(new object[] {
            "关闭",
            "开启"});
            this.cb_AntiSubmarineBack.Location = new System.Drawing.Point(97, 319);
            this.cb_AntiSubmarineBack.Name = "cb_AntiSubmarineBack";
            this.cb_AntiSubmarineBack.Size = new System.Drawing.Size(121, 29);
            this.cb_AntiSubmarineBack.TabIndex = 5;
            // 
            // cb_VehicleDetection
            // 
            this.cb_VehicleDetection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_VehicleDetection.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_VehicleDetection.FormattingEnabled = true;
            this.cb_VehicleDetection.Items.AddRange(new object[] {
            "关闭",
            "开启"});
            this.cb_VehicleDetection.Location = new System.Drawing.Point(97, 371);
            this.cb_VehicleDetection.Name = "cb_VehicleDetection";
            this.cb_VehicleDetection.Size = new System.Drawing.Size(121, 29);
            this.cb_VehicleDetection.TabIndex = 6;
            // 
            // cb_IsLikeMachine
            // 
            this.cb_IsLikeMachine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_IsLikeMachine.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_IsLikeMachine.FormattingEnabled = true;
            this.cb_IsLikeMachine.Items.AddRange(new object[] {
            "无",
            "有"});
            this.cb_IsLikeMachine.Location = new System.Drawing.Point(355, 164);
            this.cb_IsLikeMachine.Name = "cb_IsLikeMachine";
            this.cb_IsLikeMachine.Size = new System.Drawing.Size(121, 29);
            this.cb_IsLikeMachine.TabIndex = 9;
            // 
            // tb_WirelessID
            // 
            this.tb_WirelessID.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_WirelessID.Location = new System.Drawing.Point(355, 216);
            this.tb_WirelessID.MaxLength = 8;
            this.tb_WirelessID.Name = "tb_WirelessID";
            this.tb_WirelessID.Size = new System.Drawing.Size(121, 29);
            this.tb_WirelessID.TabIndex = 10;
            this.tb_WirelessID.Text = "0";
            // 
            // ud_Frequency
            // 
            this.ud_Frequency.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ud_Frequency.Location = new System.Drawing.Point(355, 268);
            this.ud_Frequency.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.ud_Frequency.Name = "ud_Frequency";
            this.ud_Frequency.Size = new System.Drawing.Size(121, 29);
            this.ud_Frequency.TabIndex = 11;
            // 
            // cb_VagueQueryNumber
            // 
            this.cb_VagueQueryNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_VagueQueryNumber.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_VagueQueryNumber.FormattingEnabled = true;
            this.cb_VagueQueryNumber.Items.AddRange(new object[] {
            "关闭",
            "1",
            "2"});
            this.cb_VagueQueryNumber.Location = new System.Drawing.Point(356, 320);
            this.cb_VagueQueryNumber.Name = "cb_VagueQueryNumber";
            this.cb_VagueQueryNumber.Size = new System.Drawing.Size(121, 29);
            this.cb_VagueQueryNumber.TabIndex = 12;
            // 
            // cb_Language
            // 
            this.cb_Language.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Language.Enabled = false;
            this.cb_Language.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_Language.FormattingEnabled = true;
            this.cb_Language.Items.AddRange(new object[] {
            "普通话",
            "东北话",
            "四川话",
            "河南话",
            "陕西话"});
            this.cb_Language.Location = new System.Drawing.Point(356, 372);
            this.cb_Language.Name = "cb_Language";
            this.cb_Language.Size = new System.Drawing.Size(121, 29);
            this.cb_Language.TabIndex = 13;
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
            this.btn_Enter.Location = new System.Drawing.Point(376, 423);
            this.btn_Enter.Name = "btn_Enter";
            this.btn_Enter.Size = new System.Drawing.Size(100, 29);
            this.btn_Enter.TabIndex = 14;
            this.btn_Enter.TabStop = false;
            this.btn_Enter.Text = "确 认";
            this.btn_Enter.UseVisualStyleBackColor = false;
            // 
            // EditDeviceInfo_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 472);
            this.Controls.Add(this.btn_Enter);
            this.Controls.Add(this.cb_Language);
            this.Controls.Add(this.cb_VagueQueryNumber);
            this.Controls.Add(this.ud_Frequency);
            this.Controls.Add(this.tb_WirelessID);
            this.Controls.Add(this.cb_IsLikeMachine);
            this.Controls.Add(this.cb_VehicleDetection);
            this.Controls.Add(this.cb_AntiSubmarineBack);
            this.Controls.Add(this.cb_FieldPartition);
            this.Controls.Add(this.cb_EquipmentDelay);
            this.Controls.Add(this.cb_Distance);
            this.Controls.Add(this.l_CameraIdSign);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.l_GateSign);
            this.Controls.Add(this.tb_DeviceNumber);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cb_IOSate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cb_DeviceMode);
            this.Controls.Add(this.ud_HostNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditDeviceInfo_Form";
            this.ShowIcon = false;
            this.Text = "编辑设备信息";
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.ud_HostNumber, 0);
            this.Controls.SetChildIndex(this.cb_DeviceMode, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.cb_IOSate, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.tb_DeviceNumber, 0);
            this.Controls.SetChildIndex(this.l_GateSign, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.label16, 0);
            this.Controls.SetChildIndex(this.label17, 0);
            this.Controls.SetChildIndex(this.l_CameraIdSign, 0);
            this.Controls.SetChildIndex(this.cb_Distance, 0);
            this.Controls.SetChildIndex(this.cb_EquipmentDelay, 0);
            this.Controls.SetChildIndex(this.cb_FieldPartition, 0);
            this.Controls.SetChildIndex(this.cb_AntiSubmarineBack, 0);
            this.Controls.SetChildIndex(this.cb_VehicleDetection, 0);
            this.Controls.SetChildIndex(this.cb_IsLikeMachine, 0);
            this.Controls.SetChildIndex(this.tb_WirelessID, 0);
            this.Controls.SetChildIndex(this.ud_Frequency, 0);
            this.Controls.SetChildIndex(this.cb_VagueQueryNumber, 0);
            this.Controls.SetChildIndex(this.cb_Language, 0);
            this.Controls.SetChildIndex(this.btn_Enter, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ud_HostNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ud_Frequency)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown ud_HostNumber;
        private System.Windows.Forms.ComboBox cb_DeviceMode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_IOSate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_DeviceNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label l_GateSign;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label l_CameraIdSign;
        private System.Windows.Forms.ComboBox cb_Distance;
        private System.Windows.Forms.ComboBox cb_EquipmentDelay;
        private System.Windows.Forms.ComboBox cb_FieldPartition;
        private System.Windows.Forms.ComboBox cb_AntiSubmarineBack;
        private System.Windows.Forms.ComboBox cb_VehicleDetection;
        private System.Windows.Forms.ComboBox cb_IsLikeMachine;
        private System.Windows.Forms.TextBox tb_WirelessID;
        private System.Windows.Forms.NumericUpDown ud_Frequency;
        private System.Windows.Forms.ComboBox cb_VagueQueryNumber;
        private System.Windows.Forms.ComboBox cb_Language;
        private System.Windows.Forms.Button btn_Enter;
    }
}