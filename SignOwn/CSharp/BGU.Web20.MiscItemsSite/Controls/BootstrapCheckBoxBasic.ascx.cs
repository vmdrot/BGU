using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace BGU.Web20.MiscItemsSite.Controls
{
    /// <summary>
    /// More examples at:
    /// http://bootsnipp.com/snippets/featured/checkboxradio-css-only
    /// http://getbootstrap.com/css/#forms
    /// http://bootsnipp.com/snippets/featured/animated-radios-amp-checkboxes-nojs
    /// http://bootsnipp.com/snippets/featured/checked-list-group
    /// </summary>
    public partial class BootstrapCheckBoxBasic : System.Web.UI.UserControl
    {
        [Browsable(true)]
        public bool Checked
        {
            get { return chk.Checked; }
            set { chk.Checked = value; }
        }

        [Browsable(true)]
        public string Text
        {
            get { return txt.Text; }
            set { txt.Text = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}