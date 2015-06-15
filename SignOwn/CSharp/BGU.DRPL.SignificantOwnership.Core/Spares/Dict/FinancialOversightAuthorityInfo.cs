using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Dict
{
    /// <summary>
    /// Банківський/фінансовий наглядовий/регуляторний орган 
    /// (згадується у декотрих анкетах)
    /// 
    /// Задля мінімізації зусиль подавачів на введення, а також уникнення помилок, бажано мати довідник цих установ і давати обрати зі списку, відфільтрувавши за країною резидентності
    /// </summary>
    /// <seealso cref="http://en.wikipedia.org/wiki/Category:Financial_regulatory_authorities"/>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.FinancialOversightAuthorityInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class FinancialOversightAuthorityInfo
    {
        public FinancialOversightAuthorityInfo()
        {
            Jurisdiction = CountryInfo.UKRAINE;
        }

        [DisplayName("Країна юрисдикції")]
        [Required]
        public CountryInfo Jurisdiction { get; set; }
        /// <summary>
        /// Назва органу оригінальною мовою, напр.:
        ///  - Bundesanstalt für Finanzdienstleistungsaufsicht
        ///  - Komisja Nadzoru Finansowego
        /// </summary>
        [DisplayName("Назва органу")]
        [Required]
        public string AuthorityName { get; set; }
        /// <summary>
        /// Назва органу українською, напр.:
        ///  - Бундесанштальт фюр фінанцдінстляйстунґзауфзіхт - Федеральний орган нагляду за фінансовими послугами (ФРН)
        ///  - Комісія надзору фінансовеґо - Комісія фінансового нагляду (Польща)
        ///  
        /// </summary>
        [DisplayName("Назва органу(українською)")]
        [Required]
        public string AuthorityNameUkr { get; set; }
        /// <summary>
        /// Максимальне заповнення полів
        /// </summary>
        [DisplayName("Адреса")]
        [Required]
        public LocationInfo Address { get; set; }

        /// <summary>
        /// Якщо у органу є адреса чи ідентифікатор SWIFT
        /// </summary>
        [DisplayName("Адреса SWIFT")]
        public string SWIFTBIC { get; set; }
        /// <summary>
        /// Контакти органу
        /// Поля, які бажано заповнити - www
        /// </summary>
        [DisplayName("Контакти")]
        [Required]
        public ContactInfo Contacts { get; set; }
    }
}
