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
using System.Xml.Serialization;
using Evolvex.Utility.Core.ComponentModelEx;
using Evolvex.Utility.Core.Common;

namespace BGU.DRPL.SignificantOwnership.Utility.WPFGen
{
    public class XAMLGeneratorPureXmlStackPanel : IXAMLGenerator
    {
        #region field(s)
        private static readonly ILog log = Logging.GetLogger(typeof(XAMLGeneratorPureXmlStackPanel));

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
        private static readonly string templatedComboBtnAddCommandPlaceholder = "yourAddComboItemCommand";
        private static readonly string templatedEnumCurrentValueTextPlaceholder = "yourEnumCurrentValueText";
        private static readonly string templatedEnumCurrentValueDescriptionPlaceholder = "yourEnumCurrentValueDescription";
        private static readonly string templatedDataGridOneColumnHeaderPlaceholder = "yourDataGridOneColumnHeader";
        private static readonly string templatedComboItemToolTipPropertyNamePlaceholder = "yourComboItemToolTipPropertyName";
        
        
            
        //private static readonly string templatedGridRowAttributeName = "Grid.Row";
        private static readonly string classStructControlTemplate = BGU.DRPL.SignificantOwnership.Utility.XAMLTemplates.XAMLPrimitiveTemplates.classstruct;
        private static readonly string classStructNoExpanderWrapControlTemplate = BGU.DRPL.SignificantOwnership.Utility.XAMLTemplates.XAMLPrimitiveTemplates.classstruct_noExpander;
        private static readonly string listOfTTemplate = BGU.DRPL.SignificantOwnership.Utility.XAMLTemplates.XAMLPrimitiveTemplates.ListOfT;
        private static readonly string multilineTemplate = BGU.DRPL.SignificantOwnership.Utility.XAMLTemplates.XAMLPrimitiveTemplates.multilinestring;
        private static readonly string listOfT_DataColumnTemplate = BGU.DRPL.SignificantOwnership.Utility.XAMLTemplates.XAMLPrimitiveTemplates.DataGridTextColumnTemplate;
        private static readonly string listOfT_CMDsColumnTemplate = BGU.DRPL.SignificantOwnership.Utility.XAMLTemplates.XAMLPrimitiveTemplates.DataGridCommandsColumnTemplate;
        private static readonly string listOfT_OneColumnDataTemplate = BGU.DRPL.SignificantOwnership.Utility.XAMLTemplates.XAMLPrimitiveTemplates.DataGridOneColumnTemplate;
        private static readonly string comboTemplate = BGU.DRPL.SignificantOwnership.Utility.XAMLTemplates.XAMLPrimitiveTemplates.ComboTemplate;
        private static readonly string categoryExpanderTemplate = BGU.DRPL.SignificantOwnership.Utility.XAMLTemplates.XAMLPrimitiveTemplates.CategoryExpander;
        private static readonly string comboAddBtnTemplate = BGU.DRPL.SignificantOwnership.Utility.XAMLTemplates.XAMLPrimitiveTemplates.ComboAddBtn;
        private static readonly string enumRadioButtonGroupTemplate = BGU.DRPL.SignificantOwnership.Utility.XAMLTemplates.XAMLPrimitiveTemplates.RadioButtonGroup;
        private static readonly string enumRadioButtonTemplate = BGU.DRPL.SignificantOwnership.Utility.XAMLTemplates.XAMLPrimitiveTemplates.RadioButton;
        private static readonly string comboItemTooltipTemplate = BGU.DRPL.SignificantOwnership.Utility.XAMLTemplates.XAMLPrimitiveTemplates.ComboItemToolTip;
        

        private static readonly string NewElemNS = "http://schemas.microsoft.com/winfx/2006/xaml/presentation";
        private static readonly Dictionary<string, string> _bguNS2XamlPfxs;
        private static readonly string BGU2XAML_NS_CFG_PFX = "xamlns4:";
        private Dictionary<string, XmlNode> _categoriesNodes = new Dictionary<string,XmlNode>();
        private Dictionary<string, int> _propertyIndexes = new Dictionary<string, int>();
        private Dictionary<int, string> _indexes2PropNames = new Dictionary<int, string>();
        private Dictionary<string, ResultantControlNodesRange> _propertyNodes = new Dictionary<string, ResultantControlNodesRange>();
        private Dictionary<string, PropertyInfo> _propsByNames = new Dictionary<string,PropertyInfo>();
        #endregion
        #region prop(s)
        public bool GenerateInlineTemplateOnly { get; set; }
        public UIPartialFieldsVisibilityAttribute InlineTemplateParams{ get; set; }

        #endregion


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
            if (!this.GenerateInlineTemplateOnly || this.InlineTemplateParams == null)
            {
                ReplaceTemplateDataType(dataTemplateNode, typ);
                AddTemplateDataTypeNS(rslt.DocumentElement, typ);
            }
            List<PropertyInfo> props = FilterEditableProps(ReflectionUtil.ListEditableProperties(typ));
            CreateCategoriesNodes(gridNode, props);
            //if (!this.GenerateInlineTemplateOnly || this.InlineTemplateParams == null)
            //{
                foreach (PropertyInfo pi in props)
                {
                    AddControl(gridNode, pi);
                }
            //}
            //else
            //{
            //    List<string> propNamesLst = ParsePropsList(this.InlineTemplateParams.PropsList);
            //    foreach (PropertyInfo pi in props)
            //    {
            //        if (InlineTemplateParams.ShowOrHide)
            //        {
            //            if (!propNamesLst.Contains(pi.Name))
            //                continue;

            //        }
            //        else
            //        { 
            //            if(propNamesLst.Contains(pi.Name))
            //                continue;
            //        }
            //        AddControl(gridNode, pi);
            //    }

            //}

            //clean-up
            RemoveEmptyNSAttrs((XmlNode)rslt.DocumentElement);

            return rslt;
        }

        private List<PropertyInfo> FilterEditableProps(List<PropertyInfo> list)
        {
            if (!this.GenerateInlineTemplateOnly)
                return list;
            List<string> propNamesLst = ParsePropsList(this.InlineTemplateParams.PropsList);
            List<PropertyInfo> rslt = new List<PropertyInfo>();
            foreach(PropertyInfo pi in list)
            {
                if (InlineTemplateParams.ShowOrHide)
                {
                    if (!propNamesLst.Contains(pi.Name))
                        continue;

                }
                else
                {
                    if (propNamesLst.Contains(pi.Name))
                        continue;
                }
                rslt.Add(pi);
            }
            return rslt;
        }

        private List<string> ParsePropsList(string propLstStr)
        {
            List<string> rslt = new List<string>();
            string[] aRaw = propLstStr.Split(',');
            foreach (string sRaw in aRaw)
            { 
                if(string.IsNullOrEmpty(sRaw))
                    continue;
                string trimmed = sRaw.Trim();
                if (string.IsNullOrEmpty(trimmed))
                    continue;
                rslt.Add(trimmed);
            }
            return rslt;
        }

        private void CreateCategoriesNodes(XmlNode gridNode, List<PropertyInfo> props)
        {
            List<String> categoryNames = new List<string>();
            int i = 0;
            foreach (PropertyInfo pi in props)
            {
                _propertyIndexes.Add(pi.Name, i++);
                _indexes2PropNames.Add(_propertyIndexes[pi.Name], pi.Name);
                _propsByNames.Add(pi.Name, pi);
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

        private ControlInsertionPosition DetectControlInsertionPosition(PropertyInfo pi, XmlNode container)
        {
            ControlInsertionPosition rslt = new ControlInsertionPosition();

            CategoryAttribute catAttr = ReflectionUtil.GetPropertyOrTypeAttribute<CategoryAttribute>(pi);
            if (catAttr != null && _categoriesNodes.ContainsKey(catAttr.Category))
            {
                rslt.BeforeOrAfter = InsertRelLocType.After;
                rslt.RelNode = _categoriesNodes[catAttr.Category];
                rslt.ChildRel = InsertChildRelLocType.LastChild;
            }
            else
            {
                string prevPropName = FindPreviousPropertyName(pi.Name);
                if (string.IsNullOrEmpty(prevPropName))
                {
                    rslt.RelNode = container;
                    rslt.BeforeOrAfter = InsertRelLocType.Before;
                    rslt.ChildRel = InsertChildRelLocType.FirstChild;
                }
                else
                {
                    PropertyInfo prevProp = _propsByNames[prevPropName];
                    CategoryAttribute prevPropCatAttr = ReflectionUtil.GetPropertyOrTypeAttribute<CategoryAttribute>(prevProp);
                    if (prevPropCatAttr != null)
                    {
                        rslt.RelNode = _categoriesNodes[prevPropCatAttr.Category].ParentNode;
                        rslt.BeforeOrAfter = InsertRelLocType.After;
                        rslt.ChildRel = InsertChildRelLocType.NodeItself;
                    }
                    else
                    {
                        rslt.RelNode = _propertyNodes[prevPropName].Last;
                        rslt.BeforeOrAfter = InsertRelLocType.After;
                        rslt.ChildRel = InsertChildRelLocType.NodeItself;
                    }
                }
            }

            return rslt;
        }

        private string FindPreviousPropertyName(string propNm)
        {
            if (_propertyIndexes[propNm] == 0)
                return null;
            return _indexes2PropNames[_propertyIndexes[propNm] - 1];

        }

        private void AddControl(XmlNode container, PropertyInfo pi)
        {
            
            UIUsageComboAttribute comboAttr;
            UIUsageComboAddButtonAttribute comboAddBtnAttr;
            UIUsageTextBoxAttribute textBoxAttr;
            ControlInsertionPosition insPos = DetectControlInsertionPosition(pi, container);
            if (IsPropOrTypeAttributeDefined<UIUsageComboAttribute>(pi, out comboAttr)) AddCombo(insPos, pi, comboAttr);
            else if (IsPropOrTypeAttributeDefined<UIUsageComboAddButtonAttribute>(pi, out comboAddBtnAttr)) AddComboAddBtn(insPos, pi, comboAddBtnAttr);
            else if (IsPropOrTypeAttributeDefined<UIUsageTextBoxAttribute>(pi, out textBoxAttr)) AddTextBox(insPos, pi, textBoxAttr); 
            else if (pi.PropertyType == typeof(string) || pi.PropertyType == typeof(String)) AddStringEditControl(insPos, pi);
            else if (pi.PropertyType == typeof(int) || pi.PropertyType == typeof(int?) || pi.PropertyType == typeof(Int32) || pi.PropertyType == typeof(long) || pi.PropertyType == typeof(Int64) || pi.PropertyType == typeof(short) || pi.PropertyType == typeof(Int16)) AddIntEditControl(insPos, pi);
            else if (pi.PropertyType == typeof(decimal) || pi.PropertyType == typeof(decimal) || pi.PropertyType == typeof(float) || pi.PropertyType == typeof(double) || pi.PropertyType == typeof(Double) || pi.PropertyType == typeof(Decimal)) AddDecimalEditControl(insPos, pi);
            else if (pi.PropertyType == typeof(DateTime) || pi.PropertyType == typeof(DateTime?)) AddDateTimeEditControl(insPos, pi);
            else if (pi.PropertyType == typeof(bool) || pi.PropertyType == typeof(bool) || pi.ReflectedType == typeof(Boolean)) AddBoolEditControl(insPos, pi);
            else if (pi.PropertyType.IsEnum) AddEnumEditControl(insPos, pi);
            else if (pi.PropertyType.IsGenericType) AddCollectionEditControl(insPos, pi);
            else if (pi.PropertyType.Assembly == _userAssembly) AddComplextTypeControl(insPos, pi);
        }

        private void AddTextBox(ControlInsertionPosition insPos, PropertyInfo pi, UIUsageTextBoxAttribute textBoxAttr)
        {
            
            XmlDocument controlXamlFragmentDoc = new XmlDocument();
            string ctrlTemplate = PRIMITIVE_TYPES_TEMPLATES[typeof(string)];
            if(textBoxAttr.IsMultiline)
                ctrlTemplate = multilineTemplate;
            controlXamlFragmentDoc.LoadXml(ctrlTemplate);
            XmlNode sourceBucket = controlXamlFragmentDoc.DocumentElement;
            List<XmlNode> targetNodes = new List<XmlNode>();
            XmlNode textBoxNode = null;
            foreach (XmlNode currSrc in sourceBucket.ChildNodes)
            {
                XmlNode curr = insPos.RelNode.OwnerDocument.ImportNode(currSrc, true);
                ApplyConditionalVisibilityAttribute(curr, pi);
                XSDReflectionUtil.WriteAttribute(curr, "xmlns", insPos.RelNode.OwnerDocument.DocumentElement.NamespaceURI);
                ReplacePlaceholderTexts(curr, pi);
                if (curr.Name == "TextBox")
                    textBoxNode = curr;
                targetNodes.Add(curr);
            }

            if (textBoxNode != null)
            {
                if (!string.IsNullOrEmpty(textBoxAttr.MaxWidth))
                    XSDReflectionUtil.WriteAttribute(textBoxNode, "MaxWidth", textBoxAttr.MaxWidth);

                if (!string.IsNullOrEmpty(textBoxAttr.MinWidth))
                    XSDReflectionUtil.WriteAttribute(textBoxNode, "MinWidth", textBoxAttr.MinWidth);

                if (!string.IsNullOrEmpty(textBoxAttr.HorizontalAlignment))
                    XSDReflectionUtil.WriteAttribute(textBoxNode, "HorizontalAlignment", textBoxAttr.HorizontalAlignment);
                
                if (!string.IsNullOrEmpty(textBoxAttr.StringFormat))
                {
                    string textAttrValue = textBoxNode.Attributes["Text"].Value;

                    int lastFigParPos = textAttrValue.LastIndexOf('}');
                    if (lastFigParPos != -1)
                    {
                        string newTextAttrValue = textAttrValue.Substring(0, lastFigParPos) + string.Format(", StringFormat={0} }}", textBoxAttr.StringFormat);
                        textBoxNode.Attributes["Text"].Value = newTextAttrValue;
                    }
                }
            }
            InsertNode(insPos, targetNodes.ToArray(), pi);
        }

        private void AddComboAddBtn(ControlInsertionPosition insPos, PropertyInfo pi, UIUsageComboAddButtonAttribute comboAddBtnAttr)
        {
            //<ComboBox ToolTip="" ItemsSource="{Binding Source={x:Static bgud:CountryInfo.AllCountries}, Mode=OneWay, diag:PresentationTraceSources.TraceLevel=High}" SelectedItem="{Binding Path=OperationCountry, Mode=TwoWay, diag:PresentationTraceSources.TraceLevel=High}" DisplayMemberPath="CountryNameUkr" HorizontalAlignment="Stretch" />
            XmlDocument controlXamlFragmentDoc = new XmlDocument();
            controlXamlFragmentDoc.LoadXml(comboAddBtnTemplate);
            XmlNode sourceBucket = controlXamlFragmentDoc.DocumentElement;


            XmlNode currSrc = sourceBucket.FirstChild;
            XmlNode curr = insPos.RelNode.OwnerDocument.ImportNode(currSrc, true);
            ApplyConditionalVisibilityAttribute(curr, pi);
            ApplyOrientation(curr, comboAddBtnAttr.ContainerOrientation);
            XSDReflectionUtil.WriteAttribute(curr, "xmlns", insPos.RelNode.OwnerDocument.DocumentElement.NamespaceURI);
            ReplacePlaceholderTexts(curr, pi);
            ReplacePlaceholderAttrRecursively(curr, templatedComboDisplayMemberPlaceholder, comboAddBtnAttr.DisplayMember);
            ReplacePlaceholderAttrRecursively(curr, templatedComboBtnAddCommandPlaceholder, comboAddBtnAttr.AddNewItemCommand);
            if (!string.IsNullOrEmpty(comboAddBtnAttr.ItemGetterFull))
            {
                ReplacePlaceholderAttrRecursively(curr, templatedComboItemsGetterPlaceholder, comboAddBtnAttr.ItemGetterFull);
            }
            else if (comboAddBtnAttr.ItemsGetterClass != null && !string.IsNullOrEmpty(comboAddBtnAttr.ItemsGetterMemberPath))
            {
                if (!_bguNS2XamlPfxs.ContainsKey(comboAddBtnAttr.ItemsGetterClass.Namespace))
                    throw new ApplicationException(String.Format("No namespace prefix defined for the namespace '{0}'", comboAddBtnAttr.ItemsGetterClass.Namespace));
                string itemsGetter = string.Format("{0}:{1}.{2}", _bguNS2XamlPfxs[comboAddBtnAttr.ItemsGetterClass.Namespace], comboAddBtnAttr.ItemsGetterClass.Name, comboAddBtnAttr.ItemsGetterMemberPath);
                ReplacePlaceholderAttrRecursively(curr, templatedComboItemsGetterPlaceholder, itemsGetter);
                AddTemplateDataTypeNS(insPos.RelNode.OwnerDocument.DocumentElement, comboAddBtnAttr.ItemsGetterClass);
            }
            XmlNode comboNode = curr.ChildNodes[1].FirstChild;
            if (comboAddBtnAttr.ValueMemberUsageMode == ComboUIValueUsageMode.ValueProperty)
            {
                XSDReflectionUtil.WriteAttribute(comboNode, "SelectedValuePath", comboAddBtnAttr.ValueMember);
                XSDReflectionUtil.WriteAttribute(comboNode, "SelectedValue", string.Format("{{Binding Path={0}, Mode=TwoWay, diag:PresentationTraceSources.TraceLevel=High}}", pi.Name));
            }
            else if (comboAddBtnAttr.ValueMemberUsageMode == ComboUIValueUsageMode.SelectedItem)
            {
                XSDReflectionUtil.WriteAttribute(comboNode, "SelectedItem", string.Format("{{Binding Path={0}, Mode=TwoWay, diag:PresentationTraceSources.TraceLevel=High}}", pi.Name));
            }

            if (!string.IsNullOrEmpty(comboAddBtnAttr.Width))
                XSDReflectionUtil.WriteAttribute(comboNode, "Width", comboAddBtnAttr.Width);

            if (!string.IsNullOrEmpty(comboAddBtnAttr.ToolTipMember))
                AddItemToolTipComboBinding(comboNode, comboAddBtnAttr.ToolTipMember);


            InsertNode(insPos, curr, pi);
        }

        //private bool IsUIComboAddButtonUsageDefined(PropertyInfo pi, out UIUsageComboAddButtonAttribute comboAddBtnAttr)
        //{
        //    attr = ReflectionUtil.GetPropertyOrTypeAttribute<UIUsageComboAttribute>(pi);
        //    if (attr != null)
        //        return true;
        //    return false;
        //}

        private bool IsPropOrTypeAttributeDefined<T>(PropertyInfo pi, out T attr) where T : System.Attribute
        {
            attr = ReflectionUtil.GetPropertyOrTypeAttribute<T>(pi);
            if (attr != null)
                return true;
            return false;
        }

        //private bool IsUIComboUsageDefined(PropertyInfo pi, out UIUsageComboAttribute attr)
        //{
        //    attr = ReflectionUtil.GetPropertyOrTypeAttribute<UIUsageComboAttribute>(pi);
        //    if (attr != null)
        //        return true;
        //    return false;
        //}

        private void AddCombo(ControlInsertionPosition insPos, PropertyInfo pi, UIUsageComboAttribute comboAttr)
        {
            //<ComboBox ToolTip="" ItemsSource="{Binding Source={x:Static bgud:CountryInfo.AllCountries}, Mode=OneWay, diag:PresentationTraceSources.TraceLevel=High}" SelectedItem="{Binding Path=OperationCountry, Mode=TwoWay, diag:PresentationTraceSources.TraceLevel=High}" DisplayMemberPath="CountryNameUkr" HorizontalAlignment="Stretch" />
            XmlDocument controlXamlFragmentDoc = new XmlDocument();
            controlXamlFragmentDoc.LoadXml(comboTemplate);
            XmlNode sourceBucket = controlXamlFragmentDoc.DocumentElement;

            //foreach (XmlNode currSrc in sourceBucket.ChildNodes)
            //{

            XmlNode currSrc = sourceBucket.FirstChild;
            XmlNode curr = insPos.RelNode.OwnerDocument.ImportNode(currSrc, true);
            ApplyConditionalVisibilityAttribute(curr, pi);
            ApplyOrientation(curr, comboAttr.ContainerOrientation);
            XSDReflectionUtil.WriteAttribute(curr, "xmlns", insPos.RelNode.OwnerDocument.DocumentElement.NamespaceURI);
            ReplacePlaceholderTexts(curr, pi);
            ReplacePlaceholderAttrRecursively(curr, templatedComboDisplayMemberPlaceholder, comboAttr.DisplayMember);
            if (comboAttr.ItemsGetterClass != null && !string.IsNullOrEmpty(comboAttr.ItemsGetterMemberPath))
            {
                if(!_bguNS2XamlPfxs.ContainsKey(comboAttr.ItemsGetterClass.Namespace))
                    throw new ApplicationException(String.Format("No namespace prefix defined for the namespace '{0}'", comboAttr.ItemsGetterClass.Namespace));
                string itemsGetter = string.Format("{0}:{1}.{2}", _bguNS2XamlPfxs[comboAttr.ItemsGetterClass.Namespace], comboAttr.ItemsGetterClass.Name, comboAttr.ItemsGetterMemberPath);
                ReplacePlaceholderAttrRecursively(curr, templatedComboItemsGetterPlaceholder, itemsGetter);
                AddTemplateDataTypeNS(insPos.RelNode.OwnerDocument.DocumentElement, comboAttr.ItemsGetterClass);
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
            if (!string.IsNullOrEmpty(comboAttr.ToolTipMember))
                AddItemToolTipComboBinding(comboNode, comboAttr.ToolTipMember);



            InsertNode(insPos, curr, pi);
        }

        private void ApplyOrientation(XmlNode curr, Orientation orientation)
        {
            XSDReflectionUtil.WriteAttribute(curr, "Orientation", orientation.ToString());
        }

        private void AddItemToolTipComboBinding(XmlNode comboNode, string toolTipMember)
        {
            XmlDocument tooltipDoc = new XmlDocument();
            tooltipDoc.LoadXml(comboItemTooltipTemplate);
            XmlNode curr = comboNode.OwnerDocument.ImportNode(tooltipDoc.DocumentElement.FirstChild, true);
            ReplacePlaceholderAttrRecursively(curr, templatedComboItemToolTipPropertyNamePlaceholder, toolTipMember);
            comboNode.InsertAfter(curr, comboNode.LastChild);
        }

        private void ApplyConditionalVisibilityAttribute(XmlNode curr, PropertyInfo pi)
        {
            UIConditionalVisibilityAttribute attr = ReflectionUtil.GetPropertyOrTypeAttribute<UIConditionalVisibilityAttribute>(pi);
            if (attr == null || string.IsNullOrEmpty(attr.VisibilityMemberPath))
                return;
            //Visibility="{Binding Path=IsSupervisoryCouncilPresent , Converter={StaticResource bool2Vis}}"
            XSDReflectionUtil.WriteAttribute(curr, "Visibility", string.Format("{{Binding Path={0}, Converter={{StaticResource bool2Vis}}}}", attr.VisibilityMemberPath));
        }

        private void AddCollectionEditControl(ControlInsertionPosition insPos, PropertyInfo pi)
        {
            XmlDocument controlXamlFragmentDoc = new XmlDocument();
            controlXamlFragmentDoc.LoadXml(listOfTTemplate);
            XmlNode sourceBucket = controlXamlFragmentDoc.DocumentElement;
            XmlNode expanderNode = null;
            List<XmlNode> targetNodes = new List<XmlNode>();
            foreach (XmlNode currSrc in sourceBucket.ChildNodes)
            {
                XmlNode curr = insPos.RelNode.OwnerDocument.ImportNode(currSrc, true);
                XSDReflectionUtil.WriteAttribute(curr, "xmlns", insPos.RelNode.OwnerDocument.DocumentElement.NamespaceURI);
                ApplyConditionalVisibilityAttribute(curr, pi);
                ReplacePlaceholderTexts(curr, pi);

                targetNodes.Add(curr);
                
                if (curr.Name == "Expander")
                    expanderNode = curr;
            }
            InsertNode(insPos, targetNodes.ToArray(), pi);

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
                    UIUsageDataGridParamsAttribute dgpAttr = ReflectionUtil.GetPropertyOrTypeAttribute<UIUsageDataGridParamsAttribute>(pi);
                    if (dgpAttr == null || !dgpAttr.IsOneColumn)
                    {
                        List<PropertyInfo> pis = ReflectionUtil.ListEditableProperties(itemTyp);
                        foreach (PropertyInfo ppi in pis)
                        {
                            XmlDocument currColDefDoc = new XmlDocument();
                            currColDefDoc.LoadXml(listOfT_DataColumnTemplate);
                            XmlNode colDefSrc = currColDefDoc.DocumentElement.FirstChild;
                            ReplacePlaceholderTexts(colDefSrc, ppi, itemTyp, true);
                            XmlNode currColDef = insPos.RelNode.OwnerDocument.ImportNode(colDefSrc, true);
                            dgColDefsNode.InsertAfter(currColDef, dgColDefsNode.LastChild);
                        }
                    }
                    else
                    {
                        XmlDocument currColDefDoc = new XmlDocument();
                        currColDefDoc.LoadXml(listOfT_OneColumnDataTemplate);
                        XmlNode colDefSrc = currColDefDoc.DocumentElement.FirstChild;
                        ReplacePlaceholderTexts(colDefSrc, pi, itemTyp, true);
                        string oneColHeader = dgpAttr.OneDataColumnHeader;
                        if(string.IsNullOrEmpty(oneColHeader))
                        {
                            DisplayNameAttribute dispAttr = ReflectionUtil.GetPropertyOrTypeAttribute<DisplayNameAttribute>(pi);
                            if(dispAttr != null && !string.IsNullOrEmpty(dispAttr.DisplayName))
                                oneColHeader = dispAttr.DisplayName;
                        }

                        if(string.IsNullOrEmpty(oneColHeader))
                        {
                            DescriptionAttribute dispAttr = ReflectionUtil.GetPropertyOrTypeAttribute<DescriptionAttribute>(pi);
                            if (dispAttr != null && !string.IsNullOrEmpty(dispAttr.Description))
                                oneColHeader = dispAttr.Description;
                        }
                        if(string.IsNullOrEmpty(oneColHeader))
                            oneColHeader = pi.Name;
                        ReplacePlaceholderAttrRecursively(colDefSrc, templatedDataGridOneColumnHeaderPlaceholder, oneColHeader);
                        XmlNode currColDef = insPos.RelNode.OwnerDocument.ImportNode(colDefSrc, true);
                        dgColDefsNode.InsertAfter(currColDef, dgColDefsNode.LastChild);

                    }
                    #region Insert action buttons column
                    {
                        XmlDocument currColDefDoc = new XmlDocument();
                        currColDefDoc.LoadXml(listOfT_CMDsColumnTemplate);
                        XmlNode colDefSrc = currColDefDoc.DocumentElement.FirstChild;
                        ReplacePlaceholderTexts(colDefSrc, pi, itemTyp, true);
                        XmlNode currColDef = insPos.RelNode.OwnerDocument.ImportNode(colDefSrc, true);
                        dgColDefsNode.InsertAfter(currColDef, dgColDefsNode.LastChild);
                    }
                    #endregion
                }

                if (!_referencedTypes.Contains(itemTyp))
                    _referencedTypes.Add(itemTyp);

            }
        }

        private void AddComplextTypeControl(ControlInsertionPosition insPos, PropertyInfo pi)
        {

            UIPartialFieldsVisibilityAttribute partFldsVisAttr = ReflectionUtil.GetPropertyOrTypeAttribute<UIPartialFieldsVisibilityAttribute>(pi);


            XmlDocument controlXamlFragmentDoc = new XmlDocument();
            XamlExpanderWrappingAttribute wrapAttr = ReflectionUtil.GetPropertyOrTypeAttribute<XamlExpanderWrappingAttribute>(pi);
            string controlTemplate = null;
            if (wrapAttr == null || wrapAttr.WrapIntoExpander)
            {
                controlTemplate = classStructControlTemplate;
            }
            else
                controlTemplate = classStructNoExpanderWrapControlTemplate;
            controlXamlFragmentDoc.LoadXml(controlTemplate);
            XmlNode sourceBucket = controlXamlFragmentDoc.DocumentElement;
            XmlNode contentControlNode = null;
            List<XmlNode> targetNodes = new List<XmlNode>();
            foreach (XmlNode currSrc in sourceBucket.ChildNodes)
            {
                XmlNode curr = insPos.RelNode.OwnerDocument.ImportNode(currSrc, true);
                XSDReflectionUtil.WriteAttribute(curr, "xmlns", insPos.RelNode.OwnerDocument.DocumentElement.NamespaceURI);
                ApplyConditionalVisibilityAttribute(curr, pi);
                ReplacePlaceholderTexts(curr, pi);
                if(curr.Name == "Expander")
                    contentControlNode = curr.FirstChild;
                targetNodes.Add(curr);
            }
            if (partFldsVisAttr != null && contentControlNode != null)
            {
                IXAMLGenerator gen = XAMLGeneratorFactory.Instance.SpawnInstance();
                gen.GenerateInlineTemplateOnly = true;
                gen.InlineTemplateParams = partFldsVisAttr;
                XmlDocument inlineTempl = gen.Generate(pi.PropertyType, pi.PropertyType.Assembly, _referencedControlTemplateNames);
                XmlNode dataTemplateNodeSrc = inlineTempl.DocumentElement.FirstChild.NextSibling;
                dataTemplateNodeSrc.Attributes.Remove(dataTemplateNodeSrc.Attributes["DataType"]);
                XmlNode dataTemplTarget = contentControlNode.OwnerDocument.ImportNode(dataTemplateNodeSrc, true);
                XmlNode contentTemplateNode = contentControlNode.OwnerDocument.CreateNode(XmlNodeType.Element, "ContentControl.ContentTemplate", contentControlNode.OwnerDocument.DocumentElement.NamespaceURI);
                contentTemplateNode.InsertAfter(dataTemplTarget, contentTemplateNode.LastChild);
                contentTemplateNode.Attributes.Remove(contentTemplateNode.Attributes["xmlns"]);
                contentControlNode.InsertAfter(contentTemplateNode, contentControlNode.LastChild);
            }

            InsertNode(insPos, targetNodes.ToArray(), pi);

            if (!_referencedTypes.Contains(pi.PropertyType))
                _referencedTypes.Add(pi.PropertyType);
        }

        private void AddPrimitiveEditControl(ControlInsertionPosition insPos, PropertyInfo pi)
        {
            throw new NotImplementedException();
        }

        private void AddEnumEditControl(ControlInsertionPosition insPos, PropertyInfo pi)
        {
            UIUsageRadioButtonGroupAttribute rbgAttr = ReflectionUtil.GetPropertyOrTypeAttribute<UIUsageRadioButtonGroupAttribute>(pi);
            if (rbgAttr == null)
                AddEnumEditComboControl(insPos, pi);
            else
                AddEnumEditRadioButtonGroupControl(insPos, pi, rbgAttr);
        }

        private void AddEnumEditRadioButtonGroupControl(ControlInsertionPosition insPos, PropertyInfo pi, UIUsageRadioButtonGroupAttribute rbgAttr)
        {
            XmlDocument controlXamlFragmentDoc = new XmlDocument();
            controlXamlFragmentDoc.LoadXml(enumRadioButtonGroupTemplate);
            XmlNode sourceBucket = controlXamlFragmentDoc.DocumentElement;

            XmlNode stackPanelNode = insPos.RelNode.OwnerDocument.ImportNode(sourceBucket.FirstChild, true);
            XSDReflectionUtil.WriteAttribute(stackPanelNode, "xmlns", insPos.RelNode.OwnerDocument.DocumentElement.NamespaceURI);
            ApplyConditionalVisibilityAttribute(stackPanelNode, pi);
            ReplacePlaceholderTexts(stackPanelNode, pi);
            XSDReflectionUtil.WriteAttribute(stackPanelNode, "Orientation", rbgAttr.GroupOrientation.ToString());
            InsertNode(insPos, stackPanelNode, pi);

            List<EnumType> ds = EnumType.GetEnumList(pi.PropertyType, false);
            foreach (EnumType entry in ds)
            {
                if (entry.EnumValue.ToString() == "None" && !rbgAttr.ShowNoneItem)
                    continue;
                XmlDocument currRBDefDoc = new XmlDocument();
                currRBDefDoc.LoadXml(enumRadioButtonTemplate);
                XmlNode rbDefSrc = currRBDefDoc.DocumentElement.FirstChild;
                ReplacePlaceholderTexts(rbDefSrc, pi);
                ReplacePlaceholderAttrRecursively(rbDefSrc, templatedEnumCurrentValueDescriptionPlaceholder, entry.Value);
                ReplacePlaceholderAttrRecursively(rbDefSrc, templatedEnumCurrentValueTextPlaceholder, entry.EnumValue.ToString());
                XmlNode currRBDef = insPos.RelNode.OwnerDocument.ImportNode(rbDefSrc, true);
                stackPanelNode.InsertAfter(currRBDef, stackPanelNode.LastChild);
            }
        }

        private void AddEnumEditComboControl(ControlInsertionPosition insPos, PropertyInfo pi)
        {
            XmlDocument controlXamlFragmentDoc = new XmlDocument();
            controlXamlFragmentDoc.LoadXml(PRIMITIVE_TYPES_TEMPLATES[typeof(Enum)]);
            XmlNode sourceBucket = controlXamlFragmentDoc.DocumentElement;
            List<XmlNode> targetNodes = new List<XmlNode>();
            foreach (XmlNode currSrc in sourceBucket.ChildNodes)
            {
                XmlNode curr = insPos.RelNode.OwnerDocument.ImportNode(currSrc, true);
                XSDReflectionUtil.WriteAttribute(curr, "xmlns", insPos.RelNode.OwnerDocument.DocumentElement.NamespaceURI);
                ApplyConditionalVisibilityAttribute(curr, pi);
                ReplacePlaceholderTexts(curr, pi);
                ReplacePlaceholderAttrRecursively(curr, templatedEnumListerPlaceholder, string.Format("{0}List", pi.PropertyType.Name));

                targetNodes.Add(curr);
            }
            InsertNode(insPos, targetNodes.ToArray(), pi);


            if (!_referencedTypes.Contains(pi.PropertyType))
                _referencedTypes.Add(pi.PropertyType);
        }

        private void AddBoolEditControl(ControlInsertionPosition insPos, PropertyInfo pi)
        {
            AddEditControlWorker(insPos, pi, typeof(bool));
        }

        private void AddDateTimeEditControl(ControlInsertionPosition insPos, PropertyInfo pi)
        {
            AddEditControlWorker(insPos, pi, typeof(DateTime));
        }

        private void AddDecimalEditControl(ControlInsertionPosition insPos, PropertyInfo pi)
        {
            AddEditControlWorker(insPos, pi, typeof(decimal));
        }

        private void AddIntEditControl(ControlInsertionPosition insPos, PropertyInfo pi)
        {
            AddEditControlWorker(insPos, pi, typeof(int));
        }

        private void AddStringEditControl(ControlInsertionPosition insPos, PropertyInfo pi)
        {
            bool isMultiline = Attribute.IsDefined(pi, typeof(MultilineAttribute));

            if(!isMultiline)
                AddEditControlWorker(insPos, pi, typeof(string));
            else
                AddEditControlWorker(insPos, pi, typeof(string), multilineTemplate);
        }

        private void AddEditControlWorker(ControlInsertionPosition insPos, PropertyInfo pi, Type ctrlTyp)
        {
            AddEditControlWorker(insPos, pi, ctrlTyp, PRIMITIVE_TYPES_TEMPLATES[ctrlTyp]);
        }


        private void AddEditControlWorker(ControlInsertionPosition insPos, PropertyInfo pi, Type ctrlTyp, string controlXamlTemplate)
        {
            XmlDocument controlXamlFragmentDoc = new XmlDocument();
            controlXamlFragmentDoc.LoadXml(controlXamlTemplate);
            XmlNode sourceBucket = controlXamlFragmentDoc.DocumentElement;
            List<XmlNode> targetNodes = new List<XmlNode>();
            foreach (XmlNode currSrc in sourceBucket.ChildNodes)
            {
                XmlNode curr = insPos.RelNode.OwnerDocument.ImportNode(currSrc, true);
                ApplyConditionalVisibilityAttribute(curr, pi);
                XSDReflectionUtil.WriteAttribute(curr, "xmlns", insPos.RelNode.OwnerDocument.DocumentElement.NamespaceURI);
                ReplacePlaceholderTexts(curr, pi);
                targetNodes.Add(curr);
            }
            InsertNode(insPos, targetNodes.ToArray(), pi);
         
        }


        private void InsertNode(ControlInsertionPosition pos, XmlNode subj, PropertyInfo pi)
        {
            InsertNode(pos, new XmlNode[] { subj }, pi);
        }
        private void InsertNode(ControlInsertionPosition pos, XmlNode[] subj, PropertyInfo pi)
        {
            log.Debug("InsertNode: pi.Name = '{0}', this._rootType.FullName = '{1}'", pi.Name, this._rootType.FullName);
            if (_propertyNodes.ContainsKey(pi.Name))
                throw new ApplicationException(string.Format("InsertNode: Duplicate property control insert attempt: {0} ({1})", pi.Name, this._rootType.FullName));
            _propertyNodes.Add(pi.Name, new ResultantControlNodesRange(){ First = subj[0], Last = subj[subj.Length-1] });
            switch (pos.ChildRel)
            {
                case InsertChildRelLocType.FirstChild:
                    {
                        switch (pos.BeforeOrAfter)
                        {
                            case InsertRelLocType.Before:
                                {
                                    pos.RelNode.InsertBefore(subj[0], pos.RelNode.FirstChild);
                                    if(subj.Length > 1)
                                    {
                                        for(int i = 1;i<subj.Length; i++)
                                            pos.RelNode.InsertAfter(subj[i],subj[0]);
                                    }

                                }
                                break;
                            case InsertRelLocType.After:
                                {
                                    pos.RelNode.InsertAfter(subj[0], pos.RelNode.FirstChild);
                                    if(subj.Length > 1)
                                    {
                                        for(int i = 1;i<subj.Length; i++)
                                            pos.RelNode.InsertAfter(subj[i],subj[0]);
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case InsertChildRelLocType.LastChild:
                    {
                        switch (pos.BeforeOrAfter)
                        {
                            case InsertRelLocType.Before:
                                {
                                    pos.RelNode.InsertBefore(subj[0], pos.RelNode.LastChild);
                                    if(subj.Length > 1)
                                    {
                                        for(int i = 1;i<subj.Length; i++)
                                            pos.RelNode.InsertAfter(subj[i],subj[0]);
                                    }
                                }
                                break;
                            case InsertRelLocType.After:
                                {
                                    pos.RelNode.InsertAfter(subj[0], pos.RelNode.LastChild);
                                    if(subj.Length > 1)
                                    {
                                        for(int i = 1;i<subj.Length; i++)
                                            pos.RelNode.InsertAfter(subj[i],subj[0]);
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case InsertChildRelLocType.NodeItself:
                    {
                        switch (pos.BeforeOrAfter)
                        {
                            case InsertRelLocType.Before:
                                {
                                    pos.RelNode.ParentNode.InsertBefore(subj[0], pos.RelNode);
                                    if(subj.Length > 1)
                                    {
                                        for(int i = 1;i<subj.Length; i++)
                                            pos.RelNode.ParentNode.InsertAfter(subj[i],subj[0]);
                                    }
                                }
                                break;
                            case InsertRelLocType.After:
                                {
                                    pos.RelNode.ParentNode.InsertAfter(subj[0], pos.RelNode);
                                    if(subj.Length > 1)
                                    {
                                        for(int i = 1;i<subj.Length; i++)
                                            pos.RelNode.ParentNode.InsertAfter(subj[i],subj[0]);
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                default:
                    break;
            }
        }




        private void AddControlByTypeEditor(ControlInsertionPosition insPos, string p)
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

        private class ControlInsertionPosition
        {
            internal InsertRelLocType BeforeOrAfter { get; set; }
            internal InsertChildRelLocType ChildRel { get; set; }
            internal XmlNode RelNode { get; set; }
        }

        private enum InsertRelLocType
        { 
            Before,
            After
        }

        private enum InsertChildRelLocType
        { 
            FirstChild,
            LastChild,
            NodeItself
        }

        private class ResultantControlNodesRange
        {
            internal XmlNode First { get; set; }
            internal XmlNode Last { get; set; }
        }

    }
}
