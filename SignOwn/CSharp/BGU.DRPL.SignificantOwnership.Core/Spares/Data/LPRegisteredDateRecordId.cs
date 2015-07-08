using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Дата та номер запису про проведення державної реєстрації фізичної особи-підприємця
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.LPRegisteredDateRecordId_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class LPRegisteredDateRecordId
    {

        public LPRegisteredDateRecordId()
        {
            RegisteredDate = DateTime.Now;
        }
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
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MaxWidth = "400", MinWidth = "250")]
        public string RegistryRecordId { get; set; }

    }
}
