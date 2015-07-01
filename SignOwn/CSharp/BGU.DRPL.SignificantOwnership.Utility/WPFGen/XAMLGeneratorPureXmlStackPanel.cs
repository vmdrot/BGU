﻿#define __DISABLE_TEXT_INSERTION__
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Reflection;
using System.ComponentModel;
using System.IO;
using System.Configuration;
using System.Xml.Serialization;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Utility.WPFGen
{
    public class XAMLGeneratorPureXmlStackPanel : IXAMLGenerator
    {
        private List<Type> _referencedTypes = new List<Type>();
        private Dictionary<Type, string> _referencedControlTemplateNames;
        private Assembly _userAssembly;
        private Type _rootType;
        private string _targetPath;
        private Dictionary<Type,Dictionary<string, BGU.DRPL.SignificantOwnership.Utility.XSDReflectionUtil.PropDispDescr>> _propDispDescrs;
        private static readonly Dictionary<Type, string> PRIMITIVE_TYPES_TEMPLATES;
        private static readonly string templatedPropertyNamePlaceholder = "yourPropertyName";
        private static readonly string templatedPropertyDispNamePlaceholder = "yourPropertyDispName";
        private static readonly string templatedPropertyDescrPlaceholder = "yourPropertyDescription";
        private static readonly string templatedEnumListerPlaceholder = "yourEnumListerProperty";
        private static readonly string templatedTypeNamePlaceholder = "yourTemplatedTypeName";
        private static readonly string templatedComboItemsGetterPlaceholder = "yourComboItemsGetter";
        private static readonly string templatedComboDisplayMemberPlaceholder = "yourComboDisplayMember";
        private static readonly string templatedCategoryNamePlaceholder = "yourCategoryName";
            
        //private static readonly string templatedGridRowAttributeName = "Grid.Row";
        private static readonly string classStructControlTemplate = BGU.DRPL.SignificantOwnership.Utility.XAMLTemplates.XAMLPrimitiveTemplates.classstruct;
        private static readonly string classStructNoExpanderWrapControlTemplate = BGU.DRPL.SignificantOwnership.Utility.XAMLTemplates.XAMLPrimitiveTemplates.classstruct_noExpander;
        private static readonly string listOfTTemplate = BGU.DRPL.SignificantOwnership.Utility.XAMLTemplates.XAMLPrimitiveTemplates.ListOfT;
        private static readonly string multilineTemplate = BGU.DRPL.SignificantOwnership.Utility.XAMLTemplates.XAMLPrimitiveTemplates.multilinestring;
        private static readonly string listOfT_DataColumnTemplate = BGU.DRPL.SignificantOwnership.Utility.XAMLTemplates.XAMLPrimitiveTemplates.DataGridTextColumnTemplate;
        private static readonly string listOfT_CMDsColumnTemplate = BGU.DRPL.SignificantOwnership.Utility.XAMLTemplates.XAMLPrimitiveTemplates.DataGridCommandsColumnTemplate;
        private static readonly string comboTemplate = BGU.DRPL.SignificantOwnership.Utility.XAMLTemplates.XAMLPrimitiveTemplates.ComboTemplate;
        private static readonly string categoryExpanderTemplate = BGU.DRPL.SignificantOwnership.Utility.XAMLTemplates.XAMLPrimitiveTemplates.CategoryExpander;
        //private static readonly string dummyNodeElementName = "dummyPhTag";
        //private static readonly string dummyNodeElementNamespaceAttrNm = "xmlns";
        //private static readonly string uniquifierAttrName = "guuiidd";
        private static readonly string NewElemNS = "http://schemas.microsoft.com/winfx/2006/xaml/presentation";
        private static readonly Dictionary<string, string> _bguNS2XamlPfxs;
        private static readonly string BGU2XAML_NS_CFG_PFX = "xamlns4:";
        private Dictionary<string, XmlNode> _categoriesNodes = new Dictionary<string,XmlNode>();


        private Dictionary<string, BGU.DRPL.SignificantOwnership.Utility.XSDReflectionUtil.PropDispDescr> GetPropDispDescrs(Type typ)
        {
            if(_propDispDescrs == null)
            {
                _propDispDescrs = new Dictionary<Type, Dictionary<string, XSDReflectionUtil.PropDispDescr>>();
            }
            if (!_propDispDescrs.ContainsKey(typ))
                _propDispDescrs.Add(typ, XSDReflectionUtil.FetchPropDispsDescrs(typ));
            return _propDispDescrs[typ];
        }

        static XAMLGeneratorPureXmlStackPanel()
        {
            PRIMITIVE_TYPES_TEMPLATES = new Dictionary<Type, string>();

            PRIMITIVE_TYPES_TEMPLATES.Add(typeof(bool), BGU.DRPL.SignificantOwnership.Utility.XAMLTemplates.XAMLPrimitiveTemplates._bool);
            PRIMITIVE_TYPES_TEMPLATES.Add(typeof(bool?), BGU.DRPL.SignificantOwnership.Utility.XAMLTemplates.XAMLPrimitiveTemplates._bool);
            PRIMITIVE_TYPES_TEMPLATES.Add(typeof(int), BGU.DRPL.SignificantOwnership.Utility.XAMLTemplates.XAMLPrimitiveTemplates._int);
            PRIMITIVE_TYPES_TEMPLATES.Add(typeof(int?), BGU.DRPL.SignificantOwnership.Utility.XAMLTemplates.XAMLPrimitiveTemplates._int);
            PRIMITIVE_TYPES_TEMPLATES.Add(typeof(decimal), BGU.DRPL.SignificantOwnership.Utility.XAMLTemplates.XAMLPrimitiveTemplates._decimal);
            PRIMITIVE_TYPES_TEMPLATES.Add(typeof(decimal?), BGU.DRPL.SignificantOwnership.Utility.XAMLTemplates.XAMLPrimitiveTemplates._decimal);
            PRIMITIVE_TYPES_TEMPLATES.Add(typeof(string), BGU.DRPL.SignificantOwnership.Utility.XAMLTemplates.XAMLPrimitiveTemplates.onelinestring);
            PRIMITIVE_TYPES_TEMPLATES.Add(typeof(double), BGU.DRPL.SignificantOwnership.Utility.XAMLTemplates.XAMLPrimitiveTemplates._decimal);//todo
            PRIMITIVE_TYPES_TEMPLATES.Add(typeof(double?), BGU.DRPL.SignificantOwnership.Utility.XAMLTemplates.XAMLPrimitiveTemplates._decimal);//todo
            PRIMITIVE_TYPES_TEMPLATES.Add(typeof(DateTime), BGU.DRPL.SignificantOwnership.Utility.XAMLTemplates.XAMLPrimitiveTemplates.DateTime);
            PRIMITIVE_TYPES_TEMPLATES.Add(typeof(DateTime?), BGU.DRPL.SignificantOwnership.Utility.XAMLTemplates.XAMLPrimitiveTemplates.DateTime);
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
        }

        private void AddReferencedControlTemplatesIncludes(XmlDocument xamlDoc1)
        {
            //XmlNode container = xamlDoc1.DocumentElement.SelectSingleNode("//ResourceDictionary.MergedDictionaries"); //doesn't work
            XmlNode container = xamlDoc1.DocumentElement.FirstChild;
            foreach(Type typ in _referencedTypes)
            {
                if (!_referencedControlTemplateNames.ContainsKey(typ))
                    continue;
                XmlNode currInclude = container.OwnerDocument.CreateNode(XmlNodeType.Element, "ResourceDictionary", xamlDoc1.DocumentElement.NamespaceURI);
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
            XmlNode dataTemplateNode = rslt.FirstChild.ChildNodes[1];//rslt.SelectSingleNode("/ResourceDictionary/DataTemplate/Grid"); //doesn't work
            XmlNode gridNode = dataTemplateNode.FirstChild;
            ReplaceTemplateDataType(dataTemplateNode, typ);
            AddTemplateDataTypeNS(rslt.DocumentElement, typ);
            List<PropertyInfo> props = ReflectionUtil.ListEditableProperties(typ);
            CreateCategoriesNodes(gridNode, props);
            foreach(PropertyInfo pi in props)
            {
                AddControl(gridNode, pi);
            }

            //clean-up
            RemoveEmptyNSAttrs((XmlNode)rslt.DocumentElement);

            return rslt;
        }

        private void CreateCategoriesNodes(XmlNode gridNode, List<PropertyInfo> props)
        {
            List<String> categoryNames = new List<string>();
            foreach (PropertyInfo pi in props)
            {
                CategoryAttribute catAttr = ReflectionUtil.GetPropertyOrTypeAttribute<CategoryAttribute>(pi);
                if (catAttr == null || categoryNames.Contains(catAttr.Category))
                    continue;
                categoryNames.Add(catAttr.Category);
            }
            if (categoryNames.Count == 0)
                return;

            foreach (string catname in categoryNames)
            {
                XmlDocument catExpanderDoc = new XmlDocument();
                catExpanderDoc.LoadXml(categoryExpanderTemplate);
                ReplacePlaceholderAttrRecursively(catExpanderDoc.DocumentElement.FirstChild, templatedCategoryNamePlaceholder, catname);
                XmlNode importedExpander = gridNode.OwnerDocument.ImportNode(catExpanderDoc.DocumentElement.FirstChild, true);
                gridNode.InsertAfter(importedExpander, gridNode.LastChild);
                XSDReflectionUtil.WriteAttribute(importedExpander, "xmlns", gridNode.OwnerDocument.DocumentElement.NamespaceURI);
                _categoriesNodes.Add(catname, importedExpander.FirstChild);
            }
        }

        private bool CheckIsXmlIgnore(PropertyInfo pi)
        {
            if (!Attribute.IsDefined(pi, typeof(XmlIgnoreAttribute)))
                return false;

            Attribute reqAttr0 = Attribute.GetCustomAttribute((MemberInfo)pi, typeof(XmlIgnoreAttribute));
            if (reqAttr0 is XmlIgnoreAttribute)
            {
                return true;
            }
            return false;
        }

        private bool CheckIsBrowsable(PropertyInfo pi)
        {
            if (!Attribute.IsDefined(pi, typeof(BrowsableAttribute)))
                return true;

            Attribute reqAttr0 = Attribute.GetCustomAttribute((MemberInfo)pi, typeof(BrowsableAttribute));
            if (reqAttr0 is BrowsableAttribute)
            {
                BrowsableAttribute reqAttr = (BrowsableAttribute)reqAttr0;
                return reqAttr.Browsable;
            }
            return true;
        }


        private void RemoveEmptyNSAttrs(XmlNode target)
        {
            if (target.Attributes["xmlns"] != null && target.Attributes["xmlns"].Value == string.Empty)
                target.Attributes.Remove(target.Attributes["xmlns"]);

            foreach(XmlNode child in target.ChildNodes)
            {
                if (child.NodeType != XmlNodeType.Element)
                    continue;
                RemoveEmptyNSAttrs(child);
            }
        }

        private void AddTemplateDataTypeNS(XmlElement resourceDicNode, Type typ)
        {
            //xmlns:bguq="clr-namespace:BGU.DRPL.SignificantOwnership.Core.Questionnaires;assembly=BGU.DRPL.SignificantOwnership.Core"
            string attrNm = string.Format("xmlns:{0}", _bguNS2XamlPfxs[typ.Namespace]);
            string assemblyShortName = typ.Assembly.FullName;
            int commaPos = assemblyShortName.IndexOf(',');
            assemblyShortName = assemblyShortName.Substring(0, commaPos);
            string attrVal = string.Format("clr-namespace:{0};assembly={1}", typ.Namespace, assemblyShortName);
            XSDReflectionUtil.WriteAttribute(resourceDicNode, attrNm, attrVal);
        }


        private void ReplaceTemplateDataType(XmlNode dataTemplateNode, Type typ)
        {
            string xamlDataTypeAlias = string.Format("{0}:{1}", _bguNS2XamlPfxs[typ.Namespace], typ.Name);
            ReplaceAllAttrPlaceholdersSingleNode(dataTemplateNode, templatedTypeNamePlaceholder, xamlDataTypeAlias);
        }

        private void AddControl(XmlNode container, PropertyInfo pi)
        {
            
            UIUsageComboAttribute comboAttr;
            XmlNode insertInto = container;
            CategoryAttribute catAttr = ReflectionUtil.GetPropertyOrTypeAttribute<CategoryAttribute>(pi);
            if (catAttr != null && _categoriesNodes.ContainsKey(catAttr.Category))
                insertInto = _categoriesNodes[catAttr.Category];
            if (IsUIComboUsageDefined(pi, out comboAttr)) AddCombo(insertInto, pi, comboAttr);
            else if (pi.PropertyType == typeof(string) || pi.PropertyType == typeof(String)) AddStringEditControl(insertInto, pi);
            else if (pi.PropertyType == typeof(int) || pi.PropertyType == typeof(int?) || pi.PropertyType == typeof(Int32) || pi.PropertyType == typeof(long) || pi.PropertyType == typeof(Int64) || pi.PropertyType == typeof(short) || pi.PropertyType == typeof(Int16)) AddIntEditControl(insertInto, pi);
            else if (pi.PropertyType == typeof(decimal) || pi.PropertyType == typeof(decimal) || pi.PropertyType == typeof(float) || pi.PropertyType == typeof(double) || pi.PropertyType == typeof(Double) || pi.PropertyType == typeof(Decimal)) AddDecimalEditControl(insertInto, pi);
            else if (pi.PropertyType == typeof(DateTime) || pi.PropertyType == typeof(DateTime?)) AddDateTimeEditControl(insertInto, pi);
            else if (pi.PropertyType == typeof(bool) || pi.PropertyType == typeof(bool) || pi.ReflectedType == typeof(Boolean)) AddBoolEditControl(insertInto, pi);
            else if (pi.PropertyType.IsEnum) AddEnumEditControl(insertInto, pi);
            else if (pi.PropertyType.IsGenericType) AddCollectionEditControl(insertInto, pi);
            else if (pi.PropertyType.Assembly == _userAssembly) AddComplextTypeControl(insertInto, pi);
        }

        private bool IsUIComboUsageDefined(PropertyInfo pi, out UIUsageComboAttribute attr)
        {
            attr = ReflectionUtil.GetPropertyOrTypeAttribute<UIUsageComboAttribute>(pi);
            if (attr != null)
                return true;
            return false;
        }

        private void AddCombo(XmlNode container, PropertyInfo pi, UIUsageComboAttribute comboAttr)
        {
            //<ComboBox ToolTip="" ItemsSource="{Binding Source={x:Static bgud:CountryInfo.AllCountries}, Mode=OneWay, diag:PresentationTraceSources.TraceLevel=High}" SelectedItem="{Binding Path=OperationCountry, Mode=TwoWay, diag:PresentationTraceSources.TraceLevel=High}" DisplayMemberPath="CountryNameUkr" HorizontalAlignment="Stretch" />
            XmlDocument controlXamlFragmentDoc = new XmlDocument();
            controlXamlFragmentDoc.LoadXml(comboTemplate);
            XmlNode sourceBucket = controlXamlFragmentDoc.DocumentElement;

            //foreach (XmlNode currSrc in sourceBucket.ChildNodes)
            //{

            XmlNode currSrc = sourceBucket.FirstChild;
            XmlNode curr = container.OwnerDocument.ImportNode(currSrc, true);
            XSDReflectionUtil.WriteAttribute(curr, "xmlns", container.OwnerDocument.DocumentElement.NamespaceURI);
            ReplacePlaceholderTexts(curr, pi);
            ReplacePlaceholderAttrRecursively(curr, templatedComboDisplayMemberPlaceholder, comboAttr.DisplayMember);
            if (comboAttr.ItemsGetterClass != null && !string.IsNullOrEmpty(comboAttr.ItemsGetterMemberPath))
            {
                if(!_bguNS2XamlPfxs.ContainsKey(comboAttr.ItemsGetterClass.Namespace))
                    throw new ApplicationException(String.Format("No namespace prefix defined for the namespace '{0}'", comboAttr.ItemsGetterClass.Namespace));
                string itemsGetter = string.Format("{0}:{1}.{2}", _bguNS2XamlPfxs[comboAttr.ItemsGetterClass.Namespace], comboAttr.ItemsGetterClass.Name, comboAttr.ItemsGetterMemberPath);
                ReplacePlaceholderAttrRecursively(curr, templatedComboItemsGetterPlaceholder, itemsGetter);
                AddTemplateDataTypeNS(container.OwnerDocument.DocumentElement, comboAttr.ItemsGetterClass);
            }
            XmlNode comboNode = curr.ChildNodes[1];
            if (comboAttr.ValueMemberUsageMode == ComboUIValueUsageMode.ValueProperty)
            {
                XSDReflectionUtil.WriteAttribute(comboNode, "SelectedValuePath", comboAttr.ValueMember);
                XSDReflectionUtil.WriteAttribute(comboNode, "SelectedValue", string.Format("{{Binding Path={0}, Mode=TwoWay, diag:PresentationTraceSources.TraceLevel=High}}", pi.Name));
            }
            else if (comboAttr.ValueMemberUsageMode == ComboUIValueUsageMode.SelectedItem)
            {
                XSDReflectionUtil.WriteAttribute(comboNode, "SelectedItem", string.Format("{{Binding Path={0}, Mode=TwoWay, diag:PresentationTraceSources.TraceLevel=High}}", pi.Name));
            }

            if(!string.IsNullOrEmpty(comboAttr.Width))
                XSDReflectionUtil.WriteAttribute(comboNode, "Width", comboAttr.Width);



            container.InsertAfter(curr, container.LastChild);
        }

        private void AddCollectionEditControl(XmlNode container, PropertyInfo pi)
        {
            XmlDocument controlXamlFragmentDoc = new XmlDocument();
            controlXamlFragmentDoc.LoadXml(listOfTTemplate);
            XmlNode sourceBucket = controlXamlFragmentDoc.DocumentElement;
            XmlNode expanderNode = null;
            foreach (XmlNode currSrc in sourceBucket.ChildNodes)
            {
                XmlNode curr = container.OwnerDocument.ImportNode(currSrc, true);
                XSDReflectionUtil.WriteAttribute(curr, "xmlns", container.OwnerDocument.DocumentElement.NamespaceURI);
                ReplacePlaceholderTexts(curr, pi);
                
                container.InsertAfter(curr, container.LastChild);
                if (curr.Name == "Expander")
                    expanderNode = curr;
            }

            if(pi.PropertyType.IsGenericType)
            {
                Type[] tmp = pi.PropertyType.GetGenericArguments();
                Type itemTyp = null;
                if(tmp != null && tmp.Length > 0)
                    itemTyp = tmp[0];

                XmlNode dgNode = expanderNode.FirstChild.FirstChild;
                XmlNode dgColDefsNode = null;
                if (dgNode.Name == "DataGrid")
                    dgColDefsNode = dgNode.FirstChild;
                if (dgColDefsNode != null)
                {
                    List<PropertyInfo> pis = ReflectionUtil.ListEditableProperties(itemTyp);
                    foreach (PropertyInfo ppi in pis)
                    {
                        XmlDocument currColDefDoc = new XmlDocument();
                        currColDefDoc.LoadXml(listOfT_DataColumnTemplate);
                        XmlNode colDefSrc = currColDefDoc.DocumentElement.FirstChild;
                        ReplacePlaceholderTexts(colDefSrc, ppi, itemTyp, true);
                        XmlNode currColDef = container.OwnerDocument.ImportNode(colDefSrc, true);
                        dgColDefsNode.InsertAfter(currColDef, dgColDefsNode.LastChild);
                    }

                    #region Insert action buttons column
                    {
                        XmlDocument currColDefDoc = new XmlDocument();
                        currColDefDoc.LoadXml(listOfT_CMDsColumnTemplate);
                        XmlNode colDefSrc = currColDefDoc.DocumentElement.FirstChild;
                        ReplacePlaceholderTexts(colDefSrc, pi, itemTyp, true);
                        XmlNode currColDef = container.OwnerDocument.ImportNode(colDefSrc, true);
                        dgColDefsNode.InsertAfter(currColDef, dgColDefsNode.LastChild);
                    }
                    #endregion
                }

                if (!_referencedTypes.Contains(itemTyp))
                    _referencedTypes.Add(itemTyp);

            }
        }

        private void AddComplextTypeControl(XmlNode container, PropertyInfo pi)
        {
          
            XmlDocument controlXamlFragmentDoc = new XmlDocument();
            XamlExpanderWrappingAttribute wrapAttr = ReflectionUtil.GetPropertyOrTypeAttribute<XamlExpanderWrappingAttribute>(pi);
            string controlTemplate = null;
            if (wrapAttr == null || wrapAttr.WrapIntoExpander)
                controlTemplate = classStructControlTemplate;
            else
                controlTemplate = classStructNoExpanderWrapControlTemplate;
            controlXamlFragmentDoc.LoadXml(controlTemplate);
            XmlNode sourceBucket = controlXamlFragmentDoc.DocumentElement;
            foreach (XmlNode currSrc in sourceBucket.ChildNodes)
            {
                XmlNode curr = container.OwnerDocument.ImportNode(currSrc, true);
                XSDReflectionUtil.WriteAttribute(curr, "xmlns", container.OwnerDocument.DocumentElement.NamespaceURI);
                ReplacePlaceholderTexts(curr, pi);
                
                container.InsertAfter(curr, container.LastChild);
            }

            if (!_referencedTypes.Contains(pi.PropertyType))
                _referencedTypes.Add(pi.PropertyType);
        }

        private void AddPrimitiveEditControl(XmlNode container, PropertyInfo pi)
        {
            throw new NotImplementedException();
        }

        private void AddEnumEditControl(XmlNode container, PropertyInfo pi)
        {
            XmlDocument controlXamlFragmentDoc = new XmlDocument();
            controlXamlFragmentDoc.LoadXml(PRIMITIVE_TYPES_TEMPLATES[typeof(Enum)]);
            XmlNode sourceBucket = controlXamlFragmentDoc.DocumentElement;
            foreach (XmlNode currSrc in sourceBucket.ChildNodes)
            {
                XmlNode curr = container.OwnerDocument.ImportNode(currSrc, true);
                XSDReflectionUtil.WriteAttribute(curr, "xmlns", container.OwnerDocument.DocumentElement.NamespaceURI);
                ReplacePlaceholderTexts(curr, pi);
                ReplacePlaceholderAttrRecursively(curr, templatedEnumListerPlaceholder, string.Format("{0}List", pi.PropertyType.Name));
                
                container.InsertAfter(curr, container.LastChild);
            }

            if (!_referencedTypes.Contains(pi.PropertyType))
                _referencedTypes.Add(pi.PropertyType);
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
            bool isMultiline = Attribute.IsDefined(pi, typeof(MultilineAttribute));

            if(!isMultiline)
                AddEditControlWorker(container, pi, typeof(string));
            else
                AddEditControlWorker(container, pi, typeof(string), multilineTemplate);
        }

        private void AddEditControlWorker(XmlNode container, PropertyInfo pi, Type ctrlTyp)
        {
            AddEditControlWorker(container, pi, ctrlTyp, PRIMITIVE_TYPES_TEMPLATES[ctrlTyp]);
        }
        
    
        private void AddEditControlWorker(XmlNode container, PropertyInfo pi, Type ctrlTyp, string controlXamlTemplate)
        {
            //string controlXamlFragment = ReplacePlaceholderTexts(PRIMITIVE_TYPES_TEMPLATES[ctrlTyp], pi);
            ////XmlNode curr = container.OwnerDocument.CreateNode(XmlNodeType.Element, dummyNodeElementName, container.OwnerDocument.Attributes[dummyNodeElementNamespaceAttrNm].Value); //doesn't work
            //XmlNode curr = container.OwnerDocument.CreateNode(XmlNodeType.Element, dummyNodeElementName, NewElemNS);
            //XSDReflectionUtil.WriteAttribute(curr, uniquifierAttrName, Guid.NewGuid().ToString());
            XmlDocument controlXamlFragmentDoc = new XmlDocument();
            controlXamlFragmentDoc.LoadXml(controlXamlTemplate);
            XmlNode sourceBucket = controlXamlFragmentDoc.DocumentElement;
            foreach (XmlNode currSrc in sourceBucket.ChildNodes)
            {
                XmlNode curr = container.OwnerDocument.ImportNode(currSrc, true);
                XSDReflectionUtil.WriteAttribute(curr, "xmlns", container.OwnerDocument.DocumentElement.NamespaceURI);
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
            ReplacePlaceholderTexts(target, pi, _rootType, false);
        }

        private void ReplacePlaceholderTexts(XmlNode target, PropertyInfo pi, Type typ, bool substDescrWithNonNullDisp)
        {
            BGU.DRPL.SignificantOwnership.Utility.XSDReflectionUtil.PropDispDescr pdd;
            if (GetPropDispDescrs(typ).ContainsKey(pi.Name))
            {
                BGU.DRPL.SignificantOwnership.Utility.XSDReflectionUtil.PropDispDescr pddOrig = GetPropDispDescrs(typ)[pi.Name];
                if (substDescrWithNonNullDisp && !string.IsNullOrEmpty(pddOrig.DisplayName) && string.IsNullOrEmpty(pddOrig.Description))
                    pdd = new XSDReflectionUtil.PropDispDescr() { Category = pddOrig.Category, DisplayName = pddOrig.DisplayName, Description = pddOrig.DisplayName};
                else pdd = pddOrig;
            }
            else
                pdd = new XSDReflectionUtil.PropDispDescr() { Category = string.Empty, DisplayName = pi.Name, Description = pi.Name };
            ReplaceStandardPlaceholderAttrsRecursively(target, pi, pdd);
        }


        private void ReplaceStandardPlaceholderAttrsRecursively(XmlNode target, PropertyInfo pi, XSDReflectionUtil.PropDispDescr pdd)
        {
            ReplacePlaceholderAttrRecursively(target, templatedPropertyNamePlaceholder, pi.Name);
            ReplacePlaceholderAttrRecursively(target, templatedPropertyDispNamePlaceholder, pdd.DisplayName);
            ReplacePlaceholderAttrRecursively(target, templatedPropertyDescrPlaceholder, pdd.Description);
        }

        private void ReplacePlaceholderAttrRecursively(XmlNode target, string phTxt, string replTxt)
        {
            ReplaceAllAttrPlaceholdersSingleNode(target, phTxt, replTxt);
            foreach (XmlNode child in target.ChildNodes)
            {
                if (child.NodeType != XmlNodeType.Element)
                    continue;
                ReplacePlaceholderAttrRecursively(child, phTxt, replTxt);
            }
        }

        private void ReplaceAllAttrPlaceholdersSingleNode(XmlNode target,string phTxt,string replTxt)
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
                //XSDReflectionUtil.WriteAttribute(target, attrNm, attrsToModify[attrNm]);
                target.Attributes[attrNm].Value = attrsToModify[attrNm];
            }
        }
    }
}
