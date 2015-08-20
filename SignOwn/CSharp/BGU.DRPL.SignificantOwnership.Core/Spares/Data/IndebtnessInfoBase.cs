using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;
using System.Xml.Serialization;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Базовий тип (клас) для інформації про позику чи іншу заборгованість (містить усі спільні поля)
    /// </summary>
    public class IndebtnessInfoBase : NotifyPropertyChangedBase
    {
        private bool _IsBankDebt;
        [DisplayName("Кредитор є банком")]
        [Description("(відзначте галочку, якщо позику було взято у банку, або ж зніміть, якщо борг виник перед особою, що не є банком)")]
        [DefaultValue(false)]
        public bool IsBankDebt { get { return _IsBankDebt; } set { _IsBankDebt = value; OnPropertyChanged("IsBankDebt"); OnPropertyChanged("IsNonBankDebt"); } }


        [Browsable(false)]
        [XmlIgnore]
        public bool IsNonBankDebt { get { return !IsBankDebt; } }

        private GenericPersonID _Lender;
        [DisplayName("Кредитор")]
        [Description("(інший кредитор, окрім банків)")]
        [Required]
        [UIConditionalVisibility("IsNonBankDebt")]
        public GenericPersonID Lender { get { return _Lender; } set { _Lender = value; OnPropertyChanged("Lender"); } }


        private GenericPersonID _Borrower;
        [DisplayName("Позичальник")]
        [Required]
        [UIConditionalVisibility("IsBorrowerOtherThanApplicant")]
        public GenericPersonID Borrower { get { return _Borrower; } set { _Borrower = value; OnPropertyChanged("Borrower"); } }

        [Browsable(false)]
        [XmlIgnore]
        public bool IsBorrowerOtherThanApplicant { get { return false; } }


        private string _DebtSubject;
        [DisplayName("Суть заборгованості")]
        [Required]
        [Multiline]
        public string DebtSubject { get { return _DebtSubject; } set { _DebtSubject = value; OnPropertyChanged("DebtSubject"); } }

        private CurrencyAmount _Principal;
        [DisplayName("Основна сума боргу")]
        [Required]
        public CurrencyAmount Principal { get { return _Principal; } set { _Principal = value; OnPropertyChanged("Principal"); } }

        //[DisplayName("Предмет боргу")]
        //[Description("У зв'язку з чим виник борг; якщо позика - для чого було надано, і т.д.")]
        //[Required]
        //[Multiline]
        //public string IndebtnessSubject { get; set; }

        private DateTime? _RepaymentDueDate;
        /// <summary>
        /// обов'язкове, якщо передбачена дата погашення; може бути й безстрокова позика.
        /// </summary>
        [DisplayName("Дата погашення")]
        public DateTime? RepaymentDueDate { get { return _RepaymentDueDate; } set { _RepaymentDueDate = value; OnPropertyChanged("RepaymentDueDate"); } }


        private CurrencyAmount _OutstandingPricipal;
        [DisplayName("Залишок заборгованості")]
        [Required]
        public CurrencyAmount OutstandingPricipal { get { return _OutstandingPricipal; } set { _OutstandingPricipal = value; OnPropertyChanged("OutstandingPricipal"); } }

        private bool _IsOverdue;
        [DisplayName("Прострочена заборгованість?")]
        [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.BooleanEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Required]
        public bool IsOverdue { get { return _IsOverdue; } set { _IsOverdue = value; OnPropertyChanged("IsOverdue"); } }

        private DateTime? _OverdueSince;
        /// <summary>
        /// якщо є прострочка
        /// </summary>
        [DisplayName("Прострочено з ... (дата)")]
        [UIConditionalVisibility("IsOverdue")]
        public DateTime? OverdueSince { get { return _OverdueSince; } set { _OverdueSince = value; OnPropertyChanged("OverdueSince"); } }

        private CurrencyAmount _PrincipalOverdue;
        /// <summary>
        /// Обов'язкове, якщо IsOverdue == true 
        /// </summary>
        [DisplayName("Сума простроченої заборгованості")]
        [UIConditionalVisibility("IsOverdue")]
        public CurrencyAmount PrincipalOverdue { get { return _PrincipalOverdue; } set { _PrincipalOverdue = value; OnPropertyChanged("PrincipalOverdue"); } }

        private string _OverdueDetails;
        /// <summary>
        /// Обов'язкове, якщо IsOverdue == true 
        /// </summary>
        [DisplayName("Деталі прострочки")]
        [Description("Додаткова інформація (окрім дати й суми) щодо простроченої заборгованості")]
        [Multiline]
        [UIConditionalVisibility("IsOverdue")]
        public string OverdueDetails { get { return _OverdueDetails; } set { _OverdueDetails = value; OnPropertyChanged("OverdueDetails"); } }

        private string _OverdueReasons;
        /// <summary>
        /// Обов'язкове, якщо IsOverdue == true 
        /// </summary>
        [DisplayName("Причини прострочки")]
        [Description("Причини виникнення простроченої заборгованості")]
        [Multiline]
        [UIConditionalVisibility("IsOverdue")]
        public string OverdueReasons { get { return _OverdueReasons; } set { _OverdueReasons = value; OnPropertyChanged("OverdueReasons"); } }

        public override string ToString()
        {
            return string.Format("позичальник: {0}, Кредитор: {1}, {2}\t{3}...", Borrower, Lender, Principal, DebtSubject);
        }

    }
}
