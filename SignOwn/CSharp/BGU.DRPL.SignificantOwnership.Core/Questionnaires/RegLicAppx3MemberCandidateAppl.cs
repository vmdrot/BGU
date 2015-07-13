﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;

namespace BGU.DRPL.SignificantOwnership.Core.Questionnaires
{
    /// <summary>
    /// АНКЕТА членів виконавчого органу та наглядової (спостережної) ради юридичної особи
    /// Додаток 3 до Положення про порядок реєстрації та ліцензування банків, відкриття відокремлених підрозділів
    /// file                                  : f364524n1223.doc
    /// Рівень складності                     : 9
    /// (оціночний, шкала від 1 до 10)
    /// Пріоритетність                        : Hi  (Легенда: Hi - Висока, Lo - Низька, Mid - Середня, Hold - Поки що притримати)
    /// Подавач анкети                        : LP (Легенда: LP - юр.особа, PP - фіз.особа, BK - банк)
    /// Чи заповнюватиметься он-лайн          : Так
    /// Первинну розробку структури завершено : Ні
    /// Структуру фіналізовано                : Ні
    /// (=остаточно узгоджено 
    /// з бізнес-користувачами)
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.RegLicAppx3MemberCandidateAppl_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class RegLicAppx3MemberCandidateAppl : QuestionnaireBase, IGenericPersonsService, IAddressesService
    {
        #region cctor(s)
        public RegLicAppx3MemberCandidateAppl()
        { 
            
        }
        #endregion

        #region Original fields
        /// <summary>
        /// Стосовно участі в ___________________________________________________________________
        /// (повне офіційне найменування банку)
        /// ___________________________________________________________________________________
        /// (найменування юридичної особи)
        /// </summary>
        [DisplayName("Повне офіційне найменування банку")]
        [Description("Ідентифікація банку, в якому подавач планує набути членство у відповідному органі управління")]
        [Browsable(true)]
        [Required]
        public BankInfo BankRef { get; set; }
        
        /// <summary>
        /// 1. Інформація про особу
        /// 1.1. _______________________________________________________________________________.
        ///         (прізвище, ім'я, по батькові, посада в юридичній особі)
        /// 1.2. Паспортні дані _________________________________________________________________.
        ///   (серія, номер, дата видачі, ким виданий)
        /// 1.3. Громадянство __________________________________________________________________.
        /// (країна, дата прийняття громадянства, якщо воно змінювалося)
        /// 1.4. Адреса постійного місця проживання ______________________________________________.
        /// 1.5. Реєстраційний номер облікової картки платника податків або серія та номер паспорта (для фізичних осіб, які через свої релігійні переконання відмовляються від прийняття реєстраційного
        /// номера облікової картки платника податків та повідомили про це відповідний контролюючий орган і мають відмітку у  паспорті) __________________________________________________________________________________.
        /// </summary>
        [DisplayName("Кандидат")]
        [Description("Реквізити фізособи-кандидата на посаду...")]
        [Browsable(true)]
        [Required]
        public GenericPersonID Candidate { get; set; }
        
        /// <summary>
        /// 1.6. Займані посади за останні п'ять років _______________________________________________
        /// ___________________________________________________________________________________
        /// (найменування юридичної особи, найменування посади;  період перебування на посаді з _____ до _____;
        /// __________________________________________________________________________________.
        /// причина звільнення; якщо трудовий стаж переривався, то слід зазначити причину)
        /// </summary>
        [DisplayName("1.6. Займані посади за останні п'ять років")]
        [Description("Займані посади за останні п'ять років: найменування юридичної особи, найменування посади;  період перебування на посаді з _ до _, причина звільнення; якщо трудовий стаж переривався, то слід зазначити причину.")]
        [Browsable(true)]
        [Required]
        public List<EmploymentRecordInfo> Last5YrsWorkExperience { get; set; }

        /// <summary>
        /// 1.7. Останнє місце роботи, номер телефону роботодавця _________________________________.
        /// </summary>
        [DisplayName("Місце роботи")]
        [Description("9. Місце роботи і посада на дату заповнення анкети ")]
        [Browsable(true)]
        [Required]
        public EmploymentRecordInfo LastEmploymentRecord { get; set; }

        /// <summary>
        /// 1.8. Освіта та професійна кваліфікація _________________________________________________
        ///                                        (науковий ступінь,
        /// __________________________________________________________________________________.
        /// професійна ліцензія, номер, дата видачі диплома, ким виданий, спеціальність і кваліфікація)
        /// </summary>
        [DisplayName("1.8. Освіта та професійна кваліфікація")]
        [Description("1.8. Освіта та професійна кваліфікація - науковий ступінь, номер, дата видачі диплома, ким виданий, спеціальність і кваліфікація")]
        [Browsable(true)]
        [Required]
        public List<EducationRecordInfo> Education { get; set; }

        /// <summary>
        /// Покриває п.1.8 (у частині проф.ліцензій)
        /// </summary>
        [DisplayName("1.8. Чи має заявник професійну(-і) ліцензію(-ї)?")]
        [Description("п.1.8 (у частині проф.ліцензій)")]
        [Browsable(true)]
        [Required]
        public bool HasProfessionalLicenses { get; set; }

        /// <summary>
        /// Поле обов'язкове лише якщо є професійні ліцензії ( HasProfessionalLicenses == true )
        /// Покриває п.1.8 (у частині проф.ліцензій)
        /// </summary>
        [DisplayName("1.8. Професійна(-і) ліцензія(-ї)")]
        [Description("п.1.8 (у частині проф.ліцензій)")]
        [Browsable(true)]
        public List<ProfessionLicenseInfo> ProfessionalLicenses {get;set;}

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("1.9. Чи маєте намір набувати істотну участь?")]
        [Description("Чи очікується, що заявник (напряму, чи через пов'язаних осіб) стане власником істотної участі в банку?")]
        [Browsable(true)]
        [Required]
        public bool IsAppyingForSignificantOwnership {get;set;}
        /// <summary>
        /// 1.9. Розмір участі в юридичній особі, яка має намір набути або збільшити істотну участь у банку-емітенті,*
        /// ___________________________________________________________________.
        /// 
        /// * Заповнюється власниками істотної участі в банку або особами, які мають намір набути істотну участь у банку.
        /// ----
        /// Вимагати, якщо IsAppyingForSignificantOwnership == true
        /// </summary>
        [DisplayName("1.9. Розмір участі в юридичній особі, яка має намір набути або збільшити істотну участь у банку-емітенті")]
        [Description("Заповнюється власниками істотної участі в банку або особами, які мають намір набути істотну участь у банку")]
        [Browsable(true)]
        public List<OwnershipStructure> OwnershipStakeWithLPAcquiree { get; set; }

        /// <summary>
        /// 1.10. Розмір отриманих  доходів за останній звітний період (рік)*  
        /// __________________________________________________________________________________.
        /// 
        /// * Заповнюється власниками істотної участі в банку або особами, які мають намір набути істотну участь у банку.
        /// -------------
        /// Обов'язкове, якщо IsAppyingForSignificantOwnership == true
        /// </summary>
        [DisplayName("1.10. Розмір отриманих  доходів за останній звітний період (рік)")]
        [Description("Заповнюється власниками істотної участі в банку або особами, які мають намір набути істотну участь у банку")]
        [Browsable(true)]
        public CurrencyAmount LastYearIncome {get;set;}


        /// <summary>
        /// 2. Відносини власності з банком-емітентом
        /// 2.1. Чи є Ви учасником банку-емітента? _______________________________________________:
        /// (так, ні)
        /// </summary>
        [DisplayName("2.1. Чи є Ви учасником банку-емітента?")]
        [Description("Чи є Ви учасником банку-емітента, прямо чи опосередковано (у т.ч. через пов'язаних осіб).")]
        [Browsable(true)]
        public bool IsIssuerBankStakeholder { get; set; }

        /// <summary>
        /// 2. Відносини власності з банком-емітентом
        /// а) пряме володіння - ____ відсотків статутного капіталу банку, що  становить ________________ 
        ///                                                                                (кількість)
        /// акцій (паїв),  загальною номінальною вартістю ______________ гривень;
        /// ------
        /// Обов'язкове, якщо IsIssuerBankStakeholder == true
        /// </summary>
        [DisplayName("2.1. а) Пряме володіння у банку-емітенті")]
        [Description("Частка прямого володіння у банкові-емітенті")]
        [Browsable(true)]
        public SharesAcquisitionInfo DirectOwnershipWithBankSummary { get; set; }

        /// <summary>
        /// 2. Відносини власності з банком-емітентом
        /// б) опосередковане володіння - ______ відсотків 
        /// ------
        /// Обов'язкове, якщо IsIssuerBankStakeholder == true
        /// </summary>
        [DisplayName("2.1. б) Опосередковане володіння у банку-емітенті")]
        [Description("Частка опосередкованого володіння у банкові-емітенті")]
        [Browsable(true)]
        public SharesAcquisitionInfo ImplicitOwnershipWithBankSummary { get; set; }

        /// <summary>
        /// через _______________________
        /// __________________________________________________________________________________.
        /// (найменування учасника банку та розмір його прямого володіння в банку)
        /// ------
        /// Обов'язкове і непуста колекція, якщо ImplicitOwnershipWithBankSummary > 0%
        /// </summary>
        [DisplayName("2.1. б) Опосередковане володіння у банку-емітенті - деталі")]
        [Description("Розшифровка опосередкованого володіння у банкові-емітенті")]
        [Browsable(true)]
        public List<OwnershipStructure> ImplicitOwnershipWithBank { get; set; }

        /// <summary>
        /// 2.2. Чи маєте Ви (як фізична особа) намір збільшити частку в статутному капіталі банку-емітента? 
        /// _________________________________________________________________________.
        /// </summary>
        [DisplayName("2.2. Маєте намір збільшити частку в капіталі банку?")]
        [Description("2.2. Чи маєте Ви (як фізична особа) намір збільшити частку в статутному капіталі банку-емітента?")]
        [Browsable(true)]
        public bool HasIntentToIncreaseEquityShareAsPhysPerson { get; set; }

        /// <summary>
        /// 2.3. Чи є Ви пов'язаною з банком-емітентом особою? ____________________________________
        /// __________________________________________________________________________________.
        ///                                                 зазначається відповідно до статті 52 Закону України "Про банки і банківську діяльність")
        /// ---------------
        /// Якщо "так", то треба розкрити природу зв'язку в полі PersonsLinks
        /// </summary>
        [DisplayName("2.3. Чи є Ви пов'язаною з банком-емітентом особою?")]
        [Description("2.3. Чи є Ви пов'язаною з банком-емітентом особою? (так/ні), якщо \"так\" - то треба розкрити природу зв'язку в полі PersonsLinks")]
        [Browsable(true)]
        public bool IsAssociatedPersonWithBank { get; set; }

        /// 3. Інші питання

        
        /// <summary>
        /// 3.1. Чи притягувалися Ви до кримінальної відповідальності? ______________________________
        /// </summary>
        [DisplayName("3.1. Чи притягувалися Ви до кримінальної відповідальності?")]
        [Description("(так або ні)")]
        [Browsable(true)]
        [Required]
        public bool WasCriminallyProsecuted { get; set; }

        /// <summary>
        /// 3.2. Чи маєте Ви судимість не погашену,  не зняту в установленому законодавством порядку? 
        /// </summary>
        [DisplayName("3.2. Чи маєте Ви судимість не погашену,  не зняту в установленому законодавством порядку?")]
        [Description("(так або ні)")]
        [Browsable(true)]
        [Required]
        public bool HasOutstandingSentencesToServe { get; set; }

        /// <summary>
        /// 3.3. Чи притягувалися Ви до відповідальності за порушення антимонопольного, податкового, 
        /// банківського, валютного законодавства, правил діяльності на ринку цінних паперів тощо? _____
        /// </summary>
        [DisplayName("3.3. Чи була відповідальніть за порушення галузевого/господарського законодавства?")]
        [Description("3.3. Чи притягувалися Ви до відповідальності за порушення антимонопольного, податкового, банківського, валютного законодавства, правил діяльності на ринку цінних паперів тощо?")]
        [Browsable(true)]
        [Required]
        public bool HadIndustrySpecificBreaches { get; set; }
        
        /// <summary>
        /// Розшифровка пп.3.1, 3.2. і 3.3.
        /// ___________________________________________________________________________________
        /// __________________________________________________________________________________.
        /// (якщо так, то зазначити детальну інформацію)
        /// __________________________________________________________________________________.
        /// (коли вчинено порушення, зміст порушення, які накладені санкції)
        /// -------
        /// Поле обов'язкове й непусте, якщо: 
        ///   HadIndustrySpecificBreaches == true 
        ///   АБО HasOutstandingSentencesToServe == true 
        ///   АБО WasCriminallyProsecuted == true
        /// </summary>
        [DisplayName("п.3.1, 3.2. і 3.3. Розшифрока правопорушень/судимостей")]
        [Description("Якщо були порушення законодавства, судимості (у т.ч. непогашені), галузеві правопорушення, тощо (зазначені у пп.3.1, 3.2. і 3.3.), то зазначити детальну інформацію, коли вчинено порушення, зміст порушення, які накладені санкції")]
        [Browsable(true)]
        public List<BreachOfLawRecordInfo> BreachesOfLaw { get; set; }


        /// <summary>
        /// 3.4. Чи маєте Ви невиконані майнові (фінансові) зобов'язання  перед іншими особами? 
        /// </summary>
        [DisplayName("3.4. Чи маєте невиконані майнові зобов'язання  перед іншими?")]
        [Description("3.4. Чи маєте Ви невиконані майнові (фінансові) зобов'язання  перед іншими особами?")]
        [Browsable(true)]
        [Required]
        public bool HasMiscNonRepaidDebts { get; set; }

        /// <summary>
        /// 3.4. 
        /// ___________________________________________________________________________________
        /// (якщо так, то зазначити, які саме зобов'язання,
        /// ___________________________________________________________________________________
        ///  у якому розмірі, перед якою особою та з яких причин не були виконані,
        /// __________________________________________________________________________________.
        ///  а також подальші плани щодо виконання/невиконання цих зобов'язань)
        ///  ------------
        ///  Обов'язкове й непусте, якщо HasMiscNonRepaidDebts == true
        /// </summary>
        [DisplayName("3.4. Невиконані зобов'язання  перед іншими особами - розшифровка")]
        [Description("якщо так, то зазначити, які саме зобов'язання, у якому розмірі, перед якою особою та з яких причин не були виконані, а також подальші плани щодо виконання/невиконання цих зобов'язань.")]
        [Browsable(true)]
        [Required]
        public List<IndebtnessInfo> MiscNonRepaidDebts { get; set; }



        /// <summary>
        /// Зв'язки між особами-фігурантами анкети
        /// ----
        /// Колекція має бути непустою, як мінімум, якщо:
        /// IsAssociatedPersonWithBank == true
        /// АБО ImplicitOwnershipWithBankSummary > сума вирахуваної через непряме особисте володіння банком на особу-заявника
        /// АБО якщо серед фігурантів анкети є особи з прізвищем заявника.
        /// </summary>
        [DisplayName("Зв'язки між особами-фігурантами анкети")]
        [Description("Природа зв'язків між усіма пов'язанами особами, що згадуються в анкеті")]
        [Browsable(true)]
        [Required]
        public List<PersonsAssociation> PersonsLinks { get; set; }

        /// <summary>
        /// Реквізити усіх осіб-фігурантів
        /// </summary>
        public List<GenericPersonInfo> MentionedIdentities { get; set; }

        /// <summary>
        /// 3.5. Стверджую, що я належним чином виконую вимоги законодавства України з питань 
        /// запобігання та протидії легалізації (відмиванню) доходів, одержаних злочинним шляхом, 
        /// або фінансуванню тероризму.
        /// </summary>
        [DisplayName("")]
        [Description("")]
        [Browsable(true)]
        public bool IsAMLLegislationKept { get; set; }

        /// <summary>
        /// Я, ________________________________________________________________________________,
        ///      (прізвище, ім'я, по батькові)
        /// стверджую, що інформація, надана в анкеті, є правдивою і повною, та не заперечую проти перевірки 
        /// Національним банком України достовірності поданих документів і персональних даних, що в них містяться.
        /// </summary>
        [DisplayName("Підтверджую правдивість інформації?")]
        [Description("Я, (прізвище, ім'я, по батькові) стверджую, що інформація,  надана в анкеті,\n є правдивою і повною, та не заперечую проти перевірки Національним банком України достовірності поданих документів і персональних даних, що в них містяться.\n")]
        [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.BooleanEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Required]
        public bool IsApplicationInfoAccurateAndTrue { get; set; }


        /// У разі будь-яких змін в інформації, що зазначена в цій анкеті, зобов'язуюся повідомити про них Національний банк України протягом 10-ти днів з дня їх виникнення.
        [DisplayName("Зобов'язуюсь повідомляти про зміни?")]
        [Description("У разі будь-яких змін в інформації, що зазначена в цій анкеті, зобов'язуюся повідомити про них Національний банк України протягом 10-ти днів з дня їх виникнення.")]
        [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.BooleanEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Required]
        public bool AmObligingToKeepUp2DateWithin10Days { get; set; }


        /// <summary>
        /// _______________________
        /// (дата підписання анкети)
        /// _____________________
        /// (підпис фізичної особи,
        /// засвідчений нотаріально)	
        /// _______________________
        /// (ініціали та прізвище
        ///    фізичної особи
        ///  друкованими літерами)
        /// </summary>
        [DisplayName("Підписант")]
        [Description("Відомості по особу, що підписала анкету")]
        [Required]
        public SignatoryInfo Signatory { get; set; }
        #endregion



        //public string SuggestSaveAsFileName()
        //{
        //    return "";
        //}

        public IEnumerable<GenericPersonInfo> MentionedGenericPersons
        {
            get { return MentionedIdentities; }
        }

        public IEnumerable<LocationInfo> MentionedAddresses
        {
            get { return new List<LocationInfo>(); /* todo */ }
        }

        protected override string QuestionnairePrefixForFileName
        {
            get { return "regLicDod3KandUChl"; }
        }

        protected override string BankNameForFileName
        {
            get { return GetBankNameForFileName(BankRef); }
        }

        protected override string ApplicantNameForFileName
        {
            get { if (this.Candidate == null) return string.Empty; return Candidate.PersonCode; }
        }


        public void RefreshGenericPersonsDisplayNames()
        {
            base.RefreshGenericPersonsDisplayNamesWorker(this.MentionedIdentities, new List<OwnershipStructure>[] { this.OwnershipStakeWithLPAcquiree, this.ImplicitOwnershipWithBank });
        }
    }
}
