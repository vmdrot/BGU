using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;
using System.Xml.Serialization;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Структура для універсальної грошової суми
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.CurrencyAmount_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    [XamlExpanderWrapping(false)]
    public class CurrencyAmount : NotifyPropertyChangedBase
    {
        public CurrencyAmount()
        {
            this.CCY = "UAH";
        }

        private string _CCY;
        /// <summary>
        /// Значення за змовчанням - UAH
        /// http://www.iso.org/iso/en-US/home/standards/currency_codes.htm
        /// </summary>
        /// <seealso cref="http://www.currency-iso.org/en/home/tables/table-a1.html"/>
        [Description("Валюта")]
        [DisplayName("Валюта")]
        [Required]
        [UIUsageCombo(ItemsGetterClass = typeof(BGU.DRPL.SignificantOwnership.Core.Spares.Dict.CurrencyInfo), ItemsGetterMemberPath = "AllCurrencies", ValueMemberUsageMode = ComboUIValueUsageMode.ValueProperty, ValueMember = "CCYCode", DisplayMember = "CCYCode", Width = "75", ToolTipMember = "CCYName")]
        public string CCY { get { return _CCY; } set { _CCY = value; OnPropertyChanged("CCY"); OnPropertyChanged("CurrencyFormat"); OnPropertyChanged("CurrencyToolTip"); } }

        private decimal _Amt;
        [Description("Сума")]
        [DisplayName("Сума")]
        [Required]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "150", MaxWidth = "350", StringFormat = "{}{0:N2}")]
        public decimal Amt { get { return _Amt; } set { _Amt = value; OnPropertyChanged("Amt"); } }


        [Browsable(false)]
        [XmlIgnore]
        public string CurrencyFormat
        {
            get 
            {
                CurrencyInfo cci = CurrencyInfo.GetCurrency(CCY);
                int afterComma = 2;
                if (cci != null)
                {
                    if (cci.CCYMinorUnit != null)
                        afterComma = (int)cci.CCYMinorUnit;
                    else afterComma = 0;
                }
                return string.Format("{{0:N{0}}}", afterComma);
            }
        }

        [Browsable(false)]
        [XmlIgnore]
        public string CurrencyToolTip
        {
            get
            {
                CurrencyInfo cci = CurrencyInfo.GetCurrency(CCY);
                string rslt = string.Empty;
                if (cci != null)
                    rslt = cci.CCYName;
                return rslt;
            }
        }


        public override string ToString()
        {
            return string.Format("{0} {1}", CCY, Amt.ToString("N0"));
        }
    }
}
