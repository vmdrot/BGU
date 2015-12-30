using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;
using System.Xml.Serialization;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Структура для зберігання відомостей про досвід роботи
    /// (один "епізод" з трудової біографії)
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.EmploymentRecordInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class EmploymentRecordInfo : NotifyPropertyChangedBase
    {

        public EmploymentRecordInfo()
        {
            State = EmploymentState.Employed;
        }

        private EmploymentState _State;
        /// <summary>
        /// обов'язкове поле
        /// </summary>
        [DisplayName("Тип зайнятості")]
        [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.EnumLookupEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Required]
        [UIUsageRadioButtonGroup(GroupOrientation=Orientation.Horizontal, ShowNoneItem=false)]
        public EmploymentState State { get { return _State; } set { _State = value; OnPropertyChanged("State"); OnPropertyChanged("IsEmployee"); OnPropertyChanged("IsSelfEmployedOrFreelance"); OnPropertyChanged("IsUnemployed"); OnPropertyChanged("IsBusy"); OnPropertyChanged("IsEmployeeSelfEmployedOrFreelance"); } }

        private bool _IsEmploymentBookRegistered;
        /// <summary>
        /// обов'язкове поле
        /// </summary>
        [DisplayName("Є в трудовій книзі")]
        [Description("Чи відображено запис у трудовій книзі?")]
        [Required]
        public bool IsEmploymentBookRegistered { get { return _IsEmploymentBookRegistered; } set { _IsEmploymentBookRegistered = value; OnPropertyChanged("IsEmploymentBookRegistered"); } }

        [Browsable(false)]
        [XmlIgnore]
        public bool IsEmployee { get { return State == EmploymentState.Employed; } }

        [Browsable(false)]
        [XmlIgnore]
        public bool IsSelfEmployedOrFreelance { get { return State == EmploymentState.SelfemployedFreelance ; } }

        [Browsable(false)]
        [XmlIgnore]
        public bool IsEmployeeSelfEmployedOrFreelance { get { return State == EmploymentState.Employed || State == EmploymentState.SelfemployedFreelance; } }

        [Browsable(false)]
        [XmlIgnore]
        public bool IsUnemployed { get { return State == EmploymentState.Unemployed; } }

        [Browsable(false)]
        [XmlIgnore]
        public bool IsBusy { get { return State != EmploymentState.Unemployed; } }

        private EmploymentTimeType _FullOrPartTime;
        /// <summary>
        /// Повна (основна) чи часткова (за сумісництвом) зайнятість
        /// </summary>
        /// 
        [DisplayName("Вид зайнятості")]
        [Description("Зайнятість повна/сумісництво")]
        [Required]
        public EmploymentTimeType FullOrPartTime { get { return _FullOrPartTime; } set { _FullOrPartTime = value; OnPropertyChanged("FullOrPartTime"); } }


        private GenericPersonID _Employer;
        /// <summary>
        /// Обов'язкове поле
        /// Посилання - реквізити в MentionedEntities
        /// </summary>
        [DisplayName("Роботодавець/основний замовник")]
        [Description("Роботодавець (для найманих працівників)\n чи основний замовник (для самозайнятих/фрілансерів)")]
        [Required("State == Employed")]
        [UIConditionalVisibility("IsEmployeeSelfEmployedOrFreelance")]
        public GenericPersonID Employer { get { return _Employer; } set { _Employer = value; OnPropertyChanged("Employer"); } }

        private EconomicActivityType _PrincipalFreelanceActivity;
        /// <summary>
        /// Заповнюється через випадаючий список КВЕД-ів.
        /// </summary>
        [DisplayName("Основний вид діяльності")]
        [Description("Основний вид діяльності - для самозайнятих/фрілансерів")]
        [Required("State == Freelance OR State == Selfemployed")]
        [UIConditionalVisibility("IsSelfEmployedOrFreelance")]
        [UIUsageComboAddButton(AddNewItemCommand = "local:MyCommands.AddEconomicActivityTypeCommand", ContainerOrientation = Orientation.Vertical, DisplayMember = "DispName", ItemsGetterClass = (typeof(EconomicActivityType)), ItemsGetterMemberPath = "AllKVEDs", ValueMemberUsageMode = ComboUIValueUsageMode.SelectedItem, Width = "350")]
        public EconomicActivityType PrincipalFreelanceActivity { get { return _PrincipalFreelanceActivity; } set { _PrincipalFreelanceActivity = value; OnPropertyChanged("PrincipalFreelanceActivity"); } }


        private string _JobTitle;
        /// <summary>
        /// обов'язкове, вільний формат
        /// </summary>
        [DisplayName("Посада/функція")]
        [Required]
        [UIConditionalVisibility("IsEmployee")]
        public string JobTitle { get { return _JobTitle; } set { _JobTitle = value; OnPropertyChanged("JobTitle"); } }

        private ISCO _ISCOJobSpec;
        /// <summary>
        /// Код професії, у ролі якого працівник був зайнятий,
        /// згідно Міжнародного стандарту класифікації професій
        /// та його української (ДК 003:2010) / іншої локальної адаптації
        /// (якщо відомий/передбачено для даної посади)
        /// </summary>
        [DisplayName("Код та назва професії за МОП")]
        [Description("Код та назва професії за класифікатором Міжнародної організації праці / ДК 003:2010")]
        public ISCO ISCOJobSpec { get { return _ISCOJobSpec; } set { _ISCOJobSpec = value; OnPropertyChanged("ISCOJobSpec"); } }

        private string _JobDutiesDescription;
        [DisplayName("Службові обов'язки")]
        [Description("Опис службових обов'язків за займаною посадою")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = true, MinWidth = "450", MaxWidth = "650")]
        public string JobDutiesDescription { get { return _JobDutiesDescription; } set { _JobDutiesDescription = value; OnPropertyChanged("JobDutiesDescription"); } }


        private bool _IsSupervisedIndustryExperience;
        /// <summary>
        /// Чи є дана робота досвідом роботи у регульованій галузі?
        /// </summary>
        [DisplayName("Банківський досвід")]
        [Description("Чи враховується описуване місце роботи у загальний банкіський стаж")]
        public bool IsSupervisedIndustryExperience { get { return _IsSupervisedIndustryExperience; } set { _IsSupervisedIndustryExperience = value; OnPropertyChanged("IsSupervisedIndustryExperience"); } }

        private bool _IsManagingPosition;
        /// <summary>
        /// Чи є це керівною посадою?
        /// </summary>
        [DisplayName("Керівна посада")]
        [Description("Чи враховується описуване місце роботи у загальний стаж роботи на керівних посадах")]
        public bool IsManagingPosition { get { return _IsManagingPosition; } set { _IsManagingPosition = value; OnPropertyChanged("IsManagingPosition"); } }

        private DateTime _DateStarted;
        /// <summary>
        /// обов'язкове, для резидентів - з точністю до дня, 
        /// для нерезидентів - з точністю до місяця (за змовчанням - 1 число)
        /// </summary>
        [DisplayName("Дата початку роботи")]
        [Description("Дата початку роботи чи переходу в нинішній статус (фрілансер, безробітний, тощо)")]
        [Required]
        public DateTime DateStarted { get { return _DateStarted; } set { _DateStarted = value; OnPropertyChanged("DateStarted"); } }

        private bool _IsStillWorkingThere;
        [DisplayName("Статус місця роботи: чинне чи ні")]
        [Description("Відзначити, якщо це - чинне місце роботи на дату заповнення анкети (чи й досі тут працює?)")]
        [Required]
        public bool IsStillWorkingThere { get { return _IsStillWorkingThere; } set { _IsStillWorkingThere = value; OnPropertyChanged("IsStillWorkingThere"); OnPropertyChanged("IsAlreadyFinished"); } }

        [Browsable(false)]
        [XmlIgnore]
        public bool IsAlreadyFinished { get { return !IsStillWorkingThere; } }

        private DateTime? _DateQuit;
        /// <summary>
        /// , для резидентів - з точністю до дня, 
        /// для нерезидентів - з точністю до місяця (за змовчанням - 1 число)
        /// якщо не заповнене, значить він/вона/воно там ще досі працює
        /// </summary>
        [DisplayName("Дата кінця роботи")]
        [UIConditionalVisibility("IsAlreadyFinished")]
        public DateTime? DateQuit { get { return _DateQuit; } set { _DateQuit = value; OnPropertyChanged("DateQuit"); } }

        private EmploymentTerminationType _TerminationType;
        /// <summary>
        /// обов'язкове поле (хіба ще досі там працює)
        /// </summary>
        [DisplayName("Тип закінчення діяльності")]
        [Required]
        [UIConditionalVisibility("IsAlreadyFinished")]
        public EmploymentTerminationType TerminationType { get { return _TerminationType; } set { _TerminationType = value; OnPropertyChanged("TerminationType"); OnPropertyChanged("IsQuitDismissedOrOtherLeave"); } }

        [Browsable(false)]
        [XmlIgnore]
        public bool IsQuitDismissedOrOtherLeave { get { return TerminationType == EmploymentTerminationType.Dismissed || TerminationType == EmploymentTerminationType.OtherLeaveType || TerminationType == EmploymentTerminationType.VoluntaryQuit; } }

        private string _DismissalOrUnemployedReason;
        /// <summary>
        /// Пояснення обов'язкове для TerminationType типів:
        /// - Dismissed
        /// - OtherLeaveType
        /// - VoluntaryQuit
        /// </summary>
        [DisplayName("Причина звільнення")]
        [Description("причина звільнення; якщо трудовий стаж переривався, то слід зазначити причину")]
        [Multiline]
        [UIConditionalVisibility("IsQuitDismissedOrOtherLeave")]
        public string DismissalOrUnemployedReason { get { return _DismissalOrUnemployedReason; } set { _DismissalOrUnemployedReason = value; OnPropertyChanged("DismissalOrUnemployedReason"); } }

        private string _KZPPArticle;
        /// <summary>
        /// Формальна стаття і пункт звільнення
        /// згідно з КЗпП
        /// </summary>
        [DisplayName("Стаття, пункт звільнення")]
        [Description("Стаття і пункт Кодексу законів про працю, за якою було припинено трудові стосунки")]
        [UIConditionalVisibility("IsQuitDismissedOrOtherLeave")]
        public string KZPPArticlePt { get { return _KZPPArticle; } set { _KZPPArticle = value; OnPropertyChanged("KZPPArticle"); } }

        private ContactInfo _EmployerOrContractorContact;
        /// <summary>
        /// тел, e-mail, якщо є - www;
        /// якщо вказується особа, то вона сприймається як рекомендувач; чим повніше цю особу ідентифіковано, тим краще для подавача
        /// Якщо той же самий роботодавець уже фігурує у вже заповнених раніше записах, вказувати не потрібно;
        /// Якщо роботодавець той же, але рекомендувач - інший, заповнюємо контакти рекомендувача 
        /// (наприклад, при зміні посади, підрозділу / 
        /// проекту в рамках тієї ж організації-роботодавця)
        /// </summary>
        [DisplayName("Контакти роботодавця / замовника")]
        [Description("Для найманих працівників - контакти роботодавця, для фрілансерів і самозайнятих - основного замовника")]
        [Required]
        [UIConditionalVisibility("IsBusy")]
        public ContactInfo EmployerOrContractorContact { get { return _EmployerOrContractorContact; } set { _EmployerOrContractorContact = value; OnPropertyChanged("EmployerOrContractorContact"); } }
    }
}
