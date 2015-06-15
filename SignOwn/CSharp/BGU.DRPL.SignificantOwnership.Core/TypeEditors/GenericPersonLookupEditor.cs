using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.Design;
using System.Drawing.Design;
using System.Windows.Forms;
using BGU.DRPL.SignificantOwnership.Core.Questionnaires;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;

namespace BGU.DRPL.SignificantOwnership.Core.TypeEditors
{
    public class GenericPersonLookupEditor : UITypeEditor
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

            lb.DisplayMember = "DisplayName";
            lb.ValueMember = "HashID";
            if (TypeEditorsDispatcher.LastQuestionnaire != null && TypeEditorsDispatcher.LastQuestionnaire is IGenericPersonsService)
            {
                IEnumerable<GenericPersonInfo> gpis = ((IGenericPersonsService)TypeEditorsDispatcher.LastQuestionnaire).MentionedGenericPersons;

                
                foreach (GenericPersonInfo gpi in gpis)
                {
                    
                    GenericPersonID gpid = new GenericPersonID() { CountryISO3Code = gpi.ID.CountryISO3Code, DisplayName = gpi.DisplayName, PersonCode = gpi.ID.PersonCode, PersonType = gpi.ID.PersonType };
                    int index = lb.Items.Add(gpid);
                    if (value != null && value is GenericPersonID && (GenericPersonID)value == gpid)
                    {
                        lb.SelectedIndex = index;
                    }
                }
            }
            // show this model stuff
            lb.Refresh();
            _editorService.DropDownControl(lb);
            if (lb.SelectedItem == null) // no selection, return the passed-in value as is
                return value;

            return lb.SelectedItem;
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