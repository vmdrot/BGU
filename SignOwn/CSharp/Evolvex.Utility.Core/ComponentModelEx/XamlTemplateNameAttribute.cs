using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolvex.Utility.Core.ComponentModelEx
{
    public class XamlTemplateNameAttribute: Attribute
    {
        public string TemplateFileName { get; set; }

        public XamlTemplateNameAttribute(string templateFileName)
            : base()
        {
            this.TemplateFileName = templateFileName;
        }


    }
}
