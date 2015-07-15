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
        public EmploymentState State { get { return _State; } set { _State = value; OnPropertyChanged("State"); OnPropertyChanged("IsEmployee"); OnPropertyChanged("IsSelfEmployedOrFreelance"); OnPropertyChanged("IsUnemployed"); OnPropertyChanged("IsBusy"); } }


        [Browsable(false)]
        [XmlIgnore]
        public bool IsEmployee { get { return State == EmploymentState.Employed; } }

        [Browsable(false)]
        [XmlIgnore]
        public bool IsSelfEmployedOrFreelance { get { return State == EmploymentState.Freelance || State == EmploymentState.Selfemployed; } }

        [Browsable(false)]
        [XmlIgnore]
        public bool IsUnemployed { get { return State == EmploymentState.Unemployed; } }

        [Browsable(false)]
        [XmlIgnore]
        public bool IsBusy { get { return State != EmploymentState.Unemployed; } }
      

        private GenericPersonID _Employer;
        /// <summary>
        /// Обов'язкове поле
        /// Посилання - реквізити в MentionedEntities
        /// </summary>
        [DisplayName("Роботодавець")]
        [Required("State == Employed")]
        [UIConditionalVisibility("IsEmployee")]
        public GenericPersonID Employer { get { return _Employer; } set { _Employer = value; OnPropertyChanged("Employer"); } }

        private GenericPersonID _PrincipalContractor;
        [DisplayName("Основний замовник")]
        [Description("Основний замовник - для самозайнятих/фрілансерів")]
        [Required("State == Freelance OR State == Selfemployed")]
        [UIConditionalVisibility("IsSelfEmployedOrFreelance")]
        public GenericPersonID PrincipalContractor { get { return _PrincipalContractor; } set { _PrincipalContractor = value; OnPropertyChanged("PrincipalContractor"); } }

        private EconomicActivityType _PrincipalFreelanceActivity;
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


        private DateTime _DateStarted;
        /// <summary>
        /// обов'язкове, з точністю до місяця
        /// </summary>
        [DisplayName("Дата початку роботи")]
        [Description("Дата початку роботи чи переходу в нинішній статус (фрілансер, безробітний, тощо)")]
        [Required]
        public DateTime DateStarted { get { return _DateStarted; } set { _DateStarted = value; OnPropertyChanged("DateStarted"); } }

        private bool _IsStillWorkingThere;

        [DisplayName("чинне місце роботи/статус")]
        [Description("(відзначити, якщо це - чинне місце роботи на дату заповнення анкети)")]
        [Required]
        public bool IsStillWorkingThere { get { return _IsStillWorkingThere; } set { _IsStillWorkingThere = value; OnPropertyChanged("IsStillWorkingThere"); OnPropertyChanged("IsAlreadyFinished"); } }

        [Browsable(false)]
        [XmlIgnore]
        public bool IsAlreadyFinished { get { return !IsStillWorkingThere; } }


        private DateTime? _DateQuit;
        /// <summary>
        /// з точністю до місяця
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

        private ContactInfo _EmployerOrContractorContact;
        /// <summary>
        /// тел, e-mail, якщо є - www;
        /// якщо вказується особа, то вона сприймається як рекомендувач; чим повніше цю особу ідентифіковано, тим краще для подавача
        /// </summary>
        [DisplayName("Контакти роботодавця / замовника")]
        [Description("Для найманих працівників - контакти роботодавця, для фрілансерів і самозайнятих - основного замовника")]
        [Required]
        [UIConditionalVisibility("IsBusy")]
        public ContactInfo EmployerOrContractorContact { get { return _EmployerOrContractorContact; } set { _EmployerOrContractorContact = value; OnPropertyChanged("EmployerOrContractorContact"); } }
    }
}
