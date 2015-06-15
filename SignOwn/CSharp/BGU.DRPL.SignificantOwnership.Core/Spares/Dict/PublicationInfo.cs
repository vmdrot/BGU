using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Dict
{
    /// <summary>
    /// Відомості про публікацію (у декотрих анкетах вимагається 
    /// офіційна публікація того чи іншого стану юр.особи (корпорації) чи банку
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.PublicationInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class PublicationInfo
    {
        /// <summary>
        /// Обов'язкове поле
        /// </summary>
        [DisplayName("Видавництво")]
        [Required]
        public PublishingHouseInfo Publisher { get; set; }
        /// <summary>
        /// ISBN публікації (якщо є).
        /// </summary>
        /// <seealso cref="http://www.ukrbook.net/agentstvo.html"/>
        [DisplayName("ІSBN ідентифікатор")]
        [Description("ІSBN ідентифікатор видання (якщо є)")]
        public string ISBN { get; set; }
        /// <summary>
        /// Якщо опубліковано не окремою публікацією, а у ЗМІ 
        /// (газеті, журналі, часописі, альманасі, тощо) - назва такого ЗМІ
        /// </summary>
        [DisplayName("Назва ЗМІ")]
        public string MediaName { get; set; }
        /// <summary>
        /// Обов'язкове поле
        /// </summary>
        [DisplayName("Дата публікації")]
        [Required]
        public DateTime PubDate { get; set; }
        /// <summary>
        /// якщо у ЗМІ, то обов'язкове
        /// </summary>
        [DisplayName("Число публікації")]
        [Description("Число/№ публікації (випуск газети, журналу, тощо)")]
        public string IssueNr { get; set; }
        /// <summary>
        /// Якщо публікація в інтернеті - обов'язкове поле
        /// Опціональне, якщо окрім друкованого варіанту є ще й он-лайновий
        /// </summary>
        [DisplayName("URL публікації")]
        [Description("Ланка на публікацію (адреса публікації в інтернет)")]
        public string PubUrl { get; set; }
    }
}
