using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Інформація про телефон
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.PhoneInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class PhoneInfo
    {
        /// <summary>
        /// не обов'язкове, значення (напр.) - дом., моб., роб., тощо
        /// </summary>
        [DisplayName("Тип/назва телефону")]
        [Description("Тип/назва телефону")]
        public string PhoneName { get; set; }
        [DisplayName("№ телефону")]
        [Description("№ телефону")]
        [Required]
        public string PhoneNr { get; set; }
        /// <summary>
        /// напр. "дзвонити з 9 до 18, по вихідних, поза зоною тоді-то, тощо"
        /// </summary>
        [DisplayName("Примітки щодо телефону")]
        [Description("Примітки щодо телефону")]
        [Multiline]
        public string PhoneNotes { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} ({2})", PhoneName, PhoneNr, PhoneNotes);
        }
    }
}
