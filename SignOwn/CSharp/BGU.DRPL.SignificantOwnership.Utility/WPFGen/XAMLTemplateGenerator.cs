using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace BGU.DRPL.SignificantOwnership.Utility.WPFGen
{
    public class XAMLTemplateGenerator
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

        static XAMLTemplateGenerator()
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

    }
}
