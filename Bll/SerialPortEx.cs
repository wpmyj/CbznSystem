using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic.Devices;
using System.Threading;

namespace Bll
{
    public class SerialPortEx
    {
        private Thread tSearchPortCom;

        private bool IsSearch;

        public void Start()
        {
            if (tSearchPortCom == null)
            {
                IsSearch = true;
                tSearchPortCom = new Thread(SearchPortCom);
                tSearchPortCom.IsBackground = true;
                tSearchPortCom.Start();
            }
        }

        public void Stop()
        {
            if (tSearchPortCom == null) return;
            IsSearch = false;
        }

        public delegate void SerialPortCountEventHandler(List<string> portnames);
        public event SerialPortCountEventHandler SerialPortCountChange;

        private void OnSerialPortCountChange(List<string> portnames)
        {
            SerialPortCountChange?.Invoke(portnames);
        }


        private int _PortCount;

        public int PortCount
        {
            get { return _PortCount; }
        }

        private List<string> _SerialPortNames;

        public List<string> SerialPortNames
        {
            get { return _SerialPortNames; }
        }


        private void SearchPortCom()
        {
            Computer pc = new Computer();
            do
            {
                if (_PortCount != pc.Ports.SerialPortNames.Count)
                {
                    _PortCount = pc.Ports.SerialPortNames.Count;
                    _SerialPortNames = new List<string>();
                    _SerialPortNames.AddRange(pc.Ports.SerialPortNames);
                    try
                    {
                        if (IsOpen && !_SerialPortNames.Contains(PortName))
                        {
                            Close();
                        }
                    }
                    catch
                    {

                    }
                    finally
                    {
                        OnSerialPortCountChange(_SerialPortNames);
                    }
                }
                Thread.Sleep(100);
            } while (IsSearch);
            tSearchPortCom = null;
        }

        public delegate void PortChangeEventHandler(bool flag);

        public event PortChangeEventHandler PortChange;

        private void OnPortChange(bool flag)
        {
            PortChange?.Invoke(flag);
        }


        private int PortIndex;

        private int _StopBit;

        public int StopBit
        {
            get { return _StopBit; }
            set { _StopBit = value; }
        }

        private int _DataBit;

        public int DataBit
        {
            get { return _DataBit; }
            set { _DataBit = value; }
        }

        private int _Parity;

        public int Parity
        {
            get { return _Parity; }
            set { _Parity = value; }
        }

        private int _BaudRate;

        public int BaudRate
        {
            get { return _BaudRate; }
            set { _BaudRate = value; }
        }

        private string _PortName;

        public string PortName
        {
            get { return _PortName; }
            set
            {
                _PortName = value;
                if (string.IsNullOrEmpty(_PortName))
                {
                    PortIndex = -1;
                }
                else
                {
                    PortIndex = Convert.ToInt32(_PortName.Replace("COM", ""));
                }
            }
        }

        private bool _IsOpen;

        public bool IsOpen
        {
            get { return _IsOpen; }
            private set
            {
                if (_IsOpen != value)
                {
                    _IsOpen = value;
                    OnPortChange(_IsOpen);
                }
            }
        }


        public int GetIqueue
        {
            get
            {
                return WinApi.sio_iqueue(PortIndex);
            }
        }

        private event WinApi.DataReceivedEventHandler _DataReceived;
        public event WinApi.DataReceivedEventHandler DataReceived
        {
            add
            {
                _DataReceived += value;
                if (IsOpen)
                {
                    SetDataReceived();
                }
            }
            remove
            {
                _DataReceived -= value;
                if (IsOpen)
                {
                    SetDataReceived();
                }
            }
        }

        public void Open()
        {
            try
            {
                GetErrorCode(WinApi.sio_open(PortIndex));
                GetErrorCode(WinApi.sio_ioctl(PortIndex, _BaudRate, _DataBit | _StopBit | _Parity));
                SetDataReceived();
                IsOpen = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SetDataReceived()
        {
            GetErrorCode(WinApi.sio_cnt_irq(PortIndex, _DataReceived, 1));
        }

        public void Close()
        {
            try
            {
                IsOpen = false;
                GetErrorCode(WinApi.sio_close(PortIndex));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Write(string value)
        {
            try
            {
                byte[] by = new byte[value.Length / 2];
                for (int i = 0, j = 0; i < value.Length; i += 2, j++)
                {
                    by[j] = Convert.ToByte(value.Substring(i, 2));
                }
                Write(by);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Write(byte[] data)
        {
            try
            {
                GetErrorCode(WinApi.sio_write(PortIndex, data, data.Length));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public byte[] Read(int count)
        {
            try
            {
                byte[] by = null;
                if (count <= 0) return null;
                by = new byte[count];
                GetErrorCode(WinApi.sio_read(PortIndex, by, by.Length));
                return by;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ClearWrite()
        {
            try
            {
                GetErrorCode(WinApi.sio_flush(PortIndex, 0));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ClearRead()
        {
            try
            {
                GetErrorCode(WinApi.sio_flush(PortIndex, 1));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Flush()
        {
            try
            {
                GetErrorCode(WinApi.sio_flush(PortIndex, 2));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void GetErrorCode(int value)
        {
            switch ((WinApi.ErrorCode)value)
            {
                case WinApi.ErrorCode.SIO_OK:
                    break;
                case WinApi.ErrorCode.SIO_BADPORT:
                    throw new ArgumentException("没有此端口或端口未打开");
                case WinApi.ErrorCode.SIO_OUTCONTROL:
                    throw new ArgumentException("无法控制此板");
                case WinApi.ErrorCode.SIO_NODATA:
                    throw new ArgumentException("没有数据代读取或没有缓冲区供写");
                case WinApi.ErrorCode.SIO_OPENFAIL:
                    throw new ArgumentException("没有此端口或端口已打开");
                case WinApi.ErrorCode.SIO_RTS_BY_HW:
                    throw new ArgumentException("因为H/W流量控制而不能设置");
                case WinApi.ErrorCode.SIO_BADPARM:
                    throw new ArgumentException("无效参数");
                case WinApi.ErrorCode.SIO_WIN32FAIL:
                    throw new ArgumentException("调用win32函数失败请调用GetLastError函数以获取错误代码");
                case WinApi.ErrorCode.SIO_BOARDNOTSUPPORT:
                    throw new ArgumentException("此版本不支持这个函数");
                case WinApi.ErrorCode.SIO_FAIL:
                    throw new ArgumentException("PCOMM函数运行结果失败");
                case WinApi.ErrorCode.SIO_ABORT_WRITE:
                    throw new ArgumentException("写入已被锁定，用户已放弃写入");
                case WinApi.ErrorCode.SIO_WRITETIMEOUT:
                    throw new ArgumentException("已发生写入超时");
            }
        }
    }
}
