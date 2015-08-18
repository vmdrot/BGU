using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Dict
{
    /// <summary>
    /// Відомості про адресу; використовується як реквізити юр./фіз.особи, держоргану, тощо
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.LocationInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class LocationInfo
    {

        public LocationInfo()
        {
            Country = CountryInfo.UKRAINE;
        }
        /// <summary>
        /// За змовчанням - Україна
        /// </summary>
        [DisplayName("Країна")]
        [Description("Країна")]
        [Required]
        public CountryInfo Country { get; set; }
        /// <summary>
        /// Якщо потрібно
        /// </summary>
        [DisplayName("область/провінція, тощо")]
        [Description("область/провінція, тощо")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MaxWidth = "400", MinWidth = "350")]
        public string Region { get; set; }
        /// <summary>
        /// Якщо потрібно
        /// </summary>
        [DisplayName("район/графство, тощо")]
        [Description("район/графство, тощо")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline=false, MaxWidth="400", MinWidth="350")]
        public string Raion { get; set; }
        /// <summary>
        /// Залежно від контексту, у більшості випадків - бажано
        /// </summary>
        [DisplayName("Поштовий індекс")]
        [Description("Поштовий індекс")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MaxWidth = "150", MinWidth = "100")]
        public string ZipCode { get; set; }
        /// <summary>
        /// Обов'язкове поле (скрізь)
        /// </summary>
        [DisplayName("Населений пункт")]
        [Description("Населений пункт")]
        [Required]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MaxWidth = "300", MinWidth = "150")]
        public string City { get; set; }
        /// <summary>
        /// Якщо вимагається контекстом
        /// </summary>
        [DisplayName("Вулиця/площа/тощо")]
        [Description("Вулиця/площа/тощо")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MaxWidth = "300", MinWidth = "150")]
        public string Street { get; set; }
        /// <summary>
        /// Якщо вимагається контекстом
        /// </summary>
        [DisplayName("№ / назва будинку")]
        [Description("№ / назва будинку")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MaxWidth = "300", MinWidth = "75")]
        public string HouseNr { get; set; }
        /// <summary>
        /// Якщо вимагається контекстом та передбачено/існує
        /// </summary>
        [DisplayName("№ кв./офісу, тощо")]
        [Description("№ кв./офісу, тощо")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MaxWidth = "300", MinWidth = "75")]
        public string ApptOfficeNr { get; set; }

        #region inner type(s)
        public class ParseMatchInfo
        {
            public ParseMatchInfo()
            {
                RecognizedParts = new Dictionary<int,AddressPart>();
                NonRecognizedParts = new Dictionary<int,string>();
            }
            public bool IsCountryMatched = false;
            public bool IsRegionMatched = false;
            public bool IsRaionMatched = false;
            public bool IsZipCodeMatched = false;
            public bool IsCityMatched = false;
            public bool IsStreetMatched = false;
            public bool IsHouseNrMatched = false;
            public bool IsApptOfficeNrMatched = false;
            public Dictionary<int, AddressPart> RecognizedParts
            {
                get;
                private set;
            }
            public Dictionary<int, string> NonRecognizedParts { get; private set; }


        }

        #endregion

        #region Parse methods
        public static LocationInfo Parse(string addressStr)
        {
            ParseMatchInfo pmi;
            return Parse(addressStr, out pmi);
        }

        public static LocationInfo Parse(string addressStr, out ParseMatchInfo pmi)
        {
            pmi = new ParseMatchInfo();
            if (string.IsNullOrEmpty(addressStr) /*|| string.IsNullOrWhiteSpace(addressStr)*/)
                return null;
            LocationInfo rslt = new LocationInfo();
            string[] words = addressStr.Split(',');
            
            for (int i = 0; i < words.Length; i++)
            {
                bool matched = false;
                if (!pmi.IsZipCodeMatched)
                {
                    matched = MatchZipCode(words[i], i, words.Length, rslt);
                    if (matched) { pmi.IsZipCodeMatched = true; pmi.RecognizedParts.Add(i, AddressPart.ZipCode); }
                }
                if (!matched && !pmi.IsCountryMatched)
                {
                    CountryInfo ctry = CountryInfo.MatchCountry(words[i]);
                    matched = (ctry == null);
                    if (matched) { pmi.IsCountryMatched = true; pmi.RecognizedParts.Add(i, AddressPart.Country); }
                }
                if (!matched && !pmi.IsRegionMatched)
                {
                    matched = MatchRegion(words[i], i, words.Length, rslt);
                    if (matched) { pmi.IsRegionMatched = true; pmi.RecognizedParts.Add(i, AddressPart.Region); }
                }
                if (!matched && !pmi.IsRaionMatched)
                {
                    matched = MatchRaion(words[i], i, words.Length, rslt);
                    if (matched) { pmi.IsRaionMatched = true; pmi.RecognizedParts.Add(i, AddressPart.Raion); }
                }
                if (!matched && !pmi.IsCityMatched)
                {
                    matched = MatchCity(words[i], i, words.Length, rslt);
                    if (matched) { pmi.IsCityMatched = true; pmi.RecognizedParts.Add(i, AddressPart.City); }
                }
                if (!matched && !pmi.IsStreetMatched)
                {
                    matched = MatchStreet(words[i], i, words.Length, rslt);
                    if (matched) { pmi.IsStreetMatched = true; pmi.RecognizedParts.Add(i, AddressPart.Street); }
                }
                if (!matched && !pmi.IsHouseNrMatched)
                {
                    matched = MatchHouseNr(words[i], i, words.Length, rslt);
                    if (matched) { pmi.IsHouseNrMatched = true; pmi.RecognizedParts.Add(i, AddressPart.HouseNr); }
                }
                if (!matched && !pmi.IsApptOfficeNrMatched)
                {
                    matched = MatchApptOfOfficeNr(words[i], i, words.Length, rslt);
                    if (matched) { pmi.IsApptOfficeNrMatched = true; pmi.RecognizedParts.Add(i, AddressPart.ApptOfficeNr); }
                }
                if (!matched)
                    pmi.NonRecognizedParts.Add(i, words[i]);
            }

            if (pmi.RecognizedParts.Count > 0)
            {
                foreach (int i in pmi.NonRecognizedParts.Keys)
                {
                    if (i > 0)
                    {
                        if (pmi.RecognizedParts.ContainsKey(i - 1))
                        {
                            switch(pmi.RecognizedParts[i-1])
                            {
                                case AddressPart.ZipCode:
                                    rslt.City = words[i];
                                    pmi.RecognizedParts.Add(i, AddressPart.City);
                                    break;
                                case AddressPart.Street:
                                    rslt.HouseNr = words[i];
                                    pmi.RecognizedParts.Add(i, AddressPart.HouseNr);
                                    break;
                                case AddressPart.HouseNr:
                                    rslt.ApptOfficeNr = words[i];
                                    pmi.RecognizedParts.Add(i, AddressPart.ApptOfficeNr);
                                    break;
                                default: break;

                            }
                        }

                    }
                }
                foreach (int idx in pmi.RecognizedParts.Keys)
                {
                    if (pmi.NonRecognizedParts.ContainsKey(idx))
                        pmi.NonRecognizedParts.Remove(idx);
                }
            }

            return rslt;

        }

        private static readonly Regex _rgxZipCode = new Regex("[0-9]{4,5}");
        private static readonly Regex _rgxWords = new Regex("[/w]+");

        public static bool MatchZipCode(string src, int wordIdx, int wordsCount, LocationInfo target)
        {
            Match m = _rgxZipCode.Match(src);
            if (m.Length == 0 || wordIdx > 0)
                return false;

            target.ZipCode = m.Groups[0].Captures[0].Value;
            return true;
        }

        private static int MatchEitherOfWords(string src, string[] words)
        {
            return -1;   
        }


        public static bool MatchStreet(string src, int wordIdx, int wordsCount, LocationInfo target)
        {
            string[] tokens = new string[] { "вул.", "ул.", "вулиця", "пров.", "пр.", "вул", "ул", "пров", "провулок", "пр", "пр-т", "бульв.", "бульв", "спуск", "узвіз", "проїзд", "тупик", "блвр", "проспект", "шосе", "шоссе", "пл", "пл.", "площа", "просп.", "просп"};

            int matchedTokenIdx = -1;

            List<string> words = NormalizeAbbrs(Regex.Split(src, @"(\W|')+").ToList());
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
                target.Street = src;
            }
            return rslt;
        }

        public static List<string> NormalizeAbbrs(List<string> list)
        {
            List<string> rslt = new List<string>();
            for (int i = 0; i < list.Count; i++)
            {
                if (string.IsNullOrEmpty(list[i]) /*|| string.IsNullOrWhiteSpace(list[i])*/)
                    continue;
                if (list[i] == ".")
                    rslt[rslt.Count - 1] += list[i];
                else
                    rslt.Add(list[i]);

            }
            return rslt;
        }


        public static bool MatchHouseNr(string src, int wordIdx, int wordsCount, LocationInfo target)
        {
            string[] tokens = new string[] { "буд.", "б."};

            int matchedTokenIdx = -1;

            List<string> words = NormalizeAbbrs(Regex.Split(src, @"(\W|')+").ToList());
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

                target.HouseNr = src;
            }
            return rslt;
        }

        public static bool MatchCity(string src, int wordIdx, int wordsCount, LocationInfo target)
        {
            string[] tokens = new string[] { "м.", "пос.", "c.", "смт", "смт.", "сел."};

            int matchedTokenIdx = -1;

            List<string> words = NormalizeAbbrs(Regex.Split(src, @"(\W|')+").ToList());
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

                target.City = src;
            }
            return rslt;
        }

        public static bool MatchRegion(string src, int wordIdx, int wordsCount, LocationInfo target)
        {
            string[] tokens = new string[] {"обл.","область"};
            int matchedTokenIdx = -1;
            for(int tokenIdx = 0; tokenIdx < tokens.Length;tokenIdx++)
            {
                int idx = src.IndexOf(tokens[tokenIdx]);
                if(idx == -1)
                    continue;
                matchedTokenIdx = tokenIdx;
                break;
            }
            bool rslt = (matchedTokenIdx != -1);
            if (rslt)
            {
                if (!string.IsNullOrEmpty(target.Region))
                    target.Region += ", " + src;
                else
                    target.Region = src;
            }
            return rslt;
        }


        public static bool MatchApptOfOfficeNr(string src, int wordIdx, int wordsCount, LocationInfo target)
        {
            string[] tokens = new string[] { "кв.", "оф.", "офіс", "оффіс" };

            int matchedTokenIdx = -1;

            List<string> words = NormalizeAbbrs(Regex.Split(src, @"(\W|')+").ToList());
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

                target.ApptOfficeNr = src;
            }
            return rslt;
        }

        public static bool MatchRaion(string src, int wordIdx, int wordsCount, LocationInfo target)
        {
            string[] tokens = new string[] { "р-н", "район" };
            int matchedTokenIdx = -1;
            for (int tokenIdx = 0; tokenIdx < tokens.Length; tokenIdx++)
            {
                int idx = src.IndexOf(tokens[tokenIdx]);
                if (idx == -1)
                    continue;
                matchedTokenIdx = tokenIdx;
                break;
            }
            bool rslt = (matchedTokenIdx != -1);
            if (rslt)
            {

                if (!string.IsNullOrEmpty(target.Region))
                    target.Region += ", " + src;
                else
                    target.Region = src;
            }
            return rslt;
        }

        public enum AddressPart
        {
            None = 0,
            Country,
            Region,
            Raion,
            ZipCode,
            City,
            Street,
            HouseNr,
            ApptOfficeNr
        }
        #endregion

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}, {4}, {5}", Country, City, Region, Street, HouseNr, ApptOfficeNr);
        }
    }
}
