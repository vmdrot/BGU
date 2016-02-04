using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Questionnaires;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;
using System.Threading;
using BGU.DRPL.SignificantOwnership.Core.Interfaces;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;

namespace BGU.DRPL.SignificantOwnership.Facade.Anonymizing
{
    public class SensitiveDataAnonymizer: ISensitiveDataAnonymizer
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

        public void GeneratePersonIDs()
        {
            Console.WriteLine("in GeneratePersonIDs");
            List<GenericPersonID> oldIds = new List<GenericPersonID>(from mi in _oldGPIs
                                select mi.ID);

            _old2NewIds = GeneratePersonIDs(oldIds);
            Console.WriteLine("GeneratePersonIDs, _old2NewIds.Count = {0}", _old2NewIds.Count);
        }
        public void ReplacePersonIDs(List<GenericPersonInfo> subj)
        {
            if (subj == null)
                return;
            foreach(GenericPersonInfo gpi in subj)
            {
                switch(gpi.PersonType)
                {
                    case Core.Spares.EntityType.Legal:     gpi.LegalPerson.TaxCodeOrHandelsRegNr = _old2NewIds[gpi.ID].PersonCode; break;
                    case Core.Spares.EntityType.Physical:  gpi.PhysicalPerson.TaxOrSocSecID      = _old2NewIds[gpi.ID].PersonCode; break;
                    default: break;
                }
            }
        }

        public void ReplacePersonIDs(List<OwnershipStructure> subj)
        {
            if (subj == null)
                return;
            foreach (OwnershipStructure os in subj)
            {
                os.Owner = _old2NewIds[os.Owner];
                os.Asset = _old2NewIds[os.Asset];
            }
        }

        public void ReplacePersonIDs(List<TotalOwnershipDetailsInfoEx> subj)
        {
            if (subj == null)
                return;
            foreach (TotalOwnershipDetailsInfoEx todix in subj)
            {
                if (todix.OwnerID.IsEmpty)
                    continue;
                todix.OwnerID = _old2NewIds[todix.OwnerID];
            }

        }
        public void ReplacePersonID(BankInfo subj)
        {
            if (subj == null)
                return;
            subj.LegalPerson = _old2NewIds[subj.LegalPerson];
        }

        public void ReplacePersonIDs(List<PersonsAssociation> subj)
        {
            if (subj == null)
                return;
            foreach (PersonsAssociation pl in subj)
            {
                pl.One = _old2NewIds[pl.One];
                pl.Two = _old2NewIds[pl.Two];
            }
        }
        

        public GenericPersonInfo AnonymizePerson(GenericPersonInfo src)
        {
            return null;
        }

        public void SetSourceInfo(List<GenericPersonInfo> mentionedIdentities)
        {
            _oldGPIs = new List<GenericPersonInfo>();
            _oldGPIs.AddRange( mentionedIdentities);
            Console.WriteLine("SetSourceInfo, _oldGPIs.Count = {0}", _oldGPIs.Count);
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
