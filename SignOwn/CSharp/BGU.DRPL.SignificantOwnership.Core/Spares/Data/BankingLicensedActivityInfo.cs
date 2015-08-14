using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using BGU.DRPL.SignificantOwnership.Utility;
using System.Xml.Serialization;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Інформація вид банківської діяльності/фін. послугу
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.BankingLicensedActivityInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class BankingLicensedActivityInfo
    {
        [DisplayName("Тип")]
        [Description("Вкажіть, це буде вид банківської діяльності чи послуга")]
        public LicensedOperationType BankActivityOrService { get; set; }
        
        /// <summary>
        /// Заповнювати або це поле, або ж ServiceType
        /// (але не обидва одразу).
        /// Одне з цих полів, де жорстко обмежується фантазія банку, є обов'язковим; 
        /// У текстовому полі хай пишуть власну інтерпретацію (якщо захочуть), але первинною
        /// є ідентифікація виду діяльності чи послуг згідно з однозначним переліком, що
        /// його прописано у законодавстві
        /// </summary>
        [DisplayName("Вид банківської діяльності")]
        [Description("Вид банківської діяльності зг. зі ст.47 з-ну про Банки й банківську діяльність")]
        public BankingActivityType ActivityType { get; set; }
        /// <summary>
        /// Заповнювати або це поле, або ж ActivityType 
        /// </summary>
        /// <seealso cref="ActivityType"/>
        [DisplayName("Вид фінансових послуг")]
        [Description("Вид фінансових послуг зг. зі ст. 4 з-ну Про фінансові послуги")]
        public FinancialServicesType ServiceType { get; set; }

        [Browsable(false)]
        [XmlIgnore]
        public String ActivityDisplayName
        {
            get
            {
                return (BankActivityOrService == Core.Spares.LicensedOperationType.BankingActivity ? EnumType.GetEnumDescription(ActivityType) : EnumType.GetEnumDescription(ServiceType));
            }
        }
        /// <summary>
        /// Власна вільна інтерпретація чи примітки/опис виду діяльності (якщо є чим доповнити поле ActivityType чи ServiceType
        /// </summary>
        /// <seealso cref="ActivityType"/>
        [DisplayName("Вид діяльності - власна інтерпретація")]
        [Description("Власна назва та/або опис виду діяльності")]
        public string ActivityName { get; set; }

        public override string ToString()
        {
            return ActivityName;
        }
    }
}
