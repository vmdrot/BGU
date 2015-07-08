using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;
using System.Xml.Serialization;
using BGU.DRPL.SignificantOwnership.Utility;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Інформація про банкрутство (юр.особи)
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.BankruptcyInvestigationInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class BankruptcyInvestigationInfo : NotifyPropertyChangedBase
    {
        public BankruptcyInvestigationInfo()
        {
            this.CourtDecisions = new List<CourtDecisionInfo>();
        }

        private DateTime _CaseFiledDt;
        [DisplayName("Дата порушення справи про банкрутство")]
        [Description("Дата відкриття справи")]
        [Required]
        public DateTime CaseFiledDt { get { return _CaseFiledDt; } set { _CaseFiledDt = value; OnPropertyChanged("CaseFiledDt"); } }


        private BankruptcyCaseResolutionType _CurrentStatus;
        [DisplayName("Статус")]
        [Description("Поточний статус справи")]
        [Required]
        public BankruptcyCaseResolutionType CurrentStatus { get { return _CurrentStatus; } set { _CurrentStatus = value; OnPropertyChanged("CurrentStatus"); OnPropertyChanged("IsCurrentStatusNotNoneOrCaseFiled"); } }
        //

        [Browsable(false)]
        [XmlIgnore]
        public bool IsCurrentStatusNotNoneOrCaseFiled { get { return CurrentStatus != BankruptcyCaseResolutionType.None && CurrentStatus != BankruptcyCaseResolutionType.CaseFiled; } }


        private DateTime? _InCurrentStatusSince;
        [DisplayName("Дата набуття поточного статусу")]
        [Description("Перебуває в нинішньому статусі починаючи з...")]
        [Required("CurrentStatus not in (None, CaseFiled)")]
        [UIConditionalVisibility("IsCurrentStatusNotNoneOrCaseFiled")]
        public DateTime? InCurrentStatusSince { get { return _InCurrentStatusSince; } set { _InCurrentStatusSince = value; OnPropertyChanged("InCurrentStatusSince"); } }

        private List<CourtDecisionInfo> _CourtDecisions;
        [DisplayName("Список судових рішень у справі")]
        [Description("Перелік судових рішень по справі банкрутства")]
        [Required]
        public List<CourtDecisionInfo> CourtDecisions { get { return _CourtDecisions; } set { _CourtDecisions = value; OnPropertyChanged("CourtDecisions"); } }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Порушено справу {0:DD.MM.YYYY}",CaseFiledDt);
            sb.AppendFormat(",статус - {0}", EnumType.GetEnumDescription(CurrentStatus));
            if(InCurrentStatusSince != null)
                sb.AppendFormat(" з {0:DD.MM.YYYY}",InCurrentStatusSince);
            sb.AppendFormat(", судових рішень - {0}", CourtDecisions);
  
            return sb.ToString();
        }
    }
}
