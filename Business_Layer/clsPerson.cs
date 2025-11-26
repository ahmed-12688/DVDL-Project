using DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer
{
    public class clsPerson
    {
        enum enMode { Addnew, Update}
        private int PersonID { get; set; }
        private string NationalNo { get; set; }
        private string FirstName { get; set; }
        private string SecondName { get; set; }
        private string ThirdName { get; set; }
        private string LastName { get; set; }
        private DateTime DateOfBirth { get; set; }
        private bool Gender { get; set; }
        private string Address { get; set; }
        private string Phone { get; set; }
        private string Email { get; set; }
        private int NationalityNumberID { get; set; }
        private string ImagePath { get; set; }
        private enMode Mode;

        public clsPerson(int PersonID, string NationalNo, string FirstName,
            string SecondName, string ThirdName, string LastName, DateTime DateOfBirth,
            bool Gender, string Address, string Phone, string Email
            , int NationalityNumberID, string ImagePath)
        {
            this.PersonID = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityNumberID = NationalityNumberID;
            this.ImagePath = ImagePath;
            this.Mode = enMode.Update;
        }

        public clsPerson()
        {
            this.PersonID = -1;
            this.NationalNo = string.Empty;
            this.FirstName = string.Empty;
            this.SecondName = string.Empty;
            this.ThirdName = string.Empty;
            this.LastName = string.Empty;
            this.DateOfBirth = DateTime.Now;
            this.Gender = true;
            this.Address = string.Empty;
            this.Phone = string.Empty;
            this.Email = string.Empty;
            this.NationalityNumberID = -1;
            this.ImagePath = string.Empty;
            this.Mode = enMode.Addnew;
        }


        public static clsPerson FindPerson(int PersonID)
        {
            string NationalNo = string.Empty;
            string FirstName = string.Empty;
            string SecondName = string.Empty;
            string ThirdName = string.Empty;
            string LastName = string.Empty;
            DateTime DateOfBirth = DateTime.Now;
            bool Gender = true;
            string Address = string.Empty;
            string Phone = string.Empty;
            string Email = string.Empty;
            int NationalityNumberID = -1;
            string ImagePath = string.Empty;

            if (clsPeopleDataAccess.FindPersonWithPersonID(PersonID, ref NationalNo, ref FirstName,
            ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth,
            ref Gender, ref Address, ref Phone, ref Email
            , ref NationalityNumberID, ref ImagePath))

                return new clsPerson(PersonID, NationalNo, FirstName,
             SecondName, ThirdName, LastName, DateOfBirth,
             Gender, Address, Phone, Email,
             NationalityNumberID, ImagePath);

            else
                return null;

        }

        public static bool DeletePerson(int PersonID)
        {
            return clsPeopleDataAccess.DeletePerson(PersonID);
        }

        public static DataTable GetAllPeople()
        {
            return clsPeopleDataAccess.GetAllPersons();
        }

        public static bool IsPersonExist(int PersonID)
        {
            return clsPeopleDataAccess.IsPersonExist(PersonID);
        }

        private bool _AddNewPerson()
        {
            this.PersonID = clsPeopleDataAccess.AddNewPerson(this.NationalNo, this.FirstName, this.SecondName,
                this.ThirdName, this.LastName, this.DateOfBirth, this.Gender, this.Address, this.Phone, this.Email
                , this.NationalityNumberID, this.ImagePath);
            return (this.PersonID != -1);
        }

        private bool _UpdatePerson()
        {
            return (clsPeopleDataAccess.UpdatePerson(this.PersonID, this.NationalNo, this.FirstName, this.SecondName,
                this.ThirdName, this.LastName, this.DateOfBirth, this.Gender, this.Address, this.Phone, this.Email
                , this.NationalityNumberID, this.ImagePath));
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Addnew:
                    if (_AddNewPerson())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    if (_UpdatePerson())
                        return true;
                    else
                        return false;


            }
            return false;
        }
    }
}
