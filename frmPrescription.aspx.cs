using _2024_CNSA212_Final_Group2;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CNSA216_EBC_project {
    public partial class WebForm5 : System.Web.UI.Page {
        private static int prescriptionID = 0;
        private static int medicationID = 0;
        private static int patientID = 0;
        private static string type;
        private static DataTable selectedMedicine;
        private static bool saved = false;

        protected void GoBack() {
            //Response.Redirect("frmSearch.aspx?search=Prescriptions");
            Session["refresh"] = true;

            // if the user saved a record, craft a search to show them the new record
            if (saved) {
                SearchParameters param = new SearchParameters();
                param.tableName = "Prescriptions";
                param.showActive = true;
                param.showInactive = false;
                param.param1Col = "PrescriptionID";
                param.param1 = prescriptionID.ToString();
                param.andOr = "O";
                param.param2Col = "";
                param.param2 = "";
                Session["searchParameters"] = param;
            }
            
            Response.Redirect("frmSearch.aspx");
        }

        protected void BindData() {
            
            DataTable dataTable;

            //int patientID = 0;
            int physicianID = 0;
            //int medicationID;
            int dosageID = 0;
            string intakeMethod = "";
            string instructions = "";
            string extraInstructions = "";
            DateTime startDate = DateTime.MinValue ;
            DateTime endDate = DateTime.MinValue; 
            DateTime entryDateTime = DateTime.MinValue;
            Int16 refillsAllowed = 0;
            Int16 refillsLeft = 0;
            Int16 refillQuantity = 0;

            // only get existing data if editing or viewing
            if (type == "EDIT" || type == "VIEW") {
                // get all data for this prescription
                dataTable = PrescriptionDataTier.GetPrescriptionInfo(prescriptionID).Tables[0];

                patientID = (int)dataTable.Rows[0]["PatientID"];
                physicianID = (int)dataTable.Rows[0]["PhysicianID"];
                medicationID = (int)dataTable.Rows[0]["MedicineID"];
                dosageID = (int)dataTable.Rows[0]["DosageID"];
                intakeMethod = (string)dataTable.Rows[0]["IntakeMethod"];
                instructions = (string)dataTable.Rows[0]["Instructions"];
                extraInstructions = (string)dataTable.Rows[0]["ExtraInstructions"];
                startDate = (DateTime)dataTable.Rows[0]["StartDate"];
                endDate = (DateTime)dataTable.Rows[0]["EndDate"];
                entryDateTime = (DateTime)dataTable.Rows[0]["EnteredDateTime"];
                refillsAllowed = (Int16)dataTable.Rows[0]["RefillsAllowed"];
                refillsLeft = (Int16)dataTable.Rows[0]["RefillsLeft"];
                refillQuantity = (Int16)dataTable.Rows[0]["RefillQuantity"];
            }

            // -- populate DDLs
            // only do all this data binding if editing or adding
            if (type == "EDIT" || type == "ADD") {

                // get dataset of all patients with only names and IDs
                dataTable = PatientDataTier.GetPatientInfo(0, true, true).Tables[0];
                DataRow InitialValue = dataTable.NewRow();
                InitialValue["FullName"] = "Select one...";
                InitialValue["PatientID"] = 0;
                dataTable.Rows.InsertAt(InitialValue, 0);

                ddlPatient.DataSource = dataTable;
                // bind to Patient ddl
                ddlPatient.DataTextField = "FullName";
                ddlPatient.DataValueField = "PatientID";
                ddlPatient.DataBind();

                dataTable = PhysicianDataTier.GetPhysicianInfo(0, true, true).Tables[0];
                InitialValue = dataTable.NewRow();
                InitialValue["FullName"] = "Select one...";
                InitialValue["PhysicianID"] = 0;
                dataTable.Rows.InsertAt(InitialValue, 0);

                ddlPhysician.DataSource = dataTable;
                ddlPhysician.DataTextField = "FullName";
                ddlPhysician.DataValueField = "PhysicianID";
                ddlPhysician.DataBind();

                dataTable = MedicineDataTier.GetMedicineList().Tables[0];
                InitialValue = dataTable.NewRow();
                InitialValue["MedicineName"] = "Select one...";
                InitialValue["MedicineID"] = 0;
                dataTable.Rows.InsertAt(InitialValue, 0);

                ddlMedication.DataSource = dataTable;
                ddlMedication.DataTextField = "MedicineName";
                ddlMedication.DataValueField = "MedicineID";
                ddlMedication.DataBind();

                UpdateDosages();
            }

            if (type == "EDIT" || type == "VIEW") {
                // if viewing, just set the text
                if (type == "VIEW") {
                    ddlPatient.Items.Add(patientID.ToString());
                    ddlPhysician.Items.Add(physicianID.ToString());
                    ddlMedication.Items.Add(medicationID.ToString());
                    ddlDosage.Items.Add(dosageID.ToString());
                }
                // if editing, select the value
                else if (type == "EDIT") {
                    ddlPatient.SelectedValue = patientID.ToString();
                    ddlPhysician.SelectedValue = physicianID.ToString();
                    ddlMedication.SelectedValue = medicationID.ToString();
                    ddlDosage.SelectedValue = dosageID.ToString();
                }
                
                // -- populate other values
                txtPrescriptionID.Text = prescriptionID.ToString();
                
                txtIntakeMethod.Text = intakeMethod;
                txtInstructions.Text = instructions;
                txtExtraInstructions.Text = extraInstructions;
                txtStartDate.Text = startDate.ToString("yyyy-MM-dd"); // date needs to be in this format to set the value
                txtEndDate.Text = endDate.ToString("yyyy-MM-dd");
                txtEnteredDateTime.Text = entryDateTime.ToString();
                txtRefillsAllowed.Text = refillsAllowed.ToString();
                txtRefillsLeft.Text = refillsLeft.ToString();
                txtRefillQuantity.Text = refillQuantity.ToString();
            }
            else if (type == "ADD") {
                ddlPatient.SelectedValue = patientID.ToString();
            }
        }

        protected void SetValidators() {
            int maxLength;
            DataSet dsColumns;

            dsColumns = GeneralDataTier.GetTableColumns("Prescriptions");


            if (type == "VIEW") {
                rgxExtraInstructions.Enabled = false;
                rngStartDate.Enabled = false;
                rngEndDate.Enabled = false;
                rngRefillsAllowed.Enabled = false;
                rngRefillsLeft.Enabled = false;
                rngRefillQuantity.Enabled = false;
                cmpRefillsLeft.Enabled = false;

                rgxString.Enabled = false;
                rngDate.Enabled = false;
                rngSmallInt.Enabled = false;
            }
            else { 
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

                rngRefillsAllowed.Type = ValidationDataType.Integer;
                rngRefillsAllowed.ErrorMessage = $"Must be a whole number between {Int16.MinValue.ToString()} and {Int16.MaxValue.ToString()}";
                rngRefillsAllowed.MinimumValue = Int16.MinValue.ToString();
                rngRefillsAllowed.MaximumValue = Int16.MaxValue.ToString();

                rngRefillsLeft.Type = ValidationDataType.Integer;
                rngRefillsLeft.ErrorMessage = $"Must be a whole number between {Int16.MinValue.ToString()} and {Int16.MaxValue.ToString()}";
                rngRefillsLeft.MinimumValue = Int16.MinValue.ToString();
                rngRefillsLeft.MaximumValue = Int16.MaxValue.ToString();

                rngRefillQuantity.Type = ValidationDataType.Integer;
                rngRefillQuantity.ErrorMessage = $"Must be a whole number between {Int16.MinValue.ToString()} and {Int16.MaxValue.ToString()}";
                rngRefillQuantity.MinimumValue = Int16.MinValue.ToString();
                rngRefillQuantity.MaximumValue = Int16.MaxValue.ToString();

                //cmpRefillsLeft.Type = ValidationDataType.Integer;
                //cmpRefillsLeft.ErrorMessage = "May not be greater than Refills Allowed";

                // ---------------------------------------------------------

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
        }

        protected void PreparePage() {
            
            
            switch (type) {
                case "ADD":
                    //RegisterStartupScript("")
                    btnSave.Text = "Add";
                    SetValidators();
                    BindData();
                    break;
                case "VIEW":
                    ddlPatient.Enabled = false;
                    ddlPhysician.Enabled = false;
                    ddlMedication.Enabled = false;
                    ddlDosage.Enabled = false;
                    txtExtraInstructions.Enabled = false;
                    txtStartDate.Enabled = false;
                    txtEndDate.Enabled = false;
                    txtEnteredDateTime.Enabled = false;
                    txtRefillQuantity.Enabled = false;
                    txtRefillsAllowed.Enabled = false;
                    txtRefillsLeft.Enabled = false;

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
            int id;

            if (!IsPostBack) {
                // check if query string contains the type key
                if (Request.QueryString.AllKeys.Contains("type") && !String.IsNullOrEmpty(Request.QueryString["type"])) {
                    type = Request.QueryString["type"];

                    // check if query string contains the id key
                    if (Request.QueryString.AllKeys.Contains("id") && !String.IsNullOrEmpty(Request.QueryString["id"])) {
                        // try to parse the ID
                        success = Int32.TryParse(SecureID.Decrypt(Request.QueryString["id"].Trim()), out id);
                        
                        if (!success) {
                            GoBack();
                        } else {
                            // If adding new prescription, the ID refers to the Patient ID to add the prescription for
                            // Otherwise, ID is the prescription ID
                            if (type == "ADD") patientID = id;
                            else prescriptionID = id;
                            PreparePage();
                        };
                    }
                    else {
                        GoBack();
                    }
                }
                else {
                    GoBack();
                }
                
            } else {

            }
        }

        protected void UpdateDosages() {
            DataRow InitialValue;
            //DataTable dataTable;
            // update the dosage DDL when medication is changed
            selectedMedicine = MedicineDataTier.GetMedicine(medicationID).Tables[0];
            //Session["SelectedMedicine"] = selectedMedicine;

            InitialValue = selectedMedicine.NewRow();
            InitialValue["Dosage"] = "Select one...";
            InitialValue["DosageID"] = 0;
            selectedMedicine.Rows.InsertAt(InitialValue, 0);

            ddlDosage.DataSource = selectedMedicine;
            ddlDosage.DataTextField = "Dosage";
            ddlDosage.DataValueField = "DosageID";
            ddlDosage.DataBind();
            ddlDosage.SelectedIndex = 0;

            UpdateMedicineInfo();
        }
                   
        protected void ddlDosage_SelectedIndexChanged(object sender, EventArgs e) {
            UpdateMedicineInfo();
        }

        protected void UpdateMedicineInfo() {
            if (selectedMedicine != null) {
                txtIntakeMethod.Text = selectedMedicine.Rows[ddlDosage.SelectedIndex]["IntakeMethod"].ToString();
                txtInstructions.Text = selectedMedicine.Rows[ddlDosage.SelectedIndex]["Instructions"].ToString();
            }
        }

        protected void ddlMedication_SelectedIndexChanged(object sender, EventArgs e) {
            Int32.TryParse(ddlMedication.SelectedValue, out medicationID);
            UpdateDosages();
        }

        protected void btnSave_Click(object sender, EventArgs e) {
            int patientID = 0;
            int physicianID = 0;
            //int medicationID;
            int dosageID = 0;
            string extraInstructions = "";
            DateTime startDate = DateTime.MinValue;
            DateTime endDate = DateTime.MinValue;
            DateTime entryDateTime = DateTime.MinValue;
            Int16 refillsAllowed = 0;
            Int16 refillsLeft = 0;
            Int16 refillQuantity = 0;

            bool fail = false;

            patientID = Int32.Parse(ddlPatient.SelectedValue);
            physicianID = Int32.Parse(ddlPhysician.SelectedValue);
            medicationID = Int32.Parse(ddlMedication.SelectedValue);
            dosageID = Int32.Parse(ddlDosage.SelectedValue);
            extraInstructions = txtExtraInstructions.Text;
            startDate = DateTime.Parse(txtStartDate.Text);
            endDate = DateTime.Parse(txtEndDate.Text);
            entryDateTime = DateTime.Parse(txtEnteredDateTime.Text);
            refillsAllowed = Int16.Parse(txtRefillsAllowed.Text);
            refillsLeft = Int16.Parse(txtRefillsLeft.Text);
            refillQuantity = Int16.Parse(txtRefillQuantity.Text);

            switch (type) {
                case "ADD":
                    PrescriptionDataTier.AddPrescription(
                        patientID,
                        dosageID,
                        physicianID,
                        startDate,
                        endDate,
                        entryDateTime,
                        extraInstructions,
                        refillsAllowed,
                        refillsLeft,
                        refillQuantity
                    );
                    break;
                case "EDIT":
                    PrescriptionDataTier.UpdatePrescription(
                        prescriptionID,
                        dosageID,
                        patientID,
                        physicianID,
                        startDate,
                        endDate,
                        entryDateTime,
                        extraInstructions,
                        refillsAllowed,
                        refillsLeft,
                        refillQuantity
                    );
                    break;
            }

            saved = true;
        }

        protected void btnGoBack_Click(object sender, EventArgs e) {
            GoBack();
        }
    }
}