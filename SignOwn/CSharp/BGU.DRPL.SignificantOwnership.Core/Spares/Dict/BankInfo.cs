using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using Evolvex.Utility.Core.ComponentModelEx;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;
using System.Xml.Serialization;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Dict
{
    /// <summary>
    /// Інформація про банк - як український, так і іноземний (якщо треба)
    /// Приклад реалізації Web UI (без заповнення поля LegalPerson) див. за адресою https://youtu.be/ReThZDDMsOM
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.BankInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    [XamlExpanderWrapping(false)]
    [UIUsageComboAddButton(AddNewItemCommand = "local:MyCommands.AddBankCommand", DisplayMember = "Name", ItemGetterFull = "localdata:DataModule.СurrentBanks", ValueMemberUsageMode = ComboUIValueUsageMode.SelectedItem, Width = "250", ToolTipMember = "MFO", ContainerOrientation = Orientation.Vertical)]
    public class BankInfo : NotifyPropertyChangedBase
    {
        private string _MFO;

        /// <summary>
        /// Для українських банків MFO (GLMFO)
        /// Для банків-нерезидентів - національний кліринговий код (Bankleitzahl (BLZ), Sorted CHAPS code, FedWire, Codigo Bancario, Code Guichet, тощо)
        /// Обов'язкове поле, якщо OperationCountry == UKRAINE
        /// ( http://www.tgbr.com/tgbr/help/RTN.html )
        /// </summary>
        [Description("МФО - для українського банку, для іноземного банку - національний кліринговий ідентифікатор (Sorted Chaps, BLZ, Code Guichet, тощо)")]
        [DisplayName("МФО")]
        public string MFO { get { return _MFO; } set { _MFO = value; OnPropertyChanged("MFO"); } }

        private string _RegistryNr;

        /// <summary>
        /// У Rcukru - REGN (тільки для укр.банків)
        /// </summary>
        [Obsolete]
        [Description("№ у реєстрі банків (лише для головних контор)")]
        [DisplayName("№ у реєстрі банків")]
        [UIConditionalVisibility("IsResident")]
        public string RegistryNr { get { return _RegistryNr; } set { _RegistryNr = value; OnPropertyChanged("RegistryNr"); } }

        private string _Code;

        /// <summary>
        /// У Rcukru - GLB (тільки дла укр.банків)
        /// </summary>
        [Obsolete]
        [Description("Код банку (лише для головних контор)")]
        [DisplayName("Код банку")]
        [UIConditionalVisibility("IsResident")]
        public string Code { get { return _Code; } set { _Code = value; OnPropertyChanged("Code"); } }

        private string _Name; 

        /// <summary>
        /// Оригінальна назва банку (мовою країни резидентності)
        /// Для українських банків заповнюється лише ця назва
        /// </summary>
        [Description("Найменування банку (в оригіналі)")]
        [DisplayName("Найменування банку")]
        [Required]
        public string Name { get { return _Name; } set { _Name = value; OnPropertyChanged("Name"); } }

        private string _NameUkr;
        /// <summary>
        /// Назва банку українською (для банків-нерезидентів)
        /// </summary>
        [Description("Найменування банку(українською)")]
        [DisplayName("Найменування банку(українською)")]
        [UIConditionalVisibility("IsNonResident")]
        public string NameUkr { get { return _NameUkr; } set { _NameUkr = value; OnPropertyChanged("NameUkr"); } }

        private GenericPersonID _LegalPerson;
        /// <summary>
        /// Реквізити банку як юр.особи.
        /// Адреса, коди, тощо - все там. 
        /// Якщо у анкеті доведеться розкривати структуру власності у т.ч. й цього банку, то необхідно вказати бодай податковий код банку (чи його еквівалент)
        /// </summary>
        [Description("Відомості про юрособу-банк")]
        [DisplayName("Відомості про юрособу-банк")]
        public GenericPersonID LegalPerson { get { return _LegalPerson; } set { _LegalPerson = value; OnPropertyChanged("LegalPerson"); } }

        private string _SWIFTBIC;
        /// <summary>
        /// SWIFT код (для банків нерезидентів), 
        /// як однозначний універсальний ідентифікатор банку
        /// Бажаний, якщо є; якщо немає - вимагати вказання національного клірингового ідентифікатору (поле MFO)
        /// http://www.swift.com/bsl/
        /// </summary>
        [DisplayName("SWIFT адреса")]
        [Description("Див. http://www.swift.com/bsl/")]
        public string SWIFTBIC { get { return _SWIFTBIC; } set { _SWIFTBIC = value; OnPropertyChanged("SWIFTBIC"); } }


        private CountryInfo _OperationCountry;
        /// <summary>
        /// Країна резидентності банку
        /// Значення за змовчанням - Україна (UA, UKR, 804, Ukraine)
        /// </summary>
        [DisplayName("Країна діяльності")]
        [Required]
        public CountryInfo OperationCountry { get { return _OperationCountry; } set { _OperationCountry = value; OnPropertyChanged("OperationCountry"); OnPropertyChanged("IsNonResident"); OnPropertyChanged("IsResident"); } }


        [Browsable(false)]
        [XmlIgnore]
        public bool IsNonResident { get { return OperationCountry != null && OperationCountry != CountryInfo.UKRAINE; } }

        [Browsable(false)]
        [XmlIgnore]
        public bool IsResident { get { return OperationCountry != null && OperationCountry == CountryInfo.UKRAINE; } }

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

        public override bool Equals(object obj)
        {
            if (obj == null && this == null)
                return true;
            if (obj == null || this == null)
                return false;
            if (!(obj is BankInfo))
                return false;
            BankInfo bi = (BankInfo)obj;
            if(bi.OperationCountry != this.OperationCountry)
                return false;
            if (bi.OperationCountry == CountryInfo.UKRAINE)
            {
                bool?[] pairsCmps = new bool?[] { CompareNonEmptyStringsPair(this.MFO, bi.MFO), CompareNonEmptyStringsPair(this.RegistryNr, bi.RegistryNr), CompareNonEmptyStringsPair(this.Code, bi.Code) };
                foreach (bool? pairCmp in pairsCmps)
                {
                    if (pairCmp == null)
                        continue;
                    return (bool)pairCmp;
                }
            }
            else
            {
                bool?[] pairsCmps = new bool?[] { CompareNonEmptyStringsPair(this.MFO, bi.MFO), CompareNonEmptyStringsPair(this.RegistryNr, bi.RegistryNr), CompareNonEmptyStringsPair(this.Code, bi.Code), CompareNonEmptyStringsPair(this.SWIFTBIC, bi.SWIFTBIC), CompareNonEmptyStringsPair(this.Name, bi.Name) };
                foreach (bool? pairCmp in pairsCmps)
                {
                    if (pairCmp == null)
                        continue;
                    return (bool)pairCmp;
                }
            }
            return false;
            
        }

        private static bool? CompareNonEmptyStringsPair(string x, string y)
        {
            if (string.IsNullOrEmpty(x) && string.IsNullOrEmpty(y))
                return null;
            if (string.IsNullOrEmpty(x) || string.IsNullOrEmpty(y))
                return false;
            return x == y;
        }

        public static BankInfo ParseFromRcuKruRow(DataRow dr)
        {
            GenericPersonInfo gpi;
            return ParseFromRcuKruRow(dr, out gpi);
        }

        public static BankInfo ParseFromRcuKruRow(DataRow dr, out GenericPersonInfo gpi)
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
            gpi = new GenericPersonInfo() { PersonType = EntityType.Legal, LegalPerson = new LegalPersonInfo() { TaxCodeOrHandelsRegNr = yedrpou, Name = dr["FULLNAME"] as string, Address = LocationInfo.Parse(address), ResidenceCountry = CountryInfo.UKRAINE } };
            bi.LegalPerson = gpi.ID;
            //bi.LegalPerson.Address.City = city;
            //bi.LegalPerson.Address.ZipCode = zipCode;
            return bi;
        }
    }
}
