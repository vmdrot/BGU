using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;

namespace BGU.DRPL.SignificantOwnership.Core.Interfaces
{
    public interface IModule
    {
        void Initialize(IUnityContainer cont);
    }
}
