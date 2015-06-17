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
    public class RegLicAppx2OwnershipAcqRequestLP : IQuestionnaire
    {

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

        /// <summary>
        /// стосовно участі в ___________________________________
        /// (повне офіційне найменування банку)
        /// </summary>
        [DisplayName("Повне офіційне найменування банку")]
        [Description("стосовно участі в ...")]
        [Required]
        public BankInfo BankRef { get; set; }

        #region І. Інформація про юридичну особу

        /// <summary>
        /// І. Інформація про юридичну особу
        /// 
        /// 1. Повне та скорочене найменування ________________________________________________________________
        /// 2. Ідентифікаційні дані:
        /// ---- 
        /// Самі реквізити мають потрапити до MentionedIdentities
        /// </summary>
        [Category("І. Інформація про юридичну особу")]
        [DisplayName("Юр.особа-заявник")]
        [Description("1. Інформація про юридичну особу")]
        [Required]
        public GenericPersonID Acquiree { get; set; }

        /// <summary>
        /// 1.5. Рейтингова оцінка ____________________________________________________________.
        /// (за рейтингом, який підтверджений у бюлетені, однієї  з провідних рейтингових компаній IBCA,
        ///  Standart & Poor's, Moody's)
        /// </summary>
        [Category("І. Інформація про юридичну особу")]
        [DisplayName("2. Ідентифікаційні дані::Рейтингова оцінка")]
        [Description("(за рейтингом, який підтверджений у бюлетені, однієї  з провідних рейтингових компаній IBCA,Standart & Poor's, Moody's)")]
        [Required]
        public List<CreditRatingInfo> CreditRatingGrade { get; set; }

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
        [Browsable(true)]
        [DisplayName("3. (4-5) Державний(-і) наглядовий(-і) орган(-и)")]
        [Description("3. Відомості про державну реєстрацію юридичної особи та відносини з контролюючими державними органами")]
        public List<FinancialOversightAuthorityInfo> StateRegulatorAuthorities { get; set; }


        /// <summary>
        /// 3. Відомості про державну реєстрацію юридичної особи та відносини з контролюючими державними органами
        /// _______________________________________________________________________________.
        ///            (найменування органу)
        /// </summary>
        
        [Browsable(true)]
        [DisplayName("5. Наявна участь юридичної особи в банку")]
        [Description("5. Інформація про розмір наявної участі юридичної особи в банку")]
        public TotalOwnershipSummaryInfo TotalExistingOwnershipWithBank { get; set; }

        /// <summary>
        /// Поле обов'язкове, лише якщо заявник не є банком.
        /// </summary>
        [Category("І. Інформація про юридичну особу")]
        [DisplayName("4. Банківські рахунки юридичної особи")]
        [Description("(не заповнюється банками)")]
        public List<BankInfo> AccountsWithBanks { get; set; }

        #endregion


        #region ІІ. Інформація про наміри щодо набуття (збільшення) істотної участі в банку

        /// <summary>
        /// 7. Набуття/збільшення істотної участі в банку відбуватиметься у спосіб (зазначити необхідне):
        /// 
        /// придбання акцій (паїв) банку на первинному ринку;
        /// придбання акцій (паїв) банку на вторинному ринку;
        /// набуття/збільшення істотної участі в банку опосередковано шляхом придбання корпоративних прав юридичних осіб у структурі власності банку;
        /// набуття/збільшення істотної участі в банку у зв’язку з передаванням права голосу за довіреністю;
        /// набуття опосередкованої істотної участі в банку у зв’язку із здійсненням значного або вирішального впливу на управління та діяльність банку незалежно від формального володіння. 
        /// </summary>
        [Category("ІІ. Інформація про наміри щодо набуття (збільшення) істотної участі в банку")]
        [DisplayName("7. Спосіб(-оби) набуття/збільшення істотної участі в банку")]
        [Description("7. Набуття/збільшення істотної участі в банку відбуватиметься у спосіб (зазначити необхідне)")]
        [Required]
        public SignificantOwnershipAcquisitionWaysInfo AcquisitionWays { get; set; }

        [Category("ІІ. Інформація про наміри щодо набуття (збільшення) істотної участі в банку")]
        [DisplayName("Придбання на первинному ринку")]
        [Description("8. Інформація про намір щодо придбання акцій (паїв) банку на первинному ринку:")]
        [Required("AcquisitionWays.IsIPO == true")]
        public List<IPOSharesPurchaseInfo> IPOPurchase { get; set; }



        [Category("ІІ. Інформація про наміри щодо набуття (збільшення) істотної участі в банку")]
        [DisplayName("9. Придбання на вторинному ринку")]
        [Description("9. Інформація про намір щодо придбання акцій (паїв) банку на вторинному ринку та/або стосовно правочинів щодо набуття (збільшення) опосередкованої участі в банку (крім набуття істотної участі в результаті передавання особі права голосу або незалежно від формального володіння)")]
        [Required("AcquisitionWays.IsSecondaryMarketPurchase == true || AcquisitionWays.IsPurchaseByImplicitOwnership == true")]
        public List<SecondaryMarketSharesPurchaseInfo> SecondaryMarketPurchases { get; set; }


        [Category("ІІ. Інформація про наміри щодо набуття (збільшення) істотної участі в банку")]
        [DisplayName("10. Набуття за довіреністю")]
        [Description("10. Інформація про намір щодо набуття опосередкованої істотної участі в банку за довіреністю")]
        [Required("AcquisitionWays.IsPurchaseByPowOfAtt == true")]
        public List<PowerOfAttorneySharesPurchaseInfo> AquisitionByPoAttorneys { get; set; }

        [Category("ІІ. Інформація про наміри щодо набуття (збільшення) істотної участі в банку")]
        [DisplayName("11. Набуття у зв’язку із здійсненням впливу")]
        [Description("11. Інформація про набуття опосередкованої істотної участі в банку у зв’язку із здійсненням значного або вирішального впливу на управління та діяльність банку незалежно від формального володіння")]
        [Required("AcquisitionWays.IsAcquireByImplicitInfluence == true")]
        public List<SignificantOrDecisiveInfulenceInfo> AquisitionByInfluence { get; set; }

        /// <summary>
        /// 12. Джерела походження коштів юридичної особи, за рахунок яких набуватиметься істотна участь у банку,
        /// _______________________________________________________________________________________________________.
        /// (прибуток, частина статутного капіталу, кошти фонду тощо)
        /// </summary>
        [Category("ІІ. Інформація про наміри щодо набуття (збільшення) істотної участі в банку")]
        [DisplayName("12. Джерела  походження коштів юридичної особи")]
        [Description("12. Джерела походження коштів юридичної особи, за рахунок яких набуватиметься істотна участь у банку")]
        [Required]
        public List<IncomeOriginInfo> FundsOrigin { get; set; }
        #endregion

        #region ІІІ. Відносини юридичної особи з іншими особами

        /// <summary>
        /// 13. Перелік юридичних осіб, у тому числі банків, в яких юридична особа має істотну участь або є ключовим учасником
        /// 14. Інформація про фізичних осіб, які володіють істотною участю в цій юридичній особі або є ключовими учасниками юридичної особи
        /// 15. Інформація про юридичних осіб, які володіють істотною участю в цій юридичній особі або є ключовими учасниками юридичної особи
        /// ----
        /// Доцільно розшифровку ланцюжків власності усіх структур, що фігурують в анкеті, скласти в це одне поле, оскільки не виключено, що власники-юр.особи повторюватимуться/фігуруватимуть в різних іпостасях в усіх 3-х пунктах (себто, і 13, і 14, і 15) 
        /// </summary>
        [Category("ІІІ. Відносини юридичної особи з іншими особами")]
        [DisplayName("13, 14, 15. Розшифровка ланцюжків власності")]
        [Description("Розшифровка ланцюжків власності усіх структур-фігурантів анкети:\n 13. Перелік юридичних осіб, у тому числі банків, в яких юридична особа має істотну участь або є ключовим учасником\n 14. Інформація про фізичних осіб, які володіють істотною участю в цій юридичній особі або є ключовими учасниками юридичної особи\n 15. Інформація про юридичних осіб, які володіють істотною участю в цій юридичній особі або є ключовими учасниками юридичної особи")]
        public List<OwnershipStructure> ExistingOwnershipDetailsHive { get; set; }
        #endregion

        #region IV. Ділова репутація
        /// <summary>
        /// 16. Інформація про кредити, одержані юридичною особою:
        /// </summary>
        [Category("IV. Ділова репутація")]
        [DisplayName("16. Чи є кредити, одержані й непогашені юридичною  особою  в  банках?")]
        [Description("(Станом на дату подання анкети)")]
        [Required]
        public bool HasOutstandingLoansWithBanks { get; set; }

        /// <summary>
        /// 16. Інформація про кредити, одержані юридичною особою:
        /// </summary>
        [Category("IV. Ділова репутація")]
        [DisplayName("16. Інформація про кредити, одержані юридичною особою")]
        [Description("(номер і дата договору про надання кредиту, сума кредиту, термін погашення кредиту, сума заборгованості за договором на дату подання анкети)")]
        [Required("HasOutstandingLoansWithBanks == true")]
        public List<LoanInfo> OutstandingLoansWithBanksDetails { get; set; }

        /// <summary>
        /// 17. Чи є щодо юридичної особи ознаки відсутності бездоганної ділової репутації, визначені нормативно-правовим
        /// актом Національного банку України про порядок реєстрації та ліцензування банків [якщо таких ознак немає, то
        /// зазначається “Стверджую, що немає ознак відсутності бездоганної ділової репутації стосовно _______ (зазначається
        /// повне найменування юридичної особи)”; якщо такі ознаки є, то здійснюється опис ознаки (ознак) відсутності
        /// бездоганної ділової репутації].
        /// </summary>
        [Category("IV. Ділова репутація")]
        [DisplayName("17. Стверджую, що немає ознак відсутності бездоганної ділової репутації")]
        [Description("Стверджую, що немає ознак відсутності бездоганної ділової репутації стосовно _______ (зазначається повне найменування юридичної особи")]
        [Required]
        public bool HasNoImperfectReputationSigns { get; set; }

        /// <summary>
        /// 17. Якщо щодо юридичної особи є ознаки відсутності бездоганної ділової репутації, визначені нормативно-правовим
        /// актом Національного банку України про порядок реєстрації та ліцензування банків, то здійснюється опис ознаки (ознак) відсутності
        /// бездоганної ділової репутації].
        /// </summary>
        [Category("IV. Ділова репутація")]
        [DisplayName("17. Ознаки відсутності бездоганної ділової репутації")]
        [Description("Опис наявних ознак відсутності бездоганної ділової репутації")]
        [Required("HasNoImperfectReputationSigns == false")]
        public ImperfectBusinessReputationInfo ImprefectReputationDetails { get; set; }


        /// <summary>
        /// 18. Стверджую, що юридична особа _______ (зазначається повне найменування юридичної особи) належним чином
        /// виконує вимоги законодавства України або законодавства країни свого громадянства з питань запобігання та протидії
        /// легалізації (відмиванню) доходів, одержаних злочинним шляхом, та фінансування тероризму.
        /// </summary>
        [Category("IV. Ділова репутація")]
        [DisplayName("18. Вимоги законодавства дотримано")]
        [Description("18. Стверджую, що юридична особа _______ (зазначається повне найменування юридичної особи) належним чином виконує вимоги законодавства України або законодавства країни свого громадянства з питань запобігання та протидії легалізації (відмиванню) доходів, одержаних злочинним шляхом, та фінансування тероризму.")]
        [Browsable(true)]
        public bool IsAMLEtcLegislationKept { get; set; }

        #endregion

        #region Trailing prop(s)
        /// <summary>
        /// Стверджую, що інформація, зазначена в анкеті, є правдивою і повною, та не заперечую проти перевірки
        /// Національним банком України її достовірності та повноти.
        /// </summary>
        [Category("Підписи і т.п.")]
        [DisplayName("Підтверджую правдивість інформації?")]
        [Description("Стверджую, що інформація, зазначена в анкеті, є правдивою і повною, та не заперечую проти перевірки Національним банком України її достовірності та повноти.")]
        [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.BooleanEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Required]
        public bool IsApplicationInfoAccurateAndTrue { get; set; }

        
        /// <summary>
        /// Примітка. Якщо немає змоги надати інформацію за відповідними пунктами анкети, то слід зазначити причину.
        /// </summary>
        [Category("Підписи і т.п.")]
        [DisplayName("Примітка. Якщо немає змоги надати інформацію за відповідними пунктами анкети, то слід зазначити причину.")]
        [Description("...")]
        [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.BooleanEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Required]
        public List<MissingInformationResonInfo> MissingInformationResons { get; set; }

        /// <summary>
        /// ____________________       __________________________    _______________________________
        ///  (дата підписання анкети) (підпис уповноваженої особи    (прізвище та ініціали уповноваженої особи
        ///                              юридичної особи)             юридичної особи, її посада в юридичній особі
        ///                                                           або реквізити довіреності представника за
        ///                                                           довіреністю)
        /// </summary>
        [Category("Підписи і т.п.")]
        [DisplayName("Підписант")]
        [Description("Відомості по особу, що підписала анкету")]
        [Required]
        public SignatoryInfo Signatory { get; set; }

        /// <summary>
        /// Прізвище, ім'я, по батькові контактної особи ___________________.
        /// 
        /// Номер телефону та факсу ________________________________________.
        /// </summary>
        [Category("Підписи і т.п.")]
        [DisplayName("Контакти")]
        [Description("Контактні дані відправника анкети")]
        [Required]
        public ContactInfo ContactPerson { get; set; }
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
        [Category("ІІІ. Відносини юридичної особи з іншими особами")]
        [DisplayName("Зв'язки між фігурантами анкети")]
        [Description("Опис зв'язків між фізичними та юридичними особами, що згадуються в розділах анкети")]
        [Required]
        public List<PersonsAssociation> PersonsLinks { get; set; }
        #endregion

        #region inherited member(s)

        public string SuggestSaveAsFileName()
        {
            return "regLicDod2IstUchYO";
        }

        #endregion
    }
}
