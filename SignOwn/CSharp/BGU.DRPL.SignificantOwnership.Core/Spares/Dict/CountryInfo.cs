using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;
using Evolvex.Utility.Core.Common;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Dict
{
    /// <summary>
    /// Країна 
    /// Значення за змовчанням - Україна (UA, UKR, 804, Ukraine)
    /// (в усіх місцях, окрім тих, де з контексту явно випливає, що буде не Україна)
    /// </summary>
    /// <seealso cref="http://userpage.chemie.fu-berlin.de/diverse/doc/ISO_3166.html"/>
    //[System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.CountryInfoLookupEditor), typeof(System.Drawing.Design.UITypeEditor))]
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.CountryInfoLookupEditor2), typeof(System.Drawing.Design.UITypeEditor))]
    [UIUsageComboAttribute(DisplayMember = "CountryNameUkr", ItemsGetterClass = typeof(CountryInfo), ItemsGetterMemberPath = "AllCountries", ValueMemberUsageMode = ComboUIValueUsageMode.SelectedItem, Width = "175", ToolTipMember = "CountryNameEng")]
    public class CountryInfo
    {

        private static readonly ILog log = Logging.GetLogger(typeof(CountryInfo));
        /// <summary>
        /// this and other fields as per http://userpage.chemie.fu-berlin.de/diverse/doc/ISO_3166.html
        /// Див. вищевказаний урл для специфікації (для усіх полів)
        /// </summary>
        public string CountryISO2Code { get; set; }
        public string CountryISO3Code { get; set; }
        [Required]
        public string CountryISONr { get; set; }
        /// <summary>
        /// Назва країни англ. мовою
        /// </summary>
        public string CountryNameEng { get; set; }
        /// <summary>
        /// Назва країни українською мовою
        /// </summary>
        [Required]
        public string CountryNameUkr { get; set; }


        public static bool operator ==(CountryInfo x, CountryInfo y)
        {
            if (((object)x) == null && ((object)y) == null)
                return true;
            if (((object)x) == null || ((object)y) == null)
                return false;
            return x.CountryISONr == y.CountryISONr;
        }

        public static bool operator !=(CountryInfo x, CountryInfo y)
        {
            if (((object)x) == null && ((object)y) == null)
                return false;
            if (((object)x) == null || ((object)y) == null)
                return true;
            return x.CountryISONr != y.CountryISONr;
        }

        #region specific countries
        public static readonly CountryInfo AALAND_ISLANDS = new CountryInfo() { CountryISO2Code = "AX", CountryISO3Code = "ALA", CountryISONr = "248", CountryNameEng = "AALAND_ISLANDS", CountryNameUkr = "Оландські острови" };
        public static readonly CountryInfo AFGHANISTAN = new CountryInfo() { CountryISO2Code = "AF", CountryISO3Code = "AFG", CountryISONr = "004", CountryNameEng = "AFGHANISTAN", CountryNameUkr = "Афганістан" };
        public static readonly CountryInfo ALBANIA = new CountryInfo() { CountryISO2Code = "AL", CountryISO3Code = "ALB", CountryISONr = "008", CountryNameEng = "ALBANIA", CountryNameUkr = "Албанія" };
        public static readonly CountryInfo ALGERIA = new CountryInfo() { CountryISO2Code = "DZ", CountryISO3Code = "DZA", CountryISONr = "012", CountryNameEng = "ALGERIA", CountryNameUkr = "Алжір" };
        public static readonly CountryInfo AMERICAN_SAMOA = new CountryInfo() { CountryISO2Code = "AS", CountryISO3Code = "ASM", CountryISONr = "016", CountryNameEng = "AMERICAN_SAMOA", CountryNameUkr = "Американське Самоа" };
        public static readonly CountryInfo ANDORRA = new CountryInfo() { CountryISO2Code = "AD", CountryISO3Code = "AND", CountryISONr = "020", CountryNameEng = "ANDORRA", CountryNameUkr = "Андорра" };
        public static readonly CountryInfo ANGOLA = new CountryInfo() { CountryISO2Code = "AO", CountryISO3Code = "AGO", CountryISONr = "024", CountryNameEng = "ANGOLA", CountryNameUkr = "Анґола" };
        public static readonly CountryInfo ANGUILLA = new CountryInfo() { CountryISO2Code = "AI", CountryISO3Code = "AIA", CountryISONr = "660", CountryNameEng = "ANGUILLA", CountryNameUkr = "Анґілья" };
        public static readonly CountryInfo ANTARCTICA = new CountryInfo() { CountryISO2Code = "AQ", CountryISO3Code = "ATA", CountryISONr = "010", CountryNameEng = "ANTARCTICA", CountryNameUkr = "Антарктика" };
        public static readonly CountryInfo ANTIGUA_AND_BARBUDA = new CountryInfo() { CountryISO2Code = "AG", CountryISO3Code = "ATG", CountryISONr = "028", CountryNameEng = "ANTIGUA_AND_BARBUDA", CountryNameUkr = "Антіґуа і Барбуда" };
        public static readonly CountryInfo ARGENTINA = new CountryInfo() { CountryISO2Code = "AR", CountryISO3Code = "ARG", CountryISONr = "032", CountryNameEng = "ARGENTINA", CountryNameUkr = "Арґентина" };
        public static readonly CountryInfo ARMENIA = new CountryInfo() { CountryISO2Code = "AM", CountryISO3Code = "ARM", CountryISONr = "051", CountryNameEng = "ARMENIA", CountryNameUkr = "Вірменія" };
        public static readonly CountryInfo ARUBA = new CountryInfo() { CountryISO2Code = "AW", CountryISO3Code = "ABW", CountryISONr = "533", CountryNameEng = "ARUBA", CountryNameUkr = "Аруба" };
        public static readonly CountryInfo AUSTRALIA = new CountryInfo() { CountryISO2Code = "AU", CountryISO3Code = "AUS", CountryISONr = "036", CountryNameEng = "AUSTRALIA", CountryNameUkr = "Австралія" };
        public static readonly CountryInfo AUSTRIA = new CountryInfo() { CountryISO2Code = "AT", CountryISO3Code = "AUT", CountryISONr = "040", CountryNameEng = "AUSTRIA", CountryNameUkr = "Австрія" };
        public static readonly CountryInfo AZERBAIJAN = new CountryInfo() { CountryISO2Code = "AZ", CountryISO3Code = "AZE", CountryISONr = "031", CountryNameEng = "AZERBAIJAN", CountryNameUkr = "Азербайджан" };
        public static readonly CountryInfo BAHAMAS = new CountryInfo() { CountryISO2Code = "BS", CountryISO3Code = "BHS", CountryISONr = "044", CountryNameEng = "BAHAMAS", CountryNameUkr = "Багами" };
        public static readonly CountryInfo BAHRAIN = new CountryInfo() { CountryISO2Code = "BH", CountryISO3Code = "BHR", CountryISONr = "048", CountryNameEng = "BAHRAIN", CountryNameUkr = "Бахрейн" };
        public static readonly CountryInfo BANGLADESH = new CountryInfo() { CountryISO2Code = "BD", CountryISO3Code = "BGD", CountryISONr = "050", CountryNameEng = "BANGLADESH", CountryNameUkr = "Банґладеш" };
        public static readonly CountryInfo BARBADOS = new CountryInfo() { CountryISO2Code = "BB", CountryISO3Code = "BRB", CountryISONr = "052", CountryNameEng = "BARBADOS", CountryNameUkr = "Барбадос" };
        public static readonly CountryInfo BELARUS = new CountryInfo() { CountryISO2Code = "BY", CountryISO3Code = "BLR", CountryISONr = "112", CountryNameEng = "BELARUS", CountryNameUkr = "Білорусь" };
        public static readonly CountryInfo BELGIUM = new CountryInfo() { CountryISO2Code = "BE", CountryISO3Code = "BEL", CountryISONr = "056", CountryNameEng = "BELGIUM", CountryNameUkr = "Бельгія" };
        public static readonly CountryInfo BELIZE = new CountryInfo() { CountryISO2Code = "BZ", CountryISO3Code = "BLZ", CountryISONr = "084", CountryNameEng = "BELIZE", CountryNameUkr = "Беліз" };
        public static readonly CountryInfo BENIN = new CountryInfo() { CountryISO2Code = "BJ", CountryISO3Code = "BEN", CountryISONr = "204", CountryNameEng = "BENIN", CountryNameUkr = "Бенін" };
        public static readonly CountryInfo BERMUDA = new CountryInfo() { CountryISO2Code = "BM", CountryISO3Code = "BMU", CountryISONr = "060", CountryNameEng = "BERMUDA", CountryNameUkr = "Бермудські острови" };
        public static readonly CountryInfo BHUTAN = new CountryInfo() { CountryISO2Code = "BT", CountryISO3Code = "BTN", CountryISONr = "064", CountryNameEng = "BHUTAN", CountryNameUkr = "Бутан" };
        public static readonly CountryInfo BOLIVIA = new CountryInfo() { CountryISO2Code = "BO", CountryISO3Code = "BOL", CountryISONr = "068", CountryNameEng = "BOLIVIA", CountryNameUkr = "Болівія" };
        public static readonly CountryInfo BOSNIA_AND_HERZEGOWINA = new CountryInfo() { CountryISO2Code = "BA", CountryISO3Code = "BIH", CountryISONr = "070", CountryNameEng = "BOSNIA_AND_HERZEGOWINA", CountryNameUkr = "Боснія і Герцеґовіна" };
        public static readonly CountryInfo BOTSWANA = new CountryInfo() { CountryISO2Code = "BW", CountryISO3Code = "BWA", CountryISONr = "072", CountryNameEng = "BOTSWANA", CountryNameUkr = "Ботсвана" };
        public static readonly CountryInfo BOUVET_ISLAND = new CountryInfo() { CountryISO2Code = "BV", CountryISO3Code = "BVT", CountryISONr = "074", CountryNameEng = "BOUVET_ISLAND", CountryNameUkr = "Острів Буве" };
        public static readonly CountryInfo BRAZIL = new CountryInfo() { CountryISO2Code = "BR", CountryISO3Code = "BRA", CountryISONr = "076", CountryNameEng = "BRAZIL", CountryNameUkr = "Бразилія" };
        public static readonly CountryInfo BRITISH_INDIAN_OCEAN_TERRITORY = new CountryInfo() { CountryISO2Code = "IO", CountryISO3Code = "IOT", CountryISONr = "086", CountryNameEng = "BRITISH_INDIAN_OCEAN_TERRITORY", CountryNameUkr = "Британські територій в Індійському Океані" };
        public static readonly CountryInfo BRUNEI_DARUSSALAM = new CountryInfo() { CountryISO2Code = "BN", CountryISO3Code = "BRN", CountryISONr = "096", CountryNameEng = "BRUNEI_DARUSSALAM", CountryNameUkr = "Бруней" };
        public static readonly CountryInfo BULGARIA = new CountryInfo() { CountryISO2Code = "BG", CountryISO3Code = "BGR", CountryISONr = "100", CountryNameEng = "BULGARIA", CountryNameUkr = "Болгарія" };
        public static readonly CountryInfo BURKINA_FASO = new CountryInfo() { CountryISO2Code = "BF", CountryISO3Code = "BFA", CountryISONr = "854", CountryNameEng = "BURKINA_FASO", CountryNameUkr = "Буркіна-Фасо" };
        public static readonly CountryInfo BURUNDI = new CountryInfo() { CountryISO2Code = "BI", CountryISO3Code = "BDI", CountryISONr = "108", CountryNameEng = "BURUNDI", CountryNameUkr = "Бурунді" };
        public static readonly CountryInfo CAMBODIA = new CountryInfo() { CountryISO2Code = "KH", CountryISO3Code = "KHM", CountryISONr = "116", CountryNameEng = "CAMBODIA", CountryNameUkr = "Камбоджа" };
        public static readonly CountryInfo CAMEROON = new CountryInfo() { CountryISO2Code = "CM", CountryISO3Code = "CMR", CountryISONr = "120", CountryNameEng = "CAMEROON", CountryNameUkr = "Камерун" };
        public static readonly CountryInfo CANADA = new CountryInfo() { CountryISO2Code = "CA", CountryISO3Code = "CAN", CountryISONr = "124", CountryNameEng = "CANADA", CountryNameUkr = "Канада" };
        public static readonly CountryInfo CAPE_VERDE = new CountryInfo() { CountryISO2Code = "CV", CountryISO3Code = "CPV", CountryISONr = "132", CountryNameEng = "CAPE_VERDE", CountryNameUkr = "Республіка Кабо-Верде" };
        public static readonly CountryInfo CAYMAN_ISLANDS = new CountryInfo() { CountryISO2Code = "KY", CountryISO3Code = "CYM", CountryISONr = "136", CountryNameEng = "CAYMAN_ISLANDS", CountryNameUkr = "Кайманові острови" };
        public static readonly CountryInfo CENTRAL_AFRICAN_REPUBLIC = new CountryInfo() { CountryISO2Code = "CF", CountryISO3Code = "CAF", CountryISONr = "140", CountryNameEng = "CENTRAL_AFRICAN_REPUBLIC", CountryNameUkr = "Центрально-Африканська Республіка" };
        public static readonly CountryInfo CHAD = new CountryInfo() { CountryISO2Code = "TD", CountryISO3Code = "TCD", CountryISONr = "148", CountryNameEng = "CHAD", CountryNameUkr = "Чад" };
        public static readonly CountryInfo CHILE = new CountryInfo() { CountryISO2Code = "CL", CountryISO3Code = "CHL", CountryISONr = "152", CountryNameEng = "CHILE", CountryNameUkr = "Чилі" };
        public static readonly CountryInfo CHINA = new CountryInfo() { CountryISO2Code = "CN", CountryISO3Code = "CHN", CountryISONr = "156", CountryNameEng = "CHINA", CountryNameUkr = "Китай" };
        public static readonly CountryInfo CHRISTMAS_ISLAND = new CountryInfo() { CountryISO2Code = "CX", CountryISO3Code = "CXR", CountryISONr = "162", CountryNameEng = "CHRISTMAS_ISLAND", CountryNameUkr = "Острів Різдва" };
        public static readonly CountryInfo COCOS_KEELING_ISLANDS = new CountryInfo() { CountryISO2Code = "CC", CountryISO3Code = "CCK", CountryISONr = "166", CountryNameEng = "COCOS_KEELING_ISLANDS", CountryNameUkr = "Кокосові Острови" };
        public static readonly CountryInfo COLOMBIA = new CountryInfo() { CountryISO2Code = "CO", CountryISO3Code = "COL", CountryISONr = "170", CountryNameEng = "COLOMBIA", CountryNameUkr = "Колубмія" };
        public static readonly CountryInfo COMOROS = new CountryInfo() { CountryISO2Code = "KM", CountryISO3Code = "COM", CountryISONr = "174", CountryNameEng = "COMOROS", CountryNameUkr = "Коморські острови" };
        public static readonly CountryInfo CONGO_Democratic_Republic_of_was_Zaire_ = new CountryInfo() { CountryISO2Code = "CD", CountryISO3Code = "COD", CountryISONr = "180", CountryNameEng = "CONGO_Democratic_Republic_of_was_Zaire_", CountryNameUkr = "Демократична Республіка Конґо (Заїр)" };
        public static readonly CountryInfo CONGO_Republic_of = new CountryInfo() { CountryISO2Code = "CG", CountryISO3Code = "COG", CountryISONr = "178", CountryNameEng = "CONGO_Republic_of", CountryNameUkr = "Республіка Конґо" };
        public static readonly CountryInfo COOK_ISLANDS = new CountryInfo() { CountryISO2Code = "CK", CountryISO3Code = "COK", CountryISONr = "184", CountryNameEng = "COOK_ISLANDS", CountryNameUkr = "Острови Кука" };
        public static readonly CountryInfo COSTA_RICA = new CountryInfo() { CountryISO2Code = "CR", CountryISO3Code = "CRI", CountryISONr = "188", CountryNameEng = "COSTA_RICA", CountryNameUkr = "Коста-Ріка" };
        public static readonly CountryInfo COTE_D_IVOIRE = new CountryInfo() { CountryISO2Code = "CI", CountryISO3Code = "CIV", CountryISONr = "384", CountryNameEng = "COTE_D_IVOIRE", CountryNameUkr = "Кот д'Івуар" };
        public static readonly CountryInfo CROATIA = new CountryInfo() { CountryISO2Code = "HR", CountryISO3Code = "HRV", CountryISONr = "191", CountryNameEng = "CROATIA", CountryNameUkr = "Хорватія" };
        public static readonly CountryInfo CUBA = new CountryInfo() { CountryISO2Code = "CU", CountryISO3Code = "CUB", CountryISONr = "192", CountryNameEng = "CUBA", CountryNameUkr = "Куба" };
        public static readonly CountryInfo CYPRUS = new CountryInfo() { CountryISO2Code = "CY", CountryISO3Code = "CYP", CountryISONr = "196", CountryNameEng = "CYPRUS", CountryNameUkr = "Кіпр" };
        public static readonly CountryInfo CZECH_REPUBLIC = new CountryInfo() { CountryISO2Code = "CZ", CountryISO3Code = "CZE", CountryISONr = "203", CountryNameEng = "CZECH_REPUBLIC", CountryNameUkr = "Чехія" };
        public static readonly CountryInfo DENMARK = new CountryInfo() { CountryISO2Code = "DK", CountryISO3Code = "DNK", CountryISONr = "208", CountryNameEng = "DENMARK", CountryNameUkr = "Данія" };
        public static readonly CountryInfo DJIBOUTI = new CountryInfo() { CountryISO2Code = "DJ", CountryISO3Code = "DJI", CountryISONr = "262", CountryNameEng = "DJIBOUTI", CountryNameUkr = "Джибуті" };
        public static readonly CountryInfo DOMINICA = new CountryInfo() { CountryISO2Code = "DM", CountryISO3Code = "DMA", CountryISONr = "212", CountryNameEng = "DOMINICA", CountryNameUkr = "Домінікана" };
        public static readonly CountryInfo DOMINICAN_REPUBLIC = new CountryInfo() { CountryISO2Code = "DO", CountryISO3Code = "DOM", CountryISONr = "214", CountryNameEng = "DOMINICAN_REPUBLIC", CountryNameUkr = "Домініканська республіка" };
        public static readonly CountryInfo ECUADOR = new CountryInfo() { CountryISO2Code = "EC", CountryISO3Code = "ECU", CountryISONr = "218", CountryNameEng = "ECUADOR", CountryNameUkr = "Еквадор" };
        public static readonly CountryInfo EGYPT = new CountryInfo() { CountryISO2Code = "EG", CountryISO3Code = "EGY", CountryISONr = "818", CountryNameEng = "EGYPT", CountryNameUkr = "Єгипет" };
        public static readonly CountryInfo EL_SALVADOR = new CountryInfo() { CountryISO2Code = "SV", CountryISO3Code = "SLV", CountryISONr = "222", CountryNameEng = "EL_SALVADOR", CountryNameUkr = "Сальвадор" };
        public static readonly CountryInfo EQUATORIAL_GUINEA = new CountryInfo() { CountryISO2Code = "GQ", CountryISO3Code = "GNQ", CountryISONr = "226", CountryNameEng = "EQUATORIAL_GUINEA", CountryNameUkr = "Екваторіальна Ґвінея" };
        public static readonly CountryInfo ERITREA = new CountryInfo() { CountryISO2Code = "ER", CountryISO3Code = "ERI", CountryISONr = "232", CountryNameEng = "ERITREA", CountryNameUkr = "Ерітрея" };
        public static readonly CountryInfo ESTONIA = new CountryInfo() { CountryISO2Code = "EE", CountryISO3Code = "EST", CountryISONr = "233", CountryNameEng = "ESTONIA", CountryNameUkr = "Естонія" };
        public static readonly CountryInfo ETHIOPIA = new CountryInfo() { CountryISO2Code = "ET", CountryISO3Code = "ETH", CountryISONr = "231", CountryNameEng = "ETHIOPIA", CountryNameUkr = "Ефіопія" };
        public static readonly CountryInfo FALKLAND_ISLANDS_MALVINAS = new CountryInfo() { CountryISO2Code = "FK", CountryISO3Code = "FLK", CountryISONr = "238", CountryNameEng = "FALKLAND_ISLANDS_MALVINAS", CountryNameUkr = "Фолклендські (Мальвінські) Острови" };
        public static readonly CountryInfo FAROE_ISLANDS = new CountryInfo() { CountryISO2Code = "FO", CountryISO3Code = "FRO", CountryISONr = "234", CountryNameEng = "FAROE_ISLANDS", CountryNameUkr = "Фарерські острови" };
        public static readonly CountryInfo FIJI = new CountryInfo() { CountryISO2Code = "FJ", CountryISO3Code = "FJI", CountryISONr = "242", CountryNameEng = "FIJI", CountryNameUkr = "Фіджі" };
        public static readonly CountryInfo FINLAND = new CountryInfo() { CountryISO2Code = "FI", CountryISO3Code = "FIN", CountryISONr = "246", CountryNameEng = "FINLAND", CountryNameUkr = "Фінляндія" };
        public static readonly CountryInfo FRANCE = new CountryInfo() { CountryISO2Code = "FR", CountryISO3Code = "FRA", CountryISONr = "250", CountryNameEng = "FRANCE", CountryNameUkr = "Франція" };
        public static readonly CountryInfo FRENCH_GUIANA = new CountryInfo() { CountryISO2Code = "GF", CountryISO3Code = "GUF", CountryISONr = "254", CountryNameEng = "FRENCH_GUIANA", CountryNameUkr = "Французька Ґвіана" };
        public static readonly CountryInfo FRENCH_POLYNESIA = new CountryInfo() { CountryISO2Code = "PF", CountryISO3Code = "PYF", CountryISONr = "258", CountryNameEng = "FRENCH_POLYNESIA", CountryNameUkr = "Французька Полінезія" };
        public static readonly CountryInfo FRENCH_SOUTHERN_TERRITORIES = new CountryInfo() { CountryISO2Code = "TF", CountryISO3Code = "ATF", CountryISONr = "260", CountryNameEng = "FRENCH_SOUTHERN_TERRITORIES", CountryNameUkr = "Французькі Південні Території" };
        public static readonly CountryInfo GABON = new CountryInfo() { CountryISO2Code = "GA", CountryISO3Code = "GAB", CountryISONr = "266", CountryNameEng = "GABON", CountryNameUkr = "Ґабон" };
        public static readonly CountryInfo GAMBIA = new CountryInfo() { CountryISO2Code = "GM", CountryISO3Code = "GMB", CountryISONr = "270", CountryNameEng = "GAMBIA", CountryNameUkr = "Ґамбія" };
        public static readonly CountryInfo GEORGIA = new CountryInfo() { CountryISO2Code = "GE", CountryISO3Code = "GEO", CountryISONr = "268", CountryNameEng = "GEORGIA", CountryNameUkr = "Грузія" };
        public static readonly CountryInfo GERMANY = new CountryInfo() { CountryISO2Code = "DE", CountryISO3Code = "DEU", CountryISONr = "276", CountryNameEng = "GERMANY", CountryNameUkr = "Німеччина" };
        public static readonly CountryInfo GHANA = new CountryInfo() { CountryISO2Code = "GH", CountryISO3Code = "GHA", CountryISONr = "288", CountryNameEng = "GHANA", CountryNameUkr = "Ґана" };
        public static readonly CountryInfo GIBRALTAR = new CountryInfo() { CountryISO2Code = "GI", CountryISO3Code = "GIB", CountryISONr = "292", CountryNameEng = "GIBRALTAR", CountryNameUkr = "Гібралтар" };
        public static readonly CountryInfo GREECE = new CountryInfo() { CountryISO2Code = "GR", CountryISO3Code = "GRC", CountryISONr = "300", CountryNameEng = "GREECE", CountryNameUkr = "Греція" };
        public static readonly CountryInfo GREENLAND = new CountryInfo() { CountryISO2Code = "GL", CountryISO3Code = "GRL", CountryISONr = "304", CountryNameEng = "GREENLAND", CountryNameUkr = "Гренландія" };
        public static readonly CountryInfo GRENADA = new CountryInfo() { CountryISO2Code = "GD", CountryISO3Code = "GRD", CountryISONr = "308", CountryNameEng = "GRENADA", CountryNameUkr = "Гренада" };
        public static readonly CountryInfo GUADELOUPE = new CountryInfo() { CountryISO2Code = "GP", CountryISO3Code = "GLP", CountryISONr = "312", CountryNameEng = "GUADELOUPE", CountryNameUkr = "Ґваделупа" };
        public static readonly CountryInfo GUAM = new CountryInfo() { CountryISO2Code = "GU", CountryISO3Code = "GUM", CountryISONr = "316", CountryNameEng = "GUAM", CountryNameUkr = "Ґуам" };
        public static readonly CountryInfo GUATEMALA = new CountryInfo() { CountryISO2Code = "GT", CountryISO3Code = "GTM", CountryISONr = "320", CountryNameEng = "GUATEMALA", CountryNameUkr = "Ґватемала" };
        public static readonly CountryInfo GUINEA = new CountryInfo() { CountryISO2Code = "GN", CountryISO3Code = "GIN", CountryISONr = "324", CountryNameEng = "GUINEA", CountryNameUkr = "Ґвінея" };
        public static readonly CountryInfo GUINEA_BISSAU = new CountryInfo() { CountryISO2Code = "GW", CountryISO3Code = "GNB", CountryISONr = "624", CountryNameEng = "GUINEA_BISSAU", CountryNameUkr = "Ґвінея-Бісау" };
        public static readonly CountryInfo GUYANA = new CountryInfo() { CountryISO2Code = "GY", CountryISO3Code = "GUY", CountryISONr = "328", CountryNameEng = "GUYANA", CountryNameUkr = "Ґайана" };
        public static readonly CountryInfo HAITI = new CountryInfo() { CountryISO2Code = "HT", CountryISO3Code = "HTI", CountryISONr = "332", CountryNameEng = "HAITI", CountryNameUkr = "Гаїті" };
        public static readonly CountryInfo HEARD_AND_MC_DONALD_ISLANDS = new CountryInfo() { CountryISO2Code = "HM", CountryISO3Code = "HMD", CountryISONr = "334", CountryNameEng = "HEARD_AND_MC_DONALD_ISLANDS", CountryNameUkr = "Острови Герда і МакДональда" };
        public static readonly CountryInfo HONDURAS = new CountryInfo() { CountryISO2Code = "HN", CountryISO3Code = "HND", CountryISONr = "340", CountryNameEng = "HONDURAS", CountryNameUkr = "Гондурас" };
        public static readonly CountryInfo HONG_KONG = new CountryInfo() { CountryISO2Code = "HK", CountryISO3Code = "HKG", CountryISONr = "344", CountryNameEng = "HONG_KONG", CountryNameUkr = "Гонконг" };
        public static readonly CountryInfo HUNGARY = new CountryInfo() { CountryISO2Code = "HU", CountryISO3Code = "HUN", CountryISONr = "348", CountryNameEng = "HUNGARY", CountryNameUkr = "Угорщина" };
        public static readonly CountryInfo ICELAND = new CountryInfo() { CountryISO2Code = "IS", CountryISO3Code = "ISL", CountryISONr = "352", CountryNameEng = "ICELAND", CountryNameUkr = "Ісландія" };
        public static readonly CountryInfo INDIA = new CountryInfo() { CountryISO2Code = "IN", CountryISO3Code = "IND", CountryISONr = "356", CountryNameEng = "INDIA", CountryNameUkr = "Індія" };
        public static readonly CountryInfo INDONESIA = new CountryInfo() { CountryISO2Code = "ID", CountryISO3Code = "IDN", CountryISONr = "360", CountryNameEng = "INDONESIA", CountryNameUkr = "Індонезія" };
        public static readonly CountryInfo IRAN_ISLAMIC_REPUBLIC_OF = new CountryInfo() { CountryISO2Code = "IR", CountryISO3Code = "IRN", CountryISONr = "364", CountryNameEng = "IRAN_ISLAMIC_REPUBLIC_OF", CountryNameUkr = "Іран" };
        public static readonly CountryInfo IRAQ = new CountryInfo() { CountryISO2Code = "IQ", CountryISO3Code = "IRQ", CountryISONr = "368", CountryNameEng = "IRAQ", CountryNameUkr = "Ірак" };
        public static readonly CountryInfo IRELAND = new CountryInfo() { CountryISO2Code = "IE", CountryISO3Code = "IRL", CountryISONr = "372", CountryNameEng = "IRELAND", CountryNameUkr = "Ірландія" };
        public static readonly CountryInfo ISRAEL = new CountryInfo() { CountryISO2Code = "IL", CountryISO3Code = "ISR", CountryISONr = "376", CountryNameEng = "ISRAEL", CountryNameUkr = "Ізраїль" };
        public static readonly CountryInfo ITALY = new CountryInfo() { CountryISO2Code = "IT", CountryISO3Code = "ITA", CountryISONr = "380", CountryNameEng = "ITALY", CountryNameUkr = "Італія" };
        public static readonly CountryInfo JAMAICA = new CountryInfo() { CountryISO2Code = "JM", CountryISO3Code = "JAM", CountryISONr = "388", CountryNameEng = "JAMAICA", CountryNameUkr = "Ямайка" };
        public static readonly CountryInfo JAPAN = new CountryInfo() { CountryISO2Code = "JP", CountryISO3Code = "JPN", CountryISONr = "392", CountryNameEng = "JAPAN", CountryNameUkr = "Японія" };
        public static readonly CountryInfo JORDAN = new CountryInfo() { CountryISO2Code = "JO", CountryISO3Code = "JOR", CountryISONr = "400", CountryNameEng = "JORDAN", CountryNameUkr = "Йорданія" };
        public static readonly CountryInfo KAZAKHSTAN = new CountryInfo() { CountryISO2Code = "KZ", CountryISO3Code = "KAZ", CountryISONr = "398", CountryNameEng = "KAZAKHSTAN", CountryNameUkr = "Казахстан" };
        public static readonly CountryInfo KENYA = new CountryInfo() { CountryISO2Code = "KE", CountryISO3Code = "KEN", CountryISONr = "404", CountryNameEng = "KENYA", CountryNameUkr = "Кенія" };
        public static readonly CountryInfo KIRIBATI = new CountryInfo() { CountryISO2Code = "KI", CountryISO3Code = "KIR", CountryISONr = "296", CountryNameEng = "KIRIBATI", CountryNameUkr = "Кірібаті" };
        public static readonly CountryInfo KOREA_DEMOCRATIC_PEOPLE_S_REPUBLIC_OF = new CountryInfo() { CountryISO2Code = "KP", CountryISO3Code = "PRK", CountryISONr = "408", CountryNameEng = "KOREA_DEMOCRATIC_PEOPLE_S_REPUBLIC_OF", CountryNameUkr = "КНДР" };
        public static readonly CountryInfo KOREA_REPUBLIC_OF = new CountryInfo() { CountryISO2Code = "KR", CountryISO3Code = "KOR", CountryISONr = "410", CountryNameEng = "KOREA_REPUBLIC_OF", CountryNameUkr = "Республіка Корея" };
        public static readonly CountryInfo KUWAIT = new CountryInfo() { CountryISO2Code = "KW", CountryISO3Code = "KWT", CountryISONr = "414", CountryNameEng = "KUWAIT", CountryNameUkr = "Кувейт" };
        public static readonly CountryInfo KYRGYZSTAN = new CountryInfo() { CountryISO2Code = "KG", CountryISO3Code = "KGZ", CountryISONr = "417", CountryNameEng = "KYRGYZSTAN", CountryNameUkr = "Киргизстан" };
        public static readonly CountryInfo LAO_PEOPLE_S_DEMOCRATIC_REPUBLIC = new CountryInfo() { CountryISO2Code = "LA", CountryISO3Code = "LAO", CountryISONr = "418", CountryNameEng = "LAO_PEOPLE_S_DEMOCRATIC_REPUBLIC", CountryNameUkr = "Лаос" };
        public static readonly CountryInfo LATVIA = new CountryInfo() { CountryISO2Code = "LV", CountryISO3Code = "LVA", CountryISONr = "428", CountryNameEng = "LATVIA", CountryNameUkr = "Латвія" };
        public static readonly CountryInfo LEBANON = new CountryInfo() { CountryISO2Code = "LB", CountryISO3Code = "LBN", CountryISONr = "422", CountryNameEng = "LEBANON", CountryNameUkr = "Ліван" };
        public static readonly CountryInfo LESOTHO = new CountryInfo() { CountryISO2Code = "LS", CountryISO3Code = "LSO", CountryISONr = "426", CountryNameEng = "LESOTHO", CountryNameUkr = "Лесото" };
        public static readonly CountryInfo LIBERIA = new CountryInfo() { CountryISO2Code = "LR", CountryISO3Code = "LBR", CountryISONr = "430", CountryNameEng = "LIBERIA", CountryNameUkr = "Ліберія" };
        public static readonly CountryInfo LIBYAN_ARAB_JAMAHIRIYA = new CountryInfo() { CountryISO2Code = "LY", CountryISO3Code = "LBY", CountryISONr = "434", CountryNameEng = "LIBYAN_ARAB_JAMAHIRIYA", CountryNameUkr = "Лівія" };
        public static readonly CountryInfo LIECHTENSTEIN = new CountryInfo() { CountryISO2Code = "LI", CountryISO3Code = "LIE", CountryISONr = "438", CountryNameEng = "LIECHTENSTEIN", CountryNameUkr = "Ліхтенштейн" };
        public static readonly CountryInfo LITHUANIA = new CountryInfo() { CountryISO2Code = "LT", CountryISO3Code = "LTU", CountryISONr = "440", CountryNameEng = "LITHUANIA", CountryNameUkr = "Литва" };
        public static readonly CountryInfo LUXEMBOURG = new CountryInfo() { CountryISO2Code = "LU", CountryISO3Code = "LUX", CountryISONr = "442", CountryNameEng = "LUXEMBOURG", CountryNameUkr = "Люксембург" };
        public static readonly CountryInfo MACAU = new CountryInfo() { CountryISO2Code = "MO", CountryISO3Code = "MAC", CountryISONr = "446", CountryNameEng = "MACAU", CountryNameUkr = "Макао" };
        public static readonly CountryInfo MACEDONIA_THE_FORMER_YUGOSLAV_REPUBLIC_OF = new CountryInfo() { CountryISO2Code = "MK", CountryISO3Code = "MKD", CountryISONr = "807", CountryNameEng = "MACEDONIA_THE_FORMER_YUGOSLAV_REPUBLIC_OF", CountryNameUkr = "Македонія" };
        public static readonly CountryInfo MADAGASCAR = new CountryInfo() { CountryISO2Code = "MG", CountryISO3Code = "MDG", CountryISONr = "450", CountryNameEng = "MADAGASCAR", CountryNameUkr = "Мадагаскар" };
        public static readonly CountryInfo MALAWI = new CountryInfo() { CountryISO2Code = "MW", CountryISO3Code = "MWI", CountryISONr = "454", CountryNameEng = "MALAWI", CountryNameUkr = "Малаві" };
        public static readonly CountryInfo MALAYSIA = new CountryInfo() { CountryISO2Code = "MY", CountryISO3Code = "MYS", CountryISONr = "458", CountryNameEng = "MALAYSIA", CountryNameUkr = "Малайзія" };
        public static readonly CountryInfo MALDIVES = new CountryInfo() { CountryISO2Code = "MV", CountryISO3Code = "MDV", CountryISONr = "462", CountryNameEng = "MALDIVES", CountryNameUkr = "Мальдиви" };
        public static readonly CountryInfo MALI = new CountryInfo() { CountryISO2Code = "ML", CountryISO3Code = "MLI", CountryISONr = "466", CountryNameEng = "MALI", CountryNameUkr = "Малі" };
        public static readonly CountryInfo MALTA = new CountryInfo() { CountryISO2Code = "MT", CountryISO3Code = "MLT", CountryISONr = "470", CountryNameEng = "MALTA", CountryNameUkr = "Мальта" };
        public static readonly CountryInfo MARSHALL_ISLANDS = new CountryInfo() { CountryISO2Code = "MH", CountryISO3Code = "MHL", CountryISONr = "584", CountryNameEng = "MARSHALL_ISLANDS", CountryNameUkr = "Маршалові Острови" };
        public static readonly CountryInfo MARTINIQUE = new CountryInfo() { CountryISO2Code = "MQ", CountryISO3Code = "MTQ", CountryISONr = "474", CountryNameEng = "MARTINIQUE", CountryNameUkr = "Мартініка" };
        public static readonly CountryInfo MAURITANIA = new CountryInfo() { CountryISO2Code = "MR", CountryISO3Code = "MRT", CountryISONr = "478", CountryNameEng = "MAURITANIA", CountryNameUkr = "Мавританія" };
        public static readonly CountryInfo MAURITIUS = new CountryInfo() { CountryISO2Code = "MU", CountryISO3Code = "MUS", CountryISONr = "480", CountryNameEng = "MAURITIUS", CountryNameUkr = "Маврикій" };
        public static readonly CountryInfo MAYOTTE = new CountryInfo() { CountryISO2Code = "YT", CountryISO3Code = "MYT", CountryISONr = "175", CountryNameEng = "MAYOTTE", CountryNameUkr = "" };
        public static readonly CountryInfo MEXICO = new CountryInfo() { CountryISO2Code = "MX", CountryISO3Code = "MEX", CountryISONr = "484", CountryNameEng = "MEXICO", CountryNameUkr = "Мексика" };
        public static readonly CountryInfo MICRONESIA_FEDERATED_STATES_OF = new CountryInfo() { CountryISO2Code = "FM", CountryISO3Code = "FSM", CountryISONr = "583", CountryNameEng = "MICRONESIA_FEDERATED_STATES_OF", CountryNameUkr = "Мікронезія" };
        public static readonly CountryInfo MOLDOVA_REPUBLIC_OF = new CountryInfo() { CountryISO2Code = "MD", CountryISO3Code = "MDA", CountryISONr = "498", CountryNameEng = "MOLDOVA_REPUBLIC_OF", CountryNameUkr = "Молдова" };
        public static readonly CountryInfo MONACO = new CountryInfo() { CountryISO2Code = "MC", CountryISO3Code = "MCO", CountryISONr = "492", CountryNameEng = "MONACO", CountryNameUkr = "Монако" };
        public static readonly CountryInfo MONGOLIA = new CountryInfo() { CountryISO2Code = "MN", CountryISO3Code = "MNG", CountryISONr = "496", CountryNameEng = "MONGOLIA", CountryNameUkr = "Монголія" };
        public static readonly CountryInfo MONTSERRAT = new CountryInfo() { CountryISO2Code = "MS", CountryISO3Code = "MSR", CountryISONr = "500", CountryNameEng = "MONTSERRAT", CountryNameUkr = "Мосеррат" };
        public static readonly CountryInfo MOROCCO = new CountryInfo() { CountryISO2Code = "MA", CountryISO3Code = "MAR", CountryISONr = "504", CountryNameEng = "MOROCCO", CountryNameUkr = "Марокко" };
        public static readonly CountryInfo MOZAMBIQUE = new CountryInfo() { CountryISO2Code = "MZ", CountryISO3Code = "MOZ", CountryISONr = "508", CountryNameEng = "MOZAMBIQUE", CountryNameUkr = "Мозамбік" };
        public static readonly CountryInfo MYANMAR = new CountryInfo() { CountryISO2Code = "MM", CountryISO3Code = "MMR", CountryISONr = "104", CountryNameEng = "MYANMAR", CountryNameUkr = "М'янма" };
        public static readonly CountryInfo NAMIBIA = new CountryInfo() { CountryISO2Code = "NA", CountryISO3Code = "NAM", CountryISONr = "516", CountryNameEng = "NAMIBIA", CountryNameUkr = "Намібія" };
        public static readonly CountryInfo NAURU = new CountryInfo() { CountryISO2Code = "NR", CountryISO3Code = "NRU", CountryISONr = "520", CountryNameEng = "NAURU", CountryNameUkr = "Науру" };
        public static readonly CountryInfo NEPAL = new CountryInfo() { CountryISO2Code = "NP", CountryISO3Code = "NPL", CountryISONr = "524", CountryNameEng = "NEPAL", CountryNameUkr = "Непал" };
        public static readonly CountryInfo NETHERLANDS = new CountryInfo() { CountryISO2Code = "NL", CountryISO3Code = "NLD", CountryISONr = "528", CountryNameEng = "NETHERLANDS", CountryNameUkr = "Нідерланди" };
        public static readonly CountryInfo NETHERLANDS_ANTILLES = new CountryInfo() { CountryISO2Code = "AN", CountryISO3Code = "ANT", CountryISONr = "530", CountryNameEng = "NETHERLANDS_ANTILLES", CountryNameUkr = "Нідерландські Антильські острови" };
        public static readonly CountryInfo NEW_CALEDONIA = new CountryInfo() { CountryISO2Code = "NC", CountryISO3Code = "NCL", CountryISONr = "540", CountryNameEng = "NEW_CALEDONIA", CountryNameUkr = "Нова Каледонія" };
        public static readonly CountryInfo NEW_ZEALAND = new CountryInfo() { CountryISO2Code = "NZ", CountryISO3Code = "NZL", CountryISONr = "554", CountryNameEng = "NEW_ZEALAND", CountryNameUkr = "Нова Зеландія" };
        public static readonly CountryInfo NICARAGUA = new CountryInfo() { CountryISO2Code = "NI", CountryISO3Code = "NIC", CountryISONr = "558", CountryNameEng = "NICARAGUA", CountryNameUkr = "Нікарагуа" };
        public static readonly CountryInfo NIGER = new CountryInfo() { CountryISO2Code = "NE", CountryISO3Code = "NER", CountryISONr = "562", CountryNameEng = "NIGER", CountryNameUkr = "Нігер" };
        public static readonly CountryInfo NIGERIA = new CountryInfo() { CountryISO2Code = "NG", CountryISO3Code = "NGA", CountryISONr = "566", CountryNameEng = "NIGERIA", CountryNameUkr = "Нігерія" };
        public static readonly CountryInfo NIUE = new CountryInfo() { CountryISO2Code = "NU", CountryISO3Code = "NIU", CountryISONr = "570", CountryNameEng = "NIUE", CountryNameUkr = "Ніуе" };
        public static readonly CountryInfo NORFOLK_ISLAND = new CountryInfo() { CountryISO2Code = "NF", CountryISO3Code = "NFK", CountryISONr = "574", CountryNameEng = "NORFOLK_ISLAND", CountryNameUkr = "Норфолкські острови" };
        public static readonly CountryInfo NORTHERN_MARIANA_ISLANDS = new CountryInfo() { CountryISO2Code = "MP", CountryISO3Code = "MNP", CountryISONr = "580", CountryNameEng = "NORTHERN_MARIANA_ISLANDS", CountryNameUkr = "Північно-Маріанські острови" };
        public static readonly CountryInfo NORWAY = new CountryInfo() { CountryISO2Code = "NO", CountryISO3Code = "NOR", CountryISONr = "578", CountryNameEng = "NORWAY", CountryNameUkr = "Норвегія" };
        public static readonly CountryInfo OMAN = new CountryInfo() { CountryISO2Code = "OM", CountryISO3Code = "OMN", CountryISONr = "512", CountryNameEng = "OMAN", CountryNameUkr = "Оман" };
        public static readonly CountryInfo PAKISTAN = new CountryInfo() { CountryISO2Code = "PK", CountryISO3Code = "PAK", CountryISONr = "586", CountryNameEng = "PAKISTAN", CountryNameUkr = "Пакистан" };
        public static readonly CountryInfo PALAU = new CountryInfo() { CountryISO2Code = "PW", CountryISO3Code = "PLW", CountryISONr = "585", CountryNameEng = "PALAU", CountryNameUkr = "Палау" };
        public static readonly CountryInfo PALESTINIAN_TERRITORY_Occupied = new CountryInfo() { CountryISO2Code = "PS", CountryISO3Code = "PSE", CountryISONr = "275", CountryNameEng = "PALESTINIAN_TERRITORY_Occupied", CountryNameUkr = "Окуповані Палестинські території" };
        public static readonly CountryInfo PANAMA = new CountryInfo() { CountryISO2Code = "PA", CountryISO3Code = "PAN", CountryISONr = "591", CountryNameEng = "PANAMA", CountryNameUkr = "Панама" };
        public static readonly CountryInfo PAPUA_NEW_GUINEA = new CountryInfo() { CountryISO2Code = "PG", CountryISO3Code = "PNG", CountryISONr = "598", CountryNameEng = "PAPUA_NEW_GUINEA", CountryNameUkr = "Папуа-Нова Ґвінея" };
        public static readonly CountryInfo PARAGUAY = new CountryInfo() { CountryISO2Code = "PY", CountryISO3Code = "PRY", CountryISONr = "600", CountryNameEng = "PARAGUAY", CountryNameUkr = "Парагвай" };
        public static readonly CountryInfo PERU = new CountryInfo() { CountryISO2Code = "PE", CountryISO3Code = "PER", CountryISONr = "604", CountryNameEng = "PERU", CountryNameUkr = "Перу" };
        public static readonly CountryInfo PHILIPPINES = new CountryInfo() { CountryISO2Code = "PH", CountryISO3Code = "PHL", CountryISONr = "608", CountryNameEng = "PHILIPPINES", CountryNameUkr = "Філіппіни" };
        public static readonly CountryInfo PITCAIRN = new CountryInfo() { CountryISO2Code = "PN", CountryISO3Code = "PCN", CountryISONr = "612", CountryNameEng = "PITCAIRN", CountryNameUkr = "Піткерн" };
        public static readonly CountryInfo POLAND = new CountryInfo() { CountryISO2Code = "PL", CountryISO3Code = "POL", CountryISONr = "616", CountryNameEng = "POLAND", CountryNameUkr = "Польща" };
        public static readonly CountryInfo PORTUGAL = new CountryInfo() { CountryISO2Code = "PT", CountryISO3Code = "PRT", CountryISONr = "620", CountryNameEng = "PORTUGAL", CountryNameUkr = "Португалія" };
        public static readonly CountryInfo PUERTO_RICO = new CountryInfo() { CountryISO2Code = "PR", CountryISO3Code = "PRI", CountryISONr = "630", CountryNameEng = "PUERTO_RICO", CountryNameUkr = "Пуерто-Ріко" };
        public static readonly CountryInfo QATAR = new CountryInfo() { CountryISO2Code = "QA", CountryISO3Code = "QAT", CountryISONr = "634", CountryNameEng = "QATAR", CountryNameUkr = "Катар" };
        public static readonly CountryInfo REUNION = new CountryInfo() { CountryISO2Code = "RE", CountryISO3Code = "REU", CountryISONr = "638", CountryNameEng = "REUNION", CountryNameUkr = "Реюньюн" };
        public static readonly CountryInfo ROMANIA = new CountryInfo() { CountryISO2Code = "RO", CountryISO3Code = "ROU", CountryISONr = "642", CountryNameEng = "ROMANIA", CountryNameUkr = "Румунія" };
        public static readonly CountryInfo RUSSIAN_FEDERATION = new CountryInfo() { CountryISO2Code = "RU", CountryISO3Code = "RUS", CountryISONr = "643", CountryNameEng = "RUSSIAN_FEDERATION", CountryNameUkr = "Російська Федерація" };
        public static readonly CountryInfo RWANDA = new CountryInfo() { CountryISO2Code = "RW", CountryISO3Code = "RWA", CountryISONr = "646", CountryNameEng = "RWANDA", CountryNameUkr = "Руанда" };
        public static readonly CountryInfo SAINT_HELENA = new CountryInfo() { CountryISO2Code = "SH", CountryISO3Code = "SHN", CountryISONr = "654", CountryNameEng = "SAINT_HELENA", CountryNameUkr = "Острів Святої Гелени" };
        public static readonly CountryInfo SAINT_KITTS_AND_NEVIS = new CountryInfo() { CountryISO2Code = "KN", CountryISO3Code = "KNA", CountryISONr = "659", CountryNameEng = "SAINT_KITTS_AND_NEVIS", CountryNameUkr = "Сент Кіттс і Невіс" };
        public static readonly CountryInfo SAINT_LUCIA = new CountryInfo() { CountryISO2Code = "LC", CountryISO3Code = "LCA", CountryISONr = "662", CountryNameEng = "SAINT_LUCIA", CountryNameUkr = "Сата Лючія" };
        public static readonly CountryInfo SAINT_PIERRE_AND_MIQUELON = new CountryInfo() { CountryISO2Code = "PM", CountryISO3Code = "SPM", CountryISONr = "666", CountryNameEng = "SAINT_PIERRE_AND_MIQUELON", CountryNameUkr = "Сен-П'єр і Мікелон" };
        public static readonly CountryInfo SAINT_VINCENT_AND_THE_GRENADINES = new CountryInfo() { CountryISO2Code = "VC", CountryISO3Code = "VCT", CountryISONr = "670", CountryNameEng = "SAINT_VINCENT_AND_THE_GRENADINES", CountryNameUkr = "Сент-Вінсент і Гренадіни" };
        public static readonly CountryInfo SAMOA = new CountryInfo() { CountryISO2Code = "WS", CountryISO3Code = "WSM", CountryISONr = "882", CountryNameEng = "SAMOA", CountryNameUkr = "Самоа" };
        public static readonly CountryInfo SAN_MARINO = new CountryInfo() { CountryISO2Code = "SM", CountryISO3Code = "SMR", CountryISONr = "674", CountryNameEng = "SAN_MARINO", CountryNameUkr = "Сан-Марино" };
        public static readonly CountryInfo SAO_TOME_AND_PRINCIPE = new CountryInfo() { CountryISO2Code = "ST", CountryISO3Code = "STP", CountryISONr = "678", CountryNameEng = "SAO_TOME_AND_PRINCIPE", CountryNameUkr = "Сан-Томе і Прінсіпі" };
        public static readonly CountryInfo SAUDI_ARABIA = new CountryInfo() { CountryISO2Code = "SA", CountryISO3Code = "SAU", CountryISONr = "682", CountryNameEng = "SAUDI_ARABIA", CountryNameUkr = "Саудівська Аравія" };
        public static readonly CountryInfo SENEGAL = new CountryInfo() { CountryISO2Code = "SN", CountryISO3Code = "SEN", CountryISONr = "686", CountryNameEng = "SENEGAL", CountryNameUkr = "Сенеґал" };
        public static readonly CountryInfo SERBIA_AND_MONTENEGRO = new CountryInfo() { CountryISO2Code = "CS", CountryISO3Code = "SCG", CountryISONr = "891", CountryNameEng = "SERBIA_AND_MONTENEGRO", CountryNameUkr = "Сербія і Македонія" };
        public static readonly CountryInfo SEYCHELLES = new CountryInfo() { CountryISO2Code = "SC", CountryISO3Code = "SYC", CountryISONr = "690", CountryNameEng = "SEYCHELLES", CountryNameUkr = "Сейшели" };
        public static readonly CountryInfo SIERRA_LEONE = new CountryInfo() { CountryISO2Code = "SL", CountryISO3Code = "SLE", CountryISONr = "694", CountryNameEng = "SIERRA_LEONE", CountryNameUkr = "Сьєрра-Леоне" };
        public static readonly CountryInfo SINGAPORE = new CountryInfo() { CountryISO2Code = "SG", CountryISO3Code = "SGP", CountryISONr = "702", CountryNameEng = "SINGAPORE", CountryNameUkr = "Сингапур" };
        public static readonly CountryInfo SLOVAKIA = new CountryInfo() { CountryISO2Code = "SK", CountryISO3Code = "SVK", CountryISONr = "703", CountryNameEng = "SLOVAKIA", CountryNameUkr = "Словаччина" };
        public static readonly CountryInfo SLOVENIA = new CountryInfo() { CountryISO2Code = "SI", CountryISO3Code = "SVN", CountryISONr = "705", CountryNameEng = "SLOVENIA", CountryNameUkr = "Словенія" };
        public static readonly CountryInfo SOLOMON_ISLANDS = new CountryInfo() { CountryISO2Code = "SB", CountryISO3Code = "SLB", CountryISONr = "090", CountryNameEng = "SOLOMON_ISLANDS", CountryNameUkr = "Соломонові острови" };
        public static readonly CountryInfo SOMALIA = new CountryInfo() { CountryISO2Code = "SO", CountryISO3Code = "SOM", CountryISONr = "706", CountryNameEng = "SOMALIA", CountryNameUkr = "Сомалія" };
        public static readonly CountryInfo SOUTH_AFRICA = new CountryInfo() { CountryISO2Code = "ZA", CountryISO3Code = "ZAF", CountryISONr = "710", CountryNameEng = "SOUTH_AFRICA", CountryNameUkr = "Південна Африка" };
        public static readonly CountryInfo SOUTH_GEORGIA_AND_THE_SOUTH_SANDWICH_ISLANDS = new CountryInfo() { CountryISO2Code = "GS", CountryISO3Code = "SGS", CountryISONr = "239", CountryNameEng = "SOUTH_GEORGIA_AND_THE_SOUTH_SANDWICH_ISLANDS", CountryNameUkr = "Південна Георгія та Південні Сендвічеві острови" };
        public static readonly CountryInfo SPAIN = new CountryInfo() { CountryISO2Code = "ES", CountryISO3Code = "ESP", CountryISONr = "724", CountryNameEng = "SPAIN", CountryNameUkr = "Іспанія" };
        public static readonly CountryInfo SRI_LANKA = new CountryInfo() { CountryISO2Code = "LK", CountryISO3Code = "LKA", CountryISONr = "144", CountryNameEng = "SRI_LANKA", CountryNameUkr = "Шрі-Ланка" };
        public static readonly CountryInfo SUDAN = new CountryInfo() { CountryISO2Code = "SD", CountryISO3Code = "SDN", CountryISONr = "736", CountryNameEng = "SUDAN", CountryNameUkr = "Судан" };
        public static readonly CountryInfo SURINAME = new CountryInfo() { CountryISO2Code = "SR", CountryISO3Code = "SUR", CountryISONr = "740", CountryNameEng = "SURINAME", CountryNameUkr = "Сурінам" };
        public static readonly CountryInfo SVALBARD_AND_JAN_MAYEN_ISLANDS = new CountryInfo() { CountryISO2Code = "SJ", CountryISO3Code = "SJM", CountryISONr = "744", CountryNameEng = "SVALBARD_AND_JAN_MAYEN_ISLANDS", CountryNameUkr = "Шпіцберґен і Ян-Майєн" };
        public static readonly CountryInfo SWAZILAND = new CountryInfo() { CountryISO2Code = "SZ", CountryISO3Code = "SWZ", CountryISONr = "748", CountryNameEng = "SWAZILAND", CountryNameUkr = "Свазиленд" };
        public static readonly CountryInfo SWEDEN = new CountryInfo() { CountryISO2Code = "SE", CountryISO3Code = "SWE", CountryISONr = "752", CountryNameEng = "SWEDEN", CountryNameUkr = "Швеція" };
        public static readonly CountryInfo SWITZERLAND = new CountryInfo() { CountryISO2Code = "CH", CountryISO3Code = "CHE", CountryISONr = "756", CountryNameEng = "SWITZERLAND", CountryNameUkr = "Швейцарія" };
        public static readonly CountryInfo SYRIAN_ARAB_REPUBLIC = new CountryInfo() { CountryISO2Code = "SY", CountryISO3Code = "SYR", CountryISONr = "760", CountryNameEng = "SYRIAN_ARAB_REPUBLIC", CountryNameUkr = "Сирійська Арабська Республіка" };
        public static readonly CountryInfo TAIWAN = new CountryInfo() { CountryISO2Code = "TW", CountryISO3Code = "TWN", CountryISONr = "158", CountryNameEng = "TAIWAN", CountryNameUkr = "Тайвань" };
        public static readonly CountryInfo TAJIKISTAN = new CountryInfo() { CountryISO2Code = "TJ", CountryISO3Code = "TJK", CountryISONr = "762", CountryNameEng = "TAJIKISTAN", CountryNameUkr = "Таджикистан" };
        public static readonly CountryInfo TANZANIA_UNITED_REPUBLIC_OF = new CountryInfo() { CountryISO2Code = "TZ", CountryISO3Code = "TZA", CountryISONr = "834", CountryNameEng = "TANZANIA_UNITED_REPUBLIC_OF", CountryNameUkr = "Танзанія" };
        public static readonly CountryInfo THAILAND = new CountryInfo() { CountryISO2Code = "TH", CountryISO3Code = "THA", CountryISONr = "764", CountryNameEng = "THAILAND", CountryNameUkr = "Тайланд" };
        public static readonly CountryInfo TIMOR_LESTE = new CountryInfo() { CountryISO2Code = "TL", CountryISO3Code = "TLS", CountryISONr = "626", CountryNameEng = "TIMOR_LESTE", CountryNameUkr = "Східний Тімор" };
        public static readonly CountryInfo TOGO = new CountryInfo() { CountryISO2Code = "TG", CountryISO3Code = "TGO", CountryISONr = "768", CountryNameEng = "TOGO", CountryNameUkr = "Тоґо" };
        public static readonly CountryInfo TOKELAU = new CountryInfo() { CountryISO2Code = "TK", CountryISO3Code = "TKL", CountryISONr = "772", CountryNameEng = "TOKELAU", CountryNameUkr = "Токелау" };
        public static readonly CountryInfo TONGA = new CountryInfo() { CountryISO2Code = "TO", CountryISO3Code = "TON", CountryISONr = "776", CountryNameEng = "TONGA", CountryNameUkr = "Тонґа" };
        public static readonly CountryInfo TRINIDAD_AND_TOBAGO = new CountryInfo() { CountryISO2Code = "TT", CountryISO3Code = "TTO", CountryISONr = "780", CountryNameEng = "TRINIDAD_AND_TOBAGO", CountryNameUkr = "Тринідад і Тобаґо" };
        public static readonly CountryInfo TUNISIA = new CountryInfo() { CountryISO2Code = "TN", CountryISO3Code = "TUN", CountryISONr = "788", CountryNameEng = "TUNISIA", CountryNameUkr = "Туніс" };
        public static readonly CountryInfo TURKEY = new CountryInfo() { CountryISO2Code = "TR", CountryISO3Code = "TUR", CountryISONr = "792", CountryNameEng = "TURKEY", CountryNameUkr = "Туреччина" };
        public static readonly CountryInfo TURKMENISTAN = new CountryInfo() { CountryISO2Code = "TM", CountryISO3Code = "TKM", CountryISONr = "795", CountryNameEng = "TURKMENISTAN", CountryNameUkr = "Туркменістан" };
        public static readonly CountryInfo TURKS_AND_CAICOS_ISLANDS = new CountryInfo() { CountryISO2Code = "TC", CountryISO3Code = "TCA", CountryISONr = "796", CountryNameEng = "TURKS_AND_CAICOS_ISLANDS", CountryNameUkr = "Кайкосові острови" };
        public static readonly CountryInfo TUVALU = new CountryInfo() { CountryISO2Code = "TV", CountryISO3Code = "TUV", CountryISONr = "798", CountryNameEng = "TUVALU", CountryNameUkr = "Тувалу" };
        public static readonly CountryInfo UGANDA = new CountryInfo() { CountryISO2Code = "UG", CountryISO3Code = "UGA", CountryISONr = "800", CountryNameEng = "UGANDA", CountryNameUkr = "Уґанда" };
        public static readonly CountryInfo UKRAINE = new CountryInfo() { CountryISO2Code = "UA", CountryISO3Code = "UKR", CountryISONr = "804", CountryNameEng = "UKRAINE", CountryNameUkr = "Україна" };
        public static readonly CountryInfo UNITED_ARAB_EMIRATES = new CountryInfo() { CountryISO2Code = "AE", CountryISO3Code = "ARE", CountryISONr = "784", CountryNameEng = "UNITED_ARAB_EMIRATES", CountryNameUkr = "Об'єднані Арабські Емірати" };
        public static readonly CountryInfo UNITED_KINGDOM = new CountryInfo() { CountryISO2Code = "GB", CountryISO3Code = "GBR", CountryISONr = "826", CountryNameEng = "UNITED_KINGDOM", CountryNameUkr = "Сполучене Королівство Великобританії" };
        public static readonly CountryInfo UNITED_STATES = new CountryInfo() { CountryISO2Code = "US", CountryISO3Code = "USA", CountryISONr = "840", CountryNameEng = "UNITED_STATES", CountryNameUkr = "Сполучені Штати Америки" };
        public static readonly CountryInfo UNITED_STATES_MINOR_OUTLYING_ISLANDS = new CountryInfo() { CountryISO2Code = "UM", CountryISO3Code = "UMI", CountryISONr = "581", CountryNameEng = "UNITED_STATES_MINOR_OUTLYING_ISLANDS", CountryNameUkr = "" };
        public static readonly CountryInfo URUGUAY = new CountryInfo() { CountryISO2Code = "UY", CountryISO3Code = "URY", CountryISONr = "858", CountryNameEng = "URUGUAY", CountryNameUkr = "Уруґвай" };
        public static readonly CountryInfo UZBEKISTAN = new CountryInfo() { CountryISO2Code = "UZ", CountryISO3Code = "UZB", CountryISONr = "860", CountryNameEng = "UZBEKISTAN", CountryNameUkr = "Узбекистан" };
        public static readonly CountryInfo VANUATU = new CountryInfo() { CountryISO2Code = "VU", CountryISO3Code = "VUT", CountryISONr = "548", CountryNameEng = "VANUATU", CountryNameUkr = "Вануату" };
        public static readonly CountryInfo VATICAN_CITY_STATE_HOLY_SEE = new CountryInfo() { CountryISO2Code = "VA", CountryISO3Code = "VAT", CountryISONr = "336", CountryNameEng = "VATICAN_CITY_STATE_HOLY_SEE", CountryNameUkr = "Ватикан" };
        public static readonly CountryInfo VENEZUELA = new CountryInfo() { CountryISO2Code = "VE", CountryISO3Code = "VEN", CountryISONr = "862", CountryNameEng = "VENEZUELA", CountryNameUkr = "Венесуела" };
        public static readonly CountryInfo VIET_NAM = new CountryInfo() { CountryISO2Code = "VN", CountryISO3Code = "VNM", CountryISONr = "704", CountryNameEng = "VIET_NAM", CountryNameUkr = "В'єтнам" };
        public static readonly CountryInfo VIRGIN_ISLANDS_BRITISH = new CountryInfo() { CountryISO2Code = "VG", CountryISO3Code = "VGB", CountryISONr = "092", CountryNameEng = "VIRGIN_ISLANDS_BRITISH", CountryNameUkr = "Вірґинські острови (Брит.)" };
        public static readonly CountryInfo VIRGIN_ISLANDS_US = new CountryInfo() { CountryISO2Code = "VI", CountryISO3Code = "VIR", CountryISONr = "850", CountryNameEng = "VIRGIN_ISLANDS_US", CountryNameUkr = "Вірґинські острови (США)" };
        public static readonly CountryInfo WALLIS_AND_FUTUNA_ISLANDS = new CountryInfo() { CountryISO2Code = "WF", CountryISO3Code = "WLF", CountryISONr = "876", CountryNameEng = "WALLIS_AND_FUTUNA_ISLANDS", CountryNameUkr = "Острови Валліс і Футуна" };
        public static readonly CountryInfo WESTERN_SAHARA = new CountryInfo() { CountryISO2Code = "EH", CountryISO3Code = "ESH", CountryISONr = "732", CountryNameEng = "WESTERN_SAHARA", CountryNameUkr = "Західна Сахара" };
        public static readonly CountryInfo YEMEN = new CountryInfo() { CountryISO2Code = "YE", CountryISO3Code = "YEM", CountryISONr = "887", CountryNameEng = "YEMEN", CountryNameUkr = "Йємен" };
        public static readonly CountryInfo ZAMBIA = new CountryInfo() { CountryISO2Code = "ZM", CountryISO3Code = "ZMB", CountryISONr = "894", CountryNameEng = "ZAMBIA", CountryNameUkr = "Замбія" };
        public static readonly CountryInfo ZIMBABWE = new CountryInfo() { CountryISO2Code = "ZW", CountryISO3Code = "ZWE", CountryISONr = "716", CountryNameEng = "ZIMBABWE", CountryNameUkr = "Зімбабве" };
        public static readonly CountryInfo GLOBAL = new CountryInfo() { CountryISO2Code = "", CountryISO3Code = "INT", CountryISONr = "000", CountryNameEng = "Global", CountryNameUkr = "Глобальна юрисдикція" };

        public static List<CountryInfo> _allCountries;
        public static List<CountryInfo> AllCountries
        {
            get 
            {
                _allCountries = new List<CountryInfo>();
                #region
                _allCountries.Add(AALAND_ISLANDS);
                _allCountries.Add(AFGHANISTAN);
                _allCountries.Add(ALBANIA);
                _allCountries.Add(ALGERIA);
                _allCountries.Add(AMERICAN_SAMOA);
                _allCountries.Add(ANDORRA);
                _allCountries.Add(ANGOLA);
                _allCountries.Add(ANGUILLA);
                _allCountries.Add(ANTARCTICA);
                _allCountries.Add(ANTIGUA_AND_BARBUDA);
                _allCountries.Add(ARGENTINA);
                _allCountries.Add(ARMENIA);
                _allCountries.Add(ARUBA);
                _allCountries.Add(AUSTRALIA);
                _allCountries.Add(AUSTRIA);
                _allCountries.Add(AZERBAIJAN);
                _allCountries.Add(BAHAMAS);
                _allCountries.Add(BAHRAIN);
                _allCountries.Add(BANGLADESH);
                _allCountries.Add(BARBADOS);
                _allCountries.Add(BELARUS);
                _allCountries.Add(BELGIUM);
                _allCountries.Add(BELIZE);
                _allCountries.Add(BENIN);
                _allCountries.Add(BERMUDA);
                _allCountries.Add(BHUTAN);
                _allCountries.Add(BOLIVIA);
                _allCountries.Add(BOSNIA_AND_HERZEGOWINA);
                _allCountries.Add(BOTSWANA);
                _allCountries.Add(BOUVET_ISLAND);
                _allCountries.Add(BRAZIL);
                _allCountries.Add(BRITISH_INDIAN_OCEAN_TERRITORY);
                _allCountries.Add(BRUNEI_DARUSSALAM);
                _allCountries.Add(BULGARIA);
                _allCountries.Add(BURKINA_FASO);
                _allCountries.Add(BURUNDI);
                _allCountries.Add(CAMBODIA);
                _allCountries.Add(CAMEROON);
                _allCountries.Add(CANADA);
                _allCountries.Add(CAPE_VERDE);
                _allCountries.Add(CAYMAN_ISLANDS);
                _allCountries.Add(CENTRAL_AFRICAN_REPUBLIC);
                _allCountries.Add(CHAD);
                _allCountries.Add(CHILE);
                _allCountries.Add(CHINA);
                _allCountries.Add(CHRISTMAS_ISLAND);
                _allCountries.Add(COCOS_KEELING_ISLANDS);
                _allCountries.Add(COLOMBIA);
                _allCountries.Add(COMOROS);
                _allCountries.Add(CONGO_Democratic_Republic_of_was_Zaire_);
                _allCountries.Add(CONGO_Republic_of);
                _allCountries.Add(COOK_ISLANDS);
                _allCountries.Add(COSTA_RICA);
                _allCountries.Add(COTE_D_IVOIRE);
                _allCountries.Add(CROATIA);
                _allCountries.Add(CUBA);
                _allCountries.Add(CYPRUS);
                _allCountries.Add(CZECH_REPUBLIC);
                _allCountries.Add(DENMARK);
                _allCountries.Add(DJIBOUTI);
                _allCountries.Add(DOMINICA);
                _allCountries.Add(DOMINICAN_REPUBLIC);
                _allCountries.Add(ECUADOR);
                _allCountries.Add(EGYPT);
                _allCountries.Add(EL_SALVADOR);
                _allCountries.Add(EQUATORIAL_GUINEA);
                _allCountries.Add(ERITREA);
                _allCountries.Add(ESTONIA);
                _allCountries.Add(ETHIOPIA);
                _allCountries.Add(FALKLAND_ISLANDS_MALVINAS);
                _allCountries.Add(FAROE_ISLANDS);
                _allCountries.Add(FIJI);
                _allCountries.Add(FINLAND);
                _allCountries.Add(FRANCE);
                _allCountries.Add(FRENCH_GUIANA);
                _allCountries.Add(FRENCH_POLYNESIA);
                _allCountries.Add(FRENCH_SOUTHERN_TERRITORIES);
                _allCountries.Add(GABON);
                _allCountries.Add(GAMBIA);
                _allCountries.Add(GEORGIA);
                _allCountries.Add(GERMANY);
                _allCountries.Add(GHANA);
                _allCountries.Add(GIBRALTAR);
                _allCountries.Add(GREECE);
                _allCountries.Add(GREENLAND);
                _allCountries.Add(GRENADA);
                _allCountries.Add(GUADELOUPE);
                _allCountries.Add(GUAM);
                _allCountries.Add(GUATEMALA);
                _allCountries.Add(GUINEA);
                _allCountries.Add(GUINEA_BISSAU);
                _allCountries.Add(GUYANA);
                _allCountries.Add(HAITI);
                _allCountries.Add(HEARD_AND_MC_DONALD_ISLANDS);
                _allCountries.Add(HONDURAS);
                _allCountries.Add(HONG_KONG);
                _allCountries.Add(HUNGARY);
                _allCountries.Add(ICELAND);
                _allCountries.Add(INDIA);
                _allCountries.Add(INDONESIA);
                _allCountries.Add(IRAN_ISLAMIC_REPUBLIC_OF);
                _allCountries.Add(IRAQ);
                _allCountries.Add(IRELAND);
                _allCountries.Add(ISRAEL);
                _allCountries.Add(ITALY);
                _allCountries.Add(JAMAICA);
                _allCountries.Add(JAPAN);
                _allCountries.Add(JORDAN);
                _allCountries.Add(KAZAKHSTAN);
                _allCountries.Add(KENYA);
                _allCountries.Add(KIRIBATI);
                _allCountries.Add(KOREA_DEMOCRATIC_PEOPLE_S_REPUBLIC_OF);
                _allCountries.Add(KOREA_REPUBLIC_OF);
                _allCountries.Add(KUWAIT);
                _allCountries.Add(KYRGYZSTAN);
                _allCountries.Add(LAO_PEOPLE_S_DEMOCRATIC_REPUBLIC);
                _allCountries.Add(LATVIA);
                _allCountries.Add(LEBANON);
                _allCountries.Add(LESOTHO);
                _allCountries.Add(LIBERIA);
                _allCountries.Add(LIBYAN_ARAB_JAMAHIRIYA);
                _allCountries.Add(LIECHTENSTEIN);
                _allCountries.Add(LITHUANIA);
                _allCountries.Add(LUXEMBOURG);
                _allCountries.Add(MACAU);
                _allCountries.Add(MACEDONIA_THE_FORMER_YUGOSLAV_REPUBLIC_OF);
                _allCountries.Add(MADAGASCAR);
                _allCountries.Add(MALAWI);
                _allCountries.Add(MALAYSIA);
                _allCountries.Add(MALDIVES);
                _allCountries.Add(MALI);
                _allCountries.Add(MALTA);
                _allCountries.Add(MARSHALL_ISLANDS);
                _allCountries.Add(MARTINIQUE);
                _allCountries.Add(MAURITANIA);
                _allCountries.Add(MAURITIUS);
                _allCountries.Add(MAYOTTE);
                _allCountries.Add(MEXICO);
                _allCountries.Add(MICRONESIA_FEDERATED_STATES_OF);
                _allCountries.Add(MOLDOVA_REPUBLIC_OF);
                _allCountries.Add(MONACO);
                _allCountries.Add(MONGOLIA);
                _allCountries.Add(MONTSERRAT);
                _allCountries.Add(MOROCCO);
                _allCountries.Add(MOZAMBIQUE);
                _allCountries.Add(MYANMAR);
                _allCountries.Add(NAMIBIA);
                _allCountries.Add(NAURU);
                _allCountries.Add(NEPAL);
                _allCountries.Add(NETHERLANDS);
                _allCountries.Add(NETHERLANDS_ANTILLES);
                _allCountries.Add(NEW_CALEDONIA);
                _allCountries.Add(NEW_ZEALAND);
                _allCountries.Add(NICARAGUA);
                _allCountries.Add(NIGER);
                _allCountries.Add(NIGERIA);
                _allCountries.Add(NIUE);
                _allCountries.Add(NORFOLK_ISLAND);
                _allCountries.Add(NORTHERN_MARIANA_ISLANDS);
                _allCountries.Add(NORWAY);
                _allCountries.Add(OMAN);
                _allCountries.Add(PAKISTAN);
                _allCountries.Add(PALAU);
                _allCountries.Add(PALESTINIAN_TERRITORY_Occupied);
                _allCountries.Add(PANAMA);
                _allCountries.Add(PAPUA_NEW_GUINEA);
                _allCountries.Add(PARAGUAY);
                _allCountries.Add(PERU);
                _allCountries.Add(PHILIPPINES);
                _allCountries.Add(PITCAIRN);
                _allCountries.Add(POLAND);
                _allCountries.Add(PORTUGAL);
                _allCountries.Add(PUERTO_RICO);
                _allCountries.Add(QATAR);
                _allCountries.Add(REUNION);
                _allCountries.Add(ROMANIA);
                _allCountries.Add(RUSSIAN_FEDERATION);
                _allCountries.Add(RWANDA);
                _allCountries.Add(SAINT_HELENA);
                _allCountries.Add(SAINT_KITTS_AND_NEVIS);
                _allCountries.Add(SAINT_LUCIA);
                _allCountries.Add(SAINT_PIERRE_AND_MIQUELON);
                _allCountries.Add(SAINT_VINCENT_AND_THE_GRENADINES);
                _allCountries.Add(SAMOA);
                _allCountries.Add(SAN_MARINO);
                _allCountries.Add(SAO_TOME_AND_PRINCIPE);
                _allCountries.Add(SAUDI_ARABIA);
                _allCountries.Add(SENEGAL);
                _allCountries.Add(SERBIA_AND_MONTENEGRO);
                _allCountries.Add(SEYCHELLES);
                _allCountries.Add(SIERRA_LEONE);
                _allCountries.Add(SINGAPORE);
                _allCountries.Add(SLOVAKIA);
                _allCountries.Add(SLOVENIA);
                _allCountries.Add(SOLOMON_ISLANDS);
                _allCountries.Add(SOMALIA);
                _allCountries.Add(SOUTH_AFRICA);
                _allCountries.Add(SOUTH_GEORGIA_AND_THE_SOUTH_SANDWICH_ISLANDS);
                _allCountries.Add(SPAIN);
                _allCountries.Add(SRI_LANKA);
                _allCountries.Add(SUDAN);
                _allCountries.Add(SURINAME);
                _allCountries.Add(SVALBARD_AND_JAN_MAYEN_ISLANDS);
                _allCountries.Add(SWAZILAND);
                _allCountries.Add(SWEDEN);
                _allCountries.Add(SWITZERLAND);
                _allCountries.Add(SYRIAN_ARAB_REPUBLIC);
                _allCountries.Add(TAIWAN);
                _allCountries.Add(TAJIKISTAN);
                _allCountries.Add(TANZANIA_UNITED_REPUBLIC_OF);
                _allCountries.Add(THAILAND);
                _allCountries.Add(TIMOR_LESTE);
                _allCountries.Add(TOGO);
                _allCountries.Add(TOKELAU);
                _allCountries.Add(TONGA);
                _allCountries.Add(TRINIDAD_AND_TOBAGO);
                _allCountries.Add(TUNISIA);
                _allCountries.Add(TURKEY);
                _allCountries.Add(TURKMENISTAN);
                _allCountries.Add(TURKS_AND_CAICOS_ISLANDS);
                _allCountries.Add(TUVALU);
                _allCountries.Add(UGANDA);
                _allCountries.Add(UKRAINE);
                _allCountries.Add(UNITED_ARAB_EMIRATES);
                _allCountries.Add(UNITED_KINGDOM);
                _allCountries.Add(UNITED_STATES);
                _allCountries.Add(UNITED_STATES_MINOR_OUTLYING_ISLANDS);
                _allCountries.Add(URUGUAY);
                _allCountries.Add(UZBEKISTAN);
                _allCountries.Add(VANUATU);
                _allCountries.Add(VATICAN_CITY_STATE_HOLY_SEE);
                _allCountries.Add(VENEZUELA);
                _allCountries.Add(VIET_NAM);
                _allCountries.Add(VIRGIN_ISLANDS_BRITISH);
                _allCountries.Add(VIRGIN_ISLANDS_US);
                _allCountries.Add(WALLIS_AND_FUTUNA_ISLANDS);
                _allCountries.Add(WESTERN_SAHARA);
                _allCountries.Add(YEMEN);
                _allCountries.Add(ZAMBIA);
                _allCountries.Add(ZIMBABWE);
                _allCountries.Add(GLOBAL);
                #endregion
                return _allCountries;
            }
        }
        #endregion

        public static CountryInfo MatchCountry(string src)
        {

            foreach (CountryInfo c in AllCountries)
            {
                if (c.CountryNameEng.ToLower().IndexOf(src.ToLower()) == -1 && c.CountryNameUkr.ToLower().IndexOf(src.ToLower()) == -1)
                    continue;
                return c;
            }
            return null;
        }


        [DisplayName]
        [Browsable(false)]
        public string DisplayName
        {
            get
            {
                if (!string.IsNullOrEmpty(CountryNameUkr))
                    return CountryNameUkr;
                if (!string.IsNullOrEmpty(CountryNameEng))
                    return CountryNameEng;
                if (!string.IsNullOrEmpty(CountryISO2Code))
                    return CountryISO2Code;
                if (!string.IsNullOrEmpty(CountryISO3Code))
                    return CountryISO3Code;
                return this.CountryISONr;
            }
        }
        public override string ToString()
        {
            return DisplayName;
        }

        public override bool Equals(object obj)
        {
            //log.Debug("Equals::entering Equals({0})", obj);
            if (((object)this == null) && ((object)obj == null))
            {
                //log.Debug("Equals::both objects are null's");
                return true;
            }

            if (((object)this == null) || ((object)obj == null))
            {
                //log.Debug("Equals::one of the objects is null");
                return false;
            }

            if (obj is CountryInfo)
            {
                //log.Debug("Equals::trying to compare object as CountryInfo");
                return (((CountryInfo)obj).CountryISONr == this.CountryISONr);
            }

            else if (obj is string)
            {
                //log.Debug("Equals::trying to compare object as string");
                return (obj as string) == this.CountryISONr || (obj as string) == this.CountryISO3Code;
            }
            return false;
        }
    }
}
