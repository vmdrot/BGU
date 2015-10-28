using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BGU.DRPL.DRClientAutomationLib.AuxData
{
    public class WindowInfo
    {
        public string Caption { get; set; }
        public IntPtr Handle { get; set; }
        public string WndClass { get; set; }
        public int ProcessId { get; set; }

        public static WindowInfo Fill(IntPtr hwnd)
        {
            WindowInfo rslt = new WindowInfo();
            rslt.Handle = hwnd;
            rslt.Caption = FormAutomUtils.GetWindowCaption(hwnd);
            rslt.WndClass = FormAutomUtils.GetWindowClassName(hwnd);
            rslt.ProcessId = FormAutomUtils.GetWindowProcess(hwnd);
            return rslt;
        }
    }
}
