using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Особа + її/його трудова біографія
    /// </summary>
    public class PersonEmploymentRecordsInfo
    {
        public PersonEmploymentRecordsInfo()
        {
            EmploymentHistory = new List<EmploymentRecordInfo>();
        }
        
        /// <summary>
        /// Сама особа (ідентифікатор)
        /// </summary>
        [DisplayName("Особа")]
        [Description("Особа, чию трудову біографію треба розкрити")]
        public GenericPersonID Person { get; set; }

        /// <summary>
        /// Трудова біографія особи
        /// </summary>
        [DisplayName("Трудова біографія")]
        [Description("Досвід роботи особи")]
        [UIUsageDataGridParams(IsOneColumn=true,OneDataColumnHeader="Місце роботи")]
        public List<EmploymentRecordInfo> EmploymentHistory { get; set; }

        public override string ToString()
        {
            return string.Format("{0} ({1} місць роботи)", Person, (EmploymentHistory != null ? EmploymentHistory.Count : 0));
        }
    }
}
