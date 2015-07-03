using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;
using System.Xml.Serialization;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Інформація про правопорушення/судимість (зокрема, у анкеті на кандидатів у керівники/члени наглядової ради)
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.BreachOfLawRecordInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class BreachOfLawRecordInfo : NotifyPropertyChangedBase
    {

        public BreachOfLawRecordInfo()
        {
            JurisdictionCountry = CountryInfo.UKRAINE;
        }

        private BreachOfLawType _BreachType;
        /// <summary>
        /// Обрати з переліку, обов'язкове, хоча б Інше
        /// </summary>
        [DisplayName("Тип правопорушення")]
        [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.EnumLookupEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Required]
        public BreachOfLawType BreachType { get { return _BreachType; } set { _BreachType = value; OnPropertyChanged("BreachType"); } }

        private string _CourtName;
        /// <summary>
        /// Суд, що виніс рішення, обов'язкове поле
        /// </summary>
        [DisplayName("Суд")]
        [Required]
        public string CourtName { get { return _CourtName; } set { _CourtName = value; OnPropertyChanged("CourtName"); } }

        private string _CourtNameUkr;
        /// <summary>
        /// Суд, що виніс рішення - укр. (якщо іноземна юрисдикція)
        /// </summary>
        [DisplayName("Суд (укр.)")]
        [UIConditionalVisibility("IsNonResident")]
        public string CourtNameUkr { get { return _CourtNameUkr; } set { _CourtNameUkr = value; OnPropertyChanged("CourtNameUkr"); } }

        private CountryInfo _JurisdictionCountry;
        /// <summary>
        /// Юрисдикція, за змовчанням - Україна
        /// </summary>
        [DisplayName("Країна підсудності")]
        [Required]
        public CountryInfo JurisdictionCountry { get { return _JurisdictionCountry; } set { _JurisdictionCountry = value; OnPropertyChanged("JurisdictionCountry"); OnPropertyChanged("IsNonResident"); } }

        [Browsable(false)]
        [XmlIgnore]
        public bool IsNonResident { get { return JurisdictionCountry != null && JurisdictionCountry != CountryInfo.UKRAINE; } }

        private DateTime _SentenceDate;
        /// <summary>
        /// обов'язкове
        /// </summary>
        [DisplayName("Дата вироку")]
        [Required]
        public DateTime SentenceDate { get { return _SentenceDate; } set { _SentenceDate = value; OnPropertyChanged("SentenceDate"); } }

        private string _CodeOrLaw;
        /// <summary>
        /// обов'язкове
        /// </summary>
        [DisplayName("Закон/кодекс")]
        [Required]
        public string CodeOrLaw { get { return _CodeOrLaw; } set { _CodeOrLaw = value; OnPropertyChanged("CodeOrLaw"); } }

        private string _Articles;
        /// <summary>
        /// обов'язкове
        /// </summary>
        [DisplayName("Стаття(-і)")]
        [Required]
        [Multiline]
        public string Articles { get { return _Articles; } set { _Articles = value; OnPropertyChanged("Articles"); } }

        private SentenceType _Sentence;
        /// <summary>
        /// обов'язкове
        /// </summary>
        [DisplayName("Тип вироку")]
        [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.EnumLookupEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Required]
        public SentenceType Sentence { get { return _Sentence; } set { _Sentence = value; OnPropertyChanged("Sentence"); } }

        private string _OtherSanctionDetails;
        /// <summary>
        /// якщо були (інші санкції)
        /// </summary>
        [DisplayName("Інші санкції")]
        [Multiline]
        public string OtherSanctionDetails { get { return _OtherSanctionDetails; } set { _OtherSanctionDetails = value; OnPropertyChanged("OtherSanctionDetails"); } }

        private bool _IsConvictionSettled;
        /// <summary>
        /// обов'язкове
        /// </summary>
        [DisplayName("Судимість погашена?")]
        [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.BooleanEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Required]
        public bool IsConvictionSettled { get { return _IsConvictionSettled; } set { _IsConvictionSettled = value; OnPropertyChanged("IsConvictionSettled"); } }

        private DateTime? _SettledDate;
        /// <summary>
        /// якщо IsConvictionSettled == true, то обов'язкове
        /// </summary>
        [DisplayName("Дата погашення судимості")]
        [UIConditionalVisibility("IsConvictionSettled")]
        public DateTime? SettledDate { get { return _SettledDate; } set { _SettledDate = value; OnPropertyChanged("SettledDate"); } }

    }
}
