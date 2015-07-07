using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Структура для агрегації даних про частки власності - як прямі, так і опосередковані, а також ті, що набуваються
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.TotalOwnershipDetailsInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class TotalOwnershipDetailsInfo
    {
        /// <summary>
        /// Обов'язкове, навіть якщо там усе по 0-м
        /// </summary>
        [DisplayName("Пряма власність")]
        [Description("Пряма власність")]
        [Required]
        public OwnershipSummaryInfo DirectOwnership { get; set; }
        /// <summary>
        /// Обов'язкове, навіть якщо там усе по 0-м
        /// </summary>
        [DisplayName("Опосередкована власність")]
        [Description("Опосередкована власність")]
        [Required]
        public OwnershipSummaryInfo ImplicitOwnership { get; set; }
        /// <summary>
        /// Обов'язкове, навіть якщо там усе по 0-м
        /// </summary>
        [DisplayName("Власність, що набувається")]
        [Description("Власність, що набувається")]
        [Required]
        public OwnershipVotesInfo AcquiredVotes { get; set; }
        /// <summary>
        /// Обов'язкове, навіть якщо там усе по 0-м
        /// </summary>
        [DisplayName("Усього % у загальній власності")]
        [Description("Усього % у загальній власності")]
        [Required]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MaxWidth = "100", StringFormat = "{}{0:N2}")]
        public decimal TotalCapitalSharePct { get; set; }
        /// <summary>
        /// Обов'язкове, навіть якщо там усе по 0-м
        /// </summary>
        [DisplayName("Усього голосів")]
        [Description("Усього голосів")]
        [Required]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MaxWidth = "250", StringFormat = "{}{0:N0}")]
        public int TotalVotes { get; set; }

        public override string ToString()
        {
            return string.Format("Direct: {0}, Implicit: {1}, Acquired: {2}, {3}%, {4:N0}", DirectOwnership, ImplicitOwnership, AcquiredVotes, TotalCapitalSharePct, TotalVotes);
        }
    }
}
