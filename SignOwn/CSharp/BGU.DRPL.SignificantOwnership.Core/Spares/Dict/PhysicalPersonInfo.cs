using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;
using System.Text.RegularExpressions;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;
using System.Xml.Serialization;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Dict
{
    /// <summary>
    /// Інформація про фіз.особу (реквізити)
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.PhysicalPersonInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class PhysicalPersonInfo : NotifyPropertyChangedBase
    {
        private const string CATEGORY_NAMES = "Ім'я";
        private const string CATEGORY_IPN = "Індивідуальний податковий номер";
        private const string CATEGORY_PASSPORT_DATA = "Паспортні дані";
        private const string CATEGORY_ADDRESSES = "Адреса(-и)";
        private const string CATEGORY_EXTRA_DATA = "Додаткова інформація";
        

        public PhysicalPersonInfo()
        {
            CitizenshipCountry = CountryInfo.UKRAINE;
        }

        private CountryInfo _CitizenshipCountry;
        /// <summary>
        /// Обов'язкове поле (окрім хіба ContactInfo)
        /// За змовчанням (пропонувати) - Україна
        /// </summary>
        [DisplayName("Громадянство")]
        [Description("Громадянство")]
        public CountryInfo CitizenshipCountry { get { return _CitizenshipCountry; } set { _CitizenshipCountry = value; OnPropertyChanged("CitizenshipCountry"); OnPropertyChanged("IsNonResident"); OnPropertyChanged("IsResident"); OnPropertyChanged("ShowIPNRefusalEvidence"); } }

        private bool _HasDoubleCitizenship;
        [DisplayName("Має інше громадянство?")]
        [Description("Особа має додаткове (подвійне) громадянство іншої(-их) країн(-и)")]
        public bool HasDoubleCitizenship { get { return _HasDoubleCitizenship; } set { _HasDoubleCitizenship = value; OnPropertyChanged("HasDoubleCitizenship"); } }

        private List<CountryInfo> _DoubleCitizenshipCountries;
        [DisplayName("Додаткове(-і)/подвійне(-і) громадянство(-а)")]
        [Description("Відомості про подвійне громадянство інших країн, ніж вказаної в полі 'Громадянство'")]
        [UIConditionalVisibility("HasDoubleCitizenship")]
        public List<CountryInfo> DoubleCitizenshipCountries { get { return _DoubleCitizenshipCountries; } set { _DoubleCitizenshipCountries = value; OnPropertyChanged("DoubleCitizenshipCountries"); } }

        [Browsable(false)]
        [XmlIgnore]
        public bool IsNonResident { get { return CitizenshipCountry != null && CitizenshipCountry != CountryInfo.UKRAINE; } }

        [Browsable(false)]
        [XmlIgnore]
        public bool IsResident { get { return CitizenshipCountry != null && CitizenshipCountry == CountryInfo.UKRAINE; } }

        private string _Surname;
        [Category(CATEGORY_NAMES)]
        [DisplayName("Прізвище")]
        [Description("Прізвище")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "250")]
        public string Surname { get { return _Surname; } set { _Surname = value; OnPropertyChanged("Surname"); } }

        private string _Name;
        [Category(CATEGORY_NAMES)]
        [DisplayName("Ім'я")]
        [Description("Ім'я")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "250")]
        public string Name { get { return _Name; } set { _Name = value; OnPropertyChanged("Name"); } }

        private string _MiddleName;
        [Category(CATEGORY_NAMES)]
        [DisplayName("По-батькові/друге ім'я")]
        [Description("По-батькові/друге ім'я")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "250")]
        public string MiddleName { get { return _MiddleName; } set { _MiddleName = value; OnPropertyChanged("MiddleName"); } }

        private string _FullName;
        /// <summary>
        /// Вказувати достатньо повного імені; 
        /// Якщо є натхнення (або вимагає анкета) - можна й деталізацію по полях
        /// Для нерезидентів бажано вимагати як окремих частин імені, 
        /// так і повного (повністю) (бо хто його там зна, як до нього звертатися)
        /// </summary>
        [Category(CATEGORY_NAMES)]
        [DisplayName("П.І.Б.")]
        [Description("П.І.Б.")]
        [Required]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "250")]
        public string FullName { get { return _FullName; } set { _FullName = value; OnPropertyChanged("FullName"); } }

        private string _SurnameUkr;
        /// <summary>
        /// для нерезидентів
        /// </summary>
        [Category(CATEGORY_NAMES)]
        [DisplayName("Прізвище (укр.)")]
        [Description("Прізвище, українською")]
        [UIConditionalVisibility("IsNonResident")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "250")]
        public string SurnameUkr { get { return _SurnameUkr; } set { _SurnameUkr = value; OnPropertyChanged("SurnameUkr"); } }

        private string _NameUkr;
        /// <summary>
        /// для нерезидентів
        /// </summary>
        [Category(CATEGORY_NAMES)]
        [DisplayName("Ім'я (укр.)")]
        [Description("Ім'я, українською")]
        [UIConditionalVisibility("IsNonResident")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "250")]
        public string NameUkr { get { return _NameUkr; } set { _NameUkr = value; OnPropertyChanged("NameUkr"); } }

        private string _MiddleNameUkr;
        /// <summary>
        /// для нерезидентів
        /// </summary>
        [Category(CATEGORY_NAMES)]
        [DisplayName("По-батькові/друге ім'я (укр.)")]
        [Description("По-батькові/друге ім'я, українською")]
        [UIConditionalVisibility("IsNonResident")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "250")]
        public string MiddleNameUkr { get { return _MiddleNameUkr; } set { _MiddleNameUkr = value; OnPropertyChanged("MiddleNameUkr"); } }

        private string _FullNameUkr;
        /// <summary>
        /// для нерезидентів
        /// </summary>
        [Category(CATEGORY_NAMES)]
        [DisplayName("П.І.Б (укр.)")]
        [Description("П.І.Б., українською")]
        [UIConditionalVisibility("IsNonResident")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "250")]
        public string FullNameUkr { get { return _FullNameUkr; } set { _FullNameUkr = value; OnPropertyChanged("FullNameUkr"); } }

        private bool _IsIPNRefused;
        [Category(CATEGORY_IPN)]
        [DisplayName("ІПН немає")]
        [Description("Особа у встановленому порядку відмовилася від індивідувального податкового номера?")]
        public bool IsIPNRefused { get { return _IsIPNRefused; } set { _IsIPNRefused = value; OnPropertyChanged("IsIPNRefused"); OnPropertyChanged("HasIPN"); OnPropertyChanged("ShowIPNRefusalEvidence"); } }


        [Browsable(false)]
        [XmlIgnore]
        public bool HasIPN { get { return !IsIPNRefused; } }

        [Browsable(false)]
        [XmlIgnore]
        public bool ShowIPNRefusalEvidence { get { return IsResident && IsIPNRefused; } }


        private IPNRefusalRecordInfo _IPNRefusalEvidence;
        [Category(CATEGORY_IPN)]
        [DisplayName("Відміка про відсутність ІПН-у")]
        [Description("Відомості про відповідний запи/відмітку в паспорті громадянина (про відмові від ІПН та погодження такої відмови)")]
        [UIConditionalVisibility("IsIPNRefused")]
        public IPNRefusalRecordInfo IPNRefusalEvidence { get { return _IPNRefusalEvidence; } set { _IPNRefusalEvidence = value; OnPropertyChanged("IPNRefusalEvidence"); } }

        private string _TaxOrSocSecID;
        [Category(CATEGORY_IPN)]
        [DisplayName("ІПН")]
        [Description("ІПН/№ картки соціального страхування/тощо, дивлячись, що використовується у країні резидентства")]
        [UIConditionalVisibility("HasIPN")]
        [Required("Not IsIPNRefused")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MaxWidth = "400", MinWidth = "250")]
        public string TaxOrSocSecID { get { return _TaxOrSocSecID; } set { _TaxOrSocSecID = value; OnPropertyChanged("TaxOrSocSecID"); } }

        private string _PassportID;
        [Category(CATEGORY_PASSPORT_DATA)]
        [DisplayName("Серія № паспорта")]
        [Description("Серія № паспорта")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "200")]
        public string PassportID { get { return _PassportID; } set { _PassportID = value; OnPropertyChanged("PassportID"); } }

        private DateTime? _PassIssuedDate;
        [Category(CATEGORY_PASSPORT_DATA)]
        [DisplayName("Дата видачі паспорта")]
        [Description("Дата видачі паспорта")]
        public DateTime? PassIssuedDate { get { return _PassIssuedDate; } set { _PassIssuedDate = value; OnPropertyChanged("PassIssuedDate"); } }

        private RegistrarAuthority _PassIssueAuthority;
        [Category(CATEGORY_PASSPORT_DATA)]
        [DisplayName("Орган, що видав паспорт")]
        [Description("Орган, що видав паспорт")]
        public RegistrarAuthority PassIssueAuthority { get { return _PassIssueAuthority; } set { _PassIssueAuthority = value; OnPropertyChanged("PassIssueAuthority"); } }

        private LocationInfo _Address;
        /// <summary>
        /// Поле необхідне лише якщо вимагається у анкеті
        /// </summary>
        [Category(CATEGORY_ADDRESSES)]
        [DisplayName("Місце реєстрації")]
        [Description("Місце реєстрації")]
        public LocationInfo Address { get { return _Address; } set { _Address = value; OnPropertyChanged("Address"); } }

        private bool _IsResidentialAndRegistrationAddressDifferent;
        /// <summary>
        /// 
        /// </summary>
        [Category(CATEGORY_ADDRESSES)]
        [DisplayName("Місце проживання й реєстрації відрізняються")]
        [Description("Відзначте цю галочку, якщо місце фактичного проживання цієї особи відрізняються від адреси її офіційної реєстрації")]
        public bool IsResidentialAndRegistrationAddressDifferent { get { return _IsResidentialAndRegistrationAddressDifferent; } set { _IsResidentialAndRegistrationAddressDifferent = value; OnPropertyChanged("IsResidentialAndRegistrationAddressDifferent"); } }


        private LocationInfo _ActualAddress;
        /// <summary>
        /// Поле необхідне лише якщо вимагається у анкеті, та якщо відрізняється від місця реєстрації.
        /// </summary>
        [Category(CATEGORY_ADDRESSES)]
        [DisplayName("Місце проживання")]
        [Description("Місце фактичного проживання (якщо інше, ніж реєстрації)")]
        [UIConditionalVisibility("IsResidentialAndRegistrationAddressDifferent")]
        public LocationInfo ActualAddress { get { return _ActualAddress; } set { _ActualAddress = value; OnPropertyChanged("ActualAddress"); } }

        private SexType _Sex;
        /// <summary>
        /// Бажано вимагати; дивитися за контекстом конкретного поля 
        /// у конкретній анкеті
        /// </summary>
        [Category(CATEGORY_EXTRA_DATA)]
        [DisplayName("Стать")]
        [Description("Стать")]
        public SexType Sex { get { return _Sex; } set { _Sex = value; OnPropertyChanged("Sex"); } }

        private DateTime? _BirthDate;
        /// <summary>
        /// Як правило, необов'язкове поле
        /// Буває, що онука називають як діда, і у ланцюжку володіння фігурують обидва
        /// Тоді корисно мати ще й дату народження, щоб відрізняти; 
        /// буває, що онук ще неповнолітній та не має паспорта/кода
        /// (реальний випадок - банк "Грант", щоправда, там, був код ІПН)
        /// </summary>
        [Category(CATEGORY_EXTRA_DATA)]
        [DisplayName("Дата народження")]
        [Description("Дата народження")]
        public DateTime? BirthDate { get { return _BirthDate; } set { _BirthDate = value; OnPropertyChanged("BirthDate"); } }

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
