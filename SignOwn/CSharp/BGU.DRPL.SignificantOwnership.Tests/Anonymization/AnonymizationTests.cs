using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BGU.DRPL.SignificantOwnership.Core.Questionnaires;
using BGU.DRPL.SignificantOwnership.Facade.Anonymizing;
using BGU.DRPL.SignificantOwnership.Utility;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;
using Newtonsoft.Json;
using System.IO;
using System.Xml;

namespace BGU.DRPL.SignificantOwnership.Tests.Anonymization
{
    [TestFixture]
    public class AnonymizationTests
    {
        private static readonly string ANONYMIZED_p328_IN_TESTING_FOLDER = @"D:\home\vmdrot\BGU\Specs\SignigicantOwnership\Testing\Arkada\ArkadaOwnershipChainParserTest_p328Msg.xml";
        private static readonly string XSLT_DEBUGGING_p328_PATH = @"D:\home\vmdrot\DEV\BGU\SignOwn\CSharp\BGU.DRPL.SignificantOwnership.XSLT\Samples\p328Msg_xsltEnabled.xml";
        [Test]
        public void AnonymizePost328Msg()
        {
            BankOwnershipStructureP328 msg = Tools.ReadXML<BankOwnershipStructureP328>(ANONYMIZED_p328_IN_TESTING_FOLDER);
            SensitiveDataAnonymizer anonymizer = new SensitiveDataAnonymizer();
            msg.Anonymize(anonymizer);
            Tools.WriteXML<BankOwnershipStructureP328>(msg, ANONYMIZED_p328_IN_TESTING_FOLDER);
            CopyAndInsertXsltRef();
        }

        [Test]
        public void CopyAndInsertXsltRef()
        {
            #region add xslt ref
            //<?xml-stylesheet type='text/xsl' href='../Templates/BankOwnershipStructureP328.xslt'?>
            XmlDocument doc = new XmlDocument();
            doc.Load(ANONYMIZED_p328_IN_TESTING_FOLDER);
            XmlProcessingInstruction xslRef = doc.CreateProcessingInstruction("xml-stylesheet", "type='text/xsl' href='../Templates/BankOwnershipStructureP328.xslt'");
            doc.InsertBefore((XmlNode)xslRef, doc.ChildNodes[1]);
            #endregion
            doc.Save(XSLT_DEBUGGING_p328_PATH);
        }

        [Test]
        public void AnonymizeGPIdsTest()
        {
            Appx2OwnershipStructLP appx2 = Tools.ReadXML<Appx2OwnershipStructLP>(@"D:\home\vmdrot\BGU\Specs\SignigicantOwnership\Testing\Arkada\ArkadaOwnershipChainParserTest_Appx2Qu.xml");
            SensitiveDataAnonymizer anonymizer = new SensitiveDataAnonymizer();
            List<GenericPersonID> oldIds = new List<GenericPersonID>(from mi in appx2.MentionedIdentities 
                                           select mi.ID);


            Dictionary<GenericPersonID, GenericPersonID> old2NewIds = anonymizer.GeneratePersonIDs(oldIds);
            JsonSerializerSettings settings = new JsonSerializerSettings() { Formatting = Newtonsoft.Json.Formatting.Indented, NullValueHandling = NullValueHandling.Ignore };
            File.WriteAllText(@"D:\home\vmdrot\BGU\Specs\SignigicantOwnership\Testing\Arkada\old2newIds.json", JsonConvert.SerializeObject(old2NewIds, settings), Encoding.Unicode);

        }
    }
}
