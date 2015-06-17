using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BGU.DRPL.SignificantOwnership.Core.Questionnaires
{
    /// <summary>
    /// КЛОПОТАННЯ про надання банківської ліцензії та реєстрацію банку
    /// Додаток 9 до Положення про порядок реєстрації та ліцензування банків, відкриття відокремлених підрозділів
    /// file                                  : f364524n1229.doc
    /// Рівень складності                     : 4
    /// (оціночний, шкала від 1 до 10)
    /// Пріоритетність                        : Lo  (Легенда: Hi - Висока, Lo - Низька, Mid - Середня, Hold - Поки що притримати)
    /// Подавач анкети                        : BK (Легенда: LP - юр.особа, PP - фіз.особа, BK - банк)
    /// Чи заповнюватиметься он-лайн          : Під питанням
    /// Первинну розробку структури завершено : Ні
    /// Структуру фіналізовано                : Ні
    /// (=остаточно узгоджено 
    /// з бізнес-користувачами)
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.RegLicAppx9BankingLicenseAppl_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class RegLicAppx9BankingLicenseAppl : IQuestionnaire
    {
        public string SuggestSaveAsFileName()
        {
            throw new NotImplementedException();
        }
    }
}
