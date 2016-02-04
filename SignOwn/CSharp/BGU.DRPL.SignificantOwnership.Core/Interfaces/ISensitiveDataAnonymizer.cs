using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;

namespace BGU.DRPL.SignificantOwnership.Core.Interfaces
{
    public interface ISensitiveDataAnonymizer
    {
        void SetSourceInfo(List<GenericPersonInfo> mentionedIdentities);
        Dictionary<GenericPersonID, GenericPersonID> GeneratePersonIDs(List<GenericPersonID> haystack);
        void GeneratePersonIDs();
        void ReplacePersonIDs(List<GenericPersonInfo> subj);
        void ReplacePersonIDs(List<OwnershipStructure> subj);
        void ReplacePersonIDs(List<TotalOwnershipDetailsInfoEx> subj);
        void ReplacePersonIDs(List<PersonsAssociation> subj);
        void ReplacePersonID(BankInfo subj);
    }
}
