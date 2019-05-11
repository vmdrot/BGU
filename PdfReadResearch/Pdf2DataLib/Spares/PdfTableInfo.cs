using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pdf2DataLib.Spares
{
    //todo - change to internal later
    public class PdfTableInfo
    {
        public PdfTableInfo()
        {
            Rows = new Dictionary<int, RowColInfo>();
            Cols = new Dictionary<int, RowColInfo>();
            Rows2Cols = new Dictionary<int, Tuple<int, int>>();
            CellTexts = new Dictionary<int, string>();
            OuterBoundaries = new RectangleInfo();
        }

        public RectangleInfo OuterBoundaries { get; set; }
        public Dictionary<int, RowColInfo> Rows { get; set; }
        public Dictionary<int, RowColInfo> Cols { get; set; }
        public Dictionary<int,Tuple<int, int>> Rows2Cols { get; set; }
        public Dictionary<int, string> CellTexts { get; set; }
    }
}
