using _2024_CNSA212_Final_Group2;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CNSA216_EBC_project {
    public partial class WebForm6 : System.Web.UI.Page {
        private static int prescriptionID;
        private static int medicationID;
        private static string type;

        protected void GoBack() {
            Response.Redirect("frmSearch.aspx");
        }

        protected void BindData() {

            DataTable RefillData;
            int RefillID;
            int patientID;
            int ClerckID;
            int PrescriptionID;
            string patientName;
            string prescriptionName;
            DateTime entryDateTime;

            // get all data for this prescription
          RefillData= RefillDataTier.GetRefill(RefillID).Tables[0];

            patientID = (int)RefillData.Rows[0]["PatientID"];
            ClerckID = (int)RefillData.Rows[0]["ClerckID"];
            PrescriptionID = (int)RefillData.Rows[0]["PrescriptionID"];
            patientName = (string)RefillData.Rows[0]["PatientName"];
            prescriptionName = (string)RefillData.Rows[0]["PrescriptionName"];
            entryDateTime = (DateTime)RefillData.Rows[0]["EnteredDateTime"];

            // -- populate DDLs
            // get dataset of all patients with only names and IDs
            ddlClerckName.DataSource = ClerkDataTier.GetClerks();

            // bind to Patient ddl
            ddlClerckName.DataTextField = "FullName";
            ddlClerckName.DataValueField = "ClerkID";
            ddlClerckName.DataBind();

            //UpdateDosages();

            // -- populate values
            txtPatientID.Text= patientID.ToString();
            txtPrescID.Text = PrescriptionID.ToString();
            txtPatientFName.Text = patientName.ToString();
            txtPresNameDose.Text = prescriptionName.ToString();
            ddlClerckName.SelectedValue = ClerckID.ToString();
            txtDateTime.Text = entryDateTime.ToString();
        }

        protected void SetValidators() {
            int maxLength;
            DataSet dsColumns;

            // set validators according to max lengths in database
            rngDateTime.Type = ValidationDataType.Date;
            rngDateTime.ErrorMessage = $"Must be a date between {DateTime.MinValue.ToShortDateString()} and {DateTime.MaxValue.ToShortDateString()}";
            rngDateTime.MinimumValue = DateTime.MinValue.ToShortDateString();
            rngDateTime.MaximumValue = DateTime.MaxValue.ToShortDateString();
        }

        protected void PreparePage() {


            switch (type) {
                case "ADD":
                    btnSave.Text = "Add";
                    break;

                    txtPatientID.Enabled = false;
                    txtPrescID.Enabled = false;
                    txtPatientFName.Enabled = false;
                    txtPresNameDose.Enabled = false;
                    ddlClerckName.Enabled = true;
                    txtDateTime.Enabled = true;
                case "VIEW":

                    txtPatientID.Enabled = false;
                    txtPrescID.Enabled = false;
                    txtPatientFName.Enabled = false;
                    txtPresNameDose.Enabled = false;
                    ddlClerckName.Enabled = false;
                    txtDateTime.Enabled = false;

                    btnSave.Enabled = false;
                    btnSave.Visible = false;

                    SetValidators();
                    BindData();
                    break;
                case "EDIT":

                    txtPatientID.Enabled = false;
                    txtPrescID.Enabled = false;
                    txtPatientFName.Enabled = false;
                    txtPresNameDose.Enabled = false;
                    ddlClerckName.Enabled = true;
                    txtDateTime.Enabled = true;
                    btnSave.Text = "ConfirmRefill";
                    SetValidators();
                    BindData();
                    break;
            }
        }

        protected void Page_Load(object sender, EventArgs e) {

            //string type;
            bool success;

            if (!IsPostBack) {
                // check if query string contains the type key
                if (Request.QueryString.AllKeys.Contains("type") && !String.IsNullOrEmpty(Request.QueryString["type"])) {
                    type = Request.QueryString["type"];

                    // ignore the id if type is ADD
                    if (type != "ADD") {
                        // check if query string contains the id key
                        if (Request.QueryString.AllKeys.Contains("id") && !String.IsNullOrEmpty(Request.QueryString["id"])) {
                            success = Int32.TryParse(SecureID.Decrypt(Request.QueryString["id"].Trim()), out prescriptionID);
                            if (!success) {
                                GoBack();
                            }
                            else {
                                PreparePage();
                            };
                        }
                        else {
                            GoBack();
                        }
                    }
                }
                else {
                    GoBack();
                }

            }
            else {

            }
        }
    }
}