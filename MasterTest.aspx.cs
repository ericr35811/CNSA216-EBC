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
            //dt.Columns.Add("</th><svg onload='alert(\'trolled\')'><th>");
            //dt.Columns.Add("%3C/th%3E%3Csvg onload=%29alert%28%5C%29trolled%5C%29%29%29%3E%3Cth%3E");

            dt.Rows.Add("value 1", "value 2");
            dt.Rows.Add("value 3", "value 4");

            for(int i = 0; i < 50;  i++) {
                dt.Rows.Add("AAAAAA", "BBBBBBBB");
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();


        }
    }
}