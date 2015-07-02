using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Універсальна інформація про особу, "обгортка" (wrapper), куди можна "запхати" як юридичну, так і фізичну особу
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.GenericPersonInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class GenericPersonInfo : NotigyPropertyChangedBase
    {
        private EntityType _PersonType = EntityType.Physical;

        [DisplayName("Тип особи")]
        [Description("Тип особи")]
        [Required]
        public EntityType PersonType { get { return _PersonType; } set { _PersonType = value; OnPropertyChanged("PersonType"); OnPropertyChanged("IsPhysical"); OnPropertyChanged("IsLegal"); } }

        private PhysicalPersonInfo _PhysicalPerson;

        /// <summary>
        /// Обов'язкове поле, якщо PersonType == Physical
        /// Інакше - відсутнє!
        /// </summary>
        [DisplayName("Фізична особа")]
        [Description("Фізична особа")]
        [Required("PersonType == EntityType.Physical")]
        [UIConditionalVisibility("IsPhysical")]
        public PhysicalPersonInfo PhysicalPerson { get { return _PhysicalPerson; } set { _PhysicalPerson = value; OnPropertyChanged("PhysicalPerson"); } }

        [Browsable(false)]
        public bool IsPhysical { get { return PersonType == EntityType.Physical; } }


        public LegalPersonInfo _LegalPerson;

        /// <summary>
        /// Обов'язкове поле, якщо PersonType == Legal
        /// Інакше - відсутнє!
        /// </summary>
        [DisplayName("Юридична особа")]
        [Description("Юридична особа")]
        [Required("PersonType == EntityType.Legal")]
        [UIConditionalVisibility("IsLegal")]
        public LegalPersonInfo LegalPerson { get { return _LegalPerson; } set { _LegalPerson = value; OnPropertyChanged("LegalPerson"); } }

        [Browsable(false)]
        public bool IsLegal { get { return PersonType == EntityType.Legal; } }

        public GenericPersonInfo()
        { }

        public GenericPersonInfo(LegalPersonInfo lp)
        {
            this.PersonType = EntityType.Legal;
            this.LegalPerson = lp;
        }
        
        public GenericPersonInfo(PhysicalPersonInfo pp)
        {
            this.PersonType = EntityType.Physical;
            this.PhysicalPerson = pp;
        }

        [Browsable(false)]
        public GenericPersonID ID 
        { 
            get 
            { 
                object o = PersonType == EntityType.Physical ? (object)PhysicalPerson : (object)LegalPerson;
                if(o == null)
                    return null;
                return PersonType == EntityType.Physical ? PhysicalPerson.GenericID : LegalPerson.GenericID;
            } 
        }


        [Browsable(false)]
        public LocationInfo Address
        {
            get
            {
                if (PersonType == EntityType.Legal && LegalPerson != null)
                    return LegalPerson.Address;
                if (PersonType == EntityType.Physical && PhysicalPerson != null)
                    return PhysicalPerson.Address;
                return null;
            }
        }


        public string DisplayName
        {
            get
            {
                object o = PersonType == EntityType.Physical ? (object)PhysicalPerson : (object)LegalPerson;
                if (o == null)
                    return null;
                string rslt = PersonType == EntityType.Physical ? PhysicalPerson.FullName : LegalPerson.Name;
                if (!string.IsNullOrEmpty(rslt))
                    return rslt;
                return this.ID.HashID;
            }
        }

        public override string ToString()
        {
            return DisplayName;
        }
    }
}
