using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Dict
{
    /// <summary>
    /// Інформація про банківський рахунок (відкритий деінде)
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.BankAccountInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class BankAccountInfo
    {
        /// <summary>
        /// У цьому полі - лише ідентифікатор особи;
        /// решта реквізитів особи - десь у MentionedEntities чи його еквіваленті
        /// </summary>
        [DisplayName("Власник рахунку")]
        [Required]
        public GenericPersonID AccountOwner { get; set; }
        /// <summary>
        /// Ідентифікація банку, де відкрито рахунок
        /// для укр. банків - назва, МФО
        /// для нерезидентів - Назва, назва укр., (SWIFT або MFO), якщо ні - адреса, щоб однозначно ідентифікувати
        /// </summary>
        [DisplayName("У банку...")]
        [Required]
        public BankInfo Bank { get; set; }
        /// <summary>
        /// № рахунку
        /// </summary>
        [DisplayName("№ рахунку")]
        public string AccountNr { get; set; }
        /// <summary>
        /// ditto
        /// </summary>
        [DisplayName("Валюта рахунку")]
        [UIUsageCombo(ItemsGetterClass = typeof(BGU.DRPL.SignificantOwnership.Core.Spares.Dict.CurrencyInfo), ItemsGetterMemberPath = "AllCurrencies", ValueMemberUsageMode = ComboUIValueUsageMode.ValueProperty, ValueMember = "CCYCode", DisplayMember = "CCYCode", Width = "50")]
        [DefaultValue("UAH")]
        public string AccountCCY { get; set; }
        /// <summary>
        /// релевантні примітки - що за рахунок, для чого використовується (залежно від контексту), необов'язкове поле
        /// </summary>
        [DisplayName("Опис/примітки/призначення рахунку")]
        [Required]
        [Multiline]
        public string AccountDescription { get; set; }
    }
}
