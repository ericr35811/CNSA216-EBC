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

        private static string[] columnNames = new string[20];
        private static Type[] columnTypes = new Type[20];
        private static DataTable dtColumns;

        // Populate the values which the user can search for
        private void PopulateParameters() {
            DataSet dsColumnList;
            int i;
            string[] columnNamesTemp = new string[25];
            Type[] columnTypesTemp = new Type[25];

            parametersPopulating = true;

            // Get the table name 
            searchTable = ddlSearchFor.SelectedValue.ToString();

            // Get the list of columns that can be searched
            dsColumnList = GeneralDataTier.GetSearchableColumns(searchTable);
            dtColumns = dsColumnList.Tables[0];

            //// Create a list of the column names and a list of their types so they can be validated
            //i = 0;
            //foreach (DataColumn col in dsColumnList.Tables[0].Columns) {
            //    columnNamesTemp[i] = col.ColumnName.ToString();
            //    columnTypesTemp[i] = col.DataType;
            //    ++i;
            //}
            //
            //// resize the array to remove nulls at the end
            //columnNames = new string[i];
            //Array.Copy(columnNamesTemp, columnNames, i);

            //columnTypes = new Type[i];
            //Array.Copy(columnTypesTemp, columnTypes, i);

            //columnNames = (string[]) Custom.RemoveNulls(columnNames);
            //columnTypes = (Type[]) Custom.RemoveNulls(columnTypes);

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
            ddlParameter2.SelectedIndex = 1;

            parametersPopulating = false;
        }

        // Set up the validators based on the type of the selected parameter
        private void SetValidator(CompareValidator cmp, RangeValidator rng, string colName) {
            // columnTypes[i] = the datatype of the column at index i
            lblTest.Text += " " + colName;

            return;

            //cmp.Enabled = true;
            //switch (columnTypes[i].ToString()) {
            //    case "System.String":
            //        cmp.Type = ValidationDataType.String;
            //        cmp.ErrorMessage = "Must be a string";
            //        rng.Enabled = false;
            //        break;
            //    case "System.Int16":
            //        cmp.Type = ValidationDataType.Integer;
            //        cmp.ErrorMessage = "Must be a number";
            //        rng.Type = ValidationDataType.Integer;
            //        rng.ErrorMessage = $" between {Int16.MinValue} and {Int16.MaxValue}";
            //        rng.MinimumValue = Int16.MinValue.ToString();
            //        rng.MaximumValue = Int16.MaxValue.ToString();
            //        rng.Enabled = true;
            //        break;
            //    case "System.Int32":
            //        cmp.Type = ValidationDataType.Integer;
            //        cmp.ErrorMessage = "Must be a number";
            //        rng.Type = ValidationDataType.Integer;
            //        rng.ErrorMessage = $" between {Int32.MinValue} and {Int32.MaxValue}";
            //        rng.MinimumValue = Int32.MinValue.ToString();
            //        rng.MaximumValue = Int32.MaxValue.ToString();
            //        rng.Enabled = true;
            //        break;
            //    case "System.DateTime":
            //        cmp.Type = ValidationDataType.Date;
            //        cmp.ErrorMessage = "Must be a date";
            //        rng.Type = ValidationDataType.Date;
            //        rng.ErrorMessage = $" between {DateTime.MinValue} and {DateTime.MaxValue}";
            //        rng.MinimumValue = DateTime.MinValue.ToShortDateString();
            //        rng.MaximumValue = DateTime.MaxValue.ToShortDateString();
            //        rng.Enabled = true;
            //        break;

            //}
        }

        protected void Page_Load(object sender, EventArgs e) {
            if (IsPostBack) {
                lblTest.Text = "postback";
            }
            else {
                lblTest.Text = "not postback";

                // Populate if the page is loading for the first time (not postback)
                PopulateParameters();

                SetValidator(cmpParameter01, rngParameter01, ddlParameter1.SelectedValue);
                //SetValidator(cmpParameter02, rngParameter02, ddlParameter2.SelectedIndex);
            }


        }

        protected void ddlSearchFor_SelectedIndexChanged(object sender, EventArgs e) {
            // Populate if the user has selected a new table (postback)
            if (!parametersPopulating) PopulateParameters();
        }

        protected void ddlParameter1_SelectedIndexChanged(object sender, EventArgs e) {
            SetValidator(cmpParameter01, rngParameter01, ddlParameter1.SelectedValue);
        }
    }
}