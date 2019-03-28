
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText.Kernel.Geom;

namespace Pdf2DataLib.Spares
{
    public class PathInfo
    {
        public List<SubPathInfo> SubPaths { get; set; }
        public int RelatedTextIndex { get; set; }

        public static explicit operator PathInfo(Path src)
        {
            PathInfo rslt = new PathInfo();
            var subPaths = src.GetSubpaths();
            rslt.SubPaths = new List<SubPathInfo>();
            foreach (var sp in subPaths)
            {
                var spi = (SubPathInfo)sp;
                if (spi != null)
                    rslt.SubPaths.Add(spi);
            }

            return rslt;
        }

        public static explicit operator Rectangle(PathInfo src)
        {
            PointInfo ul = MinP(src.SubPaths[0].Segments);
            PointInfo br = MaxP(src.SubPaths[0].Segments);
            return new Rectangle((float)ul.x, (float)ul.y, (float)(br.x - ul.x), (float)(br.y - ul.y));
        }

        public static explicit operator RectangleInfo(PathInfo src)
        {
            if (src.SubPaths == null || src.SubPaths.Count < 1)
                return null;
            PointInfo ul = MinP(src.SubPaths[0].Segments);
            PointInfo br = MaxP(src.SubPaths[0].Segments);
            return new RectangleInfo() { ulx = (float)ul.x, uly = (float)ul.y, brx = (float)br.x, bry = (float)br.y };
        }

        private static PointInfo MaxP(List<LineInfo> segments)
        {
            List<PointInfo> allPoints = new List<PointInfo>();
            foreach (LineInfo ln in segments)
            { allPoints.Add(ln.p1); allPoints.Add(ln.p2); }
            double maxX = allPoints.Select(p => p.x).Max();
            double maxY = allPoints.Select(p => p.y).Max();
            return allPoints.Where(p => p.x == maxX && p.y == maxY).FirstOrDefault();

        }

        private static PointInfo MinP(List<LineInfo> segments)
        {
            List<PointInfo> allPoints = new List<PointInfo>();
            foreach (LineInfo ln in segments)
            { allPoints.Add(ln.p1); allPoints.Add(ln.p2); }
            double minX = allPoints.Select(p => p.x).Min();
            double minY = allPoints.Select(p => p.y).Min();
            return allPoints.Where(p => p.x == minX && p.y == minY).FirstOrDefault();
        }
    }
}
