using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    [Obsolete]
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.PhysicalPersonShareInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class PhysicalPersonShareInfo
    {
        [DisplayName("Фіз.особа")]
        [Description("Фіз.особа")]
        public PhysicalPersonInfo Person { get; set; }
        [DisplayName("Часта, %")]
        [Description("Часта, %")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MaxWidth = "100", StringFormat = "{}{0:N4}")]
        public decimal SharePct { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}%", Person, SharePct);
        }
    }
}
