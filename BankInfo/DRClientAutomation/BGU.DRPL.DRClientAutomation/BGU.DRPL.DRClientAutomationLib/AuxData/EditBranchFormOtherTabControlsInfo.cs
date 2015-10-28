using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BGU.DRPL.DRClientAutomationLib.AuxData
{
    public class EditBranchFormOtherTabControlsInfo
    {
        public IntPtr PayDocNrEdit { get; set; }
        public IntPtr PayDateEdit { get; set; }
        public IntPtr ChangesDate { get; set; }
        public IntPtr ChangesSummaryEdit { get; set; }

        public bool IsChangesControlsFound { get { return ChangesDate != IntPtr.Zero && ChangesSummaryEdit != IntPtr.Zero; } }

        public static EditBranchFormOtherTabControlsInfo Fill(IntPtr hwndOtherTab)
        {
            EditBranchFormOtherTabControlsInfo rslt = new EditBranchFormOtherTabControlsInfo();
            List<WindowInfo> wiOtherTabCtrls = FormAutomUtils.ListChildControls(hwndOtherTab);
            System.Console.WriteLine("wiOtherTabCtrls = {0}", DRAutoDriver.ToJson(wiOtherTabCtrls, true));
            var groupBoxes = from c in wiOtherTabCtrls where c.WndClass == "TGroupBox" select c;
            //int g = 0;
            foreach (var groupBox in groupBoxes)
            {
                if (groupBox.Caption == "Зміни до положення про підрозділи банку")
                {

                    List<WindowInfo> chgsCtrls = FormAutomUtils.ListChildControls(((WindowInfo)groupBox).Handle);
                    WindowInfo wiChgsDescr= chgsCtrls.Find( o => o.Caption == "Короткий опис змін:" && o.WndClass == "TGroupBox");
                    if (wiChgsDescr != null)
                    {
                        List<WindowInfo> chgsDescrCtrls = FormAutomUtils.ListChildControls(wiChgsDescr.Handle);
                        WindowInfo wiChgsSummaryRichEdit = chgsDescrCtrls.Find(o => o.WndClass == "TRichEdit");
                        if (wiChgsSummaryRichEdit != null)
                            rslt.ChangesSummaryEdit = wiChgsSummaryRichEdit.Handle;
                    }
                    WindowInfo wiChgsDtPnl = chgsCtrls.Find(o => o.WndClass == "TPanel");
                    if (wiChgsDtPnl != null)
                    {
                        List<WindowInfo> wiChgsDtPnlCtrls = FormAutomUtils.ListChildControls(wiChgsDtPnl.Handle);
                        WindowInfo wiChgsDate = wiChgsDtPnlCtrls.Find(o => o.WndClass == "TDBDateTimeEditEh" || (o.WndClass == "Edit" && o.Caption == "  .  .    "));
                        if (wiChgsDate != null)
                            rslt.ChangesDate = wiChgsDate.Handle;
                    }

                }
                //else if (groupBox.Caption == "Зміни до положення про підрозділи банку")
                //{}
                //System.Console.WriteLine("wiOtherTabCtrls.groupBoxes[{0}] = {1}", g, DRAutoDriver.ToJson(, true));
                //g++;
            }
            return rslt;
        }
    }
}
