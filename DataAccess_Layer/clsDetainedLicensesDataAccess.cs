using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess_Layer
{
    public class clsDetainedLicenseDataAccess
    {
        public static int AddNewDetainedLicense(
            int LicenseID,
            DateTime DetainDate,
            decimal FineFees,
            int CreatedByUserID,
            bool IsReleased)
        {
            int DetainID = -1;

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                    INSERT INTO DetainedLicenses
                    (LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased)
                    VALUES
                    (@LicenseID, @DetainDate, @FineFees, @CreatedByUserID, @IsReleased);

                    SELECT SCOPE_IDENTITY();";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LicenseID", LicenseID);
                        command.Parameters.AddWithValue("@DetainDate", DetainDate);
                        command.Parameters.AddWithValue("@FineFees", FineFees);
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                        command.Parameters.AddWithValue("@IsReleased", IsReleased);

                        connection.Open();
                        DetainID = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch { }

            return DetainID;
        }

        public static bool ReleaseDetainedLicense(
            int DetainID,
            DateTime ReleaseDate,
            int ReleasedByUserID,
            int ReleaseApplicationID)
        {
            int RowsAffected = 0;

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                    UPDATE DetainedLicenses
                    SET IsReleased = 1,
                        ReleaseDate = @ReleaseDate,
                        ReleasedByUserID = @ReleasedByUserID,
                        ReleaseApplicationID = @ReleaseApplicationID
                    WHERE DetainID = @DetainID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DetainID", DetainID);
                        command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
                        command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
                        command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);

                        connection.Open();
                        RowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch { }

            return (RowsAffected > 0);
        }

        public static bool FindDetainedLicense(
            int DetainID,
            ref int LicenseID,
            ref DateTime DetainDate,
            ref decimal FineFees,
            ref int CreatedByUserID,
            ref bool IsReleased,
            ref DateTime? ReleaseDate,
            ref int? ReleasedByUserID,
            ref int? ReleaseApplicationID)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"SELECT * FROM DetainedLicenses
                                     WHERE DetainID = @DetainID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DetainID", DetainID);
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;

                                LicenseID = (int)reader["LicenseID"];
                                DetainDate = (DateTime)reader["DetainDate"];
                                FineFees = Convert.ToDecimal(reader["FineFees"]);
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                                IsReleased = Convert.ToBoolean(reader["IsReleased"]);

                                ReleaseDate = reader["ReleaseDate"] == DBNull.Value
                                    ? null
                                    : (DateTime?)reader["ReleaseDate"];

                                ReleasedByUserID = reader["ReleasedByUserID"] == DBNull.Value
                                    ? null
                                    : (int?)reader["ReleasedByUserID"];

                                ReleaseApplicationID = reader["ReleaseApplicationID"] == DBNull.Value
                                    ? null
                                    : (int?)reader["ReleaseApplicationID"];
                            }
                        }
                    }
                }
            }
            catch { }

            return IsFound;
        }

        public static bool FindDetainedLicenseByLicenseID(
            int LicenseID,
            ref int DetainID,
            ref DateTime DetainDate,
            ref decimal FineFees,
            ref int CreatedByUserID)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                SELECT TOP 1 *
                FROM DetainedLicenses
                WHERE LicenseID = @LicenseID
                  AND IsReleased = 0
                ORDER BY DetainDate DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LicenseID", LicenseID);
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;

                                DetainID = (int)reader["DetainID"];
                                DetainDate = (DateTime)reader["DetainDate"];
                                FineFees = Convert.ToDecimal(reader["FineFees"]);
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                            }
                        }
                    }
                }
            }
            catch { }

            return IsFound;
        }


        public static DataTable GetAllDetainedLicenses()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"SELECT * FROM DetainedLicenses_View ORDER BY DetainID DESC";

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

        public static bool IsLicenseDetained(int LicenseID)
        {
            try
            {
                using (SqlConnection connection =
                    new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"
                SELECT found = 1
                FROM DetainedLicenses
                WHERE LicenseID = @LicenseID
                  AND IsReleased = 0";

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
    }
}
