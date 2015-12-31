using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Evolvex.Utility.Core.ComponentModelEx;
using System.ComponentModel;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Інформація про підписанта (документу, анкети)
    /// - базовий тип
    /// </summary>
    public class SignatoryInfoBase
    {
        /// <summary>
        /// Обов'язкове (якщо тільки контекстом не передбачено інше)
        /// </summary>
        [DisplayName("Дата підпису")]
        [Description("Дата підпису")]
        [Required]
        public DateTime? DateSigned { get; set; }
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
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MaxWidth = "350", MinWidth = "250")]
        public string SurnameInitials { get; set; }
        }
}
