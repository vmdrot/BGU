using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Newtonsoft.Json;
using BGU.DRPL.SignificantOwnership.Utility.Office;
using BGU.DRPL.SignificantOwnership.EmpiricalData.Scraping;
using System.IO;
using BGU.DRPL.SignificantOwnership.Tests.BankInfoTests;

namespace BGU.DRPL.SignificantOwnership.Tests.PdfWord
{
    [TestFixture]
    public class WordReaderResearch
    {

        private delegate void WordAppManipulator(Microsoft.Office.Interop.Word.Document docs);

        private void WordManipulationWorker(WordAppManipulator manipulator)
        {
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            object miss = System.Reflection.Missing.Value;
            //object path = @"D:\home\vmdrot\BGU\Specs\SignigicantOwnership\Testing\Arkada\322335_20150818_cpy.rtf";
            object path = @"D:\home\vmdrot\BGU\Specs\SignigicantOwnership\Testing\Arkada\322335_20150818.doc";
            object readOnly = true;
            Microsoft.Office.Interop.Word.Document docs = word.Documents.Open(ref path, ref miss, ref readOnly, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
            manipulator(docs);
            docs.Close();
            word.Quit();
        }


        private void FirstDraftReadManipulator(Microsoft.Office.Interop.Word.Document docs)
        {
            StringBuilder totaltext = new StringBuilder();
            for (int i = 0; i < docs.Tables.Count; i++)
            {
                int tIdx = i + 1;
                Console.WriteLine("about to get table # {0}...", tIdx);
                Microsoft.Office.Interop.Word.Table tbl = docs.Tables[tIdx];
                Console.WriteLine("Got table # {0}.", tIdx);
                Console.WriteLine("table # {0} contents:\n{1}\n-------------------------------------------------------", tIdx, tbl.Range.Text.ToString());
                for (int r = 1; r < docs.Tables[tIdx].Rows.Count; r++)
                {
                    try
                    {
                        Console.WriteLine("about to get row # {0} in table # {1} ...", r + 1, tIdx);
                        Microsoft.Office.Interop.Word.Row row = tbl.Rows[r + 1];
                        Console.WriteLine("Got row # {0} in table #{1}...", r + 1, tIdx);

                        Microsoft.Office.Interop.Word.Cells cells = row.Cells;
                        Console.WriteLine("Got {0}th row in {1}th table has {1} cells", r + 1, tIdx, cells.Count);
                        StringBuilder sb = new StringBuilder();
                        for (int c = 0; c < cells.Count; c++)
                        {
                            if (c > 0)
                                sb.Append('\t');
                            sb.Append(cells[c].Range.Text.ToString());
                        }
                        totaltext.AppendLine(sb.ToString());
                    }
                    catch (System.Runtime.InteropServices.COMException exc)
                    {
                        if (exc.Message.IndexOf("объединен") != -1 || exc.Message.IndexOf("span") != -1 || exc.Message.IndexOf("об'єднан") != -1)
                            continue;
                    }

                }
                //totaltext += " \r\n " + docs.Tables[i + 1].Range.Text.ToString();
            }
            Console.WriteLine(totaltext.ToString());
        }

        private void RangeCellsManipulator(Microsoft.Office.Interop.Word.Document docs)
        {
            StringBuilder totaltext = new StringBuilder();
            for (int i = 0; i < docs.Tables.Count; i++)
            {
                int tIdx = i + 1;
                //Console.WriteLine("about to get table # {0}...", tIdx);
                Microsoft.Office.Interop.Word.Table tbl = docs.Tables[tIdx];
                //Console.WriteLine("Got table # {0}.", tIdx);
                //Console.WriteLine("table # {0} contents:\n{1}\n-------------------------------------------------------", tIdx, tbl.Range.Text.ToString());
                Microsoft.Office.Interop.Word.Cells cells = tbl.Range.Cells;
                Console.WriteLine("tbl[{0}].Range.Cells.Count = {1}", tIdx, tbl.Range.Cells.Count);
                int lastCellRowIdx = 0;
                {
                    StringBuilder sb = new StringBuilder();

                    for (int c = 1; c <= cells.Count; c++)
                    {
                        if (cells[c].ColumnIndex > 0)
                            sb.Append('\t');
                        sb.Append(cells[c].Range.Text.ToString());
                        if (cells[c].RowIndex != lastCellRowIdx)
                            totaltext.AppendLine(sb.ToString());
                        lastCellRowIdx = cells[c].RowIndex;
                    }
                    
                }
            }
            Console.WriteLine(totaltext.ToString());
        }

        private void RangeCells2JsonManipulator(Microsoft.Office.Interop.Word.Document docs)
        {
            for (int i = 0; i < docs.Tables.Count; i++)
            {
                int tIdx = i + 1;
                Console.WriteLine("about to get table # {0}...", tIdx);
                Microsoft.Office.Interop.Word.Table tbl = docs.Tables[tIdx];
                Console.WriteLine("Got table # {0}.", tIdx);
                //Console.WriteLine("table # {0} contents:\n{1}\n-------------------------------------------------------", tIdx, tbl.Range.Text.ToString());
                Microsoft.Office.Interop.Word.Cells cells = tbl.Range.Cells;
                Dictionary<int, List<string>> rslt = new Dictionary<int, List<string>>();
            
                {
                    for (int c = 1; c <= cells.Count; c++)
                    {
                        WordPdfParsingUtils.AppendCellText(rslt, cells[c].RowIndex, cells[c].ColumnIndex, cells[c].Range.Text.ToString());
                    }
                }
                
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                string jsonStr = JsonConvert.SerializeObject(rslt, settings);
                Console.WriteLine("{0}", jsonStr);
                Console.WriteLine("-------------------------------------------------------");
            }
        }


        private void RangeCellsOnlyInterestingRowsManipulator(Microsoft.Office.Interop.Word.Document docs)
        {
            List<List<string>> interestingRows = new List<List<string>>();
            List<List<string>> nonInterestingRows = new List<List<string>>();
            for (int i = 0; i < docs.Tables.Count; i++)
            {
                int tIdx = i + 1;
                //Console.WriteLine("about to get table # {0}...", tIdx);
                Microsoft.Office.Interop.Word.Table tbl = docs.Tables[tIdx];
                //Console.WriteLine("Got table # {0}.", tIdx);
                //Console.WriteLine("table # {0} contents:\n{1}\n-------------------------------------------------------", tIdx, tbl.Range.Text.ToString());
                Microsoft.Office.Interop.Word.Cells cells = tbl.Range.Cells;
                Dictionary<int, List<string>> rslt = new Dictionary<int, List<string>>();

                {
                    for (int c = 1; c <= cells.Count; c++)
                    {
                        WordPdfParsingUtils.AppendCellText(rslt, cells[c].RowIndex, cells[c].ColumnIndex-1, cells[c].Range.Text.ToString());
                    }
                }

                WordPdfParsingUtils.FilterOutInterestingRowsOnly(rslt, interestingRows, nonInterestingRows);
            }
            Console.WriteLine("Rows of interest:");
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;
            string jsonStr = JsonConvert.SerializeObject(interestingRows, settings);
            File.WriteAllText(@"D:\home\vmdrot\BGU\Specs\SignigicantOwnership\Testing\Arkada\Arkada_signowners_last.json", jsonStr, Encoding.Unicode);
            Console.WriteLine(jsonStr);
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("Wed-out rows:");
            string jsonStr2 = JsonConvert.SerializeObject(nonInterestingRows, settings);
            Console.WriteLine(jsonStr2);
            
        }



        [Test]
        public void ReadTest()
        {
            WordManipulationWorker(FirstDraftReadManipulator);
        }

        [Test]
        public void ReadTest2()
        {
            WordManipulationWorker(RangeCellsManipulator);
        }

        [Test]
        public void ReadTest3()
        {
            WordManipulationWorker(RangeCells2JsonManipulator);
        }

        [Test]
        public void ReadTest4()
        {
            WordManipulationWorker(RangeCellsOnlyInterestingRowsManipulator);
        }

        [Test]
        public void ReadTest5()
        {
            Dictionary<int, List<string>> rawDict = null;
            List<List<string>> interestingRows = new List<List<string>>();
            List<List<string>> nonInterestingRows = new List<List<string>>();

            using (WordReader wr = new WordReader())
            {
                //rawDict = wr.ReadAllTables(@"D:\home\vmdrot\BGU\Specs\SignigicantOwnership\Testing\Arkada\322335_20150818.doc");
                rawDict = wr.ReadAllTables(@"D:\home\vmdrot\BGU\Specs\SignigicantOwnership\Testing\Arkada\322335_20150818_cpy.rtf");

            }
            WordPdfParsingUtils.FilterOutInterestingRowsOnly(rawDict, interestingRows, nonInterestingRows);

            Console.WriteLine("Rows of interest:");
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;
            string jsonStr = JsonConvert.SerializeObject(interestingRows, settings);
            Console.WriteLine(jsonStr);
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("Wed-out rows:");
            string jsonStr2 = JsonConvert.SerializeObject(nonInterestingRows, settings);
            Console.WriteLine(jsonStr2);
        }

        [Test]
        public void ReadGFXNFULicensesDocTest()
        {
            Dictionary<int, Dictionary<int, List<string>>> rawDict = null;
            List<List<string>> interestingRows = new List<List<string>>();
            List<List<string>> nonInterestingRows = new List<List<string>>();

            using (WordReader wr = new WordReader())
            {
                //rawDict = wr.ReadAllTables(@"D:\home\vmdrot\BGU\Specs\SignigicantOwnership\Testing\Arkada\322335_20150818.doc");
                rawDict = wr.ReadAllTablesEx(@"D:\home\vmdrot\BGU\Var\DerzhReiestr\OpsFinSvcs\genlicnebank.doc");

            }
            (new GenLicenseWordParsingTools()).FilterOutInterestingRowsOnly(rawDict, interestingRows, nonInterestingRows); //todo

            
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;
            settings.Formatting = Formatting.Indented;
            Console.WriteLine("rawDict:");
            string jsonStr = JsonConvert.SerializeObject(rawDict, settings);
            Console.WriteLine(jsonStr);
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("Rows of interest:");
            string jsonStr1 = JsonConvert.SerializeObject(interestingRows, settings);
            Console.WriteLine(jsonStr1);
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("Wed-out rows:");
            string jsonStr2 = JsonConvert.SerializeObject(nonInterestingRows, settings);
            Console.WriteLine(jsonStr2);
        }

    }
}
