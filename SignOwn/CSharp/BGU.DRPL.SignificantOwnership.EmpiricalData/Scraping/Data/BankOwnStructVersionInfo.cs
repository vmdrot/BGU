using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BGU.DRPL.SignificantOwnership.EmpiricalData.Scraping.Data
{
    public class BankOwnStructVersionInfo
    {
        public string MFO { get; set; }
        public DateTime AsOf { get; set; }
        public string Url { get; set; }
        public long FileSize { get; set; }
    }
}
