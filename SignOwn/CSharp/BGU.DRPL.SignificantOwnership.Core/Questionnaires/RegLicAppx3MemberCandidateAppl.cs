using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;
using Evolvex.Utility.Core.Common;

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
        private static readonly ILog log = Logging.GetLogger(typeof(RegLicAppx3MemberCandidateAppl));

        private const string CATEGORY_I = "I. Перелік членів виконавчого органу та наглядової ради юридичної особи";
        private const string CATEGORY_II = "II. Загальна інформація про осіб";
        private const string CATEGORY_III = "III. Відомості про трудову діяльність";
        private const string CATEGORY_IV = "IV. Відносини особи з банком та юридичною особою";
        private const string CATEGORY_V = "V. Відомості про ділову репутацію";
        private const string CATEGORY_SignEtc = "Підписи і т.п.";

        #region cctor(s)
        public RegLicAppx3MemberCandidateAppl()
        { 
            
        }
        #endregion

        [DisplayName("Юр.особа-заявник")]
        [Description("(повне найменування юридичної особи)")]
        [Required]
        public GenericPersonID Acquiree {get;set;}
        
        /// <summary>
        /// Стосовно участі в ___________________________________________________________________
        /// (повне офіційне найменування банку)
        /// ___________________________________________________________________________________
        /// (найменування юридичної особи)
        /// </summary>
        [DisplayName("Повне офіційне найменування банку")]
        [Description("Ідентифікація банку, в якому подавачі планують набути членство у відповідному органі управління")]
        [Browsable(true)]
        [Required]
        public BankInfo BankRef { get; set; }


        #region I. Перелік членів виконавчого органу та наглядової ради юридичної особи
        [Category(CATEGORY_I)]
        [DisplayName("Наглядова (спостережна) рада юридичної особи існує")]
        [Description("Чи існує наглядова (спостережна) рада юридичної особи?")]
        public bool IsSupervisoryCouncilPresent { get; set; }

        [Category(CATEGORY_I)]
        [DisplayName("Особовий склад наглядової(спостережної)ради юрособи")]
        [Description("Голова та члени наглядової (спостережної) ради юридичної особи")]
        [UIConditionalVisibility("IsSupervisoryCouncilPresent")]
        public CouncilBodyInfo SupervisoryCouncil { get; set; }

        [Category(CATEGORY_I)]
        [DisplayName("Виконавчий орган юридичної особи існує")]
        [Description("Чи існує виконавчий орган юридичної особи?")]
        public bool IsExecutiveBodyPresent { get; set; }

        [Category(CATEGORY_I)]
        [DisplayName("Особовий склад виконавчого органу юрособи")]
        [Description("Голова та члени виконавчого органу юридичної особи")]
        [UIConditionalVisibility("IsExecutiveBodyPresent")]
        public CouncilBodyInfo ExecutiveBody { get; set; }
        #endregion

        #region II. Загальна інформація про осіб
        /// <summary>
        /// Реквізити усіх осіб-фігурантів
        /// </summary>
        [Category(CATEGORY_II)]
        [DisplayName("Реквізити усіх осіб-фігурантів")]
        [Description("Реквізити усіх осіб, що згадуються в анкеті")]
        [UIUsageDataGridParams(IsOneColumn=true, OneDataColumnHeader="Особи-фігуранти")]
        public List<GenericPersonInfo> MentionedIdentities { get; set; }
        #endregion

        #region III. Відомості про трудову діяльність
        [Category(CATEGORY_III)]
        [DisplayName("Займані посади за останні п’ять років")]
        [Description("Деталі трудової біографії погоджуваних членів наглядового та/або виконавчого органів, за останні 5 років.")]
        [UIUsageDataGridParams(IsOneColumn = true, OneDataColumnHeader = "Трудовий стаж осіб")]
        public List<PersonEmploymentRecordsInfo> BoardMembersEmploymentHistory5Yrs { get; set; }
        #endregion

        #region IV. Відносини особи з банком та юридичною особою
        
        [Category(CATEGORY_IV)]
        [DisplayName("Відомості про участь осіб в банку")]
        [Description("Деталізація існуючих відносин власності між особами, юр.особою та банком")]
        [Browsable(true)]
        [Required]
        [UIUsageDataGridParams(IsOneColumn = true, OneDataColumnHeader = "Розшифровка чинної власності осіб-фігурантів анкети")]
        public List<OwnershipStructure> ExistingOwnershipDetailsHive {get;set;}

        [Category(CATEGORY_IV)]
        [DisplayName("Відомості про намір осіб набути або збільшити участь у банку")]
        [Description("Власність, яку особи шукають здобути у банку")]
        [Browsable(true)]
        [Required]
        [UIUsageDataGridParams(IsOneColumn = true, OneDataColumnHeader = "Розшифровка жаданої власності у банку")]
        public List<OwnershipStructure> TargetedOwnershipDetailsHive { get; set; }

        /// <summary>
        /// Зв'язки між особами-фігурантами анкети
        /// ----
        /// </summary>
        [Category(CATEGORY_IV)]
        [DisplayName("Зв'язки між особами-фігурантами анкети")]
        [Description("Природа зв'язків між усіма пов'язанами особами, що згадуються в анкеті")]
        [Browsable(true)]
        [Required]
        [UIUsageDataGridParams(IsOneColumn = true, OneDataColumnHeader = "Зв'язки між особами")]
        public List<PersonsAssociation> PersonsLinks { get; set; }


        [Category(CATEGORY_IV)]
        [DisplayName("Відомості про пов’язаність осіб із банком")]
        [Description("Коди пов'язаності осіб")]
        [Browsable(true)]
        [Required]
        [UIUsageDataGridParams(IsOneColumn = true, OneDataColumnHeader = "Особа й код пов'язаності")]
        public List<PersonBankAssociationInfo> Person2BankAssociations { get; set; }
        #endregion

        #region V. Відомості про ділову репутацію

        [Category(CATEGORY_V)]
        [DisplayName("Ділова репутація кандидатів")]
        [Description("Ділова репутація кандидатів та дотримання законодавства")]
        [Browsable(true)]
        [Required]
        [UIUsageDataGridParams(IsOneColumn = true, OneDataColumnHeader = "Особа й репутація")]
        public List<PersonBusinessReputationInfo> CandidatesBusinessReputation { get; set; }
        #endregion

        #region Підписи і т.ін.

        /// <summary>
        /// Я, ________________________________________________________________________________,
        ///      (прізвище, ім'я, по батькові)
        /// стверджую, що інформація, надана в анкеті, є правдивою і повною, та не заперечую проти перевірки 
        /// Національним банком України достовірності поданих документів і персональних даних, що в них містяться.
        /// </summary>
        [Category(CATEGORY_SignEtc)]
        [DisplayName("Підтверджую правдивість інформації?")]
        [Description("стверджую, що інформація,  надана в анкеті,\n є правдивою і повною, та не заперечую проти перевірки Національним банком України достовірності поданих документів і персональних даних, що в них містяться.\n")]
        [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.BooleanEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Required]
        public bool IsApplicationInfoAccurateAndTrue { get; set; }

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
        [Category(CATEGORY_SignEtc)]
        [DisplayName("Підписант")]
        [Description("Відомості по особу, що підписала анкету")]
        [Required]
        public SignatoryInfo Signatory { get; set; }

        #endregion


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
            get { if (this.Acquiree == null) return string.Empty; return Acquiree.PersonCode; }
        }


        public void RefreshGenericPersonsDisplayNames()
        {
            base.RefreshGenericPersonsDisplayNamesWorker(this.MentionedIdentities, new List<OwnershipStructure>[] { this.ExistingOwnershipDetailsHive, this.TargetedOwnershipDetailsHive });
        }

        protected override void DoAddToMentionedEntities(GenericPersonInfo gpi)
        {
            MentionedIdentities.Add(gpi);
        }
    }
}
