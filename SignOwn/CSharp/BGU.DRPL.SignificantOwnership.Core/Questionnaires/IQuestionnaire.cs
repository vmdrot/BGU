using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;

namespace BGU.DRPL.SignificantOwnership.Core.Questionnaires
{
    public interface IQuestionnaire
    {
        string SuggestSaveAsFileName();
    }

    public interface IGenericPersonsService
    {
        IEnumerable<GenericPersonInfo> MentionedGenericPersons { get; }
        void RefreshGenericPersonsDisplayNames();
    }

    public interface IAddressesService
    {
        IEnumerable<LocationInfo> MentionedAddresses { get; }
    }
}
