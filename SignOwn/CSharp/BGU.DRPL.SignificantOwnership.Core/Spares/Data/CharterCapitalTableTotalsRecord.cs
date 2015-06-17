using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{

    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.CharterCapitalTableTotalsRecord_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class CharterCapitalTableTotalsRecord
    {
        public int ActualSharesPlaced { get; set; }
        public decimal CharterCapitalPct { get; set; }
    }
}
