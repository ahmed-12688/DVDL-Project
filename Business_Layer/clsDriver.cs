using DataAccess_Layer;
using System;
using System.Data;

namespace Business_Layer
{
    public class clsDriver
    {
        public enum enMode { AddNew, Update }

        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }

        public enMode Mode { get; set; }

        private clsDriver(int DriverID, int PersonID,
            int CreatedByUserID, DateTime CreatedDate)
        {
            this.DriverID = DriverID;
            this.PersonID = PersonID;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = CreatedDate;

            this.Mode = enMode.Update;
        }

        public clsDriver()
        {
            this.DriverID = -1;
            this.PersonID = -1;
            this.CreatedByUserID = -1;
            this.CreatedDate = DateTime.Now;

            this.Mode = enMode.AddNew;
        }

        public static clsDriver FindDriverByDriverID(int DriverID)
        {
            int PersonID = -1;
            int CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Now;

            if (clsDriverDataAccess.FindDriverByDriverID(DriverID,
                ref PersonID, ref CreatedByUserID, ref CreatedDate))
            {
                return new clsDriver(DriverID, PersonID,
                    CreatedByUserID, CreatedDate);
            }
            else
                return null;
        }

        public static clsDriver FindDriverByPersonID(int PersonID)
        {
            int DriverID = -1;
            int CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Now;

            if (clsDriverDataAccess.FindDriverByPersonID(PersonID,
                ref DriverID, ref CreatedByUserID, ref CreatedDate))
            {
                return new clsDriver(DriverID, PersonID,
                    CreatedByUserID, CreatedDate);
            }
            else
                return null;
        }


        public static bool DeleteDriver(int DriverID)
        {
            return clsDriverDataAccess.DeleteDriver(DriverID);
        }

        public static DataTable GetAllDrivers()
        {
            return clsDriverDataAccess.GetAllDrivers();
        }

        public static bool IsDriverExist(int DriverID)
        {
            return clsDriverDataAccess.IsDriverExist(DriverID);
        }

        public static bool IsPersonAlreadyDriver(int PersonID)
        {
            return clsDriverDataAccess.IsPersonAlreadyDriver(PersonID);
        }

        private bool _AddNewDriver()
        {
            this.DriverID = clsDriverDataAccess.AddNewDriver(
                this.PersonID,
                this.CreatedByUserID,
                this.CreatedDate);

            return (this.DriverID != -1);
        }

        private bool _UpdateDriver()
        {
            return clsDriverDataAccess.UpdateDriver(
                this.DriverID,
                this.PersonID,
                this.CreatedByUserID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDriver())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return _UpdateDriver();


            }
            return false;
        }
    }
}
