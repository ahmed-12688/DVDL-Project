using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer
{
    public class clsPeopleDataAccess
    {
        static public bool FindPersonWithPersonID(int PersonID,ref string NationalNo, ref string FirstName,
            ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth,
            ref bool Gender, ref string Address, ref string Phone, ref string Email
            , ref int NationalityCountryID, ref string ImagePath)
        {
                bool IsFound = false;
            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM People WHERE PersonID = @PersonID";
                    using (SqlCommand command = new SqlCommand(query, connection)) 
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@PersonID", PersonID);

                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;
                                NationalNo = reader["NationalNo"].ToString();
                                FirstName = reader["FirstName"].ToString();
                                SecondName = reader["SecondName"].ToString();
                                ThirdName = reader["ThirdName"].ToString();
                                LastName = reader["LastName"].ToString();
                                DateOfBirth = (DateTime)reader["DateOfBirth"];
                                Gender = (bool)reader["Gender"];
                                Address = reader["Address"].ToString();
                                Phone = reader["Phone"].ToString();
                                Email = reader["email"].ToString();
                                NationalityCountryID = (int)reader["NationalityCountryID"];
                                if (reader["ImagePath"] != DBNull.Value)
                                    ImagePath = reader["ImagePath"].ToString();
                                else
                                    ImagePath = string.Empty;
                            }
                            else
                                IsFound = false;
                        }
                    }
                }
            }
            catch (Exception)
            {

                IsFound=false;
            }
            return IsFound;
        }

        static public int AddNewPerson(string NationalNo, string FirstName,
            string SecondName, string ThirdName, string LastName, DateTime DateOfBirth,
            bool Gender, string Address, string Phone, string Email
            , int NationalityCountryID, string ImagePath)
        {
            int PersonID = -1;
            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"INSERT INTO People (NationalNo,FirstName,SecondName,ThirdName,
                    LastName,Email,Phone,Address,DateOfBirth,Gender,NationalityCountryID,ImagePath)     
                    values (@NationalNo,@FirstName,@SecondName,@ThirdName,@LastName,@Email,@Phone,
                    @Address,@DateOfBirth,@Gender,@NationalityCountryID,@ImagePath);
                    SELECT SCOPE_IDENTITY();";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NationalNo", NationalNo);
                        command.Parameters.AddWithValue("@FirstName", FirstName);
                        command.Parameters.AddWithValue("@SecondName", SecondName);
                        command.Parameters.AddWithValue("@ThirdName", ThirdName);
                        command.Parameters.AddWithValue("@LastName", LastName);
                        command.Parameters.AddWithValue("@Email", Email);
                        command.Parameters.AddWithValue("@Phone", Phone);
                        command.Parameters.AddWithValue("@Address", Address);
                        command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                        command.Parameters.AddWithValue("@Gender", Gender);
                        command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
                        if (ImagePath != string.Empty)
                            command.Parameters.AddWithValue("@ImagePath", ImagePath);
                        else
                            command.Parameters.AddWithValue("@ImagePath", DBNull.Value);


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

        static public bool UpdatePerson(int PersonID, string NationalNo, string FirstName,
            string SecondName, string ThirdName, string LastName, DateTime DateOfBirth,
            bool Gender, string Address, string Phone, string Email
            , int NationalityCountryID, string ImagePath)
        {
            int RowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"UPDATE People SET NationalNo = @NationalNo, FirstName = @FirstName,
                SecondName = @SecondName, ThirdName = @ThirdName, LastName = @LastName,
                Email = @Email, Phone = @Phone, Address = @Address, DateOfBirth = @DateOfBirth,
                Gender = @Gender, NationalityCountryID = @NationalityCountryID, ImagePath = @ImagePath
                WHERE PersonID = @PersonID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NationalNo", NationalNo);
                        command.Parameters.AddWithValue("@FirstName", FirstName);
                        command.Parameters.AddWithValue("@SecondName", SecondName);
                        command.Parameters.AddWithValue("@ThirdName", ThirdName);
                        command.Parameters.AddWithValue("@LastName", LastName);
                        command.Parameters.AddWithValue("@Email", Email);
                        command.Parameters.AddWithValue("@Phone", Phone);
                        command.Parameters.AddWithValue("@Address", Address);
                        command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                        command.Parameters.AddWithValue("@Gender", Gender);
                        command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
                        if (ImagePath != string.Empty)
                            command.Parameters.AddWithValue("@ImagePath", ImagePath);
                        else
                            command.Parameters.AddWithValue("@ImagePath", DBNull.Value);

                                
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

        public static bool DeletePerson(int PersonID)
        {
            int RowsAffected = 0;
            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "DELETE FROM People WHERE PersonID = @PersonID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);
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

        public static DataTable GetAllPersons()
        {
            DataTable dt = new DataTable();
            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM People";
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

        public static bool IsPersonExist(int PersonID)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT found = 1 FROM People WHERE PersonID = @PersonID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("PersonID", PersonID);
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

        public static bool IsPersonExist(string NationalNo)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT found = 1 FROM People WHERE NationalNo = @NationalNo";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NationalNo", NationalNo);
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
