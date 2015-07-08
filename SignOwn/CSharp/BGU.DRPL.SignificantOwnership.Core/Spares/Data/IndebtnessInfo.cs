using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Інформація про іншу заборгованість (окрім позики)
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.IndebtnessInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class IndebtnessInfo : IndebtnessInfoBase
    {
        private bool _IsRepaymentPlanned;
        [DisplayName("Чи планую погашення?")]
        [Description("Чи планую погашення боргу/виконання зобов'язань?")]
        [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.BooleanEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Required]
        public bool IsRepaymentPlanned { get { return _IsRepaymentPlanned; } set { _IsRepaymentPlanned = value; OnPropertyChanged("IsRepaymentPlanned"); } }

        private DateTime? _PlannedRepaymentDate;
        [DisplayName("Планована дата погашення")]
        [UIConditionalVisibility("IsRepaymentPlanned")]
        public DateTime? PlannedRepaymentDate { get { return _PlannedRepaymentDate; } set { _PlannedRepaymentDate = value; OnPropertyChanged("PlannedRepaymentDate"); } }

        private string _RepaymentPlans;
        [DisplayName("Плани щодо погашення")]
        [Required]
        [Multiline]
        public string RepaymentPlans { get { return _RepaymentPlans; } set { _RepaymentPlans = value; OnPropertyChanged("RepaymentPlans"); } }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendFormat(", {0}планую погашати", IsRepaymentPlanned ? "" : "не ");
            if(PlannedRepaymentDate != null)
                sb.AppendFormat("({0:DD.MM.YYYY})", (DateTime)PlannedRepaymentDate);
            if(!string.IsNullOrEmpty(RepaymentPlans))
                sb.AppendFormat(", {0}", RepaymentPlans);

            return sb.ToString();
        }
    }
}
