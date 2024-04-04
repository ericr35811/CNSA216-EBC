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
    public static class QueryStringEncryption
    {
        public static string Encrypt(string input)
        {
            byte[] encryptedBytes;
            string encryptedString;
            encryptedBytes = Encoding.UTF8.GetBytes(input);
            encryptedBytes = MachineKey.Protect(encryptedBytes);
            encryptedString = Convert.ToBase64String(encryptedBytes);
            encryptedString = HttpUtility.UrlEncode(encryptedString);

            return encryptedString;
        }
    }
    public partial class WebForm3 : System.Web.UI.Page
    {
        private static string type;
        private static int patientID = 0;
        private static string firstName = "";
        private static string lastName = "";
        private static string email = "";
        private static string middle = "";
        private static string city = "";
        private static string zip = "";
        private static string street = "";
        private static string state = "";
        private static string gender = "";
        private static string insuranceName = "";
        private static string phone1 = "";
        private static string phone2 = "";
        private static bool Saved = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            bool success;
            txtPatientID.Enabled = false;

            if (!Page.IsPostBack)
            {

            }
            if (!Page.IsPostBack)
            {
                Saved = false;

                if (Request.QueryString.AllKeys.Contains("type") && !String.IsNullOrEmpty(Request.QueryString["type"]))
                {
                    type = Request.QueryString["type"];
                }

            }
            if (type != "ADD")
            {
                if (Request.QueryString.AllKeys.Contains("id") && !String.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    success = Int32.TryParse(SecureID.Decrypt(Request.QueryString["id"].Trim()), out PatientID);
                    if (!success)
                    {
                        GoBack();
                    }
                    else
                    {
                        PreparePage();
                    }
                }
                else { GoBack(); }
            }
            else
            {

            }


        }

        private void GoBack()
        {
            Session["refresh"] = true;
            if (saved)
            {
                SearchParameters param = new SearchParameters();
                param.tableName = "Patient";
                param.ShowActive = true;
                param.ShowInactive = false;
                param.param1Col = "PatientID";
                param.param1 = patientID.ToString();
                param.andOr = "O";
                param.param2Col = "";
                param.param2 = "";
                Session["SearchParameters"] = param;
            }
            Response.Redirect("frmSearch.aspx");
        }

        public void SetTextBoxes()
        {
            if (type == "VIEW")
            {
                txtPatientID.Enabled = false;
                txtFname.Enabled = false;
                txtLname.Enabled = false;
                txtMiddle.Enabled = false;

                txtCity.Enabled = false;
                txtDob.Enabled = false;
                txtEmail.Enabled = false;
                txtVisit.Enabled = false;
                txtWeight.Enabled = false;
                txtHeight.Enabled = false;
                txtPhone1.Enabled = false; txtPhone2.Enabled = false;
                txtZip.Enabled = false;
                txtStreet.Enabled = false;
                txtStart.Enabled = false;
                txtEnd.Enabled = false;

                btnAdd.Enabled = false;
                btnUpdate.Enabled = false;
                btnBack.Enabled = true;
            }
            else if (type == "EDIT")
            {
                txtPatientID.Enabled = false;

                btnAdd.Text = "UPDATE";
            }
            else if (type == "NEW")
            {
                btnAdd.Text = "ADD";
            }

        }



        protected void btnUpdate_Click(object sender, CommandEventArgs e)
        {
            string recordToBeEdited;
            Int64 myEditedRecord = 0;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            try
            {
                Session["vPatientID"] = txtPatientID.Text.Trim();
                Session["vFName"] = txtFname.Text.Trim();
                Session["vLName"] = txtLname.Text.Trim();

                //get record
                recordToBeEdited = (e.CommandArgument.ToString());

                recordToBeEdited = QueryStringEncryption.Encrypt(recordToBeEdited.Trim().ToUpper());



                sb.Append("<script language = 'javaScript'>");
                sb.Append("  window.open('Display.aspx?ID=" + recordToBeEdited.ToString() + "&type=EDIT', 'DisplayEdit',");
                sb.Append("  'width= 525, height=525, menubar=no, resizable=yes, left=50, top=50, scrollbars=yes');");
                sb.Append("</script>");
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "PopupScript", sb.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        protected void btnGoBack_Click(object sender, EventArgs e)
        {
            Session["refresh"] = true;
            if (Saved)
            {
                // SearchParameters param = new SearchParameters();
                // param.tableName = "Refill";
                // param.showActive = true;
                // param.showInactive = false;
                // param.param1Col = "PatientID";
                // param.param1 = PatientID.ToString();
                // param.andOr = "O";
                // param.param2Col = "";
                // param.param2 = "";
                // Session["searchParameters"] = param;
            }
            Response.Redirect("frmSearch.aspx");
        }
        protected void PreparePage()
        {


            switch (type)
            {
                case "ADD":
                    btnSave.Text = "Add";
                    SetValidators();
                    BindData();
                    break;

                    txtPatientID.Enabled = false;
                    ddlInsurance.Enabled = true;
                    txtFname.Enabled = true;
                    txtLname.Enabled = true;
                    ddlGender.Enabled = true;
                    txtMiddle.Enabled = true;
                    txtDob.Enabled = true;
                    txtCity.Enabled = true;
                    txtStreet.Enabled = true;
                    txtZip.Enabled = true;
                    txtEmail.Enabled = true;
                    txtPhone1.Enabled = true;
                    txtPhone2.Enabled = true;
                    txtWeight.Enabled = true;
                    txtHeight.Enabled = true;
                    txtVisit.Enabled = true;
                case "VIEW":

                    txtPatientID.Enabled = false;
                    ddlInsurance.Enabled = false;
                    txtFname.Enabled = true;
                    txtLname.Enabled = true;
                    ddlGender.Enabled = true;
                    txtMiddle.Enabled = true;
                    txtDob.Enabled = true;
                    txtCity.Enabled = true;
                    txtStreet.Enabled = true;
                    txtZip.Enabled = true;
                    txtEmail.Enabled = true;
                    txtPhone1.Enabled = true;
                    txtPhone2.Enabled = true;
                    txtWeight.Enabled = true;
                    txtHeight.Enabled = true;
                    txtVisit.Enabled = true;


                    btnAdd.Enabled = false;
                    btnAdd.Visible = false;

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
                    txtDob.Enabled = true;
                    txtCity.Enabled = true;
                    txtStreet.Enabled = true;
                    txtZip.Enabled = true;
                    txtEmail.Enabled = true;
                    txtPhone1.Enabled = true;
                    txtPhone2.Enabled = true;
                    txtWeight.Enabled = true;
                    txtHeight.Enabled = true;
                    txtVisit.Enabled = true;
                    btnSave.Text = "Update";
                    SetValidators();
                    BindData();
                    break;


            }
        }
        protected void BindData()
        {

            DataTable PatientData = new DataTable();
            int PatientID = 0;
            string FirstName = "";
            string LastName = "";
            string Email = "";
            string Middle = "";
            string city = "";
            string zip = "";
            string street = "";
            string gender = "";
            string InsuranceID = "";
            string Phone1 = "";
            string Phone2 = "";
            string State = "";


            if (type == "EDIT" || type == "VIEW")
            {
                // get all data for this Patient
                PatientData = PatientDataTier.GetPatientInfo(PatientID).Tables[0];

                PatientID = (int)PatientData.Rows[0]["PatientID"];
                FirstName = (string)PatientData.Rows[0]["First Name"];
                LastName = (string)PatientData.Rows[0]["Last Name"];
                Middle = (string)PatientData.Rows[0]["Middle"];
                Email = (string)PatientData.Rows[0]["Email"];
                city = (string)PatientData.Rows[0]["City"];
                zip = (string)PatientData.Rows[0]["Zip"];
                State = (string)PatientData.Rows[0]["State"];
                street = (string)PatientData.Rows[0]["Street"];
                gender = (string)PatientData.Rows[0]["Gender"];
                insuranceName = (string)PatientData.Rows[0]["Insurance"];
                Phone1 = (string)PatientData.Rows[0]["Phone1"];
                Phone2 = (string)PatientData.Rows[0]["Phone2"];
            }
            ddlInsurance.DataTextField = "Insurance Name";
            ddlInsurance.DataValueField = "InsuranceID";
            ddlInsurance.DataBind();

            //UpdateDosages();
            if (type == "EDIT" || type == "VIEW")
            {
                // -- populate values
                txtPatientID.Text = PatientID.ToString();
                txtFname.Text = FirstName.ToString();
                txtLname.Text = LastName.ToString();
                txtMiddle.Text = Middle.ToString();
                ddlInsurance.SelectedValue = insuranceName.ToString();
                ddlState.DataSource = State.ToString();
                txtEmail.Text = Email.ToString();
                txtCity.Text = city.ToString();
                txtZip.Text = zip.ToString();
                txtStreet.Text = street.ToString();
                txtPhone1.Text = Phone1.ToString();
                txtPhone2.Text = Phone2.ToString();
            }
            else if (type == "ADD")
            {
                DataTable NewPatient = new DataTable();
                PatientData = PatientDataTier.GetPatientInfo(PatientID).Tables[0];

                PatientID = (int)PatientData.Rows[0]["PatientID"];
                FirstName = (string)PatientData.Rows[0]["First Name"];
                LastName = (string)PatientData.Rows[0]["Last Name"];
                Middle = (string)PatientData.Rows[0]["Middle"];
                Email = (string)PatientData.Rows[0]["Email"];
                city = (string)PatientData.Rows[0]["City"];
                zip = (string)PatientData.Rows[0]["Zip"];
                street = (string)PatientData.Rows[0]["Street"];
                State = (string)PatientData.Rows[0]["State"];
                gender = (string)PatientData.Rows[0]["Gender"];
                insuranceName = (string)PatientData.Rows[0]["Insurance"];
                Phone1 = (string)PatientData.Rows[0]["Phone1"];
                Phone2 = (string)PatientData.Rows[0]["Phone2"];

                txtPatientID.Text = PatientID.ToString();
                txtFname.Text = FirstName.ToString();
                txtLname.Text = LastName.ToString();
                txtMiddle.Text = Middle.ToString();
                ddlInsurance.SelectedValue = InsuranceID.ToString();
                txtEmail.Text = Email.ToString();
                txtCity.Text = city.ToString();
                txtZip.Text = zip.ToString();
                txtStreet.Text = street.ToString();
                txtPhone1.Text = Phone1.ToString();
                txtPhone2.Text = Phone2.ToString();



            }
        }
        protected void SetValidators()
        {
            int maxLength;
            DataSet dsColumns;

            dsColumns = GeneralDataTier.GetTableColumns("Patients");
            maxLength = GeneralDataTier.GetColumnMaxLength("FirstName", dsColumns);

            if (type == "VIEW")
            {
                rgxFname.Enabled = false;
                rgxLname.Enabled = false;
                rgxMiddle.Enabled = false;
                rngHeight.Enabled = false;
                rngWeight.Enabled = false;
                rgxStreet.Enabled = false;
                rgxZip.Enabled = false;
                rgxPhone1.Enabled = false;
                rgxPhone2.Enabled = false;
                rgxEmail.Enabled = false;
                rgxVisit.Enabled = false;
                rngStartDate.Enabled = false;
                rngEndDate.Enabled = false;
            }
            else
            {
                // check length
                txtFname.MaxLength = maxLength;
                rgxFname.ValidationExpression = GeneralDataTier.LengthExpression(maxLength);
                rgxFname.ErrorMessage = $"Must be {maxLength} characters or less";

                txtLname.MaxLength = maxLength;
                rgxLname.ValidationExpression = GeneralDataTier.LengthExpression(maxLength);
                rgxLname.ErrorMessage = $"Must be {maxLength} characters or less";

                txtMiddle.MaxLength = maxLength;
                rgxMiddle.ValidationExpression = GeneralDataTier.LengthExpression(maxLength);
                rgxMiddle.ErrorMessage = $"Must be {maxLength} characters or less";

                rngHeight.Type = ValidationDataType.Integer;
                rngHeight.ErrorMessage = $"Must be a whole number between {Int16.MinValue.ToString()} and {Int16.MaxValue.ToString()}";
                rngHeight.MinimumValue = Int16.MinValue.ToString();
                rngHeight.MaximumValue = Int16.MaxValue.ToString();

                rngWeight.Type = ValidationDataType.Integer;
                rngWeight.ErrorMessage = $"Must be a whole number between {Int16.MinValue.ToString()} and {Int16.MaxValue.ToString()}";
                rngWeight.MinimumValue = Int16.MinValue.ToString();
                rngWeight.MaximumValue = Int16.MaxValue.ToString();

                txtStreet.MaxLength = maxLength;
                rgxStreet.ValidationExpression = GeneralDataTier.LengthExpression(maxLength);
                rgxStreet.ErrorMessage = $"Must be {maxLength} characters or less";

                txtZip.MaxLength = maxLength;
                rgxZip.ValidationExpression = GeneralDataTier.LengthExpression(maxLength);
                rgxZip.ErrorMessage = $"Must be {maxLength} characters or less";

                txtPhone1.MaxLength = maxLength;
                rgxPhone1.ValidationExpression = GeneralDataTier.LengthExpression(maxLength);
                rgxPhone1.ErrorMessage = $"Must be {maxLength} characters or less";

                txtPhone2.MaxLength = maxLength;
                rgxPhone2.ValidationExpression = GeneralDataTier.LengthExpression(maxLength);
                rgxPhone2.ErrorMessage = $"Must be {maxLength} characters or less";

                txtEmail.MaxLength = maxLength;
                rgxEmail.ValidationExpression = GeneralDataTier.LengthExpression(maxLength);
                rgxEmail.ErrorMessage = $"Must be {maxLength} characters or less";

                txtVisit.MaxLength = maxLength;
                rgxVisit.ValidationExpression = GeneralDataTier.LengthExpression(maxLength);
                rgxVisit.ErrorMessage = $"Must be {maxLength} characters or less";

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
        protected void btnSave_Click()
        {
            int PatientID = 0;
            string FirstName = "";
            string LastName = "";
            string Email = "";
            string Middle = "";
            string city = "";
            string zip = "";
            string street = "";
            string gender = "";
            string InsuranceName = "";
            string Phone1 = "";
            string Phone2 = "";
            string State = "";

            bool fail = false;

            PatientID = Int32.Parse(txtPatientID.Text);
            FirstName = txtFname.Text;
            LastName = txtLname.Text;
            Email = txtEmail.Text;
            Middle = txtMiddle.Text;
            city = txtCity.Text;
            zip = txtZip.Text;
            street = txtStreet.Text;
            gender = ddlGender.SelectedValue;
            InsuranceName = ddlInsurance.SelectedValue;
            Phone1 = txtPhone1.Text;
            Phone2 = txtPhone2.Text;
            State = ddlState.SelectedValue;

            switch(type)
            {
                case "ADD":
                    PatientDataTier.AddPatient(
                        firstName, middle,lastName,street,city,state,phone1,phone2,zip,email,gender,insuranceName
                       );
                    break;
                case "UPDATE":
                    PatientDataTier.UpdatePatientByID(
                        patientID,
                        insuranceName,
                        firstName,
                        middle,
                        lastName,
                        street,
                        city,
                        state,
                        phone1,
                        phone2,
                        zip,
                        email,
                        gender);

                    break;
            }
            Saved = true;
        }

    }
}



