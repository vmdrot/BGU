using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace BGU.DRPL.SignificantOwnership.Core.Spares2
{
    [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.EnumLookupEditor), typeof(System.Drawing.Design.UITypeEditor))]
    [Flags]
    public enum FinancialInstitutionType
    {
        [Description("Не вказано")]
        None = 0,
        [Description("НБУ")]
        CentralBank,
        [Description("Комерційний банк")]
        Bank,
        [Description("Небанківська фінустанова")]
        NonBank
    }

    [Flags]
    public enum FinancialInstitutionStatus
    {
        [Description("Не вказано")]
        None = 0,
        [Description("Діюча")]
        Active,
        [Description("Проблемна")]
        Problem,
        [Description("У тимчасовій адміністрації")]
        UnderTemporaryCommission,
        [Description("Ліквідаційна комісія")]
        UnderLiquidation,
        [Description("Ліквідовано")]
        Liquidated,
        [Description("Перейменовано")]
        Renamed,
        [Description("Поглинання")]
        Acquired,
        [Description("Злиття")]
        Merged
    }

    [Flags]
    public enum CompanyOwnershipType
    {
        [Description("Не вказано")]
        None = 0,
        [Description("Приватна")]
        Private,
        [Description("Державна")]
        State,
        [Description("Котирується на фондовій біржі")]
        PubliclyTraded
    }

    [Description("Рівень установи")]
    public enum InstitutionLevel
    {
        [Description("Не вказано")]
        None = 0,
        [Description("Головна контора")]
        HeadOffice,
        [Description("Філія")]
        Branch,
        [Description("ТВБВ")]
        TVBV,
        [Description("Обмінний пункт")]
        ForexOutlet,
        [Description("Банкомат")]
        ATM
    }

}