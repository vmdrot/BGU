using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using BGU.DRPL.SignificantOwnership.Core.Spares;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.EKDRBU.Spares
{
    public class DocumentID : NotifyPropertyChangedBase
    {
        private string _ID; 
        [DisplayName("Ідентифікатор документа")]
        [Description("Ідентифікатор документа (додатку, тощо)")]
        [Required]
        public string ID { get { return _ID; } set { _ID = value; OnPropertyChanged("ID"); } }
    }
}
