using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.ImperfectBusinessReputationInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class ImperfectBusinessReputationInfo
    {

        #region cctor(s)
        public ImperfectBusinessReputationInfo()
        { 
            BankruptcyInvestigations = new List<BankruptcyInvestigationInfo>();
            MiscNonRepaidDebts = new List<IndebtnessInfo>();
            BreachesOfLaw = new List<BreachOfLawRecordInfo>();
            LiquidatedSignOwnershipLastYear = new List<LiquidatedEntityOwnershipInfo>();
        }

        #endregion


        [DisplayName("Чи порушувалася справа про банкрутство юридичної особи?")]
        [Description("Чи порушувалася справа про банкрутство юридичної особи?")]
        [Required]
        public bool HadBankruptcyInvestigation { get; set; } //todo - question - resolved (thanks Yaretskyi)

        /// <summary>
        /// 6.1. Деталі порушуваної(-их) справи(справ) про банкрутство юридичної особи
        /// </summary>
        [DisplayName("Деталі порушуваної(-их) справи(справ) про банкрутство юридичної особи")]
        [Description("")]
        [Required("HadBankruptcyInvestigation == true")]
        [UIConditionalVisibility("HadBankruptcyInvestigation")]
        public List<BankruptcyInvestigationInfo> BankruptcyInvestigations { get; set; }

        /// <summary>
        /// 6.2. Чи  має   юридична  особа  невиконані  майнові  (фінансові)  зобов'язання перед іншими особами?
        /// _______________________________________________________________________
        /// </summary>
        [DisplayName("Є невиконані  зобов'язання перед іншими особами?")]
        [Description("Чи  має   юридична  особа  невиконані  майнові  (фінансові)  зобов'язання перед іншими особами?")]
        [Required]
        public bool HasMiscNonRepaidDebts { get; set; }

        /// <summary>
        /// 6.2. Чи  має   юридична  особа  невиконані  майнові  (фінансові)  зобов'язання перед іншими особами?
        /// ________________________________________________________________________________
        ///  (якщо так, то зазначити, які саме зобов'язання, у якому розмірі,
        /// 
        /// _______________________________________________________________________________.
        ///  перед якою особою та з яких причин не були виконані, а також подальші плани
        ///   щодо виконання/невиконання цих зобов'язань)
        /// 
        /// </summary>
        [DisplayName("Невиконані  зобов'язання перед іншими особами - розшифровка")]
        [Description("(зазначити, які саме зобов'язання, у якому розмірі, перед якою особою та з яких причин не були виконані, а також подальші плани щодо виконання/невиконання цих зобов'язань)")]
        [Required("HasMiscNonRepaidDebts == true")]
        [UIConditionalVisibility("HasMiscNonRepaidDebts")]
        public List<IndebtnessInfo> MiscNonRepaidDebts { get; set; }

        /// <summary>
        /// 6.3. Чи  притягувалася  юридична  особа  до  відповідальності  за  порушення антимонопольного,  податкового, банківського, валютного  законодавства, правил діяльності на ринку цінних паперів тощо?
        /// </summary>
        [DisplayName("Були порушення галузевого законодавства?")]
        [Description("Чи  притягувалася  юридична  особа  до  відповідальності  за  порушення антимонопольного,  податкового, банківського, валютного  законодавства, правил діяльності на ринку цінних паперів тощо?")]
        [Required]
        public bool HadIndustrySpecificBreaches { get; set; }

        /// <summary>
        /// 6.3. ________________________________________________________________________________
        ///       (зазначити, коли вчинено порушення, зміст порушення, накладені санкції)
        /// </summary>
        [DisplayName("Порушення галузевого законодавства - деталі")]
        [Description("(зазначити, коли вчинено порушення антимонопольного,  податкового, банківського, валютного  законодавства, правил діяльності на ринку цінних паперів тощо, зміст порушення, накладені санкції)")]
        [Required("HadIndustrySpecificBreaches == true")]
        [UIConditionalVisibility("HadIndustrySpecificBreaches")]
        public List<BreachOfLawRecordInfo> BreachesOfLaw { get; set; }

        /// <summary>
        /// 6.4. Чи була юридична особа протягом останнього року, що передував прийняттю рішення про ліквідацію юридичної особи,  
        /// власником істотної участі (10 і більше відсотків) у цій особі? 
        /// </summary>
        [DisplayName("Були власником ліквідованих юросіб протягом останнього року?")]
        [Description("Чи була юридична особа протягом останнього року, що передував прийняттю рішення про ліквідацію юридичної особи, власником істотної участі (10 і більше відсотків) у цій особі?")]
        [Required]
        public bool HasLiquidatedSignOwnershipLastYear { get; set; }

        /// <summary>
        /// 6.4. __________________________________________________________________________
        ///  (найменування юридичної особи,
        /// 
        /// _______________________________________________________________________________.
        ///  код за ЄДРПОУ, відсоток володіння в ній, докладна інформація про причини та підстави ліквідації)
        /// </summary>
        [DisplayName("Ліквідовані протягом останнього року юрособи у власності")]
        [Description("Протягом останнього року, що передував прийняттю рішення про ліквідацію юридичної особи, власник істотної участі (10 і більше відсотків) у ... (найменування юридичної особи, код за ЄДРПОУ, відсоток володіння в ній, докладна інформація про причини та підстави ліквідації)")]
        [Required("HasLiquidatedSignOwnershipLastYear == true")]
        [UIConditionalVisibility("HasLiquidatedSignOwnershipLastYear")]
        public List<LiquidatedEntityOwnershipInfo> LiquidatedSignOwnershipLastYear { get; set; }
    }
}
