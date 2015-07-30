using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BGU.DRPL.SignificantOwnership.Utility;
using System.Data;
//using GenericParsing;

namespace BGU.DRPL.SignificantOwnership.Tests
{
    [TestFixture]
    public class GenericParserTests
    {
        [Test]
        public void ExportRcuKru2CSV()
        {
            DataTable dt = RcuKruReader.Read(@"D:\home\vmdrot\BGU\Var\DerzhReiestr\ShBO\rcukru.dbf");
            Tools.DataTableToCSV(dt, @"D:\home\vmdrot\BGU\Var\DerzhReiestr\ShBO\rcukru.csv", true);
        }

        [Test]
        public void ExportDeptList2CSV()
        {
            DataTable dt = RcuKruReader.Read(@"D:\home\vmdrot\BGU\Var\DerzhReiestr\ShBO\dptlist.dbf");
            Tools.DataTableToCSV(dt, @"D:\home\vmdrot\BGU\Var\DerzhReiestr\ShBO\dptlist.dbf.csv", true);
        }
    }
}
