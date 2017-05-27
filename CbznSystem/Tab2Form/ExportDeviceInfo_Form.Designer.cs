namespace CbznSystem
{
    partial class ExportDeviceInfo_Form
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
            this.cb_Directory = new System.Windows.Forms.ComboBox();
            this.btn_Enter = new System.Windows.Forms.Button();
            this.cb_LoadControlBoard = new System.Windows.Forms.CheckBox();
            this.cb_LoadDistance = new System.Windows.Forms.CheckBox();
            this.cb_LoadTempIc = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cb_Directory
            // 
            this.cb_Directory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Directory.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_Directory.FormattingEnabled = true;
            this.cb_Directory.Location = new System.Drawing.Point(50, 194);
            this.cb_Directory.Name = "cb_Directory";
            this.cb_Directory.Size = new System.Drawing.Size(244, 29);
            this.cb_Directory.TabIndex = 3;
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
            this.btn_Enter.Location = new System.Drawing.Point(300, 194);
            this.btn_Enter.Name = "btn_Enter";
            this.btn_Enter.Size = new System.Drawing.Size(100, 29);
            this.btn_Enter.TabIndex = 4;
            this.btn_Enter.TabStop = false;
            this.btn_Enter.Text = "导 出";
            this.btn_Enter.UseVisualStyleBackColor = false;
            // 
            // cb_LoadControlBoard
            // 
            this.cb_LoadControlBoard.AutoSize = true;
            this.cb_LoadControlBoard.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_LoadControlBoard.Location = new System.Drawing.Point(119, 67);
            this.cb_LoadControlBoard.Name = "cb_LoadControlBoard";
            this.cb_LoadControlBoard.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cb_LoadControlBoard.Size = new System.Drawing.Size(221, 25);
            this.cb_LoadControlBoard.TabIndex = 0;
            this.cb_LoadControlBoard.Text = "是否更改或设置控制板密码";
            this.cb_LoadControlBoard.UseVisualStyleBackColor = true;
            // 
            // cb_LoadDistance
            // 
            this.cb_LoadDistance.AutoSize = true;
            this.cb_LoadDistance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_LoadDistance.Location = new System.Drawing.Point(116, 107);
            this.cb_LoadDistance.Name = "cb_LoadDistance";
            this.cb_LoadDistance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cb_LoadDistance.Size = new System.Drawing.Size(224, 25);
            this.cb_LoadDistance.TabIndex = 1;
            this.cb_LoadDistance.Text = "是否更改 5 米定距系统口令";
            this.cb_LoadDistance.UseVisualStyleBackColor = true;
            // 
            // cb_LoadTempIc
            // 
            this.cb_LoadTempIc.AutoSize = true;
            this.cb_LoadTempIc.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_LoadTempIc.Location = new System.Drawing.Point(109, 147);
            this.cb_LoadTempIc.Name = "cb_LoadTempIc";
            this.cb_LoadTempIc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cb_LoadTempIc.Size = new System.Drawing.Size(231, 25);
            this.cb_LoadTempIc.TabIndex = 2;
            this.cb_LoadTempIc.Text = "是否更改临时 IC 卡系统口令";
            this.cb_LoadTempIc.UseVisualStyleBackColor = true;
            // 
            // ExportDeviceInfo_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 250);
            this.Controls.Add(this.cb_LoadTempIc);
            this.Controls.Add(this.cb_LoadDistance);
            this.Controls.Add(this.cb_LoadControlBoard);
            this.Controls.Add(this.btn_Enter);
            this.Controls.Add(this.cb_Directory);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExportDeviceInfo_Form";
            this.ShowIcon = false;
            this.Text = "导出设备信息";
            this.Controls.SetChildIndex(this.cb_Directory, 0);
            this.Controls.SetChildIndex(this.btn_Enter, 0);
            this.Controls.SetChildIndex(this.cb_LoadControlBoard, 0);
            this.Controls.SetChildIndex(this.cb_LoadDistance, 0);
            this.Controls.SetChildIndex(this.cb_LoadTempIc, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_Directory;
        private System.Windows.Forms.Button btn_Enter;
        private System.Windows.Forms.CheckBox cb_LoadControlBoard;
        private System.Windows.Forms.CheckBox cb_LoadDistance;
        private System.Windows.Forms.CheckBox cb_LoadTempIc;
    }
}