using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BGU.DRPL.SignificantOwnership.EmpiricalData.Examples;
using BGU.DRPL.SignificantOwnership.Core.Checks;
using BGU.DRPL.SignificantOwnership.BasicUILib.Forms;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;

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
    }
}
