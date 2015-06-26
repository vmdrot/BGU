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


        /// <summary>
        /// 
        /// </summary>
        /// <seealso cref="http://www.iso.org/iso/en-US/home/standards/currency_codes.htm"/>
        public static List<CurrencyInfo> AllCurrencies
        {
            get
            {
                return new List<CurrencyInfo>(); //todo
            }
        }
    }
}
