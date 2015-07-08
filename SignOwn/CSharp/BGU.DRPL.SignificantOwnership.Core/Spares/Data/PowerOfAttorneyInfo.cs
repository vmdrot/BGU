using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Evolvex.Utility.Core.ComponentModelEx;
using System.ComponentModel;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Реквізити довіреності
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.PowerOfAttorneyInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class PowerOfAttorneyInfo
    {
        public PowerOfAttorneyInfo()
        {
            ValidSince = DateTime.Now;
        }


        [DisplayName("Довірена особа")]
        [Description("Кому видано довіреність")]
        [Required]
        public GenericPersonID ActingPerson { get; set; }

        [DisplayName("Від імені")]
        [Description("Особа, яку представляють (від імені якої діє довірена особа)")]
        [Required]
        public GenericPersonID OnBehalfOfPerson { get; set; }

        [DisplayName("Назва/титул довіреності")]
        [Description("Короткий зміст предмету довіреності")]
        [Required]
        public string Title { get; set; }

        [DisplayName("Дійсна з")]
        [Description("Дата початку дії довіреності")]
        [Required]
        public DateTime ValidSince { get; set; }

        [DisplayName("Дійсна до")]
        [Description("Дата закінчення дії довіреності")]
        public DateTime? ValidThru { get; set; }
        
        [DisplayName("Інші відомості")]
        [Description("Додаткові (значущі) відомості про довіреність")]
        [Multiline]
        public string OtherInfo { get; set; }
    }
}
