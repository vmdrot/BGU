using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Інформація про позику
    /// </summary>
    /// <seealso cref="IndebtnessInfoBase"/>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.LoanInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class LoanInfo : IndebtnessInfoBase
    {

        public LoanInfo()
            : base()
        {
            IsBankDebt = true;
        }

        private BankInfo _LendingBank;
        [DisplayName("Банк-позичальник")]
        [Description("Банк, що надав кредит")]
        [UIConditionalVisibility("IsBankDebt")]
        public BankInfo LendingBank { get { return _LendingBank; } set { _LendingBank = value; OnPropertyChanged("LendingBank"); } }


        private string _AgreementNr;
        /// <summary>
        /// для банківських позик - обов'язковий
        /// </summary>
        [DisplayName("№ договору")]
        [UIUsageTextBox(HorizontalAlignment="Left", IsMultiline=false, MaxWidth="350", MinWidth="150")]
        public string AgreementNr { get { return _AgreementNr; } set { _AgreementNr = value; OnPropertyChanged("AgreementNr"); } }

        private DateTime _AgreementDt;
        /// <summary>
        /// обов'язкове
        /// </summary>
        [DisplayName("Дата договору")]
        [Required]
        public DateTime AgreementDt { get { return _AgreementDt; } set { _AgreementDt = value; OnPropertyChanged("AgreementDt"); } }

        public override string ToString()
        {
            return string.Format("№ {0} від {1}, {2}", AgreementNr, AgreementDt,  base.ToString());
        }
    }
}
