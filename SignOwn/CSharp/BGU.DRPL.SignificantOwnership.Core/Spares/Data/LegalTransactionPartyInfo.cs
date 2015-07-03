using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Xml.Serialization;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Інформація про сторону правочину
    /// </summary>
    public class LegalTransactionPartyInfo : NotifyPropertyChangedBase
    {
        private GenericPersonID _Party;
        [DisplayName("Сторона")]
        [Description("Ідентифікація сторони правочину")]
        [Required]
        public GenericPersonID Party { get { return _Party; } set { _Party = value; OnPropertyChanged("Party"); } }


        private LegalTransactionPartyRoleType _Role;
        [DisplayName("Роль")]
        [Description("Роль сторони у правочині")]
        [Required]
        public LegalTransactionPartyRoleType Role { get { return _Role; } set { _Role = value; OnPropertyChanged("Role"); } }

       
        [Browsable(false)]
        [XmlIgnore]
        public bool IsRoleOther { get { return Role == LegalTransactionPartyRoleType.Other; } }

        private string _RoleIfOther;
        [DisplayName("Роль (інше)")]
        [Description("Роль сторони у правочині, як в полі \"Роль\" вказано інше")]
        [UIConditionalVisibility("IsRoleOther")]
        public string RoleIfOther { get { return _RoleIfOther; } set { _RoleIfOther = value; OnPropertyChanged("RoleIfOther"); } }
    }
}
