using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    public class SecondaryMarketSharesPurchaseInfo : IPOSharesPurchaseInfo
    {
        public GenericPersonID PreviousOwner { get; set; }
        public string LegalTransaction { get; set; }
    }
}
