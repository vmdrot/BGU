using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;

namespace BGU.DRPL.SignificantOwnership.Core.TypeEditors
{
    public interface ITypeEditorFormFactoryBase
    {
        System.Windows.Forms.Form SpawnInstance();
    }

    //p.I

    public interface IAppx2OwnershipStructLPEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IRegLicAppx14NewSvcEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IRegLicAppx2OwnershipAcqRequestLPEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IRegLicAppx4PhysPQuestEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IRegLicAppx7ShareAcqIntentEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IAttachmentInfoEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IBankingLicensedActivityInfoEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IBankingLicenseInfoEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface ICommonOwnershipInfoEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IContactInfoEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface ICouncilBodyInfoEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface ICouncilMemberInfoEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface ICurrencyAmountEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IGenericPersonIDEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IGenericPersonIDShareEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IGenericPersonInfoEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface ILegalPersonShareInfoEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IOwnershipStructureEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IOwnershipSummaryInfoEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IOwnershipVotesInfoEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IPersonsAssociationEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IPhoneInfoEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IPhysicalPersonShareInfoEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IPurchasedVoteInfoEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface ISignatoryInfoEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface ITotalOwnershipDetailsInfoEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IBankInfoEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface ICountryInfoEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface ILegalPersonInfoEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface ILocationInfoEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IPhysicalPersonInfoEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IRegistrarAuthorityEditFormFactory : ITypeEditorFormFactoryBase { }

    //p.II

    public interface IBreachOfLawRecordInfoEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IEducationRecordInfoEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IEmploymentRecordInfoEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IFinancialGuaranteeInfoEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IIncomeOriginInfoEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IIndebtnessInfoEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IIndebtnessInfoBaseEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface ILiquidatedEntityOwnershipInfoEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface ILoanInfoEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IPaymentDeadlineInfoEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IPaymentModeInfoEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IProfessionLicenseInfoEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface ISharesAcquisitionInfoEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IBankAccountInfoEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IProfessionLicensingBodyInfoEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IPublicationInfoEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IPublishingHouseInfoEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IUniversityOrCollegeInfoEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IFinancialOversightAuthorityInfoEditFormFactory : ITypeEditorFormFactoryBase { }

    //p.III
    public interface ICourtInfoEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface ILPRegisteredDateRecordIdEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IEmailInfoEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface ICreditRatingInfoEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IRegLicAppx12HeadCandidateApplEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IBankruptcyInvestigationInfoEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface ILiquidatedOrInsolventEntityInfoBaseEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IRegLicAppx9BankingLicenseApplEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IManagementPositionEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IInsolvencyStatusEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IWellKnownCreditRatingAgencyTypeEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface ILongTermCreditRatingTypeEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IShortTermCreditRatingTypeEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IBankruptcyCaseResolutionTypeEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface ICourtInstanceTypeEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface ICourtDecisionTypeEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IBankAssociatedPeronsCode315pEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface ILegalTransactionTypeEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IInfluenceTypeEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface ILiquidatedOrInsolventEntityMgmtRecordInfoEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface ICharterCapitalTableRecordEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IRegLicAppx6EquityFormationTableEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IEnumsListerEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IRatingAgencyInfoEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IEconomicActivityTypeEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface ICharterCapitalTableTotalsRecordEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface ICourtDecisionInfoEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface ILicenseQualificationInfoEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IIPOSharesPurchaseInfoEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface ISecondaryMarketSharesPurchaseInfoEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IRegLicAppx17EquityChangeTableEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IAppx3OwnershipStructPPEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IRegLicAppx3MemberCandidateApplEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface ILegalTransactionInfoEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IPowerOfAttorneySharesPurchaseInfoEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface ISignificantOrDecisiveInfulenceInfoEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface ISignificantOwnershipAcquisitionWaysInfoEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface ITotalOwnershipSummaryInfoEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IImperfectBusinessReputationInfoEditFormFactory : ITypeEditorFormFactoryBase { }
    public interface IPowerOfAttorneyInfoEditFormFactory : ITypeEditorFormFactoryBase { }

}
