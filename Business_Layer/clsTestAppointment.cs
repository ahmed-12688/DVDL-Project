using DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer
{
    public class clsTestAppointment
    {
        public enum enMode { Addnew, Update }
        public enMode Mode;
        public int TestAppointmentID { get; set; }
        public clsTestType.enTestType TestTypeID { get; set; }
        public int LDLAppID { get; set; }
        public clsLocalDrivingLicenseApplication LDLApp {  get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }
        public int RetakeTestApplicationID { get; set; }

        public clsTestAppointment(int TestAppointmentID, clsTestType.enTestType TestTypeID, int LDLAppID,
         DateTime AppointmentDate, decimal PaidFees, int CreatedByUserID, bool IsLocked, int RetakeTestApplicationID)
        {
            this.TestAppointmentID = TestAppointmentID;
            this.TestTypeID = TestTypeID;
            this.LDLAppID = LDLAppID;
            this.LDLApp = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(this.LDLAppID);
            this.AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsLocked = IsLocked;
            this.RetakeTestApplicationID = RetakeTestApplicationID;
            this.Mode = enMode.Update;
        }

        public clsTestAppointment()
        {
            this.TestAppointmentID = -1;
            this.TestTypeID = clsTestType.enTestType.VisionTest;
            this.LDLAppID = -1;
            this.AppointmentDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;
            this.IsLocked = false;
            this.RetakeTestApplicationID = -1;

            this.Mode = enMode.Addnew;
        }

        public static clsTestAppointment FindTestAppointment(int TestAppointmentID)
        {
            int TestTypeID = 1;
            int LDLAppID = -1;
            DateTime AppointmentDate = DateTime.Now;
            decimal PaidFees = 0;
            int CreatedByUserID = -1;
            bool IsLocked = false;
            int RetakeTestApplicationID = -1;


            if (clsTestAppointmentDataAccess.FindTestAppointment(TestAppointmentID, ref (TestTypeID), ref LDLAppID,
                ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeTestApplicationID))

                return new clsTestAppointment(TestAppointmentID, (clsTestType.enTestType)TestTypeID, LDLAppID,
                AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);

            else
                return null;

        }

        public static bool DeleteTestAppointment(int TestAppointmentID)
        {
            return clsTestAppointmentDataAccess.DeleteTestAppointment(TestAppointmentID);
        }

        public static DataTable GetAllTestAppointments()
        {
            return clsTestAppointmentDataAccess.GetAllTestAppointments();
        }

        public static DataTable GetAllTestAppointmentsForOneLDLApp(int LDLApp)
        {
            return clsTestAppointmentDataAccess.GetAllTestAppointmentsForOneLDLApp(LDLApp);
        }

        public static DataTable GetAllTestAppointmentsForSpecificLDLAppAndTestType(int LDLApp,int TestID)
        {
            return clsTestAppointmentDataAccess.GetAllTestAppointmentsForSpecificLDLAppAndTestType(LDLApp, TestID);
        }

        public static bool IsTestAppointmentExist(int TestAppointmentID)
        {
            return clsTestAppointmentDataAccess.IsTestAppointmentxist(TestAppointmentID);
        }

        private bool _AddNewTestAppointment()
        {
            this.TestAppointmentID = clsTestAppointmentDataAccess.AddNewTestAppointment((int)this.TestTypeID,this.LDLAppID,
                this.AppointmentDate,this.PaidFees,this.CreatedByUserID,this.IsLocked,this.RetakeTestApplicationID);
            return (this.TestAppointmentID != -1);
        }

        private bool _UpdateTestAppointment()
        {
            return (clsTestAppointmentDataAccess.UpdateTestAppointment(this.TestAppointmentID, (int)this.TestTypeID, this.LDLAppID,
                this.AppointmentDate, this.PaidFees, this.CreatedByUserID, this.IsLocked, this.RetakeTestApplicationID));
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Addnew:
                    if (_AddNewTestAppointment())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    if (_UpdateTestAppointment())
                        return true;
                    else
                        return false;


            }
            return false;
        }

        public bool UpdateTestAppointmentDate(DateTime newdate)
        {
            return clsTestAppointmentDataAccess.UpdateTestAppointmentDate(this.TestAppointmentID, newdate);
        }

        public static bool LockTheAppointment(int TestAppID)
        {
            return clsTestAppointmentDataAccess.LockTheAppointment(TestAppID);
        }
    }
}
