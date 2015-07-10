using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;
using BGU.DRPL.SignificantOwnership.Utility;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Інформація-елемент ланцюжка розкриття структури власності
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.OwnershipStructure_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class OwnershipStructure
    {

        public OwnershipStructure()
        {
            this.OwnershipKind = OwnershipType.Direct;
        }
        /// <summary>
        /// Ідентифікатор юр.особи - об'єкта власності
        /// </summary>
        [DisplayName("Об'єкт власності")]
        [Description("Юр.особа, чия власність розкривається")]
        [Required]
        public GenericPersonID Asset { get; set; }
        /// <summary>
        /// ідентифікатор особи-власника
        /// </summary>
        [DisplayName("Власник")]
        [Description("Власник")]
        [Required]
        public GenericPersonID Owner { get; set; }
        /// <summary>
        /// За змовчанням Direct (пропонувати уже введене)
        /// </summary>
        [DisplayName("Тип володіння")]
        [Description("Тип володіння")]
        [Required]
        //[UIUsageCombo(ItemsGetterClass = typeof(BGU.DRPL.SignificantOwnership.Core.Spares.EnumsLister), ItemsGetterMemberPath = "OwnershipTypeList", ValueMemberUsageMode = ComboUIValueUsageMode.ValueProperty, ValueMember = "EnumValue", DisplayMember = "Value", Width = "350", ToolTipMember = "EnumValue")]
        public OwnershipType OwnershipKind { get; set; }
        /// <summary>
        /// Якщо відомий загальний статутний капітал, або якщо частку визначено в абсолютному виразі
        /// </summary>
        [DisplayName("Частка у власності (сума)")]
        [Description("Частка (сума)")]
        //[UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MaxWidth = "250", MinWidth = "150", StringFormat = "{}{0:N2}")]
        public CurrencyAmount Share { get; set; } //todo - switch currency automatically on Asset country of jurisdiction change

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Кількість акцій")]
        [Description("Кількість акцій, що належать Власникові в об'єкті власності")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MaxWidth = "250", MinWidth = "150", StringFormat = "{}{0:N0}")]
        public int SharesCount { get; set; }
        /// <summary>
        /// Як правило, саме у %-х і зазначається власність
        /// </summary>
        [DisplayName("Частка (%)")]
        [Description("Частка (%)")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MaxWidth = "100", MinWidth = "75", StringFormat = "{}{0:N4}")]
        public decimal SharePct { get; set; }
        /// <summary>
        /// Якщо вимагається контекстом
        /// </summary>
        [DisplayName("Кількість голосів в управлінні")]
        [Description("Кількість голосів в управлінні")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MaxWidth = "250", MinWidth = "150", StringFormat = "{}{0:N0}")]
        public int Votes { get; set; }

        public override string ToString()
        {
            return string.Format("у {0}, власник: {1} ({2}) {3:N0} {4}% {5:N0}", Asset, Owner, EnumType.GetEnumDescription( OwnershipKind), Share, SharePct, Votes);
        }
    }
}
