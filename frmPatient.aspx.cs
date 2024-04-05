using _2024_CNSA212_Final_Group2;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.EnterpriseServices;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Web;
using System.Web.ClientServices.Providers;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CNSA216_EBC_project
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        private static string type;
        private static int PatientID = 0;
        private static string firstName = "";
        private static string lastName = "";
        private static string email = "";
        private static string middle = "";
        private static string city = "";
        private static string zip = "";
        private static string street = "";
        private static string state = "";
        private static string gender = "";
        private static int insuranceID = 0;
        private static string phone1 = "";
        private static string phone2 = "";
        private static bool Saved = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            bool success;

           // btnSave.Click += new EventHandler(btnSave_Click);

            txtPatientID.Enabled = false;
            txtFname.Enabled = true;
            txtLname.Enabled = true;
            txtMiddle.Enabled = true;

            txtCity.Enabled = true;
            txtEmail.Enabled = true;
            txtWeight.Enabled = true;
            txtHeight.Enabled = true;
            txtPhone1.Enabled = true; txtPhone2.Enabled = true;
            txtZip.Enabled = true;
            txtStreet.Enabled = true;
            txtStart.Enabled = true;
            txtEnd.Enabled = true;
            ddlGender.Enabled = true;
            ddlInsurance.Enabled = true;
            ddlState.Enabled = true;

            btnSave.Enabled = true;
            btnBack.Enabled = true;

            if (!Page.IsPostBack)
            {
                Saved = false;

                if (Request.QueryString.AllKeys.Contains("type") && !String.IsNullOrEmpty(Request.QueryString["type"]))
                {
                    type = Request.QueryString["type"];

                    if (type != "ADD") {
                        if (Request.QueryString.AllKeys.Contains("id") && !String.IsNullOrEmpty(Request.QueryString["id"])) {
                            success = Int32.TryParse(SecureID.Decrypt(Request.QueryString["id"]), out PatientID);
                            if (!success) {
                                GoBack();
                            }
                            else {
                                PreparePage();
                            }
                        }
                        else {
                            GoBack();
                        }
                    }
                    else {
                        PreparePage();
                    }
                }
                else {
                    GoBack() ;
                }

            }


        }

        private void GoBack()
        {
            Session["refresh"] = true;
            //if (Saved)
            //{
            //    SearchParameters param = new SearchParameters();
            //    param.tableName = "Patient";
            //    param.showActive = true;
            //    param.showInactive = false;
            //    param.param1Col = "PatientID";
            //    param.param1 = PatientID.ToString();
            //    param.andOr = "O";
            //    param.param2Col = "";
            //    param.param2 = "";
            //    Session["SearchParameters"] = param;
            //}
            Response.Redirect("frmSearch.aspx");
        }

        protected void PreparePage()
        {


            switch (type)
            {
                case "ADD":

                    txtPatientID.Enabled = false;
                    ddlInsurance.Enabled = true;
                    txtFname.Enabled = true;
                    txtLname.Enabled = true;
                    ddlGender.Enabled = true;
                    txtMiddle.Enabled = true;
                    txtCity.Enabled = true;
                    txtStreet.Enabled = true;
                    txtZip.Enabled = true;
                    txtEmail.Enabled = true;
                    txtPhone1.Enabled = true;
                    txtPhone2.Enabled = true;
                    txtWeight.Enabled = true;
                    txtHeight.Enabled = true;
                    txtStart.Enabled = true;
                    txtEnd.Enabled = true;
                    ddlState.Enabled = true;

                    btnSave.Text = "Add";
                    btnBack.Text = "Back";
                    btnSave.Enabled = true;
                    btnSave.Visible = true;

                    SetValidators();
                    BindData();
                    break;
                case "VIEW":

                    txtPatientID.Enabled = false;
                    ddlInsurance.Enabled = false;
                    txtFname.Enabled = false;
                    txtLname.Enabled = false;
                    ddlGender.Enabled = false;
                    txtMiddle.Enabled = false;
                    txtCity.Enabled = false;
                    txtStreet.Enabled = false;
                    txtZip.Enabled = false;
                    txtEmail.Enabled = false;
                    txtPhone1.Enabled = false;
                    txtPhone2.Enabled = false;
                    txtWeight.Enabled = false;
                    txtHeight.Enabled = false;
                    txtStart.Enabled = false;
                    txtEnd.Enabled = false;
                    ddlState.Enabled = false;

                    btnSave.Enabled = false;
                    btnSave.Visible = false;

                    SetValidators();
                    BindData();
                    break;
                case "EDIT":

                    txtPatientID.Enabled = false;
                    ddlInsurance.Enabled = true;
                    txtFname.Enabled = true;
                    txtLname.Enabled = true;
                    ddlGender.Enabled = true;
                    txtMiddle.Enabled = true;
                    txtCity.Enabled = true;
                    txtStreet.Enabled = true;
                    txtZip.Enabled = true;
                    txtEmail.Enabled = true;
                    txtPhone1.Enabled = true;
                    txtPhone2.Enabled = true;
                    txtWeight.Enabled = true;
                    txtHeight.Enabled = true;
                    txtStart.Enabled = true;
                    txtEnd.Enabled = true;
                    ddlState.Enabled = true;

                    btnSave.Enabled=true;
                    btnSave.Text = "Update";
                    SetValidators();
                    BindData();
                    break;


            }
        }
        protected void BindData()
        {

            DataTable PatientData = new DataTable();
            //int PatientID = 0;
            string FirstName = "";
            string LastName = "";
            string Email = "";
            string Middle = "";
            string city = "";
            string zip = "";
            string street = "";
            string gender = "";
            int insuranceID = 0;
            string Phone1 = "";
            string Phone2 = "";
            string State = "";
            Int16 height = 0;
            Int16 weight = 0;
            DateTime startDate = DateTime.Parse("1/1/3000");
            DateTime endDate = DateTime.Parse("1/1/3000");

            ddlState.DataSource = GeneralDataTier.GetStates().Tables[0];
            ddlState.DataTextField = "StateName";
            ddlState.DataValueField = "State";
            ddlState.DataBind();

            ddlGender.DataSource = GeneralDataTier.GetGenders().Tables[0];
            ddlGender.DataTextField = "GenderName";
            ddlGender.DataValueField = "Gender";
            ddlGender.DataBind();

            ddlInsurance.DataSource = GeneralDataTier.GetInsurances();
            ddlInsurance.DataTextField = "Name";
            ddlInsurance.DataValueField = "InsuranceID";
            ddlInsurance.DataBind();

            if (type == "EDIT" || type == "VIEW")
            {
                // get all data for this Patient
                PatientData = PatientDataTier.GetPatientInfo(PatientID).Tables[0];

                PatientID = (int)PatientData.Rows[0]["PatientID"];
                FirstName = (string)PatientData.Rows[0]["FirstName"];
                LastName = (string)PatientData.Rows[0]["LastName"];
                Middle = (string)PatientData.Rows[0]["Middle"];
                Email = (string)PatientData.Rows[0]["Email"];
                city = (string)PatientData.Rows[0]["City"];
                zip = (string)PatientData.Rows[0]["Zip"];
                State = (string)PatientData.Rows[0]["State"];
                street = (string)PatientData.Rows[0]["Street"];
                gender = (string)PatientData.Rows[0]["Gender"];
                insuranceID = Int32.Parse(PatientData.Rows[0]["InsuranceID"].ToString());
                Phone1 = (string)PatientData.Rows[0]["Phone1"];
                Phone2 = (string)PatientData.Rows[0]["Phone2"];
                height = (Int16)PatientData.Rows[0]["Height"];
                weight = (Int16)PatientData.Rows[0]["Weight"];
                startDate = (DateTime)PatientData.Rows[0]["StartDate"];
                endDate = (DateTime)PatientData.Rows[0]["EndDate"];

                // -- populate values
                txtPatientID.Text = PatientID.ToString();
                txtFname.Text = FirstName.ToString();
                txtLname.Text = LastName.ToString();
                txtMiddle.Text = Middle.ToString();
                ddlInsurance.SelectedValue = insuranceID.ToString();
                ddlState.SelectedValue = State.ToString();
                txtEmail.Text = Email.ToString();
                txtCity.Text = city.ToString();
                txtZip.Text = zip.ToString();
                txtStreet.Text = street.ToString();
                txtPhone1.Text = Phone1.ToString();
                txtPhone2.Text = Phone2.ToString();
                ddlGender.SelectedValue = gender.ToString();
                txtHeight.Text = height.ToString();
                txtWeight.Text = weight.ToString();
                txtStart.Text = startDate.ToString("yyyy-MM-dd");
                txtEnd.Text = endDate.ToString("yyyy-MM-dd");
            }
        }
        protected void SetValidators()
        {
            DataSet dsColumns;

            if (type == "VIEW")
            {
                rngStartDate.Enabled = false;
                rngEndDate.Enabled = false;
                rngHeight.Enabled = false;
                rngWeight.Enabled = false;
            }
            else
            {
                dsColumns = GeneralDataTier.GetTableColumns("Patients");

                // check length
                txtFname.MaxLength = GeneralDataTier.GetColumnMaxLength("FirstName", dsColumns);
                txtLname.MaxLength = GeneralDataTier.GetColumnMaxLength("LastName", dsColumns);
                txtMiddle.MaxLength = GeneralDataTier.GetColumnMaxLength("Middle", dsColumns);

                rngHeight.Type = ValidationDataType.Integer;
                rngHeight.ErrorMessage = $"Must be a whole number between {Int16.MinValue.ToString()} and {Int16.MaxValue.ToString()}";
                rngHeight.MinimumValue = Int16.MinValue.ToString();
                rngHeight.MaximumValue = Int16.MaxValue.ToString();

                rngWeight.Type = ValidationDataType.Integer;
                rngWeight.ErrorMessage = $"Must be a whole number between {Int16.MinValue.ToString()} and {Int16.MaxValue.ToString()}";
                rngWeight.MinimumValue = Int16.MinValue.ToString();
                rngWeight.MaximumValue = Int16.MaxValue.ToString();

                txtStreet.MaxLength = GeneralDataTier.GetColumnMaxLength("Street", dsColumns);
                txtZip.MaxLength = GeneralDataTier.GetColumnMaxLength("Zip", dsColumns);
                //txtPhone1.MaxLength = GeneralDataTier.GetColumnMaxLength("Phone1", dsColumns);
                //txtPhone2.MaxLength = GeneralDataTier.GetColumnMaxLength("Phone2", dsColumns);
                txtPhone1.MaxLength = 12;
                txtPhone2.MaxLength = 12;
                txtEmail.MaxLength = GeneralDataTier.GetColumnMaxLength("Email", dsColumns);
                                
                rngStartDate.Type = ValidationDataType.Date;
                rngStartDate.ErrorMessage = $"Must be a date between {DateTime.MinValue.ToShortDateString()} and {DateTime.MaxValue.ToShortDateString()}";
                rngStartDate.MinimumValue = DateTime.MinValue.ToShortDateString();
                rngStartDate.MaximumValue = DateTime.MaxValue.ToShortDateString();

                rngEndDate.Type = ValidationDataType.Date;
                rngEndDate.ErrorMessage = $"Must be a date between {DateTime.MinValue.ToShortDateString()} and {DateTime.MaxValue.ToShortDateString()}";
                rngEndDate.MinimumValue = DateTime.MinValue.ToShortDateString();
                rngEndDate.MaximumValue = DateTime.MaxValue.ToShortDateString();
            }


        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //int PatientID = 0;
            string FirstName = "";
            string LastName = "";
            string Email = "";
            string Middle = "";
            string city = "";
            string zip = "";
            string street = "";
            string gender = "";
            int insuranceID = 0;
            string Phone1 = "";
            string Phone2 = "";
            string State = "";
            Int16 height = 0;
            Int16 weight = 0;
            DateTime startDate = DateTime.Parse("1/1/3000");
            DateTime endDate = DateTime.Parse("1/1/3000");

            //PatientID = Int32.Parse(txtPatientID.Text);
            FirstName = txtFname.Text;
            LastName = txtLname.Text;
            Email = txtEmail.Text;
            Middle = txtMiddle.Text;
            city = txtCity.Text;
            zip = txtZip.Text;
            street = txtStreet.Text;
            gender = ddlGender.SelectedValue;
            insuranceID = Int32.Parse(ddlInsurance.SelectedValue);
            Phone1 = txtPhone1.Text;
            Phone2 = txtPhone2.Text;
            State = ddlState.SelectedValue;
            height = Int16.Parse(txtHeight.Text);
            weight = Int16.Parse(txtWeight.Text);
            startDate = DateTime.Parse(txtStart.Text);
            endDate = DateTime.Parse(txtEnd.Text);

            switch (type)
            {
                case "ADD":
                    PatientDataTier.AddPatient(
                        FirstName, Middle, LastName, street,city, State,Phone1,Phone2,zip,Email,gender,insuranceID,height,weight, startDate, endDate
                       );
                    break;
                case "EDIT":
                    PatientDataTier.UpdatePatientByID(
                        PatientID,
                        insuranceID,
                        FirstName,
                        Middle,
                        LastName,
                        street,
                        city,
                        State,
                        Phone1,
                        Phone2,
                        zip,
                        Email,
                        gender,
                        height,
                        weight,
                        startDate,
                        endDate);

                    break;
            }
            Saved = true;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            GoBack();
        }
    }
}




