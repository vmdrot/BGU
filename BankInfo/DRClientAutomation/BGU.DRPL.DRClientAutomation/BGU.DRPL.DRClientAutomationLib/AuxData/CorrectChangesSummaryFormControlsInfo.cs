using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BGU.DRPL.DRClientAutomationLib.AuxData
{
    public class CorrectChangesSummaryFormControlsInfo
    {
        public IntPtr BranchIDEdit { get; set; }
        public IntPtr BranchFullNameEdit { get; set; }
        public IntPtr ApplyChangesButton { get; set; }
        public IntPtr ChangesSummaryEdit{ get; set; }

        public bool IsChangesControlsFound { get { return BranchIDEdit != IntPtr.Zero && ChangesSummaryEdit != IntPtr.Zero && ApplyChangesButton != IntPtr.Zero; } }

        public static CorrectChangesSummaryFormControlsInfo Fill(IntPtr hwndForm)
        {

            CorrectChangesSummaryFormControlsInfo rslt = new CorrectChangesSummaryFormControlsInfo();
            List<WindowInfo> ctrls = FormAutomUtils.ListChildControls(hwndForm);
            System.Console.WriteLine("ctrls = {0}", DRAutoDriver.ToJson(ctrls, true));

            var groupBoxes = from c in ctrls where c.WndClass == "TGroupBox" select c;
            foreach (var groupBox in groupBoxes)
            {
                if (groupBox.Caption == "Внутрішньобанківський код")
                {
                    List<WindowInfo> branchIdGrpCtrls = FormAutomUtils.ListChildControls(groupBox.Handle);
                    //var edits = from c in branchIdGrpCtrls where c.WndClass == "TEdit" || c.WndClass. == "Edit" select c;
                    if (branchIdGrpCtrls.Count == 1)
                        rslt.BranchIDEdit = branchIdGrpCtrls[0].Handle;
                }
                else if (groupBox.Caption == "Короткий опис змін")
                {

                    List<WindowInfo> chgsCtrls = FormAutomUtils.ListChildControls(((WindowInfo)groupBox).Handle);
                    if (chgsCtrls.Count == 1)
                        rslt.ChangesSummaryEdit = chgsCtrls[0].Handle;
                }
            }

            List<WindowInfo> panels = new List<WindowInfo>(from c in ctrls where c.WndClass == "TPanel" || c.WndClass == "Panel" select c);
            if (panels == null || panels.Count == 0)
                return null;
            List<WindowInfo> wiBtns = FormAutomUtils.ListChildControls(panels[0].Handle);
            var saveBtn = new List<WindowInfo>(from b in wiBtns where b.Caption == "Внести зміни" && (b.WndClass == "TButton" || b.WndClass == "Button") select b);
            if(saveBtn != null && saveBtn.Count == 1)
                rslt.ApplyChangesButton = saveBtn[0].Handle;
            return rslt;
        }
    }
}
