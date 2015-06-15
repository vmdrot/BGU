using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Структура для зберігання інформації про e-mail
    /// Можна відмовитися й зберігати просто значення e-mail
    /// </summary>
    public class EmailInfo
    {
        /// <summary>
        /// обов'язкове поле
        /// валідація як e-mail
        /// </summary>
        [DisplayName("Адреса ел.пошти")]
        [Required]
        public string Email { get; set; }
        /// <summary>
        /// Необов'язкове поле, передбачено для вказання, що за мило - робоче, особисте, офіційне (юр.особи).
        /// </summary>
        [DisplayName("Примітки (необов'язково)")]
        public string EmailDescription { get; set; }

        public override string ToString()
        {
            return Email;
        }
    }
}
