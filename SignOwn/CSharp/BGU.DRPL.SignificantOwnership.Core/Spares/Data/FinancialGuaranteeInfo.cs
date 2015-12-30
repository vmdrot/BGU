using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Структура для зберігання відомостей про надану гарантію, поручительство, тощо
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.FinancialGuaranteeInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class FinancialGuaranteeInfo
    {
        /// <summary>
        /// Ідентифікатор особи, за яку ручаються;
        /// обирається зі списку, джерело - MentionedEntities, або ж уводиться (тут же) й "кладеться" у MentionedEntities.
        /// </summary>
        [DisplayName("Особа, щодо якої гарантую/ручаюся,тощо")]
        [Required]
        public GenericPersonID Debtor { get; set; }

        /// <summary>
        /// Ідентифікатор особи, на користь якої виписана порука/гарантія;
        /// обирається зі списку, джерело - MentionedEntities, або ж уводиться (тут же) й "кладеться" у MentionedEntities.
        /// ---
        /// UPD: обов'язковість поля прибрано, на підставі зауваження М.Мельничука:
        ///   Існують гарантійні зобов’язання з умовою «платити наказу…» чи аналогічними, 
        ///   де визначити кредитора певний час неможливо. Думаю варто ознаку виставити як 
        ///   необов’язкову, або зазначати у разі наявності
        /// </summary>
        [DisplayName("Особа, на користь якої порука")]
        public GenericPersonID Creditor { get; set; }
        /// <summary>
        /// Обов'язкове
        /// </summary>
        [DisplayName("Роль")]
        [Description("Роль (гарантор, довірена особа, тощо)")]
        [Required]
        public FinancialGuarantorRoleType Role { get; set; }
        /// <summary>
        /// обов'язкове
        /// </summary>
        [DisplayName("Сума гарантії/поруки/тощо")]
        [Required]
        public CurrencyAmount PledgeAmt { get; set; }
        /// <summary>
        /// обов'язкове
        /// </summary>
        [DisplayName("Дата надання гарантії/поруки/тощо")]
        [Required]
        public DateTime IssueDate { get; set; }

        /// <summary>
        /// обов'язкове
        /// </summary>
        [DisplayName("Дата погашення зобов'язання, щодо якого надається гарантія/порука")]
        [Required]
        public DateTime UnderlyingObligationSettlementDate { get; set; }
        /// <summary>
        /// обов'язкове (але вільного формату)
        /// </summary>
        [DisplayName("Деталі")]
        [Description("Деталі наданої гарантії/поруки")]
        [Required]
        [Multiline]
        public string GuaranteeDetails { get; set; }
    }
}
