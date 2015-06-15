using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Дата та номер запису про проведення державної реєстрації фізичної особи-підприємця
    /// </summary>
    public class LPRegisteredDateRecordId
    {
        /// <summary>
        /// Дата 
        /// </summary>
        [DisplayName("Дата запису")]
        [Description("Дата запису про проведення державної реєстрації фізичної особи-підприємця")]
        public DateTime RegisteredDate { get; set; }

        /// <summary>
        /// № запису
        /// </summary>
        [DisplayName("Номер запису")]
        [Description("Номер запису про проведення державної реєстрації фізичної особи-підприємця")]
        public string RegistryRecordId { get; set; }

    }
}
