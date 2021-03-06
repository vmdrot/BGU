﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Misc;
using System.ComponentModel;
using System.Xml.Serialization;
using Evolvex.Utility.Core.ComponentModelEx;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Універсальний ідентифікатор особи (як юр., так і фізичної)
    /// (щоб не "таскати", себто, не дублювати, усі реквізити особи там, де потребується просто послатися на ту особу).
    /// Використовується (зокрема) для ідентифікації:
    ///  - об'єкту власності та власника - при розкритті ланцюжка кінцевих власників
    ///  - членів колегіального керівного органу;
    ///  - виданої гарантії/поручительства);
    ///  - тощо.
    /// </summary>
    //[XamlTemplateName("GenericPersonID_ManualTemplate.xaml")]
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.GenericPersonLookupEditor), typeof(System.Drawing.Design.UITypeEditor))]
    [XamlExpanderWrapping(false)]
    [UIUsageComboAddButton(AddNewItemCommand = "local:MyCommands.AddMentionedPersonCommand", DisplayMember = "DisplayName", ItemGetterFull = "localdata:DataModule.CurrentMentionedIdentities", ValueMember = "ID", ValueMemberUsageMode = ComboUIValueUsageMode.ValueProperty, Width = "250", ContainerOrientation = Orientation.Vertical)]
    public class GenericPersonID
    {
        /// <summary>
        /// Код країни резидентності
        /// </summary>
        /// <seealso cref="CountryInfo"/>
        [Required]
        [UIUsageComboAttribute(DisplayMember = "CountryNameUkr", ItemsGetterClass = typeof(CountryInfo), ItemsGetterMemberPath = "AllCountries", ValueMember = "CountryISONr", Width = "175")]
        public string CountryISO3Code { get; set; }
        /// <summary>
        /// Тип особи
        /// </summary>
        [Required]
        public EntityType PersonType { get; set; }
        /// <summary>
        /// Код особи;
        /// Для юр.особи - TaxCodeOrHandelsRegNr
        /// Для фіз.особи:
        /// якщо (не пустий TaxOrSocSecID ) - то TaxOrSocSecID 
        /// інакше - PassportID
        /// </summary>
        [Required]
        public string PersonCode { get; set; }

        #region Extra members
        [Browsable(false)]
        [XmlIgnore]
        public string DisplayName
        {
            get;
            set;
        }


        private string _hashId;
        public string HashID
        {
            get
            {
                if (_hashId == null)
                    _hashId = string.Format("{0}-{1}-{2}", CountryISO3Code, PersonType, PersonCode);
                return _hashId;
            }
        }

        public static readonly GenericPersonID Empty = new GenericPersonID() { CountryISO3Code = string.Empty, PersonType = EntityType.None, PersonCode = string.Empty };

        [Browsable(false)]
        public bool IsEmpty
        {
            get
            {
                return string.IsNullOrEmpty(this.CountryISO3Code) && this.PersonType == EntityType.None && string.IsNullOrEmpty(this.PersonCode);
            }
        }

        public static bool operator ==(GenericPersonID one, GenericPersonID two)
        {
            if ((object)one == null && (object)two == null)
                return true;
            if ((object)one == null || (object)two == null)
                return false;
            if (!Utils.AreStringsEqual(one.CountryISO3Code, two.CountryISO3Code)
                || one.PersonType != two.PersonType
                || !Utils.AreStringsEqual(one.PersonCode, two.PersonCode))
                return false;
            return true;
        }

        public static bool operator !=(GenericPersonID one, GenericPersonID two)
        {
            if ((object)one == null && (object)two == null)
                return false;
            if ((object)one == null || (object)two == null)
                return true;
            if (!Utils.AreStringsEqual(one.CountryISO3Code, two.CountryISO3Code)
                || one.PersonType != two.PersonType
                || !Utils.AreStringsEqual(one.PersonCode, two.PersonCode))
                return true;
            return false;
        }

        public override string ToString()
        {
            return (!string.IsNullOrEmpty(DisplayName) ? DisplayName : HashID);
        }


        public override bool Equals(object obj)
        {
            if ((object)this == null && (object)obj == null)
                return true;
            if ((object)this == null || (object)obj == null)
                return false;
            if (!(obj is GenericPersonID))
                return false;
            return (this == (GenericPersonID)obj);
        }

        public override int GetHashCode()
        {
            return HashID.GetHashCode();
        }
        #endregion
    }
}
