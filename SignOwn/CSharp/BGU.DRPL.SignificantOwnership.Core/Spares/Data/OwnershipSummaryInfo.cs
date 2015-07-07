using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Структура для групування загальної інформації про власність
    /// Обов'язково або Pct, або Amount
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.OwnershipSummaryInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class OwnershipSummaryInfo
    {
        [DisplayName("кількість акцій (паїв)")]
        [Description("кількість акцій (паїв)")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "150", MaxWidth = "350", StringFormat = "{}{0:N0}")]
        public int SharesCount { get; set; }
        [DisplayName("номінальна вартість акцій (паїв)")]
        [Description("")]
        public CurrencyAmount SharesNominalValue { get; set; }
        [DisplayName("%")]
        [Description("%")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "150", MaxWidth = "250", StringFormat = "{}{0:N2}")]
        public decimal Pct { get; set; }

        public override string ToString()
        {
            if ((SharesNominalValue == null || SharesNominalValue.Amt == 0.0M) && SharesCount == 0)
                return string.Format("{0}%", Pct);
            return string.Format("{0}% {1} {2:N0}", Pct, SharesNominalValue, SharesCount);
        }
    }
}
