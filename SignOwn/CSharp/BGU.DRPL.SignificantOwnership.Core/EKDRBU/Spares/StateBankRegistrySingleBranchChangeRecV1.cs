using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.EKDRBU.Spares
{
    /// <summary>
    /// Частина форми-додатку 15
    /// - одне відділення
    /// </summary>
    public class StateBankRegistrySingleBranchChangeRecV1
    {
        public StateBankRegistrySingleBranchChangeRecV1()
        {
            ChangeEffectiveDate = DateTime.Now;
        }

        private BankBranchChangeType _ChangeType;
        [DisplayName("Тип зміни")]
        [Description("(відкриття, зміни реквізитів, припинення діяльності, тощо)")]
        [Required]
        public BankBranchChangeType ChangeType { get { return _ChangeType; } set { _ChangeType = value; /* OnPropertyChanged("ChangeType");*/ } }


        [DisplayName("Ідентифікатор підрозділу")]
        [Description("Чинне значення унікального ідентифікатора\n відокремленого підрозділу (внутрішньобанківський код)")]
        [Required]
        public string BankBranchRegID { get; set; }

        [DisplayName("Дата набуття чинності")]
        [Description("Дата, з якої набуває чинності нинішня зміна")]
        [Required]
        public DateTime ChangeEffectiveDate { get; set; }

        [DisplayName("Зміни")]
        [Description("Значення змінюваних реквізитів")]
        [Required]
        public EKDRBUVariableEntryPartV1 Changes { get; set; }

        /// <summary>
        /// Якщо у цій зміні, наприклад, відображено результати 
        /// більше, ніж одного рішення
        /// </summary>
        [DisplayName("Відповідне(-і) рішення банку")]
        [Description("Ідентифікатор(-и) додатку(-ів), яким(-и) долучається відповідне рішення, згідно з яким(-и) вносяться зміни до відокремленого підрозділу")]
        [Required]
        public List<DocumentID> HeadBankDecisionRefs { get; set; }
    }
}
