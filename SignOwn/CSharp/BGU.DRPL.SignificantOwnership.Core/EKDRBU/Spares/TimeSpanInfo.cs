using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.EKDRBU.Spares
{
    [XamlExpanderWrapping(false)]
    [UIUsageSuppressControlLabels(false)]
    [UIUsageControlOrientation(Orientation.Horizontal)]
    public class TimeSpanInfo
    {
        [DisplayName("р.")]
        [Description("(років)")]
        public int Years { get; set; }

        [DisplayName("м.")]
        [Description("(місяців)")]
        public int Months { get; set; }
        
        [DisplayName("д.")]
        [Description("(днів)")]
        public int Days { get; set; }
    }
}
