using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.EKDRBU
{
    [HideInXSD]
    public class ActualEKDRBUStructsUnion
    {
        public StateBankBranchRegistryChangePackageV1 ChangePkgV1 { get; set; }
        public StateBankBranchRegistryChangePackageResponseV1 ChangePkgResponseV1 { get; set; }
    }
}
