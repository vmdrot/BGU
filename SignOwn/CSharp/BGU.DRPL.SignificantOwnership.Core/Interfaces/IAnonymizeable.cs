using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BGU.DRPL.SignificantOwnership.Core.Interfaces
{
    public interface IAnonymizeable
    {
        void Anonymize(List<Type> involveTypes);
        void Anonymize(ISensitiveDataAnonymizer anonymizer);
    }
}
