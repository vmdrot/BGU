using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BGU.DRPL.SignificantOwnership.Core.EKDRBU.Spares.TextualFinBankOpsSvc
{
    public class FinBankOpSvcTextualInfo
    {
        public FinBankOpSvcTextualInfo() { }
        public FinBankOpSvcTextualInfo( string nrLtrBullet, string text)
        {
            this.NrLtrBullet = nrLtrBullet;
            this.Text = text;
        }
        
        public string NrLtrBullet { get; set; }
        public string Text { get; set; }
        public List<FinBankOpSvcTextualInfo> PartialOpsSvcs { get; set; }
    }
}
