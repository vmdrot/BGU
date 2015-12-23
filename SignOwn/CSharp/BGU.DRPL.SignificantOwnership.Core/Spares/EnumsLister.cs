using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Utility;
using BGU.DRPL.SignificantOwnership.Core.Spares2;
using BGU.DRPL.SignificantOwnership.Core.Messages.BankInfo;

namespace BGU.DRPL.SignificantOwnership.Core.Spares
{
    public class EnumsLister
    {
        #region cctor(s)
        private EnumsLister()
        { }

        private static EnumsLister _instance;
        public static EnumsLister Instance
        {
            get 
            {
                if (_instance == null) _instance = new EnumsLister(); return _instance;
            }
        }
        #endregion
        #region method(s)
        public List<EnumType> ListEntityType() { return EnumType.GetEnumList(typeof(EntityType)); }
        public List<EnumType> ListOwnershipType() { return EnumType.GetEnumList(typeof(OwnershipType)); }
        public List<EnumType> ListSexType() { return EnumType.GetEnumList(typeof(SexType)); }
        public List<EnumType> ListEmploymentState() { return EnumType.GetEnumList(typeof(EmploymentState)); }
        public List<EnumType> ListEmploymentTerminationType() { return EnumType.GetEnumList(typeof(EmploymentTerminationType)); }
        public List<EnumType> ListHigherEducationDegreeType() { return EnumType.GetEnumList(typeof(HigherEducationDegreeType)); }
        public List<EnumType> ListDegreeHonourType() { return EnumType.GetEnumList(typeof(DegreeHonourType)); }
        public List<EnumType> ListFundsOriginType() { return EnumType.GetEnumList(typeof(FundsOriginType)); }
        public List<EnumType> ListPaymentType() { return EnumType.GetEnumList(typeof(PaymentType)); }
        public List<EnumType> ListFinancialGuarantorRoleType() { return EnumType.GetEnumList(typeof(FinancialGuarantorRoleType)); }
        public List<EnumType> ListBreachOfLawType() { return EnumType.GetEnumList(typeof(BreachOfLawType)); }
        public List<EnumType> ListSentenceType() { return EnumType.GetEnumList(typeof(SentenceType)); }
        public List<EnumType> ListTypicalApplicationAttachement() { return EnumType.GetEnumList(typeof(TypicalApplicationAttachement)); }
        public List<EnumType> ListFinancialServicesType() { return EnumType.GetEnumList(typeof(FinancialServicesType)); }
        public List<EnumType> ListBankingActivityType() { return EnumType.GetEnumList(typeof(BankingActivityType)); }
        public List<EnumType> ListAssociatedPersonRole() { return EnumType.GetEnumList(typeof(AssociatedPersonRole)); }
        public List<EnumType> ListManagementPosition() { return EnumType.GetEnumList(typeof(ManagementPosition)); }
        public List<EnumType> ListInsolvencyStatus() { return EnumType.GetEnumList(typeof(InsolvencyStatus)); }
        public List<EnumType> ListWellKnownCreditRatingAgencyType() { return EnumType.GetEnumList(typeof(WellKnownCreditRatingAgencyType)); }
        public List<EnumType> ListLongTermCreditRatingType() { return EnumType.GetEnumList(typeof(LongTermCreditRatingType)); }
        public List<EnumType> ListShortTermCreditRatingType() { return EnumType.GetEnumList(typeof(ShortTermCreditRatingType)); }
        public List<EnumType> ListBankruptcyCaseResolutionType() { return EnumType.GetEnumList(typeof(BankruptcyCaseResolutionType)); }
        public List<EnumType> ListCourtInstanceType() { return EnumType.GetEnumList(typeof(CourtInstanceType)); }
        public List<EnumType> ListCourtDecisionType() { return EnumType.GetEnumList(typeof(CourtDecisionType)); }
        public List<EnumType> ListBankAssociatedPeronsCode315p() { return EnumType.GetEnumList(typeof(BankAssociatedPersonsCode315p)); }

        //Spares2 enums
        public List<EnumType> ListFinancialInstitutionType() { return EnumType.GetEnumList(typeof(FinancialInstitutionType)); }
        public List<EnumType> ListFinancialInstitutionStatus() { return EnumType.GetEnumList(typeof(FinancialInstitutionStatus)); }
        public List<EnumType> ListCompanyOwnershipType() { return EnumType.GetEnumList(typeof(CompanyOwnershipType)); }
        public List<EnumType> ListInstitutionLevel() { return EnumType.GetEnumList(typeof(InstitutionLevel)); }
        #endregion

        #region prop(s)
        public static List<EnumType> EntityTypeList { get { return EnumType.GetEnumList(typeof(EntityType)); } }
        public static List<EnumType> OwnershipTypeList { get { return EnumType.GetEnumList(typeof(OwnershipType)); } }
        public static List<EnumType> SexTypeList { get { return EnumType.GetEnumList(typeof(SexType)); } }
        public static List<EnumType> EmploymentStateList { get { return EnumType.GetEnumList(typeof(EmploymentState)); } }
        public static List<EnumType> EmploymentTerminationTypeList { get { return EnumType.GetEnumList(typeof(EmploymentTerminationType)); } }
        public static List<EnumType> HigherEducationDegreeTypeList { get { return EnumType.GetEnumList(typeof(HigherEducationDegreeType)); } }
        public static List<EnumType> DegreeHonourTypeList { get { return EnumType.GetEnumList(typeof(DegreeHonourType)); } }
        public static List<EnumType> FundsOriginTypeList { get { return EnumType.GetEnumList(typeof(FundsOriginType)); } }
        public static List<EnumType> PaymentTypeList { get { return EnumType.GetEnumList(typeof(PaymentType)); } }
        public static List<EnumType> FinancialGuarantorRoleTypeList { get { return EnumType.GetEnumList(typeof(FinancialGuarantorRoleType)); } }
        public static List<EnumType> BreachOfLawTypeList { get { return EnumType.GetEnumList(typeof(BreachOfLawType)); } }
        public static List<EnumType> SentenceTypeList { get { return EnumType.GetEnumList(typeof(SentenceType)); } }
        public static List<EnumType> TypicalApplicationAttachementList { get { return EnumType.GetEnumList(typeof(TypicalApplicationAttachement)); } }
        public static List<EnumType> FinancialServicesTypeList { get { return EnumType.GetEnumList(typeof(FinancialServicesType)); } }
        public static List<EnumType> BankingActivityTypeList { get { return EnumType.GetEnumList(typeof(BankingActivityType)); } }
        public static List<EnumType> AssociatedPersonRoleList { get { return EnumType.GetEnumList(typeof(AssociatedPersonRole)); } }
        public static List<EnumType> ManagementPositionList { get { return EnumType.GetEnumList(typeof(ManagementPosition)); } }
        public static List<EnumType> InsolvencyStatusList { get { return EnumType.GetEnumList(typeof(InsolvencyStatus)); } }
        public static List<EnumType> WellKnownCreditRatingAgencyTypeList { get { return EnumType.GetEnumList(typeof(WellKnownCreditRatingAgencyType)); } }
        public static List<EnumType> LongTermCreditRatingTypeList { get { return EnumType.GetEnumList(typeof(LongTermCreditRatingType)); } }
        public static List<EnumType> ShortTermCreditRatingTypeList { get { return EnumType.GetEnumList(typeof(ShortTermCreditRatingType)); } }
        public static List<EnumType> BankruptcyCaseResolutionTypeList { get { return EnumType.GetEnumList(typeof(BankruptcyCaseResolutionType)); } }
        public static List<EnumType> CourtInstanceTypeList { get { return EnumType.GetEnumList(typeof(CourtInstanceType)); } }
        public static List<EnumType> CourtDecisionTypeList { get { return EnumType.GetEnumList(typeof(CourtDecisionType)); } }
        public static List<EnumType> BankAssociatedPeronsCode315pList { get { return EnumType.GetEnumList(typeof(BankAssociatedPersonsCode315p)); } }
        public static List<EnumType> FinancialInstitutionTypeList { get { return EnumType.GetEnumList(typeof(FinancialInstitutionType)); } }
        public static List<EnumType> FinancialInstitutionStatusList { get { return EnumType.GetEnumList(typeof(FinancialInstitutionStatus)); } }
        public static List<EnumType> CompanyOwnershipTypeList { get { return EnumType.GetEnumList(typeof(CompanyOwnershipType)); } }
        public static List<EnumType> InstitutionLevelList { get { return EnumType.GetEnumList(typeof(InstitutionLevel)); } }
        public static List<EnumType> LegalTransactionTypeList { get { return EnumType.GetEnumList(typeof(LegalTransactionType)); } }
        public static List<EnumType> InfluenceTypeList { get { return EnumType.GetEnumList(typeof(InfluenceType)); } }
        public static List<EnumType> LegalTransactionPartyRoleTypeList { get { return EnumType.GetEnumList(typeof(LegalTransactionPartyRoleType)); } }
        public static List<EnumType> MeansOfCommunicationList { get { return EnumType.GetEnumList(typeof(MeansOfCommunication)); } }
        public static List<EnumType> OwnershipFormTypeList { get { return EnumType.GetEnumList(typeof(OwnershipFormType)); } }
        public static List<EnumType> PersonAssociationTypeList { get { return EnumType.GetEnumList(typeof(PersonAssociationType)); } }
        public static List<EnumType> BankOperationLimitTypeList { get { return EnumType.GetEnumList(typeof(BankOperationLimitType)); } }
        public static List<EnumType> BankBranchStatusTypeList { get { return EnumType.GetEnumList(typeof(BankBranchStatusType)); } }
        public static List<EnumType> WorkingHoursDayTypeList { get { return EnumType.GetEnumList(typeof(WorkingHoursDayType)); } }
        public static List<EnumType> LicensedOperationTypeList { get { return EnumType.GetEnumList(typeof(LicensedOperationType)); } }
        public static List<EnumType> BankBranchManagerPositionTypeList { get { return EnumType.GetEnumList(typeof(BankBranchManagerPositionType)); } }
        public static List<EnumType> EducationKindGrosList { get { return EnumType.GetEnumList(typeof(EducationKindGros)); } }
        public static List<EnumType> BankAssociatedPersonsCode315pList { get { return EnumType.GetEnumList(typeof(BankAssociatedPersonsCode315p)); } }
        public static List<EnumType> GeneralFXLicenseActivityTypeList { get { return EnumType.GetEnumList(typeof(GeneralFXLicenseActivityType)); } }
        public static List<EnumType> ProfessionalStockMarketActivityTypeList { get { return EnumType.GetEnumList(typeof(ProfessionalStockMarketActivityType)); } }
        public static List<EnumType> FinActivitySvcInstrumentActionTypeList { get { return EnumType.GetEnumList(typeof(FinActivitySvcInstrumentActionType)); } }
        public static List<EnumType> FinActivitySvcInstrumentTypeList { get { return EnumType.GetEnumList(typeof(FinActivitySvcInstrumentType)); } }
        public static List<EnumType> BankBranchChangeTypeList { get { return EnumType.GetEnumList(typeof(BankBranchChangeType)); } }
        public static List<EnumType> BankBranchTypeList { get { return EnumType.GetEnumList(typeof(BankBranchType)); } }

        #endregion
    }
}
