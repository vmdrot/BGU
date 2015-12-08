using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BGU.DRPL.SignificantOwnership.Core.EKDRBU.Spares.TextualFinBankOpsSvc
{
    public class FinBankOpSvcTextualInfo
    {
        public string NrLtrBullet { get; set; }
        public string Text { get; set; }
        public List<FinBankOpSvcTextualInfo> PartialOpsSvcs { get; set; }
    }
}
