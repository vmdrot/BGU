using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BGU.DRPL.SignificantOwnership.Core.EKDRBU.Legacy
{
    public class DeptListEntry
    {
        private List<DeptListEntry> _hierarchySource;

        public string NCKS { get; set; }
        public string DEPCODE { get; set; }
        public string ParentCode { get; set; }
        public string KNB { get; set; } 
        public string NAMEF { get; set; }
        public DateTime D_OPEN { get; set; }
        public DateTime? D_CLOSE { get; set; }
        public string NKB { get; set; }
        public string KOB { get; set; }
        public string KK { get; set; }
        public string TP { get; set; }
        public string KOF { get; set; }
        public string NF { get; set; }
        public string KOP { get; set; }
        public string NP { get; set; }

        public IEnumerable<DeptListEntry> Children
        {
            get 
            {
                if (_hierarchySource == null)
                    return null;
                return (IEnumerable<DeptListEntry>)_hierarchySource.Where(dle => dle.ParentCode == this.DEPCODE);
            }
        }



        public void SetHierarchySource(List<DeptListEntry> collection)
        {
            _hierarchySource = collection;
        }

        public static DeptListEntry Parse(DataRow dr)
        {
            DeptListEntry rslt = new DeptListEntry();
            rslt.NCKS = dr["NCKS"] as string;
            rslt.DEPCODE = dr["DEPCODE"] as string;
            rslt.KNB = dr["KNB"] as string;
            rslt.NAMEF = dr["NAMEF"] as string;
            rslt.D_OPEN = (DateTime)dr["D_OPEN"];
            object oDClose = dr["D_CLOSE"];
            if(!(oDClose is DBNull))
                rslt.D_CLOSE = oDClose != null ? (DateTime?)(DateTime)oDClose : (DateTime?)null;
            rslt.NKB = rslt.DEPCODE.Substring(0, 3);
            rslt.KOB = rslt.DEPCODE.Substring(3, 2);
            rslt.KK = rslt.DEPCODE.Substring(5, 3);
            rslt.TP = rslt.DEPCODE.Substring(8, 1);
            rslt.KOF = rslt.DEPCODE.Substring(9, 3);
            rslt.NF = rslt.DEPCODE.Substring(11, 3);
            rslt.KOP = rslt.DEPCODE.Substring(14, 3);
            rslt.NP = rslt.DEPCODE.Substring(16, 3);
            return rslt;
        }
    }
}
