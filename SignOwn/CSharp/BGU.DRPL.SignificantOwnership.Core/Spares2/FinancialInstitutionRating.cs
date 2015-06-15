using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BGU.DRPL.SignificantOwnership.Core.Spares2
{
    public class FinancialInstitutionRating
    {
        /// <summary>
        /// http://bankografo.com/analiz-bankiv/reyting-bankiv/kredytni-reytingi-bankiv
        /// =>
        /// http://ucra.com.ua/ru/ratings/download-ratings?per-page=10&active=quick_search&orderBy=createDt&sortOrder=DESC&filter[sector_id][]=3&page=4
        /// https://www.fitchratings.com/
        /// https://www.standardandpoors.com/
        /// https://www.moodys.com/
        /// 
        /// </summary>
        public string RatingName { get; set; }
        public string RatingValue { get; set; }
    }
}
