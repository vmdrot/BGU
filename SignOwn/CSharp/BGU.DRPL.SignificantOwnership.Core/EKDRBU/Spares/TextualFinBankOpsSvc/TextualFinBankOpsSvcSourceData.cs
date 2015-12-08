using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BGU.DRPL.SignificantOwnership.Core.EKDRBU.Spares.TextualFinBankOpsSvc
{
    public class TextualFinBankOpsSvcSourceData
    {
        //№ п/п
        public int Ordinal { get; set; }
        //Банк
        public string BankName { get; set; }
        //Зміст схеми переліку операцій/послуг
        public string OpsSvcsRawText { get; set; }
        //Примітки (необов'язково)
        public string Notes { get; set; }
    }

    public class TextualFinBankOpsSvcSourceDataWrapper
    {
        public List<TextualFinBankOpsSvcSourceData> SourceData { get; set; }
    }
}
