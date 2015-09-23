using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;
using BGU.DRPL.SignificantOwnership.Core.Spares;
using BGU.DRPL.SignificantOwnership.Core.Messages;

namespace BGU.DRPL.SignificantOwnership.Core.Spares2
{
    public class Post315AppxBankAssocPerson
    {
        public int Nr { get; set; }
        public GenericPersonInfo Person { get; set; }
        public BankAssociatedPersonsCode315p AssociatedPersonCode { get; set; }
        public bool HasOperationsWithBank { get; set; }
    }
}
