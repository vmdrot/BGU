using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;
using System.Text.RegularExpressions;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Dict
{
    /// <summary>
    /// Інформація про фіз.особу (реквізити)
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.PhysicalPersonInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class PhysicalPersonInfo
    {
        public PhysicalPersonInfo()
        {
            CitizenshipCountry = CountryInfo.UKRAINE;
        }
        
        /// <summary>
        /// для нерезидентів
        /// </summary>
        [DisplayName("Прізвище (укр.)")]
        [Description("Прізвище, українською")]
        public string SurnameUkr { get; set; }
        /// <summary>
        /// для нерезидентів
        /// </summary>
        [DisplayName("Ім'я (укр.)")]
        [Description("Ім'я, українською")]
        public string NameUkr { get; set; }
        /// <summary>
        /// для нерезидентів
        /// </summary>
        [DisplayName("По-батькові/друге ім'я (укр.)")]
        [Description("По-батькові/друге ім'я, українською")]
        public string MiddleNameUkr { get; set; }
        /// <summary>
        /// для нерезидентів
        /// </summary>
        [DisplayName("П.І.Б (укр.)")]
        [Description("П.І.Б., українською")]
        public string FullNameUkr { get; set; }
        [DisplayName("Прізвище")]
        [Description("Прізвище")]
        public string Surname { get; set; }
        [DisplayName("Ім'я")]
        [Description("Ім'я")]
        public string Name { get; set; }
        [DisplayName("По-батькові/друге ім'я")]
        [Description("По-батькові/друге ім'я")]
        public string MiddleName { get; set; }
        /// <summary>
        /// Вказувати достатньо повного імені; 
        /// Якщо є натхнення (або вимагає анкета) - можна й деталізацію по полях
        /// Для нерезидентів бажано вимагати як окремих частин імені, 
        /// так і повного (повністю) (бо хто його там зна, як до нього звертатися)
        /// </summary>
        [DisplayName("П.І.Б.")]
        [Description("П.І.Б.")]
        [Required]
        public string FullName { get; set; }
        /// <summary>
        /// Бажано вимагати; дивитися за контекстом конкретного поля 
        /// у конкретній анкеті
        /// </summary>
        [DisplayName("Стать")]
        [Description("Стать")]
        public SexType Sex { get; set; }
        /// <summary>
        /// Як правило, необов'язкове поле
        /// Буває, що онука називають як діда, і у ланцюжку володіння фігурують обидва
        /// Тоді корисно мати ще й дату народження, щоб відрізняти; 
        /// буває, що онук ще неповнолітній та не має паспорта/кода
        /// (реальний випадок - банк "Грант", щоправда, там, був код ІПН)
        /// </summary>
        [DisplayName("Дата народження")]
        [Description("Дата народження")]
        public DateTime BirthDate { get; set; }
        [DisplayName("Серія № паспорта")]
        [Description("Серія № паспорта")]
        public string PassportID { get; set; }
        [DisplayName("Дата видачі паспорта")]
        [Description("Дата видачі паспорта")]
        public DateTime PassIssuedDate { get; set; }
        [DisplayName("Орган, що видав паспорт")]
        [Description("Орган, що видав паспорт")]
        public RegistrarAuthority PassIssueAuthority { get; set; }
        [DisplayName("ІПН")]
        [Description("ІПН/№ картки соціального страхування/тощо, дивлячись, що використовується у країні резидентства")]
        public string TaxOrSocSecID { get; set; }
        /// <summary>
        /// Поле необхідне лише якщо вимагається у анкеті
        /// </summary>
        [DisplayName("Місце проживання/реєстрації")]
        [Description("Місце проживання/реєстрації")]
        public LocationInfo Address { get; set; }
        /// <summary>
        /// Обов'язкове поле (окрім хіба ContactInfo)
        /// За змовчанням (пропонувати) - Україна
        /// </summary>
        [DisplayName("Громадянство")]
        [Description("Громадянство")]
        public CountryInfo CitizenshipCountry { get; set; }
        [Browsable(false)]
        public GenericPersonID GenericID { get { return new GenericPersonID() { CountryISO3Code = CitizenshipCountry != null ? CitizenshipCountry.CountryISONr : string.Empty, PersonCode = TaxOrSocSecID ?? PassportID, PersonType = EntityType.Physical, DisplayName = ToString() }; } }


        #region inner type(s)
        public enum PhysPersonInfoPart
        {
            None = 0,
            SurnameUkr,
            NameUkr,
            MiddleNameUkr,
            FullNameUkr,
            Surname,
            Name,
            MiddleName,
            FullName,
            Sex,
            BirthDate,
            PassportID,
            PassIssuedDate,
            PassIssueAuthority,
            TaxOrSocSecID,
            Address,
            CitizenshipCountry
        }

        public class ParseMatchInfo
        {
            public ParseMatchInfo()
            {
                RecognizedParts = new Dictionary<int, PhysPersonInfoPart>();
                NonRecognizedParts = new Dictionary<int, string>();
            }
            public bool IsSurnameUkrRecognized = false;
            public bool IsNameUkrRecognized = false;
            public bool IsMiddleNameUkrRecognized = false;
            public bool IsFullNameUkrRecognized = false;
            public bool IsSurnameRecognized = false;
            public bool IsNameRecognized = false;
            public bool IsMiddleNameRecognized = false;
            public bool IsFullNameRecognized = false;
            public bool IsSexRecognized = false;
            public bool IsBirthDateRecognized = false;
            public bool IsPassportIDRecognized = false;
            public bool IsPassIssuedDateRecognized = false;
            public bool IsPassIssueAuthorityRecognized = false;
            public bool IsTaxOrSocSecIDRecognized = false;
            public bool IsAddressRecognized = false;
            public bool IsCitizenshipCountryRecognized = false;

            public Dictionary<int, PhysPersonInfoPart> RecognizedParts
            {
                get;
                private set;
            }
            public Dictionary<int, string> NonRecognizedParts { get; private set; }

        }
        #endregion

        #region parse method(s)
        public static void TryParseFillPassIssueData(string rawData, PhysicalPersonInfo target)
        {
            ParseMatchInfo pmi;
            TryParseFillPassIssueData(rawData, target, out pmi);
        }

        public static void TryParseFillPassIssueData(string rawData, PhysicalPersonInfo target, out ParseMatchInfo pmi)
        {
            string remString = rawData;
            pmi = new ParseMatchInfo();
            int i = 0;
            {
                bool matched = false;
                if (!pmi.IsPassportIDRecognized)
                {
                    string currMatchedString;
                    matched = MatchPassID(remString, 0, 1, target, out currMatchedString);
                    if (matched) { pmi.IsPassportIDRecognized = true; pmi.RecognizedParts.Add(i++, PhysPersonInfoPart.PassportID); remString = remString.Replace(currMatchedString, string.Empty); }
                }
                if (!pmi.IsPassIssuedDateRecognized)
                {
                    string currMatchedString;
                    matched = MatchPassIssueDt(remString, 0, 1, target, out currMatchedString);
                    if (matched) { pmi.IsPassIssuedDateRecognized = true; pmi.RecognizedParts.Add(i++, PhysPersonInfoPart.PassIssuedDate); ; remString = remString.Replace(currMatchedString, string.Empty); }
                }
                if (!pmi.IsPassIssueAuthorityRecognized)
                {
                    string currMatchedString;
                    matched = MatchPassIssueAuthority(remString, 0, 1, target, out currMatchedString);
                    if (matched) { pmi.IsPassIssueAuthorityRecognized = true; pmi.RecognizedParts.Add(i++, PhysPersonInfoPart.PassIssueAuthority); ; remString = remString.Replace(currMatchedString, string.Empty); }
                }
                pmi.NonRecognizedParts.Add(0, remString);
            }

        }

        private static readonly Regex _rgxPassIDUA = new Regex("[А-Я]{2}([ ]*№[ ]*|[ ]*ї[ ]*|[ ]*)[0-9]{6}");
        private static readonly Regex _rgxPassIssueDtUA = new Regex("[0-9]{1,2}(\\.|\\/|\\-)[0-9]{1,2}(\\.|\\/|\\-)([0-9]{4}|[0-9]{2})[ ]*(р.|г.|року|рік|)");
        
        #region match helper methods
        public static bool MatchPassID(string src, int wordIdx, int wordsCount, PhysicalPersonInfo target, out string matchedString)
        {
            matchedString = string.Empty;
            if (target.CitizenshipCountry == null || target.CitizenshipCountry.CountryISONr == CountryInfo.UKRAINE.CountryISONr)
            {
                Match m = _rgxPassIDUA.Match(src);
                if (m.Length == 0)
                    return false;
                matchedString = m.Groups[0].Captures[0].Value;
                string res = matchedString;
                if (m.Groups.Count > 1)
                {
                    string splitter = m.Groups[1].ToString();
                    res = res.Replace(splitter, " ");
                    
                }
                target.PassportID = res;
                return true;
            }
            return false;
        }

        public static bool MatchPassIssueDt(string src, int wordIdx, int wordsCount, PhysicalPersonInfo target, out string matchedString)
        {
            matchedString = string.Empty;
            
            Match m = _rgxPassIssueDtUA.Match(src);
            if (m.Length == 0)
                return false;

            DateTime dt;
            matchedString = m.Groups[0].Captures[0].Value;
            if(DateTime.TryParse(matchedString, out dt))
            {
                target.PassIssuedDate = dt;
                return true;
            }
            return false;
        }

        public static bool MatchPassIssueAuthority(string src, int wordIdx, int wordsCount, PhysicalPersonInfo target, out string matchedString)
        {
            matchedString = string.Empty;
            string[] tokens = new string[] { "вид.", "вид", "виданий", "видане", "видана"};

            int matchedTokenIdx = -1;

            List<string> words = LocationInfo.NormalizeAbbrs(Regex.Split(src, @"(\W|')+").ToList());
            for (int tokenIdx = 0; tokenIdx < tokens.Length; tokenIdx++)
            {
                bool bFound = false;
                foreach (string currWord in words)
                {
                    if (currWord.Trim().ToLower() == tokens[tokenIdx].Trim().ToLower())
                    {
                        bFound = true;
                        matchedTokenIdx = tokenIdx;
                        break;
                    }
                }
                if (!bFound)
                    continue;
                matchedTokenIdx = tokenIdx;
                break;
            }
            bool rslt = (matchedTokenIdx != -1);
            if (rslt)
            {
                int pos0 = src.ToLower().IndexOf(tokens[matchedTokenIdx]);
                
                string rawRes = src.Substring(pos0).Trim();
                char lastChar = rawRes[rawRes.Length-1];
                if(lastChar == ',' || lastChar == '.')
                    rawRes = rawRes.Substring(0,rawRes.Length -1).Trim();
                matchedString = rawRes;
                string res = rawRes.Substring(tokens[matchedTokenIdx].Length).Trim();
                target.PassIssueAuthority = new RegistrarAuthority();
                if (target.CitizenshipCountry != null) target.PassIssueAuthority.JurisdictionCountry = target.CitizenshipCountry;
                target.PassIssueAuthority.EntitiesHandled = EntityType.Physical;
                target.PassIssueAuthority.RegistrarName = res;
            }
            return rslt;
        }
        #endregion

        #endregion

        public override string ToString()
        {
            return FullName;
        }
    }
}
