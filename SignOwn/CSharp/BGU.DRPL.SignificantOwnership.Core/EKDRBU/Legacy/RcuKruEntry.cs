using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BGU.DRPL.SignificantOwnership.Core.EKDRBU.Legacy
{
    public class RcuKruEntry
    {
        public string Reestr { get; set; }
        public string GR { get; set; }
        public string GR1 { get; set; }
        public int? XX { get; set; }
        public string BU { get; set; }
        public int? NF { get; set; }
        public string PR { get; set; }
        public int? GLB { get; set; }
        public int? PRKB { get; set; }
        public int? RC { get; set; }
        public string PRB { get; set; }
        public int? KB { get; set; }
        public string NB { get; set; }
        public int? MFO { get; set; }
        public string KNB { get; set; }
        public long? NKS { get; set; }
        public int? GLMFO { get; set; }
        public string PI { get; set; }
        public string NCKS { get; set; }
        public string N_ISEP { get; set; }
        public string ISEP { get; set; }
        public string HCKS { get; set; }
        public string FAX { get; set; }
        public string TNP { get; set; }
        public string NP { get; set; }
        public string NAI_R { get; set; }
        public int? KOD_R { get; set; }
        public string ADRESS { get; set; }
        public string FIOPB { get; set; }
        public string TELPB { get; set; }
        public string FIOGB { get; set; }
        public string TELGB { get; set; }
        public DateTime? DATAR { get; set; }
        public DateTime? D_OPEN { get; set; }
        public int? DIR { get; set; }
        public string K040 { get; set; }
        public int? KR { get; set; }
        public string NLF { get; set; }
        public string REGN { get; set; }
        public string TELEFON { get; set; }
        public int? KU { get; set; }
        public int? KO { get; set; }
        public string OBLUPR { get; set; }
        public string TB { get; set; }
        public string NB1 { get; set; }
        public string PR_EP { get; set; }
        public string VID { get; set; }
        public int? N_GLB { get; set; }
        public int? N_PRKB { get; set; }
        public string IKOD { get; set; }
        public string PR_F { get; set; }
        public string FULLNAME { get; set; }
        public string SHORTNAME { get; set; }
        public DateTime? LICDATE { get; set; }
        public string LICNUM { get; set; }
        public long? SID { get; set; }

        public static RcuKruEntry Parse(DataRow dr)
        {
            RcuKruEntry rslt = new RcuKruEntry();
            rslt.Reestr = dr["Reestr"] as string;
            rslt.GR = dr["GR"] as string;
            rslt.GR1 = dr["GR1"] as string;
            rslt.XX = dr["XX"] as int?;
            rslt.BU = dr["BU"] as string;
            rslt.NF = dr["NF"] as int?;
            rslt.PR = dr["PR"] as string;
            rslt.GLB = dr["GLB"] as int?;
            rslt.PRKB = dr["PRKB"] as int?;
            rslt.RC = dr["RC"] as int?;
            rslt.PRB = dr["PRB"] as string;
            rslt.KB = dr["KB"] as int?;
            rslt.NB = dr["NB"] as string;
            rslt.MFO = dr["MFO"] as int?;
            rslt.KNB = dr["KNB"] as string;
            rslt.NKS = dr["NKS"] as long?;
            rslt.GLMFO = dr["GLMFO"] as int?;
            rslt.PI = dr["PI"] as string;
            rslt.NCKS = dr["NCKS"] as string;
            rslt.N_ISEP = dr["N_ISEP"] as string;
            rslt.ISEP = dr["ISEP"] as string;
            rslt.HCKS = dr["HCKS"] as string;
            rslt.FAX = dr["FAX"] as string;
            rslt.TNP = dr["TNP"] as string;
            rslt.NP = dr["NP"] as string;
            rslt.NAI_R = dr["NAI_R"] as string;
            rslt.KOD_R = dr["KOD_R"] as int?;
            rslt.ADRESS = dr["ADRESS"] as string;
            rslt.FIOPB = dr["FIOPB"] as string;
            rslt.TELPB = dr["TELPB"] as string;
            rslt.FIOGB = dr["FIOGB"] as string;
            rslt.TELGB = dr["TELGB"] as string;
            rslt.DATAR = dr["DATAR"] as DateTime?;
            rslt.D_OPEN = dr["D_OPEN"] as DateTime?;
            rslt.DIR = dr["DIR"] as int?;
            rslt.K040 = dr["K040"] as string;
            rslt.KR = dr["KR"] as int?;
            rslt.NLF = dr["NLF"] as string;
            rslt.REGN = dr["REGN"] as string;
            rslt.TELEFON = dr["TELEFON"] as string;
            rslt.KU = dr["KU"] as int?;
            rslt.KO = dr["KO"] as int?;
            rslt.OBLUPR = dr["OBLUPR"] as string;
            rslt.TB = dr["TB"] as string;
            rslt.NB1 = dr["NB1"] as string;
            rslt.PR_EP = dr["PR_EP"] as string;
            rslt.VID = dr["VID"] as string;
            rslt.N_GLB = dr["N_GLB"] as int?;
            rslt.N_PRKB = dr["N_PRKB"] as int?;
            rslt.IKOD = dr["IKOD"] as string;
            rslt.PR_F = dr["PR_F"] as string;
            rslt.FULLNAME = dr["FULLNAME"] as string;
            rslt.SHORTNAME = dr["SHORTNAME"] as string;
            rslt.LICDATE = dr["LICDATE"] as DateTime?;
            rslt.LICNUM = dr["LICNUM"] as string;
            rslt.SID = dr["SID"] as long?;
            return rslt;
        }
    }
}
