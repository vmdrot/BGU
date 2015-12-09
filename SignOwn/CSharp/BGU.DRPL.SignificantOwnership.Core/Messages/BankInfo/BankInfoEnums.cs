using System;
using System.ComponentModel;
namespace BGU.DRPL.SignificantOwnership.Core.Messages.BankInfo
{ 
    public enum BankInfoMessageField
    {
        [Description("Не вказано")]
        None = 0,
        [Description("Назва (254 символів)")]
        NameFull,
        [Description("Скорочена назва (80 символів)")]
        NameShort,
        [Description("Назва для друку (40 символів)")]
        NamePrint,
        [Description("Назва для СЕП (38 символів)")]
        NameSEP,
        [Description("Назва для СТАТЗВІТНОСТІ (27 символів)")]
        NameStats,
        [Description("реєстраційний номер")]
        RegNr,
        [Description("внутрішньобанківський номер")]
        InternalNr,
        [Description("номер підрозділу за внутрішньобанківським номером")]
        BranchNrInternal,
        [Description("дата відкриття")]
        OpenDate,
        [Description("дата внесення до Державного реєстру банків")]
        RegisteredDate,
        [Description("область або код області")]
        Oblast,
        [Description("назва району")]
        Raion,
        [Description("тип та назва населеного пункту")]
        Town,
        [Description("адреса")]
        Address,
        [Description("поштовий індекс")]
        ZipCode,
        [Description("код телефонного зв’язку")]
        DialCode,
        [Description("телефон(-и)")]
        Phone,
        [Description("факс(-и)")]
        Fax,
        [Description("e-mail(-и)")]
        Email,
        [Description("веб-сайт")]
        www,
        [Description("посада")]
        MgrPosition,
        [Description("прізвище")]
        MgrSurname,
        [Description("ім’я")]
        MgrName,
        [Description("по-батькові")]
        MgrPatronymic,
        [Description("номер платіжного документа")]
        PayDocNr,
        [Description("дата здійснення оплати")]
        PayDocDate,
        [Description("дата внесення")]
        InputDate,
        [Description("короткий опис змін")]
        ShortChangesLog,
        [Description("Стан")]
        Status,
        [Description("Дата закриття")]
        ClosedDate,
        [Description("Дата виключення з Державного реєстру банків")]
        UnregisteredDate,
        [Description("Перелік операцій")]
        OperationsListing,
        [Description("Рішення, на підставі якого вносяться зміни")]
        Attachement_Resolution,
    }

    public enum FinActivitySvcInstrumentType
    {
        None = 0,
        //Поточні рахунки клієнтів
        CurrentAccount,
        //Дебітові картки
        DebitCard,
        //Кредитні картки
        CreditCard,
        //Дорожні чеки
        TravellerChecks,
        //Міжбанківські депозити
        InterbankDeposit,
        //Банківські метали
        PreciousMetal,
        //Банківські метали з фізичною доставкою
        PreciousMetalWithPhysDelivery,
        //Міжбанківські кредити
        InterbankLoans,
        //Банківські сейфи
        BankSafe,
        //todo
    }

    public enum FinActivitySvcInstrumentActionType
    {
        None = 0,
        //Випуск, емісія
        Issuance,
        //Обслуговування
        Servicing,
        //Зарахування, внесення
        Installment,
        //Зняття
        Withdrawal,
        //Відкриття
        Opening,
        //Надання в оренду
        Rental,
        //Зняття готівки за допомогою POS-терміналу
        CashAdvancePOS
        //todo
    }
}
