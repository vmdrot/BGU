using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Структура для універсальної грошової суми
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.CurrencyAmount_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    [XamlExpanderWrapping(false)]
    public class CurrencyAmount
    {
        /// <summary>
        /// Значення за змовчанням - UAH
        /// http://www.iso.org/iso/en-US/home/standards/currency_codes.htm
        /// </summary>
        /// <seealso cref="http://www.currency-iso.org/en/home/tables/table-a1.html"/>
        [Description("Валюта")]
        [DisplayName("Валюта")]
        [Required]
        [UIUsageCombo(ItemsGetterClass=typeof(BGU.DRPL.SignificantOwnership.Core.Spares.Dict.CurrencyInfo), ItemsGetterMemberPath="AllCurrencies", ValueMemberUsageMode=ComboUIValueUsageMode.ValueProperty, ValueMember="CCYCode", DisplayMember="CCYCode", Width="50")]
        public string CCY { get; set; }

        [Description("Сума")]
        [DisplayName("Сума")]
        [Required]
        public decimal Amt { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", CCY, Amt.ToString("N0"));
        }
    }
}
