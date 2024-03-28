using _2024_CNSA212_Final_Group2;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace CNSA216_EBC_project {
    public class SearchParameters {
        public string tableName;
        public string andOr;
        public bool showActive;
        public bool showInactive;
        public string param1Col;
        public string param1;
        public string param2Col;
        public string param2;
    }
    
    public partial class WebForm8 : System.Web.UI.Page {
        private string searchTable = "NONE";
        private bool parametersPopulating = false;

        private SearchParameters currentSearch;

        //private string tableName;
        //private string param1Col;
        //private string param1;
        //private string andOr;
        //private string param2Col;
        //private string param2;
        //private bool showActive;
        //private bool showInactive;

        private readonly string[] validForms = { "Patient", "Physician", "Prescription", "Refill" };
        private readonly string[] validCommands = { "ADD", "EDIT", "DELETE", "VIEW" };
        private DataSet dsResult;
        private static DataTable dtColumns;

        // Populate the values which the user can search for
        private void PopulateParameters() {
            DataSet dsColumnList;

            parametersPopulating = true;

            // Get the table name 
            searchTable = ddlSearchFor.SelectedValue.ToString();

            // Get the list of columns that can be searched
            dsColumnList = GeneralDataTier.GetSearchableColumns(searchTable);
            dtColumns = dsColumnList.Tables[0];

            // insert a default value
            DataRow InitialValue = dtColumns.NewRow();
            InitialValue["ColName"] = "Select one...";
            InitialValue["SqlDbType"] = "DEFAULT";
            dtColumns.Rows.InsertAt(InitialValue, 0);

            // Populate
            ddlParameter1.DataSource = dtColumns;
            ddlParameter1.DataTextField = "ColName";
            ddlParameter1.DataValueField = "ColName";
            ddlParameter1.DataBind();
            ddlParameter1.SelectedIndex = 0;

            ddlParameter2.DataSource = dtColumns;
            ddlParameter2.DataTextField = "ColName";
            ddlParameter2.DataValueField = "ColName";
            ddlParameter2.DataBind();
            ddlParameter2.SelectedIndex = 0;

            parametersPopulating = false;
        }

        // Set up the validators based on the type of the selected parameter
        private void SetValidator(CompareValidator cmp, RangeValidator rng, RegularExpressionValidator rgx, string colName) {
            // get the datatype and max length of the selected column
            string dataType = dtColumns.Select($"ColName = '{colName}'")[0]["SqlDbType"].ToString();
            string maxLength = dtColumns.Select($"ColName = '{colName}'")[0]["MaxLength"].ToString();

            //lblTest.Text += " " + colName;

            
            switch (dataType) {
                case "varchar":
                case "char":
                    // check datatype
                    cmp.Enabled = true;
                    cmp.Type = ValidationDataType.String;
                    cmp.ErrorMessage = "Must be a string";
                    
                    rng.Enabled = false;
                    
                    // check length
                    rgx.ValidationExpression = $"^[\\s\\S]{{0,{maxLength}}}$";
                    rgx.ErrorMessage = $"Must be {maxLength} characters or less";
                    rgx.Enabled = true;
                    break;
                case "smallint":
                    //cmp.Enabled = true;
                    //cmp.Type = ValidationDataType.Integer;
                    //cmp.ErrorMessage = "Must be a number";
                    cmp.Enabled = false;

                    // check range
                    rng.Type = ValidationDataType.Integer;
                    rng.ErrorMessage = $"Must be a whole number between {Int16.MinValue.ToString()} and {Int16.MaxValue.ToString()}";
                    rng.MinimumValue = Int16.MinValue.ToString();
                    rng.MaximumValue = Int16.MaxValue.ToString();
                    rng.Enabled = true;

                    rgx.Enabled = false;
                    break;
                case "int":
                    //cmp.Enabled = true;
                    //cmp.Type = ValidationDataType.Integer;
                    //cmp.ErrorMessage = "Must be a number";
                    cmp.Enabled = false;

                    rng.Type = ValidationDataType.Integer;
                    rng.ErrorMessage = $"Must be a whole number between {Int32.MinValue.ToString()} and {Int32.MaxValue.ToString()}";
                    rng.MinimumValue = Int32.MinValue.ToString();
                    rng.MaximumValue = Int32.MaxValue.ToString();
                    rng.Enabled = true;

                    rgx.Enabled = false;
                    break;
                case "date":
                    //cmp.Enabled = true;
                    //cmp.Type = ValidationDataType.Date;
                    //cmp.ErrorMessage = "Must be a date";
                    cmp.Enabled = false;

                    rng.Type = ValidationDataType.Date;
                    rng.ErrorMessage = $"Must be a date between {DateTime.MinValue.ToShortDateString()} and {DateTime.MaxValue.ToShortDateString()}";
                    rng.MinimumValue = DateTime.MinValue.ToShortDateString();
                    rng.MaximumValue = DateTime.MaxValue.ToShortDateString();
                    rng.Enabled = true;

                    rgx.Enabled = false;
                    break;
                case "DEFAULT":
                    cmp.Enabled = false;
                    rng.Enabled = false;
                    rgx.Enabled = false;
                    break;


            }
        }

        // bind the data to the appropriate gridview
        private void BindData(string tableName) {
            dgvPatient.Visible = false;
            dgvPhysician.Visible = false;
            dgvPrescription.Visible = false;
            dgvRefill.Visible = false;


            switch (ddlSearchFor.SelectedValue.ToString()) {
                case "Patients":
                    dgvPatient.DataSource = dsResult;
                    dgvPatient.DataBind();
                    dgvPatient.Visible = true;
                    break;
                case "Physicians":
                    dgvPhysician.DataSource = dsResult;
                    dgvPhysician.DataBind();
                    dgvPhysician.Visible = true;
                    break;
                case "Prescriptions":
                    dgvPrescription.DataSource = dsResult;
                    dgvPrescription.DataBind();
                    dgvPrescription.Visible = true;
                    break;
                case "Refills":
                    dgvRefill.DataSource = dsResult;
                    dgvRefill.DataBind();
                    dgvRefill.Visible = true;
                    break;
            }
        }

        protected void Page_Load(object sender, EventArgs e) {
            if (IsPostBack) {
                //lblTest.Text = "postback";


            }
            else {
                //lblTest.Text = "not postback";

                // optionally set the table to search
                if (Request.QueryString.AllKeys.Contains("search")) {
                    ddlSearchFor.SelectedValue = Request.QueryString["search"];
                }

                if (Request.QueryString.AllKeys.Contains("refresh")) {

                }
                
                // Populate if the page is loading for the first time (not postback)
                PopulateParameters();

                // Set up validators on first load
                SetValidator(cmpParameter01, rngParameter01, rgxParameter01, ddlParameter1.SelectedValue);
                SetValidator(cmpParameter02, rngParameter02, rgxParameter02, ddlParameter2.SelectedValue);

                // Bind data so the table shows "no data" on first load
                BindData(ddlSearchFor.SelectedValue);
            }

            // disable the and/or if we are selecting all
            if (ddlParameter1.SelectedIndex == 0 || ddlParameter2.SelectedIndex == 0) {
                rdoAndOr.Enabled = false;
            }
            else {
                rdoAndOr.Enabled = true;
            }

            // add script to require one checkbox to be selected
            chkActive.InputAttributes.Add("onchange", "ActiveInactiveChanged(this)");
            chkInactive.InputAttributes.Add("onchange", "ActiveInactiveChanged(this)");

        }

        protected void ddlSearchFor_SelectedIndexChanged(object sender, EventArgs e) {
            // Populate if the user has selected a new table (postback)
            if (!parametersPopulating) PopulateParameters();

            txtParameter1.Text = "";
            txtParameter2.Text = "";

            //// disable
            //if (ddlSearchFor.SelectedValue == "Refills") {
            //    btnAdd.Enabled = false;
            //}
            //else {
            //    btnAdd.Enabled = true;
            //}
        }

        protected void ddlParameter1_SelectedIndexChanged(object sender, EventArgs e) {
            txtParameter1.Text = "";
            SetValidator(cmpParameter01, rngParameter01, rgxParameter01, ddlParameter1.SelectedValue);
            Page.Validate();
        }

        protected void ddlParameter2_SelectedIndexChanged(object sender, EventArgs e) {
            txtParameter2.Text = "";
            SetValidator(cmpParameter02, rngParameter02, rgxParameter02, ddlParameter2.SelectedValue);
            Page.Validate();
        }

        protected SearchParameters GetSearch() {
            SearchParameters param = new SearchParameters();

            param.tableName = ddlSearchFor.SelectedValue;
            param.andOr = rdoAndOr.SelectedValue;
            param.showActive = chkActive.Checked;
            param.showInactive = chkInactive.Checked;

            // if no column selected, send a blank string
            if (ddlParameter1.SelectedIndex == 0) {
                param.param1Col = "";
                param.param1 = "";
            }
            else {
                param.param1Col = ddlParameter1.SelectedValue;
                param.param1 = txtParameter1.Text;
            }

            if (ddlParameter2.SelectedIndex == 0) {
                param.param2Col = "";
                param.param2 = "";
            }
            else {
                param.param2Col = ddlParameter2.SelectedValue;
                param.param2 = txtParameter2.Text;
            }

            return param;
        }

        protected void CacheSearch(SearchParameters param) {
            Session.Clear();
            Session.Add("searchParameters", param);
        }

        // functions for table buttons
        protected void TableActions(object sender, CommandEventArgs e) {
            //CacheSearch(currentSearch);
            //Response.Write("<script>alert('" + e.CommandName + " " + e.CommandArgument.ToString() + "');</script>");

            string[] command = e.CommandName.Split(':');
            string form = command[0];
            string action = command[1];
            string id = e.CommandArgument.ToString();

            // validate and form the URL
            StringBuilder url = new StringBuilder();
            
            if (validForms.Contains(form)) {
                url.Append("frm" + form + ".aspx");

                if (validCommands.Contains(action)) {
                    url.Append("?type=" + action);
                    url.Append("&id=" + SecureID.Encrypt(id));

                    Response.Redirect(url.ToString());
                }
            }
        }


        protected void btnSearch_Click(object sender, EventArgs e) {
            SearchParameters param;

            param = GetSearch();

            dsResult = GeneralDataTier.SearchTableGetInfo(param);

            if (dsResult != null) {
                BindData(param.tableName);
            }

            CacheSearch(param);
        }

    }
}