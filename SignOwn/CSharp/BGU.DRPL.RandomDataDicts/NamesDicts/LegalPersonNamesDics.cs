using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BGU.DRPL.RandomDataDicts
{
    public class LegalPersonNamesDics : StringNamesDictBase
    {
        private static readonly List<string> LE_PREFIXES;

        static LegalPersonNamesDics()
        {
            #region prefixes
            LE_PREFIXES = new List<string>();
            LE_PREFIXES.Add("ПП");
            LE_PREFIXES.Add("МПП");
            LE_PREFIXES.Add("ВАТ");
            LE_PREFIXES.Add("ЗАТ");
            LE_PREFIXES.Add("ПАТ");
            LE_PREFIXES.Add("НДП");
            LE_PREFIXES.Add("ТОВ");
            LE_PREFIXES.Add("ТзОВ");
            LE_PREFIXES.Add("ВКФ");
            LE_PREFIXES.Add("ТД");
            LE_PREFIXES.Add("ДП");
            LE_PREFIXES.Add("НВП");
            LE_PREFIXES.Add("НВФ");
            LE_PREFIXES.Add("КП");
            #endregion


        }
        protected override List<string> GenerateNames()
        {
            throw new NotImplementedException();
        }
    }
}
