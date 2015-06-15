using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Інформація про колегіальний орган управління (наглядова рада, виконавчий комітет, рада директорів, тощо)
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.CouncilBodyInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class CouncilBodyInfo
    {
        public CouncilBodyInfo()
        {
            Members = new List<CouncilMemberInfo>();
        }
        /// <summary>
        /// Повні реквізити самої організації "житимуть", як правило, у MentionedEntities (або його еквіваленті)
        /// </summary>
        [DisplayName("Керована організація")]
        [Required]
        public GenericPersonID GovernedEntityID { get; set; }
        /// <summary>
        /// Перелік членів органу
        /// </summary>
        [DisplayName("Члени")]
        [Description("Члени органу управління")]
        [Required]
        public List<CouncilMemberInfo> Members { get; set; }
        /// <summary>
        /// Ідентифікатор особи-голови
        /// </summary>
        [DisplayName("Очільник/голова органу")]
        [Required]
        public GenericPersonID HeadMember { get; set; }
        /// <summary>
        /// Назва органу (мовою оригіналу)
        /// </summary>
        [DisplayName("Назва органу")]
        [Description("Назва органу (мовою оригіналу)")]
        [Required]
        public string CouncilBodyName { get; set; }
        /// <summary>
        /// Назва органу (українською, для організацій-нерезидентів)
        /// </summary>
        [DisplayName("Назва органу (укр.)")]
        [Description("Назва органу (українською, для організацій-нерезидентів)")]
        public string CouncilBodyNameUkr { get; set; }
        public override string ToString()
        {
            int membersCnt = Members != null ? Members.Count : 0;
            return string.Format("{0} членів", membersCnt);
        }
    }
}
