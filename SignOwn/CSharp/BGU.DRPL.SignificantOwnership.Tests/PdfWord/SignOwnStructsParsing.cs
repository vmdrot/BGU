using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Newtonsoft.Json;
using System.IO;
using BGU.DRPL.SignificantOwnership.EmpiricalData.Scraping.Data;

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

    }
}
