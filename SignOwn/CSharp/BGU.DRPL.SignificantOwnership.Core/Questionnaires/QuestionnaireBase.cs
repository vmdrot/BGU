using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;
using BGU.DRPL.SignificantOwnership.Core.Spares;

namespace BGU.DRPL.SignificantOwnership.Core.Questionnaires
{
    public abstract class QuestionnaireBase : NotifyPropertyChangedBase, IQuestionnaire
    {
        protected abstract string QuestionnairePrefixForFileName {get;}
        protected abstract string BankNameForFileName { get; }
        protected abstract string ApplicantNameForFileName { get; }

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

    }
}
