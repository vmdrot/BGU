using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.DRClientAutomationLib.AuxData;
using System.Threading;
using Newtonsoft.Json;

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

        public static WindowInfo OpenOtherTab(IntPtr hwndBranchEditForm)
        {
            WindowInfo wiOtherTab = FormAutomUtils.FindChildWindowCaptionEquals(hwndBranchEditForm, "Інше", "TTabSheet");
            if (wiOtherTab == null)
            {
                System.Console.WriteLine("Can't find wiOtherTab");
                return null;
            }
            System.Console.WriteLine("wiOtherTab.Handle = {0} ({0:X8})", wiOtherTab.Handle);
            //FormAutomUtils.ClickButton(wiParamsSubTab.Handle);
            if (!FormAutomUtils.ClickTab(wiOtherTab.Handle, 360, -10))
            {
                System.Console.WriteLine("Failed to click tab");
                return null;
            }
            return wiOtherTab;
        }
        public static bool FillPayDocNr(WindowInfo wiOtherTab, string payDocNr)
        {
            return FillPayDocNr(wiOtherTab, IntPtr.Zero, payDocNr);
        }

        public static bool FillPayDocNr(WindowInfo wiOtherTab, IntPtr hwndPayDocEdit, string payDocNr)
        {
            if (hwndPayDocEdit == IntPtr.Zero)
            {
                WindowInfo wiPayDocGroupBox = FormAutomUtils.FindChildWindowCaptionEquals(wiOtherTab.Handle, "Інформація про платіжний документ", "TGroupBox");
                if (wiPayDocGroupBox == null)
                {
                    System.Console.WriteLine("Can't find wiPayDocGroupBox (1)");
                    IntPtr hwndPayDocGroupBox = FormAutomUtils.FindWindowEx(wiOtherTab.Handle, IntPtr.Zero, null, "Інформація про платіжний документ");
                    if (hwndPayDocGroupBox == IntPtr.Zero)
                    {
                        System.Console.WriteLine("Can't find wiPayDocGroupBox (1)");
                        return false;
                    }
                    wiPayDocGroupBox = new WindowInfo() { Handle = hwndPayDocGroupBox };
                }
                System.Console.WriteLine("wiPayDocGroupBox.Handle = {0} ({0:X8})", wiPayDocGroupBox.Handle);

                hwndPayDocEdit = FormAutomUtils.FindWindowEx(wiPayDocGroupBox.Handle, IntPtr.Zero, "TEdit", null);

                System.Console.WriteLine("hwndPayDocEdit = {0} ({0:X8})", hwndPayDocEdit);
                if (hwndPayDocEdit == IntPtr.Zero)
                {
                    List<WindowInfo> paydoctabctrls = FormAutomUtils.ListChildControls(wiPayDocGroupBox.Handle);
                    if (paydoctabctrls == null || paydoctabctrls.Count < 3 || paydoctabctrls[1].WndClass != "Edit")
                    {
                        Console.WriteLine("Can't find hwndPayDocEdit, paydoctabctrls = {0}", ToJson(paydoctabctrls));
                        return false;
                    }
                    hwndPayDocEdit = paydoctabctrls[1].Handle;
                }
            }
            System.Console.WriteLine("About to set pay doc nr.");
            FormAutomUtils.SetText2(hwndPayDocEdit, payDocNr);
            System.Console.WriteLine("Set pay doc nr.");
            //FormAutomUtils.SetAnyEditText(hwndPayDocEdit, payDocNr);

            return true;
        }

        public static bool FillChangesSummary(WindowInfo wiOtherTab, string summaryText)
        { 
            return FillChangesSummary(wiOtherTab, IntPtr.Zero, summaryText);
        }
        public static bool FillChangesSummary(WindowInfo wiOtherTab, IntPtr hwndEdit, string summaryText)
        {
            if (hwndEdit == IntPtr.Zero)
            {
                WindowInfo wiSummaryGroupBox = FormAutomUtils.FindChildWindowCaptionEquals(wiOtherTab.Handle, "Короткий опис змін:", "TGroupBox");
                if (wiSummaryGroupBox == null)
                {
                    System.Console.WriteLine("Can't find wiSummaryGroupBox(1)");
                    IntPtr hwneSummaryGroupBox = FormAutomUtils.FindWindowEx(wiOtherTab.Handle, IntPtr.Zero, null, "Короткий опис змін:");
                    if (hwneSummaryGroupBox == IntPtr.Zero)
                    {
                        System.Console.WriteLine("Can't find wiSummaryGroupBox(2)");
                        return false;
                    }
                    wiSummaryGroupBox = new WindowInfo() { Handle = hwneSummaryGroupBox };
                }
                System.Console.WriteLine("wiSummaryGroupBox.Handle = {0} ({0:X8})", wiSummaryGroupBox.Handle);

                hwndEdit = FormAutomUtils.FindWindowEx(wiSummaryGroupBox.Handle, IntPtr.Zero, "TRichEdit", null);
            }
            System.Console.WriteLine("hwndEdit = {0} ({0:X8})", hwndEdit);
            if (hwndEdit == IntPtr.Zero)
            {
                System.Console.WriteLine("Can't find hwndEdit");
                return false;
            }
            System.Console.WriteLine("About to set changes summary.");
            FormAutomUtils.SetText2(hwndEdit, summaryText);
            System.Console.WriteLine("Set changes summary.");
            //FormAutomUtils.SetAnyEditText(hwndEdit, summaryText);

            return true;
        }

        public static bool FillChangesDate(WindowInfo wiOtherTab, DateTime val)
        {
            return FillChangesDate(wiOtherTab, IntPtr.Zero, val);
        }
        public static bool FillChangesDate(WindowInfo wiOtherTab, IntPtr hwndEdit, DateTime val)
        {
            if (hwndEdit == IntPtr.Zero)
            {
                WindowInfo wiSummaryGroupBox = FormAutomUtils.FindChildWindowCaptionEquals(wiOtherTab.Handle, "  .  .    ", "TDBDateTimeEditEh");
                if (wiSummaryGroupBox == null)
                {
                    System.Console.WriteLine("Can't find wiSummaryGroupBox(1)");
                    IntPtr hwneSummaryGroupBox = FormAutomUtils.FindWindowEx(wiOtherTab.Handle, IntPtr.Zero, "TDBDateTimeEditEh", null);
                    if (hwneSummaryGroupBox == IntPtr.Zero)
                    {
                        System.Console.WriteLine("Can't find wiSummaryGroupBox(2)");
                        return false;
                    }
                    wiSummaryGroupBox = new WindowInfo() { Handle = hwneSummaryGroupBox };
                }
                System.Console.WriteLine("wiSummaryGroupBox.Handle = {0} ({0:X8})", wiSummaryGroupBox.Handle);

                hwndEdit = FormAutomUtils.FindWindowEx(wiSummaryGroupBox.Handle, IntPtr.Zero, "TRichEdit", null);
            }
            System.Console.WriteLine("hwndEdit = {0} ({0:X8})", hwndEdit);
            if (hwndEdit == IntPtr.Zero)
            {
                System.Console.WriteLine("Can't find hwndEdit");
                return false;
            }
            System.Console.WriteLine("About to set changes date.");
            FormAutomUtils.SetText2(hwndEdit, val.ToString("dd.MM.yyyy"));
            System.Console.WriteLine("Set changes date.");
            //FormAutomUtils.SetAnyEditText(hwndEdit, summaryText);

            return true;
        }

        public static string ReadChangesSummary(IntPtr hwndBranchEditForm)
        {
            WindowInfo wiOtherTab = FormAutomUtils.FindChildWindowCaptionEquals(hwndBranchEditForm, "Інше", "TTabSheet");
            if (wiOtherTab == null)
            {
                System.Console.WriteLine("Can't find wiOtherTab");
                return string.Empty;
            }
            System.Console.WriteLine("wiOtherTab.Handle = {0} ({0:X8})", wiOtherTab.Handle);
            //FormAutomUtils.ClickButton(wiParamsSubTab.Handle);
            if (!FormAutomUtils.ClickTab(wiOtherTab.Handle, 360, -10))
            {
                System.Console.WriteLine("Failed to click tab");
                return string.Empty;
            }
            Thread.Sleep(1000);


            WindowInfo wiSummaryGroupBox = FormAutomUtils.FindChildWindowCaptionEquals(wiOtherTab.Handle, "Короткий опис змін:", "TGroupBox");
            if (wiSummaryGroupBox == null)
            {
                System.Console.WriteLine("Can't find wiSummaryGroupBox");
                IntPtr hwneSummaryGroupBox = FormAutomUtils.FindWindowEx(wiOtherTab.Handle, IntPtr.Zero, null, "Короткий опис змін:");
                if (hwneSummaryGroupBox == IntPtr.Zero)
                    return string.Empty;
                wiSummaryGroupBox = new WindowInfo() { Handle = hwneSummaryGroupBox };
            }
            System.Console.WriteLine("wiSummaryGroupBox.Handle = {0} ({0:X8})", wiSummaryGroupBox.Handle);

            IntPtr hwndEdit = FormAutomUtils.FindWindowEx(wiSummaryGroupBox.Handle, IntPtr.Zero, "TRichEdit", null);
            System.Console.WriteLine("hwndEdit = {0} ({0:X8})", hwndEdit);
            if (hwndEdit == IntPtr.Zero)
                return string.Empty;
            //return FormAutomUtils.GetControlValue(hwndEdit);
            return FormAutomUtils.GetWindowCaption(hwndEdit);
        }


        private static JsonSerializerSettings _jsonSettings;

        private static JsonSerializerSettings JsonSettings 
        {
            get 
            {
                if (_jsonSettings == null)
                {
                    _jsonSettings = new JsonSerializerSettings();
                    _jsonSettings.NullValueHandling = NullValueHandling.Ignore;
                }
                return _jsonSettings;
            }
        }

        private static JsonSerializerSettings _jsonSettingsIndent;

        private static JsonSerializerSettings JsonSettingsIndent
        {
            get
            {
                if (_jsonSettingsIndent == null)
                {
                    _jsonSettingsIndent = new JsonSerializerSettings();
                    _jsonSettingsIndent.NullValueHandling = NullValueHandling.Ignore;
                    _jsonSettingsIndent.Formatting = Formatting.Indented;
                }
                return _jsonSettingsIndent;
            }
        }

        public static string ToJson(object obj)
        {
            return ToJson(obj, false);
        }

        public static string ToJson(object obj, bool bIndent)
        {
            return JsonConvert.SerializeObject(obj, bIndent ? JsonSettingsIndent : JsonSettings);
        }
    }
}
