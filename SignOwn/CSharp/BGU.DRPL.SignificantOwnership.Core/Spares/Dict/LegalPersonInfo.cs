using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;
using System.Xml.Serialization;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Dict
{
    /// <summary>
    /// Реквізити юридичної особи
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.LegalPersonInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class LegalPersonInfo : NotifyPropertyChangedBase
    {
        private const string CATEGORY_REG_INFO = "Реєстраційні дані";
        private const string CATEGORY_ADDRESSES = "Адреса(-и)";
        private const string CATEGORY_EXTRA_DATA = "Додаткова інформація";

        public LegalPersonInfo()
        {
            ResidenceCountry = CountryInfo.UKRAINE;
            this.PrincipalActivities = new List<EconomicActivityType>();
            this.OwnershipForm = OwnershipFormType.Private;
            this.IsStockExchangeListed = false;
        }

        private bool _IsIntFinOrg;
        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Міжнародна фінансова чи міжнародна організація")]
        [Description("Відзначити, якщо юридична особа є міжнародною організацією;\nміжнародна фінансова установа – установа, з якою Уряд України уклав угоду про співробітництво та для якої згідно із законами України встановлено привілеї та імунітети.")]
        public bool IsIntFinOrg 
        { 
            get { return _IsIntFinOrg; } 
            set 
            { 
                if(_IsIntFinOrg != value) 
                {
                    _IsIntFinOrg= value;  
                    if(_IsIntFinOrg) 
                        ResidenceCountry = CountryInfo.GLOBAL;
                    OnPropertyChanged("IsIntFinOrg"); OnPropertyChanged("IsNonResident"); OnPropertyChanged("ShowCountrySpecificControls"); 
                } 
            } 
        }

        [Browsable(false)]
        [XmlIgnore]
        public bool ShowCountrySpecificControls { get { return !IsIntFinOrg; } }

        private CountryInfo _ResidenceCountry;
        /// <summary>
        /// Країна резидентності
        /// Обов'язкове. За змовчанням (пропонувати) - Україна.
        /// </summary>
        [DisplayName("Країна юрисдикції")]
        [Description("Країна юрисдикції юридичної особи")]
        [Required]
        [UIConditionalVisibility("ShowCountrySpecificControls")]
        public CountryInfo ResidenceCountry { get { return _ResidenceCountry; } set { _ResidenceCountry = value; OnPropertyChanged("ResidenceCountry"); OnPropertyChanged("IsNonResident"); } }

        private string _Name;
        /// <summary>
        /// Обов'язкове поле.
        /// Назва оригінальною мовою.
        /// </summary>
        [DisplayName("Найменування")]
        [Description("Найменування юридичної особи (оригінальною мовою)")]
        [Required]
        public string Name { get { return _Name; } set { _Name = value; OnPropertyChanged("Name"); } }

        private string _NameUkr;
        /// <summary>
        /// Назва українською (якщо оригінальна - іншою мовою).
        /// </summary>
        [DisplayName("Найменування українською")]
        [Description("Найменування юридичної особи українською мовою (для нерезидентів)")]
        [UIConditionalVisibility("IsNonResident")]
        public string NameUkr { get { return _NameUkr; } set { _NameUkr = value; OnPropertyChanged("NameUkr"); } }

        private OwnershipFormType _OwnershipForm;
        [DisplayName("Форма власності")]
        [Description("Форма власності юридичної особи")]
        [Required]
        [UIUsageRadioButtonGroup(GroupOrientation=Orientation.Horizontal, ShowNoneItem=false)]
        [UIConditionalVisibility("ShowCountrySpecificControls")]
        public OwnershipFormType OwnershipForm { get { return _OwnershipForm; } set { _OwnershipForm = value; OnPropertyChanged("OwnershipForm"); } }

        [Browsable(false)]
        [XmlIgnore]
        public bool IsNonResident { get { return (ResidenceCountry != null && ResidenceCountry != CountryInfo.UKRAINE) || IsIntFinOrg; } }

        private string _TaxCodeOrHandelsRegNr;
        /// <summary>
        /// Обов'язкове поле (якщо контекстом проперті, де використовується цей тим, не визначено інакше)
        /// Для резидентів - ЄДРПОУ
        /// Для нерезидентів - еквівалентний ідентифікатор
        /// </summary>
        /// <seealso cref="http://irc.gov.ua/ua/Poshuk-v-YeDR.html"/>
        [DisplayName("Податковий №")]
        [Description("ЄДРПОУ (для резидентів), податковий ID / HandelsregisterNr., тощо (для нерезидентів)")]
        [Required]
        [UIUsageTextBox(HorizontalAlignment="Left", IsMultiline=false,MaxWidth="400", MinWidth="250")]
        [UIConditionalVisibility("ShowCountrySpecificControls")]
        public string TaxCodeOrHandelsRegNr { get { return _TaxCodeOrHandelsRegNr; } set { _TaxCodeOrHandelsRegNr = value; OnPropertyChanged("TaxCodeOrHandelsRegNr"); } }

        private RegistrarAuthority _Registrar;
        /// <summary>
        /// Обов'язкове поле, якщо контекстом не визначено інше
        /// </summary>
        [Category(CATEGORY_REG_INFO)]
        [DisplayName("Держорган-реєстратор")]
        [Description("Державний орган, який здійснив реєстрацію юридичної особи")]
        [UIConditionalVisibility("ShowCountrySpecificControls")]
        public RegistrarAuthority Registrar { get { return _Registrar; } set { _Registrar = value; OnPropertyChanged("Registrar"); } }


        private LPRegisteredDateRecordId _RegisteredDateID;
        /// <summary>
        /// Дата та номер запису про проведення державної реєстрації фізичної особи-підприємця
        /// </summary>
        [Category(CATEGORY_REG_INFO)]
        [DisplayName("Дата/№ запису в держреєстрі")]
        [Description("Дата та номер запису в Єдиному державному реєстрі юридичних осіб та фізичних осіб-підприємців")]
        [UIConditionalVisibility("ShowCountrySpecificControls")]
        public LPRegisteredDateRecordId RegisteredDateID { get { return _RegisteredDateID; } set { _RegisteredDateID = value; OnPropertyChanged("RegisteredDateID"); } }

        private bool _IsStockExchangeListed;
        [DisplayName("Публічна компанія")]
        [Description("Публічна компанія згідно з визначенням пост.357")]
        [Required]
        [UIConditionalVisibility("ShowCountrySpecificControls")]
        public bool IsStockExchangeListed { get { return _IsStockExchangeListed; } set { _IsStockExchangeListed = value; OnPropertyChanged("IsStockExchangeListed"); } }

        private StockExchangeListingInfo _StockExchangeListing;
        [DisplayName("Лістинг")]
        [Description("Інформація про біржовий лістинг для публічної компанії")]
        [Required("IsStockExchangeListed")]
        [UIConditionalVisibility("IsStockExchangeListed")]
        public StockExchangeListingInfo StockExchangeListing { get { return _StockExchangeListing; } set { _StockExchangeListing = value; OnPropertyChanged("StockExchangeListing"); } }

        private LocationInfo _Address;
        /// <summary>
        /// Адреса юрособи. Поле обов'язкове, якщо контекстом не вказано інше.
        /// Мінімальне заповнення - країна та місто
        /// </summary>
        [Category(CATEGORY_ADDRESSES)]
        [DisplayName("Юридична адреса")]
        [Description("Юридична адреса юридичної особи")]
        [Required]
        public LocationInfo Address { get { return _Address; } set { _Address = value; OnPropertyChanged("Address"); } }

        private List<LocationHistoryRecord> _OfficialAddressesHistory;
        [Category(CATEGORY_ADDRESSES)]
        [DisplayName("Історія юридичних адрес")]
        [Description("Історія юридичних (офіційних) адрес юридичної особи")]
        [Required]
        public List<LocationHistoryRecord> OfficialAddressesHistory { get { return _OfficialAddressesHistory; } set { _OfficialAddressesHistory = value; OnPropertyChanged("OfficialAddressesHistory"); } }

        private bool _IsRegistrationAddressActual;
        /// <summary>
        /// 
        /// </summary>
        [Category(CATEGORY_ADDRESSES)]
        [DisplayName("Юридична адреса є фактичним місцезнаходженням")]
        [Description("(зніміть цю галочку, якщо фактична адреса юр.особи відрізняються від її юридичної адреси)")]
        public bool IsRegistrationAddressActual { get { return _IsRegistrationAddressActual; } set { _IsRegistrationAddressActual = value; OnPropertyChanged("IsRegistrationAddressActual"); OnPropertyChanged("IsActualAndRegistrationAddressDifferent"); } }



        //private bool _IsActualAndRegistrationAddressDifferent;
        /// <summary>
        /// 
        /// </summary>
        [Category(CATEGORY_ADDRESSES)]
        [Browsable(false)]
        [XmlIgnore]
        [DisplayName("Юридична й фактична адреси відрізняються?")]
        [Description("(відзначте цю галочку, якщо фактична адреса юр.особи відрізняються від її юридичної адреси)")]
        public bool IsActualAndRegistrationAddressDifferent { get { return !IsRegistrationAddressActual; } }
        //public bool IsActualAndRegistrationAddressDifferent { get { return _IsActualAndRegistrationAddressDifferent; } set { _IsActualAndRegistrationAddressDifferent = value; OnPropertyChanged("IsActualAndRegistrationAddressDifferent"); } }


        private LocationInfo _ActualAddress;
        /// <summary>
        /// Поле необхідне лише якщо вимагається у анкеті, та якщо відрізняється від офіційної юридичної адреси.
        /// </summary>
        [Category(CATEGORY_ADDRESSES)]
        [DisplayName("Місцезнаходження")]
        [Description("Фактичне місцезнаходження юридичної особи")]
        [UIConditionalVisibility("IsActualAndRegistrationAddressDifferent")]
        public LocationInfo ActualAddress { get { return _ActualAddress; } set { _ActualAddress = value; OnPropertyChanged("ActualAddress"); } }

        private List<LocationHistoryRecord> _ActualAddressesHistory;
        [Category(CATEGORY_ADDRESSES)]
        [DisplayName("Історія місцезнаходжень")]
        [Description("Історія фактичних місцезнаходжень юридичної особи")]
        [Required]
        public List<LocationHistoryRecord> ActualAddressesHistory { get { return _ActualAddressesHistory; } set { _ActualAddressesHistory = value; OnPropertyChanged("ActualAddressesHistory"); } }

        private ContactInfo _Contacts;
        [Category(CATEGORY_ADDRESSES)]
        [DisplayName("Котакти")]
        [Description("Контактні дані ")]
        [Required]
        public ContactInfo Contacts { get { return _Contacts; } set { _Contacts = value; OnPropertyChanged("Contacts"); } }

        private List<ContactInfoHistoryRec> _ContactsHistory;
        /// <summary>
        /// Вказувати лише ту частину, що втатила чинність 
        /// і не відображена у чинних контактах (але колись була).
        /// В першу чергу (і як правило) цікавлять телефони.
        /// </summary>
        [Category(CATEGORY_ADDRESSES)]
        [DisplayName("Котакти - історія")]
        [Description("Історія контактних даних")]
        [Required]
        public List<ContactInfoHistoryRec> ContactsHistory { get { return _ContactsHistory; } set { _ContactsHistory = value; OnPropertyChanged("ContactsHistory"); } }

        private GenericPersonID _RepresentedBy;
        /// <summary>
        /// Якщо передбачений представник
        /// </summary>
        [Category(CATEGORY_EXTRA_DATA)]
        [DisplayName("Представник юрособи")]
        [Description("Особа, що представляє юрособу")]
        public GenericPersonID RepresentedBy { get { return _RepresentedBy; } set { _RepresentedBy = value; OnPropertyChanged("RepresentedBy"); } }

        private CurrencyAmount _Equity;
        /// <summary>
        /// Якщо анкетою вимагається (див. по контексту, необов'язкове поле).
        /// </summary>
        [Category(CATEGORY_EXTRA_DATA)]
        [DisplayName("Статутний капітал")]
        [Description("Статутний фонд/капітал")]
        public CurrencyAmount Equity { get { return _Equity; } set { _Equity = value; OnPropertyChanged("Equity"); } }

        private List<EconomicActivityType> _PrincipalActivities;
        /// <summary>
        /// Вид діяльності - якщо вимагається в анкеті; логічно його притулити 
        /// було до самої структури інформації про юр.особу
        /// </summary>
        [Category(CATEGORY_EXTRA_DATA)]
        [DisplayName("Основний вид діяльності")]
        [Description("Основний(-і) вид(-и) діяльності юрособи")]
        public List<EconomicActivityType> PrincipalActivities { get { return _PrincipalActivities; } set { _PrincipalActivities = value; OnPropertyChanged("PrincipalActivities"); } }


        [Browsable(false)]
        public GenericPersonID GenericID { get { return new GenericPersonID() { CountryISO3Code = ResidenceCountry.CountryISONr, PersonCode = IsIntFinOrg? Name : TaxCodeOrHandelsRegNr, PersonType = EntityType.Legal, DisplayName = ToString() }; } }

        public override string ToString()
        {
            return Name;
        }
    }
}
