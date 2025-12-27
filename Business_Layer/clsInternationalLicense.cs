using System;
using System.Data;
using DataAccess_Layer;

namespace Business_Layer
{
    public class clsInternationalLicense
    {
        public enum enMode { AddNew, Update }

        public int InternationalLicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int IssuedUsingLocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }

        public enMode Mode { get; set; }

        private clsInternationalLicense(int InternationalLicenseID, int ApplicationID, int DriverID,
        int IssuedUsingLocalLicenseID, DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {
            this.InternationalLicenseID = InternationalLicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;
            this.CreatedByUserID = CreatedByUserID;

            Mode = enMode.Update;
        }

        public clsInternationalLicense()
        {
            InternationalLicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            IssuedUsingLocalLicenseID = -1;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now.AddYears(1);
            IsActive = true;
            CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }

        public static clsInternationalLicense Find(int ID)
        {
            int ApplicationID = -1, DriverID = -1,
                IssuedUsingLocalLicenseID = -1, CreatedByUserID = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            bool IsActive = false;

            if (clsInternationalLicenseDataAccess.FindInternationalLicense(
                ID, ref ApplicationID, ref DriverID,
                ref IssuedUsingLocalLicenseID,
                ref IssueDate, ref ExpirationDate,
                ref IsActive, ref CreatedByUserID))
            {
                return new clsInternationalLicense(
                    ID, ApplicationID, DriverID,
                    IssuedUsingLocalLicenseID,
                    IssueDate, ExpirationDate,
                    IsActive, CreatedByUserID);
            }

            return null;
        }

        private bool _Add()
        {
            InternationalLicenseID =
                clsInternationalLicenseDataAccess.AddNewInternationalLicense(
                    ApplicationID, DriverID,
                    IssuedUsingLocalLicenseID,
                    IssueDate, ExpirationDate,
                    IsActive, CreatedByUserID);

            return (InternationalLicenseID != -1);
        }

        private bool _Update()
        {
            return clsInternationalLicenseDataAccess
                .UpdateInternationalLicense(InternationalLicenseID, IsActive);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_Add())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _Update();
            }

            return false;
        }

        public static bool Delete(int ID)
        {
            return clsInternationalLicenseDataAccess.DeleteInternationalLicense(ID);
        }

        public static DataTable GetAll()
        {
            return clsInternationalLicenseDataAccess.GetAllInternationalLicenses();
        }
    }
}
