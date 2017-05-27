using Bll;
using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CbznSystem
{
    /// <summary>
    /// 出入口枚举
    /// </summary>
    public enum CameraDirection
    {
        Enter = 0,
        Exit
    }

    /// <summary>
    /// 摄像头枚举
    /// </summary>
    public enum CameraTypes
    {
        AnShiBao = 0,
        HuoYan,
        QianYi,
    }

    public enum OperationTypes
    {
        None = 0,
        PlayVoice = 1,
        OpenTheDoor = 2
    }

    public partial class Tab4_Form : Form
    {

        #region 变量
        /// <summary>
        /// 是否已经显示
        /// </summary>
        private bool _isShow;
        /// <summary>
        /// 是否连接模块
        /// </summary>
        public bool IsConnectionModule;
        /// <summary>
        /// 是否读取IC卡
        /// </summary>
        public bool IsReadIcCard;

        #region 默认参数
        private readonly Pen PEN_LINE = new Pen(Color.Gray, 1);
        private readonly Color COLOR_BACKGROUND = Color.FromArgb(51, 153, 219);
        private readonly Color COLOR_MOUSEDOWN = Color.FromArgb(45, 130, 187);
        private readonly Color COLOR_MOUSEENTER = Color.FromArgb(93, 175, 225);
        private readonly Font CONTROLDEFAULTFONT = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
        #endregion

        #region 摄像头初始化
        /// <summary>
        /// 安视定摄像机初始化
        /// </summary>
        private bool _initAnShiBao;
        /// <summary>
        /// 火眼摄像机初始化
        /// </summary>
        private bool _initHuoYan;
        /// <summary>
        /// 火眼搜索摄像机
        /// </summary>
        private int _pHuoYanFindDevice = -1;
        /// <summary>
        /// 芊熠摄像机初始化
        /// </summary>
        private bool _initQianYi;
        #endregion
        /// <summary>
        /// 同一车牌识别间隔时间(秒)
        /// </summary>
        private const uint DELAYTIME = 30;
        /// <summary>
        /// 锁住车牌识别间隔时间
        /// </summary>
        private readonly object _lockTime = new object();
        /// <summary>
        /// 入场摄像机参数
        /// </summary>
        private RecognitionParam _mEnterParam;
        /// <summary>
        /// 出场摄像机参数
        /// </summary>
        private RecognitionParam _mExitParam;
        /// <summary>
        /// 出场记录
        /// </summary>
        private CbTempChargeRecord _mParkingRecord;
        /// <summary>
        /// 端口
        /// </summary>
        private SerialPortEx _mPort;
        /// <summary>
        /// 端口的集合
        /// </summary>
        private List<string> _serialPortNames;
        /// <summary>
        /// 是否连接端口
        /// </summary>
        private bool _isConnection;
        /// <summary>
        /// 自动连接端口
        /// </summary>
        private bool _isAutoConnection = true;
        /// <summary>
        /// 端口数据发送锁,防止发送数据连接成一串
        /// </summary>
        private readonly object _lockPort = new object();
        /// <summary>
        /// 端口发送的时间
        /// </summary>
        private DateTime _writeTime;
        /// <summary>
        /// 端口数据校验
        /// </summary>
        private DataValidation _mDataValidation;
        /// <summary>
        /// 已连接的摄像机
        /// </summary>
        public List<ConnectionCameraParam> _mConnCamera;
        /// <summary>
        /// 保存的摄像机
        /// </summary>
        private List<SaveCameraParam> _mSaveCamera;
        /// <summary>
        /// 搜索到的摄像机
        /// </summary>
        private List<SearchCameraParam> _mSearchCamera;
        /// <summary>
        /// 当前端口操作类型
        /// </summary>
        private OperationTypes _eCurrentOperating;
        /// <summary>
        /// 当前端口操作计数
        /// </summary>
        private int _operatingCount;
        /// <summary>
        /// 搜索摄像机延迟显示控件线程
        /// </summary>
        private System.Timers.Timer _tDelayEnableControl;
        /// <summary>
        /// 写Ic卡超时线程
        /// </summary>
        private Thread _tTimeOutThread;
        #region 摄像头回调事件

        /// <summary>
        /// 安视宝车牌识别回调
        /// </summary>
        private AnShiBaoClientSdk.IPCSDK_CALLBACK AnShiBaoPlateInfoCallBack;
        /// <summary>
        /// 火眼搜索摄像机回调
        /// </summary>
        private HuoYanClientSdk.VZLPRC_FIND_DEVICE_CALLBACK HuoYanFindDeviceCallBack;
        /// <summary>
        /// 火眼车牌识别回调
        /// </summary>
        private HuoYanClientSdk.VZLPRC_PLATE_INFO_CALLBACK HuoYanPlateInfoCallBack;
        /// <summary>
        /// 火眼串口回调
        /// </summary>
        private HuoYanClientSdk.VZDEV_SERIAL_RECV_DATA_CALLBACK HuoYanSerialDataReceivedCallBack;
        /// <summary>
        /// 芊熠搜索摄像机回调
        /// </summary>
        private QianYiClientSdk.FNetFindDeviceCallback QianYiFindDeviceCallBack;
        /// <summary>
        /// 芊熠车牌识别回调
        /// </summary>
        private QianYiClientSdk.FGetImageCB QianYiPlateInfoCallBack;
        /// <summary>
        /// 芊熠上报的消息
        /// </summary>
        private QianYiClientSdk.FGetReportCB QianYiRegReportMessageCallBack;

        #endregion 摄像头回调事件

        #endregion 变量

        #region 控件

        /// <summary>
        /// 设置容器
        /// </summary>
        public Panel p_SetBox;
        /// <summary>
        /// 搜索摄像机
        /// </summary>
        private Button btn_SearchCamera;
        /// <summary>
        /// 添加摄像机
        /// </summary>
        private Button btn_AddCamera;
        /// <summary>
        /// 编辑摄像机
        /// </summary>
        private Button btn_EditCamera;
        /// <summary>
        /// 删除摄像机
        /// </summary>
        private Button btn_DelCamera;
        /// <summary>
        /// 列表
        /// </summary>
        private DataGridView dgv_ConnectionCameraList;
        /// <summary>
        /// 显示摄像机是否打开
        /// </summary>
        private DataGridViewImageColumn c_ConnectionState;
        /// <summary>
        /// 显示摄像机IP地址
        /// </summary>
        private DataGridViewTextBoxColumn c_CameraIp;
        /// <summary>
        /// 显示摄像机出入口
        /// </summary>
        private DataGridViewTextBoxColumn c_CameraDirection;
        /// <summary>
        /// 显示门口编号
        /// </summary>
        private DataGridViewTextBoxColumn c_DeviceNumber;
        /// <summary>
        /// 自动连接标题 
        /// </summary>
        private Label l_AutoConnection;
        /// <summary>
        /// 自动连接
        /// </summary>
        private ComboBox cb_AutoConnection;
        /// <summary>
        /// 端口名称标题
        /// </summary>
        private Label l_CommPort;
        /// <summary>
        /// 显示端口名称
        /// </summary>
        private ComboBox cb_CommPort;
        /// <summary>
        /// 连接端口
        /// </summary>
        private Button btn_CommPort;
        #endregion

        public Tab4_Form()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(240, 243, 245);

            this.Load += Tab4_Form_Load;
            this.Shown += Tab4_Form_Shown;
            this.FormClosed += Tab4_Form_FormClosed;
            this.Activated += Tab4_Form_Activated;
            this.KeyDown += Tab4_Form_KeyDown;

            p_LeftBox.Resize += P_LeftBox_Resize;
            p_LeftBoxTop.Resize += P_LeftBoxTop_Resize;
            p_LeftBoxBottom.Paint += P_LeftBoxBottom_Paint;
            p_BottomRight.Paint += P_BottomRight_Paint;

            p_EnterBox.ControlAdded += P_EnterBox_ControlAdded;
            p_EnterBox.ControlRemoved += P_EnterBox_ControlRemoved;
            p_EnterBox.Resize += P_EnterBox_Resize;

            p_ExitBox.ControlAdded += P_ExitBox_ControlAdded;
            p_ExitBox.ControlRemoved += P_ExitBox_ControlRemoved;
            p_ExitBox.Resize += P_ExitBox_Resize;

            p_RightBox.Paint += P_RightBox_Paint;

            //实收金额
            tb_Money.KeyPress += Tb_Money_KeyPress;
            tb_Money.EnabledChanged += Tb_Money_EnabledChanged;

            btn_Enter.Paint += FormComm.DrawBtnEnabled;
            btn_Enter.Click += Btn_Enter_Click;
            btn_Enter.EnabledChanged += Btn_Enter_EnabledChanged;

            dgv_RecordList.CellFormatting += Dgv_RecordList_CellFormatting;
        }

        /// <summary>
        /// 窗体键盘按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tab4_Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4 && e.Alt == true)
            {
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
            {
                if (btn_Enter.Enabled)
                    Btn_Enter_Click(null, null);
            }
        }

        /// <summary>
        /// 列表格式重绘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dgv_RecordList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv_RecordList.Columns["cPlateNumber"].Index == e.ColumnIndex)
            {
                if (dgv_RecordList[e.ColumnIndex, e.RowIndex].Value.Equals("福A000000"))
                {
                    e.Value = "无牌车";
                }
            }
        }

        /// <summary>
        /// 显示入场的图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void P_BottomRight_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                g.DrawLine(PEN_LINE, 0, 0, 0, p_BottomRight.Height);
            }
        }

        /// <summary>
        ///  左边底部容器重绘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void P_LeftBoxBottom_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                g.DrawLine(PEN_LINE, 0, 0, p_LeftBoxBottom.Width, 0);
            }
        }

        /// <summary>
        /// 右边容器重绘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void P_RightBox_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                g.DrawLine(PEN_LINE, 0, 0, 0, p_RightBox.Height);
            }
        }

        /// <summary>
        /// 显示设置
        /// </summary>
        public void DisplaySet()
        {
            if (p_SetBox == null)
            {
                p_RightBox.Visible = false;
                p_LeftBox.Visible = false;
                CreateSetControls();
                ShowCameraList();
            }
            else
            {
                p_RightBox.Visible = true;
                p_LeftBox.Visible = true;
                foreach (Control item in p_SetBox.Controls)
                {
                    item.Dispose();
                }
                p_SetBox.Controls.Clear();
                p_SetBox.Dispose();
                p_SetBox = null;
            }
        }

        /// <summary>
        /// 显示摄像机列表
        /// </summary>
        private void ShowCameraList()
        {
            dgv_ConnectionCameraList.Rows.Clear();
            Image img = null;
            foreach (SaveCameraParam saveitem in _mSaveCamera)
            {
                img = Properties.Resources.block;
                foreach (SearchCameraParam searchitem in _mSearchCamera)
                {
                    if (saveitem.CameraIp == searchitem.CameraIp)
                    {
                        foreach (ConnectionCameraParam item in _mConnCamera)
                        {
                            if (item.CameraIp == searchitem.CameraIp && item.IsConnection)
                            {
                                img = Properties.Resources.check;
                                break;
                            }
                        }
                        break;
                    }
                }
                dgv_ConnectionCameraList.Rows.Add(new object[] { img, saveitem.CameraIp, saveitem.Direction, saveitem.DeviceId });
            }
        }

        /// <summary>
        /// 创建设置控件
        /// </summary>
        private void CreateSetControls()
        {
            p_SetBox = new Panel()
            {
                Dock = DockStyle.Fill,
                Name = "p_RightSetBox",
                Location = new Point(0, 0)
            };

            btn_SearchCamera = new Button()
            {
                Location = new Point(25, 20),
                Name = "btn_SearchCamera",
                Size = new Size(350, 40),
                TabIndex = 0,
                Text = @"0    搜 索 摄 像 机",
                UseVisualStyleBackColor = true,
                Font = CONTROLDEFAULTFONT,
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                Enabled = _tDelayEnableControl == null
            };
            btn_SearchCamera.FlatAppearance.BorderSize = 0;
            btn_SearchCamera.FlatAppearance.MouseOverBackColor = COLOR_MOUSEENTER;
            btn_SearchCamera.BackColor = COLOR_BACKGROUND;
            btn_SearchCamera.FlatAppearance.MouseDownBackColor = COLOR_MOUSEDOWN;
            btn_SearchCamera.Click += btn_SearchCamera_Click;
            //btn_SearchCamera.Paint += btn_SearchCamera_Paint;

            btn_AddCamera = new Button()
            {
                Location = new Point(30, 75),
                Name = "btn_AddCamera",
                Size = new Size(100, 30),
                TabIndex = 1,
                Text = @"添 加",
                UseVisualStyleBackColor = true,
                Font = CONTROLDEFAULTFONT,
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                Enabled = Dal_ManageRights.ManageRights.CameraManagement
            };
            btn_AddCamera.FlatAppearance.BorderSize = 0;
            btn_AddCamera.FlatAppearance.MouseOverBackColor = COLOR_MOUSEENTER;
            btn_AddCamera.FlatAppearance.MouseDownBackColor = COLOR_MOUSEDOWN;
            btn_AddCamera.BackColor = COLOR_BACKGROUND;
            btn_AddCamera.Click += btn_AddCamera_Click;
            btn_AddCamera.Paint += FormComm.DrawBtnEnabled;

            btn_EditCamera = new Button()
            {
                Location = new Point(150, 75),
                Name = "btn_EditCamera",
                Enabled = false,
                Size = new Size(100, 30),
                TabIndex = 2,
                Text = @"编 辑",
                UseVisualStyleBackColor = true,
                Font = CONTROLDEFAULTFONT,
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
            };
            btn_EditCamera.FlatAppearance.BorderSize = 0;
            btn_EditCamera.FlatAppearance.MouseOverBackColor = COLOR_MOUSEENTER;
            btn_EditCamera.FlatAppearance.MouseDownBackColor = COLOR_MOUSEDOWN;
            btn_EditCamera.BackColor = COLOR_BACKGROUND;
            btn_EditCamera.Click += btn_EditCamera_Click;
            btn_EditCamera.Paint += FormComm.DrawBtnEnabled;

            btn_DelCamera = new Button()
            {
                Location = new Point(270, 75),
                Name = "btn_DelCamera",
                Enabled = false,
                Size = new Size(100, 30),
                TabIndex = 3,
                Text = @"移 除",
                UseVisualStyleBackColor = true,
                Font = CONTROLDEFAULTFONT,
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White
            };
            btn_DelCamera.FlatAppearance.BorderSize = 0;
            btn_DelCamera.FlatAppearance.MouseOverBackColor = COLOR_MOUSEENTER;
            btn_DelCamera.FlatAppearance.MouseDownBackColor = COLOR_MOUSEDOWN;
            btn_DelCamera.BackColor = COLOR_BACKGROUND;
            btn_DelCamera.Click += btn_DelCamera_Click;
            btn_DelCamera.Paint += FormComm.DrawBtnEnabled;

            c_ConnectionState = new DataGridViewImageColumn()
            {
                HeaderText = "状态",
                Image = global::CbznSystem.Properties.Resources.block,
                Name = "c_ConnectionState",
                ReadOnly = true,
                Resizable = DataGridViewTriState.False,
                Width = 50,
            };

            c_CameraIp = new DataGridViewTextBoxColumn()
            {
                HeaderText = @" IP 地址",
                Name = "c_CameraIp",
                ReadOnly = true,
                Resizable = DataGridViewTriState.False,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                Width = 110,
            };

            c_CameraDirection = new DataGridViewTextBoxColumn()
            {
                HeaderText = @" 出入口",
                Name = "c_CameraDirection",
                ReadOnly = true,
                Resizable = DataGridViewTriState.False,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                Width = 80,
            };

            c_DeviceNumber = new DataGridViewTextBoxColumn()
            {
                HeaderText = @" 门口编号",
                Name = "c_DeviceNumber",
                ReadOnly = true,
                Resizable = DataGridViewTriState.False,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                Width = 90,
            };

            DataGridViewCellStyle ColumnHeaderCellStyle = new DataGridViewCellStyle()
            {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                BackColor = Color.White,
                Font = CONTROLDEFAULTFONT,
                ForeColor = SystemColors.WindowText,
                SelectionBackColor = SystemColors.Highlight,
                SelectionForeColor = SystemColors.HighlightText,
                WrapMode = DataGridViewTriState.True,
            };

            DataGridViewCellStyle RowCellStyle = new DataGridViewCellStyle()
            {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                BackColor = SystemColors.Window,
                Font = CONTROLDEFAULTFONT,
                ForeColor = SystemColors.ControlText,
                SelectionBackColor = SystemColors.Highlight,
                SelectionForeColor = SystemColors.HighlightText,
                WrapMode = DataGridViewTriState.False,
            };

            dgv_ConnectionCameraList = new DataGridView()
            {
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeColumns = false,
                AllowUserToResizeRows = false,
                BackgroundColor = Color.White,
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
                ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single,
                ColumnHeadersDefaultCellStyle = ColumnHeaderCellStyle,
                ColumnHeadersHeight = 40,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing,
                DefaultCellStyle = RowCellStyle,
                EnableHeadersVisualStyles = false,
                Location = new Point(25, 120),
                MultiSelect = false,
                Name = "dgv_ConnectionCameraList",
                ReadOnly = true,
                RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single,
                RowHeadersVisible = false,
                RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                Size = new Size(350, 300),
                TabIndex = 4,
            };
            dgv_ConnectionCameraList.RowsAdded += Dgv_ConnectionCameraList_RowsAdded;
            dgv_ConnectionCameraList.RowsRemoved += Dgv_ConnectionCameraList_RowsRemoved;
            dgv_ConnectionCameraList.CellFormatting += dgv_ConnectionCameraList_CellFormatting;
            dgv_ConnectionCameraList.RowTemplate.Height = 36;
            dgv_ConnectionCameraList.Columns.AddRange(new DataGridViewColumn[]
            {
                c_ConnectionState,
                c_CameraIp,
                c_CameraDirection,
                c_DeviceNumber
            });

            //生成串口操作控件
            l_AutoConnection = new Label
            {
                AutoSize = true,
                Font = CONTROLDEFAULTFONT,
                Location = new Point(93, 455),
                Name = "l_AutoConnection",
                Size = new Size(79, 20),
                TabIndex = 1,
                Text = @"自动连接："
            };

            cb_AutoConnection = new ComboBox
            {
                Font = CONTROLDEFAULTFONT,
                FormattingEnabled = true,
                Location = new Point(178, 450),
                Name = "cb_AutoConnection",
                Size = new Size(130, 28),
                DropDownStyle = ComboBoxStyle.DropDownList,
                TabIndex = 2
            };
            cb_AutoConnection.Items.AddRange(new object[]
            {
                "关 闭",
                "打 开"
            });
            cb_AutoConnection.SelectedIndexChanged += Cb_AutoConnection_SelectedIndexChanged;

            l_CommPort = new Label
            {
                AutoSize = true,
                Font = CONTROLDEFAULTFONT,
                Location = new Point(93, 495),
                Name = "l_CommPort",
                Size = new Size(79, 20),
                TabIndex = 3,
                Text = @"通信端口："
            };

            cb_CommPort = new ComboBox
            {
                Font = CONTROLDEFAULTFONT,
                FormattingEnabled = true,
                Location = new Point(178, 493),
                Name = "cb_CommPort",
                Size = new Size(130, 28),
                DropDownStyle = ComboBoxStyle.DropDownList,
                TabIndex = 4
            };
            if (_serialPortNames.Count > 0)
                cb_CommPort.Items.AddRange(_serialPortNames.ToArray());

            btn_CommPort = new Button
            {
                Location = new Point(90, 536),
                Name = "btn_CommPort",
                Size = new Size(220, 40),
                TabIndex = 5,
                Text = @"打    开",
                UseVisualStyleBackColor = true,
                FlatStyle = FlatStyle.Flat,
                Font = CONTROLDEFAULTFONT,
                ForeColor = Color.White
            };

            cb_AutoConnection.SelectedIndex = _isAutoConnection ? 1 : 0;
            if (_isAutoConnection)
            {
                cb_CommPort.Enabled = false;
                btn_CommPort.Enabled = false;
            }
            else
            {
                cb_CommPort.Enabled = true;
                btn_CommPort.Enabled = true;
            }
            if (IsConnection)
            {
                int index = cb_CommPort.Items.IndexOf(_mPort.PortName);
                cb_CommPort.SelectedIndex = index;
                btn_CommPort.Text = @"关    闭";
            }
            else
            {
                if (cb_CommPort.Items.Count > 0)
                    cb_CommPort.SelectedIndex = 0;
                btn_CommPort.Text = @"打    开";
            }

            btn_CommPort.BackColor = COLOR_BACKGROUND;
            btn_CommPort.FlatAppearance.BorderSize = 0;
            btn_CommPort.FlatAppearance.MouseOverBackColor = COLOR_MOUSEENTER;
            btn_CommPort.FlatAppearance.MouseDownBackColor = COLOR_MOUSEDOWN;
            btn_CommPort.Click += btn_CommPort_Click;
            btn_CommPort.Paint += FormComm.DrawBtnEnabled;

            p_SetBox.Controls.Add(btn_DelCamera);
            p_SetBox.Controls.Add(btn_EditCamera);
            p_SetBox.Controls.Add(btn_AddCamera);
            p_SetBox.Controls.Add(btn_SearchCamera);
            p_SetBox.Controls.Add(dgv_ConnectionCameraList);
            p_SetBox.Controls.Add(l_AutoConnection);
            p_SetBox.Controls.Add(cb_AutoConnection);
            p_SetBox.Controls.Add(l_CommPort);
            p_SetBox.Controls.Add(cb_CommPort);
            p_SetBox.Controls.Add(btn_CommPort);
            this.Controls.Add(p_SetBox);
            p_SetBox.BringToFront();
        }

        /// <summary>
        /// 端口打开关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_CommPort_Click(object sender, EventArgs e)
        {
            string portname = cb_CommPort.Text;
            try
            {
                if (!_mPort.IsOpen)
                {
                    _mPort.PortName = portname;
                    _mPort.Open();
                }
                else
                {
                    _mPort.Close();
                }
            }
            catch (Exception ex)
            {
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show(ex.Message, @"提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 自动连接变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cb_AutoConnection_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool bRet = cb_AutoConnection.SelectedIndex > 0;
            if (bRet != _isAutoConnection)
            {
                _isAutoConnection = bRet;
            }
            if (bRet)
            {
                cb_CommPort.Enabled = false;
                btn_CommPort.Enabled = false;
            }
            else
            {
                cb_CommPort.Enabled = !IsConnection;
                btn_CommPort.Enabled = cb_CommPort.Items.Count != 0;
            }
        }

        /// <summary>
        /// 列表格式发生变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_ConnectionCameraList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv_ConnectionCameraList.Columns[e.ColumnIndex].Name == "c_CameraDirection")
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(e.Value.ToString(), @"[0|1]$"))
                {
                    e.Value = Convert.ToInt32(e.Value) == 0 ? "入口" : "出口";
                }
            }
        }

        /// <summary>
        /// 列表添加事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dgv_ConnectionCameraList_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            btn_DelCamera.Enabled = Dal_ManageRights.ManageRights.CameraManagement;
            btn_EditCamera.Enabled = Dal_ManageRights.ManageRights.CameraManagement;
        }

        /// <summary>
        /// 列表移除事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dgv_ConnectionCameraList_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dgv_ConnectionCameraList.RowCount == 0)
            {
                btn_DelCamera.Enabled = false;
                btn_EditCamera.Enabled = false;
            }
        }

        /// <summary>
        /// 删除摄像机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_DelCamera_Click(object sender, EventArgs e)
        {
            if (dgv_ConnectionCameraList.RowCount == 0) return;
            if (dgv_ConnectionCameraList.SelectedRows.Count == 0) return;
            int index = dgv_ConnectionCameraList.SelectedRows[0].Index;
            SaveCameraParam param = _mSaveCamera[index];
            if (
                MessageBox.Show(@"确认移除相机 " + param.CameraIp + @" 吗?", @"提示", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                try
                {
                    foreach (ConnectionCameraParam item in _mConnCamera)
                    {
                        if (item.CameraIp == param.CameraIp)
                        {
                            if (item.IsConnection)
                            {
                                CloseCamera(item.CameraIp);
                            }
                            else
                            {
                                Control[] findControls = p_LeftBoxTop.Controls.Find("btn_ReconnectCamera" + item.CameraIp, true);
                                foreach (Control btnitem in findControls)
                                {
                                    btnitem.Parent.Controls.Remove(btnitem);
                                    break;
                                }
                                findControls = p_LeftBoxTop.Controls.Find("pb_" + item.CameraIp, true);
                                foreach (Control pbitem in findControls)
                                {
                                    pbitem.Parent.Controls.Remove(pbitem);
                                }
                            }
                            _mConnCamera.Remove(item);
                            break;
                        }
                    }
                    _mSaveCamera.RemoveAt(index);
                    dgv_ConnectionCameraList.Rows.RemoveAt(index);
                    XmlHelper.Del<SaveCameraParam>(index);
                }
                catch (Exception ex)
                {
                    CustomExceptionHandler.GetExceptionMessage(ex);
                    MessageBox.Show(ex.Message, @"提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// 编辑摄像机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_EditCamera_Click(object sender, EventArgs e)
        {
            if (dgv_ConnectionCameraList.RowCount == 0) return;
            if (dgv_ConnectionCameraList.SelectedRows.Count == 0) return;
            int index = dgv_ConnectionCameraList.SelectedRows[0].Index;
            SaveCameraParam param = _mSaveCamera[index];
            using (EditCamera_Form editcamera = new EditCamera_Form()
            {
                SaveParam = param
            })
            {
                editcamera.ShowDialog();
                if (editcamera.Tag == null) return;
                SaveCameraParam newparam = editcamera.Tag as SaveCameraParam;
                if (newparam == null) return;
                if (newparam == param) return;
                foreach (ConnectionCameraParam item in _mConnCamera)
                {
                    if (item.CameraIp != param.CameraIp) continue;
                    if (item.Direction != (CameraDirection)newparam.Direction)
                    {
                        item.Direction = (CameraDirection)newparam.Direction;
                        Control[] findControls = p_LeftBoxTop.Controls.Find("pb_" + param.CameraIp, true);
                        foreach (Control finditem in findControls)
                        {
                            finditem.Parent.Controls.Remove(finditem);
                            switch (item.Direction)
                            {
                                case CameraDirection.Enter:
                                    p_EnterBox.Controls.Add(finditem);
                                    break;

                                case CameraDirection.Exit:
                                    p_ExitBox.Controls.Add(finditem);
                                    break;
                            }
                            AdjustReconnectionButtonLocation(finditem as PictureBox);
                            break;
                        }
                    }
                    item.DeviceId = newparam.DeviceId;
                    break;
                }
                param.Direction = newparam.Direction;
                param.DeviceId = newparam.DeviceId;
                dgv_ConnectionCameraList.Rows[index].Cells["c_CameraDirection"].Value = param.Direction;
                dgv_ConnectionCameraList.Rows[index].Cells["c_DeviceNumber"].Value = param.DeviceId;
                try
                {
                    XmlHelper.Update<SaveCameraParam>(param, index);
                }
                catch (Exception ex)
                {
                    CustomExceptionHandler.GetExceptionMessage(ex);
                    MessageBox.Show(ex.Message, @"提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// 添加摄像机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_AddCamera_Click(object sender, EventArgs e)
        {
            using (AddCamera_Form addcamera = new AddCamera_Form()
            {
                SearchParam = _mSearchCamera,
                SaveParam = _mSaveCamera
            })
            {
                addcamera.ShowDialog();
                if (addcamera.Tag == null) return;
                SaveCameraParam param = addcamera.Tag as SaveCameraParam;
                if (param == null) return;
                _mSaveCamera.Add(param);
                try
                {
                    OpenSearchCamera(param);
                    XmlHelper.Add<SaveCameraParam>(param);
                }
                catch (Exception ex)
                {
                    CustomExceptionHandler.GetExceptionMessage(ex);
                    MessageBox.Show(ex.Message, @"提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// 搜索摄像机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SearchCamera_Click(object sender, EventArgs e)
        {
            btn_SearchCamera.Enabled = false;
            Thread tSearchCamera = new Thread(SearchCamera);
            tSearchCamera.Start();
            if (_tDelayEnableControl != null) return;
            _tDelayEnableControl = new System.Timers.Timer(10000)
            {
                AutoReset = false
            };
            _tDelayEnableControl.Elapsed += tDelayEnableControl_Elapsed;
            _tDelayEnableControl.Start();
        }

        /// <summary>
        /// 延迟事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tDelayEnableControl_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (p_SetBox != null)
                btn_SearchCamera.Enabled = true;
            _tDelayEnableControl = null;
        }

        /// <summary>
        /// 出口摄像机容器添加事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void P_ExitBox_ControlAdded(object sender, ControlEventArgs e)
        {
            CameraVideoLocation(p_ExitBox);
            p_ExitBox.BackgroundImage = null;
        }

        /// <summary>
        /// 出场摄像机移除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void P_ExitBox_ControlRemoved(object sender, ControlEventArgs e)
        {
            int count = CameraVideoLocation(p_ExitBox);
            if (count == 0)
            {
                p_ExitBox.BackgroundImage = Properties.Resources.Novideos;
            }
        }

        /// <summary>
        /// 出场摄像机大小变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void P_ExitBox_Resize(object sender, EventArgs e)
        {
            CameraVideoLocation(p_ExitBox);
        }

        /// <summary>
        /// 入场摄像机容器添加事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void P_EnterBox_ControlAdded(object sender, ControlEventArgs e)
        {
            CameraVideoLocation(p_EnterBox);
            p_EnterBox.BackgroundImage = null;
        }

        /// <summary>
        /// 入场摄像机容器移除事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void P_EnterBox_ControlRemoved(object sender, ControlEventArgs e)
        {
            int count = CameraVideoLocation(p_EnterBox);
            if (count == 0)
            {
                p_EnterBox.BackgroundImage = Properties.Resources.Novideos;
            }
        }

        /// <summary>
        /// 入场摄像机容器大小变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void P_EnterBox_Resize(object sender, EventArgs e)
        {
            CameraVideoLocation(p_EnterBox);
        }

        /// <summary>
        /// 摄像机出入口显示方式
        /// </summary>
        /// <param name="pBox"></param>
        /// <returns></returns>
        private int CameraVideoLocation(Panel pBox)
        {
            bool flag = false;
            int num = 0;
            int horizontalWidth = pBox.Width / 3;
            int horizontalHeight = (int)((1080F / 1920F) * horizontalWidth);
            int verticalHeight = (pBox.Height - horizontalHeight) / 3;
            int verticalWidth = (int)((1920F / 1080F) * verticalHeight);
            int count = 0;
            foreach (Control item in pBox.Controls)
            {
                if (!(item is PictureBox)) continue;
                count++;
            }
            foreach (Control item in pBox.Controls)
            {
                if (!(item is PictureBox)) continue;
                if (!flag)
                {
                    item.Location = new Point(0, 0);
                    if (count == 1)
                    {
                        item.Size = new Size(pBox.Width, pBox.Height);
                    }
                    else if (count <= 4)
                    {
                        item.Size = new Size(pBox.Width, pBox.Height - horizontalHeight);
                    }
                    else if (count <= 7)
                    {
                        item.Size = new Size(pBox.Width - verticalWidth, pBox.Height - verticalHeight);
                    }
                    flag = true;
                }
                else
                {
                    if (count <= 4)
                    {
                        item.Location = new Point(num * horizontalWidth, pBox.Height - horizontalHeight);
                        item.Size = new Size(pBox.Width / 3, horizontalHeight);
                        num++;
                        if (num >= 4)
                        {
                            num = 0;
                        }
                    }
                    else if (count <= 7)
                    {
                        item.Location = new Point(pBox.Width - verticalWidth, num * verticalHeight);
                        item.Size = new Size(pBox.Height / 3, verticalHeight);
                        num++;
                    }
                }
            }
            return count;
        }

        /// <summary>
        /// 显示摄像机画面容器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void P_LeftBoxTop_Resize(object sender, EventArgs e)
        {
            int width = p_LeftBoxTop.Width / 2;
            p_EnterBox.Size = new Size(width, p_LeftBoxTop.Height);
            p_ExitBox.Size = p_EnterBox.Size;
            p_EnterBox.Location = new Point(width, 0);
            p_ExitBox.Location = new Point(0, 0);
        }

        /// <summary>
        /// 左边容器大小变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void P_LeftBox_Resize(object sender, EventArgs e)
        {
            int height = p_LeftBox.Height / 2;
            p_LeftBoxBottom.Height = height;
        }

        /// <summary>
        /// 金额文本启用或不启用事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tb_Money_EnabledChanged(object sender, EventArgs e)
        {
            if (tb_Money.Enabled)
            {
                tb_Money.Focus();
                tb_Money.SelectionStart = tb_Money.TextLength;
            }
        }

        /// <summary>
        /// 限制用户输入金额数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tb_Money_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 46)
            {
                if (tb_Money.TextLength == 0)
                {
                    tb_Money.Text = tb_Money.Text.Insert(0, "0");
                    tb_Money.SelectionStart = tb_Money.TextLength;
                }
                else
                {
                    e.Handled = tb_Money.Text.Contains(".");
                }
            }
            else if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                int index = tb_Money.SelectionStart;
                int indexof = tb_Money.Text.IndexOf('.');
                if (indexof > 0)
                {
                    if (index > indexof)
                    {
                        if (tb_Money.TextLength - 1 - indexof >= 2)
                        {
                            e.Handled = true;
                        }
                    }
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 控件启用或不启用事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Enter_EnabledChanged(object sender, EventArgs e)
        {
            if (btn_Enter.Enabled)
            {
                tb_Money.Enabled = true;
                tb_Money.Focus();
                tb_Money.SelectionStart = tb_Money.TextLength;
            }
            else
            {
                tb_Money.Enabled = false;
            }
        }

        /// <summary>
        /// 确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Enter_Click(object sender, EventArgs e)
        {
            btn_Enter.Enabled = false;
            try
            {
                double newmoney = Convert.ToDouble(tb_Money.Text.Trim());
                _mParkingRecord.ActualAmount = newmoney;

                OpenTheDoor(_mParkingRecord.CardNumber, _mParkingRecord.PlateNumber);
                if (_mParkingRecord.ID == 0)
                {
                    AddChargeRecord();
                }
            }
            catch (Exception ex)
            {
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show(ex.Message, @"提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 窗体获取焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tab4_Form_Activated(object sender, EventArgs e)
        {
            if (PortHelper.CurrentForm != this)
            {
                PortHelper.CurrentForm = this;

                if (!IsReadIcCard && _isShow)
                {
                    ReadIcCard();
                }
            }
        }

        /// <summary>
        /// 关闭读取Ic卡内容
        /// </summary>
        public void CloseReadIcCard()
        {
            if (PortHelper.IsConnection)
            {
                byte[] by = PortAgreement.GetCloseModule();
                WirelessPortDataWrite(by);
                IsReadIcCard = false;
                by = null;
            }
        }

        /// <summary>
        /// 读取IC卡内容
        /// </summary>
        private void ReadIcCard()
        {
            if (PortHelper.IsConnection)
            {
                byte[] by = PortAgreement.GetReadTemporaryIC();
                WirelessPortDataWrite(by);
                IsReadIcCard = true;
                by = null;
            }
        }

        /// <summary>
        /// 窗体显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tab4_Form_Shown(object sender, EventArgs e)
        {
            _isShow = true;

            //加载摄像机
            LoadCamera();

            _mDataValidation = new DataValidation()
            {
                IsProtocol = true,
                ProtocolHead = 2,
                ProtocolEnd = 3,
                IsValidation = true
            };

            _mPort = new SerialPortEx()
            {
                BaudRate = WinApi.B19200,
                DataBit = WinApi.BIT_8,
                StopBit = WinApi.STOP_1,
                Parity = WinApi.p_NONE
            };
            _mPort.DataReceived += SerialPortDataReceived;
            _mPort.PortChange += SerialPortChange;
            _mPort.SerialPortCountChange += _mPort_SerialPortCountChange;
            _mPort.Start();
            PortHelper.SerialPortConnection += PortHelper_SerialPortConnection;

            Thread tTimingThread = new Thread(TimingFunction) { IsBackground = true };
            tTimingThread.Start();

            //无线模块进行连接
            DeviceConnectionChange(PortHelper.IsConnection);
        }

        /// <summary>
        /// 端口数据量变化事件
        /// </summary>
        /// <param name="portnames"></param>
        private void _mPort_SerialPortCountChange(List<string> portnames)
        {
            _serialPortNames = portnames;

            if (p_SetBox != null)
            {
                cb_CommPort.Invoke(new EventHandler(delegate
                {
                    cb_CommPort.Items.Clear();
                    if (_serialPortNames != null)
                    {
                        cb_CommPort.Items.AddRange(_serialPortNames.ToArray());
                        if (IsConnection)
                        {
                            int index = _serialPortNames.IndexOf(_mPort.PortName);
                            cb_CommPort.SelectedIndex = index;
                        }
                        else
                        {
                            cb_CommPort.SelectedIndex = 0;
                        }
                    }
                }));
            }
        }

        /// <summary>
        /// 有线自动连接端口
        /// </summary>
        /// <param name="portname"></param>
        private void PortHelper_SerialPortConnection(string portname)
        {
            if (!_isAutoConnection) return;
            if (IsConnection) return;
            try
            {
                _mPort.PortName = portname;
                _mPort.Open();
                _mPort.Flush();
                byte[] by;
                foreach (SaveCameraParam item in _mSaveCamera)
                {
                    if (!_isAutoConnection) break;
                    by = PortAgreement.GetSearchHost(item.DeviceId);
                    _mPort.Write(by);
                    Thread.Sleep(500);
                    if (IsConnection)
                    {
                        return;
                    }
                }
                by = null;
                _mPort.Close();
                Thread.Sleep(10);
            }
            catch
            {

            }
        }

        /// <summary>
        /// 有线端口变化事件
        /// </summary>
        /// <param name="flag"></param>
        private void SerialPortChange(bool flag)
        {
            if (!flag)
            {
                IsConnection = false;
            }
        }

        /// <summary>
        /// 端口数据接收事件
        /// </summary>
        /// <param name="port"></param>
        private void SerialPortDataReceived(int port)
        {
            try
            {
                Thread.Sleep(10);
                byte[] by = _mPort.Read(_mPort.GetIqueue);
                if (by == null) return;
                List<byte[]> bylist = _mDataValidation.Validation(by);
                foreach (byte[] item in bylist)
                {
                    ParsingParameter param = DataParsing.ParsingContent(item);
                    if (param.FunctionAddress == 48 && param.Command == 1)
                    {
                        IsConnection = true;
                    }
                }
            }
            catch (Exception ex)
            {
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 显示上传的信息
        /// </summary>
        /// <param name="by"></param>
        private void DisplayUpdateInfo(byte[] by)
        {
            string LicensePlate = DataParsing.GetModuleUpdateContent(by);
            if (string.IsNullOrEmpty(LicensePlate)) return;
            this.Invoke(new EventHandler(delegate
            {
                l_ExitLicensePlate.Text = LicensePlate;
                l_EnterLicensePlate.ForeColor = Color.Black;
            }));
        }

        /// <summary>
        /// 定时删除图片记录
        /// </summary>
        private void TimingFunction()
        {
            while (true)
            {
                DateTime now = DateTime.Now;
                DateTime timing = now.AddDays(1).Date;
                if ((timing - now).TotalMinutes < 1)
                {
                    try
                    {
                        Dbhelper.Db.Del<CbTempChargeRecord>($" and EntranceTime < '{now.AddYears(-6):yyyy-MM-dd}' ");
                        Dbhelper.Db.Del<CBEnteranceRecrd>($" and EntranceTime <'{now.AddYears(-6):yyyy-MM-dd}' ");
                        if (Dal_SysSettings.SystemSettings.RemoteConnection == 0)
                        {
                            string cmdtext = " Vacuum CBTempChargeRecord  ; Vacuum CBEnteranceRecrd  ";
                            Dbhelper.Db.ExecuteNonQuery(cmdtext);
                        }
                        string directorypath = Application.StartupPath + "\\Imgs";
                        if (Directory.Exists(directorypath))
                        {
                            //删除图片
                            DelRecordImgFile(directorypath);
                        }
                        //更新
                    }
                    catch (Exception ex)
                    {
                        CustomExceptionHandler.GetExceptionMessage(ex);
                    }
                    Thread.Sleep(60000);//一分钟
                }
                WinApi.mouse_event(WinApi.MOUSEEVENTF_MOVE, 0, 0, 0, 0);
                Thread.Sleep(60000);//一分钟
            }
        }

        /// <summary>
        /// 删除记录图片
        /// </summary>
        /// <param name="path"></param>
        private void DelRecordImgFile(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            DateTime now = DateTime.Now.AddMonths(-3);
            //DataSet ds = Dal_CbEnteranceRecrd.GetTimeGroupAndRecord(now);
            //List<CBEnteranceRecrd> mGroupList = TableToClassList<CBEnteranceRecrd>(ds.Tables[0]);
            //List<CBEnteranceRecrd> mEnterRecordList = TableToClassList<CBEnteranceRecrd>(ds.Tables[1]);
            foreach (DirectoryInfo item in dir.GetDirectories())
            {
                try
                {
                    if (item.CreationTime.Date < now.Date)
                    {
                        //bool flag = false;// ComparisonCreateTimeAndRecordTime(item, mGroupList);
                        foreach (FileInfo fileInfo in item.GetFiles())
                        {
                            try
                            {
                                // if (!ComparisonImgTimeAndRecordTime(fileInfo, mEnterRecordList))
                                // {
                                fileInfo.Delete();
                                Thread.Sleep(8);
                                // }
                            }
                            catch
                            {
                                // ignored
                            }
                        }
                        //if (!flag)
                        item.Delete();
                    }
                }
                catch
                {
                    // ignored
                }
            }
            // mGroupList = null;
            // mEnterRecordList = null;
            // ds = null;
            dir = null;
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tab4_Form_Load(object sender, EventArgs e)
        {
            AnShiBaoPlateInfoCallBack = AnShiBaoPlateInfo;
            HuoYanPlateInfoCallBack = HuoYanPlateInfo;
            HuoYanFindDeviceCallBack = HuoYanFindDevice;
            HuoYanSerialDataReceivedCallBack = HuoYanSerialDataReceived;
            QianYiPlateInfoCallBack = QianYiPlateInfo;
            QianYiFindDeviceCallBack = QianYiFindDevice;
            QianYiRegReportMessageCallBack = QianYiRegReportMessage;

            //初始化发行器端口接收事件
            PortHelper.DataReceived += SerialPortDataReceived;
            //初始化发行器端口发生变化事件
            PortHelper.ConnectionChange += DeviceConnectionChange;

            _serialPortNames = new List<string>();
            _mConnCamera = new List<ConnectionCameraParam>();
            _mSearchCamera = new List<SearchCameraParam>();
            _mSaveCamera = XmlHelper.Loads<SaveCameraParam>();
            if (_mSaveCamera == null)
            {
                _mSaveCamera = new List<SaveCameraParam>();
            }

            try
            {
                if (Dal_ChargeParameter.ChargeParam == null)
                {
                    //获取收费参数
                    Dal_ChargeParameter.ChargeParam = Dbhelper.Db.FirstDefault<CbChargeParameter>();
                    if (Dal_ChargeParameter.ChargeParam == null)
                    {
                        Dal_ChargeParameter.ChargeParam = new CbChargeParameter()
                        {
                            ChargeMode = 1,
                            DailyLimit = 10,
                            FreeMinutes = 30,
                            FirstCharge = 30,
                            FirstMoney = 5,
                            TwoCharge = 60,
                            TwoMoney = 1
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 发行器端口连接发生变化事件
        /// </summary>
        /// <param name="flag"></param>
        private void DeviceConnectionChange(bool flag)
        {
            if (flag)
            {
                if (!IsConnectionModule && Dal_SysSettings.SystemSettings.SaveCommunicationID > 0)
                {
                    SearchFrequency(PortHelper.CurrentForm == this);
                }
                else
                {
                    if (PortHelper.CurrentForm == this)
                    {
                        ReadIcCard();
                    }
                }
            }
            else
            {
                IsConnectionModule = false;
                IsReadIcCard = false;
            }
        }

        /// <summary>
        /// 搜索频率
        /// </summary>
        private void SearchFrequency(bool flag)
        {
            this.BeginInvoke(new EventHandler(delegate
            {
                //搜索无线频率
                using (SearchWirelessFrequency_Form searchwirelessfrequency = new SearchWirelessFrequency_Form(Dal_SysSettings.SystemSettings.SaveCommunicationID, Dal_SysSettings.SystemSettings.SaveFrequency))
                {
                    if (searchwirelessfrequency.ShowDialog() == DialogResult.OK)
                    {
                        IsConnectionModule = true;
                    }
                }
                if (flag)
                {
                    //防止窗体没有获取焦点并且发送读卡命令
                    this.Activate();
                }
            }));
        }

        /// <summary>
        /// 端口数据接收(发行器)
        /// </summary>
        /// <param name="param"></param>
        private void SerialPortDataReceived(ParsingParameter param)
        {
            if (!PortHelper.IsConnection) return;
            if (PortHelper.CurrentForm != this) return;

            if (param.FunctionAddress == 66)
            {
                if (param.Command == 9)//获取IC卡信息
                {
                    IcCardParameter iccardparam = DataParsing.TemporaryIcCardContent(param.DataContent);
                    if (iccardparam.Plate.Length > 9) return;
                    if (iccardparam.Time.Length > 19) return;

                    IcCardCharge(iccardparam);
                }
                else if (param.Command == 2)//写入IC卡数据
                {
                    StopTimeOut();
                    //不管成功还是失败都要发送读取Ic卡内容
                    ReadIcCard();
                }
            }
            else if (param.FunctionAddress == 67) //模块操作
            {
                if (param.Command == 9)
                {
                    if (param.DataContent.Length == 10)//模块上传车牌号码
                    {
                        DisplayUpdateInfo(param.DataContent);
                    }
                    else if (param.DataContent.Length == 1)//模块回传参数
                    {
                        StopTimeOut();
                        if (DataParsing.TemporaryContent(param.DataContent) != 83) //失败
                        {
                            _operatingCount++;
                            switch (_eCurrentOperating)
                            {
                                case OperationTypes.PlayVoice:
                                    if (_operatingCount < 3)//发送二次播报语音
                                    {
                                        BroadcastVoice(_mParkingRecord.PlateNumber, (_mParkingRecord.ExportTime - _mParkingRecord.EntranceTime).Milliseconds, _mParkingRecord.ChargeAmount);
                                    }
                                    else//二次发送都失败
                                    {
                                        _operatingCount = 0;
                                        ReadIcCard();//发送读Ic卡内容
                                    }
                                    break;
                                case OperationTypes.OpenTheDoor://发送二次开门
                                    if (_operatingCount < 3)
                                    {
                                        OpenTheDoor(_mParkingRecord.CardNumber, _mParkingRecord.PlateNumber);
                                    }
                                    else//二次发送都失败
                                    {
                                        btn_Enter.Enabled = true;
                                        _operatingCount = 0;
                                        ReadIcCard();//发送读取Ic卡内容
                                    }
                                    break;
                            }
                        }
                        else //成功
                        {
                            if (_eCurrentOperating == OperationTypes.OpenTheDoor)
                            {
                                //清除Ic卡内容
                                ClearIcCardContent();
                            }
                            else
                            {
                                //读取Ic卡内容
                                ReadIcCard();
                            }
                            _operatingCount = 0;
                            _eCurrentOperating = OperationTypes.None;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Ic卡收费处理
        /// </summary>
        private void IcCardCharge(IcCardParameter param)
        {
            DateTime now = DateTime.Now;
            //同一张IC卡30秒内不能重复刷
            if (_mParkingRecord != null && _mParkingRecord.CardNumber == param.IcNumber)
            {
                if ((now - _mParkingRecord.ExportTime).TotalSeconds < DELAYTIME)
                {
                    return;
                }
            }

            try
            {
                DateTime entertime = DateTime.ParseExact(param.Time, "G", CultureInfo.CurrentCulture);
                TimeSpan ts = now - entertime;
                double money = ChargeCalculate.CalculateMoney(ts);
                _mParkingRecord = new CbTempChargeRecord()
                {
                    CardNumber = param.IcNumber,//Ic卡编号
                    PlateNumber = param.Plate,//车牌号码
                    EntranceTime = entertime,//入场时间
                    ExportTime = now,//出场时间
                    ChargeAmount = money,//应收金额
                    ActualAmount = money,//实收金额
                    ManageName = Dal_ManageInfo.ManageInfo.ManageName
                };

                Image fullImg = null, plateImg = null;
                CBEnteranceRecrd mEnterRecord = GetEnterRecord(param.Plate.Contains("福") ? param.IcNumber : param.Plate);//获取入场的信息
                if (mEnterRecord != null)
                {
                    if (Dal_SysSettings.SystemSettings.RemoteConnection == 0)//本地数据库
                    {
                        string fullpath = string.Empty, platepath = string.Empty;
                        GetImgSavePath(mEnterRecord.PlateNumber, mEnterRecord.EntranceTime, ref fullpath, ref platepath);//获取本地图片
                        if (File.Exists(fullpath))//显示入场的图片
                        {
                            fullImg = Image.FromFile(fullpath);
                        }
                        if (File.Exists(platepath))//显示入场车牌的图片
                        {
                            plateImg = Image.FromFile(platepath);
                        }
                    }
                    else//远程数据库
                    {
                        if (mEnterRecord.ImgData != null)
                        {
                            using (MemoryStream ms = new MemoryStream(mEnterRecord.ImgData))
                            {
                                fullImg = Image.FromStream(ms);
                            }
                        }
                        if (mEnterRecord.PlateData != null)
                        {
                            using (MemoryStream ms = new MemoryStream(mEnterRecord.PlateData))
                            {
                                plateImg = Image.FromStream(ms);
                            }
                        }
                    }
                    Dbhelper.Db.Del<CBEnteranceRecrd>(mEnterRecord.ID);
                }

                this.BeginInvoke(new EventHandler(delegate
                {
                    //显示信息
                    if (_mParkingRecord.PlateNumber.Contains("福"))
                    {
                        l_EnterLicensePlate.Text = "无牌车";
                        l_EnterLicensePlate.ForeColor = Color.Black;
                        l_ExitLicensePlate.ForeColor = Color.Black;
                    }
                    else
                    {
                        l_EnterLicensePlate.Text = _mParkingRecord.PlateNumber;
                        if (l_ExitLicensePlate.Text != _mParkingRecord.PlateNumber)
                        {
                            l_EnterLicensePlate.ForeColor = Color.Red;
                            l_ExitLicensePlate.ForeColor = Color.Red;
                        }
                        else
                        {
                            l_EnterLicensePlate.ForeColor = Color.Green;
                            l_ExitLicensePlate.ForeColor = Color.Green;
                        }
                    }
                    l_EnterTime.Text = _mParkingRecord.EntranceTime.ToString("MM月dd日 HH时mm分ss秒");
                    l_ExitTime.Text = _mParkingRecord.ExportTime.ToString("MM月dd日 HH时mm分ss秒");
                    l_ParkingTime.Text = GetParkingTime(ts);
                    l_Receivables.Text = _mParkingRecord.ChargeAmount.ToString();
                    tb_Money.Text = _mParkingRecord.ChargeAmount.ToString();
                    btn_Enter.Enabled = _mParkingRecord.ChargeAmount > 0;
                    if (pb_EnterFullImg.Image != null)
                    {
                        pb_EnterFullImg.Image.Dispose();
                    }
                    pb_EnterFullImg.Image = fullImg;
                    if (pb_EnterPlateImg.Image != null)
                    {
                        pb_EnterPlateImg.Image.Dispose();
                    }
                    pb_EnterPlateImg.Image = plateImg;
                }));

                if (money > 0)//播放收费语音
                {
                    if (money <= 999 || ts.TotalHours <= 999)
                    {
                        BroadcastVoice(param.Plate, (int)ts.TotalMinutes, money);
                    }
                }
                else//打开
                {
                    OpenTheDoor(param.IcNumber, param.Plate);
                    AddChargeRecord();
                }
            }
            catch (Exception ex)
            {
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 清除Ic卡内容
        /// </summary>
        private void ClearIcCardContent()
        {
            byte[] by = PortAgreement.SetIcCardContent("FFFFFFFFFFFFFFFFFF");
            WirelessPortDataWrite(by);
            StartTimeOut();
            by = null;
        }

        /// <summary>
        /// 开启超时线程
        /// </summary>
        private void StartTimeOut()
        {
            StopTimeOut();
            _tTimeOutThread = new Thread(TimeOutWait);
            _tTimeOutThread.IsBackground = true;
            _tTimeOutThread.Start();
        }

        /// <summary>
        /// 线程等待
        /// </summary>
        private void TimeOutWait()
        {
            try
            {
                Thread.Sleep(2000);

                if (PortHelper.CurrentForm == this)
                {
                    ReadIcCard();
                }
            }
            finally
            {
                _tTimeOutThread = null;
            }
        }

        /// <summary>
        /// 停止超时线程
        /// </summary>
        private void StopTimeOut()
        {
            if (_tTimeOutThread != null)
            {
                _tTimeOutThread.Abort();
            }
        }

        /// <summary>
        /// 开门
        /// </summary>
        /// <param name="icnumber"></param>
        /// <param name="licenseplate"></param>
        private void OpenTheDoor(string icnumber, string licenseplate)
        {
            OpenTheDoor(icnumber, licenseplate, GetExitDeviceAddress());
        }

        /// <summary>
        /// 开门
        /// </summary>
        /// <param name="icnumber"></param>
        /// <param name="licenseplate"></param>
        /// <param name="deviceaddress"></param>
        private void OpenTheDoor(string icnumber, string licenseplate, int deviceaddress)
        {
            PortAgreement.OpenTheDoorParam2 param = new PortAgreement.OpenTheDoorParam2()
            {
                IcCardNumber = icnumber,
                LicensePlateNumber = licenseplate,
                Time = DateTime.Now,
                LicensePlateColor = GetLicensePlateColor(licenseplate),
                DeviceAddress = deviceaddress
            };
            _eCurrentOperating = OperationTypes.OpenTheDoor;
            byte[] by = PortAgreement.GetOpenDoor(param);
            PortDataWrite(by);
            by = null;
        }

        /// <summary>
        /// 添加收费记录
        /// </summary>
        private void AddChargeRecord()
        {
            _mParkingRecord.ID = Dbhelper.Db.Insert<CbTempChargeRecord>(_mParkingRecord);

            this.Invoke(new EventHandler(delegate
            {
                dgv_RecordList.Rows.Insert(0, new object[]
                {
                    _mParkingRecord.ID,
                    _mParkingRecord.CardNumber,
                    _mParkingRecord.PlateNumber,
                    _mParkingRecord.EntranceTime,
                    _mParkingRecord.ExportTime,
                    GetParkingTime(_mParkingRecord.EntranceTime,_mParkingRecord.ExportTime),
                    _mParkingRecord.ChargeAmount,
                    _mParkingRecord.ActualAmount,
                    _mParkingRecord.ManageName
                });
                dgv_RecordList.FirstDisplayedScrollingRowIndex = 0;
                if (dgv_RecordList.RowCount > 30)
                {
                    dgv_RecordList.Rows.RemoveAt(dgv_RecordList.RowCount - 1);
                }
            }));
        }

        /// <summary>
        /// 获取停车时间
        /// </summary>
        /// <param name="entertime"></param>
        /// <param name="exittime"></param>
        /// <returns></returns>
        private string GetParkingTime(DateTime entertime, DateTime exittime)
        {
            TimeSpan ts = exittime - entertime;
            return GetParkingTime(ts);
        }

        /// <summary>
        /// 锁住端口防止数据发送串连
        /// </summary>
        /// <param name="by"></param>
        private void PortDataWrite(byte[] by)
        {
            if (IsConnection && _mPort.IsOpen) //有线商品
            {
                _mPort.Write(by);

                ClearIcCardContent();//无线端口清给Ic卡内容
            }
            else //无线端口
            {
                WirelessPortDataWrite(by);
                StartTimeOut();
            }
        }

        /// <summary>
        /// 无线端口发送
        /// </summary>
        /// <param name="by"></param>
        private void WirelessPortDataWrite(byte[] by)
        {
            lock (_lockPort)
            {
                DateTime now = DateTime.Now;
                int milliseconds = (int)(now - _writeTime).TotalMilliseconds;
                if (milliseconds >= 0 && milliseconds < 150)
                {
                    Thread.Sleep(150 - milliseconds);
                }
                PortHelper.SerialPortWrite(by);
                _writeTime = now;
            }
        }

        /// <summary>
        /// 播报收费语音
        /// </summary>
        /// <param name="licenseplate"></param>
        /// <param name="parkingtime"></param>
        /// <param name="money"></param>
        private void BroadcastVoice(string licenseplate, int parkingtime, double money)
        {
            BroadcastVoice(licenseplate, GetExitDeviceAddress(), parkingtime, money);
        }

        /// <summary>
        /// 获取出口设备的地址
        /// </summary>
        /// <returns></returns>
        private int GetExitDeviceAddress()
        {
            int deviceaddress = 0;
            if (_mExitParam != null)
            {
                deviceaddress = _mExitParam.DeviceId;
            }
            else
            {
                foreach (SaveCameraParam item in _mSaveCamera)
                {
                    if (item.Direction == (int)CameraDirection.Exit)
                    {
                        deviceaddress = item.Direction;
                        break;
                    }
                }
            }
            return deviceaddress;
        }

        /// <summary>
        /// 播报收费语音
        /// </summary>
        /// <param name="licenseplate"></param>
        /// <param name="deviceid"></param>
        /// <param name="parkingtime"></param>
        /// <param name="money"></param>
        private void BroadcastVoice(string licenseplate, int deviceid, int parkingtime, double money)
        {
            PortAgreement.VoiceParam param = new PortAgreement.VoiceParam()
            {
                licensePlateNumber = licenseplate,
                DeviceAddress = deviceid,
                Minute = parkingtime,
                Money = money * 10,
                LicensePlateColor = GetLicensePlateColor(licenseplate)
            };
            _eCurrentOperating = OperationTypes.PlayVoice;
            byte[] by = PortAgreement.GetVoice(param);
            PortDataWrite(by);
            by = null;
        }

        /// <summary>
        /// 获取车牌的颜色
        /// </summary>
        /// <param name="licenseplatenumber"></param>
        /// <returns></returns>
        private PortAgreement.LicensePlateColors GetLicensePlateColor(string licenseplatenumber)
        {
            int licenseplatecolor = 0;
            if (_mExitParam != null && _mExitParam.LicensePlate == licenseplatenumber)
            {
                licenseplatecolor = _mExitParam.LicensePlateColor;
            }
            return (PortAgreement.LicensePlateColors)licenseplatecolor;
        }

        /// <summary>
        /// 获取入场记录
        /// </summary>
        /// <param name="licenseplate"></param>
        private CBEnteranceRecrd GetEnterRecord(string licenseplate)
        {
            return Dbhelper.Db.FirstDefault<CBEnteranceRecrd>($" and PlateNumber='{licenseplate}' ");
        }

        /// <summary>
        /// 获取停车时间
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        private string GetParkingTime(TimeSpan ts)
        {
            StringBuilder sb = new StringBuilder();
            if (ts.TotalMinutes > 1)
            {
                if (ts.Days > 0)
                {
                    sb.Append($"{ts.Days}天");
                }
                if (ts.Hours > 0)
                {
                    sb.Append($"{ts.Hours}小时");
                }
                if (ts.Minutes > 0)
                {
                    sb.Append($"{ts.Minutes}分钟");
                }
            }
            else
            {
                sb.Append("1 分钟");
            }
            return sb.ToString();
        }

        /// <summary>
        ///  加载摄像机
        /// </summary>
        private void LoadCamera()
        {
            InitCamera();

            if (_initAnShiBao && _initHuoYan && _initQianYi)
            {
                Thread tSearchFindDevice = new Thread(SearchCamera);
                tSearchFindDevice.Start();
            }
            else
            {
                //创建初始化摄像机按钮
                Control[] findControl = p_LeftBoxTop.Controls.Find("btn_InitCamera", false);
                if (findControl.Length != 0) return;
                Button btn_InitCamera = new Button()
                {
                    Size = new Size(200, 50),
                    Font = new Font(new FontFamily("微软雅黑"), 12.5F, FontStyle.Regular),
                    Name = "btn_InitCamera",
                    Text = @"初始化摄像机",
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.FromArgb(51, 153, 219),
                    ForeColor = Color.White
                };
                btn_InitCamera.Location = new Point((p_LeftBoxTop.Width - btn_InitCamera.Width) / 2,
                    (p_LeftBoxTop.Height - btn_InitCamera.Height) / 2);
                btn_InitCamera.FlatAppearance.BorderSize = 0;
                btn_InitCamera.FlatAppearance.MouseOverBackColor = Color.FromArgb(93, 175, 225);
                btn_InitCamera.FlatAppearance.MouseDownBackColor = Color.FromArgb(45, 130, 187);
                btn_InitCamera.Click += Btn_InitCamera_Click;
                p_LeftBoxTop.Controls.Add(btn_InitCamera);
                btn_InitCamera.BringToFront();
            }
        }

        /// <summary>
        /// 初始化按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_InitCamera_Click(object sender, EventArgs e)
        {
            LoadCamera();

            if (!_initAnShiBao || !_initHuoYan || !_initQianYi) return;
            Button btn = sender as Button;
            if (btn == null) return;
            btn.Parent.Controls.Remove(btn);
            btn.Dispose();
        }

        /// <summary>
        /// 搜索摄像机
        /// </summary>
        private void SearchCamera()
        {
            try
            {
                if (_initAnShiBao)
                {
                    AnShiBaoFindDevice();
                }

                if (_initHuoYan && _pHuoYanFindDevice != 0)
                {
                    _pHuoYanFindDevice = HuoYanClientSdk.VZLPRClient_StartFindDevice(HuoYanFindDeviceCallBack, IntPtr.Zero);
                }

                if (_initQianYi)
                {
                    QianYiClientSdk.Net_FindDevice(QianYiFindDeviceCallBack, IntPtr.Zero);
                }
            }
            catch (Exception ex)
            {
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show(ex.Message, @"提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 安视宝摄像机搜索
        /// </summary>
        private void AnShiBaoFindDevice()
        {
            int cameraNum = 0;
            int ipSize = Marshal.SizeOf(typeof(AnShiBaoClientSdk.CAMERA_IP_TAG));
            IntPtr pCameraList = Marshal.AllocHGlobal(ipSize * 128);
            try
            {
                int iRet = AnShiBaoClientSdk.IPCSDK_Find_Camera(ref cameraNum, pCameraList);
                if (iRet != 0) return;
                if (cameraNum <= 0) return;
                List<SearchCameraParam> searchparam = new List<SearchCameraParam>();
                for (int i = 0; i < cameraNum; i++)
                {
                    int hwnd = pCameraList.ToInt32() + i * ipSize;
                    AnShiBaoClientSdk.CAMERA_IP_TAG cameraParam =
                        (AnShiBaoClientSdk.CAMERA_IP_TAG)
                        Marshal.PtrToStructure((IntPtr)hwnd, typeof(AnShiBaoClientSdk.CAMERA_IP_TAG));
                    searchparam.Add(new SearchCameraParam()
                    {
                        CameraIp = cameraParam.ip,
                        CameraPort = cameraParam.port,
                        CameraType = CameraTypes.AnShiBao
                    });
                }
                foreach (SearchCameraParam item in searchparam)
                {
                    FindDeviceShow(item);
                }
            }
            catch (Exception ex)
            {
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show(ex.Message, @"提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Marshal.FreeHGlobal(pCameraList);
            }
        }

        /// <summary>
        /// 安视宝车牌识别结果回调函数
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="buff"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        private int AnShiBaoPlateInfo(string ip, IntPtr buff, int len)
        {
            /* 16KB 用于存储车牌信息足够了 */
            IntPtr pPlateResult = IntPtr.Zero;
            // 车牌特写图临时空间
            IntPtr pPlateJpeg = IntPtr.Zero;
            //获取车牌号
            IntPtr pLicensePlate = IntPtr.Zero;
            //获取车牌颜色
            IntPtr pLinceseColor = IntPtr.Zero;
            try
            {
                pPlateResult = Marshal.AllocHGlobal(16 * 1024);
                pPlateJpeg = Marshal.AllocHGlobal(32 * 1024);
                int lenght = 0;
                int iRet = AnShiBaoClientSdk.IPCSDK_Get_Plate_Info(buff, pPlateResult, ref lenght);
                if (iRet == 0)
                {
                    pLicensePlate = Marshal.AllocHGlobal(20);
                    iRet = AnShiBaoClientSdk.IPCSDK_Get_Plate_License(pPlateResult, pLicensePlate);
                    if (iRet == 0)
                    {
                        string strLicensePlate = Marshal.PtrToStringAnsi(pLicensePlate);
                        string strFullPath = string.Empty, strPlatePath = string.Empty;
                        int licensePlateType = 0, licensePlatecolor = 0;
                        DateTime now = GetImgSavePath(strLicensePlate, ref strFullPath, ref strPlatePath);
                        if (!File.Exists(strFullPath))
                        {
                            CameraImgSave(strFullPath, buff, len);
                        }
                        if (!File.Exists(strPlatePath))
                        {
                            iRet = AnShiBaoClientSdk.IPCSDK_Get_Plate_Jpeg(buff, pPlateJpeg, ref lenght);
                            if (iRet == 0)
                            {
                                CameraImgSave(strPlatePath, pPlateJpeg, lenght);
                            }
                        }
                        pLinceseColor = Marshal.AllocHGlobal(8);
                        iRet = AnShiBaoClientSdk.IPCSDK_Get_Plate_Color(pPlateResult, pLinceseColor);
                        if (iRet == 0)
                        {
                            string strPlateColor = Marshal.PtrToStringAnsi(pLinceseColor);
                            switch (strPlateColor)
                            {
                                case "黄":
                                    licensePlateType = 2;
                                    licensePlatecolor = 1;
                                    break;
                                case "白":
                                    licensePlatecolor = 2;
                                    break;
                                case "黑":
                                    licensePlatecolor = 3;
                                    break;
                                case "绿":
                                    licensePlatecolor = 4;
                                    break;
                            }
                        }
                        ConnectionCameraParam cameraparam = DistinguishCamera(ip);
                        if (cameraparam != null)
                        {
                            RecognitionParam param = new RecognitionParam()
                            {
                                DeviceId = cameraparam.DeviceId,
                                Direction = cameraparam.Direction,
                                EnterExitTime = now,
                                LicensePlate = strLicensePlate,
                                FullImgPath = strFullPath,
                                LicensePlatImgPath = strPlatePath,
                                LicensePlateType = licensePlateType,
                                LicensePlateColor = licensePlatecolor
                            };
                            AddEnterRecord(param);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show(ex.Message, @"提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (pLinceseColor != IntPtr.Zero)
                    Marshal.FreeHGlobal(pLinceseColor);
                if (pPlateResult != IntPtr.Zero)
                    Marshal.FreeHGlobal(pPlateResult);
                if (pPlateJpeg != IntPtr.Zero)
                    Marshal.FreeHGlobal(pPlateJpeg);
                if (pLicensePlate != IntPtr.Zero)
                    Marshal.FreeHGlobal(pLicensePlate);
            }
            return 0;
        }

        /// <summary>
        /// 火眼摄像机搜索
        /// </summary>
        /// <param name="pStrDevName"></param>
        /// <param name="pStrIPAddr"></param>
        /// <param name="usPort1"></param>
        /// <param name="usPort2"></param>
        /// <param name="SL"></param>
        /// <param name="SH"></param>
        /// <param name="pUserData"></param>
        private void HuoYanFindDevice(string pStrDevName, string pStrIPAddr, ushort usPort1, ushort usPort2, uint SL,
            uint SH, IntPtr pUserData)
        {
            try
            {
                SearchCameraParam param = new SearchCameraParam()
                {
                    CameraIp = pStrIPAddr,
                    CameraPort = usPort1,
                    CameraType = CameraTypes.HuoYan
                };

                FindDeviceShow(param);
            }
            catch (Exception ex)
            {
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show(ex.Message, @"提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 火眼车牌识别结果回调函数
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="pUserData"></param>
        /// <param name="pResult"></param>
        /// <param name="uNumPlates"></param>
        /// <param name="eResultType"></param>
        /// <param name="pImgFull"></param>
        /// <param name="pImgPlateClip"></param>
        /// <returns></returns>
        private int HuoYanPlateInfo(int handle, IntPtr pUserData, IntPtr pResult, uint uNumPlates,
            HuoYanClientSdk.VZ_LPRC_RESULT_TYPE eResultType, IntPtr pImgFull, IntPtr pImgPlateClip)
        {
            try
            {
                //获取车牌识别结果信息
                HuoYanClientSdk.TH_PlateResult plateresult;
                string input, strLicensePlate;
                if (eResultType != HuoYanClientSdk.VZ_LPRC_RESULT_TYPE.VZ_LPRC_RESULT_REALTIME)
                {
                    plateresult =
                        (HuoYanClientSdk.TH_PlateResult)
                        Marshal.PtrToStructure(pResult, typeof(HuoYanClientSdk.TH_PlateResult));
                    input = new string(plateresult.license);
                    strLicensePlate = input.Replace("\0", "");
                    int licensePlateType = 0;
                    switch (plateresult.nType)
                    {
                        case HuoYanClientSdk.LT_YELLOW:
                        case HuoYanClientSdk.LT_YELLOW2:
                            licensePlateType = 2;
                            break;
                    }
                    string strFullPath = string.Empty;
                    string strPlatePath = string.Empty;
                    DateTime now = GetImgSavePath(strLicensePlate, ref strFullPath, ref strPlatePath);
                    if (!File.Exists(strFullPath))
                        HuoYanClientSdk.VzLPRClient_ImageSaveToJpeg(pImgFull, strFullPath, 100);
                    if (!File.Exists(strPlatePath))
                        HuoYanClientSdk.VzLPRClient_ImageSaveToJpeg(pImgPlateClip, strPlatePath, 100);
                    ConnectionCameraParam cameraparam = DistinguishCamera(handle, CameraTypes.HuoYan);
                    if (cameraparam != null)
                    {
                        RecognitionParam param = new RecognitionParam()
                        {
                            DeviceId = cameraparam.DeviceId,
                            Direction = cameraparam.Direction,
                            EnterExitTime = now,
                            LicensePlate = strLicensePlate,
                            FullImgPath = strFullPath,
                            LicensePlatImgPath = strPlatePath,
                            LicensePlateType = licensePlateType,
                            LicensePlateColor = plateresult.nColor > 0 ? plateresult.nColor - 1 : plateresult.nColor
                        };
                        AddEnterRecord(param);
                    }
                }
            }
            catch (Exception ex)
            {
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show(ex.Message, @"提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return 0;
        }

        /// <summary>
        /// 火眼RS485数据回调
        /// </summary>
        /// <param name="nSerialHandle"></param>
        /// <param name="pRecvData"></param>
        /// <param name="uRecvSize"></param>
        /// <param name="pUserData"></param>
        /// <returns></returns>
        private int HuoYanSerialDataReceived(int nSerialHandle, IntPtr pRecvData, int uRecvSize, IntPtr pUserData)
        {
            try
            {
                byte[] by = new byte[uRecvSize];
                Marshal.Copy(pRecvData, by, 0, uRecvSize);
                string icNumber = Encoding.Default.GetString(by, 6, 8);
                DateTime now = DateTime.Now;
                string strFullPath = string.Empty, strPlatePath = string.Empty;
                GetImgSavePath(icNumber, now, ref strFullPath, ref strPlatePath);
                ConnectionCameraParam cameraparam = DistinguishCamera(nSerialHandle, CameraTypes.HuoYan);
                if (cameraparam != null)
                {
                    HuoYanClientSdk.VzLPRClient_GetSnapShootToJpeg2(cameraparam.ShowHwnd, strFullPath, 100);
                    RecognitionParam param = new RecognitionParam()
                    {
                        DeviceId = cameraparam.DeviceId,
                        Direction = cameraparam.Direction,
                        EnterExitTime = now,
                        LicensePlate = icNumber,
                        FullImgPath = strFullPath,
                        LicensePlatImgPath = strPlatePath
                    };
                    AddEnterRecord(param);
                }
            }
            catch (Exception ex)
            {
                CustomExceptionHandler.GetExceptionMessage(ex);
            }
            return 0;
        }

        /// <summary>
        /// 芊熠摄像机搜索
        /// </summary>
        /// <param name="ptFindDevice"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        private int QianYiFindDevice(ref QianYiClientSdk.T_RcvMsg ptFindDevice, IntPtr obj)
        {
            try
            {
                SearchCameraParam param = new SearchCameraParam()
                {
                    CameraIp = QianYiClientSdk.IntToIp(QianYiClientSdk.Reverse_uint(ptFindDevice.tNetSetup.uiIPAddress)),
                    CameraPort = 30000,
                    CameraType = CameraTypes.QianYi
                };
                FindDeviceShow(param);
            }
            catch (Exception ex)
            {
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show(ex.Message, @"提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return 0;
        }

        /// <summary>
        /// 芊熠车牌识别结果回调函数
        /// </summary>
        /// <param name="tHandle"></param>
        /// <param name="uiImageId"></param>
        /// <param name="tImageInfo"></param>
        /// <param name="tPicInfo"></param>
        /// <returns></returns>
        private int QianYiPlateInfo(int tHandle, uint uiImageId, ref QianYiClientSdk.T_ImageUserInfo tImageInfo, ref QianYiClientSdk.T_PicInfo tPicInfo)
        {
            try
            {
                //车辆图像
                if (tImageInfo.ucViolateCode != 0) return 0;
                string input = Encoding.Default.GetString(tImageInfo.szLprResult);
                string strLicensePlate = input.Replace("\0", "");
                int cartype = 0; //小型车
                switch (tImageInfo.ucVehicleSize)//车型
                {
                    case 1: //大型车
                        cartype = 2;
                        break;
                    case 2: //中型车
                        cartype = 1;
                        break;
                }
                string strFullPath = string.Empty;
                string strPlatePath = string.Empty;
                DateTime now = GetImgSavePath(strLicensePlate, ref strFullPath, ref strPlatePath);
                if (!File.Exists(strFullPath))
                {
                    if (tPicInfo.ptPanoramaPicBuff != IntPtr.Zero && tPicInfo.uiPanoramaPicLen != 0)
                    {
                        CameraImgSave(strFullPath, tPicInfo.ptPanoramaPicBuff, (int)tPicInfo.uiPanoramaPicLen);
                    }
                }

                if (!File.Exists(strPlatePath))
                {
                    if (tPicInfo.ptVehiclePicBuff != IntPtr.Zero && tPicInfo.uiVehiclePicLen != 0)
                    {
                        CameraImgSave(strPlatePath, tPicInfo.ptVehiclePicBuff, (int)tPicInfo.uiVehiclePicLen);
                    }
                }
                ConnectionCameraParam cameraparam = DistinguishCamera(tHandle, CameraTypes.QianYi);
                if (cameraparam != null)
                {
                    RecognitionParam param = new RecognitionParam()
                    {
                        DeviceId = cameraparam.DeviceId,
                        Direction = cameraparam.Direction,
                        EnterExitTime = now,
                        FullImgPath = strFullPath,
                        LicensePlatImgPath = strPlatePath,
                        LicensePlate = strLicensePlate,
                        LicensePlateType = cartype,
                        LicensePlateColor = tImageInfo.ucPlateColor
                    };
                    AddEnterRecord(param);
                }
            }
            catch (Exception ex)
            {
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show(ex.Message, @"提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return 0;
        }

        /// <summary>
        /// 芊熠上报的消息
        /// </summary>
        /// <param name="tHandle"></param>
        /// <param name="ucType"></param>
        /// <param name="ptMessage"></param>
        /// <param name="pUserData"></param>
        /// <returns></returns>
        private int QianYiRegReportMessage(int tHandle, QianYiClientSdk.E_ReportMess ucType, IntPtr ptMessage, IntPtr pUserData)
        {
            if (ucType == QianYiClientSdk.E_ReportMess.REPORT_MESS_RS485_IN_DATA)
            {
                try
                {
                    QianYiClientSdk.T_RS485Data rs485data = (QianYiClientSdk.T_RS485Data)Marshal.PtrToStructure(ptMessage, typeof(QianYiClientSdk.T_RS485Data));
                    string icNumber = Encoding.Default.GetString(rs485data.data, 6, 8);
                    DateTime now = DateTime.Now;
                    string strFullPath = string.Empty, strPlatePath = string.Empty;
                    GetImgSavePath(icNumber, now, ref strFullPath, ref strPlatePath);
                    ConnectionCameraParam cameraparam = DistinguishCamera(tHandle, CameraTypes.QianYi);
                    if (cameraparam != null)
                    {
                        QianYiClientSdk.Net_SaveJpgFile(tHandle, strFullPath);
                        RecognitionParam param = new RecognitionParam()
                        {
                            DeviceId = cameraparam.DeviceId,
                            Direction = cameraparam.Direction,
                            EnterExitTime = now,
                            LicensePlate = icNumber,
                            FullImgPath = strFullPath,
                            LicensePlatImgPath = strPlatePath
                        };
                        AddEnterRecord(param);
                    }
                }
                catch (Exception ex)
                {
                    CustomExceptionHandler.GetExceptionMessage(ex);
                }
            }
            return 0;
        }

        /// <summary>
        /// 添加入场记录
        /// </summary>
        /// <param name="param"></param>
        private void AddEnterRecord(RecognitionParam param)
        {
            this.BeginInvoke(new EventHandler(delegate
            {
                try
                {
                    if (param.Direction == CameraDirection.Enter)
                    {
                        if (GetIdentifyLimit(_mEnterParam, param)) return;
                        _mEnterParam = param;

                        CBEnteranceRecrd mEnterRecord = Dbhelper.Db.FirstDefault<CBEnteranceRecrd>($" and PlateNumber='{param.LicensePlate}' ");
                        if (mEnterRecord == null)
                        {
                            mEnterRecord = new CBEnteranceRecrd()
                            {
                                EntranceTime = param.EnterExitTime,
                                PlateNumber = param.LicensePlate
                            };
                            if (Dal_SysSettings.SystemSettings.RemoteConnection != 0)//不是本地数据库
                            {
                                //加载全图
                                mEnterRecord.ImgData = ImgHelper.ImgZoomCompression(param.FullImgPath);
                                //加载车牌图片
                                mEnterRecord.PlateData = FileHelper.GetFileBinary(param.LicensePlatImgPath);
                            }
                            else
                            {
                                mEnterRecord.ImgData = new byte[0];
                                mEnterRecord.PlateData = new byte[0];
                            }

                            mEnterRecord.ID = Dbhelper.Db.Insert<CBEnteranceRecrd>(mEnterRecord);
                        }
                        else
                        {
                            mEnterRecord.EntranceTime = param.EnterExitTime;
                            Dbhelper.Db.Update<CBEnteranceRecrd>(mEnterRecord);
                        }
                    }
                    else
                    {
                        _mExitParam = param;
                    }
                }
                catch (Exception ex)
                {
                    CustomExceptionHandler.GetExceptionMessage(ex);
                    MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }));
        }

        /// <summary>
        /// 限制车牌识别的多少秒内不能重复识别
        /// </summary>
        private bool GetIdentifyLimit(RecognitionParam oldparam, RecognitionParam newparam)
        {
            lock (_lockTime)
            {
                if (oldparam != null && oldparam.LicensePlate == newparam.LicensePlate)
                {
                    TimeSpan ts = newparam.EnterExitTime - oldparam.EnterExitTime;
                    if (ts.TotalSeconds <= DELAYTIME)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 区分摄像机
        /// </summary>
        /// <param name="strip"></param>
        /// <returns></returns>
        private ConnectionCameraParam DistinguishCamera(string strip)
        {
            foreach (ConnectionCameraParam item in _mConnCamera)
            {
                if (item.IsConnection && item.CameraIp == strip && item.CameraType == CameraTypes.AnShiBao)
                {
                    return item;
                }
            }
            return null;
        }

        /// <summary>
        /// 区分摄像机
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="cameratype"></param>
        /// <returns></returns>
        private ConnectionCameraParam DistinguishCamera(int hwnd, CameraTypes cameratype)
        {
            foreach (ConnectionCameraParam item in _mConnCamera)
            {
                if (!item.IsConnection) continue;
                if (cameratype == CameraTypes.HuoYan)
                {
                    if (item.SerialHwnd == hwnd || item.OpenHwnd == hwnd)
                    {
                        return item;
                    }
                }
                else if (item.OpenHwnd == hwnd)
                {
                    return item;
                }
            }
            return null;
        }

        /// <summary>
        /// 图片保存
        /// </summary>
        /// <param name="path"></param>
        /// <param name="picbuff"></param>
        /// <param name="len"></param>
        private void CameraImgSave(string path, IntPtr picbuff, int len)
        {
            byte[] by = new byte[len];
            try
            {
                Marshal.Copy(picbuff, by, 0, len);
                using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite, FileShare.None))
                {
                    fs.Write(by, 0, len);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        /// <summary>
        /// 获取图片保存的位置
        /// </summary>
        /// <param name="strlicense"></param>
        /// <param name="fullpath"></param>
        /// <param name="platepath"></param>
        /// <returns></returns>
        private DateTime GetImgSavePath(string strlicense, ref string fullpath, ref string platepath)
        {
            DateTime now = DateTime.Now;
            GetImgSavePath(strlicense, now, ref fullpath, ref platepath);
            return now;
        }

        /// <summary>
        /// 获取图片保存的位置
        /// </summary>
        /// <param name="strlicense"></param>
        /// <param name="time"></param>
        /// <param name="fullpath"></param>
        /// <param name="platepath"></param>
        private void GetImgSavePath(string strlicense, DateTime time, ref string fullpath, ref string platepath)
        {
            string path = string.Format("{0}\\Imgs", Environment.CurrentDirectory);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path = string.Format("{0}\\{1:yyyyMMdd}", path, time);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path = string.Format("{0}\\{1:yyyyMMddHHmmss}_{2}", path, time, strlicense);
            fullpath = path + ".jpg";
            platepath = path + "_plate.jpg";
        }

        /// <summary>
        /// 显示搜索到的摄像机
        /// </summary>
        /// <param name="param"></param>
        private void FindDeviceShow(SearchCameraParam param)
        {
            this.BeginInvoke(new EventHandler(delegate
            {
                try
                {
                    if (!ExistsCamera(param.CameraIp, param.CameraType))
                    {
                        _mSearchCamera.Add(param);

                        if (p_SetBox != null)
                        {
                            btn_SearchCamera.Text = _mSearchCamera.Count + "    搜 索 摄 像 机";
                        }

                        OpenSaveCamera(param);
                    }
                }
                catch (Exception ex)
                {
                    CustomExceptionHandler.GetExceptionMessage(ex);
                    MessageBox.Show(ex.Message, @"提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }));
        }

        /// <summary>
        /// 打开保存的摄像机
        /// </summary>
        /// <param name="param"></param>
        private void OpenSaveCamera(SearchCameraParam param)
        {
            foreach (SaveCameraParam item in _mSaveCamera)
            {
                if (item.CameraIp != param.CameraIp) continue;
                OpenCamera(param, item);
                break;
            }
        }

        /// <summary>
        /// 打开搜索的摄像机
        /// </summary>
        /// <param name="param"></param>
        private void OpenSearchCamera(SaveCameraParam param)
        {
            foreach (SearchCameraParam item in _mSearchCamera)
            {
                if (item.CameraIp != param.CameraIp) continue;
                OpenCamera(item, param);
                break;
            }
        }

        /// <summary>
        /// 打开摄像机
        /// </summary>
        /// <param name="mSearchCameraParam"></param>
        /// <param name="mSaveCameraParam"></param>
        private void OpenCamera(SearchCameraParam mSearchCameraParam, SaveCameraParam mSaveCameraParam)
        {
            ConnectionCameraParam mConnParam = new ConnectionCameraParam()
            {
                CameraType = mSearchCameraParam.CameraType,
                CameraIp = mSearchCameraParam.CameraIp,
                CameraPort = mSearchCameraParam.CameraPort,
                Direction = (CameraDirection)mSaveCameraParam.Direction,
                DeviceId = mSaveCameraParam.DeviceId
            };

            OpenCamera(null, mConnParam);
        }

        /// <summary>
        /// 打开摄像机
        /// </summary>
        /// <param name="pb"></param>
        /// <param name="param"></param>
        private void OpenCamera(PictureBox pb, ConnectionCameraParam param)
        {
            if (pb == null)
            {
                pb = CreateCameraShowControl(param.CameraIp);
                switch (param.Direction)
                {
                    case CameraDirection.Enter:
                        p_EnterBox.Controls.Add(pb);
                        break;

                    case CameraDirection.Exit:
                        p_ExitBox.Controls.Add(pb);
                        break;
                }
            }

            pb.Tag = param;
            _mConnCamera.Add(param);

            int iRet;
            switch (param.CameraType)
            {
                case CameraTypes.AnShiBao://安视宝
                    iRet = AnShiBaoClientSdk.IPCSDK_Start_Stream(Handle, pb.Handle, param.CameraIp, 0);
                    if (iRet == 0)
                    {
                        param.IsConnection = true;
                    }
                    else
                    {
                        CreateReconnecButton(pb, param);
                    }
                    break;

                case CameraTypes.HuoYan://火眼
                    int m_hLPRClinet = HuoYanClientSdk.VzLPRClient_Open(param.CameraIp, (ushort)param.CameraPort, "admin", "admin");
                    if (m_hLPRClinet == 0)
                    {
                        CreateReconnecButton(pb, param);
                    }
                    else
                    {
                        param.OpenHwnd = m_hLPRClinet;
                        int m_hPlay = HuoYanClientSdk.VzLPRClient_StartRealPlay(m_hLPRClinet, pb.Handle);
                        if (m_hPlay > -1)
                        {
                            param.ShowHwnd = m_hPlay;
                            HuoYanClientSdk.VzLPRClient_SetPlateInfoCallBack(m_hLPRClinet, HuoYanPlateInfoCallBack, IntPtr.Zero, 1);
                            param.SerialHwnd = HuoYanClientSdk.VzLPRClient_SerialStart(m_hLPRClinet, 0, HuoYanSerialDataReceivedCallBack, IntPtr.Zero);
                            param.IsConnection = true;
                        }
                        else
                        {
                            HuoYanClientSdk.VzLPRClient_Close(m_hLPRClinet);
                            CreateReconnecButton(pb, param);
                        }
                    }
                    break;

                case CameraTypes.QianYi://芊熠
                    int nCamId = QianYiClientSdk.Net_AddCamera(param.CameraIp);
                    if (nCamId == -1)
                    {
                        CreateReconnecButton(pb, param);
                    }
                    else
                    {
                        param.OpenHwnd = nCamId;
                        iRet = QianYiClientSdk.Net_ConnCamera(nCamId, 0, 10);
                        if (iRet != 0)
                        {
                            QianYiClientSdk.Net_DelCamera(nCamId);
                            CreateReconnecButton(pb, param);
                        }
                        else
                        {
                            iRet = QianYiClientSdk.Net_StartVideo(nCamId, 0, pb.Handle);
                            if (iRet != 0)
                            {
                                QianYiClientSdk.Net_DisConnCamera(nCamId);
                                QianYiClientSdk.Net_DelCamera(nCamId);
                                CreateReconnecButton(pb, param);
                            }
                            else
                            {
                                QianYiClientSdk.Net_RegReportMessEx(nCamId, QianYiRegReportMessageCallBack, IntPtr.Zero);
                                param.IsConnection = true;
                            }
                        }
                    }
                    break;
            }
            if (p_SetBox != null)
            {
                ShowCameraList();
            }
        }

        /// <summary>
        /// 关闭摄像机
        /// </summary>
        /// <param name="ip"></param>
        private void CloseCamera(string ip)
        {
            Control[] findControls = p_LeftBoxTop.Controls.Find("pb_" + ip, true);
            foreach (Control item in findControls)
            {
                if (item is PictureBox)
                {
                    ConnectionCameraParam param = item.Tag as ConnectionCameraParam;
                    if (param == null) continue;
                    CloseCamera(param);
                    item.Parent.Controls.Remove(item);
                    item.Dispose();
                    break;
                }
            }
        }

        /// <summary>
        /// 关闭摄像机
        /// </summary>
        /// <param name="param"></param>
        private void CloseCamera(ConnectionCameraParam param)
        {
            switch (param.CameraType)
            {
                case CameraTypes.AnShiBao:
                    AnShiBaoClientSdk.IPCSDK_Stop_Stream(param.CameraIp);
                    break;

                case CameraTypes.HuoYan:
                    int iRet = HuoYanClientSdk.VzLPRClient_StopRealPlay(param.ShowHwnd);
                    if (iRet == 0)
                    {
                        HuoYanClientSdk.VzLPRClient_SetPlateInfoCallBack(param.OpenHwnd, null, IntPtr.Zero, 1);
                        HuoYanClientSdk.VzLPRClient_SerialStop(param.SerialHwnd);
                        HuoYanClientSdk.VzLPRClient_Close(param.OpenHwnd);
                    }
                    break;

                case CameraTypes.QianYi:
                    QianYiClientSdk.Net_StopVideo(param.OpenHwnd);
                    QianYiClientSdk.Net_DisConnCamera(param.OpenHwnd);
                    QianYiClientSdk.Net_DelCamera(param.OpenHwnd);
                    break;
            }
        }

        /// <summary>
        /// 创建显示摄像机画面的控件
        /// </summary>
        /// <param name="strIp"></param>
        /// <returns></returns>
        private PictureBox CreateCameraShowControl(string strIp)
        {
            PictureBox pb = new PictureBox()
            {
                Name = "pb_" + strIp,
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackgroundImageLayout = ImageLayout.Stretch,
            };
            pb.Move += Bb_Move;
            pb.Resize += Pb_Resize;
            return pb;
        }

        /// <summary>
        /// 显示摄像机画面控件移动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bb_Move(object sender, EventArgs e)
        {
            if (sender is PictureBox)
            {
                AdjustReconnectionButtonLocation(sender as PictureBox);
            }
        }

        /// <summary>
        /// 显示摄像机画面控件大小变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pb_Resize(object sender, EventArgs e)
        {
            if (sender is PictureBox)
            {
                AdjustReconnectionButtonLocation(sender as PictureBox);
            }
        }

        /// <summary>
        /// 调整重新连接摄像机按钮的位置
        /// </summary>
        /// <param name="pb"></param>
        private void AdjustReconnectionButtonLocation(PictureBox pb)
        {
            if (!(pb.Tag is ConnectionCameraParam)) return;
            ConnectionCameraParam param = (ConnectionCameraParam)pb.Tag;
            if (param != null && !param.IsConnection)
            {
                Control[] findcontrols = p_LeftBoxTop.Controls.Find("btn_ReconnectCamera" + param.CameraIp, true);
                foreach (Control item in findcontrols)
                {
                    if (item.Parent != pb.Parent)
                    {
                        item.Parent.Controls.Remove(item);
                        pb.Parent.Controls.Add(item);
                        item.BringToFront();
                    }
                    item.Location = new Point(pb.Left + (pb.Width - item.Width) / 2, pb.Top + (pb.Height - item.Height) / 2);
                }
            }
        }

        /// <summary>
        /// 创建重新连接摄像机按钮
        /// </summary>
        /// <param name="pb"></param>
        /// <param name="param"></param>
        private void CreateReconnecButton(PictureBox pb, ConnectionCameraParam param)
        {
            Control[] findControl = p_LeftBoxTop.Controls.Find("btn_ReconnectCamera" + param.CameraIp, true);
            if (findControl.Length == 0)
            {
                Button btn_ReconnectCamera = new Button()
                {
                    Name = "btn_ReconnectCamera" + param.CameraIp,
                    Text = @"重新连接",
                    Size = new Size(100, 30),
                    Font = new Font(new FontFamily("微软雅黑"), 12.5F, FontStyle.Regular),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = COLOR_BACKGROUND,
                    ForeColor = Color.White
                };
                btn_ReconnectCamera.FlatAppearance.BorderSize = 0;
                btn_ReconnectCamera.FlatAppearance.MouseOverBackColor = COLOR_MOUSEENTER;
                btn_ReconnectCamera.FlatAppearance.MouseDownBackColor = COLOR_MOUSEDOWN;
                btn_ReconnectCamera.Location = new Point(pb.Left + (pb.Width - btn_ReconnectCamera.Width) / 2, pb.Top + (pb.Height - btn_ReconnectCamera.Height) / 2);
                btn_ReconnectCamera.Click += Btn_ReconnectCamera_Click;
                btn_ReconnectCamera.Tag = pb;
                pb.Parent.Controls.Add(btn_ReconnectCamera);
                btn_ReconnectCamera.BringToFront();
            }
        }

        /// <summary>
        /// 重新连接摄像机按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_ReconnectCamera_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && btn.Tag == null) return;
            PictureBox pb = btn.Tag as PictureBox;
            ConnectionCameraParam param = pb.Tag as ConnectionCameraParam;
            if (param == null) return;
            OpenCamera(pb, param);
            if (param.IsConnection)
            {
                btn.Parent.Controls.Remove(btn);
            }
        }

        /// <summary>
        /// 判断摄像机是否已经搜索到
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="cameratype"></param>
        /// <returns></returns>
        private bool ExistsCamera(string ip, CameraTypes cameratype)
        {
            foreach (SearchCameraParam item in _mSearchCamera)
            {
                if (item.CameraIp == ip && item.CameraType == cameratype)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 初始化摄像机
        /// </summary>
        private void InitCamera()
        {
            int iRet;
            if (!_initAnShiBao)
            {
                iRet = AnShiBaoClientSdk.IPCSDK_Init(8190);
                if (iRet == 0)
                {
                    AnShiBaoClientSdk.IPCSDK_Register_Callback(AnShiBaoPlateInfoCallBack);
                    _initAnShiBao = true;
                }
            }

            if (!_initHuoYan)
            {
                iRet = HuoYanClientSdk.VzLPRClient_Setup();
                _initHuoYan = true;
            }

            if (!_initQianYi)
            {
                iRet = QianYiClientSdk.Net_Init();
                if (iRet == 0)
                {
                    QianYiClientSdk.Net_RegImageRecv(QianYiPlateInfoCallBack);
                    _initQianYi = true;
                }
            }
        }

        /// <summary>
        /// 窗体关闭后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tab4_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (_initAnShiBao)
                {
                    AnShiBaoClientSdk.IPCSDK_UnInit();
                    _initAnShiBao = false;
                }
                if (_initHuoYan)
                {
                    HuoYanClientSdk.VzLPRClient_Cleanup();
                    _initHuoYan = false;
                }
                if (_initQianYi)
                {
                    QianYiClientSdk.Net_UNinit();
                    _initQianYi = false;
                }
            }
            catch (Exception ex)
            {
                CustomExceptionHandler.GetExceptionMessage(ex);
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _uniqueInstance = null;
            }
        }

        private static Tab4_Form _uniqueInstance;

        public static Tab4_Form GetInstance
        {
            get { return _uniqueInstance ?? (_uniqueInstance = new Tab4_Form()); }
        }

        /// <summary>
        /// 有线端口是否连接
        /// </summary>
        public bool IsConnection
        {
            get { return _isConnection; }
            set
            {
                _isConnection = value;
                this.Invoke(new EventHandler(delegate
                {
                    if (p_SetBox != null)
                    {
                        btn_CommPort.Text = _isConnection ? @"关    闭" : @"打    开";
                    }
                }));
            }
        }
    }

    public class ConnectionCameraParam
    {
        public string CameraIp { get; set; }
        public uint CameraPort { get; set; }
        public CameraTypes CameraType { get; set; }
        public int DeviceId { get; set; }
        public CameraDirection Direction { get; set; }
        public bool IsConnection { get; set; }
        public int OpenHwnd { get; set; }
        public int ShowHwnd { get; set; }
        public int SerialHwnd { get; set; }
    }

    public class RecognitionParam
    {
        public int LicensePlateType { get; set; }
        public int LicensePlateColor { get; set; }
        public int DeviceId { get; set; }
        public DateTime EnterExitTime { get; set; }
        public string LicensePlate { get; set; }
        public CameraDirection Direction { get; set; }
        public string FullImgPath { get; set; }
        public string LicensePlatImgPath { get; set; }
    }

    public class SaveCameraParam
    {
        public string CameraIp { get; set; }
        public int DeviceId { get; set; }
        public int Direction { get; set; }
    }

    public class SearchCameraParam
    {
        public string CameraIp { get; set; }
        public uint CameraPort { get; set; }
        public CameraTypes CameraType { get; set; }
    }
}
