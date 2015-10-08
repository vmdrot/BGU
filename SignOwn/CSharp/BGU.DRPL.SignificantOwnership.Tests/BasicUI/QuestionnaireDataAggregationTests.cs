using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BGU.DRPL.SignificantOwnership.EmpiricalData.Examples;
using BGU.DRPL.SignificantOwnership.Core.Checks;
using BGU.DRPL.SignificantOwnership.BasicUILib.Forms;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;
using BGU.DRPL.SignificantOwnership.Core.Questionnaires;
using BGU.DRPL.SignificantOwnership.Utility;
using System.ComponentModel;
using Newtonsoft.Json;
using System.IO;

namespace BGU.DRPL.SignificantOwnership.Tests.BasicUI
{
    [TestFixture]
    public class QuestionnaireDataAggregationTests
    {

        [Test]
        public void UltimateOwnersFormTest_Grant()
        {
            GrantBank gb = new GrantBank();
            Appx2OwnershipStructLPChecker checker = new Appx2OwnershipStructLPChecker();
            checker.Questionnaire = gb.Appx2Questionnaire;
            UltimateOwnersForm frm = new UltimateOwnersForm();
            frm.DataSource = checker.ListUltimateBeneficiaries(gb.Appx2Questionnaire.BankRef.LegalPerson);
            frm.ShowDialog();
        }

        [Test]
        public void OwnershipGraphFormTest_Grant()
        {
            GrantBank gb = new GrantBank();
            //Appx2OwnershipStructLPChecker checker = new Appx2OwnershipStructLPChecker();
            //checker.Questionnaire = gb.Appx2Questionnaire;
            UltimateOwnershipTreeForm frm = new UltimateOwnershipTreeForm();
            frm.MentionedEntities = gb.Appx2Questionnaire.MentionedIdentities;
//            frm.MentionedEntities.Add(new GenericPersonInfo(gb.Appx2Questionnaire.BankRef.LegalPerson));
            frm.CentralAssetID = gb.Appx2Questionnaire.BankRef.LegalPerson;
            frm.DataSource = gb.Appx2Questionnaire.BankExistingCommonImplicitOwners;
            frm.ShowDialog();
        }

        [Test]
        public void ListMissingUIEditorTypes()
        {
            string[] auxNamespacesNames = new string[] { "BGU.DRPL.SignificantOwnership.Core.Questionnaires" , "BGU.DRPL.SignificantOwnership.Core.Spares.Data", "BGU.DRPL.SignificantOwnership.Core.Spares.Dict", "BGU.DRPL.SignificantOwnership.Core.Spares" };

            List<Type> allAuxTypes = XSDReflectionUtil.ListTypes(typeof(Appx2OwnershipStructLP), auxNamespacesNames, System.Reflection.BindingFlags.Public, true);

            foreach(Type typ in allAuxTypes)
            {
                Attribute editorAttr = Attribute.GetCustomAttribute(typ, typeof(EditorAttribute));
                if (editorAttr != null)
                    continue;
                Console.WriteLine(typ.Name);
            }
            
        }

        
        private void UltimateOwnersTest_Arkada_Worker(bool bGroup)
        {
            Appx2OwnershipStructLP quest = BGU.DRPL.SignificantOwnership.Utility.Tools.ReadXML<Appx2OwnershipStructLP>(@"D:\home\vmdrot\BGU\Specs\SignigicantOwnership\Testing\Arkada\ArkadaOwnershipChainParserTest_Appx2Qu.xml");
            Appx2OwnershipStructLPChecker checker = new Appx2OwnershipStructLPChecker();
            checker.Questionnaire = quest;
            
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;
            settings.Formatting = Formatting.Indented;
            //Console.WriteLine(JsonConvert.SerializeObject(checker.ListUltimateBeneficiaries(quest.BankRef.LegalPerson, bGroup), settings));
            File.WriteAllText(string.Format(@"D:\home\vmdrot\BGU\Specs\SignigicantOwnership\Testing\Arkada\ArkadaOwnershipChainParserTest_Appx2Qu_UltimateBeneficiaries_{0}.json", (bGroup ? "groupped" : "nongroupped") ), JsonConvert.SerializeObject(checker.ListUltimateBeneficiaries(quest.BankRef.LegalPerson, bGroup), settings));
            Console.WriteLine("------------------------------------------------------------------------");
            File.WriteAllText(string.Format(@"D:\home\vmdrot\BGU\Specs\SignigicantOwnership\Testing\Arkada\ArkadaOwnershipChainParserTest_Appx2Qu_UltimateBeneficiaries_Dbg_{0}.json", (bGroup ? "groupped" : "nongroupped")), JsonConvert.SerializeObject(checker.LastDebugInfo, settings));
            Console.WriteLine("------------------------------------------------------------------------");
        }

        [Test]
        public void UltimateOwnersTest_Arkada_NonGroupped()
        {
            UltimateOwnersTest_Arkada_Worker(false);
        }

        [Test]
        public void UltimateOwnersTest_Arkada_Groupped()
        {
            UltimateOwnersTest_Arkada_Worker(true);
        }
    }
}
