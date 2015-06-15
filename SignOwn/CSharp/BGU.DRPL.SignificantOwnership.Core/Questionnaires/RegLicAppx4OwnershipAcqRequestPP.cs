using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;
using BGU.DRPL.SignificantOwnership.Core.Spares;
using Evolvex.Utility.Core.ComponentModelEx;

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
    public class RegLicAppx4OwnershipAcqRequestPP : QuestionnaireBase
    {
        public RegLicAppx4OwnershipAcqRequestPP()
        {
            this.BankingAccounts = new List<BankAccountInfo>();
            this.EmploymentRecords = new List<EmploymentRecordInfo>();
            this.EducationRecords = new List<EducationRecordInfo>();
            this.ProfessionalLicenses = new List<ProfessionLicenseInfo>();
            this.ExistingOwnershipWithBankDetails = new List<OwnershipStructure>();
            this.TargetedOwnershipWithBankDiffDetails = new List<OwnershipStructure>();
            this.TargetedOwnershipWithBankDetails = new List<OwnershipStructure>();
            this.FundsOrigins = new List<IncomeOriginInfo>();
            this.PaymentModes = new List<PaymentModeInfo>();
            this.PaymentDeadlines = new List<PaymentDeadlineInfo>();
            this.LoansWithBanks = new List<LoanInfo>();
            this.LinkedBanksGoverningBodiesMembers = new List<CouncilBodyInfo>();
            this.BreachesOfLaw = new List<BreachOfLawRecordInfo>();
            this.OtherLiabilities = new List<IndebtnessInfo>();
            this.LiquidatedSignOwnershipLastYear = new List<LiquidatedEntityOwnershipInfo>();
            this.MentionedIdentities = new List<GenericPersonInfo>();
            this.PersonsLinks = new List<PersonsAssociation>();
        }
        /// <summary>
        /// Лише укр.банки, лише головні контори
        /// </summary>
        [DisplayName("Банк")]
        [Description("Банк")]
        [Required]
        public BankInfo BankRef { get; set; }


        [DisplayName("Фізособа-заявник")]
        [Description("1. Інформація про особу")]
        [Required]
        public PhysicalPersonInfo Acquiree { get; set; }

        /// <summary>
        /// Усередині кожного BankAccountInfo, обов'язково ідентифікувати хоча б банк (поки що, принаймні).
        /// Якщо він хоче вказати №№-и рахунків - не забороняти :)
        /// </summary>
        [DisplayName("Рахунки в банках")]
        [Description("1.6. Перелік банків, у яких відкрито рахунки")]
        [Required]
        public List<BankAccountInfo> BankingAccounts { get; set; }

        /// <summary>
        /// Іноземний банк, обов'язкове поле якщо Acquiree.CitizenshipCountry != UKRAINE
        /// </summary>
        [DisplayName("Банк, що відрекомендовує іноземця")]
        [Description("1.7. Банк, який надає інформацію про наявні кошти і репутацію власника рахунку (для іноземців)")]
        public BankInfo ReferenceBank { get; set; }


        [DisplayName("Досвід роботи")]
        [Description("1.8. Займані посади за останні п'ять років")]
        [Required]
        public List<EmploymentRecordInfo> EmploymentRecords { get; set; }

        [DisplayName("Освіта")]
        [Description("1.10. Освіта (освіта, науковий ступінь, номер, дата видачі диплома, ким виданий, спеціальність і кваліфікація)")]
        [Required]
        public List<EducationRecordInfo> EducationRecords { get; set; }

        /// <summary>
        /// Якщо є
        /// </summary>
        [DisplayName("Кваліфікація")]
        [Description("1.10. Кваліфікація (професійна ліцензія, номер, дата видачі, ким видана, спеціальність і кваліфікація)")]
        public List<ProfessionLicenseInfo> ProfessionalLicenses { get; set; }

        /// <summary>
        /// Якщо Acquiree.CitizenshipCountry != UKRAINE
        /// </summary>
        [DisplayName("Чи потрібен дозвіл (для нерезидентів)")]
        [Description("1.11. Чи потрібен дозвіл на набуття (збільшення) участі в банку, розташованому в Україні (для іноземців)")]
        [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.BooleanEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool IsForeignFinOversightBodyApprovalRequired { get; set; }

        /// <summary>
        /// Обов'язкове, якщо IsForeignFinOversightBodyApprovalRequired == true
        /// У перспективі, завести словники усіх таких держорганів за кордоном 
        /// і пропонувати вибрати зі списку, лишаючи можливість увести, якщо в 
        /// списку відсутній; Так ми, принаймні, покриємо більшість існуючих.
        /// </summary>
        /// <seealso cref=""/>
        [DisplayName("Іноземний дозвільний орган (якщо потрібен дозвіл)")]
        [Description("1.11. Іноземний державний контрольний орган, що дає дозвіл на набуття (збільшення) участі в банку, розташованому в Україні (для іноземців)")]
        public FinancialOversightAuthorityInfo ForeignFinOversightBody { get; set; }

        [DisplayName("Офіційна публікація (IPO)")]
        [Description("2.1. Найменування, дата і номер офіційного видання, у якому опубліковано оголошення про емісію (у разі первинного розміщення)")]
        public PublicationInfo IssuePublication { get; set; }

        [DisplayName("Чи є андеррайтер")]
        [Description("2.2. Андеррайтер ...")]
        [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.BooleanEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool IsUnderwritten { get; set; }

        /// <summary>
        /// Обов'язкове, якщо IsUnderwritten == true
        /// </summary>
        [DisplayName("Андеррайтер")]
        [Description("2.2. Андеррайтер (якщо є) - реквізити")]
        public GenericPersonID Underwriter { get; set; }

        [DisplayName("Наявна участь у банку")]
        [Description("2.3. Наявна участь у банку")]
        [Required]
        public TotalOwnershipDetailsInfo ExistingOwnershipWithBankSummary { get; set; }

        /// <summary>
        /// Агрегована розшифровка має збігатися з даними в ExistingOwnershipWithBankSummary
        /// </summary>
        [DisplayName("Наявна участь у банку - розшифровка")]
        [Description("2.3. Наявна участь у банку - розшифровка прямого та опосередкованого володіння")]
        [Required]
        public List<OwnershipStructure> ExistingOwnershipWithBankDetails { get; set; }

        [DisplayName("Наміри набуття/збільшення істотної участі")]
        [Description("2.4. Наміри набуття/збільшення істотної участі в банку.\n (Вкажіть різницю, що набувається)")]
        [Required]
        public TotalOwnershipDetailsInfo TargetedOwnershipWithBankSummaryDiff { get; set; }

        [DisplayName("Наміри набуття/збільшення істотної участі - розшифровка")]
        [Description("2.4. Наміри набуття/збільшення істотної участі в банку - розшифровка прямого та опосередкованого володіння.\n (Вкажіть різницю, що набувається)")]
        [Required]
        public List<OwnershipStructure> TargetedOwnershipWithBankDiffDetails { get; set; }

        /// <summary>
        /// Якщо є іноземні інвестори
        /// todo - уточнити: чи це поле, що додатково заповнюється 
        /// для подавача-нерезидента, чи це та частка набуваної 
        /// власності, що фінансується за рахунок іноземної інвестиції
        /// </summary>
        [DisplayName("Інвестиція, яку іноземний інвестор має намір здійснити")]
        [Description("2.5. Інвестиція, яку іноземний інвестор має намір здійснити, становитиме ... відсотків статутного капіталу банку в розмірі ... гривень.")]
        public OwnershipSummaryInfo TargetedForeignInvestmentSummaryDiff { get; set; }

        [DisplayName("Майбутня істотна участь (усього)")]
        [Description("2.6. Майбутня істотна участь з урахуванням кількості акцій (паїв), які фізична особа має намір набути,  становитиме ...")]
        [Required]
        public TotalOwnershipDetailsInfo TargetedOwnershipWithBankSummary { get; set; }

        [DisplayName("Майбутня істотна участь (розшифровка)")]
        [Description("2.6. Майбутня істотна участь з урахуванням кількості акцій (паїв), які фізична особа має намір набути - розшифровка")]
        [Required]
        public List<OwnershipStructure> TargetedOwnershipWithBankDetails { get; set; }

        [DisplayName("Пов'язаність з з банком-емітентом")]
        [Description("2.7. Чи є Ви особою, яка пов'язана з банком-емітентом?\n (Якщо так, вкажіть деталі зв'язку в полі \"Зв'язки між особами-фігурантами анкети\")")]
        [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.BooleanEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Required]
        public bool IsAssociatedPersonWithIssuer { get; set; }

        /// <summary>
        /// 3.1. Кількість акцій, які Ви маєте намір придбати ...
        /// </summary>
        [DisplayName("Акції, що придбаються")]
        [Description("3.1. Кількість акцій, які Ви маєте намір придбати ...")]
        [Required]
        public SharesAcquisitionInfo SharesToBePurchased { get; set; }

        /// <summary>
        /// 3.2. Джерело походження коштів для сплати 
        /// </summary>
        [DisplayName("Походження коштів")]
        [Description("3.2. Джерело походження коштів для сплати")]
        [Required]
        public List<IncomeOriginInfo> FundsOrigins { get; set; }

        /// <summary>
        /// 3.3. Порядок сплати 
        /// </summary>
        [DisplayName("Порядок сплати")]
        [Description("3.3. Порядок сплати ")]
        [Required]
        public List<PaymentModeInfo> PaymentModes { get; set; }

        /// <summary>
        /// 3.4. Терміни сплати 
        /// </summary>
        [DisplayName("Терміни сплати")]
        [Description("3.4. Терміни сплати")]
        [Required]
        public List<PaymentDeadlineInfo> PaymentDeadlines { get; set; }


        /// <summary>
        /// Якщо є кредити; попередження про відповідальність 
        /// за подачу завідомо неправдивих відомостей
        /// </summary>
        [DisplayName("Кредити, одержані в банках")]
        [Description("3.5. Інформація про кредити, що одержані в банку-емітенті.\n3.6. Інформація про кредити, що одержані в інших банках.\n3.7. Інформація про стан виконання  зобов'язань щодо повернення кредитів, що одержані в банках.")]
        public List<LoanInfo> LoansWithBanks { get; set; }

        // ???!
        
        /// <summary>
        /// 4. Відносини власності із суб'єктами господарювання,
        /// у тому числі іншими банками (крім банку-емітента)
        /// </summary>
        [DisplayName("4. Чи перебуває заявник у відносинах власності з іншими суб'єктами господарювання")]
        [Description("4. Чи існують відносини власності фізичної особи зі суб'єктами господарювання, у тому числі іншими банками (крім банку-емітента)")]
        [Required]
        public bool HasAcquireeOwnershipOtherThanBankRef { get; set; }

        /// <summary>
        /// 4. Відносини власності із суб'єктами господарювання,
        /// у тому числі іншими банками (крім банку-емітента)
        /// 4.1. Найменування юридичної особи, код за ЄДРПОУ _________________________________.
        /// 4.2. Місцезнаходження ___________________________________________________________.
        /// 4.3. Основний вид діяльності ______________________________________________________.
        /// 4.4. Відсоток власності в ній ______________________________________________________.
        /// </summary>
        [DisplayName("4. Відносини власності заявника з іншими суб'єктами господарювання")]
        [Description("4. Відносини власності юридичної особи із суб'єктами господарювання, у тому числі іншими банками (крім банку, у який планується здійснення інвестиції)")]
        [Required("HasAcquireeOwnershipOtherThanBankRef == true")]
        public List<OwnershipStructure> AcquireeOwnershipOtherThanBankRef { get; set; }

        /// <summary>
        /// 4.5. Чи входите Ви до органів управління цієї юридичної особи?
        /// </summary>
        [DisplayName("4.5. Членство у органах управління інших юросіб?")]
        [Description("4.5. Чи входите Ви до органів управління цієї юридичної особи? (крім банку-емітента)")]
        [Required]
        public bool IsBoardsMemberOtherThanBankRef { get; set; }
        [DisplayName("4.5. Деталі членства у органах управління інших юросіб")]
        [Description("4.5. Якщо Ви входите до органів управління цієї юридичної особи (крім банку-емітента), вказати, до яких саме")]
        [Required("IsBoardsMemberOtherThanBankRef == true")]
        public List<CouncilBodyInfo> BoardsMembershipOtherThanBankRef { get; set; }
        
        /// <summary>
        /// 4.6. Чи є Ви особою, яка пов'язана з банком? _________________________________________.
        ///                                               (якою саме особою, у якому банку)
        /// --------------------
        /// Деталі пов'язаності - у полі PersonsLinks
        /// </summary>
        [DisplayName("4.6. Чи є Ви особою, яка пов'язана з банком?")]
        [Description("4.6. Чи є Ви особою, яка пов'язана з банком?(крім банку-емітента)")]
        [Required]
        public bool IsLinkedPersonOtherThanBankRef{ get; set; }

        /// <summary>
        /// Якщо є такі особи; попередження про відповідальність 
        /// за подачу завідомо неправдивих відомостей
        /// ----
        /// </summary>
        [DisplayName("Пов'язані особи в органах управління банків")]
        [Description("Інформація про пов'язаних осіб у органах управління згадуваних банків")]
        public List<CouncilBodyInfo> LinkedBanksGoverningBodiesMembers { get; set; }


        /// 4.7. Чи є Ви довіреною особою, гарантом або 
        /// поручителем інших осіб з фінансових, майнових і корпоративних питань? 
        /// _______________________________________________ 
        ///  (яких саме і з яких питань)
        [DisplayName("4.7. Чи є Ви довіреною особою, гарантом або поручителем інших осіб?")]
        [Description("4.7. Чи є Ви довіреною особою, гарантом або поручителем інших осіб з фінансових, майнових і корпоративних питань?")]
        [Required]
        public bool Is3rdPartiesGuarantor { get; set; }

        [DisplayName("4.7. Деталі гарантій та поручительств щодо інших осіб")]
        [Description("4.7. Якщо Ви є довіреною особою, гарантом або поручителем інших осіб з фінансових, майнових і корпоративних питань - вказати деталі")]
        [Required("Is3rdPartiesGuarantor == true")]
        public List<FinancialGuaranteeInfo> FinGuaranteesDetails { get; set; }

        [DisplayName("Притягувалися до кримінальної відповідальності?")]
        [Description("5.1. Чи притягувалися Ви до кримінальної відповідальності? Чи маєте Ви судимість не погашену, не зняту в установленому законодавством порядку?")]
        [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.BooleanEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Required]
        public bool HasBreachesOfLaw { get; set; }

        [DisplayName("Порушення господарського законодавства?")]
        [Description("5.2. Чи притягувалися Ви до відповідальності за порушення антимонопольного, податкового, банківського, валютного законодавства, правил діяльності на ринку цінних паперів тощо?")]
        [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.BooleanEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Required]
        public bool HasBreachesOfBusinessLaw { get; set; }

        /// <summary>
        /// обов'язкове, якщо HasBreachesOfLaw == true або HasBreachesOfBusinessLaw == true,
        /// мінімум один запис
        /// </summary>
        [DisplayName("Притягнення до відповідальності")]
        [Description("5.1. Чи притягувалися Ви до кримінальної відповідальності? Чи маєте Ви судимість не погашену, не зняту в установленому законодавством порядку?\n 5.2. Чи притягувалися Ви до відповідальності за порушення антимонопольного, податкового, банківського, валютного законодавства, правил діяльності на ринку цінних паперів тощо?\n(розшифровка)")]
        public List<BreachOfLawRecordInfo> BreachesOfLaw { get; set; }

        /// <summary>
        /// Якщо є; попередження про відповідальність 
        /// за подачу завідомо неправдивих відомостей
        /// </summary>
        [DisplayName("Зобов'язання перед іншими особами")]
        [Description("5.3. Чи маєте Ви невиконані майнові (фінансові) зобов'язання перед іншими особами?")]
        public List<IndebtnessInfo> OtherLiabilities { get; set; }

        /// <summary>
        /// Якщо є; попередження про відповідальність 
        /// за подачу завідомо неправдивих відомостей
        /// </summary>
        [DisplayName("Істотна участь у особах, ліквідованих останнього року")]
        [Description("5.4. Чи були Ви протягом останнього року,  що передував прийняттю рішення про ліквідацію юридичної особи, власником істотної участі  (10 і більше відсотків) у цій особі?")]
        [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.BooleanEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool HasLiquidatedSignOwnershipLastYear { get; set; }

        /// <summary>
        /// Якщо є; попередження про відповідальність 
        /// за подачу завідомо неправдивих відомостей
        /// </summary>
        [DisplayName("Істотна участь у особах, ліквідованих останнього року - розшифровка")]
        [Description("5.4. Чи були Ви протягом останнього року,  що передував прийняттю рішення про ліквідацію юридичної особи, власником істотної участі  (10 і більше відсотків) у цій особі?\n(розшифровка)")]
        public List<LiquidatedEntityOwnershipInfo> LiquidatedSignOwnershipLastYear { get; set; }

        [DisplayName("Дотримую законодавство...?")]
        [Description("5.5. Стверджую, що я належним чином виконую вимоги законодавства України з питань запобігання та протидії легалізації (відмиванню) доходів, одержаних злочинним шляхом, або фінансуванню тероризму та до мене не застосовувалися міжнародні санкції.")]
        [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.BooleanEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Required]
        public bool IsMoneyLaunderingEtcLawsKept { get; set; }

        [DisplayName("Підтверджую походження коштів?")]
        [Description("5.5. Стверджую, що маю можливість підтвердити походження джерел коштів, за рахунок яких придбаю акції банку.")]
        [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.BooleanEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Required]
        public bool CanProveMoneyOrigins { get; set; }

        [DisplayName("Підтверджую правдивість інформації?")]
        [Description("Я, (прізвище, ім'я, по батькові) стверджую, що інформація,  надана в анкеті,\n є правдивою і повною, та не заперечую проти перевірки Національним банком України достовірності поданих документів і персональних даних, що в них містяться.\n")]
        [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.BooleanEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Required]
        public bool IsApplicationInfoAccurateAndTrue { get; set; }

        [DisplayName("Зобов'язуюсь повідомляти про зміни?")]
        [Description("У разі будь-яких змін в інформації, що зазначена в цій анкеті, зобов'язуюся повідомити про них Національний банк України протягом 10-ти днів з дня їх виникнення.")]
        [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.BooleanEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Required]
        public bool AmObligingToKeepUp2DateWithin10Days { get; set; }

        [DisplayName("Реквізити осіб-фігурантів анкети")]
        [Description("Повна інформація про осіб, що згадуються в анкеті")]
        [Required]
        public List<GenericPersonInfo> MentionedIdentities { get; set; }
        
        /// <summary>
        /// Якщо є; попередження про відповідальність 
        /// за подачу завідомо неправдивих відомостей
        /// </summary>
        [DisplayName("Зв'язки між особами-фігурантами анкети")]
        [Description("Відомості про пов'язаних осіб, що згадуються в анкеті:\n1.5. Перелік асоційованих осіб")]
        public List<PersonsAssociation> PersonsLinks { get; set; }

        [DisplayName("Підписант")]
        [Description("Відомості по особу, що підписала анкету")]
        [Required]
        public SignatoryInfo Signatory { get; set; }
        
        /// <summary>
        /// Звичайні вимоги до повноти заповнення подібного типу даних...
        /// </summary>
        [DisplayName("Контакти")]
        [Description("Контактні дані відправника анкети")]
        [Required]
        public ContactInfo ContactPerson { get; set; }

        protected override string QuestionnairePrefixForFileName
        {
            get { return "regLicDod4FO"; }
        }

        protected override string BankNameForFileName
        {
            get { return GetBankNameForFileName(BankRef); }
        }

        protected override string ApplicantNameForFileName
        {
            get 
            { 
                if (this.Acquiree != null)
                    return this.Acquiree.FullName ?? this.Acquiree.FullNameUkr ?? this.Acquiree.Surname ?? this.Acquiree.SurnameUkr ?? string.Empty;
                return string.Empty;
            }
        }
    }
}
