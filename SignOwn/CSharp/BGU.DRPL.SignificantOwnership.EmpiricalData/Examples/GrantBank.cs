using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;
using BGU.DRPL.SignificantOwnership.Core.Questionnaires;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;

namespace BGU.DRPL.SignificantOwnership.EmpiricalData.Examples
{
    public class GrantBank
    {
        //private List<PhysicalPersonInfo> _INDs;
        //private List<LegalPersonInfo> _LEs;
        private Appx2OwnershipStructLP _appx2Questionnaire;
        #region particular entities
        private GenericPersonInfo physShkarupinaTA;
        private GenericPersonInfo physPohuliaievaLM;
        private GenericPersonInfo physKravchenkoIV;
        private GenericPersonInfo physLikhnoVP;
        private GenericPersonInfo physPopovOA;
        private GenericPersonInfo physSymovianSV;
        private GenericPersonInfo physSymovianVS;
        private GenericPersonInfo physIliinVV;
        private GenericPersonInfo physSymovianVP;
        private GenericPersonInfo physSymovianSV2;
        private GenericPersonInfo physTovazhnianskyiVL;
        private GenericPersonInfo leInvariantPlus;
        private GenericPersonInfo leTDVSKGrantservis;
        private GenericPersonInfo leArgusSoft;
        private GenericPersonInfo physIliinaSD;
        private GenericPersonInfo leInvesta;
        private GenericPersonInfo leIntekh;
        private GenericPersonInfo leArgus;
        private GenericPersonInfo leResidentsiaSV;
        private GenericPersonInfo leYurstokconsulting;
        private GenericPersonInfo leTheBank;
        #endregion



        public Appx2OwnershipStructLP Appx2Questionnaire
        {
            get
            {
                if (_appx2Questionnaire == null)
                    _appx2Questionnaire = GenerateAppx2Questionnaire();
                return _appx2Questionnaire;
             }
        }

        private void PopulateDicts()
        {
            #region countries
            
            #endregion

            #region addresses
            LocationInfo addrKhaMost248kv31 = LocationInfo.Parse("61000,м.Харків, пр.Московський, буд.248, кв.31"); addrKhaMost248kv31.Country = CountryInfo.UKRAINE;
            LocationInfo addrKhaGag41a25 = LocationInfo.Parse("61000,м.Харків,пр.Гагаріна,41а,кв.25"); addrKhaGag41a25.Country = CountryInfo.UKRAINE;
            LocationInfo addreKhaLen5kv53 = LocationInfo.Parse("61166,м.Харків,вул.Леніна,5,кв.53"); addreKhaLen5kv53.Country = CountryInfo.UKRAINE;
            LocationInfo addrKhaArt17kv3 = LocationInfo.Parse("61000,м.Харків,вул.Артема,17,кв.3"); addrKhaArt17kv3.Country = CountryInfo.UKRAINE;
            LocationInfo addrKhaVysRudn342 = LocationInfo.Parse("62459,Харківська обл.,Харківський р-н.,пос.Високий,вул.Руднєва,34/2"); addrKhaVysRudn342.Country = CountryInfo.UKRAINE;
            LocationInfo addrKhaTytar12kv40 = LocationInfo.Parse("61064,м.Харків,пров.Титаренківський, б.12, кв.40"); addrKhaTytar12kv40.Country = CountryInfo.UKRAINE;
            LocationInfo addrKhaMyrh3 = LocationInfo.Parse("61010,м.Харків,вул.Миргородська,буд.3"); addrKhaMyrh3.Country = CountryInfo.UKRAINE;
            LocationInfo addrKhaTankop113kv64 = LocationInfo.Parse("61000,м.Харків,вул.Танкопія,буд.11/3,кв.64"); addrKhaTankop113kv64.Country = CountryInfo.UKRAINE;
            LocationInfo addrKhaMyrh3kv1 = LocationInfo.Parse("61010,м.Харків,вул.Миргородська,буд.3,кв.1"); addrKhaMyrh3kv1.Country = CountryInfo.UKRAINE;
            LocationInfo addrKhaMin109 = LocationInfo.Parse("61166,м.Харків,вул.Мінська,буд.109"); addrKhaMin109.Country = CountryInfo.UKRAINE;
            LocationInfo addrKhaRomRol12 = LocationInfo.Parse("61166,м.Харків,вул.Ромен Роллана,12"); addrKhaRomRol12.Country = CountryInfo.UKRAINE;
            LocationInfo addrKhaArt46 = LocationInfo.Parse("61002,м.Харків,вул.Артема,46"); addrKhaArt46.Country = CountryInfo.UKRAINE;
            LocationInfo addrKhaCubar1 = LocationInfo.Parse("61002,м.Харків, вул.Чубаря,1"); addrKhaCubar1.Country = CountryInfo.UKRAINE;
            LocationInfo addrKhaDergSolonytsPushk151 = LocationInfo.Parse("62370,Харківська обл., Дергачівський р-н, смт.Солоницівка, вул. Пушкіна, буд.15/1"); addrKhaDergSolonytsPushk151.Country = CountryInfo.UKRAINE;
            LocationInfo addrKhaSums53kv4 = LocationInfo.Parse("61022,м.Харків,вул.Сумська,буд.53,кв.4"); addrKhaSums53kv4.Country = CountryInfo.UKRAINE;
            LocationInfo addrKhaDanyl19 = LocationInfo.Parse("61001, м.Харків, вулиця Данилевського, 19"); addrKhaDanyl19.Country = CountryInfo.UKRAINE;

            #endregion

            #region registrar(s)

            #endregion

            #region Phys
            physShkarupinaTA = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { CitizenshipCountry = CountryInfo.UKRAINE, FullName = "Шкарупіна Тамара Іванівна", TaxOrSocSecID = "2062001867", Address = addrKhaMost248kv31 } }; PhysicalPersonInfo.TryParseFillPassIssueData("МК 694952,вид.Фрунзенським РВ ХМУ УМВСУ в Харківській обл. 15.10.1996р.", physShkarupinaTA.PhysicalPerson);
            physPohuliaievaLM = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { CitizenshipCountry = CountryInfo.UKRAINE, FullName = "Погуляєва Любов Миколаївна", TaxOrSocSecID = "1634500989", Address = addrKhaGag41a25 } }; PhysicalPersonInfo.TryParseFillPassIssueData("МК 809348, вид.Комінтернівським РВ ХМУ УМВСУ в Харківській обл. 25.03.1998р.", physPohuliaievaLM.PhysicalPerson);
            physKravchenkoIV = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { CitizenshipCountry = CountryInfo.UKRAINE, FullName = "Кравченко Ігор Володимирович", TaxOrSocSecID = "2242501574", Address = addreKhaLen5kv53 } }; PhysicalPersonInfo.TryParseFillPassIssueData("МК 932068, вид.ЦВМ Дзержинського РВ ХМУ УМВСУ в Харківській обл.11.09.1998р.", physKravchenkoIV.PhysicalPerson);
            physLikhnoVP = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { CitizenshipCountry = CountryInfo.UKRAINE, FullName = "Ліхно Валентина Петрівна", TaxOrSocSecID = "1565405328", Address = addrKhaArt17kv3 } }; PhysicalPersonInfo.TryParseFillPassIssueData("МК 480110, вид.Київським МВРВ ХМУ УМВСУ в Харківській обл. 16.04.1997р.", physLikhnoVP.PhysicalPerson);
            physPopovOA = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { CitizenshipCountry = CountryInfo.UKRAINE, FullName = "Попов Олександр Анатолійович", TaxOrSocSecID = "1870501294", Address = addrKhaVysRudn342 } }; PhysicalPersonInfo.TryParseFillPassIssueData("МК 524005, вид.Харківським РВ УМВСУ в Харківській обл.25.07.1997р.", physPopovOA.PhysicalPerson);
            physSymovianSV2 = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { CitizenshipCountry = CountryInfo.UKRAINE, FullName = "Симов'ян Саркіс Ваграмович", TaxOrSocSecID = "3710304336", Address = addrKhaTytar12kv40 } }; PhysicalPersonInfo.TryParseFillPassIssueData("Свід. про народж.Серія 1-ВЛ № 192526, видане Відділом РАГС Жовтневого р-ну управління юстиції м.Харкова 28.12.2001р.", physSymovianSV2.PhysicalPerson);
            physSymovianVS = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { CitizenshipCountry = CountryInfo.UKRAINE, FullName = "Симов'ян Ваган Саркисович", TaxOrSocSecID = "2896701117", Address = addrKhaMyrh3 } }; PhysicalPersonInfo.TryParseFillPassIssueData("МК 175545, вид.Червонозаводським РВ УМВСУ в Харківській обл. 22.08.1996р.", physSymovianVS.PhysicalPerson);
            physIliinVV = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { CitizenshipCountry = CountryInfo.UKRAINE, FullName = "Ільїн Владислав Володимирович", TaxOrSocSecID = "3145510910", Address = addrKhaTankop113kv64 } }; PhysicalPersonInfo.TryParseFillPassIssueData("МН 460280, вид.Фрунзенским РВ ХМУ УМВСУ в Харківській обл. 12.09.2002", physIliinVV.PhysicalPerson);
            physSymovianSV = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { CitizenshipCountry = CountryInfo.UKRAINE, FullName = "Симов'ян Саркіс Ваграмович", TaxOrSocSecID = "1919307139", Address = addrKhaMyrh3kv1 } }; PhysicalPersonInfo.TryParseFillPassIssueData("МК 175546, вид.Червонозаводським РВ УМВСУ в Харківській обл. 22.08.1996р.", physSymovianSV.PhysicalPerson);
            physTovazhnianskyiVL = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { CitizenshipCountry = CountryInfo.UKRAINE, FullName = "Товажнянський Вячеслав Леонідович", TaxOrSocSecID = "2254108295", Address = addrKhaMin109 } }; PhysicalPersonInfo.TryParseFillPassIssueData("МК 894983 вид. Жовтневим РВ ХМУ УМВСУ в Харківській обл.22.07.1998 р.", physTovazhnianskyiVL.PhysicalPerson);
            physIliinaSD = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { CitizenshipCountry = CountryInfo.UKRAINE, FullName = "Ільїна Світлана Дмитрівна", TaxOrSocSecID = "1814924262", Address = addrKhaTankop113kv64 } }; PhysicalPersonInfo.TryParseFillPassIssueData("МК 695562 виданий Фрунзенським РВ ХМУ УМВСУ в Харківській обл. 12.12.1997", physIliinaSD.PhysicalPerson);


            physSymovianVP = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { CitizenshipCountry = CountryInfo.UKRAINE, FullName = "Симов'ян Віра Петрівна", TaxOrSocSecID = "1771518385", Address = addrKhaMyrh3 } }; PhysicalPersonInfo.TryParseFillPassIssueData("АР 043761, вид.Нахімовським РВ УМВСУ в м.Севастополі 30.07.1996р.", physSymovianVP.PhysicalPerson);

            #endregion

            #region Legals
            leInvariantPlus = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Legal, LegalPerson = new LegalPersonInfo(){ Name = "ТОВАРИСТВО З ОБМЕЖЕНОЮ ВІДПОВІДАЛЬНІСТЮ \"НАУКОВО-ТЕХНІЧНА ФІРМА \"ІНВАРІАНТА ПЛЮС\"", TaxCodeOrHandelsRegNr = "38634770", ResidenceCountry = CountryInfo.UKRAINE, Address = addrKhaRomRol12 } };
            leInvesta = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Legal, LegalPerson = new LegalPersonInfo(){ Name = "ТОВ \"ФК\"Інвеста\" для ПІНВФ \"Венчурний проект\"", TaxCodeOrHandelsRegNr = "32335917", ResidenceCountry = CountryInfo.UKRAINE, Address = addrKhaArt46 } };
            leArgus = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Legal, LegalPerson = new LegalPersonInfo(){ Name = "ДОЧІРНЄ ПІДПРИЄМСТВО \"АРГУС\"", TaxCodeOrHandelsRegNr = "32440523", ResidenceCountry = CountryInfo.UKRAINE, Address = addrKhaCubar1 } };
            leResidentsiaSV = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Legal, LegalPerson = new LegalPersonInfo(){ Name = "ТОВАРИСТВО З ОБМЕЖЕНОЮ ВІДПОВІДАЛЬНІСТЮ \"РЕЗИДЕНЦІЯ-СВ\"", TaxCodeOrHandelsRegNr = "35876481", ResidenceCountry = CountryInfo.UKRAINE, Address = addrKhaDergSolonytsPushk151 } };
            leYurstokconsulting = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Legal, LegalPerson = new LegalPersonInfo(){ Name = "ТОВАРИСТВО З ОБМЕЖЕНОЮ ВІДПОВІДАЛЬНІСТЮ \"ЮРСТОККОНСАЛТИНГ\"", TaxCodeOrHandelsRegNr = "34952901", ResidenceCountry = CountryInfo.UKRAINE, Address = addrKhaSums53kv4 } };
            leTDVSKGrantservis = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Legal, LegalPerson = new LegalPersonInfo() { Name = "ТДВ СК «ГРАНТСЕРВІС»", TaxCodeOrHandelsRegNr = "21213705", Address = addrKhaRomRol12, ResidenceCountry = CountryInfo.UKRAINE, Equity = new CurrencyAmount() { CCY = "UAH", Amt = 18300000.00M } } };
            leArgusSoft = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Legal, LegalPerson = new LegalPersonInfo(){ Name = "ТОВАРИСТВО З ОБМЕЖЕНОЮ ВІДПОВІДАЛЬНІСТЮ \"АРГУС-СОФТ\"", TaxCodeOrHandelsRegNr = "31940736", ResidenceCountry = CountryInfo.UKRAINE, Address = addrKhaRomRol12 } };
            leIntekh = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Legal, LegalPerson = new LegalPersonInfo(){ Name = "ТОВАРИСТВО З ДОДАТКОВОЮ ВІДПОВІДАЛЬНІСТЮ СТРАХОВА КОМПАНІЯ \"ІНТЕХ\"", TaxCodeOrHandelsRegNr = "30990299", ResidenceCountry = CountryInfo.UKRAINE, Address = addrKhaRomRol12 } };

            //the bank itself
            leTheBank = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Legal, LegalPerson = new LegalPersonInfo() { Name = "ПУБЛІЧНЕ АКЦІОНЕРНЕ ТОВАРИСТВО \"СХІДНО-УКРАЇНСЬКИЙ БАНК \"ГРАНТ\"", TaxCodeOrHandelsRegNr = "14070197", ResidenceCountry = CountryInfo.UKRAINE, Address = addrKhaDanyl19, Equity = new CurrencyAmount() { CCY = "UAH", Amt = 130000000.00M } } };
            #endregion
            this._appx2Questionnaire.BankRef = new BankInfo(leTheBank.LegalPerson) { MFO = "351607", RegistryNr = "123", Code = "788" };
            this._appx2Questionnaire.Acquiree = leArgus.ID;

            
        }


        private Appx2OwnershipStructLP GenerateAppx2Questionnaire()
        {
            this._appx2Questionnaire = new Appx2OwnershipStructLP();
            PopulateDicts();
            ComposeBankExistingCommonImplicitOwners();
            ComposeMentionedEntities();
            ComposePersonLinks();

            ComposeSupervisoryBoard();
            ComposeExecutives();
            ComposeSignatory();

            return this._appx2Questionnaire;
        }
        private void ComposeMentionedEntities()
        {
            this._appx2Questionnaire.MentionedIdentities = new List<GenericPersonInfo>();
            this._appx2Questionnaire.MentionedIdentities.Add(physShkarupinaTA);
            this._appx2Questionnaire.MentionedIdentities.Add(physPohuliaievaLM);
            this._appx2Questionnaire.MentionedIdentities.Add(physKravchenkoIV);
            this._appx2Questionnaire.MentionedIdentities.Add(physLikhnoVP);
            this._appx2Questionnaire.MentionedIdentities.Add(physPopovOA);
            this._appx2Questionnaire.MentionedIdentities.Add(physSymovianSV2);
            this._appx2Questionnaire.MentionedIdentities.Add(physSymovianVS);
            this._appx2Questionnaire.MentionedIdentities.Add(physIliinVV);
            this._appx2Questionnaire.MentionedIdentities.Add(physSymovianVP);
            this._appx2Questionnaire.MentionedIdentities.Add(physSymovianSV);
            this._appx2Questionnaire.MentionedIdentities.Add(physTovazhnianskyiVL);
            this._appx2Questionnaire.MentionedIdentities.Add(leInvariantPlus);
            this._appx2Questionnaire.MentionedIdentities.Add(leTDVSKGrantservis);
            this._appx2Questionnaire.MentionedIdentities.Add(leArgusSoft);
            this._appx2Questionnaire.MentionedIdentities.Add(physIliinaSD);
            this._appx2Questionnaire.MentionedIdentities.Add(leInvesta);
            this._appx2Questionnaire.MentionedIdentities.Add(leIntekh);
            this._appx2Questionnaire.MentionedIdentities.Add(leArgus);
            this._appx2Questionnaire.MentionedIdentities.Add(leResidentsiaSV);
            this._appx2Questionnaire.MentionedIdentities.Add(leYurstokconsulting);
            this._appx2Questionnaire.MentionedIdentities.Add(leTheBank);
            string tmp = null;
            foreach (GenericPersonInfo gpi in this._appx2Questionnaire.MentionedIdentities)
                tmp = gpi.DisplayName;
        }

        private void ComposeBankExistingCommonImplicitOwners()
        {
            #region in-line version (non-debuggable);
            //this._appx2Questionnaire.BankExistingCommonImplicitOwners = new List<OwnershipStructure>
            //    (
            //     new OwnershipStructure[]
            //     {
            //        #region direct ownership
            //         new OwnershipStructure() { Asset = leTheBank.ID, Owners = new List<GenericPersonIDShare>(new GenericPersonIDShare[] { new GenericPersonIDShare() { Person = physShkarupinaTA.ID } }), SharePct = 0.0165M, OwnershipKind = Core.Spares.OwnershipType.Direct },
            //         new OwnershipStructure() { Asset = leTheBank.ID, Owners = new List<GenericPersonIDShare>(new GenericPersonIDShare[] { new GenericPersonIDShare() { Person = physPohuliaievaLM.ID } }), SharePct = 0.0558M, OwnershipKind = Core.Spares.OwnershipType.Direct },
            //         new OwnershipStructure() { Asset = leTheBank.ID, Owners = new List<GenericPersonIDShare>(new GenericPersonIDShare[] { new GenericPersonIDShare() { Person = physKravchenkoIV.ID } }), SharePct = 0.0018M, OwnershipKind = Core.Spares.OwnershipType.Direct },
            //         new OwnershipStructure() { Asset = leTheBank.ID, Owners = new List<GenericPersonIDShare>(new GenericPersonIDShare[] { new GenericPersonIDShare() { Person = physLikhnoVP.ID } }), SharePct = 0.1188M, OwnershipKind = Core.Spares.OwnershipType.Direct },
            //         new OwnershipStructure() { Asset = leTheBank.ID, Owners = new List<GenericPersonIDShare>(new GenericPersonIDShare[] { new GenericPersonIDShare() { Person = physPopovOA.ID } }), SharePct = 0.2508M, OwnershipKind = Core.Spares.OwnershipType.Direct },
            //         new OwnershipStructure() { Asset = leTheBank.ID, Owners = new List<GenericPersonIDShare>(new GenericPersonIDShare[] { new GenericPersonIDShare() { Person = physSymovianSV2.ID } }), SharePct = 0.7035M, OwnershipKind = Core.Spares.OwnershipType.Direct },
            //         new OwnershipStructure() { Asset = leTheBank.ID, Owners = new List<GenericPersonIDShare>(new GenericPersonIDShare[] { new GenericPersonIDShare() { Person = physSymovianVS.ID } }), SharePct = 3.185M, OwnershipKind = Core.Spares.OwnershipType.Direct },
            //         new OwnershipStructure() { Asset = leTheBank.ID, Owners = new List<GenericPersonIDShare>(new GenericPersonIDShare[] { new GenericPersonIDShare() { Person = physIliinVV.ID } }), SharePct = 0.0201M, OwnershipKind = Core.Spares.OwnershipType.Direct },
            //         new OwnershipStructure() { Asset = leTheBank.ID, Owners = new List<GenericPersonIDShare>(new GenericPersonIDShare[] { new GenericPersonIDShare() { Person = physSymovianVP.ID } }), SharePct = 0.3847M, OwnershipKind = Core.Spares.OwnershipType.Direct },
            //         new OwnershipStructure() { Asset = leTheBank.ID, Owners = new List<GenericPersonIDShare>(new GenericPersonIDShare[] { new GenericPersonIDShare() { Person = physSymovianSV.ID } }), SharePct = 65.5998M, OwnershipKind = Core.Spares.OwnershipType.Direct },
            //         new OwnershipStructure() { Asset = leTheBank.ID, Owners = new List<GenericPersonIDShare>(new GenericPersonIDShare[] { new GenericPersonIDShare() { Person = physTovazhnianskyiVL.ID } }), SharePct = 0.0684M, OwnershipKind = Core.Spares.OwnershipType.Direct },
            //         new OwnershipStructure() { Asset = leTheBank.ID, Owners = new List<GenericPersonIDShare>(new GenericPersonIDShare[] { new GenericPersonIDShare() { Person = leInvariantPlus.ID } }), SharePct = 9.0462M, OwnershipKind = Core.Spares.OwnershipType.Direct },
            //         new OwnershipStructure() { Asset = leTheBank.ID, Owners = new List<GenericPersonIDShare>(new GenericPersonIDShare[] { new GenericPersonIDShare() { Person = leTDVSKGrantservis.ID } }), SharePct = 4.602M, OwnershipKind = Core.Spares.OwnershipType.Direct },
            //         new OwnershipStructure() { Asset = leTheBank.ID, Owners = new List<GenericPersonIDShare>(new GenericPersonIDShare[] { new GenericPersonIDShare() { Person = leArgusSoft.ID } }), SharePct = 4.5931M, OwnershipKind = Core.Spares.OwnershipType.Direct },
            //         new OwnershipStructure() { Asset = leTheBank.ID, Owners = new List<GenericPersonIDShare>(new GenericPersonIDShare[] { new GenericPersonIDShare() { Person = physIliinaSD.ID } }), SharePct = 0.0201M, OwnershipKind = Core.Spares.OwnershipType.Direct },
            //         new OwnershipStructure() { Asset = leTheBank.ID, Owners = new List<GenericPersonIDShare>(new GenericPersonIDShare[] { new GenericPersonIDShare() { Person = leInvesta.ID } }), SharePct = 0.1518M, OwnershipKind = Core.Spares.OwnershipType.Direct },
            //         new OwnershipStructure() { Asset = leTheBank.ID, Owners = new List<GenericPersonIDShare>(new GenericPersonIDShare[] { new GenericPersonIDShare() { Person = leIntekh.ID } }), SharePct = 4.566M, OwnershipKind = Core.Spares.OwnershipType.Direct },
            //         new OwnershipStructure() { Asset = leTheBank.ID, Owners = new List<GenericPersonIDShare>(new GenericPersonIDShare[] { new GenericPersonIDShare() { Person = leArgus.ID } }), SharePct = 0.8967M, OwnershipKind = Core.Spares.OwnershipType.Direct },
            //         new OwnershipStructure() { Asset = leTheBank.ID, Owners = new List<GenericPersonIDShare>(new GenericPersonIDShare[] { new GenericPersonIDShare() { Person = leResidentsiaSV.ID } }), SharePct = 3.8804M, OwnershipKind = Core.Spares.OwnershipType.Direct },
            //         new OwnershipStructure() { Asset = leTheBank.ID, Owners = new List<GenericPersonIDShare>(new GenericPersonIDShare[] { new GenericPersonIDShare() { Person = leYurstokconsulting.ID } }), SharePct = 1.6154M, OwnershipKind = Core.Spares.OwnershipType.Direct }
            //        #endregion

            //        #region ТОВАРИСТВО З ОБМЕЖЕНОЮ ВІДПОВІДАЛЬНІСТЮ "НАУКОВО-ТЕХНІЧНА ФІРМА "ІНВАРІАНТА ПЛЮС"
            //         ,
            //         new OwnershipStructure() { Asset = leInvariantPlus.ID, Owners = new List<GenericPersonIDShare>(new GenericPersonIDShare[] { new GenericPersonIDShare() { Person = leTDVSKGrantservis.ID } }), SharePct = 50.5121M, OwnershipKind = Core.Spares.OwnershipType.Direct },
            //         new OwnershipStructure() { Asset = leInvariantPlus.ID, Owners = new List<GenericPersonIDShare>(new GenericPersonIDShare[] { new GenericPersonIDShare() { Person = leIntekh.ID } }), SharePct = 49.4751M, OwnershipKind = Core.Spares.OwnershipType.Direct }
            //        #endregion

            //        #region ТОВАРИСТВО З ДОДАТКОВОЮ ВІДПОВІДАЛЬНІСТЮ  СТРАХОВА КОМПАНІЯ "ГРАНТСЕРВІС"
            //         ,
            //         new OwnershipStructure() { Asset = leTDVSKGrantservis.ID, Owners = new List<GenericPersonIDShare>(new GenericPersonIDShare[] { new GenericPersonIDShare() { Person = physSymovianSV.ID } }), SharePct = 37.756M, OwnershipKind = Core.Spares.OwnershipType.Direct },
            //         new OwnershipStructure() { Asset = leTDVSKGrantservis.ID, Owners = new List<GenericPersonIDShare>(new GenericPersonIDShare[] { new GenericPersonIDShare() { Person = physSymovianVS.ID } }), SharePct = 29.922M, OwnershipKind = Core.Spares.OwnershipType.Direct },
            //         new OwnershipStructure() { Asset = leTDVSKGrantservis.ID, Owners = new List<GenericPersonIDShare>(new GenericPersonIDShare[] { new GenericPersonIDShare() { Person = leIntekh.ID } }), SharePct = 11.353M, OwnershipKind = Core.Spares.OwnershipType.Direct }
            //         //todo - missing some %'s
            //        #endregion

            //        #region ТОВАРИСТВО З ОБМЕЖЕНОЮ ВІДПОВІДАЛЬНІСТЮ "АРГУС-СОФТ"
            //         ,
            //         new OwnershipStructure() { Asset = leArgusSoft.ID, Owners = new List<GenericPersonIDShare>(new GenericPersonIDShare[] { new GenericPersonIDShare() { Person = physSymovianSV.ID } }), SharePct = 50.00M, OwnershipKind = Core.Spares.OwnershipType.Direct },
            //         new OwnershipStructure() { Asset = leArgusSoft.ID, Owners = new List<GenericPersonIDShare>(new GenericPersonIDShare[] { new GenericPersonIDShare() { Person = physSymovianVS.ID } }), SharePct = 50.0M, OwnershipKind = Core.Spares.OwnershipType.Direct }
            //        #endregion

            //        #region ТОВ "ФК"Інвеста" для ПІНВФ "Венчурний проект"

            //        #endregion

            //        #region ТОВАРИСТВО З ДОДАТКОВОЮ ВІДПОВІДАЛЬНІСТЮ СТРАХОВА КОМПАНІЯ "ІНТЕХ"
            //         ,
            //         new OwnershipStructure() { Asset = leIntekh.ID, Owners = new List<GenericPersonIDShare>(new GenericPersonIDShare[] { new GenericPersonIDShare() { Person = physSymovianSV.ID } }), SharePct = 82.72M, OwnershipKind = Core.Spares.OwnershipType.Direct },
            //         new OwnershipStructure() { Asset = leIntekh.ID, Owners = new List<GenericPersonIDShare>(new GenericPersonIDShare[] { new GenericPersonIDShare() { Person = physSymovianSV2.ID } }), SharePct = 10.84M, OwnershipKind = Core.Spares.OwnershipType.Direct }
            //         //todo - missing some %'s
            //        #endregion

            //        #region ДОЧІРНЄ ПІДПРИЄМСТВО "АРГУС"
            //         //todo
            //        #endregion

            //        #region ТОВАРИСТВО З ОБМЕЖЕНОЮ ВІДПОВІДАЛЬНІСТЮ "РЕЗИДЕНЦІЯ-СВ"
            //         ,
            //         new OwnershipStructure() { Asset = leResidentsiaSV.ID, Owners = new List<GenericPersonIDShare>(new GenericPersonIDShare[] { new GenericPersonIDShare() { Person = leTDVSKGrantservis.ID } }), SharePct = 84.30M, OwnershipKind = Core.Spares.OwnershipType.Direct },
            //         new OwnershipStructure() { Asset = leResidentsiaSV.ID, Owners = new List<GenericPersonIDShare>(new GenericPersonIDShare[] { new GenericPersonIDShare() { Person = leIntekh.ID } }), SharePct = 14.70M, OwnershipKind = Core.Spares.OwnershipType.Direct }
            //        #endregion

            //        #region ТОВАРИСТВО З ОБМЕЖЕНОЮ ВІДПОВІДАЛЬНІСТЮ "ЮРСТОККОНСАЛТИНГ"
            //         ,
            //         new OwnershipStructure() { Asset = leYurstokconsulting.ID, Owners = new List<GenericPersonIDShare>(new GenericPersonIDShare[] { new GenericPersonIDShare() { Person = leTDVSKGrantservis.ID } }), SharePct = 29.9124M, OwnershipKind = Core.Spares.OwnershipType.Direct }
            //         //todo - missing some %'s
            //        #endregion

            //     }
            //    );
            #endregion

            this._appx2Questionnaire.BankExistingCommonImplicitOwners = new List<OwnershipStructure>();
                    #region direct ownership
                    this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leTheBank.ID, Owner = physShkarupinaTA.ID, SharePct = 0.0165M, OwnershipKind = Core.Spares.OwnershipType.Direct });
                     this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leTheBank.ID, Owner = physPohuliaievaLM.ID, SharePct = 0.0558M, OwnershipKind = Core.Spares.OwnershipType.Direct });
                     this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leTheBank.ID, Owner = physKravchenkoIV.ID, SharePct = 0.0018M, OwnershipKind = Core.Spares.OwnershipType.Direct });
                     this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leTheBank.ID, Owner = physLikhnoVP.ID, SharePct = 0.1188M, OwnershipKind = Core.Spares.OwnershipType.Direct });
                     this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leTheBank.ID, Owner = physPopovOA.ID, SharePct = 0.2508M, OwnershipKind = Core.Spares.OwnershipType.Direct });
                     this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leTheBank.ID, Owner = physSymovianSV2.ID, SharePct = 0.7035M, OwnershipKind = Core.Spares.OwnershipType.Direct });
                     this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leTheBank.ID, Owner = physSymovianVS.ID, SharePct = 3.185M, OwnershipKind = Core.Spares.OwnershipType.Direct });
                     this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leTheBank.ID, Owner = physIliinVV.ID, SharePct = 0.0201M, OwnershipKind = Core.Spares.OwnershipType.Direct });
                     this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leTheBank.ID, Owner = physSymovianVP.ID, SharePct = 0.3847M, OwnershipKind = Core.Spares.OwnershipType.Direct });
                     this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leTheBank.ID, Owner = physSymovianSV.ID, SharePct = 65.5998M, OwnershipKind = Core.Spares.OwnershipType.Direct });
                     this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leTheBank.ID, Owner = physTovazhnianskyiVL.ID, SharePct = 0.0684M, OwnershipKind = Core.Spares.OwnershipType.Direct });
                     this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leTheBank.ID, Owner = leInvariantPlus.ID, SharePct = 9.0462M, OwnershipKind = Core.Spares.OwnershipType.Direct });
                     this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leTheBank.ID, Owner = leTDVSKGrantservis.ID, SharePct = 4.602M, OwnershipKind = Core.Spares.OwnershipType.Direct });
                     this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leTheBank.ID, Owner = leArgusSoft.ID, SharePct = 4.5931M, OwnershipKind = Core.Spares.OwnershipType.Direct });
                     this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leTheBank.ID, Owner = physIliinaSD.ID, SharePct = 0.0201M, OwnershipKind = Core.Spares.OwnershipType.Direct });
                     this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leTheBank.ID, Owner = leInvesta.ID, SharePct = 0.1518M, OwnershipKind = Core.Spares.OwnershipType.Direct });
                     this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leTheBank.ID, Owner = leIntekh.ID, SharePct = 4.566M, OwnershipKind = Core.Spares.OwnershipType.Direct });
                     this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leTheBank.ID, Owner = leArgus.ID, SharePct = 0.8967M, OwnershipKind = Core.Spares.OwnershipType.Direct });
                     this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leTheBank.ID, Owner = leResidentsiaSV.ID, SharePct = 3.8804M, OwnershipKind = Core.Spares.OwnershipType.Direct });
                     this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leTheBank.ID, Owner = leYurstokconsulting.ID, SharePct = 1.6154M, OwnershipKind = Core.Spares.OwnershipType.Direct });
                    #endregion

                    #region ТОВАРИСТВО З ОБМЕЖЕНОЮ ВІДПОВІДАЛЬНІСТЮ "НАУКОВО-ТЕХНІЧНА ФІРМА "ІНВАРІАНТА ПЛЮС"
                     
                     this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leInvariantPlus.ID, Owner = leTDVSKGrantservis.ID, SharePct = 50.5121M, OwnershipKind = Core.Spares.OwnershipType.Direct });
                     this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leInvariantPlus.ID, Owner = leIntekh.ID, SharePct = 49.4751M, OwnershipKind = Core.Spares.OwnershipType.Direct });
                    #endregion

                    #region ТОВАРИСТВО З ДОДАТКОВОЮ ВІДПОВІДАЛЬНІСТЮ  СТРАХОВА КОМПАНІЯ "ГРАНТСЕРВІС"
                     
                     this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leTDVSKGrantservis.ID, Owner = physSymovianSV.ID, SharePct = 37.756M, OwnershipKind = Core.Spares.OwnershipType.Direct });
                     this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leTDVSKGrantservis.ID, Owner = physSymovianVS.ID, SharePct = 29.922M, OwnershipKind = Core.Spares.OwnershipType.Direct });
                     this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leTDVSKGrantservis.ID, Owner = leIntekh.ID, SharePct = 11.353M, OwnershipKind = Core.Spares.OwnershipType.Direct });
                     //todo - missing some %'s
                    #endregion

                    #region ТОВАРИСТВО З ОБМЕЖЕНОЮ ВІДПОВІДАЛЬНІСТЮ "АРГУС-СОФТ"
                     
                     this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leArgusSoft.ID, Owner = physSymovianSV.ID, SharePct = 50.00M, OwnershipKind = Core.Spares.OwnershipType.Direct });
                     this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leArgusSoft.ID, Owner = physSymovianVS.ID, SharePct = 50.0M, OwnershipKind = Core.Spares.OwnershipType.Direct });
                    #endregion

                    #region ТОВ "ФК"Інвеста" для ПІНВФ "Венчурний проект"

                    #endregion

                    #region ТОВАРИСТВО З ДОДАТКОВОЮ ВІДПОВІДАЛЬНІСТЮ СТРАХОВА КОМПАНІЯ "ІНТЕХ"
                     
                     this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leIntekh.ID, Owner = physSymovianSV.ID, SharePct = 82.72M, OwnershipKind = Core.Spares.OwnershipType.Direct });
                     this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leIntekh.ID, Owner = physSymovianSV2.ID, SharePct = 10.84M, OwnershipKind = Core.Spares.OwnershipType.Direct });
                     //todo - missing some %'s
                    #endregion

                    #region ДОЧІРНЄ ПІДПРИЄМСТВО "АРГУС"
                     //todo
                    #endregion

                    #region ТОВАРИСТВО З ОБМЕЖЕНОЮ ВІДПОВІДАЛЬНІСТЮ "РЕЗИДЕНЦІЯ-СВ"
                     
                     this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leResidentsiaSV.ID, Owner = leTDVSKGrantservis.ID, SharePct = 84.30M, OwnershipKind = Core.Spares.OwnershipType.Direct });
                     this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leResidentsiaSV.ID, Owner = leIntekh.ID, SharePct = 14.70M, OwnershipKind = Core.Spares.OwnershipType.Direct });
                    #endregion

                    #region ТОВАРИСТВО З ОБМЕЖЕНОЮ ВІДПОВІДАЛЬНІСТЮ "ЮРСТОККОНСАЛТИНГ"

                     this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leYurstokconsulting.ID, Owner = leTDVSKGrantservis.ID, SharePct = 29.9124M, OwnershipKind = Core.Spares.OwnershipType.Direct });
                     //todo - missing some %'s
                    #endregion

        }

        private void ComposePersonLinks()
        {
            this._appx2Questionnaire.PersonsLinks.Add(new PersonsAssociation() { One = physSymovianSV.ID, Two = physSymovianVS.ID, AssociationType = Core.Spares.PersonAssociationType.Relative, AssociationRoleOneVsTwo = Core.Spares.AssociatedPersonRole.Father, AssociationRoleTwoVsOne = Core.Spares.AssociatedPersonRole.Son });
            this._appx2Questionnaire.PersonsLinks.Add(new PersonsAssociation() { One = physSymovianVS.ID, Two = physSymovianSV2.ID, AssociationType = Core.Spares.PersonAssociationType.Relative, AssociationRoleOneVsTwo = Core.Spares.AssociatedPersonRole.Father, AssociationRoleTwoVsOne = Core.Spares.AssociatedPersonRole.Son });
            this._appx2Questionnaire.PersonsLinks.Add(new PersonsAssociation() { One = physSymovianVP.ID, Two = physSymovianSV.ID, AssociationType = Core.Spares.PersonAssociationType.Relative, AssociationRoleOneVsTwo = Core.Spares.AssociatedPersonRole.Wife, AssociationRoleTwoVsOne = Core.Spares.AssociatedPersonRole.Husband });
            this._appx2Questionnaire.PersonsLinks.Add(new PersonsAssociation() { One = physSymovianVP.ID, Two = physSymovianVS.ID, AssociationType = Core.Spares.PersonAssociationType.Relative, AssociationRoleOneVsTwo = Core.Spares.AssociatedPersonRole.Mother, AssociationRoleTwoVsOne = Core.Spares.AssociatedPersonRole.Son });
            this._appx2Questionnaire.PersonsLinks.Add(new PersonsAssociation() { One = physSymovianSV.ID, Two = physSymovianSV2.ID, AssociationType = Core.Spares.PersonAssociationType.Relative, AssociationRoleOneVsTwo = Core.Spares.AssociatedPersonRole.GrandFather, AssociationRoleTwoVsOne = Core.Spares.AssociatedPersonRole.GrandSon });
        }

        private void ComposeSupervisoryBoard()
        {
            this._appx2Questionnaire.IsSupervisoryCouncilPresent = true;
            this._appx2Questionnaire.SupervisoryCouncil = new CouncilBodyInfo();
            this._appx2Questionnaire.SupervisoryCouncil.CouncilBodyName = "Наглядова рада";
            this._appx2Questionnaire.SupervisoryCouncil.Members = new List<CouncilMemberInfo>();
            this._appx2Questionnaire.SupervisoryCouncil.Members.Add(new CouncilMemberInfo() { PositionName = "Член", Member = physIliinVV.ID} );
            this._appx2Questionnaire.SupervisoryCouncil.Members.Add(new CouncilMemberInfo() { PositionName = "Голова", Member = physSymovianSV.ID });
            this._appx2Questionnaire.SupervisoryCouncil.Members.Add(new CouncilMemberInfo() { PositionName = "Член", Member = physSymovianVS.ID });
            this._appx2Questionnaire.SupervisoryCouncil.Members.Add(new CouncilMemberInfo() { PositionName = "Член", Member = physTovazhnianskyiVL.ID });
            this._appx2Questionnaire.SupervisoryCouncil.HeadMember = physSymovianVS.ID;
        }


        private void ComposeExecutives()
        {
            //todo
        }

        private void ComposeSignatory()
        {
            this._appx2Questionnaire.Signatory = new BGU.DRPL.SignificantOwnership.Core.Spares.Data.SignatoryInfo() { DateSigned = DateTime.Parse("2015-04-30T00:00:00"), SignatoryPosition = "В.о. Голови правління", SurnameInitials = "Симов'ян В.С." };
        }
    }
}
