using _2024_CNSA212_Final_Group2;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.ClientServices.Providers;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CNSA216_EBC_project {
    public partial class WebForm6 : System.Web.UI.Page {
        private static int prescriptionID;
        private static int medicationID;
        private static string type;
        private static int RefillID;
        private static bool Saved=false;
        protected void GoBack() {
            Response.Redirect("frmSearch.aspx");
        }

        protected void BindData() {

            DataTable RefillData = new DataTable();
            int patientID = 0;
            int ClerckID = 0;
            int PrescriptionID = 0;
            string patientName = "";
            string prescriptionName = "";
            DateTime entryDateTime = DateTime.Parse("1/1/0001");

            if (type == "EDIT" || type == "VIEW") {
                // get all data for this prescription
                RefillData = RefillDataTier.GetRefill(RefillID).Tables[0];

                patientID = (int)RefillData.Rows[0]["PatientID"];
                ClerckID = (int)RefillData.Rows[0]["ClerkID"];
                PrescriptionID = (int)RefillData.Rows[0]["PrescriptionID"];
                patientName = (string)RefillData.Rows[0]["PatientName"];
                prescriptionName = (string)RefillData.Rows[0]["PrescriptionName"];
                entryDateTime = (DateTime)RefillData.Rows[0]["EnteredDateTime"];
            }
            // -- populate DDLs
            // get dataset of all patients with only names and IDs
            ddlClerckName.DataSource = ClerkDataTier.GetClerks();

            // bind to Patient ddl
            ddlClerckName.DataTextField = "FullName";
            ddlClerckName.DataValueField = "ClerkID";
            ddlClerckName.DataBind();

            //UpdateDosages();
            if (type == "EDIT" || type == "VIEW") {
                // -- populate values
                txtPatientID.Text = patientID.ToString();
                txtPrescID.Text = PrescriptionID.ToString();
                txtPatientFName.Text = patientName.ToString();
                txtPresNameDose.Text = prescriptionName.ToString();
                ddlClerckName.SelectedValue = ClerckID.ToString();
                txtDateTime.Text = entryDateTime.ToString();
                txtDateTime.Enabled = true;
                txtRefillID.Text = RefillID.ToString();
                btnSave.Enabled = true;
            }
            else if (type == "ADD") {
                DataTable prescriptionInfo = new DataTable();
                prescriptionInfo = PrescriptionDataTier.GetPrescriptionInfo(prescriptionID).Tables[0];

                patientID = (int)prescriptionInfo.Rows[0]["PatientID"];
                PrescriptionID = (int)prescriptionInfo.Rows[0]["PrescriptionID"];
                patientName = (string)prescriptionInfo.Rows[0]["PatientFirstName"];
                prescriptionName = (string)prescriptionInfo.Rows[0]["PrescriptionLabel"];

                txtPatientID.Text = patientID.ToString();
                txtPrescID.Text = PrescriptionID.ToString();
                txtPatientFName.Text = patientName.ToString();
                txtPresNameDose.Text = prescriptionName.ToString();
            
            }
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
                    SetValidators();
                    txtDateTime.Text = DateTime.Now.ToString();
                    BindData();
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
                    btnSave.Text = "Update";
                    SetValidators();
                    BindData();
                    break;
            }
        }
        //protected void AddRecord_Database()
        //{
        //    string connetionString = null;
        //    SqlConnection cnn;
        //    SqlDataAdapter adapter = new SqlDataAdapter();
        //    string sql = null;
        //    connetionString = "Data Source=10.200.150.21;Initial Catalog=CNSA216-EBC; Trusted_Connection=True;";

        //    cnn = new SqlConnection(connetionString);
        //    //sql = "insert into Main (Firt Name, Last Name) values(textbox2.Text,textbox3.Text)";

        //    try
        //    {
        //        cnn.Open();
        //        adapter.InsertCommand = new SqlCommand(sql, cnn);
        //        adapter.InsertCommand.ExecuteNonQuery();
        //        //MessageBox.Show("Row inserted !! ");
        //    }
        //    catch (Exception ex)
        //    {
        //        //MessageBox.Show(ex.ToString());
        //    }
        //}

        protected void Page_Load(object sender, EventArgs e) {

            //string type;
            bool success;
            int id;
            txtDateTime.Text = DateTime.Now.ToString();
            txtPresNameDose.Enabled= false;
            txtPatientFName.Enabled= false;

            if (!IsPostBack)
            {
                Saved = true;
                // check if query string contains the type key
                if (Request.QueryString.AllKeys.Contains("type") && !String.IsNullOrEmpty(Request.QueryString["type"])) {
                    type = Request.QueryString["type"];

                    // ignore the id if type is ADD
                    if (type != "ADD") {
                        // check if query string contains the id key
                        if (Request.QueryString.AllKeys.Contains("id") && !String.IsNullOrEmpty(Request.QueryString["id"])) {
                            success = Int32.TryParse(SecureID.Decrypt(Request.QueryString["id"].Trim()), out RefillID);
                            if (!success) {
                                GoBack();
                            }
                            else {
                                //if (type == "ADD") RefillID = id;
                                //else prescriptionID = id;
                                PreparePage();
                            };
                        }
                        else {
                            GoBack();
                        }
                    }
                    else {
                        success = Int32.TryParse(SecureID.Decrypt(Request.QueryString["id"].Trim()), out prescriptionID);
                        if (!success) {
                            GoBack();
                        }
                        else {
                            PreparePage();
                        };
                    }
                }
                else {
                    GoBack();
                }

            }
            else {

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnSave_Click1(object sender, EventArgs e) {
            if (btnSave.Text.Trim().ToUpper() == "UPDATE") {
                string RefillID = txtRefillID.Text;
                string PrescriptionID = txtPrescID.Text;
                string ClerkID = ddlClerckName.Text;
                string FillDateTime = txtDateTime.Text;

                try {
                    RefillDataTier.UpdateRefill(
                    RefillID,
                    int.Parse(ClerkID),
                    System.DateTime.Parse(FillDateTime)


                    );
                }
                catch {

                }

                Session["GRIDREFRESH"] = true;
            }

            else if (btnSave.Text.Trim().ToUpper() == "ADD") {
                string RefillID = "";
                string PrescriptionID = "";
                string ClerkID = "";
                string FillDateTime = "";

                RefillID = txtRefillID.Text.Trim();
                PrescriptionID = txtPrescID.Text.Trim();
                ClerkID = ddlClerckName.Text.Trim();
                FillDateTime = txtDateTime.Text.Trim();


                try {
                    RefillDataTier.AddRefill(
                    int.Parse(PrescriptionID),
                    int.Parse(ClerkID),
                    System.DateTime.Parse(FillDateTime)
                 );
                }
                catch {

                }


                Session["GRIDREFRESH"] = true;
            }
        }
     
        protected void txtDateTime_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnGoBack_Click1(object sender, EventArgs e)
        {
            Session["refresh"] = true;
            GoBack();

            if (Saved)
            {
                SearchParameters param = new SearchParameters();
                param.tableName = "Refill";
                param.showActive = true;
                param.showInactive = false;
                param.param1Col = "RefillID";
                param.param1 = RefillID.ToString();
                param.andOr = "O";
                param.param2Col = "";
                param.param2 = "";
                Session["searchParameters"] = param;
            }
             Response.Redirect("frmSearch.aspx");
        }
    }
        
    
}