using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Інформація про ліквідовану юр.особу
    /// </summary>
    public class LiquidatedOrInsolventEntityInfoBase
    {
        /// <summary>
        /// Ідентифікатор, обов'язкове
        /// </summary>
        [DisplayName("Ліквідована юрособа")]
        [Required]
        public GenericPersonID Asset { get; set; }

        /// <summary>
        /// Юр.особу ліквідовано, чи вона збанкрутіла/неплатоспроможна
        /// </summary>
        [DisplayName("Статус (ліквідації чи банкрутства)")]
        [Required]
        public InsolvencyStatus Status { get; set; }
        /// <summary>
        /// обов'язкове
        /// </summary>
        [DisplayName("Дата набуття статусу (ліквідації чи банкрутства)")]
        [Required]
        public DateTime DateEffective { get; set; }
        /// <summary>
        /// обов'язкове
        /// </summary>
        [DisplayName("Причина ліквідації/банкрутства")]
        [Required]
        public string LiquidationReason { get; set; }
        /// <summary>
        /// обов'язкове; мається на увазі, документ, рішення, розпорядження, закон, тощо (конкретний...)
        /// </summary>
        [DisplayName("Підстава ліквідації/банкрутства")]
        [Required]
        public string LiquidationPretext { get; set; }
    }
}
