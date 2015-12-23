using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace BGU.DRPL.SignificantOwnership.Core.EKDRBU.Spares
{
    public class BankBranchOpsSvcsSchemeInfo
    {
        /// <summary>
        /// Ідентифікатор, на який можна буде посилатися для конкретного відділення
        /// (у полях OperationsListingRefNew та OperationsListingRefOld)
        /// </summary>
        /// <seealso cref="#EKDRBUVariableEntryPartV1"/>
        [DisplayName("Ідентифікатор/код схеми")]
        [Description("Унікальний (в межах пакету) ідентифікатор схеми переліку й обсягу операцій відокремленого підрозділу")]
        public string SchemeID { get; set; }

        /// <summary>
        /// Власне, саме значення поля
        /// (текст із переліком та обсягом операцій)
        /// </summary>
        [DisplayName("Перелік та обсяг операцій")]
        [Description("Перелік та обсяг операцій (текст)")]
        public string OperationsListingText { get; set; }
    }
}
