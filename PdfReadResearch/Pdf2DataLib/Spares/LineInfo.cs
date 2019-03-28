using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText.Kernel.Geom;

namespace Pdf2DataLib.Spares
{
    public class LineInfo
    {
        public PointInfo p1 { get; set; }
        public PointInfo p2 { get; set; }

        public static explicit operator LineInfo(Line src)
        {
            LineInfo rslt = new LineInfo();
            var pts = src.GetBasePoints();
            if (pts.Count >= 1)
                rslt.p1 = (PointInfo)pts[0];
            if (pts.Count >= 2)
                rslt.p2 = (PointInfo)pts[1];
            return rslt;
        }
    }
}
