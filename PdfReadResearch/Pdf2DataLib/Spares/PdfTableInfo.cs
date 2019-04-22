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
            OuterBoundaries = new RectangleInfo();
            RowsBYs = new Dictionary<int, float>();
            RowsUYs = new Dictionary<int, float>();
            ColsLXs = new Dictionary<int, float>();
            ColsRXs = new Dictionary<int, float>();
        }

        public RectangleInfo OuterBoundaries { get; set; }
        public int RowsCount { get; set; }
        public int ColsCount { get; set; }

        public Dictionary<int, float> RowsUYs { get; set; }
        public Dictionary<int, float> RowsBYs { get; set; }
        public Dictionary<int, float> ColsLXs { get; set; }
        public Dictionary<int, float> ColsRXs { get; set; }
    }
}
