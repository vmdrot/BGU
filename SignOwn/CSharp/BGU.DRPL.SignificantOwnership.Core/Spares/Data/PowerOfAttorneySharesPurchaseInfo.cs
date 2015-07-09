using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;

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
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MaxWidth = "100", StringFormat = "{}{0:N4}")]
        public decimal SharesPct { get; set; }
        
        [DisplayName("Кількість голосів")]
        [Description("Кількість голосів у банку, щодо яких передається право голосу")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MaxWidth = "250", StringFormat = "{}{0:N0}")]
        public int Votes { get; set; }
        
        [DisplayName("% голосів")]
        [Description("Відсоток голосів у банку, щодо яких передається право голосу")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MaxWidth = "100", StringFormat = "{}{0:N4}")]
        public decimal VotesPct { get; set; }

        public override string ToString()
        {
            return string.Format("{0}\t{1}%\t{2}\t{3}%", PowerOfAttorney, SharesPct, Votes, VotesPct);
        }
    }
}
