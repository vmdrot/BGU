using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Спрощений варіант інформації про часту власності (де не вимагається сума в абс. виразі)
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.OwnershipVotesInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class OwnershipVotesInfo
    {
        [DisplayName("%")]
        [Description("%")]
        [Required]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MaxWidth = "100", StringFormat = "{}{0:N4}")]
        public decimal Pct { get; set; }
        [DisplayName("Кількість голосів")]
        [Description("Кількість голосів")]
        [Required]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MaxWidth = "250", StringFormat = "{}{0:N0}")]
        public int Votes { get; set; }

        public override string ToString()
        {
            return string.Format("{0}% {1:N0}", Pct, Votes);
        }
    }
}
