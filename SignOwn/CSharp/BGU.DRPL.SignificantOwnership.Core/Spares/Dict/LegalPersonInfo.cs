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

        public LegalPersonInfo()
        {
            ResidenceCountry = CountryInfo.UKRAINE;
            this.PrincipalActivities = new List<EconomicActivityType>();
        }

        private CountryInfo _ResidenceCountry;
        /// <summary>
        /// Країна резидентності
        /// Обов'язкове. За змовчанням (пропонувати) - Україна.
        /// </summary>
        [DisplayName("Країна юрисдикції")]
        [Description("Країна юрисдикції юридичної особи")]
        [Required]
        public CountryInfo ResidenceCountry { get { return _ResidenceCountry; } set { _ResidenceCountry = value; OnPropertyChanged("ResidenceCountry"); OnPropertyChanged("IsNonResident"); } }

        [Browsable(false)]
        [XmlIgnore]
        public bool IsNonResident { get { return ResidenceCountry != null && ResidenceCountry != CountryInfo.UKRAINE; } }
        private string _TaxCodeOrHandelsRegNr;
        /// <summary>
        /// Обов'язкове поле (якщо контекстом проперті, де використовується цей тим, не визначено інакше)
        /// Для резидентів - ЄДРПОУ
        /// Для нерезидентів - еквівалентний ідентифікатор
        /// </summary>
        /// <seealso cref="http://irc.gov.ua/ua/Poshuk-v-YeDR.html"/>
        [DisplayName("Податковий №")]
        [Description("ЄДРПОУ/Податковий ID/HandelsregisterNr.(для нерезидентів)")]
        [Required]
        public string TaxCodeOrHandelsRegNr { get { return _TaxCodeOrHandelsRegNr; } set { _TaxCodeOrHandelsRegNr = value; OnPropertyChanged("TaxCodeOrHandelsRegNr"); } }

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

        private LocationInfo _Address;
        /// <summary>
        /// Адреса юрособи. Поле обов'язкове, якщо контекстом не вказано інше.
        /// Мінімальне заповнення - країна та місто
        /// </summary>
        [DisplayName("Юридична адреса")]
        [Description("Юридична адреса юридичної особи")]
        [Required]
        public LocationInfo Address { get { return _Address; } set { _Address = value; OnPropertyChanged("Address"); } }

        private bool _IsActualAndRegistrationAddressDifferent;
        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Юридична й фактична адреси відрізняються?")]
        [Description("(відзначте цю галочку, якщо фактична адреса юр.особи відрізняються від її юридичної адреси)")]
        public bool IsActualAndRegistrationAddressDifferent { get { return _IsActualAndRegistrationAddressDifferent; } set { _IsActualAndRegistrationAddressDifferent = value; OnPropertyChanged("IsActualAndRegistrationAddressDifferent"); } }


        private LocationInfo _ActualAddress;
        /// <summary>
        /// Поле необхідне лише якщо вимагається у анкеті, та якщо відрізняється від офіційної юридичної адреси.
        /// </summary>
        [DisplayName("Місцезнаходження")]
        [Description("Фактичне місцезнаходження юридичної особи")]
        [UIConditionalVisibility("IsResidentialAndRegistrationAddressDifferent")]
        public LocationInfo ActualAddress { get { return _ActualAddress; } set { _ActualAddress = value; OnPropertyChanged("ActualAddress"); } }

        private RegistrarAuthority _Registrar;
        /// <summary>
        /// Обов'язкове поле, якщо контекстом не визначено інше
        /// </summary>
        [DisplayName("Держорган-реєстратор")]
        [Description("Державний орган, який здійснив реєстрацію юридичної особи")]
        public RegistrarAuthority Registrar { get { return _Registrar; } set { _Registrar = value; OnPropertyChanged("Registrar"); } }


        private LPRegisteredDateRecordId _RegisteredDateID;
        /// <summary>
        /// Дата та номер запису про проведення державної реєстрації фізичної особи-підприємця
        /// </summary>
        [DisplayName("Дата/№ запису в держреєстрі")]
        [Description("Дата та номер запису в Єдиному державному реєстрі юридичних осіб та фізичних осіб-підприємців")]
        public LPRegisteredDateRecordId RegisteredDateID { get { return _RegisteredDateID; } set { _RegisteredDateID = value; OnPropertyChanged("RegisteredDateID"); } }

        private GenericPersonID _RepresentedBy;
        /// <summary>
        /// Якщо передбачений представник
        /// </summary>
        [DisplayName("Представник юрособи")]
        [Description("Особа, що представляє юрособу")]
        public GenericPersonID RepresentedBy { get { return _RepresentedBy; } set { _RepresentedBy = value; OnPropertyChanged("RepresentedBy"); } }

        private CurrencyAmount _Equity;
        /// <summary>
        /// Якщо анкетою вимагається (див. по контексту, необов'язкове поле).
        /// </summary>
        [DisplayName("Статутний капітал")]
        [Description("Статутний фонд/капітал")]
        public CurrencyAmount Equity { get { return _Equity; } set { _Equity = value; OnPropertyChanged("Equity"); } }

        private List<EconomicActivityType> _PrincipalActivities;
        /// <summary>
        /// Вид діяльності - якщо вимагається в анкеті; логічно його притулити 
        /// було до самої структури інформації про юр.особу
        /// </summary>
        [DisplayName("Основний вид діяльності")]
        [Description("Основний(-і) вид(-и) діяльності юрособи")]
        public List<EconomicActivityType> PrincipalActivities { get { return _PrincipalActivities; } set { _PrincipalActivities = value; OnPropertyChanged("PrincipalActivities"); } }


        [Browsable(false)]
        public GenericPersonID GenericID { get { return new GenericPersonID() { CountryISO3Code = ResidenceCountry.CountryISONr, PersonCode = TaxCodeOrHandelsRegNr, PersonType = EntityType.Legal, DisplayName = ToString() }; } }

        public override string ToString()
        {
            return Name;
        }
    }
}
