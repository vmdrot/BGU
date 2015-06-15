using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Dict
{
    /// <summary>
    /// Ідентифікація суду (господарського, тощо)
    /// Використовується, зокрема, у полях, де вимагається 
    /// інформація про наявність порушених справ про банкрутство
    /// </summary>
    /// <seealso cref="http://www.reyestr.court.gov.ua/"/>
    public class CourtInfo
    {
        [Required]
        public string Name { get; set; }
        public string NameUkr { get; set; }
        public CountryInfo JurisdictionCountry { get; set; }
        public string CourtRegion { get; set; }
        public string CourtID { get; set; }
        public CourtInstanceType Instance { get; set; }
    }
}
