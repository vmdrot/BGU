using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BGU.DRPL.SignificantOwnership.Utility;
using Newtonsoft.Json;
using System.Xml;
using BGU.DRPL.SignificantOwnership.Core.Questionnaires;

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

        [Test]
        public void ListPropertyTypes()
        {
            ReflectionUtil.ClearLog();
            List<Type> nonRecognizedTypes;
            Dictionary<Type,int> scalarTypes = ReflectionUtil.ListPrimitiveTypesDistinct(typeof(RegLicAppx2OwnershipAcqRequestLP), typeof(RegLicAppx2OwnershipAcqRequestLP).Assembly, out nonRecognizedTypes);
            Console.WriteLine("Known primitive types:");
            foreach (Type typ in scalarTypes.Keys) Console.WriteLine("{0}\t{1}", typ.Name, scalarTypes[typ]);
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Unknown non-user-defined types:");
            foreach (Type typ in nonRecognizedTypes) Console.WriteLine(typ.Name);
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Unwinding log:\n{0}", ReflectionUtil.Log);

        }

    }
}
