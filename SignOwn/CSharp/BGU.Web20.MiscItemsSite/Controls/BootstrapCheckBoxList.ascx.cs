using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Web.UI.HtmlControls;
using System.Reflection;

namespace BGU.Web20.MiscItemsSite.Controls
{
    public partial class BootstrapCheckBoxList : System.Web.UI.UserControl
    {

        private const string ItemCssClassName = "list-group-item";
        private const string ClassAttrName = "class";
        private const string ValueAttrName = "data-value";
        private const string ItemTagName = "li";
        private const string CheckedAttrName = "data-checked";
        

        private PropertyInfo _dataTextMemberProperty;
        private bool _dataTextMemberPropertyInitialized = false;
        private PropertyInfo GetDataTextMemberProperty(object obj)
        {
            if (!_dataTextMemberPropertyInitialized && !string.IsNullOrEmpty(DataTextMember) && obj != null)
            {
                _dataTextMemberProperty = obj.GetType().GetProperty(DataTextMember);
                _dataTextMemberPropertyInitialized = true;
            }
            return _dataTextMemberProperty;
        }

        private PropertyInfo _dataValueMemberProperty;
        private bool _dataValueMemberPropertyInitialized = false;
        private PropertyInfo GetDataValueMemberProperty(object obj)
        {
            if (!_dataValueMemberPropertyInitialized && !string.IsNullOrEmpty(DataTextMember) && obj != null)
            {
                _dataValueMemberProperty = obj.GetType().GetProperty(DataTextMember);
                _dataValueMemberPropertyInitialized = true;
            }
            return _dataValueMemberProperty;
        }

        private List<string> _checkedValues;
        public List<string> CheckedValues
        {
            get
            {
                return CollectCheckedValues();
            }
            set
            {
                _checkedValues = value;
                ApplyCheckedValues(value);
            }
        }

        private void ApplyCheckedValues(List<string> value)
        {
            throw new NotImplementedException();
        }

        private List<string> CollectCheckedValues()
        {
            throw new NotImplementedException();
        }

        //private void InitCheckReturnDataMemberProperty(string propName, out PropertyInfo target, out 

        public string MaxHeight
        {
            get { return well.Style["max-height"]; }
            set { well.Style["max-height"] = value; }
        }
        public string Width
        {
            get { return well.Style["width"]; }
            set { well.Style["width"] = value; }
        }


        public object DataSource { get;set;}

        [Browsable(true)]
        public string DataValueMember { get; set; }

        [Browsable(true)]
        public string DataTextMember { get; set; }

        public override void DataBind()
        {
            base.DataBind();
            ul.Controls.Clear();
            
            if (DataSource == null) 
                return;
            System.Collections.IEnumerable lst = DataSource as System.Collections.IEnumerable;
            if (lst == null)
                return;
            PropertyInfo piValue = null;
            PropertyInfo piText = null;
            foreach (object di in lst)
            {
                if (di == null)
                    continue;
                if (piValue == null)
                    piValue = GetDataValueMemberProperty(di);

                if (piText == null)
                    piText = GetDataTextMemberProperty(di);

                object currValue = piValue != null ? piValue.GetValue(di, null) : null;
                object currText = piText != null ? piText.GetValue(di, null) : null;
                if (currText == null)
                    continue;
                HtmlGenericControl li = new HtmlGenericControl(ItemTagName);
                li.InnerText = currText.ToString();
                li.Attributes[ClassAttrName] = ItemCssClassName;
                //if (currValue != null)
                //    li.Attributes[ValueAttrName] = currValue.ToString();
                ul.Controls.Add(li);
            }
        }



        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}