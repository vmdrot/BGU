using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BGU.DRPL.SignificantOwnership.EmpiricalData.Examples;
using BGU.DRPL.SignificantOwnership.Core.EKDRBU;

namespace BGU.DRPL.SignificantOwnership.Tests.BankInfoTests
{
    [TestFixture]
    public class V1GoTests
    {
        [Test]
        public void OshchadZhytomyrOpsBulkChange()
        {
            BGU.DRPL.SignificantOwnership.Utility.Tools.WriteXML<StateBankBranchRegistryChangePackageV1>((new Oshchad()).ZhytomyrOblastBulkChanges, @"D:\home\vmdrot\BGU\Var\DerzhReiestr\OshchadBulkChange\RealPackages\ILP05000.xml");
        }

        [Test]
        public void OshchadZhytomyrOpsBulkChange_ReverseRead()
        {
            StateBankBranchRegistryChangePackageV1 oshchadZhytOpsBulk = BGU.DRPL.SignificantOwnership.Utility.Tools.ReadXML<StateBankBranchRegistryChangePackageV1>(@"D:\home\vmdrot\BGU\Var\DerzhReiestr\OshchadBulkChange\RealPackages\ILP05000.xml");
            Console.WriteLine("Attachments.Count = {0}", oshchadZhytOpsBulk.Attachments.Count);
            Console.WriteLine("ChangingBranches.Count = {0}", oshchadZhytOpsBulk.ChangingBranches.Count);
            Console.WriteLine("OperationsListingSchemes.Count = {0}", oshchadZhytOpsBulk.OperationsListingSchemes.Count);
        }

        [Test]
        public void OshchadDnpPhonesChange()
        {
            BGU.DRPL.SignificantOwnership.Utility.Tools.WriteXML<StateBankBranchRegistryChangePackageV1>((new Oshchad()).DnpPhoneChanges, @"D:\home\vmdrot\BGU\Var\DerzhReiestr\OshchadBulkChange\RealPackages\PhonesBulkChange.xml");
        }

    }
}
