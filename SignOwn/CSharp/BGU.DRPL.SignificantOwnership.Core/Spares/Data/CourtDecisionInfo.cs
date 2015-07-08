using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;
using Evolvex.Utility.Core.ComponentModelEx;
using System.ComponentModel;
using System.Xml.Serialization;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Рішення суду
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.CourtDecisionInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class CourtDecisionInfo : NotifyPropertyChangedBase
    {
        private CourtInfo _Court; 
        [DisplayName("Суд")]
        [Description("Суд, що виніс рішення")]
        public CourtInfo Court { get { return _Court; } set { _Court = value; OnPropertyChanged("Court"); } }

        private CourtDecisionType _DecisionType;
        [DisplayName("Тип рішення")]
        [Description("Тип рішення")]
        public CourtDecisionType DecisionType { get { return _DecisionType; } set { _DecisionType = value; OnPropertyChanged("DecisionType"); } }


        [Browsable(false)]
        [XmlIgnore]
        public bool IsCourtDecisionSentence { get { return DecisionType == CourtDecisionType.Sentence; } }


        private DateTime _DecisionDate;
        [DisplayName("Дата рішення")]
        [Description("Дата винесення судом рішення")]
        public DateTime DecisionDate { get { return _DecisionDate; } set { _DecisionDate = value; OnPropertyChanged("DecisionDate"); } }

        private string _DecisionRegistryID;
        [DisplayName("№ рішення")]
        [Description("Реєстраційний № рішення (у відповідному реєстрі судових рішень)")]
        public string DecisionRegistryID { get { return _DecisionRegistryID; } set { _DecisionRegistryID = value; OnPropertyChanged("DecisionRegistryID"); } }
        
        private string _DecisionTextSummary;

        [DisplayName("Зміст рішення")]
        [Description("Резюме чи повний зміст рішення (залежно від того, як того вимагає контекст)")]
        [Multiline]
        public string DecisionTextSummary { get { return _DecisionTextSummary; } set { _DecisionTextSummary = value; OnPropertyChanged("DecisionTextSummary"); } }
    }
}
