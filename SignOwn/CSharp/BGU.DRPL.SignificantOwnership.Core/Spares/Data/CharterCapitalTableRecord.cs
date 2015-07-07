using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.CharterCapitalTableRecord_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class CharterCapitalTableRecord
    {
        public GenericPersonID Shareholder { get; set; }
        public int ActualSharesPlaced { get; set; }
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MaxWidth = "250", StringFormat = "{}{0:N2}")]
        public decimal CharterCapitalPct { get; set; }
        public string PaidDocNr { get; set; }
        public DateTime PaidDate { get; set; }
    }
}
