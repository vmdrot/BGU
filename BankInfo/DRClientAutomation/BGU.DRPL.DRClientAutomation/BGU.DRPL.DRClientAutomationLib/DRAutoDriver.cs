using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.DRClientAutomationLib.AuxData;
using System.Threading;

namespace BGU.DRPL.DRClientAutomationLib
{
    public class DRAutoDriver
    {
        public static IntPtr FindLowestBranchesGrid(IntPtr parent)
        {
                //Window 000C0480 "Відділення  << Фiлiя - Волинське обласне управлiння публічного акцiонерного товариства "Державний ощадний банк України"" TGroupBox
                //    Window 00050892 "" TDBGridEh
            WindowInfo wi3rdBranchesGroupBox = FormAutomUtils.FindChildWindowCaptionContains(parent, "Відділення  << Фiлiя - ", "TGroupBox");
            if (wi3rdBranchesGroupBox == null)
                return (IntPtr)0;
            System.Console.WriteLine("wi3rdBranchesGroupBox.Handle = {0}", wi3rdBranchesGroupBox.Handle);
            WindowInfo wiGrid = FormAutomUtils.FindChildWindowCaptionContains(wi3rdBranchesGroupBox.Handle, "", "TDBGridEh");
            if(wiGrid == null)
                return (IntPtr)0; //todo
            return wiGrid.Handle;
        }

        public static IntPtr FindEditTVBVButton(IntPtr parent)
        {
            WindowInfo wiTVBVActionBtnsGroupBox = FormAutomUtils.FindChildWindowCaptionEquals(parent, "Відділення", "TGroupBox");
            if (wiTVBVActionBtnsGroupBox == null)
            {
                System.Console.WriteLine("wiTVBVActionBtnsGroupBox == null");
                return (IntPtr)0;
            }
            System.Console.WriteLine("wiTVBVActionBtnsGroupBox.Handle = {0}", wiTVBVActionBtnsGroupBox.Handle);


            WindowInfo wiEditBtn = FormAutomUtils.FindChildWindowCaptionContains(wiTVBVActionBtnsGroupBox.Handle, "РЕДАГУВАННЯ", "TBitBtn");

            if (wiEditBtn == null)
            {
                wiEditBtn = FormAutomUtils.FindChildWindowCaptionContains(wiTVBVActionBtnsGroupBox.Handle, "РЕДАГУВАННЯ", "Button");
                if (wiEditBtn == null)
                    return (IntPtr)0; //todo
            }
            return wiEditBtn.Handle;
        }

        public static string ReadBranchID(IntPtr hwndBranchEditForm)
        {
            WindowInfo wiParamsSubTab = FormAutomUtils.FindChildWindowCaptionEquals(hwndBranchEditForm, "Параметри", "TTabSheet");
            if (wiParamsSubTab == null)
            {
                System.Console.WriteLine("Can't find wiParamsSubTab");
                return string.Empty;
            }
            System.Console.WriteLine("wiParamsSubTab.Handle = {0} ({0:X8})", wiParamsSubTab.Handle);
            //FormAutomUtils.ClickButton(wiParamsSubTab.Handle);
            if (!FormAutomUtils.ClickTab(wiParamsSubTab.Handle, 60, -10))
            {
                System.Console.WriteLine("Failed to click tab");
                return string.Empty;
            }
            Thread.Sleep(1000);
            WindowInfo wiIntBranchIDLbl = FormAutomUtils.FindChildWindowCaptionEquals(wiParamsSubTab.Handle, "Внутрішньобанківський код", "TStaticText");
            if (wiIntBranchIDLbl == null)
            {
                System.Console.WriteLine("Can't find wiIntBranchIDLbl");
                IntPtr hwndIntBranchIDLbl = FormAutomUtils.FindWindowEx(wiParamsSubTab.Handle, IntPtr.Zero, null, "Внутрішньобанківський код");
                if(hwndIntBranchIDLbl == IntPtr.Zero)
                    return string.Empty;
                wiIntBranchIDLbl = new WindowInfo() { Handle = hwndIntBranchIDLbl };
            }
            System.Console.WriteLine("wiIntBranchIDLbl.Handle = {0} ({0:X8})", wiIntBranchIDLbl.Handle);

            IntPtr hwndEdit = FormAutomUtils.FindWindowEx(wiParamsSubTab.Handle, wiIntBranchIDLbl.Handle, "TEdit", null);
            System.Console.WriteLine("hwndEdit = {0} ({0:X8})", hwndEdit);

            if(hwndEdit == IntPtr.Zero)
                return string.Empty; //todo
            return FormAutomUtils.GetWindowCaption(hwndEdit);
        }
    }
}
