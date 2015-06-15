using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolvex.Utility.Core.ComponentModelEx
{
    public class RequiredAttribute : ValidationAttribute
    {
        public string Condition { get; set; }

        public RequiredAttribute() : this(string.Empty) { }
        public RequiredAttribute(string condition) : base()
        {
            this.Condition = condition;
        }

    }
}
