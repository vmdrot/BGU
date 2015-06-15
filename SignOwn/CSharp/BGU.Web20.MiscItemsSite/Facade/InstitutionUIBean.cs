using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BGU.Web20.MiscItemsSite.Facade
{
    public class InstitutionUIBean
    {
        public InstitutionType InstitutionKind { get; set; }
        public string InternalInstitutionCode { get; set; }
        public string Name { get; set; }
        public string LegalEntityCode { get; set;}
        public string MFO { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Address { get; set; }
        public string LicenseNr { get; set; }
        public string LicenseIssueDt { get; set; }
    }

}