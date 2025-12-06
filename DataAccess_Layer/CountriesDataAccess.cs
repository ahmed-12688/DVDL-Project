using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer
{
    public static class CountriesDataAccess
    {

        public static bool GetCountryInfoByID(int ID, ref string CountryName)
        {
            bool isfound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM Countries WHERE CountryID = @CountryID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@CountryID", ID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isfound = true;
                                CountryName = (string)reader["CountryName"];

                            }
                            else
                                isfound = false;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                isfound = false;
            }

            return isfound;
        }

        public static bool GetCountryInfoByName(string CountryName, ref int CountryID)
        {
            bool isfound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM Countries WHERE CountryName = @CountryName";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@CountryName", CountryName);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isfound = true;
                                CountryID = (int)reader["CountryID"];

                            }
                            else
                                isfound = false;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                isfound = false;
            }

            return isfound;
        }

        public static DataTable GetAllCountries()
        {
            DataTable dt = new DataTable();
            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM Countries";
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
            }
            return dt;
        }


    }
}
