using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Dict
{
    /// <summary>
    /// Інформація про лістинг на біржі (для публічної компанії)
    /// </summary>
    public class StockExchangeListingInfo
    {
        [DisplayName("Біржа")]
        [Description("Біржа, на якій здійснюється котирування")]
        [Required]
        public StockExchangeInfo Exchange { get; set; }
        
        [DisplayName("Назва емітента")]
        [Description("Назва емітента, прийнята на вищевказаній біржі")]
        [Required]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MaxWidth = "400", MinWidth = "250")]
        public string IssuerName { get; set; }
        
        [DisplayName("Символ")]
        [Description("Символ акцій (головний - якщо їх декілька), під яким торгуються акції емітента на вищевказаній біржі")]
        [Required]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MaxWidth = "400", MinWidth = "250")]
        public string MajorStockSymbol { get; set; }
    }
}
