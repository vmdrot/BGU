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

namespace BGU.DRPL.SignificantOwnership.Core.EKDRBU
{
    public class StateBankRegistryEntry : NotifyPropertyChangedBase
    {
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
        public string NameShort { get { return _NameShort; } set { _NameShort = value; OnPropertyChanged("NameShort"); } }
        
        private string _NamePrint;
        [Category("Назви")]
        [DisplayName("Назва для друку (40 символів)")]
        [Description("Назва для друку (40 символів)")]
        public string NamePrint { get { return _NamePrint; } set { _NamePrint = value; OnPropertyChanged("NamePrint"); } }
        
        private string _NameSEP;
        [Category("Назви")]
        [DisplayName("Назва для СЕП (38 символів)")]
        [Description("Назва для СЕП (38 символів)")]
        public string NameSEP { get { return _NameSEP; } set { _NameSEP = value; OnPropertyChanged("NameSEP"); } }
        
        private string _NameStats;
        [Category("Назви")]
        [DisplayName("Назва для СТАТЗВІТНОСТІ (27 символів)")]
        [Description("Назва для СТАТЗВІТНОСТІ (27 символів)")]
        public string NameStats { get { return _NameStats; } set { _NameStats = value; OnPropertyChanged("NameStats"); } }
        
        private string _MFO;
        [Category("Номери")]
        [DisplayName("МФО")]
        [Description("МФО")]
        public string MFO { get { return _MFO; } set { _MFO = value; OnPropertyChanged("MFO"); } }
        
        private string _YeDRPOU;
        [Category("Номери")]
        [DisplayName("ЄДРПОУ")]
        [Description("ЄДРПОУ")]
        public string YeDRPOU { get { return _YeDRPOU; } set { _YeDRPOU = value; OnPropertyChanged("YeDRPOU"); } }
        
        private string _RegNr;
        [Category("Номери")]
        [DisplayName("реєстраційний номер")]
        [Description("реєстраційний номер")]
        public string RegNr { get { return _RegNr; } set { _RegNr = value; OnPropertyChanged("RegNr"); } }
        
        private string _InternalNr;
        [Category("Номери")]
        [DisplayName("внутрішньобанківський номер")]
        [Description("внутрішньобанківський номер")]
        public string InternalNr { get { return _InternalNr; } set { _InternalNr = value; OnPropertyChanged("InternalNr"); } }
        
        private string _BranchNrInternal;
        [Category("Номери")]
        [DisplayName("номер підрозділу за внутрішньобанківським номером")]
        [Description("номер підрозділу за внутрішньобанківським номером")]
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
        
        private string _Oblast;
        [Category("Адреса")]
        [DisplayName("область або код області")]
        [Description("область або код області")]
        public string Oblast { get { return _Oblast; } set { _Oblast = value; OnPropertyChanged("Oblast"); } }
        
        private string _Raion;
        [Category("Адреса")]
        [DisplayName("назва району")]
        [Description("назва району")]
        public string Raion { get { return _Raion; } set { _Raion = value; OnPropertyChanged("Raion"); } }
        
        private string _Town;
        [Category("Адреса")]
        [DisplayName("тип та назва населеного пункту")]
        [Description("тип та назва населеного пункту")]
        public string Town { get { return _Town; } set { _Town = value; OnPropertyChanged("Town"); } }
        
        private LocationInfo _Address;
        [Category("Адреса")]
        [DisplayName("адреса")]
        [Description("адреса")]
        public LocationInfo Address { get { return _Address; } set { _Address = value; OnPropertyChanged("Address"); } }
        
        private string _ZipCode;
        [Category("Адреса")]
        [DisplayName("поштовий індекс")]
        [Description("поштовий індекс")]
        public string ZipCode { get { return _ZipCode; } set { _ZipCode = value; OnPropertyChanged("ZipCode"); } }
        
        private BasicGeoposition _GeoPosition;
        [Category("Адреса")]
        [DisplayName("Геокоординати (для відділень поза нас. пунктами)")]
        [Description("Геокоординати (для відділень поза нас. пунктами)")]
        public BasicGeoposition GeoPosition { get { return _GeoPosition; } set { _GeoPosition = value; OnPropertyChanged("GeoPosition"); } }

        private List<WorkHoursInfo> _WorkHours;
        [Category("Діяльність")]
        [DisplayName("Графік роботи")]
        [Description("Графік роботи")]
        public List<WorkHoursInfo> WorkHours { get { return _WorkHours; } set { _WorkHours = value; OnPropertyChanged("WorkHours"); } }
        
        private string _DialCode;
        [Category("Контактні дані")]
        [DisplayName("код телефонного зв’язку")]
        [Description("код телефонного зв’язку")]
        public string DialCode { get { return _DialCode; } set { _DialCode = value; OnPropertyChanged("DialCode"); } }
        
        private string _Phone;
        [Category("Контактні дані")]
        [DisplayName("телефон(-и)")]
        [Description("телефон(-и)")]
        public string Phone { get { return _Phone; } set { _Phone = value; OnPropertyChanged("Phone"); } }
        
        private string _Fax;
        [Category("Контактні дані")]
        [DisplayName("факс(-и)")]
        [Description("факс(-и)")]
        public string Fax { get { return _Fax; } set { _Fax = value; OnPropertyChanged("Fax"); } }
        
        private string _Email;
        [Category("Контактні дані")]
        [DisplayName("e-mail(-и)")]
        [Description("e-mail(-и)")]
        public string Email { get { return _Email; } set { _Email = value; OnPropertyChanged("Email"); } }
        
        private string _www;
        [Category("Контактні дані")]
        [DisplayName("веб-сайт")]
        [Description("веб-сайт")]
        public string www { get { return _www; } set { _www = value; OnPropertyChanged("www"); } }
        
        private string _MgrPosition;
        [Category("Керівники/персонал")]
        [DisplayName("посада")]
        [Description("посада")]
        public string MgrPosition { get { return _MgrPosition; } set { _MgrPosition = value; OnPropertyChanged("MgrPosition"); } }
        
        private string _MgrSurname;
        [Category("Керівники/персонал")]
        [DisplayName("прізвище")]
        [Description("прізвище")]
        public string MgrSurname { get { return _MgrSurname; } set { _MgrSurname = value; OnPropertyChanged("MgrSurname"); } }
        
        private string _MgrName;
        [Category("Керівники/персонал")]
        [DisplayName("ім’я")]
        [Description("ім’я")]
        public string MgrName { get { return _MgrName; } set { _MgrName = value; OnPropertyChanged("MgrName"); } }
        
        private string _MgrPatronymic;
        [Category("Керівники/персонал")]
        [DisplayName("по-батькові")]
        [Description("по-батькові")]
        public string MgrPatronymic { get { return _MgrPatronymic; } set { _MgrPatronymic = value; OnPropertyChanged("MgrPatronymic"); } }
        
        private string _MgrPassID;
        [Category("Керівники/персонал")]
        [DisplayName("Серія № паспорта")]
        [Description("Серія № паспорта")]
        public string MgrPassID { get { return _MgrPassID; } set { _MgrPassID = value; OnPropertyChanged("MgrPassID"); } }
        
        private string _MgrTaxID;
        [Category("Керівники/персонал")]
        [DisplayName("ІПН")]
        [Description("ІПН")]
        public string MgrTaxID { get { return _MgrTaxID; } set { _MgrTaxID = value; OnPropertyChanged("MgrTaxID"); } }
        
        private string _PayDocNr;
        [Category("Оплата")]
        [DisplayName("номер платіжного документа")]
        [Description("номер платіжного документа")]
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
        public List<BankBranchOperationInfo> OperationsListing { get { return _OperationsListing; } set { _OperationsListing = value; OnPropertyChanged("OperationsListing"); } }
        
        private List<AttachmentInfo> _Attachement_Resolution;
        [Category("Додатки")]
        [DisplayName("Рішення, на підставі якого вносяться зміни")]
        [Description("Рішення, на підставі якого вносяться зміни")]
        public List<AttachmentInfo> Attachement_Resolution { get { return _Attachement_Resolution; } set { _Attachement_Resolution = value; OnPropertyChanged("Attachement_Resolution"); } }
    }
}
