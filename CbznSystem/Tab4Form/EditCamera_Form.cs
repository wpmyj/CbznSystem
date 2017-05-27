using System;
using System.Drawing;
using System.Windows.Forms;
using NewControl;

namespace CbznSystem
{
    public partial class EditCamera_Form : NewForm
    {
        private readonly Font CONTROLDEFAULTFONT = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point,
    ((byte)(134)));

        public EditCamera_Form()
        {
            InitializeComponent();

            this.Load += AddCamera_Form_Load;
            this.KeyDown += EditCamera_Form_KeyDown;

            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.White;
            this.AcceptButton = btn_Enter;
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void EditCamera_Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        public SaveCameraParam SaveParam { get; set; }

        private void AddCamera_Form_Load(object sender, EventArgs e)
        {
            cb_Camera.Items.Add(SaveParam.CameraIp);
            cb_Camera.SelectedIndex = 0;
            cb_Direction.SelectedIndex = SaveParam.Direction;
            ud_DeviceNumber.Value = SaveParam.DeviceId;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Enter_Click(object sender, EventArgs e)
        {
            int direction = cb_Direction.SelectedIndex;
            int devicenumber = (int)ud_DeviceNumber.Value;
            SaveCameraParam param = new SaveCameraParam()
            {
                CameraIp = SaveParam.CameraIp,
                DeviceId = devicenumber,
                Direction = direction
            };
            this.Tag = param;
            Close();
        }

    }
}