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
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.CommonOwnershipInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class CommonOwnershipInfo
    {
        public CommonOwnershipInfo()
        {
            Partners = new List<GenericPersonID>();
        }
        [DisplayName("Об'єкт власності")]
        [Description("Юр.особа, чия власність розкривається")]
        public GenericPersonID Property { get; set; }
        [DisplayName("Співвласники")]
        [Description("Перелік співвласників")]
        public List<GenericPersonID> Partners { get; set; }
        [DisplayName("Тип спільної власності")]
        [Description("Тип спільної власності (згідно періку)")]
        public OwnershipType OwnershipType { get; set; }
        [DisplayName("Підстава володіння")]
        [Description("На підставі (якщо релевантно), напр. довіреності, тощо")]
        [Multiline]
        public string OwnershipTestimony { get; set; }
        [DisplayName("Частка власності, %")]
        public decimal OwnershipPct { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", Property.HashID, Partners[0].HashID, OwnershipType, OwnershipPct);
        }
    }
}
