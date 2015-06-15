using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Reflection;
using System.ComponentModel;

namespace BGU.DRPL.SignificantOwnership.Utility.WPFGen
{
    public class XAMLGenerator
    {
        public XmlDocument Generate(Type typ, string targetNamespace)
        {
            XmlDocument rslt = CreateControlWrapper(typ, targetNamespace);
            PropertyInfo[] props = typ.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach(PropertyInfo pi in props)
            {
                AddControl(rslt, pi);
            }
            return null; //todo
        }

        private void AddControl(XmlDocument rslt, PropertyInfo pi)
        {
            if (Attribute.IsDefined(pi, typeof(EditorAttribute)))
            {

                Attribute editorAttr0 = Attribute.GetCustomAttribute((MemberInfo)pi, typeof(EditorAttribute));
                if (editorAttr0 is EditorAttribute)
                {
                    EditorAttribute editorAttr = (EditorAttribute)editorAttr0;
                    if (!string.IsNullOrEmpty(editorAttr.EditorTypeName))
                    {
                        AddControlByTypeEditor(rslt, editorAttr.EditorTypeName);
                        return;
                    }
                }
            }

            if (pi.ReflectedType == typeof(string) || pi.ReflectedType == typeof(String)) AddStringEditControl(rslt, pi);
            else if (pi.ReflectedType == typeof(int) || pi.ReflectedType == typeof(Int32) || pi.ReflectedType == typeof(long) || pi.ReflectedType == typeof(Int64) || pi.ReflectedType == typeof(short) || pi.ReflectedType == typeof(Int16)) AddIntEditControl(rslt, pi);
            else if (pi.ReflectedType == typeof(decimal) || pi.ReflectedType == typeof(float) || pi.ReflectedType == typeof(double) || pi.ReflectedType == typeof(Double) || pi.ReflectedType == typeof(Decimal)) AddDecimalEditControl(rslt, pi);
            else if (pi.ReflectedType == typeof(DateTime)) AddDateTimeEditControl(rslt, pi);
            else if (pi.ReflectedType == typeof(bool) || pi.ReflectedType == typeof(Boolean)) AddBoolEditControl(rslt, pi);
            else if (pi.ReflectedType.IsEnum) AddEnumEditControl(rslt, pi);
            else
            {
                if (pi.ReflectedType.IsPrimitive) AddPrimitiveEditControl(rslt, pi);
                else AddComplextTypeControl(rslt, pi);
            }
            //else if (pi.ReflectedType == typeof(int)) AddIntEditControl(rslt, pi);
            //else if (pi.ReflectedType == typeof(int)) AddIntEditControl(rslt, pi);
            //else if (pi.ReflectedType == typeof(int)) AddIntEditControl(rslt, pi);
            
        }

        private void AddComplextTypeControl(XmlDocument rslt, PropertyInfo pi)
        {
            throw new NotImplementedException();
        }

        private void AddPrimitiveEditControl(XmlDocument rslt, PropertyInfo pi)
        {
            throw new NotImplementedException();
        }

        private void AddEnumEditControl(XmlDocument rslt,PropertyInfo pi)
        {
 	        throw new NotImplementedException();
        }

        private void AddBoolEditControl(XmlDocument rslt, PropertyInfo pi)
        {
            throw new NotImplementedException();
        }

        private void AddDateTimeEditControl(XmlDocument rslt, PropertyInfo pi)
        {
            throw new NotImplementedException();
        }

        private void AddDecimalEditControl(XmlDocument rslt, PropertyInfo pi)
        {
            throw new NotImplementedException();
        }

        private void AddIntEditControl(XmlDocument rslt, PropertyInfo pi)
        {
            throw new NotImplementedException();
        }

        private void AddStringEditControl(XmlDocument rslt, PropertyInfo pi)
        {
            throw new NotImplementedException();
        }

        private void AddControlByTypeEditor(XmlDocument rslt, string p)
        {
            throw new NotImplementedException();
        }

        private XmlDocument CreateControlWrapper(Type typ, string targetNamespace)
        {
            XmlDocument rslt = new XmlDocument();
            rslt.LoadXml(string.Format(@"<UserControl x:Class=""{0}.{1}""
             xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
             xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""
             xmlns:mc=""http://schemas.openxmlformats.org/markup-compatibility/2006"" 
             xmlns:d=""http://schemas.microsoft.com/expression/blend/2008"" 
             mc:Ignorable=""d"" 
             d:DesignHeight=""300"" d:DesignWidth=""300"">
    <Grid>
    </Grid>
</UserControl>", targetNamespace, typ.Name));
            return rslt;
        }
    }
}
