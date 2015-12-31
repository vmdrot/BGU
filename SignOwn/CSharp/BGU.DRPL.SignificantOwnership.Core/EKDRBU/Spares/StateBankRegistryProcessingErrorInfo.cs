using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using BGU.DRPL.SignificantOwnership.Core.Spares;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.EKDRBU.Spares
{
    /// <summary>
    /// Інформація про помилку в обробці пакету 
    /// змін до ЕКДРБУ
    /// </summary>
    public class StateBankRegistryProcessingErrorInfo : NotifyPropertyChangedBase
    {
        private ValidationType _ValidationKind;
        /// <summary>
        /// Щоб відрізняти автоматичну (машинну) валідацію від 
        /// ручної (осмисленої) перевірки оператором.
        /// Корисно у багатьох сенсах.
        /// </summary>
        [DisplayName("Виявлено в результаті...")]
        [Description("Стадія обробки, на якій було виявлено помилку - автоматична чи ручна")]
        [Required]
        public ValidationType ValidationKind { get { return _ValidationKind; } set { _ValidationKind = value; OnPropertyChanged("ValidationKind"); } }

        private string _SubjectBranchID;
        /// <summary>
        /// Якщо не вказано - помилка стосується поля на рівні пакету,
        /// якщо вказано - поля на рівні відділення
        /// </summary>
        [DisplayName("Відділення")]
        [Description("Внутр.№ відділення, щодо якого виникла помилка")]
        public string SubjectBranchID { get { return _SubjectBranchID; } set { _SubjectBranchID = value; OnPropertyChanged("SubjectBranchID"); } }

        private string _SubjectField;
        [DisplayName("Код/назва поля")]
        [Description("Назва поля (англ.) де зафіксовано помилку")]
        [Required]
        public string SubjectField { get { return _SubjectField; } set { _SubjectField = value; OnPropertyChanged("SubjectField"); } }

        private int _ErrorCode;
        /// <summary>
        /// Перелік типових помилок та їх коди буде визначено пізніше
        /// </summary>
        [DisplayName("Код помилки")]
        [Description("Цифровий код помилки (з визначеного переліку)")]
        [Required]
        public int ErrorCode { get { return _ErrorCode; } set { _ErrorCode = value; OnPropertyChanged("ErrorCode"); } }

        private string _ErrorMessage; 
        [DisplayName("Опис помилки")]
        [Description("Текстовий опис помилки")]
        public string ErrorMessage { get { return _ErrorMessage; } set { _ErrorMessage = value; OnPropertyChanged("ErrorMessage"); } }
    }
}
