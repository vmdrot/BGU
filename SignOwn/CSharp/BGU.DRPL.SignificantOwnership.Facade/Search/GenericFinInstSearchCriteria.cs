using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares2;
using Evolvex.Utility.Core.Geo;
using System.ComponentModel;
using BGU.DRPL.SignificantOwnership.Core.Spares;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;

namespace BGU.DRPL.SignificantOwnership.Facade.Search
{
    public class GenericFinInstSearchCriteria : SearchCriteriaBase
    {
        #region const(s)
        private const string Cat_Name = "Назва";
        private const string Cat_TypeKind = "Тип установи";
        private const string Cat_Geo = "Розташування";
        #endregion

        #region prop(s)
        [Category(Cat_Name)]
        [DisplayName("Фрагмент назви чи МФО банку")]
        public string InstitutionSearchText { get; set; }
        [DisplayName("Фрагмент назви чи МФО банку")]
        public string InstitutionTaxCode { get; set; }
        [DisplayName("Рівень установи - головна контора, філія, ТВБВ, тощо")]
        public InstitutionLevel InstLevel { get; set; }
        [Category(Cat_TypeKind)]
        [DisplayName("Тип установи")]
        public FinancialInstitutionType InstType { get; set; }
        [Category(Cat_TypeKind)]
        [DisplayName("Стан установи")]
        public FinancialInstitutionStatus InstStatus { get; set; }
        [Category(Cat_TypeKind)]
        [DisplayName("Форма власності")]
        public CompanyOwnershipType OwnershipType { get; set; }
        [DisplayName("Види діяльності - текст")]
        public string ActivitiesSearchText { get; set; }
        /// <summary>
        /// чекбоксліст, де можна обрати види діяльності
        /// </summary>
        [DisplayName("Види діяльності - перелік")]
        public List<BankingLicensedActivityInfo> Activities { get; set; }
        /// <summary>
        /// Провайдери:
        /// http://api.visicom.ua/ , http://api.visicom.ua/docs/reference/data-queries#search
        /// </summary>
        [DisplayName("Біля точки")]
        [Category(Cat_Geo)]
        public BasicGeoposition NearPoint { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <seealso cref="https://tech.yandex.ru/maps/geocoder/"/>
        [Category(Cat_Geo)]
        [DisplayName("Біля адреси")]
        public string NearAddress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <seealso cref="http://api.visicom.ua/docs/reference/data-queries#search"/>
        [Category(Cat_Geo)]
        [DisplayName("У радіусі (від вказаної точки чи адреси")]
        public double? InRangeKm { get; set; }
        [Category(Cat_Geo)]
        [DisplayName("У тому ж населеному пункті")]
        public bool? InTheSameCity { get; set; }
        [Category(Cat_Geo)]
        [DisplayName("У тому ж районі")]
        public bool? InTheSameRaion { get; set; }
        [Category(Cat_Geo)]
        [DisplayName("У тій же області")]
        public bool? InTheSameOblast { get; set; }
        #endregion
    }
}
