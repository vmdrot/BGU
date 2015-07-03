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
    /// Розширений варіант агрегованої інформації про власність
    /// </summary>
    public class TotalOwnershipDetailsInfoEx : TotalOwnershipDetailsInfo
    {
        public TotalOwnershipDetailsInfoEx() :base()
        { 
        }

        public TotalOwnershipDetailsInfoEx(TotalOwnershipDetailsInfo src)
        {
            this.DirectOwnership = src.DirectOwnership;
            this.ImplicitOwnership = src.ImplicitOwnership;
            this.AcquiredVotes = src.AcquiredVotes;
            this.TotalCapitalSharePct = src.TotalCapitalSharePct;
            this.TotalVotes = src.TotalVotes;
        }

        public TotalOwnershipDetailsInfoEx(TotalOwnershipDetailsInfo src, GenericPersonID id, string dispName)
        {
            this.DirectOwnership = src.DirectOwnership;
            this.ImplicitOwnership = src.ImplicitOwnership;
            this.AcquiredVotes = src.AcquiredVotes;
            this.TotalCapitalSharePct = src.TotalCapitalSharePct;
            this.TotalVotes = src.TotalVotes;
            this.OwnerID = id;
            //this.OwnerDisplayName = dispName;
        }

        /// <summary>
        /// Тут лише ідентифікатор особи; як завше, решта її реквізитів - десь у MentionedIdentities
        /// </summary>
        [DisplayName("ID Власника")]
        [Required]
        public GenericPersonID OwnerID { get; set; }
        ///// <summary>
        ///// Чисто для показу на UI; окремого бізнес-значення поле не несе
        ///// </summary>
        //[DisplayName("Власник")]
        //[XmlIgnore]
        //public string OwnerDisplayName { get; set; }
    }
}
