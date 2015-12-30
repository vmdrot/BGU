using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Відомості про виданий паспорт
    /// (для історії, якщо у особи було понад один паспорт, 
    /// окрім чинного)
    /// </summary>
    public class PassportHistoryRecord : NotifyPropertyChangedBase
    {
        private string _PassportID;
        [DisplayName("Серія № паспорта")]
        [Description("Серія № паспорта")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth = "200")]
        public string PassportID { get { return _PassportID; } set { _PassportID = value; OnPropertyChanged("PassportID"); } }

        private DateTime? _PassIssuedDate;
        [DisplayName("Дата видачі паспорта")]
        [Description("Дата видачі паспорта")]
        public DateTime? PassIssuedDate { get { return _PassIssuedDate; } set { _PassIssuedDate = value; OnPropertyChanged("PassIssuedDate"); } }

        private RegistrarAuthority _PassIssueAuthority;
        [DisplayName("Орган, що видав паспорт")]
        [Description("Орган, що видав паспорт")]
        public RegistrarAuthority PassIssueAuthority { get { return _PassIssueAuthority; } set { _PassIssueAuthority = value; OnPropertyChanged("PassIssueAuthority"); } }
    }
}
