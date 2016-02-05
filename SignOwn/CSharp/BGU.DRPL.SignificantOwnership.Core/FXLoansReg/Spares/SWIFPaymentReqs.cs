using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;

namespace BGU.DRPL.SignificantOwnership.Core.FXLoansReg.Spares
{
    public class SWIFPaymentReqs
    {
        public string Field59Bene { get; set; }
        public BankInfo Field57BeneBank { get; set; }
        public List<BankInfo> CorrespondentBanks { get; set; }
    }
}
