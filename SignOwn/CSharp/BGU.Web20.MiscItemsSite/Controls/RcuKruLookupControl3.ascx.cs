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
    public partial class RcuKruLookupControl3 : System.Web.UI.UserControl
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

        [Browsable(true)]
        public bool HeadOfficesOnly {get;set;}

        [Browsable(true)]
        public string SkipCategories { get; set; }

        protected void DoBindBanksDDL()
        {
            ddlBk.DataValueField = "MFO";
            ddlBk.DataTextField = "NB";
            if (HeadOfficesOnly || !string.IsNullOrEmpty(SkipCategories))
                ddlBk.DataSource = RcuKruReader.Filter(DataModule.RcuKru, HeadOfficesOnly, new List<string>(SkipCategories.Split(',')));
            else
                ddlBk.DataSource = DataModule.RcuKru;
            ddlBk.DataBind();
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