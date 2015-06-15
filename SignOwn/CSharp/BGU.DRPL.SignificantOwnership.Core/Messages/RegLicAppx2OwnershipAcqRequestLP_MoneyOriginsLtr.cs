using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.Messages
{
    public class RegLicAppx2OwnershipAcqRequestLP_MoneyOriginsLtr
    {
        /// <summary>
        /// Стверджую, що юридична особа має можливість підтвердити походження джерел коштів, за рахунок яких придбає акції банку.
        /// </summary>
        [DisplayName("Може підтвердити походження джерел коштів?")]
        [Description("Стверджую, що юридична особа має можливість підтвердити походження джерел коштів, за рахунок яких придбає акції банку.")]
        [Required]
        public bool CanProveMoneyOrigins { get; set; }
    }
}
