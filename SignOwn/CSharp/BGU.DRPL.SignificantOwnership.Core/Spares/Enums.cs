#define __NO_FLAGS__
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.Spares
{
    [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.EnumLookupEditor), typeof(System.Drawing.Design.UITypeEditor))]
#if __NO_FLAGS__
#else
    [Flags]
#endif
    [UIUsageRadioButtonGroup(Orientation.Horizontal, false)]
    public enum  EntityType
    {
        [Description("Не вказано")]None = 0,
        [Description("Фізична особа")]
        Physical,
        [Description("Юридична особа")]
        Legal
    }

    [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.EnumLookupEditor), typeof(System.Drawing.Design.UITypeEditor))]
    public enum OwnershipType
    {
        [Description("Не вказано")]None = 0,
        [Description("Пряма власність")]
        Direct,
        [Description("Опосередкована власність")]
        Implicit,
        [Description("Власність через пов'язану особу")]
        Associated,
        [Description("Власність через угоду/договір")]
        Agreement,
        [Description("Власність по довіреності")]
        Attorney
    }

    [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.EnumLookupEditor), typeof(System.Drawing.Design.UITypeEditor))]
    public enum PersonAssociationType
    {
        [Description("Не вказано")]
        None = 0,
        [Description("Родич")]
        Relative,
        [Description("Довірена особа")]
        Attorney,
        [Description("Інший тип зв'язку")]
        Other
    }

#if __NO_FLAGS__
#else
    [Flags]
#endif

    [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.EnumLookupEditor), typeof(System.Drawing.Design.UITypeEditor))]
    [UIUsageRadioButtonGroup(Orientation.Horizontal, true)]
    public enum SexType
    {
        [Description("Не вказано")]None = 0,
        [Description("Чол.")]
        Male,
        [Description("Жін.")]
        Female
    }

#if __NO_FLAGS__
#else
    [Flags]
#endif

    [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.EnumLookupEditor), typeof(System.Drawing.Design.UITypeEditor))]
    public enum EmploymentState
    {
        [Description("Не вказано")]None = 0,
        [Description("Найманий працівник")]
        Employed,
        [Description("Самозайнятість/Фрілансер")]
        SelfemployedFreelance,
        [Description("Безробітний")]
        Unemployed,
        [Description("Пенсіонер")]
        Retired
    }

    /// <summary>
    /// Вид зайнятості - повна, часткова, тощо
    /// </summary>
    public enum EmploymentTimeType
    { 
        [Description("None")]
        None = 0,
        [Description("Повна (основна) зайнятість")]
        FullTime,
        [Description("Часткова (за сумісництвом) зайнятість")]
        PartTime,
    }

#if __NO_FLAGS__
#else
    [Flags]
#endif
    [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.EnumLookupEditor), typeof(System.Drawing.Design.UITypeEditor))]
    public enum EmploymentTerminationType
    {
        [Description("Не вказано")]
        None = 0,
        [Description("За угодою сторін")]
        PartiesConsent,
        [Description("Переведення працівника, за його згодою, на інше підприємство, в установу, організацію або перехід на виборну посаду")]
        PromotedOrRelocated,
        [Description("Звільнення з ініціативи працівника")]
        VoluntaryQuit,
        [Description("Закінчення строку трудового договору")]
        ContractExpiry,
        [Description("Через відмову працівника від переведення на роботу в іншу місцевість разом з підприємством, установою, організацією, а також відмова від продовження роботи у зв'язку із зміною істотних умов праці")]
        RefusedToRelocate,
        [Description("набрання законної сили вироком суду, яким працівника засуджено (крім випадків звільнення від відбування покарання з випробуванням) до позбавлення волі або до іншого покарання, яке виключає можливість продовження даної роботи")]
        Conviction,
        [Description("З підстав, передбачених контрактом")]
        ContractualConditions,
        [Description("Звільнення з ініціативи власника або уповноваженого ним органу")]
        Dismissed,
        [Description("Звільнення на вимогу профспілкового чи іншого уповноваженого на представництво трудовим колективом органу")]
        TradeUnionDemand,
        [Description("Вихід на пенсію")]
        Retired,
        [Description("Декретна відпустка")]
        MaternityLeave,
        [Description("У зв’язку із призовом або вступом працівника на військову службу, направленням на альтернативну (невійськову) службу")]
        MilitaryServiceLeave,
        [Description("За станом здоров'я")]
        HealthConditionLeave,
        [Description("Інше")]
        OtherLeaveType
    }

    /// <summary>
    /// Тип диплому про освіту / освітньо-кваліфікаційний рівень та ступінь
    /// (зг.п.2. ст.30 З-ну про Освіту)
    /// </summary>
#if __NO_FLAGS__
#else
    [Flags]
#endif
    [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.EnumLookupEditor), typeof(System.Drawing.Design.UITypeEditor))]
    public enum HigherEducationDegreeType
    {
        [Description("не вказано")]
        None = 0,
        [Description("кваліфікований робітник (або еквівалент)")]
        QualifiedWorkerOrEquiv,
        [Description("молодший спеціаліст (або еквівалент)")]
        JuniorSpecialistOrEquiv,
        [Description("молодший бакалавр (або еквівалент)")]
        JuniorBachelorOrEquiv,
        [Description("бакалавр (або еквівалент)")]
        BachelorOrEquiv,
        [Description("магістр (або еквівалент)")]
        MasterOrEquiv,
        //[Description("MBA")]
        //MBA,
        [Description("доктор філософії (або еквівалент)")]
        PhDOrEquiv,
        [Description("доктор наук (або еквівалент)")]
        SciencesDoctorOrEquiv,
    }

    /// <summary>
    /// Вчене звання (та його еквіваленти)
    /// (зг.п.1 ст.32 З-ну про Освіту)
    /// </summary>
    public enum ScientificDegreeType
    { 
        None = 0,
        [Description("старший дослідник (або еквівалент)")]
        SeniorResearcherOrEquiv,
        [Description("доцент")]
        Docent,
        [Description("Професор")]
        Professor
    }

    /// <summary>
    /// Підвид освіти: 
    /// У базі доцільно завести динамічний довідник, бо для цілей 
    /// реєстрації, ліцензування чи пруденційного нагляду перелік 
    /// може бути розширено чи уточнено.
    /// </summary>
    public enum EducationKindGros
    {
        //[Description("Не вказано")]
        //None = 0,
        //[Description("Фінансова/банківська")]
        //BankingFinance,
        //[Description("Інша економічна")]
        //OtherEconomics,
        //[Description("Юридична")]
        //Legal,
        //[Description("Управлінська")]
        //Management,
        //[Description("Інша гуманітарна")]
        //OtherHumanitarian,
        //[Description("Технічна")]
        //Engineering,
        //[Description("Інша")]
        //Miscellaneous
        [Description("Не вказано")]
        None = 0,
        [Description("галузь економіки")]
        Economics,
        [Description("галузь менеджменту")]
        Management,
        [Description("галузь права")]
        Jurisprudence,
        [Description("інше")]
        Miscellaneous
    }

    [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.EnumLookupEditor), typeof(System.Drawing.Design.UITypeEditor))]
    public enum DegreeHonourType
    {
        [Description("Не вказано")]None = 0,
        [Description("Звичайний (без відзнаки)")]
        Rite,
        [Description("З відзнакою (Cum laude)")]
        CumLaude,
        [Description("З відзнакою (\"червоний\"), до-болонська система")]
        Honoured,
        [Description("Зі значною відзнакою (magna cum laude)")]
        MagnaCumLaude,
        [Description("З найвищою відзнакою (summa cum laude)")]
        SummaCumLaude,
        [Description("З вийнятковою відзнакою (egregia cum laude)")]
        EgregiaCumLaude,
        [Description("З максимальною відзнакою (maxima cum laude)")]
        MaximaCumLaude
    }

#if __NO_FLAGS__
#else
    [Flags]
#endif
    [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.EnumLookupEditor), typeof(System.Drawing.Design.UITypeEditor))]
    public enum FundsOriginType
    {
        [Description("Не вказано")]None = 0,
        [Description("Зарплатня (ф.о.)")]
        WagesSalaries,
        [Description("Роялті (ф.о.)")]
        Royalties,
        [Description("Дивіденди (ф.о.)")]
        Dividends,
        [Description("Пасивний дохід")]
        PassiveIncomes,
        [Description("Спадщина (ф.о.)")]
        Inherited,
        [Description("Прибуток (ю.о.)")]
        Profit,
        [Description("Частина статутного капіталу (ю.о.)")]
        Equity,
        [Description("Кошти фонду(-ів) (ю.о.)")]
        SpecFunds,
        [Description("Інші доходи")]
        OtherIncomes
    }

#if __NO_FLAGS__
#else
    [Flags]
#endif
    [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.EnumLookupEditor), typeof(System.Drawing.Design.UITypeEditor))]
    [UIUsageRadioButtonGroup(Orientation.Horizontal, false)]
    public enum PaymentType
    {
        [Description("Не вказано")]None = 0,
        [Description("Готівка")]
        Cash,
        [Description("Безготівка")]
        WireTransfer,
        [Description("Інше")]
        Other
    }

#if __NO_FLAGS__
#else
    [Flags]
#endif
    [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.EnumLookupEditor), typeof(System.Drawing.Design.UITypeEditor))]
    public enum FinancialGuarantorRoleType
    {
        [Description("Не вказано")]None = 0,
        [Description("Гарант")]
        Guarantor,
        [Description("Заставодавець/поручитель")]
        Pledger,
        [Description("Довірена особа")]
        Attorney
    }

#if __NO_FLAGS__
#else
    [Flags]
#endif
    [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.EnumLookupEditor), typeof(System.Drawing.Design.UITypeEditor))]
    public enum BreachOfLawType
    {
        [Description("Не вказано")]
        None = 0,
        [Description("Кримінальна відповідальність")]
        Criminal,
        [Description("Адміністративна відповідальність")]
        Administrative,
        [Description("За порушення антимонопольного законодавства")]
        Antitrust,
        [Description("За порушення податкового законодавства")]
        Taxation,
        [Description("За порушення банківського  законодавства")]
        Banking,
        [Description("За порушення законодавства про фінансові послуги")]
        Financial,
        [Description("За порушення валютного законодавства")]
        ForeignCurrency,
        [Description("За порушення на ринку цінних паперів (фондовому ринку)")]
        StockExchange,
        [Description("Інша адміністративна відповідальність")]
        OtherAdministrative
    }

#if __NO_FLAGS__
#else
    [Flags]
#endif
    [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.EnumLookupEditor), typeof(System.Drawing.Design.UITypeEditor))]
    public enum SentenceType
    {
        [Description("Не вказано")]None = 0,
        [Description("Ув'язнення")]
        Jailed,
        [Description("Умовне ув'язнення")]
        Probation,
        [Description("Виправні роботи")]
        RemedialWorks,
        [Description("Штраф")]
        Fined,
        [Description("Звільнення")]
        Dismissed,
        [Description("Позбавлення права займатися певною діяльністю/займати певні посади")]
        ProfessionalBan,
        [Description("Відкликання/позбавлення ліцензії")]
        LicenseRevoked,
        [Description("Призупинення ліцензії")]
        LicenseSuspended
    }

    [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.EnumLookupEditor), typeof(System.Drawing.Design.UITypeEditor))]
    public enum TypicalApplicationAttachement
    {
        [Description("Не вказано")]
        None = 0,
        [Description("Копії/скан внутрішніх положень")]
        InternalReglementCopiesScans,
        [Description("Копії/скан трудової книги")]
        WorkbookCopyScan,
        [Description("Копії/скан паспорта")]
        PassportCopyScan,
        [Description("Копії/скан статуту")]
        CharterCopyScan,
        [Description("Діграма структури власності")]
        OwnershipDiagram,
        [Description("Інше (вказати додатково у деталях)")]
        Other
    }

    /// <summary>
    /// Види ліцензій
    /// </summary>
    public enum LicensedOperationType
    {
        [Description("Не вказано")]
        None = 0,
        [Description("Вид банківської діяльності")]
        BankingActivity,
        [Description("Фінансова послуга")]
        FinancialService,
        [Description("Діяльність за генліцензією (банк)")]
        FXGLBkActivity,
        [Description("Діяльність за генліцензією (не-банк)")]
        SMActivityType
    }

    #region Financial services types
    /// <summary>
    /// Розділ II. УМОВИ НАДАННЯ ФІНАНСОВИХ ПОСЛУГ 
    /// 
    /// 
    /// Стаття 4. Фінансові послуги 
    /// 
    /// 1. Фінансовими вважаються такі послуги: 
    /// 
    /// 1) випуск платіжних документів, платіжних карток, дорожніх чеків та/або їх обслуговування, кліринг, інші форми забезпечення розрахунків; 
    /// 
    /// 2) довірче управління фінансовими активами; 
    /// 
    /// 3) діяльність з обміну валют; 
    /// 
    /// 4) залучення фінансових активів із зобов'язанням щодо наступного їх повернення; 
    /// 
    /// 5) фінансовий лізинг; 
    /// 
    /// 6) надання коштів у позику, в тому числі і на умовах фінансового кредиту; 
    /// 
    /// 7) надання гарантій та поручительств; 
    /// 
    /// 8) переказ коштів; 
    /// 
    /// (пункт 8 частини першої статті 4 із змінами, внесеними
    ///  згідно із Законом України від 02.12.2010 р. N 2756-VI)
    /// 
    /// 9) послуги у сфері страхування та у системі накопичувального пенсійного забезпечення; 
    /// 
    /// (пункт 9 частини першої статті 4 із змінами, внесеними
    ///  згідно із Законом України від 08.07.2011 р. N 3668-VI)
    /// 
    /// 10) професійна діяльність на ринку цінних паперів, що підлягає ліцензуванню;
    /// 
    /// (пункт 10 частини першої статті 4 у редакції
    ///  Закону України від 02.06.2011 р. N 3462-VI)
    /// 
    /// 11) факторинг; 
    /// 
    /// 11 1) адміністрування фінансових активів для придбання товарів у групах;
    /// 
    /// (частину першу статті 4 доповнено пунктом 11 1 згідно
    ///  із Законом України від 02.06.2011 р. N 3462-VI)
    /// 
    /// 12) управління майном для фінансування об'єктів будівництва та/або здійснення операцій з нерухомістю відповідно до Закону України "Про фінансово-кредитні механізми і управління майном при будівництві житла та операціях з нерухомістю";
    /// 
    /// (пункт 12 частини першої статті 4 у редакції
    ///  Закону України від 10.10.2013 р. N 643-VII)
    /// 
    /// 13) операції з іпотечними активами з метою емісії іпотечних цінних паперів;
    /// 
    /// (частину першу статті 4 доповнено пунктом 13
    ///  згідно із Законом України від 10.10.2013 р. N 643-VII)
    /// 
    /// 14) банківські та інші фінансові послуги, що надаються відповідно до Закону України "Про банки і банківську діяльність".
    /// </summary>
    [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.EnumLookupEditor), typeof(System.Drawing.Design.UITypeEditor))]
    public enum FinancialServicesType
    {
        [Description("Не вказано")]
        None = 0,
        [Description("п.1 випуск платіжних документів, платіжних карток, дорожніх чеків та/або їх обслуговування, кліринг, інші форми забезпечення розрахунків (ст.4 з-ну Про фінпослуги)")]
        PayDocsIssuance = 1,
        [Description("п.2 довірче управління фінансовими активами (ст.4 з-ну Про фінпослуги)")]
        Trust = 2,
        [Description("п.3 діяльність з обміну валют (ст.4 з-ну Про фінпослуги)")]
        CurrencyExchange = 3,
        [Description("п.4 залучення фінансових активів із зобов'язанням щодо наступного їх повернення (ст.4 з-ну Про фінпослуги)")]
        FinanceAssetsLiabilities = 4,
        [Description("п.5 фінансовий лізинг (ст.4 з-ну Про фінпослуги)")]
        FinancialLeasing = 5,
        [Description("п.6 надання коштів у позику, в тому числі і на умовах фінансового кредиту (ст.4 з-ну Про фінпослуги)")]
        Lending = 6,
        [Description("п.7 надання гарантій та поручительств (ст.4 з-ну Про фінпослуги)")]
        Guarantees = 7,
        [Description("п.8 переказ коштів (ст.4 з-ну Про фінпослуги)")]
        FundsTransfer = 8,
        [Description("п.9 послуги у сфері страхування та у системі накопичувального пенсійного забезпечення (ст.4 з-ну Про фінпослуги)")]
        InsuranceAndPensionSavings = 9,
        [Description("п.10 професійна діяльність на ринку цінних паперів, що підлягає ліцензуванню (ст.4 з-ну Про фінпослуги)")]
        StockExchangeActivities = 10,
        [Description("п.11 факторинг (ст.4 з-ну Про фінпослуги)")]
        Factoring = 11,
        [Description("п.11.1 адміністрування фінансових активів для придбання товарів у групах (ст.4 з-ну Про фінпослуги)")]
        FinAssetsAdministeringGroupsPurchase = 12,
        [Description("п.12 управління майном для фінансування об'єктів будівництва та/або здійснення операцій з нерухомістю відповідно до Закону України Про фінансово-кредитні механізми і управління майном при будівництві житла та операціях з нерухомістю (ст.4 з-ну Про фінпослуги)")]
        ConstructionAssetsManagement = 13,
        [Description("п.13 операції з іпотечними активами з метою емісії іпотечних цінних паперів (ст.4 з-ну Про фінпослуги)")]
        MortgageSecuritiesMngtIssue = 14,
        [Description("п.14 банківські та інші фінансові послуги, що надаються відповідно до Закону України Про банки і банківську діяльність (ст.4 з-ну Про фінпослуги)")]
        OtherFinBankServices = 15,
    }

    #endregion

    #region Types of banking activities
    /// <summary>
    /// Глава 8. ВИМОГИ ДО ДІЯЛЬНОСТІ БАНКУ 
    /// 
    /// 
    /// Стаття 47. Види діяльності банку 
    /// 
    /// Банк має право надавати банківські та інші фінансові послуги (крім послуг у сфері страхування), а також здійснювати іншу діяльність, визначену в цій статті. 
    /// 
    /// Банк має право здійснювати банківську діяльність на підставі банківської ліцензії шляхом надання банківських послуг. 
    /// 
    /// До банківських послуг належать: 
    /// 
    /// 1) залучення у вклади (депозити) коштів та банківських металів від необмеженого кола юридичних і фізичних осіб; 
    /// 
    /// 2) відкриття та ведення поточних (кореспондентських) рахунків клієнтів, у тому числі у банківських металах; 
    /// 
    /// 3) розміщення залучених у вклади (депозити), у тому числі на поточні рахунки, коштів та банківських металів від свого імені, на власних умовах та на власний ризик. 
    /// 
    /// Банківські послуги дозволяється надавати виключно банку. Центральний депозитарій цінних паперів має право провадити окремі банківські операції на підставі ліцензії на здійснення окремих банківських операцій, що видається у встановленому Національним банком України порядку.
    /// 
    /// (частина четверта статті 47 у редакції
    ///  Закону України від 06.07.2012 р. N 5178-VI,
    ///  із змінами, внесеними згідно із
    ///  Законом України від 04.07.2013 р. N 401-VII)
    /// 
    /// Банк має право надавати своїм клієнтам (крім банків) фінансові послуги, у тому числі шляхом укладення з юридичними особами (комерційними агентами) агентських договорів. Перелік фінансових послуг, що банк має право надавати своїм клієнтам (крім банків) шляхом укладення агентських договорів, встановлюється Національним банком України. Банк зобов'язаний повідомити Національний банк України про укладені ним агентські договори. Національний банк веде реєстр комерційних агентів банків та встановлює вимоги до них. Банк має право укладати агентський договір з юридичною особою, яка відповідає встановленим Національним банком України вимогам. 
    /// 
    /// Частину шосту статті 47 виключено
    /// 
    /// (згідно із Законом України
    ///  від 19.05.2011 р. N 3394-VI)
    /// 
    /// Частину сьому статті 47 виключено
    /// 
    /// (згідно із Законом України
    ///  від 19.05.2011 р. N 3394-VI)
    /// 
    /// Банк, крім надання фінансових послуг, має право здійснювати також діяльність щодо: 
    /// 
    /// 1) інвестицій; 
    /// 
    /// 2) випуску власних цінних паперів; 
    /// 
    /// 3) випуску, розповсюдження та проведення лотерей; 
    /// 
    /// 4) зберігання цінностей або надання в майновий найм (оренду) індивідуального банківського сейфа; 
    /// 
    /// 5) інкасації коштів та перевезення валютних цінностей; 
    /// 
    /// 6) ведення реєстрів власників іменних цінних паперів (крім власних акцій); 
    /// 
    /// 7) надання консультаційних та інформаційних послуг щодо банківських та інших фінансових послуг. 
    /// </summary>
    [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.EnumLookupEditor), typeof(System.Drawing.Design.UITypeEditor))]
    public enum BankingActivityType
    {
        [Description("Не вказано")]
        None = 0,
        [Description("п.1 залучення у вклади (депозити) коштів та банківських металів від необмеженого кола юридичних і фізичних осіб (ч.1-а ст.47 З-ну Про БіБД)")]
        DepositsTaking = 1,
        [Description("п.2 відкриття та ведення поточних (кореспондентських) рахунків клієнтів, у тому числі у банківських металах (ч.1-а ст.47 З-ну Про БіБД)")]
        AccountsMgmt = 2,
        [Description("п.3 розміщення залучених у вклади (депозити), у тому числі на поточні рахунки, коштів та банківських металів від свого імені, на власних умовах та на власний ризик (ч.1-а ст.47 З-ну Про БіБД)")]
        DepositedFundsPlacement = 3,
        [Description("п.1 інвестицій (ч.8-а ст.47 З-ну Про БіБД)")]
        Investments = 4,
        [Description("п.2 випуску власних цінних паперів (ч.8-а ст.47 З-ну Про БіБД)")]
        ProprietarySecuritiesIssue = 5,
        [Description("п.3 випуску, розповсюдження та проведення лотерей (ч.8-а ст.47 З-ну Про БіБД)")]
        Lotteries = 6,
        [Description("п.4 зберігання цінностей або надання в майновий найм (оренду) індивідуального банківського сейфа (ч.8-а ст.47 З-ну Про БіБД)")]
        SafeCustody = 7,
        [Description("п.5 інкасації коштів та перевезення валютних цінностей (ч.8-а ст.47 З-ну Про БіБД)")]
        CashCollectionTransportation = 8,
        [Description("п.6 ведення реєстрів власників іменних цінних паперів (крім власних акцій) (ч.8-а ст.47 З-ну Про БіБД)")]
        SecuritiesCustody = 9,
        [Description("п.7 надання консультаційних та інформаційних послуг щодо банківських та інших фінансових послуг (ч.8-а ст.47 З-ну Про БіБД)")]
        ConsultancyOnBankFinServices = 10,

    }
    #endregion


    #region Type of FX licensed activities

    /// <summary>
    /// Види ліцензованої діяльності за генеральною банківською валютною ліцензією
    /// </summary>
    public enum GeneralFXLicenseActivityType
    {
        [Description("Не вказано")]
        None = 0,
        [Description("неторговельні операції з валютними цінностями")]
        GFX_NonTrade,
        [Description("операції з готівковою іноземною валютою та чеками (купівля, продаж, обмін, прийняття на інкасо), що здійснюються в касах і пунктах обміну іноземної валюти банків")]
        GFX_CashBankOps,
        [Description("операції з готівковою іноземною валютою (купівля, продаж, обмін), що здійснюються в пунктах обміну іноземної валюти, які працюють на підставі укладених банками агентських договорів з юридичними особами-резидентами")]
        GFX_CashAgentOps,
        [Description("ведення рахунків клієнтів (резидентів і нерезидентів) в іноземній валюті та клієнтів-нерезидентів у грошовій одиниці України")]
        GFX_AcctMgmt,
        [Description("ведення кореспондентських рахунків банків (резидентів і нерезидентів) в іноземній валюті")]
        GFX_CorrBkAcctMgmtFCCY,
        [Description("ведення кореспондентських рахунків банків (нерезидентів) у грошовій одиниці України")]
        GFX_CorrBkAcctMgmtLCCY,
        [Description("відкриття кореспондентських рахунків в уповноважених банках України в іноземній валюті та здійснення операцій за ними")]
        GFX_CorrAcctHaveInUABksFCCY,
        [Description("відкриття кореспондентських рахунків у банках (нерезидентах) в іноземній валюті та здійснення операцій за ними")]
        GFX_CorrAcctHaveInNonUABksFCCY,
        [Description("залучення та розміщення іноземної валюти на валютному ринку України")]
        GFX_FCCYBorrNPlaceLocalMarket,
        [Description("залучення та розміщення іноземної валюти на міжнародних ринках")]
        GFX_FCCYBorrNPlaceWorldMarket,
        [Description("торгівля іноземною валютою на валютному ринку України [за винятком операцій з готівковою іноземною валютою та чеками (купівля, продаж, обмін), що здійснюється в касах і пунктах обміну іноземної валюти банків і агентів]")]
        GFX_FCCYTradingNonCashLocalMarket,
        [Description("торгівля іноземною валютою на міжнародних ринках")]
        GFX_FCCYTradingNonCashWorldMarket,
        [Description("залучення та розміщення банківських металів на валютному ринку України")]
        GFX_BkMetalBorrNPlaceLocalMarket,
        [Description("залучення та розміщення банківських металів на міжнародних ринках")]
        GFX_BkMetalBorrNPlaceWorldMarket,
        [Description("торгівля банківськими металами на валютному ринку України")]
        GFX_BkMetalTradingLocalMarket,
        [Description("торгівля банківськими металами на міжнародних ринках")]
        GFX_BkMetalTradingWorldMarket,
        [Description("валютні операції на валютному ринку України, які належать до фінансових послуг згідно зі статтею 4 ЗУпФПтДРРФП та не зазначені в абзацах 2-17 розділу 2 Положення про порядок надання банкам і філіям іноземних банків генеральних ліцензій на здійснення валютних операцій, затвердженого постановою Правління Національного банку України від 15.08.2011 № 281")]
        GFX_FinSvcLocalMarket,
        [Description("валютні операції на міжнародних ринках, які належать до фінансових послуг згідно зі статтею 4 ЗУпФПтДРРФП та не зазначені в абзацах 2-17 розділу 2 Положення про  порядок надання банкам і філіям іноземних банків генеральних ліцензій на здійснення валютних операцій, затвердженого постановою Правління Національного банку України від 15.08.2011 № 281")]
        GFX_FinSvcWorldMarket,
    }
    #endregion

    #region Stock market licensed activities:
    /// <summary>
    /// Види професійної діяльності на фондовому ринку
    /// </summary>
    public enum ProfessionalStockMarketActivityType
    {
        [Description("Не вказано")]
        None = 0,
        [Description("діяльність з торгівлі цінними паперами (пп.1 ч.2 ст.16 ЗпЦПіФР)")]
        SMSecuritiesTrading,
        [Description("діяльність з управління активами інституційних інвесторів (пп.2 ч.2 ст.16 ЗпЦПіФР)")]
        SMInstInvAssetsMgmt,
        [Description("депозитарна діяльність (пп.3 ч.2 ст.16 ЗпЦПіФР)")]
        SMDepositoryActivities,
        [Description("діяльність з організації торгівлі на фондовому ринку (пп.4 ч.2 ст.16 ЗпЦПіФР)")]
        SMTradeOrganization,
        [Description("клірингова діяльність (пп.5 ч.2 ст.16 ЗпЦПіФР)")]
        SMClearing,
    }

    /// <summary>
    /// Під-види професійної діяльності на ринку цінних паперів та фондовому ринку
    /// </summary>
    public enum ProfessionalStockMarketActivitySubType
    {
        [Description("Не вказано")]
        None = 0,
        [Description("брокерська діяльність (пп.1 ч.2, п.1, ст.17 ЗпЦПіФР)")]
        SMTBrokerage,
        [Description("дилерська діяльність (пп.2 ч.2, п.1, ст.17 ЗпЦПіФР)")]
        SMTDealership,
        [Description("андеррайтинг (пп.3 ч.2, п.1, ст.17 ЗпЦПіФР)")]
        SMTUnderwriting,
        [Description("діяльність з управління цінними паперами (пп.4 ч.2, п.1, ст.17 ЗпЦПіФР)")]
        SMTSecuritiesMgmt,
    }
    #endregion

    /// <summary>
    /// Близький до вичерпного перелік ролей пов'язаних осіб-родичів
    /// Додаткові посилання:
    ///  - http://uba.ua/documents/doc/bevza.pdf
    ///  - http://uk.wikipedia.org/wiki/%D0%9F%D0%BE%D0%B2'%D1%8F%D0%B7%D0%B0%D0%BD%D0%B0_%D0%BE%D1%81%D0%BE%D0%B1%D0%B0
    /// </summary>
    /// <seealso cref="http://uba.ua/documents/doc/bevza.pdf"/>
    [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.EnumLookupEditor), typeof(System.Drawing.Design.UITypeEditor))]
    public enum AssociatedPersonRole
    { 
        [Description("Не вказано")]
        None = 0,
        [Description("чоловік")]
        Husband,
        [Description("дружина")]
        Wife,
        [Description("син")]
        Son,
        [Description("дочка")]
        Daughter,
        [Description("батько")]
        Father,
        [Description("мати")]
        Mother,
        [Description("опікун/-ка")]
        Patron,
        [Description("брат")]
        Brother,
        [Description("сестра")]
        Sister,
        [Description("тесть/свекор")]
        FatherInLaw,
        [Description("теща/свекруха")]
        MotherInLaw,
        [Description("зять")]
        SonInLaw,
        [Description("невістка")]
        DaughterInLaw,
        [Description("шурин/дівер/зять")]
        BrotherInLaw,
        [Description("сестра чоловіка")]
        SisterInLaw,
        [Description("двоюрідні брат/сестра")]
        Cousin,
        [Description("дід")]
        GrandFather,
        [Description("баба")]
        GrandMother,
        [Description("онук")]
        GrandSon,
        [Description("онука")]
        GrandDaughter,
        [Description("племінник(-ця) / небіж / небога")]
        NephewNiece,
        [Description("дядько / тітка / дядина")]
        AuncleAunt,
        [Description("інший родич")]
        OtherRelative
    }

    [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.EnumLookupEditor), typeof(System.Drawing.Design.UITypeEditor))]
    public enum ManagementPosition
    {
        [Description("Не вказано")]
        None = 0,
        [Description("Голова Правління")]
        CEO,
        [Description("Заступник Голови Правління")]
        VCEO,
        [Description("Член Правління")]
        ManagingBoardMember,
        [Description("Головний бухгалтер")]
        ChiefBookkeeper,
        [Description("Заступник головного бухгалтера")]
        DeputyChiefBookkeeper,
        [Description("Голова Спостережної ради")]
        SupervisoryBoardHead,
        [Description("Заступник Голови Спостережної ради")]
        DeputySupervisoryBoardHead,
        [Description("Член Спостережної ради")]
        SupervisoryBoardMember,
        [Description("Представник юридичної особи – Члена спостережної ради")]
        SupervisoryBoardMemberLPRep
    }

    [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.EnumLookupEditor), typeof(System.Drawing.Design.UITypeEditor))]
    [UIUsageRadioButtonGroup(Orientation.Horizontal, false)]
    public enum InsolvencyStatus
    {
        [Description("Не вказано")]
        None = 0,
        [Description("Банкрут")]
        Insolvent,
        [Description("Ліквідовано")]
        Liquidated
    }

    /// <summary>
    /// http://en.wikipedia.org/wiki/Fitch_Ratings#Long-term_credit_ratings
    /// http://en.wikipedia.org/wiki/DBRS
    /// http://en.wikipedia.org/wiki/Dagong_Global_Credit_Rating
    /// 
    /// </summary>
    /// <seealso cref="http://en.wikipedia.org/wiki/Moody%27s_Investors_Service#Moody.27s_credit_ratings"/>
    [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.EnumLookupEditor), typeof(System.Drawing.Design.UITypeEditor))]
    public enum WellKnownCreditRatingAgencyType
    {
        [Description("Не вказано")]
        None = 0,
        [Description("Moody's Investor Service")]
        Moodys,
        [Description("Fitch Ratings")]
        Fitch,
        [Description("Standard & Poors")]
        SAndP,
        [Description("DRBS")]
        DRBS,
        [Description("Dagong Credit Rating (та дочірні рейтингові компанії)")]
        Dagong,
        [Description("Japan Credit Rating")]
        JCR,
        [Description("ARC Ratings, S.A.")]
        ACR,
        [Description("Українська кредитна рейтингова аґенція")]
        UCRA,
        [Description("Інша")]
        Other
    }

    [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.EnumLookupEditor), typeof(System.Drawing.Design.UITypeEditor))]
    public enum LongTermCreditRatingType
    {
        [Description("Не вказано")]
        None = 0,
        [Description("A")]
        A,
        [Description("A1")]
        A1,
        [Description("A2")]
        A2,
        [Description("A3")]
        A3,
        [Description("AA")]
        AA,
        [Description("Aa1")]
        Aa1,
        [Description("Aa2")]
        Aa2,
        [Description("Aa3")]
        Aa3,
        [Description("AAA")]
        AAA,
        [Description("AAA-")]
        AAAMinus,
        [Description("AAA+")]
        AAAPlus,
        [Description("AA-")]
        AAMinus,
        [Description("AA+")]
        AAPlus,
        [Description("A-")]
        AMinus,
        [Description("A+")]
        APlus,
        [Description("B")]
        B,
        [Description("B1")]
        B1,
        [Description("B2")]
        B2,
        [Description("B3")]
        B3,
        [Description("Ba1")]
        Ba1,
        [Description("Ba2")]
        Ba2,
        [Description("Ba3")]
        Ba3,
        [Description("Baa1")]
        Baa1,
        [Description("Baa2")]
        Baa2,
        [Description("Baa3")]
        Baa3,
        [Description("BB")]
        BB,
        [Description("BBB")]
        BBB,
        [Description("BBB-")]
        BBBMinus,
        [Description("BBB+")]
        BBBPlus,
        [Description("BB-")]
        BBMinus,
        [Description("BB+")]
        BBPlus,
        [Description("B-")]
        BMinus,
        [Description("B+")]
        BPlus,
        [Description("C")]
        C,
        [Description("Ca")]
        Ca,
        [Description("Caa1")]
        Caa1,
        [Description("Caa2")]
        Caa2,
        [Description("Caa3")]
        Caa3,
        [Description("CC")]
        CC,
        [Description("CCC")]
        CCC,
        [Description("CCC-")]
        CCCMinus,
        [Description("CCC+")]
        CCCPlus,
        [Description("CC-")]
        CCMinus,
        [Description("CC+")]
        CCPlus,
        [Description("C-")]
        CMinus,
        [Description("C+")]
        CPlus,
        [Description("D")]
        D,
        [Description("LD")]
        LD,
        [Description("NR")]
        NR,
        [Description("R")]
        R,
        [Description("Інше (вказати)")]
        Other
    }

    [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.EnumLookupEditor), typeof(System.Drawing.Design.UITypeEditor))]
    public enum ShortTermCreditRatingType
    {
        [Description("Не вказано")]
        None = 0,
        [Description("A-1")]
        A1,
        [Description("A-2")]
        A2,
        [Description("A-3")]
        A3,
        [Description("B")]
        B,
        [Description("C")]
        C,
        [Description("D")]
        D,
        [Description("Інше (вказати)")]
        Other
    }

    [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.EnumLookupEditor), typeof(System.Drawing.Design.UITypeEditor))]
    public enum BankruptcyCaseResolutionType
    {
        [Description("Не вказано")]
        None = 0,
        [Description("Порушено справу")]
        CaseFiled,
        [Description("Оголошено банкрутом")]
        DeclaredBankrupt,
        [Description("У стані санації")]
        InFinRecovery,
        [Description("Відновлено (після банкрутства)")]
        BankruptedRecovered,
        [Description("Ліквідовано")]
        Liquidated,
        [Description("Сановано")]
        FinRecovered
    }

    /// <summary>
    /// Перелік як у випадаючому списку "Інстанція"
    /// </summary>
    /// <seealso cref="http://www.reyestr.court.gov.ua/"/>
    [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.EnumLookupEditor), typeof(System.Drawing.Design.UITypeEditor))]
    [UIUsageRadioButtonGroup(Orientation.Horizontal, true)]
    public enum CourtInstanceType
    { 
        [Description("Перша")]
        First,
        [Description("Апеляційна")]
        Appeal,
        [Description("Касаційна")]
        Cassation
    }

    [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.EnumLookupEditor), typeof(System.Drawing.Design.UITypeEditor))]
    public enum CourtDecisionType
    {
        [Description("Вирок")]
        Sentence,
        [Description("Постанова")]
        Ruling,
        [Description("Рішення")]
        Decision,
        [Description("Судовий наказ")]
        CourtOrder,
        [Description("Ухвала суду")]
        CourtResolution,
        [Description("Окрема ухвала")]
        SpecialResolution,
        //[Description("Окрема думка судді")]
        //JudgesMinorityReport
    }

    [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.EnumLookupEditor), typeof(System.Drawing.Design.UITypeEditor))]
    public enum BankAssociatedPersonsCode315p
    { 
        [Description("Не вказано")]
        None = 0,
        [Description("521-Контролери банку")]
        BankControllers = 521,
        [Description("522-Особи, які мають істотну участь у банку, та особи, через яких ці особи здійснюють опосередковане володіння істотною участю в банку")]
        SignificantOwners = 522,
        [Description("523-Керівники банку, керівник служби внутрішнього аудиту, керівники та члени комітетів банку")]
        BankMgrsEtc = 523,
        [Description("524-Споріднені та афільовані особи банку, у тому числі учасники банківської групи")]
        Affiliated = 524,
        [Description("525-Особи, які мають істотну участь у споріднених та афільованих особах банку")]
        AffiliatedSignOwners = 525,
        [Description("526-Керівники юридичних осіб та керівники банків, які є спорідненими та афільованими особами банку, керівник служби внутрішнього аудиту, керівники та члени комітетів цих осіб")]
        AffiliatedMgrsEtc = 526,
        [Description("527-Асоційовані особи фізичних осіб, зазначених у пунктах 1 – 6 частини першої статті 52 Закону")]
        AssocPersonsArt52pp16 = 527,
        [Description("528-Юридичні особи, у яких фізичні особи, зазначені в частині першій статті 52 Закону, є керівниками або власниками істотної участі")]
        Art52MgrsSignOwnersLPs = 528,
        [Description("529-Будь-яка особа, через яку проводиться операція в інтересах осіб, зазначених у частині першій статті 52 Закону, та на яку здійснюють вплив під час проведення такої операції особи, зазначені в цій частині, через трудові, цивільні та інші відносини")]
        AnyPersonInfluencingArt52 = 529,
    }

    [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.EnumLookupEditor), typeof(System.Drawing.Design.UITypeEditor))]
    public enum LegalTransactionType
    {
        [Description("Не вказано")]
        None = 0,
        [Description("Договір купівлі-продажу")]
        BuySellAgreement,
        [Description("Договір дарування")]
        GrantAgreement,
        [Description("Спадщина")]
        Inheritance,
        [Description("Договір обміну")]
        SwapAgreement,
        [Description("Інше")]
        Other
    }


    [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.EnumLookupEditor), typeof(System.Drawing.Design.UITypeEditor))]
    [Description("Тип впливу")]
    [UIUsageRadioButtonGroup(Orientation.Horizontal, false)]
    public enum InfluenceType
    {
        [Description("Не вказано")]
        None = 0,
        [Description("Значний")]
        Significant,
        [Description("Вирішальний")]
        Decisive
    }

    [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.EnumLookupEditor), typeof(System.Drawing.Design.UITypeEditor))]
    public enum LegalTransactionPartyRoleType
    {
        [Description("Не вказано")]
        None = 0,
        [Description("Продавець")]
        Buyer,
        [Description("Покупець")]
        Seller,
        [Description("Дарувальник")]
        Grantor,
        [Description("Обдаровуваний")]
        Grantee,
        [Description("Заповідач")]
        Legator,
        [Description("Спадкоємець")]
        Inheritor,
        [Description("Поручитель")]
        Gurantor,
        [Description("Кредитор")]
        Creditor,
        [Description("Позичальник")]
        Borrower,
        [Description("Боржник")]
        Obligor,
        [Description("Застоводавець")]
        Pledger,
        [Description("Заставодержатель")]
        Pledgee,
        [Description("Інше")]
        Other
    }

    public enum MeansOfCommunication
    {
        [Description("Не вказано")]
        None = 0,
        [Description("Телефон(-и)")]
        Phone,
        [Description("Ел.пошта")]
        Email,
        [Description("Факс")]
        Fax,
        [Description("Звичайна пошта")]
        Mail
    }

    /// <summary>
    /// а) ДК 001:2004 – Класифікація форм власності; 
    /// б) ДК 002:2004 – Класифікація організаційно-правових форм господарювання.
    /// </summary>
    public enum OwnershipFormType
    {
        [Description("Не вказано")]
        None = 0,
        [Description("Приватна")]
        Private = 1,
        [Description("Державна")]
        State,
        [Description("Комунальна (муніципальна)")]
        Municipal
    }

    /// <summary>
    /// Нормальний
    /// Виключено з Держ.реєстру
    /// Режим ліквідації
    /// Тимчасовоо призупинено
    /// Реорганізація
    /// </summary>
    public enum BankBranchStatusType
    {
        [Description("Не вказано")]
        None = 0,
        [Description("Нормальний")]
        Operational,
        [Description("Виключено з Держ.реєстру")]
        Deleted,
        [Description("Режим ліквідації")]
        InLiquidation,
        [Description("Тимчасовоо призупинено")]
        Paused,
        [Description("Реорганізація")]
        InReorganization
    }

    public enum BankBranchChangeType
    { 
        [Description("Не вказано")]
        None = 0,
        [Description("відкриття")]
        Opening,
        [Description("зміни реквізитів")]
        Change,
        [Description("призупинення діяльності")]
        Pause,
        [Description("відновлення діяльності")]
        Resume,
        [Description("припинення діяльності")]
        Closure
    }

    public enum BankBranchType
    { 
        [Description("Не вказано")]
        None = 0,
        [Description("філія")]
        Filia,
        [Description("відділення")]
        Viddilennia,
        [Description("дирекція")]
        Dyrektsia,
        [Description("регіональне управління")]
        RegUpr,
        [Description("представництво")]
        RepOffice,
        [Description("інше")]
        Other
    }

    public enum ResidenceType
    {
        [Description("Не вказано")]
        None = 0,
        [Description("Резиденти")]
        Resident,
        [Description("Нерезиденти")]
        NonResident
    }


    public enum CurrencyType
    {
        [Description("Не вказано")]
        None = 0,
        [Description("Національна валюта")]
        NationalCurrency,
        [Description("Іноземна валюта")]
        ForeignCurrency,
        [Description("Банківські метали")]
        BankingMetals
    }

    public enum BankClientType
    {
        [Description("Не вказано")]
        None = 0,
        [Description("Юридичні особи")]
        LegalPersons,
        [Description("Фізичні особи")]
        PhysicalPersons,
        [Description("СПД")]
        IndividualEntrepreneurs
    }

    public enum OtherBankOpsSvcDimension
    { 
        None = 0,
        //Клієнти свого банку
        OwnClients,
        //Клієнти інших банків
        OtherBanksClients
    }
    public enum BankOperationLimitType
    {
        [Description("Не вказано")]
        None = 0,
        [Description("Ліміт на одиничну операцію")]
        SingleOperation,
        [Description("Ліміт на сумарний оборот за...")]
        TotalTurnover,
        [Description("Ліміт залишку")]
        TotalBalance
    }

    public enum WorkingHoursDayType
    {
        [Description("Не вказано")]
        None = 0,
        [Description("Будній день")]
        WorkWeekDay,
        [Description("Вихідний")]
        WeekEndDay,
        [Description("Святковий день")]
        Holiday,
        [Description("Усі дні")]
        AnyDay,
        [Description("Конкретний день тижня")]
        ParticularDay
    }

    public enum BankBranchManagerPositionType
    { 
        [Description("Не вказано")]
        None = 0,
        [Description("Керуючий філією")]
        BranchManager,
        [Description("Керуючий відділенням")]
        OutletManager,
        [Description("Інший керівник підрозділу (вказати додатково)")]
        OtherManager
    }

}

