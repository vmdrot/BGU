using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Інформація про підписанта (документу, анкети)
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.SignatoryInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class SignatoryInfo
    {
        /// <summary>
        /// обов'язкове
        /// </summary>
        [DisplayName("Посада (підписанта)")]
        [Description("Посада (підписанта)")]
        [Required]
        public string SignatoryPosition { get; set; }
        /// <summary>
        /// обов'язкове
        /// </summary>
        [DisplayName("Прізвище й ініціали (підписанта)")]
        [Description("Прізвище й ініціали (підписанта)")]
        [Required]
        public string SurnameInitials { get; set; }
        /// <summary>
        /// Обов'язкове (якщо тільки контекстом не передбачено інше)
        /// </summary>
        [DisplayName("Дата підпису")]
        [Description("Дата підпису")]
        [Required]
        public DateTime DateSigned { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}, {2}", SignatoryPosition, SurnameInitials, DateSigned);
        }
    }
}
