using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Тип даних, що енкапсулює відомості про трудовий стаж:
    ///  реквізити трудової книги + колекцію записів про епізоди трудової біографії.
    /// </summary>
    public class EmploymentHistoryInfo : NotifyPropertyChangedBase
    {

        private bool _HasEmploymentBook;
        [DisplayName("Є трудова книга?")]
        [Description("Чи існує трудова книга особи")]
        public bool HasEmploymentBook { get { return _HasEmploymentBook; } set { _HasEmploymentBook = value; OnPropertyChanged("HasEmploymentBook"); } }

        private EmploymentBookInfo _EmploymentBook;
        [DisplayName("Трудова книга")]
        [Description("Реквізити трудової книги (якщо є)")]
        [Required("HasEmploymentBook == true")]
        [UIConditionalVisibility("HasEmploymentBook")]
        public EmploymentBookInfo EmploymentBook { get { return _EmploymentBook; } set { _EmploymentBook = value; OnPropertyChanged("EmploymentBook"); } }

        /// <summary>
        /// Власне, записи про досвід роботи особи
        /// </summary>
        [DisplayName("Записи")]
        [Description("Записи про досвід роботи особи")]
        [UIUsageDataGridParams(IsOneColumn = true, OneDataColumnHeader = "Місце роботи")]
        public List<EmploymentRecordInfo> EmploymentRecords { get; set; }
    }
}
