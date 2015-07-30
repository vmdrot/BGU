using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;
using System.Xml.Serialization;

namespace BGU.DRPL.SignificantOwnership.Core.EKDRBU.Spares
{
    public class WorkHoursInfo : NotifyPropertyChangedBase
    {
        private WorkingHoursDayType _Day;
        [DisplayName("Дні")]
        [Description("Означення днів")]
        public WorkingHoursDayType Day { get { return _Day; } set { _Day = value; OnPropertyChanged("Day"); OnPropertyChanged("IsParticularDay"); } }

        [Browsable(false)]
        [XmlIgnore]
        public bool IsParticularDay { get; set; }

        private DayOfWeek? _ParticularDay;
        [DisplayName("Конкретний день тижня")]
        [Description("Конкретний день тижня( якщо у полі 'Дні' вказано 'Конкретний день')")]
        [UIConditionalVisibility("IsParticularDay")]
        public DayOfWeek? ParticularDay { get { return _ParticularDay; } set { _ParticularDay = value; OnPropertyChanged("ParticularDay"); } }

        private DateTime _StartTime;
        [DisplayName("Початок інтервалу")]
        [Description("Час початку інтервалу (робочого чи, навпаки, неробочого)")]
        public DateTime StartTime { get { return _StartTime; } set { _StartTime = value; OnPropertyChanged("StartTime"); } }

        private DateTime _EndTime;
        [DisplayName("Кінець інтервалу")]
        [Description("Час кінця інтервалу (робочого чи, навпаки, неробочого)")]
        public DateTime EndTime { get { return _EndTime; } set { _EndTime = value; OnPropertyChanged("EndTime"); } }

        private bool _IsWorkingOrIdle;
        [DisplayName("Працює")]
        [Description("Відзначити галочкою, якщо вказується робочий інтервал, зняти галочку - якщо навпаки, не робочий")]
        public bool IsWorkingOrIdle { get { return _IsWorkingOrIdle; } set { _IsWorkingOrIdle = value; OnPropertyChanged("IsWorkingOrIdle"); } }
    }
}
