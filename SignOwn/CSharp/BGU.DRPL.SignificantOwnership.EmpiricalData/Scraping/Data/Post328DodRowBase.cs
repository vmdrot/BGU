using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BGU.DRPL.SignificantOwnership.EmpiricalData.Scraping.Data
{
    public class Post328DodRowBase
    {
        public static string TrimRawValue(string raw)
        {
            return raw.Replace("\r\u0007", string.Empty).Trim();
        }

    }
}
