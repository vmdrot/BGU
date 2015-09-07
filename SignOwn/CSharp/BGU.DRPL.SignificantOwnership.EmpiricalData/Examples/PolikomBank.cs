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
        private GenericPersonInfo _gipChernihivCentrNerukh;
        private GenericPersonInfo _gipPolikombank;
        private GenericPersonInfo _gipChernihivVodProekt;
        private GenericPersonInfo _gipPonomarenkoSG;
        private GenericPersonInfo _gipHorodnychyiVK;
        private GenericPersonInfo _gipKosolapHA;
        private GenericPersonInfo _gipPankevychOM;
        private GenericPersonInfo _gipPonomarenkoHD;
        private GenericPersonInfo _gipNyzhnykOP;
        private GenericPersonInfo _gipSuprunNS;
        private GenericPersonInfo _gipBakhyrSH;
        private GenericPersonInfo _gipHatsaOP;
        private GenericPersonInfo _gipZudikVI;
        private GenericPersonInfo _gipNaskalnaMA;
        private GenericPersonInfo _gipPitsMM;
        private GenericPersonInfo _gipKoshovaKM;
        private GenericPersonInfo _gipKuzmenkoYuV;
        private GenericPersonInfo _gipMelnychenkoVI;
        private GenericPersonInfo _gipDavydovaHI;
        private GenericPersonInfo _gipYermolenkoTP;
        private GenericPersonInfo _gipKurylenkoKS;
        private GenericPersonInfo _gipKosolapKS;
        private GenericPersonInfo _gipPodorozhniaVV;
        private GenericPersonInfo _gipTovDolia;
        #endregion

        #region prop(s) (Mentioned identities, addresses, etc.)
        //private GenericPersonInfo gpiPonomarenkoSG { get { if (_gipPonomarenkoSG == null) { _gipPonomarenkoSG = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { FullName = "Пономаренко Сергій Григорович", CitizenshipCountry = CountryInfo.UKRAINE, TaxOrSocSecID = "2090110572", PassportID = "НК № 014125", BirthDate = DateTime.Parse("23.03.1957"), Address = LocationInfo.Parse("вул.Грушевського, буд. 13, смт Сосниця, Чернігівська обл., 16100") } }; } return _gipPonomarenkoSG; } }


        private GenericPersonInfo gipPonomarenkoSG { get { if (_gipPonomarenkoSG == null) { _gipPonomarenkoSG = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { FullName = "Пономаренко Сергій Григорович", CitizenshipCountry = CountryInfo.UKRAINE, TaxOrSocSecID = "2090110572", PassportID = "НК № 014125", BirthDate = DateTime.Parse("20902"), Address = LocationInfo.Parse("вул.Грушевського, буд. 13, смт Сосниця, Чернігівська обл., 16100") } }; } return _gipPonomarenkoSG; } }
        private GenericPersonInfo gipHorodnychyiVK { get { if (_gipHorodnychyiVK == null) { _gipHorodnychyiVK = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { FullName = "Городничий Василь Кузьмич", CitizenshipCountry = CountryInfo.UKRAINE, TaxOrSocSecID = "д/в", PassportID = "I-ЕЛ № 646846", BirthDate = DateTime.Parse("д/в"), Address = LocationInfo.Parse("вул.Корнєва, буд. 72, смт Сосниця, Чернігівська обл., 16100") } }; } return _gipHorodnychyiVK; } }
        private GenericPersonInfo gipKosolapHA { get { if (_gipKosolapHA == null) { _gipKosolapHA = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { FullName = "Косолап Ганна Акиндинівна", CitizenshipCountry = CountryInfo.UKRAINE, TaxOrSocSecID = "д/в", PassportID = "I-ЕЛ № 550299", BirthDate = DateTime.Parse("д/в"), Address = LocationInfo.Parse("вул.Революції, буд. 12, смт Сосниця, Чернігівська обл., 16100") } }; } return _gipKosolapHA; } }
        private GenericPersonInfo gipPankevychOM { get { if (_gipPankevychOM == null) { _gipPankevychOM = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { FullName = "Панкевич Оксана Михайлівна", CitizenshipCountry = CountryInfo.UKRAINE, TaxOrSocSecID = "2738006422", PassportID = "VII-ЕЛ №556509", BirthDate = DateTime.Parse("д/в"), Address = LocationInfo.Parse("вул.Вишгородвська, буд. 51/1, кв. 8, м.Київ, 01001") } }; } return _gipPankevychOM; } }
        private GenericPersonInfo gipPonomarenkoHD { get { if (_gipPonomarenkoHD == null) { _gipPonomarenkoHD = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { FullName = "Пономаренко Ганна Дмитрівна", CitizenshipCountry = CountryInfo.UKRAINE, TaxOrSocSecID = "д/в", PassportID = "I-ЕЛ № 549239", BirthDate = DateTime.Parse("д/в"), Address = LocationInfo.Parse("вул. Червонофлотська, буд. 30-А, кв.19, смт Сосниця, Чернігівська обл., 16100") } }; } return _gipPonomarenkoHD; } }
        private GenericPersonInfo gipNyzhnykOP { get { if (_gipNyzhnykOP == null) { _gipNyzhnykOP = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { FullName = "Нижник Олег Петрович", CitizenshipCountry = CountryInfo.UKRAINE, TaxOrSocSecID = "д/в", PassportID = "I-ЕЛ № 549239", BirthDate = DateTime.Parse("д/в"), Address = LocationInfo.Parse("вул. Червонофлотська, буд. 30-А, кв.19, смт Сосниця, Чернігівська обл., 16100") } }; } return _gipNyzhnykOP; } }
        private GenericPersonInfo gipSuprunNS { get { if (_gipSuprunNS == null) { _gipSuprunNS = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { FullName = "Супрун Надія Степанівна", CitizenshipCountry = CountryInfo.UKRAINE, TaxOrSocSecID = "д/в", PassportID = "НК № 747617", BirthDate = DateTime.Parse("д/в"), Address = LocationInfo.Parse("вул.Петровського, буд.33, смт Сосниця, Чернігівська обл., 16100") } }; } return _gipSuprunNS; } }
        private GenericPersonInfo gipBakhyrSH { get { if (_gipBakhyrSH == null) { _gipBakhyrSH = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { FullName = "Бахир Сергій Григорович", CitizenshipCountry = CountryInfo.UKRAINE, TaxOrSocSecID = "д/в", PassportID = "V-ЕЛ № 721345", BirthDate = DateTime.Parse("д/в"), Address = LocationInfo.Parse("вул.Червонофлотська, буд.14, смт Сосниця, Чернігівська обл., 16100") } }; } return _gipBakhyrSH; } }
        private GenericPersonInfo gipHatsaOP { get { if (_gipHatsaOP == null) { _gipHatsaOP = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { FullName = "Гаца Олександр Петрович", CitizenshipCountry = CountryInfo.UKRAINE, TaxOrSocSecID = "д/в", PassportID = "III-ЕЛ № 726345", BirthDate = DateTime.Parse("д/в"), Address = LocationInfo.Parse("вул.Перемоги, буд.19, смт Сосниця, Чернігівська обл., 16100") } }; } return _gipHatsaOP; } }
        private GenericPersonInfo gipZudikVI { get { if (_gipZudikVI == null) { _gipZudikVI = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { FullName = "Жудік Валентина Іванівна", CitizenshipCountry = CountryInfo.UKRAINE, TaxOrSocSecID = "1722407746", PassportID = "НК № 720323", BirthDate = DateTime.Parse("д/в"), Address = LocationInfo.Parse("вул. Червонофлотська, буд. 30-А, кв.15, смт Сосниця, Чернігівська обл., 16100") } }; } return _gipZudikVI; } }
        private GenericPersonInfo gipNaskalnaMA { get { if (_gipNaskalnaMA == null) { _gipNaskalnaMA = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { FullName = "Наскальна Марія Адамівна", CitizenshipCountry = CountryInfo.UKRAINE, TaxOrSocSecID = "7772017567", PassportID = "НК № 450871", BirthDate = DateTime.Parse("д/в"), Address = LocationInfo.Parse("вул.Покрівська, буд. 4-Б, кв.13, смт Сосниця, Чернігівська обл., 16100") } }; } return _gipNaskalnaMA; } }
        private GenericPersonInfo gipPitsMM { get { if (_gipPitsMM == null) { _gipPitsMM = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { FullName = "Піц Михайло Михайлович", CitizenshipCountry = CountryInfo.UKRAINE, TaxOrSocSecID = "д/в", PassportID = "I-ЕЛ № 646563", BirthDate = DateTime.Parse("д/в"), Address = LocationInfo.Parse("вул.Миру, буд.9, смт Сосниця, Чернігівська обл., 16100") } }; } return _gipPitsMM; } }
        private GenericPersonInfo gipKoshovaKM { get { if (_gipKoshovaKM == null) { _gipKoshovaKM = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { FullName = "Кошова Катерина Михайлівна", CitizenshipCountry = CountryInfo.UKRAINE, TaxOrSocSecID = "2003619984", PassportID = "НК № 162622", BirthDate = DateTime.Parse("д/в"), Address = LocationInfo.Parse("вул.Зелена, буд.14, смт Сосниця, Чернігівська обл., 16100") } }; } return _gipKoshovaKM; } }
        private GenericPersonInfo gipKuzmenkoYuV { get { if (_gipKuzmenkoYuV == null) { _gipKuzmenkoYuV = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { FullName = "Кузьменко Юрій Вадимович", CitizenshipCountry = CountryInfo.UKRAINE, TaxOrSocSecID = "д/в", PassportID = "III-ЕЛ № 532573", BirthDate = DateTime.Parse("д/в"), Address = LocationInfo.Parse("вул.Леніна, буд.2, кв.2, смт Сосниця, Чернігівська обл., 16100") } }; } return _gipKuzmenkoYuV; } }
        private GenericPersonInfo gipMelnychenkoVI { get { if (_gipMelnychenkoVI == null) { _gipMelnychenkoVI = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { FullName = "Мельниченко Валентина Іванівна", CitizenshipCountry = CountryInfo.UKRAINE, TaxOrSocSecID = "д/в", PassportID = "I-ЕЛ № 550411", BirthDate = DateTime.Parse("д/в"), Address = LocationInfo.Parse("вул.Республіканська, буд.28, кв.16, смт Сосниця, Чернігівська обл., 16100") } }; } return _gipMelnychenkoVI; } }
        private GenericPersonInfo gipDavydovaHI { get { if (_gipDavydovaHI == null) { _gipDavydovaHI = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { FullName = "Давидова Галина Іванівна", CitizenshipCountry = CountryInfo.UKRAINE, TaxOrSocSecID = "1989810489", PassportID = "НК № 049748", BirthDate = DateTime.Parse("д/в"), Address = LocationInfo.Parse("вул.Квіткова, буд.22, смт Сосниця, Чернігівська обл., 16100") } }; } return _gipDavydovaHI; } }
        private GenericPersonInfo gipYermolenkoTP { get { if (_gipYermolenkoTP == null) { _gipYermolenkoTP = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { FullName = "Єрмоленко Тетяна Петрівна", CitizenshipCountry = CountryInfo.UKRAINE, TaxOrSocSecID = "1849411483", PassportID = "НК № 234760", BirthDate = DateTime.Parse("д/в"), Address = LocationInfo.Parse("вул.Грушевського, буд. 42, смт Сосниця, Чернігівська обл., 16100") } }; } return _gipYermolenkoTP; } }
        private GenericPersonInfo gipKurylenkoKS { get { if (_gipKurylenkoKS == null) { _gipKurylenkoKS = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { FullName = "Куриленко Катерина Сергіївна", CitizenshipCountry = CountryInfo.UKRAINE, TaxOrSocSecID = "2121510347", PassportID = "НМ № 065089", BirthDate = DateTime.Parse("д/в"), Address = LocationInfo.Parse("вул.Чернігівська, буд.21, кв.2, смт Сосниця, Чернігівська обл., 16100") } }; } return _gipKurylenkoKS; } }
        private GenericPersonInfo gipKosolapKS { get { if (_gipKosolapKS == null) { _gipKosolapKS = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { FullName = "Косолап Раїса Андріївна", CitizenshipCountry = CountryInfo.UKRAINE, TaxOrSocSecID = "д/в", PassportID = "VI-ЕЛ № 687189", BirthDate = DateTime.Parse("д/в"), Address = LocationInfo.Parse("вул.Революції, буд. 2, смт Сосниця, Чернігівська обл., 16100") } }; } return _gipKosolapKS; } }
        private GenericPersonInfo gipPodorozhniaVV { get { if (_gipPodorozhniaVV == null) { _gipPodorozhniaVV = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Physical, PhysicalPerson = new PhysicalPersonInfo() { FullName = "Подорожня Валентина Володимирівна", CitizenshipCountry = CountryInfo.UKRAINE, TaxOrSocSecID = "2648408062", PassportID = "НК № 450025", BirthDate = DateTime.Parse("д/в"), Address = LocationInfo.Parse("вул.Грушевського, буд.1, смт Сосниця, Чернігівська обл., 16100") } }; } return _gipPodorozhniaVV; } }

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
                            RepresentedBy = gipPonomarenkoSG.ID,
                            RegisteredDateID = new LPRegisteredDateRecordId() { RegisteredDate = DateTime.Parse("12.09.1996") },
                            Registrar = new RegistrarAuthority() { RegistrarName = "Сосницька державна адміністрація Чернігівської області", JurisdictionCountry = CountryInfo.UKRAINE, EntitiesHandled = Core.Spares.EntityType.Legal}
                        }
                    };
                }
                return _gpiElita;
            }
        }


        private GenericPersonInfo gipChernihivCentrNerukh { get { if(_gipChernihivCentrNerukh == null){ _gipChernihivCentrNerukh = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Legal, LegalPerson = new LegalPersonInfo() { Name = "ТОВ \"Чернігівський центр нерухомості\"", TaxCodeOrHandelsRegNr = "35779433", ResidenceCountry = CountryInfo.UKRAINE, Address = LocationInfo.Parse("пр-т Миру, буд. 33, м.Чернігів, 14000")} }; } return _gipChernihivCentrNerukh; } }
        private GenericPersonInfo gipPolikombank { get { if (_gipPolikombank == null) { _gipPolikombank = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Legal, LegalPerson = new LegalPersonInfo() { Name = "Полікомбанк", TaxCodeOrHandelsRegNr = "19356610", ResidenceCountry = CountryInfo.UKRAINE, Address = LocationInfo.Parse("вул.О.Молодчого, буд. 46, м.Чернігів, 14013") } }; } return _gipPolikombank; } }
        private GenericPersonInfo gipChernihivVodProekt { get { if(_gipChernihivVodProekt == null){ _gipChernihivVodProekt = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Legal, LegalPerson = new LegalPersonInfo() { Name = "ПАТ \"Чернігівводпроект\"", TaxCodeOrHandelsRegNr = "01039599", ResidenceCountry = CountryInfo.UKRAINE, Address = LocationInfo.Parse("пр-т Перемоги, буд. 39, м.Чернігів, 14017")} }; } return _gipChernihivVodProekt; } }

        private GenericPersonInfo gipTovDolia { get { if(_gipTovDolia == null){ _gipTovDolia = new GenericPersonInfo() { PersonType = Core.Spares.EntityType.Legal, LegalPerson = new LegalPersonInfo() { Name = "ТОВ \"Доля\"", TaxCodeOrHandelsRegNr = "Україна", ResidenceCountry = CountryInfo.UKRAINE, Address = LocationInfo.Parse("пр-т Миру, буд.33, м.Чернігів, 14000")} }; } return _gipTovDolia; } }
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
            //todo

            return rslt;
        }
    }
}
