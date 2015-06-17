using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.PowerOfAttorneySharesPurchaseInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class PowerOfAttorneySharesPurchaseInfo
    {
        public PowerOfAttorneyInfo PowerOfAttorney { get; set; }
        public decimal SharesPct { get; set; }
        public decimal VotesPct { get; set; }
    }
}
