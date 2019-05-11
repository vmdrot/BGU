using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pdf2DataLib.Spares
{
    public class RowColInfo
    {
        public RowColInfo() { Span = 1; }
        public int Id { get; set; }
        public float Coord1 { get; set; }
        public float Coord2 { get; set; }
        public int Span { get; set; }
    }
}
