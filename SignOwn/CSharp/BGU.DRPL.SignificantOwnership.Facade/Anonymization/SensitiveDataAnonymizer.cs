using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Questionnaires;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;
using System.Threading;

namespace BGU.DRPL.SignificantOwnership.Facade.Anonymizing
{
    public class SensitiveDataAnonymizer
    {
        private List<string> _usedPhysicalPersonCodes;
        private List<string> _usedLegalPersonCodes;
        private Dictionary<GenericPersonID, GenericPersonID> _old2NewIds;
        private List<GenericPersonInfo> _oldGPIs;
        private List<GenericPersonInfo> _newGPIs;

        public SensitiveDataAnonymizer()
        {
            _usedLegalPersonCodes = new List<string>();
            _usedPhysicalPersonCodes = new List<string>();
        }

        public void AnonymizeCodes(IQuestionnaire subj)
        {
            //todo
        }

        public Dictionary<GenericPersonID, GenericPersonID> GeneratePersonIDs(List<GenericPersonID> haystack)
        {
            List<string> alreadyProcessed = new List<string>();
            Dictionary<GenericPersonID, GenericPersonID> rslt = new Dictionary<GenericPersonID, GenericPersonID>();
            foreach (GenericPersonID key in haystack)
            {
                Console.WriteLine("about to process key {0}", key.HashID);
                if (alreadyProcessed.Contains(key.HashID))
                    continue;
                GenericPersonID currNew = GeneratePersonCode(key);
                alreadyProcessed.Add(currNew.HashID);
                rslt.Add(key, currNew);
            }

            return rslt;
        }

        public GenericPersonInfo AnonymizePerson(GenericPersonInfo src)
        {
            return null;
        }

        public void SetSourceInfo(List<GenericPersonInfo> mentionedIdentities)
        { 
        }

        public GenericPersonID GeneratePersonCode(GenericPersonID oldId)
        {
            Console.WriteLine("In GeneratePersonCode({0})", oldId);
            GenericPersonID rslt = new GenericPersonID() { CountryISO3Code = oldId.CountryISO3Code, DisplayName = oldId.DisplayName, PersonType = oldId.PersonType };
            bool bFinish = false;
            string code = string.Empty;
            while (!bFinish)
            {
                switch (rslt.PersonType)
                {
                    case BGU.DRPL.SignificantOwnership.Core.Spares.EntityType.Physical:
                        {
                            code = GeneratePhysicalPersonIPN();
                            if (!_usedPhysicalPersonCodes.Contains(code))
                            {
                                _usedPhysicalPersonCodes.Add(code);
                                bFinish = true;
                            }
                        }
                        break;
                    case BGU.DRPL.SignificantOwnership.Core.Spares.EntityType.Legal:
                        {
                            code = GenerateYeDRPOU();
                            if (!_usedLegalPersonCodes.Contains(code))
                            {
                                _usedLegalPersonCodes.Add(code);
                                bFinish = true;
                            }
                        }
                        break;
                    default:
                        break;
                }
                if (!bFinish)
                    Thread.Sleep(100);
            }
            rslt.PersonCode = code;
            return rslt;
        }

        public string GeneratePhysicalPersonIPN()
        {
            return GenerateRandomStringWorker(10);
        }

        public string GenerateYeDRPOU()
        {
            return GenerateRandomStringWorker(8);
        }

        private string GenerateRandomStringWorker(int len)
        {
            Random r = new Random();
            string rslt = string.Empty;
            while (rslt.Length < len)
            {
                double dbl = r.NextDouble();
                rslt += (dbl * 10000000000).ToString().Replace(".", string.Empty).Replace(",", string.Empty);
            }
            return rslt.Substring(0, len);
        }

    }
}
