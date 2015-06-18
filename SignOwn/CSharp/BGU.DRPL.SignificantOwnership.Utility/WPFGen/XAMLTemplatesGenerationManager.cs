using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace BGU.DRPL.SignificantOwnership.Utility.WPFGen
{
    public class XAMLTemplatesGenerationManager
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

        static XAMLTemplatesGenerationManager()
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

        public static List<Type> ListUserTypesToGenerateTemplatesFor(Type rootType, Assembly userAsmbly)
        {
            List<Type> rslt = new List<Type>();
            ProcessType(rootType, userAsmbly, rslt);
            return rslt;
        }
        private static void ProcessType(Type typ, Assembly userAssembly, List<Type> target)
        {
            LogFormat("Processing type {0}", typ.FullName);

            if (typ.Assembly == userAssembly && typ.IsClass && !typ.IsEnum)
            {
                if(!target.Contains(typ))
                    target.Add(typ);
                PropertyInfo[] props = typ.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.SetProperty);
                foreach (PropertyInfo pi in props)
                {
                    ProcessType(pi.PropertyType, userAssembly, target);
                }
            }
            else if (typ.IsGenericType)
            {
                Type[] gtyps = typ.GetGenericArguments();
                foreach (Type gt in gtyps)
                    ProcessType(gt, userAssembly, target);
            }
        }
    }
}
