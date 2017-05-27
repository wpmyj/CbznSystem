using Bll;
using System;
using System.Drawing;
using System.Windows.Forms;
using NewControl;

namespace CbznSystem
{
    public partial class InputPlate_Form : NewForm
    {
        public InputPlate_Form(string plate)
        {
            InitializeComponent();

            btn_Remove.Click += Btn_Remove_Click;
            btn_Enter.Click += Btn_Enter_Click;
            tb_LicensePlate.KeyPress += Tb_LicensePlate_KeyPress;
            tb_LicensePlate.TextChanged += Tb_LicensePlate_TextChanged;
            tb_LicensePlate.Leave += Tb_LicensePlate_Leave;
            tb_LicensePlate.Text = plate;
            l_LicensePlateTitle.MouseDown += L_LicensePlateTitle_MouseDown;
        }

        /// <summary>
        ///  减少界面的闪烁
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void Btn_Remove_Click(object sender, EventArgs e)
        {
            int index = tb_LicensePlate.SelectionStart;
            if (index == 0) return;
            tb_LicensePlate.Text = tb_LicensePlate.Text.Remove(index - 1, 1);
            tb_LicensePlate.SelectionStart = index - 1;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;
            int index = tb_LicensePlate.SelectionStart;
            int len = tb_LicensePlate.SelectionLength;
            if (len == 0)
            {
                if (tb_LicensePlate.TextLength == tb_LicensePlate.MaxLength) return;
                tb_LicensePlate.Text = tb_LicensePlate.Text.Insert(index, btn.Text);
                tb_LicensePlate.SelectionStart = ++index;
            }
            else
            {
                tb_LicensePlate.SelectedText = btn.Text;
            }
        }

        private void Btn_Enter_Click(object sender, EventArgs e)
        {
            string strtxt = tb_LicensePlate.Text.Trim();
            if (strtxt.Length == 0)
            {
                l_LicensePlateTitle.Text = "内容不能为空";
                l_LicensePlateTitle.ForeColor = Color.Red;
                tb_LicensePlate.Focus();
                return;
            }
            else if (strtxt.Length < 7)
            {
                MessageBox.Show("车牌号码长度为7或8位", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb_LicensePlate.Focus();
                tb_LicensePlate.SelectionStart = tb_LicensePlate.TextLength;
                return;
            }
            this.Tag = strtxt;
            this.DialogResult = DialogResult.OK;
        }

        private void L_LicensePlateTitle_MouseDown(object sender, MouseEventArgs e)
        {
            tb_LicensePlate.Focus();
        }

        private void Tb_LicensePlate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                Close();
            }
            else if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                Btn_Enter_Click(null, null);
            }
            e.Handled = LimitInput.InputNumberAndLetter(e.KeyChar);
        }

        private void Tb_LicensePlate_Leave(object sender, EventArgs e)
        {
            tb_LicensePlate.Focus();
        }

        private void Tb_LicensePlate_TextChanged(object sender, EventArgs e)
        {
            l_LicensePlateTitle.Visible = tb_LicensePlate.TextLength == 0;
        }
    }
}