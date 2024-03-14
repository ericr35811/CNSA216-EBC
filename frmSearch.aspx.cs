using _2024_CNSA212_Final_Group2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CNSA216_EBC_project {
    public partial class WebForm8 : System.Web.UI.Page {
        private string searchTable = "NONE";
        private bool parametersPopulating = false;

        // Populate the values which the user can search for
        private void PopulateParameters() {
            string[] columnList;

            parametersPopulating = true;

            // Get the table name 
            searchTable = ddlSearchFor.SelectedValue.ToString();

            // Get the list of columns that can be searched
            columnList = GeneralDataTier.GetSearchableColumns(searchTable);

            // Populate
            ddlParameter1.DataSource = columnList;
            ddlParameter1.DataBind();
            ddlParameter1.SelectedIndex = 0;

            ddlParameter2.DataSource = columnList;
            ddlParameter2.DataBind();
            ddlParameter2.SelectedIndex = 1;

            parametersPopulating = false;
        }

        protected void Page_Load(object sender, EventArgs e) {
            if (IsPostBack) {
                lblTest.Text = "postback";
            }
            else {
                lblTest.Text = "not postback";

                // Populate if the page is loading for the first time (not postback)
                PopulateParameters();
            }

            


        }

        protected void ddlSearchFor_SelectedIndexChanged(object sender, EventArgs e) {
            // Populate if the user has selected a new table (postback)
            if (!parametersPopulating) PopulateParameters();
        }
    }
}