using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;

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
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline=false, MinWidth="150", MaxWidth="350", StringFormat="{}{0:N2}")]
        public decimal ImplicitPct { get; set; }
        
        [DisplayName("Сукупна участь, %")]
        [Description("")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "150", MaxWidth = "100", StringFormat = "{}{0:N2}")]
        public decimal TotalPct { get; set; }
    }
}
