using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Dict
{
    /// <summary>
    /// Реквізити юридичної особи
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.LegalPersonInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class LegalPersonInfo
    {

        public LegalPersonInfo()
        {
            ResidenceCountry = CountryInfo.UKRAINE;
            this.PrincipalActivities = new List<EconomicActivityType>();
        }
        /// <summary>
        /// Обов'язкове поле (якщо контекстом проперті, де використовується цей тим, не визначено інакше)
        /// Для резидентів - ЄДРПОУ
        /// Для нерезидентів - еквівалентний ідентифікатор
        /// </summary>
        /// <seealso cref="http://irc.gov.ua/ua/Poshuk-v-YeDR.html"/>
        [DisplayName("Податковий №")]
        [Description("ЄДРПОУ/Податковий ID/HandelsregisterNr.(для нерезидентів)")]
        [Required]
        public string TaxCodeOrHandelsRegNr { get; set; }
        /// <summary>
        /// Обов'язкове поле.
        /// Назва оригінальною мовою.
        /// </summary>
        [DisplayName("Найменування")]
        [Description("Найменування юридичної особи (оригінальною мовою)")]
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Назва українською (якщо оригінальна - іншою мовою).
        /// </summary>
        [DisplayName("Найменування українською")]
        [Description("Найменування юридичної особи українською мовою (для нерезидентів)")]
        public string NameUkr { get; set; }
        /// <summary>
        /// Адреса юрособи. Поле обов'язкове, якщо контекстом не вказано інше.
        /// Мінімальне заповнення - країна та місто
        /// </summary>
        [DisplayName("Місцезнаходження")]
        [Description("місцезнаходження юридичної особи")]
        [Required]
        public LocationInfo Address { get; set; }
        /// <summary>
        /// Країна резидентності
        /// Обов'язкове. За змовчанням (пропонувати) - Україна.
        /// </summary>
        [DisplayName("Країна юрисдикції")]
        [Description("Країна юрисдикції юридичної особи")]
        [Required]
        public CountryInfo ResidenceCountry { get; set; }
        /// <summary>
        /// Обов'язкове поле, якщо контекстом не визначено інше
        /// </summary>
        [DisplayName("Держорган-реєстратор")]
        [Description("Державний орган, який здійснив реєстрацію юридичної особи")]
        public RegistrarAuthority Registrar { get; set; }

        /// <summary>
        /// Дата та номер запису про проведення державної реєстрації фізичної особи-підприємця
        /// </summary>
        [DisplayName("Дата/№ запису в держреєстрі")]
        [Description("Дата та номер запису в Єдиному державному реєстрі юридичних осіб та фізичних осіб-підприємців")]
        public LPRegisteredDateRecordId RegisteredDateID { get; set; }

        /// <summary>
        /// Якщо передбачений представник
        /// </summary>
        [DisplayName("Представник юрособи")]
        [Description("Особа, що представляє юрособу")]
        public GenericPersonID RepresentedBy { get; set; }
        /// <summary>
        /// Якщо анкетою вимагається (див. по контексту, необов'язкове поле).
        /// </summary>
        [DisplayName("Статутний капітал")]
        [Description("Статутний фонд/капітал")]
        public CurrencyAmount Equity { get; set; }
        /// <summary>
        /// Вид діяльності - якщо вимагається в анкеті; логічно його притулити 
        /// було до самої структури інформації про юр.особу
        /// </summary>
        [DisplayName("Основний вид діяльності")]
        [Description("Основний(-і) вид(-и) діяльності юрособи")]
        public List<EconomicActivityType> PrincipalActivities { get; set; }

        [Browsable(false)]
        public GenericPersonID GenericID { get { return new GenericPersonID() { CountryISO3Code = ResidenceCountry.CountryISONr, PersonCode = TaxCodeOrHandelsRegNr, PersonType = EntityType.Legal, DisplayName = ToString() }; } }

        public override string ToString()
        {
            return Name;
        }
    }
}
