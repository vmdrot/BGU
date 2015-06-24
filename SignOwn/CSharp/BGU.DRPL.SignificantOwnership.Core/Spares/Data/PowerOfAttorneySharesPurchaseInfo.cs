using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Інформація про намір щодо набуття опосередкованої істотної участі в банку за довіреністю
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.PowerOfAttorneySharesPurchaseInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class PowerOfAttorneySharesPurchaseInfo
    {
        [DisplayName("Реквізити довіреності")]
        [Description("Особа, яка видаватиме довіреність, Запланований термін дії довіреності, Інша інформація")]
        public PowerOfAttorneyInfo PowerOfAttorney { get; set; }

        [DisplayName("% участі довірителя")]
        [Description("Розмір участі довірителя в банку, %")]
        public decimal SharesPct { get; set; }
        
        [DisplayName("Кількість голосів")]
        [Description("Кількість голосів у банку, щодо яких передається право голосу")]
        public int Votes { get; set; }
        
        [DisplayName("% голосів")]
        [Description("Відсоток голосів у банку, щодо яких передається право голосу")]
        public decimal VotesPct { get; set; }
    }
}
