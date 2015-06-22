#define __DISABLE_TEXT_INSERTION__
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Reflection;
using System.ComponentModel;
using System.IO;
using System.Configuration;

namespace BGU.DRPL.SignificantOwnership.Utility.WPFGen
{
    public class XAMLGeneratorPureXml : IXAMLGenerator
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
        private static readonly Dictionary<string, string> _bguNS2XamlPfxs;
        private static readonly string BGU2XAML_NS_CFG_PFX = "xamlns4:";


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

        static XAMLGeneratorPureXml()
        {
            PRIMITIVE_TYPES_TEMPLATES = new Dictionary<Type, string>();

            PRIMITIVE_TYPES_TEMPLATES.Add(typeof(bool), BGU.DRPL.SignificantOwnership.Utility.XAMLTemplates.XAMLPrimitiveTemplates._bool);
            PRIMITIVE_TYPES_TEMPLATES.Add(typeof(int), BGU.DRPL.SignificantOwnership.Utility.XAMLTemplates.XAMLPrimitiveTemplates._int);
            PRIMITIVE_TYPES_TEMPLATES.Add(typeof(decimal), BGU.DRPL.SignificantOwnership.Utility.XAMLTemplates.XAMLPrimitiveTemplates._decimal);
            PRIMITIVE_TYPES_TEMPLATES.Add(typeof(string), BGU.DRPL.SignificantOwnership.Utility.XAMLTemplates.XAMLPrimitiveTemplates.onelinestring);
            PRIMITIVE_TYPES_TEMPLATES.Add(typeof(double), BGU.DRPL.SignificantOwnership.Utility.XAMLTemplates.XAMLPrimitiveTemplates._decimal);//todo
            PRIMITIVE_TYPES_TEMPLATES.Add(typeof(DateTime), BGU.DRPL.SignificantOwnership.Utility.XAMLTemplates.XAMLPrimitiveTemplates.DateTime);
            PRIMITIVE_TYPES_TEMPLATES.Add(typeof(Enum), BGU.DRPL.SignificantOwnership.Utility.XAMLTemplates.XAMLPrimitiveTemplates._enum);

            _bguNS2XamlPfxs = new Dictionary<string, string>();
            foreach (string currKey in ConfigurationManager.AppSettings.Keys)
            {
                string currVal = ConfigurationManager.AppSettings[currKey];
                if (currKey.IndexOf(BGU2XAML_NS_CFG_PFX) != 0)
                    continue;
                string currNS = currKey.Substring(BGU2XAML_NS_CFG_PFX.Length);
                if(!_bguNS2XamlPfxs.ContainsKey(currNS)) _bguNS2XamlPfxs.Add(currNS, currVal);
            }
        }
        public void GenerateAndSave(Type typ, Assembly userAsmbly, Dictionary<Type, string> controlTemplateNames, string targetPath)
        {
            _targetPath = targetPath;
            {
                XmlDocument xamlDoc = this.Generate(typ, userAsmbly, controlTemplateNames);
                AddReferencedControlTemplatesIncludes(xamlDoc);
                xamlDoc.Save(targetPath);
            }
#if __DISABLE_TEXT_INSERTION__
#else

            string xamlTxt = File.ReadAllText(_targetPath);
            xamlTxt = xamlTxt.Replace(templatedTypeNamePlaceholder, _rootType.Name);
            foreach (string propNm in _propsRealXmls.Keys)
            {
                xamlTxt = xamlTxt.Replace(_propsDummyXmls[propNm].Trim().Replace(string.Format("xmlns=\"{0}\" ",NewElemNS), string.Empty), _propsRealXmls[propNm].Trim());
            }
            File.WriteAllText(_targetPath, xamlTxt, Encoding.Unicode);
            XmlDocument xamlDoc1 = new XmlDocument();
            xamlDoc1.Load(_targetPath);
            
            xamlDoc1.Save(_targetPath);
#endif
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
                ReplaceTemplateDataType(dataTemplateNode, typ);
                XmlNode gridNode = dataTemplateNode.FirstChild;
                AddControl(gridNode, pi);
            }
            return rslt;
        }

        private void ReplaceTemplateDataType(XmlNode dataTemplateNode, Type typ)
        {
            string xamlDataTypeAlias = string.Format("{0}:{1}", _bguNS2XamlPfxs[typ.Namespace], typ.Name);
            ReplaceAllAttrsPlaceholders(dataTemplateNode, templatedTypeNamePlaceholder, xamlDataTypeAlias);
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

            if (pi.PropertyType == typeof(string) || pi.PropertyType == typeof(String)) AddStringEditControl(container, pi);
            else if (pi.PropertyType == typeof(int) || pi.PropertyType == typeof(Int32) || pi.PropertyType == typeof(long) || pi.PropertyType == typeof(Int64) || pi.PropertyType == typeof(short) || pi.PropertyType == typeof(Int16)) AddIntEditControl(container, pi);
            else if (pi.PropertyType == typeof(decimal) || pi.PropertyType == typeof(float) || pi.PropertyType == typeof(double) || pi.PropertyType == typeof(Double) || pi.PropertyType == typeof(Decimal)) AddDecimalEditControl(container, pi);
            else if (pi.PropertyType == typeof(DateTime)) AddDateTimeEditControl(container, pi);
            else if (pi.PropertyType == typeof(bool) || pi.ReflectedType == typeof(Boolean)) AddBoolEditControl(container, pi);
            else if (pi.PropertyType.IsEnum) AddEnumEditControl(container, pi);
            else if (pi.PropertyType.IsGenericType) AddCollectionEditControl(container, pi);
            else if (pi.PropertyType.Assembly == _userAssembly) AddComplextTypeControl(container, pi);
            
        }


        private void AddCollectionEditControl(XmlNode container, PropertyInfo pi)
        {
#if __DISABLE_TEXT_INSERTION__
            XmlDocument controlXamlFragmentDoc = new XmlDocument();
            controlXamlFragmentDoc.LoadXml(listOfTTemplate);
            XmlNode sourceBucket = controlXamlFragmentDoc.DocumentElement;
            foreach (XmlNode currSrc in sourceBucket.ChildNodes)
            {
                XmlNode curr = container.OwnerDocument.ImportNode(currSrc, true);
                ReplacePlaceholderTexts(curr, pi);
                container.InsertAfter(curr, container.LastChild);
            }

            if (!_referencedTypes.Contains(pi.PropertyType))
                _referencedTypes.Add(pi.PropertyType);
#else
            string controlXamlFragment = ReplacePlaceholderTexts(listOfTTemplate, pi);
            //XmlNode curr = container.OwnerDocument.CreateNode(XmlNodeType.Element, dummyNodeElementName, container.OwnerDocument.Attributes[dummyNodeElementNamespaceAttrNm].Value); //doesn't work
            XmlNode curr = container.OwnerDocument.CreateNode(XmlNodeType.Element, dummyNodeElementName, NewElemNS);
            XSDReflectionUtil.WriteAttribute(curr, uniquifierAttrName, Guid.NewGuid().ToString());
            container.InsertAfter(curr, container.LastChild);
            IncrementRealDummyXmls(pi.Name, controlXamlFragment, curr.OuterXml);
#endif
        }

        private void AddComplextTypeControl(XmlNode container, PropertyInfo pi)
        {
#if __DISABLE_TEXT_INSERTION__
            XmlDocument controlXamlFragmentDoc = new XmlDocument();
            controlXamlFragmentDoc.LoadXml(classStructControlTemplate);
            XmlNode sourceBucket = controlXamlFragmentDoc.DocumentElement;
            foreach (XmlNode currSrc in sourceBucket.ChildNodes)
            {
                XmlNode curr = container.OwnerDocument.ImportNode(currSrc, true);
                ReplacePlaceholderTexts(curr, pi);
                container.InsertAfter(curr, container.LastChild);
            }

            if (!_referencedTypes.Contains(pi.PropertyType))
                _referencedTypes.Add(pi.PropertyType);
#else
            string controlXamlFragment = ReplacePlaceholderTexts(classStructControlTemplate, pi);
            //XmlNode curr = container.OwnerDocument.CreateNode(XmlNodeType.Element, dummyNodeElementName, container.OwnerDocument.Attributes[dummyNodeElementNamespaceAttrNm].Value); //doesn't work
            XmlNode curr = container.OwnerDocument.CreateNode(XmlNodeType.Element, dummyNodeElementName, NewElemNS);
            XSDReflectionUtil.WriteAttribute(curr, uniquifierAttrName, Guid.NewGuid().ToString());
            container.InsertAfter(curr, container.LastChild);
            IncrementRealDummyXmls(pi.Name, controlXamlFragment, curr.OuterXml);

            if (!_referencedTypes.Contains(pi.PropertyType))
                _referencedTypes.Add(pi.PropertyType);
#endif
        }

        private void AddPrimitiveEditControl(XmlNode container, PropertyInfo pi)
        {
            throw new NotImplementedException();
        }

        private void AddEnumEditControl(XmlNode container, PropertyInfo pi)
        {
#if __DISABLE_TEXT_INSERTION__
            XmlDocument controlXamlFragmentDoc = new XmlDocument();
            controlXamlFragmentDoc.LoadXml(PRIMITIVE_TYPES_TEMPLATES[typeof(Enum)]);
            XmlNode sourceBucket = controlXamlFragmentDoc.DocumentElement;
            foreach (XmlNode currSrc in sourceBucket.ChildNodes)
            {
                XmlNode curr = container.OwnerDocument.ImportNode(currSrc, true);
                ReplacePlaceholderTexts(curr, pi);
                ReplaceAllAttrsPlaceholders(curr, templatedEnumListerPlaceholder, string.Format("{0}List", pi.PropertyType.Name));
                container.InsertAfter(curr, container.LastChild);
            }

            if (!_referencedTypes.Contains(pi.PropertyType))
                _referencedTypes.Add(pi.PropertyType);

#else
            string controlXamlFragment = ReplacePlaceholderTexts(PRIMITIVE_TYPES_TEMPLATES[typeof(Enum)], pi);
            controlXamlFragment = controlXamlFragment.Replace(templatedEnumListerPlaceholder, string.Format("{0}List", pi.PropertyType.Name));
            //XmlNode curr = container.OwnerDocument.CreateNode(XmlNodeType.Element, dummyNodeElementName, container.OwnerDocument.Attributes[dummyNodeElementNamespaceAttrNm].Value); //doesn't work
            XmlNode curr = container.OwnerDocument.CreateNode(XmlNodeType.Element, dummyNodeElementName, NewElemNS);
            XSDReflectionUtil.WriteAttribute(curr, uniquifierAttrName, Guid.NewGuid().ToString());
            container.InsertAfter(curr, container.LastChild);
            IncrementRealDummyXmls(pi.Name, controlXamlFragment, curr.OuterXml);
#endif
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
            //string controlXamlFragment = ReplacePlaceholderTexts(PRIMITIVE_TYPES_TEMPLATES[ctrlTyp], pi);
            ////XmlNode curr = container.OwnerDocument.CreateNode(XmlNodeType.Element, dummyNodeElementName, container.OwnerDocument.Attributes[dummyNodeElementNamespaceAttrNm].Value); //doesn't work
            //XmlNode curr = container.OwnerDocument.CreateNode(XmlNodeType.Element, dummyNodeElementName, NewElemNS);
            //XSDReflectionUtil.WriteAttribute(curr, uniquifierAttrName, Guid.NewGuid().ToString());
            XmlDocument controlXamlFragmentDoc = new XmlDocument();
            controlXamlFragmentDoc.LoadXml(PRIMITIVE_TYPES_TEMPLATES[ctrlTyp]);
            XmlNode sourceBucket = controlXamlFragmentDoc.DocumentElement;
            foreach (XmlNode currSrc in sourceBucket.ChildNodes)
            {
                XmlNode curr = container.OwnerDocument.ImportNode(currSrc, true);
                ReplacePlaceholderTexts(curr, pi);
                container.InsertAfter(curr, container.LastChild);
            }
         
            //IncrementRealDummyXmls(pi.Name, controlXamlFragment, curr.OuterXml);
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

        private void ReplacePlaceholderTexts(XmlNode target, PropertyInfo pi)
        {
            BGU.DRPL.SignificantOwnership.Utility.XSDReflectionUtil.PropDispDescr pdd;
            if (PropDispDescrs.ContainsKey(pi.Name))
                pdd = PropDispDescrs[pi.Name];
            else
                pdd = new XSDReflectionUtil.PropDispDescr() { Category = string.Empty, DisplayName = pi.Name, Description = pi.Name};
            ReplacePlaceholderAttrsRecursively(target, pi, pdd);
        }


        private void ReplacePlaceholderAttrsRecursively(XmlNode target, PropertyInfo pi, XSDReflectionUtil.PropDispDescr pdd)
        {
            ReplaceAllAttrsPlaceholders(target, templatedPropertyNamePlaceholder, pi.Name);
            ReplaceAllAttrsPlaceholders(target, templatedPropertyDispNamePlaceholder, pdd.DisplayName);
            ReplaceAllAttrsPlaceholders(target, templatedPropertyDescrPlaceholder, pdd.Description);

            foreach(XmlNode child in target.ChildNodes)
            {
                ReplacePlaceholderAttrsRecursively(child, pi, pdd);
            }
        }

        private void ReplaceAllAttrsPlaceholders(XmlNode target,string phTxt,string replTxt)
        {
            Dictionary<string, string> attrsToModify = new Dictionary<string, string>();
            foreach(XmlAttribute attr in target.Attributes)
            {
                if (attr.Value.IndexOf(phTxt) == -1)
                    continue;
                string newAttrValue = attr.Value.Replace(phTxt, replTxt);
                attrsToModify.Add(attr.Name, newAttrValue);
            }
            foreach (string attrNm in attrsToModify.Keys)
            {
                XSDReflectionUtil.WriteAttribute(target, attrNm, attrsToModify[attrNm]);
            }
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
    }
}
