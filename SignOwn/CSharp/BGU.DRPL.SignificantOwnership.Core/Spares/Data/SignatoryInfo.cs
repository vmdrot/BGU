using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Інформація про підписанта (документу, анкети)
    /// - розширена версія
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.SignatoryInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class SignatoryInfo : SignatoryInfoBase
    {
        public SignatoryInfo()
        {
        }

        [DisplayName("За довіреністю?")]
        [Description("Підписант діє на підставі довіреності")]
        [Required]
        [DefaultValue(false)]
        public bool IsActingByPowOfAttorney { get; set; }

        [DisplayName("Довіреність")]
        [Description("Реквізити довіреності, на підставі якої діє підписант")]
        [Required("IsActingByPowOfAttorney == true")]
        [UIConditionalVisibility("IsActingByPowOfAttorney")]
        public PowerOfAttorneyInfo PowerOfAttorney { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}, {2}", SignatoryPosition, SurnameInitials, DateSigned);
        }
    }
}
