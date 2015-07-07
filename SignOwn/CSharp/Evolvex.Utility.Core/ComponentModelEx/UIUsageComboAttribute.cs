using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.ComponentModel;

namespace Evolvex.Utility.Core.ComponentModelEx
{
    public class UIUsageComboAttribute : Attribute
    {

        public string DisplayMember { get; set; }
        public ComboUIValueUsageMode ValueMemberUsageMode { get; set; }
        public string ValueMember { get; set; }
        public Type ItemsGetterClass {get;set;}
        public string ItemsGetterMemberPath {get;set;}
        public string Width { get; set; }
        public string ToolTipMember { get; set; }
        [DefaultValue(Orientation.Horizontal)]
        public Orientation ContainerOrientation { get; set; }
        public UIUsageComboAttribute() : base() { }

        public UIUsageComboAttribute(Type itemsGetterClass, string itemsGetterMemberPath, string displayMember, ComboUIValueUsageMode valueMemberUsageMode, string valueMember)
            : base()
        {
            this.ItemsGetterClass = itemsGetterClass;
            this.ItemsGetterMemberPath = itemsGetterMemberPath;
            this.DisplayMember = displayMember;
            this.ValueMemberUsageMode = valueMemberUsageMode;
            this.ValueMember = valueMember;
        }

        public UIUsageComboAttribute(Type itemsGetterClass, string itemsGetterMemberPath, string displayMember, string valueMember)
            : this(itemsGetterClass, itemsGetterMemberPath, displayMember, ComboUIValueUsageMode.ValueProperty, valueMember)
        {}

        public UIUsageComboAttribute(Type itemsGetterClass, string itemsGetterMemberPath, string displayMember, ComboUIValueUsageMode valueMemberUsageMode) 
            : this(itemsGetterClass, itemsGetterMemberPath, displayMember, valueMemberUsageMode, string.Empty) 
        {}

        //public override string ToString()
        //{
        //    return string.Format("", this.DisplayMember, this.ValueMemberUsageMode , this.ValueMember, this.ItemsGetterClass, this.ItemsGetterMemberPath, this.Width);
        //}
    }
}
