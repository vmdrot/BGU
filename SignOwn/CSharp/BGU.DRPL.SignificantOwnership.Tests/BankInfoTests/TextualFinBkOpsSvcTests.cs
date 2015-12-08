using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BGU.DRPL.SignificantOwnership.Core.EKDRBU.Spares.TextualFinBankOpsSvc;
using BGU.DRPL.SignificantOwnership.Utility;
using BGU.DRPL.SignificantOwnership.Core.EKDRBU.Spares.TextualFinBankOpsSvc.Parsers;
using System.Text.RegularExpressions;

namespace BGU.DRPL.SignificantOwnership.Tests.BankInfoTests
{
    [TestFixture]
    public class TextualFinBkOpsSvcTests
    {
        [Test]
        public void ReadSourceDataTest()
        {
            TextualFinBankOpsSvcSourceDataWrapper src = Tools.ReadXML<TextualFinBankOpsSvcSourceDataWrapper>(@"D:\home\vmdrot\BGU\Var\DerzhReiestr\OpsFinSvcs\BGU-DRPL_-_Row9Appx15_Distinctive_list_ALL.xml");
            Console.WriteLine("src.SourceData.Count = {0}", src.SourceData.Count);
        }

        [Test]
        public void ParseAlfaBankTest()
        {
            TextualFinBankOpsSvcSourceDataWrapper src = Tools.ReadXML<TextualFinBankOpsSvcSourceDataWrapper>(@"D:\home\vmdrot\BGU\Var\DerzhReiestr\OpsFinSvcs\BGU-DRPL_-_Row9Appx15_Distinctive_list_ALL.xml");
            var alfas = from sd in src.SourceData
                        where sd.BankName == "ПАТ \"АЛЬФА-БАНК\""
                        select sd;
            TextualBankOpsSvcParser_AlfaBank parser = new TextualBankOpsSvcParser_AlfaBank();
            foreach (TextualFinBankOpsSvcSourceData sd in alfas)
            {
                parser.Parse(sd.OpsSvcsRawText);
                Console.WriteLine("====================================================================================");
            }
        }

        [Test]
        public void ParseRegexResearch()
        { 
            Regex NR_LTR_BLT_SPLITTER_RGX = new Regex("[0-9\\.]+[\\.\\)]{1}", RegexOptions.Multiline | RegexOptions.IgnoreCase);
            TextualFinBankOpsSvcSourceDataWrapper src = Tools.ReadXML<TextualFinBankOpsSvcSourceDataWrapper>(@"D:\home\vmdrot\BGU\Var\DerzhReiestr\OpsFinSvcs\BGU-DRPL_-_Row9Appx15_Distinctive_list_ALL.xml");
            var alfas = from sd in src.SourceData
                        where sd.BankName == "ПАТ \"АЛЬФА-БАНК\""
                        select sd;
            foreach( TextualFinBankOpsSvcSourceData sd in alfas)
            {
                MatchCollection ms = NR_LTR_BLT_SPLITTER_RGX.Matches(sd.OpsSvcsRawText);
                Console.WriteLine("ms.Count = {0}", ms.Count);
            }
            

        }
    }
}
