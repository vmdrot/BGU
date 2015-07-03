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
    /// Відомості про кредитно-рейтингову аґенцію (якщо інша, окрім Big Three)
    /// </summary>
    /// <seealso cref="http://en.wikipedia.org/wiki/Category:Credit_rating_agencies"/>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.RatingAgencyInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class RatingAgencyInfo : NotifyPropertyChangedBase
    {
        private string _Name;
        [DisplayName("Назва")]
        [Description("Назва рейтингової аґенції (оригінальна, оригінальною мовою)")]
        [Required]
        public string Name { get { return _Name; } set { _Name = value; OnPropertyChanged("Name"); } }


        private string _NameUkr;
        [DisplayName("Назва українською")]
        [Description("Назва рейтингової аґенції українською (якщо оригінальна назва - іншомовна)")]
        [Required("CoverageCountry != CountryInfo.UKRAINE")]
        [UIConditionalVisibility("IsNonResident")]
        public string NameUkr { get { return _NameUkr; } set { _NameUkr = value; OnPropertyChanged("NameUkr"); } }


        private bool _IsGlobal;
        [DisplayName("Глобальне покриття?")]
        [Description("Аґенція рейтингує компанії глобально, а не прив'язана до якоїсь конкретної країни")]
        [Required]
        public bool IsGlobal { get { return _IsGlobal; } set { _IsGlobal = value; OnPropertyChanged("IsGlobal"); OnPropertyChanged("IsNonResident"); } }


        private CountryInfo _CoverageCountry;
        [DisplayName("Країна покриття")]
        [Description("Якщо аґенція не є глобальною, а рейтингує компанії однієї конкретної країни")]
        [Required("IsGlobal == false")]
        public CountryInfo CoverageCountry { get { return _CoverageCountry; } set { _CoverageCountry = value; OnPropertyChanged("CoverageCountry"); OnPropertyChanged("IsNonResident"); } }


        [Browsable(false)]
        [XmlIgnore]
        public bool IsNonResident { get { return IsGlobal || (CoverageCountry != null && CoverageCountry != CountryInfo.UKRAINE); } }

        private ContactInfo _Contacts;
        [DisplayName("Контакти")]
        [Description("Контактна інформація рейтингової аґенції (напр. веб-сайт); контакти особи/підрозділу, що відповідальні за Ваш рейтинг (якщо є).")]
        [Required]
        public ContactInfo Contacts { get { return _Contacts; } set { _Contacts = value; OnPropertyChanged("Contacts"); } }
    }
}
