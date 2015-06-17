using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.CourtDecisionInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class CourtDecisionInfo
    {
        public CourtInfo Court { get; set; }
        public CourtDecisionType DecisionType { get; set; }
        public DateTime DecisionDate { get; set; }
        public string DecisionText { get; set; }
    }
}
