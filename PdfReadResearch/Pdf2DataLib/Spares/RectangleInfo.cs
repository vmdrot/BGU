using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pdf2DataLib.Spares
{
    public class RectangleInfo
    {
        #region prop(s)
        public float ulx { get; set; }
        public float uly { get; set; }
        public float brx { get; set; }
        public float bry { get; set; }
        #endregion

        #region operator(s)
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
        #endregion

        #region static method(s)
        public static bool IsIntersecting_v2(RectangleInfo r1, RectangleInfo r2)
        {
            Console.WriteLine("{0} = {1}", nameof(r1), r1);
            Console.WriteLine("{0} = {1}", nameof(r2), r2);
            if (r1 == r2)
                return true;
            if (r1 == null || r2 == null)
                return false;
            float leftX = Math.Max(r1.ulx, r2.ulx);
            Console.WriteLine("{0} = {1}", nameof(leftX), leftX);
            float rightX = Math.Min(r1.brx, r2.brx);
            Console.WriteLine("{0} = {1}", nameof(rightX), rightX);
            float topY = Math.Max(r1.uly, r2.uly);
            Console.WriteLine("{0} = {1}", nameof(topY), topY);
            float bottomY = Math.Min(r1.bry, r2.bry);
            Console.WriteLine("{0} = {1}", nameof(bottomY), bottomY);

            Console.WriteLine("leftX <= rightX = {0}", leftX <= rightX);
            Console.WriteLine("topY >= bottomY = {0}", topY >= bottomY);
            Console.WriteLine(new string('-',20));
            return leftX <= rightX && topY >= bottomY;
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

        public static bool IsWithin(RectangleInfo holder, RectangleInfo subj)
        {
            if (holder == subj)
                return true;
            if (holder == null || subj == null)
                return false;
            // Attention! The below condition is PDF rectangles-specific (where x coords grow left -> right, but y coords - bottom -> top);
            return holder.ulx <= subj.ulx && holder.uly >= subj.uly && holder.brx>= subj.brx && holder.bry <= subj.bry;
        }
        #endregion

        #region misc method(s)
        public float GetArea()
        { return (brx - ulx) * (bry - uly); }

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3}", ulx, uly, brx, bry);
        }
        #endregion
    }
}
