using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Dict
{
    /// <summary>
    /// Інформація про навчальний заклад (університет, коледж, тощо) професійної, вищої чи неповної вищої освіти
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.UniversityOrCollegeInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class UniversityOrCollegeInfo
    {
        /// <summary>
        /// Обов'язкове поле
        /// </summary>
        [DisplayName("Назва ВНЗ")]
        [Description("Назва вищого навчального закладу оригінальною мовою")]
        [Required]
        public string UniversityName { get; set; }
        /// <summary>
        /// Обов'язкове, якщо ВНЗ - не український, відповідно, 
        /// назва оригінальна потребує перекладу/транслітерації українською.
        /// </summary>
        [DisplayName("Назва ВНЗ (українською)")]
        [Description("Назва вищого навчального закладу оригінальною мовою українською (якщо оригінальна мова інша")]
        public string UniversityNameUkr { get; set; }
        /// <summary>
        /// Хоча б місто й країна
        /// </summary>
        [DisplayName("Адреса ВНЗ")]
        [Required]
        public LocationInfo Address { get; set; }
        /// <summary>
        /// Не певен, чи десь існують ці ідентифікатори - 
        /// у нас їх немає, але можуть запровадити.
        /// Необов'зкове поле; заповнювати, якщо ідентифікатор існує.
        /// </summary>
        [DisplayName("Ідентифікатор ВНЗ")]
        [Description("Ідентифікатор ВНЗ - якщо є/передбачений")]
        public string UniversityID { get; set; }
    }
}
