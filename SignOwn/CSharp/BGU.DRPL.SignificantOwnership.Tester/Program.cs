using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Questionnaires;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;
using BGU.DRPL.SignificantOwnership.Core.Spares;
using System.Xml.Serialization;
using System.IO;
using Newtonsoft.Json;
using BGU.DRPL.SignificantOwnership.EmpiricalData.Examples;
using BGU.DRPL.SignificantOwnership.Core.Checks;
using System.Xml;
using BGU.DRPL.SignificantOwnership.Utility;
using System.Configuration;
using BGU.DRPL.SignificantOwnership.Utility.WPFGen;
using BGU.DRPL.SignificantOwnership.Core.EKDRBU;
using BGU.DRPL.SignificantOwnership.Core.EKDRBU.Legacy;
using System.Data;
using BGU.DRPL.SignificantOwnership.EmpiricalData.Scraping.Data;
using BGU.DRPL.SignificantOwnership.EmpiricalData.Scraping;

namespace BGU.DRPL.SignificantOwnership.Tester
{
    class Program
    {

        #region field(s)
        private delegate void CmdHandler(string[] args);
        private static readonly Dictionary<string, CmdHandler> _cmdHandlers;

        private static readonly string XsdExePath;
        private static readonly string XsdFilesOutputDir;
        private static readonly string OriginalXsdFilesOutputDir;
        private static readonly bool XsdPutDispNmDescrIntoAnnotation;
        private static readonly string XmlFormatterPath;
        private static Dictionary<string, bool> _alreadyProcessedXSDExportTypes;
        #endregion

        #region cctor(s)
        static Program()
        {
            #region Read config
            XsdExePath = ConfigurationManager.AppSettings["xsdExePath"];
            XsdFilesOutputDir = ConfigurationManager.AppSettings["xsdFilesOutputDir"];
            OriginalXsdFilesOutputDir = ConfigurationManager.AppSettings["origXsdFilesOutputDir"];
            XmlFormatterPath = ConfigurationManager.AppSettings["xmlFormatterPathRel"];
            string xsdPutDispNmDescrIntoAnnotationStr = ConfigurationManager.AppSettings["xsdUkUAPutDispNmDescr2Annot"];
            if(string.IsNullOrEmpty(xsdPutDispNmDescrIntoAnnotationStr))
                XsdPutDispNmDescrIntoAnnotation = false;
            bool tmp;
            if (bool.TryParse(xsdPutDispNmDescrIntoAnnotationStr, out tmp))
                XsdPutDispNmDescrIntoAnnotation = tmp;
            #endregion

            #region CMD handlers

            _cmdHandlers = new Dictionary<string, CmdHandler>();

            #region populate
            _cmdHandlers.Add("updatexsdstranslations", UpdateXSDsTranslations);
            _cmdHandlers.Add("generatexamls4reglicappx2", GenerateXAMLs4RegLicAppx2);
            _cmdHandlers.Add("generatexamls4bkinfo", GenerateXAMLs4BkInfo);
            _cmdHandlers.Add("bankshierarchy", BanksHierarchy);
            _cmdHandlers.Add("arkadaownershipchainparsertest", ArkadaOwnershipChainParserTest);
            _cmdHandlers.Add("arkadaownershipchainanalysis", ArkadaOwnershipChainAnalysis);
            #endregion

            #endregion
        }
        #endregion

        static void Main(string[] args)
        {
            //Console.Read();

            //CreateSampleAppx2OwnershipStructLP();
            //LocationInfoParser();
            //LocationInfoParser2();
            //ParseFillPassIssueData1();
            //ParseFillPassIssueData2();
            
            //WriteXML_Grant();
            //BuildOwnershipGraphGrantBankTest();
            //ProcessXSDTest();
            string cmdHandlerKey = string.Empty;
            if (args.Length > 0)
                cmdHandlerKey = args[0].ToLower();
            try
            {
                if (string.IsNullOrEmpty(cmdHandlerKey) || !_cmdHandlers.ContainsKey(cmdHandlerKey))
                    return;
                else
                    _cmdHandlers[cmdHandlerKey](args);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
            }

        }

        #region FFR
        //private static void CreateSampleAppx2OwnershipStructLP()
        //{
        //    Appx2OwnershipStructLP questio = new Appx2OwnershipStructLP();
        //    #region filling sample with data

        //    #region re-usable constants
        //    #region countries
        //    CountryInfo countryUkraine = new CountryInfo() { CountryISO2Code = "UA", CountryISO3Code = "UKR", CountryISONr = "804", CountryNameEng = "Ukraine", CountryNameUkr = "Україна" };
        //    CountryInfo countryAustria = new CountryInfo() { CountryISO2Code = "AT", CountryISO3Code = "AUT", CountryISONr = "040", CountryNameEng = "Austria", CountryNameUkr = "Австрія" };
        //    CountryInfo countryCyprus = new CountryInfo() { CountryISO2Code = "CY", CountryISO3Code = "CYP", CountryISONr = "196", CountryNameEng = "Cyprus", CountryNameUkr = "Кіпр" };
        //    #endregion

        //    #region addresses
        //    LocationInfo mArnautska102 = new LocationInfo() { Country = countryUkraine, City = "Одеса", Region = "Одеська область", ZipCode = "65007", Street = "вул. Мала Арнаутська", HouseNr = "102", ApptOfficeNr = "5" };
        //    LocationInfo addrPerDiv83a = new LocationInfo() { Country = countryUkraine, City = "Одеса", Region = "Одеська область", ZipCode = "65016", Street = "вул. Фонтанська Дорога", HouseNr = "83" };
        //    LocationInfo addrKordProv13a = new LocationInfo() { Country = countryUkraine, City = "Одеса", Region = "Одеська область", ZipCode = "65074", Street = "пров. Кордонний", HouseNr = "13А" };
        //    LocationInfo addrTirasp22 = new LocationInfo() { Country = countryUkraine, City = "Одеса", Region = "Одеська область", ZipCode = "65020", Street = "вул. Тираспольська", HouseNr = "22", ApptOfficeNr = "3" };
        //    //https://www.post.at/suche/standortsuche.php/index/selectedsearch/plz?_cc_=1 , http://www.stadtplandienst.at/
        //    LocationInfo addrStPoeltenErtl3 = new LocationInfo() { Country = countryAustria, City = "St.Pölten", Region = "Niederösterreich", ZipCode = "AT-3100", Street = "Ertlstr.", HouseNr = "3", ApptOfficeNr = "5" };
        //    #endregion

        //    #region Registrars
        //    RegistrarAuthority kyivOdRVUMVS = new RegistrarAuthority()
        //                                        {
        //                                            //src: http://mvs.gov.ua/mvs/control/odesa/uk/publish/article/144997
        //                                            Address = new LocationInfo()
        //                                                            {
        //                                                                Country = countryUkraine,
        //                                                                City = "Одеса",
        //                                                                ZipCode = "65080",
        //                                                                Street = "вул. Академіка Філатова",
        //                                                                Region = "Одеська область",
        //                                                                HouseNr = "15-А"
        //                                                            },
        //                                            EntitiesHandled = EntityType.Physical,
        //                                            RegistrarCode = "",
        //                                            RegistrarName = "Київський РВ ОМУ ГУМВС України в Одеській області"
        //                                        };
        //    RegistrarAuthority magistratStPoelten = new RegistrarAuthority()
        //                                        {
        //                                            //src: https://www.help.gv.at/linkaufloesung/applikation-flow;jsessionid=557D7A72865E9928014A07F8671AB9E9.tomcat_help1?execution=e1s1
        //                                            Address = new LocationInfo()
        //                                                            {
        //                                                                Country = countryAustria,
        //                                                                City = "St. Pölten",
        //                                                                ZipCode = "3100",
        //                                                                Street = "Rathausplatz",
        //                                                                Region = "Niederösterreich",
        //                                                                HouseNr = "1"
        //                                                            },
        //                                            EntitiesHandled = EntityType.Physical,
        //                                            RegistrarCode = "",
        //                                            RegistrarName = "Magistrat St. Pölten"
        //                                        };
        //    RegistrarAuthority cyprusRegister = new RegistrarAuthority()
        //                                            {
        //                                                JurisdictionCountry = countryCyprus,
        //                                                EntitiesHandled = EntityType.Legal,
        //                                                RegistrarName = "DEPARTMENT OF REGISTRAR OF COMPANIES AND OFFICIAL RECEIVER",
        //                                                //RegistrarCode = "",
        //                                                Address = new LocationInfo()
        //                                                            {
        //                                                                Country = countryCyprus,
        //                                                                City = "Nicosia",
        //                                                                Street = "Corner Makarios Avenue & Karpenisiou",
        //                                                                HouseNr = "XENIOS Building"
        //                                                            }
        //                                            };
        //    RegistrarAuthority reestrOdesa = new RegistrarAuthority()
        //    {
        //        JurisdictionCountry = countryUkraine,
        //        RegistrarName = "Реєстраційна служба Одеського міського управління юстиції",
        //        Address = new LocationInfo() { Country = countryUkraine, City = "Одеса", Street = "вул. Велика Арнаутська", HouseNr = "15", ZipCode = "65012" },
        //        EntitiesHandled = EntityType.Legal,
        //        RegistrarCode = ""
        //    };
        //    #endregion

        //    #region physical persons
        //    PhysicalPersonInfo kacmanAM = new PhysicalPersonInfo()
        //                                                   {
        //                                                       CitizenshipCountry = countryUkraine,
        //                                                       FullName = "Кацман Абрам Мойсейович",
        //                                                       Name = "Абрам",
        //                                                       MiddleName = "Мойсейович",
        //                                                       Surname = "Кацман",
        //                                                       PassportID = "ЕА 293857",
        //                                                       PassIssueAuthority = kyivOdRVUMVS,
        //                                                       PassIssuedDate = DateTime.Parse("1995-03-12T00:00:00"),
        //                                                       TaxOrSocSecID = "0540117865",
        //                                                       Address = addrPerDiv83a

        //                                                   };

        //    PhysicalPersonInfo handrabura = new PhysicalPersonInfo()
        //                                                   {
        //                                                       CitizenshipCountry = countryUkraine,
        //                                                       FullName = "Гандрабура Циля Авазівна",
        //                                                       Name = "Циля",
        //                                                       MiddleName = "Авазівна",
        //                                                       Surname = "Гандрабура",
        //                                                       PassportID = "КЕ 554635",
        //                                                       PassIssueAuthority = kyivOdRVUMVS,
        //                                                       PassIssuedDate = DateTime.Parse("1997-12-12T00:00:00"),
        //                                                       TaxOrSocSecID = "5543216455",
        //                                                       Address = addrKordProv13a
        //                                                   };
        //    PhysicalPersonInfo holovatyi = new PhysicalPersonInfo()
        //    {
        //        CitizenshipCountry = countryUkraine,
        //        FullName = "Головатий Марко Пафнутійович",
        //        Name = "Марко",
        //        MiddleName = "Пафнутійович",
        //        Surname = "Головатий",
        //        PassportID = "АВ 135986",
        //        PassIssueAuthority = kyivOdRVUMVS,
        //        PassIssuedDate = DateTime.Parse("1993-10-05T00:00:00"),
        //        TaxOrSocSecID = "0514235444",
        //        Address = addrTirasp22

        //    };

        //    // sample - 
        //    PhysicalPersonInfo siehnert = new PhysicalPersonInfo()
        //    {
        //        CitizenshipCountry = countryAustria,
        //        FullName = "Siehnert Andreas Johann",
        //        Name = "Andreas",
        //        MiddleName = "Johann",
        //        Surname = "Siehnert",
        //        FullNameUkr = "Зінерт Андреас Йоганн",
        //        NameUkr = "Андреас",
        //        MiddleNameUkr = "Йоганн",
        //        SurnameUkr = "Зінерт",
        //        BirthDate = DateTime.Parse("1982-05-10T00:00:00"),
        //        Sex = SexType.Male,
        //        PassportID = "10008456", //http://de.wikipedia.org/wiki/Personalausweis#/media/File:Austrian_ID_card.jpg
        //        PassIssueAuthority = magistratStPoelten,
        //        PassIssuedDate = DateTime.Parse("2002-12-18T00:00:00"),
        //        TaxOrSocSecID = "1237 010180", //http://de.wikipedia.org/wiki/Sozialversicherungsnummer#.C3.96sterreich
        //        Address = addrStPoeltenErtl3

        //    };
        //    #endregion

        //    #region legal persons
        //    LegalPersonInfo markManLtd = new LegalPersonInfo() // https://efiling.drcor.mcit.gov.cy/DrcorPublic/SearchResults.aspx?name=Mark&number=%25&searchtype=optStartMatch&index=4&lang=EN&tname=%25&sc=1
        //                                                              {
        //                                                                  Address = new LocationInfo()
        //                                                                  {
        //                                                                      Country = countryCyprus,
        //                                                                      City = "Μέσα Γειτονιά",
        //                                                                      Street = "Αρχ. Μακαρίου ΙΙΙ",
        //                                                                      HouseNr = "1",
        //                                                                      ApptOfficeNr = "ATLANTIS BUILDING, Floor 1",
        //                                                                      ZipCode = "4000",
        //                                                                      Region = "Λεμεσός"
        //                                                                  },
        //                                                                  ResidenceCountry = countryCyprus,
        //                                                                  Registrar = cyprusRegister,
        //                                                                  Name = "MARK MAN LIMITED",
        //                                                                  TaxCodeOrHandelsRegNr = "ΗΕ 68757"
        //                                                              };

        //    LegalPersonInfo sigmaHldngsLtd = new LegalPersonInfo() // https://efiling.drcor.mcit.gov.cy/DrcorPublic/SearchResults.aspx?name=Sigma+holdings&number=%25&searchtype=optStartMatch&index=1&lang=EN&tname=%25&sc=1
        //    {
        //        Address = new LocationInfo()
        //        {
        //            Country = countryCyprus,
        //            City = "Λεμεσός",
        //            Street = "Γρ. Ξενοπούλου",
        //            HouseNr = "17",
        //            ZipCode = "3106"

        //        },
        //        ResidenceCountry = countryCyprus,
        //        Registrar = cyprusRegister,
        //        Name = "SIGMA EXPLORATIONS HOLDINGS LIMITED",
        //        TaxCodeOrHandelsRegNr = "ΗΕ 285734"
        //    };

        //    LegalPersonInfo ebensyCustdyLtd = new LegalPersonInfo() // https://efiling.drcor.mcit.gov.cy/DrcorPublic/SearchResults.aspx?name=custody&number=%25&searchtype=optStartMatch&index=1&lang=EN&tname=%25&sc=1
        //    {
        //        Address = new LocationInfo()
        //        {
        //            Country = countryCyprus,
        //            City = "Λεμεσός",
        //            Street = "Ρήγαινας",
        //            HouseNr = "13",
        //            ZipCode = "4632"

        //        },
        //        ResidenceCountry = countryCyprus,
        //        Registrar = cyprusRegister,
        //        Name = "EBENSY CUSTODY LIMITED",
        //        TaxCodeOrHandelsRegNr = "ΗΕ 140707",
        //        RepresentedBy = siehnert
        //    };
        //    #endregion

        //    #endregion

        //    #region the Questionnaire itself
        //    questio.BankRef = new BankInfo() { HeadMFO = "300614", Name = "ПАТ \"Креді Агріколь Банк\"", Code = "171", RegistryNr = "171" };
        //    questio.Acquiree = new LegalPersonInfo()
        //                          {
        //                              Address = mArnautska102,
        //                              TaxCodeOrHandelsRegNr = "21546214",
        //                              Name = "МЧП Ветерок",
        //                              Registrar = reestrOdesa,
        //                              ResidenceCountry = countryUkraine,
        //                              RepresentedBy = kacmanAM
        //                          };
        //    questio.IsSupervisoryCouncilPresent = true;
        //    questio.SupervisoryCouncil = new CouncilBodyInfo()
        //                                    {
        //                                        Members = new List<CouncilMemberInfo>
        //                                            (new CouncilMemberInfo[]
        //                                               {
        //                                                  new CouncilMemberInfo(){ Member = new GenericPersonInfo(){ PersonType = EntityType.Physical, PhysicalPerson = kacmanAM }, PositionName = "Голова"},
        //                                                  new CouncilMemberInfo(){ Member = new GenericPersonInfo(){ PersonType = EntityType.Legal, LegalPerson = ebensyCustdyLtd }, PositionName = "Член"},
        //                                                  new CouncilMemberInfo(){ Member = new GenericPersonInfo(){ PersonType = EntityType.Physical, PhysicalPerson = siehnert }, PositionName = "Член"}

        //                                               }
        //                                            ),
        //                                        HeadMemberIndex = 0
        //                                    };
        //    questio.IsExecutivesPresent = true;
        //    questio.Executives = new CouncilBodyInfo()
        //                                    {
        //                                        Members = new List<CouncilMemberInfo>
        //                                                  (
        //                                                       new CouncilMemberInfo[] 
        //                                                       { 
        //                                                           new CouncilMemberInfo() { Member = new GenericPersonInfo() { PersonType = EntityType.Physical, PhysicalPerson = handrabura}, PositionName = "Генеральний директор" }, 
        //                                                           new CouncilMemberInfo() { Member = new GenericPersonInfo() { PersonType = EntityType.Physical, PhysicalPerson = holovatyi }, PositionName = "Головний бухгалтер" }
        //                                                       }
        //                                                  ),
        //                                        HeadMemberIndex = 0
        //                                    };
        //    questio.TotalOwneshipPct = 24.5M;
        //    questio.TotalOwneshipDetails = new TotalOwnershipDetailsInfo()
        //                                       {
        //                                           DirectOwnership = new OwnershipSummaryInfo() { Pct = 12.3M, Amount = 33000000, Votes = 52 },
        //                                           ImplicitOwnership = new OwnershipSummaryInfo() { Pct = 10.2M, Amount = 30000000, Votes = 49 },
        //                                           AcquiredVotes = new OwnershipVotesInfo() { Pct = 2, Votes = 8 },
        //                                           TotalCapitalSharePct = 24.5M,
        //                                           TotalVotes = 52 + 49 + 8
        //                                       };
        //    //questio.CommonOwnership = new CommonOwnershipInfo();
        //    //questio.ImplicitOwnership = new ImplicitOwnershipInfo();
        //    questio.BankExistingCommonImplicitOwners = new List<CommonOwnershipInfo>
        //                                                   (
        //                                                    new CommonOwnershipInfo[]
        //                                                    {
        //                                                        new CommonOwnershipInfo() 
        //                                                        { 
        //                                                            Partners = new List<GenericPersonInfo>
        //                                                                            (
        //                                                                            new GenericPersonInfo[] 
        //                                                                            {
        //                                                                                new GenericPersonInfo()
        //                                                                                {
        //                                                                                    PersonType = EntityType.Legal,
        //                                                                                    LegalPerson = new LegalPersonInfo()
        //                                                                                                      {
        //                                                                                                          Address = mArnautska102, Name = "ТОВ \"Наяда\"", Registrar = reestrOdesa, RepresentedBy = kacmanAM, ResidenceCountry = countryUkraine, TaxCodeOrHandelsRegNr = "50245463"
        //                                                                                                      }
        //                                                                                }
        //                                                                            }
        //                                                                            ),
        //                                                                            OwnershipTestimony = "довіреність від 23.06.2001р.",
        //                                                                            OwnershipPct = 99.98M, OwnershipType = CommonOwnershipType.Implicit
        //                                                        },
        //                                                        new CommonOwnershipInfo() 
        //                                                        { 
        //                                                            Partners = new List<GenericPersonInfo>
        //                                                                            (
        //                                                                            new GenericPersonInfo[] 
        //                                                                            {
        //                                                                                new GenericPersonInfo()
        //                                                                                {
        //                                                                                PersonType = EntityType.Physical,
        //                                                                                PhysicalPerson = handrabura
        //                                                                                }
        //                                                                            }),
        //                                                            OwnershipPct = 0.02M, OwnershipType = CommonOwnershipType.Direct, OwnershipTestimony = ""
        //                                                        }
        //                                                    }
        //                                                   );
        //    questio.SharesAppliedFor = new List<PurchasedVoteInfo>(
        //                              new PurchasedVoteInfo[] 
        //                               {
        //                                   new PurchasedVoteInfo() { Transferror = new GenericPersonInfo() { PersonType = EntityType.Physical, LegalPerson = null, PhysicalPerson = holovatyi}, PurchaseVotes = new OwnershipVotesInfo() { Pct = 6.02M, Votes = 12}, VotesTransferPath = "довіреність від 03.12.2012"},
        //                                   new PurchasedVoteInfo() { Transferror = new GenericPersonInfo() { PersonType = EntityType.Legal, 
        //                                                             PhysicalPerson = null, 
        //                                                             LegalPerson = markManLtd }, 
        //                                                             PurchaseVotes = new OwnershipVotesInfo() { Pct = 5.11M, Votes = 51}, VotesTransferPath = "Power of attorney dd 22.10.2010"},
        //                               }
        //                             );
        //    questio.SignificantSharesPhysicalPersons = new List<PhysicalPersonShareInfo>
        //                                                    (
        //                                                      new PhysicalPersonShareInfo[] 
        //                                                      {
        //                                                          new PhysicalPersonShareInfo() { Person = handrabura, SharePct = 20M },
        //                                                          new PhysicalPersonShareInfo() { Person = holovatyi, SharePct = 15M },
        //                                                          new PhysicalPersonShareInfo() { Person = siehnert, SharePct = 14.5M }
        //                                                      }
        //                                                    );
        //    questio.SignificantSharesLegalPersons = new List<LegalPersonShareInfo>
        //                                                    (
        //                                                      new LegalPersonShareInfo[] 
        //                                                      {
        //                                                          new LegalPersonShareInfo() { Person = markManLtd, SharePct = 12M },
        //                                                          new LegalPersonShareInfo() { Person = sigmaHldngsLtd, SharePct = 11M },
        //                                                          new LegalPersonShareInfo() { Person = ebensyCustdyLtd, SharePct = 10.5M }
        //                                                      }
        //                                                    );
        //    questio.AcquireeCommonImplicitOwners = new List<CommonOwnershipInfo>
        //        (
        //            new CommonOwnershipInfo[]
        //            {
        //                new CommonOwnershipInfo()
        //                {
        //                    Partners = new List<GenericPersonInfo>
        //                        (
        //                           new GenericPersonInfo[]
        //                           {
        //                               new GenericPersonInfo() { PersonType = EntityType.Legal, LegalPerson = markManLtd },
        //                               new GenericPersonInfo() { PersonType = EntityType.Physical, PhysicalPerson = siehnert}
        //                           }
        //                        ),
        //                    OwnershipPct = 49.9M, OwnershipTestimony = "Угода про спільне володіння № 23/44 від 04.08.2007р.", OwnershipType = CommonOwnershipType.Direct
        //                },
        //                new CommonOwnershipInfo()
        //                {
        //                    Partners = new List<GenericPersonInfo>
        //                        (
        //                           new GenericPersonInfo[]
        //                           {
        //                               new GenericPersonInfo() { PersonType = EntityType.Legal, LegalPerson = sigmaHldngsLtd },
        //                               new GenericPersonInfo() { PersonType = EntityType.Physical, PhysicalPerson = handrabura},
        //                               new GenericPersonInfo() { PersonType = EntityType.Physical, PhysicalPerson = holovatyi},
        //                               new GenericPersonInfo() { PersonType = EntityType.Legal, LegalPerson = ebensyCustdyLtd}
        //                           }
        //                        ),
        //                    OwnershipPct = 49.9M, OwnershipTestimony = "Довіренність про представництво спільних інтересів від 11.08.2007р.", OwnershipType = CommonOwnershipType.Implicit
        //                }
        //            }
        //        );

        //    questio.Signatory = new SignatoryInfo() { DateSigned = (DateTime.Now - new TimeSpan(360, 0, 0)).Date, SignatoryPosition = "Директор", SurnameInitials = "Голопупенко І.Й." };
        //    questio.ContactPerson = new PhysicalPersonInfo();
        //    questio.ContactPhone = "(050)254-51-35";
        //    #endregion

        //    #endregion
        //    XmlSerializer serializer = new XmlSerializer(typeof(Appx2OwnershipStructLP));
        //    serializer.Serialize(File.Create(@"D:\home\vmdrot\HaErez\BGU\Var\SignificantOwnership\XMLs\Appx2OwnershipStructLP.sample.xml"), questio);
        //}

        //private static void CreateSampleAppx2OwnershipStructLP_FnK()
        //{
        //    Appx2OwnershipStructLP questio = new Appx2OwnershipStructLP();
        //    #region filling sample with data
        //    //todo...
        //    #region re-usable constants
        //    #region countries
        //    CountryInfo countryUkraine = new CountryInfo() { CountryISO2Code = "UA", CountryISO3Code = "UKR", CountryISONr = "804", CountryNameEng = "Ukraine", CountryNameUkr = "Україна" };
        //    CountryInfo countryAustria = new CountryInfo() { CountryISO2Code = "AT", CountryISO3Code = "AUT", CountryISONr = "040", CountryNameEng = "Austria", CountryNameUkr = "Австрія" };
        //    CountryInfo countryCyprus = new CountryInfo() { CountryISO2Code = "CY", CountryISO3Code = "CYP", CountryISONr = "196", CountryNameEng = "Cyprus", CountryNameUkr = "Кіпр" };
        //    #endregion

        //    #region addresses
        //    LocationInfo mArnautska102 = new LocationInfo() { Country = countryUkraine, City = "Одеса", Region = "Одеська область", ZipCode = "65007", Street = "вул. Мала Арнаутська", HouseNr = "102", ApptOfficeNr = "5" };
        //    LocationInfo addrPerDiv83a = new LocationInfo() { Country = countryUkraine, City = "Одеса", Region = "Одеська область", ZipCode = "65016", Street = "вул. Фонтанська Дорога", HouseNr = "83" };
        //    LocationInfo addrKordProv13a = new LocationInfo() { Country = countryUkraine, City = "Одеса", Region = "Одеська область", ZipCode = "65074", Street = "пров. Кордонний", HouseNr = "13А" };
        //    LocationInfo addrTirasp22 = new LocationInfo() { Country = countryUkraine, City = "Одеса", Region = "Одеська область", ZipCode = "65020", Street = "вул. Тираспольська", HouseNr = "22", ApptOfficeNr = "3" };
        //    //https://www.post.at/suche/standortsuche.php/index/selectedsearch/plz?_cc_=1 , http://www.stadtplandienst.at/
        //    LocationInfo addrStPoeltenErtl3 = new LocationInfo() { Country = countryAustria, City = "St.Pölten", Region = "Niederösterreich", ZipCode = "AT-3100", Street = "Ertlstr.", HouseNr = "3", ApptOfficeNr = "5" };
        //    #endregion

        //    #region Registrars
        //    RegistrarAuthority kyivOdRVUMVS = new RegistrarAuthority()
        //    {
        //        //src: http://mvs.gov.ua/mvs/control/odesa/uk/publish/article/144997
        //        Address = new LocationInfo()
        //        {
        //            Country = countryUkraine,
        //            City = "Одеса",
        //            ZipCode = "65080",
        //            Street = "вул. Академіка Філатова",
        //            Region = "Одеська область",
        //            HouseNr = "15-А"
        //        },
        //        EntitiesHandled = EntityType.Physical,
        //        RegistrarCode = "",
        //        RegistrarName = "Київський РВ ОМУ ГУМВС України в Одеській області"
        //    };
        //    RegistrarAuthority magistratStPoelten = new RegistrarAuthority()
        //    {
        //        //src: https://www.help.gv.at/linkaufloesung/applikation-flow;jsessionid=557D7A72865E9928014A07F8671AB9E9.tomcat_help1?execution=e1s1
        //        Address = new LocationInfo()
        //        {
        //            Country = countryAustria,
        //            City = "St. Pölten",
        //            ZipCode = "3100",
        //            Street = "Rathausplatz",
        //            Region = "Niederösterreich",
        //            HouseNr = "1"
        //        },
        //        EntitiesHandled = EntityType.Physical,
        //        RegistrarCode = "",
        //        RegistrarName = "Magistrat St. Pölten"
        //    };
        //    RegistrarAuthority cyprusRegister = new RegistrarAuthority()
        //    {
        //        JurisdictionCountry = countryCyprus,
        //        EntitiesHandled = EntityType.Legal,
        //        RegistrarName = "DEPARTMENT OF REGISTRAR OF COMPANIES AND OFFICIAL RECEIVER",
        //        //RegistrarCode = "",
        //        Address = new LocationInfo()
        //        {
        //            Country = countryCyprus,
        //            City = "Nicosia",
        //            Street = "Corner Makarios Avenue & Karpenisiou",
        //            HouseNr = "XENIOS Building"
        //        }
        //    };
        //    RegistrarAuthority reestrOdesa = new RegistrarAuthority()
        //    {
        //        JurisdictionCountry = countryUkraine,
        //        RegistrarName = "Реєстраційна служба Одеського міського управління юстиції",
        //        Address = new LocationInfo() { Country = countryUkraine, City = "Одеса", Street = "вул. Велика Арнаутська", HouseNr = "15", ZipCode = "65012" },
        //        EntitiesHandled = EntityType.Legal,
        //        RegistrarCode = ""
        //    };
        //    #endregion

        //    #region physical persons
        //    PhysicalPersonInfo kacmanAM = new PhysicalPersonInfo()
        //    {
        //        CitizenshipCountry = countryUkraine,
        //        FullName = "Кацман Абрам Мойсейович",
        //        Name = "Абрам",
        //        MiddleName = "Мойсейович",
        //        Surname = "Кацман",
        //        PassportID = "ЕА 293857",
        //        PassIssueAuthority = kyivOdRVUMVS,
        //        PassIssuedDate = DateTime.Parse("1995-03-12T00:00:00"),
        //        TaxOrSocSecID = "0540117865",
        //        Address = addrPerDiv83a

        //    };

        //    PhysicalPersonInfo handrabura = new PhysicalPersonInfo()
        //    {
        //        CitizenshipCountry = countryUkraine,
        //        FullName = "Гандрабура Циля Авазівна",
        //        Name = "Циля",
        //        MiddleName = "Авазівна",
        //        Surname = "Гандрабура",
        //        PassportID = "КЕ 554635",
        //        PassIssueAuthority = kyivOdRVUMVS,
        //        PassIssuedDate = DateTime.Parse("1997-12-12T00:00:00"),
        //        TaxOrSocSecID = "5543216455",
        //        Address = addrKordProv13a
        //    };
        //    PhysicalPersonInfo holovatyi = new PhysicalPersonInfo()
        //    {
        //        CitizenshipCountry = countryUkraine,
        //        FullName = "Головатий Марко Пафнутійович",
        //        Name = "Марко",
        //        MiddleName = "Пафнутійович",
        //        Surname = "Головатий",
        //        PassportID = "АВ 135986",
        //        PassIssueAuthority = kyivOdRVUMVS,
        //        PassIssuedDate = DateTime.Parse("1993-10-05T00:00:00"),
        //        TaxOrSocSecID = "0514235444",
        //        Address = addrTirasp22

        //    };

        //    // sample - 
        //    PhysicalPersonInfo siehnert = new PhysicalPersonInfo()
        //    {
        //        CitizenshipCountry = countryAustria,
        //        FullName = "Siehnert Andreas Johann",
        //        Name = "Andreas",
        //        MiddleName = "Johann",
        //        Surname = "Siehnert",
        //        FullNameUkr = "Зінерт Андреас Йоганн",
        //        NameUkr = "Андреас",
        //        MiddleNameUkr = "Йоганн",
        //        SurnameUkr = "Зінерт",
        //        BirthDate = DateTime.Parse("1982-05-10T00:00:00"),
        //        Sex = SexType.Male,
        //        PassportID = "10008456", //http://de.wikipedia.org/wiki/Personalausweis#/media/File:Austrian_ID_card.jpg
        //        PassIssueAuthority = magistratStPoelten,
        //        PassIssuedDate = DateTime.Parse("2002-12-18T00:00:00"),
        //        TaxOrSocSecID = "1237 010180", //http://de.wikipedia.org/wiki/Sozialversicherungsnummer#.C3.96sterreich
        //        Address = addrStPoeltenErtl3

        //    };
        //    #endregion

        //    #region legal persons
        //    LegalPersonInfo markManLtd = new LegalPersonInfo() // https://efiling.drcor.mcit.gov.cy/DrcorPublic/SearchResults.aspx?name=Mark&number=%25&searchtype=optStartMatch&index=4&lang=EN&tname=%25&sc=1
        //    {
        //        Address = new LocationInfo()
        //        {
        //            Country = countryCyprus,
        //            City = "Μέσα Γειτονιά",
        //            Street = "Αρχ. Μακαρίου ΙΙΙ",
        //            HouseNr = "1",
        //            ApptOfficeNr = "ATLANTIS BUILDING, Floor 1",
        //            ZipCode = "4000",
        //            Region = "Λεμεσός"
        //        },
        //        ResidenceCountry = countryCyprus,
        //        Registrar = cyprusRegister,
        //        Name = "MARK MAN LIMITED",
        //        TaxCodeOrHandelsRegNr = "ΗΕ 68757"
        //    };

        //    LegalPersonInfo sigmaHldngsLtd = new LegalPersonInfo() // https://efiling.drcor.mcit.gov.cy/DrcorPublic/SearchResults.aspx?name=Sigma+holdings&number=%25&searchtype=optStartMatch&index=1&lang=EN&tname=%25&sc=1
        //    {
        //        Address = new LocationInfo()
        //        {
        //            Country = countryCyprus,
        //            City = "Λεμεσός",
        //            Street = "Γρ. Ξενοπούλου",
        //            HouseNr = "17",
        //            ZipCode = "3106"

        //        },
        //        ResidenceCountry = countryCyprus,
        //        Registrar = cyprusRegister,
        //        Name = "SIGMA EXPLORATIONS HOLDINGS LIMITED",
        //        TaxCodeOrHandelsRegNr = "ΗΕ 285734"
        //    };

        //    LegalPersonInfo ebensyCustdyLtd = new LegalPersonInfo() // https://efiling.drcor.mcit.gov.cy/DrcorPublic/SearchResults.aspx?name=custody&number=%25&searchtype=optStartMatch&index=1&lang=EN&tname=%25&sc=1
        //    {
        //        Address = new LocationInfo()
        //        {
        //            Country = countryCyprus,
        //            City = "Λεμεσός",
        //            Street = "Ρήγαινας",
        //            HouseNr = "13",
        //            ZipCode = "4632"

        //        },
        //        ResidenceCountry = countryCyprus,
        //        Registrar = cyprusRegister,
        //        Name = "EBENSY CUSTODY LIMITED",
        //        TaxCodeOrHandelsRegNr = "ΗΕ 140707",
        //        RepresentedBy = siehnert
        //    };
        //    #endregion

        //    #endregion

        //    #region the Questionnaire itself
        //    questio.BankRef = new BankInfo() { HeadMFO = "300614", Name = "ПАТ \"Креді Агріколь Банк\"", Code = "171", RegistryNr = "171" };
        //    questio.Acquiree = new LegalPersonInfo()
        //    {
        //        Address = mArnautska102,
        //        TaxCodeOrHandelsRegNr = "21546214",
        //        Name = "МЧП Ветерок",
        //        Registrar = reestrOdesa,
        //        ResidenceCountry = countryUkraine,
        //        RepresentedBy = kacmanAM
        //    };
        //    questio.IsSupervisoryCouncilPresent = true;
        //    questio.SupervisoryCouncil = new CouncilBodyInfo()
        //    {
        //        Members = new List<CouncilMemberInfo>
        //            (new CouncilMemberInfo[]
        //                                               {
        //                                                  new CouncilMemberInfo(){ Member = new GenericPersonInfo(){ PersonType = EntityType.Physical, PhysicalPerson = kacmanAM }, PositionName = "Голова"},
        //                                                  new CouncilMemberInfo(){ Member = new GenericPersonInfo(){ PersonType = EntityType.Legal, LegalPerson = ebensyCustdyLtd }, PositionName = "Член"},
        //                                                  new CouncilMemberInfo(){ Member = new GenericPersonInfo(){ PersonType = EntityType.Physical, PhysicalPerson = siehnert }, PositionName = "Член"}

        //                                               }
        //            ),
        //        HeadMemberIndex = 0
        //    };
        //    questio.IsExecutivesPresent = true;
        //    questio.Executives = new CouncilBodyInfo()
        //    {
        //        Members = new List<CouncilMemberInfo>
        //                  (
        //                       new CouncilMemberInfo[] 
        //                                                       { 
        //                                                           new CouncilMemberInfo() { Member = new GenericPersonInfo() { PersonType = EntityType.Physical, PhysicalPerson = handrabura}, PositionName = "Генеральний директор" }, 
        //                                                           new CouncilMemberInfo() { Member = new GenericPersonInfo() { PersonType = EntityType.Physical, PhysicalPerson = holovatyi }, PositionName = "Головний бухгалтер" }
        //                                                       }
        //                  ),
        //        HeadMemberIndex = 0
        //    };
        //    questio.TotalOwneshipPct = 24.5M;
        //    questio.TotalOwneshipDetails = new TotalOwnershipDetailsInfo()
        //    {
        //        DirectOwnership = new OwnershipSummaryInfo() { Pct = 12.3M, Amount = 33000000, Votes = 52 },
        //        ImplicitOwnership = new OwnershipSummaryInfo() { Pct = 10.2M, Amount = 30000000, Votes = 49 },
        //        AcquiredVotes = new OwnershipVotesInfo() { Pct = 2, Votes = 8 },
        //        TotalCapitalSharePct = 24.5M,
        //        TotalVotes = 52 + 49 + 8
        //    };
        //    //questio.CommonOwnership = new CommonOwnershipInfo();
        //    //questio.ImplicitOwnership = new ImplicitOwnershipInfo();
        //    questio.BankExistingCommonImplicitOwners = new List<CommonOwnershipInfo>
        //                                                   (
        //                                                    new CommonOwnershipInfo[]
        //                                                    {
        //                                                        new CommonOwnershipInfo() 
        //                                                        { 
        //                                                            Partners = new List<GenericPersonInfo>
        //                                                                            (
        //                                                                            new GenericPersonInfo[] 
        //                                                                            {
        //                                                                                new GenericPersonInfo()
        //                                                                                {
        //                                                                                    PersonType = EntityType.Legal,
        //                                                                                    LegalPerson = new LegalPersonInfo()
        //                                                                                                      {
        //                                                                                                          Address = mArnautska102, Name = "ТОВ \"Наяда\"", Registrar = reestrOdesa, RepresentedBy = kacmanAM, ResidenceCountry = countryUkraine, TaxCodeOrHandelsRegNr = "50245463"
        //                                                                                                      }
        //                                                                                }
        //                                                                            }
        //                                                                            ),
        //                                                                            OwnershipTestimony = "довіреність від 23.06.2001р.",
        //                                                                            OwnershipPct = 99.98M, OwnershipType = CommonOwnershipType.Implicit
        //                                                        },
        //                                                        new CommonOwnershipInfo() 
        //                                                        { 
        //                                                            Partners = new List<GenericPersonInfo>
        //                                                                            (
        //                                                                            new GenericPersonInfo[] 
        //                                                                            {
        //                                                                                new GenericPersonInfo()
        //                                                                                {
        //                                                                                PersonType = EntityType.Physical,
        //                                                                                PhysicalPerson = handrabura
        //                                                                                }
        //                                                                            }),
        //                                                            OwnershipPct = 0.02M, OwnershipType = CommonOwnershipType.Direct, OwnershipTestimony = ""
        //                                                        }
        //                                                    }
        //                                                   );
        //    questio.SharesAppliedFor = new List<PurchasedVoteInfo>(
        //                              new PurchasedVoteInfo[] 
        //                               {
        //                                   new PurchasedVoteInfo() { Transferror = new GenericPersonInfo() { PersonType = EntityType.Physical, LegalPerson = null, PhysicalPerson = holovatyi}, PurchaseVotes = new OwnershipVotesInfo() { Pct = 6.02M, Votes = 12}, VotesTransferPath = "довіреність від 03.12.2012"},
        //                                   new PurchasedVoteInfo() { Transferror = new GenericPersonInfo() { PersonType = EntityType.Legal, 
        //                                                             PhysicalPerson = null, 
        //                                                             LegalPerson = markManLtd }, 
        //                                                             PurchaseVotes = new OwnershipVotesInfo() { Pct = 5.11M, Votes = 51}, VotesTransferPath = "Power of attorney dd 22.10.2010"},
        //                               }
        //                             );
        //    questio.SignificantSharesPhysicalPersons = new List<PhysicalPersonShareInfo>
        //                                                    (
        //                                                      new PhysicalPersonShareInfo[] 
        //                                                      {
        //                                                          new PhysicalPersonShareInfo() { Person = handrabura, SharePct = 20M },
        //                                                          new PhysicalPersonShareInfo() { Person = holovatyi, SharePct = 15M },
        //                                                          new PhysicalPersonShareInfo() { Person = siehnert, SharePct = 14.5M }
        //                                                      }
        //                                                    );
        //    questio.SignificantSharesLegalPersons = new List<LegalPersonShareInfo>
        //                                                    (
        //                                                      new LegalPersonShareInfo[] 
        //                                                      {
        //                                                          new LegalPersonShareInfo() { Person = markManLtd, SharePct = 12M },
        //                                                          new LegalPersonShareInfo() { Person = sigmaHldngsLtd, SharePct = 11M },
        //                                                          new LegalPersonShareInfo() { Person = ebensyCustdyLtd, SharePct = 10.5M }
        //                                                      }
        //                                                    );
        //    questio.AcquireeCommonImplicitOwners = new List<CommonOwnershipInfo>
        //        (
        //            new CommonOwnershipInfo[]
        //            {
        //                new CommonOwnershipInfo()
        //                {
        //                    Partners = new List<GenericPersonInfo>
        //                        (
        //                           new GenericPersonInfo[]
        //                           {
        //                               new GenericPersonInfo() { PersonType = EntityType.Legal, LegalPerson = markManLtd },
        //                               new GenericPersonInfo() { PersonType = EntityType.Physical, PhysicalPerson = siehnert}
        //                           }
        //                        ),
        //                    OwnershipPct = 49.9M, OwnershipTestimony = "Угода про спільне володіння № 23/44 від 04.08.2007р.", OwnershipType = CommonOwnershipType.Direct
        //                },
        //                new CommonOwnershipInfo()
        //                {
        //                    Partners = new List<GenericPersonInfo>
        //                        (
        //                           new GenericPersonInfo[]
        //                           {
        //                               new GenericPersonInfo() { PersonType = EntityType.Legal, LegalPerson = sigmaHldngsLtd },
        //                               new GenericPersonInfo() { PersonType = EntityType.Physical, PhysicalPerson = handrabura},
        //                               new GenericPersonInfo() { PersonType = EntityType.Physical, PhysicalPerson = holovatyi},
        //                               new GenericPersonInfo() { PersonType = EntityType.Legal, LegalPerson = ebensyCustdyLtd}
        //                           }
        //                        ),
        //                    OwnershipPct = 49.9M, OwnershipTestimony = "Довіренність про представництво спільних інтересів від 11.08.2007р.", OwnershipType = CommonOwnershipType.Implicit
        //                }
        //            }
        //        );

        //    questio.Signatory = new SignatoryInfo() { DateSigned = (DateTime.Now - new TimeSpan(360, 0, 0)).Date, SignatoryPosition = "Директор", SurnameInitials = "Голопупенко І.Й." };
        //    questio.ContactPerson = new PhysicalPersonInfo();
        //    questio.ContactPhone = "(050)254-51-35";
        //    #endregion

        //    #endregion
        //    XmlSerializer serializer = new XmlSerializer(typeof(Appx2OwnershipStructLP));
        //    serializer.Serialize(File.Create(@"D:\home\vmdrot\HaErez\BGU\Var\SignificantOwnership\XMLs\Appx2OwnershipStructLP.sample.xml"), questio);
        //}
        #endregion

        #region location info parse test(s)
        private static void LocationInfoParser()
        {
            string addressesLnStr = @"61000,м.Харків, пр.Московський, буд.248, кв.31
61000,м.Харків,пр.Гагаріна,41а,кв.25
61166,м.Харків,вул.Леніна,5,кв.53
61000,м.Харків,вул.Артема,17,кв.3
62459,Харківська обл.,Харківський р-н.,пос.Високий,вул.Руднєва,34/2
61064,м.Харків,пров.Титаренківський, б.12, кв.40
61010,м.Харків,вул.Миргородська,буд.3
61000,м.Харків,вул.Танкопія,буд.11/3,кв.64
61010,м.Харків,вул.Миргородська,буд.3
61010,м.Харків,вул.Миргородська,буд.3,кв.1
61166,м.Харків,вул.Мінська,буд.109
61166,м.Харків,вул.Ромен Роллана,12
61058,м.Харків,вул.Ромен Роллана,12
61058,м.Харків,вул.Ромена Роллана,12
61000,м.Харків,вул. Танкопія, буд. 11/3, кв.64
61002,м.Харків,вул.Артема,46
61058,м.Харків,вул.Ромена Роллана,буд.12
61002,м.Харків, вул.Чубаря,1
62370,Харківська обл., Дергачівський р-н, смт.Солоницівка, вул. Пушкіна, буд.15/1
61022,м.Харків,вул.Сумська,буд.53,кв.4";

            string[] aAddrStrs = addressesLnStr.Split('\n');
            foreach (string addrStr in aAddrStrs)
                LocationInfoParserTestWorker(addrStr.Trim().Replace("\r", ""));
        }
        private static void LocationInfoParser2()
        {
            LocationInfoParserTestWorker("61000,м.Харків,вул. Танкопія, буд. 11/3, кв.64");
        }

        private static void LocationInfoParserTestWorker(string src)
        {
            LocationInfo li = LocationInfo.Parse(src);
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;
            string jsonStr = JsonConvert.SerializeObject(li, settings);
            Console.WriteLine("\"{0}\" recognized as {1}", src, jsonStr);
        }
        #endregion

        #region person info parse test(s)
        private static void ParseFillPassIssueData1()
        {
            string raw = @"МК 694952,вид.Фрунзенським РВ ХМУ УМВСУ в Харківській обл. 15.10.1996р.
МК 809348, вид.Комінтернівським РВ ХМУ УМВСУ в Харківській обл. 25.03.1998р.
МК 932068, вид.ЦВМ Дзержинського РВ ХМУ УМВСУ в Харківській обл.11.09.1998р.
МК 480110, вид.Київським МВРВ ХМУ УМВСУ в Харківській обл. 16.04.1997р.
МК 524005, вид.Харківським РВ УМВСУ в Харківській обл.25.07.1997р.
Свід. про народж.Серія 1-ВЛ № 192526, видане Відділом РАГС Жовтневого р-ну управління юстиції м.Харкова 28.12.2001р.
МК 175545, вид.Червонозаводським РВ УМВСУ в Харківській обл. 22.08.1996р.
МН 460280, вид.Фрунзенским РВ ХМУ УМВСУ в Харківській обл. 12.09.2002
МК 175546, вид.Червонозаводським РВ УМВСУ в Харківській обл. 22.08.1996р.
МК 894983 вид. Жовтневим РВ ХМУ УМВСУ в Харківській обл.22.07.1998 р.";
            string[] aStrs = raw.Split('\n');
            foreach (string str in aStrs)
                PhysPersonInfoParserTestWorker(str.Trim().Replace("\r", ""));

        }
        private static void ParseFillPassIssueData2()
        {
            string raw = @"паспорт серія МЕ№886790,виданий Шевченківським РУГУ МВС України в м.Києві 11.09.2008р.
паспорт СО 945448 виданий Оболонським РУГУМВС Украєни в м.Киґвi 14.06.2002р.
паспорт СК 346257 виданий Василькiвським МВГУМВС Украєни в Києвськiй обл. 19.12.1996р.
паспорт СН 382939 виданий Залiзничним РУГУМВС Украєни в м.Киґвi 23.01.1997р.
паспорт СН 527104 виданий Харкiвським РУГУМВС Украєни в м.Киґвi 26.11.1997р.
паспорт СН 758632 виданий Харкiвським РУГУМВС Украєни в м.Киґвi 31.03.1998р.
паспорт СН 677961 виданий Ватутiнським РУГУМВС Украєни в м.Киґвi 25.12.1997р.
паспорт СО 407604 виданий Мiнським РУГУМВС Украєни в м.Киґвi 06.06.2000р.
паспорт СА 349224 виданий Ленiнським РВУМВС Украєни в Запорiзькiй обл. 23.01.1997р.
паспорт СО 751860 виданий Деснянським РУГУМВС Украєни в м.Киґвi 22.11.2001р.
паспорт СО 298808 виданий Ленiнградським РУГУМВС Украєни в м.Киґвi 30.12.1999р.
паспорт СН 615775 виданий Старокиєвським РУГУМВС Украєни в м. Киґвi 05.02.1998р.
паспорт СО 365057,  виданий Печерським РУ ГУ МВС України в м. Києві, 28.04.2000
паспорт МЕ 829658, виданий Голосіївським РУ ГУ МВС України в м. Києві, 26.10.2007
пасп. КЕ 122546 виданий Приморcьким РВ УМВС Украєни Одеськiй обл. 22.12.95
паспорт СН ї 134608 видан Харківським РУГУ МВС України в м. Києві, 30.04.1996р.
паспорт МЕ ї 949460,  видан. Шевченківським  РУГУ МВС України в м. Києві 03.09.2009р.
паспорт СО ї 864630 виданий Шевченківським РУГУ МВС України в м. Києві, 09.04.2002р.
паспорт СО ї 052397 виданий Радянським РУГУ МВС України в м. Києві, 25.02.1999р.
паспорт СН ї 936281 виданий Дніпровським РУГУ МВС України в м. Києві, 29.10.1998р.
паспорт СО ї 560015 виданий Ленінградським РУГУ МВС України в м. Києві, 23.03.2001р.
паспорт СН ї 669763 виданий Радянським РУГУ МВС України в м. Києві, 18.12.1997р.
паспорт СО ї 424909 виданий Печерським РУГУ МВС України в м. Києві, 07.07.2000р.
паспорт СН ї 681771виданий Харківським РУГУ МВС України в м. Києві, 20.01.1998р.
";
            string[] aStrs = raw.Split('\n');
            foreach (string str in aStrs)
                PhysPersonInfoParserTestWorker(str.Trim().Replace("\r", ""));
        }

        private static void PhysPersonInfoParserTestWorker(string src)
        {
            PhysicalPersonInfo.ParseMatchInfo pmi;
            PhysicalPersonInfo ppi = new PhysicalPersonInfo();
            PhysicalPersonInfo.TryParseFillPassIssueData(src, ppi, out pmi);
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;
            string jsonStr = JsonConvert.SerializeObject(pmi.NonRecognizedParts, settings);
            string jsonStr1 = JsonConvert.SerializeObject(ppi, settings);
            Console.WriteLine("\"{0}\": non-recognized - {1}, details: {2}", src, jsonStr, jsonStr1);
        }


        #endregion

        #region real banks XML output

        private static void WriteXML_Grant()
        {
            GrantBank provider = new GrantBank();
            WriteXML(provider.Appx2Questionnaire, @"D:\home\vmdrot\HaErez\BGU\Var\SignificantOwnership\XMLs\Appx2OwnershipStructLP.Grant.xml");
        }


        private static void WriteXML(Appx2OwnershipStructLP questio, string saveAs)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Appx2OwnershipStructLP));
            serializer.Serialize(File.Create(saveAs), questio);
        }
        #endregion

        #region validate checkers test(s)
        private static void BuildOwnershipGraphGrantBankTest()
        {
            GrantBank gb = new GrantBank();
            Appx2OwnershipStructLPChecker checker = new Appx2OwnershipStructLPChecker();
            checker.Questionnaire = gb.Appx2Questionnaire;
            Console.WriteLine(checker.BuildOwnershipGraph());
        }
        #endregion

        #region neat XSD-related
        private static void UpdateXSDsTranslations(string[] args)
        {
            //Type[] types2Process = new Type[] { typeof(Appx2OwnershipStructLP)};
            _alreadyProcessedXSDExportTypes = new Dictionary<string, bool>();
//            Type[] types2Process = new Type[] { typeof(Appx2OwnershipStructLP),
//typeof(Appx3OwnershipStructPP),
//typeof(RegLicAppx12HeadCandidateAppl),
//typeof(RegLicAppx14NewSvc),
//typeof(RegLicAppx17EquityChangeTable),
//typeof(RegLicAppx2OwnershipAcqRequestLP),
//typeof(RegLicAppx3MemberCandidateAppl),
//typeof(RegLicAppx4OwnershipAcqRequestPP),
//typeof(RegLicAppx6EquityFormationTable),
//typeof(RegLicAppx7ShareAcqIntent),
//typeof(RegLicAppx9BankingLicenseAppl)};

            XmlDocument assemblySummariesXml = XSDReflectionUtil.LoadAnnotationXml(typeof(Appx2OwnershipStructLP).Assembly);
            string[] auxNamespacesNames = new string[] { "BGU.DRPL.SignificantOwnership.Core.Spares.Data", "BGU.DRPL.SignificantOwnership.Core.Spares.Dict", "BGU.DRPL.SignificantOwnership.Core.Spares" };
            string[] questNamespacesNames = new string[] { "BGU.DRPL.SignificantOwnership.Core.Questionnaires" };
            //CallXsdExe("BGU.DRPL.SignificantOwnership.Core.Spares.*");
            //File.Copy(Path.Combine(XsdFilesOutputDir, "schema0.xsd"), Path.Combine(XsdFilesOutputDir, "all_spares.xsd"), true);
            //File.Copy(Path.Combine(XsdFilesOutputDir, "schema0.xsd"), Path.Combine(XsdFilesOutputDir, "all_spares.uk-UA.xsd"), true);
            //ProcessXSDSingle(Path.Combine(XsdFilesOutputDir, "all_spares.uk-UA.xsd"), assemblySummariesXml);
            //CallXmlFormatterExe(Path.Combine(XsdFilesOutputDir, "all_spares.uk-UA.xsd"));
            //List<Type> allAndEveryTypes = XSDReflectionUtil.ListTypes(types2Process[0], new string[]{});

            List<Type> allAuxTypes = XSDReflectionUtil.ListTypes(typeof(Appx2OwnershipStructLP), auxNamespacesNames, System.Reflection.BindingFlags.Public, true);
            List<Type> questTypes = XSDReflectionUtil.ListTypes(typeof(Appx2OwnershipStructLP), questNamespacesNames, System.Reflection.BindingFlags.Public, true);
            List<Type> allTypes = new List<Type>(allAuxTypes);
            allTypes.AddRange(questTypes);

            //foreach (Type typ in types2Process)
            foreach (Type typ in allTypes)
            {
                ProcessTypeExport2XSD(typ, assemblySummariesXml);
            }
        }

        private static void ProcessTypeExport2XSD(Type typ, XmlDocument assemblySummariesXml)
        {
            CallXsdExe(typ.FullName);
            File.Copy(Path.Combine(XsdFilesOutputDir, "schema0.xsd"), Path.Combine(XsdFilesOutputDir, string.Format("{0}.xsd", typ.Name.Trim())), true);
            File.Copy(Path.Combine(XsdFilesOutputDir, "schema0.xsd"), Path.Combine(XsdFilesOutputDir, string.Format("{0}.uk-UA.xsd", typ.Name.Trim())), true);
            ProcessXSDSingle(typ, assemblySummariesXml, "uk-UA.", true);
            File.Copy(Path.Combine(XsdFilesOutputDir, "schema0.xsd"), Path.Combine(XsdFilesOutputDir, string.Format("{0}.full.uk-UA.xsd", typ.Name.Trim())), true);
            ProcessXSDSingle(typ, assemblySummariesXml, "uk-UA.",false);
        }

        private static void CallXmlFormatterExe(string xsdPath)
        {
            string strCmdText = string.Format(@"/C ""{0}"" ""{1}""", XmlFormatterPath, xsdPath);

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.FileName = "cmd.exe";//XsdExePath;
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.Arguments = strCmdText;
            process.StartInfo = startInfo;
            bool bStarted = process.Start();
            if (bStarted)
                process.WaitForExit();

        }

        private static void CallXsdExe(string typeName)
        {
            string strCmdText = null;
            if(string.IsNullOrEmpty(typeName))
                strCmdText = string.Format(@"/C ""{1}"" BGU.DRPL.SignificantOwnership.Core.dll /outputdir:{0} >> {2}", XsdFilesOutputDir, XsdExePath, Path.Combine(XsdFilesOutputDir, "xsd.log.txt"));
            else
                strCmdText = string.Format(@"/C ""{2}"" BGU.DRPL.SignificantOwnership.Core.dll /outputdir:{0} /type:{1} >> {3}", XsdFilesOutputDir, typeName, XsdExePath, Path.Combine(XsdFilesOutputDir, "xsd.log.txt"));

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            //startInfo.FileName = XsdExePath;
            startInfo.FileName = "cmd.exe";//XsdExePath;
            startInfo.Arguments = strCmdText;
            process.StartInfo = startInfo;
            //using (FileStream fs = new FileStream(@"D:\home\vmdrot\BGU\Specs\SignigicantOwnership\XMLs\xsd.log.txt", System.IO.FileMode.Append))
            //{
            //    process.StandardOutput = fs;
            //    //process.StartInfo.UseShellExecute = true;
            //    bool bStarted = process.Start();
            //    if (bStarted)
            //        process.WaitForExit();
            //}
            bool bStarted = process.Start();
            if (bStarted)
                process.WaitForExit();
        }

        private static void ProcessXSDTest()
        {

            string fileNames = @"Appx2OwnershipStructLP.xsd
Appx3OwnershipStructPP.xsd
RegLicAppx12HeadCandidateAppl.xsd
RegLicAppx14NewSvc.xsd
RegLicAppx17EquityChangeTable.xsd
RegLicAppx2OwnershipAcqRequestLP.xsd
RegLicAppx3MemberCandidateAppl.xsd
RegLicAppx4OwnershipAcqRequestPP.xsd
RegLicAppx6EquityFormationTable.xsd
RegLicAppx7ShareAcqIntent.xsd
RegLicAppx9BankingLicenseAppl.xsd";
            string[] aFnames = fileNames.Split('\n');
            foreach (string fnm in aFnames)
                ProcessXSDSingle(fnm.Trim(),null,null);

        }



        private static void ProcessXSDSingle(string fullPath, XmlDocument assemblySummariesXml, Type specificType)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fullPath);
            if(specificType == null)
                XSDReflectionUtil.InjectDispProps(doc, _alreadyProcessedXSDExportTypes, assemblySummariesXml, XsdPutDispNmDescrIntoAnnotation);
            else
                XSDReflectionUtil.InjectDispProps(doc, _alreadyProcessedXSDExportTypes, assemblySummariesXml, XsdPutDispNmDescrIntoAnnotation, specificType);
            doc.Save(fullPath);
        }

        private static void ProcessXSDSingle(Type typ, XmlDocument assemblySummariesXml, string extraFileExt, bool bRemoveAllOtherTypes)
        {
            string targetPath = Path.Combine(XsdFilesOutputDir, string.Format("{0}{1}.{2}xsd", typ.Name.Trim(), (bRemoveAllOtherTypes ? "" : ".full"), extraFileExt));
            if(!bRemoveAllOtherTypes)
                ProcessXSDSingle(targetPath, assemblySummariesXml, null);
            else
                ProcessXSDSingle(targetPath, assemblySummariesXml, typ);
            CallXmlFormatterExe(targetPath);
        }
        #endregion

        #region WPF gen-related
        public static void GenerateXAMLs4RegLicAppx2(string[] args)
        {
            //string targetFolder = @"D:\home\vmdrot\DEV\_tut\WpfApplication2\WpfApplication2\Resources";
            string targetFolder = @"D:\home\vmdrot\TMP\XAMLTemplates";
            XAMLTemplatesGenerationManager.GenerateXAMLTemplates(typeof(RegLicAppx2OwnershipAcqRequestLP), typeof(RegLicAppx2OwnershipAcqRequestLP).Assembly, targetFolder);
            XAMLTemplatesGenerationManager.GenerateXAMLTemplates(typeof(Appx2OwnershipStructLP), typeof(RegLicAppx2OwnershipAcqRequestLP).Assembly, targetFolder);
            XAMLTemplatesGenerationManager.GenerateXAMLTemplates(typeof(RegLicAppx14NewSvc), typeof(RegLicAppx2OwnershipAcqRequestLP).Assembly, targetFolder);
            XAMLTemplatesGenerationManager.GenerateXAMLTemplates(typeof(RegLicAppx3MemberCandidateAppl), typeof(RegLicAppx2OwnershipAcqRequestLP).Assembly, targetFolder);
            XAMLTemplatesGenerationManager.GenerateXAMLTemplates(typeof(RegLicAppx4OwnershipAcqRequestPP), typeof(RegLicAppx2OwnershipAcqRequestLP).Assembly, targetFolder);
        }

        public static void GenerateXAMLs4BkInfo(string[] args)
        {
            string targetFolder = @"D:\home\vmdrot\TMP\XAMLTemplates";
            XAMLTemplatesGenerationManager.GenerateXAMLTemplates(typeof(StateBankRegistryEntry), typeof(StateBankRegistryEntry).Assembly, targetFolder);
        }

        #endregion

        #region BankInfo-related

        private static void BanksHierarchy(string[] args)
        {
            List<DeptListEntry> depts = ListDepts();

            BGU.DRPL.SignificantOwnership.Facade.EKDRBU.DeptListUtil.BuildHierarchy(depts);
            PrintDeptsWorker(depts);
        }

        private static void PrintDeptsWorker(List<DeptListEntry> depts)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;
            foreach (DeptListEntry dle in depts)
            {
                string jsonStr = JsonConvert.SerializeObject(dle, settings);
                Console.WriteLine("{0}", jsonStr);
            }
        }

        private static List<DeptListEntry> ListDepts()
        {
            List<DeptListEntry> depts = new List<DeptListEntry>();
            DataTable dt = RcuKruReader.Read(@"D:\home\vmdrot\BGU\Var\DerzhReiestr\ShBO\dptlist.dbf");
            foreach (DataRow dr in dt.Rows)
            {
                depts.Add(DeptListEntry.Parse(dr));
            }
            return depts;
        }
        #endregion


        #region Arkada parsing-related
        private static void ArkadaOwnershipChainParserTest(string[] args)
        {
            List<List<string>> interestingRows = JsonConvert.DeserializeObject<List<List<string>>>(File.ReadAllText(@"D:\home\vmdrot\BGU\Specs\SignigicantOwnership\Testing\Arkada\Arkada_signowners_last.json"));


            List<Post328Dod2V1Row> dod2PrincipalRows;
            List<Post328Dod2V1FormulaRow> dod2FormulaRows;
            List<Post328Dod3V1Row> dod3PrincipalRows;
            Post328DodRowBase.ParseArkadaRows(interestingRows, out dod2PrincipalRows, out dod2FormulaRows, out dod3PrincipalRows);

            Dictionary<string, List<ArkadaOwnershipChainDescriptionParser.WordingItem>> rslt = new Dictionary<string, List<ArkadaOwnershipChainDescriptionParser.WordingItem>>();
            foreach (Post328Dod2V1Row row in dod2PrincipalRows)
            {
                ArkadaOwnershipChainDescriptionParser parser = new ArkadaOwnershipChainDescriptionParser();
                List<ArkadaOwnershipChainDescriptionParser.WordingItem> lst = parser.SplitIntoWordings(row.OwnershipChainDescr, row.Name);
                rslt.Add(row.Name, lst);
            }

            Dictionary<string, List<ArkadaOwnershipChainDescriptionParser.WordingItem>> fillOwnersErrors;
            ArkadaOwnershipChainDescriptionParser.FillOwners(rslt, out fillOwnersErrors);

            #region print-out
            int totalWordingsCount = 0;
            foreach (string key in rslt.Keys)
                totalWordingsCount += rslt[key].Count;
            Console.WriteLine("totalWordingsCount = {0}", totalWordingsCount);
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;
            settings.Formatting = Newtonsoft.Json.Formatting.Indented;
            string jsonStr = JsonConvert.SerializeObject(rslt, settings);
            string errorsJson = JsonConvert.SerializeObject(fillOwnersErrors, settings);
            File.WriteAllText(@"D:\home\vmdrot\BGU\Specs\SignigicantOwnership\Testing\Arkada\ArkadaOwnershipChainParserTest_rslt.json", jsonStr, Encoding.Unicode);
            File.WriteAllText(@"D:\home\vmdrot\BGU\Specs\SignigicantOwnership\Testing\Arkada\ArkadaOwnershipChainParserTest_fillOwnersErrors.json", errorsJson, Encoding.Unicode);

            #region verify owners from formulas vs rslt

            //below doesn't work
            //Console.WriteLine("dod2FormulaRows.Count = {0}", dod2FormulaRows.Count);
            //Console.WriteLine("rslt.Keys.Count = {0}", rslt.Keys.Count);
            //var joint = from f in dod2FormulaRows
            //            join r in rslt on ArkadaOwnershipChainDescriptionParser.TrimLine(f.Name) equals ArkadaOwnershipChainDescriptionParser.TrimLine(r.Key)
            //            select f;
            //string jointStr = JsonConvert.SerializeObject(joint, settings);
            //File.WriteAllText(@"D:\home\vmdrot\BGU\Specs\SignigicantOwnership\Testing\Arkada\ArkadaOwnershipChainParserTest_joint.json", errorsJson, Encoding.Unicode);

            List<string> foundOwners = new List<string>();
            List<string> notFoundOwners = new List<string>();
            foreach (Post328Dod2V1FormulaRow formula in dod2FormulaRows)
            {
                if (rslt.ContainsKey(formula.Name))
                    foundOwners.Add(formula.Name);
                else
                    notFoundOwners.Add(formula.Name);
            }
            List<List<string>> tmp = new List<List<string>>(new List<string>[] { foundOwners, notFoundOwners });
            string tmpJsonStr = JsonConvert.SerializeObject(tmp, settings);
            File.WriteAllText(@"D:\home\vmdrot\BGU\Specs\SignigicantOwnership\Testing\Arkada\ArkadaOwnershipChainParserTest_rslt_vs_formulas.json", tmpJsonStr, Encoding.Unicode);
            #endregion

            Appx2OwnershipStructLP qu = ArkadaOwnershipChainDescriptionParser.ConvertWordingItems2OwnershipHive(rslt, dod2PrincipalRows, "ПАТ  АКБ  \"АРКАДА\"");
            File.WriteAllText(@"D:\home\vmdrot\BGU\Specs\SignigicantOwnership\Testing\Arkada\ArkadaOwnershipChainParserTest_Appx2Qu.json", JsonConvert.SerializeObject(qu, settings), Encoding.Unicode);
            BGU.DRPL.SignificantOwnership.Utility.Tools.WriteXML<Appx2OwnershipStructLP>(qu, @"D:\home\vmdrot\BGU\Specs\SignigicantOwnership\Testing\Arkada\ArkadaOwnershipChainParserTest_Appx2Qu.xml");
            File.WriteAllText(@"D:\home\vmdrot\BGU\Specs\SignigicantOwnership\Testing\Arkada\ArkadaOwnershipChainParserTest_Appx2Qu_MentionedIdentities.json", JsonConvert.SerializeObject(qu.MentionedIdentities, settings), Encoding.Unicode);
               //var pl = from r in info
               //  orderby r.metric    
               //  group r by r.metric into grp
               //  select new { key = grp.Key, cnt = grp.Count()};
            var osStats = from oh in qu.BankExistingCommonImplicitOwners
                          orderby oh.Asset.HashID, oh.Owner.HashID, oh.SharePct
                          group oh by string.Format("{0}-{1}-{2}", oh.Asset, oh.Owner, oh.SharePct) into grp
                          select new { key = grp.Key, cnt = grp.Count() };
            File.WriteAllText(@"D:\home\vmdrot\BGU\Specs\SignigicantOwnership\Testing\Arkada\ArkadaOwnershipChainParserTest_Appx2Qu_OSStats.json", JsonConvert.SerializeObject(osStats, settings), Encoding.Unicode);
            var lps = from mp in qu.MentionedIdentities
                      where mp.PersonType == EntityType.Legal
                      select mp.ID.HashID;
            File.WriteAllText(@"D:\home\vmdrot\BGU\Specs\SignigicantOwnership\Testing\Arkada\ArkadaOwnershipChainParserTest_Appx2Qu_LPs.json", JsonConvert.SerializeObject(lps, settings), Encoding.Unicode);
            //Console.WriteLine("descRows.Count = {0}", descRows.Count);

            //File.WriteAllLines(@"D:\home\vmdrot\BGU\Specs\SignigicantOwnership\Testing\Arkada\DescrRows.txt", descRows.ToArray(), Encoding.Unicode);
            #endregion
        }


        private static void ArkadaOwnershipChainAnalysis(string[] args)
        {
            string hashIdsFile = args.Length > 1 ? args[1] : string.Empty;
            string selHashIdIdxStr = args.Length > 2 ? args[2] : string.Empty;
            string selHashId = string.Empty;
            Appx2OwnershipStructLP qu = JsonConvert.DeserializeObject<Appx2OwnershipStructLP>(File.ReadAllText(@"D:\home\vmdrot\BGU\Specs\SignigicantOwnership\Testing\Arkada\ArkadaOwnershipChainParserTest_Appx2Qu.json"));
            
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;
            settings.Formatting = Newtonsoft.Json.Formatting.Indented;


            if (!string.IsNullOrEmpty(hashIdsFile) && File.Exists(hashIdsFile))
            {
                List<string> hashIds = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(hashIdsFile));
                int selHashIdIdx;
                if(int.TryParse(selHashIdIdxStr, out selHashIdIdx))
                {
                    if (hashIds != null && hashIds.Count > selHashIdIdx)
                    {
                        selHashId = hashIds[selHashIdIdx];
                        Console.WriteLine("selHashId = '{0}'", selHashId);
                        var os4sel = from os in qu.BankExistingCommonImplicitOwners
                                     where os.Asset.HashID == selHashId
                                     select os;
                        File.WriteAllText(string.Format(@"D:\home\vmdrot\BGU\Specs\SignigicantOwnership\Testing\Arkada\ArkadaOwnershipChainAnalysis_selOS_{0}.json", selHashIdIdx), JsonConvert.SerializeObject(os4sel, settings), Encoding.Unicode);
                    }
                }
            }
            
            foreach (GenericPersonInfo gpi in qu.MentionedIdentities)
            {

                if (!string.IsNullOrEmpty(selHashId))
                {
                    if (gpi.ID.HashID != selHashId)
                        continue;
                }
                else
                {
                    if (gpi.PersonType != EntityType.Legal || gpi.ID == qu.BankRef.LegalPerson)
                        continue;

                }
                try
                {
                    Appx2OwnershipStructLPChecker checker = new Appx2OwnershipStructLPChecker();
                    checker.Questionnaire = qu;
                    //checker.IndentString = "    ";
#if __TEMPORARILY_SKIP__
                    checker.ListUltimateBeneficiaries(gpi.ID);
                    Console.WriteLine("Passed for {0}", gpi.DisplayName);
#endif
                }
                catch (Exception exc)
                {
                    Console.WriteLine("failed for {0}, details: '{1}'", gpi.DisplayName, exc.Message);
                    Console.WriteLine(exc);
                    Console.WriteLine("-------------------------------------------------------");
                }
            }
        }
        #endregion

    }
}
