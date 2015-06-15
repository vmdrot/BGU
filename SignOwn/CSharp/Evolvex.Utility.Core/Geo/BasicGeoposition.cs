using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolvex.Utility.Core.Geo
{
    public class BasicGeoposition
    {
        public BasicGeoposition(): this(0, 0, 0)
        {
        }

        public BasicGeoposition(double lat, double longt) :this (0, lat, longt)
        { }

        public BasicGeoposition(double alt, double lat, double longt)
        {
            Altitude = alt;
            Latitude = lat;
            Longitude = longt;
        }

        public double Altitude { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
