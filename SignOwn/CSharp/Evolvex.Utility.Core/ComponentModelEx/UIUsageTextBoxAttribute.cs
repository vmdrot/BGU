using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolvex.Utility.Core.ComponentModelEx
{
    public class UIUsageTextBoxAttribute : Attribute
    {
        public string MaxWidth { get; set; }
        public string MinWidth { get; set; }
        public string StringFormat { get; set; }
        public bool IsMultiline { get; set; }
        public string HorizontalAlignment { get; set; }
        public UIUsageTextBoxAttribute()
            : base()
        { }
    }
}
