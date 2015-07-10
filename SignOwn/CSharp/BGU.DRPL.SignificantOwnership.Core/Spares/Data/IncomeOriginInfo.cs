using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;
using BGU.DRPL.SignificantOwnership.Utility;
using System.Xml.Serialization;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Інформація про джерело отриманих доходів (за рахунок яких, 
    /// наприклад, буде сплачуватися набуття істотної участі)
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.IncomeOriginInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class IncomeOriginInfo : NotifyPropertyChangedBase
    {
        private FundsOriginType _Origin;
        [DisplayName("Тип походження")]
        [Required]
        public FundsOriginType Origin { get { return _Origin; } set { _Origin = value; OnPropertyChanged("Origin"); OnPropertyChanged("IsOtherOrigin"); } }

        [Browsable(false)]
        [XmlIgnore]
        public bool IsOtherOrigin { get { return Origin == FundsOriginType.OtherIncomes; } }

        private string _OriginOther;
        [UIConditionalVisibility("IsOtherOrigin")]
        public string OriginOther { get { return _OriginOther; } set { _OriginOther = value; OnPropertyChanged("OriginOther"); } }

        private CurrencyAmount _Income;
        [DisplayName("Сума доходу")]
        [Required]
        public CurrencyAmount Income { get { return _Income; } set { _Income = value; OnPropertyChanged("Income"); } }

        private string _IncomeOriginNotes;
        [DisplayName("Опис та деталі щодо джерела доходу")]
        [Required]
        [Multiline]
        public string IncomeOriginNotes { get { return _IncomeOriginNotes; } set { _IncomeOriginNotes = value; OnPropertyChanged("IncomeOriginNotes"); } }

        public override string ToString()
        {
            return string.Format("{0}\t{1}\t{2}", IsOtherOrigin? OriginOther : EnumType.GetEnumDescription(this.Origin), Income, IncomeOriginNotes);
        }
    }
}
