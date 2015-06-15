using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;
using Newtonsoft.Json;
using System.Data;
using BGU.DRPL.SignificantOwnership.Utility;
using System.IO;

namespace BGU.DRPL.SignificantOwnership.Tests.WebUIRelated
{
    [TestFixture]
    public class JsonGenerators
    {

        [Test]
        public void GenerateBankInfosJson()
        {
            List<BankInfo> rcuKurBanks = new List<BankInfo>();

            DataTable dt = RcuKruReader.Read(@"D:\home\vmdrot\DEV\_tut\BGU.DRPL.SignificantOwnership\Data\RCUKRU.DBF");
            foreach (DataRow dr in dt.Rows)
            {
                try
                {
                    string prb = dr["PRB"] as string;
                    //if (prb == "1")
                    //    continue;

                    string glmfo = ((int)dr["GLMFO"]).ToString();
                    string mfo = ((int)dr["MFO"]).ToString();
                    //if (glmfo != mfo)
                    //    continue;
                    string glb = ((int)dr["GLB"]).ToString();

                    string prkb = ((int)dr["PRKB"]).ToString();

                    string zipCode = dr["PI"] as string;
                    string city = dr["NP"] as string;
                    string address = dr["ADRESS"] as string;
                    string yedrpou = dr["IKOD"] as string;

                    BankInfo bi = new BankInfo();
                    bi.OperationCountry = CountryInfo.UKRAINE;
                    bi.Name = dr["NB"] as string;
                    bi.MFO = mfo;
                    bi.Code = glb;
                    bi.RegistryNr = prkb;
                    bi.LegalPerson = (new LegalPersonInfo() { TaxCodeOrHandelsRegNr = yedrpou, Name = dr["FULLNAME"] as string, Address = LocationInfo.Parse(address), ResidenceCountry = CountryInfo.UKRAINE }).GenericID;
                    //bi.LegalPerson.Address.City = city;
                    //bi.LegalPerson.Address.ZipCode = zipCode;
                    rcuKurBanks.Add(bi);
                }
                catch { }
            }

            rcuKurBanks.Sort(delegate(BankInfo obj1, BankInfo obj2)
            {
                return string.Compare(obj1.Name, obj2.Name);
            });


            
            
            
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;
            string jsonStr = JsonConvert.SerializeObject(rcuKurBanks, settings);
            File.WriteAllText(@"D:\home\vmdrot\DEV\_tut\BGU.DRPL.SignificantOwnership\BGU.Web20.MiscItemsSite\App_Data\bankInfos.json", jsonStr, Encoding.Unicode);
        }
    }
}
