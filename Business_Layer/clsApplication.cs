using DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer
{
    public class clsApplication
    {
        public enum enMode { Addnew, Update };

        public int ApplicationID { get; set; }
        public int ApplicantPersonID { get; set; }
        public clsPerson PersonInfo { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int ApplicationTypeID { get; set; }
        public clsApplicationType ApplicationTypeInfo;

        public byte ApplicationStatus { get; set; }
        public DateTime LastStatusDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }

        public clsUser CreatedByUserInfo;


        public enMode Mode;

        public clsApplication(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate,
        int ApplicationTypeID, byte ApplicationStatus, DateTime LastStatusDate, decimal PaidFees,int CreatedByUserID)
        {
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.PersonInfo = clsPerson.FindPerson(ApplicantPersonID);
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeInfo = clsApplicationType.FindApplicationType((clsApplicationType.enApplicationTypes)ApplicationTypeID);
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedByUserInfo = clsUser.FindUser(CreatedByUserID);
            this.Mode = enMode.Update;
        }

        public clsApplication()
        {
            this.ApplicationID = -1;
            this.ApplicantPersonID = -1;
            this.ApplicationDate = DateTime.Now;
            this.ApplicationTypeID = -1;
            this.ApplicationStatus = 0;
            this.LastStatusDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;
            this.Mode = enMode.Addnew;
        }

        public static clsApplication FindApplicationByApplicationID(int ApplicationID)
        {

            int ApplicationPersonID = -1;
            DateTime ApplicationDate = DateTime.Now;
            int ApplicaitonTypeID = -1;
            byte ApplicaitonStatus = 0;
            DateTime LastStatusDate = DateTime.Now;
            decimal PaidFees = 0;
            int CreatedByUserID = -1;

            if (clsApplicationDataAccess.FindApplicationByApplicationID(ApplicationID, ref ApplicationPersonID, ref ApplicationDate,
              ref ApplicaitonTypeID, ref ApplicaitonStatus, ref LastStatusDate, ref PaidFees, ref CreatedByUserID))

                return new clsApplication(ApplicationID, ApplicationPersonID, ApplicationDate,
                 ApplicaitonTypeID, ApplicaitonStatus, LastStatusDate, PaidFees, CreatedByUserID);

            else
                return null;

        }

        public bool DeleteApplcation()
        {
            return clsApplicationDataAccess.DeletApplicaion(this.ApplicationID);
        }

        public static DataTable GetAllApplicaions()
        {
            return clsApplicationDataAccess.GetAllApplicaions();
        }

        public static bool IsApplicationExist(int ApplicationID)
        {
            return clsApplicationDataAccess.IsApplicaionExist(ApplicationID);
        }

        public bool CancelApplication()
        {
            return clsApplicationDataAccess.UpdateStatus(ApplicationID,2);
        }

        public bool SetComplete()

        {
            return clsApplicationDataAccess.UpdateStatus(ApplicationID, 3);
        }

        public static bool DoesPersonHaveActiveApplication(int PersonID, int ApplicationTypeID)
        {
            return clsApplicationDataAccess.DoesPersonHaveActiveApplication(PersonID, ApplicationTypeID);
        }

        public bool DoesPersonHaveActiveApplication(int ApplicationTypeID)
        {
            return DoesPersonHaveActiveApplication(this.ApplicantPersonID, ApplicationTypeID);
        }

        public static int GetActiveApplicationID(int PersonID, clsApplicationType.enApplicationTypes ApplicationTypeID)
        {
            return clsApplicationDataAccess.GetActiveApplicationID(PersonID, (int)ApplicationTypeID);
        }

        public static int GetActiveApplicationIDForLicenseClass(int PersonID, clsApplicationType.enApplicationTypes ApplicationTypeID, int LicenseClassID)
        {
            return clsApplicationDataAccess.GetActiveApplicationIDForLicenseClass(PersonID, (int)ApplicationTypeID, LicenseClassID);
        }

        public int GetActiveApplicationID(clsApplicationType.enApplicationTypes ApplicationTypeID)
        {
            return GetActiveApplicationID(this.ApplicantPersonID, ApplicationTypeID);
        }

        private bool _AddNewApplication()
        {
            this.ApplicationID = clsApplicationDataAccess.AddNewApplicaion( this.ApplicantPersonID, this.ApplicationDate,
                this.ApplicationTypeID, this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
            return (this.ApplicationID != -1);
        }

        private bool _UpdatePerson()
        {
            return (clsApplicationDataAccess.UpdateApplicaion(this.ApplicationID, this.ApplicantPersonID, this.ApplicationDate,
                this.ApplicationTypeID, this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID));
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Addnew:
                    if (_AddNewApplication())
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
