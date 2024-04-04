using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.EnterpriseServices.CompensatingResourceManager;

namespace _2024_CNSA212_Final_Group2
{
    internal static class RefillDataTier
    {
        static string connString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
        static SqlConnection myConn = new SqlConnection(connString);
        static SqlCommand cmdString = new SqlCommand();

        public static DataSet GetRefill(int RefillID, bool selectAll = false, bool namesOnly = false)
        {
            if (selectAll) RefillID = int.MaxValue;
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
        public static void UpdateRefill(string refillID, int clerkID, DateTime fillDateTime) 
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
                cmdString.Parameters.Add("@ClerkID", SqlDbType.Int).Value = clerkID;
                cmdString.Parameters.Add("@FillDateTime", SqlDbType.DateTime).Value = fillDateTime;

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

        public static int AddRefill(int prescriptionID, int clerkID, DateTime fillDateTime)
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
                cmdString.Parameters.Add("@ClerkID", SqlDbType.Int).Value = clerkID;
                cmdString.Parameters.Add("@FillDateTime", SqlDbType.DateTime).Value = fillDateTime;

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

        public static void DeleteRefill(int refillID) {
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

        public static void ActivateRefill(int refillID) {
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
    }



 }

