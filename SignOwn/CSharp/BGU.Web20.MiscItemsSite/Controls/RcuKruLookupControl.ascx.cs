using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxEditors;
using BGU.DRPL.SignificantOwnership.Utility;
using BGU.Web20.MiscItemsSite.Facade;

namespace BGU.Web20.MiscItemsSite.Controls
{
    public partial class RcuKruLookupControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cbx_OnItemsRequestedByFilterCondition(object source, ListEditItemsRequestedByFilterConditionEventArgs e)
        {
            ASPxComboBox comboBox = (ASPxComboBox)source;
            comboBox.DataSource = RcuKruReader.Search(DataModule.RcuKru, e.Filter);
            comboBox.DataBind();
        }

        protected void cbx_OnItemRequestedByValue(object source, ListEditItemRequestedByValueEventArgs e)
        {
            long value = 0;
            if (e.Value == null || !Int64.TryParse(e.Value.ToString(), out value))
                return;
            ASPxComboBox comboBox = (ASPxComboBox)source;
            comboBox.DataSource = RcuKruReader.Search(DataModule.RcuKru, value.ToString());
            comboBox.DataBind();
        }
    }
}