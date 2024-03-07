using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CNSA216_EBC_project {
    public partial class WebForm8 : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            //ClientScript.RegisterClientScriptBlock(Page.GetType(), "test", "function test() { alert('balls') }");
        }

        protected void ddlSearchFor_SelectedIndexChanged(object sender, EventArgs e) {
            //lblTest.Text = "balls";
        }
    }
}