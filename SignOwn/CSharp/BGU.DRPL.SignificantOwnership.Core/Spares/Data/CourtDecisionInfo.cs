using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    public class CourtDecisionInfo
    {
        public CourtInfo Court { get; set; }
        public CourtDecisionType DecisionType { get; set; }
        public DateTime DecisionDate { get; set; }
        public string DecisionText { get; set; }
    }
}
