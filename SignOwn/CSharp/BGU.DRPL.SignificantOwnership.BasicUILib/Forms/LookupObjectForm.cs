using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BGU.DRPL.SignificantOwnership.Core.TypeEditors;

namespace BGU.DRPL.SignificantOwnership.BasicUILib.Forms
{
    public partial class LookupObjectForm<T> : Form, IDataSourcedForm<T>
    {
        public LookupObjectForm()
        {
            InitializeComponent();
        }


        private void rbExisting_CheckedChanged(object sender, EventArgs e)
        {
            rbExistingNewCheckedChangedCommon();
        }

        private void rbExistingNewCheckedChangedCommon()
        {
            propGrid.Enabled = rbNew.Checked;
            cbxSelectExistingObj.Enabled = rbExisting.Checked;
        }

        private IEnumerable<T> _listSource;
        public IEnumerable<T> ListSource
        {
            get 
            {
                return _listSource;
            }
            set 
            {
                _listSource = value;
                if (ListSource != null)
                    BindCombo();
            }
        }



        public T DataSource
        {
            get
            {
                if (rbExisting.Checked)
                    return (T)cbxSelectExistingObj.SelectedValue;
                if (rbNew.Checked)
                    return (T)propGrid.SelectedObject;
                return (T)(object)null;
            }
            set
            {
                for(int i = 0; i < cbxSelectExistingObj.Items.Count; i++)
                {
                    if (this.Compare((T)cbxSelectExistingObj.Items[i], value))
                    {
                        cbxSelectExistingObj.SelectedIndex = i;
                        break;
                    }
                }
                propGrid.SelectedObject = value;                
            }
        }

        private bool Compare(T one, T two)
        {
            if (NeedToCompareObjects == null)
                return false;
            NeedToCompareTypesArgs<T> args = new NeedToCompareTypesArgs<T>(one, two);
            NeedToCompareObjects(this, args);
            return args.AreEqual;
        }

        public event NeedToCompareTypesHandler<T> NeedToCompareObjects;

        private void LookupObjectForm_Load(object sender, EventArgs e)
        {
            if (ListSource != null && ListSource.Count() > 0)
                rbExisting.Checked = true;
            else
                rbNew.Checked = true;

            if (DataSource == null)
                btnFillObject_Click(this, new EventArgs());
        }

        private void BindCombo()
        {
            cbxSelectExistingObj.DataSource = _listSource;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void cbxSelectExistingObj_SelectedIndexChanged(object sender, EventArgs e)
        {
            propGrid.SelectedObject = cbxSelectExistingObj.SelectedItem;
        }

        private T InstantiateNewDataSource()
        {
            object o = Activator.CreateInstance(typeof(T));
            return (T)o;
        }

        private void btnFillObject_Click(object sender, EventArgs e)
        {
            DataSource = InstantiateNewDataSource();
        }

        public event FormCloseHandler<T> FormClose;
    }
}
