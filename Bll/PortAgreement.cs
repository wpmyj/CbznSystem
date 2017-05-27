using System;
using System.Collections.Generic;
using System.Text;

namespace Bll
{
    public class PortAgreement
    {

        public static byte[] GetDistanceEncryption(string pwd)
        {
            DealHandler dh = new DealHandler()
            {
                Head = 2,
                End = 3,
                DeviceAddress = 0,
                FunctionAddress = 65,
                Command = 0
            };
            byte[] by = Encoding.ASCII.GetBytes(string.Format("A000010000009887{0}", pwd));
            return dh.Integration(by);
        }

        public static byte[] GetDistanceCardEncryption(string pwd)
        {
            DealHandler dh = new DealHandler()
            {
                Head = 2,
                End = 3,
                DeviceAddress = 0,
                FunctionAddress = 65,
                Command = 0
            };
            byte[] by = Encoding.ASCII.GetBytes(string.Format("0D0000000000010000{0}", pwd));
            return dh.Integration(by);
        }

        public static byte[] GetReadAllCard()
        {
            DealHandler dh = new DealHandler()
            {
                Head = 2,
                End = 3,
                DeviceAddress = 0,
                FunctionAddress = 65,
                Command = 0
            };
            byte[] by = Encoding.ASCII.GetBytes("0A8000000000010003");
            return dh.Integration(by);
        }

        public static byte[] GetReadSomeCard(string cardnumber)
        {
            return GetReadSomeCard(cardnumber, 3);
        }

        public static byte[] GetReadSomeCard(string cardnumber, int len)
        {
            DealHandler dh = new DealHandler()
            {
                Head = 2,
                End = 3,
                DeviceAddress = 0,
                FunctionAddress = 65,
                Command = 0
            };
            byte[] by = Encoding.ASCII.GetBytes(string.Format("1A00{0}000100{1:X2}", cardnumber, len));
            return dh.Integration(by);
        }

        public static byte[] GetDistanceContent(string cardnumber, int start, string data)
        {
            return GetDistanceContent(cardnumber, 0, start, data);
        }

        public static byte[] GetDistanceContent(string cardnumber, int type)
        {
            return GetDistanceContent(cardnumber, type, 0, "00");
        }

        public static byte[] GetDistanceContent(string cardnumber, int type, int start, string data)
        {
            DealHandler dh = new DealHandler()
            {
                Head = 2,
                End = 3,
                DeviceAddress = 0,
                FunctionAddress = 65,
                Command = 0
            };
            byte[] by = Encoding.ASCII.GetBytes(string.Format("1B00{0}{1:X2}01{2:X2}{3:X2}{4}", cardnumber, type, start, data.Length / 2, data));
            return dh.Integration(by);
        }

        public static byte[] GetSearchCard(string cardnumber)
        {
            DealHandler dh = new DealHandler()
            {
                Head = 2,
                End = 3,
                DeviceAddress = 0,
                FunctionAddress = 65,
                Command = 0
            };
            byte[] by = Encoding.ASCII.GetBytes(string.Format("1500{0}00000000", cardnumber));
            return dh.Integration(by);
        }

        public static byte[] GetTemporaryEncryption(string pwd)
        {
            DealHandler dh = new DealHandler()
            {
                Head = 2,
                End = 3,
                DeviceAddress = 0,
                FunctionAddress = 66,
                Command = 221
            };
            byte[] by = Encoding.ASCII.GetBytes("FFFF" + pwd);
            return dh.Integration(by);
        }

        public static byte[] GetTemporaryICEncryption(string pwd)
        {
            DealHandler dh = new DealHandler()
            {
                Head = 2,
                End = 3,
                DeviceAddress = 0,
                FunctionAddress = 66,
                Command = 204
            };
            byte[] by = Encoding.ASCII.GetBytes("FFFF" + pwd);
            return dh.Integration(by);
        }

        public static byte[] GetReadTemporaryIC()
        {
            DealHandler dh = new DealHandler()
            {
                Head = 2,
                End = 3,
                FunctionAddress = 66,
                DeviceAddress = 0,
                Command = 9
            };
            return dh.Integration();
        }

        public static byte[] SetIcCardContent(string content)
        {
            DealHandler dh = new DealHandler()
            {
                Head = 2,
                End = 3,
                FunctionAddress = 66,
                DeviceAddress = 0,
                Command = 2
            };
            return dh.Integration(Encoding.Default.GetBytes(content));
        }

        public static byte[] GetOpenModule()
        {
            DealHandler dh = new DealHandler()
            {
                Head = 2,
                End = 3,
                DeviceAddress = 0,
                FunctionAddress = 67,
                Command = 209
            };
            return dh.Integration();
        }

        public static byte[] GetCloseModule()
        {
            DealHandler dh = new DealHandler()
            {
                Head = 2,
                End = 3,
                DeviceAddress = 0,
                FunctionAddress = 67,
                Command = 210
            };
            return dh.Integration();
        }

        public static byte[] GetSetModule(string content)
        {
            DealHandler dh = new DealHandler()
            {
                Head = 2,
                End = 3,
                FunctionAddress = 67,
                DeviceAddress = 0,
                Command = 208
            };
            byte[] by = Encoding.ASCII.GetBytes(content);
            return dh.Integration(by);
        }

        public static byte[] SetModuleNumber(string strnumber)
        {
            DealHandler dh = new DealHandler()
            {
                Head = 2,
                End = 3,
                DeviceAddress = 1,
                FunctionAddress = 50,
                Command = 1
            };
            byte[] by = Encoding.ASCII.GetBytes(string.Format("1234{0}", strnumber.PadLeft(8, '0')));
            return dh.Integration(by);
        }

        public struct OpenTheDoorParam
        {
            public string licensePlateNumber;
            public LicensePlateColors LicensePlateColor;
            public DateTime Time;
            public int Day;
            public int DeviceAddress;
        }

        /// <summary>
        /// 有线端开门播报语言
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static byte[] GetOpenDoor(OpenTheDoorParam param)
        {
            DealHandler dh = new DealHandler()
            {
                Head = 2,
                End = 3,
                DeviceAddress = param.DeviceAddress,
                FunctionAddress = 67,
                Command = 16
            };
            List<byte> bylist = new List<byte>();
            bylist.AddRange(GetLincensePlateToByte(param.licensePlateNumber));
            bylist.Add((byte)(48 + param.LicensePlateColor));
            bylist.AddRange(Encoding.Default.GetBytes(string.Format("{0:yyMMddHHmmss}{1:X2}", param.Time, param.Day)));
            return dh.Integration(bylist.ToArray());
        }

        public struct OpenTheDoorParam2
        {
            public string IcCardNumber;
            public string LicensePlateNumber;
            public LicensePlateColors LicensePlateColor;
            public DateTime Time;
            public int DeviceAddress;
        }

        /// <summary>
        /// 无线端打开播放语音
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static byte[] GetOpenDoor(OpenTheDoorParam2 param)
        {
            DealHandler dh = new DealHandler()
            {
                Head = 2,
                End = 3,
                DeviceAddress = param.DeviceAddress,
                FunctionAddress = 67,
                Command = 17
            };
            List<byte> bylist = new List<byte>();
            bylist.AddRange(Encoding.Default.GetBytes(param.IcCardNumber.PadRight(8, '0')));
            bylist.AddRange(GetLincensePlateToByte(param.LicensePlateNumber));
            bylist.Add((byte)(48 + param.LicensePlateColor));
            bylist.AddRange(Encoding.Default.GetBytes(string.Format("{0:yyMMddHHmmss}", param.Time)));
            return dh.Integration(bylist.ToArray());
        }

        /// <summary>
        /// 开门不播报语言
        /// </summary>
        /// <param name="deviceaddress"></param>
        /// <returns></returns>
        public static byte[] GetOpenDoor(int deviceaddress)
        {
            DealHandler dh = new DealHandler()
            {
                Head = 2,
                End = 3,
                DeviceAddress = deviceaddress,
                Command = 19,
                FunctionAddress = 67
            };
            byte[] by = Encoding.Default.GetBytes("123456");
            return dh.Integration(by);
        }

        public struct VoiceParam
        {
            public string licensePlateNumber;
            public LicensePlateColors LicensePlateColor;
            public int DeviceAddress;
            public int Minute;
            public double Money;
        }

        public enum LicensePlateColors
        {
            Blue = 0,
            Yellow = 1,
            White = 2,
            Black = 3,
            Green = 4
        }

        public static byte[] GetVoice(VoiceParam param)
        {
            DealHandler dh = new DealHandler()
            {
                Head = 2,
                End = 3,
                DeviceAddress = param.DeviceAddress,
                FunctionAddress = 67,
                Command = 18
            };
            List<byte> bylist = new List<byte>();
            bylist.AddRange(GetLincensePlateToByte(param.licensePlateNumber));
            bylist.Add((byte)param.LicensePlateColor);
            bylist.AddRange(Encoding.Default.GetBytes(string.Format("{0:X6}{1:X4}", param.Minute, (int)param.Money)));
            return dh.Integration(bylist.ToArray());
        }

        private static byte[] GetLincensePlateToByte(string licenseplate)
        {
            byte[] by = new byte[9];
            Encoding.Default.GetBytes(licenseplate, 0, licenseplate.Length, by, 0);
            if (licenseplate.Length == 7)
            {
                string charlicenseplate = licenseplate[6].ToString();
                if (CRegex.IsChinese(charlicenseplate))
                {
                    by[7] = (byte)(PlateProvinces.Provinces)Enum.Parse(typeof(PlateProvinces.Provinces), charlicenseplate);
                }
                by[8] = 126;
            }
            //by[9] = 48;
            return by;
        }

        public static byte[] GetClientNumber(int number)
        {
            DealHandler dh = new DealHandler()
            {
                Head = 2,
                End = 3,
                DeviceAddress = 1,
                FunctionAddress = 51,
                Command = 160
            };
            byte[] by = Encoding.Default.GetBytes("123456" + number.ToString().PadLeft(4, '0'));
            return dh.Integration(by);
        }

        public static byte[] GetSearchHost(int number)
        {
            DealHandler dh = new DealHandler()
            {
                Head = 2,
                End = 3,
                FunctionAddress = 49,
                DeviceAddress = number,
                Command = 0
            };
            return dh.Integration();
        }

    }
}
