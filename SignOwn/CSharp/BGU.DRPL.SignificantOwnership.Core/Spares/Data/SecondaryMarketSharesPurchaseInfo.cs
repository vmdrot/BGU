using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    public class SecondaryMarketSharesPurchaseInfo : IPOSharesPurchaseInfo
    {
        public GenericPersonID PreviousOwner { get; set; }
        public LegalTransactionInfo LegalTransaction { get; set; }
        public decimal SharesPct { get; set; }
        public CurrencyAmount NominalSharesValue { get; set; }
        public CurrencyAmount ActualSharesPrice { get; set; }
    }
}
