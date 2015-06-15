using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BGU.Web20.MiscItemsSite
{
    [Flags]
    public enum InstitutionType
    {
        None = 0,
        Bank,
        NonBankFinancial
    }

    [Flags]
    public enum InstitutionStatus
    {
        None = 0,
        Operational,
        Problem,
        Insolvent,
        CrisisAdministration,
        UnderLiquidation,
        Liquidated
    }

    public enum InstitutionLevel
    {
        None = 0,
        TopLevel,
        Branch,
        Outlet,
        ATM,
        POS
    }
}
