﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using BGU.DRPL.SignificantOwnership.Utility;
using System.Collections;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Інформація про придбання на акцій на первинному ринку
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.IPOSharesPurchaseInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class IPOSharesPurchaseInfo
    {
        public IPOSharesPurchaseInfo()
        {
            PaymentDeadlines = new List<PaymentDeadlineInfo>();
        }

        [DisplayName("Кількість акцій")]
        [Description("Кількість акцій (паїв) банку, які юридична особа має намір придбати, штук")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = false, MinWidth="150", MaxWidth = "250", StringFormat = "{}{0:N0}")]
        public int SharesCount { get; set; }
        [DisplayName("Номінальна ціна")]
        [Description("Номінальна вартість однієї акції (одного паю), грн.")]
        public CurrencyAmount NominalSharePrice { get; set; }
        [DisplayName("Загальна номінальна вартість")]
        [Description("Загальна номінальна вартість акцій (паїв), які юридична особа має намір придбати, грн.")]
        public CurrencyAmount NominalTotalSharesValue { get; set; }
        [DisplayName("Реальна ціна акцій")]
        [Description("Ціна акцій (паїв), які юридична особа має намір придбати, грн.")]
        public CurrencyAmount ActualTotalSharesValue { get; set; }
        [DisplayName("Термін оплати")]
        [Description("Запланований термін здійснення оплати")]
        [UIUsageDataGridParams(IsOneColumn=true, OneDataColumnHeader="Терміни сплати")]
        public List<PaymentDeadlineInfo> PaymentDeadlines { get; set; }

        public override string ToString()
        {
            return string.Format("{0}\t{1}\t{2}\t{3}", SharesCount, NominalSharePrice, NominalTotalSharesValue, ActualTotalSharesValue, Tools.EnumerableToString((IEnumerable)PaymentDeadlines) );
        }
    }
}
