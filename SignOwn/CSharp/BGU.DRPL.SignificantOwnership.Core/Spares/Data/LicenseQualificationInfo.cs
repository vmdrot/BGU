using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Інформація про професійну діяльність, що ліцензується
    /// </summary>
    /// <seealso cref="http://kodeksy.com.ua/buh/kp.htm"/>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.LicenseQualificationInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class LicenseQualificationInfo
    {
        /// <summary>
        /// Якщо існує
        /// </summary>
        [DisplayName("Код професії/діяльності (якщо існує)")]
        [Description("Код професії згідно відповідного класифікатору/довідника професій (напр.http://kodeksy.com.ua/buh/kp.htm)")]
        public string QualificationCode { get; set; }
        /// <summary>
        /// обов'язкове
        /// </summary>
        [DisplayName("Назва професії/діяльності")]
        [Description("Назва професії/виду ліцензованої діяльності згідно відповідного класифікатору/довідника професій (напр.http://kodeksy.com.ua/buh/kp.htm)")]
        [Required]
        public string QualificationName { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", QualificationCode, QualificationName);
        }
    }
}
