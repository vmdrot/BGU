using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    public class PersonBusinessReputationInfo : NotifyPropertyChangedBase
    {

        private GenericPersonID _Person; 
        public GenericPersonID Person { get { return _Person; } set { _Person = value; OnPropertyChanged("Person"); } }


        private bool _HasOutstandingLoansWithBanks;
        /// <summary>
        /// Інформація про кредити, одержані особою:
        /// </summary>
        [DisplayName("Чи є кредити, одержані й непогашені особою  в  банках?")]
        [Description("(Станом на дату подання анкети)")]
        [Required]
        public bool HasOutstandingLoansWithBanks { get { return _HasOutstandingLoansWithBanks; } set { _HasOutstandingLoansWithBanks = value; OnPropertyChanged("HasOutstandingLoansWithBanks"); } }

        private List<LoanInfo> _OutstandingLoansWithBanksDetails;
        /// <summary>
        /// Інформація про кредити, одержані особою:
        /// </summary>
        [DisplayName("Інформація про кредити, одержані особою")]
        [Description("(номер і дата договору про надання кредиту, сума кредиту, термін погашення кредиту, сума заборгованості за договором на дату подання анкети)")]
        [Required("HasOutstandingLoansWithBanks == true")]
        [UIConditionalVisibility("HasOutstandingLoansWithBanks")]
        [UIUsageDataGridParams(IsOneColumn = true, OneDataColumnHeader = "Деталі по кредитам")]
        public List<LoanInfo> OutstandingLoansWithBanksDetails { get { return _OutstandingLoansWithBanksDetails; } set { _OutstandingLoansWithBanksDetails = value; OnPropertyChanged("OutstandingLoansWithBanksDetails"); } }

        private bool _HasNoImperfectReputationSigns;
        /// <summary>
        /// 17. Чи є щодо юридичної особи ознаки відсутності бездоганної ділової репутації, визначені нормативно-правовим
        /// актом Національного банку України про порядок реєстрації та ліцензування банків [якщо таких ознак немає, то
        /// зазначається “Стверджую, що немає ознак відсутності бездоганної ділової репутації стосовно _______ (зазначається
        /// повне найменування юридичної особи)”; якщо такі ознаки є, то здійснюється опис ознаки (ознак) відсутності
        /// бездоганної ділової репутації.
        /// </summary>
        [DisplayName("Стверджую, що немає ознак відсутності бездоганної ділової репутації")]
        [Description("Стверджую, що немає ознак відсутності бездоганної ділової репутації стосовно _______ (зазначається найменування / П.І.Б. особи)")]
        [Required]
        public bool HasNoImperfectReputationSigns { get { return _HasNoImperfectReputationSigns; } set { _HasNoImperfectReputationSigns = value; OnPropertyChanged("HasNoImperfectReputationSigns"); OnPropertyChanged("IsImperfectReputationDetailsVisible"); OnPropertyChanged("IsImperfectReputationDetailsVisible"); } }

        private ImperfectBusinessReputationInfo _ImperfectReputationDetails;
        /// <summary>
        /// 17. Якщо щодо юридичної особи є ознаки відсутності бездоганної ділової репутації, визначені нормативно-правовим
        /// актом Національного банку України про порядок реєстрації та ліцензування банків, то здійснюється опис ознаки (ознак) відсутності
        /// бездоганної ділової репутації].
        /// </summary>
        [DisplayName("Ознаки відсутності бездоганної ділової репутації")]
        [Description("Опис наявних ознак відсутності бездоганної ділової репутації")]
        [Required("HasNoImperfectReputationSigns == false")]
        [UIConditionalVisibility("IsImperfectReputationDetailsVisible")]
        public ImperfectBusinessReputationInfo ImperfectReputationDetails { get { return _ImperfectReputationDetails; } set { _ImperfectReputationDetails = value; OnPropertyChanged("ImperfectReputationDetails"); } }

        [Browsable(false)]
        public bool IsImperfectReputationDetailsVisible { get { return HasNoImperfectReputationSigns == false; } }

        private bool _IsAMLEtcLegislationKept;
        /// <summary>
        /// 18. Стверджую, що  особа _______ (зазначається повне найменування/П.І.Б. особи) належним чином
        /// виконує вимоги законодавства України або законодавства країни свого громадянства з питань запобігання та протидії
        /// легалізації (відмиванню) доходів, одержаних злочинним шляхом, та фінансування тероризму.
        /// </summary>
        [DisplayName("Вимоги законодавства дотримано")]
        [Description("Стверджую, що особа _______ (зазначається повне найменування/П.І.Б. особи) належним чином виконує вимоги законодавства України або законодавства країни свого громадянства з питань запобігання та протидії легалізації (відмиванню) доходів, одержаних злочинним шляхом, та фінансування тероризму.")]
        [Browsable(true)]
        public bool IsAMLEtcLegislationKept { get { return _IsAMLEtcLegislationKept; } set { _IsAMLEtcLegislationKept = value; OnPropertyChanged("IsAMLEtcLegislationKept"); } }

        public override string ToString()
        {
            //Person
            //HasOutstandingLoansWithBanks
            //OutstandingLoansWithBanksDetails
            //HasNoImperfectReputationSigns
            //ImperfectReputationDetails
            //IsAMLEtcLegislationKept

            //todo - with StringBuilder

            return string.Format("{0}", Person);
        }
    }
}
