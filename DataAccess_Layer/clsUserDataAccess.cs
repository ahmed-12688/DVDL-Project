using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer
{
    public class clsUserDataAccess
    {
        static public bool FindUser(int UserID, ref int PersonID, ref string UserName,
        ref string Password, ref bool IsActive)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM Users WHERE UserID = @UserID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@UserID", UserID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;
                                PersonID = (int)reader["PersonID"];
                                UserName = reader["UserName"].ToString();
                                Password = reader["Password"].ToString();
                                IsActive = (bool)(reader["IsActive"]);
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

        static public int AddNewUser(int PersonID ,string UserName,
        string Password, bool IsActive)
        {
            int UserID = -1;
            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"INSERT INTO Users (PersonID,UserName,Password,IsActive)     
                    values (@PersonID,@UserName,@Password,@IsActive);
                    SELECT SCOPE_IDENTITY();";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);
                        command.Parameters.AddWithValue("@UserName", UserName);
                        command.Parameters.AddWithValue("@Password", Password);
                        command.Parameters.AddWithValue("@IsActive", IsActive);

                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                        {
                            UserID = InsertedID;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return -1;
            }

            return UserID;
        }

        static public bool UpdateUser(int UserID, int PersonID, string UserName,
        string Password, bool IsActive)
        {
            int RowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"UPDATE Users SET PersonID = @PersonID, UserName = @UserName,
                    Password = @Password, IsActive = @IsActive WHERE UserID = @UserID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);
                        command.Parameters.AddWithValue("@UserName", UserName);
                        command.Parameters.AddWithValue("@Password", Password);
                        command.Parameters.AddWithValue("@IsActive", IsActive);
                        command.Parameters.AddWithValue("@UserID", UserID);


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

        public static bool DeleteUser(int UserID)
        {
            int RowsAffected = 0;
            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "DELETE FROM Users WHERE UserID = @UserID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);
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

        public static DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();
            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    string query = @"SELECT U.UserID , U.PersonID,
                    (P.FirstName + ' ' + P.SecondName + ' '+ P.ThirdName+ ' ' + P.LastName) as FullName, 
                    U.UserName, U.IsActive FROM Users U JOIN People P on P.PersonID = U.PersonID";
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

        public static bool IsUserExist(int UserID)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT found = 1 FROM Users WHERE UserID = @UserID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("UserID", UserID);
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

        public static bool IsUserExistByPersonID(int PersonID)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT found = 1 FROM Users WHERE PersonID = @PersonID";
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

        public static bool IsUserExistByUserName(string UserName)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT found = 1 FROM Users WHERE UserName = @UserName";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("UserName", UserName);
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
