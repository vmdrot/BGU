using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.DRClientAutomationLib.AuxData;

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
    }
}
