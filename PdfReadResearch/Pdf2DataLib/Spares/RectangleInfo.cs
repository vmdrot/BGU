using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pdf2DataLib.Spares
{
    public class RectangleInfo
    {
        public float ulx { get; set; }
        public float uly { get; set; }
        public float brx { get; set; }
        public float bry { get; set; }

        public static bool operator ==(RectangleInfo one, RectangleInfo two)
        {
            if ((object)one == null && (object)two == null)
                return true;
            if ((object)one == null || (object)two == null)
                return false;
            return one.ulx == two.ulx && one.uly == two.uly && one.brx == two.brx && one.bry == two.bry;
        }
        public static bool operator !=(RectangleInfo one, RectangleInfo two)
        {
            if ((object)one == null && (object)two == null)
                return false;
            if ((object)one == null || (object)two == null)
                return true;
            return !(one.ulx == two.ulx && one.uly == two.uly && one.brx == two.brx && one.bry == two.bry);
        }

        public static bool IsIntersecting(RectangleInfo r1, RectangleInfo r2)
        {
            if (r1 == r2)
                return true;
            if (r1 == null || r2 == null)
                return false;
            float leftX = Math.Max(r1.ulx, r2.ulx);
            float rightX = Math.Min(r1.brx, r2.brx);
            float topY = Math.Max(r1.uly, r2.uly);
            float bottomY = Math.Min(r1.bry, r2.bry);

            return leftX < rightX && topY < bottomY;
        }

        public float GetArea()
        { return (brx - ulx) * (bry - uly); }
    }
}
