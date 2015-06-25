using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Інформація про ліцензію на зайняття професійною діяльністю
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.ProfessionLicenseInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class ProfessionLicenseInfo
    {
        public ProfessionLicenseInfo()
        {
            this.LicenseQualifications = new List<LicenseQualificationInfo>();
        }

        /// <summary>
        /// хто надав/екзаменував ліцензію
        /// обов'язкове
        /// </summary>
        [DisplayName("Ліцензор")]
        [Required]
        public ProfessionLicensingBodyInfo LicenseIssuer { get; set; }
        /// <summary>
        /// обов'язкове
        /// </summary>
        [DisplayName("Дата видачі")]
        [Required]
        public DateTime LicenseIssueDate { get; set; }
        /// <summary>
        /// якщо не вказана - дійсна довічно
        /// </summary>
        [DisplayName("Дійсна до")]
        public DateTime LicenseValidTill { get; set; }
        /// <summary>
        /// якщо передбачено
        /// </summary>
        [DisplayName("№ ліцензії")]
        public string LicenseIDNr { get; set; }
        [DisplayName("Кваліфікації/види діяльності за ліцензією")]
        [Required]
        public List<LicenseQualificationInfo> LicenseQualifications { get; set; }
        /// <summary>
        /// Якщо недостатньо поля LicenseQualifications
        /// </summary>
        [DisplayName("Формулювання/текст ліцензії")]
        [Description("Додаткові суттєві відомості про ліцензію")]
        [Multiline]
        public string LicenseClause { get; set; }
    }
}
