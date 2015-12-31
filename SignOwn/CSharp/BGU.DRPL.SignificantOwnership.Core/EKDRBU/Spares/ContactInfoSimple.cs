using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.EKDRBU.Spares
{
    public class ContactInfoSimple : ContactInfoBase
    {
        /// <summary>
        /// Необов'язкове поле; якщо заповнюється, то достатньо (як правило) П.І.Б.; як вони хочуть, щоб до них зверталися (хоч би й лише Name),
        /// напр. "Люда, тел. XXX-XXX-XX-XX, e-mail..."
        /// </summary>
        [DisplayName("Контактна особа")]
        [Description("Контактна особа (фізособа)")]
        [Required]
        public new string Person { get; set; }
    }
}
