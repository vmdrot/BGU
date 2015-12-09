using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BGU.DRPL.SignificantOwnership.Utility;
using BGU.DRPL.SignificantOwnership.EmpiricalData.Examples;

namespace BGU.DRPL.SignificantOwnership.Tests.BankInfoTests
{
    [TestFixture]
    public class BankOpsSvcStructuringTests
    {
        [Test]
        public void AlfaBankBranchesOpsSvcsTests()
        {
            AlfaBankSamples abs = new AlfaBankSamples();

            foreach(int key in abs.BankBranchOpsFinServices.Keys)
            {
                Tools.WriteXML(abs.BankBranchOpsFinServices[key], string.Format(@"D:\home\vmdrot\DEV\BGU\SignOwn\CSharp\BGU.DRPL.SignificantOwnership.XSLT\Samples\BkBranchOpsSvcs_Alfa_{0}.xml", key));
            }
        }
    }
}
