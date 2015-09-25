using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BGU.DRPL.SignificantOwnership.EmpiricalData.Scraping.Data
{
    public class BGUBankOwnStructInfo
    {
        private const string url_sub_str = "/files/Shareholders/";
        public string BankName { get; set; }
        public string BankOwnStruPgUrl { get; set; }
        private string _MFO;
        public string MFO
        {
            get 
            {
                if(string.IsNullOrEmpty(_MFO))
                {
                    int pos0 = BankOwnStruPgUrl.IndexOf(url_sub_str);
                    if (pos0 == -1)
                        return null;
                    int pos1 = BankOwnStruPgUrl.IndexOf('/', pos0 + url_sub_str.Length + 1);
                    if (pos1 == -1)
                        return null;
                    _MFO = BankOwnStruPgUrl.Substring(pos0 + url_sub_str.Length, pos1 - (pos0 + url_sub_str.Length));
                }
                return _MFO;
            }
        }
        public List<BankOwnStructVersionInfo> OwnershipStructureVersions { get; set; }
    }
}
