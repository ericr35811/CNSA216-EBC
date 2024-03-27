using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Runtime.InteropServices.ComTypes;

namespace _2024_CNSA212_Final_Group2
{
    internal static class PrescriptionDataTier
    {

        static string connString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
        static SqlConnection myConn = new SqlConnection(connString);
        static SqlCommand cmdString = new SqlCommand();

        public static DataSet GetPrescriptionInfo(int prescriptionID, bool selectAll = false, bool namesOnly = false)
        {
            try
            {
                if (selectAll) prescriptionID = int.MaxValue;
                myConn.Open();

                cmdString.Parameters.Clear();
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "procGetPrescriptionInfo";
                cmdString.Parameters.Add("@PrescriptionID", SqlDbType.Int).Value = prescriptionID;
                cmdString.Parameters.Add("@NamesOnly", SqlDbType.Bit).Value = namesOnly;

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmdString;
                DataSet dataset = new DataSet();

                adapter.Fill(dataset);

                myConn.Close();

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

        public static void UpdatePrescription(string prescriptionID, string dosageID, string patientID, string physicianID, DateTime StartDate, DateTime EndDate, DateTime EnteredDateTime, string ExtraInstructions)
        {
            try
            {

                myConn.Open();

                cmdString.Parameters.Clear();
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "procUpdatePrescriptionInfo";

                cmdString.Parameters.Add("@PrescriptionID", SqlDbType.Int).Value = prescriptionID;
                cmdString.Parameters.Add("@DosageID", SqlDbType.Int).Value = dosageID;
                cmdString.Parameters.Add("@PatientID", SqlDbType.Int).Value = patientID;
                cmdString.Parameters.Add("@PhysicianID", SqlDbType.Int).Value = physicianID;


                cmdString.Parameters.Add("@StartDate", SqlDbType.Date).Value = StartDate;
                cmdString.Parameters.Add("@EndDate", SqlDbType.Date).Value = EndDate;
                cmdString.Parameters.Add("@EnteredDateTime", SqlDbType.DateTime).Value = EnteredDateTime;
                cmdString.Parameters.Add("@ExtraInstructions", SqlDbType.VarChar, 300).Value = ExtraInstructions;



                cmdString.ExecuteNonQuery();

                myConn.Close();

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


        public static void AddPrescription(int patientID, int dosageID, int physicianID, DateTime startDate, DateTime endDate, DateTime enteredDateTime, string extraInstructions) {
            try {

                myConn.Open();

                cmdString.Parameters.Clear();
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "procAddPrescription";

                cmdString.Parameters.Add("@DosageID", SqlDbType.Int).Value = dosageID;
                cmdString.Parameters.Add("@PatientID", SqlDbType.Int).Value = patientID;
                cmdString.Parameters.Add("@PhysicianID", SqlDbType.Int).Value = physicianID;
                cmdString.Parameters.Add("@StartDate", SqlDbType.Date).Value = startDate;
                cmdString.Parameters.Add("@EndDate", SqlDbType.Date).Value = endDate;
                cmdString.Parameters.Add("@ExtraInstructions", SqlDbType.VarChar, 300).Value = extraInstructions;
                cmdString.Parameters.Add("@EnteredDateTime", SqlDbType.DateTime).Value = enteredDateTime;


                cmdString.ExecuteNonQuery();


            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            finally {
                myConn.Close();
            }
        }


        public static void DeletePrescription(string prescriptionID)
        {

            try
            {

                myConn.Open();

                cmdString.Parameters.Clear();
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "procDeletePrescription";
                cmdString.Parameters.Add("@PrescriptionID", SqlDbType.Int).Value = prescriptionID;

                cmdString.ExecuteNonQuery();

                myConn.Close();
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

        public static void ActivatePrescription(string prescriptionID)
        {

            try
            {

                myConn.Open();

                cmdString.Parameters.Clear();
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "procDeletePrescriptionUndo";
                cmdString.Parameters.Add("@PrescriptionID", SqlDbType.Int).Value = prescriptionID;

                cmdString.ExecuteNonQuery();

                myConn.Close();
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




        public static DataSet GetLatestPrescription()
        {
            try
            {
                myConn.Open();

                cmdString.Parameters.Clear();
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "procGetLatestPrescription";

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmdString;
                DataSet dataset = new DataSet();

                adapter.Fill(dataset);

                myConn.Close();

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


    }
}

