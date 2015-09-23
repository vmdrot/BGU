using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.Questionnaires
{
    [HideInXSD]
    public class ActualQuestionnairesUnion
    {
        public RegLicAppx2OwnershipAcqRequestLP Appx2 {get;set;}
        public RegLicAppx3MemberCandidateAppl Appx3 {get;set;}
        public RegLicAppx4OwnershipAcqRequestPP Appx4 {get;set;}
        public RegLicAppx12HeadCandidateAppl Appx12 {get;set;}
        public RegLicAppx14NewSvc Appx14 {get;set;}
        public RegLicAppx9BankingLicenseAppl Appx9 { get; set; }

    }
}
