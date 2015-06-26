using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Dict
{
    public class CurrencyInfo
    {
        /// <summary>
        /// ENTITY за стандартом ISO
        /// </summary>
        public string CountryNm { get; set; }

        /// <summary>
        /// ENTITY за стандартом ISO
        /// </summary>
        public string CCYName { get; set; }

        /// <summary>
        /// ENTITY за стандартом ISO
        /// </summary>
        public string CCYCode { get; set; }

        /// <summary>
        /// ENTITY за стандартом ISO
        /// </summary>
        public string CCYCode3D { get; set; }

        /// <summary>
        /// ENTITY за стандартом ISO
        /// </summary>
        public int? CCYMinorUnit { get; set; }


        private static List<CurrencyInfo> _allCurrencies;

        /// <summary>
        /// 
        /// </summary>
        /// <seealso cref="http://www.iso.org/iso/en-US/home/standards/currency_codes.htm"/>
        public static List<CurrencyInfo> AllCurrencies
        {
            get
            {
                if (_allCurrencies == null)
                {
                    _allCurrencies = new List<CurrencyInfo>();
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Euro", CCYCode = "EUR", CCYCode3D = "978", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Lek", CCYCode = "ALL", CCYCode3D = "008", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Algerian Dinar", CCYCode = "DZD", CCYCode3D = "012", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "US Dollar", CCYCode = "USD", CCYCode3D = "840", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Euro", CCYCode = "EUR", CCYCode3D = "978", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Kwanza", CCYCode = "AOA", CCYCode3D = "973", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "East Caribbean Dollar", CCYCode = "XCD", CCYCode3D = "951", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Argentine Peso", CCYCode = "ARS", CCYCode3D = "032", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Armenian Dram", CCYCode = "AMD", CCYCode3D = "051", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Aruban Florin", CCYCode = "AWG", CCYCode3D = "533", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Australian Dollar", CCYCode = "AUD", CCYCode3D = "036", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Euro", CCYCode = "EUR", CCYCode3D = "978", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Azerbaijanian Manat", CCYCode = "AZN", CCYCode3D = "944", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Bahamian Dollar", CCYCode = "BSD", CCYCode3D = "044", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Bahraini Dinar", CCYCode = "BHD", CCYCode3D = "048", CCYMinorUnit = (int?)3 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Taka", CCYCode = "BDT", CCYCode3D = "050", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Barbados Dollar", CCYCode = "BBD", CCYCode3D = "052", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Belarussian Ruble", CCYCode = "BYR", CCYCode3D = "974", CCYMinorUnit = (int?)0 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Euro", CCYCode = "EUR", CCYCode3D = "978", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Belize Dollar", CCYCode = "BZD", CCYCode3D = "084", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "CFA Franc BCEAO", CCYCode = "XOF", CCYCode3D = "952", CCYMinorUnit = (int?)0 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Bermudian Dollar", CCYCode = "BMD", CCYCode3D = "060", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Ngultrum", CCYCode = "BTN", CCYCode3D = "064", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Indian Rupee", CCYCode = "INR", CCYCode3D = "356", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Boliviano", CCYCode = "BOB", CCYCode3D = "068", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Mvdol", CCYCode = "BOV", CCYCode3D = "984", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "US Dollar", CCYCode = "USD", CCYCode3D = "840", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Convertible Mark", CCYCode = "BAM", CCYCode3D = "977", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Pula", CCYCode = "BWP", CCYCode3D = "072", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Norwegian Krone", CCYCode = "NOK", CCYCode3D = "578", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Brazilian Real", CCYCode = "BRL", CCYCode3D = "986", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "US Dollar", CCYCode = "USD", CCYCode3D = "840", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Brunei Dollar", CCYCode = "BND", CCYCode3D = "096", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Bulgarian Lev", CCYCode = "BGN", CCYCode3D = "975", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "CFA Franc BCEAO", CCYCode = "XOF", CCYCode3D = "952", CCYMinorUnit = (int?)0 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Burundi Franc", CCYCode = "BIF", CCYCode3D = "108", CCYMinorUnit = (int?)0 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Cabo Verde Escudo", CCYCode = "CVE", CCYCode3D = "132", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Riel", CCYCode = "KHR", CCYCode3D = "116", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "CFA Franc BEAC", CCYCode = "XAF", CCYCode3D = "950", CCYMinorUnit = (int?)0 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Canadian Dollar", CCYCode = "CAD", CCYCode3D = "124", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Cayman Islands Dollar", CCYCode = "KYD", CCYCode3D = "136", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "CFA Franc BEAC", CCYCode = "XAF", CCYCode3D = "950", CCYMinorUnit = (int?)0 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "CFA Franc BEAC", CCYCode = "XAF", CCYCode3D = "950", CCYMinorUnit = (int?)0 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Unidad de Fomento", CCYCode = "CLF", CCYCode3D = "990", CCYMinorUnit = (int?)4 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Chilean Peso", CCYCode = "CLP", CCYCode3D = "152", CCYMinorUnit = (int?)0 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Yuan Renminbi", CCYCode = "CNY", CCYCode3D = "156", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Australian Dollar", CCYCode = "AUD", CCYCode3D = "036", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Australian Dollar", CCYCode = "AUD", CCYCode3D = "036", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Colombian Peso", CCYCode = "COP", CCYCode3D = "170", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Unidad de Valor Real", CCYCode = "COU", CCYCode3D = "970", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Comoro Franc", CCYCode = "KMF", CCYCode3D = "174", CCYMinorUnit = (int?)0 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Congolese Franc", CCYCode = "CDF", CCYCode3D = "976", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "CFA Franc BEAC", CCYCode = "XAF", CCYCode3D = "950", CCYMinorUnit = (int?)0 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "New Zealand Dollar", CCYCode = "NZD", CCYCode3D = "554", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Costa Rican Colon", CCYCode = "CRC", CCYCode3D = "188", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "CFA Franc BCEAO", CCYCode = "XOF", CCYCode3D = "952", CCYMinorUnit = (int?)0 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Kuna", CCYCode = "HRK", CCYCode3D = "191", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Peso Convertible", CCYCode = "CUC", CCYCode3D = "931", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Cuban Peso", CCYCode = "CUP", CCYCode3D = "192", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Netherlands Antillean Guilder", CCYCode = "ANG", CCYCode3D = "532", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Euro", CCYCode = "EUR", CCYCode3D = "978", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Czech Koruna", CCYCode = "CZK", CCYCode3D = "203", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Danish Krone", CCYCode = "DKK", CCYCode3D = "208", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Djibouti Franc", CCYCode = "DJF", CCYCode3D = "262", CCYMinorUnit = (int?)0 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "East Caribbean Dollar", CCYCode = "XCD", CCYCode3D = "951", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Dominican Peso", CCYCode = "DOP", CCYCode3D = "214", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "US Dollar", CCYCode = "USD", CCYCode3D = "840", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Egyptian Pound", CCYCode = "EGP", CCYCode3D = "818", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "El Salvador Colon", CCYCode = "SVC", CCYCode3D = "222", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "US Dollar", CCYCode = "USD", CCYCode3D = "840", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "CFA Franc BEAC", CCYCode = "XAF", CCYCode3D = "950", CCYMinorUnit = (int?)0 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Nakfa", CCYCode = "ERN", CCYCode3D = "232", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Euro", CCYCode = "EUR", CCYCode3D = "978", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Ethiopian Birr", CCYCode = "ETB", CCYCode3D = "230", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Euro", CCYCode = "EUR", CCYCode3D = "978", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Falkland Islands Pound", CCYCode = "FKP", CCYCode3D = "238", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Danish Krone", CCYCode = "DKK", CCYCode3D = "208", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Fiji Dollar", CCYCode = "FJD", CCYCode3D = "242", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Euro", CCYCode = "EUR", CCYCode3D = "978", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Euro", CCYCode = "EUR", CCYCode3D = "978", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Euro", CCYCode = "EUR", CCYCode3D = "978", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "CFP Franc", CCYCode = "XPF", CCYCode3D = "953", CCYMinorUnit = (int?)0 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Euro", CCYCode = "EUR", CCYCode3D = "978", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "CFA Franc BEAC", CCYCode = "XAF", CCYCode3D = "950", CCYMinorUnit = (int?)0 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Dalasi", CCYCode = "GMD", CCYCode3D = "270", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Lari", CCYCode = "GEL", CCYCode3D = "981", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Euro", CCYCode = "EUR", CCYCode3D = "978", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Ghana Cedi", CCYCode = "GHS", CCYCode3D = "936", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Gibraltar Pound", CCYCode = "GIP", CCYCode3D = "292", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Euro", CCYCode = "EUR", CCYCode3D = "978", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Danish Krone", CCYCode = "DKK", CCYCode3D = "208", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "East Caribbean Dollar", CCYCode = "XCD", CCYCode3D = "951", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Euro", CCYCode = "EUR", CCYCode3D = "978", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "US Dollar", CCYCode = "USD", CCYCode3D = "840", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Quetzal", CCYCode = "GTQ", CCYCode3D = "320", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Pound Sterling", CCYCode = "GBP", CCYCode3D = "826", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Guinea Franc", CCYCode = "GNF", CCYCode3D = "324", CCYMinorUnit = (int?)0 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "CFA Franc BCEAO", CCYCode = "XOF", CCYCode3D = "952", CCYMinorUnit = (int?)0 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Guyana Dollar", CCYCode = "GYD", CCYCode3D = "328", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Gourde", CCYCode = "HTG", CCYCode3D = "332", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "US Dollar", CCYCode = "USD", CCYCode3D = "840", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Australian Dollar", CCYCode = "AUD", CCYCode3D = "036", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Euro", CCYCode = "EUR", CCYCode3D = "978", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Lempira", CCYCode = "HNL", CCYCode3D = "340", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Hong Kong Dollar", CCYCode = "HKD", CCYCode3D = "344", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Forint", CCYCode = "HUF", CCYCode3D = "348", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Iceland Krona", CCYCode = "ISK", CCYCode3D = "352", CCYMinorUnit = (int?)0 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Indian Rupee", CCYCode = "INR", CCYCode3D = "356", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Rupiah", CCYCode = "IDR", CCYCode3D = "360", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "SDR (Special Drawing Right)", CCYCode = "XDR", CCYCode3D = "960", CCYMinorUnit = (int?)null });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Iranian Rial", CCYCode = "IRR", CCYCode3D = "364", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Iraqi Dinar", CCYCode = "IQD", CCYCode3D = "368", CCYMinorUnit = (int?)3 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Euro", CCYCode = "EUR", CCYCode3D = "978", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Pound Sterling", CCYCode = "GBP", CCYCode3D = "826", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "New Israeli Sheqel", CCYCode = "ILS", CCYCode3D = "376", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Euro", CCYCode = "EUR", CCYCode3D = "978", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Jamaican Dollar", CCYCode = "JMD", CCYCode3D = "388", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Yen", CCYCode = "JPY", CCYCode3D = "392", CCYMinorUnit = (int?)0 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Pound Sterling", CCYCode = "GBP", CCYCode3D = "826", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Jordanian Dinar", CCYCode = "JOD", CCYCode3D = "400", CCYMinorUnit = (int?)3 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Tenge", CCYCode = "KZT", CCYCode3D = "398", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Kenyan Shilling", CCYCode = "KES", CCYCode3D = "404", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Australian Dollar", CCYCode = "AUD", CCYCode3D = "036", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "North Korean Won", CCYCode = "KPW", CCYCode3D = "408", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Won", CCYCode = "KRW", CCYCode3D = "410", CCYMinorUnit = (int?)0 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Kuwaiti Dinar", CCYCode = "KWD", CCYCode3D = "414", CCYMinorUnit = (int?)3 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Som", CCYCode = "KGS", CCYCode3D = "417", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Kip", CCYCode = "LAK", CCYCode3D = "418", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Euro", CCYCode = "EUR", CCYCode3D = "978", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Lebanese Pound", CCYCode = "LBP", CCYCode3D = "422", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Loti", CCYCode = "LSL", CCYCode3D = "426", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Rand", CCYCode = "ZAR", CCYCode3D = "710", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Liberian Dollar", CCYCode = "LRD", CCYCode3D = "430", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Libyan Dinar", CCYCode = "LYD", CCYCode3D = "434", CCYMinorUnit = (int?)3 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Swiss Franc", CCYCode = "CHF", CCYCode3D = "756", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Euro", CCYCode = "EUR", CCYCode3D = "978", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Euro", CCYCode = "EUR", CCYCode3D = "978", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Pataca", CCYCode = "MOP", CCYCode3D = "446", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Denar", CCYCode = "MKD", CCYCode3D = "807", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Malagasy Ariary", CCYCode = "MGA", CCYCode3D = "969", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Kwacha", CCYCode = "MWK", CCYCode3D = "454", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Malaysian Ringgit", CCYCode = "MYR", CCYCode3D = "458", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Rufiyaa", CCYCode = "MVR", CCYCode3D = "462", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "CFA Franc BCEAO", CCYCode = "XOF", CCYCode3D = "952", CCYMinorUnit = (int?)0 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Euro", CCYCode = "EUR", CCYCode3D = "978", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "US Dollar", CCYCode = "USD", CCYCode3D = "840", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Euro", CCYCode = "EUR", CCYCode3D = "978", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Ouguiya", CCYCode = "MRO", CCYCode3D = "478", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Mauritius Rupee", CCYCode = "MUR", CCYCode3D = "480", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Euro", CCYCode = "EUR", CCYCode3D = "978", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "ADB Unit of Account", CCYCode = "XUA", CCYCode3D = "965", CCYMinorUnit = (int?)null });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Mexican Peso", CCYCode = "MXN", CCYCode3D = "484", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Mexican Unidad de Inversion (UDI)", CCYCode = "MXV", CCYCode3D = "979", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "US Dollar", CCYCode = "USD", CCYCode3D = "840", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Moldovan Leu", CCYCode = "MDL", CCYCode3D = "498", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Euro", CCYCode = "EUR", CCYCode3D = "978", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Tugrik", CCYCode = "MNT", CCYCode3D = "496", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Euro", CCYCode = "EUR", CCYCode3D = "978", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "East Caribbean Dollar", CCYCode = "XCD", CCYCode3D = "951", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Moroccan Dirham", CCYCode = "MAD", CCYCode3D = "504", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Mozambique Metical", CCYCode = "MZN", CCYCode3D = "943", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Kyat", CCYCode = "MMK", CCYCode3D = "104", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Namibia Dollar", CCYCode = "NAD", CCYCode3D = "516", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Rand", CCYCode = "ZAR", CCYCode3D = "710", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Australian Dollar", CCYCode = "AUD", CCYCode3D = "036", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Nepalese Rupee", CCYCode = "NPR", CCYCode3D = "524", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Euro", CCYCode = "EUR", CCYCode3D = "978", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "CFP Franc", CCYCode = "XPF", CCYCode3D = "953", CCYMinorUnit = (int?)0 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "New Zealand Dollar", CCYCode = "NZD", CCYCode3D = "554", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Cordoba Oro", CCYCode = "NIO", CCYCode3D = "558", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "CFA Franc BCEAO", CCYCode = "XOF", CCYCode3D = "952", CCYMinorUnit = (int?)0 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Naira", CCYCode = "NGN", CCYCode3D = "566", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "New Zealand Dollar", CCYCode = "NZD", CCYCode3D = "554", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Australian Dollar", CCYCode = "AUD", CCYCode3D = "036", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "US Dollar", CCYCode = "USD", CCYCode3D = "840", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Norwegian Krone", CCYCode = "NOK", CCYCode3D = "578", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Rial Omani", CCYCode = "OMR", CCYCode3D = "512", CCYMinorUnit = (int?)3 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Pakistan Rupee", CCYCode = "PKR", CCYCode3D = "586", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "US Dollar", CCYCode = "USD", CCYCode3D = "840", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Balboa", CCYCode = "PAB", CCYCode3D = "590", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "US Dollar", CCYCode = "USD", CCYCode3D = "840", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Kina", CCYCode = "PGK", CCYCode3D = "598", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Guarani", CCYCode = "PYG", CCYCode3D = "600", CCYMinorUnit = (int?)0 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Nuevo Sol", CCYCode = "PEN", CCYCode3D = "604", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Philippine Peso", CCYCode = "PHP", CCYCode3D = "608", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "New Zealand Dollar", CCYCode = "NZD", CCYCode3D = "554", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Zloty", CCYCode = "PLN", CCYCode3D = "985", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Euro", CCYCode = "EUR", CCYCode3D = "978", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "US Dollar", CCYCode = "USD", CCYCode3D = "840", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Qatari Rial", CCYCode = "QAR", CCYCode3D = "634", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Euro", CCYCode = "EUR", CCYCode3D = "978", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Romanian Leu", CCYCode = "RON", CCYCode3D = "946", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Russian Ruble", CCYCode = "RUB", CCYCode3D = "643", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Rwanda Franc", CCYCode = "RWF", CCYCode3D = "646", CCYMinorUnit = (int?)0 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Euro", CCYCode = "EUR", CCYCode3D = "978", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Saint Helena Pound", CCYCode = "SHP", CCYCode3D = "654", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "East Caribbean Dollar", CCYCode = "XCD", CCYCode3D = "951", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "East Caribbean Dollar", CCYCode = "XCD", CCYCode3D = "951", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Euro", CCYCode = "EUR", CCYCode3D = "978", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Euro", CCYCode = "EUR", CCYCode3D = "978", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "East Caribbean Dollar", CCYCode = "XCD", CCYCode3D = "951", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Tala", CCYCode = "WST", CCYCode3D = "882", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Euro", CCYCode = "EUR", CCYCode3D = "978", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Dobra", CCYCode = "STD", CCYCode3D = "678", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Saudi Riyal", CCYCode = "SAR", CCYCode3D = "682", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "CFA Franc BCEAO", CCYCode = "XOF", CCYCode3D = "952", CCYMinorUnit = (int?)0 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Serbian Dinar", CCYCode = "RSD", CCYCode3D = "941", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Seychelles Rupee", CCYCode = "SCR", CCYCode3D = "690", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Leone", CCYCode = "SLL", CCYCode3D = "694", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Singapore Dollar", CCYCode = "SGD", CCYCode3D = "702", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Netherlands Antillean Guilder", CCYCode = "ANG", CCYCode3D = "532", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Sucre", CCYCode = "XSU", CCYCode3D = "994", CCYMinorUnit = (int?)null });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Euro", CCYCode = "EUR", CCYCode3D = "978", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Euro", CCYCode = "EUR", CCYCode3D = "978", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Solomon Islands Dollar", CCYCode = "SBD", CCYCode3D = "090", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Somali Shilling", CCYCode = "SOS", CCYCode3D = "706", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Rand", CCYCode = "ZAR", CCYCode3D = "710", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "South Sudanese Pound", CCYCode = "SSP", CCYCode3D = "728", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Euro", CCYCode = "EUR", CCYCode3D = "978", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Sri Lanka Rupee", CCYCode = "LKR", CCYCode3D = "144", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Sudanese Pound", CCYCode = "SDG", CCYCode3D = "938", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Surinam Dollar", CCYCode = "SRD", CCYCode3D = "968", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Norwegian Krone", CCYCode = "NOK", CCYCode3D = "578", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Lilangeni", CCYCode = "SZL", CCYCode3D = "748", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Swedish Krona", CCYCode = "SEK", CCYCode3D = "752", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "WIR Euro", CCYCode = "CHE", CCYCode3D = "947", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Swiss Franc", CCYCode = "CHF", CCYCode3D = "756", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "WIR Franc", CCYCode = "CHW", CCYCode3D = "948", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Syrian Pound", CCYCode = "SYP", CCYCode3D = "760", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "New Taiwan Dollar", CCYCode = "TWD", CCYCode3D = "901", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Somoni", CCYCode = "TJS", CCYCode3D = "972", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Tanzanian Shilling", CCYCode = "TZS", CCYCode3D = "834", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Baht", CCYCode = "THB", CCYCode3D = "764", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "US Dollar", CCYCode = "USD", CCYCode3D = "840", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "CFA Franc BCEAO", CCYCode = "XOF", CCYCode3D = "952", CCYMinorUnit = (int?)0 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "New Zealand Dollar", CCYCode = "NZD", CCYCode3D = "554", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Pa’anga", CCYCode = "TOP", CCYCode3D = "776", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Trinidad and Tobago Dollar", CCYCode = "TTD", CCYCode3D = "780", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Tunisian Dinar", CCYCode = "TND", CCYCode3D = "788", CCYMinorUnit = (int?)3 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Turkish Lira", CCYCode = "TRY", CCYCode3D = "949", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Turkmenistan New Manat", CCYCode = "TMT", CCYCode3D = "934", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "US Dollar", CCYCode = "USD", CCYCode3D = "840", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Australian Dollar", CCYCode = "AUD", CCYCode3D = "036", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Uganda Shilling", CCYCode = "UGX", CCYCode3D = "800", CCYMinorUnit = (int?)0 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Hryvnia", CCYCode = "UAH", CCYCode3D = "980", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "UAE Dirham", CCYCode = "AED", CCYCode3D = "784", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Pound Sterling", CCYCode = "GBP", CCYCode3D = "826", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "US Dollar", CCYCode = "USD", CCYCode3D = "840", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "US Dollar", CCYCode = "USD", CCYCode3D = "840", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "US Dollar (Next day)", CCYCode = "USN", CCYCode3D = "997", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Uruguay Peso en Unidades Indexadas (URUIURUI)", CCYCode = "UYI", CCYCode3D = "940", CCYMinorUnit = (int?)0 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Peso Uruguayo", CCYCode = "UYU", CCYCode3D = "858", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Uzbekistan Sum", CCYCode = "UZS", CCYCode3D = "860", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Vatu", CCYCode = "VUV", CCYCode3D = "548", CCYMinorUnit = (int?)0 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Bolivar", CCYCode = "VEF", CCYCode3D = "937", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Dong", CCYCode = "VND", CCYCode3D = "704", CCYMinorUnit = (int?)0 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "US Dollar", CCYCode = "USD", CCYCode3D = "840", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "US Dollar", CCYCode = "USD", CCYCode3D = "840", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "CFP Franc", CCYCode = "XPF", CCYCode3D = "953", CCYMinorUnit = (int?)0 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Moroccan Dirham", CCYCode = "MAD", CCYCode3D = "504", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Yemeni Rial", CCYCode = "YER", CCYCode3D = "886", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Zambian Kwacha", CCYCode = "ZMW", CCYCode3D = "967", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Zimbabwe Dollar", CCYCode = "ZWL", CCYCode3D = "932", CCYMinorUnit = (int?)2 });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Bond Markets Unit European Composite Unit (EURCO)", CCYCode = "XBA", CCYCode3D = "955", CCYMinorUnit = (int?)null });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Bond Markets Unit European Monetary Unit (E.M.U.-6)", CCYCode = "XBB", CCYCode3D = "956", CCYMinorUnit = (int?)null });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Bond Markets Unit European Unit of Account 9 (E.U.A.-9)", CCYCode = "XBC", CCYCode3D = "957", CCYMinorUnit = (int?)null });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Bond Markets Unit European Unit of Account 17 (E.U.A.-17)", CCYCode = "XBD", CCYCode3D = "958", CCYMinorUnit = (int?)null });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Codes specifically reserved for testing purposes", CCYCode = "XTS", CCYCode3D = "963", CCYMinorUnit = (int?)null });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "The codes assigned for transactions where no currency is involved", CCYCode = "XXX", CCYCode3D = "999", CCYMinorUnit = (int?)null });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Gold", CCYCode = "XAU", CCYCode3D = "959", CCYMinorUnit = (int?)null });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Palladium", CCYCode = "XPD", CCYCode3D = "964", CCYMinorUnit = (int?)null });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Platinum", CCYCode = "XPT", CCYCode3D = "962", CCYMinorUnit = (int?)null });
                    _allCurrencies.Add(new CurrencyInfo() { CCYName = "Silver", CCYCode = "XAG", CCYCode3D = "961", CCYMinorUnit = (int?)null });
                }
                return _allCurrencies;
            }
        }
    }
}
