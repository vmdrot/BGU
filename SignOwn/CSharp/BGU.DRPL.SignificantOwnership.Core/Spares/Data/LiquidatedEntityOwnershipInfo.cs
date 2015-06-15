using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.LiquidatedEntityOwnershipInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class LiquidatedEntityOwnershipInfo : LiquidatedOrInsolventEntityInfoBase
    {
        /// <summary>
        /// обов'язкове; заповнення секцій - за фактом власності подавача (чи кого там в анкеті вимагають, за контекстом)
        /// </summary>
        [DisplayName("Частки власності")]
        [Required]
        public TotalOwnershipDetailsInfo Stake { get; set; }
    }
}
