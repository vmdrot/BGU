using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;
using System.Xml.Serialization;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Інформація про зв'язок між двома особами;
    /// використовується для ідентифікації пов'язаних осіб.
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.PersonsAssociation_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class PersonsAssociation : NotifyPropertyChangedBase
    {
        private GenericPersonID _One;
        /// <summary>
        /// обов'язково
        /// </summary>
        [DisplayName("Перша особа")]
        [Description("Перша особа")]
        [Required]
        public GenericPersonID One { get { return _One; } set { _One = value; OnPropertyChanged("One"); } }

        private GenericPersonID _Two;
        /// <summary>
        /// обов'язково, не та ж що й One
        /// </summary>
        [DisplayName("Друга особа")]
        [Description("Друга особа")]
        [Required]
        public GenericPersonID Two { get { return _Two; } set { _Two = value; OnPropertyChanged("Two"); } }

        private OwnershipType _AssociationType;
        /// <summary>
        /// обов'язково
        /// </summary>
        [DisplayName("Тип зв'язку")]
        [Description("Тип зв'язку")]
        [Required]
        public OwnershipType AssociationType { get { return _AssociationType; } set { _AssociationType = value; OnPropertyChanged("AssociationType"); } }

        private AssociatedPersonRole _AssociationRoleOneVsTwo;
        /// <summary>
        /// батько, мати, дружина, кум, зять, брат, сват, і т.д.;
        /// якби існував кінечний перелік, доцільно було б замінити ним
        /// </summary>
        [DisplayName("Ким приходиться перша особа другій")]
        [Description("Назва, ким приходиться перша особа другій")]
        [Required]
        public AssociatedPersonRole AssociationRoleOneVsTwo { get { return _AssociationRoleOneVsTwo; } set { _AssociationRoleOneVsTwo = value; OnPropertyChanged("AssociationRoleOneVsTwo"); OnPropertyChanged("IsOtherRole"); } }

        private AssociatedPersonRole _AssociationRoleTwoVsOne;
        /// <summary>
        /// Віддзеркалення значення AssociationTitleOneVsTwo
        /// син, син, чоловік, кум/кума/похресник/похресниця, тесть/свекор/теща/свекруха, брат/сестра, ..., і т.д.
        /// </summary>
        /// <seealso cref="AssociationTitleOneVsTwo"/>
        [DisplayName("Ким приходиться друга особа першій")]
        [Description("Назва, ким приходиться друга особа першій")]
        [Required]
        public AssociatedPersonRole AssociationRoleTwoVsOne { get { return _AssociationRoleTwoVsOne; } set { _AssociationRoleTwoVsOne = value; OnPropertyChanged("AssociationRoleTwoVsOne"); OnPropertyChanged("IsOtherRole"); } }

        [Browsable(false)]
        [XmlIgnore]
        public bool IsOtherRole { get { return AssociationRoleOneVsTwo ==AssociatedPersonRole.OtherRelative || AssociationRoleTwoVsOne == AssociatedPersonRole.OtherRelative; } }


        private string _AssociationRolesIfOther;
        /// <summary>
        /// опис ролей пов'язаних осіб, якщо в полях AssociationTitleTwoVsOne / AssociationTitleOneVsTwo вказано "Інше..."
        /// </summary>
        /// <seealso cref="AssociationTitleOneVsTwo"/>
        [DisplayName("Ролі осіособи одна одній (якщо інше)")]
        [Description("Ким приходяться особи одна одній (якщо інше)")]
        [Required]
        [UIConditionalVisibility("IsOtherRole")]
        public string AssociationRolesIfOther { get { return _AssociationRolesIfOther; } set { _AssociationRolesIfOther = value; OnPropertyChanged("AssociationRolesIfOther"); } }


        public override string ToString()
        {
            return string.Format("{0} vs {1}, {2} ({3}, {4}, {5})", One, Two, AssociationType, AssociationRoleOneVsTwo, AssociationRoleTwoVsOne, AssociationRolesIfOther);
        }
    }
}
