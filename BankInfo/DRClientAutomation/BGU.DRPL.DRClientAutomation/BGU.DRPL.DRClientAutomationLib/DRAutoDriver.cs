using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.DRClientAutomationLib.AuxData;
using System.Threading;
using Newtonsoft.Json;
using BGU.DRPL.DRClientAutomationLib.Data;

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
                wi3rdBranchesGroupBox = FormAutomUtils.FindChildWindowCaptionContains(parent, "Відділення  << Філія - ", "TGroupBox");
            if (wi3rdBranchesGroupBox == null)
                return (IntPtr)0;
            System.Console.WriteLine("wi3rdBranchesGroupBox.Handle = {0}", wi3rdBranchesGroupBox.Handle);
            WindowInfo wiGrid = FormAutomUtils.FindChildWindowCaptionContains(wi3rdBranchesGroupBox.Handle, "", "TDBGridEh");
            if (wiGrid == null)
                return (IntPtr)0; //todo
            return wiGrid.Handle;
        }

        public static IntPtr FindMiddleBranchesGrid(IntPtr parent)
        {
                //Window 02400A88 "Філії  << публічне акціонерне товариство "Державний ощадний банк України"" TGroupBox
                //    Window 026106BA "" TDBGridEh
            WindowInfo wi2ndBranchesGroupBox = FormAutomUtils.FindChildWindowCaptionContains(parent, "Філії  << ", "TGroupBox");

            //if (wi2ndBranchesGroupBox == null)
            //    wi2ndBranchesGroupBox = FormAutomUtils.FindChildWindowCaptionContains(parent, "Відділення  << Філія - ", "TGroupBox");
            if (wi2ndBranchesGroupBox == null)
                return (IntPtr)0;
            System.Console.WriteLine("wi2ndBranchesGroupBox.Handle = {0}", wi2ndBranchesGroupBox.Handle);
            WindowInfo wiGrid = FormAutomUtils.FindChildWindowCaptionContains(wi2ndBranchesGroupBox.Handle, "", "TDBGridEh");
            if (wiGrid == null)
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


        public static IntPtr FindRollbackTVBVChanges4TodayButton(IntPtr parent)
        {
            //Window 022D0AAE "Відділення" TGroupBox
            //    Window 02340C5E "ЕП" TBitBtn
            //    Window 021E0C4A "ВИЛУЧИТИ ЗМІНИ ЗА СЬОГОДНІ" TBitBtn
            //    Window 024A08BE "   ДОДАТИ           " TBitBtn
            //    Window 00B50B1E "  РЕДАГУВАННЯ" TBitBtn
            //    Window 00A90AE0 " ПЕРЕГЛЯД" TBitBtn

            WindowInfo wiTVBVActionBtnsGroupBox = FormAutomUtils.FindChildWindowCaptionEquals(parent, "Відділення", "TGroupBox");
            if (wiTVBVActionBtnsGroupBox == null)
            {
                System.Console.WriteLine("wiTVBVActionBtnsGroupBox == null");
                return (IntPtr)0;
            }
            System.Console.WriteLine("wiTVBVActionBtnsGroupBox.Handle = {0}", wiTVBVActionBtnsGroupBox.Handle);

            string caption = "ВИЛУЧИТИ ЗМІНИ ЗА СЬОГОДНІ";

            WindowInfo wiRollBackBtn = FormAutomUtils.FindChildWindowCaptionContains(wiTVBVActionBtnsGroupBox.Handle, caption, "TBitBtn");

            if (wiRollBackBtn == null)
            {
                wiRollBackBtn = FormAutomUtils.FindChildWindowCaptionContains(wiTVBVActionBtnsGroupBox.Handle, caption, "Button");
                if (wiRollBackBtn == null)
                    return (IntPtr)0; //todo
            }
            return wiRollBackBtn.Handle;
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
                if (hwndIntBranchIDLbl == IntPtr.Zero)
                    return string.Empty;
                wiIntBranchIDLbl = new WindowInfo() { Handle = hwndIntBranchIDLbl };
            }
            System.Console.WriteLine("wiIntBranchIDLbl.Handle = {0} ({0:X8})", wiIntBranchIDLbl.Handle);

            IntPtr hwndEdit = FormAutomUtils.FindWindowEx(wiParamsSubTab.Handle, wiIntBranchIDLbl.Handle, "TEdit", null);
            System.Console.WriteLine("hwndEdit = {0} ({0:X8})", hwndEdit);

            if (hwndEdit == IntPtr.Zero)
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
                    IntPtr hwndSummaryGroupBox = FormAutomUtils.FindWindowEx(wiOtherTab.Handle, IntPtr.Zero, null, "Короткий опис змін:");
                    if (hwndSummaryGroupBox == IntPtr.Zero)
                    {
                        System.Console.WriteLine("Can't find wiSummaryGroupBox(2)");
                        return false;
                    }
                    wiSummaryGroupBox = new WindowInfo() { Handle = hwndSummaryGroupBox };
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
            //FormAutomUtils.SetAnyEditText(hwndEdit, summaryText); //experimental but not properly working
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

        public static bool ApplyBulkOpsSvcChange(TVBVsOpsSvcBulkChangeInfo changes, bool bEmulateOnly, int pauseBeforeClosing, out List<TBVBChangeResultInfo> results)
        {
            return ApplyBulkOpsSvcChange(changes, bEmulateOnly, pauseBeforeClosing, 0, out results);
        }

        public static bool ApplyBulkOpsSvcChange(TVBVsOpsSvcBulkChangeInfo changes, bool bEmulateOnly, int pauseBeforeClosing, int maxProcessCount, out List<TBVBChangeResultInfo> results)
        {
            results= new List<TBVBChangeResultInfo>();

            IntPtr mainEditBranchesForm = FormAutomUtils.FindWindow("TBanks_modFm", "Редагування банківських установ");
            
            if (mainEditBranchesForm == (IntPtr)0)
            {
                System.Console.WriteLine("Can't find main window");

                return false;
            }
            int drClientProcessId = FormAutomUtils.GetWindowProcess(mainEditBranchesForm);
            System.Console.WriteLine("drClientProcessId = {0}", drClientProcessId);
            System.Console.WriteLine("mainEditBranchesForm = {0} ({0:X8})", mainEditBranchesForm);
            if (!FormAutomUtils.SetForegroundWindow(mainEditBranchesForm))
            {
                System.Console.WriteLine("Can't activate main window");
                return false;
            }

            IntPtr hwndGrid = DRAutoDriver.FindLowestBranchesGrid(mainEditBranchesForm);

            System.Console.WriteLine("hwndGrid = {0}", hwndGrid);
            IntPtr hwnEditTvbvBtn = DRAutoDriver.FindEditTVBVButton(mainEditBranchesForm);
            System.Console.WriteLine("hwnEditTvbvBtn = {0}", hwnEditTvbvBtn);
            if (hwndGrid == IntPtr.Zero || hwnEditTvbvBtn == IntPtr.Zero)
            {
                System.Console.WriteLine("Can't find all needed windows");
                return false;
            }
            string prevBranchId = string.Empty;
            string lastBranchId = string.Empty;
            int processIdx = 0;
            FormAutomUtils.SetFocus(hwndGrid);
            FormAutomUtils.ClickGrid(hwndGrid);
            Thread.Sleep(500);
            do
            {
                if (maxProcessCount > 0 && processIdx >= maxProcessCount)
                    break;
                TBVBChangeResultInfo currRslt= new TBVBChangeResultInfo();
                prevBranchId = lastBranchId;
                FormAutomUtils.ClickButton2(hwnEditTvbvBtn);
                Thread.Sleep(1500); // todo - to shorten
                IntPtr hwndBranchEditForm = FormAutomUtils.FindWindow("TVIDDIL_CLASSForm_2", null);
                System.Console.WriteLine("hwndBranchEditForm = {0}", hwndBranchEditForm);
                Thread.Sleep(2000); // todo - to shorten
                string currIntBranchID = DRAutoDriver.ReadBranchID(hwndBranchEditForm);
                lastBranchId = currIntBranchID.Replace(" ", string.Empty).Trim();

                if (prevBranchId == lastBranchId)
                {
                    FormAutomUtils.CloseWindow(hwndBranchEditForm);
                    break;
                }

                currRslt.BranchID = lastBranchId;

                System.Console.WriteLine("currIntBranchID = '{0}'", currIntBranchID);
                if (changes.Items.Exists(o => o.BranchID == lastBranchId))
                {
                    TVBVOpsSevicesChangeInfo currChgInfo = changes.Items.Find(o => o.BranchID == lastBranchId);
                    currRslt.ParentMFO = currChgInfo.ParentMFO;
                    currRslt.BranchName = DRAutoDriver.ReadBranchName(hwndBranchEditForm);

                    WindowInfo wiOtherTab = DRAutoDriver.OpenOtherTab(hwndBranchEditForm);
                    if (wiOtherTab == null)
                        System.Console.WriteLine("wiOtherTab is null");
                    else
                    {
                        EditBranchFormOtherTabControlsInfo tabCtrlsInfo;
                        int otherTabCtrlsRetries = 0;
                        do
                        {
                            tabCtrlsInfo = EditBranchFormOtherTabControlsInfo.Fill(wiOtherTab.Handle);
                            if (tabCtrlsInfo != null && tabCtrlsInfo.IsChangesControlsFound)
                                break;
                            Thread.Sleep(250); //todo - to shorten further (try reduce sleep while increasing retries count)
                            otherTabCtrlsRetries++;
                        } while (otherTabCtrlsRetries < 5);

                        System.Console.WriteLine("tabCtrlsInfo = {0}", DRAutoDriver.ToJson(tabCtrlsInfo, true));

                        bool bChgsSummaryFilled = false;
                        bool bChgsDateFilled = false;

                        if (tabCtrlsInfo != null && tabCtrlsInfo.IsChangesControlsFound)
                        {
                            bChgsSummaryFilled = DRAutoDriver.FillChangesSummary(null, tabCtrlsInfo.ChangesSummaryEdit, FormatChangesSummary(currChgInfo));
                            bChgsDateFilled = DRAutoDriver.FillChangesDate(null, tabCtrlsInfo.ChangesDate, currChgInfo.ChangeDate);
                        }
                        else
                        {
                            bChgsSummaryFilled = DRAutoDriver.FillChangesSummary(wiOtherTab, currChgInfo.ChangesSummary);
                            bChgsDateFilled = DRAutoDriver.FillChangesDate(wiOtherTab, currChgInfo.ChangeDate);
                        }
                        if (!bChgsSummaryFilled || !bChgsDateFilled)
                        {
                            if (bChgsSummaryFilled) { currRslt.ErrorsInfo.Add("Failed to change summary"); currRslt.ErrorsCount++; }
                            if (bChgsDateFilled) { currRslt.ErrorsInfo.Add("Failed to change date"); currRslt.ErrorsCount++; }
                        }
                    }
                    WindowInfo wiSaveChangeBtn = FormAutomUtils.FindChildWindowCaptionEquals(hwndBranchEditForm, "Зберегти дані", "TButton");
                    if (wiSaveChangeBtn == null)
                        wiSaveChangeBtn = FormAutomUtils.FindChildWindowCaptionEquals(hwndBranchEditForm, "Зберегти дані", "Button");

                    if (wiSaveChangeBtn == null)
                    {
                        currRslt.ErrorsInfo.Add("Failed to find save button");
                        currRslt.ErrorsCount++;
                    }
                    else
                        Console.WriteLine("wiSaveChangeBtn.Handle = {0}", wiSaveChangeBtn.Handle);
                    if (pauseBeforeClosing > 0)
                        Thread.Sleep(pauseBeforeClosing);
                    if (bEmulateOnly)
                    {
                        if (currRslt.ErrorsCount == 0) currRslt.Succeeded = true;
                        FormAutomUtils.CloseWindow(hwndBranchEditForm);
                    }
                    else
                    {
                        if (currRslt.ErrorsCount == 0)
                        {
                            if (wiSaveChangeBtn != null)
                            {
                                System.Console.WriteLine("About to press wiSaveChangeBtn ....");
                                //FormAutomUtils.ClickButton(wiSaveChangeBtn.Handle); //doesn't work if the app spawns any modal windows
                                FormAutomUtils.ClickButton2(wiSaveChangeBtn.Handle);
                                System.Console.WriteLine("wiSaveChangeBtn pressed.");

                                Thread.Sleep(1500);
                                IntPtr hwndConfirmChangesDlg = FormAutomUtils.WaitForWindow("Підтвердження", "#32770 (Dialog)", drClientProcessId, 7, 250);
                                if (hwndConfirmChangesDlg == IntPtr.Zero)
                                    hwndConfirmChangesDlg = FormAutomUtils.WaitForWindow("Підтвердження", null, drClientProcessId, 7, 250);
                                System.Console.WriteLine("hwndConfirmChangesDlg = {0}", hwndConfirmChangesDlg);
                                if (hwndConfirmChangesDlg == IntPtr.Zero)
                                {
                                    currRslt.ErrorsCount++;
                                    currRslt.ErrorsInfo.Add("Failed to find confirm changes save dialog");
                                }
                                else
                                {
                                    IntPtr hwndYesBtn = FormAutomUtils.WaitForChildWindow(hwndConfirmChangesDlg, "&Так", "Button", 7, 50);
                                    System.Console.WriteLine("hwndYesBtn = {0}", hwndYesBtn);
                                    if (hwndYesBtn == IntPtr.Zero)
                                    {
                                        currRslt.ErrorsCount++;
                                        currRslt.ErrorsInfo.Add("Failed to find yes button on confirm changes save dialog");
                                    }
                                    else
                                    {
                                        FormAutomUtils.ClickButton(hwndYesBtn);
                                        IntPtr hwndChangesSavedOKDlg = FormAutomUtils.WaitForWindow("РЕЄСТР", "TMessageForm", drClientProcessId, 10, 100);
                                        if (hwndChangesSavedOKDlg == IntPtr.Zero)
                                            hwndChangesSavedOKDlg = FormAutomUtils.WaitForWindow("РЕЄСТР", "MessageForm", drClientProcessId, 10, 100);
                                        if (hwndChangesSavedOKDlg == IntPtr.Zero)
                                            hwndChangesSavedOKDlg = FormAutomUtils.WaitForWindow("РЕЄСТР", null, drClientProcessId, 10, 100);

                                        System.Console.WriteLine("hwndChangesSavedOKDlg = {0}", hwndChangesSavedOKDlg);
                                        if (hwndChangesSavedOKDlg == IntPtr.Zero)
                                        {
                                            currRslt.ErrorsCount++;
                                            currRslt.ErrorsInfo.Add("Failed to find changes saved OK dialog");
                                        }
                                        else
                                        {
                                            IntPtr hwndOKBtn = FormAutomUtils.WaitForChildWindow(hwndChangesSavedOKDlg, "OK", "TButton", 7, 50);
                                            if (hwndOKBtn == IntPtr.Zero)
                                                hwndOKBtn = FormAutomUtils.WaitForChildWindow(hwndChangesSavedOKDlg, "OK", "Button", 7, 50);
                                            if (hwndOKBtn == IntPtr.Zero)
                                                hwndOKBtn = FormAutomUtils.WaitForChildWindow(hwndChangesSavedOKDlg, "OK", null, 7, 50);
                                            System.Console.WriteLine("hwndOKBtn = {0}", hwndOKBtn);
                                            if (hwndOKBtn == IntPtr.Zero)
                                            {
                                                currRslt.ErrorsCount++;
                                                currRslt.ErrorsInfo.Add("Failed to find ok button on changes saved OK dialog");
                                                System.Console.WriteLine("Failed to find ok button on changes saved OK dialog");
                                            }
                                            else
                                            {
                                                FormAutomUtils.ClickButton(hwndOKBtn);
                                                currRslt.Succeeded = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    results.Add(currRslt);
                    processIdx++;
                    Thread.Sleep(300);
                    FormAutomUtils.FocusAndClickArrowDown(hwndGrid);
                    Thread.Sleep(500);
                    System.Console.WriteLine("---------------------------------------------------------------------------------------------------------");
                }
                else
                {
                    System.Console.WriteLine("Nothing to do with branch # {0}", lastBranchId);
                    FormAutomUtils.CloseWindow(hwndBranchEditForm);
                    Thread.Sleep(300);
                    FormAutomUtils.FocusAndClickArrowDown(hwndGrid);
                    Thread.Sleep(500);
                }

            } while (true);

            return true;
        }


        public static bool RollbackAllChangesForToday(bool bEmulateOnly, int pauseBeforeClosing, int maxProcessCount)
        {

            IntPtr mainEditBranchesForm = FormAutomUtils.FindWindow("TBanks_modFm", "Редагування банківських установ");

            if (mainEditBranchesForm == (IntPtr)0)
            {
                System.Console.WriteLine("Can't find main window");

                return false;
            }
            int drClientProcessId = FormAutomUtils.GetWindowProcess(mainEditBranchesForm);
            System.Console.WriteLine("drClientProcessId = {0}", drClientProcessId);
            System.Console.WriteLine("mainEditBranchesForm = {0} ({0:X8})", mainEditBranchesForm);
            if (!FormAutomUtils.SetForegroundWindow(mainEditBranchesForm))
            {
                System.Console.WriteLine("Can't activate main window");
                return false;
            }
            IntPtr hwndGrid2 = DRAutoDriver.FindMiddleBranchesGrid(mainEditBranchesForm);

            System.Console.WriteLine("hwndGrid2 = {0}", hwndGrid2);
            
            IntPtr hwndGrid3 = DRAutoDriver.FindLowestBranchesGrid(mainEditBranchesForm);
            System.Console.WriteLine("hwndGrid3(I) = {0}", hwndGrid3);
            if (hwndGrid3 == IntPtr.Zero)
            {
                FormAutomUtils.SetFocus(hwndGrid2);
                FormAutomUtils.ClickGrid(hwndGrid2, 20, 20);
                Thread.Sleep(500);
                hwndGrid3 = DRAutoDriver.FindLowestBranchesGrid(mainEditBranchesForm);
                System.Console.WriteLine("hwndGrid3(II) = {0}", hwndGrid3);
            }
            IntPtr hwndRollBackBtn = DRAutoDriver.FindRollbackTVBVChanges4TodayButton(mainEditBranchesForm);
            System.Console.WriteLine("hwndRollBackBtn = {0}", hwndRollBackBtn);

            if (hwndGrid2 == IntPtr.Zero || hwndGrid3 == IntPtr.Zero || hwndRollBackBtn == IntPtr.Zero)
            {
                System.Console.WriteLine("Can't find all needed windows");
                return false;
            }
            System.Console.WriteLine("About to enter the loop");
            string prevBranchId = string.Empty;
            string lastBranchId = string.Empty;
            int processIdx = 0;
            do
            {

                FormAutomUtils.SetFocus(hwndGrid2);
                FormAutomUtils.ClickGrid(hwndGrid2, 20, 20);
                Thread.Sleep(500);
                System.Console.WriteLine("Clicked grid2");
                FormAutomUtils.SetFocus(hwndGrid3);
                FormAutomUtils.ClickGrid(hwndGrid3);
                System.Console.WriteLine("Clicked grid3");
                Thread.Sleep(500);
                FormAutomUtils.ClickButton2(hwndRollBackBtn);
                System.Console.WriteLine("Clicked rollback btn");
                Thread.Sleep(300);
                #region deal with confirmation msg boxes
                string cfmDlgCaption = "Підтвердження";
                IntPtr hwndConfirmChangesDlg = FormAutomUtils.WaitForWindow(cfmDlgCaption, "#32770 (Dialog)", drClientProcessId, 7, 250);
                System.Console.WriteLine("Waited for confirm changes dlg (I)");
                if (hwndConfirmChangesDlg == IntPtr.Zero)
                    hwndConfirmChangesDlg = FormAutomUtils.WaitForWindow(cfmDlgCaption, null, drClientProcessId, 7, 250);
                System.Console.WriteLine("Waited for confirm changes dlg (II)");
                System.Console.WriteLine("hwndConfirmChangesDlg = {0}", hwndConfirmChangesDlg);
                if (hwndConfirmChangesDlg == IntPtr.Zero)
                {
                    System.Console.WriteLine("Failed to find confirm changes save dialog");
                }
                else
                {
                    IntPtr hwndYesBtn = FormAutomUtils.WaitForChildWindow(hwndConfirmChangesDlg, "&Так", "Button", 7, 100);
                    System.Console.WriteLine("hwndYesBtn = {0}", hwndYesBtn);
                    if (hwndYesBtn == IntPtr.Zero)
                    {
                        System.Console.WriteLine("Failed to find yes button on confirm changes save dialog");
                    }
                    else
                    {
                        if (bEmulateOnly)
                        {
                            if (pauseBeforeClosing > 0)
                                Thread.Sleep(pauseBeforeClosing);
                            FormAutomUtils.CloseWindow(hwndConfirmChangesDlg);
                            continue;
                        }
                        FormAutomUtils.ClickButton2(hwndYesBtn);
                        System.Console.WriteLine("Clicked hwndYesBtn ");
                        IntPtr hwndChangesSavedOKDlg = FormAutomUtils.WaitForWindow("РЕЄСТР", "TMessageForm", drClientProcessId, 10, 100);
                        System.Console.WriteLine("Waited for REIESTR wnd(I)");
                        if (hwndChangesSavedOKDlg == IntPtr.Zero)
                            hwndChangesSavedOKDlg = FormAutomUtils.WaitForWindow("РЕЄСТР", "MessageForm", drClientProcessId, 10, 100);
                        System.Console.WriteLine("Waited for REIESTR wnd(II)");
                        if (hwndChangesSavedOKDlg == IntPtr.Zero)
                            hwndChangesSavedOKDlg = FormAutomUtils.WaitForWindow("РЕЄСТР", null, drClientProcessId, 10, 100);
                        System.Console.WriteLine("Waited for REIESTR wnd(III)");

                        System.Console.WriteLine("hwndChangesSavedOKDlg = {0}", hwndChangesSavedOKDlg);
                        if (hwndChangesSavedOKDlg == IntPtr.Zero)
                        {
                            System.Console.WriteLine("Failed to find changes saved OK dialog");
                        }
                        else
                        {
                            IntPtr hwndOKBtn = FormAutomUtils.WaitForChildWindow(hwndChangesSavedOKDlg, "OK", "TButton", 7, 50);
                            System.Console.WriteLine("Waited for hwndOKBtn(I)");
                            if (hwndOKBtn == IntPtr.Zero)
                                hwndOKBtn = FormAutomUtils.WaitForChildWindow(hwndChangesSavedOKDlg, "OK", "Button", 7, 50);
                            System.Console.WriteLine("Waited for hwndOKBtn(II)");
                            if (hwndOKBtn == IntPtr.Zero)
                                hwndOKBtn = FormAutomUtils.WaitForChildWindow(hwndChangesSavedOKDlg, "OK", null, 7, 50);
                            System.Console.WriteLine("hwndOKBtn = {0}", hwndOKBtn);
                            System.Console.WriteLine("Waited for hwndOKBtn(III)");
                            if (hwndOKBtn == IntPtr.Zero)
                            {
                                System.Console.WriteLine("Failed to find ok button on changes saved OK dialog");
                            }
                            else
                            {
                                FormAutomUtils.ClickButton2(hwndOKBtn);
                                processIdx++;
                            }
                        }
                    }
                }

                #endregion
                if (maxProcessCount > 0 && processIdx >= maxProcessCount)
                    break;
                Thread.Sleep(1000);

            } while (true);

            return true;
        }

        public static string FormatChangesSummary(TVBVOpsSevicesChangeInfo chgInfo)
        {
            if (chgInfo.DeclaredChangeDate == null)
                return string.Format("{0:dd.MM.yyyy} {1}", chgInfo.ChangeDate, chgInfo.ChangesSummary);
            else
                return string.Format("{0:dd.MM.yyyy} (чинне з {1:dd.MM.yyyy}) {2}", chgInfo.ChangeDate, (DateTime)chgInfo.DeclaredChangeDate, chgInfo.ChangesSummary);
        }

        private static string ReadBranchName(IntPtr hwndBranchEditForm)
        {
            return string.Empty; //todo - implement later
        }

        public static bool ApplyBulkClosure(TVBVsBulkClosureInfo inputInfo, bool bEmulateOnly, int pauseBeforeClosing, int maxProcessCount, out List<TBVBChangeResultInfo> rslts)
        {
            throw new NotImplementedException();
        }

        public static bool ApplyBulkChangesSummaryCorrection(TVBVsOpsSvcBulkChangeInfo changes, bool bEmulateOnly, int pauseBeforeClosing, int maxProcessCount, out List<TBVBChangeResultInfo> results)
        {
            results = new List<TBVBChangeResultInfo>();

            IntPtr mainEditBranchesForm = FormAutomUtils.FindWindow("TBanks_modFm", "Редагування банківських установ");

            if (mainEditBranchesForm == (IntPtr)0)
            {
                System.Console.WriteLine("Can't find main window");

                return false;
            }
            int drClientProcessId = FormAutomUtils.GetWindowProcess(mainEditBranchesForm);
            System.Console.WriteLine("drClientProcessId = {0}", drClientProcessId);
            System.Console.WriteLine("mainEditBranchesForm = {0} ({0:X8})", mainEditBranchesForm);
            if (!FormAutomUtils.SetForegroundWindow(mainEditBranchesForm))
            {
                System.Console.WriteLine("Can't activate main window");
                return false;
            }

            IntPtr hwndGrid = DRAutoDriver.FindLowestBranchesGrid(mainEditBranchesForm);

            System.Console.WriteLine("hwndGrid = {0}", hwndGrid);
            

            string prevBranchId = string.Empty;
            string lastBranchId = string.Empty;
            int processIdx = 0;
            FormAutomUtils.SetFocus(hwndGrid);
            FormAutomUtils.ClickGrid(hwndGrid);
            Thread.Sleep(500);
            do
            {
                if (maxProcessCount > 0 && processIdx >= maxProcessCount)
                    break;

            


                Thread.Sleep(1500); // todo - to shorten
                #region debug-related
                List<WindowInfo> allDRWindows = FormAutomUtils.ListAllWindowsForAProcess(drClientProcessId);
                System.Console.WriteLine("allDRWindows(I):{0}", ToJson(allDRWindows, true));
                #endregion

                FormAutomUtils.PressContextMenuButton2(hwndGrid);

                List<WindowInfo> allWnds = FormAutomUtils.ListAllWindowsForAProcess(drClientProcessId);
                System.Console.WriteLine("allWnds(after contextmenu click): {0}", ToJson(allWnds, true));
                if (changes.Items.Count == 0)
                    break;
                //continue;
                bool bBreak;
                bool bContinue;
                TBVBChangeResultInfo currRslt;
                bool bCurrRslt = ApplyChangesSummaryCorrectionToSingleBranch(changes, bEmulateOnly, pauseBeforeClosing, drClientProcessId, out currRslt, ref lastBranchId, ref prevBranchId, out bBreak, out bContinue);
                if (bBreak)
                    break;
                if (bContinue)
                    continue;
                prevBranchId = lastBranchId;

                results.Add(currRslt);
                processIdx++;
                Thread.Sleep(300);
                FormAutomUtils.FocusAndClickArrowDown(hwndGrid);
                Thread.Sleep(500);
                System.Console.WriteLine("---------------------------------------------------------------------------------------------------------");

            } while (true);

            return true;
        }

        public static bool CorrectChangesSummary(IntPtr hwndChangesSummaryEdit, string oldSummary, string correctedSummary)
        {
            //string accumSummaryValue = FormAutomUtils.GetControlValue2(hwndChangesSummaryEdit);
            //System.Console.WriteLine("accumSummaryValue = '{0}'", accumSummaryValue);
            //string newAccumSummaryValue = null;
            //if (accumSummaryValue.Trim().Length > 0)
            //{
            //    if (accumSummaryValue.IndexOf(oldSummary) != -1)
            //        newAccumSummaryValue = accumSummaryValue.Replace(oldSummary, correctedSummary);
            //}
            //else
            //    newAccumSummaryValue = correctedSummary;
            //System.Console.WriteLine("newAccumSummaryValue = '{0}'", newAccumSummaryValue);
            //FormAutomUtils.SetText2(hwndChangesSummaryEdit, newAccumSummaryValue);
            FormAutomUtils.SetText2(hwndChangesSummaryEdit, correctedSummary);
            return true;
        }


        public static IntPtr FindChangesSummaryCorrectionForm()
        {
            IntPtr rslt = FormAutomUtils.FindWindow("THISTORYForm", "КОРИГУВАННЯ ЗМІН ДО СТАТУТУ(короткий опис змін)");
            if (rslt == IntPtr.Zero)
                rslt = FormAutomUtils.FindWindow(null, "КОРИГУВАННЯ ЗМІН ДО СТАТУТУ(короткий опис змін)");
            return rslt;
        }

        public static bool ApplyChangesSummaryCorrectionToSingleBranch(TVBVsOpsSvcBulkChangeInfo changes, bool bEmulateOnly, int pauseBeforeClosing, int drClientProcessId, out TBVBChangeResultInfo currRslt, ref string lastBranchId, ref string prevBranchId, out bool bBreak, out bool bContinue)
        {
            bBreak = false;
            bContinue = false;

            currRslt = new TBVBChangeResultInfo();
            IntPtr hwndChgsSummaryCorrectionFrm = FindChangesSummaryCorrectionForm();
            if (hwndChgsSummaryCorrectionFrm == IntPtr.Zero)
            {
                System.Console.WriteLine("Failed to find changes correction form");
                bContinue = true;
                return false;
            }

            FormAutomUtils.SetForegroundWindow(hwndChgsSummaryCorrectionFrm);
            System.Console.WriteLine("hwndChgsSummaryCorrectionFrm = {0}", hwndChgsSummaryCorrectionFrm);
            Thread.Sleep(50); // todo - to shorten

            CorrectChangesSummaryFormControlsInfo ctrlsInfo = null;
            int otherTabCtrlsRetries = 0;
            do
            {
                ctrlsInfo = CorrectChangesSummaryFormControlsInfo.Fill(hwndChgsSummaryCorrectionFrm);
                if (ctrlsInfo != null && ctrlsInfo.IsChangesControlsFound)
                    break;
                Thread.Sleep(250); //todo - to shorten further (try reduce sleep while increasing retries count)
                otherTabCtrlsRetries++;
            } while (otherTabCtrlsRetries < 12);

            System.Console.WriteLine("ctrlsInfo = {0}", DRAutoDriver.ToJson(ctrlsInfo, true));

            if (ctrlsInfo == null)
                return false;
            string currIntBranchID = FormAutomUtils.GetWindowCaption(ctrlsInfo.BranchIDEdit);

            lastBranchId = currIntBranchID.Replace(" ", string.Empty).Trim();

            if (prevBranchId == lastBranchId)
            {
                FormAutomUtils.CloseWindow(hwndChgsSummaryCorrectionFrm);
                bBreak = true;
                return false;
            }


            currRslt.BranchID = lastBranchId;
            string lambdaBranchID = currRslt.BranchID;
            System.Console.WriteLine("currIntBranchID = '{0}'", currIntBranchID);
            if (changes.Items.Exists(o => o.BranchID == lambdaBranchID))
            {
                TVBVOpsSevicesChangeInfo currChgInfo = changes.Items.Find(o => o.BranchID == lambdaBranchID);
                currRslt.ParentMFO = currChgInfo.ParentMFO;
                //currRslt.BranchName = DRAutoDriver.ReadBranchName(hwndChgsSummaryCorrectionFrm);

                bool bChgsSummaryFilled = false;


                if (ctrlsInfo != null && ctrlsInfo.IsChangesControlsFound)
                {
                    //bChgsSummaryFilled = DRAutoDriver.FillChangesSummary(null, сtrlsInfo.ChangesSummaryEdit, FormatChangesSummary(currChgInfo));
                    bChgsSummaryFilled = DRAutoDriver.CorrectChangesSummary(ctrlsInfo.ChangesSummaryEdit, currChgInfo.ChangesSummary, FormatChangesSummary(currChgInfo));
                }
                if (!bChgsSummaryFilled)
                {
                    if (bChgsSummaryFilled) { currRslt.ErrorsInfo.Add("Failed to change summary"); currRslt.ErrorsCount++; }
                }

                if (ctrlsInfo.ApplyChangesButton == IntPtr.Zero)
                {

                    currRslt.ErrorsInfo.Add("Failed to find apply changes button");
                    currRslt.ErrorsCount++;
                }
                else
                    Console.WriteLine("ctrlsInfo.ApplyChangesButton = {0}", ctrlsInfo.ApplyChangesButton);
                if (pauseBeforeClosing > 0)
                    Thread.Sleep(pauseBeforeClosing);
                if (bEmulateOnly)
                {
                    if (currRslt.ErrorsCount == 0) currRslt.Succeeded = true;
                    FormAutomUtils.CloseWindow(hwndChgsSummaryCorrectionFrm);
                }
                else
                {
                    if (currRslt.ErrorsCount == 0)
                    {
                        if (ctrlsInfo.ApplyChangesButton != IntPtr.Zero)
                        {
                            System.Console.WriteLine("About to press ctrlsInfo.ApplyChangesButton ....");
                            //FormAutomUtils.ClickButton(wiSaveChangeBtn.Handle); //doesn't work if the app spawns any modal windows
                            FormAutomUtils.ClickButton2(ctrlsInfo.ApplyChangesButton);
                            System.Console.WriteLine("ctrlsInfo.ApplyChangesButton pressed.");

                            //Thread.Sleep(1500);
                            IntPtr hwndChangesSavedOKDlg = FormAutomUtils.WaitForWindow("РЕЄСТР", "TMessageForm", drClientProcessId, 12, 50);
                            System.Console.WriteLine("hwndChangesSavedOKDlg(I) = {0}", hwndChangesSavedOKDlg);
                            if (hwndChangesSavedOKDlg == IntPtr.Zero)
                                hwndChangesSavedOKDlg = FormAutomUtils.WaitForWindow("РЕЄСТР", "MessageForm", drClientProcessId, 12, 50);
                            System.Console.WriteLine("hwndChangesSavedOKDlg(II) = {0}", hwndChangesSavedOKDlg);
                            if (hwndChangesSavedOKDlg == IntPtr.Zero)
                                hwndChangesSavedOKDlg = FormAutomUtils.WaitForWindow("РЕЄСТР", null, drClientProcessId, 10, 100);
                            System.Console.WriteLine("hwndChangesSavedOKDlg(III) = {0}", hwndChangesSavedOKDlg);

                            System.Console.WriteLine("hwndChangesSavedOKDlg = {0}", hwndChangesSavedOKDlg);
                            if (hwndChangesSavedOKDlg == IntPtr.Zero)
                            {
                                currRslt.ErrorsCount++;
                                currRslt.ErrorsInfo.Add("Failed to find changes saved OK dialog");
                            }
                            else
                            {
                                IntPtr hwndOKBtn = 
                                //    FormAutomUtils.WaitForChildWindow(hwndChangesSavedOKDlg, "OK", "TButton", 7, 50);
                                //System.Console.WriteLine("hwndOKBtn(I) = {0}", hwndOKBtn);
                                //if (hwndOKBtn == IntPtr.Zero)
                                //    hwndOKBtn = 
                                        FormAutomUtils.WaitForChildWindow(hwndChangesSavedOKDlg, "OK", "Button", 7, 50);
                                System.Console.WriteLine("hwndOKBtn(II) = {0}", hwndOKBtn);
                                if (hwndOKBtn == IntPtr.Zero)
                                    hwndOKBtn = FormAutomUtils.WaitForChildWindow(hwndChangesSavedOKDlg, "OK", null, 7, 50);
                                System.Console.WriteLine("hwndOKBtn(III) = {0}", hwndOKBtn);

                                System.Console.WriteLine("hwndOKBtn = {0}", hwndOKBtn);
                                if (hwndOKBtn == IntPtr.Zero)
                                {
                                    currRslt.ErrorsCount++;
                                    currRslt.ErrorsInfo.Add("Failed to find ok button on changes saved OK dialog");
                                    System.Console.WriteLine("Failed to find ok button on changes saved OK dialog");
                                }
                                else
                                {
                                    FormAutomUtils.ClickButton(hwndOKBtn);
                                    currRslt.Succeeded = true;
                                    return true;
                                }
                            }

                        }
                    }
                }
            }
            else
            {
                System.Console.WriteLine("Nothing to do with branch # {0}", lastBranchId);
                FormAutomUtils.CloseWindow(hwndChgsSummaryCorrectionFrm);
                return true;
            }
            return false;
        }
        
    }
}
