using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;
using Evolvex.Utility.Core.ComponentModelEx;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;
using System.ComponentModel;

namespace BGU.DRPL.SignificantOwnership.Core.Questionnaires
{
    /// <summary>
    /// АНКЕТА юридичної особи (у тому числі банку)
    /// Додаток 2 до Положення про порядок реєстрації та ліцензування банків, відкриття відокремлених підрозділів
    /// file                                  : f364524n1227.doc
    /// Рівень складності                     : 10
    /// (оціночний, шкала від 1 до 10)
    /// Пріоритетність                        : Hi  (Легенда: Hi - Висока, Lo - Низька, Mid - Середня, Hold - Поки що притримати)
    /// Подавач анкети                        : LP (Легенда: LP - юр.особа, PP - фіз.особа, BK - банк)
    /// Чи заповнюватиметься он-лайн          : Так
    /// Первинну розробку структури завершено : Ні
    /// Структуру фіналізовано                : Ні
    /// (=остаточно узгоджено 
    /// з бізнес-користувачами)
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.RegLicAppx2OwnershipAcqRequestLP_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class RegLicAppx2OwnershipAcqRequestLP : QuestionnaireBase, IGenericPersonsService, IAddressesService, INotifyPropertyChanged
    {
        
        private const string CATEGORY_I = "І. Інформація про юридичну особу";
        private const string CATEGORY_II = "ІІ. Інформація про наміри щодо набуття (збільшення) істотної участі в банку";
        private const string CATEGORY_III = "ІІІ. Відносини юридичної особи з іншими особами";
        private const string CATEGORY_IV = "IV. Ділова репутація";
        private const string CATEGORY_SignEtc = "Підписи і т.п.";

        #region cctor(s)
        public RegLicAppx2OwnershipAcqRequestLP()
        { 
            this.AccountsWithBanks = new List<BankInfo>();
            this.StateRegulatorAuthorities = new List<FinancialOversightAuthorityInfo>();
            this.FundsOrigin = new List<IncomeOriginInfo>();
            this.MentionedIdentities = new List<GenericPersonInfo>();
            this.PersonsLinks = new List<PersonsAssociation>();
            this.CreditRatingGrade = new List<CreditRatingInfo>();
            this.IPOPurchase = new List<IPOSharesPurchaseInfo>();
            this.SecondaryMarketPurchases = new List<SecondaryMarketSharesPurchaseInfo>();
            this.AquisitionByPoAttorneys = new List<PowerOfAttorneySharesPurchaseInfo>();
            this.AquisitionByInfluence = new List<SignificantOrDecisiveInfulenceInfo>();
            this.ExistingOwnershipDetailsHive = new List<OwnershipStructure>();
            this.OutstandingLoansWithBanksDetails = new List<LoanInfo>();
            this.MissingInformationResons = new List<MissingInformationResonInfo>();
        }

        #endregion

        private BankInfo _BankRef;
        /// <summary>
        /// стосовно участі в ___________________________________
        /// (повне офіційне найменування банку)
        /// </summary>
        [DisplayName("Повне офіційне найменування банку")]
        [Description("стосовно участі в ...")]
        [Required]
        public BankInfo BankRef { get { return _BankRef; } set { _BankRef = value; OnPropertyChanged("BankRef"); } }


        #region І. Інформація про юридичну особу

        private GenericPersonID _Acquiree;
        /// <summary>
        /// І. Інформація про юридичну особу
        /// 
        /// 1. Повне та скорочене найменування ________________________________________________________________
        /// 2. Ідентифікаційні дані:
        /// ---- 
        /// Самі реквізити мають потрапити до MentionedIdentities
        /// </summary>
        [Category(CATEGORY_I)]
        [DisplayName("Юр.особа-заявник")]
        [Description("1. Інформація про юридичну особу")]
        [Required]
        public GenericPersonID Acquiree { get { return _Acquiree; } set { _Acquiree = value; OnPropertyChanged("Acquiree"); } }


        private List<CreditRatingInfo> _CreditRatingGrade;
        /// <summary>
        /// 1.5. Рейтингова оцінка ____________________________________________________________.
        /// (за рейтингом, який підтверджений у бюлетені, однієї  з провідних рейтингових компаній IBCA,
        ///  Standart & Poor's, Moody's)
        /// </summary>
        [Category(CATEGORY_I)]
        [DisplayName("2. Ідентифікаційні дані::Рейтингова оцінка")]
        [Description("(за рейтингом, який підтверджений у бюлетені, однієї з провідних рейтингових компаній IBCA,Standart & Poor's, Moody's)")]
        [Required]
        [UIUsageDataGridParams(IsOneColumn=true, OneDataColumnHeader="Рейтингова оцінка")]
        public List<CreditRatingInfo> CreditRatingGrade { get { return _CreditRatingGrade; } set { _CreditRatingGrade = value; OnPropertyChanged("CreditRatingGrade"); } }

        private List<FinancialOversightAuthorityInfo> _StateRegulatorAuthorities;
        /// <summary>
        /// 3. Відомості про державну реєстрацію юридичної особи та відносини з контролюючими державними органами
        /// Найменування іноземного державного
        /// контролюючого органу, що дає дозвіл
        /// на набуття (збільшення) участі в банку
        /// (для іноземців)
        /// Державний орган, що здійснює
        /// нагляд за діяльністю юридичної
        /// особи (для осіб, які здійснюють
        /// регульовану діяльність)
        /// -----
        /// Орган, що здійснив державну реєстрацію - див. у полі Acquiree
        /// </summary>
        [Category(CATEGORY_I)]
        [Browsable(true)]
        [DisplayName("3. (4-5) Державний(-і) наглядовий(-і) орган(-и)")]
        [Description("3. Відомості про державну реєстрацію юридичної особи та відносини з контролюючими державними органами")]
        [UIUsageDataGridParams(IsOneColumn = true, OneDataColumnHeader = "Наглядовий(-і) орган(-и)")]
        public List<FinancialOversightAuthorityInfo> StateRegulatorAuthorities { get { return _StateRegulatorAuthorities; } set { _StateRegulatorAuthorities = value; OnPropertyChanged("StateRegulatorAuthorities"); } }


        private TotalOwnershipSummaryInfo _TotalExistingOwnershipWithBank;
        /// <summary>
        /// 3. Відомості про державну реєстрацію юридичної особи та відносини з контролюючими державними органами
        /// _______________________________________________________________________________.
        ///            (найменування органу)
        /// </summary>
        [Browsable(true)]
        [DisplayName("5. Наявна участь юридичної особи в банку")]
        [Description("5. Інформація про розмір наявної участі юридичної особи в банку")]
        public TotalOwnershipSummaryInfo TotalExistingOwnershipWithBank { get { return _TotalExistingOwnershipWithBank; } set { _TotalExistingOwnershipWithBank = value; OnPropertyChanged("TotalExistingOwnershipWithBank"); } }

        private List<BankInfo> _AccountsWithBanks;
        /// <summary>
        /// Поле обов'язкове, лише якщо заявник не є банком.
        /// </summary>
        [Category(CATEGORY_I)]
        [DisplayName("4. Банківські рахунки юридичної особи")]
        [Description("(не заповнюється банками)")]
        [UIUsageDataGridParams(IsOneColumn = true, OneDataColumnHeader = "Рахунки")]
        public List<BankInfo> AccountsWithBanks { get { return _AccountsWithBanks; } set { _AccountsWithBanks = value; OnPropertyChanged("AccountsWithBanks"); } }

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
        [DisplayName("6. Майбутня участь особи в банку")]
        [Description("6. Інформація про розмір участі, що набувається (збільшується): Майбутня участь особи в банку з урахуванням намірів щодо набуття/збільшення істотної участі")]
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
        [DisplayName("7. Спосіб(-оби) набуття/збільшення істотної участі в банку")]
        [Description("7. Набуття/збільшення істотної участі в банку відбуватиметься у спосіб (зазначити необхідне)")]
        [Required]
        public SignificantOwnershipAcquisitionWaysInfo AcquisitionWays { get { return _AcquisitionWays; } set { _AcquisitionWays = value; OnPropertyChanged("AcquisitionWays"); } }

        private List<IPOSharesPurchaseInfo> _IPOPurchase;
        [Category(CATEGORY_II)]
        [DisplayName("Придбання на первинному ринку")]
        [Description("8. Інформація про намір щодо придбання акцій (паїв) банку на первинному ринку:")]
        [Required("AcquisitionWays.IsIPO == true")]
        [UIConditionalVisibility("AcquisitionWays.IsIPO")]
        [UIUsageDataGridParams(IsOneColumn = true, OneDataColumnHeader = "Придбання на IPO")]
        public List<IPOSharesPurchaseInfo> IPOPurchase { get { return _IPOPurchase; } set { _IPOPurchase = value; OnPropertyChanged("IPOPurchase"); } }




        private List<SecondaryMarketSharesPurchaseInfo> _SecondaryMarketPurchases;
        [Category(CATEGORY_II)]
        [DisplayName("9. Придбання на вторинному ринку")]
        [Description("9. Інформація про намір щодо придбання акцій (паїв) банку на вторинному ринку та/або стосовно правочинів щодо набуття (збільшення) опосередкованої участі в банку (крім набуття істотної участі в результаті передавання особі права голосу або незалежно від формального володіння)")]
        [Required("AcquisitionWays.IsSecondaryMarketPurchase == true || AcquisitionWays.IsPurchaseByImplicitOwnership == true")]
        [UIConditionalVisibility("AcquisitionWays.IsSecondaryMarketOrImplicitOwnershipPurchase")]
        [UIUsageDataGridParams(IsOneColumn = true, OneDataColumnHeader = "Придбання вторинному ринку")]
        public List<SecondaryMarketSharesPurchaseInfo> SecondaryMarketPurchases { get { return _SecondaryMarketPurchases; } set { _SecondaryMarketPurchases = value; OnPropertyChanged("SecondaryMarketPurchases"); } }

        private List<PowerOfAttorneySharesPurchaseInfo> _AquisitionByPoAttorneys;
        [Category(CATEGORY_II)]
        [DisplayName("10. Набуття за довіреністю")]
        [Description("10. Інформація про намір щодо набуття опосередкованої істотної участі в банку за довіреністю")]
        [Required("AcquisitionWays.IsPurchaseByPowOfAtt == true")]
        [UIConditionalVisibility("AcquisitionWays.IsPurchaseByPowOfAtt")]
        [UIUsageDataGridParams(IsOneColumn = true, OneDataColumnHeader = "Набуття за довіренністю")]
        public List<PowerOfAttorneySharesPurchaseInfo> AquisitionByPoAttorneys { get { return _AquisitionByPoAttorneys; } set { _AquisitionByPoAttorneys = value; OnPropertyChanged("AquisitionByPoAttorneys"); } }

        private List<SignificantOrDecisiveInfulenceInfo> _AquisitionByInfluence;
        [Category(CATEGORY_II)]
        [DisplayName("11. Набуття у зв’язку із здійсненням впливу")]
        [Description("11. Інформація про набуття опосередкованої істотної участі в банку у зв’язку із здійсненням значного або вирішального впливу на управління та діяльність банку незалежно від формального володіння")]
        [Required("AcquisitionWays.IsAcquireByImplicitInfluence == true")]
        [UIConditionalVisibility("AcquisitionWays.IsAcquireByImplicitInfluence")]
        [UIUsageDataGridParams(IsOneColumn = true, OneDataColumnHeader = "Набуття за впливом")]
        public List<SignificantOrDecisiveInfulenceInfo> AquisitionByInfluence { get { return _AquisitionByInfluence; } set { _AquisitionByInfluence = value; OnPropertyChanged("AquisitionByInfluence"); } }

        private List<IncomeOriginInfo> _FundsOrigin;
        /// <summary>
        /// 12. Джерела походження коштів юридичної особи, за рахунок яких набуватиметься істотна участь у банку,
        /// _______________________________________________________________________________________________________.
        /// (прибуток, частина статутного капіталу, кошти фонду тощо)
        /// </summary>
        [Category(CATEGORY_II)]
        [DisplayName("12. Джерела  походження коштів юридичної особи")]
        [Description("12. Джерела походження коштів юридичної особи, за рахунок яких набуватиметься істотна участь у банку")]
        [Required]
        public List<IncomeOriginInfo> FundsOrigin { get { return _FundsOrigin; } set { _FundsOrigin = value; OnPropertyChanged("FundsOrigin"); } }
        #endregion

        #region ІІІ. Відносини юридичної особи з іншими особами

        private List<OwnershipStructure> _ExistingOwnershipDetailsHive;
        /// <summary>
        /// 13. Перелік юридичних осіб, у тому числі банків, в яких юридична особа має істотну участь або є ключовим учасником
        /// 14. Інформація про фізичних осіб, які володіють істотною участю в цій юридичній особі або є ключовими учасниками юридичної особи
        /// 15. Інформація про юридичних осіб, які володіють істотною участю в цій юридичній особі або є ключовими учасниками юридичної особи
        /// ----
        /// Доцільно розшифровку ланцюжків власності усіх структур, що фігурують в анкеті, скласти в це одне поле, оскільки не виключено, що власники-юр.особи повторюватимуться/фігуруватимуть в різних іпостасях в усіх 3-х пунктах (себто, і 13, і 14, і 15) 
        /// </summary>
        [Category(CATEGORY_III)]
        [DisplayName("13, 14, 15. Розшифровка ланцюжків власності")]
        [Description("Розшифровка ланцюжків власності усіх структур-фігурантів анкети:\n 13. Перелік юридичних осіб, у тому числі банків, в яких юридична особа має істотну участь або є ключовим учасником\n 14. Інформація про фізичних осіб, які володіють істотною участю в цій юридичній особі або є ключовими учасниками юридичної особи\n 15. Інформація про юридичних осіб, які володіють істотною участю в цій юридичній особі або є ключовими учасниками юридичної особи")]
        [UIUsageDataGridParams(IsOneColumn = true, OneDataColumnHeader = "Ланцюжки власності")]
        public List<OwnershipStructure> ExistingOwnershipDetailsHive { get { return _ExistingOwnershipDetailsHive; } set { _ExistingOwnershipDetailsHive = value; OnPropertyChanged("ExistingOwnershipDetailsHive"); } }
        #endregion

        #region IV. Ділова репутація
        private bool _HasOutstandingLoansWithBanks;
        /// <summary>
        /// 16. Інформація про кредити, одержані юридичною особою:
        /// </summary>
        [Category(CATEGORY_IV)]
        [DisplayName("16. Чи є кредити, одержані й непогашені юридичною  особою  в  банках?")]
        [Description("(Станом на дату подання анкети)")]
        [Required]
        public bool HasOutstandingLoansWithBanks { get { return _HasOutstandingLoansWithBanks; } set { _HasOutstandingLoansWithBanks = value; OnPropertyChanged("HasOutstandingLoansWithBanks"); } }

        private List<LoanInfo> _OutstandingLoansWithBanksDetails;
        /// <summary>
        /// 16. Інформація про кредити, одержані юридичною особою:
        /// </summary>
        [Category(CATEGORY_IV)]
        [DisplayName("16. Інформація про кредити, одержані юридичною особою")]
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
        /// бездоганної ділової репутації].
        /// </summary>
        [Category(CATEGORY_IV)]
        [DisplayName("17. Стверджую, що немає ознак відсутності бездоганної ділової репутації")]
        [Description("Стверджую, що немає ознак відсутності бездоганної ділової репутації стосовно _______ (зазначається повне найменування юридичної особи")]
        [Required]
        public bool HasNoImperfectReputationSigns { get { return _HasNoImperfectReputationSigns; } set { _HasNoImperfectReputationSigns = value; OnPropertyChanged("HasNoImperfectReputationSigns"); OnPropertyChanged("IsImprefectReputationDetailsVisible"); OnPropertyChanged("IsImprefectReputationDetailsVisible"); } }

        private ImperfectBusinessReputationInfo _ImprefectReputationDetails;
        /// <summary>
        /// 17. Якщо щодо юридичної особи є ознаки відсутності бездоганної ділової репутації, визначені нормативно-правовим
        /// актом Національного банку України про порядок реєстрації та ліцензування банків, то здійснюється опис ознаки (ознак) відсутності
        /// бездоганної ділової репутації].
        /// </summary>
        [Category(CATEGORY_IV)]
        [DisplayName("17. Ознаки відсутності бездоганної ділової репутації")]
        [Description("Опис наявних ознак відсутності бездоганної ділової репутації")]
        [Required("HasNoImperfectReputationSigns == false")]
        [UIConditionalVisibility("IsImprefectReputationDetailsVisible")]
        public ImperfectBusinessReputationInfo ImprefectReputationDetails { get { return _ImprefectReputationDetails; } set { _ImprefectReputationDetails = value; OnPropertyChanged("ImprefectReputationDetails"); } }

        [Browsable(false)]
        public bool IsImprefectReputationDetailsVisible { get { return HasNoImperfectReputationSigns == false; } }

        private bool _IsAMLEtcLegislationKept;
        /// <summary>
        /// 18. Стверджую, що юридична особа _______ (зазначається повне найменування юридичної особи) належним чином
        /// виконує вимоги законодавства України або законодавства країни свого громадянства з питань запобігання та протидії
        /// легалізації (відмиванню) доходів, одержаних злочинним шляхом, та фінансування тероризму.
        /// </summary>
        [Category(CATEGORY_IV)]
        [DisplayName("18. Вимоги законодавства дотримано")]
        [Description("18. Стверджую, що юридична особа _______ (зазначається повне найменування юридичної особи) належним чином виконує вимоги законодавства України або законодавства країни свого громадянства з питань запобігання та протидії легалізації (відмиванню) доходів, одержаних злочинним шляхом, та фінансування тероризму.")]
        [Browsable(true)]
        public bool IsAMLEtcLegislationKept { get { return _IsAMLEtcLegislationKept; } set { _IsAMLEtcLegislationKept = value; OnPropertyChanged("IsAMLEtcLegislationKept"); } }

        #endregion

        #region Trailing prop(s)
        private bool _IsApplicationInfoAccurateAndTrue;
        /// <summary>
        /// Стверджую, що інформація, зазначена в анкеті, є правдивою і повною, та не заперечую проти перевірки
        /// Національним банком України її достовірності та повноти.
        /// </summary>
        [Category(CATEGORY_SignEtc)]
        [DisplayName("Підтверджую правдивість інформації?")]
        [Description("Стверджую, що інформація, зазначена в анкеті, є правдивою і повною, та не заперечую проти перевірки Національним банком України її достовірності та повноти.")]
        [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.BooleanEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Required]
        public bool IsApplicationInfoAccurateAndTrue { get { return _IsApplicationInfoAccurateAndTrue; } set { _IsApplicationInfoAccurateAndTrue = value; OnPropertyChanged("IsApplicationInfoAccurateAndTrue"); } }


        private List<MissingInformationResonInfo> _MissingInformationResons;
        /// <summary>
        /// Примітка. Якщо немає змоги надати інформацію за відповідними пунктами анкети, то слід зазначити причину.
        /// </summary>
        [Category(CATEGORY_SignEtc)]
        [DisplayName("Примітка. Якщо немає змоги надати інформацію за відповідними пунктами анкети, то слід зазначити причину.")]
        [Description("...")]
        [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.BooleanEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Required]
        [UIUsageDataGridParams(IsOneColumn = true, OneDataColumnHeader = "Поля й причини")]
        public List<MissingInformationResonInfo> MissingInformationResons { get { return _MissingInformationResons; } set { _MissingInformationResons = value; OnPropertyChanged("MissingInformationResons"); } }

        private SignatoryInfo _Signatory;
        /// <summary>
        /// ____________________       __________________________    _______________________________
        ///  (дата підписання анкети) (підпис уповноваженої особи    (прізвище та ініціали уповноваженої особи
        ///                              юридичної особи)             юридичної особи, її посада в юридичній особі
        ///                                                           або реквізити довіреності представника за
        ///                                                           довіреністю)
        /// </summary>
        [Category(CATEGORY_SignEtc)]
        [DisplayName("Підписант")]
        [Description("Відомості по особу, що підписала анкету")]
        [Required]
        public SignatoryInfo Signatory { get { return _Signatory; } set { _Signatory = value; OnPropertyChanged("Signatory"); } }

        private ContactInfo _ContactPerson;
        /// <summary>
        /// Прізвище, ім'я, по батькові контактної особи ___________________.
        /// 
        /// Номер телефону та факсу ________________________________________.
        /// </summary>
        [Category(CATEGORY_SignEtc)]
        [DisplayName("Контакти")]
        [Description("Контактні дані відправника анкети")]
        [Required]
        public ContactInfo ContactPerson { get { return _ContactPerson; } set { _ContactPerson = value; OnPropertyChanged("ContactPerson"); } }
        #endregion


        #region Hidden prop(s)
        /// <summary>
        /// Реквізити осіб-фігурантів анкети
        /// </summary>
        [DisplayName("Реквізити осіб-фігурантів анкети")]
        [Description("Повні реквізити юридичних та фізичних осіб, що згадуються в розділах анкети")]
        [Required]
        public List<GenericPersonInfo> MentionedIdentities { get; set; }

        /// <summary>
        /// Зв'язки між фігурантами анкети
        /// </summary>
        [Category(CATEGORY_III)]
        [DisplayName("Зв'язки між фігурантами анкети")]
        [Description("Опис зв'язків між фізичними та юридичними особами, що згадуються в розділах анкети")]
        [Required]
        public List<PersonsAssociation> PersonsLinks { get; set; }
        #endregion

        #region inherited member(s)

        //public override string SuggestSaveAsFileName()
        //{
        //    return "regLicDod2IstUchYO";
        //}

        #endregion

        protected override string QuestionnairePrefixForFileName
        {
            get { return "regLicDod2IstUchYO"; }
        }

        protected override string BankNameForFileName
        {
            get { return GetBankNameForFileName(BankRef); }
        }

        protected override string ApplicantNameForFileName
        {
            get { if (Acquiree == null) return string.Empty; return Acquiree.PersonCode; }
        }

        public IEnumerable<GenericPersonInfo> MentionedGenericPersons
        {
            get { return MentionedIdentities; }
        }

        public IEnumerable<LocationInfo> MentionedAddresses
        {
            get { return new List<LocationInfo>(); /* todo */ }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }

        }
   }
}
