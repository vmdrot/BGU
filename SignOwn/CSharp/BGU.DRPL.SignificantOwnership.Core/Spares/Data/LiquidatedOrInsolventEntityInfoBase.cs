using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;
using BGU.DRPL.SignificantOwnership.Utility;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Інформація про ліквідовану юр.особу
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.LiquidatedOrInsolventEntityInfoBase_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class LiquidatedOrInsolventEntityInfoBase
    {
        /// <summary>
        /// Ідентифікатор, обов'язкове
        /// </summary>
        [DisplayName("Ліквідована юрособа")]
        [Required]
        public GenericPersonID Asset { get; set; }

        [DisplayName("Суд")]
        [Description("Суд на розгляді/у провадженні якого перебуває справа, чи котрий виніс рішення")]
        [Required]
        public CourtInfo Court { get; set; }

        [DisplayName("Справа №")]
        [Description("№ справи про банкрутство/ліквідацію юр.особи (з реєстру судових рішень)")]
        public string CaseNr { get; set; }
        
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
        [Multiline]
        public string LiquidationReason { get; set; }

        /// <summary>
        /// обов'язкове; мається на увазі, документ, рішення, розпорядження, закон, тощо (конкретний...)
        /// </summary>
        [DisplayName("Підстава ліквідації/банкрутства")]
        [Required]
        [Multiline]
        public string LiquidationPretext { get; set; }


        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}", Asset, Court, EnumType.GetEnumDescription(Status), DateEffective);
        }

    }
}
