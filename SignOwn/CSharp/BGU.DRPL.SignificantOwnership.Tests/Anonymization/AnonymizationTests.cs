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

namespace BGU.DRPL.SignificantOwnership.Tests.Anonymization
{
    [TestFixture]
    public class AnonymizationTests
    {
        [Test]
        public void AnonymizeRegLicAppx2()
        { 

        }

        [Test]
        public void AnonymizeGPIdsTest()
        {
            Appx2OwnershipStructLP appx2 = Tools.ReadXML<Appx2OwnershipStructLP>(@"D:\home\vmdrot\BGU\Specs\SignigicantOwnership\Testing\Arkada\ArkadaOwnershipChainParserTest_Appx2Qu.xml");
            SensitiveDataAnonymizer anonymizer = new SensitiveDataAnonymizer();
            List<GenericPersonID> oldIds = new List<GenericPersonID>(from mi in appx2.MentionedIdentities 
                                           select mi.ID);


            Dictionary<GenericPersonID, GenericPersonID> old2NewIds = anonymizer.GeneratePersonIDs(oldIds);
            JsonSerializerSettings settings = new JsonSerializerSettings() { Formatting = Formatting.Indented, NullValueHandling = NullValueHandling.Ignore };
            File.WriteAllText(@"D:\home\vmdrot\BGU\Specs\SignigicantOwnership\Testing\Arkada\old2newIds.json", JsonConvert.SerializeObject(old2NewIds, settings), Encoding.Unicode);

        }
    }
}
