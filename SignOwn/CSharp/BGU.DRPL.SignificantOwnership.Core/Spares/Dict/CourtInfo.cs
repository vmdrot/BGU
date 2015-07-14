using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Evolvex.Utility.Core.ComponentModelEx;
using System.ComponentModel;
using System.Xml.Serialization;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Dict
{
    /// <summary>
    /// Ідентифікація суду (господарського, тощо)
    /// Використовується, зокрема, у полях, де вимагається 
    /// інформація про наявність порушених справ про банкрутство
    /// </summary>
    /// <seealso cref="http://www.reyestr.court.gov.ua/"/>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.CourtInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class CourtInfo : NotifyPropertyChangedBase
    {

        #region field(s)
        private string _Name;
        private string _NameUkr;
        private CountryInfo _JurisdictionCountry;
        private string _CourtRegion;
        private string _CourtID;
        private CourtInstanceType _Instance;
        private LocationInfo _CourtAddress;
        #endregion

        public CourtInfo()
        {
            JurisdictionCountry = CountryInfo.UKRAINE;
        }
        
        [DisplayName("Суд")]
        [Description("Назва суду (оригінальною мовою)")]
        [Required]
        public string Name { get { return _Name; } set { _Name = value; OnPropertyChanged("Name"); } }

        [DisplayName("Країна підсудності")]
        [Description("(країна юрисдикції суду)")]
        public CountryInfo JurisdictionCountry { get { return _JurisdictionCountry; } set { _JurisdictionCountry = value; OnPropertyChanged("JurisdictionCountry"); OnPropertyChanged("IsNonResident"); } }

        [Browsable(false)]
        [XmlIgnore]
        public bool IsNonResident { get { return JurisdictionCountry != null && JurisdictionCountry != CountryInfo.UKRAINE; } }

        [DisplayName("Суд (укр.)")]
        [Description("Назва суду українською (якщо іноземний суд)")]
        [UIConditionalVisibility("IsNonResident")]
        public string NameUkr { get { return _NameUkr; } set { _NameUkr = value; OnPropertyChanged("NameUkr"); } }

        [DisplayName("Інстанція суду")]
        public CourtInstanceType Instance { get { return _Instance; } set { _Instance = value; OnPropertyChanged("Instance"); } }

        [DisplayName("Регіон юрисдикції")]
        [Description("Область/регіон юрисдикції суду")]
        public string CourtRegion { get { return _CourtRegion; } set { _CourtRegion = value; OnPropertyChanged("CourtRegion"); } }

        [DisplayName("Код суду")]
        [Description("Код суду (для українських судів) або ж його еквівалент для іноземних судів (якщо існує)")]
        public string CourtID { get { return _CourtID; } set { _CourtID = value; OnPropertyChanged("CourtID"); } }

        [DisplayName("Адреса суду")]
        [Description("Адреса суду")]
        public LocationInfo CourtAddress { get { return _CourtAddress; } set { _CourtAddress = value; OnPropertyChanged("CourtAddress"); } }


        public override string ToString()
        {
            return Name;
        }
    }
}
