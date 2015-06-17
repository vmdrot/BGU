using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.IPOSharesPurchaseInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class IPOSharesPurchaseInfo
    {
        public int SharesCount { get; set; }
        public CurrencyAmount NominalSharePrice { get; set; }
        public CurrencyAmount NominalTotalSharesValue { get; set; }
        public CurrencyAmount ActualTotalSharesValue { get; set; }
        public List<PaymentDeadlineInfo> PaymentDeadlines { get; set; }
    }
}
