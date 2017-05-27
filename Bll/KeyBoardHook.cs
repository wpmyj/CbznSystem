using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Bll
{
    public class KeyBoardHook
    {
        IntPtr hHook = IntPtr.Zero;
        WinApi.HookProc KeyBoardHookDelegate;
        public event KeyEventHandler OnKeyDownEvent;
        public event KeyEventHandler OnKeyUpEvent;
        public event KeyPressEventHandler OnKeyPressEvent;
        public bool Handled = false;
        public KeyBoardHook()
        { }

        /// <summary>
        /// 安装钩子
        /// </summary>
        public void SetHook()
        {
            KeyBoardHookDelegate = KeyBoardHookProc;
            //hHook = WinAPI.SetWindowsHookEx(WinAPI.WH_KEYBOARD_LL, KeyBoardHookDelegate, Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]), 0);
            hHook = WinApi.SetWindowsHookEx(WinApi.WH_KEYBOARD, KeyBoardHookDelegate, IntPtr.Zero, WinApi.GetCurrentThreadId());
            if (hHook == IntPtr.Zero)
            {
                UnHook();
                throw new Exception("钩子安装失败");
            }
        }

        /// <summary>
        /// 卸载钩子
        /// </summary>
        public void UnHook()
        {
            if (hHook != IntPtr.Zero)
                WinApi.UnhookWindowsHookEx(hHook);
            hHook = IntPtr.Zero;
        }

        private int KeyBoardHookProc(int nCode, Int32 wParam, IntPtr lParam)
        {
            if ((nCode >= 0) && (OnKeyDownEvent != null || OnKeyPressEvent != null || OnKeyUpEvent != null))
            {
                //WinAPI.KeyboardHookStruct keyboardhookstruct = (WinAPI.KeyboardHookStruct)Marshal.PtrToStructure(lParam, typeof(WinAPI.KeyboardHookStruct));
                //Keys KeyData = (Keys)keyboardhookstruct.vkCode;
                //WM_KEYDOWN和WM_SYSKEYDOWN消息，将会引发OnKeyDownEvent事件
                //if (OnKeyDownEvent != null && (wParam == WinAPI.WM_KEYDOWN || wParam == WinAPI.WM_SYSKEYDOWN))
                //{
                //    KeyEventArgs e = new KeyEventArgs(KeyData);
                //    OnKeyDownEvent(this, e);
                //}
                //WM_KEYDOWN消息将引发OnKeyPressEvent 
                //if (OnKeyPressEvent != null && wParam == WinAPI.WM_KEYDOWN)
                //{
                //    byte[] keyState = new byte[256];
                //    WinAPI.GetKeyboardState(keyState);
                //    byte[] inBuffer = new byte[2];
                //    if (WinAPI.ToAscii(keyboardhookstruct.vkCode, keyboardhookstruct.scanCode, keyState, inBuffer, keyboardhookstruct.flags) == 1)
                //    {
                //        KeyPressEventArgs e = new KeyPressEventArgs((char)inBuffer[0]);
                //        OnKeyPressEvent(this, e);
                //    }
                //}
                //WM_KEYUP和WM_SYSKEYUP消息，将引发OnKeyUpEvent事件 
                //if (OnKeyUpEvent != null && (wParam == WinAPI.WM_KEYUP || wParam == WinAPI.WM_SYSKEYUP))
                //{
                //    KeyEventArgs e = new KeyEventArgs(KeyData);
                //    OnKeyUpEvent(this, e);
                //}            
                Handled = false;
                Keys keydata = (Keys)wParam;
                KeyEventArgs e = new KeyEventArgs(keydata);
                if (OnKeyDownEvent != null && lParam.ToInt32() > 0)
                {
                    OnKeyDownEvent(this, e);
                }
                else if (OnKeyUpEvent != null && lParam.ToInt32() < 0)
                {
                    OnKeyUpEvent(this, e);
                }
                if (Handled) return 2;
            }
            return WinApi.CallNextHookEx(hHook, nCode, wParam, lParam);
        }

    }
}
