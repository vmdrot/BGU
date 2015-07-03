using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Evolvex.Utility.Core.ComponentModelEx;
using System.ComponentModel;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Інформація про правочин
    /// У перспективі - продумати структуру, що б покривала опису, що надається у https://uk.wikipedia.org/wiki/%D0%9F%D1%80%D0%B0%D0%B2%D0%BE%D1%87%D0%B8%D0%BD
    /// </summary>
    /// <see cref="https://uk.wikipedia.org/wiki/%D0%9F%D1%80%D0%B0%D0%B2%D0%BE%D1%87%D0%B8%D0%BD"/>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.LegalTransactionInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class LegalTransactionInfo
    {
        public LegalTransactionInfo()
        {
            this.Parties = new List<LegalTransactionPartyInfo>();
        }
        [DisplayName("Правочин відбувся?")]
        [Description("Чи правочин уже відбувся чи лише планується?")]
        [Required]
        public bool IsCommitted { get; set; }

        [DisplayName("Тип правочину")]
        [Description("...")]
        public LegalTransactionType TransactionType { get; set; }

        [DisplayName("№ правочину")]
        [Description("напр. №/серія договору, тощо - якщо правочин вже відбувся та/або цей реквізит відомий")]
        [Required("IsCommitted == true")]
        [UIConditionalVisibility("IsCommitted")]
        public string TransactionNr { get; set; }
        
        [DisplayName("Дата правочину")]
        [Description("якщо правочин вже відбувся та/або цей реквізит відомий")]
        [Required("IsCommitted == true")]
        [UIConditionalVisibility("IsCommitted")]       
        public DateTime TransactionDate { get; set; }

        [DisplayName("Сторони")]
        [Description("Сторони правочину")]
        [Required]
        public List<LegalTransactionPartyInfo> Parties { get; set; }

        [DisplayName("Зміст правочину")]
        [Description("Стислий опис змісту правочину")]
        [Required]
        [Multiline]
        public string TransactionText { get; set; }
    }
}
