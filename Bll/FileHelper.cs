using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Bll
{
    public class FileHelper
    {
        public static bool CopyFile(string fileaddress, string newfileaddress)
        {
            try
            {
                if (!File.Exists(fileaddress)) return false;
                byte[] by = new byte[1024 * 1024 * 2];
                using (FileStream fsRead = new FileStream(fileaddress, FileMode.Open, FileAccess.Read))
                {
                    using (FileStream fsWrite = new FileStream(newfileaddress, FileMode.Create, FileAccess.Write))
                    {
                        do
                        {
                            int len = fsRead.Read(by, 0, by.Length);
                            if (len <= 0)
                                break;
                            fsWrite.Write(by, 0, len);
                        } while (true);
                        fsWrite.Close();
                        fsWrite.Dispose();
                    }
                    fsRead.Close();
                    fsRead.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }


        /// <summary>
        /// 获取图片流
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static byte[] GetFileBinary(string path)
        {
            byte[] by = null;
            if (File.Exists(path))
            {
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    by = new byte[fs.Length];
                    fs.Read(by, 0, by.Length);
                }
            }
            return by;
        }

    }
}
