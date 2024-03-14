using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Microsoft.VisualBasic;
using System.Configuration;
using System.Xml.Linq;


namespace _2024_CNSA212_Final_Group2
{
    internal class PhysicianDataTier
    {
            static string connString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            static SqlConnection myConn = new SqlConnection(connString);
            static SqlCommand cmdString = new SqlCommand();

            public DataSet GetPhysicianByID(int physicianID)
            {
                try
                {
                    myConn.Open();

                    cmdString.Parameters.Clear();
                    cmdString.Connection = myConn;
                    cmdString.CommandType = CommandType.StoredProcedure;
                    cmdString.CommandTimeout = 1500;
                    cmdString.CommandText = "procGetPhysicianInfo";
                    cmdString.Parameters.Add("@PhysicianID", SqlDbType.Int).Value = physicianID;

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


            public void UpdatePhysicianInfo(string physicianID, string FirstName, string Middle, string LastName, string Street, string City, string State, string Zip, string Phone1, string Gender, string Email)
            {
            try
            {

                myConn.Open();

                cmdString.Parameters.Clear();
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "procUpdatePhysicianInfo";

                cmdString.Parameters.Add("@PhysicianID", SqlDbType.Int).Value = physicianID;
                cmdString.Parameters.Add("@FirstName", SqlDbType.VarChar, 20).Value = FirstName;
                cmdString.Parameters.Add("@Middle", SqlDbType.VarChar, 3).Value = Middle;
                cmdString.Parameters.Add("@LastName", SqlDbType.VarChar, 30).Value = LastName;

                cmdString.Parameters.Add("@Street", SqlDbType.VarChar, 20).Value = Street;               
                cmdString.Parameters.Add("@City", SqlDbType.VarChar, 20).Value = City;
                cmdString.Parameters.Add("@State", SqlDbType.Char, 2).Value = State;
                cmdString.Parameters.Add("@Zip", SqlDbType.Char, 5).Value = Zip;

                cmdString.Parameters.Add("@Phone1", SqlDbType.Char, 12).Value = Phone1;
                cmdString.Parameters.Add("@Gender", SqlDbType.Char, 1).Value = Gender;
                cmdString.Parameters.Add("@Email", SqlDbType.VarChar, 40).Value = Email;


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


        public void AddPhysician(
            
            string firstName,
            string middle,
            string lastName,
            string street,
            string city,
            string state,
            string phone1,          
            string zip,
            string email,
            string gender
        )
        {

            myConn.Open();

            cmdString.Parameters.Clear();
            cmdString.Connection = myConn;
            cmdString.CommandType = CommandType.StoredProcedure;
            cmdString.CommandTimeout = 1500;
            cmdString.CommandText = "procAddPhysician";

            
            cmdString.Parameters.Add("@FirstName", SqlDbType.VarChar, 20).Value = firstName;
            cmdString.Parameters.Add("@Middle", SqlDbType.VarChar, 3).Value = middle;
            cmdString.Parameters.Add("@LastName", SqlDbType.VarChar, 30).Value = lastName;
            cmdString.Parameters.Add("@Street", SqlDbType.VarChar, 20).Value = street;
            cmdString.Parameters.Add("@City", SqlDbType.VarChar, 20).Value = city;
            cmdString.Parameters.Add("@State", SqlDbType.Char, 2).Value = state;
            cmdString.Parameters.Add("@Zip", SqlDbType.Char, 5).Value = zip;
            cmdString.Parameters.Add("@Phone1", SqlDbType.Char, 12).Value = phone1;          
            cmdString.Parameters.Add("@Gender", SqlDbType.Char, 1).Value = gender;
            cmdString.Parameters.Add("@Email", SqlDbType.VarChar, 30).Value = email;

            cmdString.ExecuteNonQuery();

            myConn.Close();

        }



        public void DeletePhysician(string physicianID)
        {

            try
            {

                myConn.Open();

                cmdString.Parameters.Clear();
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "procDeletePhysician";
                cmdString.Parameters.Add("@PhysicianID", SqlDbType.VarChar, 6).Value = physicianID;

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

        public void ActivatePhysician(string physicianID)
        {

            try
            {

                myConn.Open();

                cmdString.Parameters.Clear();
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "procDeletePhysicianUndo";
                cmdString.Parameters.Add("@PhysicianID", SqlDbType.VarChar, 6).Value = physicianID;

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



    }
    }






