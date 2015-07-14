using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;
using System.Xml.Serialization;

namespace BGU.DRPL.SignificantOwnership.Core.Questionnaires
{
    /// <summary>
    /// АНКЕТА юридичної особи (у тому числі банку)
    /// Додаток 2 до Положення про порядок подання відомостей про структуру власності
    /// file                                  : f364553n172.doc
    /// Рівень складності                     : 7
    /// (оціночний, шкала від 1 до 10)
    /// Пріоритетність                        : Lo  (Легенда: Hi - Висока, Lo - Низька, Mid - Середня, Hold - Поки що притримати)
    /// Подавач анкети                        : LP (Легенда: LP - юр.особа, PP - фіз.особа, BK - банк)
    /// Чи заповнюватиметься он-лайн          : Так
    /// Первинну розробку структури завершено : Так
    /// Структуру фіналізовано                : Ні
    /// (=остаточно узгоджено 
    /// з бізнес-користувачами)
    /// </summary>
    [Obsolete]
    [Description("АНКЕТА юридичної особи (у тому числі банку),Додаток 2 до Положення про порядок подання відомостей про структуру власності")]
    [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.Appx2OwnershipStructLP_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class Appx2OwnershipStructLP : QuestionnaireBase, IGenericPersonsService, IAddressesService
    {

        public Appx2OwnershipStructLP()
        {
            SupervisoryCouncil = new CouncilBodyInfo();
            this.Executives = new CouncilBodyInfo();
            this.BankExistingCommonImplicitOwners = new List<OwnershipStructure>();
            this.SharesAppliedFor = new List<PurchasedVoteInfo>();
            this.ApplicantOwnershipStructure = new List<OwnershipStructure>();
            this.MentionedIdentities = new List<GenericPersonInfo>();
            this.PersonsLinks = new List<PersonsAssociation>();
        }

        /// <summary>
        /// Ідентифікація банку
        /// Лише укр. банки, лише головні контори, крім НБУ і всіх ТРУ
        /// </summary>
        [Required]
        [Description("Банк")]
        [DisplayName("Банк")]
        public BankInfo BankRef { get; set; }
        
        /// <summary>
        /// p.1.1 , p.1.2 , p.1.3 , p.1.6
        /// якнайповніше заповнення
        /// </summary>
        [DisplayName("Юр.особа-заявник")]
        [Description("1. Інформація про юридичну особу")]
        [Required]
        public GenericPersonID Acquiree { get; set; }

        /// <summary>
        /// p.1.4
        /// Чекбокс, щоб вказати, що її не існує (не передбачено), цього органу
        /// </summary>
        [Browsable(true)]
        [DisplayName("Наглядова (спостережна) рада юридичної особи?")]
        [Description("1.4. Чи існує наглядова (спостережна) рада юридичної особи")]
        [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.BooleanEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Required]
        public bool IsSupervisoryCouncilPresent { get; set; }

        /// <summary>
        /// тільки якщо IsSupervisoryCouncilPresent == true
        /// </summary>
        [Browsable(true)]
        [DisplayName("Особовий склад наглядової(спостережної)ради юрособи")]
        [Description("1.4. Голова та члени наглядової (спостережної) ради юридичної особи")]
        public CouncilBodyInfo SupervisoryCouncil { get; set; }
        
        /// <summary>
        /// p.1.5
        /// Чекбокс, щоб вказати, що її не існує (не передбачено), цього органу
        /// </summary>
        [Browsable(true)]
        [DisplayName("Виконавчий орган юридичної особи?")]
        [Description("1.4. Чи існує виконавчий орган юридичної особи")]
        [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.BooleanEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Required]
        public bool IsExecutivesPresent { get; set; }

        /// <summary>
        /// тільки якщо IsExecutivesPresent == true
        /// </summary>
        [Browsable(true)]
        [DisplayName("Особовий склад виконавчого органу юрособи")]
        [Description("1.5. Голова та члени виконавчого органу юридичної особи")]
        [Required]
        public CouncilBodyInfo Executives { get; set; }
        
        /// <summary>
        /// p.1.7
        /// обов'язкове поле
        /// </summary>
        [Required]
        [DisplayName("% власності юрособи у капіталі банку")]
        [Description("1.7. Відсоток участі в банку становить ... відсотків статутного капіталу банку")]
        public decimal TotalOwneshipPct { get; set; }
        
        /// <summary>
        /// Агреговане резюме власності (прямої, опосередкованої)
        /// обов'язкове поле
        /// </summary>
        [DisplayName("Частка власності юрособи в банку - розподіл")]
        [Description("1.7. Відсоток участі в банку становить, у т.ч.:")]
        [Required]
        public TotalOwnershipDetailsInfo TotalOwneshipDetails { get; set; } //todo - how many rows

        /// <summary>
        /// p.1.8
        /// Ця структура потім має розгорнутися у дерево,
        /// як його можна відприти в живому прототипі - Зразки -> Положення про порядок... структуру -> Анкета ... (Додаток 2) -> Грант 
        /// => і там п. меню Більше... -> Кінцеві власники
        ///                               Граф власності
        /// </summary>
        [DisplayName("Розшифровка ланцюжка власників банку")]
        [Description("1.8. Інформація про спільне володіння (=розкриття усього ланцюжка власників, у т.ч. й пов'язаних юросіб)")]
        [Required]
        public List<OwnershipStructure> BankExistingCommonImplicitOwners { get; set; }

        /// <summary>
        /// обов'язкове
        /// p.1.10
        /// </summary>
        [DisplayName("Частка власності, що набувається")]
        [Description("1.10. Інформація про набуття права голосу")]
        [Required]
        public List<PurchasedVoteInfo> SharesAppliedFor { get; set; }

        /// <summary>
        /// p.2.1
        /// Якщо цю інформацію не розкрито в полі BankExistingCommonImplicitOwners
        /// (як правило, таке трапляється коли набувач доти не мав жодних часток у банку
        /// </summary>
        [DisplayName("Розшифровка ланцюжка власників юрособи-набувача")]
        [Description("2.1. Інформація про осіб (юр. і фіз.), які володіють істотною участю в юридичній особі\n(якщо не було розкрито у п.1.8.)")]
        public List<OwnershipStructure> ApplicantOwnershipStructure { get; set; }

        /// <summary>
        /// Внутрішнє, службове поле.
        /// Для користувача заповнення інформації про кожну 
        /// з осіб-фігурантів має відбуватися у тому місці, 
        /// де ця особа фігурує: у полях BankRef, 
        /// BankExistingCommonImplicitOwners, ApplicantOwnershipStructure, тощо).
        /// </summary>
        [DisplayName("Реквізити осіб-фігурантів анкети")]
        [Description("Повна інформація про осіб, що згадуються в анкеті")]
        [Required]
        public List<GenericPersonInfo> MentionedIdentities { get; set; }

        /// <summary>
        /// Бачу сенс вводити це поле окремо і явно;
        /// у перспективі, запровадити попередню перевірку на 
        /// наявність однофамільців серед фігурантів і "торбити"
        /// заповнювача, що там 100% є пов'язані особи, мовляв, не хочете їх ідентифікувати.
        /// Якщо немає пов'язаних осіб - не обов'язкове
        /// </summary>
        [DisplayName("Зв'язки між особами-фігурантами анкети")]
        [Description("Відомості про пов'язаних осіб, що згадуються в анкеті")]
        public List<PersonsAssociation> PersonsLinks { get; set; }
        /// <summary>
        /// Усі поля обов'язкові
        /// </summary>
        [DisplayName("Підписант")]
        [Description("Відомості по особу, що підписала анкету")]
        [Required]
        public SignatoryInfo Signatory { get; set; }
        /// <summary>
        /// Обов'язково бодай один тел. і один e-mail, решта - необов'язкові
        /// </summary>
        [DisplayName("Контакти")]
        [Description("Контактні дані відправника анкети")]
        [Required]
        public ContactInfo ContactPerson { get; set; }

        [Browsable(false)]
        [XmlIgnore]
        public IEnumerable<GenericPersonInfo> MentionedGenericPersons
        {
            get 
            {
                Dictionary<string, GenericPersonInfo> rslt = new Dictionary<string, GenericPersonInfo>();
                //if (BankRef != null && BankRef.LegalPerson != null)
                //{
                //    GenericPersonInfo gpi = new GenericPersonInfo(BankRef.LegalPerson);
                //    rslt.Add(gpi.ID.HashID, gpi);
                //}

                //if (Acquiree != null)
                //{
                //    GenericPersonInfo gpi = new GenericPersonInfo(Acquiree);
                //    rslt.Add(gpi.ID.HashID, gpi);
                //}

                foreach (GenericPersonInfo gpi in MentionedIdentities)
                {
                    if (gpi != null && gpi.ID != null && !rslt.ContainsKey(gpi.ID.HashID))
                        rslt.Add(gpi.ID.HashID, gpi);
                }

                if (ContactPerson != null && ContactPerson.Person != null && !rslt.ContainsKey(ContactPerson.Person.GenericID.HashID))
                {
                    rslt.Add(ContactPerson.Person.GenericID.HashID, new GenericPersonInfo(ContactPerson.Person));
                }
                return new List<GenericPersonInfo>(rslt.Values);
            } 
        }

        [Browsable(false)]
        [XmlIgnore]
        public IEnumerable<LocationInfo> MentionedAddresses
        {
            get 
            {
                Dictionary<string, LocationInfo> rslt = new Dictionary<string, LocationInfo>();

                //if (BankRef != null && BankRef.LegalPerson != null && BankRef.LegalPerson.Address != null && !rslt.ContainsKey(BankRef.LegalPerson.Address.ToString()))
                //    rslt.Add(BankRef.LegalPerson.Address.ToString(), BankRef.LegalPerson.Address);
                //if (Acquiree != null && Acquiree.Address != null && !rslt.ContainsKey(Acquiree.Address.ToString()))
                //    rslt.Add(Acquiree.Address.ToString(), Acquiree.Address);
                foreach(GenericPersonInfo gpi in MentionedIdentities)
                {
                    if(gpi.Address != null && !rslt.ContainsKey(gpi.Address.ToString()))
                        rslt.Add(gpi.Address.ToString(), gpi.Address);
                }

                return new List<LocationInfo>(rslt.Values);
            }
        }


        protected override string QuestionnairePrefixForFileName
        {
            get { return "strvlasnDod2YO"; }
        }

        protected override string BankNameForFileName
        {
            get { return GetBankNameForFileName(BankRef); }
        }

        protected override string ApplicantNameForFileName
        {
            get { if (Acquiree == null) return string.Empty; return Acquiree.PersonCode; }
        }


        public void RefreshGenericPersonsDisplayNames()
        {
            throw new NotImplementedException();
        }

        protected override void DoAddToMentionedEntities(GenericPersonInfo gpi)
        {
            MentionedIdentities.Add(gpi);
        }
    }
}
