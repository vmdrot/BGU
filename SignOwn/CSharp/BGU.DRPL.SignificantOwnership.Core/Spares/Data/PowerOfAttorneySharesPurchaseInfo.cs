using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    public class PowerOfAttorneySharesPurchaseInfo
    {
        public GenericPersonID AttorneyIssuer { get; set; }
        public decimal SharesPct { get; set; }
        public decimal VotesPct { get; set; }
        public DateTime PoAValidFrom { get; set; }
        public DateTime PoAValidThru { get; set; }
        public string OtherInfo { get; set; }
    }
}
