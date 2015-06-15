using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Інформація про банкрутство (юр.особи)
    /// </summary>
    public class BankruptcyInvestigationInfo
    {
        [DisplayName("Дата порушення справи про банкрутство")]
        [Description("Дата відкриття справи")]
        [Required]
        public DateTime CaseFiledDt { get; set; }

        [DisplayName("Статус")]
        [Description("Поточний статус справи")]
        [Required]
        public BankruptcyCaseResolutionType CurrentStatus { get; set; }

        [DisplayName("Дата набуття поточного статусу")]
        [Description("Перебуває в нинішньому статусі починаючи з...")]
        [Required("CurrentStatus not in (None, CaseFiled)")]
        public DateTime? InCurrentStatusSince { get; set; }

        [DisplayName("Список судових рішень у справі")]
        [Description("Перелік судових рішень по справі банкрутства")]
        [Required]
        public List<CourtDecisionInfo> CourtDecisions { get; set; }
    }
}
