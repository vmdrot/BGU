using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BGU.DRPL.SignificantOwnership.Core.Spares2
{
    public class NonBankingFinInstLicenseInfo : BankingLicenseInfoEx
    {
        public string LicenseRevisionNr { get; set; }
        public DateTime? LicenseChangeDate { get; set; }
        public char LicenseState { get; set; }
        public string LicenseStateName { get; set; }
    }
}
