using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Questionnaires;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;

namespace BGU.DRPL.SignificantOwnership.Facade.Anonymizing
{
    public class SensitiveDataAnonymizer
    {
        private List<string> _usedPhysicalPersonCodes;
        private List<string> _usedLegalPersonCodes;

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
            foreach (GenericPersonID key in rslt.Keys)
            {
                if (alreadyProcessed.Contains(key.HashID))
                    continue;

            }

            return rslt;
        }

        public string GeneratePersonCode(GenericPersonID oldId)
        {
            GenericPersonID rslt = new GenericPersonID() { CountryISO3Code = oldId.CountryISO3Code, DisplayName = oldId.DisplayName, PersonType = oldId.PersonType };
            while (true)
            { 

            }
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
