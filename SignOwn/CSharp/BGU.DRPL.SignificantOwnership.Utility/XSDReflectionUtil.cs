using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;
using System.Xml;
using System.IO;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Utility
{
    public class XSDReflectionUtil
    {
        private static readonly string AssemblyName = "BGU.DRPL.SignificantOwnership.Core";
        public static readonly string[] SearchNamespaces = new string[] { "BGU.DRPL.SignificantOwnership.Core.Questionnaires", "BGU.DRPL.SignificantOwnership.Core.Spares.Data", "BGU.DRPL.SignificantOwnership.Core.Spares.Dict", "BGU.DRPL.SignificantOwnership.Core.Spares" };

        public static Dictionary<string, PropDispDescr> FetchPropDispsDescrs(Type typ)
        {
            Dictionary<string, PropDispDescr> rslt = new Dictionary<string,PropDispDescr>();
            
            System.ComponentModel.PropertyDescriptorCollection pdc = System.ComponentModel.TypeDescriptor.GetProperties(typ);
            foreach (PropertyDescriptor pd in pdc)
            {
                string dispName = Tools.GetPropDisplayName(pd);
                string descr = Tools.GetPropDescription(pd);
                string cat = Tools.GetPropCategory(pd);
                if (string.IsNullOrEmpty(dispName) && string.IsNullOrEmpty(descr))
                    continue;
                //if (string.IsNullOrEmpty(descr) && !string.IsNullOrEmpty(dispName))
                //    descr = dispName;
                rslt.Add(pd.Name, new PropDispDescr() { Description = descr, DisplayName = dispName, Category = cat });
            }
            return rslt;
        }

        public static List<string> GetXSDComplexTypes(XmlDocument doc)
        {
            XmlNodeList nodes = doc.DocumentElement.FirstChild.SelectNodes("//xs:complexType");
            List<string> rslt = new List<string>();
            foreach (XmlNode node in nodes)
            {
                string typeName = node.Attributes["name"].Value;
                if (string.IsNullOrEmpty(typeName) || rslt.Contains(typeName))
                    continue;
                rslt.Add(typeName);
             }
            return rslt; 
        }

        public static List<string> GetXSDEnums(XmlDocument doc)
        {
            XmlNodeList nodes = doc.SelectNodes("//xs:simpleType");
            List<string> rslt = new List<string>();
            foreach (XmlNode node in nodes)
            {
                string typeName = node.Attributes["name"].Value;
                if (string.IsNullOrEmpty(typeName) || rslt.Contains(typeName))
                    continue;
                rslt.Add(typeName);
            }
            return rslt;
        }

        public static void ProcessXSD(string xsdPath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xsdPath);
        }

        public static XmlDocument LoadAnnotationXml(Assembly asbmly)
        {
            string dir = Path.GetDirectoryName(asbmly.CodeBase).Replace("file:\\",string.Empty);;
            string fnm = Path.GetFileNameWithoutExtension(asbmly.CodeBase);
            string xmlPath = Path.Combine(dir, string.Format("{0}.xml", fnm));
            if (!File.Exists(xmlPath))
                return null;
            XmlDocument rslt = new XmlDocument();
            rslt.Load(xmlPath);
            return rslt;
        }


        #region inner type(s)

        public class PropDispDescr
        {
            public string DisplayName { get; set; }
            public string Description { get; set; }
            public string Category { get; set; }
        }
        #endregion
        public static void InjectDispProps(XmlDocument doc)
        {
            InjectDispProps(doc, null);
        }
        public static void InjectDispProps(XmlDocument doc, Dictionary<string, bool> alreadyProcessedTypes)
        {
            InjectDispProps(doc, alreadyProcessedTypes, null);
        }

        public static void InjectDispProps(XmlDocument doc, Dictionary<string,bool> alreadyProcessedTypes, XmlDocument assemblySummariesXml)
        {
            InjectDispProps(doc, alreadyProcessedTypes, assemblySummariesXml, false, null);
        }

        public static void InjectDispProps(XmlDocument doc, Dictionary<string, bool> alreadyProcessedTypes, XmlDocument assemblySummariesXml, bool xsdPutDispNmDescrIntoAnnotation)
        {
            InjectDispProps(doc, alreadyProcessedTypes, assemblySummariesXml, xsdPutDispNmDescrIntoAnnotation, null);
        }

        public static void InjectDispProps(XmlDocument doc, Dictionary<string, bool> alreadyProcessedTypes, XmlDocument assemblySummariesXml, bool xsdPutDispNmDescrIntoAnnotation, Type specificType)
        {
            List<XmlNode> toBeDel = new List<XmlNode>();
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                string currTypeShortName = node.Attributes["name"].Value;
                if (node.Name == "xs:complexType")
                {
                    if (specificType != null)
                    {
                        if (specificType.Name == currTypeShortName)
                            ProcessClass(node, assemblySummariesXml, xsdPutDispNmDescrIntoAnnotation);
                        else
                            toBeDel.Add(node);
                    }
                    else if (specificType == null)
                    {
                        if( alreadyProcessedTypes != null && alreadyProcessedTypes.ContainsKey(node.Attributes["name"].Value))
                            toBeDel.Add(node);
                        //node.ParentNode.RemoveChild(node);//doc.RemoveChild(node);
                        //doc.DocumentElement.RemoveChild(node);
                        else
                        {
                            ProcessClass(node, assemblySummariesXml, xsdPutDispNmDescrIntoAnnotation);
                            if (alreadyProcessedTypes != null)
                                alreadyProcessedTypes.Add(currTypeShortName, true);
                        }
                    }
                }
                else if (node.Name == "xs:simpleType")
                {
                    if (specificType != null)
                    {
                        if (specificType.Name == currTypeShortName)
                            ProcessEnum(node, assemblySummariesXml, xsdPutDispNmDescrIntoAnnotation);
                        else
                            toBeDel.Add(node);//node.ParentNode.RemoveChild(node);//doc.RemoveChild(node);

                    }
                    else if (specificType == null)
                    {
                        if (alreadyProcessedTypes != null && alreadyProcessedTypes.ContainsKey(node.Attributes["name"].Value))
                            toBeDel.Add(node);//node.ParentNode.RemoveChild(node);//doc.RemoveChild(node);
                        else
                        {
                            ProcessEnum(node, assemblySummariesXml, xsdPutDispNmDescrIntoAnnotation);
                            if (alreadyProcessedTypes != null)
                                alreadyProcessedTypes.Add(currTypeShortName, true);
                        }
                    }
                }
            }
            List<string> includesList = new List<string>();
            for (int i = 0; i < toBeDel.Count; i++)
            {
                string currNm = toBeDel[i].Attributes["name"].Value;
                if (!string.IsNullOrEmpty(currNm))
                {
                    if (!includesList.Contains(currNm))
                        includesList.Add(currNm);
                }
                doc.DocumentElement.RemoveChild(toBeDel[i]);
            }
            foreach(string typNm in includesList)
            {
                XmlNode inclNode = doc.CreateNode(XmlNodeType.Element, "xs:include", doc.DocumentElement.Attributes["xmlns:xs"].Value);
                WriteAttribute(inclNode, "schemaLocation", string.Format("{0}.uk-UA.xsd",typNm));
                doc.DocumentElement.AppendChild(inclNode);
            }

        }

        public static string GetSummaryFromAssemblyXmlForAType(XmlDocument doc, Type typ)
        {
            XmlNode node = doc.SelectSingleNode(string.Format("/doc/members/member[@name='T:{0}']/summary", typ.FullName));
            if (node == null)
                return null;
            return node.InnerText;
        }

        public static string GetSummaryFromAssemblyXmlForATypeProperty(XmlDocument doc, Type typ, string propName)
        {
            XmlNode node = doc.SelectSingleNode(string.Format("/doc/members/member[@name='P:{0}.{1}']/summary", typ.FullName, propName));
            if (node == null)
                return null;
            return node.InnerText;
        }

        private static string GetSeeAlsoCref(XmlDocument doc, string xPath)
        { 
            XmlNode node = doc.SelectSingleNode(xPath);
            if (node == null)
                return null;
            string cref = node.Attributes["cref"].Value;
            if(cref.IndexOf("!:")==0)
                cref = cref.Substring(2);
            return cref;
        }
        public static string GetSeeAlsoFromAssemblyXmlForAType(XmlDocument doc, Type typ)
        {
            return GetSeeAlsoCref(doc, string.Format("/doc/members/member[@name='T:{0}']/seealso", typ.FullName));
        }

        public static string GetSeeAlsoFromAssemblyXmlForATypeProperty(XmlDocument doc, Type typ, string propName)
        {
            return GetSeeAlsoCref(doc, string.Format("/doc/members/member[@name='P:{0}.{1}']/seealso", typ.FullName, propName));
        }

        private static void FindAddAnnotation(XmlNode target, Type typ, XmlDocument asmblyDoc)
        {
            StringBuilder sbComment = new StringBuilder();
            if (Attribute.GetCustomAttribute(typ, typeof(ObsoleteAttribute)) != null)
                sbComment.AppendLine("Увага! Цей тип було помічено як такий, що не використовується/застарів (Obsolete)!");
            string comment = GetSummaryFromAssemblyXmlForAType(asmblyDoc, typ);
            if (!string.IsNullOrEmpty(comment))
                sbComment.AppendLine(comment);
            comment = sbComment.ToString();
            string seeAlso = GetSeeAlsoFromAssemblyXmlForAType(asmblyDoc, typ);
            if (string.IsNullOrEmpty(comment) && string.IsNullOrEmpty(seeAlso))
                return;
            AddAnnotation(target, comment,seeAlso);
        }

        private static void FindAddAnnotation(XmlNode target, Type typ, string prop, XmlDocument asmblyDoc, string extraClause2Put)
        {
            StringBuilder sbComment = new StringBuilder();
            
            PropertyInfo pi = typ.GetProperty(prop);
            RequiredAttribute reqAttr = ReflectionUtil.GetPropertyAttribute<RequiredAttribute>(pi);
            if (reqAttr != null)
            {

                if (string.IsNullOrEmpty(reqAttr.Condition))
                {
                    target.Attributes["minOccurs"].Value = "1";
                    sbComment.AppendLine("ОБОВ'ЯЗКОВЕ ПОЛЕ!");
                }
                else
                {
                    sbComment.AppendLine(string.Format("(!)ПОЛЕ ОБОВ'ЯЗКОВЕ ЗА УМОВИ(!):\n   {0}", reqAttr.Condition));
                }
            }

            ObsoleteAttribute obsoleteAttr = ReflectionUtil.GetPropertyOrTypeAttribute<ObsoleteAttribute>(pi);
            if (obsoleteAttr != null)
                sbComment.AppendLine("Увага! Це поле було помічено як таке, що не використовується/застаріло (Obsolete)!");
            if (!string.IsNullOrEmpty(extraClause2Put))
                sbComment.AppendLine(extraClause2Put);
            string comment = GetSummaryFromAssemblyXmlForATypeProperty(asmblyDoc, typ, prop);
            if (!string.IsNullOrEmpty(comment))
                sbComment.AppendLine(comment);
            comment = sbComment.ToString();
            string seeAlso = GetSeeAlsoFromAssemblyXmlForATypeProperty(asmblyDoc, typ,prop);
            if (string.IsNullOrEmpty(comment) && string.IsNullOrEmpty(seeAlso))
                return;
            if (string.IsNullOrEmpty(comment) && string.IsNullOrEmpty(seeAlso))
                return;
            AddAnnotation(target, comment, seeAlso);
        }

        private static void AddAnnotation(XmlNode target, string comment, string seeAlso)
        {
            if (string.IsNullOrEmpty(comment) && string.IsNullOrEmpty(seeAlso))
                return;
            if (target == null)
                return;
            XmlNode annotNode = target.OwnerDocument.CreateNode(XmlNodeType.Element, "xs:annotation", target.OwnerDocument.DocumentElement.Attributes["xmlns:xs"].Value);
            XmlNode docNode = target.OwnerDocument.CreateNode(XmlNodeType.Element, "xs:documentation", target.OwnerDocument.DocumentElement.Attributes["xmlns:xs"].Value);
            StringBuilder sbInnerTxt = new StringBuilder();
            int i = 0;
            if(!string.IsNullOrEmpty(comment))
            {
                sbInnerTxt.Append(comment); i++;
            }

            if (!string.IsNullOrEmpty(seeAlso))
            {
                if (i > 0)
                    sbInnerTxt.AppendLine();
                sbInnerTxt.AppendFormat("Див.також: {0}", seeAlso); i++;
            }

            docNode.InnerText = sbInnerTxt.ToString().Trim();
            
            annotNode.AppendChild(docNode);
            if (target.ChildNodes == null || target.ChildNodes.Count == 0)
                target.AppendChild(annotNode);
            else
                target.InsertBefore(annotNode, target.ChildNodes[0]);
        }

        private static void ProcessEnum(XmlNode node, XmlDocument assemblySummariesXml, bool xsdPutDispNmDescrIntoAnnotation)
        {
            string typNm = node.Attributes["name"].Value;
            Type typ = FindType(typNm);
            if (typ == null)
                return;

            XmlNode seqNode = FindRestrictionChild(node);
            if (seqNode == null)
                return;
            if(assemblySummariesXml != null)
                FindAddAnnotation(node, typ, assemblySummariesXml);
            List<EnumType> enmTyps = EnumType.GetEnumList(typ, false);
            Dictionary<string, string> enms2Descrs = new Dictionary<string, string>();
            Dictionary<string, string> enms2Vals = new Dictionary<string, string>();

            foreach (EnumType enmTyp in enmTyps)
            {
                if (!enms2Descrs.ContainsKey(enmTyp.EnumValue.ToString()))
                    enms2Descrs.Add(enmTyp.EnumValue.ToString(), enmTyp.Value);

                if (!enms2Vals.ContainsKey(enmTyp.EnumValue.ToString()))
                    enms2Vals.Add(enmTyp.EnumValue.ToString(), enmTyp.Key);
            }
            XmlNodeList propNodes = seqNode.ChildNodes;
            foreach (XmlNode propNode in propNodes)
            {
                if (propNode.Name != "xs:enumeration")
                    continue;
                string propNm = propNode.Attributes["value"].Value;

                if (!enms2Descrs.ContainsKey(propNm))
                    continue;
                if (!string.IsNullOrEmpty(enms2Descrs[propNm]))
                {
                    if(xsdPutDispNmDescrIntoAnnotation)
                        AddAnnotation(propNode, string.Format("Підпис до значення/текст у випадаючому списку (для UI): {0}", enms2Descrs[propNm]), string.Empty);
                    else
                        WriteAttribute(propNode, "description", enms2Descrs[propNm]);
                }

                if (!string.IsNullOrEmpty(enms2Vals[propNm]))
                {
                    if (xsdPutDispNmDescrIntoAnnotation)
                        AddAnnotation(propNode, string.Format("Цифрове значення: {0}", enms2Vals[propNm]), string.Empty);
                    else
                        WriteAttribute(propNode, "enum_value", enms2Vals[propNm]);
                }
            }
        }

        private static void ProcessClass(XmlNode node, XmlDocument assemblySummariesXml, bool xsdPutDispNmDescrIntoAnnotation)
        {
            string typNm = node.Attributes["name"].Value;
            Type typ = FindType(typNm);
            if (typ == null)
                return;
            Dictionary<string, PropDispDescr> dispDescrs = FetchPropDispsDescrs(typ);
            XmlNode seqNode = FindSequenseChild(node);
            if (seqNode == null)
                return;
            HideInXSDAttribute bHideFromXSD = ReflectionUtil.GetTypeAttribute<HideInXSDAttribute>(typ);
            if (bHideFromXSD != null)
            { 
                WriteAttribute(node, "hideFromHtml", "true");
            }
            if (assemblySummariesXml != null)
                FindAddAnnotation(node, typ, assemblySummariesXml);
            int i = 0;
            XmlNodeList propNodes = seqNode.ChildNodes;
            foreach (XmlNode propNode in propNodes)
            {
                string propNm = propNode.Attributes["name"].Value;
                //if (!dispDescrs.ContainsKey(propNm))
                //    continue;

                string propTypeNmEng = propNode.Attributes["type"].Value;
                string propTypeNmUkr = TranslateTypeNm(propTypeNmEng);
                string xtraClause = null;
                if (!xsdPutDispNmDescrIntoAnnotation)
                {
                    if (propTypeNmEng != propTypeNmUkr)
                        WriteAttribute(propNode, "type_ukr", propTypeNmUkr);

                    if (dispDescrs.ContainsKey(propNm) && !string.IsNullOrEmpty(dispDescrs[propNm].DisplayName))
                        WriteAttribute(propNode, "displayName", dispDescrs[propNm].DisplayName);
                    if (dispDescrs.ContainsKey(propNm) && !string.IsNullOrEmpty(dispDescrs[propNm].Description))
                        WriteAttribute(propNode, "description", dispDescrs[propNm].Description);
                    if (dispDescrs.ContainsKey(propNm) && !string.IsNullOrEmpty(dispDescrs[propNm].Category))
                        WriteAttribute(propNode, "category", dispDescrs[propNm].Category);
                    i++;
                    WriteAttribute(propNode, "field_order", i.ToString());

                }
                else
                {
                    StringBuilder sbXtraClause = new StringBuilder();
                    if (propTypeNmEng != propTypeNmUkr)
                        sbXtraClause.AppendLine(string.Format("Тип поля (українською): {0}", propTypeNmUkr));
                    if (dispDescrs.ContainsKey(propNm) && !string.IsNullOrEmpty(dispDescrs[propNm].DisplayName))
                        sbXtraClause.AppendLine(string.Format("Підпис до поля (в UI): {0}", dispDescrs[propNm].DisplayName));
                    if (dispDescrs.ContainsKey(propNm) && !string.IsNullOrEmpty(dispDescrs[propNm].Description))
                        sbXtraClause.AppendLine(string.Format("Опис до поля (в UI): {0}", dispDescrs[propNm].Description));
                    if (dispDescrs.ContainsKey(propNm) && !string.IsNullOrEmpty(dispDescrs[propNm].Category))
                        sbXtraClause.AppendLine(string.Format("Об'єднати у категорію (в UI): {0}", dispDescrs[propNm].Category));
                    xtraClause = sbXtraClause.ToString();
                }

                FindAddAnnotation( propNode, typ, propNm, assemblySummariesXml, xtraClause);
            }
        }

        private static string TranslateTypeNm(string propTypeNmEng)
        {
            switch (propTypeNmEng)
            {
                case "xs:string": return "текст";
                case "xs:hexBinary": return "гексадвоїчний";
                case "xs:base64Binary": return "двоїчний у 64-му кодуванні";
                case "xs:anyURI": return "URL";
                case "xs:QName": return "кваліфіковане ім'я";
                case "xs:NOTATION": return "нотація";
                case "xs:normalizedString": return "нормалізований текст";
                case "xs:token": return "токен";
                case "xs:language": return "мова";
                case "xs:NMTOKEN": return "ім'я-токен";
                case "xs:Name": return "ім'я";
                case "xs:NCName": return "ім'я";
                case "xs:ID": return "ідентифікатор";
                case "xs:IDREF": return "посилання на ідентифікатор";
                case "xs:ENTITY": return "сутність";
                case "xs:integer": return "ціле число";
                case "xs:nonPositiveInteger": return "недодатнє ціле число";
                case "xs:negativeInteger": return "від'ємне ціле число";
                case "xs:nonNegativeInteger": return "невід'ємне ціле число";
                case "xs:positiveInteger": return "додатнє ціле число";
                case "xs:long": return "довге ціле число";
                case "xs:int": return "ціле число";
                case "xs:short": return "коротке ціле число";
                case "xs:byte": return "байт";
                case "xs:unsignedLong": return "беззнакове довге ціле";
                case "xs:unsignedInt": return "беззнакове ціле";
                case "xs:unsignedShort": return "беззнакове коротке ціле";
                case "xs:unsignedByte": return "беззнаковий байт";
                case "xs:float": return "число з плаваючою комою";
                case "xs:double": return "подвійне з плаваючою комою";
                case "xs:dateTime": return "дата і час";
                case "xs:date": return "дата";
                case "xs:gYearMonth": return "рік і місяць";
                case "xs:gYear": return "рік";
                case "xs:time": return "час";
                case "xs:gDay": return "день";
                case "xs:gMonth": return "місяць";
                case "xs:gMonthDay": return "місяць і день";
                case "xs:duration": return "тривалість (по часу)";
                case "xs:NMTOKENS": return "масив імен-токенів";
                case "xs:IDREFS": return "масив посилань на ідентифікатори";
                case "xs:ENTITIES": return "масив сутностей";
                case "xs:boolean": return "логічний тип(так/ні)";
                case "xs:decimal": return "десяткове число, у т.ч. дрібне";
                default: break;
            }
            return propTypeNmEng;
        }

        private static XmlNode FindSequenseChild(XmlNode node)
        {
            return FindTagNameChild(node, "xs:sequence");
        }

        private static XmlNode FindRestrictionChild(XmlNode node)
        {
            return FindTagNameChild(node, "xs:restriction");
        }

        private static XmlNode FindTagNameChild(XmlNode node, string tagName)
        {
            XmlNode rslt = node;
            while (rslt != null && rslt.Name != tagName)
            {
                rslt = rslt.FirstChild;
            }
            if (rslt != null && rslt.Name == tagName)
                return rslt;
            return null;
        }

        private static Type FindType(string typNm)
        {
            Type rslt = null;
            foreach (string namespaceNm in SearchNamespaces)
            {
                rslt = Type.GetType(string.Format("{0}.{1}, {2}", namespaceNm, typNm, AssemblyName), false);
                if (rslt != null)
                    break;
            }
            return rslt;
        }
        public static List<Type> ListTypes(Type anyTypeOfAsmbly, string[] lookInNs, BindingFlags flags, bool bClassesOnly)
        {
            List<Type> rslt = new List<Type>();
            Dictionary<string,bool> alreadyAdded = new Dictionary<string,bool>();
            Type[] allTypes = Assembly.GetAssembly(anyTypeOfAsmbly).GetTypes();
            foreach (Type typ in allTypes)
            {
                foreach(string ns in lookInNs)
                {
                    if (typ.FullName.IndexOf(string.Format("{0}.", ns.Trim())) == 0 && !alreadyAdded.ContainsKey(typ.FullName))
                    {
                        if (flags == BindingFlags.Public && !typ.IsPublic)
                            continue;
                        if (bClassesOnly && typ.IsInterface)
                            continue;
                        rslt.Add(typ);
                        alreadyAdded.Add(typ.FullName, true);
                    }
                }
                //string currNs = GetNamespaceFromType(typ);
                //if (string.IsNullOrEmpty(currNs) || !lookInNs.Contains(GetNamespaceFromType(typ)) || alreadyAdded.ContainsKey(typ.FullName))
                //    continue;
                
            }

            return rslt;
        }

        public static string GetNamespaceFromType(Type typ)
        {
            int lastDotPos = typ.FullName.LastIndexOf('.');
            if (lastDotPos == -1)
                return string.Empty;
            return typ.FullName.Substring(0, lastDotPos);
        }

        public static void WriteAttribute(XmlNode node, string attrName, string attrVal)
        {
            XmlAttribute attr = node.OwnerDocument.CreateAttribute(attrName);
            attr.Value = attrVal;
            node.Attributes.SetNamedItem(attr);
        }


        public static string GetNodeAttributeSafe(XmlNode node, string attrNm)
        {
            if (node == null || node.Attributes == null || node.Attributes[attrNm] == null)
                return null;
            return node.Attributes[attrNm].Value;
        }
    }
}
