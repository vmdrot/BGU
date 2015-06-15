using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BGU.DRPL.SignificantOwnership.Core.Misc
{
    public class Utils
    {
        public static bool AreStringsEqual(string one, string two)
        {
            if (one == null && two == null)
                return true;
            if (string.IsNullOrEmpty(one) && string.IsNullOrEmpty(two))
                return true;
            if (one == null || two == null)
                return false;
            return one == two;
        }
    }
}
