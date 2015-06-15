using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BGU.DRPL.SignificantOwnership.Core.Questionnaires;
using BGU.DRPL.SignificantOwnership.Core.Spares.Data;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;

namespace BGU.DRPL.SignificantOwnership.UI.Questionnaires
{
    public partial class Appx2OwnStruLPFrm : Form
    {
        public Appx2OwnStruLPFrm()
        {
            InitializeComponent();
        }

        public Appx2OwnershipStructLP Datasource
        {
            get
            {
                return (Appx2OwnershipStructLP)propsGrid.SelectedObject;
            }
            set
            {
                propsGrid.SelectedObject = value;
            }
        }
        public GenericPersonInfo GenericPersonDS
        {
            get
            {
                return (GenericPersonInfo)propsGrid.SelectedObject;
            }
            set
            {
                propsGrid.SelectedObject = value;
            }
        }
        public LegalPersonInfo LegalPersonDS
        {
            get
            {
                return (LegalPersonInfo)propsGrid.SelectedObject;
            }
            set
            {
                propsGrid.SelectedObject = value;
            }
        }
        public LocationInfo AddressDS
        {
            get
            {
                return (LocationInfo)propsGrid.SelectedObject;
            }
            set
            {
                propsGrid.SelectedObject = value;
            }
        }
        public CountryInfo CountryDS
        {
            get
            {
                return (CountryInfo)propsGrid.SelectedObject;
            }
            set
            {
                propsGrid.SelectedObject = value;
            }
        }
    }
}
