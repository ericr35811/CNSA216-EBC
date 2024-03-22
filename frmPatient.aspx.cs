using _2024_CNSA212_Final_Group2;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CNSA216_EBC_project {
    public partial class WebForm3 : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            int maxLength;
            DataSet dsColumns;

            dsColumns = GeneralDataTier.GetTableColumns("Patients");
            maxLength = GeneralDataTier.GetColumnMaxLength("First Name", dsColumns);
            txtFname.MaxLength = maxLength;
            txtLname.MaxLength = maxLength;
            maxLength = GeneralDataTier.GetColumnMaxLength("Last Name", dsColumns);
            txtMiddle.MaxLength = maxLength;
            maxLength = GeneralDataTier.GetColumnMaxLength("Middle", dsColumns);
            txtCity.MaxLength = maxLength;
            maxLength = GeneralDataTier.GetColumnMaxLength("City", dsColumns);
            txtDob.MaxLength = maxLength;
            maxLength = GeneralDataTier.GetColumnMaxLength("DOB", dsColumns);
            txtEmail.MaxLength = maxLength;
            maxLength = GeneralDataTier.GetColumnMaxLength("Email", dsColumns);
            txtHeight.MaxLength = maxLength;
            maxLength = GeneralDataTier.GetColumnMaxLength("Height", dsColumns);
            txtPatientID.MaxLength = maxLength;
            maxLength = GeneralDataTier.GetColumnMaxLength("PatientID", dsColumns);
            txtPhone1.MaxLength = maxLength;
            maxLength = GeneralDataTier.GetColumnMaxLength("Phone1", dsColumns);
            txtPhone2.MaxLength = maxLength;
            maxLength = GeneralDataTier.GetColumnMaxLength("Phone2", dsColumns);
            txtStart.MaxLength = maxLength;
            maxLength = GeneralDataTier.GetColumnMaxLength("Start", dsColumns);
            txtStreet.MaxLength = maxLength;
            maxLength = GeneralDataTier.GetColumnMaxLength("Street", dsColumns);
            txtVisit.MaxLength = maxLength;
            maxLength = GeneralDataTier.GetColumnMaxLength("Visit", dsColumns);
            txtZip.MaxLength = maxLength;
            maxLength = GeneralDataTier.GetColumnMaxLength("Zip", dsColumns);
            rgxString.ValidationExpression = GeneralDataTier.LengthExpression(maxLength);
            rgxString.ErrorMessage = $"Must be {maxLength} characters or less";

            rngDate1.Type = ValidationDataType.Date;
            rngDate1.ErrorMessage = $"Must be a date between {DateTime.MinValue.ToShortDateString()} and {DateTime.MaxValue.ToShortDateString()}";
            rngDate1.MinimumValue = DateTime.MinValue.ToShortDateString();
            rngDate1.MaximumValue = DateTime.MaxValue.ToShortDateString();

            rngDate2.Type = ValidationDataType.Date;
            rngDate2.ErrorMessage = $"Must be a date between {DateTime.MinValue.ToShortDateString()} and {DateTime.MaxValue.ToShortDateString()}";
            rngDate2.MinimumValue = DateTime.MinValue.ToShortDateString();
            rngDate2.MaximumValue = DateTime.MaxValue.ToShortDateString();

            rngDate3.Type = ValidationDataType.Date;
            rngDate3.ErrorMessage = $"Must be a date between {DateTime.MinValue.ToShortDateString()} and {DateTime.MaxValue.ToShortDateString()}";
            rngDate3.MinimumValue = DateTime.MinValue.ToShortDateString();
            rngDate3.MaximumValue = DateTime.MaxValue.ToShortDateString();

            // -- number validator (SmallInt/Int16)
            // change "Int16" to "Int32" for Int/Int32
            rngSmallInt.Type = ValidationDataType.Integer;
            rngSmallInt1.Type = ValidationDataType.Integer;
        }
    }
}