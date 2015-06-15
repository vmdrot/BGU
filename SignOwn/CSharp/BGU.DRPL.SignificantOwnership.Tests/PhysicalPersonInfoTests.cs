using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;
using Newtonsoft.Json;

namespace BGU.DRPL.SignificantOwnership.Tests
{
    [TestFixture]
    public class PhysicalPersonInfoTests
    {
        [Test]
        public void ParseDateTest()
        {
            DateTime dt = DateTime.Parse("15.10.1996р.");
            Console.WriteLine(dt);
        }

        [Test]
        public void ParseFillPassIssueData1()
        {
            string raw = @"МК 694952,вид.Фрунзенським РВ ХМУ УМВСУ в Харківській обл. 15.10.1996р.
МК 809348, вид.Комінтернівським РВ ХМУ УМВСУ в Харківській обл. 25.03.1998р.
МК 932068, вид.ЦВМ Дзержинського РВ ХМУ УМВСУ в Харківській обл.11.09.1998р.
МК 480110, вид.Київським МВРВ ХМУ УМВСУ в Харківській обл. 16.04.1997р.
МК 524005, вид.Харківським РВ УМВСУ в Харківській обл.25.07.1997р.
Свід. про народж.Серія 1-ВЛ № 192526, видане Відділом РАГС Жовтневого р-ну управління юстиції м.Харкова 28.12.2001р.
МК 175545, вид.Червонозаводським РВ УМВСУ в Харківській обл. 22.08.1996р.
МН 460280, вид.Фрунзенским РВ ХМУ УМВСУ в Харківській обл. 12.09.2002
МК 175546, вид.Червонозаводським РВ УМВСУ в Харківській обл. 22.08.1996р.
МК 894983 вид. Жовтневим РВ ХМУ УМВСУ в Харківській обл.22.07.1998 р.";
            string[] aStrs = raw.Split('\n');
            foreach (string str in aStrs)
                PhysPersonInfoParserTestWorker(str.Trim().Replace("\r", ""));

        }

        private static void PhysPersonInfoParserTestWorker(string src)
        {
            PhysicalPersonInfo.ParseMatchInfo pmi;
            PhysicalPersonInfo ppi = new PhysicalPersonInfo(); ppi.CitizenshipCountry = CountryInfo.UKRAINE;
            PhysicalPersonInfo.TryParseFillPassIssueData(src, ppi, out pmi);
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;
            string jsonStr = JsonConvert.SerializeObject(pmi.NonRecognizedParts, settings);
            string jsonStr1 = JsonConvert.SerializeObject(ppi, settings);
            Console.WriteLine("\"{0}\": non-recognized - {1}, details: {2}", src, jsonStr, jsonStr1);
        }

        [Test]
        public void ParseFillPassIssueData2()
        {
            string raw = @"паспорт серія МЕ№886790,виданий Шевченківським РУГУ МВС України в м.Києві 11.09.2008р.
паспорт СО 945448 виданий Оболонським РУГУМВС Украєни в м.Киґвi 14.06.2002р.
паспорт СК 346257 виданий Василькiвським МВГУМВС Украєни в Києвськiй обл. 19.12.1996р.
паспорт СН 382939 виданий Залiзничним РУГУМВС Украєни в м.Киґвi 23.01.1997р.
паспорт СН 527104 виданий Харкiвським РУГУМВС Украєни в м.Киґвi 26.11.1997р.
паспорт СН 758632 виданий Харкiвським РУГУМВС Украєни в м.Киґвi 31.03.1998р.
паспорт СН 677961 виданий Ватутiнським РУГУМВС Украєни в м.Киґвi 25.12.1997р.
паспорт СО 407604 виданий Мiнським РУГУМВС Украєни в м.Киґвi 06.06.2000р.
паспорт СА 349224 виданий Ленiнським РВУМВС Украєни в Запорiзькiй обл. 23.01.1997р.
паспорт СО 751860 виданий Деснянським РУГУМВС Украєни в м.Киґвi 22.11.2001р.
паспорт СО 298808 виданий Ленiнградським РУГУМВС Украєни в м.Киґвi 30.12.1999р.
паспорт СН 615775 виданий Старокиєвським РУГУМВС Украєни в м. Киґвi 05.02.1998р.
паспорт СО 365057,  виданий Печерським РУ ГУ МВС України в м. Києві, 28.04.2000
паспорт МЕ 829658, виданий Голосіївським РУ ГУ МВС України в м. Києві, 26.10.2007
пасп. КЕ 122546 виданий Приморcьким РВ УМВС Украєни Одеськiй обл. 22.12.95
паспорт СН ї 134608 видан Харківським РУГУ МВС України в м. Києві, 30.04.1996р.
паспорт МЕ ї 949460,  видан. Шевченківським  РУГУ МВС України в м. Києві 03.09.2009р.
паспорт СО ї 864630 виданий Шевченківським РУГУ МВС України в м. Києві, 09.04.2002р.
паспорт СО ї 052397 виданий Радянським РУГУ МВС України в м. Києві, 25.02.1999р.
паспорт СН ї 936281 виданий Дніпровським РУГУ МВС України в м. Києві, 29.10.1998р.
паспорт СО ї 560015 виданий Ленінградським РУГУ МВС України в м. Києві, 23.03.2001р.
паспорт СН ї 669763 виданий Радянським РУГУ МВС України в м. Києві, 18.12.1997р.
паспорт СО ї 424909 виданий Печерським РУГУ МВС України в м. Києві, 07.07.2000р.
паспорт СН ї 681771виданий Харківським РУГУ МВС України в м. Києві, 20.01.1998р.
";
            string[] aStrs = raw.Split('\n');
            foreach (string str in aStrs)
                PhysPersonInfoParserTestWorker(str.Trim().Replace("\r", ""));

        }
    }
}
