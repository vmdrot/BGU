using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolvex.Utility.Core.ComponentModelEx
{
    public class UIUsageDataGridParamsAttribute : Attribute
    {
        public bool IsOneColumn { get; set; }
        public string OneDataColumnHeader { get; set; }

        public UIUsageDataGridParamsAttribute()
            : base()
        { }
    }
}
