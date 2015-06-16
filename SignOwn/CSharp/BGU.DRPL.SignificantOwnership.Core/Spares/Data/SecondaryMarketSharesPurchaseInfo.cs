using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Evolvex.Utility.Core.ComponentModelEx;
using System.ComponentModel;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Інформація про намір щодо придбання акцій (паїв) банку на вторинному ринку 
    /// та/або стосовно правочинів щодо набуття (збільшення) опосередкованої участі 
    /// в банку (крім набуття істотної участі в результаті передавання особі права 
    /// голосу або незалежно від формального володіння)
    /// </summary>
    public class SecondaryMarketSharesPurchaseInfo : IPOSharesPurchaseInfo
    {
        [DisplayName("Актив, що набувається")]
        [Description("Банк або ж юр.особа - власник участі в банку (прямої чи опосередкованої)")]
        [Required]
        public GenericPersonID Asset { get; set; }

        [DisplayName("Попередній власник")]
        [Description("Власник, від якого переходитиме власність")]
        [Required]
        public GenericPersonID PreviousOwner { get; set; }

        [DisplayName("Правочин")]
        [Description("Інформація про відповідний правочин")]
        [Required]
        public LegalTransactionInfo LegalTransaction { get; set; }

        [DisplayName("%, що набувається")]
        [Description("Відсоток у статутному капіталі юридичної особи або банку, який придбавається")]
        [Required]
        public decimal SharesPct { get; set; }

        [DisplayName("Номінальна вартість")]
        [Description("Загальна номінальна вартість акцій (часток, паїв), які придбаваються")]
        [Required]
        public CurrencyAmount NominalSharesValue { get; set; }

        [DisplayName("Ціна реальної угоди")]
        [Description("Ціна акцій (часток, паїв), які придбаваються ( Може зазначатися ціна, яка попередньо погоджена сторонами відповідно до проекту договору купівлі-продажу акцій банку ...)")]
        [Required]
        public CurrencyAmount ActualSharesPrice { get; set; }
    }
}
