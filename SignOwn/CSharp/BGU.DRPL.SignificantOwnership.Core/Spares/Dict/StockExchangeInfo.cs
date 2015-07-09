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
    [UIUsageComboAddButton(AddNewItemCommand = "local:MyCommands.AddStockExchangeCommand", DisplayMember = "Name", ItemsGetterClass = typeof(StockExchangeInfo), ItemsGetterMemberPath = "AllWFExchanges", ValueMemberUsageMode = ComboUIValueUsageMode.SelectedItem, Width = "250", ContainerOrientation = Orientation.Vertical)]
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


        #region static member(s)
        private static List<StockExchangeInfo> _allWFExchanges;
        public static List<StockExchangeInfo> AllWFExchanges
        {
            get
            {
                if (_allWFExchanges == null)
                {
                    _allWFExchanges = new List<StockExchangeInfo>();
                    #region populate the list
                    DateTime mktCapDt = new DateTime(2015, 1, 1);
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Barbados SE", NameUkr = "Barbados SE", WorldExchangesID = "Barbados SE" });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Bermuda SE", NameUkr = "Bermuda SE", WorldExchangesID = "Bermuda SE", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 1609680000 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "BM&FBOVESPA", NameUkr = "BM&FBOVESPA", WorldExchangesID = "BM&FBOVESPA", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 823902665171 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Bolsa de Valores de Colombia", NameUkr = "Bolsa de Valores de Colombia", WorldExchangesID = "Bolsa de Valores de Colombia", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 139530087297 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Buenos Aires SE", NameUkr = "Buenos Aires SE", WorldExchangesID = "Buenos Aires SE", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 59804249499 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Lima SE", NameUkr = "Lima SE", WorldExchangesID = "Lima SE", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 76748179489 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Mexican Exchange", NameUkr = "Mexican Exchange", WorldExchangesID = "Mexican Exchange", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 460128249402 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "NASDAQ OMX", NameUkr = "NASDAQ OMX", WorldExchangesID = "NASDAQ OMX", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 6830967960000 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "NYSE", NameUkr = "NYSE", WorldExchangesID = "NYSE", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 19222875550000 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Santiago SE", NameUkr = "Santiago SE", WorldExchangesID = "Santiago SE", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 225219821596 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "TMX Group", NameUkr = "TMX Group", WorldExchangesID = "TMX Group", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 1938630258126 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Asia - Pacific", NameUkr = "Asia - Pacific", WorldExchangesID = "Asia - Pacific", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 0 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Australian SE", NameUkr = "Australian SE", WorldExchangesID = "Australian SE", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 1271697298356 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "BSE India", NameUkr = "BSE India", WorldExchangesID = "BSE India", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 1681712426226 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Bursa Malaysia", NameUkr = "Bursa Malaysia", WorldExchangesID = "Bursa Malaysia", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 451654557224 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Chittagong SE", NameUkr = "Chittagong SE", WorldExchangesID = "Chittagong SE" });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Colombo SE", NameUkr = "Colombo SE", WorldExchangesID = "Colombo SE", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 23472422653 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Dhaka SE", NameUkr = "Dhaka SE", WorldExchangesID = "Dhaka SE" });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Hanoi Stock Exchange ", NameUkr = "Hanoi Stock Exchange ", WorldExchangesID = "Hanoi Stock Exchange ", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 6630614989 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "HoChiMinh SE", NameUkr = "HoChiMinh SE", WorldExchangesID = "HoChiMinh SE", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 50078021980 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Hong Kong Exchanges", NameUkr = "Hong Kong Exchanges", WorldExchangesID = "Hong Kong Exchanges", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 3324641426729 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Indonesia SE", NameUkr = "Indonesia SE", WorldExchangesID = "Indonesia SE", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 420872492315 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Japan Exchange Group - Osaka", NameUkr = "Japan Exchange Group - Osaka", WorldExchangesID = "Japan Exchange Group - Osaka" });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Japan Exchange Group - Tokyo", NameUkr = "Japan Exchange Group - Tokyo", WorldExchangesID = "Japan Exchange Group - Tokyo", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 4485449805784 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Korea Exchange", NameUkr = "Korea Exchange", WorldExchangesID = "Korea Exchange", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 1251053916305 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "National Stock Exchange India", NameUkr = "National Stock Exchange India", WorldExchangesID = "National Stock Exchange India", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 1641716534492 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "New Zealand Exchange", NameUkr = "New Zealand Exchange", WorldExchangesID = "New Zealand Exchange", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 71875748284 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Philippine SE", NameUkr = "Philippine SE", WorldExchangesID = "Philippine SE", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 279502286084 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Port Moresby SE", NameUkr = "Port Moresby SE", WorldExchangesID = "Port Moresby SE" });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Shanghai SE", NameUkr = "Shanghai SE", WorldExchangesID = "Shanghai SE", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 3986011930561 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Shenzhen SE", NameUkr = "Shenzhen SE", WorldExchangesID = "Shenzhen SE", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 2284728076598 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Singapore Exchange", NameUkr = "Singapore Exchange", WorldExchangesID = "Singapore Exchange", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 755414787431 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Taipei Exchange", NameUkr = "Taipei Exchange", WorldExchangesID = "Taipei Exchange", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 84570053389 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Taiwan SE Corp.", NameUkr = "Taiwan SE Corp.", WorldExchangesID = "Taiwan SE Corp.", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 860627528840 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "The Stock Exchange of Thailand ", NameUkr = "The Stock Exchange of Thailand ", WorldExchangesID = "The Stock Exchange of Thailand ", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 460900482217 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Europe - Africa - Middle East", NameUkr = "Europe - Africa - Middle East", WorldExchangesID = "Europe - Africa - Middle East", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 0 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Abu Dhabi SE", NameUkr = "Abu Dhabi SE", WorldExchangesID = "Abu Dhabi SE", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 111447436491 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Amman SE ", NameUkr = "Amman SE ", WorldExchangesID = "Amman SE ", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 25237415062 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Athens Exchange", NameUkr = "Athens Exchange", WorldExchangesID = "Athens Exchange", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 41299638459 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Bahrain Bourse", NameUkr = "Bahrain Bourse", WorldExchangesID = "Bahrain Bourse", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 22216591091 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Beirut SE", NameUkr = "Beirut SE", WorldExchangesID = "Beirut SE" });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Belarusian Currency & Stock Exchange", NameUkr = "Belarusian Currency & Stock Exchange", WorldExchangesID = "Belarusian Currency & Stock Exchange" });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "BME Spanish Exchanges", NameUkr = "BME Spanish Exchanges", WorldExchangesID = "BME Spanish Exchanges", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 942036199300 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Borsa Istanbul", NameUkr = "Borsa Istanbul", WorldExchangesID = "Borsa Istanbul", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 222149677151 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Budapest SE", NameUkr = "Budapest SE", WorldExchangesID = "Budapest SE", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 13586360684 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Casablanca SE", NameUkr = "Casablanca SE", WorldExchangesID = "Casablanca SE", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 53656518510 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Cyprus SE", NameUkr = "Cyprus SE", WorldExchangesID = "Cyprus SE", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 3305321433 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Deutsche Börse", NameUkr = "Deutsche Börse", WorldExchangesID = "Deutsche Börse", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 1761712789515 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Dubai Financial Market", NameUkr = "Dubai Financial Market", WorldExchangesID = "Dubai Financial Market", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 89418819942 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Egyptian Exchange", NameUkr = "Egyptian Exchange", WorldExchangesID = "Egyptian Exchange", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 70264838061 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Euronext", NameUkr = "Euronext", WorldExchangesID = "Euronext", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 3320991978308 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Irish SE", NameUkr = "Irish SE", WorldExchangesID = "Irish SE", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 136727996837 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Johannesburg SE", NameUkr = "Johannesburg SE", WorldExchangesID = "Johannesburg SE", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 950662649999 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Kazakhstan SE", NameUkr = "Kazakhstan SE", WorldExchangesID = "Kazakhstan SE", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 21323597172 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Ljubljana SE", NameUkr = "Ljubljana SE", WorldExchangesID = "Ljubljana SE", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 6968704101 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Luxembourg SE", NameUkr = "Luxembourg SE", WorldExchangesID = "Luxembourg SE", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 60876262569 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Malta SE", NameUkr = "Malta SE", WorldExchangesID = "Malta SE" });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Mauritius SE", NameUkr = "Mauritius SE", WorldExchangesID = "Mauritius SE", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 8612262004 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Moscow Exchange", NameUkr = "Moscow Exchange", WorldExchangesID = "Moscow Exchange", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 391850293209 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Muscat Securities Market", NameUkr = "Muscat Securities Market", WorldExchangesID = "Muscat Securities Market", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 38679827991 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "NASDAQ OMX Nordic Exchange ", NameUkr = "NASDAQ OMX Nordic Exchange ", WorldExchangesID = "NASDAQ OMX Nordic Exchange ", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 1212039905095 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Nigerian Stock Exchange", NameUkr = "Nigerian Stock Exchange", WorldExchangesID = "Nigerian Stock Exchange", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 51745838995 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Oslo Børs", NameUkr = "Oslo Børs", WorldExchangesID = "Oslo Børs", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 219664259937 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Palestine Exchange", NameUkr = "Palestine Exchange", WorldExchangesID = "Palestine Exchange", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 3128820000 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Qatar Stock Exchange", NameUkr = "Qatar Stock Exchange", WorldExchangesID = "Qatar Stock Exchange", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 173273874957 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Saudi Stock Exchange - Tadawul", NameUkr = "Saudi Stock Exchange - Tadawul", WorldExchangesID = "Saudi Stock Exchange - Tadawul", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 510694599558 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "SIX Swiss Exchange", NameUkr = "SIX Swiss Exchange", WorldExchangesID = "SIX Swiss Exchange", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 1515760763509 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Tel Aviv SE", NameUkr = "Tel Aviv SE", WorldExchangesID = "Tel Aviv SE", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 196836176867 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Tunis SE", NameUkr = "Tunis SE", WorldExchangesID = "Tunis SE" });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Ukrainian Exchange", NameUkr = "Ukrainian Exchange", WorldExchangesID = "Ukrainian Exchange" });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Wiener Börse", NameUkr = "Wiener Börse", WorldExchangesID = "Wiener Börse", MarketCap = new CurrencyAmount() { CCY = "USD", Amt = 91732391820 }, MarketCapAsOf = mktCapDt });
                    _allWFExchanges.Add(new StockExchangeInfo() { IsWorldExchangesMember = true, Name = "Zagreb SE", NameUkr = "Zagreb SE", WorldExchangesID = "Zagreb SE" });
                    #endregion
                }
                return _allWFExchanges;
            }
        }
        #endregion
    }
}
