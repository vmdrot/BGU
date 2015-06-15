using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.TypeEditors;
using BGU.DRPL.SignificantOwnership.BasicUILib.Forms;
using BGU.DRPL.SignificantOwnership.Core.Questionnaires;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;
using System.Configuration;
using System.Data;
using BGU.DRPL.SignificantOwnership.Utility;

namespace BGU.DRPL.SignificantOwnership.BasicUILib
{

    //p.I
    
    public class Appx2OwnershipStructLPEditFormFactoryBasic : IAppx2OwnershipStructLPEditFormFactory { public System.Windows.Forms.Form SpawnInstance() { return new SimpleObjectForm<Appx2OwnershipStructLP>(); } }
    public class RegLicAppx14NewSvcEditFormFactoryBasic : IRegLicAppx14NewSvcEditFormFactory { public System.Windows.Forms.Form SpawnInstance() { return new SimpleObjectForm<RegLicAppx14NewSvc>(); } }
    public class RegLicAppx2OwnershipAcqRequestLPEditFormFactoryBasic : IRegLicAppx2OwnershipAcqRequestLPEditFormFactory { public System.Windows.Forms.Form SpawnInstance() { return new SimpleObjectForm<RegLicAppx2OwnershipAcqRequestLP>(); } }
    public class RegLicAppx4PhysPQuestEditFormFactoryBasic : IRegLicAppx4PhysPQuestEditFormFactory { public System.Windows.Forms.Form SpawnInstance() { return new SimpleObjectForm<RegLicAppx4OwnershipAcqRequestPP>(); } }
    public class RegLicAppx7ShareAcqIntentEditFormFactoryBasic : IRegLicAppx7ShareAcqIntentEditFormFactory { public System.Windows.Forms.Form SpawnInstance() { return new SimpleObjectForm<RegLicAppx7ShareAcqIntent>(); } }
    public class AttachmentInfoEditFormFactoryBasic : IAttachmentInfoEditFormFactory { public System.Windows.Forms.Form SpawnInstance() { return new SimpleObjectForm<AttachmentInfo>(); } }
    public class BankingLicensedActivityInfoEditFormFactoryBasic : IBankingLicensedActivityInfoEditFormFactory { public System.Windows.Forms.Form SpawnInstance() { return new SimpleObjectForm<BankingLicensedActivityInfo>(); } }
    public class BankingLicenseInfoEditFormFactoryBasic : IBankingLicenseInfoEditFormFactory { public System.Windows.Forms.Form SpawnInstance() { return new SimpleObjectForm<BankingLicenseInfo>(); } }
    public class CommonOwnershipInfoEditFormFactoryBasic : ICommonOwnershipInfoEditFormFactory { public System.Windows.Forms.Form SpawnInstance() { return new SimpleObjectForm<CommonOwnershipInfo>(); } }
    public class ContactInfoEditFormFactoryBasic : IContactInfoEditFormFactory { public System.Windows.Forms.Form SpawnInstance() { return new SimpleObjectForm<ContactInfo>(); } }
    public class CouncilBodyInfoEditFormFactoryBasic : ICouncilBodyInfoEditFormFactory { public System.Windows.Forms.Form SpawnInstance() { return new SimpleObjectForm<CouncilBodyInfo>(); } }
    public class CouncilMemberInfoEditFormFactoryBasic : ICouncilMemberInfoEditFormFactory { public System.Windows.Forms.Form SpawnInstance() { return new SimpleObjectForm<CouncilMemberInfo>(); } }
    public class CurrencyAmountEditFormFactoryBasic : ICurrencyAmountEditFormFactory { public System.Windows.Forms.Form SpawnInstance() { return new SimpleObjectForm<CurrencyAmount>(); } }
    public class GenericPersonIDEditFormFactoryBasic : IGenericPersonIDEditFormFactory { public System.Windows.Forms.Form SpawnInstance() { return new SimpleObjectForm<GenericPersonID>(); } }
    public class GenericPersonIDShareEditFormFactoryBasic : IGenericPersonIDShareEditFormFactory { public System.Windows.Forms.Form SpawnInstance() { return new SimpleObjectForm<GenericPersonIDShare>(); } }
    public class GenericPersonInfoEditFormFactoryBasic : IGenericPersonInfoEditFormFactory { public System.Windows.Forms.Form SpawnInstance() { return new SimpleObjectForm<GenericPersonInfo>(); } }
    public class GenericPersonInfoEditFormFactoryBasicEx : IGenericPersonInfoEditFormFactory 
    { 
        public System.Windows.Forms.Form SpawnInstance() 
        {
            LookupObjectForm<GenericPersonInfo> frm = new LookupObjectForm<GenericPersonInfo>();
            frm.NeedToCompareObjects += new NeedToCompareTypesHandler<GenericPersonInfo>(frm_NeedToCompareObjects);
            IQuestionnaire questio = TypeEditorsDispatcher.LastQuestionnaire;
            if (questio != null && questio is IGenericPersonsService)
                frm.ListSource = ((IGenericPersonsService)questio).MentionedGenericPersons;
            return new LookupObjectForm<GenericPersonInfo>(); 
        }

        private void frm_NeedToCompareObjects(object sender, NeedToCompareTypesArgs<GenericPersonInfo> args)
        {
            args.AreEqual = (args.One.ID == args.Two.ID);
        } 
    }
    public class LegalPersonShareInfoEditFormFactoryBasic : ILegalPersonShareInfoEditFormFactory { public System.Windows.Forms.Form SpawnInstance() { return new SimpleObjectForm<LegalPersonShareInfo>(); } }
    public class OwnershipStructureEditFormFactoryBasic : IOwnershipStructureEditFormFactory { public System.Windows.Forms.Form SpawnInstance() { return new SimpleObjectForm<OwnershipStructure>(); } }
    public class OwnershipSummaryInfoEditFormFactoryBasic : IOwnershipSummaryInfoEditFormFactory { public System.Windows.Forms.Form SpawnInstance() { return new SimpleObjectForm<OwnershipSummaryInfo>(); } }
    public class OwnershipVotesInfoEditFormFactoryBasic : IOwnershipVotesInfoEditFormFactory { public System.Windows.Forms.Form SpawnInstance() { return new SimpleObjectForm<OwnershipVotesInfo>(); } }
    public class PersonsAssociationEditFormFactoryBasic : IPersonsAssociationEditFormFactory { public System.Windows.Forms.Form SpawnInstance() { return new SimpleObjectForm<PersonsAssociation>(); } }
    public class PhoneInfoEditFormFactoryBasic : IPhoneInfoEditFormFactory { public System.Windows.Forms.Form SpawnInstance() { return new SimpleObjectForm<PhoneInfo>(); } }
    public class PhysicalPersonShareInfoEditFormFactoryBasic : IPhysicalPersonShareInfoEditFormFactory { public System.Windows.Forms.Form SpawnInstance() { return new SimpleObjectForm<PhysicalPersonShareInfo>(); } }
    public class PurchasedVoteInfoEditFormFactoryBasic : IPurchasedVoteInfoEditFormFactory { public System.Windows.Forms.Form SpawnInstance() { return new SimpleObjectForm<PurchasedVoteInfo>(); } }
    public class SignatoryInfoEditFormFactoryBasic : ISignatoryInfoEditFormFactory { public System.Windows.Forms.Form SpawnInstance() { return new SimpleObjectForm<SignatoryInfo>(); } }
    public class TotalOwnershipDetailsInfoEditFormFactoryBasic : ITotalOwnershipDetailsInfoEditFormFactory { public System.Windows.Forms.Form SpawnInstance() { return new SimpleObjectForm<TotalOwnershipDetailsInfo>(); } }
    public class BankInfoEditFormFactoryBasic : IBankInfoEditFormFactory { public System.Windows.Forms.Form SpawnInstance() { System.Windows.Forms.Form rslt = new SimpleObjectForm<BankInfo>(); rslt.Size = new System.Drawing.Size(500, 400); return rslt; } }

    public class BankInfoEditFormFactoryBasicEx : IBankInfoEditFormFactory
    {
        public System.Windows.Forms.Form SpawnInstance()
        {
            LookupObjectForm<BankInfo> frm = new LookupObjectForm<BankInfo>();
            frm.NeedToCompareObjects += new NeedToCompareTypesHandler<BankInfo>(frm_NeedToCompareObjects);
            IQuestionnaire questio = TypeEditorsDispatcher.LastQuestionnaire;
            frm.ListSource = RcuKruBanks;
            
            return frm;
        }

        private static List<BankInfo> _rcuKurBanks;
        private static List<BankInfo> RcuKruBanks
        {
            get
            {
                if (_rcuKurBanks == null)
                {
                    _rcuKurBanks = new List<BankInfo>();
                    DataTable dt = RcuKruReader.Read(ConfigurationManager.AppSettings["rcuKruPath"]);
                    foreach (DataRow dr in dt.Rows)
                    {
                        string prb = dr["PRB"] as string;
                        if(prb == "1")
                            continue;

                        string glmfo = ((int)dr["GLMFO"]).ToString();
                        string mfo = ((int)dr["MFO"]).ToString();
                        if(glmfo != mfo)
                            continue;
                        string glb = ((int)dr["GLB"]).ToString();

                        string prkb = ((int)dr["PRKB"]).ToString();

                        string zipCode = dr["PI"] as string;
                        string city = dr["NP"] as string;
                        string address = dr["ADRESS"] as string;
                        string yedrpou = dr["IKOD"] as string;

                        BankInfo bi = new BankInfo();
                        bi.OperationCountry = CountryInfo.UKRAINE;
                        bi.Name = dr["NB"] as string;
                        bi.MFO = mfo;
                        bi.Code = glb;
                        bi.RegistryNr = prkb;
                        bi.LegalPerson = (new LegalPersonInfo() { TaxCodeOrHandelsRegNr = yedrpou, Name = dr["FULLNAME"] as string, Address = LocationInfo.Parse(address), ResidenceCountry = CountryInfo.UKRAINE }).GenericID;
                        //bi.LegalPerson.Address.City = city;
                        //bi.LegalPerson.Address.ZipCode = zipCode;
                        _rcuKurBanks.Add(bi);
                    }

                    _rcuKurBanks.Sort(delegate(BankInfo obj1, BankInfo obj2)
                    {
                        return string.Compare(obj1.Name, obj2.Name);
                    });


                }
                return _rcuKurBanks;
            }
        }

        private void frm_NeedToCompareObjects(object sender, NeedToCompareTypesArgs<BankInfo> args)
        {
            args.AreEqual = (args.One.MFO == args.Two.MFO);
        }
    }

    public class CountryInfoEditFormFactoryBasic : ICountryInfoEditFormFactory { public System.Windows.Forms.Form SpawnInstance() { return new SimpleObjectForm<CountryInfo>(); } }
    public class LegalPersonInfoEditFormFactoryBasic : ILegalPersonInfoEditFormFactory { public System.Windows.Forms.Form SpawnInstance() { return new SimpleObjectForm<LegalPersonInfo>(); } }

    public class LegalPersonInfoEditFormFactoryBasicEx : IGenericPersonInfoEditFormFactory
    {
        public System.Windows.Forms.Form SpawnInstance()
        {
            LookupObjectForm<LegalPersonInfo> frm = new LookupObjectForm<LegalPersonInfo>();
            frm.NeedToCompareObjects += new NeedToCompareTypesHandler<LegalPersonInfo>(frm_NeedToCompareObjects);
            IQuestionnaire questio = TypeEditorsDispatcher.LastQuestionnaire;
            if (questio != null && questio is IGenericPersonsService)
            {
                IEnumerable<GenericPersonInfo> gpis = ((IGenericPersonsService)questio).MentionedGenericPersons;
                List<LegalPersonInfo> lpis = new List<LegalPersonInfo>();
                foreach(GenericPersonInfo gpi in gpis)
                {
                    if(gpi.PersonType == Core.Spares.EntityType.Legal && gpi.LegalPerson != null)
                        lpis.Add(gpi.LegalPerson);
                }

                frm.ListSource = lpis;
            }
            return new LookupObjectForm<GenericPersonInfo>();
        }

        private void frm_NeedToCompareObjects(object sender, NeedToCompareTypesArgs<LegalPersonInfo> args)
        {
            args.AreEqual = (args.One.GenericID == args.Two.GenericID);
        }
    }

    public class LocationInfoEditFormFactoryBasic : ILocationInfoEditFormFactory { public System.Windows.Forms.Form SpawnInstance() { return new SimpleObjectForm<LocationInfo>(); } }
    public class PhysicalPersonInfoEditFormFactoryBasic : IPhysicalPersonInfoEditFormFactory { public System.Windows.Forms.Form SpawnInstance() { return new SimpleObjectForm<PhysicalPersonInfo>(); } }

    public class PhysicalPersonInfoEditFormFactoryBasicEx : IPhysicalPersonInfoEditFormFactory
    {
        public System.Windows.Forms.Form SpawnInstance()
        {
            LookupObjectForm<PhysicalPersonInfo> frm = new LookupObjectForm<PhysicalPersonInfo>();
            frm.NeedToCompareObjects += new NeedToCompareTypesHandler<PhysicalPersonInfo>(frm_NeedToCompareObjects);
            IQuestionnaire questio = TypeEditorsDispatcher.LastQuestionnaire;
            if (questio != null && questio is IGenericPersonsService)
            {
                IEnumerable<GenericPersonInfo> gpis = ((IGenericPersonsService)questio).MentionedGenericPersons;
                List<PhysicalPersonInfo> ppis = new List<PhysicalPersonInfo>();
                foreach(GenericPersonInfo gpi in gpis)
                {
                    if(gpi.PersonType == Core.Spares.EntityType.Physical && gpi.PhysicalPerson != null)
                        ppis.Add(gpi.PhysicalPerson);
                }

                frm.ListSource = ppis;
            }
            return frm;
        }

        private void frm_NeedToCompareObjects(object sender, NeedToCompareTypesArgs<PhysicalPersonInfo> args)
        {
            args.AreEqual = (args.One.GenericID == args.Two.GenericID);
        }
    }

    public class RegistrarAuthorityEditFormFactoryBasic : IRegistrarAuthorityEditFormFactory { public System.Windows.Forms.Form SpawnInstance() { return new SimpleObjectForm<RegistrarAuthority>(); } }

    //p.II
    public class BreachOfLawRecordInfoEditFormFactoryBasic : IBreachOfLawRecordInfoEditFormFactory { public System.Windows.Forms.Form SpawnInstance() { return new SimpleObjectForm<BreachOfLawRecordInfo>(); } }
    public class EducationRecordInfoEditFormFactoryBasic : IEducationRecordInfoEditFormFactory { public System.Windows.Forms.Form SpawnInstance() { return new SimpleObjectForm<EducationRecordInfo>(); } }
    public class EmploymentRecordInfoEditFormFactoryBasic : IEmploymentRecordInfoEditFormFactory { public System.Windows.Forms.Form SpawnInstance() { return new SimpleObjectForm<EmploymentRecordInfo>(); } }
    public class FinancialGuaranteeInfoEditFormFactoryBasic : IFinancialGuaranteeInfoEditFormFactory { public System.Windows.Forms.Form SpawnInstance() { return new SimpleObjectForm<FinancialGuaranteeInfo>(); } }
    public class IncomeOriginInfoEditFormFactoryBasic : IIncomeOriginInfoEditFormFactory { public System.Windows.Forms.Form SpawnInstance() { return new SimpleObjectForm<IncomeOriginInfo>(); } }
    public class IndebtnessInfoEditFormFactoryBasic : IIndebtnessInfoEditFormFactory { public System.Windows.Forms.Form SpawnInstance() { return new SimpleObjectForm<IndebtnessInfo>(); } }
    public class IndebtnessInfoBaseEditFormFactoryBasic : IIndebtnessInfoBaseEditFormFactory { public System.Windows.Forms.Form SpawnInstance() { return new SimpleObjectForm<IndebtnessInfoBase>(); } }
    public class LiquidatedEntityOwnershipInfoEditFormFactoryBasic : ILiquidatedEntityOwnershipInfoEditFormFactory { public System.Windows.Forms.Form SpawnInstance() { return new SimpleObjectForm<LiquidatedEntityOwnershipInfo>(); } }
    public class LoanInfoEditFormFactoryBasic : ILoanInfoEditFormFactory { public System.Windows.Forms.Form SpawnInstance() { return new SimpleObjectForm<LoanInfo>(); } }
    public class PaymentDeadlineInfoEditFormFactoryBasic : IPaymentDeadlineInfoEditFormFactory { public System.Windows.Forms.Form SpawnInstance() { return new SimpleObjectForm<PaymentDeadlineInfo>(); } }
    public class PaymentModeInfoEditFormFactoryBasic : IPaymentModeInfoEditFormFactory { public System.Windows.Forms.Form SpawnInstance() { return new SimpleObjectForm<PaymentModeInfo>(); } }
    public class ProfessionLicenseInfoEditFormFactoryBasic : IProfessionLicenseInfoEditFormFactory { public System.Windows.Forms.Form SpawnInstance() { return new SimpleObjectForm<ProfessionLicenseInfo>(); } }
    public class SharesAcquisitionInfoEditFormFactoryBasic : ISharesAcquisitionInfoEditFormFactory { public System.Windows.Forms.Form SpawnInstance() { return new SimpleObjectForm<SharesAcquisitionInfo>(); } }
    public class BankAccountInfoEditFormFactoryBasic : IBankAccountInfoEditFormFactory { public System.Windows.Forms.Form SpawnInstance() { return new SimpleObjectForm<BankAccountInfo>(); } }
    public class ProfessionLicensingBodyInfoEditFormFactoryBasic : IProfessionLicensingBodyInfoEditFormFactory { public System.Windows.Forms.Form SpawnInstance() { return new SimpleObjectForm<ProfessionLicensingBodyInfo>(); } }
    public class PublicationInfoEditFormFactoryBasic : IPublicationInfoEditFormFactory { public System.Windows.Forms.Form SpawnInstance() { return new SimpleObjectForm<PublicationInfo>(); } }
    public class PublishingHouseInfoEditFormFactoryBasic : IPublishingHouseInfoEditFormFactory { public System.Windows.Forms.Form SpawnInstance() { return new SimpleObjectForm<PublishingHouseInfo>(); } }
    public class UniversityOrCollegeInfoEditFormFactoryBasic : IUniversityOrCollegeInfoEditFormFactory { public System.Windows.Forms.Form SpawnInstance() { return new SimpleObjectForm<UniversityOrCollegeInfo>(); } }
    public class FinancialOversightAuthorityInfoEditFormFactoryBasic : IFinancialOversightAuthorityInfoEditFormFactory { public System.Windows.Forms.Form SpawnInstance() { return new SimpleObjectForm<FinancialOversightAuthorityInfo>(); } }

}

