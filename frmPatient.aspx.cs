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

        protected void btnBack_Click(object sender, EventArgs e)
        {
            
        }
    }
}