using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BGU.DRPL.DRClientAutomationLib.Data
{
    public class TVBVOpsSevicesChangeInfo
    {
        public string ParentMFO { get; set; }
        public string BranchID { get; set; }
        public DateTime ChangeDate { get; set; }
        public string ChangesSummary { get; set; }
    }
}
