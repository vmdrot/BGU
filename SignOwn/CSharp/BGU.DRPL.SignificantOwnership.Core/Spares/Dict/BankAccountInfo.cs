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
        [Required("WithMoreDetails == true")]
        [UIConditionalVisibility("WithMoreDetails")]
        [UIUsageComboAddButton(AddNewItemCommand = "local:MyCommands.AddMentionedPersonCommand", DisplayMember = "DisplayName", ItemGetterFull = "localdata:DataModule.CurrentMentionedIdentities", ValueMember = "ID", ValueMemberUsageMode = ComboUIValueUsageMode.ValueProperty, Width = "150", ContainerOrientation=Orientation.Vertical)]
        public GenericPersonID AccountOwner { get; set; }
        /// <summary>
        /// Ідентифікація банку, де відкрито рахунок
        /// для укр. банків - назва, МФО
        /// для нерезидентів - Назва, назва укр., (SWIFT або MFO), якщо ні - адреса, щоб однозначно ідентифікувати
        /// </summary>
        [DisplayName("У банку...")]
        [Required]
        [UIUsageComboAddButton(AddNewItemCommand = "local:MyCommands.AddBankCommand", DisplayMember = "Name", ItemGetterFull = "localdata:DataModule.СurrentBanks", ValueMemberUsageMode = ComboUIValueUsageMode.SelectedItem, Width = "250", ToolTipMember = "MFO", ContainerOrientation=Orientation.Vertical)]
        public BankInfo Bank { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Вказати більше деталей")]
        [Description("(відзначити за потреби вказати додаткову інформацію про рахунок)")]
        [Required]
        [DefaultValue(false)]
        public bool WithMoreDetails { get; set; }
        /// <summary>
        /// № рахунку
        /// </summary>
        [DisplayName("№ рахунку")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline=false, MaxWidth="350", MinWidth="250")]
        [UIConditionalVisibility("WithMoreDetails")]
        public string AccountNr { get; set; }
        /// <summary>
        /// ditto
        /// </summary>
        [DisplayName("Валюта рахунку")]
        [UIUsageCombo(ItemsGetterClass = typeof(BGU.DRPL.SignificantOwnership.Core.Spares.Dict.CurrencyInfo), ItemsGetterMemberPath = "AllCurrencies", ValueMemberUsageMode = ComboUIValueUsageMode.ValueProperty, ValueMember = "CCYCode", DisplayMember = "CCYCode", Width = "85", ToolTipMember = "CCYName", ContainerOrientation=Orientation.Vertical)]
        [DefaultValue("UAH")]
        [UIConditionalVisibility("WithMoreDetails")]
        public string AccountCCY { get; set; }
        /// <summary>
        /// релевантні примітки - що за рахунок, для чого використовується (залежно від контексту), необов'язкове поле
        /// </summary>
        [DisplayName("Опис/примітки/призначення рахунку")]
        [Required]
        [Multiline]
        [UIConditionalVisibility("WithMoreDetails")]
        public string AccountDescription { get; set; }

        public override string ToString()
        {
            if(!WithMoreDetails)
                return string.Format("{0}", this.Bank);
            
            StringBuilder rslt = new StringBuilder();
            int i = 0;
            if (AccountOwner != null && !AccountOwner.IsEmpty)
            {
                rslt.AppendFormat("Власник: {0}", AccountOwner);
                i++;
            }
            if (Bank != null)
            {
                if (i > 0)
                    rslt.Append(", ");
                rslt.AppendFormat("у {0}", this.Bank);
                i++;
            }
            
            if (!String.IsNullOrEmpty(AccountNr))
            {
                if (i > 0)
                    rslt.Append(", ");
                rslt.AppendFormat("№ {0}", AccountNr);
                i++;
            }
            if (!String.IsNullOrEmpty(AccountCCY))
            {
                if (i > 0)
                    rslt.Append(", ");
                rslt.AppendFormat("{0}", AccountCCY);
                i++;
            }
            if (!String.IsNullOrEmpty(AccountDescription))
            {
                if (i > 0)
                    rslt.Append(", ");
                rslt.AppendFormat("{0}", AccountDescription);
                i++;
            }

            return rslt.ToString();
        }
    }
}
