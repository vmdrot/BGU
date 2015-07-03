using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Інформація про відмітку в паспорті про право здійснювати будь-які 
    ///   платежі без ІПН
    ///  ---------------------------------------------------------
    ///  У паспорт серія ___ N ____________, який видано громадянину
    ///  _________________________________________________________________,
    ///                     (прізвище, ім'я та по батькові)
    ///  ______ внесено  відмітку  за  N  _____________ про наявність права
    ///   (дата)
    ///  здійснювати будь-які платежі без ідентифікаційного номера.
    /// ____________             ________________________________________
    ///   (дата)                           (ПІБ, посада, підпис)
    /// </summary>
    /// <see cref="http://www.uazakon.com/documents/date_4f/pg_imnkxj.htm"/>
    public class IPNRefusalRecordInfo
    {
        [DisplayName("Дата запису")]
        [Description("Дата внесення відповідного запису до паспорта")]
        public DateTime RecordDate { get; set; }
        [DisplayName("№ запису")]
        [Description("№ відповідного запису до паспорта")]
        public string RecordID { get; set; }
        [DisplayName("Відомості про підписанта запису")]
        [Description("Відомості про підписанта запису")]
        public SignatoryInfo Signatory { get; set; }
    }
}
