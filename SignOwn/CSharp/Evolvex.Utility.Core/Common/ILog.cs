using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolvex.Utility.Core.Common
{
    public interface ILog
    {
        void Debug(string message, params object[] args);
        void Debug(string message);
        void Error(string message, params object[] args);
        void Error(string message);
        void Fatal(string message, params object[] args);
        void Fatal(string message);
        void Info(string message, params object[] args);
        void Info(string message);
        void Warn(string message);
        void Warn(string message, params object[] args);
    }
}
