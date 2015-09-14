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
            List<Post328Dod2V1Row> dod2PrincipalRows = new List<Post328Dod2V1Row>();
            List<Post328Dod2V1FormulaRow> dod2FormulaRows = new List<Post328Dod2V1FormulaRow>();
            List<Post328Dod3V1Row> dod3PrincipalRows = new List<Post328Dod3V1Row>();

            foreach (List<string> rawRow in interestingRows)
            {
                Post328DodsRowType rowType = DetectRowType(rawRow);
                switch (rowType)
                {
                    case Post328DodsRowType.Dod2Principal:
                        {
                            Post328Dod2V1Row structRow = Post328Dod2V1Row.Parse(rawRow);
                            dod2PrincipalRows.Add(structRow);
                        }
                        break;
                    case Post328DodsRowType.Dod2Continuation:
                        {
                            dod2PrincipalRows[dod2PrincipalRows.Count - 1].OwnershipChainDescr += "\r\r\r\r" + rawRow[8];
                        }
                        break;
                    case Post328DodsRowType.Dod2Formula:
                        {
                            Post328Dod2V1FormulaRow structRow = Post328Dod2V1FormulaRow.Parse(rawRow);
                            dod2FormulaRows.Add(structRow);
                        }
                        break;
                    case Post328DodsRowType.Dod2FormulaContinuation:
                        {
                            dod2FormulaRows[dod2FormulaRows.Count - 1].FormulaPath += "\r\r\r\r" + ExtractFirstNonEmpty(rawRow);
                        }
                        break;
                    case Post328DodsRowType.Dod3Principal:
                        {
                            Post328Dod3V1Row structRow = Post328Dod3V1Row.Parse(rawRow);
                            dod3PrincipalRows.Add(structRow);
                        }
                        break;
                    case Post328DodsRowType.Dod3Continuation:
                        {
                            dod3PrincipalRows[dod3PrincipalRows.Count - 1].OwnershipChainDescr += "\r\r\r\r" + ExtractFirstNonEmpty(rawRow);
                        }
                        break;
                    default:
                    case Post328DodsRowType.None:
                        break;
                }

                //switch(row
                //if (IsNewRow())
                //{
                //    
                //}

            }
        }

        private string ExtractFirstNonEmpty(List<string> rawRow)
        {
            throw new NotImplementedException();
        }

        private Post328DodsRowType DetectRowType(List<string> rawRow)
        {
            throw new NotImplementedException();
        }

        private bool IsNewRow(List<string> row)
        {
            throw new NotImplementedException();
        }
    }
}
