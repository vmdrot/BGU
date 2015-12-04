using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;
using System.Xml.Serialization;
using BGU.DRPL.SignificantOwnership.Utility;

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
            
        }

        private BreachOfLawType _BreachType;
        /// <summary>
        /// Обрати з переліку, обов'язкове, хоча б Інше
        /// </summary>
        [DisplayName("Тип правопорушення")]
        [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.EnumLookupEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Required]
        public BreachOfLawType BreachType { get { return _BreachType; } set { _BreachType = value; OnPropertyChanged("BreachType"); } }

        private CourtDecisionInfo _CourtDecision;
        [DisplayName("Рішення суду")]
        [Description("Відомості про рішення щодо притягнення до відповідальності")]
        public CourtDecisionInfo CourtDecision { get { return _CourtDecision; } set { _CourtDecision = value; OnPropertyChanged("CourtDecision"); OnPropertyChanged("IsCourtDecisionSentence"); } }

        private string _CodeOrLaw;
        /// <summary>
        /// обов'язкове
        /// </summary>
        [DisplayName("Закон/кодекс")]
        [Description("Закон/кодекс, згідно з яким було притягнуто до відповідальності")]
        [Required]
        [Multiline]
        public string CodeOrLaw { get { return _CodeOrLaw; } set { _CodeOrLaw = value; OnPropertyChanged("CodeOrLaw"); } }

        private string _Articles;
        /// <summary>
        /// обов'язкове
        /// </summary>
        [DisplayName("Стаття(-і)")]
        [Description("Стаття(-і), згідно з якою(-ими) було притягнуто до відповідальності")]
        [Required]
        [Multiline]
        public string Articles { get { return _Articles; } set { _Articles = value; OnPropertyChanged("Articles"); } }

        private SentenceType _Sentence;
        /// <summary>
        /// обов'язкове
        /// </summary>
        [DisplayName("Тип рішення")]
        [Description("Тип рішення про притягнення до відповідальності")]
        [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.EnumLookupEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Required("IsCourtDecisionSentence == true")]
        [UIConditionalVisibility("CourtDecision.IsCourtDecisionSentence")]
        public SentenceType Sentence { get {  return _Sentence; } set { _Sentence = value; OnPropertyChanged("Sentence"); OnPropertyChanged("IsDurationPenalty"); OnPropertyChanged("IsFinePenalty"); } }

        [Browsable(false)]
        [XmlIgnore]
        public bool IsDurationPenalty { get { return Sentence == SentenceType.Jailed || Sentence == SentenceType.Probation || Sentence == SentenceType.RemedialWorks; } }

        [Browsable(false)]
        [XmlIgnore]
        public bool IsFinePenalty { get { return Sentence == SentenceType.Fined; } }

        [DisplayName("Термін (років)")]
        [Description("Термін призначеного покарання (у роках)")]
        [UIConditionalVisibility("IsDurationPenalty")]
        public decimal? PenaltyDurationYrs { get; set; }

        [DisplayName("Штраф")]
        [Description("Сума (і валюта) накладеного штрафу")]
        [UIConditionalVisibility("IsFinePenalty")]
        public CurrencyAmount FineAmount { get; set; }

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
        [DisplayName("Правопорушення погашене?")]
        [Description("Чи закінчився строк після якого особа вважається такою, що не притягувалася до відповідальності?")]
        [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.BooleanEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Required]
        public bool IsConvictionSettled { get { return _IsConvictionSettled; } set { _IsConvictionSettled = value; OnPropertyChanged("IsConvictionSettled"); } }

        private DateTime? _SettledDate;
        /// <summary>
        /// якщо IsConvictionSettled == true, то обов'язкове
        /// </summary>
        [DisplayName("Дата погашення правопорушення")]
        [DisplayName("Дата закінчення строку після якого особа вважається такою, що не притягувалася до відповідальності")]
        [UIConditionalVisibility("IsConvictionSettled")]
        public DateTime? SettledDate { get { return _SettledDate; } set { _SettledDate = value; OnPropertyChanged("SettledDate"); } }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (CourtDecision != null)
            {
                if (CourtDecision.IsCourtDecisionSentence)
                    sb.AppendFormat("{0} ", EnumType.GetEnumDescription(Sentence));
            }

            if (IsDurationPenalty)
                sb.AppendFormat("{0} років", PenaltyDurationYrs);
            
            else if (IsFinePenalty)
                sb.AppendFormat("{0} штрафу", FineAmount);
            
            if(!string.IsNullOrEmpty(CodeOrLaw))
                sb.AppendFormat(", {0} ", CodeOrLaw);
            
            if (!string.IsNullOrEmpty(Articles))
                sb.AppendFormat(", {0} ", Articles);

            if (IsConvictionSettled)
                sb.AppendFormat(", погашено {0:DD.MM.YYYY}", SettledDate);

            return sb.ToString();
        }
    }
}
