using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;

namespace BGU.DRPL.SignificantOwnership.Core.Questionnaires
{
    /// <summary>
    /// ТАБЛИЦЯ формування статутного капіталу
    /// Додаток 6 до Положення про порядок реєстрації та ліцензування банків, відкриття відокремлених підрозділів
    /// file                                  : f364524n1228.doc
    /// Рівень складності                     : 2
    /// (оціночний, шкала від 1 до 10)
    /// Пріоритетність                        : Hi  (Легенда: Hi - Висока, Lo - Низька, Mid - Середня, Hold - Поки що притримати)
    /// Подавач анкети                        : BK (Легенда: LP - юр.особа, PP - фіз.особа, BK - банк)
    /// Чи заповнюватиметься он-лайн          : Під питанням
    /// Первинну розробку структури завершено : Ні
    /// Структуру фіналізовано                : Ні
    /// (=остаточно узгоджено 
    /// з бізнес-користувачами)
    /// </summary>
    public class RegLicAppx6EquityFormationTable : IQuestionnaire
    {
        public BankInfo BankRef { get; set; }

        public DateTime AsOfDate { get; set; }

        public CurrencyAmount CharterCapital { get; set; }
        public List<CharterCapitalTableRecord> ShareholderStakes { get; set; }
        public CharterCapitalTableTotalsRecord LegalPersonsSubtotals { get; set; }
        public CharterCapitalTableTotalsRecord PhysPersonsSubtotals { get; set; }
        public CharterCapitalTableTotalsRecord Totals { get; set; }

        public List<GenericPersonInfo> MentionedIdentities { get; set; }

        public SignatoryInfo CEOSignature { get; set; }
        public SignatoryInfo ChiefBookkeeperSignature { get; set; }


        public string SuggestSaveAsFileName()
        {
            return "regLicDod6ChartCapFormTbl";
        }
    }
}
