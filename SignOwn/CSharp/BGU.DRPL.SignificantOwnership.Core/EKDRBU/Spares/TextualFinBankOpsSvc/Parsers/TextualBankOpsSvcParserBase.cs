using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BGU.DRPL.SignificantOwnership.Core.EKDRBU.Spares.TextualFinBankOpsSvc.Parsers
{
    public abstract class TextualBankOpsSvcParserBase
    {
        public abstract BranchFinOpSvcTextualInfo Parse(string opsSvcsRaw);
    }
}
