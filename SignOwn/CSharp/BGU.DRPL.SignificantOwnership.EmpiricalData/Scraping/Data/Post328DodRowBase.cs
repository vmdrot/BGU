using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BGU.DRPL.SignificantOwnership.EmpiricalData.Scraping.Data
{
    public abstract class Post328DodRowBase
    {

        public static string ExtractFirstNonEmptyCell(List<string> rawRow)
        {
            foreach (string cell in rawRow)
            {
                string curr = WordPdfParsingUtils.TrimRawValue(cell);
                if (!string.IsNullOrEmpty(cell.Trim()))
                    return cell;
            }
            return string.Empty;
        }

        public static Post328DodsRowType DetectRowType(List<string> rawRow)
        {
            if (rawRow.Count == 10)
            {
                string trimmed0 = WordPdfParsingUtils.TrimRawValue(rawRow[0]);
                if (string.IsNullOrEmpty(trimmed0))
                    return Post328DodsRowType.Dod2Continuation;
                else
                    return Post328DodsRowType.Dod2Principal;
            }
            else if (rawRow.Count == 4)
            {
                string trimmed0 = WordPdfParsingUtils.TrimRawValue(rawRow[0]);
                if (string.IsNullOrEmpty(trimmed0))
                    return Post328DodsRowType.Dod2FormulaContinuation;
                else
                    return Post328DodsRowType.Dod2Formula;
            }
            else if (rawRow.Count == 7)
            {
                string trimmed0 = WordPdfParsingUtils.TrimRawValue(rawRow[0]);
                if (string.IsNullOrEmpty(trimmed0))
                    return Post328DodsRowType.Dod3Continuation;
                else
                    return Post328DodsRowType.Dod3Principal;
            }
            else
                return Post328DodsRowType.None;
        }


        public static void ParseArkadaRows(List<List<string>> interestingRows, out List<Post328Dod2V1Row> dod2PrincipalRows, out List<Post328Dod2V1FormulaRow> dod2FormulaRows, out List<Post328Dod3V1Row> dod3PrincipalRows)
        {
            dod2PrincipalRows = new List<Post328Dod2V1Row>();
            dod2FormulaRows = new List<Post328Dod2V1FormulaRow>();
            dod3PrincipalRows = new List<Post328Dod3V1Row>();

            foreach (List<string> rawRow in interestingRows)
            {
                Post328DodsRowType rowType = Post328DodRowBase.DetectRowType(rawRow);
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
                            dod2FormulaRows[dod2FormulaRows.Count - 1].FormulaPath += "\r\r\r\r" + Post328DodRowBase.ExtractFirstNonEmptyCell(rawRow);
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
                            dod3PrincipalRows[dod3PrincipalRows.Count - 1].OwnershipChainDescr += "\r\r\r\r" + Post328DodRowBase.ExtractFirstNonEmptyCell(rawRow);
                        }
                        break;
                    default:
                    case Post328DodsRowType.None:
                        break;
                }
            }
        }


    }
}
