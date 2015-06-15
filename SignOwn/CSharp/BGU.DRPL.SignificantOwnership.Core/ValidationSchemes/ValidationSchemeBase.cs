using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BGU.DRPL.SignificantOwnership.Core.ValidationSchemes
{
    public class ValidationSchemeBaseAttribute : Attribute
    {

        public string condition;
        public ValidationSchemeBaseAttribute() { }
        public ValidationSchemeBaseAttribute(string condition) { this.condition = condition; }
    }
}
