using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace BGU.DRPL.DRClientAutomationLib.Data
{
    public class TVBVClosureInfo
    {
        public string ParentMFO { get; set; }
        public string BranchID { get; set; }

        [XmlIgnore]
        public string TrimmedBranchID 
        {
            get
            {
                return BranchID.Replace(" ", string.Empty).Trim();
            }
        }

        public string Status { get; set; }
        public DateTime StatusChangeDate { get; set; }
        public DateTime CloseDownDate { get; set; }
        public DateTime ExlusionDate { get; set; }
        public DateTime ChangeDate { get; set; }
        public string ChangesSummary { get; set; }
    }
}
