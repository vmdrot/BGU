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
        /// Заповнювати одне з полів: ActivityType, ServiceType, GFXActivityType SMActivityType
        /// (але не більше одного одразу).
        /// Одне з цих полів, де жорстко обмежується фантазія банку, є обов'язковим; 
        /// У текстовому полі хай пишуть власну інтерпретацію (якщо захочуть), але первинною
        /// є ідентифікація виду діяльності чи послуг згідно з однозначним переліком, що
        /// його прописано у законодавстві
        /// </summary>
        [DisplayName("Вид банківської діяльності")]
        [Description("Вид банківської діяльності зг. зі ст.47 з-ну про Банки й банківську діяльність")]
        public BankingActivityType ActivityType { get; set; }
        
        /// <summary>
        /// Заповнювати одне з полів: ActivityType, ServiceType, GFXActivityType SMActivityType
        /// (але не більше одного одразу).
        /// </summary>
        /// <seealso cref="ActivityType"/>
        [DisplayName("Вид фінансових послуг")]
        [Description("Вид фінансових послуг зг. зі ст. 4 з-ну Про фінансові послуги")]
        public FinancialServicesType ServiceType { get; set; }

        /// <summary>
        /// Заповнювати одне з полів: ActivityType, ServiceType, GFXActivityType SMActivityType
        /// (але не більше одного одразу).
        /// </summary>
        /// <seealso cref="ActivityType"/>
        [DisplayName("Вид діяльності (ген.ліцензія)")]
        [Description("Вид банківської діяльності зг. з генеральною банківською діяльністю")]
        public GeneralFXLicenseActivityType GFXActivityType { get; set; }

        /// <summary>
        /// Заповнювати одне з полів: ActivityType, ServiceType, GFXActivityType SMActivityType
        /// (але не більше одного одразу).
        /// </summary>
        /// <seealso cref="ActivityType"/>
        [DisplayName("Вид проф.д-ті на ФР")]
        [Description("Вид професійної діяльності на фондовому ринку")]
        public ProfessionalStockMarketActivityType SMActivityType { get; set; }


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

        public static BankingLicensedActivityInfo None { get { return new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.FinancialService, ServiceType = FinancialServicesType.None }; } }
        public static BankingLicensedActivityInfo PayDocsIssuance { get { return new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.FinancialService, ServiceType = FinancialServicesType.PayDocsIssuance }; } }
        public static BankingLicensedActivityInfo Trust { get { return new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.FinancialService, ServiceType = FinancialServicesType.Trust }; } }
        public static BankingLicensedActivityInfo CurrencyExchange { get { return new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.FinancialService, ServiceType = FinancialServicesType.CurrencyExchange }; } }
        public static BankingLicensedActivityInfo FinanceAssetsLiabilities { get { return new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.FinancialService, ServiceType = FinancialServicesType.FinanceAssetsLiabilities }; } }
        public static BankingLicensedActivityInfo FinancialLeasing { get { return new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.FinancialService, ServiceType = FinancialServicesType.FinancialLeasing }; } }
        public static BankingLicensedActivityInfo Lending { get { return new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.FinancialService, ServiceType = FinancialServicesType.Lending }; } }
        public static BankingLicensedActivityInfo Guarantees { get { return new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.FinancialService, ServiceType = FinancialServicesType.Guarantees }; } }
        public static BankingLicensedActivityInfo FundsTransfer { get { return new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.FinancialService, ServiceType = FinancialServicesType.FundsTransfer }; } }
        public static BankingLicensedActivityInfo InsuranceAndPensionSavings { get { return new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.FinancialService, ServiceType = FinancialServicesType.InsuranceAndPensionSavings }; } }
        public static BankingLicensedActivityInfo StockExchangeActivities { get { return new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.FinancialService, ServiceType = FinancialServicesType.StockExchangeActivities }; } }
        public static BankingLicensedActivityInfo Factoring { get { return new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.FinancialService, ServiceType = FinancialServicesType.Factoring }; } }
        public static BankingLicensedActivityInfo FinAssetsAdministeringGroupsPurchase { get { return new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.FinancialService, ServiceType = FinancialServicesType.FinAssetsAdministeringGroupsPurchase }; } }
        public static BankingLicensedActivityInfo ConstructionAssetsManagement { get { return new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.FinancialService, ServiceType = FinancialServicesType.ConstructionAssetsManagement }; } }
        public static BankingLicensedActivityInfo MortgageSecuritiesMngtIssue { get { return new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.FinancialService, ServiceType = FinancialServicesType.MortgageSecuritiesMngtIssue }; } }
        public static BankingLicensedActivityInfo OtherFinBankServices { get { return new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.FinancialService, ServiceType = FinancialServicesType.OtherFinBankServices }; } }

        public static BankingLicensedActivityInfo DepositsTaking { get { return new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.BankingActivity, ActivityType = BankingActivityType.DepositsTaking }; } }
        public static BankingLicensedActivityInfo AccountsMgmt { get { return new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.BankingActivity, ActivityType = BankingActivityType.AccountsMgmt }; } }
        public static BankingLicensedActivityInfo DepositedFundsPlacement { get { return new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.BankingActivity, ActivityType = BankingActivityType.DepositedFundsPlacement }; } }
        public static BankingLicensedActivityInfo Investments { get { return new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.BankingActivity, ActivityType = BankingActivityType.Investments }; } }
        public static BankingLicensedActivityInfo ProprietarySecuritiesIssue { get { return new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.BankingActivity, ActivityType = BankingActivityType.ProprietarySecuritiesIssue }; } }
        public static BankingLicensedActivityInfo Lotteries { get { return new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.BankingActivity, ActivityType = BankingActivityType.Lotteries }; } }
        public static BankingLicensedActivityInfo SafeCustody { get { return new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.BankingActivity, ActivityType = BankingActivityType.SafeCustody }; } }
        public static BankingLicensedActivityInfo CashCollectionTransportation { get { return new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.BankingActivity, ActivityType = BankingActivityType.CashCollectionTransportation }; } }
        public static BankingLicensedActivityInfo SecuritiesCustody { get { return new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.BankingActivity, ActivityType = BankingActivityType.SecuritiesCustody }; } }
        public static BankingLicensedActivityInfo ConsultancyOnBankFinServices { get { return new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.BankingActivity, ActivityType = BankingActivityType.ConsultancyOnBankFinServices }; } }

        public static BankingLicensedActivityInfo GFX_NonTrade { get { return new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.FXGLBkActivity, GFXActivityType = GeneralFXLicenseActivityType.GFX_NonTrade }; } }
        public static BankingLicensedActivityInfo GFX_CashBankOps { get { return new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.FXGLBkActivity, GFXActivityType = GeneralFXLicenseActivityType.GFX_CashBankOps }; } }
        public static BankingLicensedActivityInfo GFX_CashAgentOps { get { return new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.FXGLBkActivity, GFXActivityType = GeneralFXLicenseActivityType.GFX_CashAgentOps }; } }
        public static BankingLicensedActivityInfo GFX_AcctMgmt { get { return new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.FXGLBkActivity, GFXActivityType = GeneralFXLicenseActivityType.GFX_AcctMgmt }; } }
        public static BankingLicensedActivityInfo GFX_CorrBkAcctMgmtFCCY { get { return new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.FXGLBkActivity, GFXActivityType = GeneralFXLicenseActivityType.GFX_CorrBkAcctMgmtFCCY }; } }
        public static BankingLicensedActivityInfo GFX_CorrBkAcctMgmtLCCY { get { return new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.FXGLBkActivity, GFXActivityType = GeneralFXLicenseActivityType.GFX_CorrBkAcctMgmtLCCY }; } }
        public static BankingLicensedActivityInfo GFX_CorrAcctHaveInUABksFCCY { get { return new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.FXGLBkActivity, GFXActivityType = GeneralFXLicenseActivityType.GFX_CorrAcctHaveInUABksFCCY }; } }
        public static BankingLicensedActivityInfo GFX_CorrAcctHaveInNonUABksFCCY { get { return new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.FXGLBkActivity, GFXActivityType = GeneralFXLicenseActivityType.GFX_CorrAcctHaveInNonUABksFCCY }; } }
        public static BankingLicensedActivityInfo GFX_FCCYBorrNPlaceLocalMarket { get { return new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.FXGLBkActivity, GFXActivityType = GeneralFXLicenseActivityType.GFX_FCCYBorrNPlaceLocalMarket }; } }
        public static BankingLicensedActivityInfo GFX_FCCYBorrNPlaceWorldMarket { get { return new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.FXGLBkActivity, GFXActivityType = GeneralFXLicenseActivityType.GFX_FCCYBorrNPlaceWorldMarket }; } }
        public static BankingLicensedActivityInfo GFX_FCCYTradingNonCashLocalMarket { get { return new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.FXGLBkActivity, GFXActivityType = GeneralFXLicenseActivityType.GFX_FCCYTradingNonCashLocalMarket }; } }
        public static BankingLicensedActivityInfo GFX_FCCYTradingNonCashWorldMarket { get { return new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.FXGLBkActivity, GFXActivityType = GeneralFXLicenseActivityType.GFX_FCCYTradingNonCashWorldMarket }; } }
        public static BankingLicensedActivityInfo GFX_BkMetalBorrNPlaceLocalMarket { get { return new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.FXGLBkActivity, GFXActivityType = GeneralFXLicenseActivityType.GFX_BkMetalBorrNPlaceLocalMarket }; } }
        public static BankingLicensedActivityInfo GFX_BkMetalBorrNPlaceWorldMarket { get { return new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.FXGLBkActivity, GFXActivityType = GeneralFXLicenseActivityType.GFX_BkMetalBorrNPlaceWorldMarket }; } }
        public static BankingLicensedActivityInfo GFX_BkMetalTradingLocalMarket { get { return new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.FXGLBkActivity, GFXActivityType = GeneralFXLicenseActivityType.GFX_BkMetalTradingLocalMarket }; } }
        public static BankingLicensedActivityInfo GFX_BkMetalTradingWorldMarket { get { return new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.FXGLBkActivity, GFXActivityType = GeneralFXLicenseActivityType.GFX_BkMetalTradingWorldMarket }; } }
        public static BankingLicensedActivityInfo GFX_FinSvcLocalMarket { get { return new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.FXGLBkActivity, GFXActivityType = GeneralFXLicenseActivityType.GFX_FinSvcLocalMarket }; } }
        public static BankingLicensedActivityInfo GFX_FinSvcWorldMarket { get { return new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.FXGLBkActivity, GFXActivityType = GeneralFXLicenseActivityType.GFX_FinSvcWorldMarket }; } }

        public static BankingLicensedActivityInfo SMSecuritiesTrading { get { return new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.SMActivityType, SMActivityType = ProfessionalStockMarketActivityType.SMSecuritiesTrading }; } }
        public static BankingLicensedActivityInfo SMInstInvAssetsMgmt { get { return new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.SMActivityType, SMActivityType = ProfessionalStockMarketActivityType.SMInstInvAssetsMgmt }; } }
        public static BankingLicensedActivityInfo SMDepositoryActivities { get { return new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.SMActivityType, SMActivityType = ProfessionalStockMarketActivityType.SMDepositoryActivities }; } }
        public static BankingLicensedActivityInfo SMTradeOrganization { get { return new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.SMActivityType, SMActivityType = ProfessionalStockMarketActivityType.SMTradeOrganization }; } }
        public static BankingLicensedActivityInfo SMClearing { get { return new BankingLicensedActivityInfo() { BankActivityOrService = LicensedOperationType.SMActivityType, SMActivityType = ProfessionalStockMarketActivityType.SMClearing }; } }

        #endregion
    }
}
