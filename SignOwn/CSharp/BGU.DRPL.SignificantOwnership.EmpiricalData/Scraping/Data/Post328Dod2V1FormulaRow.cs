using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BGU.DRPL.SignificantOwnership.EmpiricalData.Scraping.Data
{
    public class Post328Dod2V1FormulaRow : Post328DodRowBase
    {
        public int RowNum { get; set; }
        public string Name { get; set; }
        public string FormulaPath { get; set; }

        public static Post328Dod2V1FormulaRow Parse(List<string> rawRow)
        {
            if (rawRow == null || rawRow.Count < 3)
                return null;
            
            Post328Dod2V1FormulaRow rslt = new Post328Dod2V1FormulaRow();
            
            int rowNum;
            if (int.TryParse(Post328Dod2V1Row.TrimRawValue(rawRow[0]), out rowNum))
                rslt.RowNum = rowNum;
            rslt.Name = Post328Dod2V1Row.TrimRawValue(rawRow[1]);
            rslt.FormulaPath = Post328Dod2V1Row.TrimRawValue(rawRow[2]);

            return rslt;
        }
    }
}
