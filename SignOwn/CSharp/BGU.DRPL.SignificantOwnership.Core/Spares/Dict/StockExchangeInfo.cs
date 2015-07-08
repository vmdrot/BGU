using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Dict
{
    /// <summary>
    /// Інформація про фондову біржу
    /// Список з капіталізацією - http://www.world-exchanges.org/statistics/monthly-reports
    /// </summary>
    /// <see cref="https://en.wikipedia.org/wiki/List_of_stock_exchanges"/>
    public class StockExchangeInfo
    {
        public StockExchangeInfo()
        {
            MarketCapAsOf = DateTime.Now; //todo - year begin
        }

        [DisplayName("Країна діяльності")]
        [Description("Країна, де офіційно зареєстрована біржа")]
        [Required]
        public CountryInfo OperationCountry { get; set; }
        
        [DisplayName("Назва біржі")]
        [Description("Назва біржі (мовою оригіналу)")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Назва біржі (укр.)")]
        [Description("Назва біржі українською мовою")]
        [Required]
        public string NameUkr { get; set; }

        [DisplayName("Член світової федерації бірж")]
        [Description("Чи є біржа членом світової федерації бірж - World Federation of Exchanges")]
        public bool IsWorldExchangesMember { get; set; }

        [DisplayName("Назва у переліку WFE")]
        [Description("Назва біржі, як вона фігурує у переліку Світової Федерації Бірж - World Federation of Exchanges")]
        [UIConditionalVisibility("IsWorldExchangesMember")]
        public string WorldExchangesID { get; set; }

        [DisplayName("Капіталізація")]
        [Description("Сукупна ринкова капіталізація компаній, акції яких уключено до торгів на біржі")]
        public CurrencyAmount MarketCap { get; set; }

        [DisplayName("Дата капіталізації")]
        [Description("Дата, на яку була чинною вказана сукупна ринкова капіталізація (вище)")]
        public DateTime MarketCapAsOf { get; set; }

    }
}
