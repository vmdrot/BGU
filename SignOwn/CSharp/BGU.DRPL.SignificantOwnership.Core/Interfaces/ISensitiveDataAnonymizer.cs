using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;

namespace BGU.DRPL.SignificantOwnership.Core.Interfaces
{
    public interface ISensitiveDataAnonymizer
    {
        Dictionary<GenericPersonID, GenericPersonID> GeneratePersonIDs(List<GenericPersonID> haystack);
    }
}
