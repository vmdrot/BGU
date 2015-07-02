using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolvex.Utility.Core.ComponentModelEx
{
    public class UIUsageRadioButtonGroupAttribute : Attribute
    {
        public Orientation GroupOrientation { get; set; }
        public bool ShowNoneItem { get; set; }

        public UIUsageRadioButtonGroupAttribute() : this(Orientation.Vertical, true) { }
        public UIUsageRadioButtonGroupAttribute(Orientation groupOrientation, bool showNoneItem)
            : base()
        {
            GroupOrientation = groupOrientation;
            ShowNoneItem = showNoneItem;
        }
        
    }
}
