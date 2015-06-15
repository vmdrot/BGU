using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Dict
{
    /// <summary>
    /// Ліцензійна організація
    /// (напр. проф.комісія, що надає ліцензії для заняття 
    /// тим чи іншим видом професійної діяльності, чи ж видає сертифікат - галузевий чи професійний)
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.ProfessionLicensingBodyInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class ProfessionLicensingBodyInfo
    {
        /// <summary>
        /// Назва оригінальною мовою
        /// </summary>
        [DisplayName("Назва ліцензіатора")]
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Назва українською (якщо нерезидент)
        /// </summary>
        [DisplayName("Назва ліцензіатора(укр.)")]
        public string NameUkr { get; set; }
        /// <summary>
        /// обов'язкові поля: Назва(-и), Адреса, країна резидентності
        /// </summary>
        [DisplayName("Реквізити юрособи (ліцензіатора)")]
        [Required]
        public LegalPersonInfo LegalPerson { get; set; }
    }
}
