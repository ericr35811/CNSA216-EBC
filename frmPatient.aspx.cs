using _2024_CNSA212_Final_Group2;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CNSA216_EBC_project {
    public partial class Webform4 : System.Web.UI.Page
    {
        private static int patientID = 0;
        private static string FirstName;
        private static string LastName;
        private static string Email;
        private static string Middle;
        private static string city;
        private static string zip;
        private static string street;
        private static string gender;
        private static int InsuranceID = 0;
        private static string Phone1;
        private static string Phone2;

        protected void GoBack()
        {
            Response.Redirect("frmSearch.aspx");

        }
    }
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
        public partial class WebForm3 : System.Web.UI.Page {
        private static string type;
        protected void Page_Load(object sender, EventArgs e) {

            int maxLength;
            DataSet dsColumns;

            dsColumns = GeneralDataTier.GetTableColumns("Patients");
            maxLength = GeneralDataTier.GetColumnMaxLength("FirstName", dsColumns);

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

        protected void btnBack_Click(object sender, System.EventArgs e)
        {
            GoBack();
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
        

                protected void btnAdd_Click(object sender, EventArgs e)
        {
            int insuranceID;
            string firstName;
            string middle;
            string lastName;
            string street;
            string city;
            string state;
            string phone1;
            string phone2;
            string zip;
            string email;
            string gender;

            switch (type)
            {
                case "ADD":

                    PatientDataTier.AddPatient(
                        patientID,
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
                        gender,
                        insuranceID
                        );
                    break;

                case "UPDATE";
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
    }
    }

