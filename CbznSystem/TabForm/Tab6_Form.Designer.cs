namespace CbznSystem
{
    partial class Tab6_Form
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
            this.p_Left = new System.Windows.Forms.Panel();
            this.btn_Tab3 = new System.Windows.Forms.Button();
            this.btn_Tab2 = new System.Windows.Forms.Button();
            this.btn_Tab1 = new System.Windows.Forms.Button();
            this.p_Box = new System.Windows.Forms.Panel();
            this.p_Left.SuspendLayout();
            this.SuspendLayout();
            // 
            // p_Left
            // 
            this.p_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(71)))), ((int)(((byte)(82)))));
            this.p_Left.Controls.Add(this.btn_Tab3);
            this.p_Left.Controls.Add(this.btn_Tab2);
            this.p_Left.Controls.Add(this.btn_Tab1);
            this.p_Left.Dock = System.Windows.Forms.DockStyle.Left;
            this.p_Left.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.p_Left.Location = new System.Drawing.Point(0, 0);
            this.p_Left.Name = "p_Left";
            this.p_Left.Size = new System.Drawing.Size(200, 401);
            this.p_Left.TabIndex = 2;
            // 
            // btn_Tab3
            // 
            this.btn_Tab3.FlatAppearance.BorderSize = 0;
            this.btn_Tab3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(44)))), ((int)(((byte)(48)))));
            this.btn_Tab3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.btn_Tab3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Tab3.ForeColor = System.Drawing.Color.White;
            this.btn_Tab3.Location = new System.Drawing.Point(0, 106);
            this.btn_Tab3.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btn_Tab3.Name = "btn_Tab3";
            this.btn_Tab3.Size = new System.Drawing.Size(200, 50);
            this.btn_Tab3.TabIndex = 3;
            this.btn_Tab3.TabStop = false;
            this.btn_Tab3.Text = "操作日志";
            this.btn_Tab3.UseVisualStyleBackColor = true;
            this.btn_Tab3.Visible = false;
            // 
            // btn_Tab2
            // 
            this.btn_Tab2.FlatAppearance.BorderSize = 0;
            this.btn_Tab2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(44)))), ((int)(((byte)(48)))));
            this.btn_Tab2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.btn_Tab2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Tab2.ForeColor = System.Drawing.Color.White;
            this.btn_Tab2.Location = new System.Drawing.Point(0, 53);
            this.btn_Tab2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btn_Tab2.Name = "btn_Tab2";
            this.btn_Tab2.Size = new System.Drawing.Size(200, 50);
            this.btn_Tab2.TabIndex = 2;
            this.btn_Tab2.TabStop = false;
            this.btn_Tab2.Text = "收费记录";
            this.btn_Tab2.UseVisualStyleBackColor = true;
            // 
            // btn_Tab1
            // 
            this.btn_Tab1.FlatAppearance.BorderSize = 0;
            this.btn_Tab1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(44)))), ((int)(((byte)(48)))));
            this.btn_Tab1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.btn_Tab1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Tab1.ForeColor = System.Drawing.Color.White;
            this.btn_Tab1.Location = new System.Drawing.Point(0, 0);
            this.btn_Tab1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btn_Tab1.Name = "btn_Tab1";
            this.btn_Tab1.Size = new System.Drawing.Size(200, 50);
            this.btn_Tab1.TabIndex = 1;
            this.btn_Tab1.TabStop = false;
            this.btn_Tab1.Text = "进出记录";
            this.btn_Tab1.UseVisualStyleBackColor = true;
            // 
            // p_Box
            // 
            this.p_Box.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_Box.Location = new System.Drawing.Point(200, 0);
            this.p_Box.Name = "p_Box";
            this.p_Box.Size = new System.Drawing.Size(134, 401);
            this.p_Box.TabIndex = 3;
            // 
            // Tab6_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 401);
            this.Controls.Add(this.p_Box);
            this.Controls.Add(this.p_Left);
            this.KeyPreview = true;
            this.Name = "Tab6_Form";
            this.Text = "Tab6_Form";
            this.p_Left.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p_Left;
        private System.Windows.Forms.Button btn_Tab3;
        private System.Windows.Forms.Button btn_Tab2;
        private System.Windows.Forms.Button btn_Tab1;
        private System.Windows.Forms.Panel p_Box;
    }
}