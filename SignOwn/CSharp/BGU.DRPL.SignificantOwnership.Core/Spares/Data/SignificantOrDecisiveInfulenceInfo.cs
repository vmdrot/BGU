using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.SignificantOrDecisiveInfulenceInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class SignificantOrDecisiveInfulenceInfo
    {
        public InfluenceType TypeOfInfluence { get; set; }
        [Multiline]
        public string InfluenceCircumstances { get; set; }
    }
}
