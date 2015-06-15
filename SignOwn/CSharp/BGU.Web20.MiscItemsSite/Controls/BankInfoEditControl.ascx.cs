using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BGU.DRPL.SignificantOwnership.Core.Spares.Dict;
using BGU.Web20.MiscItemsSite.Facade;
using System.Data;
using BGU.DRPL.SignificantOwnership.Utility;

namespace BGU.Web20.MiscItemsSite.Controls
{
    public partial class BankInfoEditControl : System.Web.UI.UserControl
    {

        private class BankInfoUIDispNames
        {
            public string DisplayName { get; set; }
            public string Description { get; set; }
            public string MFOWidth { get; set; }
            public int MFOMaxLength { get; set; }
            public bool ShowRegistryNr { get; set; }
            public bool ShowCode { get; set; }
            public bool ShowNameUkr { get; set; }
            public bool ShowSwift { get; set; }
        }

        private static readonly Dictionary<string, BankInfoUIDispNames> _UIByCountries;

        static BankInfoEditControl()
        {
            _UIByCountries = new Dictionary<string, BankInfoUIDispNames>();

            #region populating country-specific data
            _UIByCountries.Add(CountryInfo.UKRAINE.CountryISONr, new BankInfoUIDispNames() { Description = "МФО", DisplayName = "МФО", MFOMaxLength=6, MFOWidth="25%", ShowCode=true, ShowNameUkr = false, ShowRegistryNr = true, ShowSwift = false});
            _UIByCountries.Add(CountryInfo.GERMANY.CountryISONr, new BankInfoUIDispNames() { Description = "Bankleitzahl", DisplayName = "Національний кліринговий код - Bankleitzahl", MFOMaxLength = 8, MFOWidth = "30%", ShowCode = false, ShowNameUkr = true, ShowRegistryNr = false, ShowSwift = true });
            _UIByCountries.Add(CountryInfo.AUSTRIA.CountryISONr, new BankInfoUIDispNames() { Description = "Bankleitzahl", DisplayName = "Національний кліринговий код - Bankleitzahl", MFOMaxLength = 8, MFOWidth = "30%", ShowCode = false, ShowNameUkr = true, ShowRegistryNr = false, ShowSwift = true });
            _UIByCountries.Add(CountryInfo.ITALY.CountryISONr, new BankInfoUIDispNames() { Description = "Codigo bancario", DisplayName = "Національний кліринговий код - Codigo bancario", MFOMaxLength = 12, MFOWidth = "35%", ShowCode = false, ShowNameUkr = true, ShowRegistryNr = false, ShowSwift = true });
            _UIByCountries.Add(CountryInfo.UNITED_KINGDOM.CountryISONr, new BankInfoUIDispNames() { Description = "Sorted CHAPS code", DisplayName = "Національний кліринговий код - Sorted CHAPS code", MFOMaxLength = 6, MFOWidth = "30%", ShowCode = false, ShowNameUkr = true, ShowRegistryNr = false, ShowSwift = true });
            _UIByCountries.Add(string.Empty, new BankInfoUIDispNames() { Description = "Національний кліринговий код", DisplayName = "Національний кліринговий код (типу Code Guichet/Bankleitzahl/FedWire/тощо)", MFOMaxLength = 20, MFOWidth = "50%", ShowCode = false, ShowNameUkr = true, ShowRegistryNr = false, ShowSwift = true });
            #endregion
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Page.LoadComplete += new EventHandler(Page_LoadComplete);
        }

        void Page_LoadComplete(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(hdATb.Value))
                SetActiveTab(hdATb.Value);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindCountriesDDL();
            //if (tbOne.Attributes["class"] == "active")
            //    hdATb.Value = tbOne.ClientID;
            //else
            //    hdATb.Value = tbTwo.ClientID;
        }

        
        private void BindCountriesDDL()
        {
            ddlCountry.DataValueField = "CountryISONr";
            ddlCountry.DataTextField = "DisplayName";
            ddlCountry.DataSource = CountryInfo.AllCountries;
            ddlCountry.DataBind();

            ddlCountry.SelectedValue = CountryInfo.UKRAINE.CountryISONr;
            ddlCountry_SelectedIndexChanged(this, EventArgs.Empty);
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selCountryIsoNr = ddlCountry.SelectedValue;
            BankInfoUIDispNames biuidn = !_UIByCountries.ContainsKey(selCountryIsoNr) ? _UIByCountries[string.Empty] : _UIByCountries[selCountryIsoNr];

            edHeadMFO.EditMaxLength = biuidn.MFOMaxLength;
            edHeadMFO.LabelDescription = biuidn.Description;
            edHeadMFO.LabelDisplayName = biuidn.DisplayName;
            edHeadMFO.EditWidth = biuidn.MFOWidth;
            edCode.Visible = biuidn.ShowCode;
            edNameUkr.Visible = biuidn.ShowNameUkr;
            edNameUkr.Visible = biuidn.ShowNameUkr;
            edRegistryNr.Visible = biuidn.ShowRegistryNr;
            edSWIFTBIC.Visible = biuidn.ShowSwift;

        }

        public BankInfo DataSource
        {
            get
            {
                BankInfo rslt = new BankInfo();
                rslt.MFO = edHeadMFO.Value;
                rslt.Name = edName.Value;
                rslt.NameUkr = edNameUkr.Value;
                rslt.OperationCountry = new CountryInfo() { CountryISONr = ddlCountry.SelectedValue };
                rslt.SWIFTBIC = edSWIFTBIC.Value;
                rslt.RegistryNr = edRegistryNr.Value;
                rslt.Code = edCode.Value;
                return rslt;
            }
            set
            {
                if (value == null)
                    return;
                edHeadMFO.Value  = value.MFO;
                edName.Value = value.Name;
                edNameUkr.Value = value.NameUkr;
                edSWIFTBIC.Value = value.SWIFTBIC;
                edRegistryNr.Value = value.RegistryNr;
                edCode.Value = value.Code;
                ddlCountry.SelectedValue = value.OperationCountry.CountryISONr;
                ddlCountry_SelectedIndexChanged(this, EventArgs.Empty);
            }
        }

        protected void uabkcbx_OnSelectedMFOChanged(object sender, EventArgs e)
        {
            DataTable dt = RcuKruReader.Search(DataModule.RcuKru, uabkcbx.SelectedMFO);
            if (dt.Rows.Count == 0)
                return;
            BankInfo bi = BankInfo.ParseFromRcuKruRow(dt.Rows[0]);
            DataSource = bi;

            
        }

        protected void SetActiveTab(string activeTabId)
        {
            if (activeTabId == tbOne.ClientID || activeTabId.IndexOf(tbOne.ClientID)!= -1)
            {
                SetTabActive(tbOne, tbPnlOne);
                SetTabInactive(tbTwo, tbPnlTwo);
            }
            else
            {
                SetTabActive(tbTwo, tbPnlTwo);
                SetTabInactive(tbOne, tbPnlOne);
            }
        }

        protected void SetTabActive(System.Web.UI.HtmlControls.HtmlGenericControl tab, System.Web.UI.HtmlControls.HtmlGenericControl pnl)
        {
            tab.Attributes["class"] = "active";
            pnl.Attributes["class"] = "tab-pane active";
        }

        protected void SetTabInactive(System.Web.UI.HtmlControls.HtmlGenericControl tab, System.Web.UI.HtmlControls.HtmlGenericControl pnl)
        {
            tab.Attributes["class"] = string.Empty;
            pnl.Attributes["class"] = "tab-pane";
        }

    }
}