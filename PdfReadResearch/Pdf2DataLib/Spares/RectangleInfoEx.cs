using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pdf2DataLib.Spares
{
    public class RectangleInfoEx : RectangleInfo
    {
        public string Text { get; set; }

        public static bool operator ==(RectangleInfoEx one, RectangleInfoEx two)
        {
            return (RectangleInfo)one == (RectangleInfo)two && one.Text == two.Text;
        }
        public static bool operator !=(RectangleInfoEx one, RectangleInfoEx two)
        {
            return (RectangleInfo)one != (RectangleInfo)two && one.Text != two.Text;
        }


    }
}
