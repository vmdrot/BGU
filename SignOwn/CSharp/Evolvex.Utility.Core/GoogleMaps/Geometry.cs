using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolvex.Utility.Core.GoogleMaps
{
    public class Geometry
    {
        public Viewport bounds { get; set; }
        LongLatInfo location { get; set; }
        public string location_type { get; set; }
        public Viewport viewport { get; set; }
    }
}
