using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.TotalOwnershipSummaryInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class TotalOwnershipSummaryInfo
    {
        [DisplayName("Пряма участь")]
        [Description("")]
        public OwnershipSummaryInfo DirectOwnershipSummary { get; set; }

        [DisplayName("Опосередкована участь (%)")]
        [Description("")]
        public decimal ImplicitPct { get; set; }
        
        [DisplayName("Сукупна участь, %")]
        [Description("")]
        public decimal TotalPct { get; set; }
    }
}
