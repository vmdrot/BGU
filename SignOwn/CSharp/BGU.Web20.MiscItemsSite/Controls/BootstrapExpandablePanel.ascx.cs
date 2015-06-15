using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace BGU.Web20.MiscItemsSite.Controls
{
    public partial class BootstrapExpandablePanel : System.Web.UI.UserControl //, IPostBackDataHandler, INamingContainer
    {
        private ITemplate _templateValue;

        [Browsable(true)]
        public string Caption
        {
            get { return txt.Text; }
            set { txt.Text = value; }
        }

        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TemplateContainer(typeof(BootstrapExpandablePanel))]
        public ITemplate Template
        {
            get
            {
                return _templateValue;
            }
            set
            {
                _templateValue = value;
            }
        }

        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            ITemplate template = _templateValue;
            if (template != null)
            {
                template.InstantiateIn(ph);
            }
            else
            {
                ph.Controls.Add(new LiteralControl("Need to define template"));
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //public bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        //{
        //    throw new NotImplementedException();
        //}

        //public void RaisePostDataChangedEvent()
        //{
        //    throw new NotImplementedException();
        //}
    }
}