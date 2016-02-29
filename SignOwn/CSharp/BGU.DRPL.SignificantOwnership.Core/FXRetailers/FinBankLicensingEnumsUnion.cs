using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares;

namespace BGU.DRPL.SignificantOwnership.Core.FXRetailers
{
    public class FinBankLicensingEnumsUnion
    {
        public BankingActivityType BankingActivity { get; set; }
        public GeneralFXLicenseActivityType FXLicensedActivity { get; set; }
        public ProfessionalStockMarketActivityType SMActivity { get; set; }
        public ProfessionalStockMarketActivitySubType SMActivitySub { get; set; }
        public FinancialServicesType FinSvc { get; set; }
    }
}
