using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.CharterCapitalTableRecord_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class CharterCapitalTableRecord
    {
        public GenericPersonID Shareholder { get; set; }
        public int ActualSharesPlaced { get; set; }
        public decimal CharterCapitalPct { get; set; }
        public string PaidDocNr { get; set; }
        public DateTime PaidDate { get; set; }
    }
}
