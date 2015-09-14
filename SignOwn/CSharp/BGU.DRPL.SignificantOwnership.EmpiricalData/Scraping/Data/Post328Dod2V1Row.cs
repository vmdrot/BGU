using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BGU.DRPL.SignificantOwnership.EmpiricalData.Scraping.Data
{
    public class Post328Dod2V1Row : Post328DodRowBase
    {
        public int RowNum { get; set; }
        public string Name { get; set; }
        public string PersonTypeStr { get; set; }
        public string IsSignOwnerStr { get; set; }
        public string PersonInfo { get; set; }
        public decimal DirectOwnershipPct { get; set; }
        public decimal ImplicitOwnershipPct { get; set; }
        public decimal TotalOwnershipPct { get; set; }
        public string OwnershipChainDescr { get; set; }

        public static Post328Dod2V1Row Parse(List<string> rawRow)
        {
            if (rawRow == null || rawRow.Count < 9)
                return null;
            Post328Dod2V1Row rslt = new Post328Dod2V1Row();
            int rowNum;
            if (int.TryParse(TrimRawValue(rawRow[0]), out rowNum))
                rslt.RowNum = rowNum;
            rslt.Name = TrimRawValue(rawRow[1]);
            rslt.PersonTypeStr = TrimRawValue(rawRow[2]);
            rslt.IsSignOwnerStr = TrimRawValue(rawRow[3]);
            rslt.PersonInfo = TrimRawValue(rawRow[4]);

            decimal pct0;
            if(decimal.TryParse(TrimRawValue(rawRow[5]), out pct0))
                rslt.DirectOwnershipPct = pct0;

            decimal pct1;
            if(decimal.TryParse(TrimRawValue(rawRow[6]), out pct1))
                rslt.ImplicitOwnershipPct = pct1;
            
            decimal pct2;
            if(decimal.TryParse(TrimRawValue(rawRow[7]), out pct2))
                rslt.TotalOwnershipPct = pct2;
            rslt.OwnershipChainDescr = rawRow[8];
            return rslt;
        }
    }
}
