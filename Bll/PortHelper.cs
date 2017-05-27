using Dal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Bll
{
    public class PortHelper
    {
        /// <summary>
        /// 无线端口
        /// </summary>
        public static SerialPortEx sp;

        private static DataValidation _dataValidation;

        private static Thread tSearchDevice;

        /// <summary>
        /// 加载无线端口
        /// </summary>
        public static void LoadPort()
        {
            _dataValidation = new DataValidation()
            {
                IsProtocol = true,
                ProtocolHead = 2,
                ProtocolEnd = 3,
                IsValidation = true
            };

            sp = new SerialPortEx()
            {
                BaudRate = WinApi.B19200,
                DataBit = WinApi.BIT_8,
                StopBit = WinApi.STOP_1,
                Parity = WinApi.p_NONE
            };
            sp.DataReceived += SerialPortDataReceived;
            sp.PortChange += SerialPortChange;
            sp.Start();

            SetAutoDevice(true);
        }

        /// <summary>
        /// 当前使用端口的窗体
        /// </summary>
        public static Form CurrentForm { get; set; }

        public delegate void ConnectionChangeHandler(bool flag);
        /// <summary>
        /// 连接变化事件
        /// </summary>
        public static event ConnectionChangeHandler ConnectionChange;

        private static void OnConnectionChange(bool flag)
        {
            ConnectionChange?.Invoke(flag);
        }

        public delegate void SerialPortDataReceivedEventHandler(ParsingParameter param);
        /// <summary>
        /// 数据接收
        /// </summary>
        public static event SerialPortDataReceivedEventHandler DataReceived;

        private static void OnDataReceived(ParsingParameter param)
        {
            DataReceived?.Invoke(param);
        }

        public delegate void SerialPortConnectionEventHandler(string portname);
        /// <summary>
        /// 端口连接
        /// </summary>
        public static event SerialPortConnectionEventHandler SerialPortConnection;

        private static void OnSerialPortConnection(string portname)
        {
            SerialPortConnection?.Invoke(portname);
        }

        private static bool _IsConnection;

        public static bool IsConnection
        {
            get { return _IsConnection; }
            set
            {
                if (_IsConnection != value)
                {
                    _IsConnection = value;
                    OnConnectionChange(_IsConnection);
                }
            }
        }

        public static void SetAutoDevice(bool flag)
        {
            if (flag)
            {
                if (tSearchDevice == null)
                {
                    tSearchDevice = new Thread(SearchDevice);
                    tSearchDevice.IsBackground = true;
                    tSearchDevice.Start();
                }
            }
            else
            {
                if (tSearchDevice != null)
                {
                    tSearchDevice.Abort();
                }
            }
        }

        private static void SearchDevice()
        {
            try
            {
                do
                {
                    if (sp.SerialPortNames != null)
                    {
                        foreach (string item in sp.SerialPortNames)
                        {
                            OnSerialPortConnection(item);
                        }
                    }
                    Thread.Sleep(100);
                } while (true);
            }
            catch (Exception ex)
            {
                CustomExceptionHandler.GetExceptionMessage(ex);
            }
            finally
            {
                tSearchDevice = null;
            }
        }

        public static void SerialPortDataReceived(int port)
        {
            try
            {
                Thread.Sleep(10);
                byte[] by = sp.Read(sp.GetIqueue);
                if (by == null) return;
                List<byte[]> bylist = _dataValidation.Validation(by);
                foreach (byte[] item in bylist)
                {
                    ParsingParameter param = DataParsing.ParsingContent(item);
                    OnDataReceived(param);
                }
            }
            catch (Exception ex)
            {
                CustomExceptionHandler.GetExceptionMessage(ex);
                //MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void SerialPortChange(bool flag)
        {
            if (!flag && _IsConnection)
            {
                IsConnection = false;
            }
        }

        public static void SerialPortWrite(byte[] by)
        {
            if (sp.IsOpen)
            {
                sp.Write(by);
            }
        }
    }
}
