using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Базовий тип (клас) для інформації про позику чи іншу заборгованість (містить усі спільні поля)
    /// </summary>
    public class IndebtnessInfoBase
    {
        [DisplayName("Кредитор")]
        [Required]
        public GenericPersonID Lender { get; set; }
        [DisplayName("Позичальник")]
        [Required]
        public GenericPersonID Borrower { get; set; }
        [DisplayName("Суть заборгованості")]
        [Required]
        [Multiline]
        public string DebtSubject { get; set; }
        [DisplayName("Основна сума боргу")]
        [Required]
        public CurrencyAmount Principal { get; set; }

        [DisplayName("Предмет боргу")]
        [Description("У зв'язку з чим виник борг; якщо позика - для чого було надано, і т.д.")]
        [Required]
        [Multiline]
        public string IndebtnessSubject { get; set; }

        /// <summary>
        /// обов'язкове, якщо передбачена дата погашення; може бути й безстрокова позика.
        /// </summary>
        [DisplayName("Дата погашення")]
        public DateTime? RepaymentDueDate { get; set; }
        [DisplayName("Залишок заборгованості")]
        [Required]
        public CurrencyAmount OutstandingPricipal { get; set; }

        [DisplayName("Прострочена заборгованість?")]
        [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.BooleanEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Required]
        public bool IsOverdue { get; set; }

        /// <summary>
        /// якщо є прострочка
        /// </summary>
        [DisplayName("Прострочено з ... (дата)")]
        [UIConditionalVisibility("IsOverdue")]
        public DateTime? OverdueSince { get; set; }

        /// <summary>
        /// Обов'язкове, якщо IsOverdue == true 
        /// </summary>
        [DisplayName("Сума простроченої заборгованості")]
        [UIConditionalVisibility("IsOverdue")]
        public CurrencyAmount PrincipalOverdue { get; set; }
        
        /// <summary>
        /// Обов'язкове, якщо IsOverdue == true 
        /// </summary>
        [DisplayName("Деталі прострочки")]
        [Description("Додаткова інформація (окрім дати й суми) щодо простроченої заборгованості")]
        [Multiline]
        [UIConditionalVisibility("IsOverdue")]
        public string OverdueDetails { get; set; }
        /// <summary>
        /// Обов'язкове, якщо IsOverdue == true 
        /// </summary>
        [DisplayName("Причини прострочки")]
        [Description("Причини виникнення простроченої заборгованості")]
        [Multiline]
        [UIConditionalVisibility("IsOverdue")]
        public string OverdueReasons { get; set; }

        public override string ToString()
        {
            return string.Format("позичальник: {0}, Кредитор: {1}, {2}\t{3}...", Borrower, Lender, Principal, DebtSubject);
        }

    }
}
