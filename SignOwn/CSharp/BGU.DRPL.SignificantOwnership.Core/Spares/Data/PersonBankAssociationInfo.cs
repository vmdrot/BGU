using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;
using BGU.DRPL.SignificantOwnership.Utility;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    public class PersonBankAssociationInfo
    {

        [DisplayName("Особа")]
        [Description("Оберіть пов'язану особу")]
        [Required]
        public GenericPersonID Person { get; set; }

        [DisplayName("Код пов'язаності")]
        [Description("Оберіть код пов'язаності особи")]
        [Required]
        public BankAssociatedPeronsCode315p AssociationKind { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Person, EnumType.GetEnumDescription(AssociationKind));
        }
    }
}
