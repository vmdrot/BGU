using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace BGU.DRPL.SignificantOwnership.Core.FXLoansReg.Spares
{
    public class AgreementAttributes
    {
        [DisplayName("Назва")]
        [Description("Назва документа - угода, договір, додаткова угода, додаток, протокол, тощо")]
        public string Nm { get; set; }

        [DisplayName("№")]
        [Description("№ документа (угоди, договору, додаткової угоди, додатка, протоколу, тощо")]
        public string Nr { get; set; }

        [DisplayName("Дата")]
        [Description("Дата документа (угоди, договору, додаткової угоди, додатка, протоколу, тощо")]
        public DateTime Dt { get; set; }

    }
}
