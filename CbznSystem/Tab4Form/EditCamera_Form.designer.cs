namespace CbznSystem
{
    partial class EditCamera_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditCamera_Form));
            this.btn_Close = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_Camera = new System.Windows.Forms.ComboBox();
            this.cb_Direction = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ud_DeviceNumber = new System.Windows.Forms.NumericUpDown();
            this.btn_Enter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ud_DeviceNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Close
            // 
            this.btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Close.BackColor = System.Drawing.Color.Transparent;
            this.btn_Close.FlatAppearance.BorderSize = 0;
            this.btn_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(27)))), ((int)(((byte)(0)))));
            this.btn_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(54)))), ((int)(((byte)(16)))));
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Location = new System.Drawing.Point(238, 0);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(46, 31);
            this.btn_Close.TabIndex = 1;
            this.btn_Close.TabStop = false;
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(42, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "选择像机";
            // 
            // cb_Camera
            // 
            this.cb_Camera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Camera.Enabled = false;
            this.cb_Camera.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_Camera.FormattingEnabled = true;
            this.cb_Camera.Location = new System.Drawing.Point(113, 60);
            this.cb_Camera.Name = "cb_Camera";
            this.cb_Camera.Size = new System.Drawing.Size(130, 28);
            this.cb_Camera.TabIndex = 0;
            // 
            // cb_Direction
            // 
            this.cb_Direction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Direction.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_Direction.FormattingEnabled = true;
            this.cb_Direction.Items.AddRange(new object[] {
            "入口",
            "出口"});
            this.cb_Direction.Location = new System.Drawing.Point(113, 109);
            this.cb_Direction.Name = "cb_Direction";
            this.cb_Direction.Size = new System.Drawing.Size(130, 28);
            this.cb_Direction.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(48, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "出 入 口";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(42, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "门口编号";
            // 
            // ud_DeviceNumber
            // 
            this.ud_DeviceNumber.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ud_DeviceNumber.Location = new System.Drawing.Point(113, 158);
            this.ud_DeviceNumber.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.ud_DeviceNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ud_DeviceNumber.Name = "ud_DeviceNumber";
            this.ud_DeviceNumber.Size = new System.Drawing.Size(130, 26);
            this.ud_DeviceNumber.TabIndex = 2;
            this.ud_DeviceNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btn_Enter
            // 
            this.btn_Enter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(219)))));
            this.btn_Enter.FlatAppearance.BorderSize = 0;
            this.btn_Enter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(130)))), ((int)(((byte)(187)))));
            this.btn_Enter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(175)))), ((int)(((byte)(225)))));
            this.btn_Enter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Enter.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Enter.ForeColor = System.Drawing.Color.White;
            this.btn_Enter.Location = new System.Drawing.Point(42, 204);
            this.btn_Enter.Name = "btn_Enter";
            this.btn_Enter.Size = new System.Drawing.Size(200, 38);
            this.btn_Enter.TabIndex = 3;
            this.btn_Enter.Text = "保    存";
            this.btn_Enter.UseVisualStyleBackColor = false;
            this.btn_Enter.Click += new System.EventHandler(this.btn_Enter_Click);
            // 
            // EditCamera_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btn_Enter);
            this.Controls.Add(this.ud_DeviceNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cb_Direction);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_Camera);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "EditCamera_Form";
            this.Text = "编辑相机";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cb_Camera, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.cb_Direction, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.ud_DeviceNumber, 0);
            this.Controls.SetChildIndex(this.btn_Enter, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ud_DeviceNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_Camera;
        private System.Windows.Forms.ComboBox cb_Direction;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown ud_DeviceNumber;
        private System.Windows.Forms.Button btn_Enter;
        private System.Windows.Forms.Button btn_Close;
    }
}