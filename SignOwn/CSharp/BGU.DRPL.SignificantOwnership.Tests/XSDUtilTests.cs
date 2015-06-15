using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BGU.DRPL.SignificantOwnership.Utility;
using Newtonsoft.Json;
using System.Xml;

namespace BGU.DRPL.SignificantOwnership.Tests
{
    [TestFixture]
    public class XSDUtilTests
    {
        [Test]
        public void GetPropDispsDescrs_Appx2OS()
        {
            Dictionary<string, BGU.DRPL.SignificantOwnership.Utility.XSDReflectionUtil.PropDispDescr> propDispsDescrs = BGU.DRPL.SignificantOwnership.Utility.XSDReflectionUtil.FetchPropDispsDescrs(typeof(BGU.DRPL.SignificantOwnership.Core.Questionnaires.Appx2OwnershipStructLP));
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;
            string jsonStr = JsonConvert.SerializeObject(propDispsDescrs, settings);
            Console.WriteLine(jsonStr);

        }

        [Test]
        public void ProcessXSDTest()
        {
            XmlDocument doc = new XmlDocument();

            doc.Load(@"D:\home\vmdrot\HaErez\BGU\Var\SignificantOwnership\XMLs\XSDs\Appx2OwnershipStructLP.xsd");
                List<string> classes = XSDReflectionUtil.GetXSDComplexTypes(doc);
                //List<string> enums = XSDReflectionUtil.GetXSDEnums(doc);
            

            foreach (string cls in classes)
                Console.WriteLine(cls);

            //foreach (string enm in enums)
            //    Console.WriteLine(enm);
        }

    }
}
