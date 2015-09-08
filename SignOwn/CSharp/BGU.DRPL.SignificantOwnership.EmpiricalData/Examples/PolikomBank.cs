using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Questionnaires;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;

namespace BGU.DRPL.SignificantOwnership.EmpiricalData.Examples
{
    public class PolikomBank
    {
        private RegLicAppx2OwnershipAcqRequestLP _regLicAppx2;
        public RegLicAppx2OwnershipAcqRequestLP RegLicAppx2
        {
            get
            {
                if(_regLicAppx2 == null)
                    _regLicAppx2 = GenerateRegLicAppx2();
                return _regLicAppx2;
            }
        }

        #region fields (Mentioned identities, addresses, etc.)
        private GenericPersonInfo _gpiElita;
        private GenericPersonInfo _gpiChernihivCentrNerukh;
        private GenericPersonInfo _gpiPolikombank;
        private GenericPersonInfo _gpiChernihivVodProekt;
        private GenericPersonInfo _gpiPonomarenkoSG;
        private GenericPersonInfo _gpiHorodnychyiVK;
        private GenericPersonInfo _gpiKosolapHA;
        private GenericPersonInfo _gpiPankevychOM;
        private GenericPersonInfo _gpiPonomarenkoHD;
        private GenericPersonInfo _gpiNyzhnykOP;
        private GenericPersonInfo _gpiSuprunNS;
        private GenericPersonInfo _gpiBakhyrSH;
        private GenericPersonInfo _gpiHatsaOP;
        private GenericPersonInfo _gpiZudikVI;
        private GenericPersonInfo _gpiNaskalnaMA;
        private GenericPersonInfo _gpiPitsMM;
        private GenericPersonInfo _gpiKoshovaKM;
        private GenericPersonInfo _gpiKuzmenkoYuV;
        private GenericPersonInfo _gpiMelnychenkoVI;
        private GenericPersonInfo _gpiDavydovaHI;
        private GenericPersonInfo _gpiYermolenkoTP;
        private GenericPersonInfo _gpiKurylenkoKS;
        private GenericPersonInfo _gpiKosolapKS;
        private GenericPersonInfo _gpiPodorozhniaVV;
        private GenericPersonInfo _gpiTovDolia;
        #endregion

        #region prop(s) (Mentioned identities, addresses, etc.)
        //private GenericPersonInfo gpiPonomarenkoSG { get { if (_gpiPonomarenkoSG == null) { _gpiPonomarenkoSG = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { FullName = "Пономаренко Сергій Григорович", CitizenshipCountry = CountryInfo.UKRAINE, TaxOrSocSecID = "2090110572", PassportID = "НК № 014125", BirthDate = DateTime.Parse("23.03.1957"), Address = LocationInfo.Parse("вул.Грушевського, буд. 13, смт Сосниця, Чернігівська обл., 16100") } }; } return _gpiPonomarenkoSG; } }


        private GenericPersonInfo gpiPonomarenkoSG { get { if (_gpiPonomarenkoSG == null) { _gpiPonomarenkoSG = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { FullName = "Пономаренко Сергій Григорович", CitizenshipCountry = CountryInfo.UKRAINE, TaxOrSocSecID = "2090110572", PassportID = "НК № 014125", BirthDate = DateTime.Parse("20902"), Address = LocationInfo.Parse("вул.Грушевського, буд. 13, смт Сосниця, Чернігівська обл., 16100") } }; } return _gpiPonomarenkoSG; } }
        private GenericPersonInfo gpiHorodnychyiVK { get { if (_gpiHorodnychyiVK == null) { _gpiHorodnychyiVK = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { FullName = "Городничий Василь Кузьмич", CitizenshipCountry = CountryInfo.UKRAINE,  PassportID = "I-ЕЛ № 646846",  Address = LocationInfo.Parse("вул.Корнєва, буд. 72, смт Сосниця, Чернігівська обл., 16100") } }; } return _gpiHorodnychyiVK; } }
        private GenericPersonInfo gpiKosolapHA { get { if (_gpiKosolapHA == null) { _gpiKosolapHA = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { FullName = "Косолап Ганна Акиндинівна", CitizenshipCountry = CountryInfo.UKRAINE,  PassportID = "I-ЕЛ № 550299",  Address = LocationInfo.Parse("вул.Революції, буд. 12, смт Сосниця, Чернігівська обл., 16100") } }; } return _gpiKosolapHA; } }
        private GenericPersonInfo gpiPankevychOM { get { if (_gpiPankevychOM == null) { _gpiPankevychOM = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { FullName = "Панкевич Оксана Михайлівна", CitizenshipCountry = CountryInfo.UKRAINE, TaxOrSocSecID = "2738006422", PassportID = "VII-ЕЛ №556509",  Address = LocationInfo.Parse("вул.Вишгородвська, буд. 51/1, кв. 8, м.Київ, 01001") } }; } return _gpiPankevychOM; } }
        private GenericPersonInfo gpiPonomarenkoHD { get { if (_gpiPonomarenkoHD == null) { _gpiPonomarenkoHD = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { FullName = "Пономаренко Ганна Дмитрівна", CitizenshipCountry = CountryInfo.UKRAINE,  PassportID = "I-ЕЛ № 549239",  Address = LocationInfo.Parse("вул. Червонофлотська, буд. 30-А, кв.19, смт Сосниця, Чернігівська обл., 16100") } }; } return _gpiPonomarenkoHD; } }
        private GenericPersonInfo gpiNyzhnykOP { get { if (_gpiNyzhnykOP == null) { _gpiNyzhnykOP = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { FullName = "Нижник Олег Петрович", CitizenshipCountry = CountryInfo.UKRAINE,  PassportID = "I-ЕЛ № 549239",  Address = LocationInfo.Parse("вул. Червонофлотська, буд. 30-А, кв.19, смт Сосниця, Чернігівська обл., 16100") } }; } return _gpiNyzhnykOP; } }
        private GenericPersonInfo gpiSuprunNS { get { if (_gpiSuprunNS == null) { _gpiSuprunNS = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { FullName = "Супрун Надія Степанівна", CitizenshipCountry = CountryInfo.UKRAINE,  PassportID = "НК № 747617",  Address = LocationInfo.Parse("вул.Петровського, буд.33, смт Сосниця, Чернігівська обл., 16100") } }; } return _gpiSuprunNS; } }
        private GenericPersonInfo gpiBakhyrSH { get { if (_gpiBakhyrSH == null) { _gpiBakhyrSH = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { FullName = "Бахир Сергій Григорович", CitizenshipCountry = CountryInfo.UKRAINE,  PassportID = "V-ЕЛ № 721345",  Address = LocationInfo.Parse("вул.Червонофлотська, буд.14, смт Сосниця, Чернігівська обл., 16100") } }; } return _gpiBakhyrSH; } }
        private GenericPersonInfo gpiHatsaOP { get { if (_gpiHatsaOP == null) { _gpiHatsaOP = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { FullName = "Гаца Олександр Петрович", CitizenshipCountry = CountryInfo.UKRAINE,  PassportID = "III-ЕЛ № 726345",  Address = LocationInfo.Parse("вул.Перемоги, буд.19, смт Сосниця, Чернігівська обл., 16100") } }; } return _gpiHatsaOP; } }
        private GenericPersonInfo gpiZudikVI { get { if (_gpiZudikVI == null) { _gpiZudikVI = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { FullName = "Жудік Валентина Іванівна", CitizenshipCountry = CountryInfo.UKRAINE, TaxOrSocSecID = "1722407746", PassportID = "НК № 720323",  Address = LocationInfo.Parse("вул. Червонофлотська, буд. 30-А, кв.15, смт Сосниця, Чернігівська обл., 16100") } }; } return _gpiZudikVI; } }
        private GenericPersonInfo gpiNaskalnaMA { get { if (_gpiNaskalnaMA == null) { _gpiNaskalnaMA = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { FullName = "Наскальна Марія Адамівна", CitizenshipCountry = CountryInfo.UKRAINE, TaxOrSocSecID = "7772017567", PassportID = "НК № 450871",  Address = LocationInfo.Parse("вул.Покрівська, буд. 4-Б, кв.13, смт Сосниця, Чернігівська обл., 16100") } }; } return _gpiNaskalnaMA; } }
        private GenericPersonInfo gpiPitsMM { get { if (_gpiPitsMM == null) { _gpiPitsMM = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { FullName = "Піц Михайло Михайлович", CitizenshipCountry = CountryInfo.UKRAINE,  PassportID = "I-ЕЛ № 646563",  Address = LocationInfo.Parse("вул.Миру, буд.9, смт Сосниця, Чернігівська обл., 16100") } }; } return _gpiPitsMM; } }
        private GenericPersonInfo gpiKoshovaKM { get { if (_gpiKoshovaKM == null) { _gpiKoshovaKM = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { FullName = "Кошова Катерина Михайлівна", CitizenshipCountry = CountryInfo.UKRAINE, TaxOrSocSecID = "2003619984", PassportID = "НК № 162622",  Address = LocationInfo.Parse("вул.Зелена, буд.14, смт Сосниця, Чернігівська обл., 16100") } }; } return _gpiKoshovaKM; } }
        private GenericPersonInfo gpiKuzmenkoYuV { get { if (_gpiKuzmenkoYuV == null) { _gpiKuzmenkoYuV = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { FullName = "Кузьменко Юрій Вадимович", CitizenshipCountry = CountryInfo.UKRAINE,  PassportID = "III-ЕЛ № 532573",  Address = LocationInfo.Parse("вул.Леніна, буд.2, кв.2, смт Сосниця, Чернігівська обл., 16100") } }; } return _gpiKuzmenkoYuV; } }
        private GenericPersonInfo gpiMelnychenkoVI { get { if (_gpiMelnychenkoVI == null) { _gpiMelnychenkoVI = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { FullName = "Мельниченко Валентина Іванівна", CitizenshipCountry = CountryInfo.UKRAINE,  PassportID = "I-ЕЛ № 550411",  Address = LocationInfo.Parse("вул.Республіканська, буд.28, кв.16, смт Сосниця, Чернігівська обл., 16100") } }; } return _gpiMelnychenkoVI; } }
        private GenericPersonInfo gpiDavydovaHI { get { if (_gpiDavydovaHI == null) { _gpiDavydovaHI = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { FullName = "Давидова Галина Іванівна", CitizenshipCountry = CountryInfo.UKRAINE, TaxOrSocSecID = "1989810489", PassportID = "НК № 049748",  Address = LocationInfo.Parse("вул.Квіткова, буд.22, смт Сосниця, Чернігівська обл., 16100") } }; } return _gpiDavydovaHI; } }
        private GenericPersonInfo gpiYermolenkoTP { get { if (_gpiYermolenkoTP == null) { _gpiYermolenkoTP = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { FullName = "Єрмоленко Тетяна Петрівна", CitizenshipCountry = CountryInfo.UKRAINE, TaxOrSocSecID = "1849411483", PassportID = "НК № 234760",  Address = LocationInfo.Parse("вул.Грушевського, буд. 42, смт Сосниця, Чернігівська обл., 16100") } }; } return _gpiYermolenkoTP; } }
        private GenericPersonInfo gpiKurylenkoKS { get { if (_gpiKurylenkoKS == null) { _gpiKurylenkoKS = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { FullName = "Куриленко Катерина Сергіївна", CitizenshipCountry = CountryInfo.UKRAINE, TaxOrSocSecID = "2121510347", PassportID = "НМ № 065089",  Address = LocationInfo.Parse("вул.Чернігівська, буд.21, кв.2, смт Сосниця, Чернігівська обл., 16100") } }; } return _gpiKurylenkoKS; } }
        private GenericPersonInfo gpiKosolapKS { get { if (_gpiKosolapKS == null) { _gpiKosolapKS = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { FullName = "Косолап Раїса Андріївна", CitizenshipCountry = CountryInfo.UKRAINE,  PassportID = "VI-ЕЛ № 687189",  Address = LocationInfo.Parse("вул.Революції, буд. 2, смт Сосниця, Чернігівська обл., 16100") } }; } return _gpiKosolapKS; } }
        private GenericPersonInfo gpiPodorozhniaVV { get { if (_gpiPodorozhniaVV == null) { _gpiPodorozhniaVV = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { FullName = "Подорожня Валентина Володимирівна", CitizenshipCountry = CountryInfo.UKRAINE, TaxOrSocSecID = "2648408062", PassportID = "НК № 450025",  Address = LocationInfo.Parse("вул.Грушевського, буд.1, смт Сосниця, Чернігівська обл., 16100") } }; } return _gpiPodorozhniaVV; } }

        private GenericPersonInfo gpiElita
        {
            get
            {
                if (_gpiElita == null)
                {

                    _gpiElita = new GenericPersonInfo()
                    {
                        PersonType = Core.Spares.EntityType.Legal,
                        LegalPerson = new LegalPersonInfo()
                        {
                            Name = "ПАТ \"Еліта\"",
                            ResidenceCountry = CountryInfo.UKRAINE,
                            Address = LocationInfo.Parse("вул.Освіти, буд. 10, смт Сосниця, Чернігівська обл., 16100"),
                            TaxCodeOrHandelsRegNr = "00310120",
                            RepresentedBy = gpiPonomarenkoSG.ID,
                            RegisteredDateID = new LPRegisteredDateRecordId() { RegisteredDate = DateTime.Parse("12.09.1996") },
                            Registrar = new RegistrarAuthority() { RegistrarName = "Сосницька державна адміністрація Чернігівської області", JurisdictionCountry = CountryInfo.UKRAINE, EntitiesHandled = Core.Spares.EntityType.Legal}
                        }
                    };
                }
                return _gpiElita;
            }
        }


        private GenericPersonInfo gpiChernihivCentrNerukh { get { if(_gpiChernihivCentrNerukh == null){ _gpiChernihivCentrNerukh = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Legal, LegalPerson = new LegalPersonInfo() { Name = "ТОВ \"Чернігівський центр нерухомості\"", TaxCodeOrHandelsRegNr = "35779433", ResidenceCountry = CountryInfo.UKRAINE, Address = LocationInfo.Parse("пр-т Миру, буд. 33, м.Чернігів, 14000")} }; } return _gpiChernihivCentrNerukh; } }
        private GenericPersonInfo gpiPolikombank { get { if (_gpiPolikombank == null) { _gpiPolikombank = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Legal, LegalPerson = new LegalPersonInfo() { Name = "Полікомбанк", TaxCodeOrHandelsRegNr = "19356610", ResidenceCountry = CountryInfo.UKRAINE, Address = LocationInfo.Parse("вул.О.Молодчого, буд. 46, м.Чернігів, 14013") } }; } return _gpiPolikombank; } }
        private GenericPersonInfo gpiChernihivVodProekt { get { if(_gpiChernihivVodProekt == null){ _gpiChernihivVodProekt = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Legal, LegalPerson = new LegalPersonInfo() { Name = "ПАТ \"Чернігівводпроект\"", TaxCodeOrHandelsRegNr = "01039599", ResidenceCountry = CountryInfo.UKRAINE, Address = LocationInfo.Parse("пр-т Перемоги, буд. 39, м.Чернігів, 14017")} }; } return _gpiChernihivVodProekt; } }

        private GenericPersonInfo gpiTovDolia { get { if(_gpiTovDolia == null){ _gpiTovDolia = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Legal, LegalPerson = new LegalPersonInfo() { Name = "ТОВ \"Доля\"", TaxCodeOrHandelsRegNr = "Україна", ResidenceCountry = CountryInfo.UKRAINE, Address = LocationInfo.Parse("пр-т Миру, буд.33, м.Чернігів, 14000")} }; } return _gpiTovDolia; } }
        #endregion


        private RegLicAppx2OwnershipAcqRequestLP GenerateRegLicAppx2()
        {
            RegLicAppx2OwnershipAcqRequestLP rslt = new RegLicAppx2OwnershipAcqRequestLP();
            rslt.BankRef = BankInfo.AllUAHeadOffices.Find(b => b.MFO == "353100");
            rslt.Acquiree = gpiElita.ID;
            rslt.AccountsWithBanks = new List<BankAccountInfo>();
            rslt.AccountsWithBanks.AddRange(new BankAccountInfo[] { new BankAccountInfo() { Bank = rslt.BankRef }, new BankAccountInfo() {Bank = BankInfo.AllUABanks.Find(b => b.MFO == "353553")} });
            rslt.TotalExistingOwnershipWithBank = new TotalOwnershipSummaryInfo()
            {
                DirectOwnershipSummary = new OwnershipSummaryInfo()
                {
                    SharesCount = 3900856,
                    SharesNominalValue = new CurrencyAmount()
                    {
                        CCY = "UAH",
                        Amt = 39008560.00M
                    },
                    Pct = 48.5785M
                }
                ,
                ImplicitPct = 0.00M,
                TotalPct = 48.5785M

            };
            rslt.ExistingOwnershipDetailsHive = new List<OwnershipStructure>
                (
                    new OwnershipStructure[]
                    {
                        new OwnershipStructure() { Asset = gpiChernihivCentrNerukh.ID, Owner = gpiElita.ID, OwnershipKind = Core.Spares.OwnershipType.Direct, SharePct = 100.0000M },
                        new OwnershipStructure() { Asset = gpiPolikombank.ID, Owner = gpiElita.ID, OwnershipKind = Core.Spares.OwnershipType.Direct, SharePct = 48.5785M },
                        new OwnershipStructure() { Asset = gpiChernihivVodProekt.ID, Owner = gpiElita.ID, OwnershipKind = Core.Spares.OwnershipType.Direct, SharePct = 8.5204M },
                        new OwnershipStructure() { Asset = gpiPolikombank.ID, Owner = gpiPonomarenkoSG.ID, OwnershipKind = Core.Spares.OwnershipType.Direct, SharePct = 0.5619M },
                        new OwnershipStructure() { Asset = gpiPolikombank.ID, Owner = gpiHorodnychyiVK.ID, OwnershipKind = Core.Spares.OwnershipType.Direct, SharePct = 0.4511M },
                        new OwnershipStructure() { Asset = gpiPolikombank.ID, Owner = gpiKosolapHA.ID, OwnershipKind = Core.Spares.OwnershipType.Direct, SharePct = 0.4511M },
                        new OwnershipStructure() { Asset = gpiPolikombank.ID, Owner = gpiPankevychOM.ID, OwnershipKind = Core.Spares.OwnershipType.Direct, SharePct = 0.4309M },
                        new OwnershipStructure() { Asset = gpiPolikombank.ID, Owner = gpiPonomarenkoHD.ID, OwnershipKind = Core.Spares.OwnershipType.Direct, SharePct = 0.4309M },
                        new OwnershipStructure() { Asset = gpiPolikombank.ID, Owner = gpiNyzhnykOP.ID, OwnershipKind = Core.Spares.OwnershipType.Direct, SharePct = 0.4203M },
                        new OwnershipStructure() { Asset = gpiPolikombank.ID, Owner = gpiSuprunNS.ID, OwnershipKind = Core.Spares.OwnershipType.Direct, SharePct = 0.4186M },
                        new OwnershipStructure() { Asset = gpiPolikombank.ID, Owner = gpiBakhyrSH.ID, OwnershipKind = Core.Spares.OwnershipType.Direct, SharePct = 0.4098M },
                        new OwnershipStructure() { Asset = gpiPolikombank.ID, Owner = gpiHatsaOP.ID, OwnershipKind = Core.Spares.OwnershipType.Direct, SharePct = 0.3693M },
                        new OwnershipStructure() { Asset = gpiPolikombank.ID, Owner = gpiZudikVI.ID, OwnershipKind = Core.Spares.OwnershipType.Direct, SharePct = 0.3570M },
                        new OwnershipStructure() { Asset = gpiPolikombank.ID, Owner = gpiNaskalnaMA.ID, OwnershipKind = Core.Spares.OwnershipType.Direct, SharePct = 0.3570M },
                        new OwnershipStructure() { Asset = gpiPolikombank.ID, Owner = gpiPitsMM.ID, OwnershipKind = Core.Spares.OwnershipType.Direct, SharePct = 0.3570M },
                        new OwnershipStructure() { Asset = gpiPolikombank.ID, Owner = gpiKoshovaKM.ID, OwnershipKind = Core.Spares.OwnershipType.Direct, SharePct = 0.3491M },
                        new OwnershipStructure() { Asset = gpiPolikombank.ID, Owner = gpiKuzmenkoYuV.ID, OwnershipKind = Core.Spares.OwnershipType.Direct, SharePct = 0.3491M },
                        new OwnershipStructure() { Asset = gpiPolikombank.ID, Owner = gpiMelnychenkoVI.ID, OwnershipKind = Core.Spares.OwnershipType.Direct, SharePct = 0.3429M },
                        new OwnershipStructure() { Asset = gpiPolikombank.ID, Owner = gpiDavydovaHI.ID, OwnershipKind = Core.Spares.OwnershipType.Direct, SharePct = 0.3368M },
                        new OwnershipStructure() { Asset = gpiPolikombank.ID, Owner = gpiYermolenkoTP.ID, OwnershipKind = Core.Spares.OwnershipType.Direct, SharePct = 0.3368M },
                        new OwnershipStructure() { Asset = gpiPolikombank.ID, Owner = gpiKurylenkoKS.ID, OwnershipKind = Core.Spares.OwnershipType.Direct, SharePct = 0.3368M },
                        new OwnershipStructure() { Asset = gpiPolikombank.ID, Owner = gpiKosolapKS.ID, OwnershipKind = Core.Spares.OwnershipType.Direct, SharePct = 0.3280M },
                        new OwnershipStructure() { Asset = gpiPolikombank.ID, Owner = gpiPodorozhniaVV.ID, OwnershipKind = Core.Spares.OwnershipType.Direct, SharePct = 0.3280M },
                        new OwnershipStructure() { Asset = gpiElita.ID, Owner = gpiTovDolia.ID, OwnershipKind = Core.Spares.OwnershipType.Direct, SharePct = 70.6331M }
                    }
                );

            rslt.HasOutstandingLoansWithBanks = true;
            rslt.OutstandingLoansWithBanksDetails = new List<LoanInfo>
                (
                    new LoanInfo[] 
                    { 
                        new LoanInfo() { LendingBank = rslt.BankRef, AgreementNr ="546", AgreementDt = DateTime.Parse("11.11.2013"), Principal = new CurrencyAmount(){ CCY = "UAH", Amt = 3900000.00M }, RepaymentDueDate = DateTime.Parse("10.11.2018"), IsOverdue = false, OutstandingPricipal = new CurrencyAmount(){ CCY = "UAH", Amt = 0.00M } },
                        new LoanInfo() { LendingBank = rslt.BankRef, AgreementNr ="546", AgreementDt = DateTime.Parse("11.11.2013"), Principal = new CurrencyAmount(){ CCY = "EUR", Amt = 150000.00M }, RepaymentDueDate = DateTime.Parse("10.11.2018"), IsOverdue = false, OutstandingPricipal = new CurrencyAmount(){ CCY = "EUR", Amt = 64788.00M } },
                    }
                );
            rslt.HasNoImperfectReputationSigns = true;
            rslt.Signatory = new SignatoryInfo() { DateSigned = DateTime.Parse("25.08.2015"), SignatoryPosition = "Директор ПАТ \"Еліта\"", SurnameInitials = "С.Г.Пономаренко" };
            rslt.ContactPerson = new ContactInfo() { Phones = new List<PhoneInfo>(new PhoneInfo[] { new PhoneInfo() { PhoneNr = "(0462) 77-48-95" } }), Person = new PhysicalPersonInfo() { FullName = "Тарасовець М.П." } };
            return rslt;
        }
    }
}
