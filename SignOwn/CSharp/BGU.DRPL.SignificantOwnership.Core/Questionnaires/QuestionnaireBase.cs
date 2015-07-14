using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;
using BGU.DRPL.SignificantOwnership.Core.Spares;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;
using Evolvex.Utility.Core.Common;

namespace BGU.DRPL.SignificantOwnership.Core.Questionnaires
{
    public abstract class QuestionnaireBase : NotifyPropertyChangedBase, IQuestionnaire
    {
        private static readonly ILog log = Logging.GetLogger(typeof(QuestionnaireBase));

        protected abstract string QuestionnairePrefixForFileName {get;}
        protected abstract string BankNameForFileName { get; }
        protected abstract string ApplicantNameForFileName { get; }

        protected virtual void AddBankToMentionedIdentities(BankInfo bank)
        {
            log.Debug("AddBankToMentionedIdentities: entering...");
            if (bank == null || bank.LegalPerson == null || bank.LegalPerson.IsEmpty)
                return;
            //GenericPersonInfo gpi = MentionedIdentities.Find(o => o.ID == bank.LegalPerson);
            //if (gpi != null)
            //    return;
            //DataTable dt = RcuKruReader.Search(RcuKruReader.Read("RCUKRU.DBF"), bank.MFO);
            //if (dt != null && dt.Rows != null && dt.Rows.Count > 10)
            //    return;
            //if (dt == null || dt.Rows != null || dt.Rows.Count == 0)
            //    return;
            //BankInfo bi = BankInfo.ParseFromRcuKruRow(dt.Rows[0], out gpi);
            GenericPersonInfo gpi = new GenericPersonInfo() { PersonType = Spares.EntityType.Legal, LegalPerson = new LegalPersonInfo() { Name = bank.Name, NameUkr = bank.NameUkr, TaxCodeOrHandelsRegNr = bank.LegalPerson.PersonCode, ResidenceCountry = CountryInfo.AllCountries.Find(c => c.CountryISONr == bank.LegalPerson.CountryISO3Code) } };
            DoAddToMentionedEntities(gpi);
            OnPropertyChanged("MentionedIdentities");
            OnPropertyChanged("MentionedGenericPersons");

        }

        protected abstract void DoAddToMentionedEntities(GenericPersonInfo gpi);

        protected virtual string GetBankNameForFileName(BankInfo bankRef)
        {
            if (bankRef == null) return string.Empty; return bankRef.MFO ?? bankRef.SWIFTBIC;
        }
        
        public virtual string SuggestSaveAsFileName()
        {
            string pfx = !string.IsNullOrEmpty(QuestionnairePrefixForFileName) ? QuestionnairePrefixForFileName : "_";
            string bk = !string.IsNullOrEmpty(BankNameForFileName) ? BankNameForFileName : "_";
            string appl = !string.IsNullOrEmpty(ApplicantNameForFileName) ? ApplicantNameForFileName : "_";

            return string.Format("{0}.{1}.{2}.xml", pfx, bk, appl);
        }

        protected void RefreshGenericPersonsDisplayNamesWorker(List<GenericPersonInfo> gpis, List<OwnershipStructure>[] ownershipHives)
        {
            foreach (List<OwnershipStructure> hive in ownershipHives)
                RefreshGenericPersonDisplayNamesPerHive(gpis, hive);
        }

        protected void RefreshGenericPersonDisplayNamesPerHive(List<GenericPersonInfo> gpis, List<OwnershipStructure> ownershipHive)
        {
            foreach (OwnershipStructure os in ownershipHive)
            { 
                GenericPersonInfo gpi = gpis.Find( g => g.ID == os.Asset);
                if (gpi != null)
                    os.Asset.DisplayName = gpi.DisplayName;
                GenericPersonInfo gpi2 = gpis.Find(g => g.ID == os.Owner);
                if (gpi != null)
                    os.Owner.DisplayName = gpi2.DisplayName;

            }
        }
    }
}
