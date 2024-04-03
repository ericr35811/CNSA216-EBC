using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Xml.Linq;

namespace _2024_CNSA212_Final_Group2 {
    internal static class PatientDataTier {
        static string connString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
        static SqlConnection myConn = new SqlConnection(connString);
        static SqlCommand cmdString = new SqlCommand();

        public static DataSet GetPatientInfo(int patientID, bool selectAll = false, bool namesOnly = false) {
            try {
                if (selectAll) patientID = int.MaxValue;

                myConn.Open();

                cmdString.Parameters.Clear();
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "procGetPatientInfo";
                cmdString.Parameters.Add("@PatientID", SqlDbType.Int).Value = patientID;
                cmdString.Parameters.Add("@NamesOnly", SqlDbType.Bit).Value = namesOnly;

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
        /*************ADD TRY CATCHES*********/
        public static void UpdatePatientByID(
            int patientID,
            int insuranceID,
            string firstName,
            string middle,
            string lastName,
            string street,
            string city,
            string state,
            string phone1,
            string phone2,
            string zip,
            string email,
            string gender
        ) {
            myConn.Open();

            cmdString.Parameters.Clear();
            cmdString.Connection = myConn;
            cmdString.CommandType = CommandType.StoredProcedure;
            cmdString.CommandTimeout = 1500;
            cmdString.CommandText = "procUpdatePatientInfo";

            cmdString.Parameters.Add("@PatientID", SqlDbType.Int).Value = patientID;
            cmdString.Parameters.Add("@InsuranceID", SqlDbType.Int).Value = insuranceID;
            cmdString.Parameters.Add("@FirstName", SqlDbType.VarChar, 20).Value = firstName;
            cmdString.Parameters.Add("@Middle", SqlDbType.VarChar, 3).Value = middle;
            cmdString.Parameters.Add("@LastName", SqlDbType.VarChar, 30).Value = lastName;
            cmdString.Parameters.Add("@Street", SqlDbType.VarChar, 20).Value =  street;
            cmdString.Parameters.Add("@City", SqlDbType.VarChar, 20).Value = city;
            cmdString.Parameters.Add("@State", SqlDbType.Char, 2).Value = state;
            cmdString.Parameters.Add("@Zip", SqlDbType.Char, 5).Value = zip;
            cmdString.Parameters.Add("@Phone1", SqlDbType.Char, 12).Value = phone1;
            cmdString.Parameters.Add("@Phone2", SqlDbType.Char, 12).Value = phone2;
            cmdString.Parameters.Add("@Gender", SqlDbType.Char, 1).Value = gender;
            cmdString.Parameters.Add("@Email", SqlDbType.VarChar, 30).Value = email;

            cmdString.ExecuteNonQuery();

            myConn.Close();
        }

        /*************ADD TRY CATCHES*********/
        public static void AddPatient(
            int InsuranceID,
            string firstName,
            string middle,
            string lastName,
            string street,
            string city,
            string state,
            string phone1,
            string phone2,
            string zip,
            string email,
            string gender,
            string insuranceName) {

            myConn.Open();

            cmdString.Parameters.Clear();
            cmdString.Connection = myConn;
            cmdString.CommandType = CommandType.StoredProcedure;
            cmdString.CommandTimeout = 1500;
            cmdString.CommandText = "procAddPatient";

            cmdString.Parameters.Add("@InsuranceID", SqlDbType.Int).Value = insuranceID;
            cmdString.Parameters.Add("@FirstName", SqlDbType.VarChar, 20).Value = firstName;
            cmdString.Parameters.Add("@Middle", SqlDbType.VarChar, 3).Value = middle;
            cmdString.Parameters.Add("@LastName", SqlDbType.VarChar, 30).Value = lastName;
            cmdString.Parameters.Add("@Street", SqlDbType.VarChar, 20).Value = street;
            cmdString.Parameters.Add("@City", SqlDbType.VarChar, 20).Value = city;
            cmdString.Parameters.Add("@State", SqlDbType.Char, 2).Value = state;
            cmdString.Parameters.Add("@Zip", SqlDbType.Char, 5).Value = zip;
            cmdString.Parameters.Add("@Phone1", SqlDbType.Char, 12).Value = phone1;
            cmdString.Parameters.Add("@Phone2", SqlDbType.Char, 12).Value = phone2;
            cmdString.Parameters.Add("@Gender", SqlDbType.Char, 1).Value = gender;
            cmdString.Parameters.Add("@Email", SqlDbType.VarChar, 30).Value = email;

            cmdString.ExecuteNonQuery();

            myConn.Close();

        }

        public static void DeletePatient(int patientID) {
            try {
                myConn.Open();

                cmdString.Parameters.Clear();
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "procDeletePatient";
                cmdString.Parameters.Add("@PatientID", SqlDbType.Int).Value = patientID;

                cmdString.ExecuteNonQuery();

            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            finally {
                myConn.Close();
            }
        
        
        }
        public static void DeletePatientUndo(int patientID) {
            try {
                myConn.Open();

                cmdString.Parameters.Clear();
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "procDeletePatientUndo";
                cmdString.Parameters.Add("@PatientID", SqlDbType.Int).Value = patientID;

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
