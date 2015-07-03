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
        #endregion

        public CourtInfo()
        {
            JurisdictionCountry = CountryInfo.UKRAINE;
        }

        [Required]
        public string Name { get { return _Name; } set { _Name = value; OnPropertyChanged("Name"); } }
        [UIConditionalVisibility("IsNonResident")]
        public string NameUkr { get { return _NameUkr; } set { _NameUkr = value; OnPropertyChanged("NameUkr"); } }
        public CountryInfo JurisdictionCountry { get { return _JurisdictionCountry; } set { _JurisdictionCountry = value; OnPropertyChanged("JurisdictionCountry"); OnPropertyChanged("IsNonResident"); } }

        [Browsable(false)]
        [XmlIgnore]
        public bool IsNonResident { get { return JurisdictionCountry != null && JurisdictionCountry != CountryInfo.UKRAINE; } }

        public string CourtRegion { get { return _CourtRegion; } set { _CourtRegion = value; OnPropertyChanged("CourtRegion"); } }
        public string CourtID { get { return _CourtID; } set { _CourtID = value; OnPropertyChanged("CourtID"); } }
        public CourtInstanceType Instance { get { return _Instance; } set { _Instance = value; OnPropertyChanged("Instance"); } }
    }
}
