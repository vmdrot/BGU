using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace BGU.Web20.MiscItemsSite.Controls
{
    public partial class BootstrapTextEditBasic : System.Web.UI.UserControl
    {
        #region prop(s)
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
        public int EditSize 
        {
            get
            {
                return this.ed.Size; 
            }
            set { this.ed.Size = value; }
        }

        [Browsable(true)]
        public string EditWidth 
        {
            get
            {
                return this.ed.Style["width"];
            }
            set
            { this.ed.Style["width"] = value; }
        }

        [Browsable(true)]
        public int EditMaxLength
        {
            get
            {
                return this.ed.MaxLength;
            }
            set { this.ed.MaxLength = value; }
        }


        [Browsable(true)]
        public string Value
        {
            get
            {
                return this.ed.Value;
            }
            set { this.ed.Value = value; }
        }

        #endregion



        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            ed.Attributes["placeholder"] = LabelDisplayName;
        }
    }
}