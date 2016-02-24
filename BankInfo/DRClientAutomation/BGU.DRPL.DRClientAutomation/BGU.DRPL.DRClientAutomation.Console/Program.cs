using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.DRClientAutomationLib;
using BGU.DRPL.DRClientAutomationLib.AuxData;
using System.Threading;
using System.IO;
using BGU.DRPL.DRClientAutomationLib.Data;

namespace BGU.DRPL.DRClientAutomation.Console
{
    class Program
    {
        #region field(s)
        private delegate void CmdHandler(string[] args);
        private static readonly Dictionary<string, CmdHandler> _cmdHandlers;
        #endregion

        #region cctor(s)
        static Program()
        {
            #region CMD handlers

            _cmdHandlers = new Dictionary<string, CmdHandler>();

            #region populate
            _cmdHandlers.Add("openeditbranchformtest", OpenEditBranchFormTest);
            _cmdHandlers.Add("findwindowtest", FindWindowTest);
            _cmdHandlers.Add("findandclosebrancheditwindow", FindAndCloseBranchEditWindow);
            _cmdHandlers.Add("openandclosebrancheditwindow", OpenAndCloseBranchEditWindow);
            _cmdHandlers.Add("clickparameterstabltest", ClickParametersTablTest);
            _cmdHandlers.Add("clickparameterstabtest2", ClickParametersTabTest2);
            _cmdHandlers.Add("clickparameterstabtest3", ClickParametersTabTest3);
            _cmdHandlers.Add("clickparameterstabtest4", ClickParametersTabTest4);
            _cmdHandlers.Add("clickparameterstabtest5", ClickParametersTabTest5);
            _cmdHandlers.Add("readbranchidtest", ReadBranchIDTest);
            _cmdHandlers.Add("readchangessummarytest", ReadChangesSummaryTest);
            _cmdHandlers.Add("listchildcontrolstest", ListChildControlsTest);
            _cmdHandlers.Add("fillpaydocnrtest", FillPayDocNrTest);
            _cmdHandlers.Add("fillchangessummarytest", FillChangesSummaryTest);
            _cmdHandlers.Add("fillchangesdatetest", FillChangesDateTest);
            _cmdHandlers.Add("editbranchformothertabcontrolsinfofilltest", EditBranchFormOtherTabControlsInfoFillTest);
            _cmdHandlers.Add("applybulkopssvcschanges", ApplyBulkOpsSvcsChanges);
            _cmdHandlers.Add("createemptyopssvcschangefile", CreateEmptyOpsSvcsChangeFile);
            _cmdHandlers.Add("resultstabfiletimeseedtest", ResultsTabFileTimeSeedTest);
            _cmdHandlers.Add("readbulkclosureinfostest", ReadBulkClosureInfosTest);
            _cmdHandlers.Add("applybulkchangessummarycorrection", ApplyBulkChangesSummaryCorrection);
            _cmdHandlers.Add("presscontextmenubutton2test", PressContextMenuButton2Test);
            _cmdHandlers.Add("applychangessummarycorrectiontosinglebranchtest", ApplyChangesSummaryCorrectionToSingleBranchTest);
            _cmdHandlers.Add("applychangessummarycorrectionbulk", ApplyChangesSummaryCorrectionBulk);
            _cmdHandlers.Add("rollbackallchangesfortoday", RollbackAllChangesForToday);
            #endregion


            #endregion
        }
        #endregion

        static void Main(string[] args)
        {
            System.Console.Read();

            string cmdHandlerKey = string.Empty;
            if (args.Length > 0)
                cmdHandlerKey = args[0].ToLower();
            try
            {
                if (string.IsNullOrEmpty(cmdHandlerKey) || !_cmdHandlers.ContainsKey(cmdHandlerKey))
                    return;
                else
                    _cmdHandlers[cmdHandlerKey](args);
            }
            catch (Exception exc)
            {
                System.Console.WriteLine(exc.ToString());
            }

        }

        private static void OpenEditBranchFormTest(string[] args)
        {
            IntPtr mainEditBranchesForm = FormAutomUtils.FindWindow("TBanks_modFm", "Редагування банківських установ");
            if (mainEditBranchesForm == (IntPtr)0)
            {
                System.Console.WriteLine("Can't find main window");
                
                return;
            }

            System.Console.WriteLine("mainEditBranchesForm = {0} ({0:X8})", mainEditBranchesForm);

            IntPtr hwndGrid = DRAutoDriver.FindLowestBranchesGrid(mainEditBranchesForm);
            
            System.Console.WriteLine("hwndGrid = {0}", hwndGrid);
            IntPtr hwnEditTvbvBtn = DRAutoDriver.FindEditTVBVButton(mainEditBranchesForm);
            System.Console.WriteLine("hwnEditTvbvBtn = {0}", hwnEditTvbvBtn);
            if (hwndGrid == IntPtr.Zero || hwnEditTvbvBtn == IntPtr.Zero)
            {
                System.Console.WriteLine("Can't find all needed windows");
                return;
            }

            for (int i = 0; i < 3; i++)
            {
                FormAutomUtils.SetFocus(hwndGrid);
                FormAutomUtils.ClickGrid(hwndGrid);
                FormAutomUtils.ClickButton2(hwnEditTvbvBtn);
                Thread.Sleep(1500);
                IntPtr hwndBranchEditForm = FormAutomUtils.FindWindow("TVIDDIL_CLASSForm_2", null);
                System.Console.WriteLine("hwndBranchEditForm = {0}", hwndBranchEditForm);
                Thread.Sleep(2000);
                string currIntBranchID = DRAutoDriver.ReadBranchID(hwndBranchEditForm);
                System.Console.WriteLine("currIntBranchID = '{0}'", currIntBranchID);
                //string changesSummary = String.Format("Постанова правління, зміни обсягу та переліку операцій) # {0}", i);
                string changesSummary = String.Format("Operations and services listing and volume change, ruling of the board # {0}", i);
                DateTime changesDate = DateTime.Parse("2015-11-02T00:00:00");

                WindowInfo wiOtherTab = DRAutoDriver.OpenOtherTab(hwndBranchEditForm);
                if (wiOtherTab == null)
                    System.Console.WriteLine("wiOtherTab is null");
                else
                {
                    //List<WindowInfo> wiOtherTabCtrls = FormAutomUtils.ListChildControls(wiOtherTab.Handle);
                    //System.Console.WriteLine("wiOtherTabCtrls = {0}", DRAutoDriver.ToJson(wiOtherTabCtrls, true));
                    //var groupBoxes = from c in wiOtherTabCtrls where c.WndClass == "TGroupBox" select c;
                    //int g=0;
                    //foreach (var groupBox in groupBoxes)
                    //{
                    //    System.Console.WriteLine("wiOtherTabCtrls.groupBoxes[{0}] = {1}", g, DRAutoDriver.ToJson(FormAutomUtils.ListChildControls(((WindowInfo)groupBox).Handle), true));
                    //    g++;
                    //}

                    EditBranchFormOtherTabControlsInfo tabCtrlsInfo; 
                    int otherTabCtrlsRetries = 0;
                    do
                    {
                        tabCtrlsInfo = EditBranchFormOtherTabControlsInfo.Fill(wiOtherTab.Handle);
                        if (tabCtrlsInfo != null && tabCtrlsInfo.IsChangesControlsFound)
                            break;
                        Thread.Sleep(250);
                        otherTabCtrlsRetries++;
                    } while (otherTabCtrlsRetries < 4);

                    System.Console.WriteLine("tabCtrlsInfo = {0}", DRAutoDriver.ToJson(tabCtrlsInfo, true));

                    if (!DRAutoDriver.FillPayDocNr(wiOtherTab, "11/plat/3024"))
                        System.Console.WriteLine("Failed to change payment doc nr");
                    bool bChgsSummaryFilled = false;

                    if (tabCtrlsInfo != null && tabCtrlsInfo.IsChangesControlsFound)
                    {
                        bChgsSummaryFilled = DRAutoDriver.FillChangesSummary(null, tabCtrlsInfo.ChangesSummaryEdit, changesSummary);
                        DRAutoDriver.FillChangesDate(null, tabCtrlsInfo.ChangesDate, changesDate);
                    }
                    else
                        bChgsSummaryFilled = DRAutoDriver.FillChangesSummary(wiOtherTab, changesSummary);
                    if (!bChgsSummaryFilled)
                        System.Console.WriteLine("Failed to change summary");
                    Thread.Sleep(2000);
                }
                FormAutomUtils.CloseWindow(hwndBranchEditForm);
                Thread.Sleep(300);
                FormAutomUtils.FocusAndClickArrowDown(hwndGrid);
                Thread.Sleep(500);
                System.Console.WriteLine("---------------------------------------------------------------------------------------------------------");
            }
            
            
        }

        private static void FindWindowTest(string[] args)
        {
            IntPtr hwnd = FormAutomUtils.FindWindow(args[1], args[2]);
            System.Console.WriteLine(hwnd);
        }

        private static void FindAndCloseBranchEditWindow(string[] args)
        {
            Thread.Sleep(3000);
            IntPtr hwndBranchEditForm = FormAutomUtils.FindWindow("TVIDDIL_CLASSForm_2", null);
            System.Console.WriteLine("hwndBranchEditForm = {0}", hwndBranchEditForm);
            Thread.Sleep(2000);
            FormAutomUtils.CloseWindow(hwndBranchEditForm);
        }

        private static void OpenAndCloseBranchEditWindow(string[] args)
        {
            System.Console.WriteLine("About to sleep 3 sec");
            Thread.Sleep(3000);
            System.Console.WriteLine("Slept 3 sec");

            IntPtr mainEditBranchesForm = FormAutomUtils.FindWindow("TBanks_modFm", "Редагування банківських установ");
            if (mainEditBranchesForm == (IntPtr)0)
            {
                System.Console.WriteLine("Can't find main window");
                return;
            }

            System.Console.WriteLine("mainEditBranchesForm = {0} ({0:X})", mainEditBranchesForm);
            IntPtr hwndGrid = DRAutoDriver.FindLowestBranchesGrid(mainEditBranchesForm);

            System.Console.WriteLine("hwndGrid = {0}", hwndGrid);
            IntPtr hwnEditTvbvBtn = DRAutoDriver.FindEditTVBVButton(mainEditBranchesForm);
            System.Console.WriteLine("hwnEditTvbvBtn = {0}", hwnEditTvbvBtn);
            if (hwndGrid == IntPtr.Zero || hwnEditTvbvBtn == IntPtr.Zero)
            {
                System.Console.WriteLine("Can't find all needed windows");
                return;
            }
            System.Console.WriteLine("Clicking the button");
            FormAutomUtils.ClickButton2(hwnEditTvbvBtn);
            System.Console.WriteLine("Clicked the button");
            Thread.Sleep(1500);
            System.Console.WriteLine("Slept 1.5 sec");
            IntPtr hwndBranchEditForm = FormAutomUtils.FindWindow("TVIDDIL_CLASSForm_2", null);
            System.Console.WriteLine("hwndBranchEditForm = {0}", hwndBranchEditForm);
            Thread.Sleep(2000);
            System.Console.WriteLine("Slept 2 sec, about to close the branch edit window");
            FormAutomUtils.CloseWindow(hwndBranchEditForm);
            Thread.Sleep(300);
        }

        private static void ClickParametersTablTest(string[] args)
        {

            IntPtr hwndBranchEditForm = FormAutomUtils.FindWindow("TVIDDIL_CLASSForm_2", null);
            System.Console.WriteLine("hwndBranchEditForm = {0}", hwndBranchEditForm);

            WindowInfo wiParamsSubTab = FormAutomUtils.FindChildWindowCaptionEquals(hwndBranchEditForm, "Параметри", "TTabSheet");
            if (wiParamsSubTab == null)
            {
                System.Console.WriteLine("Can't find wiParamsSubTab");
                return;
            }
            FormAutomUtils.SetFocus(wiParamsSubTab.Handle);
            FormAutomUtils.ClickButton2(wiParamsSubTab.Handle);
            System.Console.WriteLine("wiParamsSubTab.Handle = {0} ({0:X8})", wiParamsSubTab.Handle);
            //FormAutomUtils.ClickButton(wiParamsSubTab.Handle);
            
            //FormAutomUtils.DoMouseClick();

        }

        private static void ClickParametersTabTest2(string[] args)
        {

            IntPtr hwndBranchEditForm = FormAutomUtils.FindWindow("TVIDDIL_CLASSForm_2", null);
            System.Console.WriteLine("hwndBranchEditForm = {0}", hwndBranchEditForm);

            WindowInfo wiParamsSubTab = FormAutomUtils.FindChildWindowCaptionEquals(hwndBranchEditForm, "Назви", "TTabSheet");
            if (wiParamsSubTab == null)
            {
                System.Console.WriteLine("Can't find wiParamsSubTab");
                return;
            }
            System.Console.WriteLine("wiParamsSubTab.Handle = {0} ({0:X8})", wiParamsSubTab.Handle);
            FormAutomUtils.FocusAndClickArrowRight(wiParamsSubTab.Handle);
            
            //FormAutomUtils.ClickButton(wiParamsSubTab.Handle);

            //FormAutomUtils.DoMouseClick();

        }

        private static void ClickParametersTabTest3(string[] args)
        {

            IntPtr hwndBranchEditForm = FormAutomUtils.FindWindow("TVIDDIL_CLASSForm_2", null);
            System.Console.WriteLine("hwndBranchEditForm = {0}", hwndBranchEditForm);

            WindowInfo wiParamsSubTab = FormAutomUtils.FindChildWindowCaptionEquals(hwndBranchEditForm, "Параметри", "TTabSheet");
            if (wiParamsSubTab == null)
            {
                System.Console.WriteLine("Can't find wiParamsSubTab");
                return;
            }
            System.Console.WriteLine("wiParamsSubTab.Handle = {0} ({0:X8})", wiParamsSubTab.Handle);
            FormAutomUtils.FocusAndClickSpace(wiParamsSubTab.Handle);

            //FormAutomUtils.ClickButton(wiParamsSubTab.Handle);

            //FormAutomUtils.DoMouseClick();

        }

        private static void ClickParametersTabTest4(string[] args)
        {

            IntPtr hwndBranchEditForm = FormAutomUtils.FindWindow("TVIDDIL_CLASSForm_2", null);
            System.Console.WriteLine("hwndBranchEditForm = {0}", hwndBranchEditForm);

            WindowInfo wiParamsSubTab = FormAutomUtils.FindChildWindowCaptionEquals(hwndBranchEditForm, "Параметри", "TTabSheet");
            if (wiParamsSubTab == null)
            {
                System.Console.WriteLine("Can't find wiParamsSubTab");
                return;
            }
            System.Console.WriteLine("wiParamsSubTab.Handle = {0} ({0:X8})", wiParamsSubTab.Handle);
            FormAutomUtils.ClickTab(wiParamsSubTab.Handle);

            //FormAutomUtils.ClickButton(wiParamsSubTab.Handle);

            //FormAutomUtils.DoMouseClick();

        }

        private static void ClickParametersTabTest5(string[] args)
        {
            const int xCorrDefault = 0;
            const int yCorrDefault = 0;

            int xCorr; int yCorr;
            if (args.Length >= 3)
            {
                string xCorrStr = args[1];
                string yCorrStr = args[2];
                if (!int.TryParse(xCorrStr, out xCorr))
                    xCorr = xCorrDefault;
                if (!int.TryParse(yCorrStr, out yCorr))
                    yCorr = yCorrDefault;
            }
            else
            {
                xCorr = xCorrDefault; yCorr = yCorrDefault;
            }

            IntPtr hwndBranchEditForm = FormAutomUtils.FindWindow("TVIDDIL_CLASSForm_2", null);
            System.Console.WriteLine("hwndBranchEditForm = {0}", hwndBranchEditForm);

            WindowInfo wiParamsSubTab = FormAutomUtils.FindChildWindowCaptionEquals(hwndBranchEditForm, "Параметри", "TTabSheet");
            if (wiParamsSubTab == null)
            {
                System.Console.WriteLine("Can't find wiParamsSubTab");
                return;
            }
            System.Console.WriteLine("wiParamsSubTab.Handle = {0} ({0:X8})", wiParamsSubTab.Handle);
            FormAutomUtils.ClickTab(wiParamsSubTab.Handle, xCorr, yCorr);

            //FormAutomUtils.ClickButton(wiParamsSubTab.Handle);

            //FormAutomUtils.DoMouseClick();

        }

        private static void ReadBranchIDTest(string[] args)
        {
            IntPtr hwndBranchEditForm = FormAutomUtils.FindWindow("TVIDDIL_CLASSForm_2", null);
            System.Console.WriteLine("hwndBranchEditForm = {0}", hwndBranchEditForm);
            Thread.Sleep(2000);
            string currIntBranchID = DRAutoDriver.ReadBranchID(hwndBranchEditForm);
            System.Console.WriteLine("currIntBranchID = '{0}'", currIntBranchID);
            FormAutomUtils.CloseWindow(hwndBranchEditForm);
        }

        private static void ReadChangesSummaryTest(string[] args)
        {
            IntPtr hwndBranchEditForm = FormAutomUtils.FindWindow("TVIDDIL_CLASSForm_2", null);
            System.Console.WriteLine("hwndBranchEditForm = {0}", hwndBranchEditForm);
            Thread.Sleep(2000);
            string smryTxt = DRAutoDriver.ReadChangesSummary(hwndBranchEditForm);
            System.Console.WriteLine("smryTxt = '{0}'", smryTxt);
            //FormAutomUtils.CloseWindow(hwndBranchEditForm);
        }

        private static void ListChildControlsTest(string[] args)
        {
            List<WindowInfo> rslt;

            if (args.Length > 1)
            {
                long hwnd = long.Parse(args[1],System.Globalization.NumberStyles.HexNumber);
                rslt = FormAutomUtils.ListChildControls((IntPtr)hwnd);
            }
            else
            {
                IntPtr mainEditBranchesForm = FormAutomUtils.FindWindow("TBanks_modFm", "Редагування банківських установ");
                if (mainEditBranchesForm == (IntPtr)0)
                {
                    System.Console.WriteLine("Can't find main window");
                    return;
                }
                rslt = FormAutomUtils.ListChildControls(mainEditBranchesForm);
            }
            System.Console.WriteLine(DRAutoDriver.ToJson(rslt , true));
        }

        private static void FillPayDocNrTest(string[] args)
        {
            long hwnd = long.Parse(args[1],System.Globalization.NumberStyles.HexNumber);
            string txt = args[2];
            DRAutoDriver.FillPayDocNr(new WindowInfo() { Handle = (IntPtr)hwnd }, txt);
        }

        private static void FillChangesSummaryTest(string[] args)
        {
            long hwnd = long.Parse(args[1],System.Globalization.NumberStyles.HexNumber);
            string txt = args[2];
            DRAutoDriver.FillChangesSummary(new WindowInfo() { Handle = (IntPtr)hwnd }, txt);
        }


        private static void FillChangesDateTest(string[] args)
        {
            long hwnd = long.Parse(args[1],System.Globalization.NumberStyles.HexNumber);
            string txt = args[2];
            DRAutoDriver.FillChangesDate(null, (IntPtr)hwnd, DateTime.Parse(txt));
        }


        private static void EditBranchFormOtherTabControlsInfoFillTest(string[] args)
        {
            long hwnd = long.Parse(args[1],System.Globalization.NumberStyles.HexNumber);
            EditBranchFormOtherTabControlsInfo rslt = EditBranchFormOtherTabControlsInfo.Fill((IntPtr)hwnd);

            System.Console.WriteLine(DRAutoDriver.ToJson(rslt, true));
        }

        private static void CreateEmptyOpsSvcsChangeFile(string[] args)
        {
            string inputXmlPath = args[1];
            TVBVsOpsSvcBulkChangeInfo rslt = new TVBVsOpsSvcBulkChangeInfo();
            rslt.Items = new List<TVBVOpsSevicesChangeInfo>();
            rslt.Items.Add(new TVBVOpsSevicesChangeInfo() { BranchID = "00626804103608000000" , ChangeDate = DateTime.Parse("02.11.2015"), ChangesSummary = "зміни обсягів та переліку операцій та послуг, схема A, згідно постанови правління АТ «Ощадбанк» від «07» жовтня 2015 року № 910" });
            Tools.WriteXML<TVBVsOpsSvcBulkChangeInfo>( rslt, inputXmlPath);
        }

        private static void ApplyBulkOpsSvcsChanges(string[] args)
        {
            string inputXmlPath = args[1];
            int pauseBeforeClosing;  //2
            bool bEmulateOnly;       //3
            int maxProcessCount;     //4
            string parentMFO = null;
            string skipBranchesIDsFile = null;
            
            if(args.Length > 2)
            {
                string pauseBeforeClosingStr = args[2];
                if (!int.TryParse(pauseBeforeClosingStr, out pauseBeforeClosing))
                    pauseBeforeClosing = 0;
            }
            else
                pauseBeforeClosing = 0;

            if (args.Length > 3)
            {
                string bEmulateOnlyStr = args[3];
                if (!bool.TryParse(bEmulateOnlyStr, out bEmulateOnly))
                    bEmulateOnly = true;
            }
            else
                bEmulateOnly = true;

            if (args.Length > 4)
            {
                string maxProcessCountStr = args[4];
                if (!int.TryParse(maxProcessCountStr, out maxProcessCount))
                    maxProcessCount = 0;
            }
            else
                maxProcessCount = 0;
            if (args.Length > 5)
                parentMFO = args[5];

            if (args.Length > 6)
                skipBranchesIDsFile = args[6];
            

            if (!File.Exists(inputXmlPath))
            {
                System.Console.WriteLine("File doesn't exists - '{0}'", inputXmlPath);
                return;
            }

            TVBVsOpsSvcBulkChangeInfo inputInfo = Tools.ReadXML<TVBVsOpsSvcBulkChangeInfo>(inputXmlPath);
            if (!string.IsNullOrEmpty(parentMFO))
            {
                var filtered = from ii in inputInfo.Items where ii.ParentMFO == parentMFO select ii;
                inputInfo.Items = new List<TVBVOpsSevicesChangeInfo>();
                inputInfo.Items.AddRange(filtered);
            }
            if (!string.IsNullOrEmpty(skipBranchesIDsFile) && File.Exists(skipBranchesIDsFile))
            {
                List<string> skipBranchIDs = new List<string>(File.ReadAllLines(skipBranchesIDsFile));
                for(int i = 0;i<skipBranchIDs.Count; i++)
                    skipBranchIDs[i] = skipBranchIDs[i].Trim();
                List<TVBVOpsSevicesChangeInfo> woSkippedItems = new List<TVBVOpsSevicesChangeInfo>();
                foreach(TVBVOpsSevicesChangeInfo ci in inputInfo.Items)
                {
                    if (skipBranchIDs.Contains(ci.BranchID))
                        continue;
                    woSkippedItems.Add(ci);
                }
                inputInfo.Items = woSkippedItems;
            }

            List<TBVBChangeResultInfo> rslts;

            DateTime dtStart = DateTime.Now;
            System.Console.WriteLine("Started: {0}", dtStart);
            TVBVOpsSevicesChangeInfo.CheckCorrectChangeDates(inputInfo.Items);
            if (!DRAutoDriver.ApplyBulkOpsSvcChange(inputInfo, bEmulateOnly, pauseBeforeClosing, maxProcessCount, out rslts))
            {
                System.Console.WriteLine("Failed applying bulk change as a whole");
                return;
            }
            else
            {
                List<TVBVOpsSevicesChangeInfo> notFoundBranches = new List<TVBVOpsSevicesChangeInfo>();
                foreach (TVBVOpsSevicesChangeInfo branch in inputInfo.Items)
                {
                    if (!rslts.Exists(b => b.BranchID == branch.BranchID))
                        notFoundBranches.Add(branch);
                }

                var failures = from r in rslts
                               where r.Succeeded == false
                                   select r;
                var succeesses= from r in rslts
                               where r.Succeeded == true
                                   select r;
                System.Console.WriteLine("Succeeded = {0}, Failed = {1}, Not found = {2}", succeesses.Count(), failures.Count(), notFoundBranches.Count);
                System.Console.WriteLine("-------------------------------------------------------------------------------------------");
                System.Console.WriteLine("Successful: \n {0}", DRAutoDriver.ToJson(succeesses, true));
                System.Console.WriteLine("-------------------------------------------------------------------------------------------");
                System.Console.WriteLine("Failed: \n {0}", DRAutoDriver.ToJson(failures, true));
                System.Console.WriteLine("-------------------------------------------------------------------------------------------");
                System.Console.WriteLine("Not found: \n {0}", DRAutoDriver.ToJson(notFoundBranches, true));
                System.Console.WriteLine("-------------------------------------------------------------------------------------------");
                DateTime dtEnd = DateTime.Now;
                System.Console.WriteLine("Finished: {0}", dtEnd);
                System.Console.WriteLine("Completed in {0}", (TimeSpan)(dtEnd-dtStart));
                System.Console.WriteLine("===========================================================================================");

                string resultsTabFileTimeSeed = dtStart.ToString("yyyyMMdd_hhmmss");
                PrintTBVBChangeResultInfo(rslts, string.Format("ApplyBulkOpsSvcsChanges_{0}.{1}.{2}.rslts.txt", (bEmulateOnly ? "Emul" : "Write"), resultsTabFileTimeSeed, parentMFO));
                PrintTBVBChangeNotFoundsInfo(notFoundBranches, string.Format("ApplyBulkOpsSvcsChanges_{0}.{1}.{2}.notFound.txt", (bEmulateOnly ? "Emul" : "Write"), resultsTabFileTimeSeed, parentMFO));
            }
        }

        private static void RollbackAllChangesForToday(string[] args)
        {
            int pauseBeforeClosing;  //1
            bool bEmulateOnly;       //2
            int maxProcessCount;     //3

            if (args.Length > 1)
            {
                string pauseBeforeClosingStr = args[1];
                if (!int.TryParse(pauseBeforeClosingStr, out pauseBeforeClosing))
                    pauseBeforeClosing = 0;
            }
            else
                pauseBeforeClosing = 0;

            if (args.Length > 2)
            {
                string bEmulateOnlyStr = args[2];
                if (!bool.TryParse(bEmulateOnlyStr, out bEmulateOnly))
                    bEmulateOnly = true;
            }
            else
                bEmulateOnly = true;

            if (args.Length > 3)
            {
                string maxProcessCountStr = args[3];
                if (!int.TryParse(maxProcessCountStr, out maxProcessCount))
                    maxProcessCount = 0;
            }
            else
                maxProcessCount = 0;

            DateTime dtStart = DateTime.Now;
            System.Console.WriteLine("Started: {0}", dtStart);
            if (!DRAutoDriver.RollbackAllChangesForToday(bEmulateOnly, pauseBeforeClosing, maxProcessCount))
            {
                System.Console.WriteLine("Failed to roll back change in bulk as a whole");
            }
            else
                System.Console.WriteLine("Roll back change in bulk succeeded");
        }

        private static void PrintTBVBChangeResultInfo(List<TBVBChangeResultInfo> rslts, string fileName)
        {
            using(StreamWriter sw = new StreamWriter(fileName, false, Encoding.Unicode))
            {
                sw.WriteLine("ParentMFO\tBranchID\tBranchName\tSucceeded\tErrorsCount\tErrorsInfo");
                foreach (TBVBChangeResultInfo cr in rslts)
                {
                    sw.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", cr.ParentMFO, cr.BranchID, cr.BranchName, cr.Succeeded, cr.ErrorsCount, string.Join("|", cr.ErrorsInfo.ToArray()));
                }
            }
        }

        private static void PrintTBVBChangeNotFoundsInfo(List<TVBVOpsSevicesChangeInfo> notFoundBranches, string fileName)
        {
            using (StreamWriter sw = new StreamWriter(fileName, false, Encoding.Unicode))
            {
                sw.WriteLine("ParentMFO\tBranchID\tChangeDate\tChangesSummary");
                foreach (TVBVOpsSevicesChangeInfo ci in notFoundBranches)
                {
                    sw.WriteLine("{0}\t{1}\t{2}\t{3}", ci.ParentMFO, ci.BranchID, ci.ChangeDate, ci.ChangesSummary);
                }
            }
        }

        private static void ResultsTabFileTimeSeedTest(string[] args)
        {
            System.Console.WriteLine(DateTime.Now.ToString("yyyyMMdd_hhmmss"));
        }

        private static void ReadBulkClosureInfosTest(string[] args)
        {
            string inputXmlPath = args[1];
            TVBVsBulkClosureInfo inputInfo = Tools.ReadXML<TVBVsBulkClosureInfo>(inputXmlPath);
            System.Console.WriteLine("inputInfo.Items.Count = {0}", inputInfo.Items.Count);
        }

        private static void ApplyBulkClosure(string[] args)
        {
            string inputXmlPath = args[1];
            int pauseBeforeClosing;  //2
            bool bEmulateOnly;       //3
            int maxProcessCount;     //4
            string parentMFO = null;
            string skipBranchesIDsFile = null;

            #region input args read-out
            if (args.Length > 2)
            {
                string pauseBeforeClosingStr = args[2];
                if (!int.TryParse(pauseBeforeClosingStr, out pauseBeforeClosing))
                    pauseBeforeClosing = 0;
            }
            else
                pauseBeforeClosing = 0;

            if (args.Length > 3)
            {
                string bEmulateOnlyStr = args[3];
                if (!bool.TryParse(bEmulateOnlyStr, out bEmulateOnly))
                    bEmulateOnly = true;
            }
            else
                bEmulateOnly = true;

            if (args.Length > 4)
            {
                string maxProcessCountStr = args[4];
                if (!int.TryParse(maxProcessCountStr, out maxProcessCount))
                    maxProcessCount = 0;
            }
            else
                maxProcessCount = 0;
            if (args.Length > 5)
                parentMFO = args[5];

            if (args.Length > 6)
                skipBranchesIDsFile = args[6];

            #endregion

            if (!File.Exists(inputXmlPath))
            {
                System.Console.WriteLine("File doesn't exists - '{0}'", inputXmlPath);
                return;
            }

            TVBVsBulkClosureInfo inputInfo = Tools.ReadXML<TVBVsBulkClosureInfo>(inputXmlPath);
            if (!string.IsNullOrEmpty(parentMFO))
            {
                var filtered = from ii in inputInfo.Items where ii.ParentMFO == parentMFO select ii;
                inputInfo.Items = new List<TVBVClosureInfo>();
                inputInfo.Items.AddRange(filtered);
            }
            if (!string.IsNullOrEmpty(skipBranchesIDsFile) && File.Exists(skipBranchesIDsFile))
            {
                List<string> skipBranchIDs = new List<string>(File.ReadAllLines(skipBranchesIDsFile));
                for (int i = 0; i < skipBranchIDs.Count; i++)
                    skipBranchIDs[i] = skipBranchIDs[i].Trim();
                List<TVBVClosureInfo> woSkippedItems = new List<TVBVClosureInfo>();

                foreach (TVBVClosureInfo ci in inputInfo.Items)
                {
                    if (skipBranchIDs.Contains(ci.BranchID))
                        continue;
                    woSkippedItems.Add(ci);
                }
                inputInfo.Items = woSkippedItems;
            }

            List<TBVBChangeResultInfo> rslts;

            DateTime dtStart = DateTime.Now;
            System.Console.WriteLine("Started: {0}", dtStart);
            if (!DRAutoDriver.ApplyBulkClosure(inputInfo, bEmulateOnly, pauseBeforeClosing, maxProcessCount, out rslts))
            {
                System.Console.WriteLine("Failed applying bulk closure as a whole");
                return;
            }
            else
            {
                List<TVBVClosureInfo> notFoundBranches = new List<TVBVClosureInfo>();
                foreach (TVBVClosureInfo branch in inputInfo.Items)
                {
                    if (!rslts.Exists(b => b.BranchID == branch.BranchID))
                        notFoundBranches.Add(branch);
                }

                var failures = from r in rslts
                               where r.Succeeded == false
                               select r;
                var succeesses = from r in rslts
                                 where r.Succeeded == true
                                 select r;
                System.Console.WriteLine("Succeeded = {0}, Failed = {1}, Not found = {2}", succeesses.Count(), failures.Count(), notFoundBranches.Count);
                System.Console.WriteLine("-------------------------------------------------------------------------------------------");
                System.Console.WriteLine("Successful: \n {0}", DRAutoDriver.ToJson(succeesses, true));
                System.Console.WriteLine("-------------------------------------------------------------------------------------------");
                System.Console.WriteLine("Failed: \n {0}", DRAutoDriver.ToJson(failures, true));
                System.Console.WriteLine("-------------------------------------------------------------------------------------------");
                System.Console.WriteLine("Not found: \n {0}", DRAutoDriver.ToJson(notFoundBranches, true));
                System.Console.WriteLine("-------------------------------------------------------------------------------------------");
                DateTime dtEnd = DateTime.Now;
                System.Console.WriteLine("Finished: {0}", dtEnd);
                System.Console.WriteLine("Completed in {0}", (TimeSpan)(dtEnd - dtStart));
                System.Console.WriteLine("===========================================================================================");

                string resultsTabFileTimeSeed = dtStart.ToString("yyyyMMdd_hhmmss");
                PrintTBVBChangeResultInfo(rslts, string.Format("ApplyBulkOpsSvcsChanges_{0}.{1}.{2}.rslts.txt", (bEmulateOnly ? "Emul" : "Write"), resultsTabFileTimeSeed, parentMFO));
                PrintTBVBChangeNotFoundsInfo(notFoundBranches, string.Format("ApplyBulkOpsSvcsChanges_{0}.{1}.{2}.notFound.txt", (bEmulateOnly ? "Emul" : "Write"), resultsTabFileTimeSeed, parentMFO));
            }
        }

        private static void PrintTBVBChangeNotFoundsInfo(List<TVBVClosureInfo> notFoundBranches, string fileName)
        {
            using (StreamWriter sw = new StreamWriter(fileName, false, Encoding.Unicode))
            {
                sw.WriteLine("ParentMFO\tBranchID\tChangeDate\tChangesSummary");
                foreach (TVBVClosureInfo ci in notFoundBranches)
                {
                    sw.WriteLine("{0}\t{1}\t{2}\t{3}", ci.ParentMFO, ci.BranchID, ci.ChangeDate, ci.ChangesSummary); //todo - other closure fields
                }
            }
        }

        private static void ApplyBulkChangesSummaryCorrection(string[] args)
        {
            string inputXmlPath = args[1];
            int pauseBeforeClosing;            //2
            bool bEmulateOnly;                 //3
            int maxProcessCount;               //4
            string parentMFO = null;           //5
            string skipBranchesIDsFile = null; //6
            
            if(args.Length > 2)
            {
                string pauseBeforeClosingStr = args[2];
                if (!int.TryParse(pauseBeforeClosingStr, out pauseBeforeClosing))
                    pauseBeforeClosing = 0;
            }
            else
                pauseBeforeClosing = 0;

            if (args.Length > 3)
            {
                string bEmulateOnlyStr = args[3];
                if (!bool.TryParse(bEmulateOnlyStr, out bEmulateOnly))
                    bEmulateOnly = true;
            }
            else
                bEmulateOnly = true;

            if (args.Length > 4)
            {
                string maxProcessCountStr = args[4];
                if (!int.TryParse(maxProcessCountStr, out maxProcessCount))
                    maxProcessCount = 0;
            }
            else
                maxProcessCount = 0;
            if (args.Length > 5)
                parentMFO = args[5];

            if (args.Length > 6)
                skipBranchesIDsFile = args[6];
            

            if (!File.Exists(inputXmlPath))
            {
                System.Console.WriteLine("File doesn't exists - '{0}'", inputXmlPath);
                return;
            }

            TVBVsOpsSvcBulkChangeInfo inputInfo = Tools.ReadXML<TVBVsOpsSvcBulkChangeInfo>(inputXmlPath);
            if (!string.IsNullOrEmpty(parentMFO))
            {
                var filtered = from ii in inputInfo.Items where ii.ParentMFO == parentMFO select ii;
                inputInfo.Items = new List<TVBVOpsSevicesChangeInfo>();
                inputInfo.Items.AddRange(filtered);
            }
            if (!string.IsNullOrEmpty(skipBranchesIDsFile) && File.Exists(skipBranchesIDsFile))
            {
                List<string> skipBranchIDs = new List<string>(File.ReadAllLines(skipBranchesIDsFile));
                for(int i = 0;i<skipBranchIDs.Count; i++)
                    skipBranchIDs[i] = skipBranchIDs[i].Trim();
                List<TVBVOpsSevicesChangeInfo> woSkippedItems = new List<TVBVOpsSevicesChangeInfo>();
                foreach(TVBVOpsSevicesChangeInfo ci in inputInfo.Items)
                {
                    if (skipBranchIDs.Contains(ci.BranchID))
                        continue;
                    woSkippedItems.Add(ci);
                }
                inputInfo.Items = woSkippedItems;
            }

            List<TBVBChangeResultInfo> rslts;

            DateTime dtStart = DateTime.Now;
            System.Console.WriteLine("Started: {0}", dtStart);
            if (!DRAutoDriver.ApplyBulkChangesSummaryCorrection(inputInfo, bEmulateOnly, pauseBeforeClosing, maxProcessCount, out rslts))
            {
                System.Console.WriteLine("Failed applying bulk change as a whole");
                return;
            }
            else
            {
                List<TVBVOpsSevicesChangeInfo> notFoundBranches = new List<TVBVOpsSevicesChangeInfo>();
                foreach (TVBVOpsSevicesChangeInfo branch in inputInfo.Items)
                {
                    if (!rslts.Exists(b => b.BranchID == branch.BranchID))
                        notFoundBranches.Add(branch);
                }

                var failures = from r in rslts
                               where r.Succeeded == false
                                   select r;
                var succeesses= from r in rslts
                               where r.Succeeded == true
                                   select r;
                System.Console.WriteLine("Succeeded = {0}, Failed = {1}, Not found = {2}", succeesses.Count(), failures.Count(), notFoundBranches.Count);
                System.Console.WriteLine("-------------------------------------------------------------------------------------------");
                System.Console.WriteLine("Successful: \n {0}", DRAutoDriver.ToJson(succeesses, true));
                System.Console.WriteLine("-------------------------------------------------------------------------------------------");
                System.Console.WriteLine("Failed: \n {0}", DRAutoDriver.ToJson(failures, true));
                System.Console.WriteLine("-------------------------------------------------------------------------------------------");
                System.Console.WriteLine("Not found: \n {0}", DRAutoDriver.ToJson(notFoundBranches, true));
                System.Console.WriteLine("-------------------------------------------------------------------------------------------");
                DateTime dtEnd = DateTime.Now;
                System.Console.WriteLine("Finished: {0}", dtEnd);
                System.Console.WriteLine("Completed in {0}", (TimeSpan)(dtEnd-dtStart));
                System.Console.WriteLine("===========================================================================================");

                string resultsTabFileTimeSeed = dtStart.ToString("yyyyMMdd_hhmmss");
                PrintTBVBChangeResultInfo(rslts, string.Format("ApplyBulkOpsSvcsChanges_{0}.{1}.{2}.rslts.txt", (bEmulateOnly ? "Emul" : "Write"), resultsTabFileTimeSeed, parentMFO));
                PrintTBVBChangeNotFoundsInfo(notFoundBranches, string.Format("ApplyBulkOpsSvcsChanges_{0}.{1}.{2}.notFound.txt", (bEmulateOnly ? "Emul" : "Write"), resultsTabFileTimeSeed, parentMFO));
            }
        }

        private static void PressContextMenuButton2Test(string[] args)
        {
            if (args.Length >=3)
            {
                long hwndMainWnd = long.Parse(args[1], System.Globalization.NumberStyles.HexNumber);
                long hwndContextWnd = long.Parse(args[2], System.Globalization.NumberStyles.HexNumber);
                FormAutomUtils.SetForegroundWindow((IntPtr)hwndMainWnd);
                Thread.Sleep(50);
                FormAutomUtils.SetFocus((IntPtr)hwndContextWnd);
                Thread.Sleep(50);
                //FormAutomUtils.PressContextMenuButton2((IntPtr)hwndContextWnd);
                FormAutomUtils.PressContextMenuButton5((IntPtr)hwndContextWnd);
                Thread.Sleep(50);
            }
            return;
        }


        private static void ApplyChangesSummaryCorrectionToSingleBranchTest(string[] args)
        {
            string inputXmlPath = args[1];
            int pauseBeforeClosing;            //2
            bool bEmulateOnly;                 //3
            int maxProcessCount;               //4
            string parentMFO = null;           //5
            string skipBranchesIDsFile = null; //6
            
            if(args.Length > 2)
            {
                string pauseBeforeClosingStr = args[2];
                if (!int.TryParse(pauseBeforeClosingStr, out pauseBeforeClosing))
                    pauseBeforeClosing = 0;
            }
            else
                pauseBeforeClosing = 0;

            if (args.Length > 3)
            {
                string bEmulateOnlyStr = args[3];
                if (!bool.TryParse(bEmulateOnlyStr, out bEmulateOnly))
                    bEmulateOnly = true;
            }
            else
                bEmulateOnly = true;

            if (args.Length > 4)
            {
                string maxProcessCountStr = args[4];
                if (!int.TryParse(maxProcessCountStr, out maxProcessCount))
                    maxProcessCount = 0;
            }
            else
                maxProcessCount = 0;
            if (args.Length > 5)
                parentMFO = args[5];

            if (args.Length > 6)
                skipBranchesIDsFile = args[6];
            

            if (!File.Exists(inputXmlPath))
            {
                System.Console.WriteLine("File doesn't exists - '{0}'", inputXmlPath);
                return;
            }

            TVBVsOpsSvcBulkChangeInfo inputInfo = Tools.ReadXML<TVBVsOpsSvcBulkChangeInfo>(inputXmlPath);
            if (!string.IsNullOrEmpty(parentMFO))
            {
                var filtered = from ii in inputInfo.Items where ii.ParentMFO == parentMFO select ii;
                inputInfo.Items = new List<TVBVOpsSevicesChangeInfo>();
                inputInfo.Items.AddRange(filtered);
            }
            if (!string.IsNullOrEmpty(skipBranchesIDsFile) && File.Exists(skipBranchesIDsFile))
            {
                List<string> skipBranchIDs = new List<string>(File.ReadAllLines(skipBranchesIDsFile));
                for(int i = 0;i<skipBranchIDs.Count; i++)
                    skipBranchIDs[i] = skipBranchIDs[i].Trim();
                List<TVBVOpsSevicesChangeInfo> woSkippedItems = new List<TVBVOpsSevicesChangeInfo>();
                foreach(TVBVOpsSevicesChangeInfo ci in inputInfo.Items)
                {
                    if (skipBranchIDs.Contains(ci.BranchID))
                        continue;
                    woSkippedItems.Add(ci);
                }
                inputInfo.Items = woSkippedItems;
            }

            TBVBChangeResultInfo rslt;

            DateTime dtStart = DateTime.Now;
            System.Console.WriteLine("Started: {0}", dtStart);
            IntPtr mainEditBranchesForm = FormAutomUtils.FindWindow("TBanks_modFm", "Редагування банківських установ");
            if (mainEditBranchesForm == (IntPtr)0)
            {
                System.Console.WriteLine("Can't find main window");
                return;
            }
            int drClientProcessId = FormAutomUtils.GetWindowProcess(mainEditBranchesForm);
            System.Console.WriteLine("drClientProcessId = {0}", drClientProcessId);
            System.Console.WriteLine("mainEditBranchesForm = {0} ({0:X8})", mainEditBranchesForm);
            TVBVOpsSevicesChangeInfo.CheckCorrectChangeDates(inputInfo.Items);
            string lastBranchId = string.Empty;
            string prevBranchId = string.Empty;
            bool bBreak;
            bool bContinue;
            if (!DRAutoDriver.ApplyChangesSummaryCorrectionToSingleBranch(inputInfo, bEmulateOnly, pauseBeforeClosing, drClientProcessId, out rslt, ref lastBranchId, ref prevBranchId, out bBreak, out bContinue))
            {
                System.Console.WriteLine("Failed applying change correction");
                return;
            }
            else
            {
                System.Console.WriteLine("Changes correction applied correctly");
            }
        }

        private static void ApplyChangesSummaryCorrectionBulk(string[] args)
        {
            string inputXmlPath = args[1];
            int pauseBeforeClosing;            //2
            bool bEmulateOnly;                 //3
            int maxProcessCount;               //4
            string parentMFO = null;           //5
            string skipBranchesIDsFile = null; //6

            if (args.Length > 2)
            {
                string pauseBeforeClosingStr = args[2];
                if (!int.TryParse(pauseBeforeClosingStr, out pauseBeforeClosing))
                    pauseBeforeClosing = 0;
            }
            else
                pauseBeforeClosing = 0;

            if (args.Length > 3)
            {
                string bEmulateOnlyStr = args[3];
                if (!bool.TryParse(bEmulateOnlyStr, out bEmulateOnly))
                    bEmulateOnly = true;
            }
            else
                bEmulateOnly = true;

            if (args.Length > 4)
            {
                string maxProcessCountStr = args[4];
                if (!int.TryParse(maxProcessCountStr, out maxProcessCount))
                    maxProcessCount = 0;
            }
            else
                maxProcessCount = 0;
            if (args.Length > 5)
                parentMFO = args[5];

            if (args.Length > 6)
                skipBranchesIDsFile = args[6];


            if (!File.Exists(inputXmlPath))
            {
                System.Console.WriteLine("File doesn't exists - '{0}'", inputXmlPath);
                return;
            }

            TVBVsOpsSvcBulkChangeInfo inputInfo = Tools.ReadXML<TVBVsOpsSvcBulkChangeInfo>(inputXmlPath);
            if (!string.IsNullOrEmpty(parentMFO))
            {
                var filtered = from ii in inputInfo.Items where ii.ParentMFO == parentMFO select ii;
                inputInfo.Items = new List<TVBVOpsSevicesChangeInfo>();
                inputInfo.Items.AddRange(filtered);
            }
            if (!string.IsNullOrEmpty(skipBranchesIDsFile) && File.Exists(skipBranchesIDsFile))
            {
                List<string> skipBranchIDs = new List<string>(File.ReadAllLines(skipBranchesIDsFile));
                for (int i = 0; i < skipBranchIDs.Count; i++)
                    skipBranchIDs[i] = skipBranchIDs[i].Trim();
                List<TVBVOpsSevicesChangeInfo> woSkippedItems = new List<TVBVOpsSevicesChangeInfo>();
                foreach (TVBVOpsSevicesChangeInfo ci in inputInfo.Items)
                {
                    if (skipBranchIDs.Contains(ci.BranchID))
                        continue;
                    woSkippedItems.Add(ci);
                }
                inputInfo.Items = woSkippedItems;
            }

            DateTime dtStart = DateTime.Now;
            System.Console.WriteLine("Started: {0}", dtStart);
            IntPtr mainEditBranchesForm = FormAutomUtils.FindWindow("TBanks_modFm", "Редагування банківських установ");
            if (mainEditBranchesForm == (IntPtr)0)
            {
                System.Console.WriteLine("Can't find main window");
                return;
            }
            int drClientProcessId = FormAutomUtils.GetWindowProcess(mainEditBranchesForm);
            System.Console.WriteLine("drClientProcessId = {0}", drClientProcessId);
            System.Console.WriteLine("mainEditBranchesForm = {0} ({0:X8})", mainEditBranchesForm);

            while (true)
            {
                while (DRAutoDriver.FindChangesSummaryCorrectionForm() == IntPtr.Zero)
                {
                    Thread.Sleep(100);
                }
                TBVBChangeResultInfo rslt;
                string lastBranchId = string.Empty;
                string prevBranchId = string.Empty;
                bool bBreak;
                bool bContinue;
                if (!DRAutoDriver.ApplyChangesSummaryCorrectionToSingleBranch(inputInfo, bEmulateOnly, pauseBeforeClosing, drClientProcessId, out rslt, ref lastBranchId, ref prevBranchId, out bBreak, out bContinue))
                {
                    System.Console.WriteLine("Failed applying change correction to the branch {0}", lastBranchId);
                    continue;
                }
                else
                {
                    System.Console.WriteLine("Changes correction applied correctly to the branch {0}", lastBranchId);
                    Thread.Sleep(250);
                }
            }
        }

    }
}
