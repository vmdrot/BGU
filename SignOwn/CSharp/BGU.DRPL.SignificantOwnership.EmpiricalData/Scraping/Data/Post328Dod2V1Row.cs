using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;

namespace BGU.DRPL.SignificantOwnership.EmpiricalData.Scraping.Data
{
    public class Post328Dod2V1Row : Post328DodRowBase
    {
        public int RowNum { get; set; }
        public string Name { get; set; }
        public string PersonTypeStr { get; set; }
        public string IsSignOwnerStr { get; set; }
        public string PersonInfo { get; set; }
        public decimal DirectOwnershipPct { get; set; }
        public decimal ImplicitOwnershipPct { get; set; }
        public decimal TotalOwnershipPct { get; set; }
        public string OwnershipChainDescr { get; set; }

        public static Post328Dod2V1Row Parse(List<string> rawRow)
        {
            if (rawRow == null || rawRow.Count < 9)
                return null;
            Post328Dod2V1Row rslt = new Post328Dod2V1Row();
            int rowNum;
            if (int.TryParse(WordPdfParsingUtils.TrimRawValue(rawRow[0]), out rowNum))
                rslt.RowNum = rowNum;
            rslt.Name = WordPdfParsingUtils.NormalizeStringValue(rawRow[1]);
            rslt.PersonTypeStr = WordPdfParsingUtils.TrimRawValue(rawRow[2]);
            rslt.IsSignOwnerStr = WordPdfParsingUtils.TrimRawValue(rawRow[3]);
            rslt.PersonInfo = WordPdfParsingUtils.NormalizeStringValue(rawRow[4]);

            decimal pct0;
            if (decimal.TryParse(WordPdfParsingUtils.TrimRawValue(rawRow[5]), out pct0))
                rslt.DirectOwnershipPct = pct0;

            decimal pct1;
            if (decimal.TryParse(WordPdfParsingUtils.TrimRawValue(rawRow[6]), out pct1))
                rslt.ImplicitOwnershipPct = pct1;
            
            decimal pct2;
            if (decimal.TryParse(WordPdfParsingUtils.TrimRawValue(rawRow[7]), out pct2))
                rslt.TotalOwnershipPct = pct2;
            rslt.OwnershipChainDescr = rawRow[8];
            return rslt;
        }

        public static explicit operator GenericPersonInfo(Post328Dod2V1Row src)
        {
            GenericPersonInfo rslt = new GenericPersonInfo();

            LocationInfo li = LocationInfo.Parse(src.PersonInfo);
            CountryInfo resCountry = li.Country ?? CountryInfo.UKRAINE;
            rslt.PersonType = src.PersonTypeStr == "ФО" ? Core.Spares.EntityType.Physical : Core.Spares.EntityType.Legal;
            string normalName = WordPdfParsingUtils.NormalizeStringValue(src.Name);
            if (rslt.PersonType == Core.Spares.EntityType.Physical)
            {
                rslt.PhysicalPerson = new PhysicalPersonInfo();
                rslt.PhysicalPerson.Address = li;
                rslt.PhysicalPerson.CitizenshipCountry = resCountry;
                rslt.PhysicalPerson.TaxOrSocSecID = normalName;
                rslt.PhysicalPerson.FullName = normalName;
            }
            else
            {
                rslt.LegalPerson = new LegalPersonInfo();
                rslt.LegalPerson.Address = li;
                rslt.LegalPerson.ResidenceCountry = resCountry;
                rslt.LegalPerson.TaxCodeOrHandelsRegNr = normalName;
                rslt.LegalPerson.Name = normalName;
            }

            return rslt;
        }
    }
}
