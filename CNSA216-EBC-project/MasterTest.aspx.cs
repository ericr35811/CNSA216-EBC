using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace CNSA216_EBC_project {
    public partial class WebForm2 : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

            System.Data.DataTable dt = new System.Data.DataTable();

            dt.Columns.Add("Field 1");
            dt.Columns.Add("Field 2");

            dt.Rows.Add("value 1", "value 4");
            dt.Rows.Add("value 3", "value 4");

            GridView1.DataSource = dt;
            GridView1.DataBind();


        }
    }
}