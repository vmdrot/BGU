using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;

namespace BGU.DRPL.SignificantOwnership.Core.EKDRBU.Spares
{
    public class OperationsLimitInfo
    {
        public BankOperationLimitType LimitType { get; set; }
        public TimeSpan TimeSpecs { get; set; }
        public CurrencyAmount AmountSpecs {get; set;}
    }
}
