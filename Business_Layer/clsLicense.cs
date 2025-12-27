using DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Data;

namespace Business_Layer
{
    public class clsLicense
    {
        public enum enMode { Addnew, Update }
        public enum enIssueReason { FirstTime = 1, Renew, ReplacementforDamaged, ReplacementforLost }

        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public clsPerson PersonInfo { get; set; }
        public int LicenseClass { get; set; }
        public clsLicenseClass LicenseClassInfo { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsActive { get; set; }
        public enIssueReason IssueReason { get; set; }
        public int CreatedByUserID { get; set; }

        public enMode Mode;


        public clsLicense(int LicenseID, int ApplicationID, int DriverID, int LicenseClass,
            DateTime IssueDate, DateTime ExpirationDate, string Notes, decimal PaidFees,
            bool IsActive, enIssueReason IssueReason, int CreatedByUserID)
        {
            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.PersonInfo = clsDriver.FindDriverByDriverID(DriverID).PersonInfo;
            this.LicenseClass = LicenseClass;
            this.LicenseClassInfo = clsLicenseClass.Find(LicenseClass);
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.CreatedByUserID = CreatedByUserID;
            this.Mode = enMode.Update;
        }

        public clsLicense()
        {
            this.LicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.LicenseClass = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.Notes = string.Empty;
            this.PaidFees = 0;
            this.IsActive = true;
            this.IssueReason = enIssueReason.FirstTime;
            this.CreatedByUserID = -1;
            this.Mode = enMode.Addnew;
        }

        public static clsLicense FindLicense(int LicenseID)
        {
            int ApplicationID = -1;
            int DriverID = -1;
            int LicenseClass = -1;
            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now;
            string Notes = string.Empty;
            decimal PaidFees = 0;
            bool IsActive = false;
            byte IssueReason = 0;
            int CreatedByUserID = -1;

            if (clsLicenseDataAccess.FindLicense(LicenseID, ref ApplicationID, ref DriverID,
                ref LicenseClass, ref IssueDate, ref ExpirationDate, ref Notes, ref PaidFees,
                ref IsActive, ref IssueReason, ref CreatedByUserID))
            {
                return new clsLicense(LicenseID, ApplicationID, DriverID, LicenseClass,
                    IssueDate, ExpirationDate, Notes, PaidFees, IsActive, (enIssueReason)IssueReason, CreatedByUserID);
            }
            else
                return null;
        }


        public static clsLicense FindLicenseByApplicationID(int ApplicationID)
        {
            int LicenseID = -1;
            int DriverID = -1;
            int LicenseClass = -1;
            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now;
            string Notes = string.Empty;
            decimal PaidFees = 0;
            bool IsActive = false;
            byte IssueReason = 0;
            int CreatedByUserID = -1;

            if (clsLicenseDataAccess.FindLicenseByApplicationID(ApplicationID, ref LicenseID, ref DriverID,
                ref LicenseClass, ref IssueDate, ref ExpirationDate, ref Notes, ref PaidFees,
                ref IsActive, ref IssueReason, ref CreatedByUserID))
            {
                return new clsLicense(LicenseID, ApplicationID, DriverID, LicenseClass,
                    IssueDate, ExpirationDate, Notes, PaidFees, IsActive, (enIssueReason)IssueReason, CreatedByUserID);
            }
            else
                return null;
        }

        public static bool DeleteLicense(int LicenseID)
        {
            return clsLicenseDataAccess.DeleteLicense(LicenseID);
        }

        public static DataTable GetAllLicenses()
        {
            return clsLicenseDataAccess.GetAllLicenses();
        }

        private bool _AddNewLicense()
        {
            //check if the driver exist first if not create one
            int PersonID = clsApplication.FindApplicationByApplicationID(this.ApplicationID).ApplicantPersonID;
            if (!clsDriver.IsPersonAlreadyDriver(PersonID))
            {
                //create one

                clsDriver driver = new clsDriver();
                driver.PersonID = PersonID;
                driver.CreatedDate = DateTime.Now;
                driver.CreatedByUserID = CreatedByUserID;

                if (!driver.Save())
                {
                    return false;
                }
                this.DriverID = driver.DriverID;
            }
            else
                this.DriverID = clsDriver.FindDriverByPersonID(PersonID).DriverID;

            this.LicenseID = clsLicenseDataAccess.AddNewLicense(
                this.ApplicationID, this.DriverID, this.LicenseClass,
                this.IssueDate, this.ExpirationDate, this.Notes,
                this.PaidFees, this.IsActive, (byte)this.IssueReason, this.CreatedByUserID);

            return (this.LicenseID != -1);
        }

        private bool _UpdateLicense()
        {
            return clsLicenseDataAccess.UpdateLicense(
                this.LicenseID, this.ApplicationID, this.DriverID, this.LicenseClass,
                this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees,
                this.IsActive, (byte)this.IssueReason);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Addnew:
                    if (_AddNewLicense())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdateLicense();
            }
            return false;
        }

        public bool IsLicenseIsActiveAndClass3()
        {
            return clsLicenseDataAccess.IsLicesneIsAvtiveAndHisTypeis_Class3_(this.LicenseID);
        }

        public int CreateInternationalApplication(int CreatedBy)
        {
            clsApplication application = new clsApplication();
            application.ApplicantPersonID = this.PersonInfo.PersonID;
            application.ApplicationDate = DateTime.Now;
            application.ApplicationTypeID = (int)clsApplicationType.enApplicationTypes.NewInternationalLicense;
            application.ApplicationStatus = 1;
            application.LastStatusDate = DateTime.Now;
            application.PaidFees = clsApplicationType.FindApplicationType
                (clsApplicationType.enApplicationTypes.NewInternationalLicense).Fees;
            application.CreatedByUserID = CreatedBy;

            if (!application.Save())
                return -1;
            return application.ApplicationID;
        }
        public int IssueInternationalLicense(int appid,int CreatedBy)
        {

            clsInternationalLicense International = new clsInternationalLicense();
            International.ApplicationID = appid;
            International.DriverID = this.DriverID;
            International.IssuedUsingLocalLicenseID = this.LicenseID;
            International.IssueDate = DateTime.Now;
            International.ExpirationDate = DateTime.Now.AddYears(1);
            International.IsActive = true;
            International.CreatedByUserID = CreatedBy;

            if (!International.Save())
                return -1;

            return International.InternationalLicenseID;
        }

        public bool DeActiveLicense()
        {
            return clsLicenseDataAccess.DeActiveLicense(this.LicenseID);
        }
  
    }
}
