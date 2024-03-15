using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2024_CNSA212_Final_Group2 {
    static internal class GeneralDataTier {
        static string connString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
        static SqlConnection myConn = new SqlConnection(connString);
        static SqlCommand cmdString = new SqlCommand();

        public static DataSet GetSearchableColumns(string tableName) {
            try {

                myConn.Open();

                cmdString.Parameters.Clear();
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "procGetSearchableColumns";
                cmdString.Parameters.Add("@TableName", SqlDbType.VarChar, 15).Value = tableName;

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

        public static DataSet GetGenders() {
            try {
                myConn.Open();

                cmdString.Parameters.Clear();
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "procGetGenders";

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmdString;
                DataSet dataset = new DataSet();

                adapter.Fill(dataset);

                myConn.Close();

                return dataset;
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            finally {
                myConn.Close();
            }
        }

        public static DataSet GetStates() {
            try {
                myConn.Open();

                cmdString.Parameters.Clear();
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "procGetStates";

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmdString;
                DataSet dataset = new DataSet();

                adapter.Fill(dataset);

                myConn.Close();

                return dataset;
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            finally {
                myConn.Close();
            }
        }

        public static DataSet GetInsurances() {
            try {
                myConn.Open();

                cmdString.Parameters.Clear();
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "procGetInsurances";

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmdString;
                DataSet dataset = new DataSet();

                adapter.Fill(dataset);

                myConn.Close();

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

