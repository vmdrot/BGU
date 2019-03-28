using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pdf2DataLib.Spares
{
    public class SubPathInfo
    {
        public List<LineInfo> Segments { get; set; }

        public static explicit operator SubPathInfo(iText.Kernel.Geom.Subpath src)
        {
            if (src == null)
                return null;
            var segments = src.GetSegments();
            if (segments == null || segments.Count == 0)
                return null;
            SubPathInfo rslt = new SubPathInfo();
            rslt.Segments = new List<LineInfo>();
            foreach (iText.Kernel.Geom.IShape shp in segments)
            {
                if (shp is iText.Kernel.Geom.Line)
                    rslt.Segments.Add((LineInfo)(iText.Kernel.Geom.Line)shp);
            }
            return rslt;
        }
    }
}
