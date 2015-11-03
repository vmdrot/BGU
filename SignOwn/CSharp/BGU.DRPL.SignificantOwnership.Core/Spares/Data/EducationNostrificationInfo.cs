using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

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
    }
}
