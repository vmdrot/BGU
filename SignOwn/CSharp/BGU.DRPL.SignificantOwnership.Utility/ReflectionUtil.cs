using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;
using System.Xml.Serialization;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Utility
{
    public class ReflectionUtil
    {
        private static readonly List<Type> PRIMITIVE_TYPES;
        private static StringBuilder _log;
        private static void LogMsg(string msg)
        {
            _log.AppendLine(msg);
        }

        private static void LogFormat(string format , params object[] args)
        {
            _log.AppendLine(string.Format(format, args));
        }

        public static string Log { get { return _log.ToString(); } }

        public static void ClearLog()
        {
            _log = new StringBuilder();
        }

        static ReflectionUtil()
        {
            _log = new StringBuilder();
            PRIMITIVE_TYPES = new List<Type>();
            PRIMITIVE_TYPES.Add(typeof(bool));
            PRIMITIVE_TYPES.Add(typeof(int));
            PRIMITIVE_TYPES.Add(typeof(decimal));
            PRIMITIVE_TYPES.Add(typeof(string));
            PRIMITIVE_TYPES.Add(typeof(double));
            PRIMITIVE_TYPES.Add(typeof(DateTime));
            PRIMITIVE_TYPES.Add(typeof(Enum));
        }

        public static Dictionary<Type, int> ListPrimitiveTypesDistinct(Type rootType, Assembly userAsmbly, out List<Type> nonRecognizedTypes)
        {
            Dictionary<Type, int> rslt = new Dictionary<Type, int>();
            nonRecognizedTypes = new List<Type>();
            UnwindPropsTypes(rootType, userAsmbly, rslt, nonRecognizedTypes);
            return rslt;
        }

        private static void UnwindPropsTypes(Type typ, Assembly userAssembly, Dictionary<Type, int> target, List<Type> nonRecognizedTypes)
        {
            PropertyInfo[] props  = typ.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.SetProperty);
            foreach(PropertyInfo pi in props)
            {
                ProcessType(pi.PropertyType, userAssembly, target, nonRecognizedTypes);
            }
        }

        private static void ProcessType(Type typ, Assembly userAssembly, Dictionary<Type, int> target, List<Type> nonRecognizedTypes)
        {
            LogFormat("Processing type {0}", typ.FullName);

            if (typ.Assembly == userAssembly)
            {
                if (typ.IsEnum)
                {
                    ProcessType(typeof(Enum), userAssembly, target, nonRecognizedTypes);
                }
                else
                {
                    LogFormat("Type is user-defined, further unwinding: {0}", typ.FullName);
                    UnwindPropsTypes(typ, userAssembly, target, nonRecognizedTypes);
                    return;
                }
            }
            else
            {
                if (PRIMITIVE_TYPES.Contains(typ))
                {
                    LogFormat("Type is primitive: {0}", typ.FullName);
                    if (target.ContainsKey(typ))
                    {
                        target[typ]++;
                        return;
                    }
                    target.Add(typ,1);
                }
                else if (typ.IsGenericType)
                {
                    LogFormat("Type is generic: {0}", typ.FullName);
                    Type[] genTypes = typ.GetGenericArguments();
                    foreach (Type gt in genTypes)
                    {
                        ProcessType(gt, userAssembly, target, nonRecognizedTypes);
                    }
                }
                else
                {
                    LogFormat("Type is not recognized: {0}", typ.FullName);
                    if (nonRecognizedTypes.Contains(typ))
                        return;
                    nonRecognizedTypes.Add(typ);
                }
            }

        }

        public static void InstantiateAllProps(object obj, Assembly userAssembly)
        { 
            PropertyInfo[] pis = obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.SetProperty | BindingFlags.Public);

            foreach (PropertyInfo pi in pis)
            {
                if (pi.GetValue(obj, null) != null)
                    continue;
                if (pi.PropertyType == typeof(DateTime))
                    pi.SetValue(obj, DateTime.Now, null);
                if (pi.PropertyType.IsPrimitive || pi.PropertyType.IsEnum)
                    continue;

                if (!pi.PropertyType.IsGenericType && pi.PropertyType.Assembly != userAssembly)
                    continue;
                if (!pi.CanWrite)
                    continue;

                object currChild = null;
                if (pi.PropertyType.IsGenericType)
                    currChild = InstantiateListOfT(pi.PropertyType);
                else
                {
                    currChild = InstantiateObject(pi.PropertyType);
                    InstantiateAllProps(currChild, userAssembly);
                }
                pi.SetValue(obj, currChild,null);
                
            }
        }

        private static object InstantiateListOfT(Type typ)
        {
            return Activator.CreateInstance(typ);
        }

        public static object InstantiateObject(Type objType)
        {
            ConstructorInfo cctor = objType.GetConstructor(new Type[] { });
            if (cctor == null)
                return null;
            return cctor.Invoke(null);
        }

        public static List<PropertyInfo> ListEditableProperties(Type typ)
        {
            List<PropertyInfo> rslt = new List<PropertyInfo>();
            PropertyInfo[] props = typ.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty | BindingFlags.GetProperty);
            foreach (PropertyInfo pi in props)
            {
                if (!CheckIsBrowsable(pi) || CheckIsXmlIgnore(pi) || (pi.CanRead && !pi.CanWrite))
                    continue;
                rslt.Add(pi);
            }
            return rslt;
        }

        public static bool CheckIsBrowsable(PropertyInfo pi)
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

        public static bool CheckIsXmlIgnore(PropertyInfo pi)
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

        public static T GetTypeAttribute<T>(Type subject) where T : Attribute
        {

            if (Attribute.IsDefined(subject, typeof(T)))
            {
                object[] attrs = subject.GetCustomAttributes(typeof(T), true);
                if (attrs == null || attrs.Length == 0)
                    return null;
                return (T)attrs[0];
            }

            return null;
        }


        public static T GetPropertyOrTypeAttribute<T>(PropertyInfo pi) where T: Attribute
        {

            if (Attribute.IsDefined(pi, typeof(T)))
            {
                Attribute attr = Attribute.GetCustomAttribute((MemberInfo)pi, typeof(T));
                if (attr is T)
                {
                    return (T)attr;
                }
            }
            else
                return GetTypeAttribute<T>(pi.PropertyType);

            return null;
        }
    }
}
