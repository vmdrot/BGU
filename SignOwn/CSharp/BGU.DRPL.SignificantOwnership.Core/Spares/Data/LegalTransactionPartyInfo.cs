using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Інформація про сторону правочину
    /// </summary>
    public class LegalTransactionPartyInfo
    {
        [DisplayName("Сторона")]
        [Description("Ідентифікація сторони правочину")]
        public GenericPersonID Party { get; set; }
        [DisplayName("Роль")]
        [Description("Роль сторони у правочині")]
        public LegalTransactionPartyRoleType Role { get; set; }
        [DisplayName("Роль (інше)")]
        [Description("Роль сторони у правочині, як в полі \"Роль\" вказано інше")]
        public string RoleIfOther { get; set; }
    }
}
