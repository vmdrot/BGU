using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BGU.DRPL.SignificantOwnership.Core.Questionnaires
{
    /// <summary>
    /// ТАБЛИЦЯ збільшення (зменшення) статутного капіталу
    /// Додаток 17 до Положення про порядок реєстрації та ліцензування банків, відкриття відокремлених підрозділів
    /// file                                  : f364524n1226.doc
    /// Рівень складності                     : 5
    /// (оціночний, шкала від 1 до 10)
    /// Пріоритетність                        : Hi  (Легенда: Hi - Висока, Lo - Низька, Mid - Середня, Hold - Поки що притримати)
    /// Подавач анкети                        : BK (Легенда: LP - юр.особа, PP - фіз.особа, BK - банк)
    /// Чи заповнюватиметься он-лайн          : Під питанням
    /// Первинну розробку структури завершено : Ні
    /// Структуру фіналізовано                : Ні
    /// (=остаточно узгоджено 
    /// з бізнес-користувачами)
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.RegLicAppx17EquityChangeTable_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class RegLicAppx17EquityChangeTable : IQuestionnaire
    {
        public string SuggestSaveAsFileName()
        {
            throw new NotImplementedException();
        }
    }
}
