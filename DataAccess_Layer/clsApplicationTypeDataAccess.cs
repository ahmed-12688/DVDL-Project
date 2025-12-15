using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer
{
     public static class clsApplicationTypeDataAccess
    {
        static public bool FindApplicationType(int AppTypeID, ref string Title, ref decimal Fees)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM ApplicationTypes WHERE ApplicationTypeID = @AppTypeID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@AppTypeID", AppTypeID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;
                                Title = reader["ApplicationTypeTitle"].ToString();
                                Fees = Convert.ToDecimal(reader["ApplicationFees"]);
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


        public static bool UpdateApplicationType(int AppID, String Title, decimal Fees)
        {
            int RowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"UPDATE ApplicationTypes SET ApplicationTypeTitle = @Title, ApplicationFees = @Fees
                     WHERE ApplicationTypeID = @AppID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Title", Title);
                        command.Parameters.AddWithValue("@Fees", Fees);
                        command.Parameters.AddWithValue("@AppID", AppID);


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

        public static DataTable GetAllApplicationType()
        {
            DataTable dt = new DataTable();
                        try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    string query = @"SELECT * FROM ApplicationTypes";
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
    }
}
