using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CNSA216_EBC_project;

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

        public static DataSet GetTableColumns(string tableName) {
            try {

                myConn.Open();

                cmdString.Parameters.Clear();
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "procGetTableColumns";
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

        public static int GetColumnMaxLength(string colName, DataSet dsColumns) {
            try {
                int maxLength = Convert.ToInt32(dsColumns.Tables[0].Select($"ColName = '{colName}'")[0]["MaxLength"]);
                return maxLength;
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public static string LengthExpression(int maxLength) {
            return $"^[\\s\\S]{{0,{maxLength}}}$";
        }

        public static DataSet SearchTableGetInfo(SearchParameters param) {
            try {

                myConn.Open();

                cmdString.Parameters.Clear();
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "procSearchTableGetInfo";
                cmdString.Parameters.Add("@TableName", SqlDbType.VarChar, 20).Value = param.tableName;
                cmdString.Parameters.Add("@Param1Col", SqlDbType.VarChar, 20).Value = param.param1Col;
                cmdString.Parameters.Add("@Param1", SqlDbType.VarChar, 100).Value = param.param1;
                cmdString.Parameters.Add("@AndOr", SqlDbType.Char, 1).Value = param.andOr;
                cmdString.Parameters.Add("@Param2Col", SqlDbType.VarChar, 20).Value = param.param2Col;
                cmdString.Parameters.Add("@Param2", SqlDbType.VarChar, 100).Value = param.param2;
                cmdString.Parameters.Add("@ShowActive", SqlDbType.Bit).Value = param.showActive;
                cmdString.Parameters.Add("@ShowInactive", SqlDbType.Bit).Value = param.showInactive;

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

