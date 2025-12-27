using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess_Layer
{
    public class clsInternationalLicenseDataAccess
    {
        public static int AddNewInternationalLicense(int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID,
        DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {
            int InternationalLicenseID = -1;

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                    Update InternationalLicenses 
                    set IsActive=0
                    where DriverID=@DriverID;


                    INSERT INTO InternationalLicenses
                    (ApplicationID, DriverID, IssuedUsingLocalLicenseID,
                     IssueDate, ExpirationDate, IsActive, CreatedByUserID)
                    VALUES
                    (@ApplicationID, @DriverID, @IssuedUsingLocalLicenseID,
                     @IssueDate, @ExpirationDate, @IsActive, @CreatedByUserID);
                     
                    SELECT SCOPE_IDENTITY();";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                        command.Parameters.AddWithValue("@DriverID", DriverID);
                        command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
                        command.Parameters.AddWithValue("@IssueDate", IssueDate);
                        command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                        command.Parameters.AddWithValue("@IsActive", IsActive);
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                        connection.Open();
                        InternationalLicenseID =
                            Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch { }

            return InternationalLicenseID;
        }

        public static bool UpdateInternationalLicense(int InternationalLicenseID, bool IsActive)
        {
            int RowsAffected = 0;

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                    UPDATE InternationalLicenses
                    SET IsActive = @IsActive
                    WHERE InternationalLicenseID = @InternationalLicenseID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);
                        command.Parameters.AddWithValue("@IsActive", IsActive);

                        connection.Open();
                        RowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch { }

            return (RowsAffected > 0);
        }

        public static bool FindInternationalLicense(int InternationalLicenseID,ref int ApplicationID,
        ref int DriverID,ref int IssuedUsingLocalLicenseID,ref DateTime IssueDate,
        ref DateTime ExpirationDate,ref bool IsActive,ref int CreatedByUserID)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"SELECT * FROM InternationalLicenses
                                     WHERE InternationalLicenseID = @ID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", InternationalLicenseID);
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;

                                ApplicationID = (int)reader["ApplicationID"];
                                DriverID = (int)reader["DriverID"];
                                IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                                IssueDate = (DateTime)reader["IssueDate"];
                                ExpirationDate = (DateTime)reader["ExpirationDate"];
                                IsActive = (bool)reader["IsActive"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                            }
                        }
                    }
                }
            }
            catch { }

            return IsFound;
        }

        public static bool DeleteInternationalLicense(int InternationalLicenseID)
        {
            int RowsAffected = 0;

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"DELETE FROM InternationalLicenses
                                     WHERE InternationalLicenseID = @ID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", InternationalLicenseID);
                        connection.Open();
                        RowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch { }

            return (RowsAffected > 0);
        }

        public static DataTable GetAllInternationalLicenses()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"SELECT * FROM InternationalLicenses";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                dt.Load(reader);
                        }
                    }
                }
            }
            catch { }

            return dt;
        }

        public static bool IsInternationalLicenseExist(int InternationalLicenseID)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT found = 1 FROM InternationalLicenses WHERE InternationalLicenseID = @InternationalLicenseID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("InternationalLicenseID", InternationalLicenseID);
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

    }
}
