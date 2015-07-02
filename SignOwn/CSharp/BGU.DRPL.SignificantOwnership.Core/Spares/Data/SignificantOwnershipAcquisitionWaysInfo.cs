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
    public class SignificantOwnershipAcquisitionWaysInfo : NotigyPropertyChangedBase
    {
        private bool _IsIPO;

        [DisplayName("придбання акцій (паїв) банку на первинному ринку")]
        [Description("...")]
        [Required]
        public bool IsIPO { get { return _IsIPO; } set { _IsIPO = value; OnPropertyChanged("IsIPO"); } }

        private bool _IsSecondaryMarketPurchase;

        [DisplayName("придбання акцій (паїв) банку на вторинному ринку")]
        [Description("...")]
        [Required]
        public bool IsSecondaryMarketPurchase { get { return _IsSecondaryMarketPurchase; } set { _IsSecondaryMarketPurchase = value; OnPropertyChanged("IsSecondaryMarketPurchase"); OnPropertyChanged("IsSecondaryMarketOrImplicitOwnershipPurchase"); } }

        private bool _IsPurchaseByImplicitOwnership;


        [DisplayName("опосередковане набуття")]
        [Description("набуття/збільшення істотної участі в банку опосередковано шляхом придбання корпоративних прав юридичних осіб у структурі власності банку")]
        [Required]
        public bool IsPurchaseByImplicitOwnership { get { return _IsPurchaseByImplicitOwnership; } set { _IsPurchaseByImplicitOwnership = value; OnPropertyChanged("IsPurchaseByImplicitOwnership"); OnPropertyChanged("IsSecondaryMarketOrImplicitOwnershipPurchase"); } }


        private bool _IsPurchaseByPowOfAtt;
        [DisplayName("набуття за довіренністю")]
        [Description("набуття/збільшення істотної участі в банку у зв’язку з передаванням права голосу за довіреністю;")]
        [Required]
        public bool IsPurchaseByPowOfAtt { get { return _IsPurchaseByPowOfAtt; } set { _IsPurchaseByPowOfAtt = value; OnPropertyChanged("IsPurchaseByPowOfAtt"); } }

        private bool _IsAcquireByImplicitInfluence;

        [DisplayName("набуття через здійснення впливу")]
        [Description("набуття опосередкованої істотної участі в банку у зв’язку із здійсненням значного або вирішального впливу на управління та діяльність банку незалежно від формального володіння")]
        [Required]
        public bool IsAcquireByImplicitInfluence { get { return _IsAcquireByImplicitInfluence; } set { _IsAcquireByImplicitInfluence = value; OnPropertyChanged("IsAcquireByImplicitInfluence"); } }

        //[NotifyParentProperty(true)]
        [Browsable(false)]
        public bool IsSecondaryMarketOrImplicitOwnershipPurchase { get { return IsSecondaryMarketPurchase == true || IsPurchaseByImplicitOwnership == true; } }

     
    }
}
