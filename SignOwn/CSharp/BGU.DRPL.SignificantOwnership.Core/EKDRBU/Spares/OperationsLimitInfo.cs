using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;
using System.ComponentModel;

namespace BGU.DRPL.SignificantOwnership.Core.EKDRBU.Spares
{
    public class OperationsLimitInfo
    {
        [DisplayName("Тип")]
        [Description("Тип ліміту")]
        public BankOperationLimitType LimitType { get; set; }

        [DisplayName("Часові ознаки")]
        [Description("Період, що характеризує ліміт (денний, місячний, річний, інше")]
        public TimeSpanInfo TimeSpecs { get; set; }

        [DisplayName("Розмір")]
        [Description("Розміри ліміту (в грошах)")]
        public CurrencyAmount AmountSpecs { get; set; }
    }
}
