using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Interfaces;
using Microsoft.Practices.Unity;
using BGU.DRPL.SignificantOwnership.Core.TypeEditors;
using BGU.DRPL.SignificantOwnership.BasicUILib;


namespace BGU.DRPL.SignificantOwnership.UI.Modules
{
    public class BasicUIModule : IModule
    {
        public void Initialize(IUnityContainer cont)
        {
            //p.I

            cont.RegisterInstance<IAppx2OwnershipStructLPEditFormFactory>(new Appx2OwnershipStructLPEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IRegLicAppx14NewSvcEditFormFactory>(new RegLicAppx14NewSvcEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IRegLicAppx2OwnershipAcqRequestLPEditFormFactory>(new RegLicAppx2OwnershipAcqRequestLPEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IRegLicAppx4PhysPQuestEditFormFactory>(new RegLicAppx4PhysPQuestEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IRegLicAppx7ShareAcqIntentEditFormFactory>(new RegLicAppx7ShareAcqIntentEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IAttachmentInfoEditFormFactory>(new AttachmentInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IBankingLicensedActivityInfoEditFormFactory>(new BankingLicensedActivityInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IBankingLicenseInfoEditFormFactory>(new BankingLicenseInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<ICommonOwnershipInfoEditFormFactory>(new CommonOwnershipInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IContactInfoEditFormFactory>(new ContactInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<ICouncilBodyInfoEditFormFactory>(new CouncilBodyInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<ICouncilMemberInfoEditFormFactory>(new CouncilMemberInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<ICurrencyAmountEditFormFactory>(new CurrencyAmountEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IGenericPersonIDEditFormFactory>(new GenericPersonIDEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IGenericPersonIDShareEditFormFactory>(new GenericPersonIDShareEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            //cont.RegisterInstance<IGenericPersonInfoEditFormFactory>(new GenericPersonInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IGenericPersonInfoEditFormFactory>(new GenericPersonInfoEditFormFactoryBasicEx(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<ILegalPersonShareInfoEditFormFactory>(new LegalPersonShareInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IOwnershipStructureEditFormFactory>(new OwnershipStructureEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IOwnershipSummaryInfoEditFormFactory>(new OwnershipSummaryInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IOwnershipVotesInfoEditFormFactory>(new OwnershipVotesInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IPersonsAssociationEditFormFactory>(new PersonsAssociationEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IPhoneInfoEditFormFactory>(new PhoneInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IPhysicalPersonShareInfoEditFormFactory>(new PhysicalPersonShareInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IPurchasedVoteInfoEditFormFactory>(new PurchasedVoteInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<ISignatoryInfoEditFormFactory>(new SignatoryInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<ITotalOwnershipDetailsInfoEditFormFactory>(new TotalOwnershipDetailsInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            //cont.RegisterInstance<IBankInfoEditFormFactory>(new BankInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IBankInfoEditFormFactory>(new BankInfoEditFormFactoryBasicEx(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<ICountryInfoEditFormFactory>(new CountryInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<ILegalPersonInfoEditFormFactory>(new LegalPersonInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<ILocationInfoEditFormFactory>(new LocationInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            //cont.RegisterInstance<IPhysicalPersonInfoEditFormFactory>(new PhysicalPersonInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IPhysicalPersonInfoEditFormFactory>(new PhysicalPersonInfoEditFormFactoryBasicEx(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IRegistrarAuthorityEditFormFactory>(new RegistrarAuthorityEditFormFactoryBasic(), new ContainerControlledLifetimeManager());

            //p.II
            cont.RegisterInstance<IBreachOfLawRecordInfoEditFormFactory>(new BreachOfLawRecordInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IEducationRecordInfoEditFormFactory>(new EducationRecordInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IEmploymentRecordInfoEditFormFactory>(new EmploymentRecordInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IFinancialGuaranteeInfoEditFormFactory>(new FinancialGuaranteeInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IIncomeOriginInfoEditFormFactory>(new IncomeOriginInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IIndebtnessInfoEditFormFactory>(new IndebtnessInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IIndebtnessInfoBaseEditFormFactory>(new IndebtnessInfoBaseEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<ILiquidatedEntityOwnershipInfoEditFormFactory>(new LiquidatedEntityOwnershipInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<ILoanInfoEditFormFactory>(new LoanInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IPaymentDeadlineInfoEditFormFactory>(new PaymentDeadlineInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IPaymentModeInfoEditFormFactory>(new PaymentModeInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IProfessionLicenseInfoEditFormFactory>(new ProfessionLicenseInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<ISharesAcquisitionInfoEditFormFactory>(new SharesAcquisitionInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IBankAccountInfoEditFormFactory>(new BankAccountInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IProfessionLicensingBodyInfoEditFormFactory>(new ProfessionLicensingBodyInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IPublicationInfoEditFormFactory>(new PublicationInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IPublishingHouseInfoEditFormFactory>(new PublishingHouseInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IUniversityOrCollegeInfoEditFormFactory>(new UniversityOrCollegeInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IFinancialOversightAuthorityInfoEditFormFactory>(new FinancialOversightAuthorityInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());

            //p.III
            cont.RegisterInstance<ICourtInfoEditFormFactory>(new CourtInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<ILPRegisteredDateRecordIdEditFormFactory>(new LPRegisteredDateRecordIdEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IEmailInfoEditFormFactory>(new EmailInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IIndebtnessInfoBaseEditFormFactory>(new IndebtnessInfoBaseEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<ICreditRatingInfoEditFormFactory>(new CreditRatingInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IRegLicAppx12HeadCandidateApplEditFormFactory>(new RegLicAppx12HeadCandidateApplEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IBankruptcyInvestigationInfoEditFormFactory>(new BankruptcyInvestigationInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<ILiquidatedOrInsolventEntityInfoBaseEditFormFactory>(new LiquidatedOrInsolventEntityInfoBaseEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IRegLicAppx9BankingLicenseApplEditFormFactory>(new RegLicAppx9BankingLicenseApplEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IManagementPositionEditFormFactory>(new ManagementPositionEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IInsolvencyStatusEditFormFactory>(new InsolvencyStatusEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IWellKnownCreditRatingAgencyTypeEditFormFactory>(new WellKnownCreditRatingAgencyTypeEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<ILongTermCreditRatingTypeEditFormFactory>(new LongTermCreditRatingTypeEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IShortTermCreditRatingTypeEditFormFactory>(new ShortTermCreditRatingTypeEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IBankruptcyCaseResolutionTypeEditFormFactory>(new BankruptcyCaseResolutionTypeEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<ICourtInstanceTypeEditFormFactory>(new CourtInstanceTypeEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<ICourtDecisionTypeEditFormFactory>(new CourtDecisionTypeEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IBankAssociatedPeronsCode315pEditFormFactory>(new BankAssociatedPeronsCode315pEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<ILegalTransactionTypeEditFormFactory>(new LegalTransactionTypeEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IInfluenceTypeEditFormFactory>(new InfluenceTypeEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<ILiquidatedOrInsolventEntityMgmtRecordInfoEditFormFactory>(new LiquidatedOrInsolventEntityMgmtRecordInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<ICharterCapitalTableRecordEditFormFactory>(new CharterCapitalTableRecordEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IRegLicAppx6EquityFormationTableEditFormFactory>(new RegLicAppx6EquityFormationTableEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IEnumsListerEditFormFactory>(new EnumsListerEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IRatingAgencyInfoEditFormFactory>(new RatingAgencyInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IEconomicActivityTypeEditFormFactory>(new EconomicActivityTypeEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<ICharterCapitalTableTotalsRecordEditFormFactory>(new CharterCapitalTableTotalsRecordEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<ICourtDecisionInfoEditFormFactory>(new CourtDecisionInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<ILicenseQualificationInfoEditFormFactory>(new LicenseQualificationInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IIPOSharesPurchaseInfoEditFormFactory>(new IPOSharesPurchaseInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<ISecondaryMarketSharesPurchaseInfoEditFormFactory>(new SecondaryMarketSharesPurchaseInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IRegLicAppx17EquityChangeTableEditFormFactory>(new RegLicAppx17EquityChangeTableEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IAppx3OwnershipStructPPEditFormFactory>(new Appx3OwnershipStructPPEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IRegLicAppx3MemberCandidateApplEditFormFactory>(new RegLicAppx3MemberCandidateApplEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<ILegalTransactionInfoEditFormFactory>(new LegalTransactionInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IPowerOfAttorneySharesPurchaseInfoEditFormFactory>(new PowerOfAttorneySharesPurchaseInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<ISignificantOrDecisiveInfulenceInfoEditFormFactory>(new SignificantOrDecisiveInfulenceInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<ISignificantOwnershipAcquisitionWaysInfoEditFormFactory>(new SignificantOwnershipAcquisitionWaysInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<ITotalOwnershipSummaryInfoEditFormFactory>(new TotalOwnershipSummaryInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IImperfectBusinessReputationInfoEditFormFactory>(new ImperfectBusinessReputationInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());
            cont.RegisterInstance<IPowerOfAttorneyInfoEditFormFactory>(new PowerOfAttorneyInfoEditFormFactoryBasic(), new ContainerControlledLifetimeManager());

        }
    }
}
