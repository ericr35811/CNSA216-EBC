using _2024_CNSA212_Final_Group2;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CNSA216_EBC_project {
    public partial class WebForm5 : System.Web.UI.Page {
        private static int prescriptionID;
        private static int medicationID;
        private static string type;

        protected void GoBack() {
            Response.Redirect("frmSearch.aspx");
        }

        protected void BindData() {
            
            DataTable prescriptionData;

            int patientID;
            int physicianID;
            //int medicationID;
            int dosageID;
            string intakeMethod;
            string instructions;
            string extraInstructions;
            DateTime startDate;
            DateTime endDate;
            DateTime entryDateTime;

            // get all data for this prescription
            prescriptionData = PrescriptionDataTier.GetPrescriptionInfo(prescriptionID).Tables[0];

            patientID = (int)prescriptionData.Rows[0]["PatientID"];
            physicianID = (int)prescriptionData.Rows[0]["PhysicianID"];
            medicationID = (int)prescriptionData.Rows[0]["MedicineID"];
            dosageID = (int)prescriptionData.Rows[0]["DosageID"];
            intakeMethod = (string)prescriptionData.Rows[0]["IntakeMethod"];
            instructions = (string)prescriptionData.Rows[0]["Instructions"];
            extraInstructions = (string)prescriptionData.Rows[0]["ExtraInstructions"];
            startDate = (DateTime)prescriptionData.Rows[0]["StartDate"];
            endDate = (DateTime)prescriptionData.Rows[0]["EndDate"];
            entryDateTime = (DateTime)prescriptionData.Rows[0]["EnteredDateTime"];

            // -- populate DDLs
            // get dataset of all patients with only names and IDs
            ddlPatient.DataSource = PatientDataTier.GetPatientInfo(0, true, true);
            // bind to Patient ddl
            ddlPatient.DataTextField = "FullName";
            ddlPatient.DataValueField = "PatientID";
            ddlPatient.DataBind();
            
            ddlPhysician.DataSource = PhysicianDataTier.GetPhysicianInfo(0, true, true);
            ddlPhysician.DataTextField = "FullName";
            ddlPhysician.DataValueField = "PhysicianID";
            ddlPhysician.DataBind();
            
            ddlMedication.DataSource = MedicineDataTier.GetMedicineList();
            ddlMedication.DataTextField = "MedicineName";
            ddlMedication.DataValueField = "MedicineID";
            ddlMedication.DataBind();

            UpdateDosages();

            // -- populate values
            txtPrescriptionID.Text = prescriptionID.ToString();
            ddlPatient.SelectedValue = patientID.ToString();
            ddlPatient.SelectedValue = physicianID.ToString();
            ddlMedication.SelectedValue = medicationID.ToString();
            ddlDosage.SelectedValue = dosageID.ToString();
            txtIntakeMethod.Text = intakeMethod;
            txtInstructions.Text = instructions;
            txtExtraInstructions.Text = extraInstructions;
            txtStartDate.Text = startDate.ToString("yyyy-MM-dd"); // date needs to be in this format to set the value
            txtEndDate.Text = endDate.ToString("yyyy-MM-dd");
            txtEnteredDateTime.Text = entryDateTime.ToString();
        }

        protected void SetValidators() {
            int maxLength;
            DataSet dsColumns;

            dsColumns = GeneralDataTier.GetTableColumns("Prescriptions");
            

            // set validators according to max lengths in database
            maxLength = GeneralDataTier.GetColumnMaxLength("ExtraInstructions", dsColumns);
            txtExtraInstructions.MaxLength = maxLength;
            rgxExtraInstructions.ValidationExpression = GeneralDataTier.LengthExpression(maxLength);
            rgxExtraInstructions.ErrorMessage = $"Must be {maxLength} characters or less";

            rngStartDate.Type = ValidationDataType.Date;
            rngStartDate.ErrorMessage = $"Must be a date between {DateTime.MinValue.ToShortDateString()} and {DateTime.MaxValue.ToShortDateString()}";
            rngStartDate.MinimumValue = DateTime.MinValue.ToShortDateString();
            rngStartDate.MaximumValue = DateTime.MaxValue.ToShortDateString();

            rngEndDate.Type = ValidationDataType.Date;
            rngEndDate.ErrorMessage = $"Must be a date between {DateTime.MinValue.ToShortDateString()} and {DateTime.MaxValue.ToShortDateString()}";
            rngEndDate.MinimumValue = DateTime.MinValue.ToShortDateString();
            rngEndDate.MaximumValue = DateTime.MaxValue.ToShortDateString();

            


            // get list of table columns and lengths
            dsColumns = GeneralDataTier.GetTableColumns("Patients");

            // -- string length validator
            maxLength = GeneralDataTier.GetColumnMaxLength("FirstName", dsColumns);

            txtString.MaxLength = maxLength;
            rgxString.ValidationExpression = GeneralDataTier.LengthExpression(maxLength);
            rgxString.ErrorMessage = $"Must be {maxLength} characters or less";


            // -- date validator
            maxLength = GeneralDataTier.GetColumnMaxLength("StartDate", dsColumns);
            rngDate.Type = ValidationDataType.Date;
            rngDate.ErrorMessage = $"Must be a date between {DateTime.MinValue.ToShortDateString()} and {DateTime.MaxValue.ToShortDateString()}";
            rngDate.MinimumValue = DateTime.MinValue.ToShortDateString();
            rngDate.MaximumValue = DateTime.MaxValue.ToShortDateString();

            // -- number validator (SmallInt/Int16)
            // change "Int16" to "Int32" for Int/Int32
            maxLength = GeneralDataTier.GetColumnMaxLength("Weight", dsColumns);
            rngSmallInt.Type = ValidationDataType.Integer;
            rngSmallInt.ErrorMessage = $"Must be a whole number between {Int16.MinValue.ToString()} and {Int16.MaxValue.ToString()}";
            rngSmallInt.MinimumValue = Int16.MinValue.ToString();
            rngSmallInt.MaximumValue = Int16.MaxValue.ToString();
        }

        protected void PreparePage() {
            
            
            switch (type) {
                case "ADD":
                    btnSave.Text = "Add";
                    break;
                case "VIEW":
                    ddlPatient.Enabled = false;
                    ddlPhysician.Enabled = false;
                    ddlMedication.Enabled = false;
                    ddlDosage.Enabled = false;
                    txtExtraInstructions.Enabled = false;
                    txtStartDate.Enabled = false;
                    txtEndDate.Enabled = false;

                    btnSave.Enabled = false;
                    btnSave.Visible = false;

                    SetValidators();
                    BindData();
                    break;
                case "EDIT":
                    btnSave.Text = "Save";
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
                            } else {
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
                
            } else {

            }
        }

        protected void UpdateDosages() {
            // update the dosage DDL when medication is changed
            ddlDosage.DataSource = MedicineDataTier.GetMedicine(medicationID);
            ddlDosage.DataTextField = "Dosage";
            ddlDosage.DataValueField = "DosageID";
            ddlDosage.DataBind();
        }

        protected void ddlMedication_SelectedIndexChanged(object sender, EventArgs e) {
            Int32.TryParse(ddlMedication.SelectedValue, out medicationID);
            UpdateDosages();
        }

        protected void btnSave_Click(object sender, EventArgs e) {
            int patientID;
            int physicianID;
            //int medicationID;
            int dosageID;
            string intakeMethod;
            string instructions;
            string extraInstructions;
            DateTime startDate;
            DateTime endDate;
            DateTime entryDateTime;
            bool fail = false;

            fail |= Int32.TryParse(ddlPatient.SelectedValue, out patientID);
            fail |= Int32.TryParse(ddlPhysician.SelectedValue, out physicianID);
            fail |= Int32.TryParse(ddlMedication.SelectedValue,out medicationID);
            fail |= Int32.TryParse(ddlDosage.SelectedValue,out dosageID);
            extraInstructions = txtExtraInstructions.Text;
            fail |= DateTime.TryParse(txtStartDate.Text, out startDate);
            fail |= DateTime.TryParse(txtEndDate.Text, out endDate);
            fail |= DateTime.TryParse(txtEnteredDateTime.Text, out entryDateTime);

            switch (type) {
                case "ADD":
                    PrescriptionDataTier.AddPrescription
                    break;
                case "EDIT":
                    break;
            }
        }
    }
}