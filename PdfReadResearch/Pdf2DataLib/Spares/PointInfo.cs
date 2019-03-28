using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText.Kernel.Geom;

namespace Pdf2DataLib.Spares
{
    public class PointInfo
    {
        public double x { get; set; }
        public double y { get; set; }

        public static explicit operator PointInfo(Point src)
        {
            if (src == null)
                return null;
            PointInfo rslt = new PointInfo();
            rslt.x = src.GetX();
            rslt.y = src.GetY();
            return rslt;
        }
    }
}
