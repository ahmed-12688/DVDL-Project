using DataAccess_Layer;
using System;
using System.Data;
using System.Net.Http.Headers;

namespace Business_Layer
{
    public class clsLocalDrivingLicenseApplication : clsApplication
    {
        public enum enMode { Addnew, Update }

        public int LDLAppID { get; set; }
        public int LicenseClassID { get; set; }
        public clsLicenseClass LicenseClassInfo;

        public string PersonFullName
        {
            get
            {
                return base.PersonInfo.FullName;
            }

        }


        public enMode Mode;

        public clsLocalDrivingLicenseApplication()
        {
            this.LDLAppID = -1;
            this.LicenseClassID = -1;
            this.Mode = enMode.Addnew;
        }

        private clsLocalDrivingLicenseApplication(int LDLAppID, int ApplicationID, int ApplicantPersonID,
            DateTime ApplicationDate, int ApplicationTypeID,
             byte ApplicationStatus, DateTime LastStatusDate,
             decimal PaidFees, int CreatedByUserID, int LicenseClassID)
            : base(ApplicationID, ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)
        {
            this.LDLAppID = LDLAppID;
            this.LicenseClassID = LicenseClassID;
            this.LicenseClassInfo = clsLicenseClass.Find(LicenseClassID);
            this.Mode = enMode.Update;
        }

        public static clsLocalDrivingLicenseApplication FindByLocalDrivingAppLicenseID(int LDLAppID)
        {
            int ApplicationID = -1;
            int LicenseClassID = -1;
            bool IsFound = clsLocalDrivingLicenseApplicationDataAccess.FindLocalDrivingLicenseApplications
                (LDLAppID, ref ApplicationID, ref LicenseClassID);


            if (IsFound)
            {
                //now we find the base application
                clsApplication Application = clsApplication.FindApplicationByApplicationID(ApplicationID);

                //we return new object of that person with the right data
                return new clsLocalDrivingLicenseApplication(
                    LDLAppID, Application.ApplicationID,
                    Application.ApplicantPersonID,
                                     Application.ApplicationDate, Application.ApplicationTypeID,
                                    Application.ApplicationStatus, Application.LastStatusDate,
                                     Application.PaidFees, Application.CreatedByUserID, LicenseClassID);
            }
            else
                return null;

        }

        public static clsLocalDrivingLicenseApplication FindByApplicationID(int ApplicationID)
        {
            int LDLAppID = -1;
            int LicenseClassID = -1;

            bool IsFound = clsLocalDrivingLicenseApplicationDataAccess.FindLocalDrivingLicenseApplicationsAppID
                (ApplicationID, ref LDLAppID, ref LicenseClassID);


            if (IsFound)
            {
                //now we find the base application
                clsApplication Application = clsApplication.FindApplicationByApplicationID(ApplicationID);

                //we return new object of that person with the right data
                return new clsLocalDrivingLicenseApplication(
                    LDLAppID, Application.ApplicationID,
                    Application.ApplicantPersonID,
                                     Application.ApplicationDate, Application.ApplicationTypeID,
                                    Application.ApplicationStatus, Application.LastStatusDate,
                                     Application.PaidFees, Application.CreatedByUserID, LicenseClassID);
            }
            else
                return null;

        }

        public bool DeleteLocalDrivingLicenseApplication(int LDLAppID)
        {
            bool IsLocalDrivingApplicationDeleted = false;
            bool IsBaseApplicationDeleted = false;
            //First we delete the Local Driving License Application
            IsLocalDrivingApplicationDeleted = clsLocalDrivingLicenseApplicationDataAccess.DeleteLocalDrivingLicenseApplications(LDLAppID);

            if (!IsLocalDrivingApplicationDeleted)
                return false;
            //Then we delete the base Application
            IsBaseApplicationDeleted = base.DeleteApplcation();
            return IsBaseApplicationDeleted;

        }

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            return clsLocalDrivingLicenseApplicationDataAccess.GetAllLocalDrivingLicenseApplicationss();
        }

        public static bool IsLocalDrivingLicenseApplicationExist(int LDLAppID)
        {
            return clsLocalDrivingLicenseApplicationDataAccess.IsLocalDrivingLicenseApplicationsExist(LDLAppID);
        }

        private bool _AddNewLocalDrivingLicenseApplication()
        {

            this.LDLAppID = clsLocalDrivingLicenseApplicationDataAccess.AddNewLocalDrivingLicenseApplications(this.ApplicationID, this.LicenseClassID);
            return (this.LDLAppID != -1);
        }

        private bool _UpdateLocalDrivingLicenseApplication()
        {
            return (clsLocalDrivingLicenseApplicationDataAccess.UpdateLocalDrivingLicenseApplications(this.LDLAppID, this.ApplicationID, this.LicenseClassID));
        }

        public bool Save()
        {
            base.Mode = (clsApplication.enMode)Mode;
            if (!base.Save())
                return false;



            switch (Mode)
            {
                case enMode.Addnew:
                    if (_AddNewLocalDrivingLicenseApplication())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    if (_UpdateLocalDrivingLicenseApplication())
                        return true;
                    else
                        return false;


            }
            return false;
        }

        public byte TotalTrails(clsTestType.enTestType type)
        {
            return clsLocalDrivingLicenseApplicationDataAccess.TotalTrialsPerTest(this.LDLAppID, (int)type);
        }

        public byte NumberOfPassedTests()
        {
            return clsLocalDrivingLicenseApplicationDataAccess.NumberOfPassedTests(this.LDLAppID);
        }

        public bool DoesPassTestType(clsTestType.enTestType type)
        {
            return clsLocalDrivingLicenseApplicationDataAccess.DoesPassTestType(this.LDLAppID, (int)type);
        }

        public bool DoesAttendTestType(clsTestType.enTestType type)
        {
            return clsLocalDrivingLicenseApplicationDataAccess.DoesAttendTestType(this.LDLAppID, (int)type);
        }

        public static bool DoesPassAllTests(int LDLAppID)
        {
            return clsLocalDrivingLicenseApplicationDataAccess.DoesPassAllTests(LDLAppID);
        }

        public bool CompleteAllTests()
        {
            return clsLocalDrivingLicenseApplicationDataAccess.CompleteAllTests(this.ApplicationID);
        }

        public bool IsLicenseIssued()
        {
            return clsLocalDrivingLicenseApplicationDataAccess.IsLicenseIssuee(this.LDLAppID);
        }

        public static bool IsLicenseIssued(int LDLAppID)
        {
            return clsLocalDrivingLicenseApplicationDataAccess.IsLicenseIssuee(LDLAppID);
        }


    }
}
