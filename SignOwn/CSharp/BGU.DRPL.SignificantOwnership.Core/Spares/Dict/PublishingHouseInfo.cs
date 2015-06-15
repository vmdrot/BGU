using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Dict
{
    /// <summary>
    /// Інформація про видавництво (як організацію, 
    /// що займається виданнями)
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.PublishingHouseInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class PublishingHouseInfo
    {
        /// <summary>
        /// Обов'язкове поле
        /// </summary>
        [DisplayName("Назва видавництва")]
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Глибина валідації й повнота 
        /// заповнення залежить від відомості видавництва.
        /// Тут цікавить не стільки ЄДРПОУ, скільки адреса 
        /// (у адресі - місто, як стандартно означають видавництва)й назва; решта полів - за бажанням заповнювача.
        /// </summary>
        [DisplayName("Реквізити юрособи видавництва")]
        [Required]
        public LegalPersonInfo LegalPerson { get; set; }
    }
}
