using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Utility;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    public class ContactInfoBase
    {
        public ContactInfoBase()
        {
            Phones = new List<PhoneInfo>();
            Emails = new List<EmailInfo>();
        }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Бажаний засіб комунікації")]
        [Description("Оберіть той засіб комунікації, котрий є для Вас бажаним (і заповніть відповідні поля)")]
        [Required]
        public MeansOfCommunication PreferrableMeansOfCommunication { get; set; }

        /// <summary>
        /// Бодай один телефон.
        /// Хай самі вказують стільки, скільки хочуть, залежно від того, 
        /// наскільки вони хочуть, щоб їх знайшли, у разі потреби/питань.
        /// </summary>
        [DisplayName("Телефони")]
        [Description("Перелік телефонів")]
        [Required]
        public List<PhoneInfo> Phones { get; set; }
        /// <summary>
        /// Необов'язкове поле, як на мене - вже застарілий засіб зв'язку.
        /// </summary>
        [DisplayName("Факс")]
        public string Fax { get; set; }
        /// <summary>
        /// Мінімум одне мило - обов'язково питати.
        /// </summary>
        [DisplayName("E-mail-и")]
        [Description("Перелік адрес електронної пошти")]
        [Required]
        public List<EmailInfo> Emails { get; set; }

        /// <summary>
        /// Не обов'язкове (окрім банку, видавництва, тощо - де це вимагається контекстом використання цього типу).
        /// </summary>
        [DisplayName("www")]
        [Description("Веб-сайт")]
        public string www { get; set; }

        [DisplayName("Адреса для листування")]
        [Description("Адреса для звичайної пошти")]
        public LocationInfo Address { get; set; }

        public override string ToString()
        {
            StringBuilder rslt = new StringBuilder();
            int i = 0;
            if (Phones != null && Phones.Count > 0)
            {
                if (i > 0)
                    rslt.Append(", ");
                rslt.Append(Phones[0].ToString());
                i++;
            }
            if (Emails != null && Emails.Count > 0)
            {
                if (i > 0)
                    rslt.Append(", ");
                rslt.Append(Emails[0].ToString());
                i++;
            }
            //if (www != null && string.IsNullOrEmpty(www.ToString()))
            //{
            //    if (i > 0)
            //        rslt.Append(", ");
            //    rslt.Append(www.ToString());
            //    i++;
            //}
            if (string.IsNullOrEmpty(www))
            {
                if (i > 0)
                    rslt.Append(", ");
                rslt.Append(www);
                i++;
            }
            return rslt.ToString();
        }
    }
}
