using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDF2DataTest.Spares
{
    public class ExtractedTableTextsStats
    {
        public ExtractedTableTextsStats()
        {
            RowsByColumnCount = new Dictionary<int, int>();
        }

        public string PdfName { get; set; }
        public string PdfPath { get; set; }
        public int PagesCount {get; set;}
        public Dictionary<int,int> RowsByColumnCount { get; set; }
    }
}
