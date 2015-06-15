using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;

namespace BGU.DRPL.SignificantOwnership.BasicUILib.Forms
{
    public partial class UltimateOwnersForm : Form
    {
        public UltimateOwnersForm()
        {
            InitializeComponent();
        }

        public List<TotalOwnershipDetailsInfoEx> DataSource
        {
            get 
            {
                return (List<TotalOwnershipDetailsInfoEx>)dgvw.DataSource;
            }
            set 
            {
                dgvw.DataSource = value;
                dgvw.Refresh();
            }
        }

        private void UltimateOwnersForm_Load(object sender, EventArgs e)
        {
            dgvw.AutoGenerateColumns = true;
            dgvw.Refresh();
        }
    }
}
