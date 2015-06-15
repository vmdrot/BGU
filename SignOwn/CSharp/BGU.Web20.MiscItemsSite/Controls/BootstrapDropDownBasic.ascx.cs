using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace BGU.Web20.MiscItemsSite.Controls
{
    public partial class BootstrapDropDownBasic : System.Web.UI.UserControl
    {
        #region

        [Browsable(true)]
        public string LabelDisplayName
        {
            get
            {
                return this.lbl.InnerText;
            }
            set
            {
                this.lbl.InnerText = value;
                this.ddl.Attributes["placeholder"] = value;
            }
        }

        [Browsable(true)]
        public string LabelDescription 
        {
            get 
            {
                return this.descr.InnerText;
            }
            set 
            {
                this.descr.InnerText = value;
            }
        }

        [Browsable(true)]
        public string DropDownWidth 
        {
            get
            {
                return this.ddl.Style["width"];
            }
            set
            { this.ddl.Style["width"] = value; }
        }

        [Browsable(true)]
        public string Value
        {
            get
            {
                return this.ddl.SelectedValue;
            }
            set { this.ddl.SelectedValue = value; }
        }

        [Browsable(true)]
        public string DataValueField
        {
            get { return ddl.DataValueField; }
            set { ddl.DataValueField = value; }
        }

        [Browsable(true)]
        public string DataTextField
        {
            get { return ddl.DataTextField; }
            set { ddl.DataTextField = value; }
        }

        [Browsable(true)]
        public string DataTextFormatString
        {
            get { return ddl.DataTextFormatString; }
            set { ddl.DataTextFormatString = value; }
        }

        [Browsable(true)]
        public object DataSource
        {
            get { return ddl.DataSource; }
            set { ddl.DataSource = value; }
        }

        public override void DataBind()
        {
            base.DataBind();
            ddl.DataBind();
        }

        [Browsable(true)]
        public bool AutoPostBack
        {
            get { return ddl.AutoPostBack; }
            set
            {
                if (ddl.AutoPostBack != value)
                {
                    if (value == true)
                        ddl.SelectedIndexChanged += ddl_SelectedIndexChanged;
                    else
                        ddl.SelectedIndexChanged -= ddl_SelectedIndexChanged;
                    ddl.AutoPostBack = value;
                }
            }
        }

        [Browsable(true)]
        public string SelectedValue
        {
            get
            {
                return ddl.SelectedValue;
            }
            set
            {
                ddl.SelectedValue = value;
            }
        }

        protected void ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedIndexChanged == null)
                return;
            SelectedIndexChanged(sender, e);
        }

        [Browsable(true)]
        public event EventHandler SelectedIndexChanged;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}