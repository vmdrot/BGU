using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using BGU.DRPL.SignificantOwnership.Core.Spares;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;
using Evolvex.Utility.Core.Geo;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;
using BGU.DRPL.SignificantOwnership.Core.EKDRBU.Spares;
using Evolvex.Utility.Core.ComponentModelEx;
using System.Xml.Serialization;

namespace BGU.DRPL.SignificantOwnership.Core.EKDRBU
{
    public class StateBankRegistryEntry : NotifyPropertyChangedBase
    {
        public StateBankRegistryEntry()
        {
            OpenDate = DateTime.Now;
            RegisteredDate = DateTime.Now;
            PayDocDate = DateTime.Now;
            InputDate = DateTime.Now;
        }

        private string _ParentID;
        [Category("Ієрархія")]
        [DisplayName("Батьківський підрозділ")]
        [Description("Батьківський підрозділ")]
        public string ParentID { get { return _ParentID; } set { _ParentID = value; OnPropertyChanged("ParentID"); } }

        private string _NameFull;
        [Category("Назви")]
        [DisplayName("Назва (254 символів)")]
        [Description("Назва (254 символів)")]
        public string NameFull { get { return _NameFull; } set { _NameFull = value; OnPropertyChanged("NameFull"); } }

        private string _NameShort;
        [Category("Назви")]
        [DisplayName("Скорочена назва (80 символів)")]
        [Description("Скорочена назва (80 символів)")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "150", MaxWidth = "250")]
        public string NameShort { get { return _NameShort; } set { _NameShort = value; OnPropertyChanged("NameShort"); } }
        
        private string _NamePrint;
        [Category("Назви")]
        [DisplayName("Назва для друку (40 символів)")]
        [Description("Назва для друку (40 символів)")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "150", MaxWidth = "200")]
        public string NamePrint { get { return _NamePrint; } set { _NamePrint = value; OnPropertyChanged("NamePrint"); } }
        
        private string _NameSEP;
        [Category("Назви")]
        [DisplayName("Назва для СЕП (38 символів)")]
        [Description("Назва для СЕП (38 символів)")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "150", MaxWidth = "200")]
        public string NameSEP { get { return _NameSEP; } set { _NameSEP = value; OnPropertyChanged("NameSEP"); } }
        
        private string _NameStats;
        [Category("Назви")]
        [DisplayName("Назва для СТАТЗВІТНОСТІ (27 символів)")]
        [Description("Назва для СТАТЗВІТНОСТІ (27 символів)")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "125", MaxWidth = "150")]
        public string NameStats { get { return _NameStats; } set { _NameStats = value; OnPropertyChanged("NameStats"); } }
        
        private string _MFO;
        [Category("Номери")]
        [DisplayName("МФО")]
        [Description("МФО")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "75", MaxWidth = "100")]
        public string MFO { get { return _MFO; } set { _MFO = value; OnPropertyChanged("MFO"); } }
        
        private string _YeDRPOU;
        [Category("Номери")]
        [DisplayName("ЄДРПОУ")]
        [Description("ЄДРПОУ")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "75", MaxWidth = "100")]
        public string YeDRPOU { get { return _YeDRPOU; } set { _YeDRPOU = value; OnPropertyChanged("YeDRPOU"); } }
        
        private string _RegNr;
        [Category("Номери")]
        [DisplayName("реєстраційний номер")]
        [Description("реєстраційний номер")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "65", MaxWidth = "85")]
        public string RegNr { get { return _RegNr; } set { _RegNr = value; OnPropertyChanged("RegNr"); } }
        
        private string _InternalNr;
        [Category("Номери")]
        [DisplayName("внутрішньобанківський номер")]
        [Description("внутрішньобанківський номер")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "65", MaxWidth = "85")]
        public string InternalNr { get { return _InternalNr; } set { _InternalNr = value; OnPropertyChanged("InternalNr"); } }
        
        private string _BranchNrInternal;
        [Category("Номери")]
        [DisplayName("номер підрозділу за внутрішньобанківським номером")]
        [Description("номер підрозділу за внутрішньобанківським номером")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "65", MaxWidth = "85")]
        public string BranchNrInternal { get { return _BranchNrInternal; } set { _BranchNrInternal = value; OnPropertyChanged("BranchNrInternal"); } }
        
        private DateTime _OpenDate;
        [Category("Номери")]
        [DisplayName("дата відкриття")]
        [Description("дата відкриття")]
        public DateTime OpenDate { get { return _OpenDate; } set { _OpenDate = value; OnPropertyChanged("OpenDate"); } }
        
        private DateTime _RegisteredDate;
        [Category("Номери")]
        [DisplayName("дата внесення до Державного реєстру банків")]
        [Description("дата внесення до Державного реєстру банків")]
        public DateTime RegisteredDate { get { return _RegisteredDate; } set { _RegisteredDate = value; OnPropertyChanged("RegisteredDate"); } }
        
        //private string _Oblast;
        //[Category("Адреса")]
        //[DisplayName("область або код області")]
        //[Description("область або код області")]
        //[UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "150", MaxWidth = "250")]
        //public string Oblast { get { return _Oblast; } set { _Oblast = value; OnPropertyChanged("Oblast"); } }
        
        //private string _Raion;
        //[Category("Адреса")]
        //[DisplayName("назва району")]
        //[Description("назва району")]
        //[UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "150", MaxWidth = "250")]
        //public string Raion { get { return _Raion; } set { _Raion = value; OnPropertyChanged("Raion"); } }
        
        //private string _Town;
        //[Category("Адреса")]
        //[DisplayName("тип та назва населеного пункту")]
        //[Description("тип та назва населеного пункту")]
        //[UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "150", MaxWidth = "250")]
        //public string Town { get { return _Town; } set { _Town = value; OnPropertyChanged("Town"); } }
        
        private LocationInfo _Address;
        [Category("Адреса")]
        [DisplayName("адреса")]
        [Description("адреса")]
        public LocationInfo Address { get { return _Address; } set { _Address = value; OnPropertyChanged("Address"); } }
        
        //private string _ZipCode;
        //[Category("Адреса")]
        //[DisplayName("поштовий індекс")]
        //[Description("поштовий індекс")]
        //[UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "75", MaxWidth = "85")]
        //public string ZipCode { get { return _ZipCode; } set { _ZipCode = value; OnPropertyChanged("ZipCode"); } }
        
        private BasicGeoposition _GeoPosition;
        [Category("Адреса")]
        [DisplayName("Геокоординати (для відділень поза нас. пунктами)")]
        [Description("Геокоординати (для відділень поза нас. пунктами)")]
        public BasicGeoposition GeoPosition { get { return _GeoPosition; } set { _GeoPosition = value; OnPropertyChanged("GeoPosition"); } }

        private List<WorkHoursInfo> _WorkHours;
        [Category("Діяльність")]
        [DisplayName("Графік роботи")]
        [Description("Графік роботи")]
        [UIUsageDataGridParams(IsOneColumn = true, OneDataColumnHeader = "Графік роботи підрозділу")]
        public List<WorkHoursInfo> WorkHours { get { return _WorkHours; } set { _WorkHours = value; OnPropertyChanged("WorkHours"); } }
        
        private string _DialCode;
        [Category("Контактні дані")]
        [DisplayName("код телефонного зв’язку")]
        [Description("код телефонного зв’язку")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "50", MaxWidth = "75")]
        public string DialCode { get { return _DialCode; } set { _DialCode = value; OnPropertyChanged("DialCode"); } }
        
        private string _Phone;
        [Category("Контактні дані")]
        [DisplayName("телефон(-и)")]
        [Description("телефон(-и)")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "75", MaxWidth = "150")]
        public string Phone { get { return _Phone; } set { _Phone = value; OnPropertyChanged("Phone"); } }
        
        private string _Fax;
        [Category("Контактні дані")]
        [DisplayName("факс(-и)")]
        [Description("факс(-и)")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "75", MaxWidth = "150")]
        public string Fax { get { return _Fax; } set { _Fax = value; OnPropertyChanged("Fax"); } }
        
        private string _Email;
        [Category("Контактні дані")]
        [DisplayName("e-mail(-и)")]
        [Description("e-mail(-и)")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "100", MaxWidth = "250")]
        public string Email { get { return _Email; } set { _Email = value; OnPropertyChanged("Email"); } }
        
        private string _www;
        [Category("Контактні дані")]
        [DisplayName("веб-сайт")]
        [Description("веб-сайт")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "150", MaxWidth = "250")]
        public string www { get { return _www; } set { _www = value; OnPropertyChanged("www"); } }

        private BankBranchManagerPositionType _MgrPosition;
        [Category("Керівники/персонал")]
        [DisplayName("посада")]
        [Description("посада")]
        //[UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "200", MaxWidth = "250")]
        public BankBranchManagerPositionType MgrPosition { get { return _MgrPosition; } set { _MgrPosition = value; OnPropertyChanged("MgrPosition"); OnPropertyChanged("IsManagerPositionOther"); } }

        [Browsable(false)]
        [XmlIgnore]
        public bool IsManagerPositionOther { get { return MgrPosition == BankBranchManagerPositionType.OtherManager; } }

        private string _MgrPositionOther;
        [Category("Керівники/персонал")]
        [DisplayName("Посада (інша)")]
        [Description("Назва посади, якщо 'інше'")]
        [UIConditionalVisibility("IsManagerPositionOther")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "200", MaxWidth = "300")]
        public string MgrPositionOther { get { return _MgrPositionOther; } set { _MgrPositionOther = value; OnPropertyChanged("MgrPositionOther"); } }


        private PhysicalPersonInfo _manager;
        [Category("Керівники/персонал")]
        [DisplayName("Керівник")]
        [Description("Дані про керівника")]
        public PhysicalPersonInfo Manager { get { return _manager; } set { _manager = value; OnPropertyChanged("Manager"); } }

        private List<EducationRecordInfo> _MgrEducation;
        [Category("Керівники/персонал")]
        [DisplayName("Освіта")]
        [Description("Дані про освіту керівника")]
        [UIUsageDataGridParams(IsOneColumn = true, OneDataColumnHeader = "Освіта керівника")]
        public List<EducationRecordInfo> MgrEducation { get { return _MgrEducation; } set { _MgrEducation = value; OnPropertyChanged("MgrEducation"); } }
        
        private List<EmploymentRecordInfo> _MgrWorkExperience;
        [Category("Керівники/персонал")]
        [DisplayName("Досвід роботи")]
        [Description("Дані про досвід роботи керівника")]
        [UIUsageDataGridParams(IsOneColumn = true, OneDataColumnHeader = "Досвід роботи керівника")]
        public List<EmploymentRecordInfo> MgrWorkExperience { get { return _MgrWorkExperience; } set { _MgrWorkExperience = value; OnPropertyChanged("MgrWorkExperience"); } }
        
        private PersonBusinessReputationInfo _MgrBusinessReputation;
        [Category("Керівники/персонал")]
        [DisplayName("Репутація")]
        [Description("Ділова репутація керівника")]
        public PersonBusinessReputationInfo MgrBusinessReputation { get { return _MgrBusinessReputation; } set { _MgrBusinessReputation = value; OnPropertyChanged("MgrBusinessReputation"); } }
        
        private string _PayDocNr;
        [Category("Оплата")]
        [DisplayName("номер платіжного документа")]
        [Description("номер платіжного документа")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MaxWidth = "75", MinWidth = "100")]
        public string PayDocNr { get { return _PayDocNr; } set { _PayDocNr = value; OnPropertyChanged("PayDocNr"); } }
        
        private DateTime _PayDocDate;
        [Category("Оплата")]
        [DisplayName("дата здійснення оплати")]
        [Description("дата здійснення оплати")]
        public DateTime PayDocDate { get { return _PayDocDate; } set { _PayDocDate = value; OnPropertyChanged("PayDocDate"); } }
        
        private DateTime _InputDate;
        [Category("Службові")]
        [DisplayName("дата внесення")]
        [Description("дата внесення")]
        public DateTime InputDate { get { return _InputDate; } set { _InputDate = value; OnPropertyChanged("InputDate"); } }
        
        private string _ShortChangesLog;
        [Category("Інше")]
        [DisplayName("короткий опис змін")]
        [Description("короткий опис змін")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = true)]
        public string ShortChangesLog { get { return _ShortChangesLog; } set { _ShortChangesLog = value; OnPropertyChanged("ShortChangesLog"); } }
        
        private BankBranchStatusType _Status;
        [Category("Статус")]
        [DisplayName("Стан")]
        [Description("Стан")]
        public BankBranchStatusType Status { get { return _Status; } set { _Status = value; OnPropertyChanged("Status"); } }
        
        private DateTime? _ClosedDate;
        [Category("Службові")]
        [DisplayName("Дата закриття")]
        [Description("Дата закриття")]
        public DateTime? ClosedDate { get { return _ClosedDate; } set { _ClosedDate = value; OnPropertyChanged("ClosedDate"); } }
        
        private DateTime? _UnregisteredDate;
        [Category("Службові")]
        [DisplayName("Дата виключення з Державного реєстру банків")]
        [Description("Дата виключення з Державного реєстру банків")]
        public DateTime? UnregisteredDate { get { return _UnregisteredDate; } set { _UnregisteredDate = value; OnPropertyChanged("UnregisteredDate"); } }
        
        private List<BankBranchOperationInfo> _OperationsListing;
        [Category("Діяльність")]
        [DisplayName("Перелік операцій")]
        [Description("Перелік операцій")]
        [UIUsageDataGridParams(IsOneColumn = true, OneDataColumnHeader = "Перелік операцій")]
        public List<BankBranchOperationInfo> OperationsListing { get { return _OperationsListing; } set { _OperationsListing = value; OnPropertyChanged("OperationsListing"); } }
        
        private List<AttachmentInfo> _Attachement_Resolution;
        [Category("Додатки")]
        [DisplayName("Рішення, на підставі якого вносяться зміни")]
        [Description("Рішення, на підставі якого вносяться зміни")]
        [UIUsageDataGridParams(IsOneColumn = true, OneDataColumnHeader = "Додатки")]
        public List<AttachmentInfo> Attachement_Resolution { get { return _Attachement_Resolution; } set { _Attachement_Resolution = value; OnPropertyChanged("Attachement_Resolution"); } }
    }
}
