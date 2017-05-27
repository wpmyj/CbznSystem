namespace NewControl
{
    partial class NewForm
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
            this.p_Title = new System.Windows.Forms.Panel();
            this.btn_Min = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Settings = new System.Windows.Forms.Button();
            this.p_Title.SuspendLayout();
            this.SuspendLayout();
            // 
            // p_Title
            // 
            this.p_Title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(134)))), ((int)(((byte)(254)))));
            this.p_Title.Controls.Add(this.btn_Settings);
            this.p_Title.Controls.Add(this.btn_Min);
            this.p_Title.Controls.Add(this.btn_Close);
            this.p_Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.p_Title.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.p_Title.Location = new System.Drawing.Point(0, 0);
            this.p_Title.Name = "p_Title";
            this.p_Title.Size = new System.Drawing.Size(284, 40);
            this.p_Title.TabIndex = 0;
            // 
            // btn_Min
            // 
            this.btn_Min.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Min.FlatAppearance.BorderSize = 0;
            this.btn_Min.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(27)))), ((int)(((byte)(0)))));
            this.btn_Min.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(54)))), ((int)(((byte)(16)))));
            this.btn_Min.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Min.Image = global::NewControl.Properties.Resources.NoneMin;
            this.btn_Min.Location = new System.Drawing.Point(192, 0);
            this.btn_Min.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btn_Min.Name = "btn_Min";
            this.btn_Min.Size = new System.Drawing.Size(46, 31);
            this.btn_Min.TabIndex = 2;
            this.btn_Min.TabStop = false;
            this.btn_Min.UseVisualStyleBackColor = true;
            // 
            // btn_Close
            // 
            this.btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Close.FlatAppearance.BorderSize = 0;
            this.btn_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(27)))), ((int)(((byte)(0)))));
            this.btn_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(54)))), ((int)(((byte)(16)))));
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Image = global::NewControl.Properties.Resources.NoneClose;
            this.btn_Close.Location = new System.Drawing.Point(238, 0);
            this.btn_Close.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(46, 31);
            this.btn_Close.TabIndex = 1;
            this.btn_Close.TabStop = false;
            this.btn_Close.UseVisualStyleBackColor = true;
            // 
            // btn_Settings
            // 
            this.btn_Settings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Settings.FlatAppearance.BorderSize = 0;
            this.btn_Settings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(27)))), ((int)(((byte)(0)))));
            this.btn_Settings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(54)))), ((int)(((byte)(16)))));
            this.btn_Settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Settings.Image = global::NewControl.Properties.Resources.NoneSet;
            this.btn_Settings.Location = new System.Drawing.Point(146, 0);
            this.btn_Settings.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.btn_Settings.Name = "btn_Settings";
            this.btn_Settings.Size = new System.Drawing.Size(46, 31);
            this.btn_Settings.TabIndex = 3;
            this.btn_Settings.TabStop = false;
            this.btn_Settings.UseVisualStyleBackColor = true;
            this.btn_Settings.Visible = false;
            // 
            // NewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.p_Title);
            this.Name = "NewForm";
            this.Text = "NewForm";
            this.p_Title.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p_Title;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Min;
        private System.Windows.Forms.Button btn_Settings;
    }
}