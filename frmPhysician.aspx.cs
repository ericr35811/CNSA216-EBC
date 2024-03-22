using _2024_CNSA212_Final_Group2;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CNSA216_EBC_project {
    public partial class WebForm4 : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            rngDate1.Type = ValidationDataType.Date;
            rngDate1.ErrorMessage = $"Must be a date between {DateTime.MinValue.ToShortDateString()} and {DateTime.MaxValue.ToShortDateString()}";
            rngDate1.MinimumValue = DateTime.MinValue.ToShortDateString();
            rngDate1.MaximumValue = DateTime.MaxValue.ToShortDateString();

            rngDate2.Type = ValidationDataType.Date;
            rngDate2.ErrorMessage = $"Must be a date between {DateTime.MinValue.ToShortDateString()} and {DateTime.MaxValue.ToShortDateString()}";
            rngDate2.MinimumValue = DateTime.MinValue.ToShortDateString();
            rngDate2.MaximumValue = DateTime.MaxValue.ToShortDateString();

            int maxLength;
            DataSet dsColumns;

            dsColumns = GeneralDataTier.GetTableColumns("Patients");
            maxLength = GeneralDataTier.GetColumnMaxLength("First Name", dsColumns);
            maxLength = GeneralDataTier.GetColumnMaxLength("Last Name", dsColumns);
            maxLength = GeneralDataTier.GetColumnMaxLength("Middle", dsColumns);
            maxLength = GeneralDataTier.GetColumnMaxLength("City", dsColumns);
            maxLength = GeneralDataTier.GetColumnMaxLength("Email", dsColumns);
            maxLength = GeneralDataTier.GetColumnMaxLength("PhysicianID", dsColumns);
            maxLength = GeneralDataTier.GetColumnMaxLength("Phone", dsColumns);
            maxLength = GeneralDataTier.GetColumnMaxLength("Street", dsColumns);
            maxLength = GeneralDataTier.GetColumnMaxLength("Zip", dsColumns);
            txtFName.MaxLength = maxLength;
            txtLName.MaxLength = maxLength;
            txtMiddle.MaxLength = maxLength;
            txtCity.MaxLength = maxLength;
            txtemail.MaxLength = maxLength;
            txtPhysicianID.MaxLength = maxLength;
            txtPhone.MaxLength = maxLength;
            txtStreet.MaxLength = maxLength;
            txtZip.MaxLength = maxLength;
            rgxString.ValidationExpression = GeneralDataTier.LengthExpression(maxLength);
            rgxString.ErrorMessage = $"Must be {maxLength} characters or less";

            if (!IsPostBack && Request.QueryString.AllKeys.Contains("ID") && Request.QueryString.AllKeys.Contains("type"))
            {
                if (String.IsNullOrEmpty(Request.QueryString["ID"].Trim().ToUpper()))
                {
                    Response.Redirect("Home.aspx");
                }
                else if (Request.QueryString["Type"].Trim().ToUpper() == "NEW")
                {
                    PopulateDDL();
                }
                else if (Request.QueryString["Type"].Trim().ToUpper() == "VIEW")
                {
                    GetPhysician(Request.QueryString["ID"].Trim().ToUpper(), Request.QueryString["Type"].Trim().ToUpper());
                    PopulateDDL();
                }
                else if (Request.QueryString["Type"].Trim().ToUpper() == "EDIT")
                {
                    GetPhysician(Request.QueryString["ID"].Trim().ToUpper(), Request.QueryString["Type"].Trim().ToUpper());
                    PopulateDDL();
                }
                else
                {
                    Response.Redirect("Home.aspx");
                }
            }
            // else {
            //    Response.Redirect("Home.aspx");
            //}

        }
        protected void PopulateDDL()
        {
            ddlState.DataSource = StateManager.getStates();
            ddlState.DataTextField = "FullAndAbbrev";
            ddlState.DataValueField = "Abbreviation";
            ddlState.DataBind();
        }

        public void GetPhysician(string id, string type)
        {
            DataSet ds = new DataSet();

            ds = PhysicianID.GetPhysicianByID(id);

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtPhysicianID.Text = ds.Tables[0].Rows[0]["student_id"].ToString();
                txtFName.Text = ds.Tables[0].Rows[0]["fname"].ToString();
                txtLName.Text = ds.Tables[0].Rows[0]["lname"].ToString();

                txtMiddle.Text = ds.Tables[0].Rows[0]["midinit"].ToString();
                txtStreet.Text = ds.Tables[0].Rows[0]["address_one"].ToString();
                txtCity.Text = ds.Tables[0].Rows[0]["city"].ToString();
                ddlState.SelectedValue = ds.Tables[0].Rows[0]["stu_state"].ToString();
                txtZip.Text = ds.Tables[0].Rows[0]["zip"].ToString();
                ddlGender.SelectedValue = ds.Tables[0].Rows[0]["gender"].ToString(); ;
                txtPhone.Text = ds.Tables[0].Rows[0]["cell_phone"].ToString();

                if (type == "VIEW")
                {
                    txtPhysicianID.Enabled = false;
                    txtFName.Enabled = false;
                    txtLName.Enabled = false;

                    txtMiddle.Enabled = false;
                    txtStreet.Enabled = false;
                    txtCity.Enabled = false;
                    ddlState.Enabled = false;
                    txtZip.Enabled = false;
                    ddlGender.Enabled = false;
                    txtPhone.Enabled = false;

                    
                }
                else if (type == "EDIT")
                {
                    txtPhysicianID.Enabled = false;

                    
                    
                }
            }

        }
}