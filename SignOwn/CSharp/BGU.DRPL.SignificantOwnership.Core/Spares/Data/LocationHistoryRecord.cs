using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;
using System.ComponentModel;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Запис про історію місця/адреси (реєстрації, проживання, тощо)
    /// </summary>
    public class LocationHistoryRecord : NotifyPropertyChangedBase
    {
        private DateTime? _Since;
        [DisplayName("З...")]
        [Description("Дата, від якої адреса була чинною")]
        public DateTime? Since { get { return _Since; } set { _Since = value; OnPropertyChanged("Since"); } }

        private DateTime? _Until;
        [DisplayName("По...")]
        [Description("Дата, по котру адреса була чинною")]
        public DateTime? Until { get { return _Until; } set { _Until = value; OnPropertyChanged("Until"); } }
        
        private LocationInfo _Address;
        [DisplayName("Адреса")]
        public LocationInfo Address { get { return _Address; } set { _Address = value; OnPropertyChanged("Address"); } }
    }
}
