using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Dict
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="http://en.wikipedia.org/wiki/Category:Credit_rating_agencies"/>
    public class RatingAgencyInfo
    {
        public string Name { get; set; }
        public string NameUkr { get; set; }
        public bool IsGlobal { get; set; }
        public CountryInfo CoverageCountry { get; set; }
        public ContactInfo Contacts { get; set; }
    }
}
