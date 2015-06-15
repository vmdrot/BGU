using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Сума до сплати та спосіб сплати 
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.PaymentModeInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class PaymentModeInfo
    {
        [DisplayName("Сума")]
        [Required]
        public CurrencyAmount Amount { get; set; }
        [DisplayName("Спосіб сплати")]
        [Required]
        public PaymentType PaymentMode { get; set; }
    }
}
