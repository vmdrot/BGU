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
    /// Інформація про документ про освіту (вищу, неповну, академічну, тощо)
    /// </summary>
    /// <seealso cref="https://osvita.net/ua/checkdoc/"/>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.EducationRecordInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class EducationRecordInfo
    {
        /// <summary>
        /// Обов'язкове поле
        /// </summary>
        [DisplayName("ВНЗ")]
        [Description("ВНЗ - університет, інститут, коледж, тощо")]
        [Required]
        public UniversityOrCollegeInfo UniOrCollege { get; set; }

        /// <summary>
        /// Обов'язкове поле; достатньо рік, або рік і місяць
        /// </summary>
        [DisplayName("Дата вступу")]
        [Required]
        public DateTime EnteredDate { get; set; }

        /// <summary>
        /// Обов'язкове поле; достатньо рік, або рік і місяць
        /// </summary>
        [DisplayName("Дата закінчення")]
        [Required]
        public DateTime GraduationDate { get; set; }

        /// <summary>
        /// обов'язкове
        /// </summary>
        [DisplayName("Тип диплома")]
        [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.EnumLookupEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Required]
        public HigherEducationDegreeType DegreeType { get; set; }
        /// <summary>
        /// необов'язкове поле (подавачі самі зацікавлені)
        /// </summary>
        [DisplayName("Тип відзнаки")]
        [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.EnumLookupEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public DegreeHonourType HonourType { get; set; }


        [DisplayName("Має вчене звання?")]
        public bool HasScientificDegree { get; set; }

        [DisplayName("Вчене звання")]
        [Description("Вчене звання - вітчизняне чи еквівалент зарубіжного (якщо є)")]
        [Required("HasScientificDegree")]
        [UIConditionalVisibility("HasScientificDegree")]
        public ScientificDegreeType? ScientificDegree { get; set; }

        /// <summary>
        /// Якщо український диплом - обов'язкове; 
        /// іншої країни - на віру
        /// </summary>
        [DisplayName("Серія диплома")]
        [Required]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "100", MaxWidth = "250")]
        public string DegreeSeries { get; set; }
        /// <summary>
        /// Якщо український диплом - обов'язкове;
        /// 
        /// </summary>
        /// <seealso cref="DegreeSeries"/>
        [DisplayName("№ диплома")]
        [Required]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "200", MaxWidth = "350")]
        public string DegreeID { get; set; }
        /// <summary>
        /// Обов'язково
        /// </summary>
        [DisplayName("Спеціальність")]
        [Description("Основний фах за дипломом")]
        [Required]
        public string Trade { get; set; }
        /// <summary>
        /// Якщо передбачено
        /// </summary>
        [DisplayName("Кваліфікація")]
        [Description("Уточнююча означення отриманого фаху - спеціалізація/кваліфікація")]
        public string Qualification { get; set; }

        [DisplayName("Вид освіти")]
        [Description("Загальний вид освіти (юр., екон., техн., тощо)")]
        public EducationKindGros EducationKind { get; set; }


        [DisplayName("Потребує нострифікації?")]
        [Description("Чи потребує нострифікації відповідний диплом?")]
        public bool IsNostrificationRequired {get;set;}

        [DisplayName("Запис про нострифікацію")]
        [Description("Реквізити нострифікаційного свідоцтва (у випадку освіти, отриманої за кордоном, де потребується нострифікація диплому)")]
        //[Required("UniOrCollege.IsNonResident == true")]
        [Required("IsNostrificationRequired")]
        //[UIConditionalVisibility("UniOrCollege.IsNonResident")]
        [UIConditionalVisibility("IsNostrificationRequired")]
        public EducationNostrificationInfo NostrificationReqs { get; set; }
    }
}
