using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using NewControl;

namespace CbznSystem
{
    public partial class AddCamera_Form : NewForm
    {
        private readonly Font CONTROLDEFAULTFONT = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point,
    ((byte)(134)));

        public AddCamera_Form()
        {
            InitializeComponent();

            this.Load += AddCamera_Form_Load;
            this.KeyDown += AddCamera_Form_KeyDown;

            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.White;
            this.AcceptButton = btn_Enter;
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void AddCamera_Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        public List<SaveCameraParam> SaveParam { get; set; }
        public List<SearchCameraParam> SearchParam { get; set; }

        private void AddCamera_Form_Load(object sender, EventArgs e)
        {
            foreach (SearchCameraParam item in SearchParam)
            {
                if (ExistsSave(item.CameraIp)) continue;
                cb_Camera.Items.Add(item.CameraIp);
            }
            if (cb_Camera.Items.Count > 0)
                cb_Camera.SelectedIndex = 0;

            cb_Direction.SelectedIndex = 0;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Enter_Click(object sender, EventArgs e)
        {
            if (cb_Camera.SelectedIndex == -1)
            {
                cb_Camera.DroppedDown = true;
                return;
            }
            string ip = cb_Camera.Text;
            int direction = cb_Direction.SelectedIndex;
            int devicenumber = (int)ud_DeviceNumber.Value;
            SaveCameraParam param = new SaveCameraParam()
            {
                CameraIp = ip,
                DeviceId = devicenumber,
                Direction = direction
            };
            this.Tag = param;
            Close();
        }

        private bool ExistsSave(string strIp)
        {
            foreach (SaveCameraParam item in SaveParam)
            {
                if (item.CameraIp == strIp)
                    return true;
            }
            return false;
        }

    }
}