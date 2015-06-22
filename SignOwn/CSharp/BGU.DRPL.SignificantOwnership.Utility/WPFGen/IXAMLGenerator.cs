using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace BGU.DRPL.SignificantOwnership.Utility.WPFGen
{
    public interface IXAMLGenerator
    {
        void GenerateAndSave(Type typ, Assembly userAsmbly, Dictionary<Type, string> controlTemplateNames, string targetPath);
    }
}
