using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolvex.Utility.Core.ComponentModelEx
{
    public class UIUsageControlOrientationAttribute : Attribute
    {

        public Orientation ContainerOrientation { get; set; }
        public UIUsageControlOrientationAttribute() :this(Orientation.Vertical)
        {}

        public UIUsageControlOrientationAttribute(Orientation contOrientation)
            : base()
        {
            this.ContainerOrientation = contOrientation;
        }


    }
}
