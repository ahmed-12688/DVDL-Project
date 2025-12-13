using DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Business_Layer.clsPerson;

namespace Business_Layer
{
    public class clsUser
    {
        public enum enMode { Addnew, Update }

        public int UserID { get; set; }
        public int PersonID { get; set; }
        public clsPerson PersonInfo;
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public enMode Mode;


        public clsUser()
        {
            this.UserID = -1;
            this.PersonID = -1;
            this.UserName = string.Empty;
            this.Password = string.Empty;
            this.IsActive = true;
            this.Mode = enMode.Addnew;
        }

        public clsUser(int userId, int personID, string userName, string password, bool isActive)
        {
            this.UserID = userId;
            this.PersonID = personID;
            this.PersonInfo = clsPerson.FindPerson(PersonID);
            this.UserName = userName;
            this.Password = password;
            this.IsActive = isActive;
            this.Mode = enMode.Update;
        }

        public static clsUser FindUser(int UserID)
        {
            int PersonID = -1;
            string UserName = string.Empty;
            string Password = string.Empty;
            bool IsActive = true;

            if (clsUserDataAccess.FindUser(UserID, ref PersonID, ref UserName,
            ref Password, ref IsActive))
            {
                return new clsUser(UserID, PersonID, UserName,
                       Password, IsActive);
            }

            else
                return null;

        }

        public static clsUser FindUser(string UserName)
        {
            int PersonID = -1;
            int UserID = -1;
            string Password = string.Empty;
            bool IsActive = true;

            if (clsUserDataAccess.FindUser(UserName, ref PersonID, ref UserID,
            ref Password, ref IsActive))
            {
                return new clsUser(PersonID, UserID, UserName,
                       Password, IsActive);
            }

            else
                return null;

        }

        public static bool DeleteUser(int UserID)
        {
            return clsUserDataAccess.DeleteUser(UserID);
        }

        public static DataTable GetAllUsers()
        {
            return clsUserDataAccess.GetAllUsers();
        }

        public static bool IsUserExist(int UserID)
        {
            return clsUserDataAccess.IsUserExist(UserID);
        }

        public static bool IsUserExistByPersonID(int PersonID)
        {
            return clsUserDataAccess.IsUserExistByPersonID(PersonID);
        }

        public static bool IsUserExistByUserName(string UserName)
        {
            return clsUserDataAccess.IsUserExistByUserName(UserName);
        }

        public static bool ChangePassword(int UserID, string NewPassword)
        {
            return clsUserDataAccess.ChangePassword(UserID, NewPassword);
        }

        private bool _AddNewUser()
        {
            this.UserID = clsUserDataAccess.AddNewUser(this.PersonID, this.UserName, this.Password,
                this.IsActive);
            return (this.UserID != -1);
        }

        private bool _UpdateUser()
        {
            return (clsUserDataAccess.UpdateUser(this.UserID, this.PersonID, this.UserName, this.Password,
                this.IsActive));
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Addnew:
                    if (_AddNewUser())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    if (_UpdateUser())
                        return true;
                    else
                        return false;


            }
            return false;
        }




    }
}
