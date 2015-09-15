using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BGU.DRPL.SignificantOwnership.EmpiricalData.Scraping
{
    public class ArkadaOwnershipChainDescriptionParser
    {
        #region field(s)
        private const string SHAREHOLDER_FMT = "Акціонер ПАТ  АКБ  \"АРКАДА\" (частка 0.0000453628%)";
        private const string CONTROLLER_FMT = "Контролер  Bouret S.A.";
        private const string WHICH_POSSESSES_FMT = "якому  належить 44.6% акцій  ТОВ \"Будеволюція\"";
        private const string VIA_FMT = "Через ТОВ \"Бориспіль-Інвест-Перспективи\" (частка 22%) ";

        private const string SHAREHOLDER_WORDING_START = "Акціонер[ ]+";
        private const string CONTROLLER_WORDING_START = "Контролер[ ]+";
        private const string WHICH_POSSESSES_WORDING_START = "якому[ ]+належить[ ]+";
        private const string VIA_WORDING_START = "Через[ ]+";
        private const string ON_BEHALF_OF_WORDING_START = "від[ ]+імені[ ]+";
        private const string ON_BEHALF_OF2_WORDING_START = "діє[ ]+від[ ]+";
        private const string WHICH_IS_CONTROLLER_WORDING_START = "який[ ]+є[ ]+контролером[ ]+";

        private static readonly Dictionary<WordingType, WordingParseHandler> WORDING_PARSE_HANDLERS;
        private static readonly Dictionary<string, WordingType> WORDING_STARTS2TYPES;
        private static readonly string WORDINGS_SPLIT_PTRN;
        #endregion

        #region cctor(s)
        static ArkadaOwnershipChainDescriptionParser()
        {
            #region parsers
            WORDING_PARSE_HANDLERS = new Dictionary<WordingType, WordingParseHandler>();
            WORDING_PARSE_HANDLERS.Add(WordingType.Shareholder, null); //todo
            WORDING_PARSE_HANDLERS.Add(WordingType.Controller, null); //todo
            WORDING_PARSE_HANDLERS.Add(WordingType.WhichPossesses, null); //todo
            WORDING_PARSE_HANDLERS.Add(WordingType.Via, null); //todo
            WORDING_PARSE_HANDLERS.Add(WordingType.OnBehalf, null); //todo
            WORDING_PARSE_HANDLERS.Add(WordingType.ActsOnBehalf, null); //todo
            WORDING_PARSE_HANDLERS.Add(WordingType.WhichIsController, null); //todo
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
            //Regex r1 = new Regex(
            string[] matches = Regex.Split(ownChainDescr, WORDINGS_SPLIT_PTRN, RegexOptions.IgnoreCase | RegexOptions.Multiline);
            //int nxtWordingPos = -1;

            //do { 
            //    nxtWordingPos = 
            //}
            //while (nxtWordingPos != -1);
            foreach (string match in matches)
                Console.WriteLine(match);

            return rslt;
        }


        private delegate void WordingParseHandler(string wholeWording, out decimal pct, out string assetName);
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

        public class WordingItem
        {
            public WordingType WT {get;set;}
            public string Wording {get;set;}
        }
    }

}
