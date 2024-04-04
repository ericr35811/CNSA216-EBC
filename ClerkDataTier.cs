using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2024_CNSA212_Final_Group2 {
    internal static class ClerkDataTier {
        static string connString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
        static SqlConnection myConn = new SqlConnection(connString);
        static SqlCommand cmdString = new SqlCommand();

        public static DataSet GetClerks() 
        {
            try {
                myConn.Open();

                cmdString.Parameters.Clear();
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "procGetClerks";

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmdString;
                DataSet dataset = new DataSet();

                adapter.Fill(dataset);



                return dataset;
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            finally {
                myConn.Close();
            }
        }    
    }
}
