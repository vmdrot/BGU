using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using System.Windows.Forms;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;

namespace BGU.DRPL.SignificantOwnership.Core.TypeEditors
{
    public class CountryInfoLookupEditor2 : UITypeEditor
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

            // use a combo box - list box is a bit rogue and poorer on usability
            ComboBox cbx = new ComboBox();

            cbx.SelectedValueChanged += OnListBoxSelectedValueChanged;

            cbx.DisplayMember = "DisplayName";
            cbx.ValueMember = "CountryISONr";
            CountryInfo selectedCountry = (CountryInfo)value;
            
            
            var countriesLst = CountryInfo.AllCountries.OrderBy(x => x.CountryNameUkr).ToList();
            cbx.DataSource = countriesLst;
            if (selectedCountry != null)
                cbx.SelectedValue = selectedCountry.CountryISONr;
            else //set default value to Ukraine
                cbx.SelectedValue = CountryInfo.UKRAINE.CountryISONr;

            // show this model stuff
            _editorService.DropDownControl(cbx);
            if (cbx.SelectedItem == null) // no selection, return the passed-in value as is
                return value;

            return cbx.SelectedItem;
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