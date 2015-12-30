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
    /// Інформація про навчальний заклад (університет, коледж, тощо) професійної, вищої чи неповної вищої освіти
    /// ---
    /// UPD: Ідентифікатор ВНЗ (поле UniversityID) видалено - 
    /// поки що не існує в жодній країні; по Україні достатньо ідентифікатора диплому.
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.UniversityOrCollegeInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class UniversityOrCollegeInfo : NotifyPropertyChangedBase
    {
        private string _UniversityName;
        /// <summary>
        /// Обов'язкове поле
        /// </summary>
        [DisplayName("Назва ВНЗ")]
        [Description("Назва вищого навчального закладу оригінальною мовою")]
        [Required]
        public string UniversityName { get { return _UniversityName; } set { _UniversityName = value; OnPropertyChanged("UniversityName"); } }


        private string _UniversityNameUkr;
        /// <summary>
        /// Обов'язкове, якщо ВНЗ - не український, відповідно, 
        /// назва оригінальна потребує перекладу/транслітерації українською.
        /// </summary>
        [DisplayName("Назва ВНЗ (українською)")]
        [Description("Назва вищого навчального закладу оригінальною мовою українською (якщо оригінальна мова інша")]
        [UIConditionalVisibility("IsNonResident")]
        public string UniversityNameUkr { get { return _UniversityNameUkr; } set { _UniversityNameUkr = value; OnPropertyChanged("UniversityNameUkr"); } }

        private LocationInfo _Address;
        /// <summary>
        /// Хоча б місто й країна
        /// </summary>
        [DisplayName("Місцезнаходження ВНЗ")]
        [Description("Країна й місто, де знаходиться ВНЗ")]
        [Required]
        public LocationInfo Address { get { return _Address; } set { _Address = value; OnPropertyChanged("Address"); OnPropertyChanged("IsNonResident"); } }

        [Browsable(false)]
        [XmlIgnore]
        public bool IsNonResident { get { return (Address != null && Address.Country != null && Address.Country != CountryInfo.UKRAINE); } }


        //private string _UniversityID;
        ///// <summary>
        ///// Не певен, чи десь існують ці ідентифікатори - 
        ///// у нас їх немає, але можуть запровадити.
        ///// Необов'зкове поле; заповнювати, якщо ідентифікатор існує.
        ///// </summary>
        //[DisplayName("Ідентифікатор ВНЗ")]
        //[Description("Ідентифікатор ВНЗ - якщо є/передбачений")]
        //public string UniversityID { get { return _UniversityID; } set { _UniversityID = value; OnPropertyChanged("UniversityID"); } }
    }
}
