using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;

namespace Evolvex.Utility.Core.Common
{
    public class Logging
    {
        private static LogFactory _factory;
        private static Dictionary<String, Logger> _loggers;

        static Logging()
        {
            _loggers = new Dictionary<string, Logger>();
        }
        internal static NLog.Logger GetNLogger(String name)
        {
            return Factory.GetLogger(name);
        }

        internal static LogFactory Factory
        {
            get
            {
                if (_factory == null)
                {
                    if (LogManager.Configuration != null && LogManager.Configuration.ConfiguredNamedTargets.Count > 0)
                    {
                        _factory = new LogFactory(LogManager.Configuration);
                    }
                }
                return _factory;
            }
        }

        public static ILog GetLogger(String name)
        {
            if (!_loggers.ContainsKey(name))
            {
                _loggers.Add(name, new Logger(name));
            }
            return _loggers[name];
        }

        public static ILog GetLogger(Type type)
        {
            return GetLogger(type.Name);
        }
    }
}
