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
        private static int PhysicianID = 0;
        private static string firstName;
        private static string lastName;
        private static string email;
        private static string middle;
        private static string city;
        private static string zip;
        private static string street;
        private static string state;
        private static string phone1;
        private static bool Saved = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            bool success;
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
            txtStartDate.Enabled = true;
            txtEndDate.Enabled = true;

            if (!IsPostBack)
            {
                // check if query string contains the type key
                if (Request.QueryString.AllKeys.Contains("type") && !String.IsNullOrEmpty(Request.QueryString["type"]))
                {
                    type = Request.QueryString["type"];

                    // ignore the id if type is ADD
                    if (type != "ADD")
                    {
                        // check if query string contains the id key
                        if (Request.QueryString.AllKeys.Contains("id") && !String.IsNullOrEmpty(Request.QueryString["id"]))
                        {
                            success = Int32.TryParse(SecureID.Decrypt(Request.QueryString["id"]), out PhysicianID);
                            if (!success)
                            {
                                GoBack();
                            }
                            else
                            {
                                PreparePage();
                            };
                        }
                        else
                        {
                            GoBack();
                        }
                    }
                    else {
                        PreparePage();
                    }
                }
                else
                {
                    GoBack();
                }

            }

        }

        protected void SetValidators()
        {
            DataSet dsColumns;

            dsColumns = GeneralDataTier.GetTableColumns("Patients");

            txtFName.MaxLength = GeneralDataTier.GetColumnMaxLength("FirstName", dsColumns);                        
            txtLName.MaxLength = GeneralDataTier.GetColumnMaxLength("LastName", dsColumns);                        
            txtMiddle.MaxLength = GeneralDataTier.GetColumnMaxLength("Middle", dsColumns);                        
            txtPhone.MaxLength = GeneralDataTier.GetColumnMaxLength("Phone1", dsColumns);                        
            txtEmail.MaxLength = GeneralDataTier.GetColumnMaxLength("Email", dsColumns);                        
            txtStreet.MaxLength = GeneralDataTier.GetColumnMaxLength("Street", dsColumns);                        
            txtCity.MaxLength = GeneralDataTier.GetColumnMaxLength("City", dsColumns);                        
            txtZip.MaxLength = GeneralDataTier.GetColumnMaxLength("Zip", dsColumns);
                        
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
            //int PhysicianID = 0;
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
            DateTime startDate = new DateTime();
            DateTime endDate = new DateTime();  

            ddlState.DataSource = GeneralDataTier.GetStates().Tables[0];
            ddlState.DataTextField = "StateName";
            ddlState.DataValueField = "State";
            ddlState.DataBind();

            ddlGender.DataSource = GeneralDataTier.GetGenders().Tables[0];
            ddlGender.DataTextField = "GenderName";
            ddlGender.DataValueField = "Gender";
            ddlGender.DataBind();

            if (type == "EDIT" || type == "VIEW")
            {
                // get all data for this Patient
                PhysicianData = PhysicianDataTier.GetPhysicianInfo(PhysicianID).Tables[0];

                PhysicianID = (int)PhysicianData.Rows[0]["PhysicianID"];
                FirstName = (string)PhysicianData.Rows[0]["FirstName"];
                LastName = (string)PhysicianData.Rows[0]["LastName"];
                Middle = (string)PhysicianData.Rows[0]["Middle"];
                Email = (string)PhysicianData.Rows[0]["Email"];
                city = (string)PhysicianData.Rows[0]["City"];
                zip = (string)PhysicianData.Rows[0]["Zip"];
                State = (string)PhysicianData.Rows[0]["State"];
                street = (string)PhysicianData.Rows[0]["Street"];
                gender = (string)PhysicianData.Rows[0]["Gender"];
                phone1 = (string)PhysicianData.Rows[0]["Phone1"];
                startDate = (DateTime)PhysicianData.Rows[0]["StartDate"];
                endDate = (DateTime)PhysicianData.Rows[0]["EndDate"];
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
                txtStartDate.Text = startDate.ToString("yyyy-MM-dd");
                txtEndDate.Text = endDate.ToString("yyyy-MM-dd");
            }
            


        }
        protected void PreparePage()
        {
            switch (type)
            {
                case "ADD":
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
                    btnAdd.Text = "Add";
                    SetValidators();
                    BindData();
                    break;
                case "VIEW":

                    txtPhysicianID.Enabled = false;
                    txtFName.Enabled = false;
                    txtLName.Enabled = false;
                    ddlGender.Enabled = false;
                    txtMiddle.Enabled = false;
                    txtCity.Enabled = false;
                    txtStreet.Enabled = false;
                    txtZip.Enabled = false;
                    txtEmail.Enabled = false;
                    txtPhone.Enabled = false;
                    ddlState.Enabled = false; 
                    ddlGender.Enabled = false;

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
                    btnAdd.Text = "Update";
                    SetValidators();
                    BindData();
                    break;
            }
        }

        protected void GoBack() {
            //Response.Redirect("frmSearch.aspx?search=Prescriptions");
            Session["refresh"] = true;

            // if the user saved a record, craft a search to show them the new record
            // otherwise the cached search will be used

            if (Saved && type != "ADD") {

                SearchParameters param = new SearchParameters();
                param.tableName = "Prescriptions";
                param.showActive = true;
                param.showInactive = false;
                param.param1Col = "PrescriptionID";
                param.param1 = PhysicianID.ToString();
                param.andOr = "O";
                param.param2Col = "";
                param.param2 = "";
                Session["searchParameters"] = param;
            }

            Response.Redirect("frmSearch.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            GoBack();
        }
        
        protected void btnAdd_Click(object sender, EventArgs e) {
            //int PhysicianID = 0;
            string FirstName = "";
            string LastName = "";
            string email = "";
            string Middle = "";
            string city = "";
            string zip = "";
            string street = "";
            string gender = "";
            string Phone1 = "";
            string state = "";
            DateTime startDate = new DateTime();
            DateTime endDate = new DateTime();

            //PhysicianID = Int32.Parse(txtPhysicianID.Text);
            FirstName = txtFName.Text;
            LastName = txtLName.Text;
            email = txtEmail.Text;
            Middle = txtMiddle.Text;
            city = txtCity.Text;
            zip = txtZip.Text;
            street = txtStreet.Text;
            gender = ddlGender.SelectedValue;
            Phone1 = txtPhone.Text;
            state = ddlState.SelectedValue;
            startDate = DateTime.Parse(txtStartDate.Text);
            endDate = DateTime.Parse(txtEndDate.Text);

            switch (type) {
                case "ADD":
                    PhysicianDataTier.AddPhysician(
                        FirstName,
                        Middle,
                        LastName,
                        street,
                        city,
                        state,
                        Phone1,
                        zip,
                        email,
                        gender,
                        startDate,
                        endDate
                        ); break;

                case "EDIT":
                    PhysicianDataTier.UpdatePhysicianInfo(
                    PhysicianID.ToString(),
                        FirstName,
                    LastName,
                    Middle,
                    street,
                    city,
                    state,
                    zip,
                    Phone1,
                    gender,
                    email,
                    startDate,
                    endDate
                    ); break;

            }
        }
    }
}
    

