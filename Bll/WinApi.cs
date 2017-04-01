using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Bll
{
    public class WinApi
    {
        /// <summary>
        /// 这个函数检索处理顶级窗口的类名和窗口名称匹配指定的字符串。这个函数不搜索子窗口。
        /// </summary>
        /// <param name="lpClassName">指向一个以NULL字符结尾的、用来指定类名的字符串或一个可以确定类名字符串的原子。如果这个参数是一个原子，那么它必须是一个在调用此函数前已经通过GlobalAddAtom函数创建好的全局原子。这个原子（一个16bit的值），必须被放置在lpClassName的低位字节中，lpClassName的高位字节置零。如果该参数为null时，将会寻找任何与lpWindowName参数匹配的窗口。</param>
        /// <param name="lpWindowName">指向一个以NULL字符结尾的、用来指定窗口名（即窗口标题）的字符串。如果此参数为NULL，则匹配所有窗口名。</param>
        /// <returns></returns>
        [DllImport("user32 ")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        /// <summary>
        /// 应用程序可以使用SetParent函数来设置弹出式窗口，层叠窗口或子窗口的父窗口。新的窗口与窗口必须属于同一应用程序。
        /// </summary>
        /// <param name="hWndChild">子窗口句柄。</param>
        /// <param name="hWndNewParent">新的父窗口句柄。如果该参数是NULL，则桌面窗口就成为新的父窗口。在WindowsNT5.0中，如果参数为HWND_MESSAGE,则子窗口成为消息窗口。</param>
        /// <returns></returns>
        [DllImport("user32 ")]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
    }
}
