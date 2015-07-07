using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Reflection;
using System.ComponentModel;
using System.IO;
//using BGU.DRPL.SignificantOwnership.Utility.XAMLTemplates;

namespace BGU.DRPL.SignificantOwnership.Utility.WPFGen
{
    public class XAMLGenerator : IXAMLGenerator
    {

        private List<Type> _referencedTypes = new List<Type>();
        private Dictionary<Type, string> _referencedControlTemplateNames;
        private Assembly _userAssembly;
        private Type _rootType;
        private string _targetPath;
        private Dictionary<string, BGU.DRPL.SignificantOwnership.Utility.XSDReflectionUtil.PropDispDescr> _propDispDescrs;
        private Dictionary<string, string> _propsDummyXmls = new Dictionary<string,string>();
        private Dictionary<string, string> _propsRealXmls = new Dictionary<string,string>();
        private static readonly Dictionary<Type, string> PRIMITIVE_TYPES_TEMPLATES;
        private static readonly string templatedPropertyNamePlaceholder = "yourPropertyName";
        private static readonly string templatedPropertyDispNamePlaceholder = "yourPropertyDispName";
        private static readonly string templatedPropertyDescrPlaceholder = "yourPropertyDescription";
        private static readonly string templatedEnumListerPlaceholder = "yourEnumListerProperty";
        private static readonly string templatedTypeNamePlaceholder = "yourTemplatedTypeName";
        private static readonly string templatedGridRowAttributeName = "Grid.Row";
        private static readonly string classStructControlTemplate = BGU.DRPL.SignificantOwnership.Utility.XAMLTemplates.XAMLPrimitiveTemplates.classstruct;
        private static readonly string listOfTTemplate = BGU.DRPL.SignificantOwnership.Utility.XAMLTemplates.XAMLPrimitiveTemplates.ListOfT;
        private static readonly string dummyNodeElementName = "dummyPhTag";
        private static readonly string dummyNodeElementNamespaceAttrNm = "xmlns";
        private static readonly string uniquifierAttrName = "guuiidd";
        private static readonly string NewElemNS = "http://schemas.microsoft.com/winfx/2006/xaml/presentation";


        private Dictionary<string, BGU.DRPL.SignificantOwnership.Utility.XSDReflectionUtil.PropDispDescr> PropDispDescrs
        {
            get
            { 
                if(_propDispDescrs == null)
                {
                    _propDispDescrs = XSDReflectionUtil.FetchPropDispsDescrs(_rootType);
                }
                return _propDispDescrs;
            }
        }

        static XAMLGenerator()
        {
            PRIMITIVE_TYPES_TEMPLATES = new Dictionary<Type, string>();

            PRIMITIVE_TYPES_TEMPLATES.Add(typeof(bool), BGU.DRPL.SignificantOwnership.Utility.XAMLTemplates.XAMLPrimitiveTemplates._bool);
            PRIMITIVE_TYPES_TEMPLATES.Add(typeof(int), BGU.DRPL.SignificantOwnership.Utility.XAMLTemplates.XAMLPrimitiveTemplates._int);
            PRIMITIVE_TYPES_TEMPLATES.Add(typeof(decimal), BGU.DRPL.SignificantOwnership.Utility.XAMLTemplates.XAMLPrimitiveTemplates._decimal);
            PRIMITIVE_TYPES_TEMPLATES.Add(typeof(string), BGU.DRPL.SignificantOwnership.Utility.XAMLTemplates.XAMLPrimitiveTemplates.onelinestring);
            PRIMITIVE_TYPES_TEMPLATES.Add(typeof(double), BGU.DRPL.SignificantOwnership.Utility.XAMLTemplates.XAMLPrimitiveTemplates._decimal);//todo
            PRIMITIVE_TYPES_TEMPLATES.Add(typeof(DateTime), BGU.DRPL.SignificantOwnership.Utility.XAMLTemplates.XAMLPrimitiveTemplates.DateTime);
            PRIMITIVE_TYPES_TEMPLATES.Add(typeof(Enum), BGU.DRPL.SignificantOwnership.Utility.XAMLTemplates.XAMLPrimitiveTemplates._enum);

        }
        public void GenerateAndSave(Type typ, Assembly userAsmbly, Dictionary<Type, string> controlTemplateNames, string targetPath)
        {
            _targetPath = targetPath;
            {
                XmlDocument xamlDoc = this.Generate(typ, userAsmbly, controlTemplateNames);
                xamlDoc.Save(targetPath);
            }
            string xamlTxt = File.ReadAllText(_targetPath);
            xamlTxt = xamlTxt.Replace(templatedTypeNamePlaceholder, _rootType.Name);
            foreach (string propNm in _propsRealXmls.Keys)
            {
                xamlTxt = xamlTxt.Replace(_propsDummyXmls[propNm].Trim().Replace(string.Format("xmlns=\"{0}\" ",NewElemNS), string.Empty), _propsRealXmls[propNm].Trim());
            }
            File.WriteAllText(_targetPath, xamlTxt, Encoding.Unicode);
            XmlDocument xamlDoc1 = new XmlDocument();
            xamlDoc1.Load(_targetPath);
            AddReferencedControlTemplatesIncludes(xamlDoc1);
            xamlDoc1.Save(_targetPath);
        }

        private void AddReferencedControlTemplatesIncludes(XmlDocument xamlDoc1)
        {
            //XmlNode container = xamlDoc1.DocumentElement.SelectSingleNode("//ResourceDictionary.MergedDictionaries"); //doesn't work
            XmlNode container = xamlDoc1.DocumentElement.FirstChild;
            foreach(Type typ in _referencedTypes)
            {
                if (!_referencedControlTemplateNames.ContainsKey(typ))
                    continue;
                XmlNode currInclude = container.OwnerDocument.CreateNode(XmlNodeType.Element, "ResourceDictionary", NewElemNS);
                XSDReflectionUtil.WriteAttribute(currInclude, "Source", _referencedControlTemplateNames[typ]);
                container.InsertAfter(currInclude, container.LastChild);
            }
        }

        public XmlDocument Generate(Type typ, Assembly userAsmbly, Dictionary<Type, string> controlTemplateNames)
        {
            _referencedControlTemplateNames = controlTemplateNames;
            _rootType = typ;
            _userAssembly = userAsmbly;
            
            XmlDocument rslt = CreateControlWrapper(typ);
            PropertyInfo[] props = typ.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty | BindingFlags.GetProperty);
            foreach(PropertyInfo pi in props)
            {
                XmlNode dataTemplateNode = rslt.FirstChild.ChildNodes[1];//rslt.SelectSingleNode("/ResourceDictionary/DataTemplate/Grid"); //doesn't work
                XmlNode gridNode = dataTemplateNode.FirstChild;
                AddControl(gridNode, pi);
            }
            return rslt;
        }

        private void AddControl(XmlNode container, PropertyInfo pi)
        {
            //if (Attribute.IsDefined(pi, typeof(EditorAttribute))) //todo, later
            //{

            //    Attribute editorAttr0 = Attribute.GetCustomAttribute((MemberInfo)pi, typeof(EditorAttribute));
            //    if (editorAttr0 is EditorAttribute)
            //    {
            //        EditorAttribute editorAttr = (EditorAttribute)editorAttr0;
            //        if (!string.IsNullOrEmpty(editorAttr.EditorTypeName))
            //        {
            //            AddControlByTypeEditor(rslt, editorAttr.EditorTypeName);
            //            return;
            //        }
            //    }
            //}

            if (pi.ReflectedType == typeof(string) || pi.ReflectedType == typeof(String)) AddStringEditControl(container, pi);
            else if (pi.ReflectedType == typeof(int) || pi.ReflectedType == typeof(Int32) || pi.ReflectedType == typeof(long) || pi.ReflectedType == typeof(Int64) || pi.ReflectedType == typeof(short) || pi.ReflectedType == typeof(Int16)) AddIntEditControl(container, pi);
            else if (pi.ReflectedType == typeof(decimal) || pi.ReflectedType == typeof(float) || pi.ReflectedType == typeof(double) || pi.ReflectedType == typeof(Double) || pi.ReflectedType == typeof(Decimal)) AddDecimalEditControl(container, pi);
            else if (pi.ReflectedType == typeof(DateTime)) AddDateTimeEditControl(container, pi);
            else if (pi.ReflectedType == typeof(bool) || pi.ReflectedType == typeof(Boolean)) AddBoolEditControl(container, pi);
            else if (pi.ReflectedType.IsEnum) AddEnumEditControl(container, pi);
            else if (pi.PropertyType.IsGenericType) AddCollectionEditControl(container, pi);
            else if (pi.PropertyType.Assembly == _userAssembly) AddComplextTypeControl(container, pi);
            
        }


        private void AddCollectionEditControl(XmlNode container, PropertyInfo pi)
        {
            string controlXamlFragment = ReplacePlaceholderTexts(listOfTTemplate, pi);
            //XmlNode curr = container.OwnerDocument.CreateNode(XmlNodeType.Element, dummyNodeElementName, container.OwnerDocument.Attributes[dummyNodeElementNamespaceAttrNm].Value); //doesn't work
            XmlNode curr = container.OwnerDocument.CreateNode(XmlNodeType.Element, dummyNodeElementName, NewElemNS);
            XSDReflectionUtil.WriteAttribute(curr, uniquifierAttrName, Guid.NewGuid().ToString());
            container.InsertAfter(curr, container.LastChild);
            IncrementRealDummyXmls(pi.Name, controlXamlFragment, curr.OuterXml);
        }

        private void AddComplextTypeControl(XmlNode container, PropertyInfo pi)
        {
            string controlXamlFragment = ReplacePlaceholderTexts(classStructControlTemplate, pi);
            //XmlNode curr = container.OwnerDocument.CreateNode(XmlNodeType.Element, dummyNodeElementName, container.OwnerDocument.Attributes[dummyNodeElementNamespaceAttrNm].Value); //doesn't work
            XmlNode curr = container.OwnerDocument.CreateNode(XmlNodeType.Element, dummyNodeElementName, NewElemNS);
            XSDReflectionUtil.WriteAttribute(curr, uniquifierAttrName, Guid.NewGuid().ToString());
            container.InsertAfter(curr, container.LastChild);
            IncrementRealDummyXmls(pi.Name, controlXamlFragment, curr.OuterXml);

            if (!_referencedTypes.Contains(pi.PropertyType))
                _referencedTypes.Add(pi.PropertyType);
        }

        private void AddPrimitiveEditControl(XmlNode container, PropertyInfo pi)
        {
            throw new NotImplementedException();
        }

        private void AddEnumEditControl(XmlNode container, PropertyInfo pi)
        {
            string controlXamlFragment = ReplacePlaceholderTexts(PRIMITIVE_TYPES_TEMPLATES[typeof(Enum)], pi);
            controlXamlFragment = controlXamlFragment.Replace(templatedEnumListerPlaceholder, string.Format("{0}List", pi.PropertyType.Name));
            //XmlNode curr = container.OwnerDocument.CreateNode(XmlNodeType.Element, dummyNodeElementName, container.OwnerDocument.Attributes[dummyNodeElementNamespaceAttrNm].Value); //doesn't work
            XmlNode curr = container.OwnerDocument.CreateNode(XmlNodeType.Element, dummyNodeElementName, NewElemNS);
            XSDReflectionUtil.WriteAttribute(curr, uniquifierAttrName, Guid.NewGuid().ToString());
            container.InsertAfter(curr, container.LastChild);
            IncrementRealDummyXmls(pi.Name, controlXamlFragment, curr.OuterXml);
        }

        private void AddBoolEditControl(XmlNode container, PropertyInfo pi)
        {
            AddEditControlWorker(container, pi, typeof(bool));
        }

        private void AddDateTimeEditControl(XmlNode container, PropertyInfo pi)
        {
            AddEditControlWorker(container, pi, typeof(DateTime));
        }

        private void AddDecimalEditControl(XmlNode container, PropertyInfo pi)
        {
            AddEditControlWorker(container, pi, typeof(decimal));
        }

        private void AddIntEditControl(XmlNode container, PropertyInfo pi)
        {
            AddEditControlWorker(container, pi, typeof(int));
        }

        private void AddStringEditControl(XmlNode container, PropertyInfo pi)
        {
            AddEditControlWorker(container, pi, typeof(string));
        }

        private void AddEditControlWorker(XmlNode container, PropertyInfo pi, Type ctrlTyp)
        {
            string controlXamlFragment = ReplacePlaceholderTexts(PRIMITIVE_TYPES_TEMPLATES[ctrlTyp], pi);
            //XmlNode curr = container.OwnerDocument.CreateNode(XmlNodeType.Element, dummyNodeElementName, container.OwnerDocument.Attributes[dummyNodeElementNamespaceAttrNm].Value); //doesn't work
            XmlNode curr = container.OwnerDocument.CreateNode(XmlNodeType.Element, dummyNodeElementName, NewElemNS);
            XSDReflectionUtil.WriteAttribute(curr, uniquifierAttrName, Guid.NewGuid().ToString());
            container.InsertAfter(curr, container.LastChild);
            IncrementRealDummyXmls(pi.Name, controlXamlFragment, curr.OuterXml);
        }




        private void AddControlByTypeEditor(XmlNode container, string p)
        {
            throw new NotImplementedException();
        }

        private XmlDocument CreateControlWrapper(Type typ)
        {
            XmlDocument rslt = new XmlDocument();
            rslt.LoadXml(BGU.DRPL.SignificantOwnership.Utility.XAMLTemplates.XAMLPrimitiveTemplates.GenericControlTemplate);
            return rslt;
        }

        private string ReplacePlaceholderTexts(string xamlFragment, PropertyInfo pi)
        {
            BGU.DRPL.SignificantOwnership.Utility.XSDReflectionUtil.PropDispDescr pdd;
            if (PropDispDescrs.ContainsKey(pi.Name))
                pdd = PropDispDescrs[pi.Name];
            else
                pdd = new XSDReflectionUtil.PropDispDescr() { Category = string.Empty, DisplayName = pi.Name, Description = pi.Name};
            string rslt = xamlFragment.Replace(templatedPropertyNamePlaceholder, pi.Name);
            rslt = SafeXMLAttributeValueReplace(rslt, templatedPropertyDispNamePlaceholder, pdd.DisplayName);
            rslt = SafeXMLAttributeValueReplace(rslt, templatedPropertyDescrPlaceholder, pdd.Description);
            return rslt;
        }

        private static string SafeXMLAttributeValueReplace(string rslt, string oldString, string newString)
        {
            string replacement = newString.Replace("\"", "&quot;").Replace(">", "&gt;").Replace("<", "&lt;");
            return rslt.Replace(oldString, replacement);
        }


        private void IncrementRealDummyXmls(string propNm, string realXml, string dummyXml)
        {
            _propsDummyXmls.Add(propNm, dummyXml);
            _propsRealXmls.Add(propNm, realXml);
        }



        public bool GenerateInlineTemplateOnly
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Evolvex.Utility.Core.ComponentModelEx.UIPartialFieldsVisibilityAttribute InlineTemplateParams
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
