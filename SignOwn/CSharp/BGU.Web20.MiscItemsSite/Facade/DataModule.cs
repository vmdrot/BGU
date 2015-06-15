using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using BGU.DRPL.SignificantOwnership.Utility;
using System.IO;
using System.Reflection;

namespace BGU.Web20.MiscItemsSite.Facade
{
    public class DataModule
    {
        private static DataTable _RcuKru;
        public static DataTable RcuKru
        {
            get
            {
                if(_RcuKru == null)
                {
                    string rcuKruPath = ConfigurationManager.AppSettings.Get("rcuKruPath");
                    if (!Path.IsPathRooted(rcuKruPath))
                    {
                        string dllDir = Path.GetDirectoryName(Assembly.GetCallingAssembly().CodeBase).Replace("file:\\",string.Empty);
                        rcuKruPath = Path.Combine(dllDir, rcuKruPath);
                    }
                    _RcuKru = RcuKruReader.Read(rcuKruPath);
                }
                return _RcuKru;
            }
        }

    }
}