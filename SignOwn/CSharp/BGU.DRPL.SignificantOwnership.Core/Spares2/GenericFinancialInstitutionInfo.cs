using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;

namespace BGU.DRPL.SignificantOwnership.Core.Spares2
{
    public class GenericFinancialInstitutionInfo
    {
        public string Name { get; set; }
        public FinancialInstitutionType InstitutionType { get; set; }
        public FinancialInstitutionStatus InstitutionStatus { get; set; }
        public CompanyOwnershipType InstitutionOwnershipStatus { get; set; }
        public string InstitutionCode { get; set; }
        public LegalPersonInfo LegalPerson { get; set; }
        public GenericFinancialInstitutionInfo ParentInstitution { get; set; }
    }
}
