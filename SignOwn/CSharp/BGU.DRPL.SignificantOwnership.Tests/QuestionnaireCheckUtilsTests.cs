using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BGU.DRPL.SignificantOwnership.EmpiricalData.Examples;
using BGU.DRPL.SignificantOwnership.Core.Checks;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;
using Newtonsoft.Json;
using BGU.DRPL.SignificantOwnership.Utility;
using BGU.DRPL.SignificantOwnership.Core.Questionnaires;

namespace BGU.DRPL.SignificantOwnership.Tests
{
    [TestFixture]
    public class QuestionnaireCheckUtilsTests
    {
        [Test]
        public void ExtractPhysicsOnlyTest()
        {
            GrantBank gb = new GrantBank();
            List<GenericPersonID> physics = QuestionnaireCheckUtils.ExtractPhysicsOnly(gb.Appx2Questionnaire.BankExistingCommonImplicitOwners);
            foreach (GenericPersonID id in physics)
                Print(id);
        }
        
        [Test]
        public void ExtractLegalsOnlyTest()
        {
            GrantBank gb = new GrantBank();
            List<GenericPersonID> physics = QuestionnaireCheckUtils.ExtractLegalsOnly(gb.Appx2Questionnaire.BankExistingCommonImplicitOwners);
            foreach (GenericPersonID id in physics)
                Print(id);
        }
        private void Print(GenericPersonID id)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;
            string jsonStr = JsonConvert.SerializeObject(id, settings);
            Console.WriteLine(jsonStr);
        }

        [Test]
        public void BuildOwnershipGraphGrantBankTest()
        {
            GrantBank gb = new GrantBank();
            Appx2OwnershipStructLPChecker checker = new Appx2OwnershipStructLPChecker();
            checker.Questionnaire = gb.Appx2Questionnaire;
            Console.WriteLine(checker.BuildOwnershipGraph());
        }

        
        [Test]
        public void BuildUltimateOwnershipOnlyGraphGrantBankTest()
        {
            GrantBank gb = new GrantBank();
            Appx2OwnershipStructLPChecker checker = new Appx2OwnershipStructLPChecker();
            checker.Questionnaire = gb.Appx2Questionnaire;
            Console.WriteLine(checker.BuildUltimateOwnershipOnlyGraph(true));
        }

        [Test]
        public void BuildUltimateOwnershipOnlyGraphGrantBankFromFileTest()
        {
            GrantBank gb = new GrantBank();
            Appx2OwnershipStructLPChecker checker = new Appx2OwnershipStructLPChecker();
            checker.Questionnaire = Tools.ReadXML<Appx2OwnershipStructLP>(@"D:\home\vmdrot\HaErez\BGU\Var\SignificantOwnership\XMLs\Grant.Appx2OwnershipStructLP.xml");
            Console.WriteLine(checker.BuildUltimateOwnershipOnlyGraph(true));
        }
        
    }
}
