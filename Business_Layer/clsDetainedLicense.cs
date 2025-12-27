using System;
using System.Data;
using DataAccess_Layer;

namespace Business_Layer
{
    public class clsDetainedLicense
    {
        public enum enMode { AddNew, Update }

        public int DetainID { get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public decimal FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsReleased { get; set; }

        public DateTime? ReleaseDate { get; set; }
        public int? ReleasedByUserID { get; set; }
        public int? ReleaseApplicationID { get; set; }

        public enMode Mode { get; set; }

        public clsDetainedLicense()
        {
            DetainID = -1;
            LicenseID = -1;
            DetainDate = DateTime.Now;
            FineFees = 0;
            CreatedByUserID = -1;
            IsReleased = false;

            ReleaseDate = null;
            ReleasedByUserID = null;
            ReleaseApplicationID = null;

            Mode = enMode.AddNew;
        }

        private clsDetainedLicense(
            int DetainID,
            int LicenseID,
            DateTime DetainDate,
            decimal FineFees,
            int CreatedByUserID,
            bool IsReleased,
            DateTime? ReleaseDate,
            int? ReleasedByUserID,
            int? ReleaseApplicationID)
        {
            this.DetainID = DetainID;
            this.LicenseID = LicenseID;
            this.DetainDate = DetainDate;
            this.FineFees = FineFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsReleased = IsReleased;
            this.ReleaseDate = ReleaseDate;
            this.ReleasedByUserID = ReleasedByUserID;
            this.ReleaseApplicationID = ReleaseApplicationID;

            Mode = enMode.Update;
        }

        public static clsDetainedLicense Find(int DetainID)
        {
            int LicenseID = -1, CreatedByUserID = -1;
            DateTime DetainDate = DateTime.Now;
            decimal FineFees = 0;
            bool IsReleased = false;
            DateTime? ReleaseDate = null;
            int? ReleasedByUserID = null;
            int? ReleaseApplicationID = null;

            if (clsDetainedLicenseDataAccess.FindDetainedLicense(
                DetainID,
                ref LicenseID,
                ref DetainDate,
                ref FineFees,
                ref CreatedByUserID,
                ref IsReleased,
                ref ReleaseDate,
                ref ReleasedByUserID,
                ref ReleaseApplicationID))
            {
                return new clsDetainedLicense(
                    DetainID, LicenseID, DetainDate,
                    FineFees, CreatedByUserID, IsReleased,
                    ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
            }

            return null;
        }

        public static clsDetainedLicense FindByLicenseID(int LicenseID)
        {
            int DetainID = -1;
            DateTime DetainDate = DateTime.Now;
            decimal FineFees = 0;
            int CreatedByUserID = -1;

            if (clsDetainedLicenseDataAccess.FindDetainedLicenseByLicenseID(
                LicenseID,
                ref DetainID,
                ref DetainDate,
                ref FineFees,
                ref CreatedByUserID))
            {
                clsDetainedLicense detainedLicense = new clsDetainedLicense();

                detainedLicense.DetainID = DetainID;
                detainedLicense.LicenseID = LicenseID;
                detainedLicense.DetainDate = DetainDate;
                detainedLicense.FineFees = FineFees;
                detainedLicense.CreatedByUserID = CreatedByUserID;
                detainedLicense.IsReleased = false;
                detainedLicense.Mode = enMode.Update;

                return detainedLicense;
            }

            return null;
        }

        private bool _Add()
        {
            DetainID =
                clsDetainedLicenseDataAccess.AddNewDetainedLicense(
                    LicenseID, DetainDate, FineFees,
                    CreatedByUserID, IsReleased);

            return (DetainID != -1);
        }

        public bool Release(int ReleasedByUserID, int ReleaseApplicationID)
        {
            if (IsReleased)
                return false;

            bool Result =
                clsDetainedLicenseDataAccess.ReleaseDetainedLicense(
                    DetainID, DateTime.Now,
                    ReleasedByUserID, ReleaseApplicationID);

            if (Result)
            {
                IsReleased = true;
                this.ReleasedByUserID = ReleasedByUserID;
                this.ReleaseApplicationID = ReleaseApplicationID;
                ReleaseDate = DateTime.Now;
            }

            return Result;
        }

        public bool Save()
        {
            if (Mode == enMode.AddNew)
            {
                if (_Add())
                {
                    Mode = enMode.Update;
                    return true;
                }
                return false;
            }

            return false;
        }

        public static DataTable GetAll()
        {
            return clsDetainedLicenseDataAccess.GetAllDetainedLicenses();
        }

        public static bool IsLiceseDetained(int LiceseID)
        {
            return clsDetainedLicenseDataAccess.IsLicenseDetained(LiceseID);
        }
    }
}
