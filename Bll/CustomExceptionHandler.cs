using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Bll
{
    public class CustomExceptionHandler
    {
        public CustomExceptionHandler()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            Application.ThreadException += Application_ThreadException;

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            GetException(ex);
        }

        private void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            GetException(e.Exception);
        }

        private static void GetException(Exception e)
        {
            try
            {
                GetExceptionMessage(e);
            }
            catch (Exception ex)
            {
                GetExceptionMessage(ex);
            }
            finally
            {
                MessageBox.Show("系统运行时发生未知错误！请重新启动系统", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
        public static void GetExceptionMessage(Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("****************************异常文本****************************");
            sb.AppendLine("【出现时间】：" + DateTime.Now.ToString());
            sb.AppendLine("【异常类型】：" + ex.GetType().Name);
            sb.AppendLine("【异常信息】：" + ex.Message);
            sb.AppendLine("【堆栈调用】：" + ex.StackTrace);
            sb.AppendLine("【异常方法】：" + ex.TargetSite);
            sb.AppendLine("***************************************************************");
            WriteLog(sb.ToString());
        }

        private static void WriteLog(string str)
        {
            string path = Application.StartupPath + @"\ErrorLog";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            using (StreamWriter sw = new StreamWriter(path + @"\Error.txt", true))
            {
                sw.WriteLine(str);
                sw.Close();
            }
        }

    }
}
