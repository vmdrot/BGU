using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;
using BGU.DRPL.SignificantOwnership.Core.Questionnaires;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;

namespace BGU.DRPL.SignificantOwnership.EmpiricalData.Examples
{
    public class TKKredyt
    {
        private List<PhysicalPersonInfo> _INDs;
        private List<LegalPersonInfo> _LEs;
        private Appx2OwnershipStructLP _appx2Questionnaire;

        #region particular entities
        private GenericPersonInfo leNoviThekhn;
        private GenericPersonInfo leEkoVuhUkr;
        private GenericPersonInfo leIntal;
        private GenericPersonInfo leTop;
        private GenericPersonInfo leStavr;
        private GenericPersonInfo leBSK;
        private GenericPersonInfo leFCLider;
        private GenericPersonInfo leParadigmaC;
        private GenericPersonInfo leInterofficeLtd;
        private GenericPersonInfo leDPAntonov;
        private GenericPersonInfo leInterLend;
        private GenericPersonInfo leDPKyivprylad;
        private GenericPersonInfo leFortexM;
        private GenericPersonInfo leIntelkon;
        private GenericPersonInfo leKAST;
        private GenericPersonInfo physKurshev;
        private GenericPersonInfo leUPTK;
        private GenericPersonInfo leFOTON;
        private GenericPersonInfo leMlynmontazh;
        private GenericPersonInfo leKondor;
        private GenericPersonInfo leTheBank;

        private GenericPersonInfo leGoodLightCapitalLtd;
        private GenericPersonInfo leFieldLane;
        private GenericPersonInfo physUmanets;
        private GenericPersonInfo physElmIbanez;
        private GenericPersonInfo physWlmartnDeBeer;
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
            LocationInfo addrKyivHonch73of5 = LocationInfo.Parse("01054, Україна,  м. Київ, вул. Олеся Гончара, буд. 73, оф. 5"); addrKyivHonch73of5.Country = CountryInfo.UKRAINE;
            LocationInfo addrYenakLuhShose74 = LocationInfo.Parse("86405, Донецька обл., м. Єнакієве, вул. Луганське шосе, буд. 74"); addrYenakLuhShose74.Country = CountryInfo.UKRAINE;
            LocationInfo addrOdesHovorova7of10k5 = LocationInfo.Parse("65063, м. Одеса, вул. Маршала Говорова, 7, оф. 10, кім. 5"); addrOdesHovorova7of10k5.Country = CountryInfo.UKRAINE;
            LocationInfo addrKyivPovitrfl90of6 = LocationInfo.Parse("03036, м. Київ, просп. Повітрофлотський, буд. 90, оф. 6"); addrKyivPovitrfl90of6.Country = CountryInfo.UKRAINE;
            LocationInfo addrYenakMarata1 = LocationInfo.Parse("86400, Донецька обл., м. Єнакієве, вул. Марата, буд. 1"); addrYenakMarata1.Country = CountryInfo.UKRAINE;
            LocationInfo addrKyivMeln12 = LocationInfo.Parse("04050, м. Київ, вул. Мельникова, буд. 12"); addrKyivMeln12.Country = CountryInfo.UKRAINE;
            LocationInfo addrKyivPovitrfl90 = LocationInfo.Parse("03151, м. Київ, пр-т Повітрофлотський, буд. 90"); addrKyivPovitrfl90.Country = CountryInfo.UKRAINE;
            LocationInfo addrKyivKyianpr3_7 = LocationInfo.Parse("04053, м. Київ, пров. Киянівський, буд. 3-7"); addrKyivKyianpr3_7.Country = CountryInfo.UKRAINE;
            LocationInfo addrKyivTupol1 = LocationInfo.Parse("03062, м. Київ, вул. Академіка Туполєва, буд. 1"); addrKyivTupol1.Country = CountryInfo.UKRAINE;
            LocationInfo addrOdesPyroh3of99 = LocationInfo.Parse("65044, м. Одеса, вул. Пироговська, буд. 3, оф. 99"); addrOdesPyroh3of99.Country = CountryInfo.UKRAINE;
            LocationInfo addrKyivHarmatna2 = LocationInfo.Parse("03680, м. Київ, вул. Гарматна, буд. 2"); addrKyivHarmatna2.Country = CountryInfo.UKRAINE;
            LocationInfo addrKyivKondr4Bof72 = LocationInfo.Parse("04201, м. Київ, вул. Юрія Кондратюка, буд. 4-В, оф. 72"); addrKyivKondr4Bof72.Country = CountryInfo.UKRAINE;
            LocationInfo addrKyivRybalka11 = LocationInfo.Parse("04116, м. Київ, вул. Маршала Рибалка, буд. 11"); addrKyivRybalka11.Country = CountryInfo.UKRAINE;
            LocationInfo addrKyivSolom20 = LocationInfo.Parse("03110, м. Київ, вул. Солом'янська, буд. 20"); addrKyivSolom20.Country = CountryInfo.UKRAINE;
            LocationInfo addrKyivLUkr9Bof77 = LocationInfo.Parse("01133, м. Київ, бул. Лесі Українки, буд. 9-В, оф. 77"); addrKyivLUkr9Bof77.Country = CountryInfo.UKRAINE;
            LocationInfo addrKyivSymyrenka1B = LocationInfo.Parse("03134, м. Київ, вул. Симиренка, буд. 1-Б"); addrKyivSymyrenka1B.Country = CountryInfo.UKRAINE;
            LocationInfo addrKyivPrPeremohy42 = LocationInfo.Parse("03057, м. Київ, пр-т Перемоги, буд. 42"); addrKyivPrPeremohy42.Country = CountryInfo.UKRAINE;
            LocationInfo addrKhaChuvaska8 = LocationInfo.Parse("61177, м. Харків, вул. Чуваська, буд. 8"); addrKhaChuvaska8.Country = CountryInfo.UKRAINE;
            LocationInfo addrKyivAndrUzv30A = LocationInfo.Parse("04070, м.Київ, вул. Андрієвський Узвіз, буд.30-А"); addrKyivAndrUzv30A.Country = CountryInfo.UKRAINE;
            LocationInfo addrKyivDmytr18_24 = LocationInfo.Parse("м. Київ вул. Дмитрівська, 18/24"); addrKyivDmytr18_24.Country = CountryInfo.UKRAINE;
             
            #endregion

            #region registrar(s)

            #endregion

            #region Phys
            leNoviThekhn = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Legal, LegalPerson = new LegalPersonInfo() { Name = "Публічне акціонерне товариство \"ЗНВКІФ \"Нові технології\"", TaxCodeOrHandelsRegNr = "32588368", Address = addrKyivHonch73of5 } };
            leEkoVuhUkr = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Legal, LegalPerson = new LegalPersonInfo() { Name = "Товариство з обмеженою відповідальністю \"Торговий дім \"ЕКО-ВУГІЛЛЯ УКРАЇНИ\"", TaxCodeOrHandelsRegNr = "38215064", Address = addrYenakLuhShose74 } };
            leIntal = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Legal, LegalPerson = new LegalPersonInfo() { Name = "Товариство з обмеженою відповідальністю \"Торгова Компанія ІНТАЛ\"", TaxCodeOrHandelsRegNr = "34551277", Address = addrOdesHovorova7of10k5 } };
            leTop = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Legal, LegalPerson = new LegalPersonInfo() { Name = "Товариство з обмеженою відповідальністю \"ТОП\"", TaxCodeOrHandelsRegNr = "16399079", Address = addrKyivPovitrfl90of6 } };
            leStavr = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Legal, LegalPerson = new LegalPersonInfo() { Name = "Товариство з обмеженою відповідальністю \"СТАВР\"", TaxCodeOrHandelsRegNr = "32287112", Address = addrYenakMarata1 } };
            leBSK = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Legal, LegalPerson = new LegalPersonInfo() { Name = "Товариство з обмеженою відповідальністю \"БСК.\"", TaxCodeOrHandelsRegNr = "24573858", Address = addrKyivMeln12 } };
            leFCLider = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Legal, LegalPerson = new LegalPersonInfo() { Name = "Товариство з обмеженою відповідальністю \"Фінансова компанія \"Лідер\"", TaxCodeOrHandelsRegNr = "32924390", Address = addrYenakMarata1 } };
            leParadigmaC = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Legal, LegalPerson = new LegalPersonInfo() { Name = "Приватне підприємство \"ПАРАДІГМА-СІ\"", TaxCodeOrHandelsRegNr = "34188540", Address = addrKyivPovitrfl90 } };
            leInterofficeLtd = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Legal, LegalPerson = new LegalPersonInfo() { Name = "Товариство з обмеженою відповідальністю \"Інтерофіс Лімітед\"", TaxCodeOrHandelsRegNr = "32962368", Address = addrKyivKyianpr3_7 } };
            leDPAntonov = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Legal, LegalPerson = new LegalPersonInfo() { Name = "Державне підприємство \"АНТОНОВ\"", TaxCodeOrHandelsRegNr = "14307529", Address = addrKyivTupol1 } };
            leInterLend = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Legal, LegalPerson = new LegalPersonInfo() { Name = "Приватне підприємство \"IНТЕР ЛЕНД\"", TaxCodeOrHandelsRegNr = "35640472", Address = addrOdesPyroh3of99 } };
            leDPKyivprylad = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Legal, LegalPerson = new LegalPersonInfo() { Name = "Державне підприємство \"Виробниче об'єднання \"Київприлад\"", TaxCodeOrHandelsRegNr = "14309669", ResidenceCountry = CountryInfo.UKRAINE, Address = addrKyivHarmatna2 } };
            leFortexM = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Legal, LegalPerson = new LegalPersonInfo() { Name = "Товариство з обмеженою відповідальністю \"ФОРТЕКС-М\"", TaxCodeOrHandelsRegNr = "32307657", ResidenceCountry = CountryInfo.UKRAINE, Address = addrKyivKondr4Bof72 } };
            leIntelkon = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Legal, LegalPerson = new LegalPersonInfo() { Name = "Товариство з обмеженою відповідальністю \"Виробничо-комерційна фірма \"ІНТЕЛКОН\"", TaxCodeOrHandelsRegNr = "21586047", ResidenceCountry = CountryInfo.UKRAINE, Address = addrKyivRybalka11 } };
            leKAST = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Legal, LegalPerson = new LegalPersonInfo() { Name = "Приватне підприємство \"КАСТ\"", TaxCodeOrHandelsRegNr = "22866071", Address = addrKyivSolom20 } };
            physKurshev = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { FullName = "Приватний підприємець Куршев Генадій Олексійович", TaxOrSocSecID = "60156783", CitizenshipCountry = CountryInfo.UKRAINE, Address = addrKyivLUkr9Bof77 } };
            leUPTK = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Legal, LegalPerson = new LegalPersonInfo(){ Name = "Приватне акціонерне товариство \"УПТК\"", TaxCodeOrHandelsRegNr = "16476514", ResidenceCountry = CountryInfo.UKRAINE, Address = addrKyivSymyrenka1B } };
            leFOTON = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Legal, LegalPerson = new LegalPersonInfo(){ Name = "Приватне акціонерне товариство \"Київський завод світлочутливих матеріалів \"ФОТОН\"", TaxCodeOrHandelsRegNr = "00205162", ResidenceCountry = CountryInfo.UKRAINE, Address = addrKyivPrPeremohy42 } };
            leMlynmontazh = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Legal, LegalPerson = new LegalPersonInfo(){ Name = "Публічне акціонерне товариство \"Млинмонтаж\"", TaxCodeOrHandelsRegNr = "00953102", ResidenceCountry = CountryInfo.UKRAINE, Address = addrKhaChuvaska8 } };
            leKondor = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Legal, LegalPerson = new LegalPersonInfo(){ Name = "Приватне підприємство \"Кондор\"", TaxCodeOrHandelsRegNr = "16282785", ResidenceCountry = CountryInfo.UKRAINE, Address = addrKyivAndrUzv30A } };

            //the bank itself
            leTheBank = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Legal, LegalPerson = new LegalPersonInfo() { Name = "АТ КБ \"ТК КРЕДИТ\"", TaxCodeOrHandelsRegNr = "20050951", ResidenceCountry = CountryInfo.UKRAINE, Address = addrKyivDmytr18_24, Equity = new CurrencyAmount() { CCY = "UAH", Amt = 0.00M /* todo */} } };

            leGoodLightCapitalLtd = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Legal, LegalPerson = new LegalPersonInfo() { Name = "Good Light Capital LTD", TaxCodeOrHandelsRegNr = "ES23488", ResidenceCountry = CountryInfo.SPAIN } };
            leFieldLane = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Legal, LegalPerson = new LegalPersonInfo() { Name = "Fieldlane LTD", TaxCodeOrHandelsRegNr = "ES23489", ResidenceCountry = CountryInfo.SPAIN } };
            physUmanets = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { FullName = "Уманець Юрій Олександрович", TaxOrSocSecID = "4561615645", CitizenshipCountry = CountryInfo.UKRAINE } };
            physElmIbanez = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { FullName = "Ibanez Elmari", TaxOrSocSecID = "es-55246", CitizenshipCountry = CountryInfo.SPAIN } };
            physWlmartnDeBeer = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { FullName = "Willem Martinus De Beer", TaxOrSocSecID = "nl-45375", CitizenshipCountry = CountryInfo.NETHERLANDS } };

            #endregion
            this._appx2Questionnaire.BankRef = new BankInfo() { MFO = "322830", Name = "АТ КБ \"ТК КРЕДИТ\"", LegalPerson = leTheBank.ID, OperationCountry = CountryInfo.UKRAINE };
            this._appx2Questionnaire.Acquiree = leNoviThekhn.ID;

            
        }

        private Appx2OwnershipStructLP GenerateAppx2Questionnaire()
        {
            this._appx2Questionnaire = new Appx2OwnershipStructLP();
            PopulateDicts();
            ComposeBankExistingCommonImplicitOwners();
            ComposeMentionedEntities();
            return this._appx2Questionnaire;
        }


        private void ComposeMentionedEntities()
        {
            this._appx2Questionnaire.MentionedIdentities = new List<GenericPersonInfo>();
            this._appx2Questionnaire.MentionedIdentities.Add(leNoviThekhn);
            this._appx2Questionnaire.MentionedIdentities.Add(leEkoVuhUkr);
            this._appx2Questionnaire.MentionedIdentities.Add(leIntal);
            this._appx2Questionnaire.MentionedIdentities.Add(leTop);
            this._appx2Questionnaire.MentionedIdentities.Add(leStavr);
            this._appx2Questionnaire.MentionedIdentities.Add(leBSK);
            this._appx2Questionnaire.MentionedIdentities.Add(leFCLider);
            this._appx2Questionnaire.MentionedIdentities.Add(leParadigmaC);
            this._appx2Questionnaire.MentionedIdentities.Add(leInterofficeLtd);
            this._appx2Questionnaire.MentionedIdentities.Add(leDPAntonov);
            this._appx2Questionnaire.MentionedIdentities.Add(leInterLend);
            this._appx2Questionnaire.MentionedIdentities.Add(leDPKyivprylad);
            this._appx2Questionnaire.MentionedIdentities.Add(leFortexM);
            this._appx2Questionnaire.MentionedIdentities.Add(leIntelkon);
            this._appx2Questionnaire.MentionedIdentities.Add(leKAST);
            this._appx2Questionnaire.MentionedIdentities.Add(physKurshev);
            this._appx2Questionnaire.MentionedIdentities.Add(leUPTK);
            this._appx2Questionnaire.MentionedIdentities.Add(leFOTON);
            this._appx2Questionnaire.MentionedIdentities.Add(leMlynmontazh);
            this._appx2Questionnaire.MentionedIdentities.Add(leKondor);
            this._appx2Questionnaire.MentionedIdentities.Add(leTheBank);

            this._appx2Questionnaire.MentionedIdentities.Add(leGoodLightCapitalLtd);
            this._appx2Questionnaire.MentionedIdentities.Add(leFieldLane);
            this._appx2Questionnaire.MentionedIdentities.Add(physUmanets);
            this._appx2Questionnaire.MentionedIdentities.Add(physElmIbanez);
            this._appx2Questionnaire.MentionedIdentities.Add(physWlmartnDeBeer);
            this._appx2Questionnaire.MentionedIdentities.Add(this.leTheBank);

            string tmp = null;
            foreach (GenericPersonInfo gpi in this._appx2Questionnaire.MentionedIdentities)
                tmp = gpi.DisplayName;
            

        }
        private void ComposeBankExistingCommonImplicitOwners()
        {
            this._appx2Questionnaire.BankExistingCommonImplicitOwners = new List<OwnershipStructure>();
            #region direct ownership
            this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leTheBank.ID, Owner =leNoviThekhn.ID, SharePct = 18.6389M, OwnershipKind = Core.Spares.OwnershipType.Direct });
            this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leTheBank.ID, Owner =leEkoVuhUkr.ID, SharePct = 9.9982M, OwnershipKind = Core.Spares.OwnershipType.Direct });
            this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leTheBank.ID, Owner =leIntal.ID, SharePct = 9.9001M, OwnershipKind = Core.Spares.OwnershipType.Direct });
            this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leTheBank.ID, Owner =leTop.ID, SharePct = 9.8796M, OwnershipKind = Core.Spares.OwnershipType.Direct });
            this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leTheBank.ID, Owner =leStavr.ID, SharePct = 9.8664M, OwnershipKind = Core.Spares.OwnershipType.Direct });
            this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leTheBank.ID, Owner =leBSK.ID, SharePct = 9.4835M, OwnershipKind = Core.Spares.OwnershipType.Direct });
            this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leTheBank.ID, Owner =leFCLider.ID, SharePct = 9.4721M, OwnershipKind = Core.Spares.OwnershipType.Direct });
            this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leTheBank.ID, Owner =leParadigmaC.ID, SharePct = 7.245M, OwnershipKind = Core.Spares.OwnershipType.Direct });
            this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leTheBank.ID, Owner =leInterofficeLtd.ID, SharePct = 6.1789M, OwnershipKind = Core.Spares.OwnershipType.Direct });
            this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leTheBank.ID, Owner =leDPAntonov.ID, SharePct = 2.6345M, OwnershipKind = Core.Spares.OwnershipType.Direct });
            this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leTheBank.ID, Owner =leInterLend.ID, SharePct = 2.535M, OwnershipKind = Core.Spares.OwnershipType.Direct });
            this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leTheBank.ID, Owner =leDPKyivprylad.ID, SharePct = 1.9759M, OwnershipKind = Core.Spares.OwnershipType.Direct });
            this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leTheBank.ID, Owner =leFortexM.ID, SharePct = 1.9302M, OwnershipKind = Core.Spares.OwnershipType.Direct });
            this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leTheBank.ID, Owner =leIntelkon.ID, SharePct = 0.158M, OwnershipKind = Core.Spares.OwnershipType.Direct });
            this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leTheBank.ID, Owner =leKAST.ID, SharePct = 0.07M, OwnershipKind = Core.Spares.OwnershipType.Direct });
            this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leTheBank.ID, Owner =physKurshev.ID, SharePct = 0.0169M, OwnershipKind = Core.Spares.OwnershipType.Direct });
            this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leTheBank.ID, Owner =leUPTK.ID, SharePct = 0.0135M, OwnershipKind = Core.Spares.OwnershipType.Direct });
            this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leTheBank.ID, Owner =leFOTON.ID, SharePct = 0.0024M, OwnershipKind = Core.Spares.OwnershipType.Direct });
            this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leTheBank.ID, Owner =leMlynmontazh.ID, SharePct = 0.0007M, OwnershipKind = Core.Spares.OwnershipType.Direct });
            this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leTheBank.ID, Owner =leKondor.ID, SharePct = 0.0004M, OwnershipKind = Core.Spares.OwnershipType.Direct });


            #endregion

            #region Публічне акціонерне товариство "ЗНВКІФ "Нові технології"  
            this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leNoviThekhn.ID, Owner =leGoodLightCapitalLtd.ID, SharePct = 50M, OwnershipKind = Core.Spares.OwnershipType.Direct });
            this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leNoviThekhn.ID, Owner =leFieldLane.ID, SharePct = 50M, OwnershipKind = Core.Spares.OwnershipType.Direct });
            //this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leTheBank.ID, Owner =physUmanets.ID, SharePct = M, OwnershipKind = Core.Spares.OwnershipType.Direct });
            this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leFieldLane.ID, Owner =physElmIbanez.ID, SharePct = 100M, OwnershipKind = Core.Spares.OwnershipType.Direct });
            this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leGoodLightCapitalLtd.ID, Owner =physWlmartnDeBeer.ID, SharePct = 100M, OwnershipKind = Core.Spares.OwnershipType.Direct });

            #endregion
            #region Товариство з обмеженою відповідальністю "Торговий дім "ЕКО-ВУГІЛЛЯ УКРАЇНИ"  
            #endregion
            #region Товариство з обмеженою відповідальністю "Торгова Компанія ІНТАЛ"  
            #endregion
            #region Товариство з обмеженою відповідальністю "ТОП"  
            #endregion
            #region Товариство з обмеженою відповідальністю "СТАВР"  
            #endregion
            #region Товариство з обмеженою відповідальністю "БСК."  
            #endregion
            #region Товариство з обмеженою відповідальністю "Фінансова компанія "Лідер"  
            #endregion
            #region Приватне підприємство "ПАРАДІГМА-СІ"  
            #endregion
            #region Товариство з обмеженою відповідальністю "Інтерофіс Лімітед"  
            this._appx2Questionnaire.BankExistingCommonImplicitOwners.Add(new OwnershipStructure() { Asset = leInterofficeLtd.ID, Owner =leNoviThekhn.ID, SharePct = 100.00M, OwnershipKind = Core.Spares.OwnershipType.Direct });
            #endregion
            #region Державне підприємство "АНТОНОВ"  
            #endregion
            #region Приватне підприємство "IНТЕР ЛЕНД"  
            #endregion
            #region Державне підприємство "Виробниче об'єднання "Київприлад"  
            #endregion
            #region Товариство з обмеженою відповідальністю "ФОРТЕКС-М"  
            #endregion
            #region Товариство з обмеженою відповідальністю "Виробничо-комерційна фірма "ІНТЕЛКОН"  
            #endregion
            #region Приватне підприємство "КАСТ"  
            #endregion
            #region Приватний підприємець Куршев Генадій Олексійович  
            #endregion
            #region Приватне акціонерне товариство "УПТК"  
            #endregion
            #region Приватне акціонерне товариство "Київський завод світлочутливих матеріалів "ФОТОН"  
            #endregion
            #region Публічне акціонерне товариство "Млинмонтаж"  
            #endregion
            #region Приватне підприємство "Кондор"  
            #endregion

        }
    }
}
