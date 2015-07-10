using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Evolvex.Utility.Core.ComponentModelEx;
using System.ComponentModel;
using System.Xml.Serialization;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Інформація про правочин
    /// У перспективі - продумати структуру, що б покривала опису, що надається у https://uk.wikipedia.org/wiki/%D0%9F%D1%80%D0%B0%D0%B2%D0%BE%D1%87%D0%B8%D0%BD
    /// </summary>
    /// <see cref="https://uk.wikipedia.org/wiki/%D0%9F%D1%80%D0%B0%D0%B2%D0%BE%D1%87%D0%B8%D0%BD"/>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.LegalTransactionInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class LegalTransactionInfo : NotifyPropertyChangedBase
    {
        public LegalTransactionInfo()
        {
            this.Parties = new List<LegalTransactionPartyInfo>();
        }

        private bool _IsCommitted;
        [DisplayName("Правочин відбувся?")]
        [Description("Чи правочин уже відбувся чи лише планується?")]
        [Required]
        public bool IsCommitted { get { return _IsCommitted; } set { _IsCommitted = value; OnPropertyChanged("IsCommitted"); } }


        private LegalTransactionType _TransactionType;
        [DisplayName("Тип правочину")]
        [Description("...")]
        public LegalTransactionType TransactionType { get { return _TransactionType; } set { _TransactionType = value; OnPropertyChanged("TransactionType"); } }
        
        [Browsable(true)]
        [XmlIgnore]
        public bool IsTransactionTypOther { get { return TransactionType == LegalTransactionType.Other; } }

        private string _TransactionTypeOther;
        [DisplayName("Тип правочину (інше)")]
        [Description("(Якщо було обрано тип 'Інший')")]
        public string TransactionTypeOther { get { return _TransactionTypeOther; } set { _TransactionTypeOther = value; OnPropertyChanged("TransactionTypeOther"); } }


        private string _TransactionNr;
        [DisplayName("№ правочину")]
        [Description("напр. №/серія договору, тощо - якщо правочин вже відбувся та/або цей реквізит відомий")]
        [Required("IsCommitted == true")]
        [UIConditionalVisibility("IsCommitted")]
        public string TransactionNr { get { return _TransactionNr; } set { _TransactionNr = value; OnPropertyChanged("TransactionNr"); } }

        private DateTime? _TransactionDate;
        [DisplayName("Дата правочину")]
        [Description("якщо правочин вже відбувся та/або цей реквізит відомий")]
        [Required("IsCommitted == true")]
        [UIConditionalVisibility("IsCommitted")]
        public DateTime? TransactionDate { get { return _TransactionDate; } set { _TransactionDate = value; OnPropertyChanged("TransactionDate"); } }

        private List<LegalTransactionPartyInfo> _Parties;
        [DisplayName("Сторони")]
        [Description("Сторони правочину")]
        [Required]
        [UIUsageDataGridParams(IsOneColumn=true,OneDataColumnHeader="Сторони правочину")]
        public List<LegalTransactionPartyInfo> Parties { get { return _Parties; } set { _Parties = value; OnPropertyChanged("Parties"); } }


        private string _TransactionText;
        [DisplayName("Зміст правочину")]
        [Description("Стислий опис змісту правочину")]
        [Required]
        [Multiline]
        public string TransactionText { get { return _TransactionText; } set { _TransactionText = value; OnPropertyChanged("TransactionText"); } }
    }
}
