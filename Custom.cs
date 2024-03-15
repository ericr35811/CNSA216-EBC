using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace CNSA216_EBC_project {
    public static class Custom {
        public static void ValidateByType(object source, ServerValidateEventArgs args) {
            if (source == null);
        }

        public static object[] RemoveNulls(object[] array) {
            object[] result;
            int count;

            count = 0;
            foreach (object o in array) {
                if (o != null) ++count;
            }

            result = new object[count];
            count = 0;
            foreach (object o in array) {
                if (o != null) {
                    result[count] = o;
                }
                else break;
            }

            return result;
        }

    }
}