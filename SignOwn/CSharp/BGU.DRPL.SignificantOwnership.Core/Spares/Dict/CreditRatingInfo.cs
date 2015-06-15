using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Evolvex.Utility.Core.ComponentModelEx;
using System.ComponentModel;

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
    public class CreditRatingInfo
    {
        [Required]
        [DisplayName("Рейтингова аґенція (добре знана)")]
        public WellKnownCreditRatingAgencyType WellKnownAgency { get; set; }
        /// <summary>
        /// Якщо в полі WellKnownAgency обрано "Інше" (Other)
        /// </summary>
        [DisplayName("Рейтингова аґенція (інша)")]
        public RatingAgencyInfo AgencyOther { get; set; }
        [Required]
        [DisplayName("Довго- та середньотермінове значення рейтингу(стандартне)")]
        public LongTermCreditRatingType LongMidTermRatingValue { get; set; }
        /// <summary>
        /// Якщо в полі LongMidTermRatingValue обрано "Інше" (Other)
        /// </summary>
        [DisplayName("Довго- та середньотермінове значення рейтингу(якщо інше)")]
        public string LongMidTermRatingValueOther { get; set; }
        [Required]
        [DisplayName("Короткотермінове значення рейтингу(стандартне)")]
        public ShortTermCreditRatingType ShortTermRatingValue { get; set; }
        /// <summary>
        /// Якщо в полі ShortTermRatingValue обрано "Інше" (Other)
        /// </summary>
        [DisplayName("Короткотермінове значення рейтингу(якщо інше)")]
        public string ShortTermRatingValueOther { get; set; }
    }
}
