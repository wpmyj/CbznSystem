using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Bll;
using System.Diagnostics;

namespace CbznSystem
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            //全局异常数据捕获
            CustomExceptionHandler ce = new CustomExceptionHandler();

            Login_Form login = new Login_Form();
            if (login.ShowDialog() == DialogResult.OK)
            {
                if (GetApplicationStart()) return;
                Application.Run(new Main_Form());
            }
        }

        private static bool GetApplicationStart()
        {
            //获取欲启动进程名
            string strProcessName = Process.GetCurrentProcess().ProcessName;
            ////获取版本号 
            //CommonData.VersionNumber = Application.ProductVersion; 
            //检查进程是否已经启动，已经启动则显示报错信息退出程序。 
            if (Process.GetProcessesByName(strProcessName).Length > 1)
            {
                //MessageBox.Show(@"程序已经运行！", @"消息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }
            return false;
        }
    }
}
