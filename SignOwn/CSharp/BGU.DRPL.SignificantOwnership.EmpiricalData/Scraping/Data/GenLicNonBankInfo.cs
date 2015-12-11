using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace BGU.DRPL.SignificantOwnership.EmpiricalData.Scraping.Data
{
    public class GenLicNonBankInfo
    {
        public string NrOrdinal { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string TaxID { get; set; }
        public string LicNr { get; set; }
        public string LicDt { get; set; }
        public string LicExpiry { get; set; }
        public string LicStatus { get; set; }
        public string LicOps { get; set; }
        public string Notes { get; set; }

        public static List<GenLicNonBankInfo> Parse(List<List<string>> interestingRows)
        {
            List<GenLicNonBankInfo> rslt = new List<GenLicNonBankInfo>();
            GenLicNonBankInfo currLic = null;
            foreach (List<string> row in interestingRows)
            {
                if (row == null)
                    continue;
                if (IsNewLicenseRow(row))
                {
                    if (currLic != null)
                        rslt.Add(currLic);
                    currLic = ConstructNewRow(row);
                    if (currLic == null)
                        throw new ApplicationException(String.Format("Unable to construct new record from the row: {0}", JsonConvert.SerializeObject(row)));
                }
                else
                {
                    AppendData(currLic, row);
                }
            }
            if (currLic != null)
                rslt.Add(currLic);

            return rslt;
        }

        private static void AppendData(GenLicNonBankInfo currLic, List<string> row)
        {
            switch (row.Count)
            {
                //Length: 11, Count: 2
                //Length: 4, Count: 26
                //Length: 10, Count: 322
                //Length: 9, Count: 185
                //Length: 2, Count: 19
                //Length: 8, Count: 122

                case 4: //OK
                    { currLic.LicOps = AddIfNonEmpty(1, row, currLic.LicOps); }
                    break;
                case 11: //OK
                case 10: //OK
                case 9:  //OK
                    {
                        currLic.Name = AddIfNonEmpty(1, row, currLic.Name);
                        currLic.Address = AddIfNonEmpty(2, row, currLic.Address);
                        currLic.LicExpiry = AddIfNonEmpty(6, row, currLic.LicExpiry);
                        currLic.LicOps = AddIfNonEmpty(7, row, currLic.LicOps);
                        currLic.Notes = AddIfNonEmpty(8, row, currLic.Notes);
                    }
                    break;
                case 8:
                    {
                        currLic.Name = AddIfNonEmpty(0, row, currLic.Name);
                        currLic.Address = AddIfNonEmpty(1, row, currLic.Address);
                        currLic.LicExpiry = AddIfNonEmpty(5, row, currLic.LicExpiry);
                        currLic.LicOps = AddIfNonEmpty(6, row, currLic.LicOps);
                        currLic.Notes = AddIfNonEmpty(7, row, currLic.Notes);
                    }
                    break;
                case 2:
                    {
                        string[] lines = row[0].Split('\r');
                        foreach (string line in lines)
                        {
                            string[] flds = line.Split('\t');
                            if (flds.Length < 2)
                                break;
                            currLic.Name += flds[0];
                            currLic.LicOps += flds[1];
                        }
                    }
                    break;
                default: break;
            }
        }

        private static string AddIfNonEmpty(int i, List<string> row, string fld)
        {
            string crlfTrimmed = TrimCRLF(row[i]);
            if (crlfTrimmed.Trim().Length > 0)
                fld += (" " + crlfTrimmed);
            return fld;
        }

        private static bool IsNewLicenseRow(List<string> row)
        {
            if (row.Count < 8)
                return false;

            int startIdx = -1;
            switch (row.Count)
            {
                case 11:
                case 10:
                case 9:
                    startIdx = 3;
                    break;
                case 8:
                    startIdx = 2;
                    break;
                default: 
                    break;

            }

            string yedrpouStr = TrimCRLF(row[startIdx]);
            string licNrStr = TrimCRLF(row[startIdx+1]);
            string licDtStr = TrimCRLF(row[startIdx+2]);
            long yedrpou; int licNr; DateTime licDt;
            if (!long.TryParse(yedrpouStr.Trim(), out yedrpou) || !int.TryParse(licNrStr.Trim(), out licNr) || !DateTime.TryParse(licDtStr.Trim(), out licDt))
                return false;

            return true;
        }

        private static string TrimCRLF(string p)
        {
            return p.Replace("\r\u0007", "");
        }

        private static GenLicNonBankInfo ConstructNewRow(List<string> row)
        {
            GenLicNonBankInfo rslt = new GenLicNonBankInfo();
            if (row.Count >= 9)
            {
                for (int i = 0; i < row.Count; i++)
                {
                    switch (i)
                    {
                        case 0: rslt.NrOrdinal = TrimCRLF(row[i]).Trim(); break;
                        case 1: rslt.Name = TrimCRLF(row[i]).Trim(); break;
                        case 2: rslt.Address = TrimCRLF(row[i]); break;
                        case 3: rslt.TaxID = TrimCRLF(row[i]).Trim(); break;
                        case 4: rslt.LicNr = TrimCRLF(row[i]).Trim(); break;
                        case 5: rslt.LicDt = TrimCRLF(row[i]).Trim(); break;
                        case 6: rslt.LicExpiry = TrimCRLF(row[i]).Trim(); break;
                        case 7: rslt.LicOps = TrimCRLF(row[i]); break;
                        case 8: rslt.Notes = TrimCRLF(row[i]); break;
                        default: break;
                    }
                }
            }
            else if (row.Count == 8)
            {
                for (int i = 0; i < row.Count; i++)
                {
                    switch (i)
                    {
                        //case 0: rslt.NrOrdinal = row[i].Trim(); break;
                        case 0: rslt.Name = TrimCRLF(row[i]).Trim(); break;
                        case 1: rslt.Address = TrimCRLF(row[i]); break;
                        case 2: rslt.TaxID = TrimCRLF(row[i]).Trim(); break;
                        case 3: rslt.LicNr = TrimCRLF(row[i]).Trim(); break;
                        case 4: rslt.LicDt = TrimCRLF(row[i]).Trim(); break;
                        case 5: rslt.LicExpiry = TrimCRLF(row[i]).Trim(); break;
                        case 6: rslt.LicOps = TrimCRLF(row[i]); break;
                        case 7: rslt.Notes = TrimCRLF(row[i]); break;
                        default: break;
                    }
                }
            }
            else
                return null;
            return rslt;
        }

    }


}
