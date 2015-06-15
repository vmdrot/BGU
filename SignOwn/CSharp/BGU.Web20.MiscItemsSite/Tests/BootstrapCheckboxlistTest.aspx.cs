using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BGU.DRPL.SignificantOwnership.Utility;

namespace BGU.Web20.MiscItemsSite.Tests
{
    public partial class BootstrapCheckboxlistTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //cbl.DataSource = EnumType.GetEnumList(typeof(BGU.DRPL.SignificantOwnership.Core.Spares.BankingActivityType));
                cbl.DataSource = EnumType.GetEnumList(typeof(BGU.DRPL.SignificantOwnership.Core.Spares2.FinancialInstitutionType));
                cbl.DataBind();
            }
        }
    }
}