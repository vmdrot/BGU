using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxEditors;
using BGU.DRPL.SignificantOwnership.Utility;
using BGU.Web20.MiscItemsSite.Facade;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;
using System.Data;
using System.ComponentModel;

namespace BGU.Web20.MiscItemsSite.Controls
{
    public partial class RcuKruLookupControl2 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DoBindBanksDDL();
            }

        }

        [Browsable(true)]
        public bool AutoPostBack 
        {
            get { return ddlBk.AutoPostBack; } 
            set 
            {
                if (ddlBk.AutoPostBack != value)
                {
                    if (value == true)
                        ddlBk.SelectedIndexChanged += ddlBkSelectedIndexChanged;
                    else
                        ddlBk.SelectedIndexChanged -= ddlBkSelectedIndexChanged;
                    ddlBk.AutoPostBack = value;
                }
            } 
        }

        protected void DoBindBanksDDL()
        {

            //List<BankInfo> ds = new List<BankInfo>();
            //foreach (DataRow dr in DataModule.RcuKru.Rows)
            //{
            //    try { ds.Add(BankInfo.ParseFromRcuKruRow(dr)); }
            //    catch { }
 
            //}
            //ddlBk.DataValueField = "HeadMFO";
            //ddlBk.DataTextField = "Name";
            //ddlBk.DataSource = ds;
            //ddlBk.DataBind();
            ddlBk.DataValueField = "MFO";
            ddlBk.DataTextField = "NB";
            ddlBk.DataSource = DataModule.RcuKru;
            ddlBk.DataBind();

        }

        [Browsable(true)]
        public string SelectedMFO
        {
            get
            {
                return ddlBk.SelectedValue;
            }
            set
            {
                ddlBk.SelectedValue = value;
            }
        }

        protected void ddlBkSelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedMFOChanged == null)
                return;
            SelectedMFOChanged(sender, e);
        }

        [Browsable(true)]
        public event EventHandler SelectedMFOChanged;

    }
}