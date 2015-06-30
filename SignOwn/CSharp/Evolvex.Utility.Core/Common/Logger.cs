using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolvex.Utility.Core.Common
{
    public class Logger : ILog
    {
        private String _name;
        public Logger(String name)
        {
            _name = name;
        }
        #region ILog Members

        public void Debug(string message, params object[] args)
        {
            NLog.Logger lgr = Logging.GetNLogger(_name);
            if (lgr != null)
                lgr.Debug(message, args);
        }

        public void Debug(string message)
        {
            NLog.Logger lgr = Logging.GetNLogger(_name);
            if (lgr != null)
                lgr.Debug(message);
        }

        public void Error(string message, params object[] args)
        {
            NLog.Logger lgr = Logging.GetNLogger(_name);
            if (lgr != null)
                lgr.Error(message, args);
        }

        public void Error(string message)
        {
            NLog.Logger lgr = Logging.GetNLogger(_name);
            if (lgr != null)
                lgr.Error(message);
        }

        public void Fatal(string message, params object[] args)
        {
            NLog.Logger lgr = Logging.GetNLogger(_name);
            if (lgr != null)
                lgr.Fatal(message, args);
        }

        public void Fatal(string message)
        {
            NLog.Logger lgr = Logging.GetNLogger(_name);
            if (lgr != null)
                lgr.Fatal(message);
        }

        public void Info(string message, params object[] args)
        {
            NLog.Logger lgr = Logging.GetNLogger(_name);
            if (lgr != null)
                lgr.Info(message, args);
        }

        public void Info(string message)
        {
            NLog.Logger lgr = Logging.GetNLogger(_name);
            if (lgr != null)
                lgr.Info(message);
        }

        public void Warn(string message)
        {
            NLog.Logger lgr = Logging.GetNLogger(_name);
            if (lgr != null)
                lgr.Warn(message);
        }

        public void Warn(string message, params object[] args)
        {
            NLog.Logger lgr = Logging.GetNLogger(_name);
            if (lgr != null)
                lgr.Warn(message, args);
        }

        #endregion
    }
}
