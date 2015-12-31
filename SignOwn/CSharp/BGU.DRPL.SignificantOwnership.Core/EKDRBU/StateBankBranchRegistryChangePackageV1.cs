using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;
using BGU.DRPL.SignificantOwnership.Core.EKDRBU.Spares;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;
using BGU.DRPL.SignificantOwnership.Core.Spares;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;
using System.Xml.Serialization;

namespace BGU.DRPL.SignificantOwnership.Core.EKDRBU
{
    /// <summary>
    /// Електронний аналог додатку 15
    /// (для першого, проміжного варіанту,
    /// з мінімальними змінами відносно класичного (чинного), паперового
    /// формату)
    /// </summary>
    public class StateBankBranchRegistryChangePackageV1 : NotifyPropertyChangedBase
    {
        private BankInfo _BankRef;
        /// <summary>
        /// Заповнювати лише наступні поля для ідентифікації банку:
        /// Головне МФО
        /// Назва
        /// </summary>
        [DisplayName("Банк-подавач")]
        [Description("Ідентифікація головного банку-подавача")]
        [Required]
        public BankInfo BankRef { get { return _BankRef; } set { _BankRef = value; OnPropertyChanged("BankRef"); } }

        private string _PackageID;
        [DisplayName("№ пакету")]
        [Description("Вихідний номер документу, за яким пакет дійшов до НБУ та на котрий слід посилатися в усій подальшій комунікації з цього приводу")]
        [Required]
        public string PackageID { get { return _PackageID; } set { _PackageID = value; OnPropertyChanged("PackageID"); } }

        private DateTime _PackageDate;
        [DisplayName("Дата подачі пакету")]
        [Description("Дата вихідного документу, яким було оформлено пакет\nЯкщо не вказано, то ця ж дата використовується як дата підпису, і т.д.")]
        [Required]
        public DateTime PackageDate { get { return _PackageDate; } set { _PackageDate = value; OnPropertyChanged("PackageDate"); } }

        private EKDRBUPackageType _PackageType;
        [DisplayName("Тип повідомлення")]
        [Description("Тип повідомлення - нормальне (звичайне) повідомлення\n про зміни/відкриття/закриття/тощо,\n чи уточнення/скасування попередньо поданого пакету")]
        public EKDRBUPackageType PackageType { get { return _PackageType; } set { _PackageType = value; OnPropertyChanged("PackageType"); } }

        [XmlIgnore]
        public bool IsErrorCorrectionOrCancellation { get { return PackageType == EKDRBUPackageType.ErrorCorrection || PackageType == EKDRBUPackageType.Cancellation; } }

        private string _RelPackageRef;
        /// <summary>
        /// Поле заповнюється, якщо Тип повідомлення = уточнення/скасування попередньо поданого пакету
        /// </summary>
        [DisplayName("№ основного пакету")]
        [Description("№ основного пакету, до якого подаються виправлення/уточнення/скасування")]
        [Required("IsErrorCorrectionOrCancellation")]
        public string RelPackageRef { get { return _RelPackageRef; } set { _RelPackageRef = value; OnPropertyChanged("RelPackageRef"); } }

        private DateTime? _RelPackageDate;
        /// <summary>
        /// Поле заповнюється, якщо Тип повідомлення = уточнення/скасування попередньо поданого пакету
        /// </summary>
        [DisplayName("Дата основного пакету")]
        [Description("Дата основного пакету, до якого подаються виправлення/уточнення/скасування")]
        [Required("IsErrorCorrectionOrCancellation")]
        public DateTime? RelPackageDate { get { return _RelPackageDate; } set { _RelPackageDate = value; OnPropertyChanged("RelPackageDate"); } }

        private bool _AllowPartialFails;
        /// <summary>
        /// При обробці пакету можуть виникнути помилки валідації;
        /// Ця галочка визначає, як обробляти ці помилки - 
        /// чи відбраковувати пакет повністю, чи ж припускається 
        /// ситуація, коли зміни по частині відділень відбраковуються, 
        /// але по тій частині, що не містить помилок, приймаються в обробку.
        /// </summary>
        [DisplayName("Дозволити часткове відбракування")]
        [Description("У випадку помилок при обробці одного чи більше відділень у пакеті, намагатися продовжити обробку решти частини пакету (все одно)")]
        [Required]
        public bool AllowPartialFails { get { return _AllowPartialFails; } set { _AllowPartialFails = value; OnPropertyChanged("AllowPartialFails"); } }

        private List<StateBankRegistrySingleBranchChangeRecV1> _ChangingBranches;
        [DisplayName("Пакет змін")]
        [Description("Відомості про змінну частину реквізитів відокремлених підрозділів, що становить цей пакет")]
        [Required]
        public List<StateBankRegistrySingleBranchChangeRecV1> ChangingBranches { get { return _ChangingBranches; } set { _ChangingBranches = value; OnPropertyChanged("ChangingBranches"); } }

        private List<BankBranchOpsSvcsSchemeInfo> _OperationsListingSchemes;
        [DisplayName("Схеми переліку операцій")]
        [Description("Значення поля Перелік та обсяги операцій відокремлених підрозділів")]
        public List<BankBranchOpsSvcsSchemeInfo> OperationsListingSchemes { get { return _OperationsListingSchemes; } set { _OperationsListingSchemes = value; OnPropertyChanged("OperationsListingSchemes"); } }
        
        private List<AttachmentInfo> _Attachments;
        [DisplayName("Додатки")]
        [Description("Документи-додатки (рішення, долучення, копії, тощо)")]
        [Required]
        public List<AttachmentInfo> Attachments { get { return _Attachments; } set { _Attachments = value; OnPropertyChanged("Attachments"); } }
        
        private bool _RequirementsKept;
        [DisplayName("Підтверджуємо відповідність?")]
        [Description("Банк підтверджує відповідність відокремленого підрозділу банку вимогам,\n установленим Законом України \"Про банки і банківську діяльність\" та \nнормативно-правовими актами Національного банку України,\n у тому числі щодо приміщення, обладнання, придатності та ділової репутації\n керівників відокремленого підрозділу (виконуючих їх обов'язки)")]
        [Required]
        public bool RequirementsKept { get { return _RequirementsKept; } set { _RequirementsKept = value; OnPropertyChanged("RequirementsKept"); } }

        private string _RequirementsKeptDetails;
        [DisplayName("Деталі відповідності вимогам")]
        [Description("Банк підтверджує (у деталях) відповідність відокремленого підрозділу банку вимогам,\n установленим Законом України \"Про банки і банківську діяльність\" та \nнормативно-правовими актами Національного банку України,\n у тому числі щодо приміщення, обладнання, придатності та ділової репутації\n керівників відокремленого підрозділу (виконуючих їх обов'язки)")]
        [UIUsageTextBox(HorizontalAlignment = "Left", IsMultiline = true, MinWidth = "450", MaxWidth = "650")]
        [Required]
        public string RequirementsKeptDetails { get { return _RequirementsKeptDetails; } set { _RequirementsKeptDetails = value; OnPropertyChanged("RequirementsKeptDetails"); } }

        private SignatoryInfoBase _Signor;
        /// <summary>
        /// Примітки:
        /// Дата підпису - необов'язкова, за її 
        /// відсутності презюмується дата подачі пакету
        /// </summary>
        [DisplayName("Підписант")]
        [Description("Реквізити підпису")]
        [Required]
        public SignatoryInfoBase Signor { get { return _Signor; } set { _Signor = value; OnPropertyChanged("Signor"); } }

        private ContactInfoSimple _PreparedBy;
        /// <summary>
        /// У полі Person достатньо вказати прізвище й ініціали в під-полі FullName
        /// Як правило, вказують телефон (1 запис у колекції Phones, під-поле PhoneNr
        /// Слід заохочувати вказувати e-mail (колекція Emails) та мобільний телефон (ще один запис у колекції Phones)
        /// </summary>
        [DisplayName("Виконавець")]
        [Description("Особа, що значиться як виконавець на супровідному листі до пакету")]
        [Required]
        public ContactInfoSimple PreparedBy { get { return _PreparedBy; } set { _PreparedBy = value; OnPropertyChanged("PreparedBy"); } }

    }
}
