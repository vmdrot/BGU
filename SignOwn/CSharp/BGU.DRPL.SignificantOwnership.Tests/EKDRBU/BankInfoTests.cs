using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BGU.DRPL.SignificantOwnership.Utility;
using BGU.DRPL.SignificantOwnership.Core.EKDRBU.Legacy;
using Newtonsoft.Json;
using NUnit.Framework;

namespace BGU.DRPL.SignificantOwnership.Tests.EKDRBU
{
    [TestFixture]
    public class BankInfoTests
    {
        [Test]
        public void BuildHierTest()
        {
            List<DeptListEntry> depts = ListDepts();

            BGU.DRPL.SignificantOwnership.Facade.EKDRBU.DeptListUtil.BuildHierarchy(depts);
            PrintDeptsWorker(depts);
        }

        [Test]
        public void ParseDeptList()
        {
            List<DeptListEntry> depts = ListDepts();
            PrintDeptsWorker(depts);
        }

        [Test]
        public void ParseDeptListSaveXml()
        {
            List<DeptListEntry> depts = ListDepts();
            Tools.WriteXML<List<DeptListEntry>>(depts, @"D:\home\vmdrot\Testing\OpenData\Input\bank.gov.ua\DptList.xml");
        }

        [Test]
        public void ParseRcuKruSaveXml()
        {
            List<RcuKruEntry> depts = ListRcuKrus();
            Tools.WriteXML<List<RcuKruEntry>>(depts, @"D:\home\vmdrot\Testing\OpenData\Input\bank.gov.ua\RCUKRU.xml");
        }

        private void PrintDeptsWorker(List<DeptListEntry> depts)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;
            foreach (DeptListEntry dle in depts)
            {
                string jsonStr = JsonConvert.SerializeObject(dle, settings);
                Console.WriteLine("{0}", jsonStr);
            }
        }

        private List<DeptListEntry> ListDepts()
        {
            List<DeptListEntry> depts = new List<DeptListEntry>();
            DataTable dt = RcuKruReader.Read(@"D:\home\vmdrot\Testing\OpenData\Input\bank.gov.ua\dptlist.dbf");
            foreach (DataRow dr in dt.Rows)
            {
                depts.Add(DeptListEntry.Parse(dr));
            }
            return depts;
        }

        private List<RcuKruEntry> ListRcuKrus()
        {
            List<RcuKruEntry> depts = new List<RcuKruEntry>();
            DataTable dt = RcuKruReader.Read(@"D:\home\vmdrot\Testing\OpenData\Input\bank.gov.ua\RCUKRU.DBF");
            foreach (DataRow dr in dt.Rows)
            {
                depts.Add(RcuKruEntry.Parse(dr));
            }
            return depts;
        }

        [Test]
        public void ListNFUs()
        {
            
            DataTable dt = RcuKruReader.Read(@"D:\home\vmdrot\BGU\Var\Unsorted\COMPVAL_nfu\compval.dbf");
            
            Tools.DataTableToCSV(dt, @"D:\home\vmdrot\BGU\Var\Unsorted\COMPVAL_nfu\COMPVAL_nfu.csv", true);
        }

    }
}
