using _2024_CNSA212_Final_Group2;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CNSA216_EBC_project
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        private static string type;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void SetValidators()
        {
            int maxLength;
            DataSet dsColumns;

            dsColumns = GeneralDataTier.GetTableColumns("Patients");
            maxLength = GeneralDataTier.GetColumnMaxLength("FirstName", dsColumns);

            if (type == "VIEW")
            {
                rgxFName.Enabled = false;
                rgxLName.Enabled = false;
                rgxMiddle.Enabled = false;
                rgxStreet.Enabled = false;
                rgxZip.Enabled = false;
                rgxPhone.Enabled = false;
                rgxEmail.Enabled = false;


            }

            txtFName.MaxLength = maxLength;
            rgxFName.ValidationExpression = GeneralDataTier.LengthExpression(maxLength);
            rgxFName.ErrorMessage = $"Must be {maxLength} characters or less";

            txtLName.MaxLength = maxLength;
            rgxLName.ValidationExpression = GeneralDataTier.LengthExpression(maxLength);
            rgxLName.ErrorMessage = $"Must be {maxLength} characters or less";

            txtMiddle.MaxLength = maxLength;
            rgxMiddle.ValidationExpression = GeneralDataTier.LengthExpression(maxLength);
            rgxMiddle.ErrorMessage = $"Must be {maxLength} characters or less";

            txtPhone.MaxLength = maxLength;
            rgxPhone.ValidationExpression = GeneralDataTier.LengthExpression(maxLength);
            rgxPhone.ErrorMessage = $"Must be {maxLength} characters or less";

            txtEmail.MaxLength = maxLength;
            rgxEmail.ValidationExpression = GeneralDataTier.LengthExpression(maxLength);
            rgxEmail.ErrorMessage = $"Must be {maxLength} characters or less";

            txtStreet.MaxLength = maxLength;
            rgxStreet.ValidationExpression = GeneralDataTier.LengthExpression(maxLength);
            rgxStreet.ErrorMessage = $"Must be {maxLength} characters or less";

            txtCity.MaxLength = maxLength;
            rgxCity.ValidationExpression = GeneralDataTier.LengthExpression(maxLength);
            rgxCity.ErrorMessage = $"Must be {maxLength} characters or less";

            txtZip.MaxLength = maxLength;
            rgxZip.ValidationExpression = GeneralDataTier.LengthExpression(maxLength);
            rgxZip.ErrorMessage = $"Must be {maxLength} characters or less";

            rngStart.Type = ValidationDataType.Date;
            rngStart.ErrorMessage = $"Must be a date between {DateTime.MinValue.ToShortDateString()} and {DateTime.MaxValue.ToShortDateString()}";
            rngStart.MinimumValue = DateTime.MinValue.ToShortDateString();
            rngStart.MaximumValue = DateTime.MaxValue.ToShortDateString();

            rngEnd.Type = ValidationDataType.Date;
            rngEnd.ErrorMessage = $"Must be a date between {DateTime.MinValue.ToShortDateString()} and {DateTime.MaxValue.ToShortDateString()}";
            rngEnd.MinimumValue = DateTime.MinValue.ToShortDateString();
            rngEnd.MaximumValue = DateTime.MaxValue.ToShortDateString();
        }
        protected void BindData()
        {
            DataTable PhysicianData = new DataTable();
            int PhysicianID = 0;
            string FirstName = "";
            string LastName = "";
            string Email = "";
            string Middle = "";
            string city = "";
            string zip = "";
            string street = "";
            string gender = "";
            string State = "";
            string phone1 = "";


            if (type == "EDIT" || type == "VIEW")
            {
                // get all data for this Patient
                PhysicianData = PhysicianDataTier.GetPhysicianInfo(PhysicianID).Tables[0];

                PhysicianID = (int)PhysicianData.Rows[0]["PatientID"];
                FirstName = (string)PhysicianData.Rows[0]["First Name"];
                LastName = (string)PhysicianData.Rows[0]["Last Name"];
                Middle = (string)PhysicianData.Rows[0]["Middle"];
                Email = (string)PhysicianData.Rows[0]["Email"];
                city = (string)PhysicianData.Rows[0]["City"];
                zip = (string)PhysicianData.Rows[0]["Zip"];
                State = (string)PhysicianData.Rows[0]["State"];
                street = (string)PhysicianData.Rows[0]["Street"];
                gender = (string)PhysicianData.Rows[0]["Gender"];
                phone1 = (string)PhysicianData.Rows[0]["Phone"];
            }

            //UpdateDosages();
            if (type == "EDIT" || type == "VIEW")
            {
                // -- populate values
                txtPhysicianID.Text = PhysicianID.ToString();
                txtFName.Text = FirstName.ToString();
                txtLName.Text = LastName.ToString();
                txtMiddle.Text = Middle.ToString();
                ddlState.DataSource = State.ToString();
                txtEmail.Text = Email.ToString();
                txtCity.Text = city.ToString();
                txtZip.Text = zip.ToString();
                txtStreet.Text = street.ToString();
                txtPhone.Text = phone1.ToString();
            }
            else if (type == "ADD")
            {
                DataTable NewPatient = new DataTable();
                PhysicianData = PhysicianDataTier.GetPhysicianInfo(PhysicianID).Tables[0];

                PhysicianID = (int)PhysicianData.Rows[0]["PatientID"];
                FirstName = (string)PhysicianData.Rows[0]["First Name"];
                LastName = (string)PhysicianData.Rows[0]["Last Name"];
                Middle = (string)PhysicianData.Rows[0]["Middle"];
                Email = (string)PhysicianData.Rows[0]["Email"];
                city = (string)PhysicianData.Rows[0]["City"];
                zip = (string)PhysicianData.Rows[0]["Zip"];
                street = (string)PhysicianData.Rows[0]["Street"];
                State = (string)PhysicianData.Rows[0]["State"];
                gender = (string)PhysicianData.Rows[0]["Gender"];
                phone1 = (string)PhysicianData.Rows[0]["Phone1"];

                txtPhysicianID.Text = PhysicianID.ToString();
                txtFName.Text = FirstName.ToString();
                txtLName.Text = LastName.ToString();
                txtMiddle.Text = Middle.ToString();
                txtEmail.Text = Email.ToString();
                txtCity.Text = city.ToString();
                txtZip.Text = zip.ToString();
                txtStreet.Text = street.ToString();
            }


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

                    txtPhysicianID.Enabled = false;
                    txtFName.Enabled = true;
                    txtLName.Enabled = true;
                    ddlGender.Enabled = true;
                    txtMiddle.Enabled = true;
                    txtCity.Enabled = true;
                    txtStreet.Enabled = true;
                    txtZip.Enabled = true;
                    txtEmail.Enabled = true;
                    txtPhone.Enabled = true;
                case "VIEW":

                    txtPhysicianID.Enabled = false;
                    txtFName.Enabled = true;
                    txtLName.Enabled = true;
                    ddlGender.Enabled = true;
                    txtMiddle.Enabled = true;
                    txtCity.Enabled = true;
                    txtStreet.Enabled = true;
                    txtZip.Enabled = true;
                    txtEmail.Enabled = true;
                    txtPhone.Enabled = true;

                    btnAdd.Enabled = false;
                    btnAdd.Visible = false;

                    SetValidators();
                    BindData();
                    break;
                case "EDIT":

                    txtPhysicianID.Enabled = false;
                    txtFName.Enabled = true;
                    txtLName.Enabled = true;
                    ddlGender.Enabled = true;
                    txtMiddle.Enabled = true;
                    txtCity.Enabled = true;
                    txtStreet.Enabled = true;
                    txtZip.Enabled = true;
                    txtEmail.Enabled = true;
                    txtPhone.Enabled = true;
                    btnSave.Text = "Update";
                    SetValidators();
                    BindData();
                    break;
            }
        }
    }
}