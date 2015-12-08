using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BGU.DRPL.SignificantOwnership.Core.EKDRBU.Spares.TextualFinBankOpsSvc.Parsers
{
    public class TextualBankOpsSvcParser_AlfaBank : TextualBankOpsSvcParserBase
    {
        protected static readonly Regex LINES_SPLITTER_RGX = new Regex("[\r\n]+",RegexOptions.Multiline | RegexOptions.IgnoreCase);
        protected static readonly Regex NR_LTR_BLT_SPLITTER_RGX = new Regex("[0-9\\.]+[\\.\\)]{1}", RegexOptions.Multiline | RegexOptions.IgnoreCase);

        public override BranchFinOpSvcTextualInfo Parse(string opsSvcsRaw)
        {
            BranchFinOpSvcTextualInfo rslt = new BranchFinOpSvcTextualInfo();
            string[] lines = LINES_SPLITTER_RGX.Split(opsSvcsRaw);
            Console.WriteLine("lines.Length = {0}", lines.Length);
            foreach (string line in lines)
            {
                Console.WriteLine(line);
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            }
            Console.WriteLine("-------------------------------------------------------------------------------");
            string[] lines2 = NR_LTR_BLT_SPLITTER_RGX.Split(opsSvcsRaw);
            Console.WriteLine("lines2.Length = {0}", lines2.Length);
            foreach (string line in lines2)
            {
                Console.WriteLine(line);
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            }

            return rslt;
        }
    }
}
