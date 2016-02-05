using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;
using BGU.DRPL.SignificantOwnership.Core.Spares;
using BGU.DRPL.SignificantOwnership.Core.FXLoansReg.Spares;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;
using System.ComponentModel;

namespace BGU.DRPL.SignificantOwnership.Core.FXLoansReg
{
    public class FXLoanInfo
    {
        [DisplayName("1. Назва договору, дата, номер")]
        public AgreementAttributes AgrAttrs { get; set; }
        [DisplayName("1. Додатки до договору")]
        [Description("1. Додатки, протоколи, тощо до договору")]
        public List<AgreementAttributes> AgrAppxs { get; set; }

        [DisplayName("1.1. Чи зареєстровано НБУ?")]
        [Description("1.1. Чи зареєстровано договір НБУ раніше, чи це новий договір?")]
        public bool IsNewAgreement { get; set; }

        [DisplayName("1.1. Зареєстровано НБУ")]
        [Description("1.1. Договір зареєстровано в Національному банку України за ...")]
        public NBURegistrationAttributes NBURegistrationMain { get; set; }

        [DisplayName("1.2. Зареєстровані зміни до договору")]
        [Description("1.2. Зареєстровані зміни до договору (дата, номер реєстрації змін до договору)")]
        public List<NBURegistrationAttributes> NBURegistrationAppxs { get; set; }


        [DisplayName("1.3. Документ змін")]
        [Description("1.3. Назва, дата, номер документа, на підставі якого вносяться зміни")]
        public AgreementAttributes DocToRegister { get; set; }

        [DisplayName("Відповідає пп.1.14, 1.18?")]
        [Description("Чи відповідає договір вимогам пп. 1.14, 1.18 глави 1 розділу I Положення про порядок отримання резидентами кредитів, позик в іноземній валюті ...")]
        public bool IsPP1418Agr { get; set; }

        [DisplayName("1.4. Документ про належність...")]
        [Description("1.4. Назва, дата, номер документа, що свідчить про належність договору до договорів, що відповідають вимогам пунктів 1.14, 1.18 глави 1 розділу I Положення про порядок отримання резидентами кредитів, позик в іноземній валюті від нерезидентів і надання резидентами позик в іноземній валюті нерезидентам:")]
        public AgreementAttributes EvidenceDocReqs { get; set; }

        [DisplayName("1.5. Відомості щодо анульованої реєстрації договору")]
        [Description("1.5. Відомості щодо анульованої реєстрації договору (заповнюються в разі потреби нової реєстрації договору замість анульованої): (номер і дата реєстрації договору та дата її анулювання)")]
        public NBURegistrationAttributes NBUUnregistrationReqs { get; set; }

        [DisplayName("2. Резидент-позичальник")]
        [Description("2. Відомості щодо резидента-позичальника")]
        public GenericPersonID Borrower { get; set; }

        [DisplayName("4. Нерезидент-кредитор")]
        [Description("4. Відомості щодо нерезидента-кредитора")]
        public GenericPersonID Creditor { get; set; }

        [DisplayName("3. Обслуговуючий банк")]
        [Description("")]
        public BankInfo AgentBank { get; set; }
        [DisplayName("3.2. Рахунок")]
        [Description("3.2. Реквізити банківського рахунку, за яким проводяться операції за договором")]
        public string AccountWithAgentBank { get; set; }

        [DisplayName("5.1.")]
        public bool IsBondsFinancedLoan {get;set;}
        public CurrencyAmount BondsFinancedLoanAmount { get; set; }

        [DisplayName("5.2.")]
        public bool IsSubordinatedLoan { get; set; }
        public CurrencyAmount SubordinatedLoanAmount { get; set; }

        [DisplayName("5.3.")]
        public bool IsSindicatedLoan { get; set; }
        public CurrencyAmount SindicatedLoanAmount { get; set; }

        [DisplayName("5.4.")]
        public bool IsOtherLoan { get; set; }
        public CurrencyAmount OtherLoanAmount { get; set; }

        //public string Loan // todo

        public InterestRateType RateType { get; set; }
        public decimal BaseRate { get; set; }
        public CurrencyAmount Principal { get; set; }
        public decimal InterestRate { get; set; }
        public DateTime RepaymentDate { get; set; }
        public List<FXLoanRepaymentScheduleEntry> RepaymentSchedule { get; set; }
        public List<GenericPersonInfo> MentionedIdentities { get; set; }
    }
}
