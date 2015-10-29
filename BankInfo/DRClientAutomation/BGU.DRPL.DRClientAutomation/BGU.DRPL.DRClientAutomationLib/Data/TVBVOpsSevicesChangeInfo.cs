﻿using System;
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
        public string ChangesSummary { get; set; }
    }
}
