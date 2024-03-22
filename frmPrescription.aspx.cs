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
        protected void Page_Load(object sender, EventArgs e) {
            int maxLength;
            DataSet dsColumns;

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
}