namespace CbznSystem
{
    partial class DataManagement_Form
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
            this.tb_BackupsAddress = new System.Windows.Forms.TextBox();
            this.tb_RecoveryAddress = new System.Windows.Forms.TextBox();
            this.btn_Backups = new System.Windows.Forms.Button();
            this.btn_SelectAddress = new System.Windows.Forms.Button();
            this.btn_Recovery = new System.Windows.Forms.Button();
            this.btn_SelectFile = new System.Windows.Forms.Button();
            this.cb_EnterExitRecord = new System.Windows.Forms.CheckBox();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.cb_ChargeReocrd = new System.Windows.Forms.CheckBox();
            this.cb_DelayRecord = new System.Windows.Forms.CheckBox();
            this.cb_JournalLog = new System.Windows.Forms.CheckBox();
            this.cb_TimeSlot = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(62, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "备份地址：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(62, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "恢复数据：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(62, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "清除数据：";
            // 
            // tb_BackupsAddress
            // 
            this.tb_BackupsAddress.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_BackupsAddress.Location = new System.Drawing.Point(158, 21);
            this.tb_BackupsAddress.Name = "tb_BackupsAddress";
            this.tb_BackupsAddress.Size = new System.Drawing.Size(290, 29);
            this.tb_BackupsAddress.TabIndex = 3;
            // 
            // tb_RecoveryAddress
            // 
            this.tb_RecoveryAddress.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_RecoveryAddress.Location = new System.Drawing.Point(158, 81);
            this.tb_RecoveryAddress.Name = "tb_RecoveryAddress";
            this.tb_RecoveryAddress.Size = new System.Drawing.Size(290, 29);
            this.tb_RecoveryAddress.TabIndex = 4;
            // 
            // btn_Backups
            // 
            this.btn_Backups.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btn_Backups.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btn_Backups.FlatAppearance.BorderSize = 0;
            this.btn_Backups.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btn_Backups.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(214)))), ((int)(((byte)(141)))));
            this.btn_Backups.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Backups.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Backups.ForeColor = System.Drawing.Color.White;
            this.btn_Backups.Location = new System.Drawing.Point(560, 21);
            this.btn_Backups.Name = "btn_Backups";
            this.btn_Backups.Size = new System.Drawing.Size(100, 29);
            this.btn_Backups.TabIndex = 14;
            this.btn_Backups.TabStop = false;
            this.btn_Backups.Text = "备 份";
            this.btn_Backups.UseVisualStyleBackColor = false;
            // 
            // btn_SelectAddress
            // 
            this.btn_SelectAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_SelectAddress.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_SelectAddress.FlatAppearance.BorderSize = 0;
            this.btn_SelectAddress.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(17)))), ((int)(((byte)(42)))));
            this.btn_SelectAddress.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(181)))), ((int)(((byte)(235)))));
            this.btn_SelectAddress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SelectAddress.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_SelectAddress.ForeColor = System.Drawing.Color.White;
            this.btn_SelectAddress.Location = new System.Drawing.Point(454, 21);
            this.btn_SelectAddress.Name = "btn_SelectAddress";
            this.btn_SelectAddress.Size = new System.Drawing.Size(100, 29);
            this.btn_SelectAddress.TabIndex = 13;
            this.btn_SelectAddress.TabStop = false;
            this.btn_SelectAddress.Text = "选择地址";
            this.btn_SelectAddress.UseVisualStyleBackColor = false;
            // 
            // btn_Recovery
            // 
            this.btn_Recovery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btn_Recovery.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btn_Recovery.FlatAppearance.BorderSize = 0;
            this.btn_Recovery.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btn_Recovery.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(214)))), ((int)(((byte)(141)))));
            this.btn_Recovery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Recovery.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Recovery.ForeColor = System.Drawing.Color.White;
            this.btn_Recovery.Location = new System.Drawing.Point(560, 81);
            this.btn_Recovery.Name = "btn_Recovery";
            this.btn_Recovery.Size = new System.Drawing.Size(100, 29);
            this.btn_Recovery.TabIndex = 16;
            this.btn_Recovery.TabStop = false;
            this.btn_Recovery.Text = "还 原";
            this.btn_Recovery.UseVisualStyleBackColor = false;
            // 
            // btn_SelectFile
            // 
            this.btn_SelectFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_SelectFile.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(103)))), ((int)(((byte)(192)))));
            this.btn_SelectFile.FlatAppearance.BorderSize = 0;
            this.btn_SelectFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(17)))), ((int)(((byte)(42)))));
            this.btn_SelectFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(181)))), ((int)(((byte)(235)))));
            this.btn_SelectFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SelectFile.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_SelectFile.ForeColor = System.Drawing.Color.White;
            this.btn_SelectFile.Location = new System.Drawing.Point(454, 81);
            this.btn_SelectFile.Name = "btn_SelectFile";
            this.btn_SelectFile.Size = new System.Drawing.Size(100, 29);
            this.btn_SelectFile.TabIndex = 15;
            this.btn_SelectFile.TabStop = false;
            this.btn_SelectFile.Text = "选择文件";
            this.btn_SelectFile.UseVisualStyleBackColor = false;
            // 
            // cb_EnterExitRecord
            // 
            this.cb_EnterExitRecord.AutoSize = true;
            this.cb_EnterExitRecord.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_EnterExitRecord.Location = new System.Drawing.Point(196, 199);
            this.cb_EnterExitRecord.Name = "cb_EnterExitRecord";
            this.cb_EnterExitRecord.Size = new System.Drawing.Size(93, 25);
            this.cb_EnterExitRecord.TabIndex = 17;
            this.cb_EnterExitRecord.Text = "进出记录";
            this.cb_EnterExitRecord.UseVisualStyleBackColor = true;
            // 
            // btn_Delete
            // 
            this.btn_Delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btn_Delete.Enabled = false;
            this.btn_Delete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btn_Delete.FlatAppearance.BorderSize = 0;
            this.btn_Delete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btn_Delete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(214)))), ((int)(((byte)(141)))));
            this.btn_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Delete.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Delete.ForeColor = System.Drawing.Color.White;
            this.btn_Delete.Location = new System.Drawing.Point(454, 139);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(100, 29);
            this.btn_Delete.TabIndex = 19;
            this.btn_Delete.TabStop = false;
            this.btn_Delete.Text = "清 除";
            this.btn_Delete.UseVisualStyleBackColor = false;
            // 
            // cb_ChargeReocrd
            // 
            this.cb_ChargeReocrd.AutoSize = true;
            this.cb_ChargeReocrd.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_ChargeReocrd.Location = new System.Drawing.Point(319, 199);
            this.cb_ChargeReocrd.Name = "cb_ChargeReocrd";
            this.cb_ChargeReocrd.Size = new System.Drawing.Size(93, 25);
            this.cb_ChargeReocrd.TabIndex = 20;
            this.cb_ChargeReocrd.Text = "收费记录";
            this.cb_ChargeReocrd.UseVisualStyleBackColor = true;
            // 
            // cb_DelayRecord
            // 
            this.cb_DelayRecord.AutoSize = true;
            this.cb_DelayRecord.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_DelayRecord.Location = new System.Drawing.Point(535, 199);
            this.cb_DelayRecord.Name = "cb_DelayRecord";
            this.cb_DelayRecord.Size = new System.Drawing.Size(93, 25);
            this.cb_DelayRecord.TabIndex = 21;
            this.cb_DelayRecord.Text = "延期记录";
            this.cb_DelayRecord.UseVisualStyleBackColor = true;
            this.cb_DelayRecord.Visible = false;
            // 
            // cb_JournalLog
            // 
            this.cb_JournalLog.AutoSize = true;
            this.cb_JournalLog.Checked = true;
            this.cb_JournalLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_JournalLog.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_JournalLog.Location = new System.Drawing.Point(535, 242);
            this.cb_JournalLog.Name = "cb_JournalLog";
            this.cb_JournalLog.Size = new System.Drawing.Size(93, 25);
            this.cb_JournalLog.TabIndex = 22;
            this.cb_JournalLog.Text = "操作日志";
            this.cb_JournalLog.UseVisualStyleBackColor = true;
            this.cb_JournalLog.Visible = false;
            // 
            // cb_TimeSlot
            // 
            this.cb_TimeSlot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_TimeSlot.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_TimeSlot.FormattingEnabled = true;
            this.cb_TimeSlot.Items.AddRange(new object[] {
            "全部",
            "一个月前",
            "三个月前",
            "半年前",
            "一年前"});
            this.cb_TimeSlot.Location = new System.Drawing.Point(158, 139);
            this.cb_TimeSlot.Name = "cb_TimeSlot";
            this.cb_TimeSlot.Size = new System.Drawing.Size(290, 29);
            this.cb_TimeSlot.TabIndex = 23;
            // 
            // DataManagement_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 394);
            this.Controls.Add(this.cb_TimeSlot);
            this.Controls.Add(this.cb_JournalLog);
            this.Controls.Add(this.cb_DelayRecord);
            this.Controls.Add(this.cb_ChargeReocrd);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.cb_EnterExitRecord);
            this.Controls.Add(this.btn_Recovery);
            this.Controls.Add(this.btn_SelectFile);
            this.Controls.Add(this.btn_Backups);
            this.Controls.Add(this.btn_SelectAddress);
            this.Controls.Add(this.tb_RecoveryAddress);
            this.Controls.Add(this.tb_BackupsAddress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "DataManagement_Form";
            this.Text = "数据管理";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_BackupsAddress;
        private System.Windows.Forms.TextBox tb_RecoveryAddress;
        private System.Windows.Forms.Button btn_Backups;
        private System.Windows.Forms.Button btn_SelectAddress;
        private System.Windows.Forms.Button btn_Recovery;
        private System.Windows.Forms.Button btn_SelectFile;
        private System.Windows.Forms.CheckBox cb_EnterExitRecord;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.CheckBox cb_ChargeReocrd;
        private System.Windows.Forms.CheckBox cb_DelayRecord;
        private System.Windows.Forms.CheckBox cb_JournalLog;
        private System.Windows.Forms.ComboBox cb_TimeSlot;
    }
}