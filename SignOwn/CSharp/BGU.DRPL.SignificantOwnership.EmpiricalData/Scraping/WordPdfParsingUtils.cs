using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BGU.DRPL.SignificantOwnership.EmpiricalData.Scraping
{
    public class WordPdfParsingUtils
    {
        public static void FilterOutInterestingRowsOnly(Dictionary<int, List<string>> currDict, List<List<string>> interestingRows, List<List<string>> nonInterestingRows)
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

        public static bool IsHeadingRow(List<string> list)
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

        public static bool CompareList(List<string> list, string[] arr)
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

        public static void AppendCellText(Dictionary<int, List<string>> target, int r, int c, string val)
        {
            if (!target.ContainsKey(r))
                target.Add(r, new List<string>());
            EnsureListCount(target[r], c);
            target[r][c] = val;
        }

        public static void EnsureListCount(List<string> list, int c)
        {
            while (list.Count <= c + 1)
                list.Add(string.Empty);
        }

    }
}
