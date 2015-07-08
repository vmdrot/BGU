using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolvex.Utility.Core.ComponentModelEx
{
    public class UIUsageSuppressControlLabelsAttribute : Attribute
    {
        public bool SuppressControlLabels { get; set; }

        public UIUsageSuppressControlLabelsAttribute () :this(true)
        {
        }

        public UIUsageSuppressControlLabelsAttribute(bool suppressLabels)
            : base()
        {
            this.SuppressControlLabels = suppressLabels;
        }
    }
}
