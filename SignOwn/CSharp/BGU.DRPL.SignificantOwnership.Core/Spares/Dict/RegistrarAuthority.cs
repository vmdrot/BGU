using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Dict
{
    /// <summary>
    /// Державний (чи як там заведено у відповідній країні) 
    /// орган реєстрації осіб (як юридичних, так і фізичних)
    /// </summary>
    /// <seealso cref="http://en.wikipedia.org/wiki/List_of_company_registers"/>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.RegistrarAuthority_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class RegistrarAuthority
    {
        public RegistrarAuthority()
        {
            JurisdictionCountry = CountryInfo.UKRAINE;
        }

        /// <summary>
        /// Обов'язкове поле, за змовчанням - Україна
        /// </summary>
        [DisplayName("Країна юрисдикції")]
        [Description("Країна юрисдикції")]
        [Required]
        public CountryInfo JurisdictionCountry { get; set; }
        /// <summary>
        /// якнайповніше
        /// </summary>
        [DisplayName("Місцезнаходження")]
        [Description("Місцезнаходження")]
        [Required]
        public LocationInfo Address { get; set; }
        /// <summary>
        /// Якщо такий код передбачено/існує; коротше, необов'язкове поле
        /// (напр., у наших закордонних паспортах фігурує Issuing authority ID)
        /// </summary>
        [DisplayName("Код держоргану (якщо існує)")]
        [Description("Код держоргану (якщо існує)")]
        public string RegistrarCode { get; set; }
        /// <summary>
        /// Назва реєстратора (оригінальною мовою, у т.ч. українською - якщо реєстратор український).
        /// </summary>
        [DisplayName("Назва держоргану")]
        [Description("Назва держоргану")]
        [Required]
        public string RegistrarName { get; set; }
        /// <summary>
        /// Назва реєстратора українською (якщо реєстратор не український).
        /// </summary>
        [DisplayName("Назва держоргану українською")]
        [Description("Назва держоргану українською")]
        public string RegistrarNameUkr { get; set; }
        /// <summary>
        /// Підтримує побітове складання 
        /// Напр. Legal | Physical, Legal & Physical
        /// (оскільки не виключено, що у котрійсь з юрисдикцій 
        /// можуть існувати органи, що реєструють як фізичних, так і юр.осіб)
        /// </summary>
        [DisplayName("Тип осіб, що реєструє")]
        [Description("Тип осіб, що реєструє")]
        [Required]
        public EntityType EntitiesHandled { get; set; }
        public override string ToString()
        {
            return RegistrarName;
        }
    }
}
