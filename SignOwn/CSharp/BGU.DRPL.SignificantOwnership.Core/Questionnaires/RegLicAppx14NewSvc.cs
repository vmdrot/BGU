using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.Questionnaires
{
    /// <summary>
    /// ПОВІДОМЛЕННЯ банку про початок нового виду діяльності або надання нового виду фінансових послуг
    /// Додаток 14 до Положення про порядок реєстрації та ліцензування банків, відкриття відокремлених підрозділів
    /// file                                  : f364524n1035.doc
    /// Рівень складності                     : 3
    /// (оціночний, шкала від 1 до 10)
    /// Пріоритетність                        : Hi  (Легенда: Hi - Висока, Lo - Низька, Mid - Середня, Hold - Поки що притримати)
    /// Подавач анкети                        : BK (Легенда: LP - юр.особа, PP - фіз.особа, BK - банк)
    /// Чи заповнюватиметься он-лайн          : Під питанням
    /// Первинну розробку структури завершено : Так
    /// Структуру фіналізовано                : Ні
    /// (=остаточно узгоджено 
    /// з бізнес-користувачами)
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.RegLicAppx14NewSvc_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class RegLicAppx14NewSvc : QuestionnaireBase
    {
        public RegLicAppx14NewSvc()
        {
            NewActivitiesList = new List<BankingLicensedActivityInfo>();
            Attachements = new List<AttachmentInfo>();
        }
        [DisplayName("Дата заявки")]
        [Description("Дата")]
        [Required]
        public DateTime QuestDate { get; set; }
        [DisplayName("№ (Ваш висх.)")]
        [Description("номер")]
        public string Ref { get; set; }
        
        /// <summary>
        /// Тільки укр. банки, лише головні
        /// </summary>
        [DisplayName("Банк (назва та ін. реквізити)")]
        [Description("Ідентифікація банку, що подає заявку")]
        [Required]
        public BankInfo BankRef { get; set; }
        [DisplayName("Діюча банківська ліцензія (реквізити)")]
        [Description("має  банківську ліцензію")]
        [Required]
        public BankingLicenseInfo ExistingLicenseSpecs { get; set; }
        /// <summary>
        /// Контрол для заповнення - два listbox-а, drag у один listbox
        /// </summary>
        [DisplayName("Перелік нових видів фінпослуг")]
        [Description("перелік нових видів діяльності або нових видів фінансових послуг")]
        [Required]
        public List<BankingLicensedActivityInfo> NewActivitiesList { get; set; }
        [DisplayName("Фінансові можливості наявні?")]
        [Description("Банк має достатні фінансові  можливості  для  початку  нового виду діяльності та/або виду фінансових послуг,  зазначених у цьому повідомленні")]
        [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.BooleanEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Required]
        public bool HasSufficientFinancialCapacity { get; set; }
        [DisplayName("Тривалість беззбиткового періоду (міс.)")]
        [Description("Банк не має збитків протягом останніх ... місяців")]
        [Required]
        public int MonthsWOLosses { get; set; }
        [DisplayName("Формування фондів та резервів відповідає/не відповідає...?")]
        [Description("Банк сформував фонди та резерви відповідно до вимог законодавства України, у тому числі нормативно-правових актів Національного банку України")]
        [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.BooleanEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Required]
        public bool HasFormedEnoughFundsAndReserves { get; set; }
        [DisplayName("Тривалість дотримування нормативів обов'язвкового резервування (міс.)")]
        [Description("Банк дотримується нормативу обов'язкового резервування протягом останніх ... місяців")]
        [Required]
        public int MonthsObligatoryReservesMet { get; set; }
        [DisplayName("Тривалість дотримування економічних нормативів (міс.)")]
        [Description("Банк дотримується економічних нормативів протягом останніх ... місяців")]
        [Required]
        public int MonthsEconomicNormativesReqsMet { get; set; }
        [DisplayName("Регулятивного капіталу достатньо (так/ні)?")]
        [Description("Рівень регулятивного капіталу Банку відповідає вимогам Національного банку України")]
        [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.BooleanEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Required]
        public bool IsRegulatoryCapitalReqsMet { get; set; }
        [DisplayName("Розміри регулятивного капіталу (грн.)")]
        [Description("Рівень регулятивного капіталу Банку становить ... грн.")]
        [Required]
        public decimal RegulatoryCapitalAmt { get; set; }
        [DisplayName("Дата розмірів регулятивного капіталу")]
        [Description("Дата, на яку подано рівень регулятивного капіталу Банку (вище)")]
        [Required]
        public DateTime RegulatoryCapitalDate { get; set; }
        [DisplayName("Відсутність заходів упливу")]
        [Description("Банк не є об'єктом застосування заходів впливу (крім письмового застереження) упродовж останніх 3 місяців, причому:\nпротягом усього періоду діяльності - для банків, які отримали банківську ліцензію менше ніж за три місяці до часу повідомлення Національного банку України про початок нового виду діяльності та/або виду послуг;\nпротягом трьох місяців, що передують часу повідомлення Національного банку України про початок нового виду діяльності та/або виду послуг - для банків, які здійснюють банківську діяльність на підставі банківської ліцензії більше ніж три місяці.")]
        [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.BooleanEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Required]
        public bool NoPenaltiesWithinLast3Months { get; set; }
        [DisplayName("Забезпеченість відповідним персоналом та структурою")]
        [Description("У Банку створено відповідні підрозділи, що здійснюватимуть зазначений в повідомленні новий вид діяльності та/або вид фінансових послуг, а також підрозділ внутрішнього аудиту та підрозділ з управління ризиками, функції та повноваження яких відповідають вимогам Закону України \"Про банки і банківську діяльність\" та нормативно-правових актів Національного банку України. Банк забезпечений спеціалістами, які відповідають вимогам нормативно-правових актів Національного банку України. Відповідні відомості додаються.")]
        [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.BooleanEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Required]
        public bool HasDeptsAllocatedForNewBusLines { get; set; }
        [DisplayName("Забезпеченість відповідним обладнанням, технікою, ПЗ, тощо")]
        [Description("Банк забезпечений належним банківським обладнанням, комп'ютерною технікою, програмним забезпеченням та комунікаційними засобами, що відповідають вимогам Національного банку України")]
        [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.BooleanEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Required]
        public bool HasFacilitiesForNewBusLines { get; set; }
        [DisplayName("Дотримано вимог законодавства")]
        [Description("Банком виконано спеціальні вимоги законодавства України, у тому числі нормативно-правових актів Національного банку України, щодо нового виду діяльності та/або нового виду фінансових послуг")]
        [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.BooleanEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Required]
        public bool IsGenericLawReqsMetForNewBusLines { get; set; }
        [DisplayName("Готові розпочати новий вид діяльності?")]
        [Description("Банк готовий розпочати новий вид діяльності та/або вид фінансових послуг згідно з вимогами банківського законодавства України, нормативно-правових актів Національного банку України")]
        [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.BooleanEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Required]
        public bool IsBankIndustrySpecificLawReqsMetForNewBusLines { get; set; }
        [DisplayName("Нову діяльність зазначено в статуті?")]
        [Description("Здійснення нових видів діяльності/надання нових фінансових послуг зазначено в статуті банку.")]
        [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.BooleanEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Required]
        public bool IsNewBusLinesPresentInCharter { get; set; }
        [DisplayName("Наявність внутрішніх положень, що регламентують нову діяльність - є/немає?")]
        [Description("Копії внутрішніх положень, що регулюють здійснення банком нових видів діяльності або надання нового виду фінансових  послуг, додаються")]
        [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.BooleanEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Required]
        public bool IsInternalRegulationCopiesAttachedForNewBusLines { get; set; }
        [DisplayName("Я персонально відповідаю за достовірність поданої інформації?")]
        [Description("Я несу персональну відповідальність за достовірність усіх поданих документів")]
        [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.BooleanEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Required]
        public bool IsSigneePersonallyLiableForCopiesAttached { get; set; }
        [DisplayName("Контакти")]
        [Description("У разі виникнення будь-яких питань щодо цього повідомлення або документів, що додаються до нього, прошу звертатися до (прізвище, адреса, номер телефону, факсу)")]
        [Required]
        public ContactInfo Contacts { get; set; }
        [DisplayName("Додатки")]
        [Description("Додатки")]
        [Required]
        public List<AttachmentInfo> Attachements { get; set; }
        [DisplayName("Підписант")]
        [Description("Інформація про підписанта (Голова правління Банку)")]
        [Required]
        public SignatoryInfo Signee { get; set; }

        protected override string QuestionnairePrefixForFileName
        {
            get { return "regLicDod14NoviPoslugy"; }
        }

        protected override string BankNameForFileName
        {
            get { return GetBankNameForFileName(this.BankRef); }
        }

        protected override string ApplicantNameForFileName
        {
            get { return string.Empty; }
        }

        protected override void DoAddToMentionedEntities(GenericPersonInfo gpi)
        {
            //todo
        }
    }
}
