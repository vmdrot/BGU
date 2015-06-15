using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Practices.Unity;
using BGU.DRPL.SignificantOwnership.Core.Interfaces;
using BGU.DRPL.SignificantOwnership.UI.Modules;
using BGU.DRPL.SignificantOwnership.Core.TypeEditors;

namespace BGU.DRPL.SignificantOwnership.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (IUnityContainer cont = new UnityContainer())
            {
                //loading UI
                IModule module = null;
                System.Configuration.Configuration cfg = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);
                System.Configuration.KeyValueConfigurationElement keyVal = cfg.AppSettings.Settings["moduleTypeSpec"];
                if (keyVal != null && !string.IsNullOrEmpty(keyVal.Value))
                    module = (IModule)Activator.CreateInstance(Type.GetType(keyVal.Value));
                if (module == null)
                    module = new BasicUIModule();
                module.Initialize(cont);
                TypeEditorsDispatcher.Container = cont;
                Application.Run(new MainForm());
            }
        }
    }
}
