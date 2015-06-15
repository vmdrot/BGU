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
    public class BooleanEditor : UITypeEditor
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

            List<BooleanUkrValue> ds = new List<BooleanUkrValue>();
            ds.Add(new BooleanUkrValue() { Value = true, DisplayValue = "Так" });
            ds.Add(new BooleanUkrValue() { Value = false, DisplayValue = "Ні" });
            lb.DisplayMember = "Value";
            lb.ValueMember = "DisplayValue";

            foreach (BooleanUkrValue e in ds)
            {
                    
                int index = lb.Items.Add(e);
                if (value != null && value is bool && (bool)value == e.Value)
                {
                    lb.SelectedIndex = index;
                }
            }
            // show this model stuff
            _editorService.DropDownControl(lb);
            if (lb.SelectedItem == null) // no selection, return the passed-in value as is
                return value;

            return ((BooleanUkrValue)lb.SelectedItem).Value;
        }

        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.None;
        }

        private void OnListBoxSelectedValueChanged(object sender, EventArgs e)
        {
            // close the drop down as soon as something is clicked
            _editorService.CloseDropDown();
        }

        #region inner type(s)
        public class BooleanUkrValue
        {
            public bool Value { get; set; }
            public string DisplayValue { get; set; }
        }
        #endregion
    }
}

