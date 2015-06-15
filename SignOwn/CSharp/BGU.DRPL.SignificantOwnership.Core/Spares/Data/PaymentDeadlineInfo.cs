using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Інформація про крайній термін сплати (deadline) якогось зобов'язання
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.PaymentDeadlineInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class PaymentDeadlineInfo
    {
        [DisplayName("Сума")]
        [Required]
        public CurrencyAmount Amount { get; set; }
        [DisplayName("Дата")]
        [Required]
        public DateTime Deadline { get; set; }
    }
}
