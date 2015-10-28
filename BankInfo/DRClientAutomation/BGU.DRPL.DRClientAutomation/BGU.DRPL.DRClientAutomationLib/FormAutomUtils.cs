using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using BGU.DRPL.DRClientAutomationLib.AuxData;
using System.Threading;

namespace BGU.DRPL.DRClientAutomationLib
{
    public class FormAutomUtils
    {
        //[DllImport("USER32.DLL", CharSet = CharSet.Unicode, EntryPoint = "FindWindowW", CallingConvention = CallingConvention.StdCall)]
        [DllImport("USER32.DLL", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr FindWindow(string lpClassName,
                                               string lpWindowName);

        // Activate an application window.
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("USER32.DLL")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("USER32.DLL")]
        public static extern IntPtr GetParent(IntPtr hWnd);

        public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        [DllImport("USER32.DLL")]
        public static extern bool EnumChildWindows(IntPtr hWndParent, EnumWindowsProc lpEnumFunc, IntPtr lParam);
        
        [DllImport("USER32.DLL")]
        public static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

        [DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowText(IntPtr hWnd, [Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpString, int nMaxCount);

        [DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int RealGetWindowClass(IntPtr hWnd, [Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false, EntryPoint = "SendMessage")]
        public static extern IntPtr SendTextMessage(HandleRef hWnd, uint Msg, IntPtr wParam, string lParam);

        
        [DllImport("user32.dll")]
        static extern bool PostMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        
        [DllImport("user32.dll")]
        public static extern IntPtr SetFocus(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(long dwFlags, long dx, long dy, long cButtons, long dwExtraInfo);

        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, out long lpdwProcessId);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;        // x position of upper-left corner
            public int Top;         // y position of upper-left corner
            public int Right;       // x position of lower-right corner
            public int Bottom;      // y position of lower-right corner
        }




        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;



        private const int BN_CLICKED = 0x00F5;
        private const uint WM_KEYDOWN = 0x0100;
        private const uint WM_KEYUP = 0x0101;
        private const uint WM_CHAR = 0x0102;
        private const int VK_TAB = 0x09;
        private const int VK_ENTER = 0x0D;
        private const int VK_UP = 0x26;
        private const int VK_DOWN = 0x28;
        private const int VK_RIGHT = 0x27;
        private const int VK_SPACE = 0x20;
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_CLOSE = 0xF060;
        private const int WM_SETTEXT = 0x000c;
        private const int WM_GETTEXT = 0x000D;
        private const int WM_GETTEXTLENGTH = 0x000E;

        //public static IntPtr FindWindow(string caption, string wndClass)
        //{
        //    return Find
        //    return null;//todo
        //}

        public static string GetWindowCaption(IntPtr hWnd)
        {
            StringBuilder sbcurrWndCaption = new StringBuilder(1024);
            GetWindowText(hWnd, sbcurrWndCaption, 1024);
            return sbcurrWndCaption.ToString();

        }

        public static string GetWindowClassName(IntPtr hWnd)
        {
            StringBuilder sbcurrWndClsNm = new StringBuilder(1024);
            RealGetWindowClass(hWnd, sbcurrWndClsNm, 1024);
            return sbcurrWndClsNm.ToString();

        }

        public static WindowInfo FindChildWindowCaptionContains(IntPtr parentWnd, string captionStart, string wndClass)
        {
            List<WindowInfo> childWindows = new List<WindowInfo>();
            object[] lParam = new object[] { (object)captionStart, (object)wndClass, (object)childWindows };
            GCHandle handle1 = GCHandle.Alloc(lParam);
            EnumChildWindows(parentWnd, FindWindowByCaptionContainsClassEnumProc, (IntPtr)handle1);
            if (childWindows.Count == 0)
            {
                handle1.Free();
                return null;
            }
            handle1.Free();
            return childWindows[0];
        }

        public static WindowInfo FindChildWindowCaptionEquals(IntPtr parentWnd, string caption, string wndClass)
        {
            List<WindowInfo> childWindows = new List<WindowInfo>();
            object[] lParam = new object[] { (object)caption, (object)wndClass, (object)childWindows };
            GCHandle handle1 = GCHandle.Alloc(lParam);
            EnumChildWindows(parentWnd, FindWindowByCaptionExactClassEnumProc, (IntPtr)handle1);
            if (childWindows.Count == 0)
            {
                handle1.Free();
                return null;
            }
            handle1.Free();
            return childWindows[0];
        }
        private static bool FindWindowByCaptionExactClassEnumProc(IntPtr hWnd, IntPtr lParam)
        {
            GCHandle handle2 = (GCHandle)lParam;
            object[] args = (object[])(handle2.Target as object);
            List<WindowInfo> childWindows = (List<WindowInfo>)args[2];
            WindowInfo currWi = WindowInfo.Fill(hWnd);
            string caption = args[0] as string;
            string wndClass = args[1] as string;

            if (currWi.Caption != caption || currWi.WndClass != wndClass)
            {
                
                return true;
            }
            childWindows.Add(currWi);
            
            return true;
        }

        private static bool FindWindowByCaptionContainsClassEnumProc(IntPtr hWnd, IntPtr lParam)
        {
            GCHandle handle2 = (GCHandle)lParam;
            object[] args = (object[])(handle2.Target as object);

            
            List<WindowInfo> childWindows = (List<WindowInfo>)args[2];
            WindowInfo wi = WindowInfo.Fill(hWnd);
            string captionStart = args[0] as string;
            string wndClass = args[1] as string;
            if (wi.Caption.IndexOf(captionStart) == -1 || wi.WndClass != wndClass)
            {
                
                return true;
            }
            childWindows.Add(wi);
            
            return true;
        }

        public static void ClickButton(IntPtr hwndButton)
        {
            SendMessage(hwndButton, BN_CLICKED, IntPtr.Zero, IntPtr.Zero);
        }

        public static void FocusAndClickArrowDown(IntPtr hwnd)
        {
            SetFocus(hwnd);
            Thread.Sleep(1000);
            //SendMessage(hwnd, VK_DOWN, IntPtr.Zero, IntPtr.Zero);
            PostMessage(hwnd, (int)WM_KEYDOWN, (IntPtr)VK_DOWN, IntPtr.Zero);
            Thread.Sleep(300);
            PostMessage(hwnd, (int)WM_KEYUP, (IntPtr)VK_DOWN, IntPtr.Zero);
        }

        public static void FocusAndClickArrowRight(IntPtr hwnd)
        {
            SetFocus(hwnd);
            Thread.Sleep(1000);
            //SendMessage(hwnd, VK_DOWN, IntPtr.Zero, IntPtr.Zero);
            PostMessage(hwnd, (int)WM_KEYDOWN, (IntPtr)VK_RIGHT, IntPtr.Zero);
            Thread.Sleep(300);
            PostMessage(hwnd, (int)WM_KEYUP, (IntPtr)VK_RIGHT, IntPtr.Zero);
        }

        public static void CloseWindow(IntPtr hwnd)
        {
            SendMessage(hwnd, WM_SYSCOMMAND, (IntPtr)SC_CLOSE, IntPtr.Zero);
        }

        public static void ClickButton2(IntPtr hwndButton)
        {
            PostMessage(hwndButton, BN_CLICKED, IntPtr.Zero, IntPtr.Zero);
        }

        public static bool ClickTab(IntPtr hwndTab)
        {
            RECT tabRect;
            RECT tabClientRect;
            if (!GetWindowRect(hwndTab, out tabRect))
                return false;
            Console.WriteLine("tabRect = {{ {0}, {1} , {2}, {3} }}", tabRect.Left, tabRect.Top, tabRect.Right, tabRect.Bottom);

            if (!GetClientRect(hwndTab, out tabClientRect))
                return false;
            Console.WriteLine("tabClientRect = {{ {0}, {1} , {2}, {3} }}", tabClientRect.Left, tabClientRect.Top, tabClientRect.Right, tabClientRect.Bottom);
            
            Console.WriteLine("About to MoveCursorToPoint");
            Thread.Sleep(1000);
            MoveCursorToPoint(tabRect.Left + 2, tabRect.Top + 2);
            Thread.Sleep(1000);
            MoveCursorToPoint(tabClientRect.Left + 2, tabClientRect.Top + 2);
            Console.WriteLine("MoveCursorToPoint-ed, move mouse if not there:.....");
            Console.Read();
            DoMouseClick();
            //PostMessage(hwndTab, BN_CLICKED, IntPtr.Zero, IntPtr.Zero);
            return true;
        }

        public static bool ClickTab(IntPtr hwndTab, int xCorrection, int yCorrection)
        {
            RECT tabRect;
            if (!GetWindowRect(hwndTab, out tabRect))
                return false;
            Console.WriteLine("tabRect = {{ {0}, {1} , {2}, {3} }}", tabRect.Left, tabRect.Top, tabRect.Right, tabRect.Bottom);

            Console.WriteLine("About to MoveCursorToPoint");
            Thread.Sleep(1000);
            MoveCursorToPoint(tabRect.Left + xCorrection, tabRect.Top + yCorrection);
            Thread.Sleep(1000);
            
            //Console.Read();
            DoMouseClick();
            //PostMessage(hwndTab, BN_CLICKED, IntPtr.Zero, IntPtr.Zero);
            return true;
        }

        public static void DoMouseClick()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        public static void MoveCursorToPoint(int x, int y)
        {
            SetCursorPos(x, y);
        }



        public static void SetText(IntPtr hwnd, string text)
        {
            GCHandle handle1 = GCHandle.Alloc(text); 
            //PostMessage(hwnd, WM_SETTEXT, IntPtr.Zero, (IntPtr)handle1);
            SendMessage(hwnd, WM_SETTEXT, IntPtr.Zero, (IntPtr)handle1);
            handle1.Free();
        }

        public static void SetText2(IntPtr hwnd, string text)
        {
            HandleRef hrefHwnd = new HandleRef(null, hwnd);
            SendTextMessage(hrefHwnd, WM_SETTEXT, IntPtr.Zero, text);
        }

        public static void SetTextCharByChar(IntPtr hwnd, string text)
        {
            SetFocus(hwnd);
            Thread.Sleep(50);

            foreach (char ch in text)
            {
                PostMessage(hwnd, (int)WM_KEYDOWN, (IntPtr)(int)ch, IntPtr.Zero);
                Thread.Sleep(50);
                PostMessage(hwnd, (int)WM_KEYUP, (IntPtr)(int)ch, IntPtr.Zero);
            }
        }

        public static void SetRichEditText(IntPtr hwnd, string plainText)
        {
            using (System.Windows.Forms.RichTextBox rtbx = new System.Windows.Forms.RichTextBox())
            {
                rtbx.Text = plainText;
                SetText(hwnd, rtbx.Rtf);
            }
        }

        public static void SetAnyEditText(IntPtr hwnd, string plainText)
        {
            SetTextCharByChar(hwnd, plainText);
        }

        public static void FocusAndClickSpace(IntPtr hwnd)
        {
            SetFocus(hwnd);
            Thread.Sleep(1000);
            //SendMessage(hwnd, VK_DOWN, IntPtr.Zero, IntPtr.Zero);
            PostMessage(hwnd, (int)WM_KEYDOWN, (IntPtr)VK_SPACE, IntPtr.Zero);
            Thread.Sleep(300);
            PostMessage(hwnd, (int)WM_KEYUP, (IntPtr)VK_SPACE, IntPtr.Zero);

        }

        public static string GetControlValue(IntPtr hwnd)
        {
            int length = (int)SendMessage(hwnd, WM_GETTEXTLENGTH, IntPtr.Zero, IntPtr.Zero);
            StringBuilder sb = new StringBuilder(length);
            GCHandle handle1 = GCHandle.Alloc(sb);
            SendMessage(hwnd, WM_GETTEXT, (IntPtr)sb.Capacity, (IntPtr)handle1);
            handle1.Free();
            return sb.ToString();
        }

        public static void ClickGrid(IntPtr hwndGrid)
        {
            ClickTab(hwndGrid, 10, 20);
        }

        public static List<WindowInfo> ListChildControls(IntPtr parentWnd)
        {
            List<WindowInfo> childWindows = new List<WindowInfo>();
            GCHandle handle1 = GCHandle.Alloc(childWindows);
            EnumChildWindows(parentWnd, ListChildWindowsEnumProc, (IntPtr)handle1);
            handle1.Free();
            return childWindows;
        }

        private static bool ListChildWindowsEnumProc(IntPtr hWnd, IntPtr lParam)
        {
            GCHandle handle2 = (GCHandle)lParam;
            List<WindowInfo> childWindows = (List<WindowInfo>)handle2.Target;
            childWindows.Add(WindowInfo.Fill(hWnd));
            return true;
        }

        public static int GetWindowProcess(IntPtr hwnd)
        {
            long tmp;
            GetWindowThreadProcessId(hwnd, out tmp);
            return (int)tmp;
        }

        public static IntPtr WaitForWindow(string wndCaption, string wndCls, int wndProcessId, int retriesCount, int sleepInterval)
        {
            int retries = 0;
            while (retries < retriesCount)
            {
                List<WindowInfo> allWnds = FormAutomUtils.ListAllWindowsForAProcess(wndProcessId);
                if(allWnds.Exists( w => (wndCaption == null || w.Caption == wndCaption) && (wndCls == null || w.WndClass == wndCls)))
                {
                    return allWnds.Find(w => (wndCaption == null || w.Caption == wndCaption) && (wndCls == null || w.WndClass == wndCls)).Handle;
                }
                retries++;
                Thread.Sleep(sleepInterval);
                
            }
            return IntPtr.Zero;
        }

        private static List<WindowInfo> ListAllWindowsForAProcess(int wndProcessId)
        {
            List<WindowInfo> childWindows = new List<WindowInfo>();
            object[] lParam = new object[] { (object)wndProcessId, (object) childWindows};
            GCHandle handle1 = GCHandle.Alloc((object)lParam);
            EnumWindows(ListWindowsForAProcessEnumProc, (IntPtr)handle1);
            handle1.Free();
            return childWindows;
        }

        private static bool ListWindowsForAProcessEnumProc(IntPtr hWnd, IntPtr lParam)
        {
            GCHandle handle2 = (GCHandle)lParam;
            object[] args = (object[])(handle2.Target as object);
            int processId = (int)args[0];
            List<WindowInfo> childWindows = (List<WindowInfo>)args[1];
            WindowInfo wi = WindowInfo.Fill(hWnd);
            if (wi.ProcessId != processId)
                return true;
            childWindows.Add(wi);
            return true;
        }


        //internal static IntPtr WaitForChildWindow(IntPtr hwndConfirmChangesDlg, string p, string p_2, int p_3, int p_4)
        public static IntPtr WaitForChildWindow(IntPtr hwndParent, string wndCaption, string wndCls, int retriesCount, int sleepInterval)
        {
            int retries = 0;
            while (retries < retriesCount)
            {
                List<WindowInfo> allWnds = FormAutomUtils.ListChildControls(hwndParent);
                if (allWnds.Exists(w => (wndCaption == null || w.Caption == wndCaption) && (wndCls == null || w.WndClass == wndCls)))
                {
                    return allWnds.Find(w => (wndCaption == null || w.Caption == wndCaption) && (wndCls == null || w.WndClass == wndCls)).Handle;
                }
                retries++;
                Thread.Sleep(sleepInterval);
                
            }
            return IntPtr.Zero;
        }
    }
}
