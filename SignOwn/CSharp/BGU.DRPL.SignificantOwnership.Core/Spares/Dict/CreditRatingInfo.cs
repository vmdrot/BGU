using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Evolvex.Utility.Core.ComponentModelEx;
using System.ComponentModel;
using System.Xml.Serialization;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Dict
{
    /// <summary>
    /// Кредитний рейтинг емітента
    /// Три поля, по суті:
    /// 1) Аґенція, що роздала рейтинг;
    /// 2) Довго- та середньотерміновий рейтинг;
    /// 3) Короткотерміновий рейтинг.
    /// Якщо аґенція - добре відома, то достатньо буде обрати зі списків WellKnownAgency, LongMidTermRatingValue і ShortTermRatingValue 
    /// інакше, доведеться заповнити поле AgencyOther; якщо у полях значення рейтингу буде обрано "Інше" (Other), то також доведеться ввести значення у відповідному полі *RatingValueOther.
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.CreditRatingInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class CreditRatingInfo : NotifyPropertyChangedBase
    {
        private WellKnownCreditRatingAgencyType _WellKnownAgency;
        [Required]
        [DisplayName("Рейтингова аґенція (добре знана)")]
        public WellKnownCreditRatingAgencyType WellKnownAgency { get { return _WellKnownAgency; } set { _WellKnownAgency = value; OnPropertyChanged("WellKnownAgency"); OnPropertyChanged("IsAgencyOther"); } }


        [Browsable(false)]
        [XmlIgnore]
        public bool IsAgencyOther { get { return WellKnownAgency == WellKnownCreditRatingAgencyType.Other; } }


        private RatingAgencyInfo _AgencyOther;
        /// <summary>
        /// Якщо в полі WellKnownAgency обрано "Інше" (Other)
        /// </summary>
        [DisplayName("Рейтингова аґенція (інша)")]
        [UIConditionalVisibility("IsAgencyOther")]
        public RatingAgencyInfo AgencyOther { get { return _AgencyOther; } set { _AgencyOther = value; OnPropertyChanged("AgencyOther"); } }

        private LongTermCreditRatingType _LongMidTermRatingValue;
        [Required]
        [DisplayName("Довго- та середньотермінове значення рейтингу(стандартне)")]
        public LongTermCreditRatingType LongMidTermRatingValue { get { return _LongMidTermRatingValue; } set { _LongMidTermRatingValue = value; OnPropertyChanged("LongMidTermRatingValue"); OnPropertyChanged("IsLongMidTermRatingValueOther"); } }

        [Browsable(false)]
        [XmlIgnore]
        public bool IsLongMidTermRatingValueOther { get { return LongMidTermRatingValue == LongTermCreditRatingType.Other; } }


        private string _LongMidTermRatingValueOther;
        /// <summary>
        /// Якщо в полі LongMidTermRatingValue обрано "Інше" (Other)
        /// </summary>
        [DisplayName("Довго- та середньотермінове значення рейтингу(якщо інше)")]
        [UIConditionalVisibility("IsLongMidTermRatingValueOther")]
        public string LongMidTermRatingValueOther { get { return _LongMidTermRatingValueOther; } set { _LongMidTermRatingValueOther = value; OnPropertyChanged("LongMidTermRatingValueOther"); } }

        private ShortTermCreditRatingType _ShortTermRatingValue;
        [Required]
        [DisplayName("Короткотермінове значення рейтингу(стандартне)")]
        public ShortTermCreditRatingType ShortTermRatingValue { get { return _ShortTermRatingValue; } set { _ShortTermRatingValue = value; OnPropertyChanged("ShortTermRatingValue"); OnPropertyChanged("IsShortTermRatingValueOther"); } }

        [Browsable(false)]
        [XmlIgnore]
        public bool IsShortTermRatingValueOther { get { return ShortTermRatingValue == ShortTermCreditRatingType.Other; } }

        private string _ShortTermRatingValueOther;
        /// <summary>
        /// Якщо в полі ShortTermRatingValue обрано "Інше" (Other)
        /// </summary>
        [DisplayName("Короткотермінове значення рейтингу(якщо інше)")]
        [UIConditionalVisibility("IsShortTermRatingValueOther")]
        public string ShortTermRatingValueOther { get { return _ShortTermRatingValueOther; } set { _ShortTermRatingValueOther = value; OnPropertyChanged("ShortTermRatingValueOther"); } }

        public override string ToString()
        {
            return string.Format("{0}, {1} / {2}", IsAgencyOther ? AgencyOther.Name : WellKnownAgency.ToString(), IsLongMidTermRatingValueOther ? LongMidTermRatingValueOther : LongMidTermRatingValue.ToString(), IsShortTermRatingValueOther ? ShortTermRatingValueOther : ShortTermRatingValue.ToString());
        }
    }
}
