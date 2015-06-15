using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    public class LegalTransactionInfo
    {
        public LegalTransactionType TransactionType { get; set; }
        public string TransactionNr { get; set; }
        public DateTime TransactionDate { get; set; }
        public List<GenericPersonID> Parties { get; set; }
        public string TransactionText { get; set; }
    }
}
