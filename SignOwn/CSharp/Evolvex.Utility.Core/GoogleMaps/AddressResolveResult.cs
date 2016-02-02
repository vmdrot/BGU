using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolvex.Utility.Core.GoogleMaps
{
    public class AddressResolveResult
    {
        public List<ResolvedAddressEntry> results { get; set; }
        public string status { get; set; }
    }
}
