using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BGU.DRPL.SignificantOwnership.EmpiricalData.Scraping.Data;
using BGU.DRPL.SignificantOwnership.Utility;
using System.Net;
using Newtonsoft.Json;
using Evolvex.Utility.Core.GoogleMaps;
using System.IO;

namespace BGU.DRPL.SignificantOwnership.Tests.Geo
{
    [TestFixture]
    public class MapsGoogleTests
    {
        [Test]
        public void ResolveNFUAddressesTest()
        {
            List<GenLicNonBankInfo> nfus = Tools.ReadXML<List<GenLicNonBankInfo>>(@"D:\home\vmdrot\BGU\Var\DerzhReiestr\OpsFinSvcs\GenLicNebank_final.xml");
            List<Evolvex.Utility.Core.GoogleMaps.AddressResolveResult> rslt = new List<Evolvex.Utility.Core.GoogleMaps.AddressResolveResult>();
            using (WebClient wc = new WebClient())
            {
                WebProxy wp = new WebProxy("proxy:80");
                wp.Credentials = new NetworkCredential("Valerii.Drotenko", "********");
                wc.Proxy = wp;
                //wc.Credentials = 
                Uri rootUri = new Uri("http://maps.googleapis.com/maps/api/geocode/json");
                foreach (GenLicNonBankInfo nfu in nfus)
                {
                    //sample url = http://maps.googleapis.com/maps/api/geocode/json?address=154+Metro+Central+Heights+London+UK&sensor=true
                    UriBuilder ub = new UriBuilder(rootUri);
                    ub.Query = string.Format("address={0}", nfu.Address.Replace(' ', '+'));
                    string currJson = wc.DownloadString(ub.Uri);
                    AddressResolveResult curRslt = JsonConvert.DeserializeObject<AddressResolveResult>(currJson);
                    rslt.Add(curRslt);
                    Console.WriteLine(currJson);
                    Console.WriteLine("--------------------------------------------------------------");
                }

            }
            Console.WriteLine("Input size: {0}", nfus.Count);
            Console.WriteLine("Non-Resolved: {0}", rslt.Where(o => o.results == null || o.results.Count == 0).Count());
            Console.WriteLine("Resolved: {0}", rslt.Where(o => o.results != null && o.results.Count > 0).Count());
            File.WriteAllText(@"D:\home\vmdrot\BGU\Var\DerzhReiestr\OpsFinSvcs\GenLicNebank_geocoords.json", JsonConvert.SerializeObject(rslt), Encoding.Unicode);
        }
    }
}
