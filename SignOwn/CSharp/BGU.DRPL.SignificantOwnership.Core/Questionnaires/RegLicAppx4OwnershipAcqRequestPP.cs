using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;
using BGU.DRPL.SignificantOwnership.Core.Spares;
using Evolvex.Utility.Core.ComponentModelEx;
using Evolvex.Utility.Core.Common;
using System.Xml.Serialization;

namespace BGU.DRPL.SignificantOwnership.Core.Questionnaires
{
    /// <summary>
    /// АНКЕТА фізичної особи
    /// Додаток 4 до Положення про порядок реєстрації та ліцензування банків, відкриття відокремлених підрозділів
    /// file                                  : f364524n1224.doc
    /// Рівень складності                     : 10
    /// (оціночний, шкала від 1 до 10)
    /// Пріоритетність                        : Hi  (Легенда: Hi - Висока, Lo - Низька, Mid - Середня, Hold - Поки що притримати)
    /// Подавач анкети                        : PP (Легенда: LP - юр.особа, PP - фіз.особа, BK - банк)
    /// Чи заповнюватиметься он-лайн          : Так
    /// Первинну розробку структури завершено : Так
    /// Структуру фіналізовано                : Ні
    /// (=остаточно узгоджено 
    /// з бізнес-користувачами)
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.RegLicAppx4PhysPQuest_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class RegLicAppx4OwnershipAcqRequestPP : QuestionnaireBase, IGenericPersonsService, IAddressesService
    {
        private static readonly ILog log = Logging.GetLogger(typeof(RegLicAppx4OwnershipAcqRequestPP));

        private const string CATEGORY_I = "І. Інформація про фізичну особу";
        private const string CATEGORY_II = "ІІ. Інформація про наміри щодо набуття (збільшення) істотної участі в банку";
        private const string CATEGORY_III = "ІІІ. Відносини фізичної особи з іншими особами";
        private const string CATEGORY_IV = "IV. Ділова репутація";
        private const string CATEGORY_SignEtc = "Підписи і т.п.";

        public RegLicAppx4OwnershipAcqRequestPP()
        {
            this.BankingAccounts = new List<BankAccountInfo>();
            this.EmploymentRecords = new List<EmploymentRecordInfo>();
            this.MentionedIdentities = new List<GenericPersonInfo>();
            this.PersonsLinks = new List<PersonsAssociation>();
        }

        private BankInfo _BankRef;
        /// <summary>
        /// Лише укр.банки, лише головні контори
        /// </summary>
        [DisplayName("Банк")]
        [Description("Банк")]
        [Required]
        public BankInfo BankRef
        {
            get { return _BankRef; }
            set
            {
                //log.Debug("set_BankRef ({0})", value);
                //if (value != null && !string.IsNullOrEmpty(value.Name) && value.Name.IndexOf("НБУ") != -1)
                //    return;
                _BankRef = value;
                AddBankToMentionedIdentities(_BankRef); OnPropertyChanged("BankRef");
            }
        }

        #region І. Інформація про фізичну особу
        private GenericPersonID _Acquiree;
        [Category(CATEGORY_I)]
        [DisplayName("Фізособа-заявник")]
        [Description("1. Інформація про особу")]
        [Required]
        public GenericPersonID Acquiree { get { return _Acquiree; } set { _Acquiree = value; OnPropertyChanged("Acquiree"); } }

        private List<EmploymentRecordInfo> _EmploymentRecords;
        [Category(CATEGORY_I)]
        [DisplayName("Досвід роботи")]
        [Description("1.8. Займані посади за останні п'ять років")]
        [Required]
        [UIUsageDataGridParams(IsOneColumn=true, OneDataColumnHeader="Місце роботи")]
        public List<EmploymentRecordInfo> EmploymentRecords { get { return _EmploymentRecords; } set { _EmploymentRecords = value; OnPropertyChanged("EmploymentRecords"); } }

        private List<BankAccountInfo> _BankingAccounts;
        /// <summary>
        /// Усередині кожного BankAccountInfo, обов'язково ідентифікувати хоча б банк (поки що, принаймні).
        /// Якщо він хоче вказати №№-и рахунків - не забороняти :)
        /// </summary>
        [Category(CATEGORY_I)]
        [DisplayName("Рахунки в банках")]
        [Description("1.6. Перелік банків, у яких відкрито рахунки")]
        [Required]
        [UIUsageDataGridParams(IsOneColumn = true, OneDataColumnHeader = "Рахунки")]
        public List<BankAccountInfo> BankingAccounts { get { return _BankingAccounts; } set { _BankingAccounts = value; OnPropertyChanged("BankingAccounts"); } }

        private TotalOwnershipSummaryInfo _TotalExistingOwnershipWithBank;
        [Category(CATEGORY_I)]
        [DisplayName("5. Наявна участь у банку")]
        [Description("5. Інформація про розмір наявної участі фізичної особи в банку")]
        [Required]
        [Browsable(true)]
        public TotalOwnershipSummaryInfo TotalExistingOwnershipWithBank { get { return _TotalExistingOwnershipWithBank; } set { _TotalExistingOwnershipWithBank = value; OnPropertyChanged("TotalExistingOwnershipWithBank"); } }

        private bool _IsBankAssociatedPerson;
        [Category(CATEGORY_I)]
        [DisplayName("6. Чи є фізична особа пов’язаною з банком (якщо так, то зазначити код типу пов’язаності)?")]
        [Description("6. Чи є фізична особа пов’язаною з банком (якщо так, то зазначити код типу пов’язаності)?")]
        public bool IsBankAssociatedPerson { get { return _IsBankAssociatedPerson; } set { _IsBankAssociatedPerson = value; OnPropertyChanged("IsBankAssociatedPerson"); } }


        private BankAssociatedPersonsCode315p _BankAssociatedPersonCode;
        [Category(CATEGORY_I)]
        [DisplayName("6. Чи є фізична особа пов’язаною з банком (якщо так, то зазначити код типу пов’язаності)?")]
        [Description("6. Чи є фізична особа пов’язаною з банком (якщо так, то зазначити код типу пов’язаності)?")]
        [UIConditionalVisibility("IsBankAssociatedPerson")]
        public BankAssociatedPersonsCode315p BankAssociatedPersonCode { get { return _BankAssociatedPersonCode; } set { _BankAssociatedPersonCode = value; OnPropertyChanged("BankAssociatedPersonCode"); } }
        #endregion

        #region ІІ. Інформація про наміри щодо набуття (збільшення) істотної участі в банку

        private TotalOwnershipSummaryInfo _TotalOwnershipWithBankDiff;
        /// <summary>
        /// 6. Інформація про розмір участі, що набувається (збільшується):
        /// Наміри щодо набуття/збільшення участі в банку
        /// </summary>
        [Category(CATEGORY_II)]
        [Browsable(true)]
        [DisplayName("6. Наміри щодо набуття/збільшення участі")]
        [Description("6. Інформація про розмір участі, що набувається (збільшується): Наміри щодо набуття/збільшення участі в банку")]
        public TotalOwnershipSummaryInfo TotalOwnershipWithBankDiff { get { return _TotalOwnershipWithBankDiff; } set { _TotalOwnershipWithBankDiff = value; OnPropertyChanged("TotalOwnershipWithBankDiff"); } }

        private TotalOwnershipSummaryInfo _TotalTargetedOwnershipWithBank;
        /// <summary>
        /// 6. Інформація про розмір участі, що набувається (збільшується):
        /// Майбутня участь особи в банку з урахуванням намірів щодо набуття/збільшення істотної участі
        /// </summary>
        [Category(CATEGORY_II)]
        [Browsable(true)]
        [DisplayName("7. Майбутня участь особи в банку")]
        [Description("7. Інформація про розмір участі, що набувається (збільшується): Майбутня участь особи в банку з урахуванням намірів щодо набуття/збільшення істотної участі")]
        public TotalOwnershipSummaryInfo TotalTargetedOwnershipWithBank { get { return _TotalTargetedOwnershipWithBank; } set { _TotalTargetedOwnershipWithBank = value; OnPropertyChanged("TotalTargetedOwnershipWithBank"); } }

        private SignificantOwnershipAcquisitionWaysInfo _AcquisitionWays;
        /// <summary>
        /// 7. Набуття/збільшення істотної участі в банку відбуватиметься у спосіб (зазначити необхідне):
        /// 
        /// придбання акцій (паїв) банку на первинному ринку;
        /// придбання акцій (паїв) банку на вторинному ринку;
        /// набуття/збільшення істотної участі в банку опосередковано шляхом придбання корпоративних прав юридичних осіб у структурі власності банку;
        /// набуття/збільшення істотної участі в банку у зв’язку з передаванням права голосу за довіреністю;
        /// набуття опосередкованої істотної участі в банку у зв’язку із здійсненням значного або вирішального впливу на управління та діяльність банку незалежно від формального володіння. 
        /// </summary>
        [Category(CATEGORY_II)]
        [DisplayName("8. Спосіб(-оби) набуття/збільшення істотної участі в банку")]
        [Description("8. Набуття/збільшення істотної участі в банку відбуватиметься у спосіб (зазначити необхідне)")]
        [Required]
        public SignificantOwnershipAcquisitionWaysInfo AcquisitionWays { get { return _AcquisitionWays; } set { _AcquisitionWays = value; OnPropertyChanged("AcquisitionWays"); } }

        private List<IPOSharesPurchaseInfo> _IPOPurchase;
        [Category(CATEGORY_II)]
        [DisplayName("Придбання на первинному ринку")]
        [Description("9. Інформація про намір щодо придбання акцій (паїв) банку на первинному ринку:")]
        [Required("AcquisitionWays.IsIPO == true")]
        [UIConditionalVisibility("AcquisitionWays.IsIPO")]
        [UIUsageDataGridParams(IsOneColumn = true, OneDataColumnHeader = "Придбання на IPO")]
        public List<IPOSharesPurchaseInfo> IPOPurchase { get { return _IPOPurchase; } set { _IPOPurchase = value; OnPropertyChanged("IPOPurchase"); } }

        private List<SecondaryMarketSharesPurchaseInfo> _SecondaryMarketPurchases;
        [Category(CATEGORY_II)]
        [DisplayName("10. Придбання на вторинному ринку")]
        [Description("10. Інформація про намір щодо придбання акцій (паїв) банку на вторинному ринку та/або стосовно правочинів щодо набуття (збільшення) опосередкованої участі в банку (крім набуття істотної участі в результаті передавання особі права голосу або незалежно від формального володіння)")]
        [Required("AcquisitionWays.IsSecondaryMarketPurchase == true || AcquisitionWays.IsPurchaseByImplicitOwnership == true")]
        [UIConditionalVisibility("AcquisitionWays.IsSecondaryMarketOrImplicitOwnershipPurchase")]
        [UIUsageDataGridParams(IsOneColumn = true, OneDataColumnHeader = "Придбання на вторинному ринку")]
        public List<SecondaryMarketSharesPurchaseInfo> SecondaryMarketPurchases { get { return _SecondaryMarketPurchases; } set { _SecondaryMarketPurchases = value; OnPropertyChanged("SecondaryMarketPurchases"); } }

        private List<PowerOfAttorneySharesPurchaseInfo> _AquisitionByPoAttorneys;
        [Category(CATEGORY_II)]
        [DisplayName("11. Набуття за довіреністю")]
        [Description("11. Інформація про намір щодо набуття опосередкованої істотної участі в банку за довіреністю")]
        [Required("AcquisitionWays.IsPurchaseByPowOfAtt == true")]
        [UIConditionalVisibility("AcquisitionWays.IsPurchaseByPowOfAtt")]
        [UIUsageDataGridParams(IsOneColumn = true, OneDataColumnHeader = "Набуття за довіренністю")]
        public List<PowerOfAttorneySharesPurchaseInfo> AquisitionByPoAttorneys { get { return _AquisitionByPoAttorneys; } set { _AquisitionByPoAttorneys = value; OnPropertyChanged("AquisitionByPoAttorneys"); } }

        private List<SignificantOrDecisiveInfulenceInfo> _AquisitionByInfluence;
        [Category(CATEGORY_II)]
        [DisplayName("12. Набуття у зв’язку із здійсненням впливу")]
        [Description("12. Інформація про набуття опосередкованої істотної участі в банку у зв’язку із здійсненням значного або вирішального впливу на управління та діяльність банку незалежно від формального володіння")]
        [Required("AcquisitionWays.IsAcquireByImplicitInfluence == true")]
        [UIConditionalVisibility("AcquisitionWays.IsAcquireByImplicitInfluence")]
        [UIUsageDataGridParams(IsOneColumn = true, OneDataColumnHeader = "Набуття за впливом")]
        public List<SignificantOrDecisiveInfulenceInfo> AquisitionByInfluence { get { return _AquisitionByInfluence; } set { _AquisitionByInfluence = value; OnPropertyChanged("AquisitionByInfluence"); } }

        private List<IncomeOriginInfo> _FundsOrigin;
        /// <summary>
        /// 13. Джерела походження коштів фізичної особи, за рахунок яких набуватиметься істотна участь у банку,
        /// _______________________________________________________________________________________________________.
        /// (прибуток, частина статутного капіталу, кошти фонду тощо)
        /// </summary>
        [Category(CATEGORY_II)]
        [DisplayName("13. Джерела  походження коштів фізичної особи")]
        [Description("13. Джерела походження коштів фізичної особи, за рахунок яких набуватиметься істотна участь у банку")]
        [Required]
        [UIUsageDataGridParams(IsOneColumn = true, OneDataColumnHeader = "Джерело")]
        public List<IncomeOriginInfo> FundsOrigin { get { return _FundsOrigin; } set { _FundsOrigin = value; OnPropertyChanged("FundsOrigin"); } }
        #endregion

        #region ІІІ. Відносини юридичної особи з іншими особами

        private List<PersonsAssociation> _PersonsLinks;
        /// <summary>
        /// Якщо є; попередження про відповідальність 
        /// за подачу завідомо неправдивих відомостей
        /// </summary>
        [Category(CATEGORY_III)]
        [DisplayName("14. Асоційовані особи фізичної особи")]
        [Description("14. Асоційовані особи фізичної особи; \nВідомості про пов'язаних осіб, що згадуються в анкеті;\nЗв'язки між особами-фігурантами анкети.")]
        [UIUsageDataGridParams(IsOneColumn = true, OneDataColumnHeader = "Опис зв'язку")]
        public List<PersonsAssociation> PersonsLinks { get { return _PersonsLinks; } set { _PersonsLinks = value; OnPropertyChanged("PersonsLinks"); } }

        private List<OwnershipStructure> _ExistingOwnershipDetailsHive;
        /// <summary>
        /// 1. Перелік юридичних осіб, у тому числі банків, в яких юридична особа має істотну участь або є ключовим учасником
        /// 14. Інформація про фізичних осіб, які володіють істотною участю в цій юридичній особі або є ключовими учасниками юридичної особи
        /// 15. Інформація про юридичних осіб, які володіють істотною участю в цій юридичній особі або є ключовими учасниками юридичної особи
        /// ----
        /// Доцільно розшифровку ланцюжків власності усіх структур, що фігурують в анкеті, скласти в це одне поле, оскільки не виключено, що власники-юр.особи повторюватимуться/фігуруватимуть в різних іпостасях в усіх 3-х пунктах (себто, і 13, і 14, і 15) 
        /// </summary>
        [Category(CATEGORY_III)]
        [DisplayName("15, 16, 17. Розшифровка ланцюжків власності")]
        [Description("Розшифровка ланцюжків власності усіх структур-фігурантів анкети:\n 15. Перелік юридичних осіб, у тому числі банків, в яких фізична особа має істотну участь або є ключовим учасником\n 17. Інформація про юридичних осіб, у яких асоційовані особи фізичної особи є власниками істотної участі \n 15. Інформація про юридичних осіб, які володіють істотною участю в цій юридичній особі або є ключовими учасниками юридичної особи")]
        [UIUsageDataGridParams(IsOneColumn = true, OneDataColumnHeader = "Ланцюжки власності")]
        public List<OwnershipStructure> ExistingOwnershipDetailsHive { get { return _ExistingOwnershipDetailsHive; } set { _ExistingOwnershipDetailsHive = value; OnPropertyChanged("ExistingOwnershipDetailsHive"); } }

        private bool _IsCurrently3rdPartyBoardMember;
        /// <summary>
        /// 16. Перелік юридичних осіб, до складу органів управління яких входить фізична особа:
        /// </summary>
        [Category(CATEGORY_III)]
        [DisplayName("16. Входить до складу органів управління юридичних осіб")]
        [Description("(відзначити, якщо фізична особа-заявник або асоційовані з нею особи входять до складу органів управління юридичних осіб)")]
        [Required]
        public bool IsCurrently3rdPartyBoardMember { get { return _IsCurrently3rdPartyBoardMember; } set { _IsCurrently3rdPartyBoardMember = value; OnPropertyChanged("IsCurrently3rdPartyBoardMember"); } }

        private List<CouncilBodyInfo> _MembershipIn3rdPartyBoards;
        /// <summary>
        /// ________________________________________________________________________________
        /// 
        ///                                                              (найменування юридичної особи, її місцезнаходження, код за ЄДРПОУ,
        /// 
        /// _______________________________________________________________________________.
        /// 
        ///                                                           контактні телефони, вид діяльності юридичної особи, опис Ваших функцій)
        /// --------                                                          
        /// Поле заповнюється якщо IsCurrently3rdPartyBoardMember == true
        /// </summary>
        [Category(CATEGORY_III)]
        [DisplayName("16. Членство в керівних органах юр.осіб")]
        [Description("16. Перелік юридичних осіб, до складу органів управління яких входить фізична особа\n17. Інформація про юридичних осіб, у яких асоційовані особи фізичної особи є керівниками")]
        [UIConditionalVisibility("IsCurrently3rdPartyBoardMember")]
        [UIUsageDataGridParams(IsOneColumn=true, OneDataColumnHeader="Членство")]
        public List<CouncilBodyInfo> MembershipIn3rdPartyBoards { get { return _MembershipIn3rdPartyBoards; } set { _MembershipIn3rdPartyBoards = value; OnPropertyChanged("MembershipIn3rdPartyBoards"); } }


        private bool _Is3rdPartiesGuarantor;
        /// <summary>
        ///18 . Чи є Ви довіреною особою, гарантом або 
        /// поручителем інших осіб з фінансових, майнових і корпоративних питань? 
        /// _______________________________________________ 
        ///  (яких саме і з яких питань)
        /// </summary>
        [Category(CATEGORY_III)]
        [DisplayName("18. Чи є Ви довіреною особою, гарантом або поручителем інших осіб?")]
        [Description("18. Чи є Ви довіреною особою, гарантом або поручителем інших осіб з фінансових, майнових і корпоративних питань?")]
        [Required]
        public bool Is3rdPartiesGuarantor { get { return _Is3rdPartiesGuarantor; } set { _Is3rdPartiesGuarantor = value; OnPropertyChanged("Is3rdPartiesGuarantor"); } }

        private List<FinancialGuaranteeInfo> _FinGuaranteesDetails;
        [Category(CATEGORY_III)]
        [DisplayName("18. Деталі гарантій та поручительств щодо інших осіб")]
        [Description("18. Інформація щодо правовідносин, у яких фізична особа є поручителем (гарантом)")]
        [Required("Is3rdPartiesGuarantor == true")]
        [UIConditionalVisibility("Is3rdPartiesGuarantor")]
        [UIUsageDataGridParams(IsOneColumn = true, OneDataColumnHeader = "Поручительства")]
        public List<FinancialGuaranteeInfo> FinGuaranteesDetails { get { return _FinGuaranteesDetails; } set { _FinGuaranteesDetails = value; OnPropertyChanged("FinGuaranteesDetails"); } }

        #endregion

        #region ІV. Ділова репутація

        private bool _HasOutstandingLoansWithBanks;
        /// <summary>
        /// 19. Інформація про кредити, одержані фізичною особою
        /// </summary>
        [Category(CATEGORY_IV)]
        [DisplayName("19. Чи є кредити, одержані й непогашені фізичною особою  в  банках?")]
        [Description("(Станом на дату подання анкети)")]
        [Required]
        public bool HasOutstandingLoansWithBanks { get { return _HasOutstandingLoansWithBanks; } set { _HasOutstandingLoansWithBanks = value; OnPropertyChanged("HasOutstandingLoansWithBanks"); } }

        private List<LoanInfo> _OutstandingLoansWithBanksDetails;
        /// <summary>
        /// 19. Інформація про кредити, одержані фізичною особою:
        /// </summary>
        [Category(CATEGORY_IV)]
        [DisplayName("19. Інформація про кредити, одержані фізичною особою")]
        [Description("(номер і дата договору про надання кредиту, сума кредиту, термін погашення кредиту, сума заборгованості за договором на дату подання анкети)")]
        [Required("HasOutstandingLoansWithBanks == true")]
        [UIConditionalVisibility("HasOutstandingLoansWithBanks")]
        [UIUsageDataGridParams(IsOneColumn = true, OneDataColumnHeader = "Деталі за кредитами")]
        public List<LoanInfo> OutstandingLoansWithBanksDetails { get { return _OutstandingLoansWithBanksDetails; } set { _OutstandingLoansWithBanksDetails = value; OnPropertyChanged("OutstandingLoansWithBanksDetails"); } }

        private bool _HasNoImperfectReputationSigns;
        /// <summary>
        /// 20. Чи є щодо фізичної особи ознаки відсутності бездоганної ділової репутації
        /// актом Національного банку України про порядок реєстрації та ліцензування банків [якщо таких ознак немає, то
        /// зазначається “Стверджую, що немає ознак відсутності бездоганної ділової репутації стосовно _______ (зазначається
        /// повне найменування юридичної особи)”; якщо такі ознаки є, то здійснюється опис ознаки (ознак) відсутності
        /// бездоганної ділової репутації].
        /// </summary>
        [Category(CATEGORY_IV)]
        [DisplayName("20. Стверджую, що немає ознак відсутності бездоганної ділової репутації")]
        [Description("Стверджую, що немає ознак відсутності бездоганної ділової репутації стосовно _______ (зазначається повне найменування фізичної особи")]
        [Required]
        public bool HasNoImperfectReputationSigns { get { return _HasNoImperfectReputationSigns; } set { _HasNoImperfectReputationSigns = value; OnPropertyChanged("HasNoImperfectReputationSigns"); OnPropertyChanged("IsImperfectReputationDetailsVisible"); OnPropertyChanged("IsImperfectReputationDetailsVisible"); } }

        private ImperfectBusinessReputationInfo _ImperfectReputationDetails;
        /// <summary>
        /// 17. Якщо щодо юридичної особи є ознаки відсутності бездоганної ділової репутації, визначені нормативно-правовим
        /// актом Національного банку України про порядок реєстрації та ліцензування банків, то здійснюється опис ознаки (ознак) відсутності
        /// бездоганної ділової репутації].
        /// </summary>
        [Category(CATEGORY_IV)]
        [DisplayName("20. Ознаки відсутності бездоганної ділової репутації")]
        [Description("Опис наявних ознак відсутності бездоганної ділової репутації")]
        [Required("HasNoImperfectReputationSigns == false")]
        [UIConditionalVisibility("IsImperfectReputationDetailsVisible")]
        public ImperfectBusinessReputationInfo ImperfectReputationDetails { get { return _ImperfectReputationDetails; } set { _ImperfectReputationDetails = value; OnPropertyChanged("ImperfectReputationDetails"); } }

        [Browsable(false)]
        [XmlIgnore]
        public bool IsImperfectReputationDetailsVisible { get { return HasNoImperfectReputationSigns == false; } }

        private bool _IsAMLEtcLegislationKept;
        /// <summary>
        /// Стверджую, що _______ (зазначається прізвище, ім’я та по батькові фізичної особи) належним чином виконує
        /// вимоги законодавства України або законодавства країни свого громадянства з питань запобігання та протидії легалізації
        /// (відмиванню) доходів, одержаних злочинним шляхом, та фінансування тероризму.
        /// </summary>
        [Category(CATEGORY_IV)]
        [DisplayName("21. Вимоги законодавства дотримано")]
        [Description("21. Стверджую, що _______ (зазначається прізвище, ім’я та по батькові фізичної особи) належним чином виконує\nвимоги законодавства України або законодавства країни свого громадянства з питань запобігання та протидії легалізації\n(відмиванню) доходів, одержаних злочинним шляхом, та фінансування тероризму.")]
        [Browsable(true)]
        public bool IsAMLEtcLegislationKept { get { return _IsAMLEtcLegislationKept; } set { _IsAMLEtcLegislationKept = value; OnPropertyChanged("IsAMLEtcLegislationKept"); } }

        #endregion


        #region Signatures, etc.
        private SignatoryInfo _Signatory;
        [Category(CATEGORY_SignEtc)]
        [DisplayName("Підписант")]
        [Description("Відомості по особу, що підписала анкету")]
        [Required]
        public SignatoryInfo Signatory { get { return _Signatory; } set { _Signatory = value; OnPropertyChanged("Signatory"); } }

        private ContactInfo _ContactPerson;
        /// <summary>
        /// Звичайні вимоги до повноти заповнення подібного типу даних...
        /// </summary>
        [Category(CATEGORY_SignEtc)]
        [DisplayName("Контакти")]
        [Description("Контактні дані відправника анкети")]
        [Required]
        public ContactInfo ContactPerson { get { return _ContactPerson; } set { _ContactPerson = value; OnPropertyChanged("ContactPerson"); } }
        #endregion

        #region various common members
        private List<GenericPersonInfo> _MentionedIdentities;
        [DisplayName("Реквізити осіб-фігурантів анкети")]
        [Description("Повна інформація про осіб, що згадуються в анкеті")]
        [Required]
        [UIUsageDataGridParams(IsOneColumn = true, OneDataColumnHeader = "Особа")]
        public List<GenericPersonInfo> MentionedIdentities { get { return _MentionedIdentities; } set { _MentionedIdentities = value; OnPropertyChanged("MentionedIdentities"); OnPropertyChanged("MentionedGenericPersons"); } }

        [Browsable(false)]
        [XmlIgnore]
        public IEnumerable<GenericPersonInfo> MentionedGenericPersons
        {
            get { return MentionedIdentities; }
        }

        [Browsable(false)]
        [XmlIgnore]
        public IEnumerable<LocationInfo> MentionedAddresses
        {
            get { return new List<LocationInfo>(); /* todo */ }
        }

        [Browsable(false)]
        [XmlIgnore]
        protected override string QuestionnairePrefixForFileName
        {
            get { return "regLicDod4FO"; }
        }

        [Browsable(false)]
        [XmlIgnore]
        protected override string BankNameForFileName
        {
            get { return GetBankNameForFileName(BankRef); }
        }

        [Browsable(false)]
        [XmlIgnore]
        protected override string ApplicantNameForFileName
        {
            get { if (Acquiree == null) return string.Empty; return Acquiree.PersonCode; }
        }


        public void RefreshGenericPersonsDisplayNames()
        {
            base.RefreshGenericPersonsDisplayNamesWorker(this.MentionedIdentities, new List<OwnershipStructure>[] { ExistingOwnershipDetailsHive });
        }

        #endregion

        protected override void DoAddToMentionedEntities(GenericPersonInfo gpi)
        {
            MentionedIdentities.Add(gpi);
        }
    }
}
