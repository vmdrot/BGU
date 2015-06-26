using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BGU.DRPL.SignificantOwnership.Utility.WPFGen;
using BGU.DRPL.SignificantOwnership.Core.Questionnaires;
using System.Reflection;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;
using Evolvex.Utility.Core.ComponentModelEx;
using BGU.DRPL.SignificantOwnership.Utility;
using Newtonsoft.Json;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;

namespace BGU.DRPL.SignificantOwnership.Tests
{
    [TestFixture]
    public class XAMLGenerationTests
    {
        [Test]
        public void ListUserTypesToGenerateTemplatesForTest()
        {
            ListUserTypesToGenerateTemplatesForTestWorker(typeof(RegLicAppx2OwnershipAcqRequestLP));
        }

        [Test]
        public void ListUserTypesToGenerateTemplatesForTest2()
        {
            ListUserTypesToGenerateTemplatesForTestWorker(typeof(RegLicAppx12HeadCandidateAppl));
        }

        [Test]
        public void ListUserTypesToGenerateTemplatesForTest3()
        {
            ListUserTypesToGenerateTemplatesForTestWorker(typeof(RegLicAppx14NewSvc));
        }

        [Test]
        public void ListUserTypesToGenerateTemplatesForTest4()
        {
            ListUserTypesToGenerateTemplatesForTestWorker(typeof(RegLicAppx3MemberCandidateAppl));
        }

        [Test]
        public void ListUserTypesToGenerateTemplatesForTest5()
        {
            ListUserTypesToGenerateTemplatesForTestWorker(typeof(Appx2OwnershipStructLP));
        }

        private static void ListUserTypesToGenerateTemplatesForTestWorker(Type rootType)
        {
            XAMLTemplatesGenerationManager.ClearLog();
            List<Type> typs = XAMLTemplatesGenerationManager.ListUserTypesToGenerateTemplatesFor(rootType, rootType.Assembly);
            foreach (Type typ in typs)
                Console.WriteLine(typ.FullName);
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine(XAMLTemplatesGenerationManager.Log);
            Console.WriteLine("--------------------------------------------");
        }


        [Test]
        public void Generate4RegLicAppx2()
        {
            //string targetFolder = @"D:\home\vmdrot\DEV\_tut\WpfApplication2\WpfApplication2\Resources";
            string targetFolder = @"D:\home\vmdrot\TMP\XAMLTemplates";
            XAMLTemplatesGenerationManager.GenerateXAMLTemplates(typeof(RegLicAppx2OwnershipAcqRequestLP), typeof(RegLicAppx2OwnershipAcqRequestLP).Assembly, targetFolder);
        }

        [Test]
        public void GetCustomAttributeTest()
        { 
            UIUsageComboAttribute attr = ReflectionUtil.GetPropertyOrTypeAttribute<UIUsageComboAttribute>(typeof(BankInfo).GetProperty("OperationCountry"));
            UIUsageComboAttribute attr2 = ReflectionUtil.GetPropertyOrTypeAttribute<UIUsageComboAttribute>(typeof(GenericPersonID).GetProperty("CountryISO3Code"));
            
            if (attr != null)
            {
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                string jsonStr = JsonConvert.SerializeObject(attr, settings);
                Console.WriteLine(jsonStr);
                jsonStr = JsonConvert.SerializeObject(attr2, settings);
                Console.WriteLine(jsonStr);
            }
        }

    }
}
