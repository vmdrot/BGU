using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using BGU.DRPL.SignificantOwnership.Utility;
using System.Xml.Serialization;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Інформація вид банківської діяльності/фін. послугу
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.BankingLicensedActivityInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class BankingLicensedActivityInfo
    {
        [DisplayName("Тип")]
        [Description("Вкажіть, це буде вид банківської діяльності чи послуга")]
        public LicensedOperationType BankActivityOrService { get; set; }
        
        /// <summary>
        /// Заповнювати або це поле, або ж ServiceType
        /// (але не обидва одразу).
        /// Одне з цих полів, де жорстко обмежується фантазія банку, є обов'язковим; 
        /// У текстовому полі хай пишуть власну інтерпретацію (якщо захочуть), але первинною
        /// є ідентифікація виду діяльності чи послуг згідно з однозначним переліком, що
        /// його прописано у законодавстві
        /// </summary>
        [DisplayName("Вид банківської діяльності")]
        [Description("Вид банківської діяльності зг. зі ст.47 з-ну про Банки й банківську діяльність")]
        public BankingActivityType ActivityType { get; set; }
        /// <summary>
        /// Заповнювати або це поле, або ж ActivityType 
        /// </summary>
        /// <seealso cref="ActivityType"/>
        [DisplayName("Вид фінансових послуг")]
        [Description("Вид фінансових послуг зг. зі ст. 4 з-ну Про фінансові послуги")]
        public FinancialServicesType ServiceType { get; set; }

        [Browsable(false)]
        [XmlIgnore]
        public String ActivityDisplayName
        {
            get
            {
                return (BankActivityOrService == Core.Spares.LicensedOperationType.BankingActivity ? EnumType.GetEnumDescription(ActivityType) : EnumType.GetEnumDescription(ServiceType));
            }
        }
        /// <summary>
        /// Власна вільна інтерпретація чи примітки/опис виду діяльності (якщо є чим доповнити поле ActivityType чи ServiceType
        /// </summary>
        /// <seealso cref="ActivityType"/>
        [DisplayName("Вид діяльності - власна інтерпретація")]
        [Description("Власна назва та/або опис виду діяльності")]
        public string ActivityName { get; set; }

        public override string ToString()
        {
            return ActivityName;
        }

        #region static member(s)
        public static readonly BankingLicensedActivityInfo PayDocsIssuance = new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.FinancialService, ServiceType = FinancialServicesType.PayDocsIssuance };
        public static readonly BankingLicensedActivityInfo Trust = new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.FinancialService, ServiceType = FinancialServicesType.Trust };
        public static readonly BankingLicensedActivityInfo CurrencyExchange = new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.FinancialService, ServiceType = FinancialServicesType.CurrencyExchange };
        public static readonly BankingLicensedActivityInfo FinanceAssetsLiabilities = new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.FinancialService, ServiceType = FinancialServicesType.FinanceAssetsLiabilities };
        public static readonly BankingLicensedActivityInfo FinancialLeasing = new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.FinancialService, ServiceType = FinancialServicesType.FinancialLeasing };
        public static readonly BankingLicensedActivityInfo Lending = new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.FinancialService, ServiceType = FinancialServicesType.Lending };
        public static readonly BankingLicensedActivityInfo Guarantees = new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.FinancialService, ServiceType = FinancialServicesType.Guarantees };
        public static readonly BankingLicensedActivityInfo FundsTransfer = new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.FinancialService, ServiceType = FinancialServicesType.FundsTransfer };
        public static readonly BankingLicensedActivityInfo InsuranceAndPensionSavings = new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.FinancialService, ServiceType = FinancialServicesType.InsuranceAndPensionSavings };
        public static readonly BankingLicensedActivityInfo StockExchangeActivities = new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.FinancialService, ServiceType = FinancialServicesType.StockExchangeActivities };
        public static readonly BankingLicensedActivityInfo Factoring = new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.FinancialService, ServiceType = FinancialServicesType.Factoring };
        public static readonly BankingLicensedActivityInfo FinAssetsAdministeringGroupsPurchase = new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.FinancialService, ServiceType = FinancialServicesType.FinAssetsAdministeringGroupsPurchase };
        public static readonly BankingLicensedActivityInfo ConstructionAssetsManagement = new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.FinancialService, ServiceType = FinancialServicesType.ConstructionAssetsManagement };
        public static readonly BankingLicensedActivityInfo MortgageSecuritiesMngtIssue = new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.FinancialService, ServiceType = FinancialServicesType.MortgageSecuritiesMngtIssue };
        public static readonly BankingLicensedActivityInfo OtherFinBankServices = new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.FinancialService, ServiceType = FinancialServicesType.OtherFinBankServices };
        public static readonly BankingLicensedActivityInfo DepositsTaking = new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.BankingActivity, ActivityType = BankingActivityType.DepositsTaking };
        public static readonly BankingLicensedActivityInfo AccountsMgmt = new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.BankingActivity, ActivityType = BankingActivityType.AccountsMgmt };
        public static readonly BankingLicensedActivityInfo DepositedFundsPlacement = new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.BankingActivity, ActivityType = BankingActivityType.DepositedFundsPlacement };
        public static readonly BankingLicensedActivityInfo Investments = new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.BankingActivity, ActivityType = BankingActivityType.Investments };
        public static readonly BankingLicensedActivityInfo ProprietarySecuritiesIssue = new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.BankingActivity, ActivityType = BankingActivityType.ProprietarySecuritiesIssue };
        public static readonly BankingLicensedActivityInfo Lotteries = new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.BankingActivity, ActivityType = BankingActivityType.Lotteries };
        public static readonly BankingLicensedActivityInfo SafeCustody = new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.BankingActivity, ActivityType = BankingActivityType.SafeCustody };
        public static readonly BankingLicensedActivityInfo CashCollectionTransportation = new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.BankingActivity, ActivityType = BankingActivityType.CashCollectionTransportation };
        public static readonly BankingLicensedActivityInfo SecuritiesCustody = new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.BankingActivity, ActivityType = BankingActivityType.SecuritiesCustody };
        public static readonly BankingLicensedActivityInfo ConsultancyOnBankFinServices = new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.BankingActivity, ActivityType = BankingActivityType.ConsultancyOnBankFinServices };
        #endregion
    }
}
