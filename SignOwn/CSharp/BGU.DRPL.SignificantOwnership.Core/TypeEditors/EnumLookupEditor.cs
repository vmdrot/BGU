using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using System.Windows.Forms;
using BGU.DRPL.SignificantOwnership.Utility;

namespace BGU.DRPL.SignificantOwnership.Core.TypeEditors
{
    public class EnumLookupEditor : UITypeEditor
    {

        public override bool IsDropDownResizable
        {
            get
            {
                return true;
            }
        }


        private IWindowsFormsEditorService _editorService;
        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            _editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

            // use a list box
            ListBox lb = new ListBox();
            lb.SelectionMode = SelectionMode.One;
            lb.SelectedValueChanged += OnListBoxSelectedValueChanged;

            lb.DisplayMember = "Value";
            lb.ValueMember = "EnumValue";
                List<EnumType> lst = EnumType.GetEnumList(value.GetType(),false);
                foreach (EnumType e in lst)
                {
                    
                    int index = lb.Items.Add(e);
                    if (value != null && value is Enum && (Enum)value == e.EnumValue)
                    {
                        lb.SelectedIndex = index;
                    }
                }
            // show this model stuff
            _editorService.DropDownControl(lb);
            if (lb.SelectedItem == null) // no selection, return the passed-in value as is
                return value;

            return ((EnumType)lb.SelectedItem).EnumValue;
        }

        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        private void OnListBoxSelectedValueChanged(object sender, EventArgs e)
        {
            // close the drop down as soon as something is clicked
            _editorService.CloseDropDown();
        }
    }
}

