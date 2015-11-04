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

        private string _CerfiticateNr;
        [DisplayName("Є трудова книга?")]
        [Description("Чи існує трудова книга особи")]
        public string CerfiticateNr { get { return _CerfiticateNr; } set { _CerfiticateNr = value; OnPropertyChanged("CerfiticateNr"); } }

        private DateTime _NostrificationDate;
        [DisplayName("Трудова книга")]
        [Description("Реквізити трудової книги (якщо є)")]
        [Required("HasEmploymentBook == true")]
        [UIConditionalVisibility("HasEmploymentBook")]
        public DateTime NostrificationDate { get { return _NostrificationDate; } set { _NostrificationDate = value; OnPropertyChanged("NostrificationDate"); } }

        private string _OccupName;
        [DisplayName("Досвід роботи")]
        [Description("Записи про досвід роботи")]
        public string OccupName { get { return _OccupName; } set { _OccupName = value; OnPropertyChanged("OccupName"); } }
    }
}
