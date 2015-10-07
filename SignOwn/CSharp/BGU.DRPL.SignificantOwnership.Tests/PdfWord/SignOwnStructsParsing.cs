using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Newtonsoft.Json;
using System.IO;
using BGU.DRPL.SignificantOwnership.EmpiricalData.Scraping.Data;
using BGU.DRPL.SignificantOwnership.EmpiricalData.Scraping;
using BGU.DRPL.SignificantOwnership.Core.Questionnaires;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;

namespace BGU.DRPL.SignificantOwnership.Tests.PdfWord
{
    [TestFixture]
    public class SignOwnStructsParsing
    {
        [Test]
        public void RestoreFromJson()
        {
            List<List<string>> interestingRows = JsonConvert.DeserializeObject<List<List<string>>>(File.ReadAllText(@"D:\home\vmdrot\BGU\Specs\SignigicantOwnership\Testing\Arkada\Arkada_signowners_last.json"));
            Console.WriteLine("interestingRows.Count = {0}, interestingRows[0].Count = {1}", interestingRows.Count, interestingRows[0].Count);

        }

        [Test]
        public void ParseIntoPost328Dod2RowsTest()
        {
            List<List<string>> interestingRows = JsonConvert.DeserializeObject<List<List<string>>>(File.ReadAllText(@"D:\home\vmdrot\BGU\Specs\SignigicantOwnership\Testing\Arkada\Arkada_signowners_last.json"));


            List<Post328Dod2V1Row> dod2PrincipalRows;
            List<Post328Dod2V1FormulaRow> dod2FormulaRows;
            List<Post328Dod3V1Row> dod3PrincipalRows;
            Post328DodRowBase.ParseArkadaRows(interestingRows, out dod2PrincipalRows, out dod2FormulaRows, out dod3PrincipalRows);

            #region print-out
            Console.WriteLine("dod2PrincipalRows:");
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;
            settings.Formatting = Formatting.Indented;
            string jsonStr = JsonConvert.SerializeObject(dod2PrincipalRows, settings);

            File.WriteAllText(@"D:\home\vmdrot\BGU\Specs\SignigicantOwnership\Testing\Arkada\dod2PrincipalRows.json", jsonStr, Encoding.Unicode);
            Console.WriteLine(jsonStr);
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("dod2FormulaRows:");
            string jsonStr2 = JsonConvert.SerializeObject(dod2FormulaRows, settings);
            Console.WriteLine(jsonStr2);
            File.WriteAllText(@"D:\home\vmdrot\BGU\Specs\SignigicantOwnership\Testing\Arkada\dod2FormulaRows.json", jsonStr, Encoding.Unicode);
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("dod3PrincipalRows:");
            string jsonStr3 = JsonConvert.SerializeObject(dod3PrincipalRows, settings);
            Console.WriteLine(jsonStr3);
            File.WriteAllText(@"D:\home\vmdrot\BGU\Specs\SignigicantOwnership\Testing\Arkada\dod3PrincipalRows.json", jsonStr, Encoding.Unicode);
            #endregion
        }

        [Test]
        public void ParseIntoPost328Dod2RowsTest2()
        {
            List<List<string>> interestingRows = JsonConvert.DeserializeObject<List<List<string>>>(File.ReadAllText(@"D:\home\vmdrot\BGU\Specs\SignigicantOwnership\Testing\Arkada\Arkada_signowners_last.json"));


            List<Post328Dod2V1Row> dod2PrincipalRows;
            List<Post328Dod2V1FormulaRow> dod2FormulaRows;
            List<Post328Dod3V1Row> dod3PrincipalRows;
            Post328DodRowBase.ParseArkadaRows(interestingRows, out dod2PrincipalRows, out dod2FormulaRows, out dod3PrincipalRows);

            List<string> descRows = new List<string>();
            foreach (Post328Dod2V1Row row in dod2PrincipalRows)
            { 
                string[] aRows = row.OwnershipChainDescr.Split('\r');
                foreach (string r in aRows)
                {
                    descRows.Add(r);
                }
            }

            foreach (Post328Dod3V1Row row in dod3PrincipalRows)
            {
                string[] aRows = row.OwnershipChainDescr.Split('\r');
                descRows.AddRange(aRows);
            }

            #region print-out
            Console.WriteLine("descRows.Count = {0}", descRows.Count);
            
            File.WriteAllLines(@"D:\home\vmdrot\BGU\Specs\SignigicantOwnership\Testing\Arkada\DescrRows.txt", descRows.ToArray(), Encoding.Unicode);
            #endregion
        }

        [Test]
        public void ArkadaOwnershipChainDescriptionParserTest()
        {
            List<List<string>> interestingRows = JsonConvert.DeserializeObject<List<List<string>>>(File.ReadAllText(@"D:\home\vmdrot\BGU\Specs\SignigicantOwnership\Testing\Arkada\Arkada_signowners_last.json"));


            List<Post328Dod2V1Row> dod2PrincipalRows;
            List<Post328Dod2V1FormulaRow> dod2FormulaRows;
            List<Post328Dod3V1Row> dod3PrincipalRows;
            Post328DodRowBase.ParseArkadaRows(interestingRows, out dod2PrincipalRows, out dod2FormulaRows, out dod3PrincipalRows);

            
            foreach (Post328Dod2V1Row row in dod2PrincipalRows)
            {
                ArkadaOwnershipChainDescriptionParser parser = new ArkadaOwnershipChainDescriptionParser();
                List<ArkadaOwnershipChainDescriptionParser.WordingItem> wordingItems = parser.SplitIntoWordings(row.OwnershipChainDescr, row.Name);
                Console.WriteLine("wordingItems.Count = {0}", wordingItems.Count);
            }

            #region print-out
            //Console.WriteLine("descRows.Count = {0}", descRows.Count);
            
            //File.WriteAllLines(@"D:\home\vmdrot\BGU\Specs\SignigicantOwnership\Testing\Arkada\DescrRows.txt", descRows.ToArray(), Encoding.Unicode);
            #endregion
        }

        [Test]
        public void ShowArkadaDuplicatesStats()
        {
            List<KeyCountPair> statsRaw = JsonConvert.DeserializeObject<List<KeyCountPair>>(File.ReadAllText(@"D:\home\vmdrot\BGU\Specs\SignigicantOwnership\Testing\Arkada\ArkadaOwnershipChainParserTest_Appx2Qu_OSStats_v0.json.txt"));
            //List<KeyCountPair> statsSorted = new List<KeyCountPair>();
            var oStatsSorted = from sr in statsRaw
                                where sr.cnt > 1
                                orderby sr.cnt descending
                                select new { key = sr.key, cnt = sr.cnt };
            //statsSorted.AddRange((IEnumerable<KeyCountPair>)oStatsSorted);
            Console.WriteLine("Об'єкт власності-Власник-%\tКількість повторень");
            foreach (var kcp in oStatsSorted)
            {
                Console.WriteLine("{0}\t{1}", kcp.key,kcp.cnt);
            }

        }

        [Test]
        public void ArkadaAppx2OwnersReport()
        {
            Appx2OwnershipStructLP quest = BGU.DRPL.SignificantOwnership.Utility.Tools.ReadXML<Appx2OwnershipStructLP>(@"D:\home\vmdrot\BGU\Specs\SignigicantOwnership\Testing\Arkada\ArkadaOwnershipChainParserTest_Appx2Qu.xml");
            Console.WriteLine("№ п/п\tОб'єкт власності\tВласник (учасник)\tЧастка власності");
            int i = 0;
            foreach(OwnershipStructure os in quest.BankExistingCommonImplicitOwners)
            {

                i++;
                string currAssetName = quest.MentionedIdentities.Find(o => o.ID == os.Asset).DisplayName;
                string currOwnerName = quest.MentionedIdentities.Find(o => o.ID == os.Owner).DisplayName;
                Console.WriteLine("{0}\t{1}\t{2}\t{3} %", i, currAssetName, currOwnerName, os.SharePct);
            }
        }

        public class KeyCountPair
        {
            public string key { get; set; }
            public int cnt { get; set; }
        }
    }
}
