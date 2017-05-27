﻿using System;
using System.Collections.Generic;

namespace Bll
{
    public class DataValidation
    {

        private readonly List<byte> IncompleteByList = new List<byte>();
        /// <summary>
        /// 是否有数据头数据尾
        /// </summary>
        public bool IsProtocol { get; set; }
        /// <summary>
        /// 数据头
        /// </summary>
        public int ProtocolHead { get; set; }
        /// <summary>
        /// 数据尾
        /// </summary>
        public int ProtocolEnd { get; set; }
        /// <summary>
        /// 是否校验
        /// </summary>
        public bool IsValidation { get; set; }

        public int ValidationHead { get; set; }

        public int ValidationEnd { get; set; }

        public List<byte[]> Validation(byte[] by)
        {
            List<byte[]> byslist = new List<byte[]>();
            if (IsProtocol)
            {
                if (by[0] == ProtocolHead && by[by.Length - 1] == ProtocolEnd)
                {
                    if (GetValidationResult(by))
                    {
                        byslist.Add(by);
                        if (IncompleteByList.Count > 0)
                            IncompleteByList.Clear();
                    }
                    else
                        byslist = GetGroupData(by);
                }
                else
                {
                    byslist = GetGroupData(by);
                }
            }
            return byslist;
        }

        private List<byte[]> GetGroupData(byte[] by)
        {
            List<byte[]> byslist = new List<byte[]>();
            IncompleteByList.AddRange(by);
            do
            {
                int start = IncompleteByList.IndexOf((byte)ProtocolHead);
                if (start > -1)
                {
                    int end = IncompleteByList.IndexOf((byte)ProtocolEnd);
                    if (end > -1)
                    {
                        if (end > start)
                        {
                            int count = (end - start) + 1;
                            by = new byte[count];
                            IncompleteByList.CopyTo(start, by, 0, count);
                            IncompleteByList.RemoveRange(0, end + 1);
                            if (IsValidation)
                            {
                                if (GetValidationResult(by))
                                    byslist.Add(by);
                            }
                            else
                            {
                                byslist.Add(by);
                            }
                        }
                        else
                        {
                            IncompleteByList.RemoveRange(0, start + 1);
                        }
                    }
                    else
                    {
                        if (start > 0)
                            IncompleteByList.RemoveRange(0, start + 1);
                        break;
                    }
                }
                else
                {
                    IncompleteByList.Clear();
                    break;
                }
            } while (true);
            return byslist;
        }

        private bool GetValidationResult(byte[] by)
        {
            bool result = false;
            ValidationEnd = by.Length - 3;
            int xorvalue = Xor(by, ValidationHead, ValidationEnd);
            if (ContrastValidation(by, xorvalue, ValidationEnd))
                result = true;
            return result;
        }

        private bool ContrastValidation(byte[] by, int contrastvalue, int start)
        {
            int count = 0;
            byte[] contrastdata = HexadecimalConversion.IntToAscii(contrastvalue);
            foreach (byte item in contrastdata)
            {
                if (by[start + count] != item)
                {
                    return false;
                }
                count++;
            }
            return true;
        }

        public static int Xor(byte[] by)
        {
            return Xor(by, 0, by.Length);
        }

        public static int Xor(byte[] by, int index, int count)
        {
            int result = 0;
            for (int i = index; i < count; i++)
            {
                result = result ^ by[i];
            }
            return result;
        }

        public static int Xor(List<byte> bylist)
        {
            return Xor(bylist.ToArray(), 0, bylist.Count);
        }

        public static int Xor(List<byte> bylist, int index, int count)
        {
            return Xor(bylist.ToArray(), index, count);
        }

        public static int Xor(int value1, int value2)
        {
            byte[] by = new byte[2] { (byte)value1, (byte)value2 };
            return Xor(by, 0, by.Length);
        }

        public static int Xor(string str)
        {
            byte[] by = System.Text.Encoding.ASCII.GetBytes(str);
            return Xor(by);
        }
    }
}