using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;
using System.Xml.Serialization;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Dict
{
    /// <summary>
    /// Державний (чи як там заведено у відповідній країні) 
    /// орган реєстрації осіб (як юридичних, так і фізичних)
    /// </summary>
    /// <seealso cref="http://en.wikipedia.org/wiki/List_of_company_registers"/>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.RegistrarAuthority_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class RegistrarAuthority : NotifyPropertyChangedBase
    {
        public RegistrarAuthority()
        {
            JurisdictionCountry = CountryInfo.UKRAINE;
        }

        private CountryInfo _JurisdictionCountry;
        /// <summary>
        /// Обов'язкове поле, за змовчанням - Україна
        /// </summary>
        [DisplayName("Країна юрисдикції")]
        [Description("Країна юрисдикції")]
        [Required]
        public CountryInfo JurisdictionCountry { get { return _JurisdictionCountry; } set { _JurisdictionCountry = value; OnPropertyChanged("JurisdictionCountry"); OnPropertyChanged("IsNonResident"); } }

        [Browsable(false)]
        [XmlIgnore]
        public bool IsNonResident { get { return JurisdictionCountry != null && JurisdictionCountry != CountryInfo.UKRAINE; } }

        private LocationInfo _Address;
        /// <summary>
        /// якнайповніше
        /// </summary>
        [DisplayName("Місцезнаходження")]
        [Description("Місцезнаходження")]
        [Required]
        public LocationInfo Address { get { return _Address; } set { _Address = value; OnPropertyChanged("Address"); } }

        private string _RegistrarCode;
        /// <summary>
        /// Якщо такий код передбачено/існує; коротше, необов'язкове поле
        /// (напр., у наших закордонних паспортах фігурує Issuing authority ID)
        /// </summary>
        [DisplayName("Код держоргану (якщо існує)")]
        [Description("Код держоргану (якщо існує)")]
        public string RegistrarCode { get { return _RegistrarCode; } set { _RegistrarCode = value; OnPropertyChanged("RegistrarCode"); } }

        private string _RegistrarName;
        /// <summary>
        /// Назва реєстратора (оригінальною мовою, у т.ч. українською - якщо реєстратор український).
        /// </summary>
        [DisplayName("Назва держоргану")]
        [Description("Назва держоргану")]
        [Required]
        public string RegistrarName { get { return _RegistrarName; } set { _RegistrarName = value; OnPropertyChanged("RegistrarName"); } }

        private string _RegistrarNameUkr;
        /// <summary>
        /// Назва реєстратора українською (якщо реєстратор не український).
        /// </summary>
        [DisplayName("Назва держоргану українською")]
        [Description("Назва держоргану українською (для органів у інших країнах)")]
        [UIConditionalVisibility("IsNonResident")]
        public string RegistrarNameUkr { get { return _RegistrarNameUkr; } set { _RegistrarNameUkr = value; OnPropertyChanged("RegistrarNameUkr"); } }

        private EntityType _EntitiesHandled;
        /// <summary>
        /// Підтримує побітове складання 
        /// Напр. Legal | Physical, Legal & Physical
        /// (оскільки не виключено, що у котрійсь з юрисдикцій 
        /// можуть існувати органи, що реєструють як фізичних, так і юр.осіб)
        /// </summary>
        [DisplayName("Тип осіб, що реєструє")]
        [Description("Тип осіб, що реєструє")]
        [Required]
        public EntityType EntitiesHandled { get { return _EntitiesHandled; } set { _EntitiesHandled = value; OnPropertyChanged("EntitiesHandled"); } }

        public override string ToString()
        {
            return RegistrarName;
        }
    }
}
