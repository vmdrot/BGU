using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.GenericPersonIDShare_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class GenericPersonIDShare
    {
        [DisplayName("Власник")]
        [Description("Власник")]
        [Required]
        public GenericPersonID Person { get; set; }
        [DisplayName("Частка")]
        [Description("Частка власності (%)")]
        [Required]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MaxWidth = "100", StringFormat = "{}{0:N2}")]
        public decimal Share { get; set; }
        public override string ToString()
        {
            return string.Format("{0} {1}", Person, Share );
        }
    }
}
