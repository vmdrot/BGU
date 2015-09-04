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
        private GenericPersonInfo _gpiPonomarenkoSG;
        #endregion

        #region prop(s) (Mentioned identities, addresses, etc.)
        private GenericPersonInfo gpiPonomarenkoSG
        {
            get
            {
                if (_gpiPonomarenkoSG == null)
                {
                    _gpiPonomarenkoSG = new GenericPersonInfo()
                    {
                        PersonType = Core.Spares.EntityType.Physical,
                        PhysicalPerson = new PhysicalPersonInfo() 
                        { 
                            FullName = "Пономаренко Сергій Григорович",
                            CitizenshipCountry = CountryInfo.UKRAINE,
                            TaxOrSocSecID = "2090110572",
                            PassportID = "НК № 014125",
                            BirthDate = DateTime.Parse("23.03.1957"),
                            Address = LocationInfo.Parse("вул.Грушевського, буд. 13, смт Сосниця, Чернігівська обл., 16100")
                        }
                    };
                }
                return _gpiPonomarenkoSG;
            }
        }

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
