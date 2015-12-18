using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.EKDRBU.Spares.TextualFinBankOpsSvc;

namespace BGU.DRPL.SignificantOwnership.Core.EKDRBU.Spares
{
    public class BankBranchOpsFinSvcCompleteInfo
    {
        public BankBranchOpsFinSvcCompleteInfo()
        {
            this.AllowedOpsSvcs = new List<BankBranchOperationInfo>();
            this.ExceptOpsSvcs = new List<BankBranchOperationInfo>();
            this.OptionalOpsSvcs = new List<BankBranchOperationInfo>();
            this.Textuals = new List<FinBankOpSvcTextualInfo>();
        }

        public string SchemeNameCode { get; set; }
        public string SchemeDescriptionNotes { get; set; }
        public List<BankBranchOperationInfo> AllowedOpsSvcs { get; set; }
        public List<BankBranchOperationInfo> ExceptOpsSvcs { get; set; }
        public List<BankBranchOperationInfo> OptionalOpsSvcs { get; set; }
        public List<FinBankOpSvcTextualInfo> Textuals { get; set; }
    }
}
