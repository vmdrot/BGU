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
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.SecondaryMarketSharesPurchaseInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class SecondaryMarketSharesPurchaseInfo : IPOSharesPurchaseInfo
    {
        [DisplayName("Актив, що набувається")]
        [Description("Банк або ж юр.особа - власник участі в банку (прямої чи опосередкованої)")]
        [Required]
        [UIUsageComboAddButton(AddNewItemCommand = "local:MyCommands.AddMentionedPersonCommand", DisplayMember = "DisplayName", ItemGetterFull = "localdata:DataModule.CurrentMentionedIdentities", ValueMember = "ID", ValueMemberUsageMode = ComboUIValueUsageMode.ValueProperty, Width = "150", ContainerOrientation=Orientation.Vertical)]
        public GenericPersonID Asset { get; set; }

        [DisplayName("Попередній власник")]
        [Description("Власник, від якого переходитиме власність")]
        [Required]
        [UIUsageComboAddButton(AddNewItemCommand = "local:MyCommands.AddMentionedPersonCommand", DisplayMember = "DisplayName", ItemGetterFull = "localdata:DataModule.CurrentMentionedIdentities", ValueMember = "ID", ValueMemberUsageMode = ComboUIValueUsageMode.ValueProperty, Width = "150", ContainerOrientation = Orientation.Vertical)]
        public GenericPersonID PreviousOwner { get; set; }

        [DisplayName("Правочин")]
        [Description("Інформація про відповідний правочин")]
        [Required]
        public LegalTransactionInfo LegalTransaction { get; set; }

        [DisplayName("%, що набувається")]
        [Description("Відсоток у статутному капіталі юридичної особи або банку, який придбавається")]
        [Required]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MaxWidth = "100", StringFormat = "{}{0:N2}")]
        public decimal SharesPct { get; set; }

        [DisplayName("Номінальна вартість")]
        [Description("Загальна номінальна вартість акцій (часток, паїв), які придбаваються")]
        [Required]
        public CurrencyAmount NominalSharesValue { get; set; }

        [DisplayName("Ціна реальної угоди")]
        [Description("Ціна акцій (часток, паїв), які придбаваються ( Може зазначатися ціна, яка попередньо погоджена сторонами відповідно до проекту договору купівлі-продажу акцій банку ...)")]
        [Required]
        public CurrencyAmount ActualSharesPrice { get; set; }

        public override string ToString()
        {
            return string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", Asset, PreviousOwner, LegalTransaction, SharesPct, NominalSharesValue, ActualSharesPrice, ActualTotalSharesValue);
        }
    }
}
