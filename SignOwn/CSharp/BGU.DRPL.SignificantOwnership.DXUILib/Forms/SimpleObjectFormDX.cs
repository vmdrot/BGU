using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace BGU.DRPL.SignificantOwnership.DXUILib.Forms
{
    public partial class SimpleObjectFormDX : DevExpress.XtraEditors.XtraForm
    {
        public SimpleObjectFormDX()
        {
            InitializeComponent();
        }


        public object DataSource
        {
            get { return propGrid.SelectedObject; }
            set { propGrid.SelectedObject = value; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void SimpleObjectFormDX_Load(object sender, EventArgs e)
        {
            
        }
    }
}