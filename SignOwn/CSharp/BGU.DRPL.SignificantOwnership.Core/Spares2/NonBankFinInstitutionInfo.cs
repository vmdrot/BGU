using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;

namespace BGU.DRPL.SignificantOwnership.Core.Spares2
{
    public class NonBankFinInstitutionRawInfo
    {
        [DisplayName("Внутрішній код")]
        public int InternalCode { get; set; }
        [DisplayName("Номер ліцензії")]
        public int LicenseNr { get; set; }
        [DisplayName("Номер редакції ліцензії")]
        public int LicenseRevNr { get; set; }
        [DisplayName("Код родительского запису")]
        public int ParentRecordId { get; set; }
        [DisplayName("Стан ліцензії")]
        public char LicenseState { get; set; }
        [DisplayName("Дата видачі/початку строку дії ліцензії")]
        public DateTime LicenseIssueDate { get; set; }
        [DisplayName("Дата завершення строку дії ліцензії")]
        public DateTime? LicenseValidThruDate { get; set; }
        [DisplayName("Дата змін")]
        public DateTime? LicenseChangeDate { get; set; }
        [DisplayName("Дата анулювання")]
        public DateTime? LicenseAnnulledDate { get; set; }
        [DisplayName("Власник ліцензії")]
        public string LicenseOwner { get; set; }
        [DisplayName("Країна власника")]
        public string LicenseOwnerCountryISONr { get; set; }
        [DisplayName("Область власника")]
        public int LicenseOwnerOblast { get; set; }
        [DisplayName("Район власника")]
        public string LicenseOwnerRaion { get; set; }
        [DisplayName("Нас. пункт власника")]
        public string LicenseOwnerCity { get; set; }
        [DisplayName("Адреса власника")]
        public string LicenseOwnerAddress { get; set; }
        [DisplayName("Код ЄДРПОУ")]
        public string LicenseOwnerTaxCode { get; set; }
        [DisplayName("ТУ, в якому видано ліцензію")]
        public int LicenseIssuingTUId { get; set; }
        [DisplayName("ТУ, в якому введено ліцензію")]
        public int LicenseInputTUId { get; set; }
        [DisplayName("Ідентифікатор виконавця")]
        public int InputOfficerId { get; set; }
        [DisplayName("ТУ видачі ліцензії")]
        public string LicenseIssuingTUName { get; set; }
        [DisplayName("ТУ внесення ліцензії до БД")]
        public string LicenseInputTUName { get; set; }
        [DisplayName("Країна власника")]
        public string OwnerCountryName { get; set; }
        [DisplayName("Область власника")]
        public string OwnerOblastName { get; set; }
        [DisplayName("ПІБ виконавця Операції")]
        public string InputOfficerName { get; set; }
        [DisplayName("Операції")]
        public string Operations { get; set; }
        [DisplayName("Обслуговуючий банк")]
        public string ServicingBank { get; set; }
        [DisplayName("№ рахунку")]
        public string AccountNr { get; set; }
    }
}
