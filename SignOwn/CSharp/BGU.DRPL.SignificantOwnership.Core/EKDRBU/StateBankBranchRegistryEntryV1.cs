using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;
using Evolvex.Utility.Core.Geo;
using BGU.DRPL.SignificantOwnership.Core.EKDRBU.Spares;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;

namespace BGU.DRPL.SignificantOwnership.Core.EKDRBU
{
    public class StateBankBranchRegistryEntryV1 : NotifyPropertyChangedBase
    {
        public StateBankBranchRegistryEntryV1()
        {
            OpenDate = DateTime.Now;
            RegisteredDate = DateTime.Now;
            PayDocDate = DateTime.Now;
            
        }
        
        private EKDRBUVariableEntryPartV1 _VariablePart;
        [DisplayName("Змінна частина")]
        [Description("Змінна частина реквізитів повідомлення")]
        public EKDRBUVariableEntryPartV1 VariablePart { get { return _VariablePart; } set { _VariablePart = value; OnPropertyChanged("VariablePart"); } }

        private DateTime _OpenDate;
        [Category("Номери")]
        [DisplayName("дата відкриття")]
        [Description("дата відкриття")]
        public DateTime OpenDate { get { return _OpenDate; } set { _OpenDate = value; OnPropertyChanged("OpenDate"); } }

        private DateTime _RegisteredDate;
        [Category("Номери")]
        [DisplayName("дата внесення до Державного реєстру банків")]
        [Description("дата внесення до Державного реєстру банків")]
        public DateTime RegisteredDate { get { return _RegisteredDate; } set { _RegisteredDate = value; OnPropertyChanged("RegisteredDate"); } }

        private string _PayDocNr;
        [Category("Оплата")]
        [DisplayName("номер платіжного документа")]
        [Description("номер платіжного документа")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MaxWidth = "75", MinWidth = "100")]
        public string PayDocNr { get { return _PayDocNr; } set { _PayDocNr = value; OnPropertyChanged("PayDocNr"); } }
        
        private DateTime _PayDocDate;
        [Category("Оплата")]
        [DisplayName("дата здійснення оплати")]
        [Description("дата здійснення оплати")]
        public DateTime PayDocDate { get { return _PayDocDate; } set { _PayDocDate = value; OnPropertyChanged("PayDocDate"); } }
        
     
        
        private DateTime? _ClosedDate;
        [Category("Службові")]
        [DisplayName("Дата закриття")]
        [Description("Дата закриття")]
        public DateTime? ClosedDate { get { return _ClosedDate; } set { _ClosedDate = value; OnPropertyChanged("ClosedDate"); } }
        
        private DateTime? _UnregisteredDate;
        [Category("Службові")]
        [DisplayName("Дата виключення з Державного реєстру банків")]
        [Description("Дата виключення з Державного реєстру банків")]
        public DateTime? UnregisteredDate { get { return _UnregisteredDate; } set { _UnregisteredDate = value; OnPropertyChanged("UnregisteredDate"); } }
        
    }
}
