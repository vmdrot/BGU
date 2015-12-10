using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace BGU.DRPL.SignificantOwnership.Tests.BankInfoTests
{
    public class GenLicenseWordParsingTools
    {
        private static readonly Regex RGX_LFCR = new Regex("[\r\n]+", RegexOptions.Multiline | RegexOptions.IgnoreCase);
        private static readonly Regex RGX_2BLSPC = new Regex("[ ]+", RegexOptions.Multiline | RegexOptions.IgnoreCase);

        public void FilterOutInterestingRowsOnly(Dictionary<int, Dictionary<int, List<string>>> rawDict, List<List<string>> interestingRows, List<List<string>> nonInterestingRows)
        {
            foreach (int tblIdx in rawDict.Keys)
            {
                Dictionary<int, List<string>> currDict = rawDict[tblIdx];
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
        }

        public bool IsHeadingRow(List<string> list)
        {
            string[] headingTexts1 = new string[] {           "№\r\u0007",
      "Назва установи\r\u0007",
      "Місцезнаходження\r\u0007",
      "Код\r\u0007",
      "\r\u0007",
      "Генеральна\r\u0007",
      "ліцензія\r\u0007",
      "\r\u0007",
      "Перелік операцій,\r\u0007",
      "Примітка *\r\u0007",
      ""
 };
            string[] headingTexts2 = new string[] {           "з/п\r\u0007",
      "\r\u0007",
      "установи\r\u0007",
      "ЄДРПОУ\r\u0007",
      "Номер\r\u0007",
      "Дата\r\u0007",
      "Строк дії\r\u0007",
      "Стан\r\u0007",
      "які дозволено здійснювати\r\u0007",
      "\r\u0007",
      ""
 };
            string[] headingTexts3 = new string[] {          "\r\u0007",
      "\r\u0007",
      "\r\u0007",
      "\r\u0007",
      "\r\u0007",
      "надання\r\u0007",
      "(за наяв-\r\u0007",
      "\r\u0007",
      "на підставі генеральної\r\u0007",
      "\r\u0007",
      ""

 };

            string[] headingTexts4 = new string[] {      "\r\u0007",
      "\r\u0007",
      "\r\u0007",
      "\r\u0007",
      "\r\u0007",
      "\r\u0007",
      "ності)\r\u0007",
      "\r\u0007",
      "ліцензії\r\u0007",
      "\r\u0007",
      ""
};

            string[] headingTexts5 = new string[] {       "1\r\u0007",
      "2\r\u0007",
      "3\r\u0007",
      "4\r\u0007",
      "5\r\u0007",
      "6\r\u0007",
      "7\r\u0007",
      "8\r\u0007",
      "9\r\u0007",
      "10\r\u0007",
      ""
};

            if (CompareListExact(list, headingTexts1) || CompareListExact(list, headingTexts2) || CompareListExact(list, headingTexts3) || CompareListExact(list, headingTexts4) || CompareListExact(list, headingTexts5))
                return true;
            return false;
        }

        public  bool CompareList(List<string> list, string[] arr)
        {
            int matchedColsCount = 0;
            foreach (string col in arr)
            {
                if (string.IsNullOrEmpty(col))
                    continue;

                if (list.Contains(col))
                    matchedColsCount++;
            }
            return matchedColsCount >= Math.Min(list.Count, arr.Length);
        }

        public bool CompareListExact(List<string> list, string[] arr)
        {
            if (list == null && arr == null)
                return true;
            if (list == null || arr == null)
                return false;
            if (list.Count != arr.Length)
                return false;
            int matchedColsCount = 0;
            for(int i = 0; i < arr.Length;i++)
            {
                if(string.IsNullOrEmpty(arr[i]) && string.IsNullOrEmpty(list[i]))
                {
                    matchedColsCount++;
                    continue;
                }
                else if(string.IsNullOrEmpty(arr[i]) || string.IsNullOrEmpty(list[i]))
                    continue;
                if (arr[i] == list[i])
                    matchedColsCount++;
            }
            return matchedColsCount == list.Count;
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

        public static string NormalizeStringValue(string src)
        {
            return RGX_2BLSPC.Replace(RGX_LFCR.Replace(TrimRawValue(src).Replace("\"", "").Replace("(", "").Replace(")", ""), " "), " ").Trim();
        }

        public static string TrimRawValue(string raw)
        {
            return raw.Replace("\r\u0007", string.Empty).Trim();
        }

    }
}
