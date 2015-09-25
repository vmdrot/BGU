using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BGU.DRPL.SignificantOwnership.EmpiricalData.Scraping.Data;
using Newtonsoft.Json;
using System.IO;

namespace BGU.DRPL.SignificantOwnership.Tests.PdfWord
{
    [TestFixture]
    public class BGUSiteReaderTests
    {
        [Test]
        public void MFOParserTest()
        {
            List<BGUBankOwnStructInfo> osis = JsonConvert.DeserializeObject<List<BGUBankOwnStructInfo>>(File.ReadAllText(@"D:\home\vmdrot\BGU\Var\VisaLiberalization\SrcData\BankStructs_Hist.json"));
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;
            settings.Formatting = Formatting.Indented;
            Console.WriteLine(JsonConvert.SerializeObject(osis, settings));
        }

        [Test]
        public void BGUOwnStructsStatsTest()
        {
            List<BGUBankOwnStructInfo> osis = JsonConvert.DeserializeObject<List<BGUBankOwnStructInfo>>(File.ReadAllText(@"D:\home\vmdrot\BGU\Var\VisaLiberalization\SrcData\BankStructs_Hist.json"));
            foreach (BGUBankOwnStructInfo osi in osis)
            {
                foreach(BankOwnStructVersionInfo osiv in osi.OwnershipStructureVersions)
                    osiv.MFO = osi.MFO;
            }
            List<BankOwnStructVersionInfo> versions = new List<BankOwnStructVersionInfo>();
            foreach (BGUBankOwnStructInfo osi in osis)
                versions.AddRange(osi.OwnershipStructureVersions);
            DateTime d0 = new DateTime(2014,1,1);
            DateTime d0a0 = new DateTime(2014, 5, 1);
            DateTime d0a = new DateTime(2014,9,1);
            DateTime d1 = new DateTime(2015,1,1);
            DateTime d1a0 = new DateTime(2015, 5, 1);
            DateTime d1a = new DateTime(2015,9,1);
            DateTime d2 = new DateTime(2016,1,1);

            var versions2014 = from a in versions
                               where a.AsOf >= d0 && a.AsOf < d1
                               select a;
            var versions2015 = from a in versions
                               where a.AsOf >= d1 && a.AsOf < d2
                               select a;

            var versions2014a = from a in versions
                               where a.AsOf >= d0 && a.AsOf < d0a
                               select a;
            var versions2015a = from a in versions
                               where a.AsOf >= d1 && a.AsOf < d1a
                               select a;

            var versions2014a0 = from a in versions
                                where a.AsOf >= d0a0 && a.AsOf < d0a
                                select a;
            var versions2015a0 = from a in versions
                                where a.AsOf >= d1a0 && a.AsOf < d1a
                                select a;


            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;
            settings.Formatting = Formatting.Indented;
            //Console.WriteLine(JsonConvert.SerializeObject(osis, settings));
            Console.WriteLine(versions2014.Count());
            Console.WriteLine(versions2015.Count());
            Console.WriteLine(versions2014a.Count());
            Console.WriteLine(versions2015a.Count());

            Console.WriteLine(versions2014a0.Count());
            Console.WriteLine(versions2015a0.Count());

            //Console.WriteLine(JsonConvert.SerializeObject(versions2014, settings));
            //Console.WriteLine(JsonConvert.SerializeObject(versions2015, settings));
            //Console.WriteLine(JsonConvert.SerializeObject(versions2014a, settings));
            //Console.WriteLine(JsonConvert.SerializeObject(versions2015a, settings));
        }

    }
}
