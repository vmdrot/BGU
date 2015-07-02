using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolvex.Utility.Core.ComponentModelEx
{
    public class UIConditionalVisibilityAttribute : Attribute
    {

        public string VisibilityMemberPath { get; set; }

        public UIConditionalVisibilityAttribute() : this(string.Empty) { }
        public UIConditionalVisibilityAttribute(string visibilityMemberPath) : base()
        {
            VisibilityMemberPath = visibilityMemberPath;
        }
    }
}
