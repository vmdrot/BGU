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
    public class PersonEmploymentRecordsInfo : EmploymentHistoryInfo
    {
        public PersonEmploymentRecordsInfo()
        {
        }
        
        /// <summary>
        /// Сама особа (ідентифікатор)
        /// </summary>
        [DisplayName("Особа")]
        [Description("Особа, чию трудову біографію треба розкрити")]
        public GenericPersonID Person { get; set; }

        public override string ToString()
        {
            return string.Format("{0} ({1} місць роботи)", Person, (EmploymentRecords != null ? EmploymentRecords.Count : 0));
        }
    }
}
