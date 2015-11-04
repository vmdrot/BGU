using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Відомості про трудову книгу
    /// </summary>
    public class EmploymentBookInfo
    {
        [DisplayName("Серія")]
        [Description("Серія трудової книги")]
        public string BookSeries { get; set; }

        [DisplayName("№")]
        [Description("№ трудової книги")]
        public string BookNr { get; set; }

        [DisplayName("Дата заповнення")]
        [Description("Дата видачі (першого заповнення) трудової книги")]
        public DateTime FilledDate { get; set; }
    }
}
