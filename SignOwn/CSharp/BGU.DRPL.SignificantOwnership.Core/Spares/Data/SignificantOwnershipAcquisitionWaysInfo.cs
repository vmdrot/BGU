using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Способи, у які відбуватиметься набуття/збільшення істотної участі в банку:
    /// 
    /// - придбання акцій (паїв) банку на первинному ринку;
    /// - придбання акцій (паїв) банку на вторинному ринку;
    /// - набуття/збільшення істотної участі в банку опосередковано шляхом придбання корпоративних прав юридичних осіб у структурі власності банку;
    /// - набуття/збільшення істотної участі в банку у зв’язку з передаванням права голосу за довіреністю;
    /// - набуття опосередкованої істотної участі в банку у зв’язку із здійсненням значного або вирішального впливу на управління та діяльність банку незалежно від формального володіння. 
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.SignificantOwnershipAcquisitionWaysInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class SignificantOwnershipAcquisitionWaysInfo
    {
        [DisplayName("придбання акцій (паїв) банку на первинному ринку")]
        [Description("...")]
        [Required]
        public bool IsIPO { get; set; }
        [DisplayName("придбання акцій (паїв) банку на вторинному ринку")]
        [Description("...")]
        [Required]
        public bool IsSecondaryMarketPurchase { get; set; }
        [DisplayName("опосередковане набуття")]
        [Description("набуття/збільшення істотної участі в банку опосередковано шляхом придбання корпоративних прав юридичних осіб у структурі власності банку")]
        [Required]
        public bool IsPurchaseByImplicitOwnership { get; set; }
        [DisplayName("набуття за довіренністю")]
        [Description("набуття/збільшення істотної участі в банку у зв’язку з передаванням права голосу за довіреністю;")]
        [Required]
        public bool IsPurchaseByPowOfAtt { get; set; }
        [DisplayName("набуття через здійснення впливу")]
        [Description("набуття опосередкованої істотної участі в банку у зв’язку із здійсненням значного або вирішального впливу на управління та діяльність банку незалежно від формального володіння")]
        [Required]
        public bool IsAcquireByImplicitInfluence { get; set; }
    }
}
