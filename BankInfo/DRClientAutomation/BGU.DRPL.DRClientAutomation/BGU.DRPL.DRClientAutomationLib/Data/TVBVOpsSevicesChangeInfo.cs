using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace BGU.DRPL.DRClientAutomationLib.Data
{
    public class TVBVOpsSevicesChangeInfo
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
        public DateTime ChangeDate { get; set; }
        public DateTime? DeclaredChangeDate { get; set; }
        public string ChangesSummary { get; set; }

        public static void CheckCorrectChangeDate(TVBVOpsSevicesChangeInfo ci)
        {
            if (ci.ChangeDate.DayOfWeek == DayOfWeek.Saturday || ci.ChangeDate.DayOfWeek == DayOfWeek.Sunday)
            {
                ci.DeclaredChangeDate = ci.ChangeDate;
                ci.ChangeDate = NextWorkDay(ci.ChangeDate);
            }
        }

        public static DateTime NextWorkDay(DateTime srcDt)
        {
            DateTime rslt = srcDt;
            while (rslt.DayOfWeek == DayOfWeek.Saturday || rslt.DayOfWeek == DayOfWeek.Sunday)
                rslt = rslt.AddDays(1);
            return rslt;
        }

        public static void CheckCorrectChangeDates(List<TVBVOpsSevicesChangeInfo> target)
        {
            foreach (TVBVOpsSevicesChangeInfo ci in target)
                CheckCorrectChangeDate(ci);
        }
    }
}
