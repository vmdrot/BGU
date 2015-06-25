using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Структура для зберігання відомостей про досвід роботи
    /// (один "епізод" з трудової біографії)
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.EmploymentRecordInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class EmploymentRecordInfo
    {
        /// <summary>
        /// Обов'язкове поле
        /// Посилання - реквізити в MentionedEntities
        /// </summary>
        [DisplayName("Роботодавець")]
        [Required]
        public GenericPersonID Employer { get; set; }
        /// <summary>
        /// обов'язкове, вільний формат
        /// </summary>
        [DisplayName("Посада/функція")]
        [Required]
        public string JobTitle { get; set; }
        /// <summary>
        /// обов'язкове, з точністю до місяця
        /// </summary>
        [DisplayName("Дата початку роботи")]
        [Required]
        public DateTime DateStarted { get; set; }
        /// <summary>
        /// з точністю до місяця
        /// якщо не заповнене, значить він/вона/воно там ще досі працює
        /// </summary>
        [DisplayName("Дата кінця роботи")]
        public DateTime DateQuit { get; set; }
        /// <summary>
        /// обов'язкове поле
        /// </summary>
        [DisplayName("Тип зайнятості")]
        [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.EnumLookupEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Required]
        public EmploymentState State { get; set; }
        /// <summary>
        /// обов'язкове поле (хіба ще досі там працює)
        /// </summary>
        [DisplayName("Тип закінчення діяльності")]
        [Required]
        public EmploymentTerminationType TerminationType { get; set; }
        /// <summary>
        /// Пояснення обов'язкове для TerminationType типів:
        /// - Dismissed
        /// - OtherLeaveType
        /// - VoluntaryQuit
        /// </summary>
        [DisplayName("Причина звільнення")]
        [Description("причина звільнення; якщо трудовий стаж переривався, то слід зазначити причину")]
        [Multiline]
        public string DismissalOrUnemployedReason { get; set; }
        /// <summary>
        /// тел, e-mail, якщо є - www;
        /// якщо вказується особа, то вона сприймається як рекомендувач; чим повніше цю особу ідентифіковано, тим краще для подавача
        /// </summary>
        [DisplayName("Контакти роботодавця")]
        [Required]
        public ContactInfo EmployerContact { get; set; }
    }
}
