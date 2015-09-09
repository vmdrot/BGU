using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Newtonsoft.Json;

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
            object path = @"D:\home\vmdrot\BGU\Specs\SignigicantOwnership\Testing\Arkada\322335_20150818_cpy.rtf";
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
                        AppendCellText(rslt, cells[c].RowIndex, cells[c].ColumnIndex, cells[c].Range.Text.ToString());
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
                        AppendCellText(rslt, cells[c].RowIndex, cells[c].ColumnIndex, cells[c].Range.Text.ToString());
                    }
                }

                FilterOutInterestingRowsOnly(rslt, interestingRows, nonInterestingRows);
            }
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

        private void FilterOutInterestingRowsOnly(Dictionary<int, List<string>> currDict, List<List<string>> interestingRows, List<List<string>> nonInterestingRows)
        {
            foreach (int key in currDict.Keys)
            {
                if (IsHeadingRow(currDict[key]))
                {
                    nonInterestingRows.Add(currDict[key]);
                    continue;
                }
                interestingRows.Add(currDict[key]);
            }
        }

        private bool IsHeadingRow(List<string> list)
        {
            string[] headingTexts1 = new string[] {     "",
    "№\rз/п\r\u0007",
    "Прізвище,  ім'я\rта по батькові фізичної  особи або повне найменування юридичної особи\r\u0007",
    "Тип\rособи\r\u0007",
    "Чи є\rособа власни- ком істотної участі  в банку\r\u0007",
    "Інформація  про особу\r\u0007",
    "Участь особи в банку,  %\r\u0007",
    "Опис взаємозв'язку особи з банком\r\u0007",
    "" };
            string[] headingTexts2 = new string[] {     "",
    "",
    "",
    "",
    "",
    "",
    "Пряма\r\u0007",
    "Опосеред-\rкована\r\u0007",
    "Сукупна\r\u0007",
    "" };
            string[] headingTexts3 = new string[] {     "",
    "1\r\u0007",
    "2\r\u0007",
    "3\r\u0007",
    "4\r\u0007",
    "5\r\u0007",
    "6\r\u0007",
    "7\r\u0007",
    "8\r\u0007",
    "9\r\u0007",
    ""

 };
            if (CompareList(list, headingTexts1) || CompareList(list, headingTexts2) || CompareList(list, headingTexts3))
                return true;
            return false;
        }

        private bool CompareList(List<string> list, string[] arr)
        {
            int matchedColsCount = 0;
            foreach (string col in arr)
            {
                if (string.IsNullOrEmpty(col))
                    continue;

                if (list.Contains(col))
                    matchedColsCount++;
            }
            return matchedColsCount >= 3;
        }

        private void AppendCellText(Dictionary<int, List<string>> target, int r, int c, string val)
        {
            if (!target.ContainsKey(r))
                target.Add(r, new List<string>());
            EnsureListCount(target[r], c);
            target[r][c] = val;
        }

        private void EnsureListCount(List<string> list, int c)
        {
            while (list.Count <= c + 1)
                list.Add(string.Empty);
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

    }
}
