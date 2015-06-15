using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BGU.DRPL.SignificantOwnership.Core.Questionnaires
{
    /// <summary>
    /// АНКЕТА фізичної особи
    /// Додаток 3 до Положення про порядок подання відомостей про структуру власності
    /// file                                  : f364553n173.doc
    /// Рівень складності                     : 6
    /// (оціночний, шкала від 1 до 10)
    /// Пріоритетність                        : Lo  (Легенда: Hi - Висока, Lo - Низька, Mid - Середня, Hold - Поки що притримати)
    /// Подавач анкети                        : PP (Легенда: LP - юр.особа, PP - фіз.особа, BK - банк)
    /// Чи заповнюватиметься он-лайн          : Так
    /// Первинну розробку структури завершено : Ні
    /// Структуру фіналізовано                : Ні
    /// (=остаточно узгоджено 
    /// з бізнес-користувачами)
    /// </summary>
    [Obsolete]
    public class Appx3OwnershipStructPP : IQuestionnaire
    {
        public string SuggestSaveAsFileName()
        {
            throw new NotImplementedException();
        }
    }
}
