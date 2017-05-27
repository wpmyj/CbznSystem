namespace CbznSystem
{
    partial class InputChargeRecord_Form
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
            this.btn_Cenal = new System.Windows.Forms.Button();
            this.pBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // l_Title
            // 
            this.l_Title.AutoSize = true;
            this.l_Title.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_Title.Location = new System.Drawing.Point(48, 70);
            this.l_Title.Name = "l_Title";
            this.l_Title.Size = new System.Drawing.Size(0, 20);
            this.l_Title.TabIndex = 10;
            // 
            // btn_Cenal
            // 
            this.btn_Cenal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Cenal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btn_Cenal.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btn_Cenal.FlatAppearance.BorderSize = 0;
            this.btn_Cenal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btn_Cenal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(214)))), ((int)(((byte)(141)))));
            this.btn_Cenal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cenal.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Cenal.ForeColor = System.Drawing.Color.White;
            this.btn_Cenal.Location = new System.Drawing.Point(302, 150);
            this.btn_Cenal.Name = "btn_Cenal";
            this.btn_Cenal.Size = new System.Drawing.Size(100, 29);
            this.btn_Cenal.TabIndex = 9;
            this.btn_Cenal.TabStop = false;
            this.btn_Cenal.Text = "取 消";
            this.btn_Cenal.UseVisualStyleBackColor = false;
            // 
            // pBar
            // 
            this.pBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pBar.Location = new System.Drawing.Point(52, 105);
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(350, 30);
            this.pBar.Step = 1;
            this.pBar.TabIndex = 8;
            // 
            // InputChargeRecord_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 200);
            this.ControlBox = false;
            this.Controls.Add(this.l_Title);
            this.Controls.Add(this.btn_Cenal);
            this.Controls.Add(this.pBar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InputChargeRecord_Form";
            this.ShowIcon = false;
            this.Text = "导入记录";
            this.Controls.SetChildIndex(this.pBar, 0);
            this.Controls.SetChildIndex(this.btn_Cenal, 0);
            this.Controls.SetChildIndex(this.l_Title, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l_Title;
        private System.Windows.Forms.Button btn_Cenal;
        private System.Windows.Forms.ProgressBar pBar;
    }
}