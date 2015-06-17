using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Причина відсутності відомостей
    /// </summary>
    public class MissingInformationResonInfo
    {
        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Назва поля")]
        public string PropertyName { get; set; }
        [DisplayName("Причина відсутності інформації/неможливості її надати")]
        public string ReasonWhyMissing { get; set; }
    }
}
