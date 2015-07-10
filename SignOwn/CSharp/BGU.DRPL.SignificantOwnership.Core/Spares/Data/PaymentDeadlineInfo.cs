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

        public PaymentDeadlineInfo()
        {
            Deadline = DateTime.Now;
        }

        [DisplayName("Сума")]
        [Required]
        public CurrencyAmount Amount { get; set; }
        [DisplayName("Дата")]
        [Required]
        public DateTime Deadline { get; set; }

        public override string ToString()
        {
            if (Amount == null && Deadline == DateTime.MinValue)
                return string.Empty;
            string amt = Amount != null ? Amount.ToString() : string.Empty;
            string dt = (Deadline == DateTime.MinValue || Deadline == DateTime.MaxValue) ? string.Empty : Deadline.ToString();
            return string.Format("{0}, {1}", amt, dt);
        }
    }
}
