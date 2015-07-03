using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;
using System.Xml.Serialization;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Dict
{
    /// <summary>
    /// Ліцензійна організація
    /// (напр. проф.комісія, що надає ліцензії для заняття 
    /// тим чи іншим видом професійної діяльності, чи ж видає сертифікат - галузевий чи професійний)
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.ProfessionLicensingBodyInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class ProfessionLicensingBodyInfo : NotifyPropertyChangedBase
    {
        private string _Name;
        /// <summary>
        /// Назва оригінальною мовою
        /// </summary>
        [DisplayName("Назва ліцензіатора")]
        [Required]
        public string Name { get { return _Name; } set { _Name = value; OnPropertyChanged("Name"); } }

        private string _NameUkr;
        /// <summary>
        /// Назва українською (якщо нерезидент)
        /// </summary>
        [DisplayName("Назва ліцензіатора(укр.)")]
        [UIConditionalVisibility("IsNonResident")]
        public string NameUkr { get { return _NameUkr; } set { _NameUkr = value; OnPropertyChanged(" NameUkr"); } }

        private LegalPersonInfo _LegalPerson;
        /// <summary>
        /// обов'язкові поля: Назва(-и), Адреса, країна резидентності
        /// </summary>
        [DisplayName("Реквізити юрособи (ліцензіатора)")]
        [Required]
        public LegalPersonInfo LegalPerson { get { return _LegalPerson; } set { _LegalPerson = value; OnPropertyChanged("LegalPerson"); OnPropertyChanged("IsNonResident"); } }

        [Browsable(false)]
        [XmlIgnore]
        public bool IsNonResident { get { return (LegalPerson != null && LegalPerson.IsNonResident); } }


    }
}
