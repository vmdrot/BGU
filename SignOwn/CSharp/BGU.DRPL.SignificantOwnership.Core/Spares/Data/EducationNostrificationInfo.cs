using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Запис про нострифікацію диплому чи
    /// іншого свідоцтва про отриману за кордоном освіту.
    /// Див. також http://www.statsilk.com/maps/where-are-worlds-top-universities-interactive-maps-comparing-three-rankings-arwu-the-qs
    /// </summary>
    /// <seealso cref="http://zakon4.rada.gov.ua/laws/show/z0614-15"/>
    public class EducationNostrificationInfo : NotifyPropertyChangedBase
    {
        private string _CerfiticateNr;
        [DisplayName("№ свідоцтва")]
        [Description("№ нострифікаційного свідоцтва")]
        public string CerfiticateNr { get { return _CerfiticateNr; } set { _CerfiticateNr = value; OnPropertyChanged("CerfiticateNr"); } }

        private DateTime _NostrificationDate;
        [DisplayName("Дата видачі ")]
        [Description("Дата видачі нострифікаційного свідоцтва")]
        public DateTime NostrificationDate { get { return _NostrificationDate; } set { _NostrificationDate = value; OnPropertyChanged("NostrificationDate"); } }

                /// <summary>
        /// обов'язкове
        /// </summary>
        [DisplayName("Визнаний тип диплома - вітчизняний еквівалент")]
        [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.EnumLookupEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Required]
        public HigherEducationDegreeType DomesticDegreeTypeEquivalent { get; set; }

        /// <summary>
        /// Обов'язково
        /// </summary>
        [DisplayName("Визнана спеціальність - вітчизняний еквівалент")]
        [Description("Основний фах за дипломом - вітчизняний еквівалент")]
        [Required]
        public string DomesticTradeEquivalent { get; set; }

        /// <summary>
        /// Якщо передбачено
        /// </summary>
        [DisplayName("Визнана кваліфікація - вітчизняний еквівалент")]
        [Description("Уточнююча означення отриманого фаху - спеціалізація/кваліфікація, - вітчизняний еквівалент")]
        public string DomesticQualificationEquivalent { get; set; }

        [DisplayName("Вид освіти - вітчизняний еквівалент")]
        [Description("Загальний вид освіти (юр., екон., техн., тощо) - вітчизняний еквівалент")]
        public EducationKindGros DomesticEducationKindEquivalent { get; set; }
    }
}
