using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;
using System.ComponentModel;

namespace BGU.DRPL.SignificantOwnership.Core.Spares2
{
    /// <summary>
    /// Розширена інформація про банківську/валютну ліцензію
    /// </summary>
    public class BankingLicenseInfoEx
    {
        [DisplayName("Дата відозви/анулювання ліцензії")]
        public DateTime? RevocationDate { get; set; }
        public List<BankingLicensedActivityInfo> Activities { get; set; }
    }
}
