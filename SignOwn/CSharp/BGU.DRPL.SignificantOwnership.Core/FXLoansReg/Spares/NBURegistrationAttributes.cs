using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace BGU.DRPL.SignificantOwnership.Core.FXLoansReg.Spares
{
    public class NBURegistrationAttributes
    {
        [DisplayName("№")]
        [Description("№ реєстрації")]
        public string Nr { get; set; }

        [DisplayName("Дата")]
        [Description("Дата реєстрації")]
        public DateTime Dt { get; set; }

    }
}
