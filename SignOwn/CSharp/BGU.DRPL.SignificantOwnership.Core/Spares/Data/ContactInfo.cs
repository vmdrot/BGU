using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;
using System.ComponentModel;
using Evolvex.Utility.Core.ComponentModelEx;
using BGU.DRPL.SignificantOwnership.Utility;

namespace BGU.DRPL.SignificantOwnership.Core.Spares.Data
{
    /// <summary>
    /// Контактна інформація 
    /// </summary>
    [System.ComponentModel.Editor(typeof(BGU.DRPL.SignificantOwnership.Core.TypeEditors.ContactInfo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
    public class ContactInfo : ContactInfoBase
    {
        public ContactInfo() :base ()
        {
            Person = new PhysicalPersonInfo();
            ReflectionUtil.InstantiateAllProps(Person, Person.GetType().Assembly);
            Person.IsResidentialAndRegistrationAddressDifferent = true;
        }

        /// <summary>
        /// Необов'язкове поле; якщо заповнюється, то достатньо (як правило) П.І.Б.; як вони хочуть, щоб до них зверталися (хоч би й лише Name),
        /// напр. "Люда, тел. XXX-XXX-XX-XX, e-mail..."
        /// </summary>
        [DisplayName("Контактна особа")]
        [Description("Контактна особа (фізособа)")]
        [UIPartialFieldsVisibility(ShowOrHide=true, PropsList="FullName")]
        public PhysicalPersonInfo Person { get; set; }

        public override string ToString()
        {
            StringBuilder rslt = new StringBuilder();
            int i = 0;
            if (Person != null)
            {
                rslt.Append(Person.ToString());
                i++;
            }
            string baseToStr = base.ToString();
            if (string.IsNullOrEmpty(baseToStr))
            {
                if (i > 0)
                    rslt.Append(", ");
                rslt.Append(baseToStr);
                i++;
            }
            return rslt.ToString();
        }
    }
}
