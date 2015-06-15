using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using Evolvex.Utility.Core.ComponentModelEx;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Dict
{
    /// <summary>
    /// Інформація про банк - як український, так і іноземний (якщо треба)
    /// Приклад реалізації Web UI (без заповнення поля LegalPerson) див. за адресою https://youtu.be/ReThZDDMsOM
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.BankInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class BankInfo
    {
        /// <summary>
        /// Для українських банків MFO (GLMFO)
        /// Для банків-нерезидентів - національний кліринговий код (Bankleitzahl (BLZ), Sorted CHAPS code, FedWire, Codigo Bancario, Code Guichet, тощо)
        /// Обов'язкове поле, якщо OperationCountry == UKRAINE
        /// ( http://www.tgbr.com/tgbr/help/RTN.html )
        /// </summary>
        [Description("МФО")]
        [DisplayName("МФО")]
        public string MFO { get; set; }
        /// <summary>
        /// У Rcukru - REGN (тільки дла укр.банків)
        /// </summary>
        [Obsolete]
        [Description("№ у реєстрі банків (лише для головних контор)")]
        [DisplayName("№ у реєстрі банків")]
        public string RegistryNr { get; set; }
        /// <summary>
        /// У Rcukru - GLB (тільки дла укр.банків)
        /// </summary>
        [Obsolete]
        [Description("Код банку (лише для головних контор)")]
        [DisplayName("Код банку")]
        public string Code { get; set; }
        /// <summary>
        /// Оригінальна назва банку (мовою країни резидентності)
        /// Для українських банків заповнюється лише ця назва
        /// </summary>
        [Description("Найменування банку (в оригіналі)")]
        [DisplayName("Найменування банку")]
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Назва банку українською (для банків-нерезидентів)
        /// </summary>
        [Description("Найменування банку(українською)")]
        [DisplayName("Найменування банку(українською)")]
        public string NameUkr { get; set; }
        /// <summary>
        /// Реквізити банку як юр.особи.
        /// Адреса, коди, тощо - все там. 
        /// Якщо у анкеті доведеться розкривати структуру власності у т.ч. й цього банку, то необхідно вказати бодай податковий код банку (чи його еквівалент)
        /// </summary>
        [Description("Відомості про юрособу-банк")]
        [DisplayName("Відомості про юрособу-банк")]
        public GenericPersonID LegalPerson { get; set; }

        /// <summary>
        /// SWIFT код (для банків нерезидентів), 
        /// як однозначний універсальний ідентифікатор банку
        /// Бажаний, якщо є; якщо немає - вимагати вказання національного клірингового ідентифікатору (поле MFO)
        /// http://www.swift.com/bsl/
        /// </summary>
        [DisplayName("SWIFT адреса")]
        [Description("Див. http://www.swift.com/bsl/")]
        public string SWIFTBIC { get; set; }

        /// <summary>
        /// Країна резидентності банку
        /// Значення за змовчанням - Україна (UA, UKR, 804, Ukraine)
        /// </summary>
        [DisplayName("Країна діяльності")]
        [Required]
        public CountryInfo OperationCountry { get; set; }

        public BankInfo() 
        {
            OperationCountry = CountryInfo.UKRAINE;
        }
        public BankInfo(LegalPersonInfo le) : this()
        {
            LegalPerson = le.GenericID;
            Name = le.Name;
        }

        public override string ToString()
        {
            return Name;
        }

        public static BankInfo ParseFromRcuKruRow(DataRow dr)
        {
            string prb = dr["PRB"] as string;

            string glmfo = ((int)dr["GLMFO"]).ToString();
            string mfo = ((int)dr["MFO"]).ToString();
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
            return bi;
        }
    }
}
