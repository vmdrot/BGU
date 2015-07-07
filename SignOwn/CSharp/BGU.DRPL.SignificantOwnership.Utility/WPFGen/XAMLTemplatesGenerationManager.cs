using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using System.Xml;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Utility.WPFGen
{
    public class XAMLTemplatesGenerationManager
    {
        public static readonly List<Type> PRIMITIVE_TYPES;
        private static StringBuilder _log;

        private static readonly string AUTO_GEN_TEMPL_NAME_FMT = "{0}_AutoGenTemplate.xaml";
        

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

        //public static List<Type> ListMissingGridTypesToStrings(Type rootType, Assembly userAsmbly)
        //{
        //    List<Type> rslt = new List<Type>();
        //    ProcessType4Lists(rootType, userAsmbly, rslt);
        //    return rslt;
        //}

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

        //private static void ProcessType4Lists(Type typ, Assembly userAssembly, List<Type> target)
        //{
        //    if (typ.Assembly == userAssembly && typ.IsClass && !typ.IsEnum)
        //    {
        //        if(!target.Contains(typ))
        //            target.Add(typ);
        //        PropertyInfo[] props = typ.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.SetProperty);
        //        foreach (PropertyInfo pi in props)
        //        {
        //            ProcessType(pi.PropertyType, userAssembly, target);
        //        }
        //    }
        //    else if (typ.IsGenericType)
        //    {
        //        Type[] gtyps = typ.GetGenericArguments();
        //        foreach (Type gt in gtyps)
        //            ProcessType(gt, userAssembly, target);
        //    }
                        
        //            if (!target.Contains(typ))
        //                CheckAddIfNoString(gtyp, target);
        //}

        public static void GenerateXAMLTemplates(Type rootType, Assembly userAsmbly, string targetFolder)
        {
            List<Type> queue = ListUserTypesToGenerateTemplatesFor(rootType, userAsmbly);
            Dictionary<Type, string> controlTemplateNames = new Dictionary<Type, string>();
            foreach (Type typ in queue)
            {
                string templFname = null;
                XamlTemplateNameAttribute xtna = ReflectionUtil.GetTypeAttribute<XamlTemplateNameAttribute>(typ);

                if (xtna != null)
                    templFname = xtna.TemplateFileName;
                else
                    templFname = GenerateTemplateFilName(typ);
                controlTemplateNames.Add(typ, templFname);
            }
            foreach(Type typ in queue)
            {
                IXAMLGenerator generator = XAMLGeneratorFactory.Instance.SpawnInstance();
                generator.GenerateAndSave(typ, userAsmbly, controlTemplateNames, GenerateTemplateFilePath(typ, targetFolder));
            }

            StringBuilder includes = new StringBuilder();
            //todo - take into account increasing presence of non-auto-generated templates
            foreach (Type typ in queue)
            {
                includes.AppendLine(string.Format("<ResourceDictionary Source=\"pack://application:,,,/WpfApplication2;component/Resources/{0}\" />", GenerateTemplateFilName(typ)));
            }
            File.WriteAllText(Path.Combine(targetFolder, string.Format("{0}_includes.xaml", rootType.Name)), includes.ToString());
        }

        public static string GenerateTemplateFilName(Type typ)
        {
            return string.Format(AUTO_GEN_TEMPL_NAME_FMT, typ.Name);
        }

        public static string GenerateTemplateFilePath(Type typ,string targetFolder)
        {
            return Path.Combine(targetFolder, GenerateTemplateFilName(typ));
        }
    }
}
