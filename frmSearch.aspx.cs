﻿using _2024_CNSA212_Final_Group2;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CNSA216_EBC_project {
    public partial class WebForm8 : System.Web.UI.Page {
        private string searchTable = "NONE";
        private bool parametersPopulating = false;

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


        protected void Page_Load(object sender, EventArgs e) {
            if (IsPostBack) {
                //lblTest.Text = "postback";

                
            }
            else {
                //lblTest.Text = "not postback";

                // Populate if the page is loading for the first time (not postback)
                PopulateParameters();

                SetValidator(cmpParameter01, rngParameter01, rgxParameter01, ddlParameter1.SelectedValue);
                SetValidator(cmpParameter02, rngParameter02, rgxParameter02, ddlParameter2.SelectedValue);
            }
            
            // disable the and/or if we are selecting all
            if (ddlParameter1.SelectedIndex == 0 || ddlParameter2.SelectedIndex == 0) {
                rdoAndOr.Enabled = false;
            }
            else {
                rdoAndOr.Enabled = true;
            }

            chkActive.InputAttributes.Add("onchange", "ActiveInactiveChanged(this)");
            chkInactive.InputAttributes.Add("onchange", "ActiveInactiveChanged(this)");

        }

        protected void ddlSearchFor_SelectedIndexChanged(object sender, EventArgs e) {
            // Populate if the user has selected a new table (postback)
            if (!parametersPopulating) PopulateParameters();
        }

        protected void ddlParameter1_SelectedIndexChanged(object sender, EventArgs e) {
            SetValidator(cmpParameter01, rngParameter01, rgxParameter01, ddlParameter1.SelectedValue);
            Page.Validate();
            
            
        }

        protected void ddlParameter2_SelectedIndexChanged(object sender, EventArgs e) {
            SetValidator(cmpParameter02, rngParameter02, rgxParameter02, ddlParameter2.SelectedValue);
            Page.Validate();
        }

        protected void btnSearch_Click(object sender, EventArgs e) {
            DataSet dsResult;

            string tableName;
            string param1Col;
            string param1;
            string andOr;
            string param2Col;
            string param2;
            bool showActive;
            bool showInactive;

            tableName = ddlSearchFor.SelectedValue;
            andOr = rdoAndOr.SelectedValue;
            showActive = chkActive.Checked;
            showInactive = chkInactive.Checked;

            // if no column selected, send a blank string
            if (ddlParameter1.SelectedIndex == 0) {
                param1Col = "";
                param1 = "";
            } else {
                param1Col = ddlParameter1.SelectedValue;
                param1 = txtParameter1.Text;
            }

            if (ddlParameter2.SelectedIndex == 0) {
                param2Col = "";
                param2 = "";
            } else {
                param2Col = ddlParameter2.SelectedValue;
                param2 = txtParameter2.Text;
            }

            dsResult = GeneralDataTier.SearchTableGetInfo(tableName, param1Col, param1, andOr, param2Col, param2, showActive, showInactive);

            if (dsResult != null) {
                // before binding the data, only enable columns which exist in the dataset
                //foreach (BoundField col in dgvResult.Columns) {

                //    if (!dsResult.Tables[0].Columns.Contains(col.DataField) ) {
                //        col.Visible = false;
                //    } else {
                //        col.Visible = true;
                //    }
                //}

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
        }
    }
}