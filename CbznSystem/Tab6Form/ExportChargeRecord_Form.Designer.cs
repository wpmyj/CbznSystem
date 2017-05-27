namespace CbznSystem
{
    partial class ExportChargeRecord_Form
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
            this.l_Title = new System.Windows.Forms.Label();
            this.pBar = new System.Windows.Forms.ProgressBar();
            this.btn_Next = new System.Windows.Forms.Button();
            this.cb_ExitNumber = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // l_Title
            // 
            this.l_Title.AutoSize = true;
            this.l_Title.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_Title.Location = new System.Drawing.Point(48, 70);
            this.l_Title.Name = "l_Title";
            this.l_Title.Size = new System.Drawing.Size(205, 20);
            this.l_Title.TabIndex = 10;
            this.l_Title.Text = "请选择当前记录所在的出口编号";
            // 
            // pBar
            // 
            this.pBar.Location = new System.Drawing.Point(52, 105);
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(350, 30);
            this.pBar.Step = 1;
            this.pBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pBar.TabIndex = 8;
            // 
            // btn_Next
            // 
            this.btn_Next.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Next.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btn_Next.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btn_Next.FlatAppearance.BorderSize = 0;
            this.btn_Next.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btn_Next.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(214)))), ((int)(((byte)(141)))));
            this.btn_Next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Next.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Next.ForeColor = System.Drawing.Color.White;
            this.btn_Next.Location = new System.Drawing.Point(302, 106);
            this.btn_Next.Name = "btn_Next";
            this.btn_Next.Size = new System.Drawing.Size(100, 29);
            this.btn_Next.TabIndex = 11;
            this.btn_Next.TabStop = false;
            this.btn_Next.Text = "下一步";
            this.btn_Next.UseVisualStyleBackColor = false;
            // 
            // cb_ExitNumber
            // 
            this.cb_ExitNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ExitNumber.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_ExitNumber.FormattingEnabled = true;
            this.cb_ExitNumber.Location = new System.Drawing.Point(259, 66);
            this.cb_ExitNumber.Name = "cb_ExitNumber";
            this.cb_ExitNumber.Size = new System.Drawing.Size(143, 29);
            this.cb_ExitNumber.TabIndex = 12;
            // 
            // ExportChargeRecord_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 165);
            this.ControlBox = false;
            this.Controls.Add(this.cb_ExitNumber);
            this.Controls.Add(this.btn_Next);
            this.Controls.Add(this.l_Title);
            this.Controls.Add(this.pBar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExportChargeRecord_Form";
            this.ShowIcon = false;
            this.Text = "导出记录";
            this.Controls.SetChildIndex(this.pBar, 0);
            this.Controls.SetChildIndex(this.l_Title, 0);
            this.Controls.SetChildIndex(this.btn_Next, 0);
            this.Controls.SetChildIndex(this.cb_ExitNumber, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l_Title;
        private System.Windows.Forms.ProgressBar pBar;
        private System.Windows.Forms.Button btn_Next;
        private System.Windows.Forms.ComboBox cb_ExitNumber;
    }
}