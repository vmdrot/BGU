using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;
using Evolvex.Utility.Core.ComponentModelEx;
using System.ComponentModel;

namespace BGU.DRPL.SignificantOwnership.Core.Questionnaires
{
    /// <summary>
    /// ПОВІДОМЛЕННЯ про наміри набуття/збільшення істотної участі в банку
    /// Додаток 7 до Положення про порядок реєстрації та ліцензування банків, відкриття відокремлених підрозділів
    /// file                                  : f364524n1027.doc
    /// Рівень складності                     : 5
    /// (оціночний, шкала від 1 до 10)
    /// Пріоритетність                        : Lo  (Легенда: Hi - Висока, Lo - Низька, Mid - Середня, Hold - Поки що притримати)
    /// Подавач анкети                        : LP;PP (Легенда: LP - юр.особа, PP - фіз.особа, BK - банк)
    /// Чи заповнюватиметься он-лайн          : Так
    /// Первинну розробку структури завершено : Ні
    /// Структуру фіналізовано                : Ні
    /// (=остаточно узгоджено 
    /// з бізнес-користувачами)
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.RegLicAppx7ShareAcqIntent_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class RegLicAppx7ShareAcqIntent : IQuestionnaire
    {
        public RegLicAppx7ShareAcqIntent()
        {
            ExistingOwnership = new List<OwnershipStructure>();
            MentionedIdentities = new List<GenericPersonInfo>();
            PersonsLinks = new List<PersonsAssociation>();
            this.TargetedOwnership = new List<OwnershipStructure>();
        }

        /// <summary>
        /// в ___________________________________________________
        /// (повне офіційне найменування банку, його місцезнаходження)
        /// </summary>
        [Description("Банк, у якому мається намір набути істотну участь")]
        [DisplayName("Банк")]
        [Required]
        public BankInfo BankRef { get; set; }

        /// <summary>
        /// 
        /// Прошу погодити _________________________________________________________________
        /// (найменування юридичної особи та/або прізвище, ім'я та по батькові фізичної особи,
        /// 
        /// </summary>
        [Description("Особа, що має намір придбати істотну участь")]
        [DisplayName("Заявник")]
        [Required]
        public GenericPersonID Acquiree { get; set; }

        /// <summary>
        /// Наявна на сьогоднішній день участь.
        /// Якщо участь набувається уперше - по 0-м.
        /// </summary>
        [Description("Наявна на сьогоднішній день участь істотна участь Заявника")]
        [DisplayName("Наявна істотна участь")]
        [Required]
        public TotalOwnershipDetailsInfo ExistingOwnershipSummary { get; set; }

        /// <summary>
        /// Розшифровка наявної на сьогоднішній день участі.
        /// Якщо участь набувається уперше - пуста колекція/масив.
        /// </summary>
        [Description("Ланцюжок існуючих власників істотної участі - як прямої, так і опосередкованої, що")]
        [DisplayName("Розшифровка існуючої істотної участі")]
        [Required]
        public List<OwnershipStructure> ExistingOwnership { get; set; }

        /// Прошу погодити _________________________________________________________________
        ///                                                                 (найменування юридичної особи та/або прізвище, ім'я та по батькові фізичної особи,
        /// ________________________________________________________________________________
        ///                                   яка прямо та/або опосередковано самостійно чи спільно з іншими особами володітиме істотною участю
        ///                                        в банку із зазначенням контролера /у разі його наявності) одноосібне/спільне набуття/збільшення
        ///                                                                істотної участі, (зазначити потрібне) (зазначити потрібне)
        [Description("Ланцюжок власників істотної участі - як прямої, так і опосередкованої, - що набувається")]
        [DisplayName("Розшифровка істотної участі, що набувається")]
        [Required]
        public List<OwnershipStructure> TargetedOwnership { get; set; }
        
        /// <summary>
        /// у результаті чого істотна участь становитиме ___ відсотків статутного капіталу банку, що становить _____________ гривень.
        /// </summary>
        [Description("у результаті чого істотна участь становитиме ___ відсотків статутного капіталу банку, що становить _____________ гривень.")]
        [DisplayName("Шукана (цільова) сумарна істотна участь Заявника")]
        [Required]
        public TotalOwnershipDetailsInfo TargetedOwnershipSummary { get; set; }



        /// <summary>
        /// Реквізити усіх осіб, чиї GenericID-и згадуються в полях Acquiree, 
        /// BankRef, ExistingOwnership, TargetedOwnership
        /// </summary>
        [Description("Реквізити усіх осіб, що згадуються в полях анкети")]
        [DisplayName("Повні реквізити фігурантів")]
        [Required]
        public List<GenericPersonInfo> MentionedIdentities { get; set; }

        /// <summary>
        /// Пуста колекція, якщо пов'язаних осіб серед фігурантів анкети немає.
        /// </summary>
        [Description("Укажіть зв'язки між особами фігурантами-анкети (якщо такі є)")]
        [DisplayName("Пов'язані особи-фігуранти анкети")]
        [Required]
        public List<PersonsAssociation> PersonsLinks { get; set; }

        /// <summary>
        /// Я, ________________________________________________________________________________,
        ///      (прізвище, ім'я, по батькові)
        /// стверджую, що інформація, надана в анкеті, є правдивою і повною, та не заперечую проти перевірки 
        /// Національним банком України достовірності поданих документів і персональних даних, що в них містяться.
        /// </summary>
        [DisplayName("Підтверджую правдивість інформації?")]
        [Description("Я, (прізвище, ім'я, по батькові) стверджую, що інформація,  надана в анкеті,\n є правдивою і повною, та не заперечую проти перевірки Національним банком України достовірності поданих документів і персональних даних, що в них містяться.\n")]
        [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.BooleanEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Required]
        public bool IsApplicationInfoAccurateAndTrue { get; set; }


        /// У разі будь-яких змін в інформації, що зазначена в цій анкеті, зобов'язуюся повідомити про них Національний банк України протягом 10-ти днів з дня їх виникнення.
        [DisplayName("Зобов'язуюсь повідомляти про зміни?")]
        [Description("У разі будь-яких змін в інформації, що зазначена в цій анкеті, зобов'язуюся повідомити про них Національний банк України протягом 10-ти днів з дня їх виникнення.")]
        [Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.BooleanEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Required]
        public bool AmObligingToKeepUp2DateWithin10Days { get; set; }


        /// <summary>
        /// Керівник юридичної особи    __________________
        /// (підпис)
        /// М.П.
        ///  ________________________
        /// (ініціали, прізвище)
        /// Фізична особа ___________________________________________________________________
        ///  (підпис, засвідчений нотаріально, ініціали, прізвище)
        /// Дата _________________
        /// </summary>
        [Required]
        public SignatoryInfo Signee { get; set; }


        public string SuggestSaveAsFileName()
        {
            return "regLicDod7NamirNab";
        }
    }
}
