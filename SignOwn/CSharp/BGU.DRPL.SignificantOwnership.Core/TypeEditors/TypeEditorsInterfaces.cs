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

}
