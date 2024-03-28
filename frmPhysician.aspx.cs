using _2024_CNSA212_Final_Group2;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CNSA216_EBC_project {
    public partial class WebForm4 : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            int maxLength;
            DataSet dsColumns;

            dsColumns = GeneralDataTier.GetTableColumns("Patients");
            maxLength = GeneralDataTier.GetColumnMaxLength("FirstName", dsColumns);

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
    }
}