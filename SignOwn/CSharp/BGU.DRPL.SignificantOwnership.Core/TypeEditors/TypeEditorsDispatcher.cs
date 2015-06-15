using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using BGU.DRPL.SignificantOwnership.Core.Questionnaires;

namespace BGU.DRPL.SignificantOwnership.Core.TypeEditors
{
    public class TypeEditorsDispatcher
    {
        private static IUnityContainer _cont;
        public static IUnityContainer Container
        {
            get 
            {
                return _cont;
            }
            set 
            {
                _cont = value;
            }
        }

        public static IQuestionnaire LastQuestionnaire { get; set; }
    }
}
