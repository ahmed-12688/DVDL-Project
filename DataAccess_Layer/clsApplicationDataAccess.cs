using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer
{
    public static class clsApplicationDataAccess
    {
        static public bool FindApplicationByApplicationID(int ApplicationID, ref int ApplicationPersonID, ref DateTime ApplicationDate,
        ref int ApplicaitonTypeID, ref byte ApplicaitonStatus, ref DateTime LastStatusDate, ref decimal PaidFees,
        ref int CreatedByUserID)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM Applications WHERE ApplicationID = @ApplicationID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;
                                ApplicationPersonID = (int)reader["ApplicantPersonID"];
                                ApplicationDate = (DateTime)reader["ApplicationDate"];
                                ApplicaitonTypeID = (int)reader["ApplicationTypeID"];
                                ApplicaitonStatus = (byte)reader["ApplicationStatus"];
                                LastStatusDate = (DateTime)reader["LastStatusDate"];
                                PaidFees = (decimal)reader["PaidFees"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                            }
                            else
                                IsFound = false;
                        }
                    }
                }
            }
            catch (Exception)
            {

                IsFound = false;
            }
            return IsFound;
        }

        static public int AddNewApplicaion(int ApplicationPersonID, DateTime ApplicationDate,
         int ApplicaitonTypeID, byte ApplicaitonStatus, DateTime LastStatusDate, decimal PaidFees,
         int CreatedByUserID)
        {
            int PersonID = -1;
            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"INSERT INTO Applications (ApplicantPersonID,ApplicationDate,ApplicationTypeID,ApplicationStatus,
                    LastStatusDate,PaidFees,CreatedByUserID)     
                    values (@ApplicationPersonID,@ApplicationDate,@ApplicaitonTypeID,@ApplicaitonStatus,@LastStatusDate,@PaidFees,@CreatedByUserID);
                    SELECT SCOPE_IDENTITY();";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ApplicationPersonID", ApplicationPersonID);
                        command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
                        command.Parameters.AddWithValue("@ApplicaitonTypeID", ApplicaitonTypeID);
                        command.Parameters.AddWithValue("@ApplicaitonStatus", ApplicaitonStatus);
                        command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
                        command.Parameters.AddWithValue("@PaidFees", PaidFees);
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                        {
                            PersonID = InsertedID;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return -1;
            }




            return PersonID;
        }

        static public bool UpdateApplicaion(int ApplicationID, int ApplicationPersonID, DateTime ApplicationDate,
         int ApplicaitonTypeID, byte ApplicaitonStatus, DateTime LastStatusDate, decimal PaidFees,
         int CreatedByUserID)
        {
            int RowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"UPDATE Applications SET ApplicantPersonID = @ApplicationPersonID, ApplicationDate = @ApplicationDate,
                ApplicationTypeID = @ApplicaitonTypeID, ApplicationStatus = @ApplicaitonStatus,LastStatusDate = @LastStatusDate, PaidFees = @PaidFees,
                CreatedByUserID = @CreatedByUserID
                WHERE ApplicationID = @ApplicationID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                        command.Parameters.AddWithValue("@ApplicationPersonID", ApplicationPersonID);
                        command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
                        command.Parameters.AddWithValue("@ApplicaitonTypeID", ApplicaitonTypeID);
                        command.Parameters.AddWithValue("@ApplicaitonStatus", ApplicaitonStatus);
                        command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
                        command.Parameters.AddWithValue("@PaidFees", PaidFees);
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);



                        connection.Open();
                        RowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }

            return (RowsAffected > 0);
        }

        public static bool DeletApplicaion(int ApplicationID)
        {
            int RowsAffected = 0;
            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "DELETE FROM Applications WHERE ApplicationID = @ApplicationID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                        connection.Open();
                        RowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }

            return (RowsAffected > 0);
        }

        public static DataTable GetAllApplicaions()
        {
            DataTable dt = new DataTable();
            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    string query = "SELECT * FROM Applications";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
            return dt;
        }

        public static bool IsApplicaionExist(int ApplicationID)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT found = 1 FROM Applications WHERE ApplicationID = @ApplicationID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("ApplicationID", ApplicationID);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                return true;
                            }
                            return false;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }

        }

        public static bool DoesPersonHaveActiveApplication(int PersonID, int ApplicationTypeID)
        {

            //incase the ActiveApplication ID !=-1 return true.
            return (GetActiveApplicationID(PersonID, ApplicationTypeID) != -1);
        }

        public static int GetActiveApplicationID(int PersonID, int ApplicationTypeID)
        {
            int ActiveApplicationID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT ActiveApplicationID=ApplicationID FROM Applications WHERE ApplicantPersonID = @ApplicantPersonID and ApplicationTypeID=@ApplicationTypeID and ApplicationStatus=1";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicantPersonID", PersonID);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int AppID))
                {
                    ActiveApplicationID = AppID;
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return ActiveApplicationID;
            }
            finally
            {
                connection.Close();
            }

            return ActiveApplicationID;
        }

        public static int GetActiveApplicationIDForLicenseClass(int PersonID, int ApplicationTypeID, int LicenseClassID)
        {
            int ActiveApplicationID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT ActiveApplicationID=Applications.ApplicationID  
                            From
                            Applications INNER JOIN
                            LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
                            WHERE ApplicantPersonID = @ApplicantPersonID 
                            and ApplicationTypeID=@ApplicationTypeID 
							and LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID
                            and ApplicationStatus=1";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicantPersonID", PersonID);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int AppID))
                {
                    ActiveApplicationID = AppID;
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return ActiveApplicationID;
            }
            finally
            {
                connection.Close();
            }

            return ActiveApplicationID;
        }

        public static bool UpdateStatus(int ApplicationID, short NewStatus)
        {
            int RowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"Update  Applications  
                            set 
                                ApplicationStatus = @NewStatus, 
                                LastStatusDate = @LastStatusDate
                            where ApplicationID=@ApplicationID;";
    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                        command.Parameters.AddWithValue("@NewStatus", NewStatus);
                        command.Parameters.AddWithValue("LastStatusDate", DateTime.Now);

                        connection.Open();
                        RowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }

            return (RowsAffected > 0);

        }

    }
}
