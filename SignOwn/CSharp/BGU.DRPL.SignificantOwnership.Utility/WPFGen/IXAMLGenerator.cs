using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Evolvex.Utility.Core.ComponentModelEx;
using System.Xml;

namespace BGU.DRPL.SignificantOwnership.Utility.WPFGen
{
    public interface IXAMLGenerator
    {
        void GenerateAndSave(Type typ, Assembly userAsmbly, Dictionary<Type, string> controlTemplateNames, string targetPath);
        bool GenerateInlineTemplateOnly { get; set; }
        UIPartialFieldsVisibilityAttribute InlineTemplateParams { get; set; }
        XmlDocument Generate(Type typ, Assembly userAsmbly, Dictionary<Type, string> controlTemplateNames);
    }
}
