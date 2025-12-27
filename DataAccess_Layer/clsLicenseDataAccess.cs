using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer
{
    public static class clsLicenseDataAccess
    {
        static public bool FindLicense(int LicenseID, ref int ApplicationID, ref int DriverID,
        ref int LicenseClass, ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes,
        ref decimal PaidFees, ref bool IsActive, ref byte IssueReason, ref int CreatedByUserID)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM Licenses WHERE LicenseID = @LicenseID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LicenseID", LicenseID);
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;

                                ApplicationID = Convert.ToInt32(reader["ApplicationID"]);
                                DriverID = Convert.ToInt32(reader["DriverID"]);
                                LicenseClass = Convert.ToInt32(reader["LicenseClass"]);
                                IssueDate = Convert.ToDateTime(reader["IssueDate"]);
                                ExpirationDate = Convert.ToDateTime(reader["ExpirationDate"]);
                                Notes = reader["Notes"] == DBNull.Value
                                                    ? string.Empty
                                                    : reader["Notes"].ToString();
                                PaidFees = Convert.ToDecimal(reader["PaidFees"]);
                                IsActive = Convert.ToBoolean(reader["IsActive"]);
                                IssueReason = Convert.ToByte(reader["IssueReason"]);
                                CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                            }
                        }
                    }
                }
            }
            catch
            {
                IsFound = false;
            }

            return IsFound;
        }

        static public bool FindLicenseByApplicationID(int ApplicationID, ref int LicenseID, ref int DriverID,
        ref int LicenseClass, ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes,
        ref decimal PaidFees, ref bool IsActive, ref byte IssueReason, ref int CreatedByUserID)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM Licenses WHERE ApplicationID = @ApplicationID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;

                                LicenseID = Convert.ToInt32(reader["LicenseID"]);
                                DriverID = Convert.ToInt32(reader["DriverID"]);
                                LicenseClass = Convert.ToInt32(reader["LicenseClass"]);
                                IssueDate = Convert.ToDateTime(reader["IssueDate"]);
                                ExpirationDate = Convert.ToDateTime(reader["ExpirationDate"]);
                                Notes = reader["Notes"] == DBNull.Value
                                                    ? string.Empty
                                                    : reader["Notes"].ToString();
                                PaidFees = Convert.ToDecimal(reader["PaidFees"]);
                                IsActive = Convert.ToBoolean(reader["IsActive"]);
                                IssueReason = Convert.ToByte(reader["IssueReason"]);
                                CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                            }
                        }
                    }
                }
            }
            catch
            {
                IsFound = false;
            }

            return IsFound;
        }

        static public int AddNewLicense(int ApplicationID, int DriverID, int LicenseClass,
        DateTime IssueDate, DateTime ExpirationDate, string Notes, decimal PaidFees,
        bool IsActive, byte IssueReason, int CreatedByUserID)
        {
            int LicenseID = -1;

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
            INSERT INTO Licenses
            (ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate,
             Notes, PaidFees, IsActive, IssueReason, CreatedByUserID)
            VALUES
            (@ApplicationID, @DriverID, @LicenseClass, @IssueDate, @ExpirationDate,
             @Notes, @PaidFees, @IsActive, @IssueReason, @CreatedByUserID);
            SELECT SCOPE_IDENTITY();";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                        command.Parameters.AddWithValue("@DriverID", DriverID);
                        command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
                        command.Parameters.AddWithValue("@IssueDate", IssueDate);
                        command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                        if (Notes == string.Empty)
                            command.Parameters.AddWithValue("@Notes", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@Notes", Notes);
                        command.Parameters.AddWithValue("@PaidFees", PaidFees);
                        command.Parameters.AddWithValue("@IsActive", IsActive);
                        command.Parameters.AddWithValue("@IssueReason", IssueReason);
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null &&
                            int.TryParse(result.ToString(), out int InsertedID))
                        {
                            LicenseID = InsertedID;
                        }
                    }
                }
            }
            catch
            {
                return -1;
            }

            return LicenseID;
        }

        static public bool UpdateLicense(int LicenseID, int ApplicationID,
        int DriverID, int LicenseClass, DateTime IssueDate, DateTime ExpirationDate,
        string Notes, decimal PaidFees, bool IsActive, byte IssueReason)
        {
            int RowsAffected = 0;

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
            UPDATE Licenses SET
                ApplicationID = @ApplicationID,
                DriverID = @DriverID,
                LicenseClass = @LicenseClass,
                IssueDate = @IssueDate,
                ExpirationDate = @ExpirationDate,
                Notes = @Notes,
                PaidFees = @PaidFees,
                IsActive = @IsActive,
                IssueReason = @IssueReason
            WHERE LicenseID = @LicenseID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LicenseID", LicenseID);
                        command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                        command.Parameters.AddWithValue("@DriverID", DriverID);
                        command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
                        command.Parameters.AddWithValue("@IssueDate", IssueDate);
                        command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                        if (Notes == string.Empty)
                            command.Parameters.AddWithValue("@Notes", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@Notes", Notes);
                        command.Parameters.AddWithValue("@PaidFees", PaidFees);
                        command.Parameters.AddWithValue("@IsActive", IsActive);
                        command.Parameters.AddWithValue("@IssueReason", IssueReason);

                        connection.Open();
                        RowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                return false;
            }

            return RowsAffected > 0;
        }

        static public bool DeleteLicense(int LicenseID)
        {
            int RowsAffected = 0;

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "DELETE FROM Licenses WHERE LicenseID = @LicenseID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LicenseID", LicenseID);
                        connection.Open();
                        RowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                return false;
            }

            return RowsAffected > 0;
        }

        public static DataTable GetAllLicenses()
        {
            DataTable dt = new DataTable();
            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    string query =
                      @"SELECT * FROM Licenses";
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

        public static bool IsLicenseExist(int LicenseID)
        {
            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query =
                        "SELECT found = 1 FROM Licenses WHERE LicenseID = @LicenseID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LicenseID", LicenseID);
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            return reader.HasRows;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool IsLicesneIsAvtiveAndHisTypeis_Class3_(int LicenseID)
        {
            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query =
                        @"select top 1 found = 1 from 
                        Licenses where LicenseID = @LicenseID 
                        And LicenseClass = 3
                        And IsActive = 1 And ExpirationDate > GETDATE()";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LicenseID", LicenseID);
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            return reader.HasRows;
                        }
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        static public bool DeActiveLicense(int LicenseID)
        {
            int RowsAffected = 0;

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "Update Licenses Set IsActive = 0 WHERE LicenseID = @LicenseID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LicenseID", LicenseID);
                        connection.Open();
                        RowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                return false;
            }

            return RowsAffected > 0;
        }




    }

}

