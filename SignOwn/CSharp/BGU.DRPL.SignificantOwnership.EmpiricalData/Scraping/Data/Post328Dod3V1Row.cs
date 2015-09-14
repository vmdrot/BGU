using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BGU.DRPL.SignificantOwnership.EmpiricalData.Scraping.Data
{
    public class Post328Dod3V1Row : Post328DodRowBase
    {
        public int RowNum { get; set; }
        public string Name { get; set; }
        public string PersonTypeStr { get; set; }
        public string SignOwnTypeStr { get; set; }
        public string PersonInfo { get; set; }
        public string OwnershipChainDescr { get; set; }

        public static Post328Dod3V1Row Parse(List<string> rawRow)
        {
            if (rawRow == null || rawRow.Count < 6)
                return null;
            Post328Dod3V1Row rslt = new Post328Dod3V1Row();
            int rowNum;
            if (int.TryParse(TrimRawValue(rawRow[0]), out rowNum))
                rslt.RowNum = rowNum;
            
            rslt.Name = TrimRawValue(rawRow[1]);
            rslt.PersonTypeStr = TrimRawValue(rawRow[2]);

            rslt.SignOwnTypeStr = TrimRawValue(rawRow[3]);

            rslt.PersonInfo = TrimRawValue(rawRow[4]);

            rslt.OwnershipChainDescr = rawRow[5];
            return rslt;
        }
    }
}
