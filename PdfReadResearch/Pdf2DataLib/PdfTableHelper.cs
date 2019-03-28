using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText.Kernel.Geom;
using Pdf2DataLib.Spares;

namespace Pdf2DataLib
{
    public static class PdfTableHelper
    {
        public static List<Rectangle> ClippingPaths2RectanglesDistinct(List<PathInfo> src)
        {
            List<Rectangle> rslt = new List<Rectangle>();

            List<Rectangle> allRects = new List<Rectangle>();
            foreach (PathInfo pi in src)
                allRects.Add((Rectangle)pi);
            foreach (Rectangle curr in allRects)
            {
                if (rslt.Contains(curr))
                    continue;
                rslt.Add(curr);
            }
            return rslt;
        }

        public static List<RectangleInfo> ClippingPaths2RectangleInfosDistinct(List<PathInfo> src)
        {
            List<RectangleInfo> rslt = new List<RectangleInfo>();

            List<RectangleInfo> allRects = new List<RectangleInfo>();
            foreach (PathInfo pi in src)
                allRects.Add((RectangleInfo)pi);
            foreach (RectangleInfo curr in allRects)
            {
                if (curr == null)
                    continue;
                //if (rslt.Contains(curr))
                if (rslt.Any(r => r == curr))
                    continue;
                rslt.Add(curr);
            }   
            return rslt;
        }


    }
}
