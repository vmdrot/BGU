using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.DRClientAutomationLib;
using BGU.DRPL.DRClientAutomationLib.AuxData;
using System.Threading;

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
            
            
            #endregion

            #endregion
        }
        #endregion

        static void Main(string[] args)
        {
            //System.Console.Read();

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
                //mainEditBranchesForm = FormAutomUtils.FindWindowEx((IntPtr)0, (IntPtr)0, "TBanks_modFm", "Редагування банківських установ", );
                return;
            }

            System.Console.WriteLine("mainEditBranchesForm = {0}", mainEditBranchesForm);
            //WindowInfo wi = FormAutomUtils.FindChildWindowCaptionStartsWith(mainEditBranchesForm, "Відділення  << ", "TGroupBox");
            //if (wi == null)
            //{
            //    System.Console.WriteLine("Can't find TVBV's group box");
            //    return;
            //}
            //IntPtr hwndGrid = DRAutoDriver.FindLowestBranchesGrid(wi.Handle);

            IntPtr hwndGrid = DRAutoDriver.FindLowestBranchesGrid(mainEditBranchesForm);
            
            System.Console.WriteLine("hwndGrid = {0}", hwndGrid);
            IntPtr hwnEditTvbvBtn = DRAutoDriver.FindEditTVBVButton(mainEditBranchesForm);
            System.Console.WriteLine("hwnEditTvbvBtn = {0}", hwnEditTvbvBtn);
            if (hwndGrid == IntPtr.Zero || hwnEditTvbvBtn == IntPtr.Zero)
            {
                System.Console.WriteLine("Can't find all needed windows");
                return;
            }

            for (int i = 0; i < 10; i++)
            {
                FormAutomUtils.FocusAndClickArrowDown(hwndGrid);
                Thread.Sleep(500);
                FormAutomUtils.ClickButton2(hwnEditTvbvBtn);
                Thread.Sleep(1500);
                IntPtr hwndBranchEditForm = FormAutomUtils.FindWindow("TVIDDIL_CLASSForm_2", null);
                System.Console.WriteLine("hwndBranchEditForm = {0}", hwndBranchEditForm);
                Thread.Sleep(2000);
                FormAutomUtils.CloseWindow(hwndBranchEditForm);
                Thread.Sleep(300);
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

            System.Console.WriteLine("mainEditBranchesForm = {0}", mainEditBranchesForm);
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

    }
}
