﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BGU.DRPL.SignificantOwnership.Core.Spares;
using System.Xml.Serialization;
using System.ComponentModel;

namespace BGU.DRPL.SignificantOwnership.Core.EKDRBU.Legacy
{
    public class DeptListEntry : NotifyPropertyChangedBase
    {
        private List<DeptListEntry> _hierarchySource;

        private string _NCKS; 
        [DisplayName("")]
        [Description("")]
        public string NCKS { get { return _NCKS; } set { _NCKS = value; OnPropertyChanged("NCKS"); } }
        private string _DEPCODE;
        [DisplayName("")]
        [Description("")]
        public string DEPCODE { get { return _DEPCODE; } set { _DEPCODE = value; OnPropertyChanged("DEPCODE"); } }
        private string _ParentCode;
        [XmlIgnore]
        public string ParentCode { get { return _ParentCode; } set { _ParentCode = value; OnPropertyChanged("ParentCode"); } }
        private string _KNB;
        [DisplayName("")]
        [Description("")]
        public string KNB { get { return _KNB; } set { _KNB = value; OnPropertyChanged("KNB"); } }
        private string _NAMEF;
        [DisplayName("")]
        [Description("")]
        public string NAMEF { get { return _NAMEF; } set { _NAMEF = value; OnPropertyChanged("NAMEF"); } }
        private DateTime _D_OPEN;
        [DisplayName("")]
        [Description("")]
        public DateTime D_OPEN { get { return _D_OPEN; } set { _D_OPEN = value; OnPropertyChanged("D_OPEN"); } }
        private DateTime? _D_CLOSE;
        [DisplayName("")]
        [Description("")]
        public DateTime? D_CLOSE { get { return _D_CLOSE; } set { _D_CLOSE = value; OnPropertyChanged("D_CLOSE"); } }
        private string _NKB;
        [DisplayName("")]
        [Description("")]
        public string NKB { get { return _NKB; } set { _NKB = value; OnPropertyChanged("NKB"); } }
        private string _KOB;
        [DisplayName("")]
        [Description("")]
        public string KOB { get { return _KOB; } set { _KOB = value; OnPropertyChanged("KOB"); } }
        private string _KK;
        [DisplayName("")]
        [Description("")]
        public string KK { get { return _KK; } set { _KK = value; OnPropertyChanged("KK"); } }
        private string _TP;
        [DisplayName("")]
        [Description("")]
        public string TP { get { return _TP; } set { _TP = value; OnPropertyChanged("TP"); } }
        private string _KOF;
        [DisplayName("")]
        [Description("")]
        public string KOF { get { return _KOF; } set { _KOF = value; OnPropertyChanged("KOF"); } }
        private string _NF;
        [DisplayName("")]
        [Description("")]
        public string NF { get { return _NF; } set { _NF = value; OnPropertyChanged("NF"); } }
        private string _KOP;
        [DisplayName("")]
        [Description("")]
        public string KOP { get { return _KOP; } set { _KOP = value; OnPropertyChanged("KOP"); } }
        private string _NP;
        public string NP { get { return _NP; } set { _NP = value; OnPropertyChanged("NP"); } }
        private bool _IsChecked;
        [XmlIgnore]
        public bool IsChecked { get { return _IsChecked; } set { _IsChecked = value; OnPropertyChanged("IsChecked"); } }


        public IEnumerable<DeptListEntry> Children
        {
            get 
            {
                if (_hierarchySource == null)
                    return null;
                return (IEnumerable<DeptListEntry>)_hierarchySource.Where(dle => dle.ParentCode == this.DEPCODE);
            }
        }


        public List<DeptListEntry> HierarchySource 
        {
            get { return _hierarchySource; }
            set { _hierarchySource = value; }
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
            rslt.KOF = rslt.DEPCODE.Substring(9, 2);
            rslt.NF = rslt.DEPCODE.Substring(11, 3);
            rslt.KOP = rslt.DEPCODE.Substring(14, 2);
            rslt.NP = rslt.DEPCODE.Substring(16, 3);
            return rslt;
        }
    }
}
