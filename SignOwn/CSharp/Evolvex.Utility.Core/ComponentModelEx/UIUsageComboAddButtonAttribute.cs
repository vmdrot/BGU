using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolvex.Utility.Core.ComponentModelEx
{
    public class UIUsageComboAddButtonAttribute : Attribute
    {
        public string DisplayMember { get; set; }
        public ComboUIValueUsageMode ValueMemberUsageMode { get; set; }
        public string ValueMember { get; set; }
        public Type ItemsGetterClass {get;set;}
        public string ItemsGetterMemberPath {get;set;}
        public string ItemGetterFull { get; set; }
        public string AddNewItemCommand { get; set; }
        public string Width { get; set; }
        public string ToolTipMember { get; set; }

        public UIUsageComboAddButtonAttribute() : base() { }

        //public UIUsageComboAddButtonAttribute(Type itemsGetterClass, string itemsGetterMemberPath, string displayMember, ComboUIValueUsageMode valueMemberUsageMode, string valueMember)
        //    : base()
        //{
        //    this.ItemsGetterClass = itemsGetterClass;
        //    this.ItemsGetterMemberPath = itemsGetterMemberPath;
        //    this.DisplayMember = displayMember;
        //    this.ValueMemberUsageMode = valueMemberUsageMode;
        //    this.ValueMember = valueMember;
        //}

        //public UIUsageComboAddButtonAttribute(Type itemsGetterClass, string itemsGetterMemberPath, string displayMember, string valueMember)
        //    : this(itemsGetterClass, itemsGetterMemberPath, displayMember, ComboUIValueUsageMode.ValueProperty, valueMember)
        //{}

        //public UIUsageComboAddButtonAttribute(Type itemsGetterClass, string itemsGetterMemberPath, string displayMember, ComboUIValueUsageMode valueMemberUsageMode) 
        //    : this(itemsGetterClass, itemsGetterMemberPath, displayMember, valueMemberUsageMode, string.Empty) 
        //{}
    }
}
