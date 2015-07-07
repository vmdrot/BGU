using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolvex.Utility.Core.ComponentModelEx
{
    public class UIPartialFieldsVisibilityAttribute : Attribute
    {
        public bool ShowOrHide { get; set; }
        public string PropsList { get; set; }
        public UIPartialFieldsVisibilityAttribute()
            : base()
        { }
    }
}
