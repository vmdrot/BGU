using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Запис про історію контактних даних
    /// </summary>
    public class ContactInfoHistoryRec : NotifyPropertyChangedBase
    {
        private DateTime? _Since;
        [DisplayName("З...")]
        [Description("Дата, від якої контакти були чинними")]
        public DateTime? Since { get { return _Since; } set { _Since = value; OnPropertyChanged("Since"); } }

        private DateTime? _Until;
        [DisplayName("По...")]
        [Description("Дата, по котру контакти були чинними")]
        public DateTime? Until { get { return _Until; } set { _Until = value; OnPropertyChanged("Until"); } }

        private ContactInfo _Contacts;
        [DisplayName("Котакти")]
        public ContactInfo Contacts { get { return _Contacts; } set { _Contacts = value; OnPropertyChanged("Contacts"); } }
    }
}
