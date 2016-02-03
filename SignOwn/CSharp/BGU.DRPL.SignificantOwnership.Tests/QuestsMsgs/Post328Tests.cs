using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BGU.DRPL.SignificantOwnership.Core.Questionnaires;
using BGU.DRPL.SignificantOwnership.Utility;
using BGU.DRPL.SignificantOwnership.Core.Checks;

namespace BGU.DRPL.SignificantOwnership.Tests.QuestsMsgs
{
    [TestFixture]
    public class Post328Tests
    {
        [Test]
        public void ConvertAppx2ToP328Msg_Arkada()
        {
            BankOwnershipStructureP328 rslt = new BankOwnershipStructureP328();
            Appx2OwnershipStructLP appx2 = Tools.ReadXML<Appx2OwnershipStructLP>(@"D:\home\vmdrot\BGU\Specs\SignigicantOwnership\Testing\Arkada\ArkadaOwnershipChainParserTest_Appx2Qu.xml");
            rslt.BankRef = appx2.BankRef;
            rslt.MentionedIdentities = new List<Core.Spares.Data.GenericPersonInfo>();
            rslt.MentionedIdentities.AddRange(appx2.MentionedIdentities);
            rslt.ContactPerson = appx2.ContactPerson;
            if (appx2.Signatory != null)
                rslt.Signatory = appx2.Signatory;
            else
            {
                rslt.Signatory = new Core.Spares.Data.SignatoryInfo();
                rslt.Signatory.DateSigned = DateTime.Parse("2015-08-18T00:00:00");
                rslt.Signatory.SurnameInitials = "Паливода К.В.";
                rslt.Signatory.SignatoryPosition = "Голова Правління ПАТ АКБ \"АРКАДА\"";
                rslt.Signatory.IsActingByPowOfAttorney = false;
            }
            if (appx2.Signatory != null && appx2.Signatory.DateSigned != null)
                rslt.DateAsOf = (DateTime)appx2.Signatory.DateSigned;
            else rslt.DateAsOf = DateTime.Parse("2015-08-18T00:00:00");
            rslt.IsApplicationInfoAccurateAndTrue = true;
            rslt.OwnershipsHive = new List<Core.Spares.Data.OwnershipStructure>();
            rslt.OwnershipsHive.AddRange (appx2.BankExistingCommonImplicitOwners);
            rslt.PersonsLinks = new List<Core.Spares.Data.PersonsAssociation>();
            rslt.PersonsLinks.AddRange(appx2.PersonsLinks);
            Appx2OwnershipStructLPChecker checker = new Appx2OwnershipStructLPChecker();
            checker.Questionnaire = appx2;
            rslt.UltimateOwners = new List<Core.Spares.Data.TotalOwnershipDetailsInfoEx>();
            rslt.UltimateOwners.AddRange(checker.ListUltimateBeneficiaries(appx2.BankRef.LegalPerson));
            Tools.WriteXML<BankOwnershipStructureP328>(rslt, @"D:\home\vmdrot\BGU\Specs\SignigicantOwnership\Testing\Arkada\ArkadaOwnershipChainParserTest_p328Msg.xml");
        }
    }
}
