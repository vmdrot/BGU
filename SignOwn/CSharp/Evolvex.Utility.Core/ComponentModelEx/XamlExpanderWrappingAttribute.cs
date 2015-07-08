using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolvex.Utility.Core.ComponentModelEx
{
    public class XamlExpanderWrappingAttribute : Attribute
    {
        public bool WrapIntoExpander { get; set; }

        public XamlExpanderWrappingAttribute() :this(true)
        {
        }

        public XamlExpanderWrappingAttribute(bool wrap) : base ()
        {
            this.WrapIntoExpander = wrap;
        }
    }
}
