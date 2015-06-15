using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Інформація про пакет акцій, що купується
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.SharesAcquisitionInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class SharesAcquisitionInfo
    {
        [DisplayName("Кількість акцій (одиниць)")]
        [Required]
        public int SharesCount { get; set; }
        [DisplayName("У тому числі кількість акцій з правом голосу")]
        [Required]
        public int InclVotingSharesCount { get; set; }
        [DisplayName("номінальна вартість однієї акції (паю)")]
        [Required]
        public decimal SharePrice { get; set; }
        /// <summary>
        /// тобто, SharesCount * SharePrice
        /// </summary>
        [DisplayName("загальна сума ... гривень")]
        [Required]
        public decimal TotalCosts { get; set; }
    }
}
