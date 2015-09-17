using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Globalization;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;
using BGU.DRPL.SignificantOwnership.EmpiricalData.Scraping.Data;
using BGU.DRPL.SignificantOwnership.Core.Questionnaires;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;
using System.IO;

namespace BGU.DRPL.SignificantOwnership.EmpiricalData.Scraping
{
    public class ArkadaOwnershipChainDescriptionParser
    {
        #region field(s)
        private const string SHAREHOLDER_FMT = "Акціонер ПАТ  АКБ  \"АРКАДА\" (частка 0.0000453628%)";
        private const string CONTROLLER_FMT = "Контролер  Bouret S.A.";
        private const string WHICH_POSSESSES_FMT = "якому  належить 44.6% акцій  ТОВ \"Будеволюція\"";
        private const string VIA_FMT = "Через ТОВ \"Бориспіль-Інвест-Перспективи\" (частка 22%) ";

        private const string SHAREHOLDER_WORDING_START = "Акціонер[ ]{0,1}";
        private const string CONTROLLER_WORDING_START = "Контролер[ ]{0,1}";
        private const string WHICH_POSSESSES_WORDING_START = "якому[ ]+належить[ ]{0,1}";
        private const string VIA_WORDING_START = "Через[ ]+";
        private const string ON_BEHALF_OF_WORDING_START = "від[ ]+імені[ ]{0,1}";
        private const string ON_BEHALF_OF2_WORDING_START = "діє[ ]+від[ ]{0,1}";
        private const string WHICH_IS_CONTROLLER_WORDING_START = "який[ ]+є[ ]+контролером[ ]{0,1}";
        private const string PCT_RGX_PTRN = "[0-9\\.\\,]+\\%";
        private static readonly Regex PCT_RGX = new Regex(PCT_RGX_PTRN, RegexOptions.IgnoreCase|RegexOptions.Multiline);

        private static readonly Dictionary<WordingType, WordingParseHandler> WORDING_PARSE_HANDLERS;
        private static readonly Dictionary<string, WordingType> WORDING_STARTS2TYPES;
        private static readonly Dictionary<string, Regex> WORDINGS2REGEXES;
        private static readonly string WORDINGS_SPLIT_PTRN;
        #endregion

        private static JsonSerializerSettings _jsonSerializationSettings;
        private static JsonSerializerSettings JsonSerializationSettings
        {
            get
            {
                if (_jsonSerializationSettings == null)
                {
                    _jsonSerializationSettings = new JsonSerializerSettings();
                    _jsonSerializationSettings.NullValueHandling = NullValueHandling.Ignore;
                    _jsonSerializationSettings.Formatting = Formatting.Indented;
                }
                return _jsonSerializationSettings;
            }
        }
        #region cctor(s)
        static ArkadaOwnershipChainDescriptionParser()
        {
            #region parsers
            WORDING_PARSE_HANDLERS = new Dictionary<WordingType, WordingParseHandler>();
            WORDING_PARSE_HANDLERS.Add(WordingType.Shareholder, ShareholderParseHandler); //todo
            WORDING_PARSE_HANDLERS.Add(WordingType.Controller, ControllerParseHandler); //todo
            WORDING_PARSE_HANDLERS.Add(WordingType.WhichPossesses, WhichPossessesParseHandler); //todo
            WORDING_PARSE_HANDLERS.Add(WordingType.Via, ViaParseHandler); //todo
            WORDING_PARSE_HANDLERS.Add(WordingType.OnBehalf, OnBehalfParseHandler); //todo
            WORDING_PARSE_HANDLERS.Add(WordingType.ActsOnBehalf, ActsOnBehalfParseHandler); //todo
            WORDING_PARSE_HANDLERS.Add(WordingType.WhichIsController, WhichIsControllerParseHandler); //todo
            #endregion

            #region wordings
            WORDING_STARTS2TYPES = new Dictionary<string, WordingType>();
            WORDING_STARTS2TYPES.Add(SHAREHOLDER_WORDING_START, WordingType.Shareholder);
            WORDING_STARTS2TYPES.Add(CONTROLLER_WORDING_START, WordingType.Controller);
            WORDING_STARTS2TYPES.Add(WHICH_POSSESSES_WORDING_START, WordingType.WhichPossesses);
            WORDING_STARTS2TYPES.Add(VIA_WORDING_START, WordingType.Via);
            WORDING_STARTS2TYPES.Add(ON_BEHALF_OF_WORDING_START, WordingType.OnBehalf);
            WORDING_STARTS2TYPES.Add(ON_BEHALF_OF2_WORDING_START, WordingType.ActsOnBehalf);
            WORDING_STARTS2TYPES.Add(WHICH_IS_CONTROLLER_WORDING_START, WordingType.WhichIsController);
            #endregion

            #region 
            WORDINGS2REGEXES = new Dictionary<string, Regex>();
            foreach (string key in WORDING_STARTS2TYPES.Keys)
            {
                WORDINGS2REGEXES.Add(key, new Regex(key,RegexOptions.Multiline | RegexOptions.IgnoreCase));
            }
            #endregion

            StringBuilder ptrn = new StringBuilder();
            ptrn.Append('(');
            int i = 0;
            foreach (string key in WORDING_STARTS2TYPES.Keys)
            {
                if (i > 0)
                    ptrn.Append('|');
                ptrn.Append(key);
                i++;
            }
            ptrn.Append(')');
            WORDINGS_SPLIT_PTRN = ptrn.ToString();
        }
        #endregion

        public List<WordingItem> SplitIntoWordings(string ownChainDescr)
        {
            List<WordingItem> rslt = new List<WordingItem>();
            //Console.WriteLine("WORDINGS_SPLIT_PTRN = '{0}'", WORDINGS_SPLIT_PTRN);
            string[] matches = Regex.Split(ownChainDescr, WORDINGS_SPLIT_PTRN, RegexOptions.IgnoreCase | RegexOptions.Multiline);
            WordingType? lastWordingType = null;

            foreach (string m in matches)
            {
                if(!IsContentLine(m))
                {
                    continue;
                }
                if (lastWordingType != null && (WordingType)lastWordingType != WordingType.None)
                {
                    decimal currPct;
                    string currAsset;
                    if (WORDING_PARSE_HANDLERS[(WordingType)lastWordingType]((WordingType)lastWordingType, m, out currPct, out currAsset))
                    {
                        currAsset = WordPdfParsingUtils.NormalizeStringValue(currAsset);
                        WordingItem wi = new WordingItem() { WT = (WordingType)lastWordingType, WordingRaw = m, Pct = currPct, Asset = currAsset };
                        rslt.Add(wi);
                        lastWordingType = null;
                    }
                }
                else
                {
                    lastWordingType = IdentifyWordingType(m);
                }

            }

            //int nxtWordingPos = -1;

            //do { 
            //    nxtWordingPos = 
            //}
            //while (nxtWordingPos != -1);
            //#region debugging-related
            //Console.WriteLine("dod2PrincipalRows:");
            //JsonSerializerSettings settings = new JsonSerializerSettings();
            //settings.NullValueHandling = NullValueHandling.Ignore;
            //settings.Formatting = Formatting.Indented;
            //string jsonStr = JsonConvert.SerializeObject(matches, settings);

            ////File.WriteAllText(@"D:\home\vmdrot\BGU\Specs\SignigicantOwnership\Testing\Arkada\dod2PrincipalRows.json", jsonStr, Encoding.Unicode);
            //Console.WriteLine(jsonStr);
            //Console.WriteLine("----------------------------------------------------------------");
            //#endregion
            //foreach (string match in matches)
            //    Console.WriteLine(match);

            

            return rslt;
        }


        private WordingType? IdentifyWordingType(string m)
        {
            foreach (string key in WORDINGS2REGEXES.Keys)
            {
                Match match = WORDINGS2REGEXES[key].Match(m);
                if (!IsMatched(match))
                    continue;
                return WORDING_STARTS2TYPES[key];
            }
            return null;
        }

        private static bool IsMatched(Match match)
        {
            if (match.Groups.Count == 0)
                return false;
            if (!match.Groups[0].Success)
                return false;
            if (match.Groups[0].Captures == null || match.Groups[0].Captures.Count == 0)
                return false;
            return true;

        }
        private static bool IsContentLine(string line)
        {
            string trimmedLine = TrimLine(line);
            return !string.IsNullOrEmpty(trimmedLine);
        }

        public static string TrimLine(string raw)
        {
            return raw.Replace("\r", " ").Replace("\u0007", " ").Trim();
        }

        private static bool MatchPct(string rawMatch, out decimal pct)
        {
            Match m = PCT_RGX.Match(rawMatch);
            if (!IsMatched(m))
            {
                pct = 0.00M;
                return false;
            }
            string trimmed = m.Groups[0].Captures[0].Value.Replace("%", string.Empty).Trim();
            //return decimal.TryParse(trimmed, NumberStyles.Any, CultureInfo.GetCultureInfoByIetfLanguageTag("en").NumberFormat, out pct);
            return decimal.TryParse(trimmed, NumberStyles.Any, CultureInfo.InvariantCulture.NumberFormat, out pct);
        }

        private static bool ShareholderParseHandler(WordingType wt, string wholeWording, out decimal pct, out string assetName)
        {
            pct = 0.00M;
            assetName = string.Empty;
            string trimmedWording = TrimLine(wholeWording);
            Regex sharePctRgx = new Regex(string.Format("\\(частка[ ]+{0}\\)", PCT_RGX_PTRN), RegexOptions.IgnoreCase | RegexOptions.Multiline);
            Match m = sharePctRgx.Match(trimmedWording);
            if (!IsMatched(m))
                return false;
            if (!MatchPct(m.Groups[0].Captures[0].Value, out pct))
                return false;

            assetName = trimmedWording.Substring(0, m.Groups[0].Captures[0].Index).Trim();
            return true; 
        }

        private static bool ControllerParseHandler(WordingType wt, string wholeWording, out decimal pct, out string assetName)
        {
            pct = 100.00M;
            assetName = TrimLine(wholeWording);
            return true;
        }
        
        private static bool WhichPossessesParseHandler(WordingType wt, string wholeWording, out decimal pct, out string assetName)
        {
            pct = 0.00M;
            assetName = string.Empty;

            string trimmedWording = TrimLine(wholeWording);
            Regex sharePctRgx = new Regex(string.Format("{0}[ ]+акцій[ ]+", PCT_RGX_PTRN), RegexOptions.IgnoreCase | RegexOptions.Multiline);
            Match m = sharePctRgx.Match(trimmedWording);

            if (!IsMatched(m))
                return false;
            if (!MatchPct(m.Groups[0].Captures[0].Value, out pct))
                return false;
            assetName = trimmedWording.Substring(m.Groups[0].Captures[0].Index + m.Groups[0].Captures[0].Length).Trim();
            return true;
        }
        
        private static bool ViaParseHandler(WordingType wt, string wholeWording, out decimal pct, out string assetName)
        {
            pct = 0.00M;
            assetName = string.Empty;

            string trimmedWording = TrimLine(wholeWording);
            Regex sharePctRgx = new Regex(string.Format("\\(частка[ ]+{0}\\)", PCT_RGX_PTRN), RegexOptions.IgnoreCase | RegexOptions.Multiline);
            Match m = sharePctRgx.Match(trimmedWording);

            if (!IsMatched(m))
                return false;
            if (!MatchPct(m.Groups[0].Captures[0].Value, out pct))
                return false;

            assetName = trimmedWording.Substring(0, m.Groups[0].Captures[0].Index).Trim();

            return true;
        }

        private static bool OnBehalfParseHandler(WordingType wt, string wholeWording, out decimal pct, out string assetName)
        {
            pct = 100.00M;
            assetName = TrimLine(wholeWording);

            return true;
        }
        
        private static bool ActsOnBehalfParseHandler(WordingType wt, string wholeWording, out decimal pct, out string assetName)
        {
            pct = 100.00M;
            
            string trimmedLine = TrimLine(wholeWording);
            if(trimmedLine[trimmedLine.Length -1] == ')')
                trimmedLine = trimmedLine.Substring(0,trimmedLine.Length-1);
            assetName = trimmedLine;

            return true;
        }
        
        private static bool WhichIsControllerParseHandler(WordingType wt, string wholeWording, out decimal pct, out string assetName)
        {
            pct = 100.00M;

            string trimmedLine = TrimLine(wholeWording);
            if (trimmedLine[trimmedLine.Length - 1] == ')')
                trimmedLine = trimmedLine.Substring(0, trimmedLine.Length - 1);
            assetName = trimmedLine;

            return true;
        }

        private static void PrintMatch(Match m)
        {
            return;
            string jsonStr = JsonConvert.SerializeObject(m, JsonSerializationSettings);
            Console.WriteLine(jsonStr);
            Console.WriteLine("----------------------------------------------------------------");
        }

        public static void FillOwners(Dictionary<string, List<ArkadaOwnershipChainDescriptionParser.WordingItem>> rslt, out Dictionary<string, List<ArkadaOwnershipChainDescriptionParser.WordingItem>> errors)
        {
            errors = new Dictionary<string, List<ArkadaOwnershipChainDescriptionParser.WordingItem>>();
            foreach (string key in rslt.Keys)
            {
                List<ArkadaOwnershipChainDescriptionParser.WordingItem> currItems = rslt[key];
                for (int i = 0; i < currItems.Count; i++)
                {
                    BGU.DRPL.SignificantOwnership.EmpiricalData.Scraping.ArkadaOwnershipChainDescriptionParser.WordingItem wi = currItems[i];
                    switch (wi.WT)
                    {
                        case ArkadaOwnershipChainDescriptionParser.WordingType.Shareholder:
                        case ArkadaOwnershipChainDescriptionParser.WordingType.Controller:
                            if (string.IsNullOrEmpty(wi.Owner))
                                wi.Owner = key;
                            break;
                        case ArkadaOwnershipChainDescriptionParser.WordingType.WhichPossesses:
                        case ArkadaOwnershipChainDescriptionParser.WordingType.Via:
                        case ArkadaOwnershipChainDescriptionParser.WordingType.OnBehalf:
                        case ArkadaOwnershipChainDescriptionParser.WordingType.ActsOnBehalf:
                        case ArkadaOwnershipChainDescriptionParser.WordingType.WhichIsController:
                            if (string.IsNullOrEmpty(wi.Owner))
                            {
                                if (i > 0)
                                    wi.Owner = currItems[i - 1].Asset;
                                else
                                {
                                    if (wi.WT == ArkadaOwnershipChainDescriptionParser.WordingType.Via)
                                    {
                                        wi.Owner = key;
                                    }
                                    else
                                    {
                                        if (!errors.ContainsKey(key))
                                            errors.Add(key, new List<ArkadaOwnershipChainDescriptionParser.WordingItem>());
                                        errors[key].Add(wi);
                                    }
                                }

                            }
                            break;
                        case ArkadaOwnershipChainDescriptionParser.WordingType.None:
                        default:
                            break;
                    }
                }
            }
        }

        #region inner type(s)
        private delegate bool WordingParseHandler(WordingType wt, string wholeWording, out decimal pct, out string assetName);
        public enum WordingType
        { 
            None = 0,
            Shareholder, 
            Controller,
            WhichPossesses,
            Via,
            OnBehalf,
            ActsOnBehalf,
            WhichIsController
        }

        public static BGU.DRPL.SignificantOwnership.Core.Questionnaires.Appx2OwnershipStructLP ConvertWordingItems2OwnershipHive(Dictionary<string, List<ArkadaOwnershipChainDescriptionParser.WordingItem>> wis, List<Post328Dod2V1Row> dod2Rows, string bankRefName)
        {
            Appx2OwnershipStructLP rslt = new Appx2OwnershipStructLP();
            rslt.BankExistingCommonImplicitOwners = new List<OwnershipStructure>();
            rslt.MentionedIdentities = new List<GenericPersonInfo>();
            string normalBkRefName = WordPdfParsingUtils.NormalizeStringValue(bankRefName);
            GenericPersonInfo bk = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Legal, LegalPerson = new LegalPersonInfo() { Name = normalBkRefName, TaxCodeOrHandelsRegNr = normalBkRefName, ResidenceCountry = CountryInfo.UKRAINE } };
            rslt.BankRef = new Core.Spares.Dict.BankInfo() { Name = normalBkRefName, OperationCountry = CountryInfo.UKRAINE, LegalPerson = bk.ID };
            Dictionary<string, GenericPersonInfo> names2GPIs = new Dictionary<string, GenericPersonInfo>();
            names2GPIs.Add(normalBkRefName, bk);
            foreach (Post328Dod2V1Row d2r in dod2Rows)
            {
                if (names2GPIs.ContainsKey(d2r.Name))
                    continue;
                GenericPersonInfo gpi = (GenericPersonInfo)d2r;
                names2GPIs.Add(d2r.Name, gpi);
            }

            foreach(string key in wis.Keys)
            {
                foreach (WordingItem wi in wis[key])
                {
                    OwnershipStructure currOS = new OwnershipStructure();
                    if (!names2GPIs.ContainsKey(wi.Owner))
                        AddLP(wi.Owner, names2GPIs);
                    if (!names2GPIs.ContainsKey(wi.Asset))
                        AddLP(wi.Asset, names2GPIs);
                    currOS.Asset = names2GPIs[wi.Asset].ID;
                    currOS.Owner = names2GPIs[wi.Owner].ID;
                    currOS.SharePct = wi.Pct;
                    currOS.OwnershipKind = Core.Spares.OwnershipType.Direct;
                    //OwnershipStructure dupl = rslt.BankExistingCommonImplicitOwners.Find(os => os.Owner == currOS.Owner && os.Asset == currOS.Asset);
                    //if(dupl != null)

                    rslt.BankExistingCommonImplicitOwners.Add(currOS);
                }
            }

            rslt.MentionedIdentities = new List<GenericPersonInfo>(names2GPIs.Values);
            
            return rslt;
        }

        private static void AddLP(string name, Dictionary<string, GenericPersonInfo> names2GPIs)
        {
            GenericPersonInfo gpi = new GenericPersonInfo();
            gpi.PersonType = Core.Spares.EntityType.Legal;
            gpi.LegalPerson = new LegalPersonInfo() { Name = name, ResidenceCountry = CountryInfo.UKRAINE, TaxCodeOrHandelsRegNr = name };
            names2GPIs.Add(name, gpi);
        }

        public class WordingItem
        {
            public WordingType WT {get;set;}
            public string WordingRaw {get;set;}
            public string Asset { get; set; }
            public string Owner { get; set; }
            public decimal Pct { get; set; }

            //public static explicit operator OwnershipStructure(WordingItem wi)
            //{
            //    OwnershipStructure rslt = new OwnershipStructure();
            //    rslt.Asset = new GenericPersonID() { wi.Asset };
            //    rslt.Owner = wi.Owner;
            //    rslt.OwnershipKind = Core.Spares.OwnershipType.Direct;
            //    rslt.SharePct = wi.Pct;
            //    return rslt;
            //}
        }

        #endregion
    }

}
