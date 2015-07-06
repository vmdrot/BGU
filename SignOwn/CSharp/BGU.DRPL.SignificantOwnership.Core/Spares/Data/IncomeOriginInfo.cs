using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;
using BGU.DRPL.SignificantOwnership.Utility;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Інформація про джерело отриманих доходів (за рахунок яких, 
    /// наприклад, буде сплачуватися набуття істотної участі)
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.IncomeOriginInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class IncomeOriginInfo
    {
        [DisplayName("Тип походження")]
        [Required]
        public FundsOriginType Origin { get; set; }
        [DisplayName("Сума доходу")]
        [Required]
        public CurrencyAmount Income { get; set; }
        [DisplayName("Опис та деталі щодо джерела доходу")]
        [Required]
        [Multiline]
        public string IncomeOriginNotes { get; set; }

        public override string ToString()
        {
            return string.Format("{0}\t{1}\t{2}", EnumType.GetEnumDescription(this.Origin), Income, IncomeOriginNotes);
            
            
        }
    }
}
