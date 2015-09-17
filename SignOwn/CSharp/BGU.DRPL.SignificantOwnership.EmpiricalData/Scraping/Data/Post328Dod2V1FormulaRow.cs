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
            if (int.TryParse(WordPdfParsingUtils.TrimRawValue(rawRow[0]), out rowNum))
                rslt.RowNum = rowNum;
            rslt.Name = WordPdfParsingUtils.NormalizeStringValue(rawRow[1]);
            rslt.FormulaPath = WordPdfParsingUtils.NormalizeStringValue(rawRow[2]);

            return rslt;
        }
    }
}
