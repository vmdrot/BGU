using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BGU.DRPL.SignificantOwnership.Core.EKDRBU.Spares
{
    public class BankBranchOpsFinSvcCompleteInfo
    {
        public BankBranchOpsFinSvcCompleteInfo()
        {
            this.AllowedOpsSvcs = new List<BankBranchOperationInfo>();
            this.ExceptOpsSvcs = new List<BankBranchOperationInfo>();
            this.OptionalOpsSvcs = new List<BankBranchOperationInfo>();
        }
        
        public List<BankBranchOperationInfo> AllowedOpsSvcs { get; set; }
        public List<BankBranchOperationInfo> ExceptOpsSvcs { get; set; }
        public List<BankBranchOperationInfo> OptionalOpsSvcs { get; set; }

    }
}
