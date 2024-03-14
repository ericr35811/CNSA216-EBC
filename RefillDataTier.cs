using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2024_CNSA212_Final_Group2
{
    internal class RefillDataTier
    {
        static string connString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
        static SqlConnection myConn = new SqlConnection(connString);
        static SqlCommand cmdString = new SqlCommand();

        public DataSet GetRefillByID(int RefillID)
        {
            try
            {
                myConn.Open();

                cmdString.Parameters.Clear();
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "procGetRefill";
                cmdString.Parameters.Add("@RefillID", SqlDbType.Int).Value = RefillID;

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmdString;
                DataSet dataset = new DataSet();

                adapter.Fill(dataset);

                

                return dataset;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                myConn.Close();
            }
        }

        //not working
        public void UpdateRefillInfo(string refillID, string prescriptionID, string quantity, string numberOfRefills, DateTime startDate, DateTime endDate)
        {
            try
            {
                myConn.Open();
                cmdString.Parameters.Clear();
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "procUpdateRefill";

                cmdString.Parameters.Add("@RefillID", SqlDbType.Int).Value = refillID;
                cmdString.Parameters.Add("@PrescriptionID", SqlDbType.Int).Value = prescriptionID;
                cmdString.Parameters.Add("@Quantity", SqlDbType.VarChar, 20).Value = quantity;
                cmdString.Parameters.Add("@NumberOfRefills", SqlDbType.SmallInt).Value = numberOfRefills;
                cmdString.Parameters.Add("@StartDate", SqlDbType.Date).Value = startDate;
                cmdString.Parameters.Add("@EndDate", SqlDbType.Date).Value = endDate;

                cmdString.ExecuteNonQuery();
                
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                myConn.Close();
            }

        }

        public int AddRefill(int prescriptionID, string quantity, string numberOfRefills, DateTime startDate, DateTime endDate)
        {
            try
            {

                myConn.Open();

                cmdString.Parameters.Clear();
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "procAddRefill";

               
                cmdString.Parameters.Add("@PrescriptionID", SqlDbType.Int).Value = prescriptionID;
                cmdString.Parameters.Add("@Quantity", SqlDbType.SmallInt).Value = quantity;
                cmdString.Parameters.Add("@NumberOfRefills", SqlDbType.SmallInt).Value = numberOfRefills;
                cmdString.Parameters.Add("@StartDate", SqlDbType.Date).Value = startDate;
                cmdString.Parameters.Add("@EndDate", SqlDbType.Date).Value = endDate;

                // get return value from the procedure
                var returnParameter = cmdString.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;

                cmdString.ExecuteNonQuery();

                return (int) returnParameter.Value;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                myConn.Close();
            }
        }

        public void DeleteRefill(int refillID) {
            try {
                myConn.Open();

                cmdString.Parameters.Clear();
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "procDeleteRefill";
                cmdString.Parameters.Add("@RefillID", SqlDbType.Int).Value = refillID;

                cmdString.ExecuteNonQuery();

            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            finally {
                myConn.Close();
            }
        }

        public void ActivateRefill(int refillID) {
            try {
                myConn.Open();

                cmdString.Parameters.Clear();
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "procDeleteRefillUndo";
                cmdString.Parameters.Add("@RefillID", SqlDbType.Int).Value = refillID;

                cmdString.ExecuteNonQuery();

            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            finally {
                myConn.Close();
            }
        }

        public int Fill(int refillID, int clerkID) {
            try {
                myConn.Open();

                cmdString.Parameters.Clear();
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "procFill";
                
                cmdString.Parameters.Add("@RefillID", SqlDbType.Int).Value = refillID;
                cmdString.Parameters.Add("@ClerkID", SqlDbType.Int).Value = clerkID;

                // get the return value from the procedure
                var returnParameter = cmdString.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;

                cmdString.ExecuteNonQuery();

                return (int) returnParameter.Value;

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

